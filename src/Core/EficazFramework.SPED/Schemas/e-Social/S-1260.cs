using System.Collections.ObjectModel;

namespace EficazFramework.SPED.Schemas.eSocial;

[Serializable()]
public partial class S1260 : Evento
{
    private S1260ComercializacaoProd evtComProdField;
    private SignatureType signatureField;

    public S1260ComercializacaoProd evtComProd
    {
        get => evtComProdField;
        set
        {
            evtComProdField = value;
            RaisePropertyChanged(nameof(evtComProd));
        }
    }

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
    public override void GeraEventoID()
        => evtComProdField.Id = string.Format("ID{0}{1}{2}", (int)(evtComProdField?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtComProdField?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000", eSocialTimeStampUtils.GetTimeStampIDForEvent());

    /// <exclude/>
    public override string ContribuinteCNPJ()
        => evtComProdField.ideEmpregador.nrInsc;


    // IXmlSignableDocument Members
    /// <exclude/>
    public override string TagToSign => Evento.root;
    /// <exclude/>
    public override string TagId => "evtComProd";
    /// <exclude/>
    public override bool EmptyURI => true;
    /// <exclude/>
    public override bool SignAsSHA256 => true;


    // Serialization Members
    /// <exclude/>
    public override XmlSerializer DefineSerializer() =>
        new(typeof(S2200), new XmlRootAttribute(Evento.root) { Namespace = $"http://www.esocial.gov.br/schema/evt/evtComProd/{Versao}", IsNullable = false });
}

public partial class S1260ComercializacaoProd : ESocialBindableObject
{
    private IdeEventoPeriodico ideEventoField;
    private Empregador ideEmpregadorField;
    private S1260InfoComProducao infoComProdField;
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

    public S1260InfoComProducao infoComProd
    {
        get => infoComProdField;
        set
        {
            infoComProdField = value;
            RaisePropertyChanged(nameof(infoComProd));
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

public partial class S1260InfoComProducao : ESocialBindableObject
{
    private S1260IdeEstabelecimento ideEstabelField;

    public S1260IdeEstabelecimento ideEstabel
    {
        get => ideEstabelField;
        set
        {
            ideEstabelField = value;
            RaisePropertyChanged(nameof(ideEstabel));
        }
    }
}

public partial class S1260IdeEstabelecimento : ESocialBindableObject
{
    private string nrInscEstabRuralField;
    private ObservableCollection<S1260TipoComercializacao> tpComercField = new ObservableCollection<S1260TipoComercializacao>();

    /// <summary>
    /// CAEPF (substituiu o CEI)
    /// </summary>
    /// <returns></returns>
    public string nrInscEstabRural
    {
        get => nrInscEstabRuralField;
        set
        {
            nrInscEstabRuralField = value;
            RaisePropertyChanged(nameof(nrInscEstabRural));
        }
    }

    [XmlElement("tpComerc")]
    public ObservableCollection<S1260TipoComercializacao> tpComerc
    {
        get => tpComercField;
        set
        {
            tpComercField = value;
            RaisePropertyChanged(nameof(tpComerc));
        }
    }
}

public partial class S1260TipoComercializacao : ESocialBindableObject
{
    private IndicadorComercializacaoS1260 indComercField = IndicadorComercializacaoS1260.Vendas_a_PJ;
    private decimal vrTotComField;
    private ObservableCollection<S1260TpComercIdeAdquirente> ideAdquirField = [];
    private ObservableCollection<S1260TipoComercializacaoInfoProcJudicial> infoProcJudField = [];

    public IndicadorComercializacaoS1260 indComerc
    {
        get => indComercField;
        set
        {
            indComercField = value;
            RaisePropertyChanged(nameof(indComerc));
        }
    }

    public decimal vrTotCom
    {
        get => vrTotComField;
        set
        {
            vrTotComField = value;
            RaisePropertyChanged(nameof(vrTotCom));
        }
    }

    [XmlIgnore()]
    public decimal vrCPDesc => ideAdquirField.Sum(f => f.vrCPDesc);

    [XmlIgnore()]
    public decimal vrRatDescPR => ideAdquirField.Sum(f => f.vrRatDescPR);

    [XmlIgnore()]
    public decimal vrSenarDesc => ideAdquirField.Sum(f => f.vrSenarDesc);


    [XmlElement("ideAdquir", Order = 2)]
    public ObservableCollection<S1260TpComercIdeAdquirente> ideAdquir
    {
        get => ideAdquirField;
        set
        {
            ideAdquirField = value;
            RaisePropertyChanged(nameof(ideAdquir));
        }
    }

    [XmlElement("infoProcJud", Order = 3)]
    public ObservableCollection<S1260TipoComercializacaoInfoProcJudicial> infoProcJud
    {
        get => infoProcJudField;
        set
        {
            infoProcJudField = value;
            RaisePropertyChanged(nameof(infoProcJud));
        }
    }
}

public partial class S1260TpComercIdeAdquirente : ESocialBindableObject
{
    private PersonalidadeJuridica tpInscField = PersonalidadeJuridica.CNPJ;
    private string nrInscField;
    private decimal vrComercField;
    private ObservableCollection<S1260IdeAdquirenteNf> nfsField = new ObservableCollection<S1260IdeAdquirenteNf>();

    public PersonalidadeJuridica tpInsc
    {
        get => tpInscField;
        set
        {
            tpInscField = value;
            RaisePropertyChanged(nameof(tpInsc));
        }
    }

    public string nrInsc
    {
        get => nrInscField;
        set
        {
            nrInscField = value;
            RaisePropertyChanged(nameof(nrInsc));
        }
    }

    public decimal vrComerc
    {
        get => vrComercField;
        set
        {
            vrComercField = value;
            RaisePropertyChanged(nameof(vrComerc));
        }
    }

    [XmlIgnore()]
    public decimal vrCPDesc => nfs.Sum(f => f.vrCPDescPR);

    [XmlIgnore()]
    public decimal vrRatDescPR => nfs.Sum(f => f.vrRatDescPR);

    [XmlIgnore()]
    public decimal vrSenarDesc => nfs.Sum(f => f.vrSenarDesc);


    [XmlElement("nfs")]
    public ObservableCollection<S1260IdeAdquirenteNf> nfs
    {
        get => nfsField;
        set
        {
            nfsField = value;
            RaisePropertyChanged(nameof(nfs));
        }
    }
}

public partial class S1260IdeAdquirenteNf : ESocialBindableObject
{
    private string serieField;
    private string nrDoctoField;
    private DateTime dtEmisNFField;
    private decimal vlrBrutoField;
    private decimal vrCPDescPRField;
    private decimal vrRatDescPRField;
    private decimal vrSenarDescField;

    public string serie
    {
        get => serieField;
        set
        {
            serieField = value;
            RaisePropertyChanged(nameof(serie));
        }
    }

    public string nrDocto
    {
        get => nrDoctoField;
        set
        {
            nrDoctoField = value;
            RaisePropertyChanged(nameof(nrDocto));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime dtEmisNF
    {
        get => dtEmisNFField;
        set
        {
            dtEmisNFField = value;
            RaisePropertyChanged(nameof(dtEmisNF));
        }
    }

    public decimal vlrBruto
    {
        get => vlrBrutoField;
        set
        {
            vlrBrutoField = value;
            RaisePropertyChanged(nameof(vlrBruto));
        }
    }

    public decimal vrCPDescPR
    {
        get => vrCPDescPRField;
        set
        {
            vrCPDescPRField = value;
            RaisePropertyChanged(nameof(vrCPDescPR));
        }
    }

    public decimal vrRatDescPR
    {
        get => vrRatDescPRField;
        set
        {
            vrRatDescPRField = value;
            RaisePropertyChanged(nameof(vrRatDescPR));
        }
    }

    public decimal vrSenarDesc
    {
        get => vrSenarDescField;
        set
        {
            vrSenarDescField = value;
            RaisePropertyChanged(nameof(vrSenarDesc));
        }
    }
}

public partial class S1260TipoComercializacaoInfoProcJudicial : ESocialBindableObject
{
    private sbyte tpProcField;
    private string nrProcField;
    private string codSuspField;
    private decimal vrCPSuspField;
    private bool vrCPSuspFieldSpecified;
    private decimal vrRatSuspField;
    private bool vrRatSuspFieldSpecified;
    private decimal vrSenarSuspField;
    private bool vrSenarSuspFieldSpecified;

    public sbyte tpProc
    {
        get => tpProcField;
        set
        {
            tpProcField = value;
            RaisePropertyChanged(nameof(tpProc));
        }
    }

    public string nrProc
    {
        get => nrProcField;
        set
        {
            nrProcField = value;
            RaisePropertyChanged(nameof(nrProc));
        }
    }

    [XmlElement(DataType = "integer")]
    public string codSusp
    {
        get => codSuspField;
        set
        {
            codSuspField = value;
            RaisePropertyChanged(nameof(codSusp));
        }
    }

    public decimal vrCPSusp
    {
        get => vrCPSuspField;
        set
        {
            vrCPSuspField = value;
            RaisePropertyChanged(nameof(vrCPSusp));
        }
    }

    [XmlIgnore()]
    public bool vrCPSuspSpecified
    {
        get => vrCPSuspFieldSpecified;
        set
        {
            vrCPSuspFieldSpecified = value;
            RaisePropertyChanged(nameof(vrCPSuspSpecified));
        }
    }

    public decimal vrRatSusp
    {
        get => vrRatSuspField;
        set
        {
            vrRatSuspField = value;
            RaisePropertyChanged(nameof(vrRatSusp));
        }
    }

    [XmlIgnore()]
    public bool vrRatSuspSpecified
    {
        get => vrRatSuspFieldSpecified;
        set
        {
            vrRatSuspFieldSpecified = value;
            RaisePropertyChanged(nameof(vrRatSuspSpecified));
        }
    }

    public decimal vrSenarSusp
    {
        get => vrSenarSuspField;
        set
        {
            vrSenarSuspField = value;
            RaisePropertyChanged(nameof(vrSenarSusp));
        }
    }

    [XmlIgnore()]
    public bool vrSenarSuspSpecified
    {
        get => vrSenarSuspFieldSpecified;
        set
        {
            vrSenarSuspFieldSpecified = value;
            RaisePropertyChanged(nameof(vrSenarSuspSpecified));
        }
    }
}