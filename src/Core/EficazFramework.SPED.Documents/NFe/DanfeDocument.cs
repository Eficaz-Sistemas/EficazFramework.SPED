using System.Globalization;
using System.Text;
using EficazFramework.SPED.Documents.Common;
using EficazFramework.SPED.Schemas.NFe;

namespace EficazFramework.SPED.Documents.NFe;

/// <summary>
/// Documento QuestPDF que gera o DANFE (Documento Auxiliar da NF-e, modelo 55) conforme o
/// leiaute da NT 2026.010 (Reforma Tributária: IBS, CBS e IS), mantendo os campos do layout v4.00.
/// A orientação (retrato/paisagem/simplificado) é determinada automaticamente pelo campo
/// <c>IdentificacaoNFe.TipoImpressao</c>.
/// </summary>
/// <remarks>
/// <para>O documento apenas apresenta o que consta no XML: campos e quadros facultativos sem conteúdo
/// (fatura/duplicatas, FCP, DIFAL, ICMS monofásico, IBS/CBS monofásicos, ISSQN, transporte, QR Code)
/// são suprimidos, e nenhuma informação ausente é inferida.</para>
/// <para>O campo "Tipo de Regime de Apuração do IBS e da CBS" ainda não possui tag definida na NT
/// e, por isso, não é impresso.</para>
/// </remarks>
public sealed class DanfeDocument : IDocument
{
    // ── Cores ─────────────────────────────────────────────────────────────────
    private const string CorBorda = "#000000";
    private const string CorPrimaria = "#1a3a5c";     // azul SPED (títulos)
    private const string CorFacultativo = "#d0dce8";  // azul SPED claro (quadros facultativos)
    private const string CorRotulo = "#555555";
    private const string CorSecundaria = "#666666";
    private const string CorDivisoria = "#BBBBBB";
    private const string CorMarcaDagua = "#DDDDDD";

    // ── Tamanhos de fonte ─────────────────────────────────────────────────────
    private const float FonteRotulo = 5.5f;
    private const float FonteValor = 7.5f;
    private const float FonteTitulo = 7f;
    private const float FonteTabela = 6.5f;
    private const float FonteTabelaSecundaria = 5.5f;

    private const float Borda = 0.5f;
    private const string Traco = "-";

    private static readonly CultureInfo PtBr = CultureInfo.GetCultureInfo("pt-BR");

    private readonly ProcessoNFe _processo;
    private readonly DanfeOptions _options;

    // Atalhos para os objetos mais acessados
    private InformacoesNFe Info => _processo.NFe.InformacoesNFe;
    private IdentificacaoNFe Ide => Info.IdentificacaoOperacao;
    private Emitente? Emit => Info.Emitente;
    private Destinatario? Dest => Info.Destinatario;
    private Totais? Tot => Info.Totais;
    private TotalICMS? ICMSTot => Tot?.ICMS;
    private InformacoesProtocolo? Prot => _processo.ProtocoloAutorizacao?.InformacoesProtocolo;
    private bool IsLandscape => Ide.TipoImpressao == TipoImpressao.Paisagem;
    private bool IsSimplificado => Ide.TipoImpressao == TipoImpressao.Simplificado;

    static DanfeDocument()
    {
        QuestPDF.Settings.License = LicenseType.Community;
    }

    public DanfeDocument(ProcessoNFe processo, DanfeOptions options)
    {
        _processo = processo;
        _options = options;
    }

    public DocumentMetadata GetMetadata() => new()
    {
        Title = $"DANFE {Ide.Numero}",
        Subject = "Documento Auxiliar da Nota Fiscal Eletrônica",
        Creator = "EficazFramework.SPED.Documents"
    };

    public DocumentSettings GetSettings() => DocumentSettings.Default;

    // =========================================================================
    // Compose — ponto de entrada do QuestPDF
    // =========================================================================
    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Size(IsLandscape ? PageSizes.A4.Landscape() : PageSizes.A4);
            page.MarginTop(4, Unit.Millimetre);
            page.MarginBottom(4, Unit.Millimetre);
            page.MarginLeft(6, Unit.Millimetre);
            page.MarginRight(6, Unit.Millimetre);
            page.PageColor(Colors.White);
            page.DefaultTextStyle(x => x.FontFamily("Lato").FontSize(FonteValor).FontColor(Colors.Black));

            if (_options.MostrarMarcaDagua)
            {
                page.Background().AlignCenter().AlignMiddle().Rotate(-45)
                    .Text("SEM VALOR FISCAL").FontSize(72).Bold().FontColor(CorMarcaDagua);
            }

            if (IsLandscape)
            {
                // Paisagem: a altura útil não comporta todos os quadros repetidos. Os quadros completos ficam na
                // primeira folha; as demais repetem só a identificação (emitente, DANFE e chave).
                page.Header().SkipOnce().PaddingBottom(2).Element(c => ComposeCabecalho(c, completo: false));
                page.Content().Column(col =>
                {
                    ComposeQuadros(col);
                    col.Item().Element(ComposeProdutos);
                });
            }
            else
            {
                // Retrato: todos os quadros acima dos itens se repetem em cada folha (canhoto só na primeira).
                page.Header().Column(ComposeQuadros);

                // Itens: ocupam o espaço entre o cabeçalho e o rodapé, em todas as folhas.
                page.Content().Element(ComposeProdutos);
            }

            // Rodapé: Dados Adicionais ancorados no fim de cada folha, seguidos da mensagem do usuário.
            page.Footer().Column(col =>
            {
                col.Item().Element(ComposeDadosAdicionais);
                if (_options.MensagemRodape is not null)
                    col.Item().PaddingTop(2).Element(c => _options.MensagemRodape(c));
            });
        });
    }


    /// <summary>Quadros acima da tabela de itens, na ordem do leiaute.</summary>
    private void ComposeQuadros(ColumnDescriptor col)
    {
        if (_options.ExibirCanhoto)
            col.Item().ShowOnce().Element(ComposeCanhoto);

        col.Item().Element(c => ComposeCabecalho(c, completo: true));
        col.Item().Element(ComposeDestinatario);
        col.Item().Element(ComposeFatura);
        col.Item().Element(ComposeTotaisProdutosNota);
        col.Item().Element(ComposeTotaisIcmsIpi);
        col.Item().Element(ComposeTotaisIbsCbsIs);
        col.Item().Element(ComposeIssqn);
        col.Item().Element(ComposeTransporte);
    }
    // =========================================================================
    // CANHOTO (facultativo)
    // =========================================================================
    private void ComposeCanhoto(IContainer c)
    {
        c.PaddingBottom(2).Column(outer =>
        {
            outer.Item().Background(CorFacultativo).Border(Borda).BorderColor(CorBorda).Row(row =>
            {
                row.RelativeItem(5).Column(col =>
                {
                    col.Item().Padding(2).Text(
                        $"RECEBEMOS DE {Emit?.RazaoSocial?.ToUpper(PtBr)} OS PRODUTOS/SERVIÇOS CONSTANTES DA NOTA FISCAL ELETRÔNICA INDICADA AO LADO")
                        .FontSize(FonteRotulo + 0.5f).Bold();
                    col.Item().BorderTop(Borda).BorderColor(CorBorda).Row(r =>
                    {
                        ComposeCelula(r.RelativeItem(1), new Cel("DATA DE RECEBIMENTO", null));
                        ComposeCelula(r.RelativeItem(3).BorderLeft(Borda).BorderColor(CorBorda),
                            new Cel("IDENTIFICAÇÃO E ASSINATURA DO RECEBEDOR", null));
                    });
                });
                row.RelativeItem(1).BorderLeft(Borda).BorderColor(CorBorda).Padding(3).AlignMiddle().Column(col =>
                {
                    col.Item().AlignCenter().Text("NF-e").Bold().FontSize(9);
                    col.Item().AlignCenter().Text($"Nº {NumeroFormatado()}").FontSize(FonteValor);
                    col.Item().AlignCenter().Text($"SÉRIE {Ide.Serie:D3}").FontSize(FonteValor);
                });
            });
            outer.Item().PaddingTop(2).LineHorizontal(Borda).LineColor(CorDivisoria);
        });
    }

    // =========================================================================
    // CABEÇALHO: emitente, DANFE, chave de acesso, natureza, protocolo, IE/CNPJ, CRT
    // =========================================================================
    private void ComposeCabecalho(IContainer c, bool completo)
    {
        c.Border(Borda).BorderColor(CorBorda).Column(box =>
        {
            box.Item().Row(row =>
            {
                row.RelativeItem(53).Row(esq =>
                {
                    esq.RelativeItem(3).Element(ComposeEmitente);
                    esq.RelativeItem(1.7f).BorderLeft(Borda).BorderColor(CorBorda).Element(ComposeBoxDanfe);
                });
                row.RelativeItem(47).BorderLeft(Borda).BorderColor(CorBorda).Element(ComposeChaveAcesso);
            });

            if (!completo)
                return;

            Linhas(box,
            [
                [
                    new Cel("NATUREZA DA OPERAÇÃO", Ide.NaturezaOperacao, 53),
                    new Cel("PROTOCOLO DE AUTORIZAÇÃO DE USO", ProtocoloTexto(), 47, Centro: true)
                ],
                [
                    new Cel("INSCRIÇÃO ESTADUAL", Seguro(() => Emit?.IEFormatado) ?? Emit?.InscricaoEstadual, 26.5f),
                    new Cel("INSCRIÇÃO ESTADUAL DO SUBST. TRIBUTÁRIO", Emit?.InscricaoEstadualST, 26.5f),
                    new Cel("CNPJ / CPF", Emit?.CNPJ_CPFFormatado, 47, Centro: true)
                ],
                [
                    new Cel("CÓDIGO DE REGIME TRIBUTÁRIO (CRT)", DescricaoCrt(Emit?.RegimeTributario), 53),
                    new Cel("TIPO DE REGIME DE APURAÇÃO DO IBS E DA CBS", null, 47, Azul: true, Vazia: !_options.ExibirQuadrosFacultativos)
                ]
            ]);
        });
    }

    private void ComposeEmitente(IContainer c)
    {
        var logo = _options.LogoEmitente ?? Emit?.Logo;
        var end = Emit?.Endereco;

        c.Padding(3).Row(row =>
        {
            if (logo is { Length: > 0 })
                row.ConstantItem(48).PaddingRight(3).AlignMiddle().MaxHeight(46).Image(logo).FitArea();

            row.RelativeItem().AlignMiddle().Column(col =>
            {
                col.Item().AlignCenter().Text(Emit?.RazaoSocial ?? string.Empty).Bold().FontSize(9);
                if (!string.IsNullOrWhiteSpace(Emit?.NomeFantasia) && Emit.NomeFantasia != Emit.RazaoSocial)
                    col.Item().AlignCenter().Text(Emit.NomeFantasia).FontSize(FonteValor);

                if (end is not null)
                {
                    col.Item().AlignCenter().Text(MontarEndereco(end.Logradouro, end.Numero, end.Complemento, end.Bairro))
                        .FontSize(FonteValor - 0.5f);
                    col.Item().AlignCenter().Text(
                        $"{end.MunicipioNome}/{end.UF} – CEP {end.CEPFormatado}" +
                        (string.IsNullOrWhiteSpace(end.Fone) ? "" : $" – Fone: {Seguro(() => end.FoneFormatado) ?? end.Fone}"))
                        .FontSize(FonteValor - 0.5f);
                }
            });
        });
    }

    private void ComposeBoxDanfe(IContainer c)
    {
        c.Padding(2).Column(col =>
        {
            col.Item().AlignCenter().Text("DANFE").Bold().FontSize(13);
            col.Item().AlignCenter().Text("DOCUMENTO AUXILIAR DA NOTA FISCAL ELETRÔNICA")
                .FontSize(FonteRotulo - 0.5f).FontColor(CorRotulo);

            col.Item().PaddingTop(3).Row(row =>
            {
                row.RelativeItem().AlignMiddle().Column(legenda =>
                {
                    legenda.Item().Text("0 - ENTRADA").FontSize(FonteRotulo);
                    legenda.Item().Text("1 - SAÍDA").FontSize(FonteRotulo);
                });
                row.ConstantItem(18).Height(16).Border(Borda).BorderColor(CorBorda).AlignMiddle().AlignCenter()
                    .Text(Ide.TipoOperacao == OperacaoNFe.Entrada ? "0" : "1").Bold().FontSize(10);
            });

            col.Item().PaddingTop(2).AlignCenter().Text($"Nº {NumeroFormatado()}").Bold().FontSize(FonteValor);
            col.Item().AlignCenter().Text($"SÉRIE {Ide.Serie:D3}").Bold().FontSize(FonteValor);
            col.Item().AlignCenter().Text(text =>
            {
                text.DefaultTextStyle(x => x.Bold().FontSize(FonteValor));
                text.Span("FOLHA ");
                text.CurrentPageNumber();
                text.Span("/");
                text.TotalPages();
            });

            if (IsSimplificado)
                col.Item().AlignCenter().Text("DANFE SIMPLIFICADO").FontSize(FonteRotulo).Italic();
        });
    }

    private void ComposeChaveAcesso(IContainer c)
    {
        var chave = Prot?.ChaveNFe ?? Info.Id?.Replace("NFe", "") ?? string.Empty;

        c.Column(col =>
        {
            var barras = Code128.SvgSubconjuntoC(chave);
            if (barras is not null)
                col.Item().PaddingTop(4).AlignCenter().Height(28).Svg(barras);

            col.Item().PaddingTop(3).Element(x => ComposeCelula(x.BorderTop(Borda).BorderColor(CorBorda),
                new Cel("CHAVE DE ACESSO", FormatarChave(chave), Negrito: true, Centro: true)));

            col.Item().PaddingHorizontal(3).PaddingBottom(3).AlignCenter().Text(
                "Consulta de autenticidade no portal nacional da NF-e www.nfe.fazenda.gov.br/portal ou no site da SEFAZ Autorizadora")
                .FontSize(FonteRotulo).FontColor(CorRotulo);
        });
    }

    // =========================================================================
    // DESTINATÁRIO / REMETENTE
    // =========================================================================
    private void ComposeDestinatario(IContainer c)
    {
        var end = Dest?.Endereco;
        var documento = Dest?.CNPJ_CPFFormatado;
        if (string.IsNullOrWhiteSpace(documento))
            documento = Dest?.idEstrangeiro;

        var emissao = Ide.DataHoraEmissao ?? Ide.DataEmissao;
        var saida = Ide.DataHoraSaidaEntrada ?? Ide.DataSaidaEntrada;
        var horaSaida = Ide.DataHoraSaidaEntrada?.ToString("HH:mm:ss", PtBr)
            ?? (Ide.HoraSaidaEntrada is { } h ? h.ToString(@"hh\:mm\:ss", PtBr) : null);

        c.Column(col => Bloco(col, "DESTINATÁRIO / REMETENTE",
        [
            [
                new Cel("NOME / RAZÃO SOCIAL", Dest?.RazaoSocial, 55),
                new Cel("CNPJ / CPF", documento, 22),
                new Cel("DATA DE EMISSÃO", emissao?.ToString("dd/MM/yyyy", PtBr), 18)
            ],
            [
                new Cel("ENDEREÇO", MontarEndereco(end?.Logradouro, end?.Numero, end?.Complemento), 45),
                new Cel("BAIRRO / DISTRITO", end?.Bairro, 20),
                new Cel("CEP", end?.CEPFormatado, 12),
                new Cel("DATA DE ENTRADA / SAÍDA", saida?.ToString("dd/MM/yyyy", PtBr), 18)
            ],
            [
                new Cel("MUNICÍPIO", end?.MunicipioNome, 33),
                new Cel("FONE / FAX", end is null ? null : Seguro(() => end.FoneFormatado) ?? end.Fone, 20),
                new Cel("UF", end is null ? null : end.UF.ToString(), 7),
                new Cel("INSCRIÇÃO ESTADUAL", Seguro(() => Dest?.IEFormatado) ?? Dest?.InscricaoEstadual, 22),
                new Cel("HORA DE SAÍDA", horaSaida, 18)
            ]
        ]));
    }

    // =========================================================================
    // FATURA / DUPLICATAS (facultativo)
    // =========================================================================
    private void ComposeFatura(IContainer c)
    {
        var cobr = Info.Cobranca;
        var duplicatas = cobr?.dup ?? [];

        // Cada ocorrência = 3 células (número, vencimento, valor); 3 (retrato) ou 4 (paisagem) ocorrências por linha.
        var entradas = new List<Cel[]>();
        foreach (var d in duplicatas)
        {
            entradas.Add([
                new Cel("FATURA / DUPLICATA", d.nDup, 2.2f),
                new Cel("VENCIMENTO", d.dVenc?.ToString("dd/MM/yyyy", PtBr), 1.5f),
                new Cel("VALOR", Moeda(d.vDup), 1.5f)
            ]);
        }

        if (entradas.Count == 0 && cobr?.fat is { } fat && !string.IsNullOrWhiteSpace(fat.nFat))
        {
            entradas.Add([
                new Cel("FATURA", fat.nFat, 2.2f),
                new Cel("VALOR ORIGINAL", Moeda(fat.vOrig), 1.5f),
                new Cel("VALOR LÍQUIDO", Moeda(fat.vLiq ?? fat.vOrig), 1.5f)
            ]);
        }

        if (entradas.Count == 0 && !_options.ExibirQuadrosFacultativos)
            return;

        // Quadro facultativo sem dados: uma linha em branco com o leiaute das duplicatas.
        if (entradas.Count == 0)
            entradas.Add([new Cel("FATURA / DUPLICATA", null, 2.2f), new Cel("VENCIMENTO", null, 1.5f), new Cel("VALOR", null, 1.5f)]);

        var porLinha = IsLandscape ? 4 : 3; // no retrato, 3 por linha para os rótulos e datas caberem sem quebra
        var linhas = new List<Cel[]>();
        for (var i = 0; i < entradas.Count; i += porLinha)
        {
            var grupo = entradas.Skip(i).Take(porLinha).SelectMany(x => x).ToList();
            // completa a última linha para manter o alinhamento das colunas
            while (grupo.Count < porLinha * 3)
                grupo.Add(new Cel("", null, 1.5f, Vazia: true));
            linhas.Add([.. grupo]);
        }

        c.Column(col => Bloco(col, "FATURA / DUPLICATAS", linhas, facultativo: true));
    }

    // =========================================================================
    // TOTAL DOS PRODUTOS E TOTAL DA NOTA
    // =========================================================================
    private void ComposeTotaisProdutosNota(IContainer c)
    {
        var linha2 = new List<Cel> { new("VALOR TOTAL DA NOTA", Moeda(ICMSTot?.TotalNF), 1, Negrito: true) };
        // vNFTot (W60): total da NF-e somando IBS/CBS/IS, quando informado no XML.
        if (Tot?.vNFTot is > 0)
            linha2.Add(new("VALOR TOTAL DA NF-e (C/ IBS/CBS/IS)", Moeda((double?)Tot.vNFTot), 1, Negrito: true));
        // Sem vNFTot: a célula ocupa a linha inteira; com ele, as duas dividem a linha.
        if (linha2.Count == 1)
            linha2[0] = linha2[0] with { Peso = 5 };
        else
            linha2 = [linha2[0] with { Peso = 2.5f }, linha2[1] with { Peso = 2.5f }];

        c.Column(col => Bloco(col, "TOTAL DOS PRODUTOS E TOTAL DA NOTA",
        [
            [
                new Cel("VALOR TOTAL DOS PRODUTOS", Moeda(ICMSTot?.Produtos), 1),
                new Cel("VALOR DO FRETE", Moeda(ICMSTot?.Frete), 1),
                new Cel("VALOR DO SEGURO", Moeda(ICMSTot?.Seguros), 1),
                new Cel("DESCONTO", Moeda(ICMSTot?.Desconto), 1),
                new Cel("OUTRAS DESPESAS", Moeda(ICMSTot?.Outros), 1)
            ],
            [.. linha2]
        ]));
    }

    // =========================================================================
    // TOTAL DO ICMS / IPI
    // =========================================================================
    private void ComposeTotaisIcmsIpi(IContainer c)
    {
        var t = ICMSTot;
        var linhas = new List<Cel[]>
        {
            new[]
            {
                new Cel("BASE DE CÁLCULO DO ICMS", Moeda(t?.BaseDeCalculo), 1),
                new Cel("VALOR DO ICMS", Moeda(t?.ICMS), 1),
                new Cel("BASE DE CÁLCULO DO ICMS ST", Moeda(t?.BaseDeCalculoST), 1),
                new Cel("VALOR DO ICMS ST", Moeda(t?.ICMSST), 1),
                new Cel("VALOR DO IPI", Moeda(t?.IPI), 1)
            }
        };

        // Quadros facultativos do leiaute (azul): sempre exibidos, ou só com valor no XML se desligado nas opções.
        // Linhas do quadro ICMS/IPI sem lugar fixo de valor: só quando o XML as informa (independe da opção).
        const bool forcar = false;
        AdicionarLinhaOpcional(linhas, forcar, false,
            ("VALOR DO FCP", t?.ICMSFCP, Moeda),
            ("VALOR DO FCP RETIDO POR ST", t?.ICMSFCPST, Moeda),
            ("VALOR DO DIFAL NA UF DE DESTINO", t?.ICMSUFDestino, Moeda),
            ("VALOR DO FCP NA UF DE DESTINO", t?.ICMSFCPUFDestino, Moeda));

        AdicionarLinhaOpcional(linhas, forcar, false,
            ("BC (QUANTIDADE) DO ICMS MONOFÁSICO", t?.qBCMono, Quantidade),
            ("VALOR DO ICMS MONOFÁSICO", t?.ICMSMono, Moeda),
            ("BC (QUANTIDADE) DO ICMS MONOFÁSICO POR RETENÇÃO", t?.qBCMonoReten, Quantidade),
            ("VALOR DO ICMS MONOFÁSICO POR RETENÇÃO", t?.ICMSMonoReten, Moeda));

        // Demais valores do XML sem lugar fixo no leiaute: só quando informados.
        AdicionarLinhaOpcional(linhas, false, true,
            ("VALOR DO ICMS DESONERADO", t?.ICMSDesonerado, Moeda),
            ("VALOR DO FCP RETIDO ANTERIORMENTE POR ST", t?.ICMSFCPSTRet, Moeda),
            ("VALOR DO II", t?.II, Moeda),
            ("VALOR DO IPI DEVOLVIDO", t?.vIPIDevol, Moeda),
            ("ICMS INTERESTADUAL NA UF DO REMETENTE", t?.ICMSUFRemetente, Moeda));

        AdicionarLinhaOpcional(linhas, false, true,
            ("BC (QUANTIDADE) DO ICMS MONOFÁSICO RETIDO ANTERIORMENTE", t?.qBCMonoRet, Quantidade),
            ("VALOR DO ICMS MONOFÁSICO RETIDO ANTERIORMENTE", t?.ICMSMonoRet, Moeda));

        c.Column(col => Bloco(col, "TOTAL DO ICMS / IPI", linhas));
    }

    // =========================================================================
    // TOTAL DO IBS / CBS / IS (NT 2026.010)
    // =========================================================================
    private bool TemReformaTributaria =>
        Tot?.IBSCBSTot is not null
        || Tot?.IS is not null
        || (Info.Items ?? []).Any(i => i.Imposto?.IBSCBS is not null || i.Imposto?.IS is not null);

    private void ComposeTotaisIbsCbsIs(IContainer c)
    {
        if (!TemReformaTributaria)
            return;

        var ibsCbs = Tot?.IBSCBSTot;
        var mono = ibsCbs?.gMono;

        var linhas = new List<Cel[]>
        {
            new[]
            {
                new Cel("VALOR DA CBS", Moeda(ibsCbs?.gCBS?.vCBS), 1),
                new Cel("VALOR DO IBS UF", Moeda(ibsCbs?.gIBS?.gIBSUF?.vIBSUF), 1),
                new Cel("VALOR DO IBS MUNICÍPIO", Moeda(ibsCbs?.gIBS?.gIBSMun?.vIBSMun), 1),
                new Cel("VALOR DO IMPOSTO SELETIVO", Moeda(Tot?.IS?.vIS), 1)
            }
        };

        AdicionarLinhaOpcional(linhas, _options.ExibirQuadrosFacultativos, false,
            ("VALOR DO IBS MONOFÁSICO", (double?)mono?.vIBSMono, Moeda),
            ("VALOR DA CBS MONOFÁSICA", (double?)mono?.vCBSMono, Moeda),
            ("VALOR DO IBS MONOFÁSICO POR RETENÇÃO", (double?)mono?.vIBSMonoReten, Moeda),
            ("VALOR DA CBS MONOFÁSICA POR RETENÇÃO", (double?)mono?.vCBSMonoReten, Moeda));

        c.Column(col => Bloco(col, "TOTAL DO IBS / CBS / IS", linhas));
    }

    // =========================================================================
    // CÁLCULO DO ISSQN (facultativo)
    // =========================================================================
    private void ComposeIssqn(IContainer c)
    {
        var iss = Tot?.ISSQN;
        if (iss is null)
            return;

        c.Column(col => Bloco(col, "CÁLCULO DO ISSQN",
        [
            [
                new Cel("INSCRIÇÃO MUNICIPAL", Emit?.InscricaoMunicipal, 1),
                new Cel("VALOR TOTAL DOS SERVIÇOS", iss is null ? null : Moeda(iss.vServ), 1),
                new Cel("BASE DE CÁLCULO DO ISSQN", iss is null ? null : Moeda(iss.vBC), 1),
                new Cel("VALOR DO ISSQN", iss is null ? null : Moeda(iss.vISS), 1)
            ]
        ], facultativo: true));
    }

    // =========================================================================
    // TRANSPORTADOR / VOLUMES TRANSPORTADOS (facultativo)
    // =========================================================================
    private void ComposeTransporte(IContainer c)
    {
        var transp = Info.Transporte;
        var exibirSempre = _options.ExibirQuadrosFacultativos;
        if (transp is null && !exibirSempre)
            return;

        var transportadora = transp?.Transportadora;
        var veiculo = transp?.Veiculo;
        var volumes = transp?.Volumes ?? [];
        var semDados = transportadora is null && veiculo is null && volumes.Count == 0
            && (transp is null || transp.Modalidade == ModalidadeFrete.SemFrete);
        if (semDados && !exibirSempre)
            return;

        var temPlaca = !string.IsNullOrWhiteSpace(veiculo?.Placa);
        var linhas = new List<Cel[]>
        {
            new[]
            {
                new Cel("RAZÃO SOCIAL", transportadora?.RazaoSocial, 32),
                new Cel("FRETE POR CONTA", DescricaoFrete(transp?.Modalidade), 18),
                new Cel("CÓDIGO ANTT", veiculo?.RNTC, 12),
                new Cel("PLACA DO VEÍCULO", veiculo?.Placa, 12),
                new Cel("UF", temPlaca ? veiculo!.UF.ToString() : null, 5),
                new Cel("CNPJ / CPF", transportadora?.CNPJ_CPFFormatado, 21)
            },
            new[]
            {
                new Cel("ENDEREÇO", transportadora?.Endereco, 50),
                new Cel("MUNICÍPIO", transportadora?.Municipio, 25),
                new Cel("UF", transportadora is { UFSpecified: true } ? transportadora.UF.ToString() : null, 5),
                new Cel("INSCRIÇÃO ESTADUAL", transportadora is null ? null : Seguro(() => transportadora.IEFormatado) ?? transportadora.InscricaoEstadual, 20)
            }
        };

        var linhasVolume = volumes.Count == 0 && exibirSempre ? [new VolumeTransportado()] : volumes;
        foreach (var v in linhasVolume)
        {
            linhas.Add(
            [
                new Cel("QUANTIDADE", v.qVol?.ToString("#,##0", PtBr), 1),
                new Cel("ESPÉCIE", v.esp, 2),
                new Cel("MARCA", v.marca, 2),
                new Cel("NUMERAÇÃO", v.nVol, 2),
                new Cel("PESO BRUTO", v.pesoB is null ? null : $"{v.pesoB.Value.ToString("#,##0.000", PtBr)} kg", 2),
                new Cel("PESO LÍQUIDO", v.pesoL is null ? null : $"{v.pesoL.Value.ToString("#,##0.000", PtBr)} kg", 2)
            ]);
        }

        c.Column(col => Bloco(col, "TRANSPORTADOR / VOLUMES TRANSPORTADOS", linhas, facultativo: true));
    }

    // =========================================================================
    // DADOS DOS PRODUTOS / SERVIÇOS
    // =========================================================================
    private const float LarguraCstCfop = 44;
    private const float LarguraQtdUn = 44;
    private const float LarguraValorUnit = 46;
    private const float LarguraValorTotal = 46;
    private const float LarguraBases = 72;
    private const float LarguraAliquotas = 98;
    private const float LarguraTributos = 98;

    private void ComposeProdutos(IContainer c)
    {
        var itens = Info.Items ?? [];

        c.Column(col =>
        {
            col.Item().PaddingTop(3).Text("DADOS DOS PRODUTOS / SERVIÇOS").FontSize(FonteTitulo).Bold().FontColor(CorPrimaria);
            col.Item().Border(Borda).BorderColor(CorBorda).Column(box =>
            {
            box.Item().Table(table =>
            {
                table.ColumnsDefinition(cols =>
                {
                    cols.RelativeColumn();                         // Descrição
                    cols.ConstantColumn(LarguraCstCfop);           // CST / CFOP
                    cols.ConstantColumn(LarguraQtdUn);             // QTD / UN
                    cols.ConstantColumn(LarguraValorUnit);         // VLR UNIT
                    cols.ConstantColumn(LarguraValorTotal);        // VLR TOTAL
                    cols.ConstantColumn(LarguraBases);             // Bases de cálculo
                    cols.ConstantColumn(LarguraAliquotas);         // Alíquotas
                    cols.ConstantColumn(LarguraTributos);          // Valor dos tributos
                });

                table.Header(header =>
                {
                    CabecalhoTabela(header.Cell(), "DESCRIÇÃO DO PRODUTO / SERVIÇO", false);
                    CabecalhoTabela(header.Cell(), "CST / CFOP");
                    CabecalhoTabela(header.Cell(), "QTD / UN");
                    CabecalhoTabela(header.Cell(), "VLR UNIT");
                    CabecalhoTabela(header.Cell(), "VLR TOTAL");
                    CabecalhoTabela(header.Cell(), "BASES DE CÁLCULO");
                    CabecalhoTabela(header.Cell(), "ALÍQUOTAS");
                    CabecalhoTabela(header.Cell(), "VALOR DOS TRIBUTOS");
                });

                foreach (var item in itens)
                {
                    var prod = item.Dados;
                    var trib = TributosDoItem(item);

                    CelulaItem(table.Cell()).Element(x => ComposeDescricaoItem(x, item));

                    CelulaItem(table.Cell()).AlignCenter().Column(cc =>
                    {
                        cc.Item().Text($"CST {item.Imposto?.ICMS?.CST_Formatado ?? Traco}").FontSize(FonteTabela);
                        cc.Item().Text($"CFOP {prod?.CFOP}").FontSize(FonteTabela);
                    });

                    CelulaItem(table.Cell()).AlignRight().Column(cc =>
                    {
                        cc.Item().AlignRight().Text(Decimais(prod?.QuantidadeComercial, 4)).FontSize(FonteTabela);
                        cc.Item().AlignRight().Text($"[{prod?.UnidadeComercial}]").FontSize(FonteTabelaSecundaria).FontColor(CorSecundaria);
                    });
                    CelulaItem(table.Cell()).AlignRight().Text(Decimais(prod?.ValorUnitarioComercial, 10)).FontSize(FonteTabela);
                    CelulaItem(table.Cell()).AlignRight().Text(Moeda(prod?.ValorTotalBruto)).FontSize(FonteTabela);

                    CelulaItem(table.Cell()).Element(x => ComposeBases(x, trib));
                    CelulaItem(table.Cell()).Element(x => ComposePares(x, trib, t => t.Aliquota));
                    CelulaItem(table.Cell()).Element(x => ComposePares(x, trib, t => t.Valor));
                }
            });

            // Estende as divisórias das colunas até o fim da última folha.
            box.Item().ExtendVertical().Row(row =>
            {
                row.RelativeItem();
                var larguras = new[] { LarguraCstCfop, LarguraQtdUn, LarguraValorUnit, LarguraValorTotal, LarguraBases, LarguraAliquotas, LarguraTributos };
                foreach (var largura in larguras)
                    row.ConstantItem(largura).BorderLeft(Borda).BorderColor(CorBorda);
            });
            });
        });
    }

    private const float AlturaMinimaDadosAdicionais = 80;
    private void ComposeDescricaoItem(IContainer c, Item item)
    {
        var prod = item.Dados;
        var codigo = string.IsNullOrWhiteSpace(prod?.Codigo) ? null : $"{prod.Codigo} - ";

        c.Column(col =>
        {
            col.Item().Text($"{codigo}{prod?.Descricao}").FontSize(FonteTabela);

            if (!string.IsNullOrWhiteSpace(item.InformacoesAdicionais))
                col.Item().Text(item.InformacoesAdicionais.Trim()).FontSize(FonteTabelaSecundaria).FontColor(CorSecundaria);

            var classificacao = ClassificacaoFiscal(item);
            if (classificacao.Length > 0)
                col.Item().Text(classificacao).FontSize(FonteTabelaSecundaria).FontColor(CorSecundaria);
        });
    }

    /// <summary>
    /// Linha secundária sob a descrição (NT 2026.010): classificação fiscal e enquadramentos.
    /// </summary>
    private static string ClassificacaoFiscal(Item item)
    {
        var prod = item.Dados;
        var partes = new List<string>();

        if (!string.IsNullOrWhiteSpace(prod?.NCM)) partes.Add($"[NCM {prod.NCM}]");
        if (!string.IsNullOrWhiteSpace(prod?.CEST)) partes.Add($"[CEST {prod.CEST}]");

        var ibsCbs = item.Imposto?.IBSCBS;
        if (ibsCbs is not null)
        {
            partes.Add($"[CST IBS/CBS {ibsCbs.CST.ToString().Replace("CST_", string.Empty)}]");
            if (!string.IsNullOrWhiteSpace(ibsCbs.cClassTrib)) partes.Add($"[cClassTrib {ibsCbs.cClassTrib}]");
        }

        var imposto = item.Imposto?.IS;
        if (imposto is not null)
        {
            partes.Add($"[CST IS {imposto.CSTIS.ToString().Replace("CST_", string.Empty)}]");
            if (!string.IsNullOrWhiteSpace(imposto.cClassTribIS)) partes.Add($"[cClassTribIS {imposto.cClassTribIS}]");
        }

        if (!string.IsNullOrWhiteSpace(item.Imposto?.IPI?.CodigoEnquadramento))
            partes.Add($"[Enq. IPI {item.Imposto.IPI.CodigoEnquadramento}]");

        if (prod?.ValorDesconto is > 0) partes.Add($"[Desc. {Moeda(prod.ValorDesconto)}]");
        if (prod?.ValorFrete is > 0) partes.Add($"[Frete {Moeda(prod.ValorFrete)}]");
        if (prod?.ValorSeguro is > 0) partes.Add($"[Seguro {Moeda(prod.ValorSeguro)}]");
        if (prod?.ValorOutrasDespesas is > 0) partes.Add($"[Outras desp. {Moeda(prod.ValorOutrasDespesas)}]");

        return string.Join(" ", partes);
    }

    // ── Tributos por item ─────────────────────────────────────────────────────

    private sealed record TributoItem(string Rotulo, string Aliquota, string Valor);

    private sealed record TributosItem(
        List<(string Rotulo, string Base)> Bases,
        List<TributoItem> Tributos);

    /// <summary>
    /// Reúne, na ordem do leiaute (ICMS, CBS, IBS UF, IPI, IBS MUN, IS), apenas os tributos presentes no item.
    /// Alíquotas de IBS/CBS: com grupo gRed, imprime a alíquota efetiva (pAliqEfet); sem ele, a alíquota vigente.
    /// </summary>
    private static TributosItem TributosDoItem(Item item)
    {
        var imposto = item.Imposto;
        var bases = new List<(string, string)>();
        var icms = new TributoItem?[1];
        TributoItem? cbs = null, ibsUf = null, ibsMun = null, ipi = null, isel = null;

        // ICMS
        var t = imposto?.ICMS?.Tributacao;
        if (t is not null && (t.vBC.HasValue || t.pICMS.HasValue || t.vICMS.HasValue))
        {
            if (t.vBC.HasValue) bases.Add(("ICMS", Moeda(t.vBC)));
            icms[0] = new("ICMS", Percentual(t.pICMS), Moeda(t.vICMS));
        }

        // IBS / CBS
        var g = imposto?.IBSCBS?.gIBSCBS;
        if (g is not null)
        {
            bases.Add(("IBS/CBS", Moeda((double)g.vBC)));
            if (g.gCBS is { } c)
                cbs = new("CBS", Percentual((double)(c.gRed?.pAliqEfet ?? c.pCBS)), Moeda((double)c.vCBS));
            if (g.gIBSUF is { } uf)
                ibsUf = new("IBS UF", Percentual((double)(uf.gRed?.pAliqEfet ?? uf.pIBSUF)), Moeda((double)uf.vIBSUF));
            if (g.gIBSMun is { } mun)
                ibsMun = new("IBS MUN", Percentual((double)(mun.gRed?.pAliqEfet ?? mun.pIBSMun)), Moeda((double)mun.vIBSMun));
        }

        // Imposto Seletivo
        var s = imposto?.IS;
        if (s is not null)
        {
            bases.Add(("IS", Moeda((double)s.vBCIS)));
            isel = new("IS", Percentual((double)s.pIS), Moeda((double)s.vIS));
        }

        // IPI
        var p = imposto?.IPI?.Tributacao;
        if (p is not null && (p.BaseDeCalculo.HasValue || p.Aliquota.HasValue || p.ValorIPI.HasValue))
        {
            if (p.BaseDeCalculo.HasValue) bases.Add(("IPI", Moeda(p.BaseDeCalculo)));
            ipi = new("IPI", Percentual(p.Aliquota), Moeda(p.ValorIPI));
        }

        // As bases seguem a ordem do leiaute: ICMS, IBS/CBS, IS, IPI
        var ordem = new[] { "ICMS", "IBS/CBS", "IS", "IPI" };
        bases = [.. bases.OrderBy(b => Array.IndexOf(ordem, b.Item1))];

        var tributos = new[] { icms[0], cbs, ibsUf, ipi, ibsMun, isel }.OfType<TributoItem>().ToList();
        return new TributosItem(bases, tributos);
    }

    private static void ComposeBases(IContainer c, TributosItem trib)
    {
        c.Column(col =>
        {
            foreach (var (rotulo, valor) in trib.Bases)
                col.Item().Row(r => LinhaRotuloValor(r, rotulo, valor));
        });
    }

    /// <summary>Distribui os tributos em pares por linha, como no leiaute (ex.: ICMS/CBS, IBS UF/IPI, IBS MUN/IS).</summary>
    private static void ComposePares(IContainer c, TributosItem trib, Func<TributoItem, string> valor)
    {
        c.Column(col =>
        {
            for (var i = 0; i < trib.Tributos.Count; i += 2)
            {
                var a = trib.Tributos[i];
                var b = i + 1 < trib.Tributos.Count ? trib.Tributos[i + 1] : null;
                col.Item().Row(r =>
                {
                    r.RelativeItem().Row(x => LinhaRotuloValor(x, a.Rotulo, valor(a)));
                    if (b is not null)
                        r.RelativeItem().PaddingLeft(3).Row(x => LinhaRotuloValor(x, b.Rotulo, valor(b)));
                    else
                        r.RelativeItem();
                });
            }
        });
    }

    private static void LinhaRotuloValor(RowDescriptor r, string rotulo, string valor)
    {
        r.AutoItem().PaddingRight(2).Text(rotulo).FontSize(FonteTabelaSecundaria).FontColor(CorSecundaria);
        r.RelativeItem().AlignRight().Text(valor).FontSize(FonteTabela - 0.5f);
    }

    // =========================================================================
    // DADOS ADICIONAIS + QR CODE
    // =========================================================================
    private void ComposeDadosAdicionais(IContainer c)
    {
        var infAdic = Info.InformacoesAdicionais;
        var qrCode = _processo.NFe.InformacoesSuplementares?.QrCode;

        var complementares = new StringBuilder(infAdic?.infCpl?.Trim());
        foreach (var obs in infAdic?.obsCont ?? [])
            complementares.Append(complementares.Length > 0 ? " " : "").Append($"{obs.xCampo}: {obs.xTexto}");

        // Lei 12.741/2012: só complementa quando o emitente não informou o valor no próprio texto.
        if (ICMSTot?.TotalTributos is > 0
            && complementares.ToString().IndexOf("tribut", StringComparison.OrdinalIgnoreCase) < 0)
        {
            complementares.Append(complementares.Length > 0 ? " " : "")
                .Append($"Valor aproximado dos tributos: R$ {Moeda(ICMSTot.TotalTributos)}.");
        }

        var fisco = new StringBuilder(infAdic?.infAdFisco?.Trim());
        foreach (var obs in infAdic?.obsFisco ?? [])
            fisco.Append(fisco.Length > 0 ? " " : "").Append($"{obs.xCampo}: {obs.xTexto}");

        c.PaddingTop(3).Column(col =>
        {
            col.Item().Text("DADOS ADICIONAIS").FontSize(FonteTitulo).Bold().FontColor(CorPrimaria);
            col.Item().Row(row =>
            {
                row.RelativeItem(6).Border(Borda).BorderColor(CorBorda).Row(r =>
                {
                    r.RelativeItem(1).Element(x => ComposeCelula(x.MinHeight(AlturaMinimaDadosAdicionais), new Cel("INFORMAÇÕES COMPLEMENTARES", complementares.ToString(), 1, Quebra: true)));
                    r.RelativeItem(1).BorderLeft(Borda).BorderColor(CorBorda)
                        .Element(x => ComposeCelula(x.MinHeight(AlturaMinimaDadosAdicionais), new Cel("RESERVADO AO FISCO", fisco.ToString(), 1, Quebra: true)));
                });

                if (!string.IsNullOrWhiteSpace(qrCode) || _options.ExibirQuadrosFacultativos)
                {
                    row.ConstantItem(82).PaddingLeft(3).Background(CorFacultativo).Border(Borda).BorderColor(CorBorda).Column(qr =>
                    {
                        qr.Item().Padding(2).Text("QR CODE").FontSize(FonteTitulo).Bold().FontColor(CorPrimaria);
                        if (!string.IsNullOrWhiteSpace(qrCode))
                            qr.Item().AlignCenter().PaddingBottom(2).Width(62).Height(62).Image(QrCodePng.Gerar(qrCode)).FitArea();
                        else
                            qr.Item().Height(66);
                    });
                }
            });
        });
    }

    // =========================================================================
    // Helpers de layout
    // =========================================================================

    /// <summary>Célula rotulada da grade: rótulo pequeno em cinza e valor logo abaixo.</summary>
    private readonly record struct Cel(
        string Rotulo, string? Valor, float Peso = 1f,
        bool Negrito = false, bool Centro = false, bool Quebra = false, bool Vazia = false, bool Azul = false);

    /// <summary>Título do quadro (fora da moldura) seguido das linhas da grade.</summary>
    private static void Bloco(ColumnDescriptor col, string titulo, IEnumerable<Cel[]> linhas, bool facultativo = false)
    {
        col.Item().PaddingTop(3).Text(titulo).FontSize(FonteTitulo).Bold().FontColor(CorPrimaria);
        (facultativo ? col.Item().Background(CorFacultativo) : col.Item()).Border(Borda).BorderColor(CorBorda).Column(box => Linhas(box, facultativo ? linhas.Select(l => l.Select(x => x with { Azul = true }).ToArray()) : linhas, bordaNaPrimeira: false));
    }

    private static void Linhas(ColumnDescriptor box, IEnumerable<Cel[]> linhas, bool bordaNaPrimeira = true)
    {
        var primeira = true;
        foreach (var linha in linhas)
        {
            var item = box.Item();
            if (!primeira || bordaNaPrimeira)
                item = item.BorderTop(Borda).BorderColor(CorBorda);
            primeira = false;

            item.Row(row =>
            {
                var primeiraCelula = true;
                foreach (var cel in linha)
                {
                    var container = row.RelativeItem(cel.Peso);
                    if (cel.Vazia)
                        continue; // reserva a largura sem desenhar a célula
                    if (!primeiraCelula)
                        container = container.BorderLeft(Borda).BorderColor(CorBorda);
                    primeiraCelula = false;
                    ComposeCelula(container, cel);
                }
            });
        }
    }

    private static void ComposeCelula(IContainer c, Cel cel)
    {
        if (cel.Azul)
            c = c.Background(CorFacultativo);

        c.PaddingHorizontal(2).PaddingVertical(1.5f).Column(col =>
        {
            col.Item().Text(cel.Rotulo).FontSize(FonteRotulo).FontColor(CorRotulo);

            if (cel.Valor is null && cel.Rotulo.Length > 0 && !cel.Quebra)
            {
                col.Item().Text(" ").FontSize(FonteValor);
                return;
            }

            var texto = col.Item();
            var valor = cel.Centro ? texto.AlignCenter().Text(cel.Valor ?? " ") : texto.Text(cel.Valor ?? " ");
            valor.FontSize(FonteValor);
            if (cel.Negrito) valor.Bold();
        });
    }

    private static void CabecalhoTabela(IContainer cell, string texto, bool centralizar = true)
    {
        var c = cell.BorderBottom(Borda).BorderColor(CorBorda).BorderLeft(Borda).BorderColor(CorBorda).Padding(2);
        (centralizar ? c.AlignCenter() : c).Text(texto).FontSize(FonteRotulo + 0.5f).Bold();
    }

    private static IContainer CelulaItem(IContainer cell) =>
        cell.BorderBottom(0.25f).BorderColor(CorDivisoria)
            .BorderLeft(Borda).BorderColor(CorBorda)
            .PaddingVertical(1.5f).PaddingHorizontal(2)
            .ShowEntire(); // um item nunca é dividido entre folhas

    private static void AdicionarLinhaOpcional(
        List<Cel[]> linhas, bool forcar, bool filtrar, params (string Rotulo, double? Valor, Func<double?, string> Formato)[] campos)
    {
        // Linha facultativa: impressa apenas se algum valor do grupo constar no XML (diferente de zero).
        if (!forcar && !campos.Any(x => x.Valor is not null and not 0))
            return;
        var exibidos = filtrar ? campos.Where(x => x.Valor is not null and not 0) : campos;
        linhas.Add([.. exibidos.Select(x => new Cel(x.Rotulo, x.Formato(x.Valor), 1, Azul: true))]);
    }

    // =========================================================================
    // Formatação
    // =========================================================================

    private static string Moeda(double? valor) => (valor ?? 0).ToString("N2", PtBr);

    private static string Moeda(decimal? valor) => (valor ?? 0).ToString("N2", PtBr);

    private static string Quantidade(double? valor) => (valor ?? 0).ToString("#,##0.0000", PtBr);

    private static string Percentual(double? valor) => $"{(valor ?? 0).ToString("#,##0.00##", PtBr)}%";

    /// <summary>Número com no mínimo 2 e no máximo <paramref name="maximo"/> casas decimais.</summary>
    private static string Decimais(double? valor, int maximo) =>
        (valor ?? 0).ToString("#,##0.00" + new string('#', Math.Max(0, maximo - 2)), PtBr);

    private string NumeroFormatado() => Ide.Numero.ToString(@"000\.000\.000", CultureInfo.InvariantCulture);

    private string ProtocoloTexto() =>
        Prot?.Protocolo is { Length: > 0 } protocolo
            ? $"{protocolo} - {Prot.DataHoraRecebimento:dd/MM/yyyy HH:mm:ss}"
            : "SEM PROTOCOLO DE AUTORIZAÇÃO";

    private static string? MontarEndereco(params string?[] partes)
    {
        var texto = string.Join(", ", partes.Where(p => !string.IsNullOrWhiteSpace(p)).Select(p => p!.Trim()));
        return texto.Length == 0 ? null : texto;
    }

    private static string? Seguro(Func<string?> obter)
    {
        try { return obter(); }
        catch { return null; }
    }

    private static string FormatarChave(string chave)
    {
        if (string.IsNullOrEmpty(chave) || chave.Length != 44)
            return chave;
        var sb = new StringBuilder();
        for (var i = 0; i < 11; i++)
        {
            sb.Append(chave.AsSpan(i * 4, 4));
            if (i < 10) sb.Append(' ');
        }
        return sb.ToString();
    }

    private static string? DescricaoCrt(RegimeTributario? crt) => crt switch
    {
        RegimeTributario.SimplesNacional => "1 - SIMPLES NACIONAL",
        RegimeTributario.SimplesNacionalExcesso => "2 - SIMPLES NACIONAL - EXCESSO DE SUBLIMITE DE RECEITA BRUTA",
        RegimeTributario.RegimeNormal => "3 - REGIME NORMAL",
        RegimeTributario.Mei => "4 - SIMPLES NACIONAL - MEI",
        _ => null
    };

    private static string? DescricaoFrete(ModalidadeFrete? modalidade) => modalidade switch
    {
        ModalidadeFrete.Emitente => "0 - Remetente (CIF)",
        ModalidadeFrete.Destinatario => "1 - Destinatário (FOB)",
        ModalidadeFrete.Outros => "2 - Terceiros",
        ModalidadeFrete.ProprioRemetente => "3 - Próprio Remetente",
        ModalidadeFrete.ProprioDestinatario => "4 - Próprio Destinatário",
        ModalidadeFrete.SemFrete => "9 - Sem Transporte",
        _ => null
    };

}
