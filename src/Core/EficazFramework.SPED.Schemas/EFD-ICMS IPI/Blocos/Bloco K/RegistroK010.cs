// NOTA: Este registro nunca sofreu alteração desde o primeiro ano da escrituração.
// NOTA: Este registro nunca sofreu alteração desde o primeiro ano da escrituração.
// Não será preciso avaliar qual é a versão do arquivo para diferenciar a forma
// de escrita/leitura.

using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Informação sobre o tipo de leiaute (simplificado / completo)
/// </summary>
/// <remarks></remarks>
public class RegistroK010 : Primitives.Registro
{
    public RegistroK010() : base("K010")
    {
    }

    public RegistroK010(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|K010|"); // 1
        writer.Append(((int)IndicadorTemplate).ToString() + "|"); // 3
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        IndicadorTemplate = (IndicadorLayoutBlocoK)data[2].ToEnum<IndicadorLayoutBlocoK>(IndicadorLayoutBlocoK.RestritoSaldosEstoque);
    }

    public IndicadorLayoutBlocoK IndicadorTemplate { get; set; } = IndicadorLayoutBlocoK.RestritoSaldosEstoque;
}
