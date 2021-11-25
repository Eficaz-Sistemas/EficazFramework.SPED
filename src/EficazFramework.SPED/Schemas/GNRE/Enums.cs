using System;

namespace EficazFramework.SPED.Schemas.GNRE
{
    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.33440")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.gnre.pe.gov.br")]
    public enum Ambiente
    {

        /// <remarks/>
        [System.ComponentModel.Description("Produção")]
        [System.Xml.Serialization.XmlEnum("1")]
        Producao = 1,

        /// <remarks/>
        [System.ComponentModel.Description("Homologação")]
        [System.Xml.Serialization.XmlEnum("2")]
        Homologacao = 2
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.33440")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(Namespace = "http://www.gnre.pe.gov.br")]
    public enum Identificacao
    {
        [System.ComponentModel.Description("CNPJ")]
        [System.Xml.Serialization.XmlEnum("1")]
        CNPJ = 1,
        [System.ComponentModel.Description("CPF")]
        [System.Xml.Serialization.XmlEnum("2")]
        CPF = 2
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.33440")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(Namespace = "http://www.gnre.pe.gov.br", IncludeInSchema = false)]
    public enum PersonalidadeJuridica
    {

        /// <remarks/>
        [System.ComponentModel.Description("CNPJ")]
        CNPJ,

        /// <remarks/>
        [System.ComponentModel.Description("CPF")]
        CPF
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.33440")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(Namespace = "http://www.gnre.pe.gov.br")]
    public enum Mes
    {
        [System.ComponentModel.Description("Janeiro")]
        [System.Xml.Serialization.XmlEnum("01")]
        Janeiro = 1,
        [System.ComponentModel.Description("Fevereiro")]
        [System.Xml.Serialization.XmlEnum("02")]
        Fevereiro = 2,
        [System.ComponentModel.Description("Março")]
        [System.Xml.Serialization.XmlEnum("03")]
        marco = 3,
        [System.ComponentModel.Description("Abril")]
        [System.Xml.Serialization.XmlEnum("04")]
        Abril = 4,
        [System.ComponentModel.Description("Maio")]
        [System.Xml.Serialization.XmlEnum("05")]
        Maio = 5,
        [System.ComponentModel.Description("Junho")]
        [System.Xml.Serialization.XmlEnum("06")]
        Junho = 6,
        [System.ComponentModel.Description("Julho")]
        [System.Xml.Serialization.XmlEnum("07")]
        Julho = 7,
        [System.ComponentModel.Description("Agosto")]
        [System.Xml.Serialization.XmlEnum("08")]
        Agosto = 8,
        [System.ComponentModel.Description("Setembro")]
        [System.Xml.Serialization.XmlEnum("09")]
        Setembro = 9,
        [System.ComponentModel.Description("Outubro")]
        [System.Xml.Serialization.XmlEnum("10")]
        Outubro = 10,
        [System.ComponentModel.Description("Novembro")]
        [System.Xml.Serialization.XmlEnum("11")]
        Novembro = 11,
        [System.ComponentModel.Description("Dezembro")]
        [System.Xml.Serialization.XmlEnum("12")]
        Dezembro = 12
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.33440")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.gnre.pe.gov.br")]
    public enum ReferenciaPeriodo
    {
        [System.ComponentModel.Description("Mensal")]
        [System.Xml.Serialization.XmlEnum("0")]
        Mensal = 0,
        [System.ComponentModel.Description("1ª Quinzena")]
        [System.Xml.Serialization.XmlEnum("1")]
        Quinzena1 = 1,
        [System.ComponentModel.Description("2ª Quinzena")]
        [System.Xml.Serialization.XmlEnum("2")]
        Quinzena2 = 2,
        [System.ComponentModel.Description("1º Decêndio")]
        [System.Xml.Serialization.XmlEnum("3")]
        Decendio1 = 3,
        [System.ComponentModel.Description("2º Decêndio")]
        [System.Xml.Serialization.XmlEnum("4")]
        Decendio2 = 4,
        [System.ComponentModel.Description("3º Decêndio")]
        [System.Xml.Serialization.XmlEnum("5")]
        Decendio3 = 5
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.33440")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(Namespace = "http://www.gnre.pe.gov.br")]
    public enum TipoCampoExtra
    {
        [System.ComponentModel.Description("Texto")]
        T,
        [System.ComponentModel.Description("Numérico")]
        N,
        [System.ComponentModel.Description("Data")]
        D
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.33440")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(Namespace = "http://www.gnre.pe.gov.br")]
    public enum UF
    {

        /// <remarks/>
        AC,

        /// <remarks/>
        AL,

        /// <remarks/>
        AM,

        /// <remarks/>
        AP,

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
        MG,

        /// <remarks/>
        MS,

        /// <remarks/>
        MT,

        /// <remarks/>
        PA,

        /// <remarks/>
        PB,

        /// <remarks/>
        PE,

        /// <remarks/>
        PI,

        /// <remarks/>
        PR,

        /// <remarks/>
        RJ,

        /// <remarks/>
        RN,

        /// <remarks/>
        RO,

        /// <remarks/>
        RR,

        /// <remarks/>
        RS,

        /// <remarks/>
        SC,

        /// <remarks/>
        SE,

        /// <remarks/>
        SP,

        /// <remarks/>
        TO
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.33440")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(Namespace = "http://www.gnre.pe.gov.br")]
    public enum PTBrBoolean
    {

        /// <remarks/>
        S,

        /// <remarks/>
        N
    }

    public enum CodigoReceita
    {
        [System.ComponentModel.Description("100013 - ICMS Comunicação")]
        ICMS_Comunicacao = 100013,
        [System.ComponentModel.Description("100021 - ICMS Energia Elétrica")]
        ICMS_EEletrica = 100021,
        [System.ComponentModel.Description("100030 - ICMS Transporte")]
        ICMS_Transporte = 100030,
        [System.ComponentModel.Description("100048 - ICMS ST por Apuração")]
        ICMS_ST_Apuracao = 100048,
        [System.ComponentModel.Description("100056 - ICMS Importação")]
        ICMS_Importacao = 100056,
        [System.ComponentModel.Description("100064 - ICMS Autuação Fiscal")]
        ICMS_AutuacaoFiscal = 100064,
        [System.ComponentModel.Description("100072 - ICMS Parcelamento")]
        ICMS_Parcelamento = 100072,
        [System.ComponentModel.Description("100080 - ICMS Recolhimentos Especiais")]
        ICMS_RecolhimentosEspeciais = 100080,
        [System.ComponentModel.Description("100099 - ICMS ST por Operação")]
        ICMS_ST_Operacao = 100099,
        [System.ComponentModel.Description("100102 - ICMS Consumidor Final Não Contribuinte Outra UF por Operação")]
        ICMS_ConsFinalOutraUFOperacao = 100102,
        [System.ComponentModel.Description("100110 - ICMS Consumidor Final Não Contribuinte Outra UF por Apuração")]
        ICMS_ConsFinalOutraUFApuracao = 100110,
        [System.ComponentModel.Description("100129 – ICMS Fundo Estadual de Combate à Pobreza por Operação")]
        ICMS_FundoCombPobrezaOperacao = 100129,
        [System.ComponentModel.Description("100137 - ICMS Fundo Estadual de Combate à Pobreza por Apuração")]
        ICMS_FundoCombPobrezaApuracao = 100137,
        [System.ComponentModel.Description("150010 - ICMS Dívida Ativa")]
        ICMS_DividaAtiva = 150010,
        [System.ComponentModel.Description("500011 - Multa p/ Infração")]
        Multa_Infracao = 500011,
        [System.ComponentModel.Description("600016 - Tava")]
        Taxa = 600016
    }

    public enum PersonalidadeJuridicaRetorno
    {
        CPF = 1,
        CNPJ = 2,
        InscrEstadual = 3
    }

    public enum SituacaoGuia
    {
        [System.Xml.Serialization.XmlEnum("0")]
        ProcessadaSucesso = 0,
        [System.Xml.Serialization.XmlEnum("1")]
        InvalidadaPortal = 1,
        [System.Xml.Serialization.XmlEnum("2")]
        InvalidadaUF = 2,
        [System.Xml.Serialization.XmlEnum("3")]
        ErroComunicacao = 3
    }

    public enum Contingencia
    {
        [System.ComponentModel.Description("0 - Guia gerada pela UF")]
        UF = 0,
        [System.ComponentModel.Description("1 - Guia gerada em contingência")]
        Contingencia
    }

    // 2.00

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.gnre.pe.gov.br")]
    public enum TipoGNRE
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnum("0")]
        Simples = 0,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnum("1")]
        MultiDocsOrigem = 1,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnum("2")]
        MultiReceitas = 2
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.gnre.pe.gov.br")]
    public enum TipoValor
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnum("11")]
        VlrPrincICMS = 11,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnum("12")]
        VlrFCP = 12,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnum("21")]
        VlrTotalICMS = 21,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnum("22")]
        VlrTotalFP = 22,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnum("31")]
        VlrMultaICMS = 31,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnum("32")]
        VlrMultaFP = 32,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnum("41")]
        VlrJurosICMS = 41,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnum("42")]
        VlrJurosFP = 42,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnum("51")]
        VlrAtMonICMS = 51,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnum("52")]
        VlrtAtMonFP = 52
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.gnre.pe.gov.br")]
    public enum Versao
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnum("1.00")]
        v1_00 = 1,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnum("2.00")]
        v2_00 = 2
    }
}