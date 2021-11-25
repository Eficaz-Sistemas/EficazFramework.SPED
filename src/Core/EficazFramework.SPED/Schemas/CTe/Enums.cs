using System;

namespace EficazFramework.SPED.Schemas.CTe;

/* TODO ERROR: Skipped RegionDirectiveTrivia */
[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public enum FormatoImpressao
{
    [System.ComponentModel.Description("Enum_FormatoImpressao_Retrato")]
    [System.Xml.Serialization.XmlEnum("1")]
    Retrato = 1,
    [System.ComponentModel.Description("Enum_FormatoImpressao_Paisagem")]
    [System.Xml.Serialization.XmlEnum("2")]
    Paisagem = 2
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public enum FormaEmissao
{
    [System.ComponentModel.Description("Enum_CTe_FormaEmissao_Normal")]
    [System.Xml.Serialization.XmlEnum("1")]
    Normal = 1,
    [System.ComponentModel.Description("Enum_CTe_FormaEmissao_EPEC")]
    [System.Xml.Serialization.XmlEnum("4")]
    EPEC_SVC = 4,
    [System.ComponentModel.Description("Enum_CTe_FormaEmissao_FSDA")]
    [System.Xml.Serialization.XmlEnum("5")]
    Contingencia_FSDA = 5,
    [System.ComponentModel.Description("Enum_CTe_FormaEmissao_SVCRS")]
    [System.Xml.Serialization.XmlEnum("7")]
    Autorizacao_SVC_RS = 7,
    [System.ComponentModel.Description("Enum_CTe_FormaEmissao_SVCSP")]
    [System.Xml.Serialization.XmlEnum("8")]
    Autorizacao_SVC_SP = 8
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[System.Xml.Serialization.XmlType(Namespace = "http://www.portalfiscal.inf.br/cte")]
public enum TipoCTe
{
    [System.ComponentModel.Description("Enum_TipoCTe_Normal")]
    [System.Xml.Serialization.XmlEnum("0")]
    Normal = 0,
    [System.ComponentModel.Description("Enum_TipoCTe_Complemento")]
    [System.Xml.Serialization.XmlEnum("1")]
    Complemento = 1,
    [System.ComponentModel.Description("Enum_TipoCTe_Anulacao")]
    [System.Xml.Serialization.XmlEnum("2")]
    Anulacao = 2,
    [System.ComponentModel.Description("Enum_TipoCTe_Substituto")]
    [System.Xml.Serialization.XmlEnum("3")]
    Substituto = 3
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[System.Xml.Serialization.XmlType(Namespace = "http://www.portalfiscal.inf.br/cte")]
public enum Modelo
{
    [System.ComponentModel.Description("57")]// , False)>
    [System.Xml.Serialization.XmlEnum("57")]
    CTe = 57,
    [System.ComponentModel.Description("67")]// , False)>
    [System.Xml.Serialization.XmlEnum("67")]
    CTeOS = 67
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[System.Xml.Serialization.XmlType(Namespace = "http://www.portalfiscal.inf.br/cte")]
public enum ProcessoEmissao
{
    [System.ComponentModel.Description("Enum_EmissorCTe_AppContrib")]
    [System.Xml.Serialization.XmlEnum("0")]
    AppContribuinte = 0,
    [System.ComponentModel.Description("Enum_EmissorCTe_Avulso")]
    [System.Xml.Serialization.XmlEnum("1")]
    Avulso_Fisco = 1,
    [System.ComponentModel.Description("Enum_EmissorCTe_AvulsoCertContrb")]
    [System.Xml.Serialization.XmlEnum("2")]
    Avulso_SiteFisco = 2,
    [System.ComponentModel.Description("Enum_EmissorCTe_AppFisco")]
    [System.Xml.Serialization.XmlEnum("3")]
    AppFornecidoFisco = 3
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public enum FormaPagamento
{
    [System.ComponentModel.Description("Enum_CTe_FormaPagto_Pago")]
    [System.Xml.Serialization.XmlEnum("0")]
    Pago = 0,
    [System.ComponentModel.Description("Enum_CTe_FormaPagto_APagar")]
    [System.Xml.Serialization.XmlEnum("1")]
    APagar = 1,
    [System.ComponentModel.Description("Enum_CTe_FormaPagto_Outros")]
    [System.Xml.Serialization.XmlEnum("2")]
    Outros = 2
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[System.Xml.Serialization.XmlType(Namespace = "http://www.portalfiscal.inf.br/cte")]
public enum ModalidadeTransporte
{
    [System.ComponentModel.Description("Enum_CTe_Modalidade_Rodoviario")]
    [System.Xml.Serialization.XmlEnum("01")]
    Rodoviario = 1,
    [System.ComponentModel.Description("Enum_CTe_Modalidade_Aereo")]
    [System.Xml.Serialization.XmlEnum("02")]
    Aereo = 2,
    [System.ComponentModel.Description("Enum_CTe_Modalidade_Aquaviario")]
    [System.Xml.Serialization.XmlEnum("03")]
    Aquaviario = 3,
    [System.ComponentModel.Description("Enum_CTe_Modalidade_Ferroviario")]
    [System.Xml.Serialization.XmlEnum("04")]
    Ferroviario = 4,
    [System.ComponentModel.Description("Enum_CTe_Modalidade_Dutoviario")]
    [System.Xml.Serialization.XmlEnum("05")]
    Dutoviario = 5,
    [System.ComponentModel.Description("Enum_CTe_Modalidade_MultiModal")]
    [System.Xml.Serialization.XmlEnum("06")]
    Multimodal = 6
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public enum TiposServico
{
    [System.ComponentModel.Description("Enum_CTe_TipoServico_Normal")]
    [System.Xml.Serialization.XmlEnum("0")]
    Normal = 0,
    [System.ComponentModel.Description("Enum_CTe_TipoServico_SubContratacao")]
    [System.Xml.Serialization.XmlEnum("1")]
    SubContratacao = 1,
    [System.ComponentModel.Description("Enum_CTe_TipoServico_Redespacho")]
    [System.Xml.Serialization.XmlEnum("2")]
    ReDespacho = 2,
    [System.ComponentModel.Description("Enum_CTe_TipoServico_RedespachoInt")]
    [System.Xml.Serialization.XmlEnum("3")]
    Redespacho_Intermediario = 3,
    [System.ComponentModel.Description("Enum_CTe_TipoServico_ServVincMultiModal")]
    [System.Xml.Serialization.XmlEnum("4")]
    Servico_Vinculado_MultiModal = 4,
    [System.ComponentModel.Description("Enum_CTe_TipoServico_CTeOS")]
    [System.Xml.Serialization.XmlEnum("6")]
    ServicoCTeOS = 6
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public enum Retira
{

    /// <remarks/>
    [System.Xml.Serialization.XmlEnum("0")]
    Sim = 0,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnum("1")]
    Nao = 1
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public enum TipoTomador
{
    [System.ComponentModel.Description("Enum_CTe_TipoTomador_Remetente")]
    [System.Xml.Serialization.XmlEnum("0")]
    Remetente = 0,
    [System.ComponentModel.Description("Enum_CTe_TipoTomador_Expedidor")]
    [System.Xml.Serialization.XmlEnum("1")]
    Expedidor = 1,
    [System.ComponentModel.Description("Enum_CTe_TipoTomador_Recebedor")]
    [System.Xml.Serialization.XmlEnum("2")]
    Recebedor = 2,
    [System.ComponentModel.Description("Enum_CTe_TipoTomador_Destinatario")]
    [System.Xml.Serialization.XmlEnum("3")]
    Destinatario = 3,
    [System.ComponentModel.Description("Enum_CTe_TipoTomador_Outros")]
    [System.Xml.Serialization.XmlEnum("4")]
    Outros = 4
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public enum ResponsavelSeguro
{
    [System.ComponentModel.Description("Enum_CTe_ResponsavelSeguro_Remetente")]
    [System.Xml.Serialization.XmlEnum("0")]
    Remetente = 0,
    [System.ComponentModel.Description("Enum_CTe_ResponsavelSeguro_Expedidor")]
    [System.Xml.Serialization.XmlEnum("1")]
    Expedidor = 1,
    [System.ComponentModel.Description("Enum_CTe_ResponsavelSeguro_Recebedor")]
    [System.Xml.Serialization.XmlEnum("2")]
    Recebedor = 2,
    [System.ComponentModel.Description("Enum_CTe_ResponsavelSeguro_Destinatário")]
    [System.Xml.Serialization.XmlEnum("3")]
    Destinatario = 3,
    [System.ComponentModel.Description("Enum_CTe_ResponsavelSeguro_EmitenteCTe")]
    [System.Xml.Serialization.XmlEnum("4")]
    Emitente = 4,
    [System.ComponentModel.Description("Enum_CTe_ResponsavelSeguro_Tomador")]
    [System.Xml.Serialization.XmlEnum("5")]
    Tomador = 5
}

/* TODO ERROR: Skipped RegionDirectiveTrivia */
[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public enum Tributacao_ICMS_Identifier
{
    ICMS00,
    ICMS20,
    ICMS45,
    ICMS60,
    ICMS90,
    ICMSOutraUF,
    ICMSSN,
    CST00,
    CST20,
    CST45,
    CST60,
    CST90
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public enum DetalhamentoICMSIndicadorSN
{

    /// <remarks/>
    [System.Xml.Serialization.XmlEnum("1")]
    Item1
}

/* TODO ERROR: Skipped EndRegionDirectiveTrivia */
/* TODO ERROR: Skipped RegionDirectiveTrivia */
[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.33440")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public enum rodoVeicTpProp
{
    [System.Xml.Serialization.XmlEnum("P")]
    [System.ComponentModel.Description("Enum_CTeRodov_VeicTpProp_Proprio")]
    Proprio = 0,
    [System.Xml.Serialization.XmlEnum("T")]
    [System.ComponentModel.Description("Enum_CTeRodov_VeicTpProp_Terceiro")]
    Terceiro = 1
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.33440")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public enum rodoLota
{
    [System.ComponentModel.Description("Enum_CTeRodov_Lotacao_Nao")]
    [System.Xml.Serialization.XmlEnum("0")]
    Nao = 0,
    [System.ComponentModel.Description("Enum_CTeRodov_Lotacao_Sim")]
    [System.Xml.Serialization.XmlEnum("1")]
    Sim = 1
}

/* TODO ERROR: Skipped EndRegionDirectiveTrivia */
/* TODO ERROR: Skipped EndRegionDirectiveTrivia */
/* TODO ERROR: Skipped RegionDirectiveTrivia */

/* TODO ERROR: Skipped EndRegionDirectiveTrivia */
/* TODO ERROR: Skipped RegionDirectiveTrivia */
[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[System.Xml.Serialization.XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum VersaoServicoConsulta
{
    [System.ComponentModel.Description("1.03")]
    [System.Xml.Serialization.XmlEnum("1.03")]
    Versao_1_03,
    [System.ComponentModel.Description("1.04")]
    [System.Xml.Serialization.XmlEnum("1.04")]
    Versao_1_04,
    [System.ComponentModel.Description("2.00")]
    [System.Xml.Serialization.XmlEnum("2.00")]
    Versao_2_00,
    [System.ComponentModel.Description("3.00")]
    [System.Xml.Serialization.XmlEnum("3.00")]
    Versao_3_00
}

// <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18033"),
// System.SerializableAttribute(),
// System.Xml.Serialization.XmlTypeAttribute(TypeName:="TEventoInfEventoDetEventoVersao", [Namespace]:="http://www.portalfiscal.inf.br/nfe")>
// Public Enum VersaoServicoEvento

// ''' <summary>
// ''' Versao 1.00
// ''' </summary>
// ''' <remarks></remarks>
// <Attributes.DisplayNameAttribute("1.00", False)>
// <System.Xml.Serialization.XmlEnumAttribute("1.00")>
// Versao_1_00

// <Attributes.DisplayNameAttribute("3.00", False)>
// <System.Xml.Serialization.XmlEnumAttribute("3.00")>
// Versao_3_00

// End Enum

// <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18033"),
// System.SerializableAttribute(),
// System.Xml.Serialization.XmlTypeAttribute(TypeName:="TEventoInfEventoTpEvento", AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/nfe")>
// Public Enum CodigoEvento

// <Attributes.DisplayNameAttribute("Carta de Correção", False)>
// <System.Xml.Serialization.XmlEnumAttribute("110110")>
// Correcao = 110110

// <Attributes.DisplayNameAttribute("Cancelamento", False)>
// <System.Xml.Serialization.XmlEnumAttribute("110111")>
// Cancelamento = 110111

// <Attributes.DisplayNameAttribute("Confirmação da Operação", False)>
// <System.Xml.Serialization.XmlEnumAttribute("210200")>
// Confirmacao = 210200

// <Attributes.DisplayNameAttribute("Ciência da Operação", False)>
// <System.Xml.Serialization.XmlEnumAttribute("210210")>
// Ciencia = 210210

// <Attributes.DisplayNameAttribute("Desconhecimento da Operação", False)>
// <System.Xml.Serialization.XmlEnumAttribute("210220")>
// Desconhecimento = 210220

// <Attributes.DisplayNameAttribute("Operação não Realizada", False)>
// <System.Xml.Serialization.XmlEnumAttribute("210240")>
// NaoRealizada = 210240

// <Attributes.DisplayNameAttribute("Registro Passagem NF-e", False)>
// <System.Xml.Serialization.XmlEnumAttribute("610500")>
// PassagemNFe = 610500

// <Attributes.DisplayNameAttribute("Registro Passagem NF-e Cancelado", False)>
// <System.Xml.Serialization.XmlEnumAttribute("610501")>
// PassagemNFeCancelado = 610501

// <Attributes.DisplayNameAttribute("Registro Passagem NF-e RFID", False)>
// <System.Xml.Serialization.XmlEnumAttribute("610550")>
// PassagemNFeRFID = 610550

// <Attributes.DisplayNameAttribute("CT-e Autorizado", False)>
// <System.Xml.Serialization.XmlEnumAttribute("610600")>
// CTeAutorizado = 610600

// <Attributes.DisplayNameAttribute("CT-e Cancelado", False)>
// <System.Xml.Serialization.XmlEnumAttribute("610601")>
// CTeCancelado = 610601

// <Attributes.DisplayNameAttribute("MDF-e Autorizado", False)>
// <System.Xml.Serialization.XmlEnumAttribute("610610")>
// MDFeAutorizado = 610610

// <Attributes.DisplayNameAttribute("MDF-e Cancelado", False)>
// <System.Xml.Serialization.XmlEnumAttribute("610611")>
// MDFeCancelado = 610611

// <Attributes.DisplayNameAttribute("Vistoria Suframa", False)>
// <System.Xml.Serialization.XmlEnumAttribute("990900")>
// VistoriaSuframa = 990900

// <Attributes.DisplayNameAttribute("Internalização Suframa", False)>
// <System.Xml.Serialization.XmlEnumAttribute("990910")>
// IntarnalizacaoSuframa = 990910


// End Enum

// <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18033"),
// System.SerializableAttribute(),
// System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/nfe")>
// Public Enum VersaoServicoConsSitNFe

// <Attributes.DisplayNameAttribute("1.07", False)>
// <System.Xml.Serialization.XmlEnumAttribute("1.07")>
// Versao_1_07

// <Attributes.DisplayNameAttribute("1.10", False)>
// <System.Xml.Serialization.XmlEnumAttribute("1.10")>
// Versao_1_10

// <Attributes.DisplayNameAttribute("2.00", False)>
// <System.Xml.Serialization.XmlEnumAttribute("2.00")>
// Versao_2_00

// <Attributes.DisplayNameAttribute("2.01", False)>
// <System.Xml.Serialization.XmlEnumAttribute("2.01")>
// Versao_2_01

// <Attributes.DisplayNameAttribute("3.00", False)>
// <System.Xml.Serialization.XmlEnumAttribute("3.00")>
// Versao_3_00

// <Attributes.DisplayNameAttribute("3.10", False)>
// <System.Xml.Serialization.XmlEnumAttribute("3.10")>
// Versao_3_10

// <Attributes.DisplayNameAttribute("5.00", False)>
// <System.Xml.Serialization.XmlEnumAttribute("5.00")>
// Versao_5_00
// End Enum

// <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18033"),
// System.SerializableAttribute(),
// System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/nfe")>
// Public Enum VersaoCancelamento_V200_107

// <Attributes.DisplayNameAttribute("2.00", False)>
// <System.Xml.Serialization.XmlEnumAttribute("2.00")>
// Versao_2_00

// <Attributes.DisplayNameAttribute("1.07", False)>
// <System.Xml.Serialization.XmlEnumAttribute("1.07")>
// Versao_1_07
// End Enum

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[System.Xml.Serialization.XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum VersaoServicoDistribuicaoDF
{

    /// <remarks/>
    [System.Xml.Serialization.XmlEnum("1.00")]
    Versao1_00
}
