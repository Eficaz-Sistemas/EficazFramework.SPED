using System;

namespace EficazFramework.SPED.Schemas.SP.eCredAc.CAT207;

/// <summary>
/// Operações de Saídas
/// </summary>
/// <remarks></remarks>
public class Registro5315 : Primitives.Registro
{
    public DateTime? DataEmissao { get; set; } = default;
    public int? EspecieDocumento { get; set; }
    public string Serie { get; set; } = null;
    public int? Numero { get; set; } = default;
    public string CodigoParticipante { get; set; } = "99999999"; // null value
    public double? ValorDocumento { get; set; } = default;
    public double? CreditoOuturgado_Percentual { get; set; } = default;
    public double? CreditoOuturgado_Valor { get; set; } = default;

    public Registro5315() : base("5315")
    {
    }

    public Registro5315(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("5315|");
        writer.Append(string.Format("{0:ddMMyyyy}", DataEmissao) + "|");
        writer.Append(string.Format("{0:00}", EspecieDocumento) + "|");
        writer.Append(Serie + "|");
        writer.Append(Numero + "|");
        writer.Append(CodigoParticipante + "|");
        writer.Append(string.Format("{0:F2}", ValorDocumento) + "|");
        writer.Append(string.Format("{0:F2}", CreditoOuturgado_Percentual) + "|");
        writer.Append(string.Format("{0:F2}", CreditoOuturgado_Valor));
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
    }
}
