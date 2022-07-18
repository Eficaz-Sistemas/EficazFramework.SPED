using System.Collections.Generic;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Observações do lançamento fiscal (Código 59)
/// </summary>
/// <remarks></remarks>
public class RegistroC895 : Primitives.Registro
{
    public RegistroC895() : base("C895")
    {
    }

    public RegistroC895(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|C895|"); // 1
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

    public List<RegistroC897> RegistrosC897 { get; set; } = new List<RegistroC897>();
}
