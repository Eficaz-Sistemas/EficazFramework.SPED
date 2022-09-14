namespace EficazFramework.SPED.Schemas.EFD_Reinf.v2_01_01;

[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evt2055AquisicaoProdRural/v1_05_01")]
[XmlRoot("Reinf", Namespace = "http://www.reinf.esocial.gov.br/schemas/evt2055AquisicaoProdRural/v1_05_01", IsNullable = false)]
public partial class R2055 : IEfdReinfEvt, INotifyPropertyChanged
{
    private ReinfAqProd evtAqProdField;
    private SignatureType signatureField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public ReinfAqProd evtAqProd
    {
        get
        {
            return evtAqProdField;
        }

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
        return new XmlSerializer(typeof(R2055));
    }

    public override void GeraEventoID()
    {
        evtAqProdField.id = string.Format("ID{0}{1}{2}", (int)(evtAqProdField?.ideContri?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtAqProdField?.ideContri?.NumeroInscricaoTag() ?? "00000000000000", ReinfTimeStampUtils.GetTimeStampIDForEvent());
    }

    public override string ContribuinteCNPJ()
    {
        return evtAqProd.ideContri.nrInsc;
    }
}


[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evt2055AquisicaoProdRural/v1_05_01")]
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
    public ReinfEvtAqProdIdeContri ideContri
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
    public ReinfEvtAqProdInfoAqProd infoAquisProd
    {
        get
        {
            return infoAqProdField;
        }

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
[XmlType(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evt2055AquisicaoProdRural/v1_05_01")]
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


[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evt2055AquisicaoProdRural/v1_05_01")]
public partial class ReinfEvtAqProdIdeContri : object, INotifyPropertyChanged
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
[XmlType(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evt2055AquisicaoProdRural/v1_05_01")]
public partial class ReinfEvtAqProdInfoAqProd : object, INotifyPropertyChanged
{
    private ReinfEvtAqProdInfoAqProdIdeEstabAdquir ideEstabField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public ReinfEvtAqProdInfoAqProdIdeEstabAdquir ideEstabAdquir
    {
        get
        {
            return ideEstabField;
        }

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


[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evt2055AquisicaoProdRural/v1_05_01")]
public partial class ReinfEvtAqProdInfoAqProdIdeEstabAdquir : object, INotifyPropertyChanged
{
    private PersonalidadeJuridica tpInscAdqField;
    private string nrInscAdqField;
    ReinfEvtAqProdInfoAquisProdIdeEstabIdeProdutor tipoComField;
    List<ReinfEvtAqProdInfoAquisProdIdeEstabIdeProdutorDetAquis> _detAquisField = new List<ReinfEvtAqProdInfoAquisProdIdeEstabIdeProdutorDetAquis>();

    /// <remarks/>
    [XmlElement(Order = 0)]
    public PersonalidadeJuridica tpInscAdq
    {
        get
        {
            return tpInscAdqField;
        }

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
        get
        {
            return nrInscAdqField;
        }

        set
        {
            nrInscAdqField = value;
            RaisePropertyChanged("nrInscAdq");
        }
    }

    ///// <remarks/>
    //[XmlElement(Order = 2)]
    //public string vlrRecBrutaTotal
    //{
    //    get
    //    {
    //        return vlrRecBrutaTotalField;
    //    }

    //    set
    //    {
    //        vlrRecBrutaTotalField = value;
    //        RaisePropertyChanged("vlrRecBrutaTotal");
    //    }
    //}

    ///// <remarks/>
    //[XmlElement(Order = 3)]
    //public string vlrCPApur
    //{
    //    get
    //    {
    //        return vlrCPApurField;
    //    }

    //    set
    //    {
    //        vlrCPApurField = value;
    //        RaisePropertyChanged("vlrCPApur");
    //    }
    //}

    ///// <remarks/>
    //[XmlElement(Order = 4)]
    //public string vlrRatApur
    //{
    //    get
    //    {
    //        return vlrRatApurField;
    //    }

    //    set
    //    {
    //        vlrRatApurField = value;
    //        RaisePropertyChanged("vlrRatApur");
    //    }
    //}

    ///// <remarks/>
    //[XmlElement(Order = 5)]
    //public string vlrSenarApur
    //{
    //    get
    //    {
    //        return vlrSenarApurField;
    //    }

    //    set
    //    {
    //        vlrSenarApurField = value;
    //        RaisePropertyChanged("vlrSenarApur");
    //    }
    //}

    ///// <remarks/>
    //[XmlElement(Order = 6)]
    //public string vlrCPSuspTotal
    //{
    //    get
    //    {
    //        return vlrCPSuspTotalField;
    //    }

    //    set
    //    {
    //        vlrCPSuspTotalField = value;
    //        RaisePropertyChanged("vlrCPSuspTotal");
    //    }
    //}

    ///// <remarks/>
    //[XmlElement(Order = 7)]
    //public string vlrRatSuspTotal
    //{
    //    get
    //    {
    //        return vlrRatSuspTotalField;
    //    }

    //    set
    //    {
    //        vlrRatSuspTotalField = value;
    //        RaisePropertyChanged("vlrRatSuspTotal");
    //    }
    //}

    ///// <remarks/>
    //[XmlElement(Order = 8)]
    //public string vlrSenarSuspTotal
    //{
    //    get
    //    {
    //        return vlrSenarSuspTotalField;
    //    }

    //    set
    //    {
    //        vlrSenarSuspTotalField = value;
    //        RaisePropertyChanged("vlrSenarSuspTotal");
    //    }
    //}

    /// <remarks/>
    [XmlElement("ideProdutor", Order = 2)]
    public ReinfEvtAqProdInfoAquisProdIdeEstabIdeProdutor ideProdutor
    {
        get
        {
            return tipoComField;
        }

        set
        {
            tipoComField = value;
            RaisePropertyChanged("ideProdutor");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public List<ReinfEvtAqProdInfoAquisProdIdeEstabIdeProdutorDetAquis> detAquis
    {
        get
        {
            return _detAquisField;
        }

        set
        {
            _detAquisField = value;
            RaisePropertyChanged("detAquis");
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
[XmlType(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evt2055AquisicaoProdRural/v1_05_01")]
public partial class ReinfEvtAqProdInfoAquisProdIdeEstabIdeProdutor : object, INotifyPropertyChanged
{
    private PersonalidadeJuridica tpInscProdField;
    private string nrInscProdField;
    private string indOpcCPField;
    //private string vlrRecBrutaField;
    //private ReinfEvtAqProdInfoAqProdIdeEstabTipoComInfoProc[] infoProcField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public PersonalidadeJuridica tpInscProd
    {
        get
        {
            return tpInscProdField;
        }

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
        get
        {
            return nrInscProdField;
        }

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
        get
        {
            return indOpcCPField;
        }

        set
        {
            indOpcCPField = value;
            RaisePropertyChanged("indOpcCP");
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


[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evt2055AquisicaoProdRural/v1_05_01")]
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
        get
        {
            return indAquisField;
        }

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
    [XmlElement(Order = 2)]
    public string vlrCPDescPR
    {
        get
        {
            return vlrCPDescPRField;
        }

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
        get
        {
            return vlrRatDescPRField;
        }

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
        get
        {
            return vlrSenarDescField;
        }

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
        get
        {
            return infoProcJudField;
        }

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


[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evt2055AquisicaoProdRural/v1_05_01")]
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
        get
        {
            return nrProcJudField;
        }

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
    [XmlElement(Order = 2)]
    public string vlrCPNRet
    {
        get
        {
            return vlrCPNRetField;
        }

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
        get
        {
            return vlrRatNRetField;
        }

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
        get
        {
            return vlrSenarNRetField;
        }

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
