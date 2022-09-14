namespace EficazFramework.SPED.Schemas.EFD_Reinf.v2_01_01;

[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evtReabreEvPer/v2_01_01")]
[XmlRoot("Reinf", Namespace = "http://www.reinf.esocial.gov.br/schemas/evtReabreEvPer/v2_01_01", IsNullable = false)]
public partial class R2098 : IEfdReinfEvt, INotifyPropertyChanged
{
    private ReinfEvtReabreEvPer evtReabreEvPerField;
    private SignatureType signatureField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public ReinfEvtReabreEvPer evtReabreEvPer
    {
        get
        {
            return evtReabreEvPerField;
        }

        set
        {
            evtReabreEvPerField = value;
            RaisePropertyChanged("evtReabreEvPer");
        }
    }

    /// <remarks/>
    [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#", Order = 1)]
    public SignatureType Signature
    {
        get
        {
            return signatureField;
        }

        set
        {
            signatureField = value;
            RaisePropertyChanged("Signature");
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName)
    {
        var propertyChanged = PropertyChanged;
        if (propertyChanged != null)
        {
            propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public override XmlSerializer DefineSerializer()
    {
        return new XmlSerializer(typeof(R2098));
    }

    public override void GeraEventoID()
    {
        evtReabreEvPer.id = string.Format("ID{0}{1}{2}", (int)(evtReabreEvPer?.ideContri?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtReabreEvPer?.ideContri?.NumeroInscricaoTag() ?? "00000000000000", ReinfTimeStampUtils.GetTimeStampIDForEvent());
    }

    public override string ContribuinteCNPJ()
    {
        return evtReabreEvPer.ideContri.nrInsc;
    }
}


[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evtReabreEvPer/v2_01_01")]
public partial class ReinfEvtReabreEvPer : object, INotifyPropertyChanged
{
    private ReinfEvtIdeEventoPeriodicoR209x ideEventoField;
    private ReinfEvtIdeContri ideContriField;
    private string idField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public ReinfEvtIdeEventoPeriodicoR209x ideEvento
    {
        get
        {
            return ideEventoField;
        }

        set
        {
            ideEventoField = value;
            RaisePropertyChanged("ideEvento");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public ReinfEvtIdeContri ideContri
    {
        get
        {
            return ideContriField;
        }

        set
        {
            ideContriField = value;
            RaisePropertyChanged("ideContri");
        }
    }

    /// <remarks/>
    [XmlAttribute(DataType = "ID")]
    public string id
    {
        get
        {
            return idField;
        }

        set
        {
            idField = value;
            RaisePropertyChanged("id");
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName)
    {
        var propertyChanged = PropertyChanged;
        if (propertyChanged != null)
        {
            propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
