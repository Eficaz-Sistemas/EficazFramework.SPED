namespace EficazFramework.SPED.Schemas.EFD_Reinf;

/// <summary>
/// Receita de espetáculos desportivos
/// </summary>
/// <example>
/// ```csharp
/// var eventoo = new R3010()
/// {
///     Versao = Versao.v2_01_02,
///     evtEspDesportivo = new R3010EventoEspDesportivo()
///     {
///         ideContri = new R3010IdentificacaoContribuinte()
///         {
///             tpInsc = PersonalidadeJuridica.CNPJ,
///             nrInsc = "12345678",
///             ideEstab = new()
///             {
///                 new R3010IdentificacaoEstabelecimento()
///                 {
///                     tpInscEstab = PersonalidadeJuridica.CNPJ,
///                     nrInscEstab = "12345678000100,
///                     receitaTotal = new R3010ReceitaTotal()
///                     {
///                         vlrReceitaTotal = 1500000M.ToString("f2"),
///                         vlrReceitaClubes = 1250000M.ToString("f2"),
///                         vlrCP = 125000M.ToString("f2"),
///                         vlrRetParc = 0M.ToString("f2")
///                     },
///                     boletim = new()
///                     {
///                         new R3010Boletim()
///                         {
///                             nrBoletim = "1234",
///                             tpCompeticao = TipoCompeticao.Oficial,
///                             categEvento = CategoriaEvento.Interestadual,
///                             modDesportiva = "Futebol",
///                             nomeCompeticao = "Campeonato Nacional",
///                             cnpjMandante = "32522866000159",
///                             cnpjVisitante = "73653529000188",
///                             nomeVisitante = "Rio de Janeiro FC",
///                             pracaDesportiva = "Estadio do Triângulo Mineiro",
///                             codMunic = 3129707,
///                             codMunicSpecified = true,
///                             uf = "MG",
///                             qtdePagantes = 45000,
///                             qtdeNaoPagantes = 2250,
///                             receitaIngressos = new()
///                             {
///                                 new R3010ReceitaIngressos()
///                                 {
///                                     tpIngresso = TipoIngressoCompeticao.Geral,
///                                     descIngr = "G1",
///                                     qtdeIngrVendidos = 25000,
///                                     precoIndiv = 30M.ToString("f2"),
///                                     vlrTotal = 750000M.ToString("f2")
///                                 },
///                                 new R3010ReceitaIngressos()
///                                 {
///                                     tpIngresso = TipoIngressoCompeticao.Arquibancada,
///                                     descIngr = "A1",
///                                     qtdeIngrVendidos = 750,
///                                     precoIndiv = 300M.ToString("f2"),
///                                     vlrTotal = 225000M.ToString("f2")
///                                 }
///                             },
///                             outrasReceitas = new()
///                             {
///                                 new R3010OutrasReceitas()
///                                 {
///                                     tpReceita = TipoReceitaCompeticao.Transmissao,
///                                     descReceita = "TV",
///                                     vlrReceita = 175000M.ToString("f2")
///                                 },
///                                 new R3010OutrasReceitas()
///                                 {
///                                     tpReceita = TipoReceitaCompeticao.Propaganda,
///                                     descReceita = "Anunciantes",
///                                     vlrReceita = 80000M.ToString("f2")
///                                 }
///                             }
///                         }
///                     }
///                 }
///             }
///         },
///         ideEvento = new R3010IdentificacaoEvento()
///         {
///             indRetif = IndicadorRetificacao.Original,
///             dtApuracao = DateTime.Now.AddMonths(-1),
///             procEmi = EmissorEvento.AppContribuinte,
///             tpAmb = Ambiente.ProducaoRestrita_DadosReais,
///             verProc = "2.2"
///         }
///     }
/// };
/// ```
/// </example>
[Serializable()]
public partial class R3010 : Evento
{
    private R3010EventoEspDesportivo evtEspDesportivoField;
    private SignatureType signatureField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public R3010EventoEspDesportivo evtEspDesportivo
    {
        get => evtEspDesportivoField;

        set
        {
            evtEspDesportivoField = value;
            RaisePropertyChanged(nameof(evtEspDesportivo));
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
        evtEspDesportivo.id = $"ID{(int)(evtEspDesportivo?.ideContri?.tpInsc ?? PersonalidadeJuridica.CNPJ)}{evtEspDesportivo?.ideContri?.NumeroInscricaoTag() ?? "00000000000000"}{ReinfTimeStampUtils.GetTimeStampIDForEvent()}";

    /// <exclude/>
    public override string ContribuinteCNPJ() =>
        evtEspDesportivo.ideContri.nrInsc;


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
    public override XmlSerializer DefineSerializer() =>
        new(typeof(R3010), new XmlRootAttribute("Reinf") { Namespace = $"http://www.reinf.esocial.gov.br/schemas/evtEspDesportivo/{Versao}", IsNullable = false });
}


/// <exclude />
public partial class R3010EventoEspDesportivo : EfdReinfBindableObject
{
    private R3010IdentificacaoEvento ideEventoField;
    private R3010IdentificacaoContribuinte ideContriField;
    private string idField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public R3010IdentificacaoEvento ideEvento
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
    public R3010IdentificacaoContribuinte ideContri
    {
        get => ideContriField;

        set
        {
            ideContriField = value;
            RaisePropertyChanged(nameof(ideContri));
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


// Identificação Evento:
/// <exclude />
public partial class R3010IdentificacaoEvento : EfdReinfBindableObject
{
    private IndicadorRetificacao indRetifField = IndicadorRetificacao.Original;
    private string nrReciboField;
    private DateTime dtApuracaoField;
    private Ambiente tpAmbField = Ambiente.Producao;
    private EmissorEvento procEmiField = EmissorEvento.AppContribuinte;
    private string verProcField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public IndicadorRetificacao indRetif
    {
        get => indRetifField;

        set
        {
            indRetifField = value;
            RaisePropertyChanged(nameof(indRetif));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nrRecibo
    {
        get => nrReciboField;

        set
        {
            nrReciboField = value;
            RaisePropertyChanged(nameof(nrRecibo));
        }
    }

    /// <remarks/>
    [XmlElement(DataType = "date", Order = 2)]
    public DateTime dtApuracao
    {
        get => dtApuracaoField;

        set
        {
            dtApuracaoField = value;
            RaisePropertyChanged(nameof(dtApuracao));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public Ambiente tpAmb
    {
        get => tpAmbField;

        set
        {
            tpAmbField = value;
            RaisePropertyChanged(nameof(tpAmb));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public EmissorEvento procEmi
    {
        get => procEmiField;

        set
        {
            procEmiField = value;
            RaisePropertyChanged(nameof(procEmi));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 5)]
    public string verProc
    {
        get => verProcField;

        set
        {
            verProcField = value;
            RaisePropertyChanged(nameof(verProc));
        }
    }
}


// Identificação Contribuinte:
/// <exclude />
public partial class R3010IdentificacaoContribuinte : EfdReinfBindableObject
{
    private PersonalidadeJuridica tpInscField;
    private string nrInscField;
    private List<R3010IdentificacaoEstabelecimento> ideEstabField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public PersonalidadeJuridica tpInsc
    {
        get => tpInscField;

        set
        {
            tpInscField = value;
            RaisePropertyChanged(nameof(tpInsc));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nrInsc
    {
        get => nrInscField;

        set
        {
            nrInscField = value;
            RaisePropertyChanged(nameof(nrInsc));
        }
    }

    /// <remarks/>
    [XmlElement("ideEstab", Order = 2)]
    public List<R3010IdentificacaoEstabelecimento> ideEstab
    {
        get => ideEstabField;

        set
        {
            ideEstabField = value;
            RaisePropertyChanged(nameof(ideEstab));
        }
    }

    public string NumeroInscricaoTag() =>
        Extensions.String.ToFixedLenghtString(nrInsc, 14, Extensions.Alignment.Left, "0");
}


/// <exclude />
public partial class R3010IdentificacaoEstabelecimento : EfdReinfBindableObject
{
    private PersonalidadeJuridica tpInscEstabField;
    private string nrInscEstabField;
    private List<R3010Boletim> boletimField;
    private R3010ReceitaTotal receitaTotalField;

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
    [XmlElement("boletim", Order = 2)]
    public List<R3010Boletim> boletim
    {
        get => boletimField;

        set
        {
            boletimField = value;
            RaisePropertyChanged(nameof(boletim));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public R3010ReceitaTotal receitaTotal
    {
        get => receitaTotalField;

        set
        {
            receitaTotalField = value;
            RaisePropertyChanged(nameof(receitaTotal));
        }
    }
}


// Identificação Evento:
/// <exclude />
public partial class R3010Boletim : EfdReinfBindableObject
{
    private string nrBoletimField;
    private TipoCompeticao tpCompeticaoField;
    private CategoriaEvento categEventoField;
    private string modDesportivaField;
    private string nomeCompeticaoField;
    private string cnpjMandanteField;
    private string cnpjVisitanteField;
    private string nomeVisitanteField;
    private string pracaDesportivaField;
    private uint codMunicField;
    private bool codMunicFieldSpecified;
    private string ufField;
    private uint qtdePagantesField;
    private uint qtdeNaoPagantesField;
    private List<R3010ReceitaIngressos> receitaIngressosField;
    private List<R3010OutrasReceitas> outrasReceitasField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string nrBoletim
    {
        get => nrBoletimField;

        set
        {
            nrBoletimField = value;
            RaisePropertyChanged(nameof(nrBoletim));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public TipoCompeticao tpCompeticao
    {
        get => tpCompeticaoField;

        set
        {
            tpCompeticaoField = value;
            RaisePropertyChanged(nameof(tpCompeticao));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public CategoriaEvento categEvento
    {
        get => categEventoField;

        set
        {
            categEventoField = value;
            RaisePropertyChanged(nameof(categEvento));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string modDesportiva
    {
        get => modDesportivaField;

        set
        {
            modDesportivaField = value;
            RaisePropertyChanged(nameof(modDesportiva));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public string nomeCompeticao
    {
        get => nomeCompeticaoField;

        set
        {
            nomeCompeticaoField = value;
            RaisePropertyChanged(nameof(nomeCompeticao));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 5)]
    public string cnpjMandante
    {
        get => cnpjMandanteField;

        set
        {
            cnpjMandanteField = value;
            RaisePropertyChanged(nameof(cnpjMandante));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 6)]
    public string cnpjVisitante
    {
        get => cnpjVisitanteField;

        set
        {
            cnpjVisitanteField = value;
            RaisePropertyChanged(nameof(cnpjVisitante));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 7)]
    public string nomeVisitante
    {
        get => nomeVisitanteField;

        set
        {
            nomeVisitanteField = value;
            RaisePropertyChanged(nameof(nomeVisitante));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 8)]
    public string pracaDesportiva
    {
        get => pracaDesportivaField;

        set
        {
            pracaDesportivaField = value;
            RaisePropertyChanged(nameof(pracaDesportiva));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 9)]
    public uint codMunic
    {
        get => codMunicField;

        set
        {
            codMunicField = value;
            RaisePropertyChanged(nameof(codMunic));
        }
    }

    /// <remarks/>
    [XmlIgnore()]
    public bool codMunicSpecified
    {
        get => codMunicFieldSpecified;

        set
        {
            codMunicFieldSpecified = value;
            RaisePropertyChanged(nameof(codMunicSpecified));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 10)]
    public string uf
    {
        get => ufField;

        set
        {
            ufField = value;
            RaisePropertyChanged(nameof(uf));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 11)]
    public uint qtdePagantes
    {
        get => qtdePagantesField;

        set
        {
            qtdePagantesField = value;
            RaisePropertyChanged(nameof(qtdePagantes));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 12)]
    public uint qtdeNaoPagantes
    {
        get => qtdeNaoPagantesField;

        set
        {
            qtdeNaoPagantesField = value;
            RaisePropertyChanged(nameof(qtdeNaoPagantes));
        }
    }

    /// <remarks/>
    [XmlElement("receitaIngressos", Order = 13)]
    public List<R3010ReceitaIngressos> receitaIngressos
    {
        get => receitaIngressosField;

        set
        {
            receitaIngressosField = value;
            RaisePropertyChanged(nameof(receitaIngressos));
        }
    }

    /// <remarks/>
    [XmlElement("outrasReceitas", Order = 14)]
    public List<R3010OutrasReceitas> outrasReceitas
    {
        get => outrasReceitasField;

        set
        {
            outrasReceitasField = value;
            RaisePropertyChanged(nameof(outrasReceitas));
        }
    }
}


/// <exclude />
public partial class R3010ReceitaIngressos : EfdReinfBindableObject
{
    private TipoIngressoCompeticao tpIngressoField;
    private string descIngrField;
    private uint qtdeIngrVendaField;
    private uint qtdeIngrVendidosField;
    private uint qtdeIngrDevField;
    private string precoIndivField;
    private string vlrTotalField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public TipoIngressoCompeticao tpIngresso
    {
        get => tpIngressoField;

        set
        {
            tpIngressoField = value;
            RaisePropertyChanged(nameof(tpIngresso));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string descIngr
    {
        get => descIngrField;

        set
        {
            descIngrField = value;
            RaisePropertyChanged(nameof(descIngr));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public uint qtdeIngrVenda
    {
        get => qtdeIngrVendaField;

        set
        {
            qtdeIngrVendaField = value;
            RaisePropertyChanged(nameof(qtdeIngrVenda));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public uint qtdeIngrVendidos
    {
        get => qtdeIngrVendidosField;

        set
        {
            qtdeIngrVendidosField = value;
            RaisePropertyChanged(nameof(qtdeIngrVendidos));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public uint qtdeIngrDev
    {
        get => qtdeIngrDevField;

        set
        {
            qtdeIngrDevField = value;
            RaisePropertyChanged(nameof(qtdeIngrDev));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 5)]
    public string precoIndiv
    {
        get => precoIndivField;

        set
        {
            precoIndivField = value;
            RaisePropertyChanged(nameof(precoIndiv));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 6)]
    public string vlrTotal
    {
        get => vlrTotalField;

        set
        {
            vlrTotalField = value;
            RaisePropertyChanged(nameof(vlrTotal));
        }
    }
}


/// <exclude />
public partial class R3010OutrasReceitas : EfdReinfBindableObject
{
    private TipoReceitaCompeticao tpReceitaField;
    private string vlrReceitaField;
    private string descReceitaField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public TipoReceitaCompeticao tpReceita
    {
        get => tpReceitaField;

        set
        {
            tpReceitaField = value;
            RaisePropertyChanged(nameof(tpReceita));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string vlrReceita
    {
        get => vlrReceitaField;

        set
        {
            vlrReceitaField = value;
            RaisePropertyChanged(nameof(vlrReceita));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string descReceita
    {
        get => descReceitaField;

        set
        {
            descReceitaField = value;
            RaisePropertyChanged(nameof(descReceita));
        }
    }
}


/// <exclude />
public partial class R3010ReceitaTotal : EfdReinfBindableObject
{
    private string vlrReceitaTotalField;
    private string vlrCPField;
    private string vlrCPSuspTotalField;
    private string vlrReceitaClubesField;
    private string vlrRetParcField;
    private R3010InfoProcesso[] infoProcField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string vlrReceitaTotal
    {
        get => vlrReceitaTotalField;

        set
        {
            vlrReceitaTotalField = value;
            RaisePropertyChanged(nameof(vlrReceitaTotal));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string vlrCP
    {
        get => vlrCPField;

        set
        {
            vlrCPField = value;
            RaisePropertyChanged(nameof(vlrCP));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
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
    [XmlElement(Order = 3)]
    public string vlrReceitaClubes
    {
        get => vlrReceitaClubesField;

        set
        {
            vlrReceitaClubesField = value;
            RaisePropertyChanged(nameof(vlrReceitaClubes));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public string vlrRetParc
    {
        get => vlrRetParcField;

        set
        {
            vlrRetParcField = value;
            RaisePropertyChanged(nameof(vlrRetParc));
        }
    }

    /// <remarks/>
    [XmlElement("infoProc", Order = 5)]
    public R3010InfoProcesso[] infoProc
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
public partial class R3010InfoProcesso : EfdReinfBindableObject
{
    private TipoProcesso tpProcField;
    private string nrProcField;
    private string codSuspField;
    private string vlrCPSuspField;

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
}
