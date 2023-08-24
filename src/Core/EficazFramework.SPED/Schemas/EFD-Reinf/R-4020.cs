using System.Runtime.ConstrainedExecution;

namespace EficazFramework.SPED.Schemas.EFD_Reinf;

/// <summary>
/// Pagamentos/créditos a beneficiário pessoa jurídica
/// </summary>
[System.SerializableAttribute()]
public partial class R4020 : Evento, System.ComponentModel.INotifyPropertyChanged {
    
    private ReinfEvtRetPJ evtRetPJField;
    private SignatureType signatureField;
    
    /// <remarks/>
    [XmlElement(Order = 0)]
    public ReinfEvtRetPJ evtRetPJ
    {
        get => evtRetPJField;
        set
        {
            evtRetPJField = value;
            RaisePropertyChanged("evtRetPJ");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.w3.org/2000/09/xmldsig#", Order = 1)]
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
    public override string TagToSign => "Reinf";
    public override string TagId => "evtRetPJ";
    public override bool EmptyURI => true;
    public override bool SignAsSHA256 => true;


    // Evento Members
    public override void GeraEventoID()
    {
        evtRetPJ.id = string.Format("ID{0}{1}{2}", (int)(evtRetPJ?.ideContri?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtRetPJ?.ideContri?.NumeroInscricaoTag() ?? "00000000000000", ReinfTimeStampUtils.GetTimeStampIDForEvent());
    }

    public override string ContribuinteCNPJ()
    {
        return evtRetPJ.ideContri.nrInsc;
    }


    // PropertyChanged Members
    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }


    // Serialization Members
    public override XmlSerializer DefineSerializer()
    {
        return new XmlSerializer(typeof(R4020), new XmlRootAttribute("Reinf") { Namespace = $"http://www.reinf.esocial.gov.br/schemas/evt4020PagtoBeneficiarioPJ/{Versao}", IsNullable = false });
    }
}

/// <exclude />
public partial class ReinfEvtRetPJ : object, System.ComponentModel.INotifyPropertyChanged {
    
    private ReinfEvtIdeEvento_R40xx ideEventoField;
    private IdentificacaoContribuinte ideContriField;
    private ReinfEvtRetPJIdeEstab ideEstabField;
    
    private string idField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public ReinfEvtIdeEvento_R40xx ideEvento
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
    public ReinfEvtRetPJIdeEstab ideEstab
    {
        get => ideEstabField;
        set
        {
            ideEstabField = value;
            RaisePropertyChanged("ideEstab");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType="ID")]
    public string id
    {
        get => idField;
        set
        {
            idField = value;
            RaisePropertyChanged("id");
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <exclude />
public partial class ReinfEvtRetPJIdeEstab : object, System.ComponentModel.INotifyPropertyChanged {
    
    private PersonalidadeJuridica tpInscEstabField;
    private string nrInscEstabField;
    private ReinfEvtRetPJIdeEstabIdeBenef ideBenefField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public PersonalidadeJuridica tpInscEstab
    {
        get => tpInscEstabField;
        set
        {
            tpInscEstabField = value;
            RaisePropertyChanged("tpInscEstab");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nrInscEstab
    {
        get => nrInscEstabField;
        set
        {
            nrInscEstabField = value;
            RaisePropertyChanged("nrInscEstab");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public ReinfEvtRetPJIdeEstabIdeBenef ideBenef
    {
        get => ideBenefField;
        set
        {
            ideBenefField = value;
            RaisePropertyChanged("ideBenef");
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <exclude />
public partial class ReinfEvtRetPJIdeEstabIdeBenef : object, System.ComponentModel.INotifyPropertyChanged {
    
    private string cnpjBenefField;
    private string nmBenefField;
    private TipoIsencaoPJ? isenImunField;
    private List<ReinfEvtRetPJIdeEstabIdeBenefIdePgto> idePgtoField;

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
    public List<ReinfEvtRetPJIdeEstabIdeBenefIdePgto> idePgto
    {
        get => idePgtoField;
        set
        {
            idePgtoField = value;
            RaisePropertyChanged("idePgto");
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <exclude />
public partial class ReinfEvtRetPJIdeEstabIdeBenefIdePgto : object, System.ComponentModel.INotifyPropertyChanged {
    
    private string natRendField;
    
    private string observField;
    
    private List<ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgto> infoPgtoField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="integer", Order = 0)]
    public string natRend
    {
        get => natRendField;
        set
        {
            natRendField = value;
            RaisePropertyChanged("natRend");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string observ
    {
        get => observField;
        set
        {
            observField = value;
            RaisePropertyChanged("observ");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("infoPgto", Order = 2)]
    public List<ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgto> infoPgto
    {
        get => infoPgtoField;
        set
        {
            infoPgtoField = value;
            RaisePropertyChanged("infoPgto");
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <exclude />
public partial class ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgto : object, System.ComponentModel.INotifyPropertyChanged {
    
    private System.DateTime dtFGField;
    private string vlrBrutoField;
    private IndicadorFciScp? indFciScpField;
    private string nrInscFciScpField;
    private string percSCPField;
    private string indJudField;
    private string paisResidExtField;
    private ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgtoRetencoes retencoesField;
    private List<ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcRet> infoProcRetField = new();
    private ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcJud infoProcJudField;
    private ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgtoInfoPgtoExt infoPgtoExtField;

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
    public ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgtoRetencoes retencoes
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
    public List<ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcRet> infoProcRet
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
    public ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcJud infoProcJud
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
    public ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgtoInfoPgtoExt infoPgtoExt
    {
        get => infoPgtoExtField;
        set
        {
            infoPgtoExtField = value;
            RaisePropertyChanged("infoPgtoExt");
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <exclude />
public partial class ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgtoRetencoes : object, System.ComponentModel.INotifyPropertyChanged {
    
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

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <exclude />
public partial class ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcRet : object, System.ComponentModel.INotifyPropertyChanged {
    
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

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <exclude />
public partial class ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcJud : object, System.ComponentModel.INotifyPropertyChanged {
    
    private string nrProcField;
    private IndicadorOrigemDosRecursos indOrigRecField;
    private string cnpjOrigRecursoField;
    private string descField;
    private ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcJudDespProcJud despProcJudField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string nrProc
    {
        get => nrProcField;
        set
        {
            nrProcField = value;
            RaisePropertyChanged("nrProc");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public IndicadorOrigemDosRecursos indOrigRec
    {
        get => indOrigRecField;
        set
        {
            indOrigRecField = value;
            RaisePropertyChanged("indOrigRec");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string cnpjOrigRecurso
    {
        get => cnpjOrigRecursoField;
        set
        {
            cnpjOrigRecursoField = value;
            RaisePropertyChanged("cnpjOrigRecurso");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string desc
    {
        get => descField;
        set
        {
            descField = value;
            RaisePropertyChanged("desc");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcJudDespProcJud despProcJud
    {
        get => despProcJudField;
        set
        {
            despProcJudField = value;
            RaisePropertyChanged("despProcJud");
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <exclude />
public partial class ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcJudDespProcJud : object, System.ComponentModel.INotifyPropertyChanged {
    
    private string vlrDespCustasField;
    private string vlrDespAdvogadosField;
    private List<ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcJudDespProcJudIdeAdv> ideAdvField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string vlrDespCustas
    {
        get => vlrDespCustasField;
        set
        {
            vlrDespCustasField = value;
            RaisePropertyChanged("vlrDespCustas");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string vlrDespAdvogados
    {
        get => vlrDespAdvogadosField;
        set
        {
            vlrDespAdvogadosField = value;
            RaisePropertyChanged("vlrDespAdvogados");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ideAdv", Order = 2)]
    public List<ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcJudDespProcJudIdeAdv> ideAdv
    {
        get => ideAdvField;
        set
        {
            ideAdvField = value;
            RaisePropertyChanged("ideAdv");
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <exclude />
public partial class ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcJudDespProcJudIdeAdv : object, System.ComponentModel.INotifyPropertyChanged {
    
    private PersonalidadeJuridica tpInscAdvField;
    
    private string nrInscAdvField;
    
    private string vlrAdvField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public PersonalidadeJuridica tpInscAdv
    {
        get => tpInscAdvField;
        set
        {
            tpInscAdvField = value;
            RaisePropertyChanged("tpInscAdv");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nrInscAdv
    {
        get => nrInscAdvField;
        set
        {
            nrInscAdvField = value;
            RaisePropertyChanged("nrInscAdv");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string vlrAdv
    {
        get => vlrAdvField;
        set
        {
            vlrAdvField = value;
            RaisePropertyChanged("vlrAdv");
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <exclude />
public partial class ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgtoInfoPgtoExt : object, System.ComponentModel.INotifyPropertyChanged {
    
    private IndicadorNIF indNIFField;
    private string nifBenefField;
    private string relFontPgField;
    private string frmTributField;
    private ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgtoInfoPgtoExtEndExt endExtField;

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
    [System.Xml.Serialization.XmlElementAttribute(DataType="integer", Order = 2)]
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
    public ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgtoInfoPgtoExtEndExt endExt
    {
        get => endExtField;
        set
        {
            endExtField = value;
            RaisePropertyChanged("endExt");
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}


/// <exclude />
public partial class ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgtoInfoPgtoExtEndExt : object, System.ComponentModel.INotifyPropertyChanged {
    
    private string dscLogradField;
    private string nrLogradField;
    private string complemField;
    private string bairroField;
    private string cidadeField;
    private string estadoField;
    private string codPostalField;
    private string telefField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string dscLograd
    {
        get => dscLogradField;
        set
        {
            dscLogradField = value;
            RaisePropertyChanged("dscLograd");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nrLograd
    {
        get => nrLogradField;
        set
        {
            nrLogradField = value;
            RaisePropertyChanged("nrLograd");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string complem
    {
        get => complemField;
        set
        {
            complemField = value;
            RaisePropertyChanged("complem");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string bairro
    {
        get => bairroField;
        set
        {
            bairroField = value;
            RaisePropertyChanged("bairro");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public string cidade
    {
        get => cidadeField;
        set
        {
            cidadeField = value;
            RaisePropertyChanged("cidade");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 5)]
    public string estado
    {
        get => estadoField;
        set
        {
            estadoField = value;
            RaisePropertyChanged("estado");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 6)]
    public string codPostal
    {
        get => codPostalField;
        set
        {
            codPostalField = value;
            RaisePropertyChanged("codPostal");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 7)]
    public string telef
    {
        get => telefField;
        set
        {
            telefField = value;
            RaisePropertyChanged("telef");
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}
