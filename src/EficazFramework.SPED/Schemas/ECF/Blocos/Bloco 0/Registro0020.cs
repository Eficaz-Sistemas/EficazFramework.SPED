
namespace EficazFramework.SPED.Schemas.ECF
{

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
        public bool RecapRepesPadisPatvdReidiOlimpEDemaisDiachos { get; set; } = false;
        public bool PoloIndManausAmazonaOcidencal { get; set; } = false;
        public bool ZonaExportacao { get; set; } = false;
        public bool AreaLivreComercio { get; set; } = false;
        public bool IntegranteMultinacional { get; set; } = false;
        public bool DEREX { get; set; } = false;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|0020|"); // 1
            if (FormaTributacao != IndicadorAliquotaCSLL2015.NA)
                writer.Append((int)FormaTributacao + "|");
            else
                writer.Append('|'); // 2
            writer.Append(QuantidadeSCP + "|"); // 3
            if (AdminFundoClubeInvest)
                writer.Append("S|");
            else
                writer.Append("N|"); // 4
            if (ParticipacoesConsorcios)
                writer.Append("S|");
            else
                writer.Append("N|"); // 5
            if (OperacoesExterior)
                writer.Append("S|");
            else
                writer.Append("N|"); // 6
            if (OperacoesVinculadas)
                writer.Append("S|");
            else
                writer.Append("N|"); // 7
            if (EnquadramentoArts48ou49_IN_1312_12)
                writer.Append("S|");
            else
                writer.Append("N|"); // 8
            if (ParticipacoesExterior)
                writer.Append("S|");
            else
                writer.Append("N|"); // 9
            if (AtividadeRural)
                writer.Append("S|");
            else
                writer.Append("N|"); // 10
            if (LucroExploracao)
                writer.Append("S|");
            else
                writer.Append("N|"); // 11
            if (IsencaoReducaoLucroPresumido)
                writer.Append("S|");
            else
                writer.Append("N|"); // 12
            if (Finor_Finam)
                writer.Append("S|");
            else
                writer.Append("N|"); // 13
            if (int.Parse(Versao) < 7)
            {
                if (DoacaoEleitoral)
                    writer.Append("S|");
                else
                    writer.Append("N|"); // 14
            }
            if (ParticipAvMetodoEquivPatrim)
                writer.Append("S|");
            else
                writer.Append("N|"); // 15
            if (int.Parse(Versao) < 7)
            {
                if (VendasExportacao)
                    writer.Append("S|");
                else
                    writer.Append("N|"); // 16
            }
            if (RecebimExterior)
                writer.Append("S|");
            else
                writer.Append("N|"); // 17
            if (AtivosNoExterior)
                writer.Append("S|");
            else
                writer.Append("N|"); // 18
            if (int.Parse(Versao) < 7)
            {
                if (PJExportadora)
                    writer.Append("S|");
                else
                    writer.Append("N|"); // 19
            }
            if (PagtosExterior)
                writer.Append("S|");
            else
                writer.Append("N|"); // 20
            if (ComEletronicoTI)
                writer.Append("S|");
            else
                writer.Append("N|"); // 21
            if (RoyaltiesRecebidos)
                writer.Append("S|");
            else
                writer.Append("N|"); // 22
            if (RoyaltiesPagos)
                writer.Append("S|");
            else
                writer.Append("N|"); // 23
            if (RendServicosJurosDivRecebidos)
                writer.Append("S|");
            else
                writer.Append("N|"); // 24
            if (PgRemessasTitServicosJurosDiv)
                writer.Append("S|");
            else
                writer.Append("N|"); // 25
            if (InovacaoTenologica)
                writer.Append("S|");
            else
                writer.Append("N|"); // 26
            if (CapacitacaoInformaticaInclDigital)
                writer.Append("S|");
            else
                writer.Append("N|"); // 27
            if (RecapRepesPadisPatvdReidiOlimpEDemaisDiachos)
                writer.Append("S|");
            else
                writer.Append("N|"); // 28
            if (PoloIndManausAmazonaOcidencal)
                writer.Append("S|");
            else
                writer.Append("N|"); // 29
            if (ZonaExportacao)
                writer.Append("S|");
            else
                writer.Append("N|"); // 30
            if (AreaLivreComercio)
                writer.Append("S|");
            else
                writer.Append("N|"); // 31
            if (IntegranteMultinacional)
                writer.Append("S|");
            else
                writer.Append("N|"); // 32
            if (DEREX)
                writer.Append("S|");
            else
                writer.Append("N|"); // 33
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
}