namespace EficazFramework.SPED.Schemas.EFD_Reinf;

/// <summary>
/// Comercialização da produção p/ produtor rural PJ/agroindústria
/// </summary>
/// <example>
/// ```csharp
/// var evento = new R2050() 
/// {
///     Versao = Versao.v2_01_02,
///     evtComProd = new R2050EventoInfoComProdutor()
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
///         infoComProd = new R2050InfoComProdutor()
///         {
///             ideEstab = new()
///             {
///                 tpInscEstab = PersonalidadeJuridica.CNPJ,
///                 nrInscEstab = "61918769000188",
///                 vlrRecBrutaTotal = 1000.01M.ToString("f2"),
///                 vlrCPApur = 15.02M.ToString("f2"),
///                 vlrRatApur = 2.01M.ToString("f2"),
///                 vlrSenarApur = 1.01M.ToString("f2"),
///                 tipoCom = new()
///                 {
///                     new R2050TipoComercializacao()
///                     {
///                         indCom = IndicadorContribuicaoProd.PJ_Agrodind,
///                         vlrRecBruta = 1000.01M.ToString("f2")
///                     }
///                 }
///             }
///         },
///     }
/// };
/// ```
/// </example>
[Serializable()]
public partial class R2050 : Evento
{
    private R2050EventoInfoComProdutor evtComProdField;
    private SignatureType signatureField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public R2050EventoInfoComProdutor evtComProd
    {
        get => evtComProdField;

        set
        {
            evtComProdField = value;
            RaisePropertyChanged(nameof(evtComProd));
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
        evtComProdField.id = $"ID{(int)(evtComProdField?.ideContri?.tpInsc ?? PersonalidadeJuridica.CNPJ)}{evtComProdField?.ideContri?.NumeroInscricaoTag() ?? "00000000000000"}{ReinfTimeStampUtils.GetTimeStampIDForEvent()}";

    /// <exclude/>
    public override string ContribuinteCNPJ() =>
        evtComProd.ideContri.nrInsc;


    // IXmlSignableDocument Members
    /// <exclude/>
    public override string TagToSign => "Reinf";
    /// <exclude/>
    public override string TagId => "evtRetPF";
    /// <exclude/>
    public override bool EmptyURI => true;
    /// <exclude/>
    public override bool SignAsSHA256 => true;


    // Serialization Members
    /// <exclude/>
    public override XmlSerializer DefineSerializer() =>
        new(typeof(R2050), new XmlRootAttribute("Reinf") { Namespace = $"http://www.reinf.esocial.gov.br/schemas/evtInfoProdRural/{Versao}", IsNullable = false });
}


/// <exclude />
public partial class R2050EventoInfoComProdutor : EfdReinfBindableObject
{
    private IdentificacaoEventoPeriodico ideEventoField;
    private IdentificacaoContribuinte ideContriField;
    private R2050InfoComProdutor infoComProdField;
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
    public R2050InfoComProdutor infoComProd
    {
        get => infoComProdField;

        set
        {
            infoComProdField = value;
            RaisePropertyChanged(nameof(infoComProd));
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
public partial class R2050InfoComProdutor : EfdReinfBindableObject
{
    private R2050IdentificacaoEstabelecimento ideEstabField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public R2050IdentificacaoEstabelecimento ideEstab
    {
        get => ideEstabField;

        set
        {
            ideEstabField = value;
            RaisePropertyChanged(nameof(ideEstab));
        }
    }
}


/// <exclude />
public partial class R2050IdentificacaoEstabelecimento : EfdReinfBindableObject
{
    private PersonalidadeJuridica tpInscEstabField;
    private string nrInscEstabField;
    private string vlrRecBrutaTotalField;
    private string vlrCPApurField;
    private string vlrRatApurField;
    private string vlrSenarApurField;
    private string vlrCPSuspTotalField;
    private string vlrRatSuspTotalField;
    private string vlrSenarSuspTotalField;
    private List<R2050TipoComercializacao> tipoComField;

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

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string vlrRecBrutaTotal
    {
        get => vlrRecBrutaTotalField;

        set
        {
            vlrRecBrutaTotalField = value;
            RaisePropertyChanged(nameof(vlrRecBrutaTotal));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string vlrCPApur
    {
        get => vlrCPApurField;

        set
        {
            vlrCPApurField = value;
            RaisePropertyChanged(nameof(vlrCPApur));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public string vlrRatApur
    {
        get => vlrRatApurField;

        set
        {
            vlrRatApurField = value;
            RaisePropertyChanged(nameof(vlrRatApur));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 5)]
    public string vlrSenarApur
    {
        get => vlrSenarApurField;

        set
        {
            vlrSenarApurField = value;
            RaisePropertyChanged(nameof(vlrSenarApur));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 6)]
    public string vlrCPSuspTotal
    {
        get => vlrCPSuspTotalField;

        set
        {
            vlrCPSuspTotalField = value;
            RaisePropertyChanged(nameof(vlrCPSuspTotal));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 7)]
    public string vlrRatSuspTotal
    {
        get => vlrRatSuspTotalField;

        set
        {
            vlrRatSuspTotalField = value;
            RaisePropertyChanged(nameof(vlrRatSuspTotal));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 8)]
    public string vlrSenarSuspTotal
    {
        get => vlrSenarSuspTotalField;

        set
        {
            vlrSenarSuspTotalField = value;
            RaisePropertyChanged(nameof(vlrSenarSuspTotal));
        }
    }

    /// <remarks/>
    [XmlElement("tipoCom", Order = 9)]
    public List<R2050TipoComercializacao> tipoCom
    {
        get => tipoComField;

        set
        {
            tipoComField = value;
            RaisePropertyChanged(nameof(tipoCom));
        }
    }
}


/// <exclude />
public partial class R2050TipoComercializacao : EfdReinfBindableObject
{
    private IndicadorContribuicaoProd indComField;
    private string vlrRecBrutaField;
    private List<R2050InfoProcesso> infoProcField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public IndicadorContribuicaoProd indCom
    {
        get => indComField;

        set
        {
            indComField = value;
            RaisePropertyChanged(nameof(indCom));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string vlrRecBruta
    {
        get => vlrRecBrutaField;

        set
        {
            vlrRecBrutaField = value;
            RaisePropertyChanged(nameof(vlrRecBruta));
        }
    }

    /// <remarks/>
    [XmlElement("infoProc", Order = 2)]
    public List<R2050InfoProcesso> infoProc
    {
        get => infoProcField;

        set
        {
            infoProcField = value;
            RaisePropertyChanged(nameof(infoProc));
        }
    }
}


/// <exclude />
public partial class R2050InfoProcesso : EfdReinfBindableObject
{
    private TipoProcesso tpProcField;
    private string nrProcField;
    private string codSuspField;
    private string vlrCPSuspField;
    private string vlrRatSuspField;
    private string vlrSenarSuspField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public TipoProcesso tpProc
    {
        get => tpProcField;

        set
        {
            tpProcField = value;
            RaisePropertyChanged(nameof(tpProc));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
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
    [XmlElement(Order = 2)]
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
    [XmlElement(Order = 3)]
    public string vlrCPSusp
    {
        get => vlrCPSuspField;

        set
        {
            vlrCPSuspField = value;
            RaisePropertyChanged(nameof(vlrCPSusp));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public string vlrRatSusp
    {
        get => vlrRatSuspField;

        set
        {
            vlrRatSuspField = value;
            RaisePropertyChanged(nameof(vlrRatSusp));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 5)]
    public string vlrSenarSusp
    {
        get => vlrSenarSuspField;

        set
        {
            vlrSenarSuspField = value;
            RaisePropertyChanged(nameof(vlrSenarSusp));
        }
    }
}