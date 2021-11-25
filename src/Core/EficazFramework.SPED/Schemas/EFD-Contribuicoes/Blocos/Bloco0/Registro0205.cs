using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;


/// <summary>
/// Alteração do Item
/// </summary>
/// <remarks></remarks>

public class Registro0205 : Primitives.Registro
{
    public Registro0205() : base("0205")
    {
    }

    public Registro0205(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public string DescricaoItemAnterior { get; set; } = null;
    public DateTime? DataInicial { get; set; } // tamanho 8'
    public DateTime? Datafinal { get; set; } // tamanho 8'
    public string CodigoItemAnterior { get; set; } = null; // tamanho 60'

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|0205|");
        writer.Append(DescricaoItemAnterior + "|");
        writer.Append(DataInicial.ToSpedString() + "|");
        writer.Append(Datafinal.ToSpedString() + "|");
        writer.Append(CodigoItemAnterior + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        DescricaoItemAnterior = data[2];
        DataInicial = data[3].ToDate();
        Datafinal = data[4].ToDate();
        CodigoItemAnterior = data[5];
    }
}
