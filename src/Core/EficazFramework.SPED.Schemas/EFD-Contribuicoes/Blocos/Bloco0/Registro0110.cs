using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Regimes de Apuração da Contribuição Social e de Apropriação de Crédito
/// </summary>
/// <remarks></remarks>
public class Registro0110 : Primitives.Registro
{
    public Registro0110() : base("0110")
    {
    }

    public Registro0110(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public CodigoIncidenciaTributaria CodigoIndicador { get; set; } = CodigoIncidenciaTributaria.Escrituracaodeoperacoescomincidenciaexclusivamentenoregimenaocumulativo;
    public MetodoApropriacaoEnum? MetodoApropriacao { get; set; } = default; // MetodoApropriacao.MetodoApropriacaoDireta
    public TipoContribuicaoEnum? TipoContribuicao { get; set; } = default; // TipoContribuicao.ApuracaodaContribuicaoAliquotaBasica
    public int? CriterioEscrituracaoApuracao { get; set; }
    public Registro0111 Registro0111 { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|0110|");
        writer.Append(((int)CodigoIndicador).ToString() + "|");
        if (MetodoApropriacao.HasValue == false)
            writer.Append('|');
        else
            writer.Append(MetodoApropriacao + "|");
        if (TipoContribuicao.HasValue == false)
            writer.Append('|');
        else
            writer.Append(TipoContribuicao + "|");
        if (CriterioEscrituracaoApuracao.HasValue == false)
            writer.Append('|');
        else
            writer.Append(CriterioEscrituracaoApuracao + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        CodigoIndicador = (CodigoIncidenciaTributaria)data[2].ToEnum<CodigoIncidenciaTributaria>(CodigoIncidenciaTributaria.Escrituracaodeoperacoescomincidenciaexclusivamentenoregimenaocumulativo);
        MetodoApropriacao = (MetodoApropriacaoEnum?)data[3].ToEnum<MetodoApropriacaoEnum>(MetodoApropriacaoEnum.MetodoApropriacaoDireta);
        TipoContribuicao = (TipoContribuicaoEnum?)data[4].ToEnum<TipoContribuicaoEnum>(TipoContribuicaoEnum.ApuracaodaContribuicaoAliquotaBasica);
        CriterioEscrituracaoApuracao = data[5].ToNullableInteger();
    }
}
