namespace EficazFramework.SPED.Schemas.EFD_Reinf.v2_1;

[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evtPrestadorServicos/v2_01_01")]
[XmlRoot("Reinf", Namespace = "http://www.reinf.esocial.gov.br/schemas/evtPrestadorServicos/v2_01_01", IsNullable = false)]
public partial class R2020 : IEfdReinfEvt, INotifyPropertyChanged
{
    private ReinfEvtServPrest evtServPrestField;
    private SignatureType signatureField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public ReinfEvtServPrest evtServPrest
    {
        get
        {
            return evtServPrestField;
        }

        set
        {
            evtServPrestField = value;
            RaisePropertyChanged("evtServPrest");
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
        return new XmlSerializer(typeof(R2020));
    }

    public override void GeraEventoID()
    {
        evtServPrestField.id = string.Format("ID{0}{1}{2}", (int)(evtServPrestField?.ideContri?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtServPrestField?.ideContri?.NumeroInscricaoTag() ?? "00000000000000", ReinfTimeStampUtils.GetTimeStampIDForEvent());
    }

    public override string ContribuinteCNPJ()
    {
        return evtServPrest.ideContri.nrInsc;
    }
}


[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evtPrestadorServicos/v2_01_01")]
public partial class ReinfEvtServPrest : object, INotifyPropertyChanged
{
    private ReinfEvtIdeEvento_R20xx ideEventoField;
    private ReinfEvtIdeContri ideContriField;
    private ReinfEvtServPrestInfoServPrest infoServPrestField;
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
    public ReinfEvtServPrestInfoServPrest infoServPrest
    {
        get
        {
            return infoServPrestField;
        }

        set
        {
            infoServPrestField = value;
            RaisePropertyChanged("infoServPrest");
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
[XmlType(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evtPrestadorServicos/v2_01_01")]
public partial class ReinfEvtServPrestInfoServPrest : object, INotifyPropertyChanged
{
    private ReinfEvtServPrestInfoServPrestIdeEstabPrest ideEstabPrestField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public ReinfEvtServPrestInfoServPrestIdeEstabPrest ideEstabPrest
    {
        get
        {
            return ideEstabPrestField;
        }

        set
        {
            ideEstabPrestField = value;
            RaisePropertyChanged("ideEstabPrest");
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
[XmlType(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evtPrestadorServicos/v2_01_01")]
public partial class ReinfEvtServPrestInfoServPrestIdeEstabPrest : object, INotifyPropertyChanged
{
    private PersonalidadeJuridica tpInscEstabPrestField;
    private string nrInscEstabPrestField;
    private ReinfEvtServPrestInfoServPrestIdeEstabPrestIdeTomador ideTomadorField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public PersonalidadeJuridica tpInscEstabPrest
    {
        get
        {
            return tpInscEstabPrestField;
        }

        set
        {
            tpInscEstabPrestField = value;
            RaisePropertyChanged("tpInscEstabPrest");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nrInscEstabPrest
    {
        get
        {
            return nrInscEstabPrestField;
        }

        set
        {
            nrInscEstabPrestField = value;
            RaisePropertyChanged("nrInscEstabPrest");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public ReinfEvtServPrestInfoServPrestIdeEstabPrestIdeTomador ideTomador
    {
        get
        {
            return ideTomadorField;
        }

        set
        {
            ideTomadorField = value;
            RaisePropertyChanged("ideTomador");
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
[XmlType(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evtPrestadorServicos/v2_01_01")]
public partial class ReinfEvtServPrestInfoServPrestIdeEstabPrestIdeTomador : object, INotifyPropertyChanged
{
    private PersonalidadeJuridica tpInscTomadorField;
    private string nrInscTomadorField;
    private IndicadorObra indObraField;
    private string vlrTotalBrutoField;
    private string vlrTotalBaseRetField;
    private string vlrTotalRetPrincField;
    private string vlrTotalRetAdicField;
    private string vlrTotalNRetPrincField;
    private string vlrTotalNRetAdicField;
    private List<ReinfEvtServPrestInfoServPrestIdeEstabPrestIdeTomadorNfs> nfsField = new List<ReinfEvtServPrestInfoServPrestIdeEstabPrestIdeTomadorNfs>();
    private List<ReinfEvtServPrestInfoServPrestIdeEstabPrestIdeTomadorInfoProcRetPr> infoProcRetPrField = new List<ReinfEvtServPrestInfoServPrestIdeEstabPrestIdeTomadorInfoProcRetPr>();
    private List<ReinfEvtServPrestInfoServPrestIdeEstabPrestIdeTomadorInfoProcRetAd> infoProcRetAdField = new List<ReinfEvtServPrestInfoServPrestIdeEstabPrestIdeTomadorInfoProcRetAd>();

    /// <remarks/>
    [XmlElement(Order = 0)]
    public PersonalidadeJuridica tpInscTomador
    {
        get
        {
            return tpInscTomadorField;
        }

        set
        {
            tpInscTomadorField = value;
            RaisePropertyChanged("tpInscTomador");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nrInscTomador
    {
        get
        {
            return nrInscTomadorField;
        }

        set
        {
            nrInscTomadorField = value;
            RaisePropertyChanged("nrInscTomador");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public IndicadorObra indObra
    {
        get
        {
            return indObraField;
        }

        set
        {
            indObraField = value;
            RaisePropertyChanged("indObra");
        }
    }

    [XmlIgnore()]
    public string indObra_Str
    {
        get
        {
            switch (indObra)
            {
                case IndicadorObra.NaoSujeitoCEI:
                    {
                        return "Não é obra ou não está sujeito a Matrícula CEI";
                    }

                case IndicadorObra.Obra_Parcial:
                    {
                        return "Obra - Empreitada Parcial";
                    }

                case IndicadorObra.Obra_Total:
                    {
                        return "Obra - Empreitada Total";
                    }
            }

            return null;
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string vlrTotalBruto
    {
        get
        {
            return vlrTotalBrutoField;
        }

        set
        {
            vlrTotalBrutoField = value;
            RaisePropertyChanged("vlrTotalBruto");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public string vlrTotalBaseRet
    {
        get
        {
            return vlrTotalBaseRetField;
        }

        set
        {
            vlrTotalBaseRetField = value;
            RaisePropertyChanged("vlrTotalBaseRet");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 5)]
    public string vlrTotalRetPrinc
    {
        get
        {
            return vlrTotalRetPrincField;
        }

        set
        {
            vlrTotalRetPrincField = value;
            RaisePropertyChanged("vlrTotalRetPrinc");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 6)]
    public string vlrTotalRetAdic
    {
        get
        {
            return vlrTotalRetAdicField;
        }

        set
        {
            vlrTotalRetAdicField = value;
            RaisePropertyChanged("vlrTotalRetAdic");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 7)]
    public string vlrTotalNRetPrinc
    {
        get
        {
            return vlrTotalNRetPrincField;
        }

        set
        {
            vlrTotalNRetPrincField = value;
            RaisePropertyChanged("vlrTotalNRetPrinc");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 8)]
    public string vlrTotalNRetAdic
    {
        get
        {
            return vlrTotalNRetAdicField;
        }

        set
        {
            vlrTotalNRetAdicField = value;
            RaisePropertyChanged("vlrTotalNRetAdic");
        }
    }

    /// <remarks/>
    [XmlElement("nfs", Order = 9)]
    public List<ReinfEvtServPrestInfoServPrestIdeEstabPrestIdeTomadorNfs> nfs
    {
        get
        {
            return nfsField;
        }

        set
        {
            nfsField = value;
            RaisePropertyChanged("nfs");
        }
    }

    /// <remarks/>
    [XmlElement("infoProcRetPr", Order = 10)]
    public List<ReinfEvtServPrestInfoServPrestIdeEstabPrestIdeTomadorInfoProcRetPr> infoProcRetPr
    {
        get
        {
            return infoProcRetPrField;
        }

        set
        {
            infoProcRetPrField = value;
            RaisePropertyChanged("infoProcRetPr");
        }
    }

    /// <remarks/>s
    [XmlElement("infoProcRetAd", Order = 11)]
    public List<ReinfEvtServPrestInfoServPrestIdeEstabPrestIdeTomadorInfoProcRetAd> infoProcRetAd
    {
        get
        {
            return infoProcRetAdField;
        }

        set
        {
            infoProcRetAdField = value;
            RaisePropertyChanged("infoProcRetAd");
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
[XmlType(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evtPrestadorServicos/v2_01_01")]
public partial class ReinfEvtServPrestInfoServPrestIdeEstabPrestIdeTomadorNfs : object, INotifyPropertyChanged
{
    private string serieField;
    private string numDoctoField;
    private DateTime dtEmissaoNFField;
    private string vlrBrutoField;
    private string obsField;
    private List<ReinfEvtServPrestInfoServPrestIdeEstabPrestIdeTomadorNfsInfoTpServ> infoTpServField = new List<ReinfEvtServPrestInfoServPrestIdeEstabPrestIdeTomadorNfsInfoTpServ>();

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string serie
    {
        get
        {
            return serieField;
        }

        set
        {
            serieField = value;
            RaisePropertyChanged("serie");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string numDocto
    {
        get
        {
            return numDoctoField;
        }

        set
        {
            numDoctoField = value;
            RaisePropertyChanged("numDocto");
        }
    }

    /// <remarks/>
    [XmlElement(DataType = "date", Order = 2)]
    public DateTime dtEmissaoNF
    {
        get
        {
            return dtEmissaoNFField;
        }

        set
        {
            dtEmissaoNFField = value;
            RaisePropertyChanged("dtEmissaoNF");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
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
    [XmlElement(Order = 4)]
    public string obs
    {
        get
        {
            return obsField;
        }

        set
        {
            obsField = value;
            RaisePropertyChanged("obs");
        }
    }

    /// <remarks/>
    [XmlElement("infoTpServ", Order = 5)]
    public List<ReinfEvtServPrestInfoServPrestIdeEstabPrestIdeTomadorNfsInfoTpServ> infoTpServ
    {
        get
        {
            return infoTpServField;
        }

        set
        {
            infoTpServField = value;
            RaisePropertyChanged("infoTpServ");
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
[XmlType(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evtPrestadorServicos/v2_01_01")]
public partial class ReinfEvtServPrestInfoServPrestIdeEstabPrestIdeTomadorNfsInfoTpServ : object, INotifyPropertyChanged
{
    private string tpServicoField;
    private string vlrBaseRetField;
    private string vlrRetencaoField;
    private string vlrRetSubField;
    private string vlrNRetPrincField;
    private string vlrServicos15Field;
    private string vlrServicos20Field;
    private string vlrServicos25Field;
    private string vlrAdicionalField;
    private string vlrNRetAdicField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string tpServico
    {
        get
        {
            return tpServicoField;
        }

        set
        {
            tpServicoField = value;
            RaisePropertyChanged("tpServico");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string vlrBaseRet
    {
        get
        {
            return vlrBaseRetField;
        }

        set
        {
            vlrBaseRetField = value;
            RaisePropertyChanged("vlrBaseRet");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string vlrRetencao
    {
        get
        {
            return vlrRetencaoField;
        }

        set
        {
            vlrRetencaoField = value;
            RaisePropertyChanged("vlrRetencao");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string vlrRetSub
    {
        get
        {
            return vlrRetSubField;
        }

        set
        {
            vlrRetSubField = value;
            RaisePropertyChanged("vlrRetSub");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public string vlrNRetPrinc
    {
        get
        {
            return vlrNRetPrincField;
        }

        set
        {
            vlrNRetPrincField = value;
            RaisePropertyChanged("vlrNRetPrinc");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 5)]
    public string vlrServicos15
    {
        get
        {
            return vlrServicos15Field;
        }

        set
        {
            vlrServicos15Field = value;
            RaisePropertyChanged("vlrServicos15");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 6)]
    public string vlrServicos20
    {
        get
        {
            return vlrServicos20Field;
        }

        set
        {
            vlrServicos20Field = value;
            RaisePropertyChanged("vlrServicos20");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 7)]
    public string vlrServicos25
    {
        get
        {
            return vlrServicos25Field;
        }

        set
        {
            vlrServicos25Field = value;
            RaisePropertyChanged("vlrServicos25");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 8)]
    public string vlrAdicional
    {
        get
        {
            return vlrAdicionalField;
        }

        set
        {
            vlrAdicionalField = value;
            RaisePropertyChanged("vlrAdicional");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 9)]
    public string vlrNRetAdic
    {
        get
        {
            return vlrNRetAdicField;
        }

        set
        {
            vlrNRetAdicField = value;
            RaisePropertyChanged("vlrNRetAdic");
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
[XmlType(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evtPrestadorServicos/v2_01_01")]
public partial class ReinfEvtServPrestInfoServPrestIdeEstabPrestIdeTomadorInfoProcRetPr : object, INotifyPropertyChanged
{
    private TipoProcesso tpProcRetPrincField;
    private string nrProcRetPrincField;
    private string codSuspPrincField;
    private string valorPrincField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public TipoProcesso tpProcRetPrinc
    {
        get
        {
            return tpProcRetPrincField;
        }

        set
        {
            tpProcRetPrincField = value;
            RaisePropertyChanged("tpProcRetPrinc");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nrProcRetPrinc
    {
        get
        {
            return nrProcRetPrincField;
        }

        set
        {
            nrProcRetPrincField = value;
            RaisePropertyChanged("nrProcRetPrinc");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string codSuspPrinc
    {
        get
        {
            return codSuspPrincField;
        }

        set
        {
            codSuspPrincField = value;
            RaisePropertyChanged("codSuspPrinc");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string valorPrinc
    {
        get
        {
            return valorPrincField;
        }

        set
        {
            valorPrincField = value;
            RaisePropertyChanged("valorPrinc");
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
[XmlType(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evtPrestadorServicos/v2_01_01")]
public partial class ReinfEvtServPrestInfoServPrestIdeEstabPrestIdeTomadorInfoProcRetAd : object, INotifyPropertyChanged
{
    private TipoProcesso tpProcRetAdicField;
    private string nrProcRetAdicField;
    private string codSuspAdicField;
    private string valorAdicField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public TipoProcesso tpProcRetAdic
    {
        get
        {
            return tpProcRetAdicField;
        }

        set
        {
            tpProcRetAdicField = value;
            RaisePropertyChanged("tpProcRetAdic");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nrProcRetAdic
    {
        get
        {
            return nrProcRetAdicField;
        }

        set
        {
            nrProcRetAdicField = value;
            RaisePropertyChanged("nrProcRetAdic");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string codSuspAdic
    {
        get
        {
            return codSuspAdicField;
        }

        set
        {
            codSuspAdicField = value;
            RaisePropertyChanged("codSuspAdic");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string valorAdic
    {
        get
        {
            return valorAdicField;
        }

        set
        {
            valorAdicField = value;
            RaisePropertyChanged("valorAdic");
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
