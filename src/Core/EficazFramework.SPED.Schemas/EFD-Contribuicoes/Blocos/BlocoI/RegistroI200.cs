using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Composição das receitas, deduções ou exclusões do período
/// </summary>
/// <remarks></remarks>

public class RegistroI200 : Primitives.Registro
{
    public RegistroI200() : base("I200")
    {
    }

    public RegistroI200(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public short? NumeroCampoRegistroI100 { get; set; }
    public string CodigoTipoDetalhamento { get; set; } = null;
    public double? VrDetalhado { get; set; }
    public string CodigoContaContabil { get; set; } = null;
    public string InfoComplementar { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|I200|");
        writer.Append(NumeroCampoRegistroI100 + "|");
        writer.Append(CodigoTipoDetalhamento + "|");
        writer.Append(VrDetalhado + "|");
        writer.Append(CodigoContaContabil + "|");
        writer.Append(InfoComplementar + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        NumeroCampoRegistroI100 = data[2].ToNullableShort();
        CodigoTipoDetalhamento = data[3];
        VrDetalhado = data[4].ToNullableDouble();
        CodigoTipoDetalhamento = data[5];
        InfoComplementar = data[6];
    }
}
