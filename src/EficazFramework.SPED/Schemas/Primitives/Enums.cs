namespace EficazFramework.SPED.Schemas.Primitives
{
    public enum Finalidade
    {
        [System.ComponentModel.Description("Remessa do Arquivo Original")]
        Original = 0,
        [System.ComponentModel.Description("Remessa do Arquivo Substituto")]
        Substituto = 1
    }

    public enum TipoAtividade
    {
        [System.ComponentModel.Description("Industrial ou Equiparado a Industrial")]
        Industrial = 0,
        [System.ComponentModel.Description("Outros")]
        Outros = 1
    }

    public enum IndicadorMovimento
    {
        [System.ComponentModel.Description("Bloco com dados informados")]
        ComDados = 0,
        [System.ComponentModel.Description("Bloco sem dados informados")]
        SemDados = 1
    }
}