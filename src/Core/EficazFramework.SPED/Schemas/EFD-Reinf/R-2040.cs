namespace EficazFramework.SPED.Schemas.EFD_Reinf;

/// <summary>
/// Recursos repassados para associação desportiva
/// </summary>
[Serializable()]
public partial class R2040 : Evento, INotifyPropertyChanged
{
    private ReinfEvtAssocDespRep evtAssocDespRepField;
    private SignatureType signatureField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public ReinfEvtAssocDespRep evtAssocDespRep
    {
        get => evtAssocDespRepField;

        set
        {
            evtAssocDespRepField = value;
            RaisePropertyChanged("evtAssocDespRep");
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
        evtAssocDespRepField.id = string.Format("ID{0}{1}{2}", (evtAssocDespRepField?.ideContri?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtAssocDespRepField?.ideContri?.NumeroInscricaoTag() ?? "00000000000000", ReinfTimeStampUtils.GetTimeStampIDForEvent());
    }

    public override string ContribuinteCNPJ()
    {
        return evtAssocDespRep.ideContri.nrInsc;
    }


    // IXmlSignableDocument Members
    public override string TagToSign => "Reinf";
    public override string TagId => "evtAssocDespRep";
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
        return new XmlSerializer(typeof(R2040), new XmlRootAttribute("Reinf") { Namespace = $"http://www.reinf.esocial.gov.br/schemas/evtRecursoRepassadoAssociacao/{Versao}", IsNullable = false });
    }
}


/// <exclude />
public partial class ReinfEvtAssocDespRep : object, INotifyPropertyChanged
{
    private IdentificacaoEventoPeriodico ideEventoField;
    private ReinfEvtAssocDespRepIdeContri ideContriField;
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
    public ReinfEvtAssocDespRepIdeContri ideContri
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


/// <exclude />
public partial class ReinfEvtAssocDespRepIdeContri : object, INotifyPropertyChanged
{
    private PersonalidadeJuridica tpInscField;
    private string nrInscField;
    private ReinfEvtAssocDespRepIdeContriIdeEstab ideEstabField;

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

    /// <remarks/>
    [XmlElement(Order = 2)]
    public ReinfEvtAssocDespRepIdeContriIdeEstab ideEstab
    {
        get => ideEstabField;

        set
        {
            ideEstabField = value;
            RaisePropertyChanged("ideEstab");
        }
    }

    public string NumeroInscricaoTag()
    {
        return Extensions.String.ToFixedLenghtString(nrInsc, 14, Extensions.Alignment.Left, "0");
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


/// <exclude />
public partial class ReinfEvtAssocDespRepIdeContriIdeEstab : object, INotifyPropertyChanged
{
    private PersonalidadeJuridica tpInscEstabField;
    private string nrInscEstabField;
    private ReinfEvtAssocDespRepIdeContriIdeEstabRecursosRep[] recursosRepField;

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
    [XmlElement("recursosRep", Order = 2)]
    public ReinfEvtAssocDespRepIdeContriIdeEstabRecursosRep[] recursosRep
    {
        get => recursosRepField;

        set
        {
            recursosRepField = value;
            RaisePropertyChanged("recursosRep");
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


/// <exclude />
public partial class ReinfEvtAssocDespRepIdeContriIdeEstabRecursosRep : object, INotifyPropertyChanged
{
    private string cnpjAssocDespField;
    private string vlrTotalRepField;
    private string vlrTotalRetField;
    private string vlrTotalNRetField;
    private ReinfEvtAssocDespRepIdeContriIdeEstabRecursosRepInfoRecurso[] infoRecursoField;
    private ReinfEvtAssocDespRepIdeContriIdeEstabRecursosRepInfoProc[] infoProcField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string cnpjAssocDesp
    {
        get => cnpjAssocDespField;

        set
        {
            cnpjAssocDespField = value;
            RaisePropertyChanged("cnpjAssocDesp");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string vlrTotalRep
    {
        get => vlrTotalRepField;

        set
        {
            vlrTotalRepField = value;
            RaisePropertyChanged("vlrTotalRep");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string vlrTotalRet
    {
        get => vlrTotalRetField;

        set
        {
            vlrTotalRetField = value;
            RaisePropertyChanged("vlrTotalRet");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string vlrTotalNRet
    {
        get => vlrTotalNRetField;

        set
        {
            vlrTotalNRetField = value;
            RaisePropertyChanged("vlrTotalNRet");
        }
    }

    /// <remarks/>
    [XmlElement("infoRecurso", Order = 4)]
    public ReinfEvtAssocDespRepIdeContriIdeEstabRecursosRepInfoRecurso[] infoRecurso
    {
        get => infoRecursoField;

        set
        {
            infoRecursoField = value;
            RaisePropertyChanged("infoRecurso");
        }
    }

    /// <remarks/>
    [XmlElement("infoProc", Order = 5)]
    public ReinfEvtAssocDespRepIdeContriIdeEstabRecursosRepInfoProc[] infoProc
    {
        get => infoProcField;

        set
        {
            infoProcField = value;
            RaisePropertyChanged("infoProc");
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


/// <exclude />
public partial class ReinfEvtAssocDespRepIdeContriIdeEstabRecursosRepInfoRecurso : object, INotifyPropertyChanged
{
    private string tpRepasseField;
    private string descRecursoField;
    private string vlrBrutoField;
    private string vlrRetApurField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string tpRepasse
    {
        get => tpRepasseField;

        set
        {
            tpRepasseField = value;
            RaisePropertyChanged("tpRepasse");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string descRecurso
    {
        get => descRecursoField;

        set
        {
            descRecursoField = value;
            RaisePropertyChanged("descRecurso");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
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
    [XmlElement(Order = 3)]
    public string vlrRetApur
    {
        get => vlrRetApurField;

        set
        {
            vlrRetApurField = value;
            RaisePropertyChanged("vlrRetApur");
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


/// <exclude />
public partial class ReinfEvtAssocDespRepIdeContriIdeEstabRecursosRepInfoProc : object, INotifyPropertyChanged
{
    private TipoProcesso tpProcField;
    private string nrProcField;
    private string codSuspField;
    private string vlrNRetField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public TipoProcesso tpProc
    {
        get => tpProcField;

        set
        {
            tpProcField = value;
            RaisePropertyChanged("tpProc");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
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
    public string vlrNRet
    {
        get => vlrNRetField;

        set
        {
            vlrNRetField = value;
            RaisePropertyChanged("vlrNRet");
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