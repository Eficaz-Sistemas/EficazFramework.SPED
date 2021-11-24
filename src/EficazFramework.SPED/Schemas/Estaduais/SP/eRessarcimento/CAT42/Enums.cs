
namespace EficazFrameworkCore.SPED.Schemas.SP.eRessarcimento.CAT42
{

    /// <summary>
    /// Tabela 3.1
    /// </summary>
    /// <remarks></remarks>
    public enum VersaoLayout
    {
        [Attributes.DisplayName("1.0.0.0")]
        versao_1000 = 1,
        [Attributes.DisplayName("1.1.0.0")]
        versao_1100 = 2
    }

    /// <summary>
    /// Tabela 3.2
    /// </summary>
    /// <remarks></remarks>
    public enum Finalidade
    {
        [Attributes.DisplayName("Remessa regular de arquivo")]
        RemessaRegular = 0,
        [Attributes.DisplayName("Remessa de arquivo requerido por intimação específica")]
        RemessaIntimacao = 1,
        [Attributes.DisplayName("Remessa de arquivo para substituição de arquivo remetido anteriormente")]
        RemessaSubstituicao = 2
    }

    public enum IndicadorMovimento
    {
        [Attributes.DisplayName("Bloco com dados informados")]
        ComMovimento = 0,
        [Attributes.DisplayName("Bloco sem dados informados")]
        SemMovimento = 1
    }

    public enum EnquadramentLegal
    {
        [Attributes.DisplayName("0 - Operação não ensejadora de Ressarcimento ou Complemento de ICMS-ST")]
        OperacaoSemComplouRessarc = 0,
        [Attributes.DisplayName("1 - Inciso I do Art. 269 do RICMS: Saída a Consumidor ou Usuário Final")]
        IncisoI = 1,
        [Attributes.DisplayName("2 - Inciso II do Art. 269 do RICMS: Fato Gerador não Realizado")]
        IncisoII = 2,
        [Attributes.DisplayName("3 - Inciso III do Art. 269 do RICMS: Saída com Isenção ou Não-Incidência")]
        IncisoIII = 3,
        [Attributes.DisplayName("4 - Inciso IV do Art. 269 do RICMS: Saída para outro Estado")]
        IncisoIV = 4
    }
}