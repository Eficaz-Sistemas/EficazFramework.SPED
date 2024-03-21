using System;
using System.Runtime.Serialization;

namespace EficazFramework.SPED.Schemas.NFe;

// ############
// CABEÇALHO '
// ############

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[DataContract()]
[System.Xml.Serialization.XmlType(TypeName = "TAmb", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum Ambiente
{
    [EnumMember(Value="1")]
    [System.Xml.Serialization.XmlEnum("1")]
    [System.ComponentModel.Description("Enum_Ambiente_Producao")]
    Producao = 1,
    [EnumMember(Value = "2")]
    [System.Xml.Serialization.XmlEnum("2")]
    [System.ComponentModel.Description("Enum_Ambiente_Homologacao")]
    Homologacao = 2
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[DataContract()]
[System.Xml.Serialization.XmlType(TypeName = "TConsNFeDestXServ", AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum ServicoSolicitado
{

    /// <summary>
    /// Web Service 'nfeConsultaNFDest'
    /// </summary>
    /// <remarks></remarks>
    [System.Xml.Serialization.XmlEnum("CONSULTAR NFE DEST")]
    [System.ComponentModel.Description("Enum_ServicoSolicitado_ConsultaNFeDest")]
    CONSULTARNFEDEST
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[DataContract()]
[System.Xml.Serialization.XmlType(TypeName = "TConsNFeDestIndNFe", AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum IndicadorTipoNFe
{

    /// <remarks/>
    [System.Xml.Serialization.XmlEnum("0")]
    [System.ComponentModel.Description("Enum_IndicadorTipoNFe_Todas")]
    Todas = 0,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnum("1")]
    [System.ComponentModel.Description("Enum_IndicadorTipoNFe_NaoManifestadas")]
    NaoManifestadasDesconhecidas = 1,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnum("2")]
    [System.ComponentModel.Description("Enum_IndicadorTipoNFe_NaoCientes")]
    NaoManifestasNaoCientes = 2
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[DataContract()]
[System.Xml.Serialization.XmlType(TypeName = "TConsNFeDestIndEmi", AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum IndicadorEmissorNFe
{

    /// <summary>
    /// Não aplica nenhum filtro baseano no CNPJ do emitente.
    /// </summary>
    /// <remarks></remarks>
    [System.Xml.Serialization.XmlEnum("0")]
    [System.ComponentModel.Description("Enum_IndicadorEmissorNFe_Todos")]
    Todos = 0,

    /// <summary>
    /// Evita que NF-e's emitidas por filiais ou pela matriz do CNPJ destinatário sejam incluídas nos resultados.
    /// </summary>
    /// <remarks></remarks>
    [System.Xml.Serialization.XmlEnum("1")]
    [System.ComponentModel.Description("Enum_IndicadorEmissorNFe_NaoFilial")]
    NaoFinalMatrizCNPJ = 1
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[DataContract()]
[System.Xml.Serialization.XmlType(TypeName = "TRetConsNFeDestRetResCCeTpNF", AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum OperacaoNFe
{
    [System.Xml.Serialization.XmlEnum("0")]
    [System.ComponentModel.Description("Entrada")]
    Entrada = 0,
    [System.Xml.Serialization.XmlEnum("1")]
    [System.ComponentModel.Description("Saída")]
    Saida = 1
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[DataContract()]
[System.Xml.Serialization.XmlType(TypeName = "ItemChoiceType1", Namespace = "http://www.portalfiscal.inf.br/nfe", IncludeInSchema = false)]
public enum PersonalidadeJuridica
{

    /// <summary>
    /// CNPJ: 14 dígitos
    /// </summary>
    /// <remarks></remarks>
    CNPJ,

    /// <summary>
    /// CPF: 11 dígitos
    /// </summary>
    /// <remarks></remarks>
    CPF
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[DataContract()]
[System.Xml.Serialization.XmlType(TypeName = "TRetConsNFeDestRetResCancCSitNFe", AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum SituacaoNFe
{
    [System.Xml.Serialization.XmlEnum("1")]
    [System.ComponentModel.Description("Autorizada")]
    Autorizada = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    [System.ComponentModel.Description("Denegada")]
    Denegada = 2,
    [System.Xml.Serialization.XmlEnum("3")]
    [System.ComponentModel.Description("Cancelada")]
    Cancelada = 3
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[DataContract()]
[System.Xml.Serialization.XmlType(TypeName = "TRetConsNFeDestRetResCancCSitConf", AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum SituacaoManifestacaoDestinatario
{
    [System.Xml.Serialization.XmlEnum("0")]
    [System.ComponentModel.Description("Enum_SituacaoManifestacaoDestinatario_SemManifesto")]
    SemManifestacao = 0,
    [System.Xml.Serialization.XmlEnum("1")]
    [System.ComponentModel.Description("Enum_SituacaoManifestacaoDestinatario_Confirmada")]
    Confirmada = 1,
    [System.Xml.Serialization.XmlEnum("2")]
    [System.ComponentModel.Description("Enum_SituacaoManifestacaoDestinatario_Desconhecida")]
    Desconhecida = 2,
    [System.Xml.Serialization.XmlEnum("3")]
    [System.ComponentModel.Description("Enum_SituacaoManifestacaoDestinatario_NaoRealizada")]
    NaoRealizada = 3,
    [System.Xml.Serialization.XmlEnum("4")]
    [System.ComponentModel.Description("Enum_SituacaoManifestacaoDestinatario_Ciencia")]
    Ciencia = 4
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[DataContract()]
[System.Xml.Serialization.XmlType(TypeName = "TCOrgaoIBGE", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum OrgaoIBGE
{
    [System.ComponentModel.Description("Rondônia")] // , False)>
    [System.Xml.Serialization.XmlEnum("11")]
    RO = 11,
    [System.ComponentModel.Description("Acre")] // , False)>
    [System.Xml.Serialization.XmlEnum("12")]
    AC = 12,
    [System.ComponentModel.Description("Amazonas")] // , False)>
    [System.Xml.Serialization.XmlEnum("13")]
    AM = 13,
    [System.ComponentModel.Description("Roraima")] // , False)>
    [System.Xml.Serialization.XmlEnum("14")]
    RR = 14,
    [System.ComponentModel.Description("Pará")] // , False)>
    [System.Xml.Serialization.XmlEnum("15")]
    PA = 15,
    [System.ComponentModel.Description("Amapá")] // , False)>
    [System.Xml.Serialization.XmlEnum("16")]
    AP = 16,
    [System.ComponentModel.Description("Tocantins")] // , False)>
    [System.Xml.Serialization.XmlEnum("17")]
    TO = 17,
    [System.ComponentModel.Description("Maranhão")] // , False)>
    [System.Xml.Serialization.XmlEnum("21")]
    MA = 21,
    [System.ComponentModel.Description("Piauí")] // , False)>
    [System.Xml.Serialization.XmlEnum("22")]
    PI = 22,
    [System.ComponentModel.Description("Ceará")] // , False)>
    [System.Xml.Serialization.XmlEnum("23")]
    CE = 23,
    [System.ComponentModel.Description("Rio Grande do Norte")] // , False)>
    [System.Xml.Serialization.XmlEnum("24")]
    RN = 24,
    [System.ComponentModel.Description("Paraíba")] // , False)>
    [System.Xml.Serialization.XmlEnum("25")]
    PB = 25,
    [System.ComponentModel.Description("Pernambuco")] // , False)>
    [System.Xml.Serialization.XmlEnum("26")]
    PE = 26,
    [System.ComponentModel.Description("Alagoas")] // , False)>
    [System.Xml.Serialization.XmlEnum("27")]
    AL = 27,
    [System.ComponentModel.Description("Sergipe")] // , False)>
    [System.Xml.Serialization.XmlEnum("28")]
    SE = 28,
    [System.ComponentModel.Description("Bahia")] // , False)>
    [System.Xml.Serialization.XmlEnum("29")]
    BA = 29,
    [System.ComponentModel.Description("Minas Gerais")] // , False)>
    [System.Xml.Serialization.XmlEnum("31")]
    MG = 31,
    [System.ComponentModel.Description("Espírito Santo")] // , False)>
    [System.Xml.Serialization.XmlEnum("32")]
    ES = 32,
    [System.ComponentModel.Description("Rio de Janeiro")] // , False)>
    [System.Xml.Serialization.XmlEnum("33")]
    RJ = 33,
    [System.ComponentModel.Description("São Paulo")] // , False)>
    [System.Xml.Serialization.XmlEnum("35")]
    SP = 35,
    [System.ComponentModel.Description("Paraná")] // , False)>
    [System.Xml.Serialization.XmlEnum("41")]
    PR = 41,
    [System.ComponentModel.Description("Santa Catarina")] // , False)>
    [System.Xml.Serialization.XmlEnum("42")]
    SC = 42,
    [System.ComponentModel.Description("Rio Grande do Sul")] // , False)>
    [System.Xml.Serialization.XmlEnum("43")]
    RS = 43,
    [System.ComponentModel.Description("Mato Grosso do Sul")] // , False)>
    [System.Xml.Serialization.XmlEnum("50")]
    MS = 50,
    [System.ComponentModel.Description("Mato Grosso")] // , False)>
    [System.Xml.Serialization.XmlEnum("51")]
    MT = 51,
    [System.ComponentModel.Description("Goiás")] // , False)>
    [System.Xml.Serialization.XmlEnum("52")]
    GO = 52,
    [System.ComponentModel.Description("Distrito Federal")]
    [System.Xml.Serialization.XmlEnum("53")]
    DF = 53,
    [System.ComponentModel.Description("Distrito Federal")] // , False)>
    [System.Xml.Serialization.XmlEnum("")]
    NN = 0,
    [System.ComponentModel.Description("Enum_OrgaoIBGE_SCAN")]
    [System.Xml.Serialization.XmlEnum("90")]
    SefazNacional_SVCAN = 90,
    [System.ComponentModel.Description("Enum_OrgaoIBGE_SVAN")]
    [System.Xml.Serialization.XmlEnum("91")]
    SefazNacional_SVCRS = 91,
    [System.ComponentModel.Description("Enum_OrgaoIBGE_AN")]
    [System.Xml.Serialization.XmlEnum("92")]
    SefazNacional_AN = 92,
    [System.ComponentModel.Description("Enum_OrgaoIBGE_SVAN")]
    [System.Xml.Serialization.XmlEnum("93")]
    SefazNacional_SVCSP = 93,
    [System.ComponentModel.Description("Exporacao")] // , False)>
    [System.Xml.Serialization.XmlEnum("99")]
    EX = 99
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[DataContract()]
[System.Xml.Serialization.XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum Estado
{
    [System.ComponentModel.Description("Acre")] // , False)>
    AC,
    [System.ComponentModel.Description("Alagoas")] // , False)>
    AL,
    [System.ComponentModel.Description("Amazonas")] // , False)>
    AM,
    [System.ComponentModel.Description("Amapá")] // , False)>
    AP,
    [System.ComponentModel.Description("Bahia")] // , False)>
    BA,
    [System.ComponentModel.Description("Ceará")] // , False)>
    CE,
    [System.ComponentModel.Description("Distrito Federal")] // , False)>
    DF,
    [System.ComponentModel.Description("Espírito Santo")] // , False)>
    ES,
    [System.ComponentModel.Description("Goiás")] // , False)>
    GO,
    [System.ComponentModel.Description("Maranhão")] // , False)>
    MA,
    [System.ComponentModel.Description("Minas Gerais")] // , False)>
    MG,
    [System.ComponentModel.Description("Mato Grosso do Sul")] // , False)>
    MS,
    [System.ComponentModel.Description("Mato Grosso")] // , False)>
    MT,
    [System.ComponentModel.Description("Pará")] // , False)>
    PA,
    [System.ComponentModel.Description("Paraíba")] // , False)>
    PB,
    [System.ComponentModel.Description("Pernambuco")] // , False)>
    PE,
    [System.ComponentModel.Description("Piauí")] // , False)>
    PI,
    [System.ComponentModel.Description("Paraná")] // , False)>
    PR,
    [System.ComponentModel.Description("Rio de Janeiro")] // , False)>
    RJ,
    [System.ComponentModel.Description("Rio Grande do Norte")] // , False)>
    RN,
    [System.ComponentModel.Description("Rondônia")] // , False)>
    RO,
    [System.ComponentModel.Description("Roraima")] // , False)>
    RR,
    [System.ComponentModel.Description("Rio Grande do Sul")] // , False)>
    RS,
    [System.ComponentModel.Description("Santa Catarina")] // , False)>
    SC,
    [System.ComponentModel.Description("Sergipe")] // , False)>
    SE,
    [System.ComponentModel.Description("São Paulo")] // , False)>
    SP,
    [System.ComponentModel.Description("Tocantins")] // , False)>
    TO,
    [System.ComponentModel.Description("Enum_Estado_EX")]
    EX
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(TypeName = "TNFeInfNFeIdeIndPag", AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum FormaDePagamento
{
    [System.Xml.Serialization.XmlEnum("0")]
    [System.ComponentModel.Description("Enum_FormaDePagamento_AVista")]
    Vista = 0,
    [System.ComponentModel.Description("Enum_FormaDePagamento_APrazo")]
    [System.Xml.Serialization.XmlEnum("1")]
    Prazo = 1,
    [System.ComponentModel.Description("Enum_FormaDePagamento_Outros")]
    [System.Xml.Serialization.XmlEnum("2")]
    Outros = 2,
    [System.ComponentModel.Description("Sem Pagamento")]
    [System.Xml.Serialization.XmlEnum("9")]
    SemPagto = 9
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum ModeloDocumento
{
    [System.ComponentModel.Description("Enum_ModeloDocumento_55")]
    [System.Xml.Serialization.XmlEnum("55")]
    NFe = 55,
    [System.ComponentModel.Description("Enum_ModeloDocumento_65")]
    [System.Xml.Serialization.XmlEnum("65")]
    NFeAv = 65
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum TipoImpressao
{
    [System.Xml.Serialization.XmlEnum("0")]
    SemDanfe = 0,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnum("1")]
    Retrato = 1,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnum("2")]
    Paisagem = 2,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnum("3")]
    Simplificado = 3,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnum("4")]
    DanfeNFCe = 4,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnum("5")]
    DanfeNFCeMensagemEletronica = 5
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum FormaEmissao
{
    [System.ComponentModel.Description("Enum_FormaEmissao_Normal")]
    [System.Xml.Serialization.XmlEnum("1")]
    Normal = 1,
    [System.ComponentModel.Description("Enum_FormaEmissao_ContingenciaFS")]
    [System.Xml.Serialization.XmlEnum("2")]
    ContingenciaFS = 2,
    [System.ComponentModel.Description("Enum_FormaEmissao_ContingenciaSCAN")]
    [System.Xml.Serialization.XmlEnum("3")]
    ContingenciaSCAN = 3,
    [System.ComponentModel.Description("Enum_FormaEmissao_ContingenciaDPEC")]
    [System.Xml.Serialization.XmlEnum("4")]
    ContingenciaDPEC = 4,
    [System.ComponentModel.Description("Enum_FormaEmissao_ContingenciaFS_DA")]
    [System.Xml.Serialization.XmlEnum("5")]
    ContingenciaFS_DA = 5,
    [System.ComponentModel.Description("Enum_FormaEmissao_ContingenciaSVAN")]
    [System.Xml.Serialization.XmlEnum("6")]
    ContingenciaSVC_AN = 6,
    [System.ComponentModel.Description("Enum_FormaEmissao_ContingenciaSefaz_RS")]
    [System.Xml.Serialization.XmlEnum("7")]
    ContingenciaSVC_RS = 7,
    [System.ComponentModel.Description("Enum_FormaEmissao_ContingenciaOffLine_NFCe")]
    [System.Xml.Serialization.XmlEnum("9")]
    ContingenciaOffLine_NFCe = 9
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum FinalidadeEmissao
{
    [System.ComponentModel.Description("Enum_FinalidadeEmissao_Normal")]
    [System.Xml.Serialization.XmlEnum("1")]
    Normal = 1,
    [System.ComponentModel.Description("Enum_FinalidadeEmissao_Complementar")]
    [System.Xml.Serialization.XmlEnum("2")]
    Complementar = 2,
    [System.ComponentModel.Description("Enum_FinalidadeEmissao_Ajuste")]
    [System.Xml.Serialization.XmlEnum("3")]
    Ajuste = 3,
    [System.ComponentModel.Description("Enum_FinalidadeEmissao_Devolucao")]
    [System.Xml.Serialization.XmlEnum("4")]
    Devolucao = 4
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum ProcessoEmissao
{
    [System.ComponentModel.Description("Enum_ProcessoEmissao_AppContrib")]
    [System.Xml.Serialization.XmlEnum("0")]
    AplicativoContribuinte = 0,
    [System.ComponentModel.Description("Enum_ProcessoEmissao_AvulsaFisco")]
    [System.Xml.Serialization.XmlEnum("1")]
    Avulsa_Fisco = 1,
    [System.ComponentModel.Description("Enum_ProcessoEmissao_AvulsaContrib")]
    [System.Xml.Serialization.XmlEnum("2")]
    Avulsa_Contribuinte = 2,
    [System.ComponentModel.Description("Enum_ProcessoEmissao_AppFisco")]
    [System.Xml.Serialization.XmlEnum("3")]
    AplicativoFisco = 3
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum RegimeTributario
{
    [System.ComponentModel.Description("Enum_RegimeTributario_SN")]
    [System.Xml.Serialization.XmlEnum("1")]
    SimplesNacional = 1,
    [System.ComponentModel.Description("Enum_RegimeTributario_SNExcesso")]
    [System.Xml.Serialization.XmlEnum("2")]
    SimplesNacionalExcesso = 2,
    [System.ComponentModel.Description("Enum_RegimeTributario_Normal")]
    [System.Xml.Serialization.XmlEnum("3")]
    RegimeNormal = 3
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum IndicadorProcessoReferenciado
{

    /// <remarks/>
    [System.ComponentModel.Description("Enum_IndicadorProcessoReferenciado_SEFAZ")]
    [System.Xml.Serialization.XmlEnum("0")]
    SEFAZ = 0,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_IndicadorProcessoReferenciado_JustFederal")]
    [System.Xml.Serialization.XmlEnum("1")]
    JusticaFederal = 1,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_IndicadorProcessoReferenciado_JustEstadual")]
    [System.Xml.Serialization.XmlEnum("2")]
    JusticaEstadual = 2,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_IndicadorProcessoReferenciado_Secex_RFB")]
    [System.Xml.Serialization.XmlEnum("3")]
    SecexRFB = 3,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_IndicadorProcessoReferenciado_Outros")]
    [System.Xml.Serialization.XmlEnum("9")]
    Outros = 9
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe", IncludeInSchema = false)]
public enum TipoDocumentoReferencia
{
    [System.ComponentModel.Description("Conhecimento de Transporte Eletrônico")] // , False)>
    [System.Xml.Serialization.XmlEnum("refCTe")]
    CTe,
    [System.ComponentModel.Description("ECF - Cupom Fiscal")] // , False)>
    [System.Xml.Serialization.XmlEnum("refECF")]
    ECF,
    [System.ComponentModel.Description("Nota Fiscal")] // , False)>
    [System.Xml.Serialization.XmlEnum("refNF")]
    NF,
    [System.ComponentModel.Description("Nota Fiscal de Produtor Rural")] // , False)>
    [System.Xml.Serialization.XmlEnum("refNFP")]
    NFP,
    [System.ComponentModel.Description("Nota Fiscal Eletrônica")] // , False)>
    [System.Xml.Serialization.XmlEnum("refNFe")]
    NFe
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum ModeloECF
{
    [System.ComponentModel.Description("2B")] // , False)>
    [System.Xml.Serialization.XmlEnum("2B")]
    Modelo2B = 0,
    [System.ComponentModel.Description("2C")] // , False)>
    [System.Xml.Serialization.XmlEnum("2C")]
    Modelo2C = 1,
    [System.ComponentModel.Description("2D")] // , False)>
    [System.Xml.Serialization.XmlEnum("2D")]
    Modelo2D = 2
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum ModeloNF
{
    [System.ComponentModel.Description("Enum_ModeloDocumento_01")]
    [System.Xml.Serialization.XmlEnum("01")]
    Modelo_1 = 1
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum ModeloNFProdutor
{
    [System.ComponentModel.Description("Enum_ModeloDocumento_01")]
    [System.Xml.Serialization.XmlEnum("01")]
    Modelo_1 = 1,
    [System.ComponentModel.Description("Enum_ModeloDocumento_04")]
    [System.Xml.Serialization.XmlEnum("04")]
    Modelo_4 = 4
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe", IncludeInSchema = false)]
public enum FormaTransporte
{
    [System.ComponentModel.Description("Enum_FormaTransporte_Balsa")]
    balsa,
    [System.ComponentModel.Description("Enum_FormaTransporte_Reboque")]
    reboque,
    [System.ComponentModel.Description("Enum_FormaTransporte_Vagao")]
    vagao,
    [System.ComponentModel.Description("Enum_FormaTransporte_Veiculo")]
    veicTransp
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum ModalidadeFrete
{
    [System.ComponentModel.Description("Enum_ModalidadeFrete_Emitente")]
    [System.Xml.Serialization.XmlEnum("0")]
    Emitente = 0,
    [System.ComponentModel.Description("Enum_ModalidadeFrete_Destinatario")]
    [System.Xml.Serialization.XmlEnum("1")]
    Destinatario = 1,
    [System.ComponentModel.Description("Enum_ModalidadeFrete_Outros")]
    [System.Xml.Serialization.XmlEnum("2")]
    Outros = 2,
    [System.ComponentModel.Description("Enum_ModalidadeFrete_ProprioRemetente")]
    [System.Xml.Serialization.XmlEnum("3")]
    ProprioRemetente = 3,
    [System.ComponentModel.Description("Enum_ModalidadeFrete_ProprioDestinatario")]
    [System.Xml.Serialization.XmlEnum("4")]
    ProprioDestinatario = 4,
    [System.ComponentModel.Description("Enum_ModalidadeFrete_SemFrete")]
    [System.Xml.Serialization.XmlEnum("9")]
    SemFrete = 9
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum TipoAtendimento
{
    [System.ComponentModel.Description("Enum_TipoAtendimento_NaoSeAplica")]
    [System.Xml.Serialization.XmlEnum("0")]
    NaoSeAplica = 0,
    [System.ComponentModel.Description("Enum_TipoAtendimento_Presencial")]
    [System.Xml.Serialization.XmlEnum("1")]
    Presencial = 1,
    [System.ComponentModel.Description("Enum_TipoAtendimento_NaoPresencial_Internet")]
    [System.Xml.Serialization.XmlEnum("2")]
    NaoPresencial_Internet = 2,
    [System.ComponentModel.Description("Enum_TipoAtendimento_NaoPresencial_Tele")]
    [System.Xml.Serialization.XmlEnum("3")]
    NaoPresencial_Tele = 3,
    [System.ComponentModel.Description("Enum_TipoAtendimento_NFCeDomicilio")]
    [System.Xml.Serialization.XmlEnum("4")]
    NFCeEntregaDomicicio = 4,
    [System.ComponentModel.Description("Enum_TipoAtendimento_PresencialForaEstab")]
    [System.Xml.Serialization.XmlEnum("5")]
    Presencial_ForaEstabelecimento = 5,
    [System.ComponentModel.Description("Enum_TipoAtendimento_NaoPresencial_Outros")]
    [System.Xml.Serialization.XmlEnum("9")]
    NaoPresencial_Outros = 9
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum DestinoOperacao
{
    [System.ComponentModel.Description("Enum_DestinoOperacao_Interna")]
    [System.Xml.Serialization.XmlEnum("1")]
    Interna = 1,
    [System.ComponentModel.Description("Enum_DestinoOperacao_Interestadual")]
    [System.Xml.Serialization.XmlEnum("2")]
    Interestadual = 2,
    [System.ComponentModel.Description("Enum_DestinoOperacao_Exterior")]
    [System.Xml.Serialization.XmlEnum("3")]
    Exterior = 3
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum TipoViaTransporteDI
{
    [System.ComponentModel.Description("Marítima")]
    [System.Xml.Serialization.XmlEnum("1")]
    Maritima = 1,
    [System.ComponentModel.Description("Fluvial")]
    [System.Xml.Serialization.XmlEnum("2")]
    Fluvial = 2,
    [System.ComponentModel.Description("Lacustre")]
    [System.Xml.Serialization.XmlEnum("3")]
    Lacustre = 3,
    [System.ComponentModel.Description("Aérea")]
    [System.Xml.Serialization.XmlEnum("4")]
    Aerea = 4,
    [System.ComponentModel.Description("Postal")]
    [System.Xml.Serialization.XmlEnum("5")]
    Postal = 5,
    [System.ComponentModel.Description("Ferroviária")]
    [System.Xml.Serialization.XmlEnum("6")]
    Ferroviaria = 6,
    [System.ComponentModel.Description("Rodoviária")]
    [System.Xml.Serialization.XmlEnum("7")]
    Rodoviaria = 7,
    [System.ComponentModel.Description("Conduto")]
    [System.Xml.Serialization.XmlEnum("8")]
    Conduto = 8,
    [System.ComponentModel.Description("Meios Próprios")]
    [System.Xml.Serialization.XmlEnum("9")]
    MeiosProprios = 9,
    [System.ComponentModel.Description("Entrada / Saída Fictícia")]
    [System.Xml.Serialization.XmlEnum("10")]
    EntradaSaidaFicticia = 10,
    [System.ComponentModel.Description("Desconhecido")]
    [System.Xml.Serialization.XmlEnum("11")]
    NA11 = 11,
    [System.ComponentModel.Description("Desconhecido")]
    [System.Xml.Serialization.XmlEnum("12")]
    NA12 = 12
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum TipoIntermedioDI
{
    [System.ComponentModel.Description("Por Conta Própria")]
    [System.Xml.Serialization.XmlEnum("1")]
    ContaPropria = 1,
    [System.ComponentModel.Description("Por Conta e Ordem")]
    [System.Xml.Serialization.XmlEnum("2")]
    ContaOrdem = 2,
    [System.ComponentModel.Description("Encomendda")]
    [System.Xml.Serialization.XmlEnum("3")]
    Encomenda = 3
}

// ############
// ITEMS   '
// ############

/* TODO ERROR: Skipped RegionDirectiveTrivia */
[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum IndicadorTotal
{
    [System.ComponentModel.Description("Enum_IndicadorTotal_NaoCompoeTotal")]
    [System.Xml.Serialization.XmlEnum("0")]
    NaoCompoeTotal = 0,
    [System.ComponentModel.Description("Enum_IndicadorTotal_CompoeTotal")]
    [System.Xml.Serialization.XmlEnum("1")]
    CompoeTotal = 1
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(Namespace = "http: //www.portalfiscal.inf.br/nfe")]
public enum OrigemMercadoria
{

    /// <remarks/>
    [System.ComponentModel.Description("Enum_OrigemMercadoria_Nacional")]
    [System.Xml.Serialization.XmlEnum("0")]
    Nacional = 0,
    [System.ComponentModel.Description("Enum_OrigemMercadoria_EstrImpIndireta")]
    [System.Xml.Serialization.XmlEnum("1")]
    EstrangeiraImpdireta = 1,
    [System.ComponentModel.Description("Enum_OrigemMercadoria_EstrAdqMercIntEx7")]
    [System.Xml.Serialization.XmlEnum("2")]
    EstrangeiraAdqmercinterno = 2,
    [System.ComponentModel.Description("Enum_OrigemMercadoria_NacContImp40a70")]
    [System.Xml.Serialization.XmlEnum("3")]
    NAcionalConteudoImportSup40Inf70 = 3,
    [System.ComponentModel.Description("Enum_OrigemMercadoria_NacProdAjustes")]
    [System.Xml.Serialization.XmlEnum("4")]
    NaiconalProducaoAjustes = 4,
    [System.ComponentModel.Description("Enum_OrigemMercadoria_NacContImpAte40")]
    [System.Xml.Serialization.XmlEnum("5")]
    NacionalConteudoImportInf40 = 5,
    [System.ComponentModel.Description("Enum_OrigemMercadoria_EstrImpDiretaSemSimilar")]
    [System.Xml.Serialization.XmlEnum("6")]
    EstrangeiraImpDiretaSemSimilar = 6,
    [System.ComponentModel.Description("Enum_OrigemMercadoria_EstrAdqMercIntSemSimilar")]
    [System.Xml.Serialization.XmlEnum("7")]
    EstrangeiraAdqMercInternoSemSimilar = 7,
    [System.ComponentModel.Description("Enum_OrigemMercadoria_NacContImpSup70")]
    [System.Xml.Serialization.XmlEnum("8")]
    NacionalConteudoImpSup70 = 8
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum TipoArma
{

    /// <remarks/>
    [System.ComponentModel.Description("Enum_TipoArma_UsoPermitido")]
    [System.Xml.Serialization.XmlEnum("0")]
    UsoPermitido = 0,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_TipoArma_UsoRestrito")]
    [System.Xml.Serialization.XmlEnum("1")]
    UsoRestrito = 1,
    [System.ComponentModel.Description("Enum_NotAnOption")]
    [System.Xml.Serialization.XmlIgnore()]
    NA = 999
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum VeiculoTipoOperacao
{

    /// <remarks/>
    [System.ComponentModel.Description("Enum_VeiculoTipoOperacao_VendaConc")]
    [System.Xml.Serialization.XmlEnum("1")]
    VendaConcessionaria = 1,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_VeiculoTipoOperacao_FatConsFinal")]
    [System.Xml.Serialization.XmlEnum("2")]
    FatConsFinal = 2,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_VeiculoTipoOperacao_VendaDirGrandesCons")]
    [System.Xml.Serialization.XmlEnum("3")]
    GrandesConsumidores = 3,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_VeiculoTipoOperacao_Outros")]
    [System.Xml.Serialization.XmlEnum("0")]
    Outros = 0
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum VeiculoTipoCombustivel
{
    [System.ComponentModel.Description("Enum_VeiculoTipoCombustivel_Alcool")]
    [System.Xml.Serialization.XmlEnum("01")]
    Alcool = 1,
    [System.ComponentModel.Description("Enum_VeiculoTipoCombustivel_Alcool")]
    [System.Xml.Serialization.XmlEnum("1")]
    Alcool_v3 = 1,
    [System.ComponentModel.Description("Enum_VeiculoTipoCombustivel_Gasolina")]
    [System.Xml.Serialization.XmlEnum("02")]
    Gasolina = 2,
    [System.ComponentModel.Description("Enum_VeiculoTipoCombustivel_Gasolina")]
    [System.Xml.Serialization.XmlEnum("2")]
    Gasolina_v3 = 2,
    [System.ComponentModel.Description("Enum_VeiculoTipoCombustivel_Diesel")]
    [System.Xml.Serialization.XmlEnum("03")]
    Diesel = 3,
    [System.ComponentModel.Description("Enum_VeiculoTipoCombustivel_Diesel")]
    [System.Xml.Serialization.XmlEnum("3")]
    Diesel_v3 = 3,
    [System.ComponentModel.Description("Enum_VeiculoTipoCombustivel_Gasogenio")]
    [System.Xml.Serialization.XmlEnum("04")]
    Gasogenio = 4,
    [System.ComponentModel.Description("Enum_VeiculoTipoCombustivel_GasMetano")]
    [System.Xml.Serialization.XmlEnum("05")]
    GasMetano = 5,
    [System.ComponentModel.Description("Enum_VeiculoTipoCombustivel_ElfontIN")]
    [System.Xml.Serialization.XmlEnum("06")]
    ElfontIN = 6,
    [System.ComponentModel.Description("Enum_VeiculoTipoCombustivel_ElfontEX")]
    [System.Xml.Serialization.XmlEnum("07")]
    ElfontEX = 7,
    [System.ComponentModel.Description("Enum_VeiculoTipoCombustivel_GasolinaGNC")]
    [System.Xml.Serialization.XmlEnum("08")]
    Gasolina_GNV = 8,
    [System.ComponentModel.Description("Enum_VeiculoTipoCombustivel_AlcoolGNC")]
    [System.Xml.Serialization.XmlEnum("09")]
    Alcool_GNC = 9,
    [System.ComponentModel.Description("Enum_VeiculoTipoCombustivel_DieselGNC")]
    [System.Xml.Serialization.XmlEnum("10")]
    Diesel_GNC = 10,
    [System.ComponentModel.Description("Enum_VeiculoTipoCombustivel_AlcoolGasolina")]
    [System.Xml.Serialization.XmlEnum("12")]
    Alcool_Gasolina = 12,
    [System.ComponentModel.Description("Enum_VeiculoTipoCombustivel_AlcoolGasolinaGNV")]
    [System.Xml.Serialization.XmlEnum("13")]
    Alcool_Gasolina_GNV = 13,
    [System.ComponentModel.Description("Enum_VeiculoTipoCombustivel_AlcoolGasolina")]
    [System.Xml.Serialization.XmlEnum("16")]
    Alcool_Gasolina_v3 = 16,
    [System.ComponentModel.Description("Enum_VeiculoTipoCombustivel_AlcoolGasolinaGNV")]
    [System.Xml.Serialization.XmlEnum("17")]
    Alcool_Gasolina_GNV_v3 = 17,
    [System.ComponentModel.Description("Enum_VeiculoTipoCombustivel_GasolinaEletrico")]
    [System.Xml.Serialization.XmlEnum("18")]
    GasolinaEletrico = 18,
    [System.ComponentModel.Description("Enum_NotAnOption")]
    [System.Xml.Serialization.XmlIgnore()]
    NA = 999
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum VeiculoCondicaoChassi
{
    [System.ComponentModel.Description("Enum_VeiculoCondicaoChassi_Remarcado")]
    [System.Xml.Serialization.XmlEnum("R")]
    R,
    [System.ComponentModel.Description("Enum_VeiculoCondicaoChassi_Normal")]
    [System.Xml.Serialization.XmlEnum("N")]
    N
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum VeiculoCondicao
{

    /// <remarks/>
    [System.ComponentModel.Description("Enum_VeiculoCondicao_Acabado")]
    [System.Xml.Serialization.XmlEnum("1")]
    Acabad0 = 1,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_VeiculoCondicao_Inacabado")]
    [System.Xml.Serialization.XmlEnum("2")]
    Inacabado = 2,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_VeiculoCondicao_SemiAcabado")]
    [System.Xml.Serialization.XmlEnum("3")]
    SemiAcabado = 3
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum VeiculoRestricao
{

    /// <remarks/>
    [System.ComponentModel.Description("Enum_VeiculoRestricao_None")]
    [System.Xml.Serialization.XmlEnum("0")]
    NaoHa = 0,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_VeiculoRestricao_AlienacaoFiduciaria")]
    [System.Xml.Serialization.XmlEnum("1")]
    AlienacaoFiduciaria = 1,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_VeiculoRestricao_ArrendMercantil")]
    [System.Xml.Serialization.XmlEnum("2")]
    ArrendamentoMercantil = 2,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_VeiculoRestricao_ReservaDominio")]
    [System.Xml.Serialization.XmlEnum("3")]
    ReservaDominio = 3,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_VeiculoRestricao_Penhor")]
    [System.Xml.Serialization.XmlEnum("4")]
    PenhorVeiculos = 4,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_VeiculoRestricao_Outras")]
    [System.Xml.Serialization.XmlEnum("9")]
    Outras = 9
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum VeiculoTipo
{
    [System.ComponentModel.Description("Enum_VeiculoTipo_Bicicleta")]
    [System.Xml.Serialization.XmlEnum("1")]
    Bicicleta = 1,
    [System.ComponentModel.Description("Enum_VeiculoTipo_Bicicleta")]
    [System.Xml.Serialization.XmlEnum("01")]
    Bicicleta_v3 = 1,
    [System.ComponentModel.Description("Enum_VeiculoTipo_Ciclomoto")]
    [System.Xml.Serialization.XmlEnum("2")]
    Ciclomoto = 2,
    [System.ComponentModel.Description("Enum_VeiculoTipo_Motoneta")]
    [System.Xml.Serialization.XmlEnum("3")]
    Motoneta = 3,
    [System.ComponentModel.Description("Enum_VeiculoTipo_Motociclo")]
    [System.Xml.Serialization.XmlEnum("4")]
    Motociclo = 4,
    [System.ComponentModel.Description("Enum_VeiculoTipo_Motociclo")]
    [System.Xml.Serialization.XmlEnum("04")]
    Motociclo_v3 = 4,
    [System.ComponentModel.Description("Enum_VeiculoTipo_Triciclo")]
    [System.Xml.Serialization.XmlEnum("5")]
    Triciclo = 5,
    [System.ComponentModel.Description("Enum_VeiculoTipo_Automovel")]
    [System.Xml.Serialization.XmlEnum("6")]
    Automovel = 6,
    [System.ComponentModel.Description("Enum_VeiculoTipo_Automovel")]
    [System.Xml.Serialization.XmlEnum("06")]
    Automovel_v3 = 6,
    [System.ComponentModel.Description("Enum_VeiculoTipo_Microonibus")]
    [System.Xml.Serialization.XmlEnum("7")]
    Microonibus = 7,
    [System.ComponentModel.Description("Enum_VeiculoTipo_Microonibus")]
    [System.Xml.Serialization.XmlEnum("07")]
    Microonibus_v3 = 7,
    [System.ComponentModel.Description("Enum_VeiculoTipo_Onibus")]
    [System.Xml.Serialization.XmlEnum("8")]
    Onibus = 8,
    [System.ComponentModel.Description("Enum_VeiculoTipo_Bonde")]
    [System.Xml.Serialization.XmlEnum("9")]
    Bonde = 9,
    [System.ComponentModel.Description("Enum_VeiculoTipo_Reboque")]
    [System.Xml.Serialization.XmlEnum("10")]
    Reboque = 10,
    [System.ComponentModel.Description("Enum_VeiculoTipo_SemiReboque")]
    [System.Xml.Serialization.XmlEnum("11")]
    SemiReboque = 11,
    [System.ComponentModel.Description("Enum_VeiculoTipo_Charrete")]
    [System.Xml.Serialization.XmlEnum("12")]
    Charrete = 12,
    [System.ComponentModel.Description("Enum_VeiculoTipo_Caminhoneta")]
    [System.Xml.Serialization.XmlEnum("13")]
    Caminhoneta = 13,
    [System.ComponentModel.Description("Enum_VeiculoTipo_Caminhao")]
    [System.Xml.Serialization.XmlEnum("14")]
    Caminhao = 14,
    [System.ComponentModel.Description("Enum_VeiculoTipo_Carroca")]
    [System.Xml.Serialization.XmlEnum("15")]
    Carroça = 15,
    [System.ComponentModel.Description("Enum_VeiculoTipo_CarroDeMao")]
    [System.Xml.Serialization.XmlEnum("16")]
    CarrodeMao = 16,
    [System.ComponentModel.Description("Enum_VeiculoTipo_CTrator")]
    [System.Xml.Serialization.XmlEnum("17")]
    CTrator = 17,
    [System.ComponentModel.Description("Enum_VeiculoTipo_TratorRodas")]
    [System.Xml.Serialization.XmlEnum("18")]
    TratordeRodas = 18,
    [System.ComponentModel.Description("Enum_VeiculoTipo_TratorMisto")]
    [System.Xml.Serialization.XmlEnum("19")]
    TratorMisto = 19,
    [System.ComponentModel.Description("Enum_VeiculoTipo_TratorEsteira")]
    [System.Xml.Serialization.XmlEnum("20")]
    TratordeEsteiras = 20,
    [System.ComponentModel.Description("Enum_VeiculoTipo_Quadriciclo")]
    [System.Xml.Serialization.XmlEnum("21")]
    Quadriciclo = 21,
    [System.ComponentModel.Description("Enum_VeiculoTipo_EspOnibus")]
    [System.Xml.Serialization.XmlEnum("22")]
    EspOnibus = 22,
    [System.ComponentModel.Description("Enum_VeiculoTipo_MistoCAM")]
    [System.Xml.Serialization.XmlEnum("23")]
    MistoCAM = 23,
    [System.ComponentModel.Description("Enum_VeiculoTipo_CargaCAM")]
    [System.Xml.Serialization.XmlEnum("24")]
    CargaCAM = 24,
    [System.ComponentModel.Description("Enum_VeiculoTipo_Utilitario")]
    [System.Xml.Serialization.XmlEnum("25")]
    Utilitario = 25,
    [System.ComponentModel.Description("Enum_VeiculoTipo_MotorCasa")]
    [System.Xml.Serialization.XmlEnum("26")]
    MotorCasa = 26,
    [System.ComponentModel.Description("Enum_NotAnOption")]
    [System.Xml.Serialization.XmlIgnore()]
    NA = 999
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum VeiculoEspecie
{
    [System.ComponentModel.Description("Enum_VeciculoEspecie_Desconhecido")]
    [System.Xml.Serialization.XmlEnum("0")]
    Desconhecido = 0,
    [System.ComponentModel.Description("Enum_VeciculoEspecie_Passageiro")]
    [System.Xml.Serialization.XmlEnum("1")]
    Passageiro = 1,
    [System.ComponentModel.Description("Enum_VeciculoEspecie_Carga")]
    [System.Xml.Serialization.XmlEnum("2")]
    Carga = 2,
    [System.ComponentModel.Description("Enum_VeciculoEspecie_Misto")]
    [System.Xml.Serialization.XmlEnum("3")]
    Misto = 3,
    [System.ComponentModel.Description("Enum_VeciculoEspecie_Corrida")]
    [System.Xml.Serialization.XmlEnum("4")]
    Corrida = 4,
    [System.ComponentModel.Description("Enum_VeciculoEspecie_Tracao")]
    [System.Xml.Serialization.XmlEnum("5")]
    Tracao = 5,
    [System.ComponentModel.Description("Enum_VeciculoEspecie_Especial")]
    [System.Xml.Serialization.XmlEnum("6")]
    Especial = 6,
    [System.ComponentModel.Description("Enum_NotAnOption")]
    [System.Xml.Serialization.XmlIgnore()]
    NA = 999
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum VeiculoCorDENATRAN
{
    [System.ComponentModel.Description("Enum_VeiculoCorDenatran_Amarelo")]
    [System.Xml.Serialization.XmlEnum("1")]
    Amarelo = 1,
    [System.ComponentModel.Description("Enum_VeiculoCorDenatran_Amarelo")]
    [System.Xml.Serialization.XmlEnum("01")]
    Amarelo_V4 = 1,
    [System.ComponentModel.Description("Enum_VeiculoCorDenatran_Azul")]
    [System.Xml.Serialization.XmlEnum("2")]
    Azul = 2,
    [System.ComponentModel.Description("Enum_VeiculoCorDenatran_Azul")]
    [System.Xml.Serialization.XmlEnum("02")]
    Azul_V4 = 2,
    [System.ComponentModel.Description("Enum_VeiculoCorDenatran_Bege")]
    [System.Xml.Serialization.XmlEnum("3")]
    Bege = 3,
    [System.ComponentModel.Description("Enum_VeiculoCorDenatran_Bege")]
    [System.Xml.Serialization.XmlEnum("03")]
    Bege_V4 = 3,
    [System.ComponentModel.Description("Enum_VeiculoCorDenatran_Branca")]
    [System.Xml.Serialization.XmlEnum("4")]
    Branca = 4,
    [System.ComponentModel.Description("Enum_VeiculoCorDenatran_Branca")]
    [System.Xml.Serialization.XmlEnum("04")]
    Branca_v3 = 4,
    [System.ComponentModel.Description("Enum_VeiculoCorDenatran_Cinza")]
    [System.Xml.Serialization.XmlEnum("5")]
    Cinza = 5,
    [System.ComponentModel.Description("Enum_VeiculoCorDenatran_Cinza")]
    [System.Xml.Serialization.XmlEnum("05")]
    Cinza_V4 = 5,
    [System.ComponentModel.Description("Enum_VeiculoCorDenatran_Dourada")]
    [System.Xml.Serialization.XmlEnum("6")]
    Dourada = 6,
    [System.ComponentModel.Description("Enum_VeiculoCorDenatran_Dourada")]
    [System.Xml.Serialization.XmlEnum("06")]
    Dourada_V4 = 6,
    [System.ComponentModel.Description("Enum_VeiculoCorDenatran_Grena")]
    [System.Xml.Serialization.XmlEnum("7")]
    Grena = 7,
    [System.ComponentModel.Description("Enum_VeiculoCorDenatran_Grena")]
    [System.Xml.Serialization.XmlEnum("07")]
    Grena_V4 = 7,
    [System.ComponentModel.Description("Enum_VeiculoCorDenatran_Laranja")]
    [System.Xml.Serialization.XmlEnum("8")]
    Laranja = 8,
    [System.ComponentModel.Description("Enum_VeiculoCorDenatran_Laranja")]
    [System.Xml.Serialization.XmlEnum("08")]
    Laranja_V4 = 8,
    [System.ComponentModel.Description("Enum_VeiculoCorDenatran_Marrom")]
    [System.Xml.Serialization.XmlEnum("9")]
    Marrom = 9,
    [System.ComponentModel.Description("Enum_VeiculoCorDenatran_Marrom")]
    [System.Xml.Serialization.XmlEnum("09")]
    Marrom_V4 = 9,
    [System.ComponentModel.Description("Enum_VeiculoCorDenatran_Prata")]
    [System.Xml.Serialization.XmlEnum("10")]
    Prata = 10,
    [System.ComponentModel.Description("Enum_VeiculoCorDenatran_Preta")]
    [System.Xml.Serialization.XmlEnum("11")]
    Preta = 11,
    [System.ComponentModel.Description("Enum_VeiculoCorDenatran_Rosa")]
    [System.Xml.Serialization.XmlEnum("12")]
    Rosa = 12,
    [System.ComponentModel.Description("Enum_VeiculoCorDenatran_Roxa")]
    [System.Xml.Serialization.XmlEnum("13")]
    Roxa = 13,
    [System.ComponentModel.Description("Enum_VeiculoCorDenatran_Verde")]
    [System.Xml.Serialization.XmlEnum("14")]
    Verde = 14,
    [System.ComponentModel.Description("Enum_VeiculoCorDenatran_Vermelha")]
    [System.Xml.Serialization.XmlEnum("15")]
    Vermelha = 15,
    [System.ComponentModel.Description("Enum_VeiculoCorDenatran_Fantasia")]
    [System.Xml.Serialization.XmlEnum("16")]
    Fantasia = 16
}

/* TODO ERROR: Skipped RegionDirectiveTrivia */
[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum CST_ICMS
{
    [System.Xml.Serialization.XmlEnum("00")]
    [System.ComponentModel.Description("00")]
    CST_00 = 0,
    [System.Xml.Serialization.XmlEnum("02")]
    [System.ComponentModel.Description("02")]
    CST_02 = 2,
    [System.ComponentModel.Description("10")]
    [System.Xml.Serialization.XmlEnum("10")]
    CST_10 = 10,
    [System.ComponentModel.Description("15")]
    [System.Xml.Serialization.XmlEnum("15")]
    CST_15 = 15,
    [System.ComponentModel.Description("20")]
    [System.Xml.Serialization.XmlEnum("20")]
    CST_20 = 20,
    [System.ComponentModel.Description("30")]
    [System.Xml.Serialization.XmlEnum("30")]
    CST_30 = 30,
    [System.ComponentModel.Description("40")]
    [System.Xml.Serialization.XmlEnum("40")]
    CST_40 = 40,
    [System.ComponentModel.Description("41")]
    [System.Xml.Serialization.XmlEnum("41")]
    CST_41 = 41,
    [System.ComponentModel.Description("50")]
    [System.Xml.Serialization.XmlEnum("50")]
    CST_50 = 50,
    [System.ComponentModel.Description("51")]
    [System.Xml.Serialization.XmlEnum("51")]
    CST_51 = 51,
    [System.ComponentModel.Description("53")]
    [System.Xml.Serialization.XmlEnum("53")]
    CST_53 = 53,
    [System.ComponentModel.Description("60")]
    [System.Xml.Serialization.XmlEnum("60")]
    CST_60 = 60,
    [System.ComponentModel.Description("61")]
    [System.Xml.Serialization.XmlEnum("61")]
    CST_61 = 61,
    [System.ComponentModel.Description("70")]
    [System.Xml.Serialization.XmlEnum("70")]
    CST_70 = 70,
    [System.ComponentModel.Description("90")]
    [System.Xml.Serialization.XmlEnum("90")]
    CST_90 = 90,
    [System.ComponentModel.Description("999")]
    [System.Xml.Serialization.XmlEnum("999")]
    CST_NA = 999
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum CSOSN_ICMS
{
    [System.ComponentModel.Description("101")]
    [System.Xml.Serialization.XmlEnum("101")]
    CST101 = 101,
    [System.ComponentModel.Description("102")]
    [System.Xml.Serialization.XmlEnum("102")]
    CST102 = 102,
    [System.ComponentModel.Description("103")]
    [System.Xml.Serialization.XmlEnum("103")]
    CST103 = 103,
    [System.ComponentModel.Description("201")]
    [System.Xml.Serialization.XmlEnum("201")]
    CST201 = 201,
    [System.ComponentModel.Description("202")]
    [System.Xml.Serialization.XmlEnum("202")]
    CST202 = 202,
    [System.ComponentModel.Description("203")]
    [System.Xml.Serialization.XmlEnum("203")]
    CST203 = 203,
    [System.ComponentModel.Description("300")]
    [System.Xml.Serialization.XmlEnum("300")]
    CST300 = 300,
    [System.ComponentModel.Description("400")]
    [System.Xml.Serialization.XmlEnum("400")]
    CST400 = 400,
    [System.ComponentModel.Description("500")]
    [System.Xml.Serialization.XmlEnum("500")]
    CST500 = 500,
    [System.ComponentModel.Description("900")]
    [System.Xml.Serialization.XmlEnum("900")]
    CST900 = 900,
    [System.ComponentModel.Description("999")]
    [System.Xml.Serialization.XmlEnum("999")]
    CSTNA = 999
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(TypeName = "ItemChoiceTypeICMSTrib", Namespace = "http://www.portalfiscal.inf.br/nfe", IncludeInSchema = false)]
public enum Tributacao_ICMS_Identifier
{
    ICMS00,
    ICMS02,
    ICMS10,
    ICMS15,
    ICMS20,
    ICMS30,
    ICMS40,
    ICMS51,
    ICMS53,
    ICMS60,
    ICMS61,
    ICMS70,
    ICMS90,
    ICMSPart,
    ICMSSN101,
    ICMSSN102,
    ICMSSN201,
    ICMSSN202,
    ICMSSN500,
    ICMSSN900,
    ICMSST
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum DetalhamentoICMS_CST00_ModBC
{

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMS_ModBC_MVA")]
    [System.Xml.Serialization.XmlEnum("0")]
    MargeValorAgregado = 0,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMS_ModBC_PautaValor")]
    [System.Xml.Serialization.XmlEnum("1")]
    PautaValor = 1,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMS_ModBC_TabeladoMaxValor")]
    [System.Xml.Serialization.XmlEnum("2")]
    PrecoTabeladoMaxVal = 2,
    [System.ComponentModel.Description("Enum_ICMS_ModBC_Valor")]
    [System.Xml.Serialization.XmlEnum("3")]
    ValorOperacao = 3
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum DetalhamentoICMS_CST10_ModBC
{

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMS_ModBC_MVA")]
    [System.Xml.Serialization.XmlEnum("0")]
    MargeValorAgregado = 0,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMS_ModBC_PautaValor")]
    [System.Xml.Serialization.XmlEnum("1")]
    PautaValor = 1,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMS_ModBC_TabeladoMaxValor")]
    [System.Xml.Serialization.XmlEnum("2")]
    PrecoTabeladoMaxVal = 2,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMS_ModBC_Valor")]
    [System.Xml.Serialization.XmlEnum("3")]
    ValorOperacao = 3
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum DetalhamentoICMS_CST10_ModBCST
{

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_TabeladoMaxSugerido")]
    [System.Xml.Serialization.XmlEnum("0")]
    PrecoTabMaxSugerido = 0,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_ListaNegativaValor")]
    [System.Xml.Serialization.XmlEnum("1")]
    ListaNegativaVal = 1,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_ListaPositivaValor")]
    [System.Xml.Serialization.XmlEnum("2")]
    ListaPositivaVal = 2,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_ListaNeutraValor")]
    [System.Xml.Serialization.XmlEnum("3")]
    ListaNeutraVal = 3,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_MVA")]
    [System.Xml.Serialization.XmlEnum("4")]
    MVA = 4,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_PautaValor")]
    [System.Xml.Serialization.XmlEnum("5")]
    PautaVal = 5
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum DetalhamentoICMS_CST20_ModBC
{
    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMS_ModBC_MVA")]
    [System.Xml.Serialization.XmlEnum("0")]
    MargeValorAgregado = 0,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMS_ModBC_PautaValor")]
    [System.Xml.Serialization.XmlEnum("1")]
    PautaValor = 1,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMS_ModBC_TabeladoMaxValor")]
    [System.Xml.Serialization.XmlEnum("2")]
    PrecoTabeladoMaxVal = 2,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMS_ModBC_Valor")]
    [System.Xml.Serialization.XmlEnum("3")]
    ValorOperacao = 3
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum DetalhamentoICMS_CST30_ModBCST
{

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_TabeladoMaxSugerido")]
    [System.Xml.Serialization.XmlEnum("0")]
    PrecoTabMaxSugerido = 0,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_ListaNegativaValor")]
    [System.Xml.Serialization.XmlEnum("1")]
    ListaNegativaVal = 1,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_ListaPositivaValor")]
    [System.Xml.Serialization.XmlEnum("2")]
    ListaPositivaVal = 2,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_ListaNeutraValor")]
    [System.Xml.Serialization.XmlEnum("3")]
    ListaNeutraVal = 3,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_MVA")]
    [System.Xml.Serialization.XmlEnum("4")]
    MVA = 4,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_PautaValor")]
    [System.Xml.Serialization.XmlEnum("5")]
    PautaVal = 5
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum DetalhamentoICMS_CST40_MotivoDesoneracao
{

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMS_MotivoDesoneracao_Taxi")]
    [System.Xml.Serialization.XmlEnum("1")]
    Taxi = 1,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMS_MotivoDesoneracao_DefFisico")]
    [System.Xml.Serialization.XmlEnum("2")]
    DeficienteFisico = 2,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMS_MotivoDesoneracao_ProdAgrop")]
    [System.Xml.Serialization.XmlEnum("3")]
    ProdutorAgropecuario = 3,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMS_MotivoDesoneracao_FrotistaLocadora")]
    [System.Xml.Serialization.XmlEnum("4")]
    FrotistaLocadora = 4,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMS_MotivoDesoneracao_DiploConsular")]
    [System.Xml.Serialization.XmlEnum("5")]
    DiplomáticoConsular = 5,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMS_MotivoDesoneracao_AmazoniaALC")]
    [System.Xml.Serialization.XmlEnum("6")]
    UtilMotocAmOcidALC = 6,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMS_MotivoDesoneracao_Suframa")]
    [System.Xml.Serialization.XmlEnum("7")]
    SUFRAMA = 7,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMS_MotivoDesoneracao_VendaOrgPublico")]
    [System.Xml.Serialization.XmlEnum("8")]
    VendaOrgaosPublicos = 8,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMS_MotivoDesoneracao_Outros")]
    [System.Xml.Serialization.XmlEnum("9")]
    Outros = 9
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum DetalhamentoICMS_CST51_ModBC
{

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMS_ModBC_MVA")]
    [System.Xml.Serialization.XmlEnum("0")]
    MargeValorAgregado = 0,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMS_ModBC_PautaValor")]
    [System.Xml.Serialization.XmlEnum("1")]
    PautaValor = 1,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMS_ModBC_TabeladoMaxValor")]
    [System.Xml.Serialization.XmlEnum("2")]
    PrecoTabeladoMaxVal = 2,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMS_ModBC_Valor")]
    [System.Xml.Serialization.XmlEnum("3")]
    ValorOperacao = 3
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum DetalhamentoICMS_CST70_ModBC
{

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMS_ModBC_MVA")]
    [System.Xml.Serialization.XmlEnum("0")]
    MargeValorAgregado = 0,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMS_ModBC_PautaValor")]
    [System.Xml.Serialization.XmlEnum("1")]
    PautaValor = 1,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMS_ModBC_TabeladoMaxValor")]
    [System.Xml.Serialization.XmlEnum("2")]
    PrecoTabeladoMaxVal = 2,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMS_ModBC_Valor")]
    [System.Xml.Serialization.XmlEnum("3")]
    ValorOperacao = 3
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum DetalhamentoICMS_CST70_ModBCST
{

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_TabeladoMaxSugerido")]
    [System.Xml.Serialization.XmlEnum("0")]
    PrecoTabMaxSugerido = 0,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_ListaNegativaValor")]
    [System.Xml.Serialization.XmlEnum("1")]
    ListaNegativaVal = 1,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_ListaPositivaValor")]
    [System.Xml.Serialization.XmlEnum("2")]
    ListaPositivaVal = 2,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_ListaNeutraValor")]
    [System.Xml.Serialization.XmlEnum("3")]
    ListaNeutraVal = 3,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_MVA")]
    [System.Xml.Serialization.XmlEnum("4")]
    MVA = 4,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_PautaValor")]
    [System.Xml.Serialization.XmlEnum("5")]
    PautaVal = 5
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum DetalhamentoICMS_CST90_ModBC
{

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMS_ModBC_MVA")]
    [System.Xml.Serialization.XmlEnum("0")]
    MargeValorAgregado = 0,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMS_ModBC_PautaValor")]
    [System.Xml.Serialization.XmlEnum("1")]
    PautaValor = 1,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMS_ModBC_TabeladoMaxValor")]
    [System.Xml.Serialization.XmlEnum("2")]
    PrecoTabeladoMaxVal = 2,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMS_ModBC_Valor")]
    [System.Xml.Serialization.XmlEnum("3")]
    ValorOperacao = 3
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum DetalhamentoICMS_CST90_ModBCST
{

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_MVA")]
    [System.Xml.Serialization.XmlEnum("0")]
    PrecoTabMaxSugerido = 0,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_ListaNegativaValor")]
    [System.Xml.Serialization.XmlEnum("1")]
    ListaNegativaVal = 1,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_ListaPositivaValor")]
    [System.Xml.Serialization.XmlEnum("2")]
    ListaPositivaVal = 2,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_ListaNeutraValor")]
    [System.Xml.Serialization.XmlEnum("3")]
    ListaNeutraVal = 3,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_MVA")]
    [System.Xml.Serialization.XmlEnum("4")]
    MVA = 4,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_PautaValor")]
    [System.Xml.Serialization.XmlEnum("5")]
    PautaVal = 5
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum DetalhamentoICMSSN_CSOSN201_ModBCST
{

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_TabeladoMaxSugerido")]
    [System.Xml.Serialization.XmlEnum("0")]
    PrecoTabMaxSugerido = 0,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_ListaNegativaValor")]
    [System.Xml.Serialization.XmlEnum("1")]
    ListaNegativaVal = 1,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_ListaPositivaValor")]
    [System.Xml.Serialization.XmlEnum("2")]
    ListaPositivaVal = 2,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_ListaNeutraValor")]
    [System.Xml.Serialization.XmlEnum("3")]
    ListaNeutraVal = 3,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_MVA")]
    [System.Xml.Serialization.XmlEnum("4")]
    MVA = 4,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_PautaValor")]
    [System.Xml.Serialization.XmlEnum("5")]
    PautaVal = 5
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum DetalhamentoICMSSN_CSOSN202_ModBCST
{

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_TabeladoMaxSugerido")]
    [System.Xml.Serialization.XmlEnum("0")]
    PrecoTabMaxSugerido = 0,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_ListaNegativaValor")]
    [System.Xml.Serialization.XmlEnum("1")]
    ListaNegativaVal = 1,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_ListaPositivaValor")]
    [System.Xml.Serialization.XmlEnum("2")]
    ListaPositivaVal = 2,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_ListaNeutraValor")]
    [System.Xml.Serialization.XmlEnum("3")]
    ListaNeutraVal = 3,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_MVA")]
    [System.Xml.Serialization.XmlEnum("4")]
    MVA = 4,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_PautaValor")]
    [System.Xml.Serialization.XmlEnum("5")]
    PautaVal = 5
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum DetalhamentoICMSSN_CSOSN900_ModBC
{

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMS_ModBC_MVA")]
    [System.Xml.Serialization.XmlEnum("0")]
    MargeValorAgregado = 0,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMS_ModBC_PautaValor")]
    [System.Xml.Serialization.XmlEnum("1")]
    PautaValor = 1,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMS_ModBC_TabeladoMaxValor")]
    [System.Xml.Serialization.XmlEnum("2")]
    PrecoTabeladoMaxVal = 2,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMS_ModBC_Valor")]
    [System.Xml.Serialization.XmlEnum("3")]
    ValorOperacao = 3
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum DetalhamentoICMSSN_CSOSN900_ModBCST
{

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_TabeladoMaxSugerido")]
    [System.Xml.Serialization.XmlEnum("0")]
    PrecoTabMaxSugerido = 0,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_ListaNegativaValor")]
    [System.Xml.Serialization.XmlEnum("1")]
    ListaNegativaVal = 1,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_ListaPositivaValor")]
    [System.Xml.Serialization.XmlEnum("2")]
    ListaPositivaVal = 2,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_ListaNeutraValor")]
    [System.Xml.Serialization.XmlEnum("3")]
    ListaNeutraVal = 3,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_MVA")]
    [System.Xml.Serialization.XmlEnum("4")]
    MVA = 4,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_PautaValor")]
    [System.Xml.Serialization.XmlEnum("5")]
    PautaVal = 5
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum DetalhamentoICMS_Part_ModBC
{

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMS_ModBC_MVA")]
    [System.Xml.Serialization.XmlEnum("0")]
    MargeValorAgregado = 0,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMS_ModBC_PautaValor")]
    [System.Xml.Serialization.XmlEnum("1")]
    PautaValor = 1,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMS_ModBC_TabeladoMaxValor")]
    [System.Xml.Serialization.XmlEnum("2")]
    PrecoTabeladoMaxVal = 2,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMS_ModBC_Valor")]
    [System.Xml.Serialization.XmlEnum("3")]
    ValorOperacao = 3
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum DetalhamentoICMS_Part_ModBCST
{

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_TabeladoMaxSugerido")]
    [System.Xml.Serialization.XmlEnum("0")]
    PrecoTabMaxSugerido = 0,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_ListaNegativaValor")]
    [System.Xml.Serialization.XmlEnum("1")]
    ListaNegativaVal = 1,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_ListaPositivaValor")]
    [System.Xml.Serialization.XmlEnum("2")]
    ListaPositivaVal = 2,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_ListaNeutraValor")]
    [System.Xml.Serialization.XmlEnum("3")]
    ListaNeutraVal = 3,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_MVA")]
    [System.Xml.Serialization.XmlEnum("4")]
    MVA = 4,

    /// <remarks/>
    [System.ComponentModel.Description("Enum_ICMSST_ModBC_PautaValor")]
    [System.Xml.Serialization.XmlEnum("5")]
    PautaVal = 5
}

/* TODO ERROR: Skipped EndRegionDirectiveTrivia */
/* TODO ERROR: Skipped RegionDirectiveTrivia */
[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum CST_IPI
{
    [System.ComponentModel.Description("Enum_IPI_CST_EntrRecupCredito")]
    [System.Xml.Serialization.XmlEnum("00")]
    EntradaCredito = 0,
    [System.ComponentModel.Description("Enum_IPI_CST_EntrTribAliqZero")]
    [System.Xml.Serialization.XmlEnum("01")]
    EntAliqZero = 1,
    [System.ComponentModel.Description("Enum_IPI_CST_EntrIsenta")]
    [System.Xml.Serialization.XmlEnum("02")]
    EntIsenta = 2,
    [System.ComponentModel.Description("Enum_IPI_CST_EntrNaoTrib")]
    [System.Xml.Serialization.XmlEnum("03")]
    EntNTributada = 3,
    [System.ComponentModel.Description("Enum_IPI_CST_EntrImune")]
    [System.Xml.Serialization.XmlEnum("04")]
    EntImune = 4,
    [System.ComponentModel.Description("Enum_IPI_CST_EntrSuspensao")]
    [System.Xml.Serialization.XmlEnum("05")]
    EntSuspensao = 5,
    [System.ComponentModel.Description("Enum_IPI_CST_EntrOutras")]
    [System.Xml.Serialization.XmlEnum("49")]
    OutrasEntradas = 49,
    [System.ComponentModel.Description("Enum_IPI_CST_SaidaTrib")]
    [System.Xml.Serialization.XmlEnum("50")]
    SaidaTributada = 50,
    [System.ComponentModel.Description("Enum_IPI_CST_SaidaTribAliqZero")]
    [System.Xml.Serialization.XmlEnum("51")]
    SaiAliqZero = 51,
    [System.ComponentModel.Description("Enum_IPI_CST_SaidaIsenta")]
    [System.Xml.Serialization.XmlEnum("52")]
    SaiIsenta = 52,
    [System.ComponentModel.Description("Enum_IPI_CST_SaidaNaoTrib")]
    [System.Xml.Serialization.XmlEnum("53")]
    SaiNTributada = 53,
    [System.ComponentModel.Description("Enum_IPI_CST_SaidaImune")]
    [System.Xml.Serialization.XmlEnum("54")]
    SaiImune = 54,
    [System.ComponentModel.Description("Enum_IPI_CST_SaidaSuspensao")]
    [System.Xml.Serialization.XmlEnum("55")]
    SaiSuspensao = 55,
    [System.ComponentModel.Description("Enum_IPI_CST_SaidaOutras")]
    [System.Xml.Serialization.XmlEnum("99")]
    OutrasSaidas = 99
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(TypeName = "ItemChoiceTypeIPITrib", Namespace = "http://www.portalfiscal.inf.br/nfe", IncludeInSchema = false)]
public enum Tributacao_IPI_Identifier
{
    IPINT,
    IPITrib
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(TypeName = "ItemChoiceTypeIPISTTrib", Namespace = "http://www.portalfiscal.inf.br/nfe", IncludeInSchema = false)]
public enum Tributacao_IPI_ST_Identifier
{
    IPINT,
    IPITrib
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe", IncludeInSchema = false)]
public enum DetalhamentoIPI_Tributado_ModoCalculo
{

    /// <remarks/>
    pIPI,

    /// <remarks/>
    qUnid,

    /// <remarks/>
    vBC,

    /// <remarks/>
    vUnid
}

/* TODO ERROR: Skipped EndRegionDirectiveTrivia */
/* TODO ERROR: Skipped RegionDirectiveTrivia */
[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum CST_ISSQN
{

    /// <remarks/>
    N,

    /// <remarks/>
    R,

    /// <remarks/>
    S,

    /// <remarks/>
    I
}

/* TODO ERROR: Skipped EndRegionDirectiveTrivia */
/* TODO ERROR: Skipped RegionDirectiveTrivia */
[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum CST_PIS
{
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpTribAliqNormal")]
    [System.Xml.Serialization.XmlEnum("01")]
    AliquotaNormal = 1,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpTribAliqDif")]
    [System.Xml.Serialization.XmlEnum("02")]
    AliquotaDiferenciada = 2,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpTribAliqUnProd")]
    [System.Xml.Serialization.XmlEnum("03")]
    TributavelQuant = 3,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpTribMonoAliqZero")]
    [System.Xml.Serialization.XmlEnum("04")]
    TribMonofasica = 4,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpTribST")]
    [System.Xml.Serialization.XmlEnum("05")]
    SubstituicaoTributaria = 5,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpTribAliqZero")]
    [System.Xml.Serialization.XmlEnum("06")]
    AliqZero = 6,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpIsenta")]
    [System.Xml.Serialization.XmlEnum("07")]
    Isenta = 7,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpSemIncidencia")]
    [System.Xml.Serialization.XmlEnum("08")]
    SemIncidencia = 8,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpSuspensao")]
    [System.Xml.Serialization.XmlEnum("09")]
    Suspensao = 9,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_SaidasOutras")]
    [System.Xml.Serialization.XmlEnum("49")]
    OutrasOpSaidas = 49,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpCreditoMercInterno")]
    [System.Xml.Serialization.XmlEnum("50")]
    CreditoTribMercadoInterno = 50,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpCreditoNTMercInterno")]
    [System.Xml.Serialization.XmlEnum("51")]
    CreditoNaoTribMercadoInterno = 51,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpCreditoExp")]
    [System.Xml.Serialization.XmlEnum("52")]
    CreditoTribExportacao = 52,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpCreditoTribNTMercInterno")]
    [System.Xml.Serialization.XmlEnum("53")]
    CreditoTribNaoTribMercadoInterno = 53,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpCreditoMercIntExp")]
    [System.Xml.Serialization.XmlEnum("54")]
    CreditoTribMercadoInternoExportacao = 54,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpCreditoNTMercIntExp")]
    [System.Xml.Serialization.XmlEnum("55")]
    CreditoNaoTribMercadoInternoExportacao = 55,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpCreditoTribNTMercIntExp")]
    [System.Xml.Serialization.XmlEnum("56")]
    CreditoTribNaoTribMercadoInternoExportacao = 56,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_CreditoPresMercInterno")]
    [System.Xml.Serialization.XmlEnum("60")]
    CredPresumidoTribMercadoInterno = 60,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_CreditoPresNTMercInterno")]
    [System.Xml.Serialization.XmlEnum("61")]
    CredPresumidoNaoTribMercadoInterno = 61,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_CreditoPresExportacao")]
    [System.Xml.Serialization.XmlEnum("62")]
    CredPresumidoTribExportacao = 62,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_CreditoPresTribNTMercInt")]
    [System.Xml.Serialization.XmlEnum("63")]
    CredPresumidoTribNaoTribMercadoInterno = 63,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_CreditoPresTribMercIntExp")]
    [System.Xml.Serialization.XmlEnum("64")]
    CredPresumidoMercadoInternoExportacao = 64,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_CreditoPresNTTribMercIntExp")]
    [System.Xml.Serialization.XmlEnum("65")]
    CredPresumidoNaoTribMercadoInternoExportacao = 65,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_CreditoPresTribNTMercIntExp")]
    [System.Xml.Serialization.XmlEnum("66")]
    CredPresumidoTribNaoTribMercadoInternoExportacao = 66,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_CreditoPresOutras")]
    [System.Xml.Serialization.XmlEnum("67")]
    CredPresumidoOutrasOp = 67,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpAquisSemCredito")]
    [System.Xml.Serialization.XmlEnum("70")]
    AquisSemDireitoCredito = 70,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpAquisIsencao")]
    [System.Xml.Serialization.XmlEnum("71")]
    AquisIsencao = 71,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpAquisSuspensao")]
    [System.Xml.Serialization.XmlEnum("72")]
    AquisSuspensao = 72,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpAquisAliqZero")]
    [System.Xml.Serialization.XmlEnum("73")]
    AquisAliqZero = 73,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpAquisSemIncidencia")]
    [System.Xml.Serialization.XmlEnum("74")]
    AquisSemIncidencia = 74,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpAquisST")]
    [System.Xml.Serialization.XmlEnum("75")]
    AquisST = 75,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpAquisOutras")]
    [System.Xml.Serialization.XmlEnum("98")]
    OutrasOpEntradas = 98,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OutrasOperacoes")]
    [System.Xml.Serialization.XmlEnum("99")]
    OutrasOp = 99,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_NotValid")]
    [System.Xml.Serialization.XmlEnum("999")]
    NotValid = 999
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(TypeName = "ItemChoiceTypePIS", Namespace = "http://www.portalfiscal.inf.br/nfe", IncludeInSchema = false)]
public enum Tributacao_PIS_Identifier
{
    PISAliq,
    PISNT,
    PISOutr,
    PISQtde
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe", IncludeInSchema = false)]
public enum DetalhamentoPISST_ModoCalculo
{


    /// <remarks/>
    pPIS,

    /// <remarks/>
    qBCProd,

    /// <remarks/>
    vAliqProd,

    /// <remarks/>
    vBC
}

/* TODO ERROR: Skipped EndRegionDirectiveTrivia */
/* TODO ERROR: Skipped RegionDirectiveTrivia */
[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum CST_COFINS
{
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpTribAliqNormal")]
    [System.Xml.Serialization.XmlEnum("01")]
    AliquotaNormal = 1,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpTribAliqDif")]
    [System.Xml.Serialization.XmlEnum("02")]
    AliquotaDiferenciada = 2,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpTribAliqUnProd")]
    [System.Xml.Serialization.XmlEnum("03")]
    TributavelQuant = 3,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpTribMonoAliqZero")]
    [System.Xml.Serialization.XmlEnum("04")]
    TribMonofasica = 4,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpTribST")]
    [System.Xml.Serialization.XmlEnum("05")]
    SubstituicaoTributaria = 5,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpTribAliqZero")]
    [System.Xml.Serialization.XmlEnum("06")]
    AliqZero = 6,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpIsenta")]
    [System.Xml.Serialization.XmlEnum("07")]
    Isenta = 7,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpSemIncidencia")]
    [System.Xml.Serialization.XmlEnum("08")]
    SemIncidencia = 8,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpSuspensao")]
    [System.Xml.Serialization.XmlEnum("09")]
    Suspensao = 9,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_SaidasOutras")]
    [System.Xml.Serialization.XmlEnum("49")]
    OutrasOpSaidas = 49,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpCreditoMercInterno")]
    [System.Xml.Serialization.XmlEnum("50")]
    CreditoTribMercadoInterno = 50,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpCreditoNTMercInterno")]
    [System.Xml.Serialization.XmlEnum("51")]
    CreditoNaoTribMercadoInterno = 51,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpCreditoExp")]
    [System.Xml.Serialization.XmlEnum("52")]
    CreditoTribExportacao = 52,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpCreditoTribNTMercInterno")]
    [System.Xml.Serialization.XmlEnum("53")]
    CreditoTribNaoTribMercadoInterno = 53,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpCreditoMercIntExp")]
    [System.Xml.Serialization.XmlEnum("54")]
    CreditoTribMercadoInternoExportacao = 54,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpCreditoNTMercIntExp")]
    [System.Xml.Serialization.XmlEnum("55")]
    CreditoNaoTribMercadoInternoExportacao = 55,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpCreditoTribNTMercIntExp")]
    [System.Xml.Serialization.XmlEnum("56")]
    CreditoTribNaoTribMercadoInternoExportacao = 56,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_CreditoPresMercInterno")]
    [System.Xml.Serialization.XmlEnum("60")]
    CredPresumidoTribMercadoInterno = 60,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_CreditoPresNTMercInterno")]
    [System.Xml.Serialization.XmlEnum("61")]
    CredPresumidoNaoTribMercadoInterno = 61,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_CreditoPresExportacao")]
    [System.Xml.Serialization.XmlEnum("62")]
    CredPresumidoTribExportacao = 62,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_CreditoPresTribNTMercInt")]
    [System.Xml.Serialization.XmlEnum("63")]
    CredPresumidoTribNaoTribMercadoInterno = 63,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_CreditoPresTribMercIntExp")]
    [System.Xml.Serialization.XmlEnum("64")]
    CredPresumidoMercadoInternoExportacao = 64,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_CreditoPresNTTribMercIntExp")]
    [System.Xml.Serialization.XmlEnum("65")]
    CredPresumidoNaoTribMercadoInternoExportacao = 65,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_CreditoPresTribNTMercIntExp")]
    [System.Xml.Serialization.XmlEnum("66")]
    CredPresumidoTribNaoTribMercadoInternoExportacao = 66,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_CreditoPresOutras")]
    [System.Xml.Serialization.XmlEnum("67")]
    CredPresumidoOutrasOp = 67,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpAquisSemCredito")]
    [System.Xml.Serialization.XmlEnum("70")]
    AquisSemDireitoCredito = 70,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpAquisIsencao")]
    [System.Xml.Serialization.XmlEnum("71")]
    AquisIsencao = 71,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpAquisSuspensao")]
    [System.Xml.Serialization.XmlEnum("72")]
    AquisSuspensao = 72,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpAquisAliqZero")]
    [System.Xml.Serialization.XmlEnum("73")]
    AquisAliqZero = 73,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpAquisSemIncidencia")]
    [System.Xml.Serialization.XmlEnum("74")]
    AquisSemIncidencia = 74,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpAquisST")]
    [System.Xml.Serialization.XmlEnum("75")]
    AquisST = 75,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OpAquisOutras")]
    [System.Xml.Serialization.XmlEnum("98")]
    OutrasOpEntradas = 98,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_OutrasOperacoes")]
    [System.Xml.Serialization.XmlEnum("99")]
    OutrasOp = 99,
    [System.ComponentModel.Description("Enum_PISCOFINS_CST_NotValid")]
    [System.Xml.Serialization.XmlEnum("999")]
    NotValid = 999
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(TypeName = "ItemChoiceTypeCOFINS", Namespace = "http://www.portalfiscal.inf.br/nfe", IncludeInSchema = false)]
public enum Tributacao_COFINS_Identifier
{
    COFINSAliq,
    COFINSNT,
    COFINSOutr,
    COFINSQtde
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe", IncludeInSchema = false)]
public enum DetalhamentoCOFINSST_ModoCalculo
{


    /// <remarks/>
    pPIS,

    /// <remarks/>
    qBCProd,

    /// <remarks/>
    vAliqProd,

    /// <remarks/>
    vBC
}

/* TODO ERROR: Skipped EndRegionDirectiveTrivia */
/* TODO ERROR: Skipped EndRegionDirectiveTrivia */
// ################
// PAGAMENTO   '
// ################

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum FormaPagamento
{
    [System.ComponentModel.Description("Dinheiro")]
    [System.Xml.Serialization.XmlEnum("01")]
    Dinheiro = 1,
    [System.ComponentModel.Description("Cheque")]
    [System.Xml.Serialization.XmlEnum("02")]
    Cheque = 2,
    [System.ComponentModel.Description("Cartão de Crédito")]
    [System.Xml.Serialization.XmlEnum("03")]
    CartaoCredito = 3,
    [System.ComponentModel.Description("Cartão de Débito")]
    [System.Xml.Serialization.XmlEnum("04")]
    CartaoDebito = 4,
    [System.ComponentModel.Description("Crédito Loja")]
    [System.Xml.Serialization.XmlEnum("05")]
    CreditoLoja = 5,
    [System.ComponentModel.Description("Vale Alimentação")]
    [System.Xml.Serialization.XmlEnum("10")]
    ValeAlimentacao = 10,
    [System.ComponentModel.Description("Vale Refeição")]
    [System.Xml.Serialization.XmlEnum("11")]
    ValeRefeicao = 11,
    [System.ComponentModel.Description("Vale Presente")]
    [System.Xml.Serialization.XmlEnum("12")]
    ValePresente = 12,
    [System.ComponentModel.Description("Vale Combustível")]
    [System.Xml.Serialization.XmlEnum("13")]
    ValeCombustivel = 13,
    [System.ComponentModel.Description("Duplicata Mercantil")]
    [System.Xml.Serialization.XmlEnum("14")]
    DuplicataMercantil = 14,
    [System.ComponentModel.Description("Boleto Bancário")]
    [System.Xml.Serialization.XmlEnum("15")]
    BoletoBancario = 15,
    [System.ComponentModel.Description("Depósito Bancário")]
    [System.Xml.Serialization.XmlEnum("16")]
    DepositoBancario = 16,
    [System.ComponentModel.Description("Pagamento Instantâneo (PIX)")]
    [System.Xml.Serialization.XmlEnum("17")]
    PIX = 17,
    [System.ComponentModel.Description("Transferência bancária, Carteira Digital")]
    [System.Xml.Serialization.XmlEnum("18")]
    CarteiraDigital = 18,
    [System.ComponentModel.Description("Programa de fidelidade, Cashback, Crédito Virtual")]
    [System.Xml.Serialization.XmlEnum("19")]
    Fidelidade_Cashback_CredVirtual = 19,
    [System.ComponentModel.Description("Sem Pagamento")]
    [System.Xml.Serialization.XmlEnum("90")]
    SemPagto = 90,
    [System.ComponentModel.Description("Outros")]
    [System.Xml.Serialization.XmlEnum("99")]
    Outros = 99
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum TipoIntegracaoPgCartao
{
    [System.ComponentModel.Description("Integrado (TEF / e-Commerce)")]
    [System.Xml.Serialization.XmlEnum("1")]
    TEF_eCommerce = 1,
    [System.ComponentModel.Description("Não Integrado (POS)")]
    [System.Xml.Serialization.XmlEnum("2")]
    POS = 2
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum BandeiraCartaoCredito
{
    [System.ComponentModel.Description("Visa")]
    [System.Xml.Serialization.XmlEnum("01")]
    Visa = 1,
    [System.ComponentModel.Description("Mastercard")]
    [System.Xml.Serialization.XmlEnum("02")]
    Mastercard = 2,
    [System.ComponentModel.Description("American Express")]
    [System.Xml.Serialization.XmlEnum("03")]
    AmericanExpress = 3,
    [System.ComponentModel.Description("Sorocred")]
    [System.Xml.Serialization.XmlEnum("04")]
    Sorocred = 4,
    [System.ComponentModel.Description("Diners Club")]
    [System.Xml.Serialization.XmlEnum("05")]
    DinersClub = 5,
    [System.ComponentModel.Description("Elo")]
    [System.Xml.Serialization.XmlEnum("06")]
    Elo = 6,
    [System.ComponentModel.Description("Hipercard")]
    [System.Xml.Serialization.XmlEnum("07")]
    Hipercard = 7,
    [System.ComponentModel.Description("Aura")]
    [System.Xml.Serialization.XmlEnum("08")]
    Aura = 8,
    [System.ComponentModel.Description("Cabal")]
    [System.Xml.Serialization.XmlEnum("09")]
    Cabal = 9,
    [System.ComponentModel.Description("Outros")]
    [System.Xml.Serialization.XmlEnum("99")]
    Outros = 99
}

// #############
// OUTROS   '
// #############

/* TODO ERROR: Skipped RegionDirectiveTrivia */
[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(TypeName = "TEventoInfEventoDetEventoVersao", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum VersaoServicoEvento
{

    /// <summary>
    /// Versao 1.00
    /// </summary>
    /// <remarks></remarks>
    [System.ComponentModel.Description("1.00")] // , False)>
    [System.Xml.Serialization.XmlEnum("1.00")]
    Versao_1_00,
    [System.ComponentModel.Description("3.00")] // , False)>
    [System.Xml.Serialization.XmlEnum("3.00")]
    Versao_3_00
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(TypeName = "TEventoInfEventoTpEvento", AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum CodigoEvento
{
    [System.ComponentModel.Description("Carta de Correção")] // , False)>
    [System.Xml.Serialization.XmlEnum("110110")]
    Correcao = 110110,
    [System.ComponentModel.Description("Cancelamento")] // , False)>
    [System.Xml.Serialization.XmlEnum("110111")]
    Cancelamento = 110111,
    [System.ComponentModel.Description("Confirmação da Operação")] // , False)>
    [System.Xml.Serialization.XmlEnum("210200")]
    Confirmacao = 210200,
    [System.ComponentModel.Description("Ciência da Operação")] // , False)>
    [System.Xml.Serialization.XmlEnum("210210")]
    Ciencia = 210210,
    [System.ComponentModel.Description("Desconhecimento da Operação")] // , False)>
    [System.Xml.Serialization.XmlEnum("210220")]
    Desconhecimento = 210220,
    [System.ComponentModel.Description("Operação não Realizada")] // , False)>
    [System.Xml.Serialization.XmlEnum("210240")]
    NaoRealizada = 210240,
    [System.ComponentModel.Description("Registro Passagem NF-e")] // , False)>
    [System.Xml.Serialization.XmlEnum("610500")]
    PassagemNFe = 610500,
    [System.ComponentModel.Description("Registro Passagem NF-e Cancelado")] // , False)>
    [System.Xml.Serialization.XmlEnum("610501")]
    PassagemNFeCancelado = 610501,
    [System.ComponentModel.Description("Registro de Passagem de NFe propagado pelo MDFe")] // , False)>
    [System.Xml.Serialization.XmlEnum("610510")]
    PassagemNFePropgMDFe = 610510,
    [System.ComponentModel.Description("Registro de Passagem de NFe propagado pelo MDFe/CTe")] // , False)>
    [System.Xml.Serialization.XmlEnum("610514")]
    PassagemNFePropgMDFeCTe = 610514,
    [System.ComponentModel.Description("Registro Passagem NF-e RFID")] // , False)>
    [System.Xml.Serialization.XmlEnum("610550")]
    PassagemNFeRFID = 610550,
    [System.ComponentModel.Description("Registro de Passagem Automatico MDF-e")] // , False)>
    [System.Xml.Serialization.XmlEnum("610552")]
    PassagemAutoMDFe = 610552,
    [System.ComponentModel.Description("Registro de Passagem Automatico MDF-e com CT-e")] // , False)>
    [System.Xml.Serialization.XmlEnum("610554")]
    PassagemAutoMDFecomCTe = 610554,
    [System.ComponentModel.Description("CT-e Autorizado")] // , False)>
    [System.Xml.Serialization.XmlEnum("610600")]
    CTeAutorizado = 610600,
    [System.ComponentModel.Description("CT-e Cancelado")] // , False)>
    [System.Xml.Serialization.XmlEnum("610601")]
    CTeCancelado = 610601,
    [System.ComponentModel.Description("MDF-e Autorizado")] // , False)>
    [System.Xml.Serialization.XmlEnum("610610")]
    MDFeAutorizado = 610610,
    [System.ComponentModel.Description("MDF-e Cancelado")] // , False)>
    [System.Xml.Serialization.XmlEnum("610611")]
    MDFeCancelado = 610611,
    [System.ComponentModel.Description("MDF-e Autorizado com CT-e")] // , False)>
    [System.Xml.Serialization.XmlEnum("610614")]
    MDFeAutorizadoComCTe = 610614,
    [System.ComponentModel.Description("Cancelamento de MDF-e Autorizado com CT-e")] // , False)>
    [System.Xml.Serialization.XmlEnum("610615")]
    MDFeCanceladoComCTe = 610615,
    [System.ComponentModel.Description("Vistoria Suframa")] // , False)>
    [System.Xml.Serialization.XmlEnum("990900")]
    VistoriaSuframa = 990900,
    [System.ComponentModel.Description("Internalização Suframa")] // , False)>
    [System.Xml.Serialization.XmlEnum("990910")]
    IntarnalizacaoSuframa = 990910
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum VersaoServicoConsSitNFe
{
    [System.ComponentModel.Description("1.07")] // , False)>
    [System.Xml.Serialization.XmlEnum("1.07")]
    Versao_1_07,
    [System.ComponentModel.Description("1.10")] // , False)>
    [System.Xml.Serialization.XmlEnum("1.10")]
    Versao_1_10,
    [System.ComponentModel.Description("2.00")] // , False)>
    [System.Xml.Serialization.XmlEnum("2.00")]
    Versao_2_00,
    [System.ComponentModel.Description("2.01")] // , False)>
    [System.Xml.Serialization.XmlEnum("2.01")]
    Versao_2_01,
    [System.ComponentModel.Description("3.00")] // , False)>
    [System.Xml.Serialization.XmlEnum("3.00")]
    Versao_3_00,
    [System.ComponentModel.Description("3.10")] // , False)>
    [System.Xml.Serialization.XmlEnum("3.10")]
    Versao_3_10,
    [System.ComponentModel.Description("4.00")] // , False)>
    [System.Xml.Serialization.XmlEnum("4.00")]
    Versao_4_00,
    [System.ComponentModel.Description("5.00")] // , False)>
    [System.Xml.Serialization.XmlEnum("5.00")]
    Versao_5_00
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum VersaoCancelamento
{
    [System.ComponentModel.Description("3.10")] // , False)>
    [System.Xml.Serialization.XmlEnum("3.10")]
    Versao_3_10,
    [System.ComponentModel.Description("2.00")] // , False)>
    [System.Xml.Serialization.XmlEnum("2.00")]
    Versao_2_00,
    [System.ComponentModel.Description("1.07")] // , False)>
    [System.Xml.Serialization.XmlEnum("1.07")]
    Versao_1_07,
    [System.ComponentModel.Description("1.00")] // , False)>
    [System.Xml.Serialization.XmlEnum("1.00")]
    Versao_1_00
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(TypeName = "TVeConsNFeDest", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum VersaoServicoConsCadastro
{

    /// <summary>
    /// Versao 1.01
    /// </summary>
    /// <remarks></remarks>
    [System.ComponentModel.Description("2.00")] // , False)>
    [System.Xml.Serialization.XmlEnum("2.00")]
    Versao_2_00,
    [System.ComponentModel.Description("3.10")] // , False)>
    [System.Xml.Serialization.XmlEnum("3.10")]
    Versao_3_10,
    [System.ComponentModel.Description("4.00")] // , False)>
    [System.Xml.Serialization.XmlEnum("4.00")]
    Versao_4_00
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(TypeName = "TVeConsNFeDest", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum VersaoServicoConsDestinatario
{

    /// <summary>
    /// Versao 1.01
    /// </summary>
    /// <remarks></remarks>
    [System.ComponentModel.Description("1.01")]
    [System.Xml.Serialization.XmlEnum("1.01")]
    Versao_1_01
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(TypeName = "TRetConsNFeDestIndCont", AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum IndicadorContinuacao
{

    /// <remarks/>
    [System.Xml.Serialization.XmlEnum("0")]
    [System.ComponentModel.Description("Enum_ConsultaDestinatario_IndCont_Fim")]
    NaoPossuiMaisDocuments = 0,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnum("1")]
    [System.ComponentModel.Description("Enum_ConsultaDestinatario_IndCont_Desc")]
    Desconhecido = 1
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(TypeName = "TVerDownloadNFe", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum VersaoServicoDownload
{

    /// <summary>
    /// Versao 1.00
    /// </summary>
    /// <remarks></remarks>
    [System.ComponentModel.Description("1.00")]
    [System.Xml.Serialization.XmlEnum("1.00")]
    Versao_1_00,

    /// <summary>
    /// Versao 2.00
    /// </summary>
    /// <remarks></remarks>
    [System.ComponentModel.Description("2.00")]
    [System.Xml.Serialization.XmlEnum("2.00")]
    Versao_2_00,

    /// <summary>
    /// Versao 3.10
    /// </summary>
    /// <remarks></remarks>
    [System.ComponentModel.Description("3.10")]
    [System.Xml.Serialization.XmlEnum("3.10")]
    Versao_3_10
}

[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[System.Xml.Serialization.XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum VersaoServicoDistribuicaoDF
{

    /// <remarks/>
    [System.Xml.Serialization.XmlEnum("1.00")]
    Versao1_00,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnum("1.01")]
    Versao1_01
}
