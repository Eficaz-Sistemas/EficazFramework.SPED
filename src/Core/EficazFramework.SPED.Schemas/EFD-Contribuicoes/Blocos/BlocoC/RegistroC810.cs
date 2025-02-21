using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Detalhamento do Cupom Fiscal Eletrônico
/// </summary>
/// <remarks></remarks>

public class RegistroC810 : Primitives.Registro
{
    public RegistroC810() : base("C810")
    {
    }

    public RegistroC810(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public string CFOP { get; set; } = null;
    public double? ValorTotal { get; set; }
    public string CodigoProduto { get; set; } = null;
    public string PIS_CST { get; set; } = null;
    public double? PIS_BaseCalculo { get; set; }
    public double? PIS_Aliquota { get; set; }
    public double? PIS_Valor { get; set; }
    public string COFINS_CST { get; set; } = null;
    public double? COFINS_BaseCalculo { get; set; }
    public double? COFINS_Aliquota { get; set; }
    public double? COFINS_Valor { get; set; }
    public string CodContaContabil { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|C810|");
        writer.Append(CFOP + "|");
        writer.Append(string.Format("{0:0.##}", ValorTotal) + "|");
        writer.Append(CodigoProduto + "|");
        writer.Append(PIS_CST + "|");
        writer.Append(PIS_BaseCalculo + "|");
        writer.Append(string.Format("{0:0.##}", PIS_BaseCalculo) + "|");
        writer.Append(string.Format("{0:0.####}", PIS_Aliquota) + "|");
        writer.Append(string.Format("{0:0.##}", PIS_Valor) + "|");
        writer.Append(COFINS_CST + "|");
        writer.Append(string.Format("{0:0.##}", COFINS_BaseCalculo) + "|");
        writer.Append(string.Format("{0:0.####}", COFINS_Aliquota) + "|");
        writer.Append(string.Format("{0:0.##}", COFINS_Valor) + "|");
        writer.Append(CodContaContabil + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        CFOP = data[2];
        ValorTotal = data[3].ToNullableDouble();
        CodigoProduto = data[4];
        PIS_CST = data[5];
        PIS_BaseCalculo = data[6].ToNullableDouble();
        PIS_Aliquota = data[7].ToNullableDouble();
        PIS_Valor = data[8].ToNullableDouble();
        COFINS_CST = data[9];
        COFINS_BaseCalculo = data[10].ToNullableDouble();
        COFINS_Aliquota = data[11].ToNullableDouble();
        COFINS_Valor = data[12].ToNullableDouble();
        CodContaContabil = data[13];
    }
}
