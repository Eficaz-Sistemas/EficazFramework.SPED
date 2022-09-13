// NOTA: Este registro nunca sofreu alteração desde o primeiro ano da escrituração.
// Não será preciso avaliar qual é a versão do arquivo para diferenciar a forma
// de escrita/leitura.

using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Inventário
/// </summary>
/// <remarks></remarks>
public class RegistroH020 : Primitives.Registro
{
    public RegistroH020() : base("H020")
    {
    }

    public RegistroH020(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|H020|"); // 1
        writer.Append(CST + "|"); // 2
        writer.Append(string.Format("{0:0.##}", BaseCalculoICMS) + "|"); // 3
        writer.Append(string.Format("{0:0.##}", ValorICMS) + "|"); // 4
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        CST = data[2];
        BaseCalculoICMS = data[3].ToNullableDouble(2);
        ValorICMS = data[4].ToNullableDouble(2);
    }

    public string CST { get; set; }
    public double? BaseCalculoICMS { get; set; }
    public double? ValorICMS { get; set; }
}
