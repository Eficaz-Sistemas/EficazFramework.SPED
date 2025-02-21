using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Composição da receita escriturada no período - detalhamento da receita recebido pelo regime de caixa
/// </summary>
/// <remarks></remarks>

public class RegistroF525 : Primitives.Registro
{
    public RegistroF525() : base("F525")
    {
    }

    public RegistroF525(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public double? VrReceitaReceb { get; set; }
    public IndicadorComposicaoReceitaPeriodo IndicadorComposicaoRecRecebPer { get; set; } = IndicadorComposicaoReceitaPeriodo.Outros;
    public string CNPJ_CPFParticipante { get; set; } = null;
    public string NumeroDoc { get; set; } = null;
    public string CodigoItem { get; set; } = null;
    public double? VrRecDetalhada { get; set; }
    public string CSTPis { get; set; } = null;
    public string CSTCofins { get; set; } = null;
    public string InfoComplementar { get; set; } = null;
    public string CodigoContaContabil { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|F525|");
        writer.Append(VrReceitaReceb + "|");
        writer.Append(((int)IndicadorComposicaoRecRecebPer).ToString() + "|");
        writer.Append(CNPJ_CPFParticipante + "|");
        writer.Append(NumeroDoc + "|");
        writer.Append(CodigoItem + "|");
        writer.Append(VrRecDetalhada + "|");
        writer.Append(CSTPis + "|");
        writer.Append(CSTCofins + "|");
        writer.Append(InfoComplementar + "|");
        writer.Append(CodigoContaContabil + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        VrReceitaReceb = data[2].ToNullableDouble();
        IndicadorComposicaoRecRecebPer = (IndicadorComposicaoReceitaPeriodo)data[3].ToEnum<IndicadorComposicaoReceitaPeriodo>(IndicadorComposicaoReceitaPeriodo.Outros);
        CNPJ_CPFParticipante = data[4];
        NumeroDoc = data[5];
        CodigoItem = data[6];
        VrRecDetalhada = data[7].ToNullableDouble();
        CSTPis = data[8];
        CSTCofins = data[9];
        InfoComplementar = data[10];
        CodigoContaContabil = data[11];
    }
}
