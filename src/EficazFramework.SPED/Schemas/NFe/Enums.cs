using System;
using System.Runtime.Serialization;

namespace EficazFrameworkCore.SPED.Schemas.NFe
{

    // ############
    // CABEÇALHO '
    // ############

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [DataContract()]
    [System.Xml.Serialization.XmlType(TypeName = "TAmb", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum Ambiente
    {
        [System.Xml.Serialization.XmlEnum("1")]
        [Attributes.DisplayName("Enum_Ambiente_Producao")]
        Producao = 1,
        [System.Xml.Serialization.XmlEnum("2")]
        [Attributes.DisplayName("Enum_Ambiente_Homologacao")]
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
        [Attributes.DisplayName("Enum_ServicoSolicitado_ConsultaNFeDest")]
        CONSULTARNFEDEST
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [DataContract()]
    [System.Xml.Serialization.XmlType(TypeName = "TConsNFeDestIndNFe", AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum IndicadorTipoNFe
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnum("0")]
        [Attributes.DisplayName("Enum_IndicadorTipoNFe_Todas")]
        Todas = 0,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnum("1")]
        [Attributes.DisplayName("Enum_IndicadorTipoNFe_NaoManifestadas")]
        NaoManifestadasDesconhecidas = 1,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnum("2")]
        [Attributes.DisplayName("Enum_IndicadorTipoNFe_NaoCientes")]
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
        [Attributes.DisplayName("Enum_IndicadorEmissorNFe_Todos")]
        Todos = 0,

        /// <summary>
        /// Evita que NF-e's emitidas por filiais ou pela matriz do CNPJ destinatário sejam incluídas nos resultados.
        /// </summary>
        /// <remarks></remarks>
        [System.Xml.Serialization.XmlEnum("1")]
        [Attributes.DisplayName("Enum_IndicadorEmissorNFe_NaoFilial")]
        NaoFinalMatrizCNPJ = 1
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [DataContract()]
    [System.Xml.Serialization.XmlType(TypeName = "TRetConsNFeDestRetResCCeTpNF", AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum OperacaoNFe
    {
        [System.Xml.Serialization.XmlEnum("0")]
        [Attributes.DisplayName("Entrada")]
        Entrada = 0,
        [System.Xml.Serialization.XmlEnum("1")]
        [Attributes.DisplayName("Saída")]
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
        [Attributes.DisplayName("Autorizada")]
        Autorizada = 1,
        [System.Xml.Serialization.XmlEnum("2")]
        [Attributes.DisplayName("Denegada")]
        Denegada = 2,
        [System.Xml.Serialization.XmlEnum("3")]
        [Attributes.DisplayName("Cancelada")]
        Cancelada = 3
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [DataContract()]
    [System.Xml.Serialization.XmlType(TypeName = "TRetConsNFeDestRetResCancCSitConf", AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum SituacaoManifestacaoDestinatario
    {
        [System.Xml.Serialization.XmlEnum("0")]
        [Attributes.DisplayName("Enum_SituacaoManifestacaoDestinatario_SemManifesto")]
        SemManifestacao = 0,
        [System.Xml.Serialization.XmlEnum("1")]
        [Attributes.DisplayName("Enum_SituacaoManifestacaoDestinatario_Confirmada")]
        Confirmada = 1,
        [System.Xml.Serialization.XmlEnum("2")]
        [Attributes.DisplayName("Enum_SituacaoManifestacaoDestinatario_Desconhecida")]
        Desconhecida = 2,
        [System.Xml.Serialization.XmlEnum("3")]
        [Attributes.DisplayName("Enum_SituacaoManifestacaoDestinatario_NaoRealizada")]
        NaoRealizada = 3,
        [System.Xml.Serialization.XmlEnum("4")]
        [Attributes.DisplayName("Enum_SituacaoManifestacaoDestinatario_Ciencia")]
        Ciencia = 4
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [DataContract()]
    [System.Xml.Serialization.XmlType(TypeName = "TCOrgaoIBGE", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum OrgaoIBGE
    {
        [Attributes.DisplayName("Rondônia")] // , False)>
        [System.Xml.Serialization.XmlEnum("11")]
        RO = 11,
        [Attributes.DisplayName("Acre")] // , False)>
        [System.Xml.Serialization.XmlEnum("12")]
        AC = 12,
        [Attributes.DisplayName("Amazonas")] // , False)>
        [System.Xml.Serialization.XmlEnum("13")]
        AM = 13,
        [Attributes.DisplayName("Roraima")] // , False)>
        [System.Xml.Serialization.XmlEnum("14")]
        RR = 14,
        [Attributes.DisplayName("Pará")] // , False)>
        [System.Xml.Serialization.XmlEnum("15")]
        PA = 15,
        [Attributes.DisplayName("Amapá")] // , False)>
        [System.Xml.Serialization.XmlEnum("16")]
        AP = 16,
        [Attributes.DisplayName("Tocantins")] // , False)>
        [System.Xml.Serialization.XmlEnum("17")]
        TO = 17,
        [Attributes.DisplayName("Maranhão")] // , False)>
        [System.Xml.Serialization.XmlEnum("21")]
        MA = 21,
        [Attributes.DisplayName("Piauí")] // , False)>
        [System.Xml.Serialization.XmlEnum("22")]
        PI = 22,
        [Attributes.DisplayName("Ceará")] // , False)>
        [System.Xml.Serialization.XmlEnum("23")]
        CE = 23,
        [Attributes.DisplayName("Rio Grande do Norte")] // , False)>
        [System.Xml.Serialization.XmlEnum("24")]
        RN = 24,
        [Attributes.DisplayName("Paraíba")] // , False)>
        [System.Xml.Serialization.XmlEnum("25")]
        PB = 25,
        [Attributes.DisplayName("Pernambuco")] // , False)>
        [System.Xml.Serialization.XmlEnum("26")]
        PE = 26,
        [Attributes.DisplayName("Alagoas")] // , False)>
        [System.Xml.Serialization.XmlEnum("27")]
        AL = 27,
        [Attributes.DisplayName("Sergipe")] // , False)>
        [System.Xml.Serialization.XmlEnum("28")]
        SE = 28,
        [Attributes.DisplayName("Bahia")] // , False)>
        [System.Xml.Serialization.XmlEnum("29")]
        BA = 29,
        [Attributes.DisplayName("Minas Gerais")] // , False)>
        [System.Xml.Serialization.XmlEnum("31")]
        MG = 31,
        [Attributes.DisplayName("Espírito Santo")] // , False)>
        [System.Xml.Serialization.XmlEnum("32")]
        ES = 32,
        [Attributes.DisplayName("Rio de Janeiro")] // , False)>
        [System.Xml.Serialization.XmlEnum("33")]
        RJ = 33,
        [Attributes.DisplayName("São Paulo")] // , False)>
        [System.Xml.Serialization.XmlEnum("35")]
        SP = 35,
        [Attributes.DisplayName("Paraná")] // , False)>
        [System.Xml.Serialization.XmlEnum("41")]
        PR = 41,
        [Attributes.DisplayName("Santa Catarina")] // , False)>
        [System.Xml.Serialization.XmlEnum("42")]
        SC = 42,
        [Attributes.DisplayName("Rio Grande do Sul")] // , False)>
        [System.Xml.Serialization.XmlEnum("43")]
        RS = 43,
        [Attributes.DisplayName("Mato Grosso do Sul")] // , False)>
        [System.Xml.Serialization.XmlEnum("50")]
        MS = 50,
        [Attributes.DisplayName("Mato Grosso")] // , False)>
        [System.Xml.Serialization.XmlEnum("51")]
        MT = 51,
        [Attributes.DisplayName("Goiás")] // , False)>
        [System.Xml.Serialization.XmlEnum("52")]
        GO = 52,
        [Attributes.DisplayName("Distrito Federal")]
        [System.Xml.Serialization.XmlEnum("53")]
        DF = 53,
        [Attributes.DisplayName("Distrito Federal")] // , False)>
        [System.Xml.Serialization.XmlEnum("")]
        NN = 0,
        [Attributes.DisplayName("Enum_OrgaoIBGE_SCAN")]
        [System.Xml.Serialization.XmlEnum("90")]
        SefazNacional_SVCAN = 90,
        [Attributes.DisplayName("Enum_OrgaoIBGE_SVAN")]
        [System.Xml.Serialization.XmlEnum("91")]
        SefazNacional_SVCRS = 91,
        [Attributes.DisplayName("Enum_OrgaoIBGE_AN")]
        [System.Xml.Serialization.XmlEnum("92")]
        SefazNacional_AN = 92,
        [Attributes.DisplayName("Exporacao")] // , False)>
        [System.Xml.Serialization.XmlEnum("99")]
        EX = 99
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [DataContract()]
    [System.Xml.Serialization.XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum Estado
    {
        [Attributes.DisplayName("Acre")] // , False)>
        AC,
        [Attributes.DisplayName("Alagoas")] // , False)>
        AL,
        [Attributes.DisplayName("Amazonas")] // , False)>
        AM,
        [Attributes.DisplayName("Amapá")] // , False)>
        AP,
        [Attributes.DisplayName("Bahia")] // , False)>
        BA,
        [Attributes.DisplayName("Ceará")] // , False)>
        CE,
        [Attributes.DisplayName("Distrito Federal")] // , False)>
        DF,
        [Attributes.DisplayName("Espírito Santo")] // , False)>
        ES,
        [Attributes.DisplayName("Goiás")] // , False)>
        GO,
        [Attributes.DisplayName("Maranhão")] // , False)>
        MA,
        [Attributes.DisplayName("Minas Gerais")] // , False)>
        MG,
        [Attributes.DisplayName("Mato Grosso do Sul")] // , False)>
        MS,
        [Attributes.DisplayName("Mato Grosso")] // , False)>
        MT,
        [Attributes.DisplayName("Pará")] // , False)>
        PA,
        [Attributes.DisplayName("Paraíba")] // , False)>
        PB,
        [Attributes.DisplayName("Pernambuco")] // , False)>
        PE,
        [Attributes.DisplayName("Piauí")] // , False)>
        PI,
        [Attributes.DisplayName("Paraná")] // , False)>
        PR,
        [Attributes.DisplayName("Rio de Janeiro")] // , False)>
        RJ,
        [Attributes.DisplayName("Rio Grande do Norte")] // , False)>
        RN,
        [Attributes.DisplayName("Rondônia")] // , False)>
        RO,
        [Attributes.DisplayName("Roraima")] // , False)>
        RR,
        [Attributes.DisplayName("Rio Grande do Sul")] // , False)>
        RS,
        [Attributes.DisplayName("Santa Catarina")] // , False)>
        SC,
        [Attributes.DisplayName("Sergipe")] // , False)>
        SE,
        [Attributes.DisplayName("São Paulo")] // , False)>
        SP,
        [Attributes.DisplayName("Tocantins")] // , False)>
        TO,
        [Attributes.DisplayName("Enum_Estado_EX")]
        EX
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(TypeName = "TNFeInfNFeIdeIndPag", AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum FormaDePagamento
    {
        [System.Xml.Serialization.XmlEnum("0")]
        [Attributes.DisplayName("Enum_FormaDePagamento_AVista")]
        Vista = 0,
        [Attributes.DisplayName("Enum_FormaDePagamento_APrazo")]
        [System.Xml.Serialization.XmlEnum("1")]
        Prazo = 1,
        [Attributes.DisplayName("Enum_FormaDePagamento_Outros")]
        [System.Xml.Serialization.XmlEnum("2")]
        Outros = 2,
        [Attributes.DisplayName("Sem Pagamento")]
        [System.Xml.Serialization.XmlEnum("9")]
        SemPagto = 9
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum ModeloDocumento
    {
        [Attributes.DisplayName("Enum_ModeloDocumento_55")]
        [System.Xml.Serialization.XmlEnum("55")]
        NFe = 55,
        [Attributes.DisplayName("Enum_ModeloDocumento_65")]
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
        [Attributes.DisplayName("Enum_FormaEmissao_Normal")]
        [System.Xml.Serialization.XmlEnum("1")]
        Normal = 1,
        [Attributes.DisplayName("Enum_FormaEmissao_ContingenciaFS")]
        [System.Xml.Serialization.XmlEnum("2")]
        ContingenciaFS = 2,
        [Attributes.DisplayName("Enum_FormaEmissao_ContingenciaSCAN")]
        [System.Xml.Serialization.XmlEnum("3")]
        ContingenciaSCAN = 3,
        [Attributes.DisplayName("Enum_FormaEmissao_ContingenciaDPEC")]
        [System.Xml.Serialization.XmlEnum("4")]
        ContingenciaDPEC = 4,
        [Attributes.DisplayName("Enum_FormaEmissao_ContingenciaFS_DA")]
        [System.Xml.Serialization.XmlEnum("5")]
        ContingenciaFS_DA = 5,
        [Attributes.DisplayName("Enum_FormaEmissao_ContingenciaSVAN")]
        [System.Xml.Serialization.XmlEnum("6")]
        ContingenciaSVC_AN = 6,
        [Attributes.DisplayName("Enum_FormaEmissao_ContingenciaSefaz_RS")]
        [System.Xml.Serialization.XmlEnum("7")]
        ContingenciaSVC_RS = 7,
        [Attributes.DisplayName("Enum_FormaEmissao_ContingenciaOffLine_NFCe")]
        [System.Xml.Serialization.XmlEnum("9")]
        ContingenciaOffLine_NFCe = 9
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum FinalidadeEmissao
    {
        [Attributes.DisplayName("Enum_FinalidadeEmissao_Normal")]
        [System.Xml.Serialization.XmlEnum("1")]
        Normal = 1,
        [Attributes.DisplayName("Enum_FinalidadeEmissao_Complementar")]
        [System.Xml.Serialization.XmlEnum("2")]
        Complementar = 2,
        [Attributes.DisplayName("Enum_FinalidadeEmissao_Ajuste")]
        [System.Xml.Serialization.XmlEnum("3")]
        Ajuste = 3,
        [Attributes.DisplayName("Enum_FinalidadeEmissao_Devolucao")]
        [System.Xml.Serialization.XmlEnum("4")]
        Devolucao = 4
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum ProcessoEmissao
    {
        [Attributes.DisplayName("Enum_ProcessoEmissao_AppContrib")]
        [System.Xml.Serialization.XmlEnum("0")]
        AplicativoContribuinte = 0,
        [Attributes.DisplayName("Enum_ProcessoEmissao_AvulsaFisco")]
        [System.Xml.Serialization.XmlEnum("1")]
        Avulsa_Fisco = 1,
        [Attributes.DisplayName("Enum_ProcessoEmissao_AvulsaContrib")]
        [System.Xml.Serialization.XmlEnum("2")]
        Avulsa_Contribuinte = 2,
        [Attributes.DisplayName("Enum_ProcessoEmissao_AppFisco")]
        [System.Xml.Serialization.XmlEnum("3")]
        AplicativoFisco = 3
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum RegimeTributario
    {
        [Attributes.DisplayName("Enum_RegimeTributario_SN")]
        [System.Xml.Serialization.XmlEnum("1")]
        SimplesNacional = 1,
        [Attributes.DisplayName("Enum_RegimeTributario_SNExcesso")]
        [System.Xml.Serialization.XmlEnum("2")]
        SimplesNacionalExcesso = 2,
        [Attributes.DisplayName("Enum_RegimeTributario_Normal")]
        [System.Xml.Serialization.XmlEnum("3")]
        RegimeNormal = 3
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum IndicadorProcessoReferenciado
    {

        /// <remarks/>
        [Attributes.DisplayName("Enum_IndicadorProcessoReferenciado_SEFAZ")]
        [System.Xml.Serialization.XmlEnum("0")]
        SEFAZ = 0,

        /// <remarks/>
        [Attributes.DisplayName("Enum_IndicadorProcessoReferenciado_JustFederal")]
        [System.Xml.Serialization.XmlEnum("1")]
        JusticaFederal = 1,

        /// <remarks/>
        [Attributes.DisplayName("Enum_IndicadorProcessoReferenciado_JustEstadual")]
        [System.Xml.Serialization.XmlEnum("2")]
        JusticaEstadual = 2,

        /// <remarks/>
        [Attributes.DisplayName("Enum_IndicadorProcessoReferenciado_Secex_RFB")]
        [System.Xml.Serialization.XmlEnum("3")]
        SecexRFB = 3,

        /// <remarks/>
        [Attributes.DisplayName("Enum_IndicadorProcessoReferenciado_Outros")]
        [System.Xml.Serialization.XmlEnum("9")]
        Outros = 9
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe", IncludeInSchema = false)]
    public enum TipoDocumentoReferencia
    {
        [Attributes.DisplayName("Conhecimento de Transporte Eletrônico")] // , False)>
        [System.Xml.Serialization.XmlEnum("refCTe")]
        CTe,
        [Attributes.DisplayName("ECF - Cupom Fiscal")] // , False)>
        [System.Xml.Serialization.XmlEnum("refECF")]
        ECF,
        [Attributes.DisplayName("Nota Fiscal")] // , False)>
        [System.Xml.Serialization.XmlEnum("refNF")]
        NF,
        [Attributes.DisplayName("Nota Fiscal de Produtor Rural")] // , False)>
        [System.Xml.Serialization.XmlEnum("refNFP")]
        NFP,
        [Attributes.DisplayName("Nota Fiscal Eletrônica")] // , False)>
        [System.Xml.Serialization.XmlEnum("refNFe")]
        NFe
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum ModeloECF
    {
        [Attributes.DisplayName("2B")] // , False)>
        [System.Xml.Serialization.XmlEnum("2B")]
        Modelo2B = 0,
        [Attributes.DisplayName("2C")] // , False)>
        [System.Xml.Serialization.XmlEnum("2C")]
        Modelo2C = 1,
        [Attributes.DisplayName("2D")] // , False)>
        [System.Xml.Serialization.XmlEnum("2D")]
        Modelo2D = 2
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum ModeloNF
    {
        [Attributes.DisplayName("Enum_ModeloDocumento_01")]
        [System.Xml.Serialization.XmlEnum("01")]
        Modelo_1 = 1
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum ModeloNFProdutor
    {
        [Attributes.DisplayName("Enum_ModeloDocumento_01")]
        [System.Xml.Serialization.XmlEnum("01")]
        Modelo_1 = 1,
        [Attributes.DisplayName("Enum_ModeloDocumento_04")]
        [System.Xml.Serialization.XmlEnum("04")]
        Modelo_4 = 4
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe", IncludeInSchema = false)]
    public enum FormaTransporte
    {
        [Attributes.DisplayName("Enum_FormaTransporte_Balsa")]
        balsa,
        [Attributes.DisplayName("Enum_FormaTransporte_Reboque")]
        reboque,
        [Attributes.DisplayName("Enum_FormaTransporte_Vagao")]
        vagao,
        [Attributes.DisplayName("Enum_FormaTransporte_Veiculo")]
        veicTransp
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum ModalidadeFrete
    {
        [Attributes.DisplayName("Enum_ModalidadeFrete_Emitente")]
        [System.Xml.Serialization.XmlEnum("0")]
        Emitente = 0,
        [Attributes.DisplayName("Enum_ModalidadeFrete_Destinatario")]
        [System.Xml.Serialization.XmlEnum("1")]
        Destinatario = 1,
        [Attributes.DisplayName("Enum_ModalidadeFrete_Outros")]
        [System.Xml.Serialization.XmlEnum("2")]
        Outros = 2,
        [Attributes.DisplayName("Enum_ModalidadeFrete_ProprioRemetente")]
        [System.Xml.Serialization.XmlEnum("3")]
        ProprioRemetente = 3,
        [Attributes.DisplayName("Enum_ModalidadeFrete_ProprioDestinatario")]
        [System.Xml.Serialization.XmlEnum("4")]
        ProprioDestinatario = 4,
        [Attributes.DisplayName("Enum_ModalidadeFrete_SemFrete")]
        [System.Xml.Serialization.XmlEnum("9")]
        SemFrete = 9
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum TipoAtendimento
    {
        [Attributes.DisplayName("Enum_TipoAtendimento_NaoSeAplica")]
        [System.Xml.Serialization.XmlEnum("0")]
        NaoSeAplica = 0,
        [Attributes.DisplayName("Enum_TipoAtendimento_Presencial")]
        [System.Xml.Serialization.XmlEnum("1")]
        Presencial = 1,
        [Attributes.DisplayName("Enum_TipoAtendimento_NaoPresencial_Internet")]
        [System.Xml.Serialization.XmlEnum("2")]
        NaoPresencial_Internet = 2,
        [Attributes.DisplayName("Enum_TipoAtendimento_NaoPresencial_Tele")]
        [System.Xml.Serialization.XmlEnum("3")]
        NaoPresencial_Tele = 3,
        [Attributes.DisplayName("Enum_TipoAtendimento_NFCeDomicilio")]
        [System.Xml.Serialization.XmlEnum("4")]
        NFCeEntregaDomicicio = 4,
        [Attributes.DisplayName("Enum_TipoAtendimento_PresencialForaEstab")]
        [System.Xml.Serialization.XmlEnum("5")]
        Presencial_ForaEstabelecimento = 5,
        [Attributes.DisplayName("Enum_TipoAtendimento_NaoPresencial_Outros")]
        [System.Xml.Serialization.XmlEnum("9")]
        NaoPresencial_Outros = 9
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum DestinoOperacao
    {
        [Attributes.DisplayName("Enum_DestinoOperacao_Interna")]
        [System.Xml.Serialization.XmlEnum("1")]
        Interna = 1,
        [Attributes.DisplayName("Enum_DestinoOperacao_Interestadual")]
        [System.Xml.Serialization.XmlEnum("2")]
        Interestadual = 2,
        [Attributes.DisplayName("Enum_DestinoOperacao_Exterior")]
        [System.Xml.Serialization.XmlEnum("3")]
        Exterior = 3
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum TipoViaTransporteDI
    {
        [Attributes.DisplayName("Marítima")]
        [System.Xml.Serialization.XmlEnum("1")]
        Maritima = 1,
        [Attributes.DisplayName("Fluvial")]
        [System.Xml.Serialization.XmlEnum("2")]
        Fluvial = 2,
        [Attributes.DisplayName("Lacustre")]
        [System.Xml.Serialization.XmlEnum("3")]
        Lacustre = 3,
        [Attributes.DisplayName("Aérea")]
        [System.Xml.Serialization.XmlEnum("4")]
        Aerea = 4,
        [Attributes.DisplayName("Postal")]
        [System.Xml.Serialization.XmlEnum("5")]
        Postal = 5,
        [Attributes.DisplayName("Ferroviária")]
        [System.Xml.Serialization.XmlEnum("6")]
        Ferroviaria = 6,
        [Attributes.DisplayName("Rodoviária")]
        [System.Xml.Serialization.XmlEnum("7")]
        Rodoviaria = 7,
        [Attributes.DisplayName("Conduto")]
        [System.Xml.Serialization.XmlEnum("8")]
        Conduto = 8,
        [Attributes.DisplayName("Meios Próprios")]
        [System.Xml.Serialization.XmlEnum("9")]
        MeiosProprios = 9,
        [Attributes.DisplayName("Entrada / Saída Fictícia")]
        [System.Xml.Serialization.XmlEnum("10")]
        EntradaSaidaFicticia = 10,
        [Attributes.DisplayName("Desconhecido")]
        [System.Xml.Serialization.XmlEnum("11")]
        NA11 = 11,
        [Attributes.DisplayName("Desconhecido")]
        [System.Xml.Serialization.XmlEnum("12")]
        NA12 = 12
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum TipoIntermedioDI
    {
        [Attributes.DisplayName("Por Conta Própria")]
        [System.Xml.Serialization.XmlEnum("1")]
        ContaPropria = 1,
        [Attributes.DisplayName("Por Conta e Ordem")]
        [System.Xml.Serialization.XmlEnum("2")]
        ContaOrdem = 2,
        [Attributes.DisplayName("Encomendda")]
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
        [Attributes.DisplayName("Enum_IndicadorTotal_NaoCompoeTotal")]
        [System.Xml.Serialization.XmlEnum("0")]
        NaoCompoeTotal = 0,
        [Attributes.DisplayName("Enum_IndicadorTotal_CompoeTotal")]
        [System.Xml.Serialization.XmlEnum("1")]
        CompoeTotal = 1
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(Namespace = "http: //www.portalfiscal.inf.br/nfe")]
    public enum OrigemMercadoria
    {

        /// <remarks/>
        [Attributes.DisplayName("Enum_OrigemMercadoria_Nacional")]
        [System.Xml.Serialization.XmlEnum("0")]
        Nacional = 0,
        [Attributes.DisplayName("Enum_OrigemMercadoria_EstrImpIndireta")]
        [System.Xml.Serialization.XmlEnum("1")]
        EstrangeiraImpdireta = 1,
        [Attributes.DisplayName("Enum_OrigemMercadoria_EstrAdqMercIntEx7")]
        [System.Xml.Serialization.XmlEnum("2")]
        EstrangeiraAdqmercinterno = 2,
        [Attributes.DisplayName("Enum_OrigemMercadoria_NacContImp40a70")]
        [System.Xml.Serialization.XmlEnum("3")]
        NAcionalConteudoImportSup40Inf70 = 3,
        [Attributes.DisplayName("Enum_OrigemMercadoria_NacProdAjustes")]
        [System.Xml.Serialization.XmlEnum("4")]
        NaiconalProducaoAjustes = 4,
        [Attributes.DisplayName("Enum_OrigemMercadoria_NacContImpAte40")]
        [System.Xml.Serialization.XmlEnum("5")]
        NacionalConteudoImportInf40 = 5,
        [Attributes.DisplayName("Enum_OrigemMercadoria_EstrImpDiretaSemSimilar")]
        [System.Xml.Serialization.XmlEnum("6")]
        EstrangeiraImpDiretaSemSimilar = 6,
        [Attributes.DisplayName("Enum_OrigemMercadoria_EstrAdqMercIntSemSimilar")]
        [System.Xml.Serialization.XmlEnum("7")]
        EstrangeiraAdqMercInternoSemSimilar = 7,
        [Attributes.DisplayName("Enum_OrigemMercadoria_NacContImpSup70")]
        [System.Xml.Serialization.XmlEnum("8")]
        NacionalConteudoImpSup70 = 8
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum TipoArma
    {

        /// <remarks/>
        [Attributes.DisplayName("Enum_TipoArma_UsoPermitido")]
        [System.Xml.Serialization.XmlEnum("0")]
        UsoPermitido = 0,

        /// <remarks/>
        [Attributes.DisplayName("Enum_TipoArma_UsoRestrito")]
        [System.Xml.Serialization.XmlEnum("1")]
        UsoRestrito = 1,
        [Attributes.DisplayName("Enum_NotAnOption")]
        [System.Xml.Serialization.XmlIgnore()]
        NA = 999
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum VeiculoTipoOperacao
    {

        /// <remarks/>
        [Attributes.DisplayName("Enum_VeiculoTipoOperacao_VendaConc")]
        [System.Xml.Serialization.XmlEnum("1")]
        VendaConcessionaria = 1,

        /// <remarks/>
        [Attributes.DisplayName("Enum_VeiculoTipoOperacao_FatConsFinal")]
        [System.Xml.Serialization.XmlEnum("2")]
        FatConsFinal = 2,

        /// <remarks/>
        [Attributes.DisplayName("Enum_VeiculoTipoOperacao_VendaDirGrandesCons")]
        [System.Xml.Serialization.XmlEnum("3")]
        GrandesConsumidores = 3,

        /// <remarks/>
        [Attributes.DisplayName("Enum_VeiculoTipoOperacao_Outros")]
        [System.Xml.Serialization.XmlEnum("0")]
        Outros = 0
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum VeiculoTipoCombustivel
    {
        [Attributes.DisplayName("Enum_VeiculoTipoCombustivel_Alcool")]
        [System.Xml.Serialization.XmlEnum("01")]
        Alcool = 1,
        [Attributes.DisplayName("Enum_VeiculoTipoCombustivel_Alcool")]
        [System.Xml.Serialization.XmlEnum("1")]
        Alcool_v3 = 1,
        [Attributes.DisplayName("Enum_VeiculoTipoCombustivel_Gasolina")]
        [System.Xml.Serialization.XmlEnum("02")]
        Gasolina = 2,
        [Attributes.DisplayName("Enum_VeiculoTipoCombustivel_Gasolina")]
        [System.Xml.Serialization.XmlEnum("2")]
        Gasolina_v3 = 2,
        [Attributes.DisplayName("Enum_VeiculoTipoCombustivel_Diesel")]
        [System.Xml.Serialization.XmlEnum("03")]
        Diesel = 3,
        [Attributes.DisplayName("Enum_VeiculoTipoCombustivel_Diesel")]
        [System.Xml.Serialization.XmlEnum("3")]
        Diesel_v3 = 3,
        [Attributes.DisplayName("Enum_VeiculoTipoCombustivel_Gasogenio")]
        [System.Xml.Serialization.XmlEnum("04")]
        Gasogenio = 4,
        [Attributes.DisplayName("Enum_VeiculoTipoCombustivel_GasMetano")]
        [System.Xml.Serialization.XmlEnum("05")]
        GasMetano = 5,
        [Attributes.DisplayName("Enum_VeiculoTipoCombustivel_ElfontIN")]
        [System.Xml.Serialization.XmlEnum("06")]
        ElfontIN = 6,
        [Attributes.DisplayName("Enum_VeiculoTipoCombustivel_ElfontEX")]
        [System.Xml.Serialization.XmlEnum("07")]
        ElfontEX = 7,
        [Attributes.DisplayName("Enum_VeiculoTipoCombustivel_GasolinaGNC")]
        [System.Xml.Serialization.XmlEnum("08")]
        Gasolina_GNV = 8,
        [Attributes.DisplayName("Enum_VeiculoTipoCombustivel_AlcoolGNC")]
        [System.Xml.Serialization.XmlEnum("09")]
        Alcool_GNC = 9,
        [Attributes.DisplayName("Enum_VeiculoTipoCombustivel_DieselGNC")]
        [System.Xml.Serialization.XmlEnum("10")]
        Diesel_GNC = 10,
        [Attributes.DisplayName("Enum_VeiculoTipoCombustivel_AlcoolGasolina")]
        [System.Xml.Serialization.XmlEnum("12")]
        Alcool_Gasolina = 12,
        [Attributes.DisplayName("Enum_VeiculoTipoCombustivel_AlcoolGasolinaGNV")]
        [System.Xml.Serialization.XmlEnum("13")]
        Alcool_Gasolina_GNV = 13,
        [Attributes.DisplayName("Enum_VeiculoTipoCombustivel_AlcoolGasolina")]
        [System.Xml.Serialization.XmlEnum("16")]
        Alcool_Gasolina_v3 = 16,
        [Attributes.DisplayName("Enum_VeiculoTipoCombustivel_AlcoolGasolinaGNV")]
        [System.Xml.Serialization.XmlEnum("17")]
        Alcool_Gasolina_GNV_v3 = 17,
        [Attributes.DisplayName("Enum_VeiculoTipoCombustivel_GasolinaEletrico")]
        [System.Xml.Serialization.XmlEnum("18")]
        GasolinaEletrico = 18,
        [Attributes.DisplayName("Enum_NotAnOption")]
        [System.Xml.Serialization.XmlIgnore()]
        NA = 999
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum VeiculoCondicaoChassi
    {
        [Attributes.DisplayName("Enum_VeiculoCondicaoChassi_Remarcado")]
        [System.Xml.Serialization.XmlEnum("R")]
        R,
        [Attributes.DisplayName("Enum_VeiculoCondicaoChassi_Normal")]
        [System.Xml.Serialization.XmlEnum("N")]
        N
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum VeiculoCondicao
    {

        /// <remarks/>
        [Attributes.DisplayName("Enum_VeiculoCondicao_Acabado")]
        [System.Xml.Serialization.XmlEnum("1")]
        Acabad0 = 1,

        /// <remarks/>
        [Attributes.DisplayName("Enum_VeiculoCondicao_Inacabado")]
        [System.Xml.Serialization.XmlEnum("2")]
        Inacabado = 2,

        /// <remarks/>
        [Attributes.DisplayName("Enum_VeiculoCondicao_SemiAcabado")]
        [System.Xml.Serialization.XmlEnum("3")]
        SemiAcabado = 3
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum VeiculoRestricao
    {

        /// <remarks/>
        [Attributes.DisplayName("Enum_VeiculoRestricao_None")]
        [System.Xml.Serialization.XmlEnum("0")]
        NaoHa = 0,

        /// <remarks/>
        [Attributes.DisplayName("Enum_VeiculoRestricao_AlienacaoFiduciaria")]
        [System.Xml.Serialization.XmlEnum("1")]
        AlienacaoFiduciaria = 1,

        /// <remarks/>
        [Attributes.DisplayName("Enum_VeiculoRestricao_ArrendMercantil")]
        [System.Xml.Serialization.XmlEnum("2")]
        ArrendamentoMercantil = 2,

        /// <remarks/>
        [Attributes.DisplayName("Enum_VeiculoRestricao_ReservaDominio")]
        [System.Xml.Serialization.XmlEnum("3")]
        ReservaDominio = 3,

        /// <remarks/>
        [Attributes.DisplayName("Enum_VeiculoRestricao_Penhor")]
        [System.Xml.Serialization.XmlEnum("4")]
        PenhorVeiculos = 4,

        /// <remarks/>
        [Attributes.DisplayName("Enum_VeiculoRestricao_Outras")]
        [System.Xml.Serialization.XmlEnum("9")]
        Outras = 9
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum VeiculoTipo
    {
        [Attributes.DisplayName("Enum_VeiculoTipo_Bicicleta")]
        [System.Xml.Serialization.XmlEnum("1")]
        Bicicleta = 1,
        [Attributes.DisplayName("Enum_VeiculoTipo_Bicicleta")]
        [System.Xml.Serialization.XmlEnum("01")]
        Bicicleta_v3 = 1,
        [Attributes.DisplayName("Enum_VeiculoTipo_Ciclomoto")]
        [System.Xml.Serialization.XmlEnum("2")]
        Ciclomoto = 2,
        [Attributes.DisplayName("Enum_VeiculoTipo_Motoneta")]
        [System.Xml.Serialization.XmlEnum("3")]
        Motoneta = 3,
        [Attributes.DisplayName("Enum_VeiculoTipo_Motociclo")]
        [System.Xml.Serialization.XmlEnum("4")]
        Motociclo = 4,
        [Attributes.DisplayName("Enum_VeiculoTipo_Motociclo")]
        [System.Xml.Serialization.XmlEnum("04")]
        Motociclo_v3 = 4,
        [Attributes.DisplayName("Enum_VeiculoTipo_Triciclo")]
        [System.Xml.Serialization.XmlEnum("5")]
        Triciclo = 5,
        [Attributes.DisplayName("Enum_VeiculoTipo_Automovel")]
        [System.Xml.Serialization.XmlEnum("6")]
        Automovel = 6,
        [Attributes.DisplayName("Enum_VeiculoTipo_Automovel")]
        [System.Xml.Serialization.XmlEnum("06")]
        Automovel_v3 = 6,
        [Attributes.DisplayName("Enum_VeiculoTipo_Microonibus")]
        [System.Xml.Serialization.XmlEnum("7")]
        Microonibus = 7,
        [Attributes.DisplayName("Enum_VeiculoTipo_Microonibus")]
        [System.Xml.Serialization.XmlEnum("07")]
        Microonibus_v3 = 7,
        [Attributes.DisplayName("Enum_VeiculoTipo_Onibus")]
        [System.Xml.Serialization.XmlEnum("8")]
        Onibus = 8,
        [Attributes.DisplayName("Enum_VeiculoTipo_Bonde")]
        [System.Xml.Serialization.XmlEnum("9")]
        Bonde = 9,
        [Attributes.DisplayName("Enum_VeiculoTipo_Reboque")]
        [System.Xml.Serialization.XmlEnum("10")]
        Reboque = 10,
        [Attributes.DisplayName("Enum_VeiculoTipo_SemiReboque")]
        [System.Xml.Serialization.XmlEnum("11")]
        SemiReboque = 11,
        [Attributes.DisplayName("Enum_VeiculoTipo_Charrete")]
        [System.Xml.Serialization.XmlEnum("12")]
        Charrete = 12,
        [Attributes.DisplayName("Enum_VeiculoTipo_Caminhoneta")]
        [System.Xml.Serialization.XmlEnum("13")]
        Caminhoneta = 13,
        [Attributes.DisplayName("Enum_VeiculoTipo_Caminhao")]
        [System.Xml.Serialization.XmlEnum("14")]
        Caminhao = 14,
        [Attributes.DisplayName("Enum_VeiculoTipo_Carroca")]
        [System.Xml.Serialization.XmlEnum("15")]
        Carroça = 15,
        [Attributes.DisplayName("Enum_VeiculoTipo_CarroDeMao")]
        [System.Xml.Serialization.XmlEnum("16")]
        CarrodeMao = 16,
        [Attributes.DisplayName("Enum_VeiculoTipo_CTrator")]
        [System.Xml.Serialization.XmlEnum("17")]
        CTrator = 17,
        [Attributes.DisplayName("Enum_VeiculoTipo_TratorRodas")]
        [System.Xml.Serialization.XmlEnum("18")]
        TratordeRodas = 18,
        [Attributes.DisplayName("Enum_VeiculoTipo_TratorMisto")]
        [System.Xml.Serialization.XmlEnum("19")]
        TratorMisto = 19,
        [Attributes.DisplayName("Enum_VeiculoTipo_TratorEsteira")]
        [System.Xml.Serialization.XmlEnum("20")]
        TratordeEsteiras = 20,
        [Attributes.DisplayName("Enum_VeiculoTipo_Quadriciclo")]
        [System.Xml.Serialization.XmlEnum("21")]
        Quadriciclo = 21,
        [Attributes.DisplayName("Enum_VeiculoTipo_EspOnibus")]
        [System.Xml.Serialization.XmlEnum("22")]
        EspOnibus = 22,
        [Attributes.DisplayName("Enum_VeiculoTipo_MistoCAM")]
        [System.Xml.Serialization.XmlEnum("23")]
        MistoCAM = 23,
        [Attributes.DisplayName("Enum_VeiculoTipo_CargaCAM")]
        [System.Xml.Serialization.XmlEnum("24")]
        CargaCAM = 24,
        [Attributes.DisplayName("Enum_VeiculoTipo_Utilitario")]
        [System.Xml.Serialization.XmlEnum("25")]
        Utilitario = 25,
        [Attributes.DisplayName("Enum_VeiculoTipo_MotorCasa")]
        [System.Xml.Serialization.XmlEnum("26")]
        MotorCasa = 26,
        [Attributes.DisplayName("Enum_NotAnOption")]
        [System.Xml.Serialization.XmlIgnore()]
        NA = 999
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum VeiculoEspecie
    {
        [Attributes.DisplayName("Enum_VeciculoEspecie_Desconhecido")]
        [System.Xml.Serialization.XmlEnum("0")]
        Desconhecido = 0,
        [Attributes.DisplayName("Enum_VeciculoEspecie_Passageiro")]
        [System.Xml.Serialization.XmlEnum("1")]
        Passageiro = 1,
        [Attributes.DisplayName("Enum_VeciculoEspecie_Carga")]
        [System.Xml.Serialization.XmlEnum("2")]
        Carga = 2,
        [Attributes.DisplayName("Enum_VeciculoEspecie_Misto")]
        [System.Xml.Serialization.XmlEnum("3")]
        Misto = 3,
        [Attributes.DisplayName("Enum_VeciculoEspecie_Corrida")]
        [System.Xml.Serialization.XmlEnum("4")]
        Corrida = 4,
        [Attributes.DisplayName("Enum_VeciculoEspecie_Tracao")]
        [System.Xml.Serialization.XmlEnum("5")]
        Tracao = 5,
        [Attributes.DisplayName("Enum_VeciculoEspecie_Especial")]
        [System.Xml.Serialization.XmlEnum("6")]
        Especial = 6,
        [Attributes.DisplayName("Enum_NotAnOption")]
        [System.Xml.Serialization.XmlIgnore()]
        NA = 999
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum VeiculoCorDENATRAN
    {
        [Attributes.DisplayName("Enum_VeiculoCorDenatran_Amarelo")]
        [System.Xml.Serialization.XmlEnum("1")]
        Amarelo = 1,
        [Attributes.DisplayName("Enum_VeiculoCorDenatran_Amarelo")]
        [System.Xml.Serialization.XmlEnum("01")]
        Amarelo_V4 = 1,
        [Attributes.DisplayName("Enum_VeiculoCorDenatran_Azul")]
        [System.Xml.Serialization.XmlEnum("2")]
        Azul = 2,
        [Attributes.DisplayName("Enum_VeiculoCorDenatran_Azul")]
        [System.Xml.Serialization.XmlEnum("02")]
        Azul_V4 = 2,
        [Attributes.DisplayName("Enum_VeiculoCorDenatran_Bege")]
        [System.Xml.Serialization.XmlEnum("3")]
        Bege = 3,
        [Attributes.DisplayName("Enum_VeiculoCorDenatran_Bege")]
        [System.Xml.Serialization.XmlEnum("03")]
        Bege_V4 = 3,
        [Attributes.DisplayName("Enum_VeiculoCorDenatran_Branca")]
        [System.Xml.Serialization.XmlEnum("4")]
        Branca = 4,
        [Attributes.DisplayName("Enum_VeiculoCorDenatran_Branca")]
        [System.Xml.Serialization.XmlEnum("04")]
        Branca_v3 = 4,
        [Attributes.DisplayName("Enum_VeiculoCorDenatran_Cinza")]
        [System.Xml.Serialization.XmlEnum("5")]
        Cinza = 5,
        [Attributes.DisplayName("Enum_VeiculoCorDenatran_Cinza")]
        [System.Xml.Serialization.XmlEnum("05")]
        Cinza_V4 = 5,
        [Attributes.DisplayName("Enum_VeiculoCorDenatran_Dourada")]
        [System.Xml.Serialization.XmlEnum("6")]
        Dourada = 6,
        [Attributes.DisplayName("Enum_VeiculoCorDenatran_Dourada")]
        [System.Xml.Serialization.XmlEnum("06")]
        Dourada_V4 = 6,
        [Attributes.DisplayName("Enum_VeiculoCorDenatran_Grena")]
        [System.Xml.Serialization.XmlEnum("7")]
        Grena = 7,
        [Attributes.DisplayName("Enum_VeiculoCorDenatran_Grena")]
        [System.Xml.Serialization.XmlEnum("07")]
        Grena_V4 = 7,
        [Attributes.DisplayName("Enum_VeiculoCorDenatran_Laranja")]
        [System.Xml.Serialization.XmlEnum("8")]
        Laranja = 8,
        [Attributes.DisplayName("Enum_VeiculoCorDenatran_Laranja")]
        [System.Xml.Serialization.XmlEnum("08")]
        Laranja_V4 = 8,
        [Attributes.DisplayName("Enum_VeiculoCorDenatran_Marrom")]
        [System.Xml.Serialization.XmlEnum("9")]
        Marrom = 9,
        [Attributes.DisplayName("Enum_VeiculoCorDenatran_Marrom")]
        [System.Xml.Serialization.XmlEnum("09")]
        Marrom_V4 = 9,
        [Attributes.DisplayName("Enum_VeiculoCorDenatran_Prata")]
        [System.Xml.Serialization.XmlEnum("10")]
        Prata = 10,
        [Attributes.DisplayName("Enum_VeiculoCorDenatran_Preta")]
        [System.Xml.Serialization.XmlEnum("11")]
        Preta = 11,
        [Attributes.DisplayName("Enum_VeiculoCorDenatran_Rosa")]
        [System.Xml.Serialization.XmlEnum("12")]
        Rosa = 12,
        [Attributes.DisplayName("Enum_VeiculoCorDenatran_Roxa")]
        [System.Xml.Serialization.XmlEnum("13")]
        Roxa = 13,
        [Attributes.DisplayName("Enum_VeiculoCorDenatran_Verde")]
        [System.Xml.Serialization.XmlEnum("14")]
        Verde = 14,
        [Attributes.DisplayName("Enum_VeiculoCorDenatran_Vermelha")]
        [System.Xml.Serialization.XmlEnum("15")]
        Vermelha = 15,
        [Attributes.DisplayName("Enum_VeiculoCorDenatran_Fantasia")]
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
        [Attributes.DisplayName("00")]
        CST_00 = 0,
        [Attributes.DisplayName("10")]
        [System.Xml.Serialization.XmlEnum("10")]
        CST_10 = 10,
        [Attributes.DisplayName("20")]
        [System.Xml.Serialization.XmlEnum("20")]
        CST_20 = 20,
        [Attributes.DisplayName("30")]
        [System.Xml.Serialization.XmlEnum("30")]
        CST_30 = 30,
        [Attributes.DisplayName("40")]
        [System.Xml.Serialization.XmlEnum("40")]
        CST_40 = 40,
        [Attributes.DisplayName("41")]
        [System.Xml.Serialization.XmlEnum("41")]
        CST_41 = 41,
        [Attributes.DisplayName("50")]
        [System.Xml.Serialization.XmlEnum("50")]
        CST_50 = 50,
        [Attributes.DisplayName("51")]
        [System.Xml.Serialization.XmlEnum("51")]
        CST_51 = 51,
        [Attributes.DisplayName("60")]
        [System.Xml.Serialization.XmlEnum("60")]
        CST_60 = 60,
        [Attributes.DisplayName("70")]
        [System.Xml.Serialization.XmlEnum("70")]
        CST_70 = 70,
        [Attributes.DisplayName("90")]
        [System.Xml.Serialization.XmlEnum("90")]
        CST_90 = 90,
        [Attributes.DisplayName("999")]
        [System.Xml.Serialization.XmlEnum("999")]
        CST_NA = 999
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum CSOSN_ICMS
    {
        [Attributes.DisplayName("101")]
        [System.Xml.Serialization.XmlEnum("101")]
        CST101 = 101,
        [Attributes.DisplayName("102")]
        [System.Xml.Serialization.XmlEnum("102")]
        CST102 = 102,
        [Attributes.DisplayName("103")]
        [System.Xml.Serialization.XmlEnum("103")]
        CST103 = 103,
        [Attributes.DisplayName("201")]
        [System.Xml.Serialization.XmlEnum("201")]
        CST201 = 201,
        [Attributes.DisplayName("202")]
        [System.Xml.Serialization.XmlEnum("202")]
        CST202 = 202,
        [Attributes.DisplayName("203")]
        [System.Xml.Serialization.XmlEnum("203")]
        CST203 = 203,
        [Attributes.DisplayName("300")]
        [System.Xml.Serialization.XmlEnum("300")]
        CST300 = 300,
        [Attributes.DisplayName("400")]
        [System.Xml.Serialization.XmlEnum("400")]
        CST400 = 400,
        [Attributes.DisplayName("500")]
        [System.Xml.Serialization.XmlEnum("500")]
        CST500 = 500,
        [Attributes.DisplayName("900")]
        [System.Xml.Serialization.XmlEnum("900")]
        CST900 = 900,
        [Attributes.DisplayName("999")]
        [System.Xml.Serialization.XmlEnum("999")]
        CSTNA = 999
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(TypeName = "ItemChoiceTypeICMSTrib", Namespace = "http://www.portalfiscal.inf.br/nfe", IncludeInSchema = false)]
    public enum Tributacao_ICMS_Identifier
    {
        ICMS00,
        ICMS10,
        ICMS20,
        ICMS30,
        ICMS40,
        ICMS51,
        ICMS60,
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
        [Attributes.DisplayName("Enum_ICMS_ModBC_MVA")]
        [System.Xml.Serialization.XmlEnum("0")]
        MargeValorAgregado = 0,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMS_ModBC_PautaValor")]
        [System.Xml.Serialization.XmlEnum("1")]
        PautaValor = 1,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMS_ModBC_TabeladoMaxValor")]
        [System.Xml.Serialization.XmlEnum("2")]
        PrecoTabeladoMaxVal = 2,
        [Attributes.DisplayName("Enum_ICMS_ModBC_Valor")]
        [System.Xml.Serialization.XmlEnum("3")]
        ValorOperacao = 3
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum DetalhamentoICMS_CST10_ModBC
    {

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMS_ModBC_MVA")]
        [System.Xml.Serialization.XmlEnum("0")]
        MargeValorAgregado = 0,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMS_ModBC_PautaValor")]
        [System.Xml.Serialization.XmlEnum("1")]
        PautaValor = 1,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMS_ModBC_TabeladoMaxValor")]
        [System.Xml.Serialization.XmlEnum("2")]
        PrecoTabeladoMaxVal = 2,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMS_ModBC_Valor")]
        [System.Xml.Serialization.XmlEnum("3")]
        ValorOperacao = 3
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum DetalhamentoICMS_CST10_ModBCST
    {

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_TabeladoMaxSugerido")]
        [System.Xml.Serialization.XmlEnum("0")]
        PrecoTabMaxSugerido = 0,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_ListaNegativaValor")]
        [System.Xml.Serialization.XmlEnum("1")]
        ListaNegativaVal = 1,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_ListaPositivaValor")]
        [System.Xml.Serialization.XmlEnum("2")]
        ListaPositivaVal = 2,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_ListaNeutraValor")]
        [System.Xml.Serialization.XmlEnum("3")]
        ListaNeutraVal = 3,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_MVA")]
        [System.Xml.Serialization.XmlEnum("4")]
        MVA = 4,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_PautaValor")]
        [System.Xml.Serialization.XmlEnum("5")]
        PautaVal = 5
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum DetalhamentoICMS_CST20_ModBC
    {
        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMS_ModBC_MVA")]
        [System.Xml.Serialization.XmlEnum("0")]
        MargeValorAgregado = 0,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMS_ModBC_PautaValor")]
        [System.Xml.Serialization.XmlEnum("1")]
        PautaValor = 1,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMS_ModBC_TabeladoMaxValor")]
        [System.Xml.Serialization.XmlEnum("2")]
        PrecoTabeladoMaxVal = 2,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMS_ModBC_Valor")]
        [System.Xml.Serialization.XmlEnum("3")]
        ValorOperacao = 3
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum DetalhamentoICMS_CST30_ModBCST
    {

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_TabeladoMaxSugerido")]
        [System.Xml.Serialization.XmlEnum("0")]
        PrecoTabMaxSugerido = 0,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_ListaNegativaValor")]
        [System.Xml.Serialization.XmlEnum("1")]
        ListaNegativaVal = 1,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_ListaPositivaValor")]
        [System.Xml.Serialization.XmlEnum("2")]
        ListaPositivaVal = 2,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_ListaNeutraValor")]
        [System.Xml.Serialization.XmlEnum("3")]
        ListaNeutraVal = 3,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_MVA")]
        [System.Xml.Serialization.XmlEnum("4")]
        MVA = 4,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_PautaValor")]
        [System.Xml.Serialization.XmlEnum("5")]
        PautaVal = 5
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum DetalhamentoICMS_CST40_MotivoDesoneracao
    {

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMS_MotivoDesoneracao_Taxi")]
        [System.Xml.Serialization.XmlEnum("1")]
        Taxi = 1,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMS_MotivoDesoneracao_DefFisico")]
        [System.Xml.Serialization.XmlEnum("2")]
        DeficienteFisico = 2,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMS_MotivoDesoneracao_ProdAgrop")]
        [System.Xml.Serialization.XmlEnum("3")]
        ProdutorAgropecuario = 3,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMS_MotivoDesoneracao_FrotistaLocadora")]
        [System.Xml.Serialization.XmlEnum("4")]
        FrotistaLocadora = 4,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMS_MotivoDesoneracao_DiploConsular")]
        [System.Xml.Serialization.XmlEnum("5")]
        DiplomáticoConsular = 5,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMS_MotivoDesoneracao_AmazoniaALC")]
        [System.Xml.Serialization.XmlEnum("6")]
        UtilMotocAmOcidALC = 6,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMS_MotivoDesoneracao_Suframa")]
        [System.Xml.Serialization.XmlEnum("7")]
        SUFRAMA = 7,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMS_MotivoDesoneracao_VendaOrgPublico")]
        [System.Xml.Serialization.XmlEnum("8")]
        VendaOrgaosPublicos = 8,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMS_MotivoDesoneracao_Outros")]
        [System.Xml.Serialization.XmlEnum("9")]
        Outros = 9
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum DetalhamentoICMS_CST51_ModBC
    {

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMS_ModBC_MVA")]
        [System.Xml.Serialization.XmlEnum("0")]
        MargeValorAgregado = 0,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMS_ModBC_PautaValor")]
        [System.Xml.Serialization.XmlEnum("1")]
        PautaValor = 1,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMS_ModBC_TabeladoMaxValor")]
        [System.Xml.Serialization.XmlEnum("2")]
        PrecoTabeladoMaxVal = 2,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMS_ModBC_Valor")]
        [System.Xml.Serialization.XmlEnum("3")]
        ValorOperacao = 3
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum DetalhamentoICMS_CST70_ModBC
    {

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMS_ModBC_MVA")]
        [System.Xml.Serialization.XmlEnum("0")]
        MargeValorAgregado = 0,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMS_ModBC_PautaValor")]
        [System.Xml.Serialization.XmlEnum("1")]
        PautaValor = 1,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMS_ModBC_TabeladoMaxValor")]
        [System.Xml.Serialization.XmlEnum("2")]
        PrecoTabeladoMaxVal = 2,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMS_ModBC_Valor")]
        [System.Xml.Serialization.XmlEnum("3")]
        ValorOperacao = 3
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum DetalhamentoICMS_CST70_ModBCST
    {

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_TabeladoMaxSugerido")]
        [System.Xml.Serialization.XmlEnum("0")]
        PrecoTabMaxSugerido = 0,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_ListaNegativaValor")]
        [System.Xml.Serialization.XmlEnum("1")]
        ListaNegativaVal = 1,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_ListaPositivaValor")]
        [System.Xml.Serialization.XmlEnum("2")]
        ListaPositivaVal = 2,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_ListaNeutraValor")]
        [System.Xml.Serialization.XmlEnum("3")]
        ListaNeutraVal = 3,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_MVA")]
        [System.Xml.Serialization.XmlEnum("4")]
        MVA = 4,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_PautaValor")]
        [System.Xml.Serialization.XmlEnum("5")]
        PautaVal = 5
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum DetalhamentoICMS_CST90_ModBC
    {

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMS_ModBC_MVA")]
        [System.Xml.Serialization.XmlEnum("0")]
        MargeValorAgregado = 0,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMS_ModBC_PautaValor")]
        [System.Xml.Serialization.XmlEnum("1")]
        PautaValor = 1,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMS_ModBC_TabeladoMaxValor")]
        [System.Xml.Serialization.XmlEnum("2")]
        PrecoTabeladoMaxVal = 2,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMS_ModBC_Valor")]
        [System.Xml.Serialization.XmlEnum("3")]
        ValorOperacao = 3
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum DetalhamentoICMS_CST90_ModBCST
    {

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_MVA")]
        [System.Xml.Serialization.XmlEnum("0")]
        PrecoTabMaxSugerido = 0,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_ListaNegativaValor")]
        [System.Xml.Serialization.XmlEnum("1")]
        ListaNegativaVal = 1,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_ListaPositivaValor")]
        [System.Xml.Serialization.XmlEnum("2")]
        ListaPositivaVal = 2,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_ListaNeutraValor")]
        [System.Xml.Serialization.XmlEnum("3")]
        ListaNeutraVal = 3,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_MVA")]
        [System.Xml.Serialization.XmlEnum("4")]
        MVA = 4,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_PautaValor")]
        [System.Xml.Serialization.XmlEnum("5")]
        PautaVal = 5
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum DetalhamentoICMSSN_CSOSN201_ModBCST
    {

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_TabeladoMaxSugerido")]
        [System.Xml.Serialization.XmlEnum("0")]
        PrecoTabMaxSugerido = 0,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_ListaNegativaValor")]
        [System.Xml.Serialization.XmlEnum("1")]
        ListaNegativaVal = 1,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_ListaPositivaValor")]
        [System.Xml.Serialization.XmlEnum("2")]
        ListaPositivaVal = 2,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_ListaNeutraValor")]
        [System.Xml.Serialization.XmlEnum("3")]
        ListaNeutraVal = 3,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_MVA")]
        [System.Xml.Serialization.XmlEnum("4")]
        MVA = 4,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_PautaValor")]
        [System.Xml.Serialization.XmlEnum("5")]
        PautaVal = 5
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum DetalhamentoICMSSN_CSOSN202_ModBCST
    {

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_TabeladoMaxSugerido")]
        [System.Xml.Serialization.XmlEnum("0")]
        PrecoTabMaxSugerido = 0,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_ListaNegativaValor")]
        [System.Xml.Serialization.XmlEnum("1")]
        ListaNegativaVal = 1,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_ListaPositivaValor")]
        [System.Xml.Serialization.XmlEnum("2")]
        ListaPositivaVal = 2,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_ListaNeutraValor")]
        [System.Xml.Serialization.XmlEnum("3")]
        ListaNeutraVal = 3,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_MVA")]
        [System.Xml.Serialization.XmlEnum("4")]
        MVA = 4,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_PautaValor")]
        [System.Xml.Serialization.XmlEnum("5")]
        PautaVal = 5
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum DetalhamentoICMSSN_CSOSN900_ModBC
    {

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMS_ModBC_MVA")]
        [System.Xml.Serialization.XmlEnum("0")]
        MargeValorAgregado = 0,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMS_ModBC_PautaValor")]
        [System.Xml.Serialization.XmlEnum("1")]
        PautaValor = 1,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMS_ModBC_TabeladoMaxValor")]
        [System.Xml.Serialization.XmlEnum("2")]
        PrecoTabeladoMaxVal = 2,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMS_ModBC_Valor")]
        [System.Xml.Serialization.XmlEnum("3")]
        ValorOperacao = 3
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum DetalhamentoICMSSN_CSOSN900_ModBCST
    {

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_TabeladoMaxSugerido")]
        [System.Xml.Serialization.XmlEnum("0")]
        PrecoTabMaxSugerido = 0,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_ListaNegativaValor")]
        [System.Xml.Serialization.XmlEnum("1")]
        ListaNegativaVal = 1,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_ListaPositivaValor")]
        [System.Xml.Serialization.XmlEnum("2")]
        ListaPositivaVal = 2,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_ListaNeutraValor")]
        [System.Xml.Serialization.XmlEnum("3")]
        ListaNeutraVal = 3,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_MVA")]
        [System.Xml.Serialization.XmlEnum("4")]
        MVA = 4,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_PautaValor")]
        [System.Xml.Serialization.XmlEnum("5")]
        PautaVal = 5
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum DetalhamentoICMS_Part_ModBC
    {

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMS_ModBC_MVA")]
        [System.Xml.Serialization.XmlEnum("0")]
        MargeValorAgregado = 0,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMS_ModBC_PautaValor")]
        [System.Xml.Serialization.XmlEnum("1")]
        PautaValor = 1,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMS_ModBC_TabeladoMaxValor")]
        [System.Xml.Serialization.XmlEnum("2")]
        PrecoTabeladoMaxVal = 2,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMS_ModBC_Valor")]
        [System.Xml.Serialization.XmlEnum("3")]
        ValorOperacao = 3
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum DetalhamentoICMS_Part_ModBCST
    {

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_TabeladoMaxSugerido")]
        [System.Xml.Serialization.XmlEnum("0")]
        PrecoTabMaxSugerido = 0,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_ListaNegativaValor")]
        [System.Xml.Serialization.XmlEnum("1")]
        ListaNegativaVal = 1,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_ListaPositivaValor")]
        [System.Xml.Serialization.XmlEnum("2")]
        ListaPositivaVal = 2,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_ListaNeutraValor")]
        [System.Xml.Serialization.XmlEnum("3")]
        ListaNeutraVal = 3,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_MVA")]
        [System.Xml.Serialization.XmlEnum("4")]
        MVA = 4,

        /// <remarks/>
        [Attributes.DisplayName("Enum_ICMSST_ModBC_PautaValor")]
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
        [Attributes.DisplayName("Enum_IPI_CST_EntrRecupCredito")]
        [System.Xml.Serialization.XmlEnum("00")]
        EntradaCredito = 0,
        [Attributes.DisplayName("Enum_IPI_CST_EntrTribAliqZero")]
        [System.Xml.Serialization.XmlEnum("01")]
        EntAliqZero = 1,
        [Attributes.DisplayName("Enum_IPI_CST_EntrIsenta")]
        [System.Xml.Serialization.XmlEnum("02")]
        EntIsenta = 2,
        [Attributes.DisplayName("Enum_IPI_CST_EntrNaoTrib")]
        [System.Xml.Serialization.XmlEnum("03")]
        EntNTributada = 3,
        [Attributes.DisplayName("Enum_IPI_CST_EntrImune")]
        [System.Xml.Serialization.XmlEnum("04")]
        EntImune = 4,
        [Attributes.DisplayName("Enum_IPI_CST_EntrSuspensao")]
        [System.Xml.Serialization.XmlEnum("05")]
        EntSuspensao = 5,
        [Attributes.DisplayName("Enum_IPI_CST_EntrOutras")]
        [System.Xml.Serialization.XmlEnum("49")]
        OutrasEntradas = 49,
        [Attributes.DisplayName("Enum_IPI_CST_SaidaTrib")]
        [System.Xml.Serialization.XmlEnum("50")]
        SaidaTributada = 50,
        [Attributes.DisplayName("Enum_IPI_CST_SaidaTribAliqZero")]
        [System.Xml.Serialization.XmlEnum("51")]
        SaiAliqZero = 51,
        [Attributes.DisplayName("Enum_IPI_CST_SaidaIsenta")]
        [System.Xml.Serialization.XmlEnum("52")]
        SaiIsenta = 52,
        [Attributes.DisplayName("Enum_IPI_CST_SaidaNaoTrib")]
        [System.Xml.Serialization.XmlEnum("53")]
        SaiNTributada = 53,
        [Attributes.DisplayName("Enum_IPI_CST_SaidaImune")]
        [System.Xml.Serialization.XmlEnum("54")]
        SaiImune = 54,
        [Attributes.DisplayName("Enum_IPI_CST_SaidaSuspensao")]
        [System.Xml.Serialization.XmlEnum("55")]
        SaiSuspensao = 55,
        [Attributes.DisplayName("Enum_IPI_CST_SaidaOutras")]
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
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpTribAliqNormal")]
        [System.Xml.Serialization.XmlEnum("01")]
        AliquotaNormal = 1,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpTribAliqDif")]
        [System.Xml.Serialization.XmlEnum("02")]
        AliquotaDiferenciada = 2,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpTribAliqUnProd")]
        [System.Xml.Serialization.XmlEnum("03")]
        TributavelQuant = 3,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpTribMonoAliqZero")]
        [System.Xml.Serialization.XmlEnum("04")]
        TribMonofasica = 4,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpTribST")]
        [System.Xml.Serialization.XmlEnum("05")]
        SubstituicaoTributaria = 5,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpTribAliqZero")]
        [System.Xml.Serialization.XmlEnum("06")]
        AliqZero = 6,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpIsenta")]
        [System.Xml.Serialization.XmlEnum("07")]
        Isenta = 7,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpSemIncidencia")]
        [System.Xml.Serialization.XmlEnum("08")]
        SemIncidencia = 8,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpSuspensao")]
        [System.Xml.Serialization.XmlEnum("09")]
        Suspensao = 9,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_SaidasOutras")]
        [System.Xml.Serialization.XmlEnum("49")]
        OutrasOpSaidas = 49,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpCreditoMercInterno")]
        [System.Xml.Serialization.XmlEnum("50")]
        CreditoTribMercadoInterno = 50,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpCreditoNTMercInterno")]
        [System.Xml.Serialization.XmlEnum("51")]
        CreditoNaoTribMercadoInterno = 51,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpCreditoExp")]
        [System.Xml.Serialization.XmlEnum("52")]
        CreditoTribExportacao = 52,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpCreditoTribNTMercInterno")]
        [System.Xml.Serialization.XmlEnum("53")]
        CreditoTribNaoTribMercadoInterno = 53,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpCreditoMercIntExp")]
        [System.Xml.Serialization.XmlEnum("54")]
        CreditoTribMercadoInternoExportacao = 54,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpCreditoNTMercIntExp")]
        [System.Xml.Serialization.XmlEnum("55")]
        CreditoNaoTribMercadoInternoExportacao = 55,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpCreditoTribNTMercIntExp")]
        [System.Xml.Serialization.XmlEnum("56")]
        CreditoTribNaoTribMercadoInternoExportacao = 56,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_CreditoPresMercInterno")]
        [System.Xml.Serialization.XmlEnum("60")]
        CredPresumidoTribMercadoInterno = 60,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_CreditoPresNTMercInterno")]
        [System.Xml.Serialization.XmlEnum("61")]
        CredPresumidoNaoTribMercadoInterno = 61,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_CreditoPresExportacao")]
        [System.Xml.Serialization.XmlEnum("62")]
        CredPresumidoTribExportacao = 62,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_CreditoPresTribNTMercInt")]
        [System.Xml.Serialization.XmlEnum("63")]
        CredPresumidoTribNaoTribMercadoInterno = 63,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_CreditoPresTribMercIntExp")]
        [System.Xml.Serialization.XmlEnum("64")]
        CredPresumidoMercadoInternoExportacao = 64,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_CreditoPresNTTribMercIntExp")]
        [System.Xml.Serialization.XmlEnum("65")]
        CredPresumidoNaoTribMercadoInternoExportacao = 65,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_CreditoPresTribNTMercIntExp")]
        [System.Xml.Serialization.XmlEnum("66")]
        CredPresumidoTribNaoTribMercadoInternoExportacao = 66,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_CreditoPresOutras")]
        [System.Xml.Serialization.XmlEnum("67")]
        CredPresumidoOutrasOp = 67,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpAquisSemCredito")]
        [System.Xml.Serialization.XmlEnum("70")]
        AquisSemDireitoCredito = 70,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpAquisIsencao")]
        [System.Xml.Serialization.XmlEnum("71")]
        AquisIsencao = 71,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpAquisSuspensao")]
        [System.Xml.Serialization.XmlEnum("72")]
        AquisSuspensao = 72,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpAquisAliqZero")]
        [System.Xml.Serialization.XmlEnum("73")]
        AquisAliqZero = 73,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpAquisSemIncidencia")]
        [System.Xml.Serialization.XmlEnum("74")]
        AquisSemIncidencia = 74,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpAquisST")]
        [System.Xml.Serialization.XmlEnum("75")]
        AquisST = 75,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpAquisOutras")]
        [System.Xml.Serialization.XmlEnum("98")]
        OutrasOpEntradas = 98,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OutrasOperacoes")]
        [System.Xml.Serialization.XmlEnum("99")]
        OutrasOp = 99,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_NotValid")]
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
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpTribAliqNormal")]
        [System.Xml.Serialization.XmlEnum("01")]
        AliquotaNormal = 1,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpTribAliqDif")]
        [System.Xml.Serialization.XmlEnum("02")]
        AliquotaDiferenciada = 2,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpTribAliqUnProd")]
        [System.Xml.Serialization.XmlEnum("03")]
        TributavelQuant = 3,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpTribMonoAliqZero")]
        [System.Xml.Serialization.XmlEnum("04")]
        TribMonofasica = 4,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpTribST")]
        [System.Xml.Serialization.XmlEnum("05")]
        SubstituicaoTributaria = 5,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpTribAliqZero")]
        [System.Xml.Serialization.XmlEnum("06")]
        AliqZero = 6,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpIsenta")]
        [System.Xml.Serialization.XmlEnum("07")]
        Isenta = 7,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpSemIncidencia")]
        [System.Xml.Serialization.XmlEnum("08")]
        SemIncidencia = 8,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpSuspensao")]
        [System.Xml.Serialization.XmlEnum("09")]
        Suspensao = 9,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_SaidasOutras")]
        [System.Xml.Serialization.XmlEnum("49")]
        OutrasOpSaidas = 49,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpCreditoMercInterno")]
        [System.Xml.Serialization.XmlEnum("50")]
        CreditoTribMercadoInterno = 50,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpCreditoNTMercInterno")]
        [System.Xml.Serialization.XmlEnum("51")]
        CreditoNaoTribMercadoInterno = 51,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpCreditoExp")]
        [System.Xml.Serialization.XmlEnum("52")]
        CreditoTribExportacao = 52,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpCreditoTribNTMercInterno")]
        [System.Xml.Serialization.XmlEnum("53")]
        CreditoTribNaoTribMercadoInterno = 53,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpCreditoMercIntExp")]
        [System.Xml.Serialization.XmlEnum("54")]
        CreditoTribMercadoInternoExportacao = 54,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpCreditoNTMercIntExp")]
        [System.Xml.Serialization.XmlEnum("55")]
        CreditoNaoTribMercadoInternoExportacao = 55,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpCreditoTribNTMercIntExp")]
        [System.Xml.Serialization.XmlEnum("56")]
        CreditoTribNaoTribMercadoInternoExportacao = 56,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_CreditoPresMercInterno")]
        [System.Xml.Serialization.XmlEnum("60")]
        CredPresumidoTribMercadoInterno = 60,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_CreditoPresNTMercInterno")]
        [System.Xml.Serialization.XmlEnum("61")]
        CredPresumidoNaoTribMercadoInterno = 61,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_CreditoPresExportacao")]
        [System.Xml.Serialization.XmlEnum("62")]
        CredPresumidoTribExportacao = 62,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_CreditoPresTribNTMercInt")]
        [System.Xml.Serialization.XmlEnum("63")]
        CredPresumidoTribNaoTribMercadoInterno = 63,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_CreditoPresTribMercIntExp")]
        [System.Xml.Serialization.XmlEnum("64")]
        CredPresumidoMercadoInternoExportacao = 64,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_CreditoPresNTTribMercIntExp")]
        [System.Xml.Serialization.XmlEnum("65")]
        CredPresumidoNaoTribMercadoInternoExportacao = 65,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_CreditoPresTribNTMercIntExp")]
        [System.Xml.Serialization.XmlEnum("66")]
        CredPresumidoTribNaoTribMercadoInternoExportacao = 66,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_CreditoPresOutras")]
        [System.Xml.Serialization.XmlEnum("67")]
        CredPresumidoOutrasOp = 67,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpAquisSemCredito")]
        [System.Xml.Serialization.XmlEnum("70")]
        AquisSemDireitoCredito = 70,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpAquisIsencao")]
        [System.Xml.Serialization.XmlEnum("71")]
        AquisIsencao = 71,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpAquisSuspensao")]
        [System.Xml.Serialization.XmlEnum("72")]
        AquisSuspensao = 72,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpAquisAliqZero")]
        [System.Xml.Serialization.XmlEnum("73")]
        AquisAliqZero = 73,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpAquisSemIncidencia")]
        [System.Xml.Serialization.XmlEnum("74")]
        AquisSemIncidencia = 74,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpAquisST")]
        [System.Xml.Serialization.XmlEnum("75")]
        AquisST = 75,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OpAquisOutras")]
        [System.Xml.Serialization.XmlEnum("98")]
        OutrasOpEntradas = 98,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_OutrasOperacoes")]
        [System.Xml.Serialization.XmlEnum("99")]
        OutrasOp = 99,
        [Attributes.DisplayName("Enum_PISCOFINS_CST_NotValid")]
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
        [Attributes.DisplayName("Dinheiro")]
        [System.Xml.Serialization.XmlEnum("01")]
        Dinheiro = 1,
        [Attributes.DisplayName("Cheque")]
        [System.Xml.Serialization.XmlEnum("02")]
        Cheque = 2,
        [Attributes.DisplayName("Cartão de Crédito")]
        [System.Xml.Serialization.XmlEnum("03")]
        CartaoCredito = 3,
        [Attributes.DisplayName("Cartão de Débito")]
        [System.Xml.Serialization.XmlEnum("04")]
        CartaoDebito = 4,
        [Attributes.DisplayName("Crédito Loja")]
        [System.Xml.Serialization.XmlEnum("05")]
        CreditoLoja = 5,
        [Attributes.DisplayName("Vale Alimentação")]
        [System.Xml.Serialization.XmlEnum("10")]
        ValeAlimentacao = 10,
        [Attributes.DisplayName("Vale Refeição")]
        [System.Xml.Serialization.XmlEnum("11")]
        ValeRefeicao = 11,
        [Attributes.DisplayName("Vale Presente")]
        [System.Xml.Serialization.XmlEnum("12")]
        ValePresente = 12,
        [Attributes.DisplayName("Vale Combustível")]
        [System.Xml.Serialization.XmlEnum("13")]
        ValeCombustivel = 13,
        [Attributes.DisplayName("Duplicata Mercantil")]
        [System.Xml.Serialization.XmlEnum("14")]
        DuplicataMercantil = 14,
        [Attributes.DisplayName("Boleto Bancário")]
        [System.Xml.Serialization.XmlEnum("15")]
        BoletoBancario = 15,
        [Attributes.DisplayName("Depósito Bancário")]
        [System.Xml.Serialization.XmlEnum("16")]
        DepositoBancario = 16,
        [Attributes.DisplayName("Pagamento Instantâneo (PIX)")]
        [System.Xml.Serialization.XmlEnum("17")]
        PIX = 17,
        [Attributes.DisplayName("Transferência bancária, Carteira Digital")]
        [System.Xml.Serialization.XmlEnum("18")]
        CarteiraDigital = 18,
        [Attributes.DisplayName("Programa de fidelidade, Cashback, Crédito Virtual")]
        [System.Xml.Serialization.XmlEnum("19")]
        Fidelidade_Cashback_CredVirtual = 19,
        [Attributes.DisplayName("Sem Pagamento")]
        [System.Xml.Serialization.XmlEnum("90")]
        SemPagto = 90,
        [Attributes.DisplayName("Outros")]
        [System.Xml.Serialization.XmlEnum("99")]
        Outros = 99
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum TipoIntegracaoPgCartao
    {
        [Attributes.DisplayName("Integrado (TEF / e-Commerce)")]
        [System.Xml.Serialization.XmlEnum("1")]
        TEF_eCommerce = 1,
        [Attributes.DisplayName("Não Integrado (POS)")]
        [System.Xml.Serialization.XmlEnum("2")]
        POS = 2
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum BandeiraCartaoCredito
    {
        [Attributes.DisplayName("Visa")]
        [System.Xml.Serialization.XmlEnum("01")]
        Visa = 1,
        [Attributes.DisplayName("Mastercard")]
        [System.Xml.Serialization.XmlEnum("02")]
        Mastercard = 2,
        [Attributes.DisplayName("American Express")]
        [System.Xml.Serialization.XmlEnum("03")]
        AmericanExpress = 3,
        [Attributes.DisplayName("Sorocred")]
        [System.Xml.Serialization.XmlEnum("04")]
        Sorocred = 4,
        [Attributes.DisplayName("Diners Club")]
        [System.Xml.Serialization.XmlEnum("05")]
        DinersClub = 5,
        [Attributes.DisplayName("Elo")]
        [System.Xml.Serialization.XmlEnum("06")]
        Elo = 6,
        [Attributes.DisplayName("Hipercard")]
        [System.Xml.Serialization.XmlEnum("07")]
        Hipercard = 7,
        [Attributes.DisplayName("Aura")]
        [System.Xml.Serialization.XmlEnum("08")]
        Aura = 8,
        [Attributes.DisplayName("Cabal")]
        [System.Xml.Serialization.XmlEnum("09")]
        Cabal = 9,
        [Attributes.DisplayName("Outros")]
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
        [Attributes.DisplayName("1.00")] // , False)>
        [System.Xml.Serialization.XmlEnum("1.00")]
        Versao_1_00,
        [Attributes.DisplayName("3.00")] // , False)>
        [System.Xml.Serialization.XmlEnum("3.00")]
        Versao_3_00
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(TypeName = "TEventoInfEventoTpEvento", AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum CodigoEvento
    {
        [Attributes.DisplayName("Carta de Correção")] // , False)>
        [System.Xml.Serialization.XmlEnum("110110")]
        Correcao = 110110,
        [Attributes.DisplayName("Cancelamento")] // , False)>
        [System.Xml.Serialization.XmlEnum("110111")]
        Cancelamento = 110111,
        [Attributes.DisplayName("Confirmação da Operação")] // , False)>
        [System.Xml.Serialization.XmlEnum("210200")]
        Confirmacao = 210200,
        [Attributes.DisplayName("Ciência da Operação")] // , False)>
        [System.Xml.Serialization.XmlEnum("210210")]
        Ciencia = 210210,
        [Attributes.DisplayName("Desconhecimento da Operação")] // , False)>
        [System.Xml.Serialization.XmlEnum("210220")]
        Desconhecimento = 210220,
        [Attributes.DisplayName("Operação não Realizada")] // , False)>
        [System.Xml.Serialization.XmlEnum("210240")]
        NaoRealizada = 210240,
        [Attributes.DisplayName("Registro Passagem NF-e")] // , False)>
        [System.Xml.Serialization.XmlEnum("610500")]
        PassagemNFe = 610500,
        [Attributes.DisplayName("Registro Passagem NF-e Cancelado")] // , False)>
        [System.Xml.Serialization.XmlEnum("610501")]
        PassagemNFeCancelado = 610501,
        [Attributes.DisplayName("Registro de Passagem de NFe propagado pelo MDFe")] // , False)>
        [System.Xml.Serialization.XmlEnum("610510")]
        PassagemNFePropgMDFe = 610510,
        [Attributes.DisplayName("Registro de Passagem de NFe propagado pelo MDFe/CTe")] // , False)>
        [System.Xml.Serialization.XmlEnum("610514")]
        PassagemNFePropgMDFeCTe = 610514,
        [Attributes.DisplayName("Registro Passagem NF-e RFID")] // , False)>
        [System.Xml.Serialization.XmlEnum("610550")]
        PassagemNFeRFID = 610550,
        [Attributes.DisplayName("Registro de Passagem Automatico MDF-e")] // , False)>
        [System.Xml.Serialization.XmlEnum("610552")]
        PassagemAutoMDFe = 610552,
        [Attributes.DisplayName("Registro de Passagem Automatico MDF-e com CT-e")] // , False)>
        [System.Xml.Serialization.XmlEnum("610554")]
        PassagemAutoMDFecomCTe = 610554,
        [Attributes.DisplayName("CT-e Autorizado")] // , False)>
        [System.Xml.Serialization.XmlEnum("610600")]
        CTeAutorizado = 610600,
        [Attributes.DisplayName("CT-e Cancelado")] // , False)>
        [System.Xml.Serialization.XmlEnum("610601")]
        CTeCancelado = 610601,
        [Attributes.DisplayName("MDF-e Autorizado")] // , False)>
        [System.Xml.Serialization.XmlEnum("610610")]
        MDFeAutorizado = 610610,
        [Attributes.DisplayName("MDF-e Cancelado")] // , False)>
        [System.Xml.Serialization.XmlEnum("610611")]
        MDFeCancelado = 610611,
        [Attributes.DisplayName("MDF-e Autorizado com CT-e")] // , False)>
        [System.Xml.Serialization.XmlEnum("610614")]
        MDFeAutorizadoComCTe = 610614,
        [Attributes.DisplayName("Cancelamento de MDF-e Autorizado com CT-e")] // , False)>
        [System.Xml.Serialization.XmlEnum("610615")]
        MDFeCanceladoComCTe = 610615,
        [Attributes.DisplayName("Vistoria Suframa")] // , False)>
        [System.Xml.Serialization.XmlEnum("990900")]
        VistoriaSuframa = 990900,
        [Attributes.DisplayName("Internalização Suframa")] // , False)>
        [System.Xml.Serialization.XmlEnum("990910")]
        IntarnalizacaoSuframa = 990910
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum VersaoServicoConsSitNFe
    {
        [Attributes.DisplayName("1.07")] // , False)>
        [System.Xml.Serialization.XmlEnum("1.07")]
        Versao_1_07,
        [Attributes.DisplayName("1.10")] // , False)>
        [System.Xml.Serialization.XmlEnum("1.10")]
        Versao_1_10,
        [Attributes.DisplayName("2.00")] // , False)>
        [System.Xml.Serialization.XmlEnum("2.00")]
        Versao_2_00,
        [Attributes.DisplayName("2.01")] // , False)>
        [System.Xml.Serialization.XmlEnum("2.01")]
        Versao_2_01,
        [Attributes.DisplayName("3.00")] // , False)>
        [System.Xml.Serialization.XmlEnum("3.00")]
        Versao_3_00,
        [Attributes.DisplayName("3.10")] // , False)>
        [System.Xml.Serialization.XmlEnum("3.10")]
        Versao_3_10,
        [Attributes.DisplayName("4.00")] // , False)>
        [System.Xml.Serialization.XmlEnum("4.00")]
        Versao_4_00,
        [Attributes.DisplayName("5.00")] // , False)>
        [System.Xml.Serialization.XmlEnum("5.00")]
        Versao_5_00
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public enum VersaoCancelamento
    {
        [Attributes.DisplayName("3.10")] // , False)>
        [System.Xml.Serialization.XmlEnum("3.10")]
        Versao_3_10,
        [Attributes.DisplayName("2.00")] // , False)>
        [System.Xml.Serialization.XmlEnum("2.00")]
        Versao_2_00,
        [Attributes.DisplayName("1.07")] // , False)>
        [System.Xml.Serialization.XmlEnum("1.07")]
        Versao_1_07,
        [Attributes.DisplayName("1.00")] // , False)>
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
        [Attributes.DisplayName("2.00")] // , False)>
        [System.Xml.Serialization.XmlEnum("2.00")]
        Versao_2_00,
        [Attributes.DisplayName("3.10")] // , False)>
        [System.Xml.Serialization.XmlEnum("3.10")]
        Versao_3_10,
        [Attributes.DisplayName("4.00")] // , False)>
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
        [Attributes.DisplayName("1.01")]
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
        [Attributes.DisplayName("Enum_ConsultaDestinatario_IndCont_Fim")]
        NaoPossuiMaisDocuments = 0,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnum("1")]
        [Attributes.DisplayName("Enum_ConsultaDestinatario_IndCont_Desc")]
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
        [Attributes.DisplayName("1.00")]
        [System.Xml.Serialization.XmlEnum("1.00")]
        Versao_1_00,

        /// <summary>
        /// Versao 2.00
        /// </summary>
        /// <remarks></remarks>
        [Attributes.DisplayName("2.00")]
        [System.Xml.Serialization.XmlEnum("2.00")]
        Versao_2_00,

        /// <summary>
        /// Versao 3.10
        /// </summary>
        /// <remarks></remarks>
        [Attributes.DisplayName("3.10")]
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

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */

}