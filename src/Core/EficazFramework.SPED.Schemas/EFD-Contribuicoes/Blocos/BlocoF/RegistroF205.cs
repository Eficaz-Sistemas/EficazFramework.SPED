using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Operações da atividade imobiliária - custo incorrido da unidade imobiliária
/// </summary>
/// <remarks></remarks>

public class RegistroF205 : Primitives.Registro
{
    public RegistroF205() : base("F205")
    {
    }

    public RegistroF205(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public double? VrCustoIncorridoAcumAnt { get; set; }
    public double? VrCustoIncorridoPeriodoEscrituracao { get; set; }
    public double? VrCustoIncorridoAcum { get; set; }
    public double? VrExcluidoBcCustoAcumPeriodo { get; set; }
    public double? VrBcCustoIncorridoAcumPeriodo { get; set; }
    public string CSTPis { get; set; } = null;
    public double? AliqPis { get; set; }
    public double? VrCredPisAcum { get; set; }
    public double? VrCredPisDescAnterior { get; set; }
    public double? VrCredPisDescPeriodoEscrit { get; set; }
    public double? VrCredPisDescPeriodosFuturos { get; set; }
    public string CSTCofins { get; set; } = null;
    public double? AliqCofins { get; set; }
    public double? VrCredCofinsAcum { get; set; }
    public double? VrCredCofinsDescAnterior { get; set; }
    public double? VrCredCofinsDescPeriodoEscrit { get; set; }
    public double? VrCredCofinsDescPeriodosFuturos { get; set; }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|F205|");
        writer.Append(VrCustoIncorridoAcumAnt + "|");
        writer.Append(VrCustoIncorridoPeriodoEscrituracao + "|");
        writer.Append(VrCustoIncorridoAcum + "|");
        writer.Append(VrExcluidoBcCustoAcumPeriodo + "|");
        writer.Append(VrBcCustoIncorridoAcumPeriodo + "|");
        writer.Append(CSTPis + "|");
        writer.Append(AliqPis + "|");
        writer.Append(VrCredPisAcum + "|");
        writer.Append(VrCredPisDescAnterior + "|");
        writer.Append(VrCredPisDescPeriodoEscrit + "|");
        writer.Append(VrCredPisDescPeriodosFuturos + "|");
        writer.Append(CSTCofins + "|");
        writer.Append(AliqCofins + "|");
        writer.Append(VrCredCofinsAcum + "|");
        writer.Append(VrCredCofinsDescAnterior + "|");
        writer.Append(VrCredCofinsDescPeriodoEscrit + "|");
        writer.Append(VrCredCofinsDescPeriodosFuturos + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        VrCustoIncorridoAcumAnt = data[2].ToNullableDouble();
        VrCustoIncorridoPeriodoEscrituracao = data[3].ToNullableDouble();
        VrCustoIncorridoAcum = data[4].ToNullableDouble();
        VrExcluidoBcCustoAcumPeriodo = data[5].ToNullableDouble();
        VrBcCustoIncorridoAcumPeriodo = data[6].ToNullableDouble();
        CSTPis = data[7];
        AliqPis = data[8].ToNullableDouble();
        VrCredPisAcum = data[9].ToNullableDouble();
        VrCredPisDescAnterior = data[10].ToNullableDouble();
        VrCredPisDescPeriodoEscrit = data[11].ToNullableDouble();
        VrCredPisDescPeriodosFuturos = data[12].ToNullableDouble();
        CSTCofins = data[13];
        AliqCofins = data[14].ToNullableDouble();
        VrCredCofinsAcum = data[15].ToNullableDouble();
        VrCredCofinsDescAnterior = data[16].ToNullableDouble();
        VrCredCofinsDescPeriodoEscrit = data[17].ToNullableDouble();
        VrCredCofinsDescPeriodosFuturos = data[18].ToNullableDouble();
    }
}
