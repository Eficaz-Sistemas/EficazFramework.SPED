namespace EficazFramework.SPED.Schemas.EFD_Reinf;

/// <summary>
/// Exclusão de eventos
/// </summary>
/// <example>
/// ```csharp
/// var evento = new R9000()
/// {
///     Versao = Versao.v2_01_02,
///     evtExclusao = new R9000EventoExclusao()
///     {
///     
///         ideEvento = new IdentificacaoEvento()
///         {
///             tpAmb = Ambiente.ProducaoRestrita_DadosReais,
///             procEmi = EmissorEvento.AppContribuinte,
///             verProc = "6.0"
///         },
///         ideContri = new IdentificacaoContribuinte()
///         {
///             tpInsc = PersonalidadeJuridica.CNPJ,
///             nrInsc = "12345678"
///         },
///         infoExclusao = new ReinfEvtExclusaoInfoExclusao()
///         {
///             nrRecEvt = "12345-00-1234-9876-0",
///             perApur = $"{DateTime.Now.AddMonths(-1):yyyy-MM}",
///             tpEvento = "R-4010" // ou qualquer outro evento que for preciso, exceto pelos de Fechamento/reabertura - R-2098, R-2099 e R-4099
///         }
///     }
/// };
/// ```
/// </example>
[Serializable()]
public partial class R9000 : Evento
{
    private R9000EventoExclusao evtExclusaoField;
    private SignatureType signatureField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public R9000EventoExclusao evtExclusao
    {
        get => evtExclusaoField;

        set
        {
            evtExclusaoField = value;
            RaisePropertyChanged("evtExclusao");
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
        evtExclusao.id = $"ID{(int)(evtExclusao?.ideContri?.tpInsc ?? PersonalidadeJuridica.CNPJ)}{evtExclusao?.ideContri?.NumeroInscricaoTag() ?? "00000000000000"}{ReinfTimeStampUtils.GetTimeStampIDForEvent()}";

    /// <exclude/>
    public override string ContribuinteCNPJ() =>
        evtExclusao.ideContri.nrInsc;


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
        new(typeof(R9000), new XmlRootAttribute("Reinf") { Namespace = $"http://www.reinf.esocial.gov.br/schemas/evtExclusao/{Versao}", IsNullable = false });
}


/// <exclude />
public partial class R9000EventoExclusao : EfdReinfBindableObject
{ 
    private IdentificacaoEvento ideEventoField;
    private IdentificacaoContribuinte ideContriField;
    private ReinfEvtExclusaoInfoExclusao infoExclusaoField;
    private string idField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public IdentificacaoEvento ideEvento
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
    public IdentificacaoContribuinte ideContri
    {
        get => ideContriField;

        set
        {
            ideContriField = value;
            RaisePropertyChanged("ideContri");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public ReinfEvtExclusaoInfoExclusao infoExclusao
    {
        get => infoExclusaoField;

        set
        {
            infoExclusaoField = value;
            RaisePropertyChanged("infoExclusao");
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



/// <summary>
/// Identificação Evento (Exclusão)
/// </summary>
/// <exclude />
public partial class ReinfEvtExclusaoInfoExclusao : EfdReinfBindableObject
{
    private string tpEventoField;
    private string nrRecEvtField;
    private string perApurField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string tpEvento
    {
        get => tpEventoField;

        set
        {
            tpEventoField = value;
            RaisePropertyChanged("tpEvento");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nrRecEvt
    {
        get => nrRecEvtField;

        set
        {
            nrRecEvtField = value;
            RaisePropertyChanged("nrRecEvt");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string perApur
    {
        get => perApurField;

        set
        {
            perApurField = value;
            RaisePropertyChanged("perApur");
        }
    }
}