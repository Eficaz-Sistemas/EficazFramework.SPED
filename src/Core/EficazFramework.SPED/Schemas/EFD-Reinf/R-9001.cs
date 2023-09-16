namespace EficazFramework.SPED.Schemas.EFD_Reinf;

/// <summary>
/// Informações de bases e tributos por evento. Retorno da série R-2000.
/// </summary>
[Serializable()]
public partial class R9001 : EventoRetorno
{
    private R9001EventoRetornoTotal evtTotalField;
    private SignatureType signatureField;

    [XmlElement(Order = 0)]
    public R9001EventoRetornoTotal evtTotal
    {
        get => evtTotalField;
        set
        {
            evtTotalField = value;
            RaisePropertyChanged(nameof(evtTotal));
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

    /// <exclude/>
    public override string ContribuinteCNPJ() =>
        evtTotal.ideContri.nrInsc;

    // Serialization Members
    /// <exclude/>
    public override XmlSerializer DefineSerializer() =>
        new XmlSerializer(typeof(R9001), new XmlRootAttribute("Reinf")
        {
            Namespace = $"http://www.reinf.esocial.gov.br/schemas/evtTotal/{Versao}",
            IsNullable = false
        });
}


/// <summary>
/// Evento Totalizador - Retorno dos eventos da série R-2000, exceto pelo fechamento e/ou reabertura (R-2099 e R-2098)
/// </summary>
public partial class R9001EventoRetornoTotal : EventoRetornoTotal
{
    private R9001InfoTotal infoTotalField;

    /// <summary>
    /// Informacoes relativas as Totalizacoes
    /// </summary>
    [XmlElement()]
    public R9001InfoTotal infoTotal
    {
        get => infoTotalField;
        set
        {
            infoTotalField = value;
            RaisePropertyChanged(nameof(infoTotal));
        }
    }
}


public partial class R9001InfoTotal : EfdReinfBindableObject
{
    private R9001IdentificacaoEstabelecimento ideEstabField;

    /// <summary>
    /// Informacoes relativas as Totalizacoes
    /// </summary>
    [XmlElement()]
    public R9001IdentificacaoEstabelecimento ideEstab
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
/// Identificação do Estabelecimento do Evento Totalizador, série R-2000
/// </summary>
public partial class R9001IdentificacaoEstabelecimento : TotalSerieR2000
{
    private PersonalidadeJuridica tpInscField;
    private string nrInscField;

    /// <remarks/>
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

    /// <remarks/>
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
}