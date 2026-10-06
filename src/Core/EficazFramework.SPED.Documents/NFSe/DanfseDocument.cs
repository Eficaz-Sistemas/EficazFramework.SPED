using System.Globalization;
using EficazFramework.SPED.Schemas.NFSe.Nacional;
using SchemaNFSe = EficazFramework.SPED.Schemas.NFSe.Nacional.NFSe;

namespace EficazFramework.SPED.Documents.NFSe;

/// <summary>
/// Documento QuestPDF do DANFSe v2.0 (Documento Auxiliar da NFS-e Nacional), conforme o Anexo I da
/// NT 008 SE/CGNFS-e (leiaute com IBS/CBS). Preenchido a partir do schema <see cref="SchemaNFSe"/>.
/// </summary>
/// <remarks>
/// <para>A NT indica Arial e Microsoft Sans Serif; como essas fontes não podem ser distribuídas, o documento usa
/// Lato (fonte embutida no QuestPDF), mantendo tamanhos, estilos e disposição dos blocos.</para>
/// <para>Campos sem conteúdo no XML são exibidos com traço (–).</para>
/// </remarks>
public sealed class DanfseDocument : IDocument
{
    /// <summary>URL da consulta pública usada no QR Code (seguida da chave de acesso).</summary>
    public const string UrlConsultaPublica = "https://www.nfse.gov.br/ConsultaPublica/?tpc=1&chave=";

    private const string Fonte = "Lato";
    private const string CinzaClaro = "#F2F2F2";   // 5% de densidade
    private const string CinzaMarcaDagua = "#A6A6A6"; // K35
    private const string Vermelho = "#FF0000";     // M100/Y100
    private const string Traco = "–";

    private const float FonteTituloBloco = 7f;
    private const float FonteRotulo = 6f;
    private const float FonteValor = 7f;
    private const float BordaExterna = 1f;
    private const float BordaInterna = 0.5f;

    private static readonly CultureInfo PtBr = CultureInfo.GetCultureInfo("pt-BR");

    private readonly SchemaNFSe _nfse;
    private readonly DanfseOptions _options;

    // Atalhos
    private InformacoesNfse? Info => _nfse.InfNFSe;
    private InformacoesDps? Dps => Info?.DPS?.InfDPS;
    private InfoDpsPrestador? Prest => Dps?.Prestador;
    private Emitente? Emit => Info?.Emitente;
    private TotalValores? ValoresDps => Dps?.Valores;
    private TributacaoMunicipal? TribMun => ValoresDps?.Tributos?.Municipais;
    private TributacaoFederal? TribFed => ValoresDps?.Tributos?.tribFed;
    private IbsCbs? IbsCbsNfse => Info?.IBSCBS;
    private TotalIBsCbs? IbsCbsDps => Dps?.IBSCBS;

    static DanfseDocument()
    {
        QuestPDF.Settings.License = LicenseType.Community;
    }

    /// <summary>
    /// Cria o documento.
    /// </summary>
    /// <param name="nfse">NFS-e autorizada (XML do ADN desserializado).</param>
    /// <param name="options">Opções de geração; padrão: <see cref="DanfseOptions"/>.</param>
    public DanfseDocument(SchemaNFSe nfse, DanfseOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(nfse);
        _nfse = nfse;
        _options = options ?? new DanfseOptions();
    }

    /// <inheritdoc />
    public DocumentMetadata GetMetadata() => new()
    {
        Title = $"DANFSe {Info?.Numero}",
        Subject = "Documento Auxiliar da NFS-e",
        Creator = "EficazFramework.SPED.Documents"
    };

    /// <inheritdoc />
    public DocumentSettings GetSettings() => DocumentSettings.Default;

    // =========================================================================
    // Página
    // =========================================================================

    /// <inheritdoc />
    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Size(PageSizes.A4);
            page.MarginHorizontal(0.3f, Unit.Centimetre);
            page.MarginVertical(0.3f, Unit.Centimetre);
            page.PageColor(Colors.White);
            page.DefaultTextStyle(x => x.FontFamily(Fonte).FontSize(FonteValor).FontColor(Colors.Black));

            if (_options.Situacao != SituacaoDanfse.Normal)
            {
                page.Foreground()
                    .AlignCenter()
                    .AlignMiddle()
                    .Rotate(-45)
                    .Text(_options.Situacao == SituacaoDanfse.Cancelada ? "CANCELADA" : "SUBSTITUÍDA")
                    .FontFamily(Fonte)
                    .FontSize(72)
                    .FontColor(CinzaMarcaDagua);
            }

            // Moldura da página inteira; o canhoto (opcional) fica no rodapé, dentro da moldura.
            page.Content().Layers(layers =>
            {
                layers.PrimaryLayer().Border(BordaExterna).ExtendVertical().Column(col =>
                {
                    col.Item().Element(ComposeCabecalho);
                    col.Item().Element(ComposeDadosNfse);
                    col.Item().Element(ComposePrestador);
                    col.Item().Element(ComposeTomador);
                    col.Item().Element(ComposeDestinatario);
                    col.Item().Element(ComposeIntermediario);
                    col.Item().Element(ComposeServico);
                    col.Item().Element(ComposeTributacaoMunicipal);
                    col.Item().Element(ComposeTributacaoFederal);
                    col.Item().Element(ComposeTributacaoIbsCbs);
                    col.Item().Element(ComposeTotais);
                    col.Item().Element(ComposeInformacoesComplementares);
                    if (_options.ExibirCanhoto)
                        col.Item().Height(AlturaCanhoto, Unit.Centimetre); // reserva o espaço do canhoto
                });

                if (_options.ExibirCanhoto)
                    layers.Layer().AlignBottom().Padding(0.3f, Unit.Centimetre).Element(ComposeCanhoto);
            });
        });
    }

    private const float AlturaCanhoto = 1.3f;

    // =========================================================================
    // Cabeçalho
    // =========================================================================
    private void ComposeCabecalho(IContainer c)
    {
        var homologacao = Dps?.Ambiente == Ambiente.Homologacao;

        c.BorderBottom(BordaExterna).Background(CinzaClaro).MinHeight(1.16f, Unit.Centimetre).Padding(3).Row(row =>
        {
            row.RelativeItem(1).AlignMiddle().Element(logo =>
            {
                if (_options.LogoNfse is { Length: > 0 })
                    logo.Height(0.85f, Unit.Centimetre).AlignLeft().Image(_options.LogoNfse).FitArea();
            });

            row.RelativeItem(2).AlignMiddle().Column(titulo =>
            {
                titulo.Item().AlignCenter().Text("DANFSe v2.0").FontSize(9).Bold();
                titulo.Item().AlignCenter().Text("Documento Auxiliar da NFS-e").FontSize(9).Bold();
                if (homologacao)
                    titulo.Item().AlignCenter().Text("NFS-e SEM VALIDADE JURÍDICA").FontSize(9).Bold().FontColor(Vermelho);
            });

            row.RelativeItem(1).AlignMiddle().Column(amb =>
            {
                var uf = UfDoMunicipio(Dps?.LocalEmissaoCodigo);
                var municipio = string.IsNullOrWhiteSpace(Info?.LocalEmissao) ? Traco : Info.LocalEmissao.Trim();
                amb.Item().Text($"Município: {municipio} - {uf ?? Traco}").FontSize(FonteTituloBloco);
                amb.Item().Text($"Ambiente Gerador: {DescricaoAmbienteGerador(Info?.AmbienteGerador)}").FontSize(FonteRotulo);
                amb.Item().Text($"Tipo de Ambiente: {DescricaoTipoAmbiente(Dps?.Ambiente)}").FontSize(FonteRotulo);
            });
        });
    }

    // =========================================================================
    // Dados da NFS-e (3 colunas + QR Code)
    // =========================================================================
    private void ComposeDadosNfse(IContainer c)
    {
        var chave = ChaveAcesso();

        c.Row(row =>
        {
            row.RelativeItem(3).Column(col =>
            {
                Linha(col, 3, Celula.Identificacao("CHAVE DE ACESSO DA NFS-E", chave, 3));
                Linha(col, 3,
                    Celula.Identificacao("NÚMERO DA NFS-E", Info?.Numero > 0 ? Info.Numero.ToString(CultureInfo.InvariantCulture) : null),
                    Celula.Identificacao("COMPETÊNCIA DA NFS-E", DataIso(Dps?.Competencia)),
                    Celula.Identificacao("DATA E HORA DA EMISSÃO DA NFS-E", DataHora(Info?.DataHoraProcessamento)));
                Linha(col, 3,
                    Celula.Identificacao("NÚMERO DA DPS", Dps?.Numero > 0 ? Dps.Numero.ToString(CultureInfo.InvariantCulture) : null),
                    Celula.Identificacao("SÉRIE DA DPS", Dps?.Serie),
                    Celula.Identificacao("DATA E HORA DA EMISSÃO DA DPS", DataHora(Dps?.DataHoraEmissao)));
                Linha(col, 3,
                    Celula.Identificacao("EMITENTE DA NFS-e", DescricaoTipoEmitente(Dps?.TipoEmitente), destaque: true),
                    Celula.Identificacao("SITUAÇÃO DA NFS-e", Truncar(DescricaoSituacao(Info?.CodigoSituacao), 37)),
                    Celula.Identificacao("FINALIDADE", Truncar(DescricaoFinalidade(IbsCbsDps?.finNFSe), 37)));
            });

            row.RelativeItem(1).Padding(3).Column(qr =>
            {
                if (chave != null)
                    qr.Item().AlignCenter().Width(1.9f, Unit.Centimetre).Height(1.9f, Unit.Centimetre).Image(GerarQrCode(UrlConsultaPublica + chave)).FitArea();
                qr.Item().PaddingTop(2).Text(
                    "A autenticidade desta NFS-e pode ser verificada pela leitura deste código QR ou pela consulta da chave de acesso no portal nacional da NFS-e")
                    .FontSize(FonteRotulo);
            });
        });
    }

    // =========================================================================
    // Partes da operação
    // =========================================================================
    private void ComposePrestador(IContainer c)
    {
        var end = Prest?.end;
        var endEmit = Emit?.EnderecoNacional;

        var cMun = end?.Nacional?.MunicipioCodigo ?? endEmit?.MunicipioCodigo;
        var municipio = end?.endExt != null
            ? CidadeExterior(end.endExt)
            : MunicipioUf(cMun, NomeMunicipio(cMun), endEmit?.UF);
        var cep = end?.endExt?.cEndPost ?? end?.Nacional?.CEP ?? endEmit?.CEP;
        var endereco = end != null
            ? MontarEndereco(end.Logradouro, end.Numero, end.xCpl, end.Bairro)
            : MontarEndereco(endEmit?.Logradouro, endEmit?.Numero, endEmit?.xCpl, endEmit?.Bairro);
        var email = Prest?.Email ?? Emit?.Email;

        Bloco(c, col =>
        {
            Linha(col, 4,
                Celula.Titulo("PRESTADOR / FORNECEDOR"),
                Celula.Campo("CNPJ / CPF / NIF", Documento(Prest?.Cnpj ?? Emit?.Cnpj, Prest?.CPF ?? Emit?.CPF, Prest?.NIF)),
                Celula.Campo("Indicador Municipal (Inscrição)", Prest?.InscricaoMunicipal ?? Emit?.InscricaoMunicipal),
                Celula.Campo("Telefone", Telefone(Prest?.Telefone ?? Emit?.Telefone)));
            Linha(col, 4,
                Celula.Campo("Nome / Nome Empresarial", Truncar(Prest?.xNome ?? Emit?.Nome, 77), 2),
                Celula.Campo("Município / Sigla UF", Truncar(municipio, 37)),
                Celula.Campo("Código IBGE / CEP", CodigoIbgeCep(cMun, cep, end?.endExt != null)));
            Linha(col, 4,
                Celula.Campo("Endereço", Truncar(endereco, 77), 2),
                _options.ExibirEmails ? Celula.Campo("E-mail", email, 2) : Celula.Vazia(2));
            Linha(col, 4,
                Celula.Campo("Simples Nacional na Data de Competência", Truncar(DescricaoOpcaoSimples(Prest?.RegimeTributario?.OptanteSimplesNacional), 37)),
                Celula.Campo("Regime de Apuração Tributária pelo SN", Truncar(DescricaoRegimeApuracaoSn(Prest?.RegimeTributario?.regApTribSN), 77), 3));
        });
    }

    private void ComposeTomador(IContainer c)
    {
        var toma = Dps?.Tomador;
        if (toma == null || (string.IsNullOrWhiteSpace(toma.CNPJ) && string.IsNullOrWhiteSpace(toma.CPF) && string.IsNullOrWhiteSpace(toma.NIF)))
        {
            BlocoSuprimido(c, "TOMADOR/ADQUIRENTE DA OPERAÇÃO NÃO IDENTIFICADO NA NFS-e");
            return;
        }

        Bloco(c, col => LinhasParte(col, "TOMADOR / ADQUIRENTE", toma.CNPJ, toma.CPF, toma.NIF, toma.IM, toma.fone, toma.xNome, toma.Endereco, toma.email, exibirIm: true));
    }

    private void ComposeDestinatario(IContainer c)
    {
        var dest = IbsCbsDps?.dest;
        var toma = Dps?.Tomador;
        if (dest == null)
        {
            BlocoSuprimido(c, IbsCbsDps?.indDest == "0" || toma != null
                ? "O DESTINATÁRIO É O PRÓPRIO TOMADOR/ADQUIRENTE DA OPERAÇÃO"
                : "DESTINATÁRIO DA OPERAÇÃO NÃO IDENTIFICADO NA NFS-e");
            return;
        }

        var mesmoDoTomador = toma != null
            && (dest.CNPJ ?? dest.CPF ?? dest.NIF) is { Length: > 0 } docDest
            && docDest == (toma.CNPJ ?? toma.CPF ?? toma.NIF);
        if (mesmoDoTomador)
        {
            BlocoSuprimido(c, "O DESTINATÁRIO É O PRÓPRIO TOMADOR/ADQUIRENTE DA OPERAÇÃO");
            return;
        }

        Bloco(c, col => LinhasParte(col, "DESTINATÁRIO DA OPERAÇÃO", dest.CNPJ, dest.CPF, dest.NIF, null, dest.fone, dest.xNome, dest.end, dest.email, exibirIm: false));
    }

    private void ComposeIntermediario(IContainer c)
    {
        var interm = Dps?.interm;
        if (interm == null || (string.IsNullOrWhiteSpace(interm.CNPJ) && string.IsNullOrWhiteSpace(interm.CPF) && string.IsNullOrWhiteSpace(interm.NIF)))
        {
            BlocoSuprimido(c, "INTERMEDIÁRIO DA OPERAÇÃO NÃO IDENTIFICADO NA NFS-e");
            return;
        }

        Bloco(c, col => LinhasParte(col, "INTERMEDIÁRIO DA OPERAÇÃO", interm.CNPJ, interm.CPF, interm.NIF, interm.IM, interm.fone, interm.xNome, interm.Endereco, interm.email, exibirIm: true));
    }

    /// <summary>Linhas comuns a tomador, destinatário e intermediário.</summary>
    private void LinhasParte(
        ColumnDescriptor col,
        string titulo,
        string? cnpj,
        string? cpf,
        string? nif,
        string? im,
        string? fone,
        string? nome,
        Endereco? end,
        string? email,
        bool exibirIm)
    {
        var cMun = end?.Nacional?.MunicipioCodigo;
        var municipio = end?.endExt != null ? CidadeExterior(end.endExt) : MunicipioUf(cMun, NomeMunicipio(cMun));
        var cep = end?.endExt?.cEndPost ?? end?.Nacional?.CEP;

        Linha(col, 4,
            Celula.Titulo(titulo),
            Celula.Campo("CNPJ / CPF / NIF", Documento(cnpj, cpf, nif)),
            exibirIm ? Celula.Campo("Indicador Municipal (Inscrição)", im) : Celula.Vazia(),
            Celula.Campo("Telefone", Telefone(fone)));
        Linha(col, 4,
            Celula.Campo("Nome / Nome Empresarial", Truncar(nome, 77), 2),
            Celula.Campo("Município / Sigla UF", Truncar(municipio, 37)),
            Celula.Campo("Código IBGE / CEP", CodigoIbgeCep(cMun, cep, end?.endExt != null)));
        Linha(col, 4,
            Celula.Campo("Endereço", Truncar(end == null ? null : MontarEndereco(end.Logradouro, end.Numero, end.xCpl, end.Bairro), 77), 2),
            _options.ExibirEmails ? Celula.Campo("E-mail", email, 2) : Celula.Vazia(2));
    }

    // =========================================================================
    // Serviço prestado
    // =========================================================================
    private void ComposeServico(IContainer c)
    {
        var serv = Dps?.Servico;
        var cServ = serv?.InfoServico;
        var cLocPrest = serv?.LocalPrestacao?.Codigo;
        var paisPrest = serv?.LocalPrestacao?.cPaisPrestacao;
        var localPrestacao = string.IsNullOrWhiteSpace(paisPrest) || paisPrest == "BR"
            ? $"{MunicipioUf(cLocPrest, Info?.LocalPrestacao ?? NomeMunicipio(cLocPrest))} / BR"
            : $"{Info?.LocalPrestacao ?? Traco} / {paisPrest}";

        var codigoTrib = FormatarCodigoTribNacional(cServ?.CodigoTribNacional);
        if (!string.IsNullOrWhiteSpace(cServ?.cTribMun))
            codigoTrib += $" / {cServ.cTribMun}";

        Bloco(c, col =>
        {
            Linha(col, 4,
                Celula.Titulo("SERVIÇO PRESTADO"),
                Celula.Campo("Código de Tributação Nacional / Municipal", codigoTrib),
                Celula.Campo("Código da NBS", FormatarNbs(cServ?.NBS)),
                Celula.Campo("Local da Prestação / Sigla UF / País", Truncar(localPrestacao, 42)));

            // Descrição do código: municipal se houver, senão nacional (sem rótulo, em cinza).
            col.Item().PaddingHorizontal(2).PaddingVertical(1)
                .Text(Truncar(Info?.xTribMun ?? Info?.TributacaoNacional, 167) ?? Traco)
                .FontSize(FonteValor).FontColor(Colors.Grey.Darken1);

            col.Item().MinHeight(2.2f, Unit.Centimetre).PaddingHorizontal(2).PaddingVertical(1).Column(desc =>
            {
                desc.Item().Text("Descrição do Serviço").FontSize(FonteRotulo).Bold();
                desc.Item().Text(Truncar(cServ?.Descricao, 1300) ?? Traco).FontSize(FonteValor);
            });
        });
    }

    // =========================================================================
    // Tributação municipal (ISSQN)
    // =========================================================================
    private void ComposeTributacaoMunicipal(IContainer c)
    {
        var trib = TribMun;
        if (trib == null || string.IsNullOrWhiteSpace(trib.Issqn) || trib.Issqn == "4")
        {
            BlocoSuprimido(c, "TRIBUTAÇÃO MUNICIPAL (ISSQN) - OPERAÇÃO NÃO SUJEITA AO ISSQN");
            return;
        }

        var valores = Info?.Valores;
        var paisResult = string.IsNullOrWhiteSpace(trib.cPaisResult) ? "BR" : trib.cPaisResult;
        var incidencia = $"{MunicipioUf(Info?.LocalIncidenciaCodigo, Info?.LocalIncidenciaNome)} / {paisResult}";
        var regimeEspecial = Prest?.RegimeTributario?.RegimeEspecial;

        var calculoBm = valores?.vCalcBM ?? ParseDecimal(trib.BM?.vRedBCBM);
        var deducoes = valores?.vCalcDR ?? ValoresDps?.vDedRed?.vDR;
        var descontoIncond = ValoresDps?.vDescCondIncond?.vDescIncond;

        Bloco(c, col =>
        {
            Linha(col, 4,
                Celula.Titulo("TRIBUTAÇÃO MUNICIPAL (ISSQN)"),
                Celula.Campo("Tipo de Tributação do ISSQN", DescricaoTributacaoIssqn(trib.Issqn)),
                Celula.Campo("Município / Sigla UF / País de Incidência do ISSQN", Truncar(incidencia, 42), 2));

            // Linhas suprimíveis quando não há dado algum no XML.
            if (regimeEspecial is > 0 || !string.IsNullOrWhiteSpace(trib.tpImunidade) || trib.exigSusp != null)
            {
                Linha(col, 4,
                    Celula.Campo("Regime Especial de Tributação do ISSQN", regimeEspecial is > 0 ? DescricaoRegimeEspecial(regimeEspecial) : null),
                    Celula.Campo("Tipo de Imunidade do ISSQN", Truncar(DescricaoImunidade(trib.tpImunidade), 37)),
                    Celula.Campo("Suspensão da Exigibilidade do ISSQN", Truncar(DescricaoSuspensao(trib.exigSusp?.tpSusp), 37)),
                    Celula.Campo("Número Processo Suspensão", trib.exigSusp?.nProcesso));
            }

            if (!string.IsNullOrWhiteSpace(valores?.tpBM) || calculoBm.HasValue || deducoes.HasValue || descontoIncond.HasValue)
            {
                Linha(col, 4,
                    Celula.Campo("Benefício Municipal", DescricaoBeneficioMunicipal(valores?.tpBM)),
                    Celula.Campo("Cálculo do BM", Moeda(calculoBm)),
                    Celula.Campo("Total Deduções/Reduções", Moeda(deducoes)),
                    Celula.Campo("Desconto Incondicionado", Moeda(descontoIncond)));
            }

            Linha(col, 4,
                Celula.Campo("BC ISSQN", Moeda(valores?.IssqnBaseCalculo)),
                Celula.Campo("Alíquota Aplicada", Percentual(valores?.IssqnAliquota)),
                Celula.Campo("Retenção do ISSQN", DescricaoRetencaoIssqn(trib.TipoRetencao)),
                Celula.Campo("ISSQN Apurado", Moeda(valores?.IssqnValor)));
        });
    }

    // =========================================================================
    // Tributação federal (exceto CBS)
    // =========================================================================
    private void ComposeTributacaoFederal(IContainer c)
    {
        var fed = TribFed;
        var pisCofins = fed?.piscofins;
        var ateFimDe2026 = AnoCompetencia() is null or <= 2026;

        Bloco(c, col =>
        {
            Linha(col, 4,
                Celula.Titulo("TRIBUTAÇÃO FEDERAL (EXCETO CBS)"),
                Celula.Campo("IRRF", Moeda(ParseDecimal(fed?.vRetIRRF))),
                Celula.Campo("Contribuição Previdenciária - Retida", Moeda(ParseDecimal(fed?.vRetCP))),
                Celula.Campo("Contribuições Sociais - Retidas", Moeda(ParseDecimal(fed?.vRetCSLL))));

            // PIS/COFINS de apuração própria: só até o fim de 2026.
            if (ateFimDe2026)
            {
                Linha(col, 4,
                    Celula.Campo("PIS - Débito Apuração Própria", Moeda(pisCofins?.vPis)),
                    Celula.Campo("COFINS - Débito Apuração Própria", Moeda(pisCofins?.vCofins)),
                    Celula.Campo("Descrição Contrib. Sociais - Retidas", Truncar(DescricaoRetencaoPisCofins(pisCofins?.tpRetPisCofins), 35)),
                    Celula.Vazia());
            }
        });
    }

    // =========================================================================
    // Tributação IBS / CBS
    // =========================================================================
    private void ComposeTributacaoIbsCbs(IContainer c)
    {
        var sitClas = IbsCbsDps?.valores?.trib?.gIBSCBS;
        var valores = IbsCbsNfse?.valores;
        var tot = IbsCbsNfse?.totCIBS;

        var cst = string.IsNullOrWhiteSpace(sitClas?.CST) && string.IsNullOrWhiteSpace(sitClas?.cClassTrib)
            ? null
            : $"{sitClas?.CST ?? Traco} / {sitClas?.cClassTrib ?? Traco}";

        var cLocIncid = IbsCbsNfse?.cLocalidadeIncid;
        var incidencia = string.IsNullOrWhiteSpace(IbsCbsDps?.cIndOp) && string.IsNullOrWhiteSpace(cLocIncid)
            ? null
            : $"{IbsCbsDps?.cIndOp ?? Traco} / {cLocIncid ?? Traco} / {IbsCbsNfse?.xLocalidadeIncid ?? NomeMunicipio(cLocIncid) ?? Traco} / {UfDoMunicipio(cLocIncid) ?? Traco}";

        decimal? exclusoes = null;
        if (IbsCbsNfse != null)
        {
            exclusoes = (ValoresDps?.vDescCondIncond?.vDescIncond ?? 0m)
                + (valores?.vCalcReeRepRes ?? 0m)
                + (Info?.Valores?.IssqnValor ?? 0m)
                + (TribFed?.piscofins?.vPis ?? 0m)
                + (TribFed?.piscofins?.vCofins ?? 0m);
        }

        var reducoes = valores?.uf?.pRedAliqUF == null && valores?.mun?.pRedAliqMun == null && valores?.fed?.pRedAliqCBS == null
            ? null
            : $"{Percentual(valores?.uf?.pRedAliqUF) ?? Traco} / {Percentual(valores?.mun?.pRedAliqMun) ?? Traco} / {Percentual(valores?.fed?.pRedAliqCBS) ?? Traco}";
        var aliquotasIbs = valores?.uf?.pIBSUF == null && valores?.mun?.pIBSMun == null
            ? null
            : $"{Percentual(valores?.uf?.pIBSUF) ?? Traco} / {Percentual(valores?.mun?.pIBSMun) ?? Traco}";

        Bloco(c, col =>
        {
            Linha(col, 4,
                Celula.Titulo("TRIBUTAÇÃO IBS / CBS"),
                Celula.Campo("CST / cClassTrib", cst),
                Celula.Campo("Indicador de Operação / Código IBGE Incidência / Município Incidência / Sigla UF", Truncar(incidencia, 56), 2));
            Linha(col, 4,
                Celula.Campo("Exclusões e Reduções da Base de Cálculo", Moeda(exclusoes)),
                Celula.Campo("Base de Cálculo Após Exclusões e Reduções", Moeda(valores?.vBC)),
                Celula.Campo("Red. Alíquota IBS / Red. Alíquota CBS", reducoes),
                Celula.Campo("Alíquota – IBS UF / IBS Mun", aliquotasIbs));
            Linha(col, 4,
                Celula.Campo("Alíq. Efetiva Municipal – IBS", Percentual(valores?.mun?.pAliqEfetMun)),
                Celula.Campo("Valor Apurado Municipal – IBS", Moeda(ParseDecimal(tot?.gIBS?.gIBSMunTot?.vIBSMun))),
                Celula.Campo("Alíq. Efetiva Estadual – IBS", Percentual(valores?.uf?.pAliqEfetUF)),
                Celula.Campo("Valor Apurado Estadual – IBS", Moeda(ParseDecimal(tot?.gIBS?.gIBSUFTot?.vIBSUF))));
            Linha(col, 4,
                Celula.Campo("Valor Total Apurado – IBS", Moeda(tot?.gIBS?.vIBSTot)),
                Celula.Campo("Alíquota - CBS", Percentual(valores?.fed?.pCBS)),
                Celula.Campo("Alíquota Efetiva – CBS", Percentual(valores?.fed?.pAliqEfetCBS)),
                Celula.Campo("Valor Total Apurado – CBS", Moeda(ParseDecimal(tot?.gCBS?.vCBS))));
        });
    }

    // =========================================================================
    // Valor total da NFS-e
    // =========================================================================
    private void ComposeTotais(IContainer c)
    {
        var tot = IbsCbsNfse?.totCIBS;
        var ibs = tot?.gIBS?.vIBSTot;
        var cbs = ParseDecimal(tot?.gCBS?.vCBS);
        decimal? totalIbsCbs = ibs.HasValue || cbs.HasValue ? (ibs ?? 0m) + (cbs ?? 0m) : null;

        Bloco(c, col =>
        {
            Linha(col, 4,
                Celula.Titulo("VALOR TOTAL DA NFS-E"),
                Celula.Principal("VALOR DA OPERAÇÃO / SERVIÇO", Moeda(ValoresDps?.ValoresPrestacao?.ValorServico)),
                Celula.Campo("Desconto Incondicionado", Moeda(ValoresDps?.vDescCondIncond?.vDescIncond)),
                Celula.Campo("Desconto Condicionado", Moeda(ValoresDps?.vDescCondIncond?.vDescCond)));
            Linha(col, 4,
                Celula.Campo("Total das Retenções (ISSQN / Federais)", Moeda(Info?.Valores?.ValorTotalRetencoes)),
                Celula.Principal("VALOR LÍQUIDO DA NFS-e", Moeda(Info?.Valores?.ValorTotalLiquido)),
                Celula.Campo("Total do IBS/CBS", Moeda(totalIbsCbs)),
                Celula.Principal("VALOR LÍQUIDO DA NFS-e + IBS/CBS", Moeda(tot?.vTotNF), destaque: true));
        });
    }

    // =========================================================================
    // Informações complementares
    // =========================================================================
    private void ComposeInformacoesComplementares(IContainer c)
    {
        var serv = Dps?.Servico;
        var compl = serv?.infoCompl;
        var linhas = new List<string>();

        void Adicionar(string rotulo, string? valor)
        {
            if (!string.IsNullOrWhiteSpace(valor))
                linhas.Add($"{rotulo}: {valor.Trim()}");
        }

        Adicionar("Inf. Cont.", compl?.xInfComp);
        Adicionar("NFS-e Subst.", Dps?.subst?.chSubstda);
        Adicionar("Doc. Ref.", compl?.docRef);
        Adicionar("Cod. Obra", serv?.obra?.cObra);
        Adicionar("Insc. Imob.", serv?.obra?.inscImobFisc);
        Adicionar("Cod. Evt.", serv?.atvEvento?.idAtvEvt);
        Adicionar("Doc. Tec.", compl?.idDocTec);
        Adicionar("Núm. Ped.", compl?.xPed);
        Adicionar("Item Ped.", compl?.gItemPed?.xItemPed is { Length: > 0 } itens ? string.Join(", ", itens) : null);
        Adicionar("Inf. A. T. Mun.", Info?.xOutInf);

        // Limite da NT: 1997 caracteres, sem contar a linha obrigatória dos tributos aproximados.
        var texto = Truncar(string.Join(";\n", linhas), 1997);

        Bloco(c, col =>
        {
            col.Item().MinHeight(2f, Unit.Centimetre).PaddingHorizontal(2).PaddingVertical(1).Column(info =>
            {
                info.Item().Text("INFORMAÇÕES COMPLEMENTARES").FontSize(FonteTituloBloco).Bold();
                if (!string.IsNullOrWhiteSpace(texto))
                    info.Item().Text(texto + ";").FontSize(FonteValor);
                info.Item().Text(TotaisAproximados()).FontSize(FonteValor);
            });
        });
    }

    /// <summary>Linha obrigatória dos tributos aproximados (Lei nº 12.741/2012).</summary>
    private string TotaisAproximados()
    {
        var tot = ValoresDps?.Tributos?.TotalTributos;
        string fed, est, mun;

        if (tot?.ValorTotalTributos is { } v)
        {
            fed = Moeda(v.Federais) ?? Traco;
            est = Moeda(v.Estaduais) ?? Traco;
            mun = Moeda(v.Municipais) ?? Traco;
        }
        else if (tot?.pTotTrib is { } p)
        {
            fed = Percentual(ParseDecimal(p.pTotTribFed)) ?? Traco;
            est = Percentual(ParseDecimal(p.pTotTribEst)) ?? Traco;
            mun = Percentual(ParseDecimal(p.pTotTribMun)) ?? Traco;
        }
        else if (ParseDecimal(tot?.pTotTribSN) is { } sn)
        {
            return $"Totais Aproximados dos Tributos cfe. Lei nº 12.741/2012: Simples Nacional: {Percentual(sn)};";
        }
        else
        {
            fed = est = mun = Traco;
        }

        return $"Totais Aproximados dos Tributos cfe. Lei nº 12.741/2012: Federais: {fed}; Estaduais: {est}; Municipais: {mun};";
    }

    // =========================================================================
    // Canhoto (opcional)
    // =========================================================================
    private void ComposeCanhoto(IContainer c)
    {
        var numeroChave = $"{(Info?.Numero > 0 ? Info.Numero.ToString(CultureInfo.InvariantCulture) : Traco)} / {ChaveAcesso() ?? Traco}";

        c.Border(BordaExterna).MinHeight(0.67f, Unit.Centimetre).Row(row =>
        {
            row.RelativeItem(1).Padding(2).Text("DATA CIENTIFICAÇÃO:").FontSize(FonteTituloBloco).Bold();
            row.RelativeItem(1).BorderLeft(BordaExterna).Padding(2).Text("IDENTIFICAÇÃO E ASSINATURA").FontSize(FonteTituloBloco).Bold();
            row.RelativeItem(2).BorderLeft(BordaExterna).Padding(2).Column(cel =>
            {
                cel.Item().Text("Nº NFS-e / CHAVE NFS-e").FontSize(FonteTituloBloco).Bold();
                cel.Item().Text(numeroChave).FontSize(FonteValor);
            });
        });
    }

    // =========================================================================
    // Estrutura: grade de 4 colunas
    // =========================================================================

    private enum TipoCelula { Campo, Titulo, Identificacao, Principal, Vazia }

    /// <summary>Célula da grade: ocupa <c>Span</c> colunas.</summary>
    private sealed record Celula(TipoCelula Tipo, string? Rotulo, string? Valor, int Span, bool Destaque)
    {
        public static Celula Campo(string rotulo, string? valor, int span = 1) => new(TipoCelula.Campo, rotulo, valor, span, false);
        public static Celula Titulo(string titulo) => new(TipoCelula.Titulo, titulo, null, 1, true);
        public static Celula Identificacao(string rotulo, string? valor, int span = 1, bool destaque = false) => new(TipoCelula.Identificacao, rotulo, valor, span, destaque);
        public static Celula Principal(string rotulo, string? valor, bool destaque = false) => new(TipoCelula.Principal, rotulo, valor, 1, destaque);
        public static Celula Vazia(int span = 1) => new(TipoCelula.Vazia, null, null, span, false);
    }

    /// <summary>Bloco separado do anterior por uma linha de 1 pt.</summary>
    private static void Bloco(IContainer c, Action<ColumnDescriptor> conteudo) =>
        c.BorderTop(BordaExterna).PaddingBottom(1).Column(conteudo);

    /// <summary>Bloco suprimido: só a mensagem, em uma linha (altura mínima 0,32 cm).</summary>
    private static void BlocoSuprimido(IContainer c, string mensagem)
    {
        c.BorderTop(BordaExterna).MinHeight(0.32f, Unit.Centimetre).PaddingHorizontal(2).PaddingVertical(1)
            .Text(mensagem).FontSize(FonteTituloBloco).Bold();
    }

    /// <summary>Linha da grade; completa com células vazias até <paramref name="colunas"/>.</summary>
    private static void Linha(ColumnDescriptor col, int colunas, params Celula[] celulas)
    {
        var ocupadas = celulas.Sum(x => x.Span);
        col.Item().Row(row =>
        {
            foreach (var celula in celulas)
                ComposeCelula(row.RelativeItem(celula.Span), celula);
            if (ocupadas < colunas)
                row.RelativeItem(colunas - ocupadas);
        });
    }

    private static void ComposeCelula(IContainer c, Celula celula)
    {
        if (celula.Destaque)
            c = c.Background(CinzaClaro);

        c = c.PaddingHorizontal(2).PaddingVertical(1.5f);

        switch (celula.Tipo)
        {
            case TipoCelula.Vazia:
                return;
            case TipoCelula.Titulo:
                c.Text(celula.Rotulo!).FontSize(FonteTituloBloco).Bold();
                return;
        }

        c.Column(cel =>
        {
            var rotulo = cel.Item().Text(celula.Rotulo!).Bold();
            rotulo.FontSize(celula.Tipo is TipoCelula.Identificacao or TipoCelula.Principal ? FonteTituloBloco : FonteRotulo);
            cel.Item().Text(string.IsNullOrWhiteSpace(celula.Valor) ? Traco : celula.Valor).FontSize(FonteValor);
        });
    }

    // =========================================================================
    // QR Code
    // =========================================================================
    private static byte[] GerarQrCode(string conteudo)
    {
        using var gerador = new QRCoder.QRCodeGenerator();
        using var dados = gerador.CreateQrCode(conteudo, QRCoder.QRCodeGenerator.ECCLevel.M);
        using var png = new QRCoder.PngByteQRCode(dados);
        return png.GetGraphic(10);
    }

    // =========================================================================
    // Formatação
    // =========================================================================

    /// <summary>Chave de acesso (50 dígitos) a partir do Id do infNFSe ("NFS" + chave).</summary>
    private string? ChaveAcesso()
    {
        var id = Info?.Id;
        if (string.IsNullOrWhiteSpace(id))
            return null;
        var digitos = SomenteDigitos(id);
        return digitos.Length > 0 ? digitos : null;
    }

    private int? AnoCompetencia() =>
        DateTime.TryParseExact(Dps?.Competencia, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var d) ? d.Year : null;

    private string? NomeMunicipio(string? codigoIbge)
    {
        if (string.IsNullOrWhiteSpace(codigoIbge))
            return null;
        var nome = _options.NomeMunicipio?.Invoke(codigoIbge);
        if (!string.IsNullOrWhiteSpace(nome))
            return nome;
        // Nomes conhecidos pelo próprio XML
        if (codigoIbge == Dps?.LocalEmissaoCodigo) return Info?.LocalEmissao;
        if (codigoIbge == Info?.LocalIncidenciaCodigo) return Info?.LocalIncidenciaNome;
        if (codigoIbge == Dps?.Servico?.LocalPrestacao?.Codigo) return Info?.LocalPrestacao;
        return null;
    }

    private static string? MunicipioUf(string? codigoIbge, string? nome, string? uf = null)
    {
        uf ??= UfDoMunicipio(codigoIbge);
        if (string.IsNullOrWhiteSpace(nome) && string.IsNullOrWhiteSpace(uf))
            return null;
        return $"{(string.IsNullOrWhiteSpace(nome) ? Traco : nome.Trim())} / {uf ?? Traco}";
    }

    private static string CidadeExterior(EnderecoExterior ext)
    {
        var partes = new[] { ext.xCidade, ext.xEstProvReg, ext.cPais }.Where(p => !string.IsNullOrWhiteSpace(p));
        return string.Join(" / ", partes);
    }

    private static string? CodigoIbgeCep(string? codigoIbge, string? cep, bool exterior)
    {
        if (string.IsNullOrWhiteSpace(codigoIbge) && string.IsNullOrWhiteSpace(cep))
            return null;
        var cepFormatado = exterior ? cep : FormatarCep(cep);
        return $"{(string.IsNullOrWhiteSpace(codigoIbge) ? Traco : codigoIbge)} / {cepFormatado ?? Traco}";
    }

    private static string? FormatarCep(string? cep)
    {
        var d = SomenteDigitos(cep);
        return d.Length == 8 ? $"{d[..2]}.{d[2..5]}-{d[5..]}" : (string.IsNullOrWhiteSpace(cep) ? null : cep);
    }

    private static string? MontarEndereco(string? logradouro, string? numero, string? complemento, string? bairro)
    {
        var partes = new[] { logradouro, numero, complemento, bairro }
            .Where(p => !string.IsNullOrWhiteSpace(p))
            .Select(p => p!.Trim());
        var texto = string.Join(", ", partes);
        return texto.Length == 0 ? null : texto;
    }

    private static string? Documento(string? cnpj, string? cpf, string? nif)
    {
        var dCnpj = SomenteDigitos(cnpj);
        if (dCnpj.Length == 14)
            return $"{dCnpj[..2]}.{dCnpj[2..5]}.{dCnpj[5..8]}/{dCnpj[8..12]}-{dCnpj[12..]}";
        var dCpf = SomenteDigitos(cpf);
        if (dCpf.Length == 11)
            return $"{dCpf[..3]}.{dCpf[3..6]}.{dCpf[6..9]}-{dCpf[9..]}";
        return string.IsNullOrWhiteSpace(nif) ? (cnpj ?? cpf) : nif;
    }

    private static string? Telefone(string? fone) => string.IsNullOrWhiteSpace(fone) ? null : Truncar(fone.Trim(), 20);

    private static string? FormatarCodigoTribNacional(string? codigo)
    {
        var d = SomenteDigitos(codigo);
        return d.Length == 6 ? $"{d[..2]}.{d[2..4]}.{d[4..]}" : codigo;
    }

    private static string? FormatarNbs(string? nbs)
    {
        var d = SomenteDigitos(nbs);
        return d.Length == 9 ? $"{d[..1]}.{d[1..5]}.{d[5..7]}.{d[7..]}" : nbs;
    }

    private static string? DataIso(string? data) =>
        DateTime.TryParseExact(data, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var d)
            ? d.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
            : data;

    private static string? DataHora(DateTimeOffset? data) =>
        data is { } d && d != default ? d.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture) : null;

    private static string? Moeda(decimal? valor) => valor?.ToString("C2", PtBr);

    private static string? Percentual(decimal? valor) => valor.HasValue ? valor.Value.ToString("N2", PtBr) + "%" : null;

    private static decimal? ParseDecimal(string? valor) =>
        decimal.TryParse(valor, NumberStyles.Number, CultureInfo.InvariantCulture, out var d) ? d : null;

    private static string SomenteDigitos(string? valor) => new((valor ?? string.Empty).Where(char.IsDigit).ToArray());

    /// <summary>Trunca com reticências quando o texto passa do limite indicado pela NT.</summary>
    private static string? Truncar(string? texto, int limite)
    {
        if (string.IsNullOrWhiteSpace(texto))
            return null;
        var t = texto.Trim();
        return t.Length <= limite ? t : t[..limite].TrimEnd() + "...";
    }

    /// <summary>Sigla da UF pelos dois primeiros dígitos do código IBGE do município.</summary>
    internal static string? UfDoMunicipio(string? codigoIbge)
    {
        var d = SomenteDigitos(codigoIbge);
        if (d.Length < 2)
            return null;
        return d[..2] switch
        {
            "11" => "RO", "12" => "AC", "13" => "AM", "14" => "RR", "15" => "PA", "16" => "AP", "17" => "TO",
            "21" => "MA", "22" => "PI", "23" => "CE", "24" => "RN", "25" => "PB", "26" => "PE", "27" => "AL", "28" => "SE", "29" => "BA",
            "31" => "MG", "32" => "ES", "33" => "RJ", "35" => "SP",
            "41" => "PR", "42" => "SC", "43" => "RS",
            "50" => "MS", "51" => "MT", "52" => "GO", "53" => "DF",
            _ => null
        };
    }

    // =========================================================================
    // Descrições dos códigos (leiaute DPS/NFS-e v1.01)
    // =========================================================================
    private static string? DescricaoAmbienteGerador(AmbienteGerador? amb) => amb switch
    {
        AmbienteGerador.Prefeitura => "Prefeitura",
        AmbienteGerador.SistemaNacional => "Sistema Nacional da NFS-e",
        _ => Traco
    };

    private static string DescricaoTipoAmbiente(Ambiente? amb) => amb switch
    {
        Ambiente.Producao => "Produção",
        Ambiente.Homologacao => "Homologação",
        _ => Traco
    };

    private static string? DescricaoTipoEmitente(EmitenteDps? tipo) => tipo switch
    {
        EmitenteDps.Prestador => "Prestador",
        EmitenteDps.Tomador => "Tomador",
        EmitenteDps.Intermediario => "Intermediário",
        _ => null
    };

    private static string? DescricaoSituacao(string? cStat) => cStat switch
    {
        null or "" => null,
        "100" => "NFS-e Gerada",
        "101" => "NFS-e de Substituição Gerada",
        "102" => "NFS-e de Decisão Judicial ou Administrativa",
        "103" => "NFS-e Avulsa",
        _ => cStat
    };

    private static string? DescricaoFinalidade(string? finNFSe) => finNFSe switch
    {
        null or "" => null,
        "0" => "NFS-e regular",
        _ => finNFSe
    };

    private static string? DescricaoOpcaoSimples(int? op) => op switch
    {
        1 => "Não Optante",
        2 => "Optante - Microempreendedor Individual (MEI)",
        3 => "Optante - Microempresa ou Empresa de Pequeno Porte (ME/EPP)",
        null => null,
        _ => op.Value.ToString(CultureInfo.InvariantCulture)
    };

    private static string? DescricaoRegimeApuracaoSn(int? regime) => regime switch
    {
        1 => "Regime de apuração dos tributos federais e municipal pelo SN",
        2 => "Regime de apuração dos tributos federais pelo SN e ISSQN por fora do SN conforme respectiva legislação municipal do tributo",
        3 => "Regime de apuração dos tributos federais e municipal por fora do SN conforme respectivas legislações federal e municipal de cada tributo",
        null => null,
        _ => regime.Value.ToString(CultureInfo.InvariantCulture)
    };

    private static string? DescricaoRegimeEspecial(int? regime) => regime switch
    {
        0 => "Nenhum",
        1 => "Ato Cooperado (Cooperativa)",
        2 => "Estimativa",
        3 => "Microempresa Municipal",
        4 => "Notário ou Registrador",
        5 => "Profissional Autônomo",
        6 => "Sociedade de Profissionais",
        9 => "Outros",
        null => null,
        _ => regime.Value.ToString(CultureInfo.InvariantCulture)
    };

    private static string? DescricaoTributacaoIssqn(string? trib) => trib switch
    {
        "1" => "Operação Tributável",
        "2" => "Imunidade",
        "3" => "Exportação de Serviço",
        "4" => "Não Incidência",
        _ => trib
    };

    private static string? DescricaoImunidade(string? tipo) => tipo switch
    {
        null or "" => null,
        "0" => "Imunidade (tipo não informado na nota de origem)",
        "1" => "Patrimônio, renda ou serviços, uns dos outros (CF88, Art 150, VI, a)",
        "2" => "Templos de qualquer culto (CF88, Art 150, VI, b)",
        "3" => "Partidos políticos, sindicatos, educação e assistência social (CF88, Art 150, VI, c)",
        "4" => "Livros, jornais, periódicos e o papel destinado a sua impressão (CF88, Art 150, VI, d)",
        "5" => "Fonogramas e videofonogramas musicais (CF88, Art 150, VI, e)",
        _ => tipo
    };

    private static string? DescricaoSuspensao(string? tipo) => tipo switch
    {
        null or "" => null,
        "1" => "Exigibilidade Suspensa por Decisão Judicial",
        "2" => "Exigibilidade Suspensa por Processo Administrativo",
        _ => tipo
    };

    private static string? DescricaoBeneficioMunicipal(string? tipo) => tipo switch
    {
        null or "" => null,
        "1" => "Isenção",
        "2" => "Redução da BC em percentual",
        "3" => "Redução da BC em valor",
        "4" => "Alíquota Diferenciada",
        _ => tipo
    };

    private static string? DescricaoRetencaoIssqn(string? tipo) => tipo switch
    {
        null or "" => null,
        "1" => "Não Retido",
        "2" => "Retido pelo Tomador",
        "3" => "Retido pelo Intermediário",
        _ => tipo
    };

    private static string? DescricaoRetencaoPisCofins(string? tipo) => tipo switch
    {
        null or "" => null,
        "0" => "PIS/COFINS/CSLL Não Retidos",
        "1" => "PIS/COFINS Retidos",
        "2" => "PIS/COFINS Não Retidos",
        "3" => "PIS/COFINS/CSLL Retidos",
        "4" => "PIS/COFINS Retidos, CSLL Não Retido",
        "5" => "PIS Retido, COFINS/CSLL Não Retido",
        "6" => "COFINS Retido, PIS/CSLL Não Retido",
        "7" => "PIS Não Retido, COFINS/CSLL Retidos",
        "8" => "PIS/COFINS Não Retidos, CSLL Retido",
        "9" => "COFINS Não Retido, PIS/CSLL Retidos",
        _ => tipo
    };
}
