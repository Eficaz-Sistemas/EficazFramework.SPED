namespace EficazFramework.SPED.Schemas.EFD_Reinf;

/// <summary>
/// Recursos recebidos por associação desportiva
/// </summary>
/// <example>
/// ```csharp
/// var evento = new R2030()
/// {
///     Versao = Versao.v2_01_02,
///     evtAssocDespRec = new R2030EventoAssociacaoDespRecebim()
///     {
///         ideContri = new R2030IdentificacaoContribuinteAssoc()
///         {
///             tpInsc = PersonalidadeJuridica.CNPJ,
///             nrInsc = "12345678",
///             ideEstab = new R2030IdentificacaoEstabelecimentoAssoc()
///             {
///                 tpInscEstab = PersonalidadeJuridica.CNPJ,
///                 nrInscEstab = "12345678000100",
///                 recursosRec = new()
///                 {
///                     new R2030RecursosRecebidos()
///                     {
///                         cnpjOrigRecurso = "61918769000188",
///                         vlrTotalRec = "600,00",
///                         vlrTotalNRet = "0,00",
///                         vlrTotalRet = "60,00",
///                         infoRecurso = new()
///                         {
///                             new R2030eR2040InfoRecurso()
///                             {
///                                 tpRepasse = TipoRepasseAssocDesp.Patrocinio,
///                                 descRecurso = "Exibição da marca durante campeonato nacional",
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
public partial class R2030 : Evento
{
    private R2030EventoAssociacaoDespRecebim evtAssocDespRecField;
    private SignatureType signatureField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public R2030EventoAssociacaoDespRecebim evtAssocDespRec
    {
        get => evtAssocDespRecField;

        set
        {
            evtAssocDespRecField = value;
            RaisePropertyChanged("evtAssocDespRec");
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
        evtAssocDespRec.id = $"ID{(int)(evtAssocDespRec?.ideContri?.tpInsc ?? PersonalidadeJuridica.CNPJ)}{evtAssocDespRec?.ideContri?.NumeroInscricaoTag() ?? "00000000000000"}{ReinfTimeStampUtils.GetTimeStampIDForEvent()}";

    /// <exclude/>
    public override string ContribuinteCNPJ()
    {
        return evtAssocDespRec.ideContri.nrInsc;
    }


    // IXmlSignableDocument Members
    /// <exclude/>
    public override string TagToSign => "Reinf";
    /// <exclude/>
    public override string TagId => "evtAssocDespRec";
    /// <exclude/>
    public override bool EmptyURI => true;
    /// <exclude/>
    public override bool SignAsSHA256 => true;


    // Serialization Members
    /// <exclude/>
    public override XmlSerializer DefineSerializer()
    {
        return new XmlSerializer(typeof(R2030), new XmlRootAttribute("Reinf") { Namespace = $"http://www.reinf.esocial.gov.br/schemas/evtRecursoRecebidoAssociacao/{Versao}", IsNullable = false });
    }
}


/// <exclude />
public partial class R2030EventoAssociacaoDespRecebim : EfdReinfBindableObject
{
    private IdentificacaoEventoPeriodico ideEventoField;
    private R2030IdentificacaoContribuinteAssoc ideContriField;
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
    public R2030IdentificacaoContribuinteAssoc ideContri
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
public partial class R2030IdentificacaoContribuinteAssoc : EfdReinfBindableObject
{
    private PersonalidadeJuridica tpInscField;
    private string nrInscField;
    private R2030IdentificacaoEstabelecimentoAssoc ideEstabField;

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
    public R2030IdentificacaoEstabelecimentoAssoc ideEstab
    {
        get => ideEstabField;

        set
        {
            ideEstabField = value;
            RaisePropertyChanged("ideEstab");
        }
    }

    public string NumeroInscricaoTag() =>
        Extensions.String.ToFixedLenghtString(nrInsc, 14, Extensions.Alignment.Left, "0");
}


/// <exclude />
public partial class R2030IdentificacaoEstabelecimentoAssoc : EfdReinfBindableObject
{
    private PersonalidadeJuridica tpInscEstabField;
    private string nrInscEstabField;
    private List<R2030RecursosRecebidos> recursosRecField = new();

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
    [XmlElement("recursosRec", Order = 2)]
    public List<R2030RecursosRecebidos> recursosRec
    {
        get => recursosRecField;

        set
        {
            recursosRecField = value;
            RaisePropertyChanged("recursosRec");
        }
    }
}


/// <exclude />
public partial class R2030RecursosRecebidos : EfdReinfBindableObject
{
    private string cnpjOrigRecursoField;
    private string vlrTotalRecField;
    private string vlrTotalRetField;
    private string vlrTotalNRetField;
    private List<R2030eR2040InfoRecurso> infoRecursoField;
    private List<R2030eR2040ProcessoRelacionado> infoProcField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string cnpjOrigRecurso
    {
        get => cnpjOrigRecursoField;

        set
        {
            cnpjOrigRecursoField = value;
            RaisePropertyChanged("cnpjOrigRecurso");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string vlrTotalRec
    {
        get => vlrTotalRecField;

        set
        {
            vlrTotalRecField = value;
            RaisePropertyChanged("vlrTotalRec");
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