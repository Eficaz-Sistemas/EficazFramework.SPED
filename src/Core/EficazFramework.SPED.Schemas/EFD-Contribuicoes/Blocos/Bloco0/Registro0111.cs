using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Tabela de Receita Bruta Mensal para Fins de Rateio de Créditos Comuns
/// </summary>
/// <remarks></remarks>

public class Registro0111 : Primitives.Registro
{
    public Registro0111() : base("0111")
    {
    }

    public Registro0111(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public double? ReceitaBrutaNaoCumulativaMercadoInt { get; set; }
    public double? ReceitaBrutaNaoCumulativaNaoTribMercInt { get; set; }
    public double? ReceitaBrutaNaoCumulativaExport { get; set; }
    public double? ReceitaBrutaCumulativa { get; set; }
    public double? ReceitaBrutaTotal { get; set; }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|0111|");
        writer.Append(ReceitaBrutaNaoCumulativaMercadoInt + "|");
        writer.Append(ReceitaBrutaNaoCumulativaNaoTribMercInt + "|");
        writer.Append(ReceitaBrutaNaoCumulativaExport + "|");
        writer.Append(ReceitaBrutaCumulativa + "|");
        writer.Append(ReceitaBrutaTotal + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        ReceitaBrutaNaoCumulativaMercadoInt = data[2].ToNullableDouble();
        ReceitaBrutaNaoCumulativaNaoTribMercInt = data[3].ToNullableDouble();
        ReceitaBrutaNaoCumulativaExport = data[4].ToNullableDouble();
        ReceitaBrutaCumulativa = data[5].ToNullableDouble();
        ReceitaBrutaTotal = data[6].ToNullableDouble();
    }
}
