namespace EficazFramework.SPED.Schemas.EFD_Reinf.v2_01_01;

[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evtRecursoRepassadoAssociacao/v2_01_01")]
[XmlRoot("Reinf", Namespace = "http://www.reinf.esocial.gov.br/schemas/evtRecursoRepassadoAssociacao/v2_01_01", IsNullable = false)]
public partial class R2040 : IEfdReinfEvt, INotifyPropertyChanged
{
    private ReinfEvtAssocDespRep evtAssocDespRepField;
    private SignatureType signatureField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public ReinfEvtAssocDespRep evtAssocDespRep
    {
        get
        {
            return evtAssocDespRepField;
        }

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
        return new XmlSerializer(typeof(R2040));
    }

    public override void GeraEventoID()
    {
        evtAssocDespRepField.id = string.Format("ID{0}{1}{2}", (evtAssocDespRepField?.ideContri?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtAssocDespRepField?.ideContri?.NumeroInscricaoTag() ?? "00000000000000", ReinfTimeStampUtils.GetTimeStampIDForEvent());
    }

    public override string ContribuinteCNPJ()
    {
        return evtAssocDespRep.ideContri.nrInsc;
    }
}


[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evtRecursoRepassadoAssociacao/v2_01_01")]
public partial class ReinfEvtAssocDespRep : object, INotifyPropertyChanged
{
    private ReinfEvtIdeEvento_R20xx ideEventoField;
    private ReinfEvtAssocDespRepIdeContri ideContriField;
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
    public ReinfEvtAssocDespRepIdeContri ideContri
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


[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evtRecursoRepassadoAssociacao/v2_01_01")]
public partial class ReinfEvtAssocDespRepIdeContri : object, INotifyPropertyChanged
{
    private PersonalidadeJuridica tpInscField;
    private string nrInscField;
    private ReinfEvtAssocDespRepIdeContriIdeEstab ideEstabField;

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
    public ReinfEvtAssocDespRepIdeContriIdeEstab ideEstab
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


[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evtRecursoRepassadoAssociacao/v2_01_01")]
public partial class ReinfEvtAssocDespRepIdeContriIdeEstab : object, INotifyPropertyChanged
{
    private PersonalidadeJuridica tpInscEstabField;
    private string nrInscEstabField;
    private ReinfEvtAssocDespRepIdeContriIdeEstabRecursosRep[] recursosRepField;

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
    [XmlElement("recursosRep", Order = 2)]
    public ReinfEvtAssocDespRepIdeContriIdeEstabRecursosRep[] recursosRep
    {
        get
        {
            return recursosRepField;
        }

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


[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evtRecursoRepassadoAssociacao/v2_01_01")]
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
        get
        {
            return cnpjAssocDespField;
        }

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
        get
        {
            return vlrTotalRepField;
        }

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
    public ReinfEvtAssocDespRepIdeContriIdeEstabRecursosRepInfoRecurso[] infoRecurso
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
    public ReinfEvtAssocDespRepIdeContriIdeEstabRecursosRepInfoProc[] infoProc
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
[XmlType(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evtRecursoRepassadoAssociacao/v2_01_01")]
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


[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evtRecursoRepassadoAssociacao/v2_01_01")]
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