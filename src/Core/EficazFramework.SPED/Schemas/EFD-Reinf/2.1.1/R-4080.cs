namespace EficazFramework.SPED.Schemas.EFD_Reinf.v2_01_01;    

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.reinf.esocial.gov.br/schemas/evt4080RetencaoRecebimento/v2_01_01")]
[System.Xml.Serialization.XmlRootAttribute("Reinf", Namespace = "http://www.reinf.esocial.gov.br/schemas/evt4080RetencaoRecebimento/v2_01_01", IsNullable=false)]
public partial class R4080 : IEfdReinfEvt, System.ComponentModel.INotifyPropertyChanged {
    
    private ReinfEvtRetRec evtRetRecField;
    private SignatureType signatureField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=0)]
    public ReinfEvtRetRec evtRetRec {
        get {
            return this.evtRetRecField;
        }
        set {
            this.evtRetRecField = value;
            this.RaisePropertyChanged("evtRetRec");
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.w3.org/2000/09/xmldsig#", Order=1)]
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
    public override string TagId => "evtRetRecField";
    public override bool EmptyURI => true;
    public override bool SignAsSHA256 => true;


    // IEfdReinfEvt Members
    public override void GeraEventoID()
    {
        evtRetRecField.id = string.Format("ID{0}{1}{2}", (int)(evtRetRecField?.ideContri?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtRetRecField?.ideContri?.NumeroInscricaoTag() ?? "00000000000000", ReinfTimeStampUtils.GetTimeStampIDForEvent());
    }

    public override string ContribuinteCNPJ()
    {
        return evtRetRecField.ideContri.nrInsc;
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
        return new XmlSerializer(typeof(R4080));
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.reinf.esocial.gov.br/schemas/evt4080RetencaoRecebimento/v2_01_01")]
public partial class ReinfEvtRetRec : object, System.ComponentModel.INotifyPropertyChanged {
    
    private ReinfEvtIdeEvento_R40xx ideEventoField;
    private ReinfEvtIdeContri ideContriField;
    private ReinfEvtRetRecIdeEstab ideEstabField;
    private string idField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=0)]
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
    [System.Xml.Serialization.XmlElementAttribute(Order=1)]
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
    [System.Xml.Serialization.XmlElementAttribute(Order=2)]
    public ReinfEvtRetRecIdeEstab ideEstab {
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
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.reinf.esocial.gov.br/schemas/evt4080RetencaoRecebimento/v2_01_01")]
public partial class ReinfEvtRetRecIdeEstab : object, System.ComponentModel.INotifyPropertyChanged {
    
    private PersonalidadeJuridica tpInscEstabField;  
    private string nrInscEstabField;
    private ReinfEvtRetRecIdeEstabIdeFont ideFontField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=0)]
    public PersonalidadeJuridica tpInscEstab {
        get {
            return this.tpInscEstabField;
        }
        set {
            this.tpInscEstabField = value;
            this.RaisePropertyChanged("tpInscEstab");
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=1)]
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
    [System.Xml.Serialization.XmlElementAttribute(Order=2)]
    public ReinfEvtRetRecIdeEstabIdeFont ideFont {
        get {
            return this.ideFontField;
        }
        set {
            this.ideFontField = value;
            this.RaisePropertyChanged("ideFont");
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
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.reinf.esocial.gov.br/schemas/evt4080RetencaoRecebimento/v2_01_01")]
public partial class ReinfEvtRetRecIdeEstabIdeFont : object, System.ComponentModel.INotifyPropertyChanged {
    
    private string cnpjFontField;
    private List<ReinfEvtRetRecIdeEstabIdeFontIdeRend> ideRendField;
    
    /// <summary>
    /// CNPJ da Fonte Pagadora do Rendimento
    /// </summary>
    [System.Xml.Serialization.XmlElementAttribute(Order=0)]
    public string cnpjFont {
        get {
            return this.cnpjFontField;
        }
        set {
            this.cnpjFontField = value;
            this.RaisePropertyChanged("cnpjFont");
        }
    }
    
    /// <summary>
    /// Listagem de Identificação dos Rendimentos
    /// </summary>
    [System.Xml.Serialization.XmlElementAttribute("ideRend", Order=1)]
    public List<ReinfEvtRetRecIdeEstabIdeFontIdeRend> ideRend {
        get {
            return this.ideRendField;
        }
        set {
            this.ideRendField = value;
            this.RaisePropertyChanged("ideRend");
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

/// <summary>
/// Identificação do Rendimento
/// </summary>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.reinf.esocial.gov.br/schemas/evt4080RetencaoRecebimento/v2_01_01")]
public partial class ReinfEvtRetRecIdeEstabIdeFontIdeRend : object, System.ComponentModel.INotifyPropertyChanged {
    
    private string natRendField;
    private string observField;
    private List<ReinfEvtRetRecIdeEstabIdeFontIdeRendInfoRec> infoRecField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="integer", Order=0)]
    public string natRend {
        get {
            return this.natRendField;
        }
        set {
            this.natRendField = value;
            this.RaisePropertyChanged("natRend");
        }
    }

    /// <summary>
    /// Informações relativas ao recebimento do rendimento.
    /// </summary>
    [System.Xml.Serialization.XmlElementAttribute(Order=1)]
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
    [System.Xml.Serialization.XmlElementAttribute("infoRec", Order=2)]
    public List<ReinfEvtRetRecIdeEstabIdeFontIdeRendInfoRec> infoRec {
        get {
            return this.infoRecField;
        }
        set {
            this.infoRecField = value;
            this.RaisePropertyChanged("infoRec");
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

/// <summary>
/// Informações relativas ao recebimento do rendimento.
/// </summary>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.reinf.esocial.gov.br/schemas/evt4080RetencaoRecebimento/v2_01_01")]
public partial class ReinfEvtRetRecIdeEstabIdeFontIdeRendInfoRec : object, System.ComponentModel.INotifyPropertyChanged {
    
    private System.DateTime dtFGField;
    private string vlrBrutoField;
    private string vlrBaseIRField; 
    private string vlrIRField;
    private List<ReinfEvtRetRecIdeEstabIdeFontIdeRendInfoRecInfoProcRet> infoProcRetField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("dtFG", DataType ="date", Order=0)]
    public System.DateTime DataFatoGerador {
        get {
            return this.dtFGField;
        }
        set {
            this.dtFGField = value;
            this.RaisePropertyChanged("DataFatoGerador");
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=1)]
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
    [System.Xml.Serialization.XmlElementAttribute(Order=2)]
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
    [System.Xml.Serialization.XmlElementAttribute(Order=3)]
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
    [System.Xml.Serialization.XmlElementAttribute("infoProcRet", Order=4)]
    public List<ReinfEvtRetRecIdeEstabIdeFontIdeRendInfoRecInfoProcRet> infoProcRet {
        get {
            return this.infoProcRetField;
        }
        set {
            this.infoProcRetField = value;
            this.RaisePropertyChanged("infoProcRet");
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
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.reinf.esocial.gov.br/schemas/evt4080RetencaoRecebimento/v2_01_01")]
public partial class ReinfEvtRetRecIdeEstabIdeFontIdeRendInfoRecInfoProcRet : object, System.ComponentModel.INotifyPropertyChanged {
    
    private TipoProcesso tpProcRetField;
    private string nrProcRetField;
    private string codSuspField;
    private string vlrBaseSuspIRField;
    private string vlrNIRField;
    private string vlrDepIRField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=0)]
    public TipoProcesso tpProcRet {
        get {
            return this.tpProcRetField;
        }
        set {
            this.tpProcRetField = value;
            this.RaisePropertyChanged("tpProcRet");
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=1)]
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
    [System.Xml.Serialization.XmlElementAttribute(Order=2)]
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
    [System.Xml.Serialization.XmlElementAttribute(Order=3)]
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
    [System.Xml.Serialization.XmlElementAttribute(Order=4)]
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
    [System.Xml.Serialization.XmlElementAttribute(Order=5)]
    public string vlrDepIR {
        get {
            return this.vlrDepIRField;
        }
        set {
            this.vlrDepIRField = value;
            this.RaisePropertyChanged("vlrDepIR");
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
