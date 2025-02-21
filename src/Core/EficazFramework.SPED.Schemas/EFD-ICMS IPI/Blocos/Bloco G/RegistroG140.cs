using EficazFramework.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Identificação do Item do Documento Fiscal
/// </summary>
/// <remarks></remarks>
public class RegistroG140 : Primitives.Registro
{
    public RegistroG140() : base("G140")
    {
    }

    public RegistroG140(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|G140|"); // 01
        writer.Append(NumeroItem + "|"); // 02
        writer.Append(CodigoItem0200 + "|"); // 03
        if (Conversions.ToInteger(Versao) >= 14)
        {
            writer.Append(string.Format("{0:0.#####}", Quantidade) + "|"); // 04
            writer.Append(Unidade + "|"); // 05
            writer.Append(string.Format("{0:0.##}", VlrIcmsOpPropriaEntrada) + "|"); // 06
            writer.Append(string.Format("{0:0.##}", VlrIcmsSTEntrada) + "|"); // 07
            writer.Append(string.Format("{0:0.##}", VlrIcmsFreteEntrada) + "|"); // 08
            writer.Append(string.Format("{0:0.##}", VlrIcmsDifAliquotaEntrada) + "|"); // 09
        }

        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        NumeroItem = data[2].ToNullableInteger();
        CodigoItem0200 = data[3];
        if (Conversions.ToInteger(Versao) >= 14)
        {
            Quantidade = data[4].ToNullableDouble();
            Unidade = data[5];
            VlrIcmsOpPropriaEntrada = data[6].ToNullableDouble();
            VlrIcmsSTEntrada = data[7].ToNullableDouble();
            VlrIcmsFreteEntrada = data[8].ToNullableDouble();
            VlrIcmsDifAliquotaEntrada = data[9].ToNullableDouble();
        }
    }

    public int? NumeroItem { get; set; } = default; // 02
    public string CodigoItem0200 { get; set; } = null; // 03
                                                       // Versão 14
    public double? Quantidade { get; set; } = default; // 04
    public string Unidade { get; set; } = null; // 05
    public double? VlrIcmsOpPropriaEntrada { get; set; } = default; // 06
    public double? VlrIcmsSTEntrada { get; set; } = default; // 07
    public double? VlrIcmsFreteEntrada { get; set; } = default; // 08
    public double? VlrIcmsDifAliquotaEntrada { get; set; } = default; // 09
}
