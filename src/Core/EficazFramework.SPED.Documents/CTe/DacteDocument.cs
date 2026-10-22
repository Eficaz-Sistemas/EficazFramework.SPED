using System.Globalization;
using System.Text;
using EficazFramework.SPED.Documents.Common;
using EficazFramework.SPED.Schemas.CTe;

namespace EficazFramework.SPED.Documents.CTe;

/// <summary>
/// Documento QuestPDF que gera o DACTE (Documento Auxiliar do CT-e), modal rodoviário, emissão normal,
/// conforme o modelo de impressão do MOC (item 5.1) e o mesmo estilo de quadros do <c>DanfeDocument</c>.
/// </summary>
/// <remarks>
/// <para>O documento apenas apresenta o que consta no XML; nenhuma informação ausente é inferida.</para>
/// <para><b>Provisório:</b> ainda não há NT com os campos de IBS/CBS no DACTE. Quando o XML os traz
/// (<c>imp/IBSCBS</c>, <c>vTotDFe</c>), eles são impressos em um quadro azul adicional.</para>
/// </remarks>
public sealed class DacteDocument : IDocument
{
    // ── Cores (mesmas do DANFE) ───────────────────────────────────────────────
    private const string CorBorda = "#000000";
    private const string CorRotulo = "#555555";
    private const string CorPrimaria = "#1a3a5c";
    private const string CorFacultativo = "#d0dce8";
    private const string CorMarcaDagua = "#DDDDDD";

    // ── Fontes ────────────────────────────────────────────────────────────────
    private const float FonteRotulo = 5.5f;
    private const float FonteValor = 7.5f;
    private const float FonteTitulo = 7f;

    private const float Borda = 0.5f;

    private static readonly CultureInfo PtBr = CultureInfo.GetCultureInfo("pt-BR");

    private readonly ProcessoCTe _processo;
    private readonly DacteOptions _options;

    private InformacoesCTe? Info => _processo.CTe?.Informacoes;
    private IdentificacaoOperacao? Ide => Info?.IdentificacaoOperacao;
    private Emitente? Emit => Info?.Emitente;
    private ValoresPrestacaoServico? Valores => Info?.Valores;
    private Impostos? Imp => Info?.Impostos;
    private InformacoesCteNormal? Normal => Info?.InformacaoCTePorTipo as InformacoesCteNormal;
    private CTeRodoviario? Rodo => Normal?.infModal?.ItemModal as CTeRodoviario;
    private TProtCTeInfProt? Prot => _processo.ProtocoloAutorizacao?.infProt;

    static DacteDocument()
    {
        QuestPDF.Settings.License = LicenseType.Community;
    }

    public DacteDocument(ProcessoCTe processo, DacteOptions options)
    {
        _processo = processo;
        _options = options;
    }

    public DocumentMetadata GetMetadata() => new()
    {
        Title = $"DACTE {Ide?.Numero}",
        Subject = "Documento Auxiliar do Conhecimento de Transporte Eletrônico",
        Creator = "EficazFramework.SPED.Documents"
    };

    public DocumentSettings GetSettings() => DocumentSettings.Default;

    // =========================================================================
    // Compose
    // =========================================================================
    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Size(PageSizes.A4);
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

            // Folhas seguintes: repete a identificação do emitente, do DACTE e a chave de acesso.
            page.Header().SkipOnce().PaddingBottom(2).Element(c => ComposeCabecalho(c, completo: false));

            page.Content().Column(col =>
            {
                if (_options.ExibirCanhoto)
                    col.Item().ShowOnce().Element(ComposeCanhoto);

                col.Item().Element(c => ComposeCabecalho(c, completo: true));
                col.Item().ShowEntire().Element(ComposePrestacao);
                col.Item().ShowEntire().Element(ComposePartes);
                col.Item().ShowEntire().Element(ComposeTomador);
                col.Item().ShowEntire().Element(ComposeCarga);
                col.Item().ShowEntire().Element(ComposeComponentes);
                col.Item().ShowEntire().Element(ComposeImposto);
                col.Item().ShowEntire().Element(ComposeIbsCbs);
                col.Item().Element(ComposeDocumentosOriginarios);
                col.Item().ShowEntire().Element(ComposeFluxo);
                col.Item().ShowEntire().Element(ComposeObservacoes);
                col.Item().ShowEntire().Element(ComposeModalRodoviario);
                col.Item().ShowEntire().Element(ComposeUsoEmissorFisco);
            });

            if (!string.IsNullOrWhiteSpace(_options.MensagemRodape))
                page.Footer().PaddingTop(2).Text(_options.MensagemRodape).FontSize(FonteRotulo).Italic();
        });
    }

    // =========================================================================
    // CANHOTO
    // =========================================================================
    private void ComposeCanhoto(IContainer c)
    {
        c.PaddingBottom(2).Column(outer =>
        {
            outer.Item().Border(Borda).BorderColor(CorBorda).Column(box =>
            {
                Faixa(box, "DECLARO QUE RECEBI OS VOLUMES DESTE CONHECIMENTO EM PERFEITO ESTADO PELO QUE DOU POR CUMPRIDO O PRESENTE CONTRATO DE TRANSPORTE");
                Linhas(box,
                [
                    [
                        new Cel("NOME", null, 5, Azul: true),
                        new Cel("TÉRMINO DA PRESTAÇÃO - DATA / HORA", null, 3, Azul: true),
                        new Cel("CT-E  Nº DOCUMENTO", Ide?.Numero?.ToString(CultureInfo.InvariantCulture), 2, Azul: true)
                    ],
                    [
                        new Cel("RG", null, 5, Azul: true),
                        new Cel("INÍCIO DA PRESTAÇÃO - DATA / HORA", null, 3, Azul: true),
                        new Cel("SÉRIE", Ide?.Serie, 2, Azul: true)
                    ],
                    [new Cel("ASSINATURA / CARIMBO", null, 10, Azul: true, MinAltura: 12)]
                ], bordaNaPrimeira: true);
            });
            outer.Item().PaddingTop(2).LineHorizontal(Borda).LineColor("#BBBBBB");
        });
    }

    // =========================================================================
    // CABEÇALHO
    // =========================================================================
    private void ComposeCabecalho(IContainer c, bool completo)
    {
        c.Border(Borda).BorderColor(CorBorda).Column(box =>
        {
            box.Item().Row(row =>
            {
                row.RelativeItem(42).Column(esq =>
                {
                    esq.Item().Background(CorFacultativo).Element(ComposeEmitente);
                    if (!completo)
                        return;

                    Linhas(esq,
                    [
                        [
                            new Cel("TIPO DO CT-e", DescricaoTipoCte(Ide?.Finalidade), 1),
                            new Cel("TIPO DO SERVIÇO", DescricaoTipoServico(Ide?.TipoServico), 1)
                        ],
                        [
                            // O schema ainda não traz o indicador de CT-e globalizado: imprime apenas o leiaute.
                            new Cel("INDICADOR DO CT-E GLOBALIZADO", "( ) SIM    ( ) NÃO", 1),
                            new Cel("INF. DO CT-E GLOBALIZADO", null, 1)
                        ]
                    ]);
                });

                row.RelativeItem(58).BorderLeft(Borda).BorderColor(CorBorda).Column(dir =>
                {
                    dir.Item().Row(r =>
                    {
                        r.RelativeItem(3.4f).Element(ComposeTituloDacte);
                        ComposeCelula(r.RelativeItem(1.5f).BorderLeft(Borda).BorderColor(CorBorda),
                            new Cel("MODAL", DescricaoModal(Ide?.Modalidade), 1, Azul: true, Centro: true));
                        r.RelativeItem(0.9f).BorderLeft(Borda).BorderColor(CorBorda).Element(ComposeFolha);
                    });

                    if (!completo)
                    {
                        dir.Item().BorderTop(Borda).BorderColor(CorBorda).Element(ComposeChaveCompacta);
                        return;
                    }

                    Linhas(dir,
                    [
                        [
                            new Cel("MODELO", ((int?)Ide?.Modelo)?.ToString(CultureInfo.InvariantCulture), 0.8f),
                            new Cel("SÉRIE", Ide?.Serie, 0.8f),
                            new Cel("NÚMERO", Ide?.Numero?.ToString(CultureInfo.InvariantCulture), 1.4f),
                            new Cel("DATA E HORA DE EMISSÃO", Ide?.DataEmissao?.ToString("dd/MM/yyyy HH:mm:ss", PtBr), 2.2f),
                            new Cel("INSC. SUFRAMA DESTINATÁRIO", Info?.Destinatario?.ISUF, 1.8f)
                        ]
                    ]);

                    dir.Item().BorderTop(Borda).BorderColor(CorBorda).Element(ComposeChaveAcesso);
                });
            });

            if (!completo)
                return;

            Linhas(box,
            [
                [
                    new Cel("CÓD. FISCAL DE OPERAÇÕES E PRESTAÇÕES - NAT. DA OPERAÇÃO",
                        string.Join(" - ", new[] { Ide?.CFOP, Ide?.NaturezaOperacao }.Where(x => !string.IsNullOrWhiteSpace(x))), 42),
                    new Cel("PROTOCOLO DE AUTORIZAÇÃO DE USO", ProtocoloTexto(), 58, Centro: true)
                ]
            ]);
        });
    }

    private void ComposeEmitente(IContainer c)
    {
        var logo = _options.LogoTransportadora;
        var end = Emit?.Endereco;

        c.Padding(3).Row(row =>
        {
            if (logo is { Length: > 0 })
                row.ConstantItem(48).PaddingRight(3).AlignMiddle().MaxHeight(46).Image(logo).FitArea();

            row.RelativeItem().AlignMiddle().Column(col =>
            {
                col.Item().AlignCenter().Text("IDENTIFICAÇÃO DO EMITENTE").FontSize(FonteRotulo).FontColor(CorRotulo);
                col.Item().AlignCenter().Text(Emit?.xNome ?? string.Empty).Bold().FontSize(9);
                if (!string.IsNullOrWhiteSpace(Emit?.xFant) && Emit.xFant != Emit.xNome)
                    col.Item().AlignCenter().Text(Emit.xFant).FontSize(FonteValor);

                col.Item().AlignCenter().Text(
                    $"CNPJ: {Emit?.CNPJ_Formatado}" + (string.IsNullOrWhiteSpace(Emit?.IE) ? "" : $"   IE: {Emit.IE}"))
                    .FontSize(FonteValor - 0.5f);

                if (end is not null)
                {
                    col.Item().AlignCenter().Text(MontarEndereco(end.xLgr, end.nro, end.xCpl, end.xBairro))
                        .FontSize(FonteValor - 0.5f);
                    col.Item().AlignCenter().Text(
                        $"{end.xMun}/{end.UF} - CEP {Seguro(() => end.CEPFormatado) ?? end.CEP}" +
                        (string.IsNullOrWhiteSpace(end.fone) ? "" : $" - Fone: {end.fone}"))
                        .FontSize(FonteValor - 0.5f);
                }
            });
        });
    }

    private static void ComposeTituloDacte(IContainer c)
    {
        c.Padding(3).AlignMiddle().Column(col =>
        {
            col.Item().AlignCenter().Text("DACTE").Bold().FontSize(13);
            col.Item().AlignCenter().Text("Documento Auxiliar do Conhecimento de Transporte Eletrônico")
                .Bold().FontSize(FonteRotulo + 0.5f);
        });
    }

    private static void ComposeFolha(IContainer c)
    {
        c.PaddingHorizontal(2).PaddingVertical(1.5f).Column(col =>
        {
            col.Item().Text("FL").FontSize(FonteRotulo).FontColor(CorRotulo);
            col.Item().Text(t =>
            {
                t.DefaultTextStyle(x => x.FontSize(FonteValor));
                t.CurrentPageNumber();
                t.Span("/");
                t.TotalPages();
            });
        });
    }

    private void ComposeChaveAcesso(IContainer c)
    {
        var chave = ChaveAcesso();
        var qr = _processo.CTe?.InformacoesSuplementares?.QrCode;

        c.Row(row =>
        {
            row.RelativeItem().Column(col =>
            {
                var barras = Code128.SvgSubconjuntoC(chave);
                if (barras is not null)
                    col.Item().PaddingTop(4).AlignCenter().Height(28).Svg(barras);

                ComposeCelula(col.Item().PaddingTop(3).BorderTop(Borda).BorderColor(CorBorda),
                    new Cel("CHAVE DE ACESSO", FormatarChave(chave), Negrito: true, Centro: true));

                col.Item().PaddingHorizontal(3).PaddingBottom(3).AlignCenter()
                    .Text("Consulta em http://www.cte.fazenda.gov.br/portal").Bold().FontSize(FonteRotulo + 1);
            });

            if (!string.IsNullOrWhiteSpace(qr))
                row.ConstantItem(70).Padding(3).AlignMiddle().Width(64).Height(64).Image(QrCodePng.Gerar(qr)).FitArea();
        });
    }

    private void ComposeChaveCompacta(IContainer c)
    {
        ComposeCelula(c, new Cel("CHAVE DE ACESSO", FormatarChave(ChaveAcesso()), Negrito: true, Centro: true));
    }

    // =========================================================================
    // INÍCIO / TÉRMINO DA PRESTAÇÃO
    // =========================================================================
    private void ComposePrestacao(IContainer c)
    {
        c.PaddingTop(2).Border(Borda).BorderColor(CorBorda).Column(box => Linhas(box,
        [
            [
                new Cel("INÍCIO DA PRESTAÇÃO", MunicipioUf(Ide?.MunicipioInicioNome, Ide?.MunicipioInicioNome is null ? null : Ide.UFInicio.ToString()), 50),
                new Cel("TÉRMINO DA PRESTAÇÃO", MunicipioUf(Ide?.MunicipioFimNome, Ide?.MunicipioFimNome is null ? null : Ide.UFFim.ToString()), 50)
            ]
        ], bordaNaPrimeira: false));
    }

    // =========================================================================
    // PARTES: remetente | destinatário, expedidor | recebedor
    // =========================================================================
    private sealed record Parte(
        string? Nome, string? Endereco, string? Municipio, string? Cep, string? Documento,
        string? Ie, string? Uf, string? Pais, string? Fone);

    private static Parte ParteDe(string? nome, Schemas.CTe.Endereco? end, string? documento, string? ie, string? fone) => new(
        nome,
        end is null ? null : MontarEndereco(end.xLgr, end.nro, end.xCpl, end.xBairro),
        end?.xMun,
        end is null ? null : Seguro(() => end.CEPFormatado) ?? end.CEP,
        documento,
        ie,
        end is null || string.IsNullOrWhiteSpace(end.xMun) ? null : end.UF.ToString(),
        end?.xPais,
        string.IsNullOrWhiteSpace(fone) ? end?.fone : fone);

    private static string? Doc(string? documento) =>
        string.IsNullOrWhiteSpace(documento) ? null : Seguro(() => EficazFramework.SPED.Extensions.String.FormatRFBDocument(documento)) ?? documento;

    private Parte? Remetente => Info?.Remetente is { } r ? ParteDe(r.xNome, r.Endereco, r.CNPJ_CPFFormatado, r.IE, r.fone) : null;
    private Parte? Expedidor => Info?.Expedidor is { } e ? ParteDe(e.xNome, e.Endereco, e.CNPJ_CPFFormatado, e.IE, e.fone) : null;
    private Parte? Recebedor => Info?.Recebedor is { } r ? ParteDe(r.xNome, r.enderReceb, Doc(r.CNPJ_CPF), r.IE, r.fone) : null;
    private Parte? Destinatario => Info?.Destinatario is { } d ? ParteDe(d.xNome, d.Endereco, d.CNPJ_CPFFormatado, d.IE, d.fone) : null;

    /// <summary>Resolve o tomador: toma3 aponta para uma das partes; toma4 traz os dados próprios.</summary>
    private Parte? Tomador => Ide?.Tomador switch
    {
        TomadorTipo04 t4 => ParteDe(t4.xNome, t4.Endereco, t4.CNPJ_CPFFormatado, t4.IE, t4.fone),
        TomadorTipo03 t3 => t3.toma switch
        {
            TipoTomador.Remetente => Remetente,
            TipoTomador.Expedidor => Expedidor,
            TipoTomador.Recebedor => Recebedor,
            TipoTomador.Destinatario => Destinatario,
            _ => null
        },
        _ => null
    };

    private static Cel[][] LinhasDaParte(string titulo, Parte? p) =>
    [
        [new Cel(titulo, p?.Nome, 1)],
        [new Cel("ENDEREÇO", p?.Endereco, 1)],
        [new Cel("MUNICÍPIO", p?.Municipio, 70), new Cel("CEP", p?.Cep, 30)],
        [new Cel("CNPJ / CPF", p?.Documento, 60), new Cel("IE", p?.Ie, 40)],
        [new Cel("UF", p?.Uf, 12), new Cel("PAÍS", p?.Pais, 58), new Cel("FONE", p?.Fone, 30)]
    ];

    private void ComposePartes(IContainer c)
    {
        c.PaddingTop(2).Column(col =>
        {
            col.Item().Border(Borda).BorderColor(CorBorda).Row(row =>
            {
                row.RelativeItem().Column(esq => Linhas(esq, LinhasDaParte("REMETENTE", Remetente), bordaNaPrimeira: false));
                row.RelativeItem().BorderLeft(Borda).BorderColor(CorBorda)
                    .Column(dir => Linhas(dir, LinhasDaParte("DESTINATÁRIO", Destinatario), bordaNaPrimeira: false));
            });
            col.Item().PaddingTop(2).Border(Borda).BorderColor(CorBorda).Row(row =>
            {
                row.RelativeItem().Column(esq => Linhas(esq, LinhasDaParte("EXPEDIDOR", Expedidor), bordaNaPrimeira: false));
                row.RelativeItem().BorderLeft(Borda).BorderColor(CorBorda)
                    .Column(dir => Linhas(dir, LinhasDaParte("RECEBEDOR", Recebedor), bordaNaPrimeira: false));
            });
        });
    }

    private void ComposeTomador(IContainer c)
    {
        var p = Tomador;
        c.PaddingTop(2).Border(Borda).BorderColor(CorBorda).Column(box => Linhas(box,
        [
            [new Cel("TOMADOR DO SERVIÇO", p?.Nome, 50), new Cel("MUNICÍPIO", p?.Municipio, 38), new Cel("CEP", p?.Cep, 12)],
            [new Cel("ENDEREÇO", p?.Endereco, 50), new Cel("UF", p?.Uf, 8), new Cel("PAÍS", p?.Pais, 42)],
            [new Cel("CNPJ / CPF", p?.Documento, 30), new Cel("IE", p?.Ie, 30), new Cel("FONE", p?.Fone, 40)]
        ], bordaNaPrimeira: false));
    }

    // =========================================================================
    // CARGA
    // =========================================================================
    private void ComposeCarga(IContainer c)
    {
        var carga = Normal?.infCarga;
        var (bruto, baseCalculo, aferido, cubagem, volumes) = QuantidadesDaCarga(carga);

        c.PaddingTop(2).Border(Borda).BorderColor(CorBorda).Column(box => Linhas(box,
        [
            [
                new Cel("PRODUTO PREDOMINANTE", carga?.proPred, 33),
                new Cel("OUTRAS CARACTERÍSTICAS DA CARGA", carga?.xOutCat, 33),
                new Cel("VALOR TOTAL DA CARGA", carga?.vCarga is null ? null : Moeda(carga.vCarga), 34)
            ],
            [
                new Cel("PESO BRUTO (KG)", bruto, 1),
                new Cel("PESO BASE CÁLCULO (KG)", baseCalculo, 1),
                new Cel("PESO AFERIDO (KG)", aferido, 1),
                new Cel("CUBAGEM (M³)", cubagem, 1),
                new Cel("QUANTIDADE DE VOLUMES (UND)", volumes, 1)
            ]
        ], bordaNaPrimeira: false));
    }

    /// <summary>
    /// Distribui <c>infQ</c> (tipo de medida livre) nos campos do leiaute, pelo texto de <c>tpMed</c>;
    /// a unidade (m³ / unidade) só é usada quando o texto não identifica a medida.
    /// </summary>
    private static (string? Bruto, string? Base, string? Aferido, string? Cubagem, string? Volumes) QuantidadesDaCarga(
        TCTeInfCteInfCTeNormInfCarga? carga)
    {
        string? bruto = null, baseCalculo = null, aferido = null, cubagem = null, volumes = null;

        foreach (var q in carga?.infQ ?? [])
        {
            var valor = FormatarQuantidade(q.qCarga);
            var med = (q.tpMed ?? string.Empty).ToUpperInvariant();

            if (med.Contains("AFERIDO")) aferido ??= valor;
            else if (med.Contains("BASE")) baseCalculo ??= valor;
            else if (med.Contains("BRUTO") || med.Contains("PESO")) bruto ??= valor;
            else if (med.Contains("CUBAGEM") || q.cUnid == TCTeInfCteInfCTeNormInfCargaInfQCUnid.Item00) cubagem ??= valor;
            else if (med.Contains("VOLUME") || med.Contains("UNID") || q.cUnid == TCTeInfCteInfCTeNormInfCargaInfQCUnid.Item03) volumes ??= valor;
        }

        return (bruto, baseCalculo, aferido, cubagem, volumes);
    }

    // =========================================================================
    // COMPONENTES DO VALOR DA PRESTAÇÃO
    // =========================================================================
    private void ComposeComponentes(IContainer c)
    {
        var comps = Valores?.Comp?.ToList() ?? [];

        c.PaddingTop(2).Border(Borda).BorderColor(CorBorda).Column(box =>
        {
            Faixa(box, "COMPONENTES DO VALOR DA PRESTAÇÃO DE SERVIÇO", conBorda: false);

            box.Item().Row(row =>
            {
                row.RelativeItem(8).Column(esq =>
                {
                    var linhas = Math.Max(1, (int)Math.Ceiling(comps.Count / 4.0));
                    for (var l = 0; l < linhas; l++)
                    {
                        esq.Item().Row(r =>
                        {
                            for (var i = 0; i < 4; i++)
                            {
                                var comp = l * 4 + i < comps.Count ? comps[l * 4 + i] : null;
                                var cel = r.RelativeItem();
                                if (i > 0)
                                    cel = cel.BorderLeft(Borda).BorderColor(CorBorda);
                                ComposeComponente(cel, comp);
                            }
                        });
                    }
                });

                row.RelativeItem(2.2f).BorderLeft(Borda).BorderColor(CorBorda).Column(dir => Linhas(dir,
                [
                    [new Cel("VALOR TOTAL DA PRESTAÇÃO DO SERVIÇO", Moeda(Valores?.vTPrest), 1, Negrito: true)],
                    [new Cel("VALOR A RECEBER", Moeda(Valores?.vRec), 1, Negrito: true)]
                ], bordaNaPrimeira: false));
            });
        });
    }

    private static void ComposeComponente(IContainer c, TCTeInfCteVPrestComp? comp)
    {
        c.PaddingHorizontal(2).PaddingVertical(1.5f).Column(col =>
        {
            col.Item().Row(r =>
            {
                r.RelativeItem().Text("NOME").FontSize(FonteRotulo).FontColor(CorRotulo);
                r.AutoItem().Text("VALOR").FontSize(FonteRotulo).FontColor(CorRotulo);
            });
            col.Item().Row(r =>
            {
                r.RelativeItem().Text(comp?.xNome ?? " ").FontSize(FonteValor);
                r.AutoItem().Text(comp?.vComp is null ? " " : Moeda(comp.vComp)).FontSize(FonteValor);
            });
        });
    }

    // =========================================================================
    // INFORMAÇÕES RELATIVAS AO IMPOSTO
    // =========================================================================
    private void ComposeImposto(IContainer c)
    {
        var icms = Imp?.ICMS?.Tributacao;
        var tem = icms is not null && icms.CST != Schemas.NFe.CST_ICMS.CST_NA;

        c.PaddingTop(2).Border(Borda).BorderColor(CorBorda).Column(box =>
        {
            Faixa(box, "INFORMAÇÕES RELATIVAS AO IMPOSTO", conBorda: false);
            Linhas(box,
            [
                [
                    new Cel("CLASSIFICAÇÃO TRIBUTÁRIA DO SERVIÇO", DescricaoIcms(Imp?.ICMS?.TributacaoIndentifier, tem ? icms : null), 50),
                    new Cel("BASE DE CÁLCULO", icms?.vBC is null ? null : Moeda(icms.vBC), 12.5f),
                    new Cel("ALÍQUOTA DO ICMS", icms?.pICMS is null ? null : Percentual(icms.pICMS), 12.5f),
                    new Cel("VALOR DO ICMS", icms?.vICMS is null ? null : Moeda(icms.vICMS), 12.5f),
                    new Cel("% RED. BC. CALC.", icms?.pRedBC is null ? null : Percentual(icms.pRedBC), 12.5f)
                ]
            ], bordaNaPrimeira: true);
        });
    }

    // =========================================================================
    // IBS / CBS  —  PROVISÓRIO (sem NT do DACTE)
    // =========================================================================
    private void ComposeIbsCbs(IContainer c)
    {
        var tributacao = Imp?.IBSCBS;
        var g = tributacao?.gIBSCBS;
        var totalDfe = Imp?.vTotDFe;
        if (g is null && totalDfe is not > 0)
            return;

        c.PaddingTop(2).Border(Borda).BorderColor(CorBorda).Column(box =>
        {
            Faixa(box, "IBS / CBS (PROVISÓRIO)", conBorda: false);
            Linhas(box,
            [
                [
                    new Cel("CST", tributacao is null ? null : tributacao.CST.ToString().Replace("CST_", string.Empty), 8, Azul: true),
                    new Cel("CLASSIFICAÇÃO TRIBUTÁRIA", tributacao?.cClassTrib, 14, Azul: true),
                    new Cel("BASE DE CÁLCULO", g is null ? null : Moeda(g.vBC), 14, Azul: true),
                    new Cel("IBS UF", g?.gIBSUF is { } uf ? $"{Percentual((double)(uf.gRed?.pAliqEfet ?? uf.pIBSUF))}  {Moeda(uf.vIBSUF)}" : null, 16, Azul: true),
                    new Cel("IBS MUNICÍPIO", g?.gIBSMun is { } mun ? $"{Percentual((double)(mun.gRed?.pAliqEfet ?? mun.pIBSMun))}  {Moeda(mun.vIBSMun)}" : null, 16, Azul: true),
                    new Cel("CBS", g?.gCBS is { } cbs ? $"{Percentual((double)(cbs.gRed?.pAliqEfet ?? cbs.pCBS))}  {Moeda(cbs.vCBS)}" : null, 16, Azul: true),
                    new Cel("VALOR TOTAL DO DF-e", totalDfe is > 0 ? Moeda(totalDfe) : null, 16, Azul: true, Negrito: true)
                ]
            ], bordaNaPrimeira: true);
        });
    }

    // =========================================================================
    // DOCUMENTOS ORIGINÁRIOS
    // =========================================================================
    private sealed record DocumentoOriginario(string Tipo, string? Emitente, string? SerieNumero);

    private IEnumerable<DocumentoOriginario> DocumentosOriginarios()
    {
        var emitenteNf = Info?.Remetente?.CNPJ_CPFFormatado;

        foreach (var item in Normal?.infDoc?.Items ?? [])
        {
            switch (item)
            {
                case TCTeInfCteInfCTeNormInfDocInfNFe nfe:
                    var chave = nfe.Chave ?? string.Empty;
                    // A chave da NF-e carrega CNPJ do emitente (posições 7-20), série (23-25) e número (26-34).
                    yield return chave.Length == 44
                        ? new("NF-e", Doc(chave.Substring(6, 14)), $"{chave.Substring(22, 3).TrimStart('0').PadLeft(1, '0')}/{chave.Substring(25, 9).TrimStart('0').PadLeft(1, '0')}")
                        : new("NF-e", null, chave);
                    break;
                case TCTeInfCteInfCTeNormInfDocInfNF nf:
                    yield return new("NF", emitenteNf, $"{nf.serie}/{nf.nDoc}");
                    break;
                case TCTeInfCteInfCTeNormInfDocInfOutros outros:
                    yield return new(DescricaoTipoOutros(outros.tpDoc), emitenteNf,
                        string.IsNullOrWhiteSpace(outros.descOutros) ? outros.nDoc : $"{outros.descOutros} {outros.nDoc}".Trim());
                    break;
            }
        }
    }

    private void ComposeDocumentosOriginarios(IContainer c)
    {
        var docs = DocumentosOriginarios().ToList();

        c.PaddingTop(2).Border(Borda).BorderColor(CorBorda).Column(box =>
        {
            Faixa(box, "DOCUMENTOS ORIGINÁRIOS", conBorda: false);

            var linhas = new List<Cel[]>();
            for (var i = 0; i < Math.Max(1, docs.Count); i += 2)
            {
                var a = i < docs.Count ? docs[i] : null;
                var b = i + 1 < docs.Count ? docs[i + 1] : null;
                linhas.Add(
                [
                    new Cel("TP DOC.", a?.Tipo, 1), new Cel("CNPJ/CPF EMITENTE", a?.Emitente, 1.4f), new Cel("SÉRIE/Nº DOCUMENTO", a?.SerieNumero, 1.4f),
                    new Cel("TP DOC.", b?.Tipo, 1), new Cel("CNPJ/CPF EMITENTE", b?.Emitente, 1.4f), new Cel("SÉRIE/Nº DOCUMENTO", b?.SerieNumero, 1.4f)
                ]);
            }

            Linhas(box, linhas, bordaNaPrimeira: true);
        });
    }

    // =========================================================================
    // PREVISÃO DO FLUXO DA CARGA
    // =========================================================================
    private void ComposeFluxo(IContainer c)
    {
        var fluxo = Info?.Complemento?.fluxo;
        var passagem = string.Join(", ", (fluxo?.pass ?? []).Select(p => p.xPass).Where(x => !string.IsNullOrWhiteSpace(x)));

        c.PaddingTop(2).Border(Borda).BorderColor(CorBorda).Column(box =>
        {
            Faixa(box, "PREVISÃO DO FLUXO DA CARGA", conBorda: false);
            Linhas(box,
            [
                [
                    new Cel("SIGLA OU CÓDIGO INT. DA FILIAL/PORTO/ESTAÇÃO/AEROPORTO DE ORIGEM", fluxo?.xOrig, 1),
                    new Cel("SIGLA OU CÓDIGO INT. DA FILIAL/PORTO/ESTAÇÃO/AEROPORTO DE PASSAGEM", passagem, 1),
                    new Cel("SIGLA OU CÓDIGO INT. DA FILIAL/PORTO/ESTAÇÃO/AEROPORTO DE DESTINO", fluxo?.xDest, 1)
                ]
            ], bordaNaPrimeira: true);
        });
    }

    // =========================================================================
    // OBSERVAÇÕES, MODAL RODOVIÁRIO, USO EXCLUSIVO / FISCO
    // =========================================================================
    private void ComposeObservacoes(IContainer c)
    {
        c.PaddingTop(2).Border(Borda).BorderColor(CorBorda).Column(box =>
        {
            Faixa(box, "OBSERVAÇÕES GERAIS", conBorda: false);
            box.Item().Element(x => ComposeCelula(x.MinHeight(20), new Cel("", Info?.Complemento?.xObs, 1, Quebra: true, SemRotulo: true)));
        });
    }

    private void ComposeModalRodoviario(IContainer c)
    {
        var celulas = new List<Cel> { new("RNTRC DA EMPRESA", Rodo?.RNTRC, 3) };
        if (Rodo?.lota == rodoLota.Sim)
            celulas.Add(new("LOTAÇÃO", "Sim", 1));
        if (!string.IsNullOrWhiteSpace(Rodo?.CIOT))
            celulas.Add(new("CIOT", Rodo.CIOT, 2));
        if (Rodo?.DataPrevistaEntrega is { } previsao)
            celulas.Add(new("DATA PREVISTA DE ENTREGA", previsao.ToString("dd/MM/yyyy", PtBr), 2));
        var placas = string.Join(", ", (Rodo?.veic ?? []).Select(v => v.placa).Where(x => !string.IsNullOrWhiteSpace(x)));
        if (placas.Length > 0)
            celulas.Add(new("VEÍCULO(S)", placas, 3));

        c.PaddingTop(2).Border(Borda).BorderColor(CorBorda).Column(box =>
        {
            Faixa(box, "INFORMAÇÕES ESPECÍFICAS DO MODAL RODOVIÁRIO", conBorda: false);
            Linhas(box, [[.. celulas]], bordaNaPrimeira: true);
        });
    }

    private void ComposeUsoEmissorFisco(IContainer c)
    {
        var comp = Info?.Complemento;
        var emissor = new StringBuilder();
        foreach (var obs in comp?.ObsCont ?? [])
            emissor.Append(emissor.Length > 0 ? " " : "").Append($"{obs.xCampo}: {obs.xTexto}");

        var fisco = new StringBuilder(Imp?.infAdFisco?.Trim());
        foreach (var obs in comp?.ObsFisco ?? [])
            fisco.Append(fisco.Length > 0 ? " " : "").Append($"{obs.xCampo}: {obs.xTexto}");

        c.PaddingTop(2).Border(Borda).BorderColor(CorBorda).Row(row =>
        {
            row.RelativeItem(2.1f).Column(esq =>
            {
                Faixa(esq, "USO EXCLUSIVO DO EMISSOR DO CT-E", conBorda: false);
                esq.Item().Element(x => ComposeCelula(x.MinHeight(24), new Cel("", emissor.ToString(), 1, Quebra: true, SemRotulo: true)));
            });
            row.RelativeItem(1).BorderLeft(Borda).BorderColor(CorBorda).Column(dir =>
            {
                Faixa(dir, "RESERVADO AO FISCO", conBorda: false);
                dir.Item().Element(x => ComposeCelula(x.MinHeight(24), new Cel("", fisco.ToString(), 1, Quebra: true, SemRotulo: true)));
            });
        });
    }

    // =========================================================================
    // Helpers de layout (mesma linguagem visual do DANFE)
    // =========================================================================

    /// <summary>Célula rotulada da grade: rótulo pequeno em cinza e valor logo abaixo.</summary>
    private readonly record struct Cel(
        string Rotulo, string? Valor, float Peso = 1f,
        bool Negrito = false, bool Centro = false, bool Quebra = false, bool Azul = false,
        float MinAltura = 0, bool SemRotulo = false);

    /// <summary>Faixa de título centralizada e sombreada, como nos quadros do modelo.</summary>
    private static void Faixa(ColumnDescriptor col, string titulo, bool conBorda = true)
    {
        var item = col.Item().Background(CorFacultativo).Padding(1.5f);
        if (conBorda)
            item = item.BorderBottom(Borda).BorderColor(CorBorda);
        item.AlignCenter().Text(titulo).FontSize(FonteTitulo).Bold().FontColor(CorPrimaria);
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
        if (cel.MinAltura > 0)
            c = c.MinHeight(cel.MinAltura);

        c.PaddingHorizontal(2).PaddingVertical(1.5f).Column(col =>
        {
            if (!cel.SemRotulo)
                col.Item().Text(cel.Rotulo).FontSize(FonteRotulo).FontColor(CorRotulo);

            var texto = col.Item();
            var valor = cel.Centro ? texto.AlignCenter().Text(cel.Valor ?? " ") : texto.Text(cel.Valor ?? " ");
            valor.FontSize(FonteValor);
            if (cel.Negrito) valor.Bold();
        });
    }

    // =========================================================================
    // Formatação
    // =========================================================================

    private static string Moeda(double? valor) => (valor ?? 0).ToString("N2", PtBr);

    private static string Moeda(decimal? valor) => (valor ?? 0).ToString("N2", PtBr);

    private static string Percentual(double? valor) => $"{(valor ?? 0).ToString("#,##0.00##", PtBr)}%";

    private static string? FormatarQuantidade(string? valor) =>
        double.TryParse(valor, NumberStyles.Float, CultureInfo.InvariantCulture, out var n)
            ? n.ToString("#,##0.00##", PtBr)
            : valor;

    private static string? MunicipioUf(string? municipio, string? uf) =>
        string.IsNullOrWhiteSpace(municipio) ? null : $"{municipio}{(string.IsNullOrWhiteSpace(uf) ? "" : $" - {uf}")}";

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

    private string ChaveAcesso()
    {
        var chave = Prot?.chCTe;
        if (string.IsNullOrWhiteSpace(chave))
            chave = Info?.Id?.Replace("CTe", string.Empty);
        return chave ?? string.Empty;
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

    private string ProtocoloTexto() =>
        Prot?.nProt is { Length: > 0 } protocolo
            ? $"{protocolo} - {Prot.dhRecbto:dd/MM/yyyy HH:mm:ss}"
            : "SEM PROTOCOLO DE AUTORIZAÇÃO";

    private static string? DescricaoModal(ModalidadeTransporte? modal) => modal switch
    {
        ModalidadeTransporte.Rodoviario => "RODOVIÁRIO",
        ModalidadeTransporte.Aereo => "AÉREO",
        ModalidadeTransporte.Aquaviario => "AQUAVIÁRIO",
        null => null,
        _ => modal.ToString()!.ToUpperInvariant()
    };

    private static string? DescricaoTipoCte(TipoCTe? tipo) => tipo switch
    {
        TipoCTe.Normal => "Normal",
        TipoCTe.Complemento => "Complemento de Valores",
        TipoCTe.Anulacao => "Anulação",
        null => null,
        _ => tipo.ToString()
    };

    private static string? DescricaoTipoServico(TiposServico? tipo) => tipo switch
    {
        TiposServico.Normal => "Normal",
        TiposServico.SubContratacao => "Subcontratação",
        TiposServico.ReDespacho => "Redespacho",
        TiposServico.Redespacho_Intermediario => "Redespacho Intermediário",
        TiposServico.Servico_Vinculado_MultiModal => "Serviço Vinculado a Multimodal",
        null => null,
        _ => tipo.ToString()
    };

    private static string? DescricaoIcms(Tributacao_ICMS_Identifier? tipo, DetalhamentoICMS? icms) => tipo switch
    {
        _ when icms is null => null,
        Tributacao_ICMS_Identifier.ICMS00 or Tributacao_ICMS_Identifier.CST00 => "00 - Tributação normal do ICMS",
        Tributacao_ICMS_Identifier.ICMS20 or Tributacao_ICMS_Identifier.CST20 => "20 - Tributação com BC reduzida do ICMS",
        Tributacao_ICMS_Identifier.ICMS45 or Tributacao_ICMS_Identifier.CST45 => "45 - ICMS isento, não tributado ou diferido",
        Tributacao_ICMS_Identifier.ICMS60 or Tributacao_ICMS_Identifier.CST60 => "60 - ICMS cobrado anteriormente por substituição tributária",
        Tributacao_ICMS_Identifier.ICMS90 or Tributacao_ICMS_Identifier.CST90 => "90 - ICMS outros",
        Tributacao_ICMS_Identifier.ICMSOutraUF => "90 - ICMS outra UF",
        Tributacao_ICMS_Identifier.ICMSSN => "Simples Nacional",
        _ => null
    };

    private static string DescricaoTipoOutros(TCTeInfCteInfCTeNormInfDocInfOutrosTpDoc tipo) => tipo switch
    {
        TCTeInfCteInfCTeNormInfDocInfOutrosTpDoc.Item00 => "Declaração",
        TCTeInfCteInfCTeNormInfDocInfOutrosTpDoc.Item10 => "Dutoviário",
        _ => "Outros"
    };
}
