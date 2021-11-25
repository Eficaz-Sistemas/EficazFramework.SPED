using System;

namespace EficazFramework.SPED.Schemas.SAT_CFe;

[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[System.Xml.Serialization.XmlType(IncludeInSchema = false)]
public enum PersonalidadJuridica
{
    [System.ComponentModel.Description("CNPJ")]
    CNPJ,
    [System.ComponentModel.Description("CPF")]
    CPF
}

[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true)]
public enum Ambiente
{

    /// <remarks/>
    [System.Xml.Serialization.XmlEnum("1")]
    Producao,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnum("2")]
    Homologacao
}

[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true)]
public enum Tributacao_ICMS_Identifier
{
    ICMS00,
    ICMS40,
    ICMSSN102,
    ICMSSN900
}

[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true)]
public enum Tributacao_PIS_Identifier
{
    PISAliq,
    PISNT,
    PISOutr,
    PISQtde,
    PISSN
}

[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true)]
public enum Tributacao_COFINS_Identifier
{
    COFINSAliq,
    COFINSNT,
    COFINSOutr,
    COFINSQtde,
    COFINSSN
}

[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[System.Xml.Serialization.XmlType(IncludeInSchema = false)]
public enum ItemChoiceType1
{

    /// <remarks/>
    CRT,

    /// <remarks/>
    CSR
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true)]
public enum consGestaoParametroGestao
{

    /// <remarks/>
    [System.Xml.Serialization.XmlEnum("0")]
    Item0,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnum("1")]
    Item1,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnum("2")]
    Item2,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnum("3")]
    Item3
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[System.Xml.Serialization.XmlType(IncludeInSchema = false)]
public enum DescontoAcredimo
{

    /// <remarks/>
    vAcresSubtot,

    /// <remarks/>
    vDescSubtot
}

public enum FormaPagto
{
    [System.Xml.Serialization.XmlEnum("01")]
    [System.ComponentModel.Description("Dinheiro")]
    Dinheiro = 1,
    [System.Xml.Serialization.XmlEnum("02")]
    [System.ComponentModel.Description("Dinheiro")]
    Cheque = 2,
    [System.Xml.Serialization.XmlEnum("03")]
    [System.ComponentModel.Description("Cartão de Crédito")]
    CartaoCredito = 3,
    [System.Xml.Serialization.XmlEnum("04")]
    [System.ComponentModel.Description("Cartão de Débito")]
    CartaoDebito = 4,
    [System.Xml.Serialization.XmlEnum("05")]
    [System.ComponentModel.Description("Outros")]
    Outros = 5,
    [System.Xml.Serialization.XmlEnum("99")]
    [System.ComponentModel.Description("Outros")]
    OutrosNA = 99
}
