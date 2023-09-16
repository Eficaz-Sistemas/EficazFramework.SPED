namespace EficazFramework.SPED.Schemas.EFD_Reinf;

/// <summary>
/// Reabertura dos eventos da série R-2000
/// </summary>
/// <example>
/// ```csharp
/// var registro = new R2098()
/// {
///     Versao = Versao.v2_01_02,
///     evtReabreEvPer = new R2098EventoReabrePeriodo()
///     {
///         ideContri = new EficazFramework.SPED.Schemas.EFD_Reinf.IdentificacaoContribuinte()
///         {
///             tpInsc = EficazFramework.SPED.Schemas.EFD_Reinf.PersonalidadeJuridica.CNPJ,
///             nrInsc = "12345678"
///         },
///         ideEvento = new IdentificacaoEventoFechamento()
///         {
///             perApur = $"{DateTime.Now.AddMonths(-1):yyyy-MM}",
///             tpAmb = EficazFramework.SPED.Schemas.EFD_Reinf.Ambiente.ProducaoRestrita_DadosReais,
///             procEmi = EficazFramework.SPED.Schemas.EFD_Reinf.EmissorEvento.AppContribuinte,
///             verProc = "2.2"
///         }
///     }
/// };
/// ```
/// </example>
[Serializable()]
public partial class R2098 : Evento
{
    private R2098EventoReabrePeriodo evtReabreEvPerField;
    private SignatureType signatureField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public R2098EventoReabrePeriodo evtReabreEvPer
    {
        get => evtReabreEvPerField;

        set
        {
            evtReabreEvPerField = value;
            RaisePropertyChanged(nameof(evtReabreEvPer));
        }
    }

    /// <exclude />
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
    /// <exclude />
    public override void GeraEventoID() =>
        evtReabreEvPer.id = $"ID{(int)(evtReabreEvPer?.ideContri?.tpInsc ?? PersonalidadeJuridica.CNPJ)}{evtReabreEvPer?.ideContri?.NumeroInscricaoTag() ?? "00000000000000"}{ReinfTimeStampUtils.GetTimeStampIDForEvent()}";

    /// <exclude />
    public override string ContribuinteCNPJ() =>
        evtReabreEvPer.ideContri.nrInsc;


    // IXmlSignableDocument Members
    /// <exclude />
    public override string TagToSign => "Reinf";
    /// <exclude />
    public override string TagId => "evtReabreEvPer";
    /// <exclude />
    public override bool EmptyURI => true;
    /// <exclude />
    public override bool SignAsSHA256 => true;


    // Serialization Members
    /// <exclude />
    public override XmlSerializer DefineSerializer() =>
        new(typeof(R2098), new XmlRootAttribute("Reinf") { Namespace = $"http://www.reinf.esocial.gov.br/schemas/evtReabreEvPer/{Versao}", IsNullable = false });
}


/// <exclude />
public partial class R2098EventoReabrePeriodo : EfdReinfBindableObject
{
    private IdentificacaoEventoFechamento ideEventoField;
    private IdentificacaoContribuinte ideContriField;
    private string idField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public IdentificacaoEventoFechamento ideEvento
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
