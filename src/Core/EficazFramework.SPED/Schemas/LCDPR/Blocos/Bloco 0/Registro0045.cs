using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.LCDPR;

/// <summary>
/// Cadastro de Terceiros
/// </summary>
/// <remarks></remarks>
public class Registro0045 : Primitives.Registro
{
    public Registro0045() : base("0045")
    {
    }

    public Registro0045(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("0045|"); // 1
        writer.Append(Imovel + "|"); // 2
        writer.Append((int)TipoContratante + "|"); // 3
        writer.Append(CPF + "|"); // 4
        writer.Append(Nome + "|"); // 5
        writer.Append(Percentual.ValueToString(2)); // 6
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
    }

    public int? Imovel { get; set; } = default;
    public TipoExploracaoTerceiro TipoContratante { get; set; } = TipoExploracaoTerceiro.Condomino;
    public string CPF { get; set; } = null;
    public string Nome { get; set; } = null;
    public double? Percentual { get; set; } = default;
}
