
namespace EficazFramework.SPED.Schemas.ECF;

/// <summary>
/// Identificação da SCP
/// </summary>
/// <remarks></remarks>
public class Registro0035 : Primitives.Registro
{
    public Registro0035() : base("0035")
    {
    }

    public Registro0035(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos
    public string CodigoSCP { get; set; }
    public string NomeSCP { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|0035|"); // 1
        writer.Append(CodigoSCP + "|"); // 2
        writer.Append(NomeSCP + "|"); // 3
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
