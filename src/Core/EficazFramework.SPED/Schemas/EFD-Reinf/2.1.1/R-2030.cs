namespace EficazFramework.SPED.Schemas.EFD_Reinf.v2_01_01;

[Serializable()]
public partial class R2030 : IEfdReinfEvt, INotifyPropertyChanged
{
    private ReinfEvtAssocDespRec evtAssocDespRecField;
    private SignatureType signatureField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public ReinfEvtAssocDespRec evtAssocDespRec
    {
        get
        {
            return evtAssocDespRecField;
        }

        set
        {
            evtAssocDespRecField = value;
            RaisePropertyChanged("evtAssocDespRec");
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
        return evtAssocDespRec.ideContri.nrInsc;
    }


    // IXmlSignableDocument Members
    public override string TagToSign => "Reinf";
    public override string TagId => "evtAssocDespRec";
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
        return new XmlSerializer(typeof(R2030), new XmlRootAttribute("Reinf") { Namespace = $"http://www.reinf.esocial.gov.br/schemas/evtRecursoRecebidoAssociacao/{Versao}", IsNullable = false });
    }
}


public partial class ReinfEvtAssocDespRec : object, INotifyPropertyChanged
{
    private ReinfEvtAssocDespRecIdeEvento ideEventoField;
    private ReinfEvtAssocDespRecIdeContri ideContriField;
    private string idField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public ReinfEvtAssocDespRecIdeEvento ideEvento
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
    public ReinfEvtAssocDespRecIdeContri ideContri
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


public partial class ReinfEvtAssocDespRecIdeEvento : object, INotifyPropertyChanged
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


public partial class ReinfEvtAssocDespRecIdeContri : object, INotifyPropertyChanged
{
    private PersonalidadeJuridica tpInscField;
    private string nrInscField;
    private ReinfEvtAssocDespRecIdeContriIdeEstab ideEstabField;

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

    /// <remarks/>
    [XmlElement(Order = 2)]
    public ReinfEvtAssocDespRecIdeContriIdeEstab ideEstab
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


public partial class ReinfEvtAssocDespRecIdeContriIdeEstab : object, INotifyPropertyChanged
{
    private PersonalidadeJuridica tpInscEstabField;
    private string nrInscEstabField;
    private ReinfEvtAssocDespRecIdeContriIdeEstabRecursosRec[] recursosRecField;

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
    [XmlElement("recursosRec", Order = 2)]
    public ReinfEvtAssocDespRecIdeContriIdeEstabRecursosRec[] recursosRec
    {
        get
        {
            return recursosRecField;
        }

        set
        {
            recursosRecField = value;
            RaisePropertyChanged("recursosRec");
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


public partial class ReinfEvtAssocDespRecIdeContriIdeEstabRecursosRec : object, INotifyPropertyChanged
{
    private string cnpjOrigRecursoField;
    private string vlrTotalRecField;
    private string vlrTotalRetField;
    private string vlrTotalNRetField;
    private ReinfEvtAssocDespRecIdeContriIdeEstabRecursosRecInfoRecurso[] infoRecursoField;
    private ReinfEvtAssocDespRecIdeContriIdeEstabRecursosRecInfoProc[] infoProcField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string cnpjOrigRecurso
    {
        get
        {
            return cnpjOrigRecursoField;
        }

        set
        {
            cnpjOrigRecursoField = value;
            RaisePropertyChanged("cnpjOrigRecurso");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string vlrTotalRec
    {
        get
        {
            return vlrTotalRecField;
        }

        set
        {
            vlrTotalRecField = value;
            RaisePropertyChanged("vlrTotalRec");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string vlrTotalRet
    {
        get
        {
            return vlrTotalRetField;
        }

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
        get
        {
            return vlrTotalNRetField;
        }

        set
        {
            vlrTotalNRetField = value;
            RaisePropertyChanged("vlrTotalNRet");
        }
    }

    /// <remarks/>
    [XmlElement("infoRecurso", Order = 4)]
    public ReinfEvtAssocDespRecIdeContriIdeEstabRecursosRecInfoRecurso[] infoRecurso
    {
        get
        {
            return infoRecursoField;
        }

        set
        {
            infoRecursoField = value;
            RaisePropertyChanged("infoRecurso");
        }
    }

    /// <remarks/>
    [XmlElement("infoProc", Order = 5)]
    public ReinfEvtAssocDespRecIdeContriIdeEstabRecursosRecInfoProc[] infoProc
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


public partial class ReinfEvtAssocDespRecIdeContriIdeEstabRecursosRecInfoRecurso : object, INotifyPropertyChanged
{
    private TipoRepasseAssocDesp tpRepasseField;
    private string descRecursoField;
    private string vlrBrutoField;
    private string vlrRetApurField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public TipoRepasseAssocDesp tpRepasse
    {
        get
        {
            return tpRepasseField;
        }

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
        get
        {
            return descRecursoField;
        }

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
        get
        {
            return vlrBrutoField;
        }

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
        get
        {
            return vlrRetApurField;
        }

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


public partial class ReinfEvtAssocDespRecIdeContriIdeEstabRecursosRecInfoProc : object, INotifyPropertyChanged
{
    private TipoProcesso tpProcField;
    private string nrProcField;
    private string codSuspField;
    private string vlrNRetField;

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
    public string vlrNRet
    {
        get
        {
            return vlrNRetField;
        }

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