namespace EficazFramework.SPED.Schemas.NFe;

public partial class ReferenciaDocFiscal : INotifyPropertyChanged
{
    private object itemField;
    private TipoDocumentoReferencia itemElementNameField;

    [XmlElement("refCTe", typeof(string))]
    [XmlElement("refECF", typeof(ReferenciaECF))]
    [XmlElement("refNF", typeof(ReferenciaNF))]
    [XmlElement("refNFP", typeof(ReferenciaNFProdutor))]
    [XmlElement("refNFe", typeof(string))]
    [XmlChoiceIdentifier("TipoReferencia")]
    public object Item
    {
        get => itemField;
        set
        {
            if (itemField is null || itemField.Equals(value) != true)
            {
                itemField = value;
                OnPropertyChanged(nameof(Item));
            }
        }
    }

    [XmlIgnore()]
    public TipoDocumentoReferencia TipoReferencia
    {
        get => itemElementNameField;
        set
        {
            if (itemElementNameField.Equals(value) != true)
            {
                itemElementNameField = value;
                OnPropertyChanged(nameof(TipoReferencia));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class ReferenciaECF : INotifyPropertyChanged
{
    private ModeloECF modField;
    private string nECFField;
    private string nCOOField;

    [XmlElement("mod")]
    public ModeloECF Modelo
    {
        get => modField;
        set
        {
            if (modField.Equals(value) != true)
            {
                modField = value;
                OnPropertyChanged(nameof(Modelo));
            }
        }
    }

    [XmlElement("nECF")]
    public string NumeroECF
    {
        get => nECFField;
        set
        {
            if (nECFField is null || nECFField.Equals(value) != true)
            {
                nECFField = value;
                OnPropertyChanged(nameof(NumeroECF));
            }
        }
    }

    [XmlElement("nCOO")]
    public string ContadorOperacoesCOO
    {
        get => nCOOField;
        set
        {
            if (nCOOField is null || nCOOField.Equals(value) != true)
            {
                nCOOField = value;
                OnPropertyChanged(nameof(ContadorOperacoesCOO));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class ReferenciaNF : INotifyPropertyChanged
{
    private OrgaoIBGE cUFField;
    private string aAMMField;
    private string cNPJField;
    private ModeloNF modField;
    private string serieField;
    private string nNFField;

    [XmlElement("cUF")]
    public OrgaoIBGE CodigoUF
    {
        get => cUFField;
        set
        {
            if (cUFField.Equals(value) != true)
            {
                cUFField = value;
                OnPropertyChanged(nameof(CodigoUF));
            }
        }
    }

    [XmlElement("AAMM")]
    public string EmissaoAAMM
    {
        get => aAMMField;
        set
        {
            if (aAMMField is null || aAMMField.Equals(value) != true)
            {
                aAMMField = value;
                OnPropertyChanged(nameof(EmissaoAAMM));
            }
        }
    }

    public string CNPJ
    {
        get => cNPJField;
        set
        {
            if (cNPJField is null || cNPJField.Equals(value) != true)
            {
                cNPJField = value;
                OnPropertyChanged(nameof(CNPJ));
            }
        }
    }

    [XmlElement("mod")]
    public ModeloNF Modelo
    {
        get => modField;
        set
        {
            if (modField.Equals(value) != true)
            {
                modField = value;
                OnPropertyChanged(nameof(Modelo));
            }
        }
    }

    [XmlElement("serie")]
    public string Serie
    {
        get => serieField;
        set
        {
            if (serieField is null || serieField.Equals(value) != true)
            {
                serieField = value;
                OnPropertyChanged(nameof(Serie));
            }
        }
    }

    [XmlElement("nNF")]
    public string Numero
    {
        get => nNFField;
        set
        {
            if (nNFField is null || nNFField.Equals(value) != true)
            {
                nNFField = value;
                OnPropertyChanged(nameof(Numero));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class ReferenciaNFProdutor : INotifyPropertyChanged
{
    private OrgaoIBGE cUFField;
    private string aAMMField;
    private string itemField;
    private PersonalidadeJuridica itemElementNameField;
    private string ieField;
    private ModeloNFProdutor modField;
    private string serieField;
    private string nNFField;

    [XmlElement("cUF")]
    public OrgaoIBGE CodigoUF
    {
        get => cUFField;
        set
        {
            if (cUFField.Equals(value) != true)
            {
                cUFField = value;
                OnPropertyChanged(nameof(CodigoUF));
            }
        }
    }

    [XmlElement("AAMM")]
    public string EmissaoAAMM
    {
        get => aAMMField;
        set
        {
            if (aAMMField is null || aAMMField.Equals(value) != true)
            {
                aAMMField = value;
                OnPropertyChanged(nameof(EmissaoAAMM));
            }
        }
    }

    [XmlElement("CNPJ", typeof(string))]
    [XmlElement("CPF", typeof(string))]
    [XmlChoiceIdentifier("ProdutorPersonalidadeJuridica")]
    public string CNPJ_CPF
    {
        get => itemField;
        set
        {
            if (itemField is null || itemField.Equals(value) != true)
            {
                itemField = value;
                OnPropertyChanged(nameof(CNPJ_CPF));
            }
        }
    }

    [XmlIgnore()]
    public PersonalidadeJuridica ProdutorPersonalidadeJuridica
    {
        get => itemElementNameField;
        set
        {
            if (itemElementNameField.Equals(value) != true)
            {
                itemElementNameField = value;
                OnPropertyChanged("ItemElementName");
            }
        }
    }

    [XmlElement("IE")]
    public string InscricaoEstadual
    {
        get => ieField;
        set
        {
            if (ieField is null || ieField.Equals(value) != true)
            {
                ieField = value;
                OnPropertyChanged(nameof(InscricaoEstadual));
            }
        }
    }

    [XmlElement("mod")]
    public ModeloNFProdutor Modelo
    {
        get => modField;
        set
        {
            if (modField.Equals(value) != true)
            {
                modField = value;
                OnPropertyChanged(nameof(Modelo));
            }
        }
    }

    [XmlElement("serie")]
    public string Serie
    {
        get => serieField;
        set
        {
            if (serieField is null || serieField.Equals(value) != true)
            {
                serieField = value;
                OnPropertyChanged(nameof(Serie));
            }
        }
    }

    [XmlElement("nNF")]
    public string Numero
    {
        get => nNFField;
        set
        {
            if (nNFField is null || nNFField.Equals(value) != true)
            {
                nNFField = value;
                OnPropertyChanged(nameof(Numero));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
