using System;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// REGISTRO C112: DOCUMENTO DE ARRECADAÇÃO REFERENCIADO.
/// </summary>
/// <remarks></remarks>
public class RegistroC112 : Primitives.Registro
{
    public RegistroC112() : base("C112")
    {
    }

    public RegistroC112(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|C112|"); // 1
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
    }

    public CodigoModeloDocArrec Codigo_Modelo_Doc_Arrec { get; set; } = CodigoModeloDocArrec.DAE; // 2
    public string UF { get; set; } // 3
    public string Numero { get; set; } // 4
    public string Cod_Autent_Bancaria { get; set; } // 5
    public double? Vr_Doc_Arrec { get; set; } // 6
    public DateTime? Data_Vecto { get; set; } // 7
    public DateTime? Data_Pgto { get; set; } // 8
}
