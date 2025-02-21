// NOTA: Este registro nunca sofreu alteração desde o primeiro ano da escrituração.
// Não será preciso avaliar qual é a versão do arquivo para diferenciar a forma
// de escrita/leitura.

using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Estoque Escriturado
/// </summary>
/// <remarks></remarks>
public class RegistroK200 : Primitives.Registro
{
    public RegistroK200() : base("K200")
    {
    }

    public RegistroK200(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|K200|"); // 1
        writer.Append(DataEscrituracao.ToSpedString() + "|"); // 2
        writer.Append(CodigoProduto + "|"); // 3
        writer.Append(string.Format("{0:0.###}", Quantidade) + "|"); // 4
        writer.Append(((int)IndicadorPosse).ToString() + "|"); // 5
        writer.Append(CodigoParticipante + "|"); // 6
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        DataEscrituracao = data[2].ToDate();
        CodigoProduto = data[3];
        Quantidade = data[4].ToNullableDouble();
        IndicadorPosse = (IndicadorPropriedade)data[5].ToEnum<IndicadorPropriedade>(IndicadorPropriedade.InformanteEmPoder);
        CodigoParticipante = data[6];
    }

    public DateTime? DataEscrituracao { get; set; }
    public string CodigoProduto { get; set; }
    public string UnidadeInventariada { get; set; }
    public double? Quantidade { get; set; }
    public IndicadorPropriedade IndicadorPosse { get; set; } = IndicadorPropriedade.InformanteEmPoder;
    public string CodigoParticipante { get; set; }
}
