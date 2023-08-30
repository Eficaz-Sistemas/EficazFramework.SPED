namespace EficazFramework.SPED.Schemas.EFD_Reinf;

/// <exclude />
public abstract class R4010eR4020IdentificacaoEstabelecimentoBase : EfdReinfBindableObject
{

    private PersonalidadeJuridica tpInscEstabField;
    private string nrInscEstabField;

    /// <remarks/>
    [XmlElement(Order = 0)]
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
    [XmlElement(Order = 1)]
    public string nrInscEstab
    {
        get => nrInscEstabField;
        set
        {
            nrInscEstabField = value;
            RaisePropertyChanged("nrInscEstab");
        }
    }
}

/// <exclude />
public abstract class R4010eR4020IdentificacaoPagtoBase : EfdReinfBindableObject
{
    private string natRendField;
    private string observField;

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

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string observ
    {
        get => observField;
        set
        {
            observField = value;
            RaisePropertyChanged("observ");
        }
    }
}

