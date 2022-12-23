namespace EficazFramework.SPED.Schemas.EFD_Reinf;

/// <summary>
/// Retenção de contribuição previdenciária - serviços tomados
/// </summary>
[Serializable()]
public partial class R2010 : IEfdReinfEvt, INotifyPropertyChanged
{
    private ReinfEvtServTom evtServTomField;
    private SignatureType signatureField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public ReinfEvtServTom evtServTom
    {
        get
        {
            return evtServTomField;
        }

        set
        {
            evtServTomField = value;
            RaisePropertyChanged("evtServTom");
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
        evtServTomField.id = string.Format("ID{0}{1}{2}", (int)(evtServTomField?.ideContri?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtServTomField?.ideContri?.NumeroInscricaoTag() ?? "00000000000000", ReinfTimeStampUtils.GetTimeStampIDForEvent());
    }

    public override string ContribuinteCNPJ()
    {
        return evtServTom.ideContri.nrInsc;
    }


    // IXmlSignableDocument Members
    public override string TagToSign => "Reinf";
    public override string TagId => "evtServTom";
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
        return new XmlSerializer(typeof(R2010), new XmlRootAttribute("Reinf") { Namespace = $"http://www.reinf.esocial.gov.br/schemas/evtTomadorServicos/{Versao}", IsNullable = false });
    }
}


/// <exclude />
public partial class ReinfEvtServTom : object, INotifyPropertyChanged
{
    private ReinfEvtIdeEvento_R20xx ideEventoField;
    private ReinfEvtIdeContri ideContriField;
    private ReinfEvtServTomInfoServTom infoServTomField;
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
    public ReinfEvtServTomInfoServTom infoServTom
    {
        get
        {
            return infoServTomField;
        }

        set
        {
            infoServTomField = value;
            RaisePropertyChanged("infoServTom");
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
public partial class ReinfEvtServTomInfoServTom : object, INotifyPropertyChanged
{
    private ReinfEvtServTomInfoServTomIdeEstabObra ideEstabObraField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public ReinfEvtServTomInfoServTomIdeEstabObra ideEstabObra
    {
        get
        {
            return ideEstabObraField;
        }

        set
        {
            ideEstabObraField = value;
            RaisePropertyChanged("ideEstabObra");
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
public partial class ReinfEvtServTomInfoServTomIdeEstabObra : object, INotifyPropertyChanged
{
    private PersonalidadeJuridica tpInscEstabField;
    private string nrInscEstabField;
    private IndicadorObra indObraField = IndicadorObra.NaoSujeitoCEI;
    private ReinfEvtServTomInfoServTomIdeEstabObraIdePrestServ idePrestServField;

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
            RaisePropertyChanged("indObra_Str");
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
    public ReinfEvtServTomInfoServTomIdeEstabObraIdePrestServ idePrestServ
    {
        get
        {
            return idePrestServField;
        }

        set
        {
            idePrestServField = value;
            RaisePropertyChanged("idePrestServ");
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
public partial class ReinfEvtServTomInfoServTomIdeEstabObraIdePrestServ : object, INotifyPropertyChanged
{
    private string cnpjPrestadorField;
    private string vlrTotalBrutoField;
    private string vlrTotalBaseRetField;
    private string vlrTotalRetPrincField;
    private string vlrTotalRetAdicField;
    private string vlrTotalNRetPrincField;
    private string vlrTotalNRetAdicField;
    private IndicadorContribuinteCPRB indCPRBField;
    private List<ReinfEvtServTomInfoServTomIdeEstabObraIdePrestServNfs> nfsField = new List<ReinfEvtServTomInfoServTomIdeEstabObraIdePrestServNfs>();
    private List<ReinfEvtServTomInfoServTomIdeEstabObraIdePrestServInfoProcRetPr> infoProcRetPrField = new List<ReinfEvtServTomInfoServTomIdeEstabObraIdePrestServInfoProcRetPr>();
    private List<ReinfEvtServTomInfoServTomIdeEstabObraIdePrestServInfoProcRetAd> infoProcRetAdField = new List<ReinfEvtServTomInfoServTomIdeEstabObraIdePrestServInfoProcRetAd>();

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string cnpjPrestador
    {
        get
        {
            return cnpjPrestadorField;
        }

        set
        {
            cnpjPrestadorField = value;
            RaisePropertyChanged("cnpjPrestador");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string vlrTotalBruto
    {
        get
        {
            return vlrTotalBrutoField;
        }

        set
        {
            vlrTotalBrutoField = value;
            // If Me.vlrTotalBrutoField.HasValue Then Me.vlrTotalBrutoField = Math.Round(Me.vlrTotalBrutoField.Value, 2)
            RaisePropertyChanged("vlrTotalBruto");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string vlrTotalBaseRet
    {
        get
        {
            return vlrTotalBaseRetField;
        }

        set
        {
            vlrTotalBaseRetField = value;
            // If Me.vlrTotalBaseRetField.HasValue Then Me.vlrTotalBaseRetField = Math.Round(Me.vlrTotalBaseRetField.Value, 2)
            RaisePropertyChanged("vlrTotalBaseRet");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string vlrTotalRetPrinc
    {
        get
        {
            return vlrTotalRetPrincField;
        }

        set
        {
            vlrTotalRetPrincField = value;
            // If Me.vlrTotalRetPrincField.HasValue Then Me.vlrTotalRetPrincField = Math.Round(Me.vlrTotalRetPrincField.Value, 2)
            RaisePropertyChanged("vlrTotalRetPrinc");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public string vlrTotalRetAdic
    {
        get
        {
            return vlrTotalRetAdicField;
        }

        set
        {
            vlrTotalRetAdicField = value;
            // If Me.vlrTotalRetAdicField.HasValue Then Me.vlrTotalRetAdicField = Math.Round(Me.vlrTotalRetAdicField.Value, 2)
            RaisePropertyChanged("vlrTotalRetAdic");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 5)]
    public string vlrTotalNRetPrinc
    {
        get
        {
            return vlrTotalNRetPrincField;
        }

        set
        {
            vlrTotalNRetPrincField = value;
            // If Me.vlrTotalNRetPrincField.HasValue Then Me.vlrTotalNRetPrincField = Math.Round(Me.vlrTotalNRetPrincField.Value, 2)
            RaisePropertyChanged("vlrTotalNRetPrinc");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 6)]
    public string vlrTotalNRetAdic
    {
        get
        {
            return vlrTotalNRetAdicField;
        }

        set
        {
            vlrTotalNRetAdicField = value;
            // If Me.vlrTotalNRetAdicField.HasValue Then Me.vlrTotalNRetAdicField = Math.Round(Me.vlrTotalNRetAdicField.Value, 2)
            RaisePropertyChanged("vlrTotalNRetAdic");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 7)]
    public IndicadorContribuinteCPRB indCPRB
    {
        get
        {
            return indCPRBField;
        }

        set
        {
            indCPRBField = value;
            RaisePropertyChanged("indCPRB");
            RaisePropertyChanged("indCPRB_Str");
        }
    }

    [XmlIgnore()]
    public string indCPRB_Str
    {
        get
        {
            switch (indCPRB)
            {
                case IndicadorContribuinteCPRB.Contribuinte:
                    {
                        return "Contribuinte";
                    }

                case IndicadorContribuinteCPRB.NaoContribuinte:
                    {
                        return "Não Contribuinte";
                    }
            }

            return null;
        }
    }

    /// <remarks/>
    [XmlElement("nfs", Order = 8)]
    public List<ReinfEvtServTomInfoServTomIdeEstabObraIdePrestServNfs> nfs
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
    [XmlElement("infoProcRetPr", Order = 9)]
    public List<ReinfEvtServTomInfoServTomIdeEstabObraIdePrestServInfoProcRetPr> infoProcRetPr
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

    /// <remarks/>
    [XmlElement("infoProcRetAd", Order = 10)]
    public List<ReinfEvtServTomInfoServTomIdeEstabObraIdePrestServInfoProcRetAd> infoProcRetAd
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


/// <exclude />
public partial class ReinfEvtServTomInfoServTomIdeEstabObraIdePrestServNfs : object, INotifyPropertyChanged
{
    private string serieField;
    private string numDoctoField;
    private DateTime dtEmissaoNFField;
    private string vlrBrutoField;
    private string obsField;
    private List<ReinfEvtServTomInfoServTomIdeEstabObraIdePrestServNfsInfoTpServ> infoTpServField;

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
            // If Me.vlrBrutoField.HasValue Then Me.vlrBrutoField = Math.Round(Me.vlrBrutoField.Value, 2)
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
    public List<ReinfEvtServTomInfoServTomIdeEstabObraIdePrestServNfsInfoTpServ> infoTpServ
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


/// <exclude />
public partial class ReinfEvtServTomInfoServTomIdeEstabObraIdePrestServNfsInfoTpServ : object, INotifyPropertyChanged
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
            // If Me.vlrBaseRetField.HasValue Then Me.vlrBaseRetField = Math.Round(Me.vlrBaseRetField.Value, 2)
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
            // If Me.vlrRetencaoField.HasValue Then Me.vlrRetencaoField = Math.Round(Me.vlrRetencaoField.Value, 2)
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
            // If Me.vlrRetSubField.HasValue Then Me.vlrRetSubField = Math.Round(Me.vlrRetSubField.Value, 2)
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
            // If Me.vlrNRetPrincField.HasValue Then Me.vlrNRetPrincField = Math.Round(Me.vlrNRetPrincField.Value, 2)
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
            // If Me.vlrServicos15Field.HasValue Then Me.vlrServicos15Field = Math.Round(Me.vlrServicos15Field.Value, 2)
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
            // If Me.vlrServicos20Field.HasValue Then Me.vlrServicos20Field = Math.Round(Me.vlrServicos20Field.Value, 2)
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
            // If Me.vlrServicos25Field.HasValue Then Me.vlrServicos25Field = Math.Round(Me.vlrServicos25Field.Value, 2)
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
            // If Me.vlrAdicionalField.HasValue Then Me.vlrAdicionalField = Math.Round(Me.vlrAdicionalField.Value, 2)
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
            // If Me.vlrNRetAdicField.HasValue Then Me.vlrNRetAdicField = Math.Round(Me.vlrNRetAdicField.Value, 2)
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


/// <exclude />
public partial class ReinfEvtServTomInfoServTomIdeEstabObraIdePrestServInfoProcRetPr : object, INotifyPropertyChanged
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


/// <exclude />
public partial class ReinfEvtServTomInfoServTomIdeEstabObraIdePrestServInfoProcRetAd : object, INotifyPropertyChanged
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
