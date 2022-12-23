namespace EficazFramework.SPED.Schemas.EFD_Reinf;

/// <summary>
/// Pagamentos/créditos a beneficiários não identificados
/// </summary>
[System.SerializableAttribute()]
public partial class R4040 : IEfdReinfEvt, System.ComponentModel.INotifyPropertyChanged {
    
    private ReinfEvtBenefNId evtBenefNIdField;
    private SignatureType signatureField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=0)]
    public ReinfEvtBenefNId evtBenefNId {
        get {
            return this.evtBenefNIdField;
        }
        set {
            this.evtBenefNIdField = value;
            this.RaisePropertyChanged("evtBenefNId");
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
    public override string TagId => "ReinfEvtBenefNId";
    public override bool EmptyURI => true;
    public override bool SignAsSHA256 => true;


    // IEfdReinfEvt Members
    public override void GeraEventoID()
    {
        evtBenefNId.id = string.Format("ID{0}{1}{2}", (int)(evtBenefNId?.ideContri?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtBenefNId?.ideContri?.NumeroInscricaoTag() ?? "00000000000000", ReinfTimeStampUtils.GetTimeStampIDForEvent());
    }

    public override string ContribuinteCNPJ()
    {
        return evtBenefNId.ideContri.nrInsc;
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
        return new XmlSerializer(typeof(R4040), new XmlRootAttribute("Reinf") { Namespace = $"http://www.reinf.esocial.gov.br/schemas/evt4040PagtoBenefNaoIdentificado/{Versao}", IsNullable = false });
    }
}

/// <exclude />
public partial class ReinfEvtBenefNId : object, System.ComponentModel.INotifyPropertyChanged {
    
    private ReinfEvtIdeEvento_R40xx ideEventoField;
    private ReinfEvtIdeContri ideContriField;
    private ReinfEvtBenefNIdIdeEstab ideEstabField;
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
    public ReinfEvtBenefNIdIdeEstab ideEstab {
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

/// <exclude />
public partial class ReinfEvtBenefNIdIdeEstab : object, System.ComponentModel.INotifyPropertyChanged {
    
    private PersonalidadeJuridica tpInscEstabField;
    private string nrInscEstabField;
    private List<ReinfEvtBenefNIdIdeEstabIdeNat> ideNatField;
    
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
    [System.Xml.Serialization.XmlElementAttribute("ideNat", Order=2)]
    public List<ReinfEvtBenefNIdIdeEstabIdeNat> ideNat {
        get {
            return this.ideNatField;
        }
        set {
            this.ideNatField = value;
            this.RaisePropertyChanged("ideNat");
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

/// <exclude />
public partial class ReinfEvtBenefNIdIdeEstabIdeNat : object, System.ComponentModel.INotifyPropertyChanged {
    
    private int natRendField;
    private List<ReinfEvtBenefNIdIdeEstabIdeNatInfoPgto> infoPgtoField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=0)]
    public int natRend {
        get {
            return this.natRendField;
        }
        set {
            this.natRendField = value;
            this.RaisePropertyChanged("natRend");
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("infoPgto", Order=1)]
    public List<ReinfEvtBenefNIdIdeEstabIdeNatInfoPgto> infoPgto {
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

/// <exclude />
public partial class ReinfEvtBenefNIdIdeEstabIdeNatInfoPgto : object, System.ComponentModel.INotifyPropertyChanged {
    
    private System.DateTime dtFGField;
    private string vlrLiqField;
    private string vlrBaseIRField;
    private string vlrIRField;
    private string descrField;
    private List<ReinfEvtBenefNIdIdeEstabIdeNatInfoPgtoInfoProcRet> infoProcRetField;

    /// <summary>
    /// Informar a data do fato gerador, no formato AAAA-MM-DD. <br/><br/>
    /// <b>Validação: </b>A data informada deve estar compreendida no período de apuração 
    /// ao qual se refere o arquivo, conforme informado em(perApur}, no formato AAAA-MM-DD.
    /// </summary>
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
    
    /// <summary>
    /// Valor líquido do Pagamento
    /// </summary>
    [System.Xml.Serialization.XmlElementAttribute(Order=1)]
    public string vlrLiq {
        get {
            return this.vlrLiqField;
        }
        set {
            this.vlrLiqField = value;
            this.RaisePropertyChanged("vlrLiq");
        }
    }

    /// <summary>
    /// Valor reajustado, considerado como valor da base de cálculo do IRRF.<br/><br/>
    /// <b>Validação: </b> Deve corresponder a (<see cref="vlrLiq"/> / 0,65).
    /// </summary>
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
    
    /// <summary>
    /// Descrição do Pagamento
    /// </summary>
    [System.Xml.Serialization.XmlElementAttribute(Order=4)]
    public string descr {
        get {
            return this.descrField;
        }
        set {
            this.descrField = value;
            this.RaisePropertyChanged("descr");
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("infoProcRet", Order=5)]
    public List<ReinfEvtBenefNIdIdeEstabIdeNatInfoPgtoInfoProcRet> infoProcRet {
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

/// <exclude />
public partial class ReinfEvtBenefNIdIdeEstabIdeNatInfoPgtoInfoProcRet : object, System.ComponentModel.INotifyPropertyChanged {
    
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
