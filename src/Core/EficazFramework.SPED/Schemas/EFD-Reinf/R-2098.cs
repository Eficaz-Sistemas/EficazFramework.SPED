namespace EficazFramework.SPED.Schemas.EFD_Reinf;

/// <summary>
/// Reabertura dos eventos da série R-2000
/// </summary>
[Serializable()]
public partial class R2098 : Evento, INotifyPropertyChanged
{
    private ReinfEvtReabreEvPer evtReabreEvPerField;
    private SignatureType signatureField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public ReinfEvtReabreEvPer evtReabreEvPer
    {
        get => evtReabreEvPerField;

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
        get => signatureField;

        set
        {
            signatureField = value;
            RaisePropertyChanged("Signature");
        }
    }


    // Evento Members
    public override void GeraEventoID()
    {
        evtReabreEvPer.id = string.Format("ID{0}{1}{2}", (int)(evtReabreEvPer?.ideContri?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtReabreEvPer?.ideContri?.NumeroInscricaoTag() ?? "00000000000000", ReinfTimeStampUtils.GetTimeStampIDForEvent());
    }

    public override string ContribuinteCNPJ()
    {
        return evtReabreEvPer.ideContri.nrInsc;
    }


    // IXmlSignableDocument Members
    public override string TagToSign => "Reinf";
    public override string TagId => "evtReabreEvPer";
    public override bool EmptyURI => true;
    public override bool SignAsSHA256 => true;


    // PropertyChanged Members
    public event PropertyChangedEventHandler PropertyChanged;
    protected void RaisePropertyChanged(string propertyName)
    {
        var propertyChanged = PropertyChanged;
        if (propertyChanged != null)
        {
            propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }


    // Serialization Members
    public override XmlSerializer DefineSerializer()
    {
        return new XmlSerializer(typeof(R2098), new XmlRootAttribute("Reinf") { Namespace = $"http://www.reinf.esocial.gov.br/schemas/evtReabreEvPer/{Versao}", IsNullable = false });
    }
}


/// <exclude />
public partial class ReinfEvtReabreEvPer : object, INotifyPropertyChanged
{
    private IdentificacaoEventoFechamento ideEventoField;
    private IdentificacaoContribuinte ideContriField;
    private string idField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public IdentificacaoEventoFechamento ideEvento
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
    [XmlAttribute(DataType = "ID")]
    public string id
    {
        get => idField;

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
