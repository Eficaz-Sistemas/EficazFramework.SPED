using System;

namespace EficazFramework.SPED.Schemas.EFD_Reinf;

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
    AppContribuinte = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    AppGovernamental = 2
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

public enum ObrigatoriedadeECD
{
    [System.Xml.Serialization.XmlEnum("0")]
    [System.ComponentModel.Description("Não entrega ECD")]
    NaoFaz = 0,
    [System.Xml.Serialization.XmlEnum("1")]
    [System.ComponentModel.Description("Obrigada a entrega da ECD")]
    EntregaECD = 1
}

public enum DesoneracaoCPRB
{
    [System.Xml.Serialization.XmlEnum("0")]
    [System.ComponentModel.Description("Não Aplicável")]
    NaoAplicavel = 0,
    [System.Xml.Serialization.XmlEnum("1")]
    [System.ComponentModel.Description("Desonerada")]
    Desonerada = 1
}

public enum AcordoInternacionalIsencaoMulta
{
    [System.Xml.Serialization.XmlEnum("0")]
    [System.ComponentModel.Description("Sem Acordo")]
    SemAcordo = 0,
    [System.Xml.Serialization.XmlEnum("1")]
    [System.ComponentModel.Description("Com Acordo")]
    ComAcordo = 1
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

public enum TipoProcesso
{
    [System.Xml.Serialization.XmlEnum("1")]
    Administrativo = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    Judicial = 2
}

public enum IndicadorAuditoria
{
    [System.Xml.Serialization.XmlEnum("1")]
    Contribuinte = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    Outros = 2
}

public enum TipoCompeticao
{
    Oficial = 1,
    NaoOficial = 2
}

public enum CategoriaEvento
{
    Internacional = 1,
    Interestadual = 2,
    Estadual = 3,
    Local = 4
}

public enum TipoIngressoCompeticao
{
    Arquibancada = 1,
    Geral = 2,
    Cadeiras = 3,
    Camarote = 4
}

public enum TipoReceitaCompeticao
{
    Transmissao = 1,
    Propaganda = 2,
    Publicidade = 3,
    Sorteio = 4,
    Outros = 5
}

public enum IndicadorRetificacao
{
    [System.Xml.Serialization.XmlEnum("1")]
    Original = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    Retificacao = 2
}

public enum SimNao
{


    /// <remarks/>
    [System.Xml.Serialization.XmlEnum("S")]
    Sim = 0,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnum("N")]
    Nao = 1
}

public enum TipoAjusteContribuicao
{
    [System.Xml.Serialization.XmlEnum("0")]
    Reducao = 0,
    [System.Xml.Serialization.XmlEnum("1")]
    Acrescimo = 1
}

public enum IndicadorContribuicaoProd
{
    [System.Xml.Serialization.XmlEnum("1")]
    PJ_Agrodind = 1,
    [System.Xml.Serialization.XmlEnum("8")]
    PAA = 8,
    [System.Xml.Serialization.XmlEnum("9")]
    MercadoExterno = 9
}

public enum IndicadorAquisProd
{
    [System.Xml.Serialization.XmlEnum("1")]
    PF = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    PF_PAA = 2,
    [System.Xml.Serialization.XmlEnum("3")]
    PJ_PAA = 3,
    [System.Xml.Serialization.XmlEnum("4")]
    PF_ProdIsenta = 4,
    [System.Xml.Serialization.XmlEnum("5")]
    PF_PAA_ProdIsenta = 5,
    [System.Xml.Serialization.XmlEnum("6")]
    PJ_PAA_ProdIsenta = 6,
    [System.Xml.Serialization.XmlEnum("7")]
    PF_Exportacao = 7
}


public enum CodigoAjusteConstribuicao
{
    [System.Xml.Serialization.XmlEnum("1")]
    CPRB_RegimeCaixa = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    CPRB_DiferimentoValoresRecolher = 2,
    [System.Xml.Serialization.XmlEnum("3")]
    AdicaoValoresDiferidosAnteriores = 3,
    [System.Xml.Serialization.XmlEnum("4")]
    ExportacoesDiretas = 4,
    [System.Xml.Serialization.XmlEnum("5")]
    TransporteInternacionalCargas = 5,
    [System.Xml.Serialization.XmlEnum("6")]
    VendasCancDescIncondicionais = 6,
    [System.Xml.Serialization.XmlEnum("7")]
    IPI_inclRecBruta = 7,
    [System.Xml.Serialization.XmlEnum("8")]
    ICMS_VendedorST = 8,
    [System.Xml.Serialization.XmlEnum("9")]
    Constr_Reforma_Ampl_AtivoIntangivel = 9,
    [System.Xml.Serialization.XmlEnum("10")]
    AporteRecursos = 10,
    [System.Xml.Serialization.XmlEnum("11")]
    Outros = 11
}

public enum IndicadorObra
{
    [System.Xml.Serialization.XmlEnum("0")]
    NaoSujeitoCEI = 0,
    [System.Xml.Serialization.XmlEnum("1")]
    Obra_Total = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    Obra_Parcial = 2
}

public enum TipoRepasseAssocDesp
{
    [System.Xml.Serialization.XmlEnum("1")]
    Patrocinio = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    LicencMarcasSimbolos = 2,
    [System.Xml.Serialization.XmlEnum("3")]
    Publicidade = 3,
    [System.Xml.Serialization.XmlEnum("4")]
    Propaganda = 4,
    [System.Xml.Serialization.XmlEnum("5")]
    TranmEspetaculos = 5
}

public enum IndicadorContribuinteCPRB
{


    /// <remarks>Retenção: 11%</remarks>
    [System.Xml.Serialization.XmlEnum("0")]
    NaoContribuinte = 0,

    /// <remarks>Retenção: 3,2%</remarks>
    [System.Xml.Serialization.XmlEnum("1")]
    Contribuinte = 1
}

public enum TipoOCorrenciaR5001
{
    [System.Xml.Serialization.XmlEnum("1")]
    Aviso = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    Erro = 2
}


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evtExclusao/v1_02_00")]
public enum TipoEventoExclusao
{

    /// <remarks/>
    [System.Xml.Serialization.XmlEnum("R-2010")]
    R2010 = 2010,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnum("R-2020")]
    R2020 = 2020,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnum("R-2030")]
    R2030 = 2030,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnum("R-2040")]
    R2040 = 2040,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnum("R-2050")]
    R2050 = 2050,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnum("R-2055")]
    R2055 = 2055,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnum("R-2060")]
    R2060 = 2060,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnum("R-2070")]
    R2070 = 2070,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnum("R-3010")]
    R3010 = 3010
}
