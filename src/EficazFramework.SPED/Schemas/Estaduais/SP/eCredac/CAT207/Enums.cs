
namespace EficazFramework.SPED.Schemas.SP.eCredAc.CAT207
{

    /// <summary>
    /// Tabela 3.1
    /// </summary>
    /// <remarks></remarks>
    public enum VersaoLayout
    {
        [System.ComponentModel.Description("1.0.0.1")]
        versao_1001 = 1,
        [System.ComponentModel.Description("Não Utilizar esta opção")]
        nao_aplicavel = 99
    }

    /// <summary>
    /// Tabela 3.2
    /// </summary>
    /// <remarks></remarks>
    public enum Finalidade
    {
        [System.ComponentModel.Description("Remessa regular de arquivo")]
        RemessaRegular = 1,
        [System.ComponentModel.Description("Remessa de arquivo requerido por intimação específica")]
        RemessaIntimacao = 2,
        [System.ComponentModel.Description("Remessa de arquivo para substituição de arquivo remetido anteriormente")]
        RemessaSubstituicao = 3,
        [System.ComponentModel.Description("Remessa de arquivo com informações complementares relativas à comprovação de operações de exportação-Siscomex e ou ingresso da mercadoria - Suframa")]
        RemessaComplementar_Siscomex_Suframa = 4
    }

    public enum IndicadorMovimento
    {
        [System.ComponentModel.Description("Bloco com dados informados")]
        ComMovimento = 0,
        [System.ComponentModel.Description("Bloco sem dados informados")]
        SemMovimento = 1
    }
}