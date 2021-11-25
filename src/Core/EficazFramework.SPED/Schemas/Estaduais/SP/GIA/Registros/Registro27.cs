using EficazFramework.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.SP.GIA;

/// <summary>
/// IE Substituído
/// </summary>
public class Registro27 : Primitives.Registro
{
    public Registro27() : base("27")
    {
    }

    public Registro27(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("27"); // 1 Código Registro
        writer.Append(InscricaoEstadualSubstituido.ToFixedLenghtString(12, Escrituracao._builder, Alignment.Right, " ")); // 2
        if (NumeroNF.HasValue == false)
            NumeroNF = 0;
        writer.Append(string.Format(Conversions.ToString(NumeroNF), "{0:000000000}")); // 3
        writer.Append(Valor.ValueToString().ToFixedLenghtString(15, Escrituracao._builder, Alignment.Left, "0")); // 4
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        string linha = data[0];
        InscricaoEstadualSubstituido = linha.Substring(2, 12).Trim();
        NumeroNF = linha.Substring(14, 9).Trim().ToNullableInteger();
        Valor = linha.Substring(23, 15).ToNullableDouble(2);
    }

    public string InscricaoEstadualSubstituido { get; set; } = null;
    public int? NumeroNF { get; set; } = default;
    public double? Valor { get; set; } = 0;
}
