
namespace EficazFramework.SPED.Schemas.ECF;

/// <summary>
/// Identificação de Processos Judiciais e Administrativos Referentes ao Lançamento
/// </summary>
/// <remarks></remarks>

public class RegistroM365 : Primitives.Registro
{
    public RegistroM365() : base("M365")
    {
    }

    public RegistroM365(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos
    public TipoProcessoLancto IndicadorTipoProcesso { get; set; } = TipoProcessoLancto.Administrativo;
    public string NumeroLancto { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|M365|");
        writer.Append((int)IndicadorTipoProcesso + "|");
        writer.Append(NumeroLancto + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
    }
}
