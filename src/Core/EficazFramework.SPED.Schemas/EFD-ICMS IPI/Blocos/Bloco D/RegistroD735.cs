using System.Collections.Generic;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Observações do lançamento fiscal (Código 62)
/// </summary>
/// <remarks></remarks>
public class RegistroD735 : Primitives.Registro
{
    public RegistroD735() : base("D735")
    {
    }

    public RegistroD735(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|D735|"); // 1
        writer.Append(CodigoObs0460 + "|"); // 02
        writer.Append(Descricao + "|"); // 03
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        CodigoObs0460 = data[2];
        Descricao = data[3];
    }

    public string CodigoObs0460 { get; set; } = null; // 02
    public string Descricao { get; set; } = null; // 03

    // // Navigation Properties

    public List<RegistroD737> RegistrosD737 { get; set; } = new List<RegistroD737>();
}
