
namespace EficazFramework.SPED.Schemas.eSocial;

/// <summary>
/// Versão do schema
/// </summary>
public enum Versao
{
    v_S_01_02_00 = 0,
}

public enum Ambiente
{
    [System.Xml.Serialization.XmlEnum("1")]
    [System.ComponentModel.Description("Produção")]
    Producao = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    [System.ComponentModel.Description("Produção Restrita - Dados Reais")]
    ProducaoRestrita_DadosReais = 2
    // <System.Xml.Serialization.XmlEnumAttribute("3")>
    // <Attributes.DisplayName("Produção Restrita - Dados Fictícios")>
    // ProducaoRestrita_DadosFicticios = 3
}

public enum EmissorEvento
{
    [System.Xml.Serialization.XmlEnum("1")]
    AppEmpregador = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    AppGovernamentalDomestico = 2,
    [System.Xml.Serialization.XmlEnum("3")]
    AppGovernamentalWeb = 3,
    [System.Xml.Serialization.XmlEnum("4")]
    AppGovernamentalMEI = 4,
    [System.Xml.Serialization.XmlEnum("5")]
    AppGovernamentalSegEspecial = 5
}

public enum IndicadorApuracao
{
    [System.Xml.Serialization.XmlEnum("1")]
    Mensal = 1
}

public enum IndicadorGuia
{
    [System.Xml.Serialization.XmlEnum("1")]
    DAE = 1
}


public enum PersonalidadeJuridica
{
    [System.Xml.Serialization.XmlEnum("1")]
    CNPJ = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    CPF = 2,
    [System.Xml.Serialization.XmlEnum("4")]
    CNO = 4
}

public enum IndicadorRetificacao
{
    [System.Xml.Serialization.XmlEnum("1")]
    Original = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    Retificacao = 2
}

public enum SimNaoString
{


    /// <remarks/>
    [System.Xml.Serialization.XmlEnum("S")]
    Sim = 0,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnum("N")]
    Nao = 1
}

public enum SimNaoByte
{


    /// <remarks/>
    [System.Xml.Serialization.XmlEnum("0")]
    Nao = 0,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnum("1")]
    Sim = 1
}

public enum OpcaoTributacaoPrevidenciaria
{
    [System.Xml.Serialization.XmlEnum("1")]
    Comercializacao = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    FolhaPagto = 2
}

public enum GrupoEnvio
{
    EventosIniciais = 1,
    EventosPeriodicos = 3,
    EventosNaoPeriodicos = 2
}

public enum UFCadastro
{

    /// <remarks/>
    AC,

    /// <remarks/>
    AL,

    /// <remarks/>
    AP,

    /// <remarks/>
    AM,

    /// <remarks/>
    BA,

    /// <remarks/>
    CE,

    /// <remarks/>
    DF,

    /// <remarks/>
    ES,

    /// <remarks/>
    GO,

    /// <remarks/>
    MA,

    /// <remarks/>
    MT,

    /// <remarks/>
    MS,

    /// <remarks/>
    MG,

    /// <remarks/>
    PA,

    /// <remarks/>
    PB,

    /// <remarks/>
    PR,

    /// <remarks/>
    PE,

    /// <remarks/>
    PI,

    /// <remarks/>
    RJ,

    /// <remarks/>
    RN,

    /// <remarks/>
    RS,

    /// <remarks/>
    RO,

    /// <remarks/>
    RR,

    /// <remarks/>
    SC,

    /// <remarks/>
    SP,

    /// <remarks/>
    SE,

    /// <remarks/>
    TO
}

/* TODO ERROR: Skipped RegionDirectiveTrivia */
public enum IndicadorCooperativa
{
    [System.Xml.Serialization.XmlEnum("0")]
    Nao = 0,
    [System.Xml.Serialization.XmlEnum("1")]
    CoopTrabalho = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    CoopProducao = 2,
    [System.Xml.Serialization.XmlEnum("3")]
    OutrasCoops = 3
}

public enum SituacaoPessoaJuridica
{
    [System.Xml.Serialization.XmlEnum("0")]
    [System.ComponentModel.Description("Normal")]
    Normal = 0,
    [System.Xml.Serialization.XmlEnum("1")]
    [System.ComponentModel.Description("Extinção")]
    Extincao = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    [System.ComponentModel.Description("Fusão")]
    Fusao = 2,
    [System.Xml.Serialization.XmlEnum("3")]
    [System.ComponentModel.Description("Cisão")]
    Cisao = 3,
    [System.Xml.Serialization.XmlEnum("4")]
    [System.ComponentModel.Description("Incorporação")]
    Incorporacao = 4
}

public enum SituacaoPessoaFisica
{
    [System.Xml.Serialization.XmlEnum("0")]
    [System.ComponentModel.Description("Normal")]
    Normal = 0,
    [System.Xml.Serialization.XmlEnum("1")]
    [System.ComponentModel.Description("Encerramento de Espólio")]
    Espolio = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    [System.ComponentModel.Description("Saída do país em caráter permanente")]
    SaidaPais = 2
}

/* TODO ERROR: Skipped EndRegionDirectiveTrivia */
/* TODO ERROR: Skipped RegionDirectiveTrivia */
public enum TipoInscricao
{
    [System.Xml.Serialization.XmlEnum("1")]
    CNPJ = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    CPF = 2,
    [System.Xml.Serialization.XmlEnum("3")]
    CAEPF = 3,
    [System.Xml.Serialization.XmlEnum("4")]
    CNO = 4,
    [System.Xml.Serialization.XmlEnum("5")]
    CGC = 5
}

public enum TipoCAEPF
{
    [System.Xml.Serialization.XmlEnum("1")]
    ContribIndividual = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    ProdRural = 2,
    [System.Xml.Serialization.XmlEnum("2")]
    SegEspecial = 3
}

public enum IndicadorSubstPatronalObra
{
    [System.Xml.Serialization.XmlEnum("1")]
    ContribPatSubstituida = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    NaoSubstituida = 2
}

public enum RegistroPonto
{
    [System.Xml.Serialization.XmlEnum("0")]
    NaoUtiliza = 0,
    [System.Xml.Serialization.XmlEnum("1")]
    Manual = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    Mecanico = 2,
    [System.Xml.Serialization.XmlEnum("3")]
    Eletronico_MTE_1510_09 = 3,
    [System.Xml.Serialization.XmlEnum("4")]
    NaoEletronico_Alt_MTE1_373_11 = 4,
    [System.Xml.Serialization.XmlEnum("5")]
    Eletronico_Alt_MTE2_373_11 = 5,
    [System.Xml.Serialization.XmlEnum("6")]
    Eletronico_Outros = 6
}

public enum IndicadorContratAprendiz
{
    [System.Xml.Serialization.XmlEnum("0")]
    DispensadoLei = 0,
    [System.Xml.Serialization.XmlEnum("1")]
    DispensadoParcialmente_ProcJud = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    Obrigado = 2
    // De nada
}

public enum IndicadorAprendiz
{
    [System.Xml.Serialization.XmlEnum("0")]
    NA = 0,
    /// <summary>
    /// Contratação direta: contratação do aprendiz efetivada pelo estabelecimento cumpridor da cota de aprendizagem
    /// </summary>
    [System.Xml.Serialization.XmlEnum("1")]
    ContratacaoDireta = 1,
    /// <summary>
    /// Contratação indireta: contratação do aprendiz efetivada por entidades sem fins lucrativos ou por entidades de prática desportiva a serviço do estabelecimento cumpridor da cota
    /// </summary>
    [System.Xml.Serialization.XmlEnum("2")]
    ContratacaoIndireta = 2
}

public enum IndicadorContratPCD
{
    [System.Xml.Serialization.XmlEnum("0")]
    DispensadoLei = 0,
    [System.Xml.Serialization.XmlEnum("1")]
    DispensadoParcialmente_ProcJud = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    ExibibilidadeSusp = 2,
    [System.Xml.Serialization.XmlEnum("3")]
    Obrigado = 3
    // De nada
}

/* TODO ERROR: Skipped EndRegionDirectiveTrivia */
/* TODO ERROR: Skipped RegionDirectiveTrivia */
public enum NaturezaRubrica
{
    [System.Xml.Serialization.XmlEnum("1")]
    Provento = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    Desconto = 2,
    [System.Xml.Serialization.XmlEnum("3")]
    Outros = 3,
    [System.Xml.Serialization.XmlEnum("4")]
    Outros_deducao = 4
}

public enum TipoProcesso
{
    [System.Xml.Serialization.XmlEnum("1")]
    Administrativo = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    Judicial = 2
}

public enum DescisaoSentencaCP
{
    [System.Xml.Serialization.XmlEnum("1")]
    CPP = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    CPP_DescontadaSeg = 2
}

/* TODO ERROR: Skipped EndRegionDirectiveTrivia */
/* TODO ERROR: Skipped RegionDirectiveTrivia */
public enum TipoBC_FPAS
{
    [System.Xml.Serialization.XmlEnum("0")]
    Remuneracao = 4,
    [System.Xml.Serialization.XmlEnum("1")]
    SalContribPrev20 = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    ReceitaBrutaProd = 2,
    [System.Xml.Serialization.XmlEnum("99")]
    NaoAplicavel = 99
}

/* TODO ERROR: Skipped EndRegionDirectiveTrivia */
/* TODO ERROR: Skipped RegionDirectiveTrivia */
public enum AcumuladorCargo
{
    [System.Xml.Serialization.XmlEnum("1")]
    NaoAcumulavel = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    ProfSaude = 2,
    [System.Xml.Serialization.XmlEnum("3")]
    Professor = 3,
    [System.Xml.Serialization.XmlEnum("4")]
    TecnicoCientifico = 4
}

public enum ContagemEspecialCargo
{
    [System.Xml.Serialization.XmlEnum("1")]
    Nao = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    Professor_InfFundMedio = 2,
    [System.Xml.Serialization.XmlEnum("3")]
    Professor_SupMagMpTribC = 3,
    [System.Xml.Serialization.XmlEnum("4")]
    AtividadeRisco = 4
}

public enum SituacaoCargoPublico
{
    [System.Xml.Serialization.XmlEnum("1")]
    Criacao = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    Extincao = 2,
    [System.Xml.Serialization.XmlEnum("3")]
    Reestruturacao = 3
}

/* TODO ERROR: Skipped EndRegionDirectiveTrivia */
/* TODO ERROR: Skipped RegionDirectiveTrivia */
public enum IndicadorAquisicaoS1250
{
    [System.Xml.Serialization.XmlEnum("1")]
    ProdRuralPF = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    ProdRuralPF_PAA = 2,
    [System.Xml.Serialization.XmlEnum("3")]
    ProdRUralPJ_PAA = 3,
    [System.Xml.Serialization.XmlEnum("4")]
    ProdRuralPF_Isencao = 4,
    [System.Xml.Serialization.XmlEnum("5")]
    ProdRuralPF_PAA_Isencao = 5,
    [System.Xml.Serialization.XmlEnum("6")]
    ProdRuralPJ_PAA_Isentacao = 6
}

/* TODO ERROR: Skipped EndRegionDirectiveTrivia */
/* TODO ERROR: Skipped RegionDirectiveTrivia */
public enum IndicadorComercializacaoS1260
{
    [System.Xml.Serialization.XmlEnum("2")]
    VarejoConsFinalOuProdRural = 2,
    [System.Xml.Serialization.XmlEnum("3")]
    Vendas_a_PJ = 3,
    [System.Xml.Serialization.XmlEnum("7")]
    ProducaoIsenta = 7,
    [System.Xml.Serialization.XmlEnum("8")]
    VendasPAA = 8,
    [System.Xml.Serialization.XmlEnum("9")]
    MercadoExterno = 9
}


/* TODO ERROR: Skipped EndRegionDirectiveTrivia */
/* TODO ERROR: Skipped RegionDirectiveTrivia */
public enum Sexo
{
    [System.Xml.Serialization.XmlEnum("M")]
    [System.ComponentModel.Description("Masculino")]
    Masculino = 1,
    [System.Xml.Serialization.XmlEnum("F")]
    [System.ComponentModel.Description("Feminino")]
    Feminino = 2
}

public enum RacaCor
{
    [System.Xml.Serialization.XmlEnum("1")]
    [System.ComponentModel.Description("Branca")]
    Branca = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    [System.ComponentModel.Description("Preta")]
    Preta = 2,
    [System.Xml.Serialization.XmlEnum("3")]
    [System.ComponentModel.Description("Parda")]
    Parda = 3,
    [System.Xml.Serialization.XmlEnum("4")]
    [System.ComponentModel.Description("Amarela")]
    Amarela = 4,
    [System.Xml.Serialization.XmlEnum("5")]
    [System.ComponentModel.Description("Indígena")]
    Indigena = 5,
    [System.Xml.Serialization.XmlEnum("6")]
    [System.ComponentModel.Description("Não Informado")]
    NaoInformado = 6
}

public enum EstadoCivil
{
    [System.Xml.Serialization.XmlEnum("1")]
    [System.ComponentModel.Description("Solteiro")]
    Solteiro = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    [System.ComponentModel.Description("Casado")]
    Casado = 2,
    [System.Xml.Serialization.XmlEnum("3")]
    [System.ComponentModel.Description("Divorciado")]
    Divorciado = 3,
    [System.Xml.Serialization.XmlEnum("4")]
    [System.ComponentModel.Description("Separado")]
    Separado = 4,
    [System.Xml.Serialization.XmlEnum("5")]
    [System.ComponentModel.Description("Viúvo")]
    Viuvo = 5
}

public enum GrauInstrucao
{
    [System.Xml.Serialization.XmlEnum("01")]
    [System.ComponentModel.Description("01 - Analfabeto, inclusive o que, embora tenha recebido instrução, não se alfabetizou")]
    Analfabeto = 1,
    [System.Xml.Serialization.XmlEnum("02")]
    [System.ComponentModel.Description("02 - Até o 5º ano incompleto do Ensino Fundamental (antiga 4ª série) ou que se tenha alfabetizado sem ter frequentado escola regular")]
    FundamentalIncompletoAte5Ano = 2,
    [System.Xml.Serialization.XmlEnum("03")]
    [System.ComponentModel.Description("03 - 5º ano completo do Ensino Fundamental")]
    FundamentalCompletoAte5Ano = 3,
    [System.Xml.Serialization.XmlEnum("04")]
    [System.ComponentModel.Description("04 - Do 6º ao 9º ano do Ensino Fundamental incompleto (antiga 5ª a 8ª série)")]
    FundamentalIncompleto6a9Ano = 4,
    [System.Xml.Serialization.XmlEnum("05")]
    [System.ComponentModel.Description("05 - Ensino Fundamental Completo")]
    FundamentalCompletoTotal = 5,
    [System.Xml.Serialization.XmlEnum("06")]
    [System.ComponentModel.Description("06 - Ensino Médio incompleto")]
    MedioIncompleto = 6,
    [System.Xml.Serialization.XmlEnum("07")]
    [System.ComponentModel.Description("07 - Ensino Médio completo")]
    MedioCompleto = 7,
    [System.Xml.Serialization.XmlEnum("08")]
    [System.ComponentModel.Description("08 - Educação Superior incompleta")]
    SuperiorIncompleto = 8,
    [System.Xml.Serialization.XmlEnum("09")]
    [System.ComponentModel.Description("09 - Educação Superior completa")]
    SuperiorCompleto = 9,
    [System.Xml.Serialization.XmlEnum("10")]
    [System.ComponentModel.Description("10 - Pós-Graduação completa")]
    PosGraduacaoCompleta = 10,
    [System.Xml.Serialization.XmlEnum("11")]
    [System.ComponentModel.Description("11 - Mestrado completo")]
    Mestrado = 11,
    [System.Xml.Serialization.XmlEnum("12")]
    [System.ComponentModel.Description("12 - Doutorado completo")]
    Doutorado = 12
}

public enum ClasseTrabEstrangeiro
{
    [System.Xml.Serialization.XmlEnum("1")]
    [System.ComponentModel.Description("1 - Visto permanente")]
    VistoPermanente = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    [System.ComponentModel.Description("2 - Visto temporário")]
    VistoTemporario = 2,
    [System.Xml.Serialization.XmlEnum("3")]
    [System.ComponentModel.Description("3 - Asilado")]
    Asilado = 3,
    [System.Xml.Serialization.XmlEnum("4")]
    [System.ComponentModel.Description("4 - Refugiado")]
    Regufiado = 4,
    [System.Xml.Serialization.XmlEnum("5")]
    [System.ComponentModel.Description("5 - Solicitante de Refúgio")]
    SolictRefudio = 5,
    [System.Xml.Serialization.XmlEnum("6")]
    [System.ComponentModel.Description("6 - Residente fora do Brasil")]
    ResForaBrasil = 6,
    [System.Xml.Serialization.XmlEnum("7")]
    [System.ComponentModel.Description("7 - Deficiente físico e com mais de 51 anos")]
    DeficienteFisiMaior51Anos = 7,
    [System.Xml.Serialization.XmlEnum("8")]
    [System.ComponentModel.Description("8 - Com residência provisória e anistiado, em situação irregular")]
    ResidProvisoria_Anistiado_Irregular = 8,
    [System.Xml.Serialization.XmlEnum("9")]
    [System.ComponentModel.Description("9 - Permanência no Brasil em razão de filhos ou cônjuge brasileiros")]
    PermPorFilhosOuConjugeBR = 9,
    [System.Xml.Serialization.XmlEnum("10")]
    [System.ComponentModel.Description("10 - Beneficiado pelo acordo entre países do Mercosul")]
    BeneficMercosul = 10,
    [System.Xml.Serialization.XmlEnum("11")]
    [System.ComponentModel.Description("11 - Dependente de agente diplomático e/ou consular de países que mantém convênio de reciprocidade para o exercício de atividade remunerada no Brasil")]
    DepAgDiplomatico = 11,
    [System.Xml.Serialization.XmlEnum("12")]
    [System.ComponentModel.Description("12 - Beneficiado pelo Tratado de Amizade, Cooperação e Consulta entre a República Federativa do Brasil e a República Portuguesa")]
    TratAmizBR_PT = 12
}

public enum VinculoTrabalhista
{
    [System.Xml.Serialization.XmlEnum("1")]
    [System.ComponentModel.Description("CLT")]
    CLT = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    [System.ComponentModel.Description("Estatutário")]
    Estatutario = 2,
    [System.Xml.Serialization.XmlEnum("9999")]
    [System.ComponentModel.Description("Não Aplicável - Evento de Alteração")]
    NA = 9999
}

public enum RegimePrevidenciario
{
    [System.Xml.Serialization.XmlEnum("1")]
    [System.ComponentModel.Description("1 - Regime Gera da Previdência Social - RGPS")]
    RGPS = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    [System.ComponentModel.Description("2 - Regime Próprio de Previdência Social - RPPS")]
    RPPS = 2,
    [System.ComponentModel.Description("3 - Regime de Previdência Social no Exterior")]
    Exterior = 3
}

public enum TipoAdmissaoCLT
{
    [System.ComponentModel.Description("1 - Admissão")]
    Admissao = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    [System.ComponentModel.Description("2 - Transferência de empresa do mesmo grupo econômico")]
    TransfMesmoGrupoEcon = 2,
    [System.Xml.Serialization.XmlEnum("3")]
    [System.ComponentModel.Description("3 - Transferência de empresa consorciada ou de consórcio")]
    TransConsorciada = 3,
    [System.Xml.Serialization.XmlEnum("4")]
    [System.ComponentModel.Description("4 - Transferência por motivo de sucessão, incorporação, cisão ou fusão")]
    TransfSucessaoIncCisaoFusao = 4,
    [System.Xml.Serialization.XmlEnum("5")]
    [System.ComponentModel.Description("5 - Transferência do empregado doméstico para outro representante da mesma unidade familiar")]
    TransfDomesticoMesmaFamilia = 5,
    [System.Xml.Serialization.XmlEnum("6")]
    [System.ComponentModel.Description("6 - Mudança de CPF")]
    MudancaCPF = 6,
    [System.Xml.Serialization.XmlEnum("9999")]
    [System.ComponentModel.Description("Não Aplicável - Evento de Alteração")]
    NA = 9999
}

public enum IndicadorAdmissao
{
    [System.Xml.Serialization.XmlEnum("1")]
    [System.ComponentModel.Description("1 - Normal")]
    Normal = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    [System.ComponentModel.Description("2 - Decorrente de Ação Fiscal")]
    AcaoFiscal = 2,
    [System.Xml.Serialization.XmlEnum("3")]
    [System.ComponentModel.Description("3 - Decorrente de Decisão Judicial")]
    DecisaoJudicial = 3,
    [System.Xml.Serialization.XmlEnum("9999")]
    [System.ComponentModel.Description("Não Aplicável - Evento de Alteração")]
    NA = 9999
}

public enum VinculoRegimeJornada
{
    [System.ComponentModel.Description("1 - Submetidos a Horário de Trabalho (Cap. II da CLT)")]
    SubHorarioTrabalho = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    [System.ComponentModel.Description("2 - Atividade Externa especificada no Inciso I do Art. 62 da CLT")]
    AtivExterna = 2,
    [System.Xml.Serialization.XmlEnum("3")]
    [System.ComponentModel.Description("3 - Funções especificadas no Inciso II do Art. 62 da CLT")]
    FuncoesEspecificas = 3,
    [System.Xml.Serialization.XmlEnum("4")]
    [System.ComponentModel.Description("4 - Teletrabalho, previsto no Inciso III do Art. 62 da CLT")]
    TeleTrabalho = 4
}

public enum NaturezaAtividade
{
    [System.Xml.Serialization.XmlEnum("1")]
    [System.ComponentModel.Description("1 - Trabalho Urbano")]
    Urbano = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    [System.ComponentModel.Description("2 - Trabalho Rural")]
    Rural = 2
}

public enum OpcaoFGTS
{
    [System.Xml.Serialization.XmlEnum("1")]
    [System.ComponentModel.Description("1 - Optante")]
    Optante = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    [System.ComponentModel.Description("2 - Não Optante")]
    NaoOptante = 2
}

public enum TrabTemporarioHipotese
{
    [System.Xml.Serialization.XmlEnum("1")]
    [System.ComponentModel.Description("1 - Necessidade de substituição transitória de pessoal permanente")]
    SubstTransitoriaPessoalPermn = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    [System.ComponentModel.Description("2 - Demanda complementar de serviços")]
    DemandaComplementar = 2,
    [System.Xml.Serialization.XmlEnum("9999")]
    [System.ComponentModel.Description("Não Aplicável")]
    NA = 9999
}

public enum TrabTemporarioTpInclusao
{
    [System.Xml.Serialization.XmlEnum("1")]
    [System.ComponentModel.Description("1 - Locais sem filiais")]
    SemFiliais = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    [System.ComponentModel.Description("2 - Estudo de mercado")]
    EstudoMercado = 2,
    [System.Xml.Serialization.XmlEnum("2")]
    [System.ComponentModel.Description("3 - Contratação superior a 3 meses")]
    Superior3Meses = 3,
    [System.Xml.Serialization.XmlEnum("9999")]
    [System.ComponentModel.Description("Não Aplicável")]
    NA = 9999
}

public enum IndicadorAdmissaoEstatutario
{
    [System.Xml.Serialization.XmlEnum("1")]
    [System.ComponentModel.Description("1 - Normal")]
    Normal = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    [System.ComponentModel.Description("2 - Decorrente de Decisão Judicial")]
    DecisaoJudicial = 2
}

public enum TipoProvimentoEstatutario
{
    [System.Xml.Serialization.XmlEnum("1")]
    [System.ComponentModel.Description("1 - Nomeação em cargo efetivo")]
    NomeacaoEfetivo = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    [System.ComponentModel.Description("2 - Nomeação em cargo em comissão")]
    NomeacaoComissao = 2,
    [System.Xml.Serialization.XmlEnum("3")]
    [System.ComponentModel.Description("3 - Incorporação (militar)")]
    IncorporacaoMilitar = 3,
    [System.Xml.Serialization.XmlEnum("4")]
    [System.ComponentModel.Description("4 - Matrícula (militar)")]
    MatriculaMilitar = 4,
    [System.Xml.Serialization.XmlEnum("5")]
    [System.ComponentModel.Description("5 - Reinclusão (militar)")]
    ReinclusaoMilitar = 5,
    [System.Xml.Serialization.XmlEnum("6")]
    [System.ComponentModel.Description("6 - Diplomação")]
    Diplomacao = 6,
    [System.Xml.Serialization.XmlEnum("99")]
    [System.ComponentModel.Description("Outros")]
    Outros = 7
}

public enum PlanoSegregacaoMassa
{
    [System.Xml.Serialization.XmlEnum("1")]
    [System.ComponentModel.Description("1 - Plano previdenciário ou único")]
    PrevUnico = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    [System.ComponentModel.Description("2 - Plano financeiro")]
    Financeiro = 2
}

public enum UnidadeSalarial
{
    [System.Xml.Serialization.XmlEnum("1")]
    [System.ComponentModel.Description("1 - Por Hora")]
    Hora = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    [System.ComponentModel.Description("2 - Por Dia")]
    Dia = 2,
    [System.Xml.Serialization.XmlEnum("3")]
    [System.ComponentModel.Description("3 - Por Semana")]
    Semana = 3,
    [System.Xml.Serialization.XmlEnum("4")]
    [System.ComponentModel.Description("4 - Por Quinzena")]
    Quinzena = 4,
    [System.Xml.Serialization.XmlEnum("5")]
    [System.ComponentModel.Description("5 - Por Mês")]
    Mes = 5,
    [System.Xml.Serialization.XmlEnum("6")]
    [System.ComponentModel.Description("6 - Por Tarefa")]
    Tarefa = 6,
    [System.Xml.Serialization.XmlEnum("7")]
    [System.ComponentModel.Description("7 - Não aplicável - salário exclusivamente variável")]
    Variavel = 7
}

public enum TipoContrato
{
    [System.Xml.Serialization.XmlEnum("1")]
    [System.ComponentModel.Description("1 - Prazo indeterminado")]
    Indeterminado = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    [System.ComponentModel.Description("2 - Prazo determinado, definido em dias;")]
    DeterminadoDias = 2,
    [System.Xml.Serialization.XmlEnum("3")]
    [System.ComponentModel.Description("3 - Prazo determinado, vinculado à ocorrência de um fato")]
    DeterminadoFato = 3
}

public enum TipoJornada
{
    // <System.Xml.Serialization.XmlEnumAttribute("1")>
    // <Attributes.DisplayName("1 - Jornada com horário diário e folga fixos")>
    // HorarioFolgaFixo = 1
    [System.Xml.Serialization.XmlEnum("2")]
    [System.ComponentModel.Description("2 - Jornada 12 x 36 (12 horas de trabalho seguidas de 36 horas ininterruptas de descanso)")]
    j12x36 = 2,
    [System.Xml.Serialization.XmlEnum("3")]
    [System.ComponentModel.Description("3 - Jornada com horário diário fixo e folga variável")]
    HorarioFixoFolgaVariavel = 3,
    [System.Xml.Serialization.XmlEnum("4")]
    [System.ComponentModel.Description("4 - Jornada com horário diário fixo e folga fixa (no domingo)")]
    HorarioFixoFolgaFixa_Dom = 4,
    [System.Xml.Serialization.XmlEnum("5")]
    [System.ComponentModel.Description("5 - Jornada com horário diário fixo e folga fixa (exceto no domingo)")]
    HorarioFixoFolgaFixa_ExDom = 5,
    [System.Xml.Serialization.XmlEnum("6")]
    [System.ComponentModel.Description("6 - Jornada com horário diário fixo e folga fixa (em outro dia da semana)")]
    HorarioFixoFolgaFixa_OutroDia = 6,
    [System.Xml.Serialization.XmlEnum("7")]
    [System.ComponentModel.Description("7 - Turno ininterrupto de revezamento")]
    TurnoIniterruptoRevezamento = 7,
    [System.Xml.Serialization.XmlEnum("9")]
    [System.ComponentModel.Description("9 - Demais tipos de jornada")]
    Outros = 9
}

public enum TempoParcial
{
    [System.Xml.Serialization.XmlEnum("0")]
    [System.ComponentModel.Description("0 - Não é contrato em tempo parcial")]
    NaoETempoParcial = 0,
    [System.Xml.Serialization.XmlEnum("1")]
    [System.ComponentModel.Description("1 - Limitado a 25 horas semnanais")]
    Lim25Horas = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    [System.ComponentModel.Description("2 - Limitado a 30 horas semnanais")]
    Lim30Horas = 2,
    [System.Xml.Serialization.XmlEnum("3")]
    [System.ComponentModel.Description("3 - Limitado a 26 horas semnanais")]
    Lim26Horas = 3
}

public enum VinculoSucecssaoAnteriorTipo
{
    [System.Xml.Serialization.XmlEnum("1")]
    [System.ComponentModel.Description("CNPJ")]
    CNPJ = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    [System.ComponentModel.Description("CPF")]
    CPF = 2,
    [System.Xml.Serialization.XmlEnum("5")]
    [System.ComponentModel.Description("CGC")]
    CGC = 5,
    [System.Xml.Serialization.XmlEnum("6")]
    [System.ComponentModel.Description("CEI")]
    CEI = 6
}

public enum ImigranteTempoResidencia
{
    [System.Xml.Serialization.XmlEnum("1")]
    [System.ComponentModel.Description("1 - Prazo Indeterminado")]
    Indeterminado = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    [System.ComponentModel.Description("2 - Prazo Determinado")]
    Determinado = 2,
    [System.Xml.Serialization.XmlEnum("9999")]
    [System.ComponentModel.Description("Não se Aplica")]
    NA = 9999
}

public enum ImigranteCondicao
{
    [System.Xml.Serialization.XmlEnum("1")]
    [System.ComponentModel.Description("1 - Refugiado")]
    Refugidao = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    [System.ComponentModel.Description("2 - Solicitante Refúgio")]
    SolicitanteRefugio = 2,
    [System.Xml.Serialization.XmlEnum("3")]
    [System.ComponentModel.Description("3 - Permanência no Brasil em razão de reunião familiar")]
    PermanenciaReuniaoFamiliar = 3,
    [System.Xml.Serialization.XmlEnum("4")]
    [System.ComponentModel.Description("4 - Beneficiado pelo acordo entre Países do Mercosul")]
    Mercosul = 4,
    [System.Xml.Serialization.XmlEnum("5")]
    [System.ComponentModel.Description("5 - Dependente de ag. diplomático e/ou consular de países com acordo de reciproc. para exercício de ativ. rem. no Brasil")]
    DepAgenteDiplomatico = 6,
    [System.Xml.Serialization.XmlEnum("6")]
    [System.ComponentModel.Description("6 - Benef. pelo Tratado de Amizade, Coop. e Consulta entre a Rep. Fed. Brasil e a Rep. Portuguesa")]
    Tratado = 6,
    [System.Xml.Serialization.XmlEnum("7")]
    [System.ComponentModel.Description("7 - Outra Condição")]
    Outra = 7,
    [System.Xml.Serialization.XmlEnum("9999")]
    [System.ComponentModel.Description("Não se Aplica")]
    NA = 9999
}
