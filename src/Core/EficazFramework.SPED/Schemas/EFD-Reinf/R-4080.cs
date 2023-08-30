namespace EficazFramework.SPED.Schemas.EFD_Reinf;

/// <summary>
/// Retenção no recebimento
/// </summary>
[System.SerializableAttribute()]
public partial class R4080 : Evento, System.ComponentModel.INotifyPropertyChanged
{

    private ReinfEvtRetRec evtRetRecField;
    private SignatureType signatureField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
    public ReinfEvtRetRec evtRetRec
    {
        get => evtRetRecField;
        set
        {
            evtRetRecField = value;
            RaisePropertyChanged("evtRetRec");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#", Order = 1)]
    public SignatureType Signature
    {
        get => signatureField;
        set
        {
            signatureField = value;
            RaisePropertyChanged("Signature");
        }
    }


    // IXmlSignableDocument Members
    public override string TagToSign => "Reinf";
    public override string TagId => "evtRetRecField";
    public override bool EmptyURI => true;
    public override bool SignAsSHA256 => true;


    // Evento Members
    public override void GeraEventoID()
    {
        evtRetRecField.id = string.Format("ID{0}{1}{2}", (int)(evtRetRecField?.ideContri?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtRetRecField?.ideContri?.NumeroInscricaoTag() ?? "00000000000000", ReinfTimeStampUtils.GetTimeStampIDForEvent());
    }

    public override string ContribuinteCNPJ()
    {
        return evtRetRecField.ideContri.nrInsc;
    }


    // PropertyChanged Members
    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    protected void RaisePropertyChanged(string propertyName)
    {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null))
        {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }


    // Serialization Members
    public override XmlSerializer DefineSerializer()
    {
        return new XmlSerializer(typeof(R4080), new XmlRootAttribute("Reinf") { Namespace = $"http://www.reinf.esocial.gov.br/schemas/evt4080RetencaoRecebimento/{Versao}", IsNullable = false });
    }
}

/// <exclude />
public partial class ReinfEvtRetRec : object, System.ComponentModel.INotifyPropertyChanged
{

    private IdentificacaoEventoPeriodico ideEventoField;
    private IdentificacaoContribuinte ideContriField;
    private ReinfEvtRetRecIdeEstab ideEstabField;
    private string idField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
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
    [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
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
    [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
    public ReinfEvtRetRecIdeEstab ideEstab
    {
        get => ideEstabField;
        set
        {
            ideEstabField = value;
            RaisePropertyChanged("ideEstab");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "ID")]
    public string id
    {
        get => idField;
        set
        {
            idField = value;
            RaisePropertyChanged("id");
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName)
    {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null))
        {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <exclude />
public partial class ReinfEvtRetRecIdeEstab : object, System.ComponentModel.INotifyPropertyChanged
{

    private PersonalidadeJuridica tpInscEstabField;
    private string nrInscEstabField;
    private ReinfEvtRetRecIdeEstabIdeFont ideFontField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
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
    [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
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
    [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
    public ReinfEvtRetRecIdeEstabIdeFont ideFont
    {
        get => ideFontField;
        set
        {
            ideFontField = value;
            RaisePropertyChanged("ideFont");
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName)
    {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null))
        {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <exclude />
public partial class ReinfEvtRetRecIdeEstabIdeFont : object, System.ComponentModel.INotifyPropertyChanged
{

    private string cnpjFontField;
    private List<ReinfEvtRetRecIdeEstabIdeFontIdeRend> ideRendField;

    /// <summary>
    /// CNPJ da Fonte Pagadora do Rendimento
    /// </summary>
    [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
    public string cnpjFont
    {
        get => cnpjFontField;
        set
        {
            cnpjFontField = value;
            RaisePropertyChanged("cnpjFont");
        }
    }

    /// <summary>
    /// Listagem de Identificação dos Rendimentos
    /// </summary>
    [System.Xml.Serialization.XmlElementAttribute("ideRend", Order = 1)]
    public List<ReinfEvtRetRecIdeEstabIdeFontIdeRend> ideRend
    {
        get => ideRendField;
        set
        {
            ideRendField = value;
            RaisePropertyChanged("ideRend");
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName)
    {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null))
        {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <summary>
/// Identificação do Rendimento
/// </summary>
/// <exclude />
public partial class ReinfEvtRetRecIdeEstabIdeFontIdeRend : object, System.ComponentModel.INotifyPropertyChanged
{

    private string natRendField;
    private string observField;
    private List<ReinfEvtRetRecIdeEstabIdeFontIdeRendInfoRec> infoRecField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 0)]
    public string natRend
    {
        get => natRendField;
        set
        {
            natRendField = value;
            RaisePropertyChanged("natRend");
        }
    }

    /// <summary>
    /// Informações relativas ao recebimento do rendimento.
    /// </summary>
    [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
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
    [System.Xml.Serialization.XmlElementAttribute("infoRec", Order = 2)]
    public List<ReinfEvtRetRecIdeEstabIdeFontIdeRendInfoRec> infoRec
    {
        get => infoRecField;
        set
        {
            infoRecField = value;
            RaisePropertyChanged("infoRec");
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName)
    {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null))
        {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <summary>
/// Informações relativas ao recebimento do rendimento.
/// </summary>
/// <exclude />
public partial class ReinfEvtRetRecIdeEstabIdeFontIdeRendInfoRec : object, System.ComponentModel.INotifyPropertyChanged
{

    private System.DateTime dtFGField;
    private string vlrBrutoField;
    private string vlrBaseIRField;
    private string vlrIRField;
    private List<ReinfEvtRetRecIdeEstabIdeFontIdeRendInfoRecInfoProcRet> infoProcRetField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("dtFG", DataType = "date", Order = 0)]
    public System.DateTime DataFatoGerador
    {
        get => dtFGField;
        set
        {
            dtFGField = value;
            RaisePropertyChanged("DataFatoGerador");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
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
    [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
    public string vlrBaseIR
    {
        get => vlrBaseIRField;
        set
        {
            vlrBaseIRField = value;
            RaisePropertyChanged("vlrBaseIR");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
    public string vlrIR
    {
        get => vlrIRField;
        set
        {
            vlrIRField = value;
            RaisePropertyChanged("vlrIR");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("infoProcRet", Order = 4)]
    public List<ReinfEvtRetRecIdeEstabIdeFontIdeRendInfoRecInfoProcRet> infoProcRet
    {
        get => infoProcRetField;
        set
        {
            infoProcRetField = value;
            RaisePropertyChanged("infoProcRet");
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName)
    {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null))
        {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <exclude />
public partial class ReinfEvtRetRecIdeEstabIdeFontIdeRendInfoRecInfoProcRet : object, System.ComponentModel.INotifyPropertyChanged
{

    private TipoProcesso tpProcRetField;
    private string nrProcRetField;
    private string codSuspField;
    private string vlrBaseSuspIRField;
    private string vlrNIRField;
    private string vlrDepIRField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
    public TipoProcesso tpProcRet
    {
        get => tpProcRetField;
        set
        {
            tpProcRetField = value;
            RaisePropertyChanged("tpProcRet");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
    public string nrProcRet
    {
        get => nrProcRetField;
        set
        {
            nrProcRetField = value;
            RaisePropertyChanged("nrProcRet");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
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
    [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
    public string vlrBaseSuspIR
    {
        get => vlrBaseSuspIRField;
        set
        {
            vlrBaseSuspIRField = value;
            RaisePropertyChanged("vlrBaseSuspIR");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
    public string vlrNIR
    {
        get => vlrNIRField;
        set
        {
            vlrNIRField = value;
            RaisePropertyChanged("vlrNIR");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
    public string vlrDepIR
    {
        get => vlrDepIRField;
        set
        {
            vlrDepIRField = value;
            RaisePropertyChanged("vlrDepIR");
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName)
    {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null))
        {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}
