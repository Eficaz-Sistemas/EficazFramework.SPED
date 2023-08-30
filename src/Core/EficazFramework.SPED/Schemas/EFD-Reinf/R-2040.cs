namespace EficazFramework.SPED.Schemas.EFD_Reinf;

/// <summary>
/// Recursos repassados para associação desportiva
/// </summary>
/// <example>
/// ```csharp
/// var evento = new R2040()
/// {
///     Versao = Versao.v2_01_02,
///     evtAssocDespRep = new R2040EventoAssociacaoDespRepasse()
///     {
///         ideContri = new R2040IdentificacaoContribuinteAssoc()
///         {
///             tpInsc = PersonalidadeJuridica.CNPJ,
///             nrInsc = _cnpj.Substring(0, 8),
///             ideEstab = new R2040IdentificacaoEstabelecimentoAssoc()
///             {
///                 tpInscEstab = PersonalidadeJuridica.CNPJ,
///                 nrInscEstab = _cnpj,
///                 recursosRep = new()
///                 {
///                     new R2040RecursosRepassados()
///                     {
///                         cnpjAssocDesp = "61918769000188",
///                         vlrTotalRep = "600,00",
///                         vlrTotalNRet = "0,00",
///                         vlrTotalRet = "60,00",
///                         infoRecurso = new()
///                         {
///                             new R2030eR2040InfoRecurso()
///                             {
///                                 tpRepasse = TipoRepasseAssocDesp.Patrocinio,
///                                 descRecurso = "Exib. camp. nac.",
///                                 vlrBruto = "660,00",
///                                 vlrRetApur = "60,00"
///                             }
///                         }
///                     }
///                 }
///             }
///         },
///         ideEvento = new IdentificacaoEventoPeriodico()
///         {
///             indRetif = IndicadorRetificacao.Original,
///             perApur = $"{DateTime.Now.AddMonths(-1):yyyy-MM}",
///             procEmi = EmissorEvento.AppContribuinte,
///             tpAmb = Ambiente.ProducaoRestrita_DadosReais,
///             verProc = "2.2"
///         }
///     }
/// };
/// ```
/// </example>
[Serializable()]
public partial class R2040 : Evento
{
    private R2040EventoAssociacaoDespRepasse evtAssocDespRepField;
    private SignatureType signatureField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public R2040EventoAssociacaoDespRepasse evtAssocDespRep
    {
        get => evtAssocDespRepField;

        set
        {
            evtAssocDespRepField = value;
            RaisePropertyChanged("evtAssocDespRep");
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
            RaisePropertyChanged("Signature");
        }
    }


    // Evento Members
    /// <exclude/>
    public override void GeraEventoID() =>
        evtAssocDespRepField.id = $"ID{(int)(evtAssocDespRepField?.ideContri?.tpInsc ?? PersonalidadeJuridica.CNPJ)}{evtAssocDespRepField?.ideContri?.NumeroInscricaoTag() ?? "00000000000000"}{ReinfTimeStampUtils.GetTimeStampIDForEvent()}";

    /// <exclude/>
    public override string ContribuinteCNPJ() =>
        evtAssocDespRep.ideContri.nrInsc;


    // IXmlSignableDocument Members
    /// <exclude/>
    public override string TagToSign => "Reinf";
    /// <exclude/>
    public override string TagId => "evtAssocDespRep";
    /// <exclude/>
    public override bool EmptyURI => true;
    /// <exclude/>
    public override bool SignAsSHA256 => true;


    // Serialization Members
    /// <exclude/>
    public override XmlSerializer DefineSerializer() =>
        new(typeof(R2040), new XmlRootAttribute("Reinf") { Namespace = $"http://www.reinf.esocial.gov.br/schemas/evtRecursoRepassadoAssociacao/{Versao}", IsNullable = false });
}


/// <exclude />
public partial class R2040EventoAssociacaoDespRepasse : EfdReinfBindableObject
{
    private IdentificacaoEventoPeriodico ideEventoField;
    private R2040IdentificacaoContribuinteAssoc ideContriField;
    private string idField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public IdentificacaoEventoPeriodico ideEvento
    {
        get => ideEventoField;

        set
        {
            ideEventoField = value;
            RaisePropertyChanged("ideEvento");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public R2040IdentificacaoContribuinteAssoc ideContri
    {
        get => ideContriField;

        set
        {
            ideContriField = value;
            RaisePropertyChanged("ideContri");
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
            RaisePropertyChanged("id");
        }
    }
}


/// <exclude />
public partial class R2040IdentificacaoContribuinteAssoc : EfdReinfBindableObject
{
    private PersonalidadeJuridica tpInscField;
    private string nrInscField;
    private R2040IdentificacaoEstabelecimentoAssoc ideEstabField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public PersonalidadeJuridica tpInsc
    {
        get => tpInscField;

        set
        {
            tpInscField = value;
            RaisePropertyChanged("tpInsc");
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
            RaisePropertyChanged("nrInsc");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public R2040IdentificacaoEstabelecimentoAssoc ideEstab
    {
        get => ideEstabField;

        set
        {
            ideEstabField = value;
            RaisePropertyChanged("ideEstab");
        }
    }

    public string NumeroInscricaoTag()
    {
        return Extensions.String.ToFixedLenghtString(nrInsc, 14, Extensions.Alignment.Left, "0");
    }
}


/// <exclude />
public partial class R2040IdentificacaoEstabelecimentoAssoc : EfdReinfBindableObject
{
    private PersonalidadeJuridica tpInscEstabField;
    private string nrInscEstabField;
    private List<R2040RecursosRepassados> recursosRepField;

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

    /// <remarks/>
    [XmlElement("recursosRep", Order = 2)]
    public List<R2040RecursosRepassados> recursosRep
    {
        get => recursosRepField;

        set
        {
            recursosRepField = value;
            RaisePropertyChanged("recursosRep");
        }
    }
}


/// <exclude />
public partial class R2040RecursosRepassados : EfdReinfBindableObject
{
    private string cnpjAssocDespField;
    private string vlrTotalRepField;
    private string vlrTotalRetField;
    private string vlrTotalNRetField;
    private List<R2030eR2040InfoRecurso> infoRecursoField;
    private List<R2030eR2040ProcessoRelacionado> infoProcField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string cnpjAssocDesp
    {
        get => cnpjAssocDespField;

        set
        {
            cnpjAssocDespField = value;
            RaisePropertyChanged("cnpjAssocDesp");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string vlrTotalRep
    {
        get => vlrTotalRepField;

        set
        {
            vlrTotalRepField = value;
            RaisePropertyChanged("vlrTotalRep");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string vlrTotalRet
    {
        get => vlrTotalRetField;

        set
        {
            vlrTotalRetField = value;
            RaisePropertyChanged("vlrTotalRet");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string vlrTotalNRet
    {
        get => vlrTotalNRetField;

        set
        {
            vlrTotalNRetField = value;
            RaisePropertyChanged("vlrTotalNRet");
        }
    }

    /// <remarks/>
    [XmlElement("infoRecurso", Order = 4)]
    public List<R2030eR2040InfoRecurso> infoRecurso
    {
        get => infoRecursoField;

        set
        {
            infoRecursoField = value;
            RaisePropertyChanged("infoRecurso");
        }
    }

    /// <remarks/>
    [XmlElement("infoProc", Order = 5)]
    public List<R2030eR2040ProcessoRelacionado> infoProc
    {
        get => infoProcField;

        set
        {
            infoProcField = value;
            RaisePropertyChanged("infoProc");
        }
    }
}