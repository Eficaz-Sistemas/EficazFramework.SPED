using EficazFrameworkCore.Attributes;

namespace EficazFrameworkCore.SPED.Schemas.Primitives
{
    public enum Finalidade
    {
        [DisplayName("Remessa do Arquivo Original")]
        Original = 0,
        [DisplayName("Remessa do Arquivo Substituto")]
        Substituto = 1
    }

    public enum TipoAtividade
    {
        [DisplayName("Industrial ou Equiparado a Industrial")]
        Industrial = 0,
        [DisplayName("Outros")]
        Outros = 1
    }

    public enum IndicadorMovimento
    {
        [DisplayName("Bloco com dados informados")]
        ComDados = 0,
        [DisplayName("Bloco sem dados informados")]
        SemDados = 1
    }
}