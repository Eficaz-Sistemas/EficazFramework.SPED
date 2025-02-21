using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.ECF;

/// <summary>
/// Identificação dos Signatários da ECF
/// </summary>
/// <remarks></remarks>
public class Registro0930 : Primitives.Registro
{
    public Registro0930() : base("0930")
    {
    }

    public Registro0930(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos
    public string Nome { get; set; }
    public string CNPJ_CPF { get; set; } = null;
    public string Qualificacao { get; set; } = null;
    public string CRC_Contador { get; set; } = null;
    public string EMail { get; set; } = null;
    public string Telefone { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|0930|"); // 1
        writer.Append(Nome + "|"); // 2
        writer.Append(CNPJ_CPF + "|"); // 3
        writer.Append(Qualificacao ?? "0".ToFixedLenghtString(3, Alignment.Left, "0") + "|"); // 4
        writer.Append(CRC_Contador + "|"); // 5
        writer.Append(EMail + "|"); // 6
        writer.Append(Telefone + "|"); // 7
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
