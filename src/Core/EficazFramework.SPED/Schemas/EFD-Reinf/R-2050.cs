namespace EficazFramework.SPED.Schemas.EFD_Reinf;

/// <summary>
/// Comercialização da produção p/ produtor rural PJ/agroindústria
/// </summary>
[Serializable()]
public partial class R2050 : IEfdReinfEvt, INotifyPropertyChanged
{
    private ReinfEvtComProd evtComProdField;
    private SignatureType signatureField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public ReinfEvtComProd evtComProd
    {
        get
        {
            return evtComProdField;
        }

        set
        {
            evtComProdField = value;
            RaisePropertyChanged("evtComProd");
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


    // IEfdReinfEvt Members
    public override void GeraEventoID()
    {
        // Me.evtTabProcessoField.id = String.Format("ID{0}{1}{2}", If(Me.evtTabProcessoField?.ideContri?.tpInsc, "1"), If(Me.evtTabProcessoFields?.ideContri?.NumeroInscricaoTag, "00000000000000"), ReinfTimeStampUtils.GetTimeStampIDForEvent)
    }

    public override string ContribuinteCNPJ()
    {
        return evtComProd.ideContri.nrInsc;
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
        return new XmlSerializer(typeof(R2050), new XmlRootAttribute("Reinf") { Namespace = $"http://www.reinf.esocial.gov.br/schemas/evtInfoProdRural/{Versao}", IsNullable = false });
    }
}


/// <exclude />
public partial class ReinfEvtComProd : object, INotifyPropertyChanged
{
    private ReinfEvtComProdIdeEvento ideEventoField;
    private ReinfEvtComProdIdeContri ideContriField;
    private ReinfEvtComProdInfoComProd infoComProdField;
    private string idField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public ReinfEvtComProdIdeEvento ideEvento
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
    public ReinfEvtComProdIdeContri ideContri
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
    [XmlElement(Order = 2)]
    public ReinfEvtComProdInfoComProd infoComProd
    {
        get
        {
            return infoComProdField;
        }

        set
        {
            infoComProdField = value;
            RaisePropertyChanged("infoComProd");
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


/// <exclude />
public partial class ReinfEvtComProdIdeEvento : object, INotifyPropertyChanged
{
    private IndicadorRetificacao indRetifField;
    private string nrReciboField;
    private string perApurField;
    private Ambiente tpAmbField;
    private EmissorEvento procEmiField;
    private string verProcField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public IndicadorRetificacao indRetif
    {
        get
        {
            return indRetifField;
        }

        set
        {
            indRetifField = value;
            RaisePropertyChanged("indRetif");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nrRecibo
    {
        get
        {
            return nrReciboField;
        }

        set
        {
            nrReciboField = value;
            RaisePropertyChanged("nrRecibo");
        }
    }

    /// <remarks/>
    [XmlElement(DataType = "gYearMonth", Order = 2)]
    public string perApur
    {
        get
        {
            return perApurField;
        }

        set
        {
            perApurField = value;
            RaisePropertyChanged("perApur");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public Ambiente tpAmb
    {
        get
        {
            return tpAmbField;
        }

        set
        {
            tpAmbField = value;
            RaisePropertyChanged("tpAmb");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public EmissorEvento procEmi
    {
        get
        {
            return procEmiField;
        }

        set
        {
            procEmiField = value;
            RaisePropertyChanged("procEmi");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 5)]
    public string verProc
    {
        get
        {
            return verProcField;
        }

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


/// <exclude />
public partial class ReinfEvtComProdIdeContri : object, INotifyPropertyChanged
{
    private PersonalidadeJuridica tpInscField;
    private string nrInscField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public PersonalidadeJuridica tpInsc
    {
        get
        {
            return tpInscField;
        }

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
        get
        {
            return nrInscField;
        }

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


/// <exclude />
public partial class ReinfEvtComProdInfoComProd : object, INotifyPropertyChanged
{
    private ReinfEvtComProdInfoComProdIdeEstab ideEstabField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public ReinfEvtComProdInfoComProdIdeEstab ideEstab
    {
        get
        {
            return ideEstabField;
        }

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
public partial class ReinfEvtComProdInfoComProdIdeEstab : object, INotifyPropertyChanged
{
    private PersonalidadeJuridica tpInscEstabField;
    private string nrInscEstabField;
    private string vlrRecBrutaTotalField;
    private string vlrCPApurField;
    private string vlrRatApurField;
    private string vlrSenarApurField;
    private string vlrCPSuspTotalField;
    private string vlrRatSuspTotalField;
    private string vlrSenarSuspTotalField;
    private ReinfEvtComProdInfoComProdIdeEstabTipoCom[] tipoComField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public PersonalidadeJuridica tpInscEstab
    {
        get
        {
            return tpInscEstabField;
        }

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
        get
        {
            return nrInscEstabField;
        }

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
        get
        {
            return vlrRecBrutaTotalField;
        }

        set
        {
            vlrRecBrutaTotalField = value;
            RaisePropertyChanged("vlrRecBrutaTotal");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string vlrCPApur
    {
        get
        {
            return vlrCPApurField;
        }

        set
        {
            vlrCPApurField = value;
            RaisePropertyChanged("vlrCPApur");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public string vlrRatApur
    {
        get
        {
            return vlrRatApurField;
        }

        set
        {
            vlrRatApurField = value;
            RaisePropertyChanged("vlrRatApur");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 5)]
    public string vlrSenarApur
    {
        get
        {
            return vlrSenarApurField;
        }

        set
        {
            vlrSenarApurField = value;
            RaisePropertyChanged("vlrSenarApur");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 6)]
    public string vlrCPSuspTotal
    {
        get
        {
            return vlrCPSuspTotalField;
        }

        set
        {
            vlrCPSuspTotalField = value;
            RaisePropertyChanged("vlrCPSuspTotal");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 7)]
    public string vlrRatSuspTotal
    {
        get
        {
            return vlrRatSuspTotalField;
        }

        set
        {
            vlrRatSuspTotalField = value;
            RaisePropertyChanged("vlrRatSuspTotal");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 8)]
    public string vlrSenarSuspTotal
    {
        get
        {
            return vlrSenarSuspTotalField;
        }

        set
        {
            vlrSenarSuspTotalField = value;
            RaisePropertyChanged("vlrSenarSuspTotal");
        }
    }

    /// <remarks/>
    [XmlElement("tipoCom", Order = 9)]
    public ReinfEvtComProdInfoComProdIdeEstabTipoCom[] tipoCom
    {
        get
        {
            return tipoComField;
        }

        set
        {
            tipoComField = value;
            RaisePropertyChanged("tipoCom");
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
public partial class ReinfEvtComProdInfoComProdIdeEstabTipoCom : object, INotifyPropertyChanged
{
    private IndicadorContribuicaoProd indComField;
    private string vlrRecBrutaField;
    private ReinfEvtComProdInfoComProdIdeEstabTipoComInfoProc[] infoProcField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public IndicadorContribuicaoProd indCom
    {
        get
        {
            return indComField;
        }

        set
        {
            indComField = value;
            RaisePropertyChanged("indCom");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string vlrRecBruta
    {
        get
        {
            return vlrRecBrutaField;
        }

        set
        {
            vlrRecBrutaField = value;
            RaisePropertyChanged("vlrRecBruta");
        }
    }

    /// <remarks/>
    [XmlElement("infoProc", Order = 2)]
    public ReinfEvtComProdInfoComProdIdeEstabTipoComInfoProc[] infoProc
    {
        get
        {
            return infoProcField;
        }

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
public partial class ReinfEvtComProdInfoComProdIdeEstabTipoComInfoProc : object, INotifyPropertyChanged
{
    private TipoProcesso tpProcField;
    private string nrProcField;
    private string codSuspField;
    private string vlrCPSuspField;
    private string vlrRatSuspField;
    private string vlrSenarSuspField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public TipoProcesso tpProc
    {
        get
        {
            return tpProcField;
        }

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
        get
        {
            return nrProcField;
        }

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
        get
        {
            return codSuspField;
        }

        set
        {
            codSuspField = value;
            RaisePropertyChanged("codSusp");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string vlrCPSusp
    {
        get
        {
            return vlrCPSuspField;
        }

        set
        {
            vlrCPSuspField = value;
            RaisePropertyChanged("vlrCPSusp");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public string vlrRatSusp
    {
        get
        {
            return vlrRatSuspField;
        }

        set
        {
            vlrRatSuspField = value;
            RaisePropertyChanged("vlrRatSusp");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 5)]
    public string vlrSenarSusp
    {
        get
        {
            return vlrSenarSuspField;
        }

        set
        {
            vlrSenarSuspField = value;
            RaisePropertyChanged("vlrSenarSusp");
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