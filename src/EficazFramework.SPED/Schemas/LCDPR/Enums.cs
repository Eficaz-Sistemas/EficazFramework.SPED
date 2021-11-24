
namespace EficazFrameworkCore.SPED.Schemas.LCDPR
{

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public enum SituacaoInicioPeriodo
    {
        [Attributes.DisplayName("Regular (Início no primeiro dia do ano)")]
        Regular = 0,
        [Attributes.DisplayName("Abertura (Início de atividades no ano-calendário)")]
        Abertura = 1,
        [Attributes.DisplayName("– Início de obrigatoriedade da entrega no curso do ano calendário")]
        InicioObrigatoriedadeCursoAnoCalendario = 2
    }

    public enum SituacaoEspecial
    {
        [Attributes.DisplayName("Normal")]
        Normal = 0,
        [Attributes.DisplayName("Falecimento")]
        Falecimento = 1,
        [Attributes.DisplayName("Espólio")]
        Espolio = 2,
        [Attributes.DisplayName("Saída Definitiva do País")]
        SaidaPais = 3
    }

    public enum FormaApuracao
    {
        [Attributes.DisplayName("Livro Caixa")]
        LivroCaixa = 1,
        [Attributes.DisplayName("Ap. do Lucro conf. Art. 5, Lei 8.023/1990")]
        ApLucroArt5Lei8023_90 = 2
    }

    public enum TipoExploracao
    {
        [Attributes.DisplayName("Exploração Individual")]
        Individual = 1,
        [Attributes.DisplayName("Condomínio")]
        Condominio = 2,
        [Attributes.DisplayName("Imóvel Arrendado")]
        Arrendamento = 3,
        [Attributes.DisplayName("Parceria")]
        Parceria = 4,
        [Attributes.DisplayName("Comodato")]
        Comodato = 5,
        [Attributes.DisplayName("Outros")]
        Outros = 6
    }

    public enum TipoExploracaoTerceiro
    {
        [Attributes.DisplayName("Condômino")]
        Condomino = 1,
        [Attributes.DisplayName("Arrendador")]
        Arrendador = 2,
        [Attributes.DisplayName("Parceiro")]
        Parceiro = 3,
        [Attributes.DisplayName("Comodante")]
        Comodante = 4,
        [Attributes.DisplayName("Outros")]
        Outros = 5
    }


    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public enum TipoDocumento
    {
        [Attributes.DisplayName("Nota Fiscal")]
        NF = 1,
        [Attributes.DisplayName("Fatura")]
        Fatura = 2,
        [Attributes.DisplayName("Recibo")]
        Recibo = 3,
        [Attributes.DisplayName("Contrato")]
        Contrato = 4,
        [Attributes.DisplayName("Folha de Pagamento")]
        FolhaPagto = 5,
        [Attributes.DisplayName("Outros")]
        Outros = 4
    }

    public enum TipoLancamento
    {
        [Attributes.DisplayName("Receita")]
        Receita = 1,
        [Attributes.DisplayName("Despesa")]
        Despesa = 2,
        [Attributes.DisplayName("Produtos entregues no ano referente a adiantamento de recursos financeiros")]
        ProdEntrAdiantRecursosFin = 3
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}