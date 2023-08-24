namespace EficazFramework.SPED.Schemas.EFD_Reinf;

/// <summary>
/// Fechamento dos eventos da série R-2000
/// </summary>
[Serializable()]
public partial class R2099 : Evento, INotifyPropertyChanged
{
    private ReinfEvtFechaEvPer evtFechaEvPerField;
    private SignatureType signatureField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public ReinfEvtFechaEvPer evtFechaEvPer
    {
        get => evtFechaEvPerField;

        set
        {
            evtFechaEvPerField = value;
            RaisePropertyChanged("evtFechaEvPer");
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
        evtFechaEvPerField.id = string.Format("ID{0}{1}{2}", (int)(evtFechaEvPerField?.ideContri?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtFechaEvPerField?.ideContri?.NumeroInscricaoTag() ?? "00000000000000", ReinfTimeStampUtils.GetTimeStampIDForEvent());
    }

    public override string ContribuinteCNPJ()
    {
        return evtFechaEvPer.ideContri.nrInsc;
    }


    // IXmlSignableDocument Members
    public override string TagToSign => "Reinf";
    public override string TagId => "evtFechaEvPer";
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
        return new XmlSerializer(typeof(R2099), new XmlRootAttribute("Reinf") { Namespace = $"http://www.reinf.esocial.gov.br/schemas/evtFechamento/{Versao}", IsNullable = false });
    }
}


/// <exclude />
public partial class ReinfEvtFechaEvPer : object, INotifyPropertyChanged
{
    private IdentificacaoEventoFechamento ideEventoField;
    private IdentificacaoContribuinte ideContriField;
    private IdentificacaoResponsavel ideRespInfField;
    private ReinfEvtFechaEvPerInfoFech infoFechField;
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
    [XmlElement(Order = 2)]
    public IdentificacaoResponsavel ideRespInf
    {
        get => ideRespInfField;

        set
        {
            ideRespInfField = value;
            RaisePropertyChanged("ideRespInf");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public ReinfEvtFechaEvPerInfoFech infoFech
    {
        get => infoFechField;

        set
        {
            infoFechField = value;
            RaisePropertyChanged("infoFech");
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
public partial class ReinfEvtFechaEvPerInfoFech : object, INotifyPropertyChanged
{
    private SimNao evtServTmField = SimNao.Nao;
    private SimNao evtServPrField = SimNao.Nao;
    private SimNao evtAssDespRecField = SimNao.Nao;
    private SimNao evtAssDespRepField = SimNao.Nao;
    private SimNao evtComProdField = SimNao.Nao;
    private SimNao evtCPRBField = SimNao.Nao;
    private SimNao evtAquisField = SimNao.Nao;
    private SimNao evtPgtosField = SimNao.Nao;
    private bool evtPgtosFieldSpecified = false;
    private string compSemMovtoField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public SimNao evtServTm
    {
        get => evtServTmField;

        set
        {
            evtServTmField = value;
            RaisePropertyChanged("evtServTm");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public SimNao evtServPr
    {
        get => evtServPrField;

        set
        {
            evtServPrField = value;
            RaisePropertyChanged("evtServPr");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public SimNao evtAssDespRec
    {
        get => evtAssDespRecField;

        set
        {
            evtAssDespRecField = value;
            RaisePropertyChanged("evtAssDespRec");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public SimNao evtAssDespRep
    {
        get => evtAssDespRepField;

        set
        {
            evtAssDespRepField = value;
            RaisePropertyChanged("evtAssDespRep");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public SimNao evtComProd
    {
        get => evtComProdField;

        set
        {
            evtComProdField = value;
            RaisePropertyChanged("evtComProd");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 5)]
    public SimNao evtCPRB
    {
        get => evtCPRBField;

        set
        {
            evtCPRBField = value;
            RaisePropertyChanged("evtCPRB");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 6)]
    public SimNao evtAquis
    {
        get => evtAquisField;

        set
        {
            evtAquisField = value;
            RaisePropertyChanged("evtAquis");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 7)]
    public SimNao evtPgtos
    {
        get => evtPgtosField;

        set
        {
            evtPgtosField = value;
            RaisePropertyChanged("evtPgtos");
        }
    }

    /// <remarks/>
    [XmlIgnore()]
    public bool evtPgtosSpecified
    {
        get => evtPgtosFieldSpecified;

        set
        {
            evtPgtosFieldSpecified = value;
            RaisePropertyChanged("evtPgtosSpecified");
        }
    }

    /// <remarks/>
    [XmlElement(DataType = "gYearMonth", Order = 8)]
    public string compSemMovto
    {
        get => compSemMovtoField;

        set
        {
            compSemMovtoField = value;
            RaisePropertyChanged("compSemMovto");
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