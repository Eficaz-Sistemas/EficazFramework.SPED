using EficazFramework.SPED.Schemas.NFe;

namespace EficazFramework.SPED.Documents.NFe;

/// <summary>
/// Documento QuestPDF que gera o DANFE (Documento Auxiliar da NF-e) conforme
/// layout v4.00 e NTs 2019.001, 2020.006, 2024.001 (IBS/CBS/IS - Reforma Tributária).
/// A orientação (retrato/paisagem/simplificado) é determinada automaticamente pelo campo
/// <c>IdentificacaoNFe.TipoImpressao</c>.
/// </summary>
public sealed class DanfeDocument : IDocument
{
    // ── Paleta de cores ───────────────────────────────────────────────────────
    private const string CorPrimaria      = "#1a3a5c"; // azul escuro SPED
    private const string CorSecundaria    = "#2e6da4"; // azul médio
    private const string CorBorda         = "#bdc3c7";
    private const string CorLinhaImpar    = "#f2f5f8"; // cinza muito claro
    private const string CorLinhaPar      = "#ffffff";
    private const string CorCabecalhoTabela = "#d0dce8";

    // ── Tamanhos de fonte ─────────────────────────────────────────────────────
    private const float FonteRotulo  = 6f;
    private const float FonteValor   = 8f;
    private const float FonteTabela  = 7f;
    private const float FonteTitulo  = 14f;

    private readonly ProcessoNFe _processo;
    private readonly DanfeOptions _options;

    // Atalhos para os objetos mais acessados
    private InformacoesNFe Info   => _processo.NFe.InformacoesNFe;
    private IdentificacaoNFe Ide  => Info.IdentificacaoOperacao;
    private Emitente Emit         => Info.Emitente;
    private Destinatario? Dest    => Info.Destinatario;
    private TotalICMS? ICMSTot    => Info.Totais?.ICMS;
    private TotalISSQN? ISSQNTot  => Info.Totais?.ISSQN;
    private InformacoesProtocolo? Prot => _processo.ProtocoloAutorizacao?.InformacoesProtocolo;
    private bool IsLandscape      => Ide.TipoImpressao == TipoImpressao.Paisagem;
    private bool IsSimplificado   => Ide.TipoImpressao == TipoImpressao.Simplificado;

    static DanfeDocument()
    {
        QuestPDF.Settings.License = LicenseType.Community;
    }

    public DanfeDocument(ProcessoNFe processo, DanfeOptions options)
    {
        _processo = processo;
        _options  = options;
    }

    public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

    public DocumentSettings GetSettings() => DocumentSettings.Default;

    // =========================================================================
    // Compose — ponto de entrada do QuestPDF
    // =========================================================================
    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            // Tamanho e orientação
            if (IsLandscape)
                page.Size(PageSizes.A4.Landscape());
            else
                page.Size(PageSizes.A4);

            page.MarginTop(4, Unit.Millimetre);
            page.MarginBottom(4, Unit.Millimetre);
            page.MarginLeft(6, Unit.Millimetre);
            page.MarginRight(6, Unit.Millimetre);
            page.DefaultTextStyle(x => x.FontFamily("Arial").FontSize(FonteValor));

            // ── Header: repete em todas as páginas ───────────────────────────
            page.Header().Column(col =>
            {
                col.Item().Element(ComposeHeaderPrincipal);
                col.Item().PaddingTop(1).Element(ComposeEmitente);
                col.Item().PaddingTop(1).Element(ComposeIdentificacao);
                col.Item().PaddingTop(1).Element(ComposeDestinatario);
                col.Item().PaddingTop(2).LineHorizontal(0.5f).LineColor(CorBorda);
            });

            // ── Content: tabela de itens (ocupa a área restante entre header e footer e pagina) ────
            page.Content().PaddingVertical(1).Element(ComposeProdutos);

            // ── Footer: seções abaixo dos itens (repetem em todas as páginas) ─
            page.Footer().Element(ComposeFooter);
        });
    }

    // =========================================================================
    // HEADER: bloco superior (logo + DANFE + chave)
    // =========================================================================
    private void ComposeHeaderPrincipal(IContainer c)
    {
        c.Border(0.5f).BorderColor(CorBorda).Row(row =>
        {
            // ── Coluna Esquerda: Logo ──────────────────────────────────────
            row.RelativeItem(2).Padding(2).Element(ComposeLogoEmitente);

            // ── Coluna Central: Título DANFE ───────────────────────────────
            row.RelativeItem(3).BorderLeft(0.5f).BorderColor(CorBorda)
               .Padding(3).Column(col =>
               {
                   col.Item().AlignCenter().Text("DANFE")
                      .Bold().FontSize(FonteTitulo).FontColor(CorPrimaria);
                   col.Item().AlignCenter().Text("Documento Auxiliar da Nota Fiscal Eletrônica")
                      .FontSize(FonteRotulo);

                   var tpOp = Ide.TipoOperacao == OperacaoNFe.Entrada ? "0 - ENTRADA" : "1 - SAÍDA";
                   col.Item().PaddingTop(2).AlignCenter()
                      .Text($"Nº {Ide.Numero:D9}   Série {Ide.Serie:D3}   {tpOp}")
                      .FontSize(FonteValor).Bold();

                   // Número da folha X/N no Header
                   col.Item().PaddingTop(1).AlignCenter().Text(text =>
                   {
                       text.Span("FOLHA ").FontSize(FonteRotulo).Bold();
                       text.CurrentPageNumber().FontSize(FonteRotulo).Bold();
                       text.Span(" / ").FontSize(FonteRotulo).Bold();
                       text.TotalPages().FontSize(FonteRotulo).Bold();
                   });

                   if (Ide.TipoImpressao == TipoImpressao.Simplificado)
                       col.Item().AlignCenter().Text("DANFE SIMPLIFICADO")
                          .FontSize(FonteRotulo).Italic();
               });

            // ── Coluna Direita: Chave de Acesso ────────────────────────────
            row.RelativeItem(4).BorderLeft(0.5f).BorderColor(CorBorda)
               .Padding(3).Column(col =>
               {
                   col.Item().Text("CHAVE DE ACESSO").FontSize(FonteRotulo).FontColor(CorSecundaria).Bold();
                   var chave = Prot?.ChaveNFe ?? Info.Id?.Replace("NFe","") ?? string.Empty;
                   var chaveFormatada = Prot?.ChaveNFeFormatada ?? FormatarChave(chave);
                   col.Item().PaddingTop(1).Text(chaveFormatada)
                      .FontSize(FonteRotulo + 1).FontFamily("Courier New");

                   col.Item().PaddingTop(3).Text("PROTOCOLO DE AUTORIZAÇÃO DE USO")
                      .FontSize(FonteRotulo).FontColor(CorSecundaria).Bold();

                   if (Prot?.Protocolo != null)
                   {
                       col.Item().Text(
                           $"{Prot.Protocolo}  {Prot.DataHoraRecebimento:dd/MM/yyyy HH:mm:ss}")
                           .FontSize(FonteRotulo + 1);
                   }
                   else
                   {
                       col.Item().Text("SEM PROTOCOLO").FontSize(FonteRotulo + 1).Italic();
                   }

                   // Marca d'água ou ambiente
                   if (_options.MostrarMarcaDagua)
                   {
                       col.Item().PaddingTop(2).AlignCenter()
                          .Text("⚠ HOMOLOGAÇÃO - SEM VALOR FISCAL ⚠")
                          .FontSize(FonteRotulo).Bold().FontColor("#e74c3c");
                   }
               });
        });
    }

    private void ComposeLogoEmitente(IContainer c)
    {
        var logoBytes = _options.LogoEmitente ?? Emit?.Logo;
        if (logoBytes is { Length: > 0 })
        {
            c.AlignMiddle().AlignCenter().MaxHeight(40).Image(logoBytes);
        }
        else
        {
            c.AlignMiddle().AlignCenter().Column(col =>
            {
                col.Item().Text(Emit?.RazaoSocial ?? string.Empty)
                   .Bold().FontSize(FonteValor).FontColor(CorPrimaria);
                if (!string.IsNullOrEmpty(Emit?.NomeFantasia))
                    col.Item().Text(Emit.NomeFantasia).FontSize(FonteRotulo);
            });
        }
    }

    // =========================================================================
    // EMITENTE
    // =========================================================================
    private void ComposeEmitente(IContainer c)
    {
        c.Border(0.5f).BorderColor(CorBorda).Row(row =>
        {
            // Nome / Fantasia / CNPJ / IE / Endereço
            row.RelativeItem().Padding(0).Column(col =>
            {
                Rotulo(col, "EMITENTE");
                col.Item().PaddingHorizontal(3).PaddingTop(3).Text(Emit?.RazaoSocial ?? string.Empty).Bold().FontSize(FonteValor);
                if (!string.IsNullOrEmpty(Emit?.NomeFantasia))
                    col.Item().PaddingHorizontal(3).Text(Emit.NomeFantasia).FontSize(FonteRotulo);

                var end = Emit?.Endereco;
                if (end is not null)
                {
                    col.Item().PaddingHorizontal(3).Text(
                        $"{end.Logradouro}, {end.Numero}" +
                        (string.IsNullOrEmpty(end.Complemento) ? "" : $", {end.Complemento}") +
                        $" - {end.Bairro} - {end.MunicipioNome}/{end.UF} - CEP {end.CEPFormatado}")
                        .FontSize(FonteRotulo);
                }

                col.Item().PaddingHorizontal(3).PaddingBottom(3).Text(
                    $"CNPJ: {Emit?.CNPJ_CPFFormatado}  " +
                    $"IE: {Emit?.IEFormatado ?? Emit?.InscricaoEstadual}  " +
                    (string.IsNullOrEmpty(Emit?.InscricaoMunicipal) ? "" : $"IM: {Emit.InscricaoMunicipal}"))
                    .FontSize(FonteRotulo);
            });
        });
    }

    // =========================================================================
    // IDENTIFICAÇÃO DA OPERAÇÃO
    // =========================================================================
    private void ComposeIdentificacao(IContainer c)
    {
        c.Border(0.5f).BorderColor(CorBorda).Row(row =>
        {
            CelulaLabel(row.RelativeItem(4), "NATUREZA DA OPERAÇÃO", Ide.NaturezaOperacao);
            row.ConstantItem(0.5f).Background(CorBorda);
            CelulaLabel(row.AutoItem().PaddingRight(2), "FORMA DE EMISSÃO",
                Ide.FormaEmissao == FormaEmissao.Normal ? "1 - Emissão Normal" :
                $"{(int)Ide.FormaEmissao} - {Ide.FormaEmissao}");
            row.ConstantItem(0.5f).Background(CorBorda);
            CelulaLabel(row.AutoItem().PaddingRight(2), "DATA/HORA DE EMISSÃO",
                (Ide.DataHoraEmissao ?? Ide.DataEmissao)?.ToString("dd/MM/yyyy HH:mm:ss") ?? "-");
            row.ConstantItem(0.5f).Background(CorBorda);
            CelulaLabel(row.AutoItem().PaddingRight(2), "DATA/HORA SAÍDA/ENTRADA",
                (Ide.DataHoraSaidaEntrada ?? Ide.DataSaidaEntrada)?.ToString("dd/MM/yyyy HH:mm:ss") ?? "-");
        });
    }

    // =========================================================================
    // DESTINATÁRIO
    // =========================================================================
    private void ComposeDestinatario(IContainer c)
    {
        c.Border(0.5f).BorderColor(CorBorda).Column(col =>
        {
            Rotulo(col, "DESTINATÁRIO / REMETENTE");
            col.Item().Row(row =>
            {
                CelulaLabel(row.RelativeItem(5), "NOME / RAZÃO SOCIAL", Dest?.RazaoSocial);
                row.ConstantItem(0.5f).Background(CorBorda);
                CelulaLabel(row.RelativeItem(2), "CNPJ / CPF", Dest?.CNPJ_CPFFormatado);
                row.ConstantItem(0.5f).Background(CorBorda);
                CelulaLabel(row.RelativeItem(2), "DATA DE EMISSÃO",
                    Ide.DataEmissao?.ToString("dd/MM/yyyy") ?? "-");
            });
            col.Item().LineHorizontal(0.3f).LineColor(CorBorda);
            col.Item().Row(row =>
            {
                var endDest = Dest?.Endereco;
                CelulaLabel(row.RelativeItem(5), "ENDEREÇO",
                    endDest is null ? "-" :
                    $"{endDest.Logradouro}, {endDest.Numero} - {endDest.Bairro}");
                row.ConstantItem(0.5f).Background(CorBorda);
                CelulaLabel(row.RelativeItem(2), "MUNICÍPIO", endDest?.MunicipioNome);
                row.ConstantItem(0.5f).Background(CorBorda);
                CelulaLabel(row.RelativeItem(1), "UF", endDest?.UF.ToString());
                row.ConstantItem(0.5f).Background(CorBorda);
                CelulaLabel(row.RelativeItem(1), "CEP", endDest?.CEPFormatado);
                row.ConstantItem(0.5f).Background(CorBorda);
                CelulaLabel(row.RelativeItem(2), "IE DEST.", Dest?.IEFormatado);
            });
        });
    }

    // =========================================================================
    // PRODUTOS (tabela paginada — fica no Content())
    // =========================================================================
    private void ComposeProdutos(IContainer c)
    {
        var itens = Info.Items ?? [];

        c.ExtendVertical().Border(0.5f).BorderColor(CorBorda).Column(col =>
        {
            col.Item().Table(table =>
            {
                // ── Definição de colunas ──────────────────────────────────────
                table.ColumnsDefinition(cols =>
                {
                    cols.ConstantColumn(18);  // #
                    cols.ConstantColumn(45);  // Código
                    cols.RelativeColumn(4);   // Descrição
                    cols.ConstantColumn(40);  // NCM
                    if (!IsSimplificado)
                        cols.ConstantColumn(25); // CST/CSOSN
                    cols.ConstantColumn(22);  // CFOP
                    cols.ConstantColumn(20);  // Un.
                    cols.ConstantColumn(50);  // Qtd.
                    cols.ConstantColumn(60);  // V.Unit.
                    cols.ConstantColumn(60);  // V.Desc
                    cols.ConstantColumn(60);  // V.Total
                });

                // ── Cabeçalho da tabela (repete a cada página) ─────────────
                table.Header(header =>
                {
                    header.Cell().ColumnSpan((uint)(IsSimplificado ? 10 : 11))
                          .Background(CorCabecalhoTabela).Padding(1).PaddingLeft(3)
                          .Text("DADOS DOS PRODUTOS / SERVIÇOS").FontSize(FonteRotulo).Bold().FontColor(CorPrimaria);

                    CabecalhoTabela(header.Cell(), "#");
                    CabecalhoTabela(header.Cell(), "CÓDIGO");
                    CabecalhoTabela(header.Cell(), "DESCRIÇÃO DO PRODUTO/SERVIÇO");
                    CabecalhoTabela(header.Cell(), "NCM/SH");
                    if (!IsSimplificado)
                        CabecalhoTabela(header.Cell(), "CST");
                    CabecalhoTabela(header.Cell(), "CFOP");
                    CabecalhoTabela(header.Cell(), "UN");
                    CabecalhoTabela(header.Cell(), "QTD.");
                    CabecalhoTabela(header.Cell(), "V.UNIT.");
                    CabecalhoTabela(header.Cell(), "V.DESC.");
                    CabecalhoTabela(header.Cell(), "V.TOTAL");
                });

                // ── Linhas de dados com alternância de background ──────────
                for (int i = 0; i < itens.Count; i++)
                {
                    var item = itens[i];
                    var prod = item.Dados;
                    var bg = i % 2 == 0 ? CorLinhaPar : CorLinhaImpar;

                    CelulaTabela(table, (i + 1).ToString(), bg, AlinhamentoTexto.Centro);
                    CelulaTabela(table, prod?.Codigo, bg);
                    CelulaTabela(table, prod?.Descricao, bg);
                    CelulaTabela(table, prod?.NCM, bg, AlinhamentoTexto.Centro);
                    if (!IsSimplificado)
                        CelulaTabela(table, ObterCst(item), bg, AlinhamentoTexto.Centro);
                    CelulaTabela(table, prod?.CFOP, bg, AlinhamentoTexto.Centro);
                    CelulaTabela(table, prod?.UnidadeComercial, bg, AlinhamentoTexto.Centro);
                    CelulaTabela(table, $"{prod?.QuantidadeComercial:N4}", bg, AlinhamentoTexto.Direita);
                    CelulaTabela(table, $"{prod?.ValorUnitarioComercial:N2}", bg, AlinhamentoTexto.Direita);
                    CelulaTabela(table, $"{prod?.ValorDesconto:N2}", bg, AlinhamentoTexto.Direita);
                    CelulaTabela(table, $"{prod?.ValorTotalBruto:N2}", bg, AlinhamentoTexto.Direita);
                }
            });

            // ── Extensão vertical das colunas até a borda inferior ────────
            col.Item().ExtendVertical().Row(emptyRow =>
            {
                emptyRow.ConstantItem(18).BorderRight(0.3f).BorderColor(CorBorda);
                emptyRow.ConstantItem(45).BorderRight(0.3f).BorderColor(CorBorda);
                emptyRow.RelativeItem(4).BorderRight(0.3f).BorderColor(CorBorda);
                emptyRow.ConstantItem(40).BorderRight(0.3f).BorderColor(CorBorda);
                if (!IsSimplificado)
                    emptyRow.ConstantItem(25).BorderRight(0.3f).BorderColor(CorBorda);
                emptyRow.ConstantItem(22).BorderRight(0.3f).BorderColor(CorBorda);
                emptyRow.ConstantItem(20).BorderRight(0.3f).BorderColor(CorBorda);
                emptyRow.ConstantItem(50).BorderRight(0.3f).BorderColor(CorBorda);
                emptyRow.ConstantItem(60).BorderRight(0.3f).BorderColor(CorBorda);
                emptyRow.ConstantItem(60).BorderRight(0.3f).BorderColor(CorBorda);
                emptyRow.ConstantItem(60);
            });
        });
    }

    // =========================================================================
    // TRANSPORTE
    // =========================================================================
    private void ComposeTransporte(IContainer c)
    {
        var transp = Info.Transporte;
        c.Border(0.5f).BorderColor(CorBorda).Column(col =>
        {
            Rotulo(col, "DADOS DO TRANSPORTE");
            col.Item().Row(row =>
            {
                CelulaLabel(row.AutoItem().PaddingRight(2), "MODALIDADE DO FRETE",
                    transp?.Modalidade switch
                    {
                        ModalidadeFrete.Emitente  => "0 - Contratação p/ conta do Emitente (CIF)",
                        ModalidadeFrete.Destinatario => "1 - Contratação p/ conta do Destinatário (FOB)",
                        ModalidadeFrete.Outros  => "2 - Contratação p/ conta de Terceiros",
                        ModalidadeFrete.ProprioRemetente => "3 - Transporte Próprio do Remetente",
                        ModalidadeFrete.ProprioDestinatario => "4 - Transporte Próprio do Destinatário",
                        ModalidadeFrete.SemFrete        => "9 - Sem Frete",
                        _ => "-"
                    });
                row.ConstantItem(0.5f).Background(CorBorda);
                CelulaLabel(row.RelativeItem(4), "TRANSPORTADOR", transp?.Transportadora?.RazaoSocial);
                row.ConstantItem(0.5f).Background(CorBorda);
                CelulaLabel(row.AutoItem().PaddingRight(2), rotulo: "CNPJ / CPF", transp?.Transportadora?.CNPJ_CPFFormatado);
                row.ConstantItem(0.5f).Background(CorBorda);
                CelulaLabel(row.AutoItem().PaddingRight(2), "IE", transp?.Transportadora?.IEFormatado);
            });
        });
    }

    // =========================================================================
    // TOTAIS
    // =========================================================================
    private void ComposeTotais(IContainer c)
    {
        c.Row(row =>
        {
            // ── Coluna Esquerda: ISSQN (quando houver) ────────────────────
            if (ISSQNTot is not null)
            {
                row.RelativeItem(3).Border(0.5f).BorderColor(CorBorda).Column(col =>
                {
                    Rotulo(col, "CÁLCULO DO ISSQN");
                    col.Item().Row(r =>
                    {
                        CelulaLabel(r.RelativeItem(), "INS.MUNICIPAL PREST.", Emit?.InscricaoMunicipal);
                        CelulaLabel(r.RelativeItem(), "VALOR TOTAL SERV.", $"{ISSQNTot.vServ:N2}");
                    });
                    col.Item().Row(r =>
                    {
                        CelulaLabel(r.RelativeItem(), "BASE CÁLC. ISSQN", $"{ISSQNTot.vBC:N2}");
                        CelulaLabel(r.RelativeItem(), "VALOR ISSQN", $"{ISSQNTot.vISS:N2}");
                    });
                });
                row.ConstantItem(2);
            }

            // ── Coluna Direita: Totais ICMS ───────────────────────────────
            row.RelativeItem(5).Border(0.5f).BorderColor(CorBorda).Column(col =>
            {
                Rotulo(col, "CÁLCULO DO IMPOSTO");
                col.Item().Row(r =>
                {
                    CelulaLabel(r.RelativeItem(), "BASE CÁLC. ICMS", $"{ICMSTot?.BaseDeCalculo:N2}");
                    CelulaLabel(r.RelativeItem(), "VALOR ICMS", $"{ICMSTot?.ICMS:N2}");
                    CelulaLabel(r.RelativeItem(), "ICMS DESON.", $"{ICMSTot?.ICMSDesonerado:N2}");
                    CelulaLabel(r.RelativeItem(), "BASE CÁLC. ICMS ST", $"{ICMSTot?.BaseDeCalculoST:N2}");
                    CelulaLabel(r.RelativeItem(), "VALOR ICMS ST", $"{ICMSTot?.ICMSST:N2}");
                });
                col.Item().Row(r =>
                {
                    CelulaLabel(r.RelativeItem(), "VL. TOTAL PRODUTOS", $"{ICMSTot?.Produtos:N2}");
                    CelulaLabel(r.RelativeItem(), "VALOR FRETE", $"{ICMSTot?.Frete:N2}");
                    CelulaLabel(r.RelativeItem(), "VALOR SEGURO", $"{ICMSTot?.Seguros:N2}");
                    CelulaLabel(r.RelativeItem(), "DESCONTO", $"{ICMSTot?.Desconto:N2}");
                    CelulaLabel(r.RelativeItem(), "OUTRAS DESP.", $"{ICMSTot?.Outros:N2}");
                });
                col.Item().Row(r =>
                {
                    CelulaLabel(r.RelativeItem(), "VALOR IPI", $"{ICMSTot?.IPI:N2}");
                    CelulaLabel(r.RelativeItem(), "IPI DEVOLVIDO", $"{ICMSTot?.vIPIDevol:N2}");
                    CelulaLabel(r.RelativeItem(), "PIS", $"{ICMSTot?.PIS:N2}");
                    CelulaLabel(r.RelativeItem(), "COFINS", $"{ICMSTot?.COFINS:N2}");
                    // NT 2024.001 — Total com IBS/CBS/IS quando aplicável
                    var temReforma = Info.Totais?.vNFTot is > 0;
                    CelulaLabel(r.RelativeItem(),
                        temReforma ? "VALOR TOTAL NF (c/ IBS/CBS)" : "VALOR TOTAL NF",
                        temReforma ? $"{Info.Totais!.vNFTot:N2}" : $"{ICMSTot?.TotalNF:N2}");
                });

                // Bloco IBS/CBS (NT 2024.001 - Reforma Tributária)
                var ibsCbs = Info.Totais?.IBSCBSTot;
                if (ibsCbs is not null)
                {
                    col.Item().LineHorizontal(0.3f).LineColor(CorBorda);
                    col.Item().Row(r =>
                    {
                        CelulaLabel(r.RelativeItem(), "IBS/CBS (BC)", $"{ibsCbs.vBCIBSCBS:N2}");
                        CelulaLabel(r.RelativeItem(), "IBS", $"{ibsCbs.gIBS?.vIBS:N2}");
                        CelulaLabel(r.RelativeItem(), "CBS", $"{ibsCbs.gCBS?.vCBS:N2}");
                        CelulaLabel(r.RelativeItem(), "IS", $"{Info.Totais?.IS?.vIS:N2}");
                    });
                }

                // Tributos totais aproximados (Lei 12.741)
                if (ICMSTot?.TotalTributos > 0)
                {
                    col.Item().PaddingVertical(1).PaddingHorizontal(2).Text(
                        $"Valor aprox. dos tributos: R$ {ICMSTot.TotalTributos:N2} (fonte: IBPT)")
                        .FontSize(FonteRotulo).Italic();
                }
            });
        });
    }

    // =========================================================================
    // INFORMAÇÕES ADICIONAIS
    // =========================================================================
    private void ComposeInformacoesAdicionais(IContainer c)
    {
        var infAdic = Info.InformacoesAdicionais;
        c.Border(0.5f).BorderColor(CorBorda).Row(row =>
        {
            row.RelativeItem(3).Padding(0).Column(col =>
            {
                Rotulo(col, "INFORMAÇÕES COMPLEMENTARES");
                col.Item().Padding(2).Text(infAdic?.infCpl ?? string.Empty)
                   .FontSize(FonteRotulo).BreakAnywhere();
            });
            row.ConstantItem(0.5f).Background(CorBorda);
            row.RelativeItem(2).Padding(0).Column(col =>
            {
                Rotulo(col, "INFORMAÇÕES DE INTERESSE DO FISCO");
                col.Item().Padding(2).Text(infAdic?.infAdFisco ?? string.Empty)
                   .FontSize(FonteRotulo).BreakAnywhere();
            });
        });
    }

    // =========================================================================
    // FOOTER: seções abaixo dos itens (repetem em todas as páginas)
    // =========================================================================
    private void ComposeFooter(IContainer c)
    {
        c.Column(col =>
        {
            col.Item().Element(ComposeTransporte);
            col.Item().PaddingTop(1).Element(ComposeTotais);
            col.Item().PaddingTop(1).Element(ComposeInformacoesAdicionais);
            _options.MensagemRodape?.Invoke(col.Item());
        });
    }

    // =========================================================================
    // Helpers de layout
    // =========================================================================

    private static void Rotulo(ColumnDescriptor col, string texto) =>
        col.Item().Background(CorCabecalhoTabela).Padding(1).PaddingLeft(3)
           .Text(texto).FontSize(FonteRotulo).Bold().FontColor(CorPrimaria);

    private static void CelulaLabel(IContainer cell, string rotulo, string? valor) =>
        cell.Column(col =>
        {
            col.Item().Padding(1).PaddingLeft(2).Text(rotulo)
               .FontSize(FonteRotulo).FontColor("#666666");
            col.Item().Padding(1).PaddingLeft(2).Text(valor ?? "-")
               .FontSize(FonteValor);
        });

    private static void CabecalhoTabela(IContainer cell, string texto) =>
        cell.Background(CorCabecalhoTabela).Border(0.3f).BorderColor(CorBorda)
            .Padding(2).AlignCenter()
            .Text(texto).FontSize(FonteRotulo).Bold().FontColor(CorPrimaria);

    private enum AlinhamentoTexto { Esquerda, Centro, Direita }

    private static void CelulaTabela(
        TableDescriptor table, string? valor, string bg,
        AlinhamentoTexto align = AlinhamentoTexto.Esquerda)
    {
        var cell = table.Cell().Background(bg).Border(0.3f).BorderColor(CorBorda).Padding(1).PaddingLeft(2);
        var aligned = align switch
        {
            AlinhamentoTexto.Centro => cell.AlignCenter(),
            AlinhamentoTexto.Direita => cell.AlignRight(),
            _ => cell.AlignLeft()
        };
        aligned.Text(valor ?? string.Empty).FontSize(FonteTabela);
    }

    private static string FormatarChave(string chave)
    {
        if (string.IsNullOrEmpty(chave) || chave.Length != 44) return chave;
        var sb = new System.Text.StringBuilder();
        for (int i = 0; i < 11; i++)
        {
            sb.Append(chave.AsSpan(i * 4, 4));
            if (i < 10) sb.Append(' ');
        }
        return sb.ToString();
    }

    private static string? ObterCst(Item item)
    {
        try
        {
            var icms = item.Imposto?.ICMS?.Tributacao;
            if (icms is null) return null;
            var cst = (int)icms.CST;
            return $"{(int)icms.Origem}{cst}";
        }
        catch { return null; }
    }
}
