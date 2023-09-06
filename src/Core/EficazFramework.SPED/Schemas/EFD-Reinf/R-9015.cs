namespace EficazFramework.SPED.Schemas.EFD_Reinf;

/// <summary>
/// Evento totalizador por contribuinte. Retorno do fechamento da série R-4000.
/// </summary>
[Serializable()]
public partial class R9015 : EventoRetorno
{
    private R9015EventoRetornoTotal evtRetConsField;
    private SignatureType signatureField;

    [XmlElement(Order = 0)]
    public R9015EventoRetornoTotal evtRetCons
    {
        get => evtRetConsField;
        set
        {
            evtRetConsField = value;
            RaisePropertyChanged(nameof(evtRetCons));
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
        evtRetCons.ideContri.nrInsc;

    // Serialization Members
    /// <exclude/>
    public override XmlSerializer DefineSerializer() =>
        new XmlSerializer(typeof(R9015), new XmlRootAttribute("Reinf")
        {
            Namespace = $"http://www.reinf.esocial.gov.br/schemas/evtRetCons/{Versao}",
            IsNullable = false
        });
}


/// <summary>
/// Evento Totalizador - Retorno dos eventos da série R-4000, exceto pelo fechamento e/ou reabertura (R-4099)
/// </summary>
public partial class R9015EventoRetornoTotal : EventoRetornoTotal
{
    private R9015InfoTotalCnr infoCR_CNRField;
    private TotalSerieR4000 infoTotalCRField;

    /// <summary>
    /// Informacoes relativas as Totalizadores Pela Natureza do Rendimento
    /// </summary>
    [XmlElement()]
    public R9015InfoTotalCnr infoCR_CNR
    {
        get => infoCR_CNRField;
        set
        {
            infoCR_CNRField = value;
            RaisePropertyChanged(nameof(infoCR_CNR));
        }
    }

    /// <summary>
    /// Informacoes consolidadas dos tributos da empresa
    /// </summary>
    [XmlElement()]
    public TotalSerieR4000 infoTotalCR
    {
        get => infoTotalCRField;
        set
        {
            infoTotalCRField = value;
            RaisePropertyChanged(nameof(infoTotalCR));
        }
    }

}


public partial class R9015InfoTotalCnr : TotalSerieR4000
{
    private uint indExistInfoField;
    private uint identEscritDCTFField;

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