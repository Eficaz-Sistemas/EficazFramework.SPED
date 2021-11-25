using EficazFramework.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Informações adicionais de diferimento
/// </summary>
/// <remarks></remarks>

public class RegistroM230 : Primitives.Registro
{
    public RegistroM230() : base("M230")
    {
    }

    public RegistroM230(string linha, string versao) : base(linha, versao)
    {
    }


    // Campos'
    public string CNPJ { get; set; } = null;
    public double? VrTotalVendasPeriodo { get; set; }
    public double? VrTotalNaoRecebPeriodo { get; set; }
    public double? VrContribDiferidaPeriodo { get; set; }
    public double? VrCreditoDiferidoPeriodo { get; set; }
    public string CodigoTipoCredDiferido { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|M230|");
        writer.Append(CNPJ + "|");
        writer.Append(VrTotalVendasPeriodo + "|");
        writer.Append(VrTotalNaoRecebPeriodo + "|");
        writer.Append(VrContribDiferidaPeriodo + "|");
        writer.Append(VrCreditoDiferidoPeriodo + "|");
        writer.Append(CodigoTipoCredDiferido + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        CNPJ = data[2];
        VrTotalVendasPeriodo = data[3].ToNullableDouble();
        VrTotalNaoRecebPeriodo = data[4].ToNullableDouble();
        VrContribDiferidaPeriodo = data[5].ToNullableDouble();
        VrCreditoDiferidoPeriodo = data[6].ToNullableDouble();
        CodigoTipoCredDiferido = Conversions.ToString(data[7].ToNullableDouble());
    }
}
