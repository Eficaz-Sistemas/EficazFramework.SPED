
namespace EficazFramework.SPED.Schemas.ECF
{

    /// <summary>
    /// Parâmetros de Tributação
    /// </summary>
    /// <remarks></remarks>
    public class Registro0010 : Primitives.Registro
    {
        public Registro0010() : base("0010")
        {
        }

        public Registro0010(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos
        public string HashEcfAnterior { get; set; } = null;
        public bool OpptanteRefis { get; set; } = false;
        public bool OptantePAES { get; set; } = false;
        public FormaTributacao FormaTributacao { get; set; } = FormaTributacao.LucroReal;
        public FormaApuracao FormaApuracao { get; set; } = FormaApuracao.Anual;
        public QualificacaoPJ QualificacaoPJ { get; set; } = QualificacaoPJ.PjemGeral;
        /// <summary>
        /// Valores válidos (um caractere para cada trimestre):
        /// 0 - ZERO - Não Informado - trimestre não compreendido no período de apuração
        /// R - Real
        /// P - Presumido
        /// A - Arbitrado
        /// E - Real Estimativa
        /// </summary>
        public string FormaTributacaoTrimestre { get; set; } = null;
        /// <summary>
        /// Valores válidos (um caractere para cada trimestre):
        /// 0 - ZERO - Fora do Período
        /// E - Receita Bruta: Estimativa com base na Receita Bruta
        /// B - Balanço ou Balancete: Estimativa com base no balanço ou balancete de suspensão / reduçao
        /// </summary>
        public string FormaTributacaoMes { get; set; } = null;
        /// <summary>
        /// Valores Válidos:
        /// C - Obrigada a entregar ECD ou entrega facultativa
        /// L - Não obrigada a entregar ECD
        /// </summary>
        public string ObrigatoriedadeECD { get; set; } = null;
        public TipoPJImuneOuIsenta TipoPJImuneIsenta { get; set; } = TipoPJImuneOuIsenta.NaoAplicavel;
        /// <summary>
        /// Valores Válidos:
        /// A - Anual
        /// T - Trimestral
        /// D - Desobrigada
        /// </summary>
        public string FormaApuracaoImuneIsenta_IRPJ { get; set; } = null;
        /// <summary>
        /// Valores Válidos:
        /// A - Anual
        /// T - Trimestral
        /// D - Desobrigada
        /// </summary>
        public string FormaApuracaoImuneIsenta_CSLL { get; set; } = null;
        public IndicadorReceita IndicadorRegimeReceita { get; set; } = IndicadorReceita.Competencia;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|0010|"); // 1
            writer.Append(HashEcfAnterior + "|"); // 2
            if (OpptanteRefis)
                writer.Append("S|");
            else
                writer.Append("N|"); // 3
            if (int.Parse(Versao) < 7)
            {
                if (OptantePAES)
                    writer.Append("S|");
                else
                    writer.Append("N|"); // 4
            }
            writer.Append((int)FormaTributacao + "|"); // 5
            if (FormaApuracao == FormaApuracao.Trimestral)
                writer.Append("T" + "|");
            else
            {
                if (FormaApuracao == FormaApuracao.Anual)
                    writer.Append("A" + "|");
                else
                    writer.Append('|');
            }  // 6

            if (QualificacaoPJ != QualificacaoPJ.NaoAplicavel)
                writer.Append(string.Format("{0:00}", (int)QualificacaoPJ) + "|");
            else
                writer.Append('|'); // 7
            writer.Append(FormaTributacaoTrimestre + "|"); // 8
            writer.Append(FormaTributacaoMes + "|"); // 9
            writer.Append(ObrigatoriedadeECD + "|"); // 10
            if (TipoPJImuneIsenta != TipoPJImuneOuIsenta.NaoAplicavel)
                writer.Append(string.Format("{0:00}", (int)TipoPJImuneIsenta) + "|");
            else
                writer.Append('|'); // 11
            writer.Append(FormaApuracaoImuneIsenta_IRPJ + "|"); // 12
            writer.Append(FormaApuracaoImuneIsenta_CSLL + "|"); // 13
            if (FormaTributacao == FormaTributacao.LucroReal | FormaTributacao == FormaTributacao.LucroRealArbitrado | FormaTributacao == FormaTributacao.LucroArbitrado | FormaTributacao == FormaTributacao.ImuneIRPJ | FormaTributacao == FormaTributacao.IsentoIRPJ)
            {
                writer.Append('|');  // 14
            }
            else
            {
                writer.Append((int)IndicadorRegimeReceita + "|");
            }  // 14

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