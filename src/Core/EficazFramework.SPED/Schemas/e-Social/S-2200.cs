namespace EficazFramework.SPED.Schemas.eSocial;

[Serializable()]
public partial class S2200 : Evento
{
    private S2200Admissao evtAdmissaoField;
    private SignatureType signatureField;

    public S2200Admissao evtAdmissao
    {
        get => evtAdmissaoField;
        set
        {
            evtAdmissaoField = value;
            RaisePropertyChanged(nameof(evtAdmissao));
        }
    }

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
    /// <exclude/>
    public override void GeraEventoID()
        => evtAdmissaoField.Id = string.Format("ID{0}{1}{2}", (int)(evtAdmissaoField?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtAdmissaoField?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000", eSocialTimeStampUtils.GetTimeStampIDForEvent());

    /// <exclude/>
    public override string ContribuinteCNPJ()
        => evtAdmissaoField.ideEmpregador.nrInsc;


    // IXmlSignableDocument Members
    /// <exclude/>
    public override string TagToSign => Evento.root;
    /// <exclude/>
    public override string TagId => "evtAdmissao";
    /// <exclude/>
    public override bool EmptyURI => true;
    /// <exclude/>
    public override bool SignAsSHA256 => true;


    // Serialization Members
    /// <exclude/>
    public override XmlSerializer DefineSerializer() =>
        new(typeof(S2200), new XmlRootAttribute(Evento.root) { Namespace = $"http://www.esocial.gov.br/schema/evt/evtAdmissao/{Versao}", IsNullable = false });

}

public partial class S2200Admissao : ESocialBindableObject
{
    private IdeEventoNaoPeriodico ideEventoField;
    private Empregador ideEmpregadorField;
    private eSocialEvtAdmissaoTrabalhador trabalhadorField;
    private eSocialEvtAdmissaoVinculo vinculoField;
    private string idField;

    public IdeEventoNaoPeriodico ideEvento
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

    public eSocialEvtAdmissaoTrabalhador trabalhador
    {
        get => trabalhadorField;
        set
        {
            trabalhadorField = value;
            RaisePropertyChanged(nameof(trabalhador));
        }
    }

    public eSocialEvtAdmissaoVinculo vinculo
    {
        get => vinculoField;
        set
        {
            vinculoField = value;
            RaisePropertyChanged(nameof(vinculo));
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
