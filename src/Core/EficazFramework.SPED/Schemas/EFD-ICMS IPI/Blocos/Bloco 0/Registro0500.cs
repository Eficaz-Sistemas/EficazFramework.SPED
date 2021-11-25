using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Plano de contas contábeis
/// </summary>
/// <remarks></remarks>
public class Registro0500 : Primitives.Registro
{
    public Registro0500() : base("0500")
    {
    }

    public Registro0500(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|0500|"); // 1
        writer.Append(DataAlteracao.ToSpedString() + "|"); // 02
        writer.Append(string.Format("{0:00}", (int)CodigoNatureza) + "|"); // 03
        writer.Append(IndicadorConta + "|"); // 04
        writer.Append(Nivel + "|"); // 05
        writer.Append(CodigoConta + "|"); // 06
        writer.Append(NomeConta + "|"); // 07
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        DataAlteracao = data[2].ToDate();
        CodigoNatureza = (ECD.TipoConta)data[3].ToEnum<ECD.TipoConta>(ECD.TipoConta.Outras);
        IndicadorConta = data[4];
        Nivel = data[5].ToNullableShort();
        CodigoConta = data[6];
        NomeConta = data[7];
    }

    public DateTime? DataAlteracao { get; set; }
    public ECD.TipoConta CodigoNatureza { get; set; } = ECD.TipoConta.Outras;
    public string IndicadorConta { get; set; } = "A";
    public short? Nivel { get; set; }
    public string CodigoConta { get; set; } = null;
    public string NomeConta { get; set; } = null;
}
