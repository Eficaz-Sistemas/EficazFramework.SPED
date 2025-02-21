
namespace EficazFramework.SPED.Schemas.ECF;

/// <summary>
/// Identificação de Processos Judiciais e Administrativos Referentes ao Lançamento
/// </summary>
/// <remarks></remarks>

public class RegistroM415 : Primitives.Registro
{
    public RegistroM415() : base("M415")
    {
    }

    public RegistroM415(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos
    public TipoProcessoLancto IndicadorTipoProcesso { get; set; } = TipoProcessoLancto.Administrativo;
    public string NumeroLancto { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|M415|");
        writer.Append((int)IndicadorTipoProcesso + "|");
        writer.Append(NumeroLancto + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
    }
}
