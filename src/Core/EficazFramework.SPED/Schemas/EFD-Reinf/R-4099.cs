namespace EficazFramework.SPED.Schemas.EFD_Reinf;

/// <summary>
/// Fechamento/reabertura dos eventos da série R-4000
/// </summary>
[System.SerializableAttribute()]
public partial class R4099 : IEfdReinfEvt, System.ComponentModel.INotifyPropertyChanged {
    
    private ReinfEvtFech evtFechField;
    private SignatureType signatureField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=0)]
    public ReinfEvtFech evtFech {
        get {
            return this.evtFechField;
        }
        set {
            this.evtFechField = value;
            this.RaisePropertyChanged("evtFech");
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
    public override string TagId => "evtFechField";
    public override bool EmptyURI => true;
    public override bool SignAsSHA256 => true;


    // IEfdReinfEvt Members
    public override void GeraEventoID()
    {
        evtFechField.id = string.Format("ID{0}{1}{2}", (int)(evtFechField?.ideContri?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtFechField?.ideContri?.NumeroInscricaoTag() ?? "00000000000000", ReinfTimeStampUtils.GetTimeStampIDForEvent());
    }

    public override string ContribuinteCNPJ()
    {
        return evtFechField.ideContri.nrInsc;
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
        return new XmlSerializer(typeof(R4099), new XmlRootAttribute("Reinf") { Namespace = $"http://www.reinf.esocial.gov.br/schemas/evt4099FechamentoDirf/{Versao}", IsNullable = false });
    }

}

/// <exclude />
public partial class ReinfEvtFech : object, System.ComponentModel.INotifyPropertyChanged {
    
    private ReinfEvtIdeEventoPeriodicoFechamento ideEventoField;
    private ReinfEvtIdeContri ideContriField;
    private ReinfEvtFechaEvPerIdeRespInf ideRespInfField;
    private ReinfEvtFechInfoFech infoFechField;
    private string idField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=0)]
    public ReinfEvtIdeEventoPeriodicoFechamento ideEvento {
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
    public ReinfEvtFechaEvPerIdeRespInf ideRespInf {
        get {
            return this.ideRespInfField;
        }
        set {
            this.ideRespInfField = value;
            this.RaisePropertyChanged("ideRespInf");
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=3)]
    public ReinfEvtFechInfoFech infoFech {
        get {
            return this.infoFechField;
        }
        set {
            this.infoFechField = value;
            this.RaisePropertyChanged("infoFech");
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
public partial class ReinfEvtFechInfoFech : object, System.ComponentModel.INotifyPropertyChanged {
    
    private IndicadorFechamentoReabertura fechRetField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=0)]
    public IndicadorFechamentoReabertura fechRet {
        get {
            return this.fechRetField;
        }
        set {
            this.fechRetField = value;
            this.RaisePropertyChanged("fechRet");
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
