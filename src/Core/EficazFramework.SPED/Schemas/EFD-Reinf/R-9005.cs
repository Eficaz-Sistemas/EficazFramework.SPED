namespace EficazFramework.SPED.Schemas.EFD_Reinf;

/// <summary>
/// Informações de bases e tributos por evento. Retorno da série R-4000.
/// </summary>
[Serializable()]
public partial class R9005 : EventoRetorno
{
    private R9005EventoRetornoTotal evtRetField;
    private SignatureType signatureField;

    [XmlElement()]
    public R9005EventoRetornoTotal evtRet
    {
        get => evtRetField;
        set
        {
            evtRetField = value;
            RaisePropertyChanged(nameof(evtRet));
        }
    }

    /// <exclude/>
    [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public SignatureType Signature
    {
        get => signatureField;
        set
        {
            signatureField = value;
            RaisePropertyChanged(nameof(Signature));
        }
    }

    /// <exclude/>
    public override string ContribuinteCNPJ() =>
        evtRet.ideContri.nrInsc;

    // Serialization Members
    /// <exclude/>
    public override XmlSerializer DefineSerializer() =>
        new XmlSerializer(typeof(R9005), new XmlRootAttribute("Reinf")
        {
            Namespace = $"http://www.reinf.esocial.gov.br/schemas/evtRet/{Versao}",
            IsNullable = false
        });
}


/// <summary>
/// Evento Totalizador - Retorno dos eventos da série R-4000, exceto pelo fechamento e/ou reabertura (R-4099)
/// </summary>
public partial class R9005EventoRetornoTotal : EventoRetornoTotal
{
    private R9005InfoTotal infoTotalField;

    /// <summary>
    /// Informacoes relativas as Totalizacoes
    /// </summary>
    [XmlElement()]
    public R9005InfoTotal infoTotal
    {
        get => infoTotalField;
        set
        {
            infoTotalField = value;
            RaisePropertyChanged(nameof(infoTotal));
        }
    }
}


public partial class R9005InfoTotal : EfdReinfBindableObject
{
    private R9005IdentificacaoEstabelecimento ideEstabField;

    /// <summary>
    /// Informacoes relativas as Totalizacoes
    /// </summary>
    [XmlElement()]
    public R9005IdentificacaoEstabelecimento ideEstab
    {
        get => ideEstabField;
        set
        {
            ideEstabField = value;
            RaisePropertyChanged(nameof(ideEstab));
        }
    }
}


/// <summary>
/// Identificação do Estabelecimento do Evento Totalizador, série R-4000
/// </summary>
public partial class R9005IdentificacaoEstabelecimento : TotalSerieR4000
{
    private PersonalidadeJuridica tpInscField;
    private string nrInscField;
    private string nrInscBenefField;
    private string nmBenefField;
    private string ideEvtAdicField;


    [XmlElement()]
    public PersonalidadeJuridica tpInsc
    {
        get => tpInscField;
        set
        {
            tpInscField = value;
            RaisePropertyChanged(nameof(tpInsc));
        }
    }

    [XmlElement()]
    public string nrInsc
    {
        get => nrInscField;
        set
        {
            nrInscField = value;
            RaisePropertyChanged(nameof(nrInsc));
        }
    }

    [XmlElement()]
    public string nrInscBenef
    {
        get => nrInscBenefField;
        set
        {
            nrInscBenefField = value;
            RaisePropertyChanged(nameof(nrInscBenef));
        }
    }

    [XmlElement()]
    public string nmBenef
    {
        get => nmBenefField;
        set
        {
            nmBenefField = value;
            RaisePropertyChanged(nameof(nmBenef));
        }
    }

    [XmlElement()]
    public string ideEvtAdic
    {
        get => ideEvtAdicField;
        set
        {
            ideEvtAdicField = value;
            RaisePropertyChanged(nameof(ideEvtAdic));
        }
    }
}