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

public class InfoMultiplosVinculos : ESocialBindableObject
{
    private int indMV = 3;
    private List<RemuneracaoOutrasEmpresas> remunOutrEmpr;

    /// <summary>
    /// <b>Valores válidos:</b><br/><br/>
    /// 1. O declarante aplica a(s) alíquota(s) de desconto do segurado sobre a remuneração por ele 
    /// informada (o percentual da(s) alíquota(s) será(ão) obtido(s) considerando a remuneração total 
    /// do trabalhador)<br/><br/>
    /// 2. O declarante aplica a(s) alíquota(s) de desconto do segurado sobre a diferença entre o 
    /// limite máximo do salário de contribuição e a remuneração de outra(s) empresa(s) para as quais 
    /// o trabalhador informou que houve o desconto<br/><br/>
    /// 3 - O declarante não realiza desconto do segurado, uma vez que houve desconto sobre o limite 
    /// máximo de salário de contribuição em outra(s) empresa(s)
    /// </summary>
    [XmlElement(ElementName = "indMV")]
    public int IndMV
    {
        get => indMV;
        set
        {
            indMV = value;
            RaisePropertyChanged(nameof(IndMV));
        }
    }

    [XmlElement(ElementName = "remunOutrEmpr")]
    public List<RemuneracaoOutrasEmpresas> RemunOutrEmpr
    {
        get => remunOutrEmpr;
        set
        {
            remunOutrEmpr = value;
            RaisePropertyChanged(nameof(RemunOutrEmpr));
        }
    }
}

public class RemuneracaoOutrasEmpresas : ESocialBindableObject
{
    private PersonalidadeJuridica tpInsc;
    private string nrInsc;
    private string codCateg;
    private decimal vlrRemunOE;

    [XmlElement(ElementName = "tpInsc")]
    public PersonalidadeJuridica TpInsc
    {
        get => tpInsc;
        set
        {
            tpInsc = value;
            RaisePropertyChanged(nameof(TpInsc));
        }
    }

    [XmlElement(ElementName = "nrInsc")]
    public string NrInsc
    {
        get => nrInsc;
        set
        {
            nrInsc = value;
            RaisePropertyChanged(nameof(NrInsc));
        }
    }

    [XmlElement(ElementName = "codCateg")]
    public string CodCateg
    {
        get => codCateg;
        set
        {
            codCateg = value;
            RaisePropertyChanged(nameof(CodCateg));
        }
    }

    [XmlElement(ElementName = "vlrRemunOE")]
    public decimal VlrRemunOE
    {
        get => vlrRemunOE;
        set
        {
            vlrRemunOE = value;
            RaisePropertyChanged(nameof(VlrRemunOE));
        }
    }
}
