using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Detalhamento do Crédito Extemporâneo Vinculado a mais de um tipo de receita - Cofins
/// </summary>
/// <remarks></remarks>

public class Registro1502 : Primitives.Registro
{
    public Registro1502() : base("1502")
    {
    }

    public Registro1502(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public double? ParcelaCreditoCofinsReceitaMercInterno { get; set; }
    public double? ParcelaCreditoCofinsReceitaNãoTribMercInterno { get; set; }
    public double? ParcelaCreditoVincExportacao { get; set; }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|1502|");
        writer.Append(ParcelaCreditoCofinsReceitaMercInterno + "|");
        writer.Append(ParcelaCreditoCofinsReceitaNãoTribMercInterno + "|");
        writer.Append(ParcelaCreditoVincExportacao + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        ParcelaCreditoCofinsReceitaMercInterno = data[2].ToNullableDouble();
        ParcelaCreditoCofinsReceitaNãoTribMercInterno = data[3].ToNullableDouble();
        ParcelaCreditoVincExportacao = data[4].ToNullableDouble();
    }
}
