
namespace EficazFramework.SPED.Schemas.ECF
{

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public enum SituacaoInicioPeriodo
    {
        [Attributes.DisplayName("Regular (Início no primeiro dia do ano)")]
        Regular = 0,
        [Attributes.DisplayName("Abertura (Início de atividades no ano-calendário)")]
        Abertura = 1,
        [Attributes.DisplayName("Resultante de cisão/fusão ou remanescente de cisão, ou realizou incorporação")]
        Resultante_Cisao_Fusao_Incoporacao = 2,
        [Attributes.DisplayName("– Início de obrigatoriedade da entrega no curso do ano calendário")]
        InicioObrigatoriedadeCursoAnoCalendario = 4
    }

    public enum SituacaoEspecial
    {
        [Attributes.DisplayName("Não Aplicável")]
        NaoAplicavel = 0,
        [Attributes.DisplayName("Extinção")]
        Extincao = 1,
        [Attributes.DisplayName("Fusão")]
        Fusao = 2,
        [Attributes.DisplayName("Incorporação / Incorporada")]
        Incorporacao_Incorporada = 3,
        [Attributes.DisplayName("Incorporação / Incorporadora")]
        Incorporacao_Incorporadora = 4,
        [Attributes.DisplayName("Cisão Total")]
        CisaoTotal = 5,
        [Attributes.DisplayName("Cisão Parcial")]
        CisaoParcial = 6,
        [Attributes.DisplayName("Desenquadramento de Imune / Isenta")]
        DesenquadramentoImuneIsenta = 8,
        [Attributes.DisplayName("Inclusao no Simples Nacional")]
        InclusaoSimplesNacional = 9
    }

    public enum TipoECF
    {
        [Attributes.DisplayName("ECF de empresa não participante de SCP como sócio ostensivo")]
        NaoSCP = 0,
        [Attributes.DisplayName("ECF de empresa participante de SCP como sócio ostensivo")]
        ParticpanteSCP = 1,
        [Attributes.DisplayName("ECF da SCP")]
        SCP = 2
    }

    public enum FormaTributacao
    {
        [Attributes.DisplayName("Lucro Real")]
        LucroReal = 1,
        [Attributes.DisplayName("Lucro Real / Arbitrado")]
        LucroRealArbitrado = 2,
        [Attributes.DisplayName("Lucro Presumido / Real")]
        LucroPresumidoReal = 3,
        [Attributes.DisplayName("Lucro Presumido / Real / Arbitrado")]
        LucroPresumidoRealArbitrado = 4,
        [Attributes.DisplayName("Lucro Presumido")]
        LucroPresumido = 5,
        [Attributes.DisplayName("Lucro Arbitrado")]
        LucroArbitrado = 6,
        [Attributes.DisplayName("Lucro Presumido / Arbitrado")]
        LucroPresumidoArbitrado = 7,
        [Attributes.DisplayName("Imune do IRPJ")]
        ImuneIRPJ = 8,
        [Attributes.DisplayName("Isenta do IRPJ")]
        IsentoIRPJ = 9
    }

    public enum FormaApuracao
    {
        [Attributes.DisplayName("Trimestral")]
        Trimestral = 0,
        [Attributes.DisplayName("Anual")]
        Anual = 1,
        [Attributes.DisplayName("Não Aplicável")]
        NA = 99
    }

    public enum QualificacaoPJ
    {
        [Attributes.DisplayName("PJ em Geral")]
        PjemGeral = 1,
        [Attributes.DisplayName("PJ Componente do Sistema Financeiro")]
        PJCompSistFinanceiro = 2,
        [Attributes.DisplayName("Soc. Seguradoras, de Capitalizaão ou Ent. Aberta de Prev. Compl.")]
        SocSegCapAbPrevCompl = 3,
        [Attributes.DisplayName("Não Aplicável")]
        NaoAplicavel = 999
    }

    public enum TipoPJImuneOuIsenta
    {
        [Attributes.DisplayName("Assistência Social")]
        AssistenciaSocial = 1,
        [Attributes.DisplayName("Educacional")]
        Educacional = 2,
        [Attributes.DisplayName("Sindicato de Trabalhadores")]
        SindicatoTrabalhadores = 3,
        [Attributes.DisplayName("Associação Civil")]
        AssociacaoCivil = 4,
        [Attributes.DisplayName("Cultural")]
        Cultural = 5,
        [Attributes.DisplayName("Entidade Privada de Previdência Complementar")]
        EntFechadaPrevCompleentar = 6,
        [Attributes.DisplayName("Filantrópica")]
        Filantropica = 7,
        [Attributes.DisplayName("Sindicato")]
        Sindicato = 8,
        [Attributes.DisplayName("Recreativa")]
        Recreativa = 9,
        [Attributes.DisplayName("Científica")]
        Cientifica = 10,
        [Attributes.DisplayName("Associação de Poupança e Empréstimo")]
        AssocPoupancaEmprestimo = 11,
        [Attributes.DisplayName("Entidade Aberta de Previdência Complementar")]
        EntAbertaPrevComplementar = 12,
        [Attributes.DisplayName("FIFA e Entidades Relacionadas")]
        Fifa = 13,
        [Attributes.DisplayName("CIO e Entidades Relacionadas")]
        CIO = 14,
        [Attributes.DisplayName("Partios Políticos")]
        PartidosPoliticos = 15,
        [Attributes.DisplayName("Outras")]
        Outras = 99,
        [Attributes.DisplayName("Não Aplicável")]
        NaoAplicavel = 999
    }

    public enum IndicadorReceita
    {
        [Attributes.DisplayName("Regime de Caixa")]
        Caixa = 1,
        [Attributes.DisplayName("Regime de Competência")]
        Competencia = 2
    }

    public enum IndicadorAliquotaCSLL2015
    {
        [Attributes.DisplayName("9%")]
        NovePorcento = 1,
        [Attributes.DisplayName("17%")]
        DezessetePorcento = 2,
        [Attributes.DisplayName("20%")]
        VintePorcento = 3,
        [Attributes.DisplayName("Não Aplicável")]
        NA = 99
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public enum MetodoAvEstoque
    {
        [Attributes.DisplayName("1 – Custo Médio Ponderado")]
        CustoMedioPonderado = 1,
        [Attributes.DisplayName("2 – PEPS (Primeiro que entra, primeiro que sai)")]
        PEPS = 2,
        [Attributes.DisplayName("3 – Arbitramento - art. 296, Inc. I e II, do RIR/99")]
        Arbitramento = 3,
        [Attributes.DisplayName("4 – Custo Específico")]
        CustoEspecifico = 4,
        [Attributes.DisplayName("5 – Valor Realizável Líquido")]
        ValorRealizavelLiquido = 5,
        [Attributes.DisplayName("6 - Inventário Períodico")]
        InventarioPeriodico = 6,
        [Attributes.DisplayName("7 – Outros")]
        Outros = 7,
        [Attributes.DisplayName("8 – Não há (Exemplo: Empresas Prestadoras de Serviços)")]
        NaoHa = 8
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public enum TipoProcessoLancto
    {
        [Attributes.DisplayName("1 – Judicial")]
        Judicial = 1,
        [Attributes.DisplayName("2 – Administrativo")]
        Administrativo = 2
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}