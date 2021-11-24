
namespace EficazFrameworkCore.SPED.Schemas.LCDPR
{

    /// <summary>
    /// Dados Cadastrais
    /// </summary>
    /// <remarks></remarks>
    public class Registro0030 : Primitives.Registro
    {
        public Registro0030() : base("0030")
        {
        }

        public Registro0030(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos
        public string Endereco { get; set; } = null;
        public string Numero { get; set; } = null;
        public string Complemento { get; set; } = null;
        public string Bairro { get; set; } = null;
        public string UF { get; set; } = null;
        public string CodigoMunicipio { get; set; } = null;
        public string CEP { get; set; } = null;
        public string Telefone { get; set; } = null;
        public string EMail { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("0030|"); // 1
            writer.Append(Endereco + "|"); // 2
            writer.Append(Numero + "|"); // 3
            writer.Append(Complemento + "|"); // 4
            writer.Append(Bairro + "|"); // 5
            writer.Append(UF + "|"); // 6
            writer.Append(CodigoMunicipio + "|"); // 7
            writer.Append(CEP + "|"); // 8
            writer.Append(Telefone + "|"); // 9
            writer.Append(EMail); // 10
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