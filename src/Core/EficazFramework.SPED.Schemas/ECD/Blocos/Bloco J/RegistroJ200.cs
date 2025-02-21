
namespace EficazFramework.SPED.Schemas.ECD;

/// <summary>
/// Tabela de Histório de Fatos Contábeis que Modificam a Conta Lucros Acumulados ou a Conta de Prejuízos Acumulados ou Todo o Patrimônio Líquido
/// </summary>
/// <remarks></remarks>

public class RegistroJ200 : Primitives.Registro
{
    public RegistroJ200() : base("J200")
    {
    }

    // Campos'
    public string CodHistoricoFatoContabil { get; set; } = null;
    public string DescFatoContabil { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new global::System.Text.StringBuilder();
        writer.Append("|J200|");
        writer.Append(CodHistoricoFatoContabil + "|");
        writer.Append(DescFatoContabil + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        CodHistoricoFatoContabil = data[2];
        DescFatoContabil = data[3];
    }
}
