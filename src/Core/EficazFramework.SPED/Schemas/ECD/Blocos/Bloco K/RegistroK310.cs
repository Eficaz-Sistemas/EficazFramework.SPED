using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.ECD;

/// <summary>
/// Empresas Detentoras das Parcelas do Valor Eliminado Total
/// </summary>
/// <remarks></remarks>

public class RegistroK310 : Primitives.Registro
{
    public RegistroK310() : base("K310")
    {
    }

    public RegistroK310(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public string CodigoEmpresaDetVrAglutinadoEliminado { get; set; } = null;
    public double? ParcelaVrEliminadoTotal { get; set; }
    public string IndicadorSitVrEliminada { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|K310|");
        writer.Append(CodigoEmpresaDetVrAglutinadoEliminado + "|");
        writer.Append(ParcelaVrEliminadoTotal + "|");
        writer.Append(IndicadorSitVrEliminada + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        CodigoEmpresaDetVrAglutinadoEliminado = data[2];
        ParcelaVrEliminadoTotal = data[3].ToNullableDouble();
        IndicadorSitVrEliminada = data[4];
    }
}
