namespace EficazFramework.SPED.Schemas.eSocial;

[Serializable()]
public class S1200 : Evento
{
    private EvtRemun evtRemunField;
    private SignatureType signatureField;

    public EvtRemun evtRemun
    {
        get => evtRemunField;
        set
        {
            evtRemunField = value;
            RaisePropertyChanged(nameof(evtRemun));
        }
    }

    /// <remarks/>
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


    // Evento Members
    /// <exclude/>
    public override string ContribuinteCNPJ()
        => evtRemun.ideEmpregador.nrInsc;

    /// <exclude/>
    public override void GeraEventoID()
        => evtRemun.Id = string.Format("ID{0}{1}{2}", (int)(evtRemun?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtRemun?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000", eSocialTimeStampUtils.GetTimeStampIDForEvent());

    // IXmlSignableDocument Members
    /// <exclude/>
    public override string TagToSign => Evento.root;
    /// <exclude/>
    public override string TagId { get; }
    /// <exclude/>
    public override bool EmptyURI => true;
    /// <exclude/>
    public override bool SignAsSHA256 => true;
}

public class EvtRemun : ESocialBindableObject
{
    private IdeEventoPeriodico ideEventoField;
    private Empregador ideEmpregadorField;
    private Trabalhador ideTrabalhadorField;
    private List<DmDev> dmDevField;
    private string idField;

    public IdeEventoPeriodico ideEvento
    {
        get => ideEventoField;
        set
        {
            ideEventoField = value;
            RaisePropertyChanged(nameof(ideEvento));
        }
    }

    public Empregador ideEmpregador
    {
        get => ideEmpregadorField;
        set
        {
            ideEmpregadorField = value;
            RaisePropertyChanged(nameof(ideEmpregador));
        }
    }

    public Trabalhador ideTrabalhador
    {
        get => ideTrabalhadorField;
        set
        {
            ideTrabalhadorField = value;
            RaisePropertyChanged(nameof(ideTrabalhador));
        }
    }

    public List<DmDev> dmDev
    {
        get => dmDevField;
        set
        {
            dmDevField = value;
            RaisePropertyChanged(nameof(dmDev));
        }
    }

    [XmlAttribute(DataType = "ID")]
    public string Id
    {
        get => idField;
        set
        {
            idField = value;
            RaisePropertyChanged(nameof(Id));
        }
    }
}


