namespace EficazFramework.SPED.Schemas.EFD_Reinf;

/// <summary>
/// Aquisição de produção rural
/// </summary>
/// <example>
/// ```csharp
/// var evento = new R2055()
/// {
///     Versao = Versao.v2_01_02,
///     evtAqProd = new EficazFramework.SPED.Schemas.EFD_Reinf.R2055EventoAquisProd()
///     {
///         ideContri = new IdentificacaoContribuinte()
///         {
///             tpInsc = PersonalidadeJuridica.CNPJ,
///             nrInsc = "12345678"
///         },
///         ideEvento = new IdentificacaoEventoPeriodico()
///         {
///             indRetif = IndicadorRetificacao.Original,
///             perApur = $"{DateTime.Now.AddMonths(-1):yyyy-MM}",
///             procEmi = EmissorEvento.AppContribuinte,
///             tpAmb = Ambiente.ProducaoRestrita_DadosReais,
///             verProc = "2.2"
///         },
///         infoAquisProd = new R2055InfoAquisProd()
///         {
///             ideEstabAdquir = new R2050IdentificacaoEstabAdquirente()
///             {
///                 tpInscAdq = PersonalidadeJuridica.CNPJ,
///                 nrInscAdq = "12345678000100",
///                 ideProdutor = new R2055IdentificacaoProdutor()
///                 {
///                     tpInscProd = PersonalidadeJuridica.CPF,
///                     nrInscProd = "07731253619",
///                     detAquis = new()
///                     {
///                         new R2055DetalhamentoAquisicao()
///                         {
///                             indAquis = IndicadorAquisProd.PF,
///                             vlrBruto = $"{1000.01D:#0.00}",
///                             vlrCPDescPR = $"{15.02:#0.00}",
///                             vlrRatDescPR = $"{2.01:#0.00}",
///                             vlrSenarDesc = $"{1.01:#0.00}",
///                             infoProcJud = null
///                         }
///                     }
///                 }
///             }
///         },
///     }
/// };
/// ```
/// </example>
[Serializable()]
public partial class R2055 : Evento
{
    private R2055EventoAquisProd evtAqProdField;
    private SignatureType signatureField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public R2055EventoAquisProd evtAqProd
    {
        get => evtAqProdField;

        set
        {
            evtAqProdField = value;
            RaisePropertyChanged(nameof(evtAqProd));
        }
    }

    /// <exclude/>
    [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#", Order = 1)]
    public SignatureType Signature
    {
        get => signatureField;

        set
        {
            signatureField = value;
            RaisePropertyChanged(nameof(Signature));
        }
    }


    // Evento Members
    /// <exclude/>
    public override void GeraEventoID() =>
        evtAqProdField.id = $"ID{(int)(evtAqProdField?.ideContri?.tpInsc ?? PersonalidadeJuridica.CNPJ)}{evtAqProdField?.ideContri?.NumeroInscricaoTag() ?? "00000000000000"}{ReinfTimeStampUtils.GetTimeStampIDForEvent()}";

    /// <exclude/>
    public override string ContribuinteCNPJ() =>
        evtAqProd.ideContri.nrInsc;


    // IXmlSignableDocument Members
    /// <exclude/>
    public override string TagToSign => "Reinf";
    /// <exclude/>
    public override string TagId => "evtAqProd";
    /// <exclude/>
    public override bool EmptyURI => true;
    /// <exclude/>
    public override bool SignAsSHA256 => true;


    // Serialization Members
    /// <exclude/>
    public override XmlSerializer DefineSerializer()
    {
        return new XmlSerializer(typeof(R2055), new XmlRootAttribute("Reinf") { Namespace = $"http://www.reinf.esocial.gov.br/schemas/evt2055AquisicaoProdRural/{Versao}", IsNullable = false });
    }
}


/// <exclude />
public partial class R2055EventoAquisProd : EfdReinfBindableObject
{
    private IdentificacaoEventoPeriodico ideEventoField;
    private IdentificacaoContribuinte ideContriField;
    private R2055InfoAquisProd infoAqProdField;
    private string idField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public IdentificacaoEventoPeriodico ideEvento
    {
        get => ideEventoField;

        set
        {
            ideEventoField = value;
            RaisePropertyChanged(nameof(ideEvento));
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
            RaisePropertyChanged(nameof(ideContri));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public R2055InfoAquisProd infoAquisProd
    {
        get => infoAqProdField;

        set
        {
            infoAqProdField = value;
            RaisePropertyChanged(nameof(infoAquisProd));
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
            RaisePropertyChanged(nameof(id));
        }
    }
}


/// <exclude />
public partial class R2055InfoAquisProd : EfdReinfBindableObject
{
    private R2050IdentificacaoEstabAdquirente ideEstabField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public R2050IdentificacaoEstabAdquirente ideEstabAdquir
    {
        get => ideEstabField;

        set
        {
            ideEstabField = value;
            RaisePropertyChanged(nameof(ideEstabAdquir));
        }
    }
}


/// <exclude />
public partial class R2050IdentificacaoEstabAdquirente : EfdReinfBindableObject
{
    private PersonalidadeJuridica tpInscAdqField;
    private string nrInscAdqField;
    R2055IdentificacaoProdutor tipoComField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public PersonalidadeJuridica tpInscAdq
    {
        get => tpInscAdqField;

        set
        {
            tpInscAdqField = value;
            RaisePropertyChanged(nameof(tpInscAdq));
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
            RaisePropertyChanged(nameof(nrInscAdq));
        }
    }

    /// <remarks/>
    [XmlElement("ideProdutor", Order = 2)]
    public R2055IdentificacaoProdutor ideProdutor
    {
        get => tipoComField;

        set
        {
            tipoComField = value;
            RaisePropertyChanged(nameof(ideProdutor));
        }
    }
}


/// <exclude />
public partial class R2055IdentificacaoProdutor : EfdReinfBindableObject
{
    private PersonalidadeJuridica tpInscProdField;
    private string nrInscProdField;
    private string indOpcCPField;
    List<R2055DetalhamentoAquisicao> _detAquisField = new List<R2055DetalhamentoAquisicao>();

    /// <remarks/>
    [XmlElement(Order = 0)]
    public PersonalidadeJuridica tpInscProd
    {
        get => tpInscProdField;

        set
        {
            tpInscProdField = value;
            RaisePropertyChanged(nameof(tpInscProd));
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
            RaisePropertyChanged(nameof(nrInscProd));
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
            RaisePropertyChanged(nameof(indOpcCP));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public List<R2055DetalhamentoAquisicao> detAquis
    {
        get => _detAquisField;

        set
        {
            _detAquisField = value;
            RaisePropertyChanged(nameof(detAquis));
        }
    }

    public bool ShouldSerializeindOpcCP()
    {
        return (indOpcCPField ?? "").ToUpper() == "S";
    }
}


/// <exclude />
public partial class R2055DetalhamentoAquisicao : EfdReinfBindableObject
{
    private IndicadorAquisProd indAquisField;
    private string vlrBrutoField;
    private string vlrCPDescPRField;
    private string vlrRatDescPRField;
    private string vlrSenarDescField;
    private List<R2055InfoProcesso> infoProcJudField = new();

    /// <remarks/>
    [XmlElement(Order = 0)]
    public IndicadorAquisProd indAquis
    {
        get => indAquisField;

        set
        {
            indAquisField = value;
            RaisePropertyChanged(nameof(indAquis));
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
            RaisePropertyChanged(nameof(vlrBruto));
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
            RaisePropertyChanged(nameof(vlrCPDescPR));
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
            RaisePropertyChanged(nameof(vlrRatDescPR));
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
            RaisePropertyChanged(nameof(vlrSenarDesc));
        }
    }

    /// <remarks/>
    [XmlElement("ideProdutor", Order = 5)]
    public List<R2055InfoProcesso> infoProcJud
    {
        get => infoProcJudField;

        set
        {
            infoProcJudField = value;
            RaisePropertyChanged(nameof(infoProcJud));
        }
    }
}


/// <exclude />
public partial class R2055InfoProcesso : EfdReinfBindableObject
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
            RaisePropertyChanged(nameof(nrProcJud));
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
            RaisePropertyChanged(nameof(codSusp));
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
            RaisePropertyChanged(nameof(vlrCPNRet));
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
            RaisePropertyChanged(nameof(vlrRatNRet));
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
            RaisePropertyChanged(nameof(vlrSenarNRet));
        }
    }
}
