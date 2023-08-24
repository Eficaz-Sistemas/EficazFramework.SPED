namespace EficazFramework.SPED.Schemas.EFD_Reinf;

/// <summary>
/// Exclusão de eventos
/// </summary>
[Serializable()]
public partial class R9000 : Evento, INotifyPropertyChanged
{
    private ReinfEvtExclusao evtExclusaoField;
    private SignatureType signatureField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public ReinfEvtExclusao evtExclusao
    {
        get => evtExclusaoField;

        set
        {
            evtExclusaoField = value;
            RaisePropertyChanged("evtExclusao");
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
        // Me.evtTabProcessoField.id = String.Format("ID{0}{1}{2}", If(Me.evtTabProcessoField?.ideContri?.tpInsc, "1"), If(Me.evtTabProcessoFields?.ideContri?.NumeroInscricaoTag, "00000000000000"), ReinfTimeStampUtils.GetTimeStampIDForEvent)
    }

    public override string ContribuinteCNPJ()
    {
        return evtExclusao.ideContri.nrInsc;
    }


    // IXmlSignableDocument Members
    public override string TagToSign => "Reinf";
    public override string TagId => "evtRetPF";
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
        return new XmlSerializer(typeof(R9000), new XmlRootAttribute("Reinf") { Namespace = $"http://www.reinf.esocial.gov.br/schemas/evtExclusao/{Versao}", IsNullable = false });
    }
}


/// <exclude />
public partial class ReinfEvtExclusao : object, INotifyPropertyChanged
{
    private ReinfEvtExclusaoIdeEvento ideEventoField;
    private ReinfEvtExclusaoIdeContri ideContriField;
    private ReinfEvtExclusaoInfoExclusao infoExclusaoField;
    private string idField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public ReinfEvtExclusaoIdeEvento ideEvento
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
    public ReinfEvtExclusaoIdeContri ideContri
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
    public ReinfEvtExclusaoInfoExclusao infoExclusao
    {
        get => infoExclusaoField;

        set
        {
            infoExclusaoField = value;
            RaisePropertyChanged("infoExclusao");
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


/// <summary>
/// Identificação Evento
/// </summary>
/// <exclude />
public partial class ReinfEvtExclusaoIdeEvento : object, INotifyPropertyChanged
{
    private Ambiente tpAmbField;
    private EmissorEvento procEmiField;
    private string verProcField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public Ambiente tpAmb
    {
        get => tpAmbField;

        set
        {
            tpAmbField = value;
            RaisePropertyChanged("tpAmb");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public EmissorEvento procEmi
    {
        get => procEmiField;

        set
        {
            procEmiField = value;
            RaisePropertyChanged("procEmi");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string verProc
    {
        get => verProcField;

        set
        {
            verProcField = value;
            RaisePropertyChanged("verProc");
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


/// <summary>
/// Identificação Contribuinte
/// </summary>
/// <exclude />
public partial class ReinfEvtExclusaoIdeContri : object, INotifyPropertyChanged
{
    private PersonalidadeJuridica tpInscField;
    private string nrInscField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public PersonalidadeJuridica tpInsc
    {
        get => tpInscField;

        set
        {
            tpInscField = value;
            RaisePropertyChanged("tpInsc");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nrInsc
    {
        get => nrInscField;

        set
        {
            nrInscField = value;
            RaisePropertyChanged("nrInsc");
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


/// <summary>
/// Identificação Evento (Exclusão)
/// </summary>
/// <exclude />
public partial class ReinfEvtExclusaoInfoExclusao : object, INotifyPropertyChanged
{
    private string tpEventoField;
    private string nrRecEvtField;
    private string perApurField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string tpEvento
    {
        get => tpEventoField;

        set
        {
            tpEventoField = value;
            RaisePropertyChanged("tpEvento");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nrRecEvt
    {
        get => nrRecEvtField;

        set
        {
            nrRecEvtField = value;
            RaisePropertyChanged("nrRecEvt");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string perApur
    {
        get => perApurField;

        set
        {
            perApurField = value;
            RaisePropertyChanged("perApur");
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