namespace EficazFramework.SPED.Schemas.EFD_Reinf;

/// <summary>
/// Contribuição previdenciária sobre a receita bruta – CPRB
/// </summary>
/// <example>
/// ```csharp
/// var evento = new R2060()
/// {
///     Versao = Versao.v2_01_02,
///     evtCPRB = new R2060EventoCprb()
///     {
///         ideContri = new IdentificacaoContribuinte()
///         {
///             tpInsc = PersonalidadeJuridica.CNPJ,
///             nrInsc = _cnpj.Substring(0, 8)
///         },
///         ideEvento = new IdentificacaoEventoPeriodico()
///         {
///             indRetif = IndicadorRetificacao.Original,
///             perApur = $"{DateTime.Now.AddMonths(-1):yyyy-MM}",
///             procEmi = EmissorEvento.AppContribuinte,
///             tpAmb = Ambiente.ProducaoRestrita_DadosReais,
///             verProc = "2.2"
///         },
///         infoCPRB = new R2060InfoCprb()
///         {
///             ideEstab = new R2060IdentificacaoEstabelecimento()
///             {
///                 tpInscEstab = PersonalidadeJuridica.CNPJ,
///                 nrInscEstab = _cnpj,
///                 vlrRecBrutaTotal = 1000.00M.ToString("f2"),
///                 vlrCPApurTotal = 110.00M.ToString("f2"),
///                 tipoCod = new()
///                 {
///                     new R2060ReceitaPorAtividade()
///                     {
///                         codAtivEcon = "12345678",
///                         vlrRecBrutaAtiv = 1000.00M.ToString("f2"),
///                         vlrExcRecBruta = 0M.ToString("f2"),
///                         vlrAdicRecBruta = 0M.ToString("f2"),
///                         vlrBcCPRB = 1000.00M.ToString("f2"),
///                         vlrCPRBapur = 110.00M.ToString("f2")
///                     }
///                 }
///             }
///         },
///     }
/// };
/// ```
/// </example>
[Serializable()]
public partial class R2060 : Evento
{
    private R2060EventoCprb evtCPRBField;
    private SignatureType signatureField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public R2060EventoCprb evtCPRB
    {
        get => evtCPRBField;

        set
        {
            evtCPRBField = value;
            RaisePropertyChanged(nameof(evtCPRB));
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
        evtCPRB.id = $"ID{(int)(evtCPRB?.ideContri?.tpInsc ?? PersonalidadeJuridica.CNPJ)}{evtCPRB?.ideContri?.NumeroInscricaoTag() ?? "00000000000000"}{ReinfTimeStampUtils.GetTimeStampIDForEvent()}";

    /// <exclude/>
    public override string ContribuinteCNPJ() =>
        evtCPRB.ideContri.nrInsc;


    // IXmlSignableDocument Members
    /// <exclude/>
    public override string TagToSign => "Reinf";
    /// <exclude/>
    public override string TagId => "evtCPRB";
    /// <exclude/>
    public override bool EmptyURI => true;
    /// <exclude/>
    public override bool SignAsSHA256 => true;


    // Serialization Members
    /// <exclude/>
    public override XmlSerializer DefineSerializer() =>
        new(typeof(R2060), new XmlRootAttribute("Reinf") { Namespace = $"http://www.reinf.esocial.gov.br/schemas/evtInfoCPRB/{Versao}", IsNullable = false });
}


/// <exclude />
public partial class R2060EventoCprb : EfdReinfBindableObject
{
    private IdentificacaoEventoPeriodico ideEventoField;
    private IdentificacaoContribuinte ideContriField;
    private R2060InfoCprb infoCPRBField;
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
    public R2060InfoCprb infoCPRB
    {
        get => infoCPRBField;

        set
        {
            infoCPRBField = value;
            RaisePropertyChanged(nameof(infoCPRB));
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
public partial class R2060InfoCprb : EfdReinfBindableObject
{
    private R2060IdentificacaoEstabelecimento ideEstabField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public R2060IdentificacaoEstabelecimento ideEstab
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
public partial class R2060IdentificacaoEstabelecimento : EfdReinfBindableObject
{
    private PersonalidadeJuridica tpInscEstabField;
    private string nrInscEstabField;
    private string vlrRecBrutaTotalField;
    private string vlrCPApurTotalField;
    private string vlrCPRBSuspTotalField;
    private List<R2060ReceitaPorAtividade> tipoCodField;

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
    public string vlrCPApurTotal
    {
        get => vlrCPApurTotalField;

        set
        {
            vlrCPApurTotalField = value;
            RaisePropertyChanged(nameof(vlrCPApurTotal));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public string vlrCPRBSuspTotal
    {
        get => vlrCPRBSuspTotalField;

        set
        {
            vlrCPRBSuspTotalField = value;
            RaisePropertyChanged(nameof(vlrCPRBSuspTotal));
        }
    }

    /// <remarks/>
    [XmlElement("tipoCod", Order = 5)]
    public List<R2060ReceitaPorAtividade> tipoCod
    {
        get => tipoCodField;

        set
        {
            tipoCodField = value;
            RaisePropertyChanged(nameof(tipoCod));
        }
    }
}


/// <exclude />
public partial class R2060ReceitaPorAtividade : EfdReinfBindableObject
{
    private string codAtivEconField;
    private string vlrRecBrutaAtivField;
    private string vlrExcRecBrutaField;
    private string vlrAdicRecBrutaField;
    private string vlrBcCPRBField;
    private string vlrCPRBapurField;
    private string observField;
    private List<R2060AjusteContribuicao> tipoAjusteField;
    private List<R2060InfoProcesso> infoProcField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string codAtivEcon
    {
        get => codAtivEconField;

        set
        {
            codAtivEconField = value;
            RaisePropertyChanged(nameof(codAtivEcon));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string vlrRecBrutaAtiv
    {
        get => vlrRecBrutaAtivField;

        set
        {
            vlrRecBrutaAtivField = value;
            RaisePropertyChanged(nameof(vlrRecBrutaAtiv));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string vlrExcRecBruta
    {
        get => vlrExcRecBrutaField;

        set
        {
            vlrExcRecBrutaField = value;
            RaisePropertyChanged(nameof(vlrExcRecBruta));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string vlrAdicRecBruta
    {
        get => vlrAdicRecBrutaField;

        set
        {
            vlrAdicRecBrutaField = value;
            RaisePropertyChanged(nameof(vlrAdicRecBruta));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public string vlrBcCPRB
    {
        get => vlrBcCPRBField;

        set
        {
            vlrBcCPRBField = value;
            RaisePropertyChanged(nameof(vlrBcCPRB));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 5)]
    public string vlrCPRBapur
    {
        get => vlrCPRBapurField;

        set
        {
            vlrCPRBapurField = value;
            RaisePropertyChanged(nameof(vlrCPRBapur));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 6)]
    public string observ
    {
        get => observField;

        set
        {
            observField = value;
            RaisePropertyChanged(nameof(observ));
        }
    }

    /// <remarks/>
    [XmlElement("tipoAjuste", Order = 7)]
    public List<R2060AjusteContribuicao> tipoAjuste
    {
        get => tipoAjusteField;

        set
        {
            tipoAjusteField = value;
            RaisePropertyChanged(nameof(tipoAjuste));
        }
    }

    /// <remarks/>
    [XmlElement("infoProc", Order = 8)]
    public List<R2060InfoProcesso> infoProc
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
public partial class R2060AjusteContribuicao : EfdReinfBindableObject
{
    private TipoAjusteContribuicao tpAjusteField;
    private string codAjusteField;
    private string vlrAjusteField;
    private string descAjusteField;
    private string dtAjusteField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public TipoAjusteContribuicao tpAjuste
    {
        get => tpAjusteField;

        set
        {
            tpAjusteField = value;
            RaisePropertyChanged(nameof(tpAjuste));
        }
    }

    /// <remarks/>
    [XmlElement(DataType = "integer", Order = 1)]
    public string codAjuste
    {
        get => codAjusteField;

        set
        {
            codAjusteField = value;
            RaisePropertyChanged(nameof(codAjuste));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string vlrAjuste
    {
        get => vlrAjusteField;

        set
        {
            vlrAjusteField = value;
            RaisePropertyChanged(nameof(vlrAjuste));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string descAjuste
    {
        get => descAjusteField;

        set
        {
            descAjusteField = value;
            RaisePropertyChanged(nameof(descAjuste));
        }
    }

    /// <remarks/>
    [XmlElement(DataType = "gYearMonth", Order = 4)]
    public string dtAjuste
    {
        get => dtAjusteField;

        set
        {
            dtAjusteField = value;
            RaisePropertyChanged(nameof(dtAjuste));
        }
    }
}


/// <exclude />
public partial class R2060InfoProcesso : EfdReinfBindableObject
{
    private TipoProcesso tpProcField;
    private string nrProcField;
    private string codSuspField;
    private string vlrCPRBSuspField;

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
    public string vlrCPRBSusp
    {
        get => vlrCPRBSuspField;

        set
        {
            vlrCPRBSuspField = value;
            RaisePropertyChanged(nameof(vlrCPRBSusp));
        }
    }
}