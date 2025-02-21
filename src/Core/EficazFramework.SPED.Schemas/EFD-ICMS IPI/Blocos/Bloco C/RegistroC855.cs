using System.Collections.Generic;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Observações do lançamento fiscal (Código 59)
/// </summary>
/// <remarks></remarks>
public class RegistroC855 : Primitives.Registro
{
    public RegistroC855() : base("C855")
    {
    }

    public RegistroC855(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|C855|"); // 1
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

    public List<RegistroC857> RegistrosC857 { get; set; } = new List<RegistroC857>();
}
