namespace EficazFramework.SPED.Schemas.EFD_Reinf;

/// <summary>
/// Contribuição previdenciária sobre a receita bruta – CPRB
/// </summary>
[Serializable()]
public partial class R2060 : Evento, INotifyPropertyChanged
{
    private ReinfEvtCPRB evtCPRBField;
    private SignatureType signatureField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public ReinfEvtCPRB evtCPRB
    {
        get => evtCPRBField;

        set
        {
            evtCPRBField = value;
            RaisePropertyChanged("evtCPRB");
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
        return evtCPRB.ideContri.nrInsc;
    }


    // IXmlSignableDocument Members
    public override string TagToSign => "Reinf";
    public override string TagId => "evtCPRB";
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
        return new XmlSerializer(typeof(R2060), new XmlRootAttribute("Reinf") { Namespace = $"http://www.reinf.esocial.gov.br/schemas/evtInfoCPRB/{Versao}", IsNullable = false });
    }
}


/// <exclude />
public partial class ReinfEvtCPRB : object, INotifyPropertyChanged
{
    private IdentificacaoEventoR2000 ideEventoField;
    private IdentificacaoContribuinte ideContriField;
    private ReinfEvtCPRBInfoCPRB infoCPRBField;
    private string idField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public IdentificacaoEventoR2000 ideEvento
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
    public ReinfEvtCPRBInfoCPRB infoCPRB
    {
        get => infoCPRBField;

        set
        {
            infoCPRBField = value;
            RaisePropertyChanged("infoCPRB");
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
public partial class ReinfEvtCPRBInfoCPRB : object, INotifyPropertyChanged
{
    private ReinfEvtCPRBInfoCPRBIdeEstab ideEstabField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public ReinfEvtCPRBInfoCPRBIdeEstab ideEstab
    {
        get => ideEstabField;

        set
        {
            ideEstabField = value;
            RaisePropertyChanged("ideEstab");
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
public partial class ReinfEvtCPRBInfoCPRBIdeEstab : object, INotifyPropertyChanged
{
    private PersonalidadeJuridica tpInscEstabField;
    private string nrInscEstabField;
    private string vlrRecBrutaTotalField;
    private string vlrCPApurTotalField;
    private string vlrCPRBSuspTotalField;
    private ReinfEvtCPRBInfoCPRBIdeEstabTipoCod[] tipoCodField;

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
    public string vlrRecBrutaTotal
    {
        get => vlrRecBrutaTotalField;

        set
        {
            vlrRecBrutaTotalField = value;
            RaisePropertyChanged("vlrRecBrutaTotal");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string vlrCPApurTotal
    {
        get => vlrCPApurTotalField;

        set
        {
            vlrCPApurTotalField = value;
            RaisePropertyChanged("vlrCPApurTotal");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public string vlrCPRBSuspTotal
    {
        get => vlrCPRBSuspTotalField;

        set
        {
            vlrCPRBSuspTotalField = value;
            RaisePropertyChanged("vlrCPRBSuspTotal");
        }
    }

    /// <remarks/>
    [XmlElement("tipoCod", Order = 5)]
    public ReinfEvtCPRBInfoCPRBIdeEstabTipoCod[] tipoCod
    {
        get => tipoCodField;

        set
        {
            tipoCodField = value;
            RaisePropertyChanged("tipoCod");
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
public partial class ReinfEvtCPRBInfoCPRBIdeEstabTipoCod : object, INotifyPropertyChanged
{
    private string codAtivEconField;
    private string vlrRecBrutaAtivField;
    private string vlrExcRecBrutaField;
    private string vlrAdicRecBrutaField;
    private string vlrBcCPRBField;
    private string vlrCPRBapurField;
    private string observField;
    private ReinfEvtCPRBInfoCPRBIdeEstabTipoCodTipoAjuste[] tipoAjusteField;
    private ReinfEvtCPRBInfoCPRBIdeEstabTipoCodInfoProc[] infoProcField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string codAtivEcon
    {
        get => codAtivEconField;

        set
        {
            codAtivEconField = value;
            RaisePropertyChanged("codAtivEcon");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string vlrRecBrutaAtiv
    {
        get => vlrRecBrutaAtivField;

        set
        {
            vlrRecBrutaAtivField = value;
            RaisePropertyChanged("vlrRecBrutaAtiv");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string vlrExcRecBruta
    {
        get => vlrExcRecBrutaField;

        set
        {
            vlrExcRecBrutaField = value;
            RaisePropertyChanged("vlrExcRecBruta");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string vlrAdicRecBruta
    {
        get => vlrAdicRecBrutaField;

        set
        {
            vlrAdicRecBrutaField = value;
            RaisePropertyChanged("vlrAdicRecBruta");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public string vlrBcCPRB
    {
        get => vlrBcCPRBField;

        set
        {
            vlrBcCPRBField = value;
            RaisePropertyChanged("vlrBcCPRB");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 5)]
    public string vlrCPRBapur
    {
        get => vlrCPRBapurField;

        set
        {
            vlrCPRBapurField = value;
            RaisePropertyChanged("vlrCPRBapur");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 6)]
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
    [XmlElement("tipoAjuste", Order = 7)]
    public ReinfEvtCPRBInfoCPRBIdeEstabTipoCodTipoAjuste[] tipoAjuste
    {
        get => tipoAjusteField;

        set
        {
            tipoAjusteField = value;
            RaisePropertyChanged("tipoAjuste");
        }
    }

    /// <remarks/>
    [XmlElement("infoProc", Order = 8)]
    public ReinfEvtCPRBInfoCPRBIdeEstabTipoCodInfoProc[] infoProc
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
public partial class ReinfEvtCPRBInfoCPRBIdeEstabTipoCodTipoAjuste : object, INotifyPropertyChanged
{
    private TipoAjusteContribuicao tpAjusteField;
    private string codAjusteField;
    private string vlrAjusteField;
    private string descAjusteField;
    private string dtAjusteField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public TipoAjusteContribuicao tpAjuste
    {
        get => tpAjusteField;

        set
        {
            tpAjusteField = value;
            RaisePropertyChanged("tpAjuste");
        }
    }

    /// <remarks/>
    [XmlElement(DataType = "integer", Order = 1)]
    public string codAjuste
    {
        get => codAjusteField;

        set
        {
            codAjusteField = value;
            RaisePropertyChanged("codAjuste");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string vlrAjuste
    {
        get => vlrAjusteField;

        set
        {
            vlrAjusteField = value;
            RaisePropertyChanged("vlrAjuste");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string descAjuste
    {
        get => descAjusteField;

        set
        {
            descAjusteField = value;
            RaisePropertyChanged("descAjuste");
        }
    }

    /// <remarks/>
    [XmlElement(DataType = "gYearMonth", Order = 4)]
    public string dtAjuste
    {
        get => dtAjusteField;

        set
        {
            dtAjusteField = value;
            RaisePropertyChanged("dtAjuste");
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
public partial class ReinfEvtCPRBInfoCPRBIdeEstabTipoCodInfoProc : object, INotifyPropertyChanged
{
    private TipoProcesso tpProcField;
    private string nrProcField;
    private string codSuspField;
    private string vlrCPRBSuspField;

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
    public string vlrCPRBSusp
    {
        get => vlrCPRBSuspField;

        set
        {
            vlrCPRBSuspField = value;
            RaisePropertyChanged("vlrCPRBSusp");
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