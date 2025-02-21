using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.ECD;

/// <summary>
/// Definição de Campos do Livro Razão Auxiliar com Leiaute Parametrizável
/// </summary>
/// <remarks></remarks>

public class RegistroI510 : Primitives.Registro
{
    public RegistroI510() : base("I510")
    {
    }

    public RegistroI510(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public string NomeCampo { get; set; } = null;
    public string DescricaoCampo { get; set; } = null;
    public string TipoCampo { get; set; } = null;
    public short? TamanhoCampo { get; set; }
    public short? QtdeCasasDecimais { get; set; }
    public short? LarguraColunaRelatorio { get; set; }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|I510|");
        writer.Append(NomeCampo + "|");
        writer.Append(DescricaoCampo + "|");
        writer.Append(TipoCampo + "|");
        writer.Append(TamanhoCampo + "|");
        writer.Append(QtdeCasasDecimais + "|");
        writer.Append(LarguraColunaRelatorio + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        NomeCampo = data[2];
        DescricaoCampo = data[3];
        TipoCampo = data[4];
        TamanhoCampo = data[5].ToNullableShort();
        QtdeCasasDecimais = data[6].ToNullableShort();
        LarguraColunaRelatorio = data[7].ToNullableShort();
    }
}
