namespace EficazFramework.SPED.Schemas.EFD_Reinf;

/// <summary>
/// Evento totalizador por contribuinte. Retorno do fechamento da série R-2000.
/// </summary>
[Serializable()]
public partial class R9011 : EventoRetorno
{
    private R9011EventoRetornoTotal evtTotalContribField;
    private SignatureType signatureField;

    [XmlElement(Order = 0)]
    public R9011EventoRetornoTotal evtTotalContrib
    {
        get => evtTotalContribField;
        set
        {
            evtTotalContribField = value;
            RaisePropertyChanged(nameof(evtTotalContrib));
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
        evtTotalContrib.ideContri.nrInsc;

    // Serialization Members
    /// <exclude/>
    public override XmlSerializer DefineSerializer() =>
        new XmlSerializer(typeof(R9001), new XmlRootAttribute("Reinf")
        {
            Namespace = $"http://www.reinf.esocial.gov.br/schemas/evtTotalContrib/{Versao}",
            IsNullable = false
        });
}


/// <summary>
/// Evento Totalizador - Retorno dos eventos da série R-2000, exceto pelo fechamento e/ou reabertura (R-2099 e R-2098)
/// </summary>
public partial class R9011EventoRetornoTotal : EventoRetornoTotal
{
    private R9011InfoTotal infoTotalContribField;

    /// <summary>
    /// Informacoes relativas as Totalizacoes
    /// </summary>
    [XmlElement()]
    public R9011InfoTotal infoTotalContrib
    {
        get => infoTotalContribField;
        set
        {
            infoTotalContribField = value;
            RaisePropertyChanged(nameof(infoTotalContrib));
        }
    }
}


public partial class R9011InfoTotal : TotalSerieR2000
{
    private string nrRecArqBaseField;
    private uint indExistInfoField;
    private uint identEscritDCTFField;

    [Obsolete("Removido no schema 2.01.02B")]
    public string nrRecArqBase
    {
        get => nrRecArqBaseField;
        set
        {
            nrRecArqBaseField = value;
            RaisePropertyChanged(nameof(nrRecArqBase));
        }
    }

    public uint indExistInfo
    {
        get => indExistInfoField;
        set
        {
            indExistInfoField = value;
            RaisePropertyChanged(nameof(indExistInfo));
        }
    }

    public uint identEscritDCTF
    {
        get => identEscritDCTFField;
        set
        {
            identEscritDCTFField = value;
            RaisePropertyChanged(nameof(identEscritDCTF));
        }
    }
}