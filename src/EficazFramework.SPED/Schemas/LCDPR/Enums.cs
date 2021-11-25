
namespace EficazFramework.SPED.Schemas.LCDPR
{

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public enum SituacaoInicioPeriodo
    {
        [System.ComponentModel.Description("Regular (Início no primeiro dia do ano)")]
        Regular = 0,
        [System.ComponentModel.Description("Abertura (Início de atividades no ano-calendário)")]
        Abertura = 1,
        [System.ComponentModel.Description("– Início de obrigatoriedade da entrega no curso do ano calendário")]
        InicioObrigatoriedadeCursoAnoCalendario = 2
    }

    public enum SituacaoEspecial
    {
        [System.ComponentModel.Description("Normal")]
        Normal = 0,
        [System.ComponentModel.Description("Falecimento")]
        Falecimento = 1,
        [System.ComponentModel.Description("Espólio")]
        Espolio = 2,
        [System.ComponentModel.Description("Saída Definitiva do País")]
        SaidaPais = 3
    }

    public enum FormaApuracao
    {
        [System.ComponentModel.Description("Livro Caixa")]
        LivroCaixa = 1,
        [System.ComponentModel.Description("Ap. do Lucro conf. Art. 5, Lei 8.023/1990")]
        ApLucroArt5Lei8023_90 = 2
    }

    public enum TipoExploracao
    {
        [System.ComponentModel.Description("Exploração Individual")]
        Individual = 1,
        [System.ComponentModel.Description("Condomínio")]
        Condominio = 2,
        [System.ComponentModel.Description("Imóvel Arrendado")]
        Arrendamento = 3,
        [System.ComponentModel.Description("Parceria")]
        Parceria = 4,
        [System.ComponentModel.Description("Comodato")]
        Comodato = 5,
        [System.ComponentModel.Description("Outros")]
        Outros = 6
    }

    public enum TipoExploracaoTerceiro
    {
        [System.ComponentModel.Description("Condômino")]
        Condomino = 1,
        [System.ComponentModel.Description("Arrendador")]
        Arrendador = 2,
        [System.ComponentModel.Description("Parceiro")]
        Parceiro = 3,
        [System.ComponentModel.Description("Comodante")]
        Comodante = 4,
        [System.ComponentModel.Description("Outros")]
        Outros = 5
    }


    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public enum TipoDocumento
    {
        [System.ComponentModel.Description("Nota Fiscal")]
        NF = 1,
        [System.ComponentModel.Description("Fatura")]
        Fatura = 2,
        [System.ComponentModel.Description("Recibo")]
        Recibo = 3,
        [System.ComponentModel.Description("Contrato")]
        Contrato = 4,
        [System.ComponentModel.Description("Folha de Pagamento")]
        FolhaPagto = 5,
        [System.ComponentModel.Description("Outros")]
        Outros = 4
    }

    public enum TipoLancamento
    {
        [System.ComponentModel.Description("Receita")]
        Receita = 1,
        [System.ComponentModel.Description("Despesa")]
        Despesa = 2,
        [System.ComponentModel.Description("Produtos entregues no ano referente a adiantamento de recursos financeiros")]
        ProdEntrAdiantRecursosFin = 3
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}