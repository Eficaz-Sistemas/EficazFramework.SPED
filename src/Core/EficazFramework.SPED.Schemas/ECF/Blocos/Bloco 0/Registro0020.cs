
namespace EficazFramework.SPED.Schemas.ECF;

/// <summary>
/// Parâmetros de Tributação
/// </summary>
/// <remarks></remarks>
public class Registro0020 : Primitives.Registro
{
    public Registro0020() : base("0020")
    {
    }

    public Registro0020(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos
    public IndicadorAliquotaCSLL2015 FormaTributacao { get; set; } = IndicadorAliquotaCSLL2015.NovePorcento;
    public int? QuantidadeSCP { get; set; } = default;
    public bool AdminFundoClubeInvest { get; set; } = false;
    public bool ParticipacoesConsorcios { get; set; } = false;
    public bool OperacoesExterior { get; set; } = false;
    public bool OperacoesVinculadas { get; set; } = false;
    /// <summary>
    /// PJ Enquadrada nos artigos 48 ou 49 da Instrução Normativa RFB nº 1.312/2012
    /// </summary>
    public bool EnquadramentoArts48ou49_IN_1312_12 { get; set; } = false;
    public bool ParticipacoesExterior { get; set; } = false;
    public bool AtividadeRural { get; set; } = false;
    public bool LucroExploracao { get; set; } = false;
    public bool IsencaoReducaoLucroPresumido { get; set; } = false;
    public bool Finor_Finam { get; set; } = false;
    public bool DoacaoEleitoral { get; set; } = false;
    public bool ParticipAvMetodoEquivPatrim { get; set; } = false;
    public bool VendasExportacao { get; set; } = false;
    public bool RecebimExterior { get; set; } = false;
    public bool AtivosNoExterior { get; set; } = false;
    public bool PJExportadora { get; set; } = false;
    public bool PagtosExterior { get; set; } = false;
    public bool ComEletronicoTI { get; set; } = false;
    public bool RoyaltiesRecebidos { get; set; } = false;
    public bool RoyaltiesPagos { get; set; } = false;
    public bool RendServicosJurosDivRecebidos { get; set; } = false;
    public bool PgRemessasTitServicosJurosDiv { get; set; } = false;
    public bool InovacaoTenologica { get; set; } = false;
    public bool CapacitacaoInformaticaInclDigital { get; set; } = false;
    /// <summary>
    /// PJ Habilitada ao Repes, Recap, Padis, Reidi, Recine, Retid, Óleo Bunker, Reporto, RET II, 
    /// RET PMCMV/PCVA, RET EEI, EBAS Imune, Repetro-Industrialização, RepetroNacional, Repetro-Permanente e 
    /// Repetro-Temporário:
    /// </summary>
    public bool RecapRepesPadisPatvdReidiOlimpEDemaisDiachos { get; set; } = false;
    public bool PoloIndManausAmazonaOcidencal { get; set; } = false;
    public bool ZonaExportacao { get; set; } = false;
    public bool AreaLivreComercio { get; set; } = false;
    public bool IntegranteMultinacional { get; set; } = false;
    public bool DEREX { get; set; } = false;
    /// <summary>
    /// Opção pelas novas regras de preços de transferência no ano-calendário 2023 (Lei nº 14.956/2023)
    /// </summary>
    public bool OpcaoLei14956_2023 { get; set; } = false;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|0020|"); // 1
        writer.Append(FormaTributacao != IndicadorAliquotaCSLL2015.NA ? $"{(int)FormaTributacao}|" : "|"); // 2
        writer.Append(QuantidadeSCP + "|"); // 3
        writer.Append(AdminFundoClubeInvest ? "S|" : "N|"); // 4
        writer.Append(ParticipacoesConsorcios ? "S|" : "N|"); // 5
        writer.Append(OperacoesExterior ? "S|" : "N|"); // 6
        writer.Append(OperacoesVinculadas ? "S|" : "N|"); // 7
        writer.Append(EnquadramentoArts48ou49_IN_1312_12 ? "S|" : "N|"); // 8
        writer.Append(ParticipacoesExterior ? "S|" : "N|"); // 9
        writer.Append(AtividadeRural ? "S|" : "N|"); // 10
        writer.Append(LucroExploracao ? "S|" : "N|"); // 11
        writer.Append(IsencaoReducaoLucroPresumido ? "S|" : "N|"); // 12
        writer.Append(Finor_Finam ? "S|" : "N|"); // 13

        if (int.Parse(Versao) < 7)
            writer.Append(DoacaoEleitoral ? "S|" : "N|"); // 14

        writer.Append(ParticipAvMetodoEquivPatrim ? "S|" : "N|"); // 14 (sim, atualmente é o campo 14)


        if (int.Parse(Versao) < 7)
            writer.Append(VendasExportacao ? "S|" : "N|"); // 15

        writer.Append(RecebimExterior ? "S|" : "N|"); // 15 (sim, atualmente é o campo 15)

        writer.Append(AtivosNoExterior ? "S|" : "N|"); // 16

        if (int.Parse(Versao) < 7)
            writer.Append(PJExportadora ? "S|" : "N|"); // 17

        writer.Append(PagtosExterior ? "S|" : "N|"); // 17 (sim, atualmente é o campo 17)

        writer.Append(ComEletronicoTI ? "S|" : "N|"); // 18
        writer.Append(RoyaltiesRecebidos ? "S|" : "N|"); // 19
        writer.Append(RoyaltiesPagos ? "S|" : "N|"); // 20
        writer.Append(RendServicosJurosDivRecebidos ? "S|" : "N|"); // 21
        writer.Append(PgRemessasTitServicosJurosDiv ? "S|" : "N|"); // 22
        writer.Append(InovacaoTenologica ? "S|" : "N|"); // 23
        writer.Append(CapacitacaoInformaticaInclDigital ? "S|" : "N|"); // 24
        writer.Append(RecapRepesPadisPatvdReidiOlimpEDemaisDiachos ? "S|" : "N|"); // 25
        writer.Append(PoloIndManausAmazonaOcidencal ? "S|" : "N|"); // 26
        writer.Append(ZonaExportacao ? "S|" : "N|"); // 27
        writer.Append(AreaLivreComercio ? "S|" : "N|"); // 28
        writer.Append(IntegranteMultinacional ? "S|" : "N|"); // 29
        writer.Append(DEREX ? "S|" : "N|"); // 30

        if (int.Parse(Versao) >= 10)
            writer.Append(OpcaoLei14956_2023 ? "S|" : "N|"); // 31

        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        // Me.DataInicial = data(3).ToDate
        // Me.DataFinal = data(4).ToDate
        // Me.NomeEmpresarialPJ = data(5)
        // Me.CNPJ = data(6)
        // Me.UF = data(7)
        // Me.IEPj = data(8)
        // Me.CodMunicipio = data(9)
        // Me.InscMunicipal = data(10)
        // Me.IndicadorSitEspecial = data(11)
        // Me.IndicadorSitInicioPeriodo = data(12)
        // Me.IndicadorExistNire = data(13).ToEnum(Of IndicadorExistNire)(IndicadorExistNire.EmpresaPossuiRegistroJunta)
        // Me.IndicadorFinalidadeEscrit = data(14).ToEnum(Of IndicadorFinalidadeEscrit)(IndicadorFinalidadeEscrit.Original)
        // Me.CodigoHash = data(15)
        // Me.IndicadorGrandePorte = data(16).ToEnum(Of IndicadorGrandePorte)(IndicadorGrandePorte.EmpresaNaoSujeitaAuditoria)
        // Me.IndicadorTipoECD = data(17).ToEnum(Of IndicadorTipoECD)(IndicadorTipoECD.ECDempresaNaoParticipanteSCP)
        // Me.IdentificacaoSCP = data(18)
        // If data(19) = "S" Then
        // Me.IdentificacaoMoedaFuncional = True
        // Else
        // Me.IdentificacaoMoedaFuncional = False
        // End If
        // If data(20) = "S" Then
        // Me.EscritContConsolidades = True
        // Else
        // Me.EscritContConsolidades = False
        // End If
    }
}
