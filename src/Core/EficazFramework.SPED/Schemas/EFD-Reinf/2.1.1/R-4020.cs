namespace EficazFramework.SPED.Schemas.EFD_Reinf.v2_01_01; 

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.reinf.esocial.gov.br/schemas/evt4020PagtoBeneficiarioPJ/v2_01_01")]
[System.Xml.Serialization.XmlRootAttribute("Reinf", Namespace="http://www.reinf.esocial.gov.br/schemas/evt4020PagtoBeneficiarioPJ/v2_01_01", IsNullable=false)]
public partial class R4020 : IEfdReinfEvt, System.ComponentModel.INotifyPropertyChanged {
    
    private ReinfEvtRetPJ evtRetPJField;
    private SignatureType signatureField;
    
    /// <remarks/>
    [XmlElement(Order = 0)]
    public ReinfEvtRetPJ evtRetPJ {
        get {
            return this.evtRetPJField;
        }
        set {
            this.evtRetPJField = value;
            this.RaisePropertyChanged("evtRetPJ");
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.w3.org/2000/09/xmldsig#")]
    public SignatureType Signature {
        get {
            return this.signatureField;
        }
        set {
            this.signatureField = value;
            this.RaisePropertyChanged("Signature");
        }
    }


    // IXmlSignableDocument Members
    public override string TagToSign => "Reinf";
    public override string TagId => "evtRetPJ";
    public override bool EmptyURI => true;
    public override bool SignAsSHA256 => true;


    // IEfdReinfEvt Members
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
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }


    // Serialization Members
    public override XmlSerializer DefineSerializer()
    {
        return new XmlSerializer(typeof(R4020));
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.reinf.esocial.gov.br/schemas/evt4020PagtoBeneficiarioPJ/v2_01_01")]
public partial class ReinfEvtRetPJ : object, System.ComponentModel.INotifyPropertyChanged {
    
    private ReinfEvtIdeEvento_R40xx ideEventoField;
    private ReinfEvtIdeContri ideContriField;
    private ReinfEvtRetPJIdeEstab ideEstabField;
    
    private string idField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public ReinfEvtIdeEvento_R40xx ideEvento {
        get {
            return this.ideEventoField;
        }
        set {
            this.ideEventoField = value;
            this.RaisePropertyChanged("ideEvento");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public ReinfEvtIdeContri ideContri {
        get {
            return this.ideContriField;
        }
        set {
            this.ideContriField = value;
            this.RaisePropertyChanged("ideContri");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public ReinfEvtRetPJIdeEstab ideEstab {
        get {
            return this.ideEstabField;
        }
        set {
            this.ideEstabField = value;
            this.RaisePropertyChanged("ideEstab");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType="ID")]
    public string id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
            this.RaisePropertyChanged("id");
        }
    }
    
    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.reinf.esocial.gov.br/schemas/evt4020PagtoBeneficiarioPJ/v2_01_01")]
public partial class ReinfEvtRetPJIdeEstab : object, System.ComponentModel.INotifyPropertyChanged {
    
    private byte tpInscEstabField;
    private string nrInscEstabField;
    private ReinfEvtRetPJIdeEstabIdeBenef ideBenefField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public byte tpInscEstab {
        get {
            return this.tpInscEstabField;
        }
        set {
            this.tpInscEstabField = value;
            this.RaisePropertyChanged("tpInscEstab");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nrInscEstab {
        get {
            return this.nrInscEstabField;
        }
        set {
            this.nrInscEstabField = value;
            this.RaisePropertyChanged("nrInscEstab");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public ReinfEvtRetPJIdeEstabIdeBenef ideBenef {
        get {
            return this.ideBenefField;
        }
        set {
            this.ideBenefField = value;
            this.RaisePropertyChanged("ideBenef");
        }
    }
    
    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.reinf.esocial.gov.br/schemas/evt4020PagtoBeneficiarioPJ/v2_01_01")]
public partial class ReinfEvtRetPJIdeEstabIdeBenef : object, System.ComponentModel.INotifyPropertyChanged {
    
    private string cnpjBenefField;
    private string nmBenefField;
    private byte isenImunField;
    private List<ReinfEvtRetPJIdeEstabIdeBenefIdePgto> idePgtoField;

    /// <summary>
    /// CNPJ do Beneficiário recebedor dos Rendimentos
    /// </summary>
    [XmlElement(Order = 0)]
    public string cnpjBenef {
        get {
            return this.cnpjBenefField;
        }
        set {
            this.cnpjBenefField = value;
            this.RaisePropertyChanged("cnpjBenef");
        }
    }

    /// <summary>
    /// Razão Social do Beneficiário recebedor dos Rendimentos
    /// </summary>
    [XmlElement(Order = 1)]
    public string nmBenef {
        get {
            return this.nmBenefField;
        }
        set {
            this.nmBenefField = value;
            this.RaisePropertyChanged("nmBenef");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public byte isenImun {
        get {
            return this.isenImunField;
        }
        set {
            this.isenImunField = value;
            this.RaisePropertyChanged("isenImun");
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("idePgto", Order = 3)]
    public List<ReinfEvtRetPJIdeEstabIdeBenefIdePgto> idePgto {
        get {
            return this.idePgtoField;
        }
        set {
            this.idePgtoField = value;
            this.RaisePropertyChanged("idePgto");
        }
    }
    
    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.reinf.esocial.gov.br/schemas/evt4020PagtoBeneficiarioPJ/v2_01_01")]
public partial class ReinfEvtRetPJIdeEstabIdeBenefIdePgto : object, System.ComponentModel.INotifyPropertyChanged {
    
    private string natRendField;
    
    private string observField;
    
    private ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgto[] infoPgtoField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
    public string natRend {
        get {
            return this.natRendField;
        }
        set {
            this.natRendField = value;
            this.RaisePropertyChanged("natRend");
        }
    }
    
    /// <remarks/>
    public string observ {
        get {
            return this.observField;
        }
        set {
            this.observField = value;
            this.RaisePropertyChanged("observ");
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("infoPgto")]
    public ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgto[] infoPgto {
        get {
            return this.infoPgtoField;
        }
        set {
            this.infoPgtoField = value;
            this.RaisePropertyChanged("infoPgto");
        }
    }
    
    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.reinf.esocial.gov.br/schemas/evt4020PagtoBeneficiarioPJ/v2_01_01")]
public partial class ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgto : object, System.ComponentModel.INotifyPropertyChanged {
    
    private System.DateTime dtFGField;
    
    private string vlrBrutoField;
    
    private byte indFciScpField;
    
    private bool indFciScpFieldSpecified;
    
    private string nrInscFciScpField;
    
    private string percSCPField;
    
    private string indJudField;
    
    private string paisResidExtField;
    
    private ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgtoRetencoes retencoesField;
    
    private ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcRet[] infoProcRetField;
    
    private ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcJud infoProcJudField;
    
    private ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgtoInfoPgtoExt infoPgtoExtField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
    public System.DateTime dtFG {
        get {
            return this.dtFGField;
        }
        set {
            this.dtFGField = value;
            this.RaisePropertyChanged("dtFG");
        }
    }
    
    /// <remarks/>
    public string vlrBruto {
        get {
            return this.vlrBrutoField;
        }
        set {
            this.vlrBrutoField = value;
            this.RaisePropertyChanged("vlrBruto");
        }
    }
    
    /// <remarks/>
    public byte indFciScp {
        get {
            return this.indFciScpField;
        }
        set {
            this.indFciScpField = value;
            this.RaisePropertyChanged("indFciScp");
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool indFciScpSpecified {
        get {
            return this.indFciScpFieldSpecified;
        }
        set {
            this.indFciScpFieldSpecified = value;
            this.RaisePropertyChanged("indFciScpSpecified");
        }
    }
    
    /// <remarks/>
    public string nrInscFciScp {
        get {
            return this.nrInscFciScpField;
        }
        set {
            this.nrInscFciScpField = value;
            this.RaisePropertyChanged("nrInscFciScp");
        }
    }
    
    /// <remarks/>
    public string percSCP {
        get {
            return this.percSCPField;
        }
        set {
            this.percSCPField = value;
            this.RaisePropertyChanged("percSCP");
        }
    }
    
    /// <remarks/>
    public string indJud {
        get {
            return this.indJudField;
        }
        set {
            this.indJudField = value;
            this.RaisePropertyChanged("indJud");
        }
    }
    
    /// <remarks/>
    public string paisResidExt {
        get {
            return this.paisResidExtField;
        }
        set {
            this.paisResidExtField = value;
            this.RaisePropertyChanged("paisResidExt");
        }
    }
    
    /// <remarks/>
    public ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgtoRetencoes retencoes {
        get {
            return this.retencoesField;
        }
        set {
            this.retencoesField = value;
            this.RaisePropertyChanged("retencoes");
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("infoProcRet")]
    public ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcRet[] infoProcRet {
        get {
            return this.infoProcRetField;
        }
        set {
            this.infoProcRetField = value;
            this.RaisePropertyChanged("infoProcRet");
        }
    }
    
    /// <remarks/>
    public ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcJud infoProcJud {
        get {
            return this.infoProcJudField;
        }
        set {
            this.infoProcJudField = value;
            this.RaisePropertyChanged("infoProcJud");
        }
    }
    
    /// <remarks/>
    public ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgtoInfoPgtoExt infoPgtoExt {
        get {
            return this.infoPgtoExtField;
        }
        set {
            this.infoPgtoExtField = value;
            this.RaisePropertyChanged("infoPgtoExt");
        }
    }
    
    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.reinf.esocial.gov.br/schemas/evt4020PagtoBeneficiarioPJ/v2_01_01")]
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
    public string vlrBaseIR {
        get {
            return this.vlrBaseIRField;
        }
        set {
            this.vlrBaseIRField = value;
            this.RaisePropertyChanged("vlrBaseIR");
        }
    }
    
    /// <remarks/>
    public string vlrIR {
        get {
            return this.vlrIRField;
        }
        set {
            this.vlrIRField = value;
            this.RaisePropertyChanged("vlrIR");
        }
    }
    
    /// <remarks/>
    public string vlrBaseAgreg {
        get {
            return this.vlrBaseAgregField;
        }
        set {
            this.vlrBaseAgregField = value;
            this.RaisePropertyChanged("vlrBaseAgreg");
        }
    }
    
    /// <remarks/>
    public string vlrAgreg {
        get {
            return this.vlrAgregField;
        }
        set {
            this.vlrAgregField = value;
            this.RaisePropertyChanged("vlrAgreg");
        }
    }
    
    /// <remarks/>
    public string vlrBaseCSLL {
        get {
            return this.vlrBaseCSLLField;
        }
        set {
            this.vlrBaseCSLLField = value;
            this.RaisePropertyChanged("vlrBaseCSLL");
        }
    }
    
    /// <remarks/>
    public string vlrCSLL {
        get {
            return this.vlrCSLLField;
        }
        set {
            this.vlrCSLLField = value;
            this.RaisePropertyChanged("vlrCSLL");
        }
    }
    
    /// <remarks/>
    public string vlrBaseCofins {
        get {
            return this.vlrBaseCofinsField;
        }
        set {
            this.vlrBaseCofinsField = value;
            this.RaisePropertyChanged("vlrBaseCofins");
        }
    }
    
    /// <remarks/>
    public string vlrCofins {
        get {
            return this.vlrCofinsField;
        }
        set {
            this.vlrCofinsField = value;
            this.RaisePropertyChanged("vlrCofins");
        }
    }
    
    /// <remarks/>
    public string vlrBasePP {
        get {
            return this.vlrBasePPField;
        }
        set {
            this.vlrBasePPField = value;
            this.RaisePropertyChanged("vlrBasePP");
        }
    }
    
    /// <remarks/>
    public string vlrPP {
        get {
            return this.vlrPPField;
        }
        set {
            this.vlrPPField = value;
            this.RaisePropertyChanged("vlrPP");
        }
    }
    
    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.reinf.esocial.gov.br/schemas/evt4020PagtoBeneficiarioPJ/v2_01_01")]
public partial class ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcRet : object, System.ComponentModel.INotifyPropertyChanged {
    
    private byte tpProcRetField;
    
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
    public byte tpProcRet {
        get {
            return this.tpProcRetField;
        }
        set {
            this.tpProcRetField = value;
            this.RaisePropertyChanged("tpProcRet");
        }
    }
    
    /// <remarks/>
    public string nrProcRet {
        get {
            return this.nrProcRetField;
        }
        set {
            this.nrProcRetField = value;
            this.RaisePropertyChanged("nrProcRet");
        }
    }
    
    /// <remarks/>
    public string codSusp {
        get {
            return this.codSuspField;
        }
        set {
            this.codSuspField = value;
            this.RaisePropertyChanged("codSusp");
        }
    }
    
    /// <remarks/>
    public string vlrBaseSuspIR {
        get {
            return this.vlrBaseSuspIRField;
        }
        set {
            this.vlrBaseSuspIRField = value;
            this.RaisePropertyChanged("vlrBaseSuspIR");
        }
    }
    
    /// <remarks/>
    public string vlrNIR {
        get {
            return this.vlrNIRField;
        }
        set {
            this.vlrNIRField = value;
            this.RaisePropertyChanged("vlrNIR");
        }
    }
    
    /// <remarks/>
    public string vlrDepIR {
        get {
            return this.vlrDepIRField;
        }
        set {
            this.vlrDepIRField = value;
            this.RaisePropertyChanged("vlrDepIR");
        }
    }
    
    /// <remarks/>
    public string vlrBaseSuspCSLL {
        get {
            return this.vlrBaseSuspCSLLField;
        }
        set {
            this.vlrBaseSuspCSLLField = value;
            this.RaisePropertyChanged("vlrBaseSuspCSLL");
        }
    }
    
    /// <remarks/>
    public string vlrNCSLL {
        get {
            return this.vlrNCSLLField;
        }
        set {
            this.vlrNCSLLField = value;
            this.RaisePropertyChanged("vlrNCSLL");
        }
    }
    
    /// <remarks/>
    public string vlrDepCSLL {
        get {
            return this.vlrDepCSLLField;
        }
        set {
            this.vlrDepCSLLField = value;
            this.RaisePropertyChanged("vlrDepCSLL");
        }
    }
    
    /// <remarks/>
    public string vlrBaseSuspCofins {
        get {
            return this.vlrBaseSuspCofinsField;
        }
        set {
            this.vlrBaseSuspCofinsField = value;
            this.RaisePropertyChanged("vlrBaseSuspCofins");
        }
    }
    
    /// <remarks/>
    public string vlrNCofins {
        get {
            return this.vlrNCofinsField;
        }
        set {
            this.vlrNCofinsField = value;
            this.RaisePropertyChanged("vlrNCofins");
        }
    }
    
    /// <remarks/>
    public string vlrDepCofins {
        get {
            return this.vlrDepCofinsField;
        }
        set {
            this.vlrDepCofinsField = value;
            this.RaisePropertyChanged("vlrDepCofins");
        }
    }
    
    /// <remarks/>
    public string vlrBaseSuspPP {
        get {
            return this.vlrBaseSuspPPField;
        }
        set {
            this.vlrBaseSuspPPField = value;
            this.RaisePropertyChanged("vlrBaseSuspPP");
        }
    }
    
    /// <remarks/>
    public string vlrNPP {
        get {
            return this.vlrNPPField;
        }
        set {
            this.vlrNPPField = value;
            this.RaisePropertyChanged("vlrNPP");
        }
    }
    
    /// <remarks/>
    public string vlrDepPP {
        get {
            return this.vlrDepPPField;
        }
        set {
            this.vlrDepPPField = value;
            this.RaisePropertyChanged("vlrDepPP");
        }
    }
    
    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.reinf.esocial.gov.br/schemas/evt4020PagtoBeneficiarioPJ/v2_01_01")]
public partial class ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcJud : object, System.ComponentModel.INotifyPropertyChanged {
    
    private string nrProcField;
    
    private byte indOrigRecField;
    
    private string cnpjOrigRecursoField;
    
    private string descField;
    
    private ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcJudDespProcJud despProcJudField;
    
    /// <remarks/>
    public string nrProc {
        get {
            return this.nrProcField;
        }
        set {
            this.nrProcField = value;
            this.RaisePropertyChanged("nrProc");
        }
    }
    
    /// <remarks/>
    public byte indOrigRec {
        get {
            return this.indOrigRecField;
        }
        set {
            this.indOrigRecField = value;
            this.RaisePropertyChanged("indOrigRec");
        }
    }
    
    /// <remarks/>
    public string cnpjOrigRecurso {
        get {
            return this.cnpjOrigRecursoField;
        }
        set {
            this.cnpjOrigRecursoField = value;
            this.RaisePropertyChanged("cnpjOrigRecurso");
        }
    }
    
    /// <remarks/>
    public string desc {
        get {
            return this.descField;
        }
        set {
            this.descField = value;
            this.RaisePropertyChanged("desc");
        }
    }
    
    /// <remarks/>
    public ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcJudDespProcJud despProcJud {
        get {
            return this.despProcJudField;
        }
        set {
            this.despProcJudField = value;
            this.RaisePropertyChanged("despProcJud");
        }
    }
    
    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.reinf.esocial.gov.br/schemas/evt4020PagtoBeneficiarioPJ/v2_01_01")]
public partial class ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcJudDespProcJud : object, System.ComponentModel.INotifyPropertyChanged {
    
    private string vlrDespCustasField;
    
    private string vlrDespAdvogadosField;
    
    private ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcJudDespProcJudIdeAdv[] ideAdvField;
    
    /// <remarks/>
    public string vlrDespCustas {
        get {
            return this.vlrDespCustasField;
        }
        set {
            this.vlrDespCustasField = value;
            this.RaisePropertyChanged("vlrDespCustas");
        }
    }
    
    /// <remarks/>
    public string vlrDespAdvogados {
        get {
            return this.vlrDespAdvogadosField;
        }
        set {
            this.vlrDespAdvogadosField = value;
            this.RaisePropertyChanged("vlrDespAdvogados");
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ideAdv")]
    public ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcJudDespProcJudIdeAdv[] ideAdv {
        get {
            return this.ideAdvField;
        }
        set {
            this.ideAdvField = value;
            this.RaisePropertyChanged("ideAdv");
        }
    }
    
    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.reinf.esocial.gov.br/schemas/evt4020PagtoBeneficiarioPJ/v2_01_01")]
public partial class ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcJudDespProcJudIdeAdv : object, System.ComponentModel.INotifyPropertyChanged {
    
    private byte tpInscAdvField;
    
    private string nrInscAdvField;
    
    private string vlrAdvField;
    
    /// <remarks/>
    public byte tpInscAdv {
        get {
            return this.tpInscAdvField;
        }
        set {
            this.tpInscAdvField = value;
            this.RaisePropertyChanged("tpInscAdv");
        }
    }
    
    /// <remarks/>
    public string nrInscAdv {
        get {
            return this.nrInscAdvField;
        }
        set {
            this.nrInscAdvField = value;
            this.RaisePropertyChanged("nrInscAdv");
        }
    }
    
    /// <remarks/>
    public string vlrAdv {
        get {
            return this.vlrAdvField;
        }
        set {
            this.vlrAdvField = value;
            this.RaisePropertyChanged("vlrAdv");
        }
    }
    
    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.reinf.esocial.gov.br/schemas/evt4020PagtoBeneficiarioPJ/v2_01_01")]
public partial class ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgtoInfoPgtoExt : object, System.ComponentModel.INotifyPropertyChanged {
    
    private byte indNIFField;
    
    private string nifBenefField;
    
    private string relFontPgField;
    
    private string frmTributField;
    
    private ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgtoInfoPgtoExtEndExt endExtField;
    
    /// <remarks/>
    public byte indNIF {
        get {
            return this.indNIFField;
        }
        set {
            this.indNIFField = value;
            this.RaisePropertyChanged("indNIF");
        }
    }
    
    /// <remarks/>
    public string nifBenef {
        get {
            return this.nifBenefField;
        }
        set {
            this.nifBenefField = value;
            this.RaisePropertyChanged("nifBenef");
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
    public string relFontPg {
        get {
            return this.relFontPgField;
        }
        set {
            this.relFontPgField = value;
            this.RaisePropertyChanged("relFontPg");
        }
    }
    
    /// <remarks/>
    public string frmTribut {
        get {
            return this.frmTributField;
        }
        set {
            this.frmTributField = value;
            this.RaisePropertyChanged("frmTribut");
        }
    }
    
    /// <remarks/>
    public ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgtoInfoPgtoExtEndExt endExt {
        get {
            return this.endExtField;
        }
        set {
            this.endExtField = value;
            this.RaisePropertyChanged("endExt");
        }
    }
    
    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.reinf.esocial.gov.br/schemas/evt4020PagtoBeneficiarioPJ/v2_01_01")]
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
    public string dscLograd {
        get {
            return this.dscLogradField;
        }
        set {
            this.dscLogradField = value;
            this.RaisePropertyChanged("dscLograd");
        }
    }
    
    /// <remarks/>
    public string nrLograd {
        get {
            return this.nrLogradField;
        }
        set {
            this.nrLogradField = value;
            this.RaisePropertyChanged("nrLograd");
        }
    }
    
    /// <remarks/>
    public string complem {
        get {
            return this.complemField;
        }
        set {
            this.complemField = value;
            this.RaisePropertyChanged("complem");
        }
    }
    
    /// <remarks/>
    public string bairro {
        get {
            return this.bairroField;
        }
        set {
            this.bairroField = value;
            this.RaisePropertyChanged("bairro");
        }
    }
    
    /// <remarks/>
    public string cidade {
        get {
            return this.cidadeField;
        }
        set {
            this.cidadeField = value;
            this.RaisePropertyChanged("cidade");
        }
    }
    
    /// <remarks/>
    public string estado {
        get {
            return this.estadoField;
        }
        set {
            this.estadoField = value;
            this.RaisePropertyChanged("estado");
        }
    }
    
    /// <remarks/>
    public string codPostal {
        get {
            return this.codPostalField;
        }
        set {
            this.codPostalField = value;
            this.RaisePropertyChanged("codPostal");
        }
    }
    
    /// <remarks/>
    public string telef {
        get {
            return this.telefField;
        }
        set {
            this.telefField = value;
            this.RaisePropertyChanged("telef");
        }
    }
    
    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}
