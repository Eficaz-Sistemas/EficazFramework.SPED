namespace EficazFramework.SPED.Schemas.EFD_Reinf;

/// <summary>
/// Informações de bases e tributos por evento. Retorno da série R-2000.
/// </summary>
[Serializable()]
public partial class R9001 : EventoRetorno
{
    //private ReinfEvtTotal evtTotalField;
    private SignatureType signatureField;

    [XmlElement(Order = 0)]
    //public ReinfEvtTotal evtTotal
    //{
    //    get
    //    {
    //        return evtTotalField;
    //    }

    //    set
    //    {
    //        evtTotalField = value;
    //        RaisePropertyChanged("evtTotal");
    //    }
    //}

    /// <exclude/>
    [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#", Order = 1)]
    public SignatureType Signature
    {
        get
        {
            return signatureField;
        }

        set
        {
            signatureField = value;
            RaisePropertyChanged("Signature");
        }
    }

    /// <exclude/>
    public override string ContribuinteCNPJ() =>
        throw new NotImplementedException();

    // Serialization Members
    /// <exclude/>
    public override XmlSerializer DefineSerializer() =>
        new XmlSerializer(typeof(R9001), new XmlRootAttribute("Reinf")
        {
            Namespace = $"http://www.reinf.esocial.gov.br/schemas/evtTotal/{Versao}",
            IsNullable = false
        });
}