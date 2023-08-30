﻿namespace EficazFramework.SPED.Schemas.EFD_Reinf;

/// <summary>
/// Pagamentos/créditos a beneficiário pessoa jurídica
/// </summary>
/// <example>
/// ```csharp
/// // Rendimento Isento:
/// var evento = new R4020()
/// {
///     Versao = Versao.v2_01_02,
///     evtRetPJ = new R4020EventoRetencaoPj()
///     {
///         ideEvento = new IdentificacaoEventoPeriodico()
///         {
///             indRetif = IndicadorRetificacao.Original,
///             perApur = $"{DateTime.Now.AddMonths(-1):yyyy-MM}",
///             tpAmb = Ambiente.ProducaoRestrita_DadosReais,
///             procEmi = EmissorEvento.AppContribuinte,
///             verProc = "6.0"
///         },
///         ideContri = new IdentificacaoContribuinte()
///         {
///             tpInsc = PersonalidadeJuridica.CNPJ,
///             nrInsc = "34785515000166",
///         },
///         ideEstab = new R4020IdentificacaoEstabelecimentoPj()
///         {
///             tpInscEstab = PersonalidadeJuridica.CNPJ,
///             nrInscEstab = "34785515000166",
///             ideBenef = new R4010IdentificacaoBeneficiarioPj()
///             {
///                 // identificação do beneficiário
///                 cnpjBenef = "10608025000126",
///                 nmBenef = "Eficaz Assistência Social",
///                 isenImun = TipoIsencaoPJ.InstEduOrAssistSocial,
///                 // pagamento (1:1, diferentemente ao apresentado em R-4010
///                 idePgto = new()
///                 {
///                     // identificação do pagamento
///                     new R4020IdentificacaoPagtoPj()
///                     {
///                         // Utilizar a tabela 01, do Anexo I do Manual
///                         natRend = "15049", // Pagamentos a entidades imunes ou isentas – IN RFB 1.234/2012
///                         observ = "Referente campanha do agasalho",
///                         // informações do pagamento
///                         infoPgto = new()
///                         {
///                             new R4020InfoPagtoPj()
///                             {
///                                 DataFatoGerador = System.DateTime.Now,
///                                 vlrBruto = 152725.25M.ToString("f2"),
///                                 retencoes = null 
///                                 // rendimento isento não possui renteção
///                             },
///                         },
///                     },
///                 }
///             }
///         }
///     }
/// };
/// 
/// // Rendimento Tributável:
/// var eventoo = new R4020() 
/// {
///     Versao = Versao.v2_01_02,
///     evtRetPJ = new R4020EventoRetencaoPj()
///     {
///         ideEvento = new IdentificacaoEventoPeriodico()
///         {
///             indRetif = IndicadorRetificacao.Original,
///             perApur = "2022-08",
///             tpAmb = Ambiente.ProducaoRestrita_DadosReais,
///             procEmi = EmissorEvento.AppContribuinte,
///             verProc = "6.0"
///         },
///         ideContri = new IdentificacaoContribuinte()
///         {
///             tpInsc = PersonalidadeJuridica.CNPJ,
///             nrInsc = "34785515000166",
///         },
///         ideEstab = new R4020IdentificacaoEstabelecimentoPj()
///         {
///             tpInscEstab = PersonalidadeJuridica.CNPJ,
///             nrInscEstab = "34785515000166",
///             ideBenef = new R4010IdentificacaoBeneficiarioPj()
///             {
///                 // identificação do beneficiário
///                 cnpjBenef = "10608025000126",
///                 nmBenef = "Eficaz Auditoria Contábil",
///                 isenImun = TipoIsencaoPJ.InstEduOrAssistSocial,
///                 // pagamento (1:1, diferentemente ao apresentado em R-4010
///                 idePgto = new()
///                 {
///                     // identificação do pagamento
///                     new R4020IdentificacaoPagtoPj()
///                     {
///                         // Utilizar a tabela 01, do Anexo I do Manual
///                         natRend = "15010", // Remuneração de Serviços de auditoria;
///                         observ = "Referente auditoria das demonstrações contábeis do exercício de 2021",
///                         // informações do pagamento
///                         infoPgto = new()
///                         {
///                             new R4020InfoPagtoPj()
///                             {
///                                 DataFatoGerador = System.DateTime.Now,
///                                 vlrBruto = 152725.25M.ToString("f2"),
///                                 retencoes = new R4020InfoPagtoRetencoes()
///                                 {
///                                     vlrBaseIR = 152725.25M.ToString("f2"),
///                                     vlrIR = 2290.88M.ToString("f2"),
///                                     vlrBaseCSLL = 152725.25M.ToString("f2"),
///                                     vlrCSLL = 15272.53M.ToString("f2"),
///                                     vlrBaseCofins = 152725.25M.ToString("f2"),
///                                     vlrCofins = 4581.76M.ToString("f2"),
///                                     vlrBasePP = 152725.25M.ToString("f2"),
///                                     vlrPP = 992.71M.ToString("f2"),
///                                 }
///                             },
///                         }
///                     },
///                 }
///             }
///         }
///     }
/// };
/// ```
/// </example>
[System.SerializableAttribute()]
public partial class R4020 : Evento
{

    private R4020EventoRetencaoPj evtRetPJField;
    private SignatureType signatureField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public R4020EventoRetencaoPj evtRetPJ
    {
        get => evtRetPJField;
        set
        {
            evtRetPJField = value;
            RaisePropertyChanged("evtRetPJ");
        }
    }

    /// <exclude />
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#", Order = 1)]
    public SignatureType Signature
    {
        get => signatureField;
        set
        {
            signatureField = value;
            RaisePropertyChanged("Signature");
        }
    }


    // IXmlSignableDocument Members
    /// <exclude />
    public override string TagToSign => "Reinf";
    /// <exclude />
    public override string TagId => "evtRetPJ";
    /// <exclude />
    public override bool EmptyURI => true;
    /// <exclude />
    public override bool SignAsSHA256 => true;


    // Evento Members
    /// <exclude />
    public override void GeraEventoID() =>
        evtRetPJ.id = $"ID{(int)(evtRetPJ?.ideContri?.tpInsc ?? PersonalidadeJuridica.CNPJ)}{evtRetPJ?.ideContri?.NumeroInscricaoTag() ?? "00000000000000"}{ReinfTimeStampUtils.GetTimeStampIDForEvent()}";

    /// <exclude />
    public override string ContribuinteCNPJ() =>
        evtRetPJ.ideContri.nrInsc;


    // Serialization Members
    /// <exclude />
    public override XmlSerializer DefineSerializer() =>
        new(typeof(R4020), new XmlRootAttribute("Reinf") { Namespace = $"http://www.reinf.esocial.gov.br/schemas/evt4020PagtoBeneficiarioPJ/{Versao}", IsNullable = false });
}

/// <exclude />
public partial class R4020EventoRetencaoPj : EfdReinfBindableObject
{

    private IdentificacaoEventoPeriodico ideEventoField;
    private IdentificacaoContribuinte ideContriField;
    private R4020IdentificacaoEstabelecimentoPj ideEstabField;

    private string idField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public IdentificacaoEventoPeriodico ideEvento
    {
        get => ideEventoField;
        set
        {
            ideEventoField = value;
            RaisePropertyChanged("ideEvento");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public IdentificacaoContribuinte ideContri
    {
        get => ideContriField;
        set
        {
            ideContriField = value;
            RaisePropertyChanged("ideContri");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public R4020IdentificacaoEstabelecimentoPj ideEstab
    {
        get => ideEstabField;
        set
        {
            ideEstabField = value;
            RaisePropertyChanged("ideEstab");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "ID")]
    public string id
    {
        get => idField;
        set
        {
            idField = value;
            RaisePropertyChanged("id");
        }
    }
}

/// <exclude />
public partial class R4020IdentificacaoEstabelecimentoPj : R4010eR4020IdentificacaoEstabelecimentoBase
{
    private R4010IdentificacaoBeneficiarioPj ideBenefField;

    /// <remarks/>
    [XmlElement(Order = 2)]
    public R4010IdentificacaoBeneficiarioPj ideBenef
    {
        get => ideBenefField;
        set
        {
            ideBenefField = value;
            RaisePropertyChanged("ideBenef");
        }
    }
}

/// <exclude />
public partial class R4010IdentificacaoBeneficiarioPj : EfdReinfBindableObject
{

    private string cnpjBenefField;
    private string nmBenefField;
    private TipoIsencaoPJ? isenImunField;
    private List<R4020IdentificacaoPagtoPj> idePgtoField;

    /// <summary>
    /// CNPJ do Beneficiário recebedor dos Rendimentos
    /// </summary>
    [XmlElement(Order = 0)]
    public string cnpjBenef
    {
        get => cnpjBenefField;
        set
        {
            cnpjBenefField = value;
            RaisePropertyChanged("cnpjBenef");
        }
    }

    /// <summary>
    /// Razão Social do Beneficiário recebedor dos Rendimentos
    /// </summary>
    [XmlElement(Order = 1)]
    public string nmBenef
    {
        get => nmBenefField;
        set
        {
            nmBenefField = value;
            RaisePropertyChanged("nmBenef");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public TipoIsencaoPJ? isenImun
    {
        get => isenImunField;
        set
        {
            isenImunField = value;
            RaisePropertyChanged("isenImun");
        }
    }
    public bool ShouldSerializeTipoIsencaoPJ() => isenImun.HasValue;


    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("idePgto", Order = 3)]
    public List<R4020IdentificacaoPagtoPj> idePgto
    {
        get => idePgtoField;
        set
        {
            idePgtoField = value;
            RaisePropertyChanged("idePgto");
        }
    }
}

/// <exclude />
public partial class R4020IdentificacaoPagtoPj : R4010eR4020IdentificacaoPagtoBase
{
    private List<R4020InfoPagtoPj> infoPgtoField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("infoPgto", Order = 2)]
    public List<R4020InfoPagtoPj> infoPgto
    {
        get => infoPgtoField;
        set
        {
            infoPgtoField = value;
            RaisePropertyChanged("infoPgto");
        }
    }
}

/// <exclude />
public partial class R4020InfoPagtoPj : EfdReinfBindableObject
{
    private System.DateTime dtFGField;
    private string vlrBrutoField;
    private IndicadorFciScp? indFciScpField;
    private string nrInscFciScpField;
    private string percSCPField;
    private string indJudField;
    private string paisResidExtField;
    private R4020InfoPagtoRetencoes retencoesField;
    private List<R4020InfoProcessoRelacionado> infoProcRetField = new();
    private R4010eR4020InfomacaoProcessoJudic infoProcJudField;
    private R4020InfoPagtoResExt infoPgtoExtField;

    /// <summary>
    /// Informar a data do fato gerador, ou, em caso de fato não tributável mas de 
    /// informação obrigatória conforme legislação vigente, a data do pagamento ou
    /// crédito, no formato AAAA-MM-DD. <br/><br/>
    /// <b>Validação:</b> A data informada deve estar compreendida no período de apuração
    /// ao qual se refere o arquivo, conforme informado em(perApur}, no formato
    /// AAAA-MM-DD.
    /// </summary>
    [System.Xml.Serialization.XmlElementAttribute("dtFG", DataType = "date", Order = 0)]
    public System.DateTime DataFatoGerador
    {
        get => dtFGField;
        set
        {
            dtFGField = value;
            RaisePropertyChanged("DataFatoGerador");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string vlrBruto
    {
        get => vlrBrutoField;
        set
        {
            vlrBrutoField = value;
            RaisePropertyChanged("vlrBruto");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public IndicadorFciScp? indFciScp
    {
        get => indFciScpField;
        set
        {
            indFciScpField = value;
            RaisePropertyChanged("indFciScp");
        }
    }
    public bool ShouldSerializeindFciScp() => indFciScp.HasValue;

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string nrInscFciScp
    {
        get => nrInscFciScpField;
        set
        {
            nrInscFciScpField = value;
            RaisePropertyChanged("nrInscFciScp");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public string percSCP
    {
        get => percSCPField;
        set
        {
            percSCPField = value;
            RaisePropertyChanged("percSCP");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 5)]
    public string indJud
    {
        get => indJudField;
        set
        {
            indJudField = value;
            RaisePropertyChanged("indJud");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 6)]
    public string paisResidExt
    {
        get => paisResidExtField;
        set
        {
            paisResidExtField = value;
            RaisePropertyChanged("paisResidExt");
        }
    }

    /// <summary>
    /// Informações relativas a retenções na fonte e respectivas bases de cálculo.
    /// </summary>
    [XmlElement(Order = 7)]
    public R4020InfoPagtoRetencoes retencoes
    {
        get => retencoesField;
        set
        {
            retencoesField = value;
            RaisePropertyChanged("retencoes");
        }
    }

    /// <summary>
    /// Informações de processos relacionados a não retenção de tributos ou a depósitos judiciais.
    /// </summary>
    [System.Xml.Serialization.XmlElementAttribute("infoProcRet", Order = 8)]
    public List<R4020InfoProcessoRelacionado> infoProcRet
    {
        get => infoProcRetField;
        set
        {
            infoProcRetField = value;
            RaisePropertyChanged("infoProcRet");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 9)]
    public R4010eR4020InfomacaoProcessoJudic infoProcJud
    {
        get => infoProcJudField;
        set
        {
            infoProcJudField = value;
            RaisePropertyChanged("infoProcJud");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 10)]
    public R4020InfoPagtoResExt infoPgtoExt
    {
        get => infoPgtoExtField;
        set
        {
            infoPgtoExtField = value;
            RaisePropertyChanged("infoPgtoExt");
        }
    }
}

/// <exclude />
public partial class R4020InfoPagtoRetencoes : EfdReinfBindableObject
{

    private string vlrBaseIRField;
    private string vlrIRField;
    private string vlrBaseAgregField;
    private string vlrAgregField;
    private string vlrBaseCSLLField;
    private string vlrCSLLField;
    private string vlrBaseCofinsField;
    private string vlrCofinsField;
    private string vlrBasePPField;
    private string vlrPPField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string vlrBaseIR
    {
        get => vlrBaseIRField;
        set
        {
            vlrBaseIRField = value;
            RaisePropertyChanged("vlrBaseIR");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string vlrIR
    {
        get => vlrIRField;
        set
        {
            vlrIRField = value;
            RaisePropertyChanged("vlrIR");
        }
    }

    /// <summary>
    /// Valor da base de retenção de tributos de forma agregada, efetivamente realizada. <br/>
    /// Este campo deve ser utilizado nos casos em que a retenção for realizada em valor agregado e 
    /// informada no campo {vlrAgreg}. <br/><br/>
    /// <b>Validação: </b>Informação permitida apenas se, para a natureza do rendimento informada 
    /// em {natRend}, houver "Agreg" na coluna "Tributo" da Tabela 01.<br/>
    /// Se informado, deve ser maior que 0 (zero).
    /// </summary>
    [XmlElement(Order = 2)]
    public string vlrBaseAgreg
    {
        get => vlrBaseAgregField;
        set
        {
            vlrBaseAgregField = value;
            RaisePropertyChanged("vlrBaseAgreg");
        }
    }

    /// <summary>
    /// Valor da retenção em valor agregado de tributos (IR, CSLL, Cofins e PIS/Pasep). <br/><br/>
    /// <b>Validação: </b>Informação obrigatória se {vlrBaseAgreg} for informado. Se informado, deve ser maior que zero
    /// </summary>
    [XmlElement(Order = 3)]
    public string vlrAgreg
    {
        get => vlrAgregField;
        set
        {
            vlrAgregField = value;
            RaisePropertyChanged("vlrAgreg");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public string vlrBaseCSLL
    {
        get => vlrBaseCSLLField;
        set
        {
            vlrBaseCSLLField = value;
            RaisePropertyChanged("vlrBaseCSLL");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 5)]
    public string vlrCSLL
    {
        get => vlrCSLLField;
        set
        {
            vlrCSLLField = value;
            RaisePropertyChanged("vlrCSLL");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 6)]
    public string vlrBaseCofins
    {
        get => vlrBaseCofinsField;
        set
        {
            vlrBaseCofinsField = value;
            RaisePropertyChanged("vlrBaseCofins");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 7)]
    public string vlrCofins
    {
        get => vlrCofinsField;
        set
        {
            vlrCofinsField = value;
            RaisePropertyChanged("vlrCofins");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 8)]
    public string vlrBasePP
    {
        get => vlrBasePPField;
        set
        {
            vlrBasePPField = value;
            RaisePropertyChanged("vlrBasePP");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 9)]
    public string vlrPP
    {
        get => vlrPPField;
        set
        {
            vlrPPField = value;
            RaisePropertyChanged("vlrPP");
        }
    }
}

/// <exclude />
public partial class R4020InfoProcessoRelacionado : EfdReinfBindableObject
{

    private TipoProcesso tpProcRetField;
    private string nrProcRetField;
    private string codSuspField;
    private string vlrBaseSuspIRField;
    private string vlrNIRField;
    private string vlrDepIRField;
    private string vlrBaseSuspCSLLField;
    private string vlrNCSLLField;
    private string vlrDepCSLLField;
    private string vlrBaseSuspCofinsField;
    private string vlrNCofinsField;
    private string vlrDepCofinsField;
    private string vlrBaseSuspPPField;
    private string vlrNPPField;
    private string vlrDepPPField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public TipoProcesso tpProcRet
    {
        get => tpProcRetField;
        set
        {
            tpProcRetField = value;
            RaisePropertyChanged("tpProcRet");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nrProcRet
    {
        get => nrProcRetField;
        set
        {
            nrProcRetField = value;
            RaisePropertyChanged("nrProcRet");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string codSusp
    {
        get => codSuspField;
        set
        {
            codSuspField = value;
            RaisePropertyChanged("codSusp");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string vlrBaseSuspIR
    {
        get => vlrBaseSuspIRField;
        set
        {
            vlrBaseSuspIRField = value;
            RaisePropertyChanged("vlrBaseSuspIR");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public string vlrNIR
    {
        get => vlrNIRField;
        set
        {
            vlrNIRField = value;
            RaisePropertyChanged("vlrNIR");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 5)]
    public string vlrDepIR
    {
        get => vlrDepIRField;
        set
        {
            vlrDepIRField = value;
            RaisePropertyChanged("vlrDepIR");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 6)]
    public string vlrBaseSuspCSLL
    {
        get => vlrBaseSuspCSLLField;
        set
        {
            vlrBaseSuspCSLLField = value;
            RaisePropertyChanged("vlrBaseSuspCSLL");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 7)]
    public string vlrNCSLL
    {
        get => vlrNCSLLField;
        set
        {
            vlrNCSLLField = value;
            RaisePropertyChanged("vlrNCSLL");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 8)]
    public string vlrDepCSLL
    {
        get => vlrDepCSLLField;
        set
        {
            vlrDepCSLLField = value;
            RaisePropertyChanged("vlrDepCSLL");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 9)]
    public string vlrBaseSuspCofins
    {
        get => vlrBaseSuspCofinsField;
        set
        {
            vlrBaseSuspCofinsField = value;
            RaisePropertyChanged("vlrBaseSuspCofins");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 10)]
    public string vlrNCofins
    {
        get => vlrNCofinsField;
        set
        {
            vlrNCofinsField = value;
            RaisePropertyChanged("vlrNCofins");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 11)]
    public string vlrDepCofins
    {
        get => vlrDepCofinsField;
        set
        {
            vlrDepCofinsField = value;
            RaisePropertyChanged("vlrDepCofins");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 12)]
    public string vlrBaseSuspPP
    {
        get => vlrBaseSuspPPField;
        set
        {
            vlrBaseSuspPPField = value;
            RaisePropertyChanged("vlrBaseSuspPP");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 13)]
    public string vlrNPP
    {
        get => vlrNPPField;
        set
        {
            vlrNPPField = value;
            RaisePropertyChanged("vlrNPP");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 14)]
    public string vlrDepPP
    {
        get => vlrDepPPField;
        set
        {
            vlrDepPPField = value;
            RaisePropertyChanged("vlrDepPP");
        }
    }
}

/// <exclude />
public partial class R4020InfoPagtoResExt : EfdReinfBindableObject
{
    private IndicadorNIF indNIFField;
    private string nifBenefField;
    private string relFontPgField;
    private string frmTributField;
    private R4010e4020EnderecoResExterior endExtField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public IndicadorNIF indNIF
    {
        get => indNIFField;
        set
        {
            indNIFField = value;
            RaisePropertyChanged("indNIF");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nifBenef
    {
        get => nifBenefField;
        set
        {
            nifBenefField = value;
            RaisePropertyChanged("nifBenef");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 2)]
    public string relFontPg
    {
        get => relFontPgField;
        set
        {
            relFontPgField = value;
            RaisePropertyChanged("relFontPg");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string frmTribut
    {
        get => frmTributField;
        set
        {
            frmTributField = value;
            RaisePropertyChanged("frmTribut");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public R4010e4020EnderecoResExterior endExt
    {
        get => endExtField;
        set
        {
            endExtField = value;
            RaisePropertyChanged("endExt");
        }
    }
}
