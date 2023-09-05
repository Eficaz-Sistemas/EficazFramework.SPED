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

}