using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Resumo Diário de Documentos Emitidos por Equipamento SAT
/// </summary>
/// <remarks></remarks>

public class RegistroC870 : Primitives.Registro
{
    public RegistroC870() : base("C870")
    {
    }

    public RegistroC870(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public string CodigoItem { get; set; } = null;
    public string CFOP { get; set; } = null;
    public double? VrTotalItens { get; set; }
    public double? VrExclusaoDescontoItens { get; set; }
    public string CSTPis { get; set; } = null;
    public double? VrBcPis { get; set; }
    public double? AliquotaPis { get; set; }
    public double? VrPis { get; set; }
    public string CSTCofins { get; set; } = null;
    public double? VrBcCofins { get; set; }
    public double? AliquotaCofins { get; set; }
    public double? VrCofins { get; set; }
    public string CodigoContaContabil { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|C870|");
        writer.Append(CodigoItem + "|");
        writer.Append(CFOP + "|");
        writer.Append(string.Format("{0:0.##}", VrTotalItens) + "|");
        writer.Append(string.Format("{0:0.##}", VrExclusaoDescontoItens) + "|");
        writer.Append(CSTPis + "|");
        writer.Append(string.Format("{0:0.##}", VrBcPis) + "|");
        writer.Append(string.Format("{0:0.####}", AliquotaPis) + "|");
        writer.Append(string.Format("{0:0.##}", VrPis) + "|");
        writer.Append(CSTCofins + "|");
        writer.Append(string.Format("{0:0.##}", VrBcCofins) + "|");
        writer.Append(string.Format("{0:0.####}", AliquotaCofins) + "|");
        writer.Append(string.Format("{0:0.##}", VrCofins) + "|");
        writer.Append(CodigoContaContabil + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        CodigoItem = data[2];
        CFOP = data[3];
        VrTotalItens = data[4].ToNullableDouble();
        VrExclusaoDescontoItens = data[5].ToNullableDouble();
        CSTPis = data[6];
        VrBcPis = data[7].ToNullableDouble();
        AliquotaPis = data[8].ToNullableDouble();
        VrPis = data[9].ToNullableDouble();
        CSTCofins = data[10];
        VrBcCofins = data[11].ToNullableDouble();
        AliquotaCofins = data[12].ToNullableDouble();
        VrCofins = data[13].ToNullableDouble();
        CodigoContaContabil = data[14];
    }
}
