using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Contribuição para o Cofins a recolher - detalhamento por código de receita
/// </summary>
/// <remarks></remarks>

public class RegistroM605 : Primitives.Registro
{
    public RegistroM605() : base("M605")
    {
    }

    public RegistroM605(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public string NumeroCampoRegistroM600 { get; set; } = null;
    public string CodigoReceita { get; set; } = null;
    public double? VrDebitoDCTF { get; set; }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|M605|");
        writer.Append(NumeroCampoRegistroM600 + "|");
        writer.Append(CodigoReceita + "|");
        writer.Append(VrDebitoDCTF + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        NumeroCampoRegistroM600 = data[2];
        CodigoReceita = data[3];
        VrDebitoDCTF = data[4].ToNullableDouble();
    }
}
