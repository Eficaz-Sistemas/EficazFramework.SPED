using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// REGISTRO 1600: OPERAÇÕES COM INSTRUMENTOS DE PAGAMENTOS ELETRÔNICOS
/// </summary>
/// <remarks></remarks>
public class Registro1601 : Primitives.Registro
{
    public Registro1601() : base("1601")
    {
    }
    public Registro1601(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        System.Text.StringBuilder writer = new System.Text.StringBuilder();
        writer.Append("|1601|"); // 1
        writer.Append(CodigoParticipante + "|"); // 2
        writer.Append(CodigoParticipanteIntermediador + "|"); // 3
        writer.Append(string.Format("{0:0.##}", TotalBrutoIncIcms) + "|"); // 4
        writer.Append(string.Format("{0:0.##}", TotalBrutoIncIss) + "|");  // 5
        writer.Append(string.Format("{0:0.##}", TotalOutros) + "|");  // 6
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        CodigoParticipante = data[2];
        CodigoParticipanteIntermediador = data[3];
        TotalBrutoIncIcms = data[4].ToNullableDouble();
        TotalBrutoIncIss = data[5].ToNullableDouble();
        TotalOutros = data[6].ToNullableDouble();
    }

    public string CodigoParticipante { get; set; } = null; // 2
    public string CodigoParticipanteIntermediador { get; set; } = null; // 3
    /// <summary>
    /// Valor total bruto das vendas e/ou prestações de serviços no campo de incidência Do ICMS, 
    /// incluindo operações com imunidade Do imposto
    /// </summary>
    public double? TotalBrutoIncIcms { get; set; } // 4
    /// <summary>
    /// Valor total bruto das prestações de serviços no campo de incidência Do ISS
    /// </summary>
    /// <returns></returns>
    public double? TotalBrutoIncIss { get; set; } // 5
    /// <summary>
    /// Valor total de operações deduzido dos valores dos campos TotalBrutoIncIcms e TotalBrutoIncIss
    /// </summary>
    /// <returns></returns>
    public double? TotalOutros { get; set; } // 6
}