using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.LCDPR
{

    /// <summary>
    /// Cadastro dos Imóveis Rurais
    /// </summary>
    /// <remarks></remarks>
    public class Registro0040 : Primitives.Registro
    {
        public Registro0040() : base("0040")
        {
        }

        public Registro0040(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos
        public int? IDImovel { get; set; } = default;
        public string Pais { get; set; } = "BR";
        public string Moeda { get; set; } = "BRL";
        /// <summary>
        /// NOTA: Informar DV
        /// </summary>
        public string NIRF { get; set; } = null;
        public string CAEPF { get; set; } = null;
        public string InscricaoEstadual { get; set; } = null;
        public string NomeImovel { get; set; } = null;
        public string Endereco { get; set; } = null;
        public string Numero { get; set; } = null;
        public string Complemento { get; set; } = null;
        public string Bairro { get; set; } = null;
        public string UF { get; set; } = null;
        public string CodigoMunicipio { get; set; } = null;
        public string CEP { get; set; } = null;
        public TipoExploracao TipoExploracao { get; set; } = TipoExploracao.Individual;
        public double? Percentual { get; set; } = default;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("0040|"); // 1
            writer.Append(IDImovel + "|"); // 2
            writer.Append(Pais + "|"); // 3
            writer.Append(Moeda + "|"); // 4
            writer.Append(NIRF + "|"); // 5
            writer.Append(CAEPF + "|"); // 6
            writer.Append(InscricaoEstadual + "|"); // 7
            writer.Append(NomeImovel + "|"); // 8
            writer.Append(Endereco + "|"); // 9
            writer.Append(Numero + "|"); // 10
            writer.Append(Complemento + "|"); // 11 
            writer.Append(Bairro + "|"); // 12
            writer.Append(UF + "|"); // 13
            writer.Append(CodigoMunicipio + "|"); // 14
            writer.Append(CEP + "|"); // 15
            writer.Append((int)TipoExploracao + "|"); // 16
            writer.Append(Percentual.ValueToString(2)); // 17
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