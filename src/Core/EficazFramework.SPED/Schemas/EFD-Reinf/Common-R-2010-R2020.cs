namespace EficazFramework.SPED.Schemas.EFD_Reinf;

/// <exclude />
public partial class R2010eR2020Nfs : EfdReinfBindableObject
{
    private string serieField;
    private string numDoctoField;
    private DateTime dtEmissaoNFField;
    private string vlrBrutoField;
    private string obsField;
    private List<R2010eR2020InformacaoServico> infoTpServField = new();

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string serie
    {
        get => serieField;

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
        get => numDoctoField;

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
        get => dtEmissaoNFField;

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
        get => vlrBrutoField;

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
        get => obsField;

        set
        {
            obsField = value;
            RaisePropertyChanged("obs");
        }
    }

    /// <remarks/>
    [XmlElement("infoTpServ", Order = 5)]
    public List<R2010eR2020InformacaoServico> infoTpServ
    {
        get => infoTpServField;

        set
        {
            infoTpServField = value;
            RaisePropertyChanged("infoTpServ");
        }
    }
}


/// <exclude />
public partial class R2010eR2020InformacaoServico : EfdReinfBindableObject
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
        get => tpServicoField;

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
        get => vlrBaseRetField;

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
        get => vlrRetencaoField;

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
        get => vlrRetSubField;

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
        get => vlrNRetPrincField;

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
        get => vlrServicos15Field;

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
        get => vlrServicos20Field;

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
        get => vlrServicos25Field;

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
        get => vlrAdicionalField;

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
        get => vlrNRetAdicField;

        set
        {
            vlrNRetAdicField = value;
            // If Me.vlrNRetAdicField.HasValue Then Me.vlrNRetAdicField = Math.Round(Me.vlrNRetAdicField.Value, 2)
            RaisePropertyChanged("vlrNRetAdic");
        }
    }
}


/// <exclude />
public partial class R2010eR2020ProcessoRelacionado : EfdReinfBindableObject
{
    private TipoProcesso tpProcRetPrincField;
    private string nrProcRetPrincField;
    private string codSuspPrincField;
    private string valorPrincField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public TipoProcesso tpProcRetPrinc
    {
        get => tpProcRetPrincField;

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
        get => nrProcRetPrincField;

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
        get => codSuspPrincField;

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
        get => valorPrincField;

        set
        {
            valorPrincField = value;
            RaisePropertyChanged("valorPrinc");
        }
    }
}


/// <exclude />
public partial class R2010eR2020ProcessoRelacionadoAdic : EfdReinfBindableObject
{
    private TipoProcesso tpProcRetAdicField;
    private string nrProcRetAdicField;
    private string codSuspAdicField;
    private string valorAdicField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public TipoProcesso tpProcRetAdic
    {
        get => tpProcRetAdicField;

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
        get => nrProcRetAdicField;

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
        get => codSuspAdicField;

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
        get => valorAdicField;

        set
        {
            valorAdicField = value;
            RaisePropertyChanged("valorAdic");
        }
    }
}