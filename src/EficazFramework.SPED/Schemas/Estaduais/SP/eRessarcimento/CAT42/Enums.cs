
namespace EficazFramework.SPED.Schemas.SP.eRessarcimento.CAT42
{

    /// <summary>
    /// Tabela 3.1
    /// </summary>
    /// <remarks></remarks>
    public enum VersaoLayout
    {
        [System.ComponentModel.Description("1.0.0.0")]
        versao_1000 = 1,
        [System.ComponentModel.Description("1.1.0.0")]
        versao_1100 = 2
    }

    /// <summary>
    /// Tabela 3.2
    /// </summary>
    /// <remarks></remarks>
    public enum Finalidade
    {
        [System.ComponentModel.Description("Remessa regular de arquivo")]
        RemessaRegular = 0,
        [System.ComponentModel.Description("Remessa de arquivo requerido por intimação específica")]
        RemessaIntimacao = 1,
        [System.ComponentModel.Description("Remessa de arquivo para substituição de arquivo remetido anteriormente")]
        RemessaSubstituicao = 2
    }

    public enum IndicadorMovimento
    {
        [System.ComponentModel.Description("Bloco com dados informados")]
        ComMovimento = 0,
        [System.ComponentModel.Description("Bloco sem dados informados")]
        SemMovimento = 1
    }

    public enum EnquadramentLegal
    {
        [System.ComponentModel.Description("0 - Operação não ensejadora de Ressarcimento ou Complemento de ICMS-ST")]
        OperacaoSemComplouRessarc = 0,
        [System.ComponentModel.Description("1 - Inciso I do Art. 269 do RICMS: Saída a Consumidor ou Usuário Final")]
        IncisoI = 1,
        [System.ComponentModel.Description("2 - Inciso II do Art. 269 do RICMS: Fato Gerador não Realizado")]
        IncisoII = 2,
        [System.ComponentModel.Description("3 - Inciso III do Art. 269 do RICMS: Saída com Isenção ou Não-Incidência")]
        IncisoIII = 3,
        [System.ComponentModel.Description("4 - Inciso IV do Art. 269 do RICMS: Saída para outro Estado")]
        IncisoIV = 4
    }
}