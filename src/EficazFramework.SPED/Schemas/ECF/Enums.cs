
namespace EficazFramework.SPED.Schemas.ECF
{

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public enum SituacaoInicioPeriodo
    {
        [System.ComponentModel.Description("Regular (Início no primeiro dia do ano)")]
        Regular = 0,
        [System.ComponentModel.Description("Abertura (Início de atividades no ano-calendário)")]
        Abertura = 1,
        [System.ComponentModel.Description("Resultante de cisão/fusão ou remanescente de cisão, ou realizou incorporação")]
        Resultante_Cisao_Fusao_Incoporacao = 2,
        [System.ComponentModel.Description("– Início de obrigatoriedade da entrega no curso do ano calendário")]
        InicioObrigatoriedadeCursoAnoCalendario = 4
    }

    public enum SituacaoEspecial
    {
        [System.ComponentModel.Description("Não Aplicável")]
        NaoAplicavel = 0,
        [System.ComponentModel.Description("Extinção")]
        Extincao = 1,
        [System.ComponentModel.Description("Fusão")]
        Fusao = 2,
        [System.ComponentModel.Description("Incorporação / Incorporada")]
        Incorporacao_Incorporada = 3,
        [System.ComponentModel.Description("Incorporação / Incorporadora")]
        Incorporacao_Incorporadora = 4,
        [System.ComponentModel.Description("Cisão Total")]
        CisaoTotal = 5,
        [System.ComponentModel.Description("Cisão Parcial")]
        CisaoParcial = 6,
        [System.ComponentModel.Description("Desenquadramento de Imune / Isenta")]
        DesenquadramentoImuneIsenta = 8,
        [System.ComponentModel.Description("Inclusao no Simples Nacional")]
        InclusaoSimplesNacional = 9
    }

    public enum TipoECF
    {
        [System.ComponentModel.Description("ECF de empresa não participante de SCP como sócio ostensivo")]
        NaoSCP = 0,
        [System.ComponentModel.Description("ECF de empresa participante de SCP como sócio ostensivo")]
        ParticpanteSCP = 1,
        [System.ComponentModel.Description("ECF da SCP")]
        SCP = 2
    }

    public enum FormaTributacao
    {
        [System.ComponentModel.Description("Lucro Real")]
        LucroReal = 1,
        [System.ComponentModel.Description("Lucro Real / Arbitrado")]
        LucroRealArbitrado = 2,
        [System.ComponentModel.Description("Lucro Presumido / Real")]
        LucroPresumidoReal = 3,
        [System.ComponentModel.Description("Lucro Presumido / Real / Arbitrado")]
        LucroPresumidoRealArbitrado = 4,
        [System.ComponentModel.Description("Lucro Presumido")]
        LucroPresumido = 5,
        [System.ComponentModel.Description("Lucro Arbitrado")]
        LucroArbitrado = 6,
        [System.ComponentModel.Description("Lucro Presumido / Arbitrado")]
        LucroPresumidoArbitrado = 7,
        [System.ComponentModel.Description("Imune do IRPJ")]
        ImuneIRPJ = 8,
        [System.ComponentModel.Description("Isenta do IRPJ")]
        IsentoIRPJ = 9
    }

    public enum FormaApuracao
    {
        [System.ComponentModel.Description("Trimestral")]
        Trimestral = 0,
        [System.ComponentModel.Description("Anual")]
        Anual = 1,
        [System.ComponentModel.Description("Não Aplicável")]
        NA = 99
    }

    public enum QualificacaoPJ
    {
        [System.ComponentModel.Description("PJ em Geral")]
        PjemGeral = 1,
        [System.ComponentModel.Description("PJ Componente do Sistema Financeiro")]
        PJCompSistFinanceiro = 2,
        [System.ComponentModel.Description("Soc. Seguradoras, de Capitalizaão ou Ent. Aberta de Prev. Compl.")]
        SocSegCapAbPrevCompl = 3,
        [System.ComponentModel.Description("Não Aplicável")]
        NaoAplicavel = 999
    }

    public enum TipoPJImuneOuIsenta
    {
        [System.ComponentModel.Description("Assistência Social")]
        AssistenciaSocial = 1,
        [System.ComponentModel.Description("Educacional")]
        Educacional = 2,
        [System.ComponentModel.Description("Sindicato de Trabalhadores")]
        SindicatoTrabalhadores = 3,
        [System.ComponentModel.Description("Associação Civil")]
        AssociacaoCivil = 4,
        [System.ComponentModel.Description("Cultural")]
        Cultural = 5,
        [System.ComponentModel.Description("Entidade Privada de Previdência Complementar")]
        EntFechadaPrevCompleentar = 6,
        [System.ComponentModel.Description("Filantrópica")]
        Filantropica = 7,
        [System.ComponentModel.Description("Sindicato")]
        Sindicato = 8,
        [System.ComponentModel.Description("Recreativa")]
        Recreativa = 9,
        [System.ComponentModel.Description("Científica")]
        Cientifica = 10,
        [System.ComponentModel.Description("Associação de Poupança e Empréstimo")]
        AssocPoupancaEmprestimo = 11,
        [System.ComponentModel.Description("Entidade Aberta de Previdência Complementar")]
        EntAbertaPrevComplementar = 12,
        [System.ComponentModel.Description("FIFA e Entidades Relacionadas")]
        Fifa = 13,
        [System.ComponentModel.Description("CIO e Entidades Relacionadas")]
        CIO = 14,
        [System.ComponentModel.Description("Partios Políticos")]
        PartidosPoliticos = 15,
        [System.ComponentModel.Description("Outras")]
        Outras = 99,
        [System.ComponentModel.Description("Não Aplicável")]
        NaoAplicavel = 999
    }

    public enum IndicadorReceita
    {
        [System.ComponentModel.Description("Regime de Caixa")]
        Caixa = 1,
        [System.ComponentModel.Description("Regime de Competência")]
        Competencia = 2
    }

    public enum IndicadorAliquotaCSLL2015
    {
        [System.ComponentModel.Description("9%")]
        NovePorcento = 1,
        [System.ComponentModel.Description("17%")]
        DezessetePorcento = 2,
        [System.ComponentModel.Description("20%")]
        VintePorcento = 3,
        [System.ComponentModel.Description("Não Aplicável")]
        NA = 99
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public enum MetodoAvEstoque
    {
        [System.ComponentModel.Description("1 – Custo Médio Ponderado")]
        CustoMedioPonderado = 1,
        [System.ComponentModel.Description("2 – PEPS (Primeiro que entra, primeiro que sai)")]
        PEPS = 2,
        [System.ComponentModel.Description("3 – Arbitramento - art. 296, Inc. I e II, do RIR/99")]
        Arbitramento = 3,
        [System.ComponentModel.Description("4 – Custo Específico")]
        CustoEspecifico = 4,
        [System.ComponentModel.Description("5 – Valor Realizável Líquido")]
        ValorRealizavelLiquido = 5,
        [System.ComponentModel.Description("6 - Inventário Períodico")]
        InventarioPeriodico = 6,
        [System.ComponentModel.Description("7 – Outros")]
        Outros = 7,
        [System.ComponentModel.Description("8 – Não há (Exemplo: Empresas Prestadoras de Serviços)")]
        NaoHa = 8
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public enum TipoProcessoLancto
    {
        [System.ComponentModel.Description("1 – Judicial")]
        Judicial = 1,
        [System.ComponentModel.Description("2 – Administrativo")]
        Administrativo = 2
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}