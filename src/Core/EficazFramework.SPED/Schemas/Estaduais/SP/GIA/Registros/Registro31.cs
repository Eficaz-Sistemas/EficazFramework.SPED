using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.SP.GIA;

/// <summary>
/// Exportação
/// </summary>
public class Registro31 : Primitives.Registro
{
    public Registro31() : base("31")
    {
    }

    public Registro31(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("31"); // 1 Código Registro
        writer.Append(RE.ToString().ToFixedLenghtString(15, Escrituracao._builder, Alignment.Left, "0")); // 3
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        string linha = data[0];
        _ = long.TryParse(linha.Substring(2, 15).Trim(), out long argresult);
        RE = argresult;
    }

    public long RE { get; set; } = default;
}
