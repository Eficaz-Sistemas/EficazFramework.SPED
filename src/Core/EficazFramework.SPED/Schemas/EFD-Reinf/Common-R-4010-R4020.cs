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
            RaisePropertyChanged(nameof(tpInscEstab));
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
            RaisePropertyChanged(nameof(nrInscEstab));
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
            RaisePropertyChanged(nameof(natRend));
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
            RaisePropertyChanged(nameof(observ));
        }
    }
}

/// <exclude />
public partial class R4010eR4020InfomacaoProcessoJudic : EfdReinfBindableObject
{
    private string nrProcField;
    private IndicadorOrigemDosRecursos indOrigRecField;
    private string cnpjOrigRecursoField;
    private string descField;
    private R4010eR4020DespesasAdvogado despProcJudField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string nrProc
    {
        get => nrProcField;
        set
        {
            nrProcField = value;
            RaisePropertyChanged(nameof(nrProc));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public IndicadorOrigemDosRecursos indOrigRec
    {
        get => indOrigRecField;
        set
        {
            indOrigRecField = value;
            RaisePropertyChanged(nameof(indOrigRec));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string cnpjOrigRecurso
    {
        get => cnpjOrigRecursoField;
        set
        {
            cnpjOrigRecursoField = value;
            RaisePropertyChanged(nameof(cnpjOrigRecurso));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string desc
    {
        get => descField;
        set
        {
            descField = value;
            RaisePropertyChanged(nameof(desc));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public R4010eR4020DespesasAdvogado despProcJud
    {
        get => despProcJudField;
        set
        {
            despProcJudField = value;
            RaisePropertyChanged(nameof(despProcJud));
        }
    }
}


/// <exclude />
public partial class R4010eR4020DespesasAdvogado : EfdReinfBindableObject
{
    private string vlrDespCustasField;
    private string vlrDespAdvogadosField;

    private List<R4010eR4020IdentificacaoAdvogado> ideAdvField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string vlrDespCustas
    {
        get => vlrDespCustasField;
        set
        {
            vlrDespCustasField = value;
            RaisePropertyChanged(nameof(vlrDespCustas));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string vlrDespAdvogados
    {
        get => vlrDespAdvogadosField;
        set
        {
            vlrDespAdvogadosField = value;
            RaisePropertyChanged(nameof(vlrDespAdvogados));
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ideAdv", Order = 2)]
    public List<R4010eR4020IdentificacaoAdvogado> ideAdv
    {
        get => ideAdvField;
        set
        {
            ideAdvField = value;
            RaisePropertyChanged(nameof(ideAdv));
        }
    }
}


/// <exclude />
public partial class R4010eR4020IdentificacaoAdvogado : EfdReinfBindableObject
{
    private PersonalidadeJuridica tpInscAdvField;

    private string nrInscAdvField;
    private string vlrAdvField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public PersonalidadeJuridica tpInscAdv
    {
        get => tpInscAdvField;
        set
        {
            tpInscAdvField = value;
            RaisePropertyChanged(nameof(tpInscAdv));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nrInscAdv
    {
        get => nrInscAdvField;
        set
        {
            nrInscAdvField = value;
            RaisePropertyChanged(nameof(nrInscAdv));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string vlrAdv
    {
        get => vlrAdvField;
        set
        {
            vlrAdvField = value;
            RaisePropertyChanged(nameof(vlrAdv));
        }
    }
}


/// <exclude />
public partial class R4010e4020EnderecoResExterior : EfdReinfBindableObject
{
    private string dscLogradField;
    private string nrLogradField;
    private string complemField;
    private string bairroField;
    private string cidadeField;
    private string estadoField;
    private string codPostalField;
    private string telefField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string dscLograd
    {
        get => dscLogradField;
        set
        {
            dscLogradField = value;
            RaisePropertyChanged(nameof(dscLograd));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nrLograd
    {
        get => nrLogradField;
        set
        {
            nrLogradField = value;
            RaisePropertyChanged(nameof(nrLograd));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string complem
    {
        get => complemField;
        set
        {
            complemField = value;
            RaisePropertyChanged(nameof(complem));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string bairro
    {
        get => bairroField;
        set
        {
            bairroField = value;
            RaisePropertyChanged(nameof(bairro));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public string cidade
    {
        get => cidadeField;
        set
        {
            cidadeField = value;
            RaisePropertyChanged(nameof(cidade));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 5)]
    public string estado
    {
        get => estadoField;
        set
        {
            estadoField = value;
            RaisePropertyChanged(nameof(estado));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 6)]
    public string codPostal
    {
        get => codPostalField;
        set
        {
            codPostalField = value;
            RaisePropertyChanged(nameof(codPostal));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 7)]
    public string telef
    {
        get => telefField;
        set
        {
            telefField = value;
            RaisePropertyChanged(nameof(telef));
        }
    }
}
