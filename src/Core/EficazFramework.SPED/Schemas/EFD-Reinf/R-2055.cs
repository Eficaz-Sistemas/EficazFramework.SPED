namespace EficazFramework.SPED.Schemas.EFD_Reinf;

/// <summary>
/// Aquisição de produção rural
/// </summary>
[Serializable()]
public partial class R2055 : Evento, INotifyPropertyChanged
{
    private ReinfAqProd evtAqProdField;
    private SignatureType signatureField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public ReinfAqProd evtAqProd
    {
        get => evtAqProdField;

        set
        {
            evtAqProdField = value;
            RaisePropertyChanged("evtAqProd");
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
        evtAqProdField.id = string.Format("ID{0}{1}{2}", (int)(evtAqProdField?.ideContri?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtAqProdField?.ideContri?.NumeroInscricaoTag() ?? "00000000000000", ReinfTimeStampUtils.GetTimeStampIDForEvent());
    }

    public override string ContribuinteCNPJ()
    {
        return evtAqProd.ideContri.nrInsc;
    }


    // IXmlSignableDocument Members
    public override string TagToSign => "Reinf";
    public override string TagId => "evtAqProd";
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
        return new XmlSerializer(typeof(R2055), new XmlRootAttribute("Reinf") { Namespace = $"http://www.reinf.esocial.gov.br/schemas/evt2055AquisicaoProdRural/{Versao}", IsNullable = false });
    }
}


/// <exclude />
public partial class ReinfAqProd : object, INotifyPropertyChanged
{
    private ReinfEvtAqProdIdeEvento ideEventoField;
    private ReinfEvtAqProdIdeContri ideContriField;
    private ReinfEvtAqProdInfoAqProd infoAqProdField;
    private string idField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public ReinfEvtAqProdIdeEvento ideEvento
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
    public ReinfEvtAqProdIdeContri ideContri
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
    public ReinfEvtAqProdInfoAqProd infoAquisProd
    {
        get => infoAqProdField;

        set
        {
            infoAqProdField = value;
            RaisePropertyChanged("infoAquisProd");
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
public partial class ReinfEvtAqProdIdeEvento : object, INotifyPropertyChanged
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
        get => indRetifField;

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
        get => nrReciboField;

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
        get => perApurField;

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
        get => tpAmbField;

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
        get => procEmiField;

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


/// <exclude />
public partial class ReinfEvtAqProdIdeContri : object, INotifyPropertyChanged
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
public partial class ReinfEvtAqProdInfoAqProd : object, INotifyPropertyChanged
{
    private ReinfEvtAqProdInfoAqProdIdeEstabAdquir ideEstabField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public ReinfEvtAqProdInfoAqProdIdeEstabAdquir ideEstabAdquir
    {
        get => ideEstabField;

        set
        {
            ideEstabField = value;
            RaisePropertyChanged("ideEstabAdquir");
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
public partial class ReinfEvtAqProdInfoAqProdIdeEstabAdquir : object, INotifyPropertyChanged
{
    private PersonalidadeJuridica tpInscAdqField;
    private string nrInscAdqField;
    ReinfEvtAqProdInfoAquisProdIdeEstabIdeProdutor tipoComField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public PersonalidadeJuridica tpInscAdq
    {
        get => tpInscAdqField;

        set
        {
            tpInscAdqField = value;
            RaisePropertyChanged("tpInscAdq");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nrInscAdq
    {
        get => nrInscAdqField;

        set
        {
            nrInscAdqField = value;
            RaisePropertyChanged("nrInscAdq");
        }
    }

    /// <remarks/>
    [XmlElement("ideProdutor", Order = 2)]
    public ReinfEvtAqProdInfoAquisProdIdeEstabIdeProdutor ideProdutor
    {
        get => tipoComField;

        set
        {
            tipoComField = value;
            RaisePropertyChanged("ideProdutor");
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
public partial class ReinfEvtAqProdInfoAquisProdIdeEstabIdeProdutor : object, INotifyPropertyChanged
{
    private PersonalidadeJuridica tpInscProdField;
    private string nrInscProdField;
    private string indOpcCPField;
    List<ReinfEvtAqProdInfoAquisProdIdeEstabIdeProdutorDetAquis> _detAquisField = new List<ReinfEvtAqProdInfoAquisProdIdeEstabIdeProdutorDetAquis>();

    /// <remarks/>
    [XmlElement(Order = 0)]
    public PersonalidadeJuridica tpInscProd
    {
        get => tpInscProdField;

        set
        {
            tpInscProdField = value;
            RaisePropertyChanged("tpInscProd");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nrInscProd
    {
        get => nrInscProdField;

        set
        {
            nrInscProdField = value;
            RaisePropertyChanged("nrInscProd");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string indOpcCP
    {
        get => indOpcCPField;

        set
        {
            indOpcCPField = value;
            RaisePropertyChanged("indOpcCP");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public List<ReinfEvtAqProdInfoAquisProdIdeEstabIdeProdutorDetAquis> detAquis
    {
        get => _detAquisField;

        set
        {
            _detAquisField = value;
            RaisePropertyChanged("detAquis");
        }
    }

    public bool ShouldSerializeindOpcCP()
    {
        return (indOpcCPField ?? "").ToUpper() == "S";
    }

    ///// <remarks/>
    //[XmlElement(Order = 1)]
    //public string vlrRecBruta
    //{
    //    get
    //    {
    //        return vlrRecBrutaField;
    //    }

    //    set
    //    {
    //        vlrRecBrutaField = value;
    //        RaisePropertyChanged("vlrRecBruta");
    //    }
    //}

    ///// <remarks/>
    //[XmlElement("infoProc", Order = 2)]
    //public ReinfEvtAqProdInfoAqProdIdeEstabTipoComInfoProc[] infoProc
    //{
    //    get
    //    {
    //        return infoProcField;
    //    }

    //    set
    //    {
    //        infoProcField = value;
    //        RaisePropertyChanged("infoProc");
    //    }
    //}

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
public partial class ReinfEvtAqProdInfoAquisProdIdeEstabIdeProdutorDetAquis : object, INotifyPropertyChanged
{
    private IndicadorAquisProd indAquisField;
    private string vlrBrutoField;
    private string vlrCPDescPRField;
    private string vlrRatDescPRField;
    private string vlrSenarDescField;
    private ReinfEvtAqProdInfoAqProdIdeEstabTipoComInfoProc[] infoProcJudField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public IndicadorAquisProd indAquis
    {
        get => indAquisField;

        set
        {
            indAquisField = value;
            RaisePropertyChanged("indAquis");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
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
    [XmlElement(Order = 2)]
    public string vlrCPDescPR
    {
        get => vlrCPDescPRField;

        set
        {
            vlrCPDescPRField = value;
            RaisePropertyChanged("vlrCPDescPR");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string vlrRatDescPR
    {
        get => vlrRatDescPRField;

        set
        {
            vlrRatDescPRField = value;
            RaisePropertyChanged("vlrRatDescPR");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public string vlrSenarDesc
    {
        get => vlrSenarDescField;

        set
        {
            vlrSenarDescField = value;
            RaisePropertyChanged("vlrSenarDesc");
        }
    }

    /// <remarks/>
    [XmlElement("ideProdutor", Order = 5)]
    public ReinfEvtAqProdInfoAqProdIdeEstabTipoComInfoProc[] infoProcJud
    {
        get => infoProcJudField;

        set
        {
            infoProcJudField = value;
            RaisePropertyChanged("infoProcJud");
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
public partial class ReinfEvtAqProdInfoAqProdIdeEstabTipoComInfoProc : object, INotifyPropertyChanged
{
    private string nrProcJudField;
    private string codSuspField;
    private string vlrCPNRetField;
    private string vlrRatNRetField;
    private string vlrSenarNRetField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string nrProcJud
    {
        get => nrProcJudField;

        set
        {
            nrProcJudField = value;
            RaisePropertyChanged("nrProcJud");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
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
    [XmlElement(Order = 2)]
    public string vlrCPNRet
    {
        get => vlrCPNRetField;

        set
        {
            vlrCPNRetField = value;
            RaisePropertyChanged("vlrCPNRet");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string vlrRatNRet
    {
        get => vlrRatNRetField;

        set
        {
            vlrRatNRetField = value;
            RaisePropertyChanged("vlrRatNRet");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public string vlrSenarNRet
    {
        get => vlrSenarNRetField;

        set
        {
            vlrSenarNRetField = value;
            RaisePropertyChanged("vlrSenarNRet");
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
