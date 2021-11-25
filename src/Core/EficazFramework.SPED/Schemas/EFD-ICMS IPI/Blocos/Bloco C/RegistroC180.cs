using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Items dos Documentos Fiscais
/// </summary>
/// <remarks></remarks>

public class RegistroC180 : Primitives.Registro
{
    public RegistroC180() : base("C180")
    {
    }

    public RegistroC180(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|C180|"); // 1
        writer.Append(((int)CodRespRetencao).ToString() + "|"); // 2
        writer.Append(string.Format("{0:0.######}", QuantidadeItem) + "|"); // 3
        writer.Append(Unidade + "|"); // 4
        writer.Append(string.Format("{0:0.######}", VrUnitario) + "|"); // 5
        writer.Append(string.Format("{0:0.######}", VrUnitarioOpPropria) + "|"); // 6
        writer.Append(string.Format("{0:0.######}", VrUnitarioBcICMSSt) + "|"); // 7
        writer.Append(string.Format("{0:0.######}", VrUnitarioICMSSt) + "|"); // 8
        writer.Append(string.Format("{0:0.######}", VrUnitarioFCPStAgregado) + "|"); // 9
        writer.Append(((int)CodigoDocArrecad).ToString() + "|"); // 10
        writer.Append(NumeroDocArrecad + "|"); // 11
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        CodRespRetencao = (CodRespRetStC180)data[2].ToEnum<CodRespRetStC180>(CodRespRetStC180.Proprio_Declarante);
        QuantidadeItem = data[3].ToNullableDouble();
        Unidade = data[4].ToString();
        VrUnitario = data[5].ToNullableDouble();
        VrUnitarioOpPropria = data[6].ToNullableDouble();
        VrUnitarioBcICMSSt = data[7].ToNullableDouble();
        VrUnitarioICMSSt = data[8].ToNullableDouble();
        VrUnitarioFCPStAgregado = data[9].ToNullableDouble();
        CodigoDocArrecad = (CodigoDocArrecadC180)data[10].ToEnum<CodigoDocArrecadC180>(CodigoDocArrecadC180.Documento_Estadual);
        NumeroDocArrecad = data[11].ToString();
    }

    public CodRespRetStC180 CodRespRetencao { get; set; } = CodRespRetStC180.Proprio_Declarante; // 2
    public double? QuantidadeItem { get; set; } // 3
    public string Unidade { get; set; } // 4
    public double? VrUnitario { get; set; } // 5
    public double? VrUnitarioOpPropria { get; set; } // 6
    public double? VrUnitarioBcICMSSt { get; set; } // 7
    public double? VrUnitarioICMSSt { get; set; } // 8
    public double? VrUnitarioFCPStAgregado { get; set; } // 9
    public CodigoDocArrecadC180 CodigoDocArrecad { get; set; } = CodigoDocArrecadC180.Documento_Estadual; // 10
    public string NumeroDocArrecad { get; set; } // 11
}
