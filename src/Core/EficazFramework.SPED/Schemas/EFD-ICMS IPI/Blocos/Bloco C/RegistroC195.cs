using System.Collections.Generic;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Outras obrigações Tributárias, Ajustes e Infos. de Valores
/// Provenientes de Documento Fiscal
/// </summary>
/// <remarks></remarks>
public class RegistroC195 : Primitives.Registro
{
    public RegistroC195() : base("C195")
    {
    }

    public RegistroC195(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|C195|"); // 1
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

    public List<RegistroC197> RegistrosC197 { get; set; } = new List<RegistroC197>();
}
