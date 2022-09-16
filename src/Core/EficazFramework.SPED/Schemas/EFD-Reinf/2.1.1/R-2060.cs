namespace EficazFramework.SPED.Schemas.EFD_Reinf.v2_01_01;

[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evtInfoCPRB/v2_01_01")]
[XmlRoot("Reinf", Namespace = "http://www.reinf.esocial.gov.br/schemas/evtInfoCPRB/v2_01_01", IsNullable = false)]
public partial class R2060 : IEfdReinfEvt, INotifyPropertyChanged
{
    private ReinfEvtCPRB evtCPRBField;
    private SignatureType signatureField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public ReinfEvtCPRB evtCPRB
    {
        get
        {
            return evtCPRBField;
        }

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
        return new XmlSerializer(typeof(R2060));
    }
}


[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evtInfoCPRB/v2_01_01")]
public partial class ReinfEvtCPRB : object, INotifyPropertyChanged
{
    private ReinfEvtIdeEvento_R20xx ideEventoField;
    private ReinfEvtIdeContri ideContriField;
    private ReinfEvtCPRBInfoCPRB infoCPRBField;
    private string idField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public ReinfEvtIdeEvento_R20xx ideEvento
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
    [XmlElement(Order = 2)]
    public ReinfEvtCPRBInfoCPRB infoCPRB
    {
        get
        {
            return infoCPRBField;
        }

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


[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evtInfoCPRB/v2_01_01")]
public partial class ReinfEvtCPRBInfoCPRB : object, INotifyPropertyChanged
{
    private ReinfEvtCPRBInfoCPRBIdeEstab ideEstabField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public ReinfEvtCPRBInfoCPRBIdeEstab ideEstab
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


[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evtInfoCPRB/v2_01_01")]
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
    public string vlrCPApurTotal
    {
        get
        {
            return vlrCPApurTotalField;
        }

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
        get
        {
            return vlrCPRBSuspTotalField;
        }

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
        get
        {
            return tipoCodField;
        }

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


[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evtInfoCPRB/v2_01_01")]
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
        get
        {
            return codAtivEconField;
        }

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
        get
        {
            return vlrRecBrutaAtivField;
        }

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
        get
        {
            return vlrExcRecBrutaField;
        }

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
        get
        {
            return vlrAdicRecBrutaField;
        }

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
        get
        {
            return vlrBcCPRBField;
        }

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
        get
        {
            return vlrCPRBapurField;
        }

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
        get
        {
            return observField;
        }

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
        get
        {
            return tipoAjusteField;
        }

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


[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evtInfoCPRB/v2_01_01")]
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
        get
        {
            return tpAjusteField;
        }

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
        get
        {
            return codAjusteField;
        }

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
        get
        {
            return vlrAjusteField;
        }

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
        get
        {
            return descAjusteField;
        }

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
        get
        {
            return dtAjusteField;
        }

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


[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evtInfoCPRB/v2_01_01")]
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
    public string vlrCPRBSusp
    {
        get
        {
            return vlrCPRBSuspField;
        }

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