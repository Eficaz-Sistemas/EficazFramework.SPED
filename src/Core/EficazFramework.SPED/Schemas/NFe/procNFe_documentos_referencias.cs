using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EficazFramework.SPED.Schemas.NFe;

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public partial class ReferenciaDocFiscal : INotifyPropertyChanged
{

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private object itemField;
    private TipoDocumentoReferencia itemElementNameField;

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    [XmlElement("refCTe", typeof(string))]
    [XmlElement("refECF", typeof(ReferenciaECF))]
    [XmlElement("refNF", typeof(ReferenciaNF))]
    [XmlElement("refNFP", typeof(ReferenciaNFProdutor))]
    [XmlElement("refNFe", typeof(string))]
    [XmlChoiceIdentifier("TipoReferencia")]
    public object Item
    {
        get
        {
            return itemField;
        }

        set
        {
            if (itemField is null || itemField.Equals(value) != true)
            {
                itemField = value;
                OnPropertyChanged("Item");
            }
        }
    }

    [XmlIgnore()]
    public TipoDocumentoReferencia TipoReferencia
    {
        get
        {
            return itemElementNameField;
        }

        set
        {
            if (itemElementNameField.Equals(value) != true)
            {
                itemElementNameField = value;
                OnPropertyChanged("TipoReferencia");
            }
        }
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public event PropertyChangedEventHandler PropertyChanged;

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public virtual void OnPropertyChanged(string propertyName)
    {
        var handler = PropertyChanged;
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public partial class ReferenciaECF : INotifyPropertyChanged
{

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private ModeloECF modField;
    private string nECFField;
    private string nCOOField;


    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    [XmlElement("mod")]
    public ModeloECF Modelo
    {
        get
        {
            return modField;
        }

        set
        {
            if (modField.Equals(value) != true)
            {
                modField = value;
                OnPropertyChanged("Modelo");
            }
        }
    }

    [XmlElement("nECF")]
    public string NumeroECF
    {
        get
        {
            return nECFField;
        }

        set
        {
            if (nECFField is null || nECFField.Equals(value) != true)
            {
                nECFField = value;
                OnPropertyChanged("NumeroECF");
            }
        }
    }

    [XmlElement("nCOO")]
    public string ContadorOperacoesCOO
    {
        get
        {
            return nCOOField;
        }

        set
        {
            if (nCOOField is null || nCOOField.Equals(value) != true)
            {
                nCOOField = value;
                OnPropertyChanged("ContadorOperacoesCOO");
            }
        }
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName)
    {
        var handler = PropertyChanged;
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public partial class ReferenciaNF : INotifyPropertyChanged
{

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private OrgaoIBGE cUFField;
    private string aAMMField;
    private string cNPJField;
    private ModeloNF modField;
    private string serieField;
    private string nNFField;


    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    [XmlElement("cUF")]
    public OrgaoIBGE CodigoUF
    {
        get
        {
            return cUFField;
        }

        set
        {
            if (cUFField.Equals(value) != true)
            {
                cUFField = value;
                OnPropertyChanged("CodigoUF");
            }
        }
    }

    [XmlElement("AAMM")]
    public string EmissaoAAMM
    {
        get
        {
            return aAMMField;
        }

        set
        {
            if (aAMMField is null || aAMMField.Equals(value) != true)
            {
                aAMMField = value;
                OnPropertyChanged("EmissaoAAMM");
            }
        }
    }

    public string CNPJ
    {
        get
        {
            return cNPJField;
        }

        set
        {
            if (cNPJField is null || cNPJField.Equals(value) != true)
            {
                cNPJField = value;
                OnPropertyChanged("CNPJ");
            }
        }
    }

    [XmlElement("mod")]
    public ModeloNF Modelo
    {
        get
        {
            return modField;
        }

        set
        {
            if (modField.Equals(value) != true)
            {
                modField = value;
                OnPropertyChanged("Modelo");
            }
        }
    }

    [XmlElement("serie")]
    public string Serie
    {
        get
        {
            return serieField;
        }

        set
        {
            if (serieField is null || serieField.Equals(value) != true)
            {
                serieField = value;
                OnPropertyChanged("Serie");
            }
        }
    }

    [XmlElement("nNF")]
    public string Numero
    {
        get
        {
            return nNFField;
        }

        set
        {
            if (nNFField is null || nNFField.Equals(value) != true)
            {
                nNFField = value;
                OnPropertyChanged("Numero");
            }
        }
    }

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public event PropertyChangedEventHandler PropertyChanged;

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public virtual void OnPropertyChanged(string propertyName)
    {
        var handler = PropertyChanged;
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public partial class ReferenciaNFProdutor : INotifyPropertyChanged
{

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private OrgaoIBGE cUFField;
    private string aAMMField;
    private string itemField;
    private PersonalidadeJuridica itemElementNameField;
    private string ieField;
    private ModeloNFProdutor modField;
    private string serieField;
    private string nNFField;


    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    [XmlElement("cUF")]
    public OrgaoIBGE CodigoUF
    {
        get
        {
            return cUFField;
        }

        set
        {
            if (cUFField.Equals(value) != true)
            {
                cUFField = value;
                OnPropertyChanged("CodigoUF");
            }
        }
    }

    [XmlElement("AAMM")]
    public string EmissaoAAMM
    {
        get
        {
            return aAMMField;
        }

        set
        {
            if (aAMMField is null || aAMMField.Equals(value) != true)
            {
                aAMMField = value;
                OnPropertyChanged("EmissaoAAMM");
            }
        }
    }

    [XmlElement("CNPJ", typeof(string))]
    [XmlElement("CPF", typeof(string))]
    [XmlChoiceIdentifier("ProdutorPersonalidadeJuridica")]
    public string CNPJ_CPF
    {
        get
        {
            return itemField;
        }

        set
        {
            if (itemField is null || itemField.Equals(value) != true)
            {
                itemField = value;
                OnPropertyChanged("CNPJ_CPF");
            }
        }
    }

    [XmlIgnore()]
    public PersonalidadeJuridica ProdutorPersonalidadeJuridica
    {
        get
        {
            return itemElementNameField;
        }

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
        get
        {
            return ieField;
        }

        set
        {
            if (ieField is null || ieField.Equals(value) != true)
            {
                ieField = value;
                OnPropertyChanged("InscricaoEstadual");
            }
        }
    }

    [XmlElement("mod")]
    public ModeloNFProdutor Modelo
    {
        get
        {
            return modField;
        }

        set
        {
            if (modField.Equals(value) != true)
            {
                modField = value;
                OnPropertyChanged("Modelo");
            }
        }
    }

    [XmlElement("serie")]
    public string Serie
    {
        get
        {
            return serieField;
        }

        set
        {
            if (serieField is null || serieField.Equals(value) != true)
            {
                serieField = value;
                OnPropertyChanged("Serie");
            }
        }
    }

    [XmlElement("nNF")]
    public string Numero
    {
        get
        {
            return nNFField;
        }

        set
        {
            if (nNFField is null || nNFField.Equals(value) != true)
            {
                nNFField = value;
                OnPropertyChanged("Numero");
            }
        }
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public event PropertyChangedEventHandler PropertyChanged;

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public virtual void OnPropertyChanged(string propertyName)
    {
        var handler = PropertyChanged;
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}
