using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Identificação da pessoa jurídica estabelecimento
/// </summary>
/// <remarks></remarks>

public class RegistroI010 : Primitives.Registro
{
    public RegistroI010() : base("I010")
    {
    }

    public RegistroI010(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public string CNPJ { get; set; } = null;
    public IdentificaoOperacaoPeriodo IndicadorOperacoesPeriodo { get; set; } = IdentificaoOperacaoPeriodo.RealizouOperacoesReferenteMaisIndicadoresAcima;
    public string InfoComplementar { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|I010|");
        writer.Append(CNPJ + "|");
        writer.Append(((int)IndicadorOperacoesPeriodo).ToString() + "|");
        writer.Append(InfoComplementar + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        CNPJ = data[2];
        IndicadorOperacoesPeriodo = (IdentificaoOperacaoPeriodo)data[3].ToEnum<IdentificaoOperacaoPeriodo>(IdentificaoOperacaoPeriodo.RealizouOperacoesReferenteMaisIndicadoresAcima);
        InfoComplementar = data[4];
    }
}
