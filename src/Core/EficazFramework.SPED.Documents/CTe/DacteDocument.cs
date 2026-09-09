using EficazFramework.SPED.Schemas.CTe;

namespace EficazFramework.SPED.Documents.CTe;

/// <summary>
/// Documento QuestPDF que gera o DACTE (Documento Auxiliar do CT-e) conforme
/// layout v4.00, modal Rodoviário. Orientação retrato (A4).
/// </summary>
public sealed class DacteDocument : IDocument
{
    // ── Paleta de cores ───────────────────────────────────────────────────────
    private const string CorPrimaria   = "#1a3a5c";
    private const string CorSecundaria = "#2e6da4";
    private const string CorBorda      = "#bdc3c7";
    private const string CorCabecalho  = "#d0dce8";

    private const float FonteRotulo = 6f;
    private const float FonteValor  = 8f;
    private const float FonteTitulo = 14f;

    private readonly ProcessoCTe _processo;
    private readonly DacteOptions _options;

    private InformacoesCTe? Info  => _processo.CTe?.Informacoes;
    private IdentificacaoOperacao? Ide => Info?.IdentificacaoOperacao;
    private Emitente? Emit => Info?.Emitente;
    private Remetente? Rem => Info?.Remetente;
    private Destinatario? Dest => Info?.Destinatario;
    private TProtCTeInfProt? Prot => _processo.ProtocoloAutorizacao?.infProt;

    static DacteDocument()
    {
        QuestPDF.Settings.License = LicenseType.Community;
    }

    public DacteDocument(ProcessoCTe processo, DacteOptions options)
    {
        _processo = processo;
        _options  = options;
    }

    public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
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
            page.DefaultTextStyle(x => x.FontFamily("Arial").FontSize(FonteValor));

            page.Header().Column(col =>
            {
                col.Item().Element(ComposeHeaderPrincipal);
                col.Item().PaddingTop(2).Element(ComposeEmitente);
                col.Item().PaddingTop(2).Element(ComposeProtocolo);
                col.Item().PaddingTop(1).LineHorizontal(0.5f).LineColor(CorBorda);
            });

            page.Content().PaddingTop(4).Column(col =>
            {
                col.Item().Element(ComposeParticipantes);
                col.Item().PaddingTop(3).Element(ComposeTomador);
                col.Item().PaddingTop(3).Element(ComposeValores);

                // Modal Rodoviário (NT 2024.003)
                if (Ide?.Modalidade == ModalidadeTransporte.Rodoviario)
                    col.Item().PaddingTop(3).Element(ComposeModalRodoviario);

                col.Item().PaddingTop(3).Element(ComposeDocumentosReferenciados);
                col.Item().PaddingTop(3).Element(ComposeComplemento);
            });

            page.Footer().Element(ComposeFooter);
        });
    }

    // =========================================================================
    // HEADER
    // =========================================================================
    private void ComposeHeaderPrincipal(IContainer c)
    {
        c.Border(0.5f).BorderColor(CorBorda).Row(row =>
        {
            // Logo
            row.RelativeItem(2).Padding(2).AlignMiddle().AlignCenter().Column(col =>
            {
                var logo = _options.LogoTransportadora;
                if (logo is { Length: > 0 })
                    col.Item().MaxHeight(40).Image(logo);
                else
                    col.Item().Text(Emit?.xNome ?? string.Empty).Bold().FontSize(FonteValor);
            });

            // Título
            row.RelativeItem(3).BorderLeft(0.5f).BorderColor(CorBorda).Padding(4).Column(col =>
            {
                col.Item().AlignCenter().Text("DACTE").Bold().FontSize(FonteTitulo).FontColor(CorPrimaria);
                col.Item().AlignCenter().Text("Documento Auxiliar do Conhecimento de Transporte Eletrônico")
                   .FontSize(FonteRotulo);
                col.Item().PaddingTop(4).AlignCenter()
                   .Text($"Nº {Ide?.Numero:D9}   Série {Ide?.Serie}   Modal: {Ide?.Modalidade}")
                   .FontSize(FonteValor).Bold();
            });

            // Chave
            row.RelativeItem(4).BorderLeft(0.5f).BorderColor(CorBorda).Padding(3).Column(col =>
            {
                col.Item().Text("CHAVE DE ACESSO").FontSize(FonteRotulo).FontColor(CorSecundaria).Bold();
                var chave = Prot?.ChaveCTeFormatada ?? FormatarChave(Prot?.chCTe ?? string.Empty);
                col.Item().PaddingTop(1).Text(chave)
                   .FontSize(FonteRotulo + 1).FontFamily("Courier New");

                col.Item().PaddingTop(3).Text("PROTOCOLO DE AUTORIZAÇÃO").FontSize(FonteRotulo).Bold().FontColor(CorSecundaria);
                col.Item().Text(
                    Prot?.nProt is not null
                    ? $"{Prot.nProt}  {Prot.dhRecbto:dd/MM/yyyy HH:mm:ss}"
                    : "SEM PROTOCOLO")
                   .FontSize(FonteRotulo + 1);

                if (_options.MostrarMarcaDagua)
                    col.Item().PaddingTop(2).AlignCenter()
                       .Text("⚠ HOMOLOGAÇÃO - SEM VALOR FISCAL ⚠")
                       .FontSize(FonteRotulo).Bold().FontColor("#e74c3c");
            });
        });
    }

    private void ComposeEmitente(IContainer c)
    {
        c.Border(0.5f).BorderColor(CorBorda).Row(row =>
        {
            row.RelativeItem().Padding(3).Column(col =>
            {
                Rotulo(col, "EMITENTE / TRANSPORTADOR");
                col.Item().Text(Emit?.xNome ?? string.Empty).Bold().FontSize(FonteValor);
                if (!string.IsNullOrEmpty(Emit?.xFant))
                    col.Item().Text(Emit.xFant).FontSize(FonteRotulo);

                var end = Emit?.Endereco;
                if (end is not null)
                    col.Item().Text(
                        $"{end.xLgr}, {end.nro} - {end.xBairro} - {end.xMun}/{end.UF} - CEP {end.CEP}")
                        .FontSize(FonteRotulo);

                col.Item().Text(
                    $"CNPJ: {Emit?.CNPJ_Formatado}  IE: {Emit?.IE}")
                    .FontSize(FonteRotulo);
            });
        });
    }

    private void ComposeProtocolo(IContainer c)
    {
        c.Border(0.5f).BorderColor(CorBorda).Row(row =>
        {
            CelulaLabel(row.RelativeItem(3), "NATUREZA DA PRESTAÇÃO", Ide?.NaturezaOperacao);
            BordaVertical(row);
            CelulaLabel(row.RelativeItem(1), "CFOP", Ide?.CFOP);
            BordaVertical(row);
            CelulaLabel(row.RelativeItem(2), "DATA/HORA EMISSÃO",
                Ide?.DataEmissao?.ToString("dd/MM/yyyy HH:mm:ss") ?? "-");
            BordaVertical(row);
            CelulaLabel(row.RelativeItem(2), "TIPO SERVIÇO", Ide?.TipoServico.ToString());
        });
    }

    // =========================================================================
    // PARTICIPANTES (Remetente / Destinatário / Expedidor / Recebedor)
    // =========================================================================
    private void ComposeParticipantes(IContainer c)
    {
        c.Column(col =>
        {
            // Linha 1: Remetente | Destinatário
            col.Item().Row(row =>
            {
                row.RelativeItem().Border(0.5f).BorderColor(CorBorda).Padding(3).Column(rCol =>
                {
                    Rotulo(rCol, "REMETENTE");
                    rCol.Item().Text(Rem?.xNome ?? string.Empty).Bold().FontSize(FonteValor);
                    var end = Rem?.Endereco;
                    if (end is not null)
                        rCol.Item().Text(
                            $"{end.xLgr}, {end.nro} - {end.xMun}/{end.UF}  CNPJ: {Rem?.CNPJ_CPFFormatado}")
                            .FontSize(FonteRotulo);
                });

                row.ConstantItem(2);

                row.RelativeItem().Border(0.5f).BorderColor(CorBorda).Padding(3).Column(dCol =>
                {
                    Rotulo(dCol, "DESTINATÁRIO");
                    dCol.Item().Text(Dest?.xNome ?? string.Empty).Bold().FontSize(FonteValor);
                    var end = Dest?.Endereco;
                    if (end is not null)
                        dCol.Item().Text(
                            $"{end.xLgr}, {end.nro} - {end.xMun}/{end.UF}  CNPJ/CPF: {Dest?.CNPJ_CPFFormatado}")
                            .FontSize(FonteRotulo);
                });
            });

            // Linha 2: Origem / Destino
            col.Item().PaddingTop(2).Row(row =>
            {
                CelulaLabel(row.RelativeItem(), "MUNICÍPIO ORIGEM",
                    $"{Ide?.MunicipioInicioNome}/{Ide?.UFInicio}");
                row.ConstantItem(2);
                CelulaLabel(row.RelativeItem(), "MUNICÍPIO DESTINO",
                    $"{Ide?.MunicipioFimNome}/{Ide?.UFFim}");
            });
        });
    }

    private void ComposeTomador(IContainer c)
    {
        c.Border(0.5f).BorderColor(CorBorda).Padding(3).Column(col =>
        {
            Rotulo(col, "TOMADOR DO SERVIÇO");

            string? nome = null, cnpj = null, end = null;
            if (Info?.Tomador is TomadorTipo04 t04)
            {
                nome = t04.xNome;
                cnpj = t04.CNPJ_CPFFormatado;
                end = $"{t04.Endereco?.xLgr}, {t04.Endereco?.nro} - {t04.Endereco?.xMun}/{t04.Endereco?.UF}";
            }
            else if (Info?.Tomador is TomadorTipo03 t03)
            {
                (nome, cnpj) = t03.toma switch
                {
                    TipoTomador.Remetente => (Rem?.xNome, Rem?.CNPJ_CPFFormatado),
                    TipoTomador.Destinatario => (Dest?.xNome, Dest?.CNPJ_CPFFormatado),
                    _ => ("-", "-")
                };
            }

            col.Item().Row(row =>
            {
                CelulaLabel(row.RelativeItem(4), "NOME / RAZÃO SOCIAL", nome);
                BordaVertical(row);
                CelulaLabel(row.RelativeItem(2), "CNPJ / CPF", cnpj);
                BordaVertical(row);
                CelulaLabel(row.RelativeItem(3), "ENDEREÇO", end);
            });
        });
    }

    // =========================================================================
    // VALORES
    // =========================================================================
    private void ComposeValores(IContainer c)
    {
        var vals = Info?.Valores;
        var imp = Info?.Impostos;

        c.Border(0.5f).BorderColor(CorBorda).Column(col =>
        {
            Rotulo(col, "VALORES DA PRESTAÇÃO DO SERVIÇO");
            col.Item().Row(row =>
            {
                CelulaLabel(row.RelativeItem(), "VALOR TOTAL DA PRESTAÇÃO", $"{vals?.vTPrest:N2}");
                BordaVertical(row);
                CelulaLabel(row.RelativeItem(), "RECEBIDO POR ACERTO", $"{vals?.vRec:N2}");
                BordaVertical(row);
                CelulaLabel(row.RelativeItem(), "VALOR DO ICMS", ObterValorICMSCTe(imp));
                BordaVertical(row);
                CelulaLabel(row.RelativeItem(), "BASE CÁLC. ICMS", ObterBCICMSCTe(imp));
                BordaVertical(row);
                CelulaLabel(row.RelativeItem(), "ALÍQUOTA ICMS", ObterAliqICMSCTe(imp));
            });
        });
    }

    // =========================================================================
    // MODAL RODOVIÁRIO
    // =========================================================================
    private void ComposeModalRodoviario(IContainer c)
    {
        var cteNorm = Info?.InformacaoCTePorTipo as InformacoesCteNormal;
        var rodo = cteNorm?.infModal?.ItemModal as CTeRodoviario;

        c.Border(0.5f).BorderColor(CorBorda).Column(col =>
        {
            Rotulo(col, "MODAL RODOVIÁRIO");
            col.Item().Row(row =>
            {
                CelulaLabel(row.RelativeItem(2), "RNTRC", rodo?.RNTRC);
                BordaVertical(row);
                CelulaLabel(row.RelativeItem(2), "DATA PREVISTA ENTREGA",
                    rodo?.DataPrevistaEntrega?.ToString("dd/MM/yyyy") ?? "-");
                BordaVertical(row);
                CelulaLabel(row.RelativeItem(3), "LOTAÇÃO", rodo?.lota.ToString());
                BordaVertical(row);
                CelulaLabel(row.RelativeItem(2), "CIOT", rodo?.CIOT);
            });
        });
    }

    // =========================================================================
    // DOCUMENTOS REFERENCIADOS
    // =========================================================================
    private void ComposeDocumentosReferenciados(IContainer c)
    {
        var docs = Info?.DocumentosReferenciados;
        if (docs is null || docs.Count == 0) return;

        c.Border(0.5f).BorderColor(CorBorda).Column(col =>
        {
            Rotulo(col, "DOCUMENTOS REFERENCIADOS");
            foreach (var doc in docs)
            {
                col.Item().Padding(2).Text(doc?.ToString() ?? string.Empty).FontSize(FonteRotulo);
            }
        });
    }

    // =========================================================================
    // COMPLEMENTO
    // =========================================================================
    private void ComposeComplemento(IContainer c)
    {
        var comp = Info?.Complemento;
        if (comp is null) return;

        c.Border(0.5f).BorderColor(CorBorda).Padding(3).Column(col =>
        {
            Rotulo(col, "INFORMAÇÕES COMPLEMENTARES / OBSERVAÇÕES");

            if (!string.IsNullOrEmpty(comp.xObs))
                col.Item().Text(comp.xObs).FontSize(FonteRotulo);

            if (comp.ObsFisco is { Count: > 0 })
                foreach (var obs in comp.ObsFisco)
                    col.Item().Text($"{obs.xCampo}: {obs.xTexto}").FontSize(FonteRotulo);

            if (comp.ObsCont is { Count: > 0 })
                foreach (var obs in comp.ObsCont)
                    col.Item().Text($"{obs.xCampo}: {obs.xTexto}").FontSize(FonteRotulo);
        });
    }

    // =========================================================================
    // FOOTER
    // =========================================================================
    private void ComposeFooter(IContainer c)
    {
        c.Row(row =>
        {
            row.RelativeItem().Text(_options.MensagemRodape ?? string.Empty)
               .FontSize(FonteRotulo).Italic();
            row.ConstantItem(60).AlignRight().Column(col =>
                col.Item().Text(ctx =>
                {
                    ctx.Span("Folha ").FontSize(FonteRotulo);
                    ctx.CurrentPageNumber().FontSize(FonteRotulo).Bold();
                    ctx.Span(" / ").FontSize(FonteRotulo);
                    ctx.TotalPages().FontSize(FonteRotulo).Bold();
                }));
        });
    }

    // =========================================================================
    // Helpers
    // =========================================================================

    private static void Rotulo(ColumnDescriptor col, string texto) =>
        col.Item().Background(CorCabecalho).Padding(1).PaddingLeft(3)
           .Text(texto).FontSize(FonteRotulo).Bold().FontColor(CorPrimaria);

    private static void CelulaLabel(
        IContainer cell, string rotulo, string? valor) =>
        cell.Column(col =>
        {
            col.Item().Padding(1).PaddingLeft(2)
               .Text(rotulo).FontSize(FonteRotulo).FontColor("#666666");
            col.Item().Padding(1).PaddingLeft(2)
               .Text(valor ?? "-").FontSize(FonteValor);
        });

    private static void BordaVertical(RowDescriptor row) =>
        row.ConstantItem(0.5f).Background(CorBorda);

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

    // Helpers para extrair ICMS do CTe (pode ser ICMS00, ICMS20, ICMSST, etc.)
    private static string ObterValorICMSCTe(Impostos? imp)
    {
        try
        {
            var icms = imp?.GetType()?.GetProperty("ICMS")?.GetValue(imp);
            var trib = icms?.GetType()?.GetProperty("Tributacao")?.GetValue(icms);
            var v = trib?.GetType()?.GetProperty("vICMS")?.GetValue(trib) as double?;
            return v.HasValue ? $"{v:N2}" : "-";
        }
        catch { return "-"; }
    }

    private static string ObterBCICMSCTe(Impostos? imp)
    {
        try
        {
            var icms = imp?.GetType()?.GetProperty("ICMS")?.GetValue(imp);
            var trib = icms?.GetType()?.GetProperty("Tributacao")?.GetValue(icms);
            var v = trib?.GetType()?.GetProperty("vBC")?.GetValue(trib) as double?;
            return v.HasValue ? $"{v:N2}" : "-";
        }
        catch { return "-"; }
    }

    private static string ObterAliqICMSCTe(Impostos? imp)
    {
        try
        {
            var icms = imp?.GetType()?.GetProperty("ICMS")?.GetValue(imp);
            var trib = icms?.GetType()?.GetProperty("Tributacao")?.GetValue(icms);
            var v = trib?.GetType()?.GetProperty("pICMS")?.GetValue(trib) as double?;
            return v.HasValue ? $"{v:N2}%" : "-";
        }
        catch { return "-"; }
    }
}
