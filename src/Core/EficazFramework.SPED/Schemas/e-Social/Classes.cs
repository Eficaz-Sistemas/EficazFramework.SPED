using System.Collections.ObjectModel;

namespace EficazFramework.SPED.Schemas.eSocial;

[Serializable()]
[XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtTabLotacao/v02_05_00")]
[XmlRoot("eSocial", Namespace = "http://www.esocial.gov.br/schema/evt/evtTabLotacao/v02_05_00", IsNullable = false)]
public partial class S1020 : IeSocialEvt, INotifyPropertyChanged
{
    private eSocialEvtTabLotacao evtTabLotacaoField;
    private SignatureType signatureField;

    public eSocialEvtTabLotacao evtTabLotacao
    {
        get => evtTabLotacaoField;
        set
        {
            evtTabLotacaoField = value;
            RaisePropertyChanged(nameof(evtTabLotacao));
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

    public event PropertyChangedEventHandler PropertyChanged;

    public override void GeraEventoID()
    {
        evtTabLotacaoField.Id = string.Format("ID{0}{1}{2}", (int)(evtTabLotacaoField?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtTabLotacaoField?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000", eSocialTimeStampUtils.GetTimeStampIDForEvent());
    }

    protected void RaisePropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public override XmlSerializer DefineSerializer()
    {
        return new XmlSerializer(typeof(S1020));
    }

    public override object GetEventoID()
    {
        return evtTabLotacaoField.Id;
    }

    public override string ContribuinteCNPJ()
    {
        return evtTabLotacaoField.ideEmpregador.nrInsc;
    }
}

public partial class eSocialEvtTabLotacao : ESocialBindableObject
{
    private IdentificacaoCadastro ideEventoField;
    private Empregador ideEmpregadorField;
    private eSocialEvtTabLotacaoInfoLotacao infoLotacaoField;
    private string idField;

    public IdentificacaoCadastro ideEvento
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

    public eSocialEvtTabLotacaoInfoLotacao infoLotacao
    {
        get => infoLotacaoField;
        set
        {
            infoLotacaoField = value;
            RaisePropertyChanged(nameof(infoLotacao));
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

public partial class eSocialEvtTabLotacaoInfoLotacao : ESocialBindableObject
{
    private object itemField;

    [XmlElement("alteracao", typeof(S1020_Alteracao))]
    [XmlElement("exclusao", typeof(S1020_Exclusao))]
    [XmlElement("inclusao", typeof(S1020_Inclusao))]
    public object Item
    {
        get => itemField;
        set
        {
            itemField = value;
            RaisePropertyChanged(nameof(Item));
        }
    }
}

public partial class TIdeLotacao : ESocialBindableObject
{
    private string codLotacaoField;
    private string iniValidField;
    private string fimValidField;

    public string codLotacao
    {
        get => codLotacaoField;
        set
        {
            codLotacaoField = value;
            RaisePropertyChanged(nameof(codLotacao));
        }
    }

    public string iniValid
    {
        get => iniValidField;
        set
        {
            iniValidField = value;
            RaisePropertyChanged(nameof(iniValid));
        }
    }

    public string fimValid
    {
        get => fimValidField;
        set
        {
            fimValidField = value;
            RaisePropertyChanged(nameof(fimValid));
        }
    }
}

public partial class TDadosLotacao : ESocialBindableObject
{
    private string tpLotacaoField;
    private PersonalidadeJuridica tpInscField = PersonalidadeJuridica.CNPJ;
    private bool tpInscFieldSpecified;
    private string nrInscField;
    private TDadosLotacaoFpasLotacao fpasLotacaoField;
    private TDadosLotacaoInfoEmprParcial infoEmprParcialField;

    public string tpLotacao
    {
        get => tpLotacaoField;
        set
        {
            tpLotacaoField = value;
            RaisePropertyChanged(nameof(tpLotacao));
        }
    }

    public PersonalidadeJuridica tpInsc
    {
        get => tpInscField;
        set
        {
            tpInscField = value;
            RaisePropertyChanged(nameof(tpInsc));
        }
    }

    [XmlIgnore()]
    public bool tpInscSpecified
    {
        get => tpInscFieldSpecified;
        set
        {
            tpInscFieldSpecified = value;
            RaisePropertyChanged(nameof(tpInscSpecified));
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

    public TDadosLotacaoFpasLotacao fpasLotacao
    {
        get => fpasLotacaoField;
        set
        {
            fpasLotacaoField = value;
            RaisePropertyChanged(nameof(fpasLotacao));
        }
    }

    public TDadosLotacaoInfoEmprParcial infoEmprParcial
    {
        get => infoEmprParcialField;
        set
        {
            infoEmprParcialField = value;
            RaisePropertyChanged(nameof(infoEmprParcial));
        }
    }
}

public partial class TDadosLotacaoFpasLotacao : ESocialBindableObject
{
    private string fpasField;
    private string codTercsField;
    private string codTercsSuspField;
    private TDadosLotacaoFpasLotacaoProcJudTerceiro[] infoProcJudTerceirosField;

    [XmlElement(DataType = "integer")]
    public string fpas
    {
        get => fpasField;
        set
        {
            fpasField = value;
            RaisePropertyChanged(nameof(fpas));
        }
    }

    public string codTercs
    {
        get => codTercsField;
        set
        {
            codTercsField = value;
            RaisePropertyChanged(nameof(codTercs));
        }
    }

    public string codTercsSusp
    {
        get => codTercsSuspField;
        set
        {
            codTercsSuspField = value;
            RaisePropertyChanged(nameof(codTercsSusp));
        }
    }

    [XmlArrayItem("procJudTerceiro", IsNullable = false)]
    public TDadosLotacaoFpasLotacaoProcJudTerceiro[] infoProcJudTerceiros
    {
        get => infoProcJudTerceirosField;
        set
        {
            infoProcJudTerceirosField = value;
            RaisePropertyChanged(nameof(infoProcJudTerceiros));
        }
    }
}

public partial class TDadosLotacaoFpasLotacaoProcJudTerceiro : ESocialBindableObject
{
    private string codTercField;
    private string nrProcJudField;
    private string codSuspField;

    public string codTerc
    {
        get => codTercField;
        set
        {
            codTercField = value;
            RaisePropertyChanged(nameof(codTerc));
        }
    }

    public string nrProcJud
    {
        get => nrProcJudField;
        set
        {
            nrProcJudField = value;
            RaisePropertyChanged(nameof(nrProcJud));
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
}

public partial class TDadosLotacaoInfoEmprParcial : ESocialBindableObject
{
    private PersonalidadeJuridica tpInscContratField = PersonalidadeJuridica.CNPJ;
    private string nrInscContratField;
    private PersonalidadeJuridica tpInscPropField = PersonalidadeJuridica.CNPJ;
    private string nrInscPropField;

    public PersonalidadeJuridica tpInscContrat
    {
        get => tpInscContratField;
        set
        {
            tpInscContratField = value;
            RaisePropertyChanged(nameof(tpInscContrat));
        }
    }

    public string nrInscContrat
    {
        get => nrInscContratField;
        set
        {
            nrInscContratField = value;
            RaisePropertyChanged(nameof(nrInscContrat));
        }
    }

    public PersonalidadeJuridica tpInscProp
    {
        get => tpInscPropField;
        set
        {
            tpInscPropField = value;
            RaisePropertyChanged(nameof(tpInscProp));
        }
    }

    public string nrInscProp
    {
        get => nrInscPropField;
        set
        {
            nrInscPropField = value;
            RaisePropertyChanged(nameof(nrInscProp));
        }
    }
}

public partial class S1020_Exclusao : ESocialBindableObject
{
    private TIdeLotacao ideLotacaoField;

    public TIdeLotacao ideLotacao
    {
        get => ideLotacaoField;
        set
        {
            ideLotacaoField = value;
            RaisePropertyChanged(nameof(ideLotacao));
        }
    }
}

public partial class S1020_Inclusao : ESocialBindableObject
{
    private TIdeLotacao ideLotacaoField;
    private TDadosLotacao dadosLotacaoField;

    public TIdeLotacao ideLotacao
    {
        get => ideLotacaoField;
        set
        {
            ideLotacaoField = value;
            RaisePropertyChanged(nameof(ideLotacao));
        }
    }

    public TDadosLotacao dadosLotacao
    {
        get => dadosLotacaoField;
        set
        {
            dadosLotacaoField = value;
            RaisePropertyChanged(nameof(dadosLotacao));
        }
    }
}

public partial class S1020_Alteracao : ESocialBindableObject
{
    private TIdeLotacao ideLotacaoField;
    private TDadosLotacao dadosLotacaoField;
    private IdePeriodo novaValidadeField;

    public TIdeLotacao ideLotacao
    {
        get => ideLotacaoField;
        set
        {
            ideLotacaoField = value;
            RaisePropertyChanged(nameof(ideLotacao));
        }
    }

    public TDadosLotacao dadosLotacao
    {
        get => dadosLotacaoField;
        set
        {
            dadosLotacaoField = value;
            RaisePropertyChanged(nameof(dadosLotacao));
        }
    }

    public IdePeriodo novaValidade
    {
        get => novaValidadeField;
        set
        {
            novaValidadeField = value;
            RaisePropertyChanged(nameof(novaValidade));
        }
    }
}


[Serializable()]
[XmlType(AnonymousType = true)]
[XmlRoot("eSocial", Namespace = "http://www.esocial.gov.br/schema/evt/evtComProd/v02_05_00", IsNullable = false)]
public partial class S1260 : IeSocialEvt, INotifyPropertyChanged
{
    private eSocialEvtComProd evtComProdField;
    private SignatureType signatureField;

    [XmlElement(Order = 0)]
    public eSocialEvtComProd evtComProd
    {
        get => evtComProdField;
        set
        {
            evtComProdField = value;
            RaisePropertyChanged(nameof(evtComProd));
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

    public override XmlSerializer DefineSerializer()
    {
        return new XmlSerializer(typeof(S1260));
    }

    public override void GeraEventoID()
    {
        evtComProdField.Id = string.Format("ID{0}{1}{2}", (int)(evtComProdField?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtComProdField?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000", eSocialTimeStampUtils.GetTimeStampIDForEvent());
    }

    public override object GetEventoID()
    {
        return evtComProdField.Id;
    }

    public override string ContribuinteCNPJ()
    {
        return evtComProdField.ideEmpregador.nrInsc;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

public partial class eSocialEvtComProd : ESocialBindableObject
{
    private IdeEventoPeriodico ideEventoField;
    private Empregador ideEmpregadorField;
    private eSocialEvtComProdInfoComProd infoComProdField;
    private string idField;

    [XmlElement(Order = 0)]
    public IdeEventoPeriodico ideEvento
    {
        get => ideEventoField;
        set
        {
            ideEventoField = value;
            RaisePropertyChanged(nameof(ideEvento));
        }
    }

    [XmlElement(Order = 1)]
    public Empregador ideEmpregador
    {
        get => ideEmpregadorField;
        set
        {
            ideEmpregadorField = value;
            RaisePropertyChanged(nameof(ideEmpregador));
        }
    }

    [XmlElement(Order = 2)]
    public eSocialEvtComProdInfoComProd infoComProd
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

public partial class eSocialEvtComProdInfoComProd : ESocialBindableObject
{
    private eSocialEvtComProdInfoComProdIdeEstabel ideEstabelField;

    [XmlElement(Order = 0)]
    public eSocialEvtComProdInfoComProdIdeEstabel ideEstabel
    {
        get => ideEstabelField;
        set
        {
            ideEstabelField = value;
            RaisePropertyChanged(nameof(ideEstabel));
        }
    }
}

public partial class eSocialEvtComProdInfoComProdIdeEstabel : ESocialBindableObject
{
    private string nrInscEstabRuralField;
    private ObservableCollection<eSocialEvtComProdInfoComProdIdeEstabelTpComerc> tpComercField = new ObservableCollection<eSocialEvtComProdInfoComProdIdeEstabelTpComerc>();

    /// <summary>
    /// CAEPF (substituiu o CEI)
    /// </summary>
    /// <returns></returns>
    [XmlElement(Order = 0)]
    public string nrInscEstabRural
    {
        get => nrInscEstabRuralField;
        set
        {
            nrInscEstabRuralField = value;
            RaisePropertyChanged(nameof(nrInscEstabRural));
        }
    }

    [XmlElement("tpComerc", Order = 1)]
    public ObservableCollection<eSocialEvtComProdInfoComProdIdeEstabelTpComerc> tpComerc
    {
        get => tpComercField;
        set
        {
            tpComercField = value;
            RaisePropertyChanged(nameof(tpComerc));
        }
    }
}

public partial class eSocialEvtComProdInfoComProdIdeEstabelTpComerc : ESocialBindableObject
{
    private IndicadorComercializacaoS1260 indComercField = IndicadorComercializacaoS1260.Vendas_a_PJ;
    private decimal vrTotComField;
    private ObservableCollection<eSocialEvtComProdInfoComProdIdeEstabelTpComercIdeAdquir> ideAdquirField = new ObservableCollection<eSocialEvtComProdInfoComProdIdeEstabelTpComercIdeAdquir>();
    private eSocialEvtComProdInfoComProdIdeEstabelTpComercInfoProcJud[] infoProcJudField;

    [XmlElement(Order = 0)]
    public IndicadorComercializacaoS1260 indComerc
    {
        get => indComercField;
        set
        {
            indComercField = value;
            RaisePropertyChanged(nameof(indComerc));
        }
    }

    [XmlElement(Order = 1)]
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
    public decimal vrCPDesc
    {
        get
        {
            return ideAdquirField.Sum(f => f.vrCPDesc);
        }
    }

    [XmlIgnore()]
    public decimal vrRatDescPR
    {
        get
        {
            return ideAdquirField.Sum(f => f.vrRatDescPR);
        }
    }

    [XmlIgnore()]
    public decimal vrSenarDesc
    {
        get
        {
            return ideAdquirField.Sum(f => f.vrSenarDesc);
        }
    }


    [XmlElement("ideAdquir", Order = 2)]
    public ObservableCollection<eSocialEvtComProdInfoComProdIdeEstabelTpComercIdeAdquir> ideAdquir
    {
        get => ideAdquirField;
        set
        {
            ideAdquirField = value;
            RaisePropertyChanged(nameof(ideAdquir));
        }
    }

    [XmlElement("infoProcJud", Order = 3)]
    public eSocialEvtComProdInfoComProdIdeEstabelTpComercInfoProcJud[] infoProcJud
    {
        get => infoProcJudField;
        set
        {
            infoProcJudField = value;
            RaisePropertyChanged(nameof(infoProcJud));
        }
    }
}

public partial class eSocialEvtComProdInfoComProdIdeEstabelTpComercIdeAdquir : ESocialBindableObject
{
    private PersonalidadeJuridica tpInscField = PersonalidadeJuridica.CNPJ;
    private string nrInscField;
    private decimal vrComercField;
    private ObservableCollection<eSocialEvtComProdInfoComProdIdeEstabelTpComercIdeAdquirNfs> nfsField = new ObservableCollection<eSocialEvtComProdInfoComProdIdeEstabelTpComercIdeAdquirNfs>();

    [XmlElement(Order = 0)]
    public PersonalidadeJuridica tpInsc
    {
        get => tpInscField;
        set
        {
            tpInscField = value;
            RaisePropertyChanged(nameof(tpInsc));
        }
    }

    [XmlElement(Order = 1)]
    public string nrInsc
    {
        get => nrInscField;
        set
        {
            nrInscField = value;
            RaisePropertyChanged(nameof(nrInsc));
        }
    }

    [XmlElement(Order = 2)]
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
    public decimal vrCPDesc
    {
        get
        {
            return nfs.Sum(f => f.vrCPDescPR);
        }
    }

    [XmlIgnore()]
    public decimal vrRatDescPR
    {
        get
        {
            return nfs.Sum(f => f.vrRatDescPR);
        }
    }

    [XmlIgnore()]
    public decimal vrSenarDesc
    {
        get
        {
            return nfs.Sum(f => f.vrSenarDesc);
        }
    }


    [XmlElement("nfs", Order = 3)]
    public ObservableCollection<eSocialEvtComProdInfoComProdIdeEstabelTpComercIdeAdquirNfs> nfs
    {
        get => nfsField;
        set
        {
            nfsField = value;
            RaisePropertyChanged(nameof(nfs));
        }
    }
}

public partial class eSocialEvtComProdInfoComProdIdeEstabelTpComercIdeAdquirNfs : ESocialBindableObject
{
    private string serieField;
    private string nrDoctoField;
    private DateTime dtEmisNFField;
    private decimal vlrBrutoField;
    private decimal vrCPDescPRField;
    private decimal vrRatDescPRField;
    private decimal vrSenarDescField;

    [XmlElement(Order = 0)]
    public string serie
    {
        get => serieField;
        set
        {
            serieField = value;
            RaisePropertyChanged(nameof(serie));
        }
    }

    [XmlElement(Order = 1)]
    public string nrDocto
    {
        get => nrDoctoField;
        set
        {
            nrDoctoField = value;
            RaisePropertyChanged(nameof(nrDocto));
        }
    }

    [XmlElement(DataType = "date", Order = 2)]
    public DateTime dtEmisNF
    {
        get => dtEmisNFField;
        set
        {
            dtEmisNFField = value;
            RaisePropertyChanged(nameof(dtEmisNF));
        }
    }

    [XmlElement(Order = 3)]
    public decimal vlrBruto
    {
        get => vlrBrutoField;
        set
        {
            vlrBrutoField = value;
            RaisePropertyChanged(nameof(vlrBruto));
        }
    }

    [XmlElement(Order = 4)]
    public decimal vrCPDescPR
    {
        get => vrCPDescPRField;
        set
        {
            vrCPDescPRField = value;
            RaisePropertyChanged(nameof(vrCPDescPR));
        }
    }

    [XmlElement(Order = 5)]
    public decimal vrRatDescPR
    {
        get => vrRatDescPRField;
        set
        {
            vrRatDescPRField = value;
            RaisePropertyChanged(nameof(vrRatDescPR));
        }
    }

    [XmlElement(Order = 6)]
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

public partial class eSocialEvtComProdInfoComProdIdeEstabelTpComercInfoProcJud : ESocialBindableObject
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

    [XmlElement(Order = 0)]
    public sbyte tpProc
    {
        get => tpProcField;
        set
        {
            tpProcField = value;
            RaisePropertyChanged(nameof(tpProc));
        }
    }

    [XmlElement(Order = 1)]
    public string nrProc
    {
        get => nrProcField;
        set
        {
            nrProcField = value;
            RaisePropertyChanged(nameof(nrProc));
        }
    }

    [XmlElement(DataType = "integer", Order = 2)]
    public string codSusp
    {
        get => codSuspField;
        set
        {
            codSuspField = value;
            RaisePropertyChanged(nameof(codSusp));
        }
    }

    [XmlElement(Order = 3)]
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

    [XmlElement(Order = 4)]
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

    [XmlElement(Order = 5)]
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

[Serializable()]
[XmlType(AnonymousType = true)]
[XmlRoot("eSocial", Namespace = "http://www.esocial.gov.br/schema/evt/evtReabreEvPer/v02_05_00", IsNullable = false)]
public partial class S1298 : IeSocialEvt
{
    private eSocialEvtReabreEvPer evtReabreEvPerField;
    private SignatureType signatureField;

    [XmlElement(Order = 0)]
    public eSocialEvtReabreEvPer evtReabreEvPer
    {
        get => evtReabreEvPerField;
        set
        {
            evtReabreEvPerField = value;
            RaisePropertyChanged(nameof(evtReabreEvPer));
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

    public override XmlSerializer DefineSerializer()
    {
        return new XmlSerializer(typeof(S1298));
    }

    public override void GeraEventoID()
    {
        evtReabreEvPerField.Id = string.Format("ID{0}{1}{2}", (int)(evtReabreEvPerField?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtReabreEvPerField?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000", eSocialTimeStampUtils.GetTimeStampIDForEvent());
    }

    public override object GetEventoID()
    {
        return evtReabreEvPerField.Id;
    }

    public override string ContribuinteCNPJ()
    {
        return evtReabreEvPerField.ideEmpregador.nrInsc;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

public partial class eSocialEvtReabreEvPer : ESocialBindableObject
{
    private eSocialEvtReabreEvPerIdeEvento ideEventoField;
    private Empregador ideEmpregadorField;
    private string idField;

    [XmlElement(Order = 0)]
    public eSocialEvtReabreEvPerIdeEvento ideEvento
    {
        get => ideEventoField;
        set
        {
            ideEventoField = value;
            RaisePropertyChanged(nameof(ideEvento));
        }
    }

    [XmlElement(Order = 1)]
    public Empregador ideEmpregador
    {
        get => ideEmpregadorField;
        set
        {
            ideEmpregadorField = value;
            RaisePropertyChanged(nameof(ideEmpregador));
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

public partial class eSocialEvtReabreEvPerIdeEvento : ESocialBindableObject
{
    private IndicadorApuracao indApuracaoField = IndicadorApuracao.Mensal;
    private string perApurField;
    private Ambiente tpAmbField = Ambiente.Producao;
    private EmissorEvento procEmiField = EmissorEvento.AppEmpregador;
    private string verProcField;

    [XmlElement(Order = 0)]
    public IndicadorApuracao indApuracao
    {
        get => indApuracaoField;
        set
        {
            indApuracaoField = value;
            RaisePropertyChanged(nameof(indApuracao));
        }
    }

    [XmlElement(Order = 1)]
    public string perApur
    {
        get => perApurField;
        set
        {
            perApurField = value;
            RaisePropertyChanged(nameof(perApur));
        }
    }

    [XmlElement(Order = 2)]
    public Ambiente tpAmb
    {
        get => tpAmbField;
        set
        {
            tpAmbField = value;
            RaisePropertyChanged(nameof(tpAmb));
        }
    }

    [XmlElement(Order = 3)]
    public EmissorEvento procEmi
    {
        get => procEmiField;
        set
        {
            procEmiField = value;
            RaisePropertyChanged(nameof(procEmi));
        }
    }

    [XmlElement(Order = 4)]
    public string verProc
    {
        get => verProcField;
        set
        {
            verProcField = value;
            RaisePropertyChanged(nameof(verProc));
        }
    }
}

[Serializable()]
[XmlType(AnonymousType = true)]
[XmlRoot("eSocial", Namespace = "http://www.esocial.gov.br/schema/evt/evtFechaEvPer/v02_05_00", IsNullable = false)]
public partial class S1299 : IeSocialEvt
{
    private eSocialEvtFechaEvPer evtFechaEvPerField;
    private SignatureType signatureField;

    [XmlElement(Order = 0)]
    public eSocialEvtFechaEvPer evtFechaEvPer
    {
        get => evtFechaEvPerField;
        set
        {
            evtFechaEvPerField = value;
            RaisePropertyChanged(nameof(evtFechaEvPer));
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

    public override XmlSerializer DefineSerializer()
    {
        return new XmlSerializer(typeof(S1299));
    }

    public override void GeraEventoID()
    {
        evtFechaEvPerField.Id = string.Format("ID{0}{1}{2}", (int)(evtFechaEvPerField?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtFechaEvPerField?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000", eSocialTimeStampUtils.GetTimeStampIDForEvent());
    }

    public override object GetEventoID()
    {
        return evtFechaEvPerField.Id;
    }

    public override string ContribuinteCNPJ()
    {
        return evtFechaEvPerField.ideEmpregador.nrInsc;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}

public partial class eSocialEvtFechaEvPer : ESocialBindableObject
{
    private eSocialEvtFechaEvPerIdeEvento ideEventoField;
    private Empregador ideEmpregadorField;
    private eSocialEvtFechaEvPerIdeRespInf ideRespInfField;
    private eSocialEvtFechaEvPerInfoFech infoFechField;
    private string idField;

    [XmlElement(Order = 0)]
    public eSocialEvtFechaEvPerIdeEvento ideEvento
    {
        get => ideEventoField;
        set
        {
            ideEventoField = value;
            RaisePropertyChanged(nameof(ideEvento));
        }
    }

    [XmlElement(Order = 1)]
    public Empregador ideEmpregador
    {
        get => ideEmpregadorField;
        set
        {
            ideEmpregadorField = value;
            RaisePropertyChanged(nameof(ideEmpregador));
        }
    }

    [XmlElement(Order = 2)]
    public eSocialEvtFechaEvPerIdeRespInf ideRespInf
    {
        get => ideRespInfField;
        set
        {
            ideRespInfField = value;
            RaisePropertyChanged(nameof(ideRespInf));
        }
    }

    [XmlElement(Order = 3)]
    public eSocialEvtFechaEvPerInfoFech infoFech
    {
        get => infoFechField;
        set
        {
            infoFechField = value;
            RaisePropertyChanged(nameof(infoFech));
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

public partial class eSocialEvtFechaEvPerIdeEvento : ESocialBindableObject
{
    private IndicadorApuracao indApuracaoField = IndicadorApuracao.Mensal;
    private string perApurField;
    private Ambiente tpAmbField = Ambiente.Producao;
    private EmissorEvento procEmiField = EmissorEvento.AppEmpregador;
    private string verProcField;

    [XmlElement(Order = 0)]
    public IndicadorApuracao indApuracao
    {
        get => indApuracaoField;
        set
        {
            indApuracaoField = value;
            RaisePropertyChanged(nameof(indApuracao));
        }
    }

    [XmlElement(Order = 1)]
    public string perApur
    {
        get => perApurField;
        set
        {
            perApurField = value;
            RaisePropertyChanged(nameof(perApur));
        }
    }

    [XmlElement(Order = 2)]
    public Ambiente tpAmb
    {
        get => tpAmbField;
        set
        {
            tpAmbField = value;
            RaisePropertyChanged(nameof(tpAmb));
        }
    }

    [XmlElement(Order = 3)]
    public EmissorEvento procEmi
    {
        get => procEmiField;
        set
        {
            procEmiField = value;
            RaisePropertyChanged(nameof(procEmi));
        }
    }

    [XmlElement(Order = 4)]
    public string verProc
    {
        get => verProcField;
        set
        {
            verProcField = value;
            RaisePropertyChanged(nameof(verProc));
        }
    }
}

public partial class eSocialEvtFechaEvPerIdeRespInf : ESocialBindableObject
{
    private string nmRespField;
    private string cpfRespField;
    private string telefoneField;
    private string emailField;

    [XmlElement(Order = 0)]
    public string nmResp
    {
        get => nmRespField;
        set
        {
            nmRespField = value;
            RaisePropertyChanged(nameof(nmResp));
        }
    }

    [XmlElement(Order = 1)]
    public string cpfResp
    {
        get => cpfRespField;
        set
        {
            cpfRespField = value;
            RaisePropertyChanged(nameof(cpfResp));
        }
    }

    [XmlElement(Order = 2)]
    public string telefone
    {
        get => telefoneField;
        set
        {
            telefoneField = value;
            RaisePropertyChanged(nameof(telefone));
        }
    }

    [XmlElement(Order = 3)]
    public string email
    {
        get => emailField;
        set
        {
            emailField = value;
            RaisePropertyChanged(nameof(email));
        }
    }
}

public partial class eSocialEvtFechaEvPerInfoFech : ESocialBindableObject
{
    private SimNaoString evtRemunField = SimNaoString.Nao;
    private SimNaoString evtPgtosField = SimNaoString.Nao;
    private SimNaoString evtAqProdField = SimNaoString.Nao;
    private SimNaoString evtComProdField = SimNaoString.Nao;
    private SimNaoString evtContratAvNPField = SimNaoString.Nao;
    private SimNaoString evtInfoComplPerField = SimNaoString.Nao;
    private string compSemMovtoField;

    [XmlElement(Order = 0)]
    public SimNaoString evtRemun
    {
        get => evtRemunField;
        set
        {
            evtRemunField = value;
            RaisePropertyChanged(nameof(evtRemun));
        }
    }

    [XmlElement(Order = 1)]
    public SimNaoString evtPgtos
    {
        get => evtPgtosField;
        set
        {
            evtPgtosField = value;
            RaisePropertyChanged(nameof(evtPgtos));
        }
    }

    [XmlElement(Order = 2)]
    public SimNaoString evtAqProd
    {
        get => evtAqProdField;
        set
        {
            evtAqProdField = value;
            RaisePropertyChanged(nameof(evtAqProd));
        }
    }

    [XmlElement(Order = 3)]
    public SimNaoString evtComProd
    {
        get => evtComProdField;
        set
        {
            evtComProdField = value;
            RaisePropertyChanged(nameof(evtComProd));
        }
    }

    [XmlElement(Order = 4)]
    public SimNaoString evtContratAvNP
    {
        get => evtContratAvNPField;
        set
        {
            evtContratAvNPField = value;
            RaisePropertyChanged(nameof(evtContratAvNP));
        }
    }

    [XmlElement(Order = 5)]
    public SimNaoString evtInfoComplPer
    {
        get => evtInfoComplPerField;
        set
        {
            evtInfoComplPerField = value;
            RaisePropertyChanged(nameof(evtInfoComplPer));
        }
    }

    [XmlElement(Order = 6)]
    public string compSemMovto
    {
        get => compSemMovtoField;
        set
        {
            compSemMovtoField = value;
            RaisePropertyChanged(nameof(compSemMovto));
        }
    }
}

[Serializable()]
[XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
[XmlRoot(Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00", IsNullable = false)]
public partial class S2200 : IeSocialEvt
{
    private eSocialEvtAdmissao evtAdmissaoField;
    private SignatureType signatureField;

    public eSocialEvtAdmissao evtAdmissao
    {
        get => evtAdmissaoField;
        set
        {
            evtAdmissaoField = value;
            RaisePropertyChanged(nameof(evtAdmissao));
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

    public override XmlSerializer DefineSerializer()
    {
        return new XmlSerializer(typeof(S2200));
    }

    public override void GeraEventoID()
    {
        evtAdmissaoField.Id = string.Format("ID{0}{1}{2}", (int)(evtAdmissaoField?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtAdmissaoField?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000", eSocialTimeStampUtils.GetTimeStampIDForEvent());
    }

    public override object GetEventoID()
    {
        return evtAdmissaoField.Id;
    }

    public override string ContribuinteCNPJ()
    {
        return evtAdmissaoField.ideEmpregador.nrInsc;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

public partial class eSocialEvtAdmissao : ESocialBindableObject
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

public partial class eSocialEvtAdmissaoTrabalhador : ESocialBindableObject
{
    private string cpfTrabField;
    private string nisTrabField;
    private string nmTrabField;
    private string sexoField;
    private RacaCor racaCorField = RacaCor.NaoInformado;
    private EstadoCivil estCivField = EstadoCivil.Solteiro;
    private bool estCivFieldSpecified;
    private GrauInstrucao grauInstrField = GrauInstrucao.Analfabeto;
    private SimNaoString indPriEmprField = SimNaoString.Nao;
    private string nmSocField;
    private eSocialEvtAdmissaoTrabalhadorNascimento nascimentoField;
    private eSocialEvtAdmissaoTrabalhadorDocumentos documentosField;
    private eSocialEvtAdmissaoTrabalhadorEndereco enderecoField;
    private TTrabEstrang trabEstrangeiroField;
    private eSocialEvtAdmissaoTrabalhadorInfoDeficiencia infoDeficienciaField;
    private List<TDependente> dependenteField = new List<TDependente>();
    private eSocialEvtAdmissaoTrabalhadorAposentadoria aposentadoriaField;
    private TContato contatoField;

    public string cpfTrab
    {
        get => cpfTrabField;
        set
        {
            cpfTrabField = value;
            RaisePropertyChanged(nameof(cpfTrab));
        }
    }

    public string nisTrab
    {
        get => nisTrabField;
        set
        {
            nisTrabField = value;
            RaisePropertyChanged(nameof(nisTrab));
        }
    }

    public string nmTrab
    {
        get => nmTrabField;
        set
        {
            nmTrabField = value;
            RaisePropertyChanged(nameof(nmTrab));
        }
    }

    public string sexo
    {
        get => sexoField;
        set
        {
            sexoField = value;
            RaisePropertyChanged(nameof(sexo));
        }
    }

    public RacaCor racaCor
    {
        get => racaCorField;
        set
        {
            racaCorField = value;
            RaisePropertyChanged(nameof(racaCor));
        }
    }

    public EstadoCivil estCiv
    {
        get => estCivField;
        set
        {
            estCivField = value;
            RaisePropertyChanged(nameof(estCiv));
        }
    }

    [XmlIgnore()]
    public bool estCivSpecified
    {
        get => estCivFieldSpecified;
        set
        {
            estCivFieldSpecified = value;
            RaisePropertyChanged(nameof(estCivSpecified));
        }
    }

    public GrauInstrucao grauInstr
    {
        get => grauInstrField;
        set
        {
            grauInstrField = value;
            RaisePropertyChanged(nameof(grauInstr));
        }
    }

    public SimNaoString indPriEmpr
    {
        get => indPriEmprField;
        set
        {
            indPriEmprField = value;
            RaisePropertyChanged(nameof(indPriEmpr));
        }
    }

    public string nmSoc
    {
        get => nmSocField;
        set
        {
            nmSocField = value;
            RaisePropertyChanged(nameof(nmSoc));
        }
    }

    public eSocialEvtAdmissaoTrabalhadorNascimento nascimento
    {
        get => nascimentoField;
        set
        {
            nascimentoField = value;
            RaisePropertyChanged(nameof(nascimento));
        }
    }

    public eSocialEvtAdmissaoTrabalhadorDocumentos documentos
    {
        get => documentosField;
        set
        {
            documentosField = value;
            RaisePropertyChanged(nameof(documentos));
        }
    }

    public eSocialEvtAdmissaoTrabalhadorEndereco endereco
    {
        get => enderecoField;
        set
        {
            enderecoField = value;
            RaisePropertyChanged(nameof(endereco));
        }
    }

    public TTrabEstrang trabEstrangeiro
    {
        get => trabEstrangeiroField;
        set
        {
            trabEstrangeiroField = value;
            RaisePropertyChanged(nameof(trabEstrangeiro));
        }
    }

    public eSocialEvtAdmissaoTrabalhadorInfoDeficiencia infoDeficiencia
    {
        get => infoDeficienciaField;
        set
        {
            infoDeficienciaField = value;
            RaisePropertyChanged(nameof(infoDeficiencia));
        }
    }

    [XmlElement("dependente")]
    public List<TDependente> dependente
    {
        get => dependenteField;
        set
        {
            dependenteField = value;
            RaisePropertyChanged(nameof(dependente));
        }
    }

    public eSocialEvtAdmissaoTrabalhadorAposentadoria aposentadoria
    {
        get => aposentadoriaField;
        set
        {
            aposentadoriaField = value;
            RaisePropertyChanged(nameof(aposentadoria));
        }
    }

    public TContato contato
    {
        get => contatoField;
        set
        {
            contatoField = value;
            RaisePropertyChanged(nameof(contato));
        }
    }
}

public partial class eSocialEvtAdmissaoTrabalhadorNascimento : ESocialBindableObject
{
    private DateTime dtNasctoField;
    private string codMunicField;
    private UFCadastro ufField;
    private bool ufFieldSpecified;
    private string paisNasctoField;
    private string paisNacField;
    private string nmMaeField;
    private string nmPaiField;

    [XmlElement(DataType = "date")]
    public DateTime dtNascto
    {
        get => dtNasctoField;
        set
        {
            dtNasctoField = value;
            RaisePropertyChanged(nameof(dtNascto));
        }
    }

    [XmlElement(DataType = "integer")]
    public string codMunic
    {
        get => codMunicField;
        set
        {
            codMunicField = value;
            RaisePropertyChanged(nameof(codMunic));
        }
    }

    public UFCadastro uf
    {
        get => ufField;
        set
        {
            ufField = value;
            RaisePropertyChanged(nameof(uf));
        }
    }

    [XmlIgnore()]
    public bool ufSpecified
    {
        get => ufFieldSpecified;
        set
        {
            ufFieldSpecified = value;
            RaisePropertyChanged(nameof(ufSpecified));
        }
    }

    public string paisNascto
    {
        get => paisNasctoField;
        set
        {
            paisNasctoField = value;
            RaisePropertyChanged(nameof(paisNascto));
        }
    }

    public string paisNac
    {
        get => paisNacField;
        set
        {
            paisNacField = value;
            RaisePropertyChanged(nameof(paisNac));
        }
    }

    public string nmMae
    {
        get => nmMaeField;
        set
        {
            nmMaeField = value;
            RaisePropertyChanged(nameof(nmMae));
        }
    }

    public string nmPai
    {
        get => nmPaiField;
        set
        {
            nmPaiField = value;
            RaisePropertyChanged(nameof(nmPai));
        }
    }
}

public partial class eSocialEvtAdmissaoTrabalhadorDocumentos : ESocialBindableObject
{
    private TCtps cTPSField;
    private TRic rICField;
    private TRg rgField;
    private TRne rNEField;
    private TOc ocField;
    private TCnh cNHField;

    public TCtps CTPS
    {
        get => cTPSField;
        set
        {
            cTPSField = value;
            RaisePropertyChanged(nameof(CTPS));
        }
    }

    public TRic RIC
    {
        get => rICField;
        set
        {
            rICField = value;
            RaisePropertyChanged(nameof(RIC));
        }
    }

    public TRg RG
    {
        get => rgField;
        set
        {
            rgField = value;
            RaisePropertyChanged(nameof(RG));
        }
    }

    public TRne RNE
    {
        get => rNEField;
        set
        {
            rNEField = value;
            RaisePropertyChanged(nameof(RNE));
        }
    }

    public TOc OC
    {
        get => ocField;
        set
        {
            ocField = value;
            RaisePropertyChanged(nameof(OC));
        }
    }

    public TCnh CNH
    {
        get => cNHField;
        set
        {
            cNHField = value;
            RaisePropertyChanged(nameof(CNH));
        }
    }
}

public partial class TCtps : ESocialBindableObject
{
    private string nrCtpsField;
    private string serieCtpsField;
    private UFCadastro ufCtpsField;

    public string nrCtps
    {
        get => nrCtpsField;
        set
        {
            nrCtpsField = value;
            RaisePropertyChanged(nameof(nrCtps));
        }
    }

    public string serieCtps
    {
        get => serieCtpsField;
        set
        {
            serieCtpsField = value;
            RaisePropertyChanged(nameof(serieCtps));
        }
    }

    public UFCadastro ufCtps
    {
        get => ufCtpsField;
        set
        {
            ufCtpsField = value;
            RaisePropertyChanged(nameof(ufCtps));
        }
    }
}

public partial class TRic : ESocialBindableObject
{
    private string nrRicField;
    private string orgaoEmissorField;
    private DateTime dtExpedField;
    private bool dtExpedFieldSpecified;

    public string nrRic
    {
        get => nrRicField;
        set
        {
            nrRicField = value;
            RaisePropertyChanged(nameof(nrRic));
        }
    }

    public string orgaoEmissor
    {
        get => orgaoEmissorField;
        set
        {
            orgaoEmissorField = value;
            RaisePropertyChanged(nameof(orgaoEmissor));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime dtExped
    {
        get => dtExpedField;
        set
        {
            dtExpedField = value;
            RaisePropertyChanged(nameof(dtExped));
        }
    }

    [XmlIgnore()]
    public bool dtExpedSpecified
    {
        get => dtExpedFieldSpecified;
        set
        {
            dtExpedFieldSpecified = value;
            RaisePropertyChanged(nameof(dtExpedSpecified));
        }
    }
}

public partial class TRg : ESocialBindableObject
{
    private string nrRgField;
    private string orgaoEmissorField;
    private DateTime dtExpedField;
    private bool dtExpedFieldSpecified;

    public string nrRg
    {
        get => nrRgField;
        set
        {
            nrRgField = value;
            RaisePropertyChanged(nameof(nrRg));
        }
    }

    public string orgaoEmissor
    {
        get => orgaoEmissorField;
        set
        {
            orgaoEmissorField = value;
            RaisePropertyChanged(nameof(orgaoEmissor));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime dtExped
    {
        get => dtExpedField;
        set
        {
            dtExpedField = value;
            RaisePropertyChanged(nameof(dtExped));
        }
    }

    [XmlIgnore()]
    public bool dtExpedSpecified
    {
        get => dtExpedFieldSpecified;
        set
        {
            dtExpedFieldSpecified = value;
            RaisePropertyChanged(nameof(dtExpedSpecified));
        }
    }
}

public partial class TRne : ESocialBindableObject
{
    private string nrRneField;
    private string orgaoEmissorField;
    private DateTime dtExpedField;
    private bool dtExpedFieldSpecified;

    public string nrRne
    {
        get => nrRneField;
        set
        {
            nrRneField = value;
            RaisePropertyChanged(nameof(nrRne));
        }
    }

    public string orgaoEmissor
    {
        get => orgaoEmissorField;
        set
        {
            orgaoEmissorField = value;
            RaisePropertyChanged(nameof(orgaoEmissor));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime dtExped
    {
        get => dtExpedField;
        set
        {
            dtExpedField = value;
            RaisePropertyChanged(nameof(dtExped));
        }
    }

    [XmlIgnore()]
    public bool dtExpedSpecified
    {
        get => dtExpedFieldSpecified;
        set
        {
            dtExpedFieldSpecified = value;
            RaisePropertyChanged(nameof(dtExpedSpecified));
        }
    }
}

public partial class TOc : ESocialBindableObject
{
    private string nrOcField;
    private string orgaoEmissorField;
    private DateTime dtExpedField;
    private bool dtExpedFieldSpecified;
    private DateTime dtValidField;
    private bool dtValidFieldSpecified;

    public string nrOc
    {
        get => nrOcField;
        set
        {
            nrOcField = value;
            RaisePropertyChanged(nameof(nrOc));
        }
    }

    public string orgaoEmissor
    {
        get => orgaoEmissorField;
        set
        {
            orgaoEmissorField = value;
            RaisePropertyChanged(nameof(orgaoEmissor));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime dtExped
    {
        get => dtExpedField;
        set
        {
            dtExpedField = value;
            RaisePropertyChanged(nameof(dtExped));
        }
    }

    [XmlIgnore()]
    public bool dtExpedSpecified
    {
        get => dtExpedFieldSpecified;
        set
        {
            dtExpedFieldSpecified = value;
            RaisePropertyChanged(nameof(dtExpedSpecified));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime dtValid
    {
        get => dtValidField;
        set
        {
            dtValidField = value;
            RaisePropertyChanged(nameof(dtValid));
        }
    }

    [XmlIgnore()]
    public bool dtValidSpecified
    {
        get => dtValidFieldSpecified;
        set
        {
            dtValidFieldSpecified = value;
            RaisePropertyChanged(nameof(dtValidSpecified));
        }
    }
}

public partial class TCnh : ESocialBindableObject
{
    private string nrRegCnhField;
    private DateTime dtExpedField;
    private bool dtExpedFieldSpecified;
    private UFCadastro ufCnhField;
    private DateTime dtValidField;
    private DateTime dtPriHabField;
    private bool dtPriHabFieldSpecified;
    private string categoriaCnhField;

    public string nrRegCnh
    {
        get => nrRegCnhField;
        set
        {
            nrRegCnhField = value;
            RaisePropertyChanged(nameof(nrRegCnh));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime dtExped
    {
        get => dtExpedField;
        set
        {
            dtExpedField = value;
            RaisePropertyChanged(nameof(dtExped));
        }
    }

    [XmlIgnore()]
    public bool dtExpedSpecified
    {
        get => dtExpedFieldSpecified;
        set
        {
            dtExpedFieldSpecified = value;
            RaisePropertyChanged(nameof(dtExpedSpecified));
        }
    }

    public UFCadastro ufCnh
    {
        get => ufCnhField;
        set
        {
            ufCnhField = value;
            RaisePropertyChanged(nameof(ufCnh));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime dtValid
    {
        get => dtValidField;
        set
        {
            dtValidField = value;
            RaisePropertyChanged(nameof(dtValid));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime dtPriHab
    {
        get => dtPriHabField;
        set
        {
            dtPriHabField = value;
            RaisePropertyChanged(nameof(dtPriHab));
        }
    }

    [XmlIgnore()]
    public bool dtPriHabSpecified
    {
        get => dtPriHabFieldSpecified;
        set
        {
            dtPriHabFieldSpecified = value;
            RaisePropertyChanged(nameof(dtPriHabSpecified));
        }
    }

    public string categoriaCnh
    {
        get => categoriaCnhField;
        set
        {
            categoriaCnhField = value;
            RaisePropertyChanged(nameof(categoriaCnh));
        }
    }
}

public partial class eSocialEvtAdmissaoTrabalhadorEndereco : ESocialBindableObject
{
    private object itemField;

    [XmlElement("brasil", typeof(EnderecoBrasileiro))]
    [XmlElement("exterior", typeof(TEnderecoExterior))]
    public object Item
    {
        get => itemField;
        set
        {
            itemField = value;
            RaisePropertyChanged(nameof(Item));
        }
    }
}

public partial class TEnderecoExterior : ESocialBindableObject
{
    private string paisResidField;
    private string dscLogradField;
    private string nrLogradField;
    private string complementoField;
    private string bairroField;
    private string nmCidField;
    private string codPostalField;

    public string paisResid
    {
        get => paisResidField;
        set
        {
            paisResidField = value;
            RaisePropertyChanged(nameof(paisResid));
        }
    }

    public string dscLograd
    {
        get => dscLogradField;
        set
        {
            dscLogradField = value;
            RaisePropertyChanged(nameof(dscLograd));
        }
    }

    public string nrLograd
    {
        get => nrLogradField;
        set
        {
            nrLogradField = value;
            RaisePropertyChanged(nameof(nrLograd));
        }
    }

    public string complemento
    {
        get => complementoField;
        set
        {
            complementoField = value;
            RaisePropertyChanged(nameof(complemento));
        }
    }

    public string bairro
    {
        get => bairroField;
        set
        {
            bairroField = value;
            RaisePropertyChanged(nameof(bairro));
        }
    }

    public string nmCid
    {
        get => nmCidField;
        set
        {
            nmCidField = value;
            RaisePropertyChanged(nameof(nmCid));
        }
    }

    public string codPostal
    {
        get => codPostalField;
        set
        {
            codPostalField = value;
            RaisePropertyChanged(nameof(codPostal));
        }
    }
}

public partial class TTrabEstrang : ESocialBindableObject
{
    private DateTime dtChegadaField;
    private bool dtChegadaFieldSpecified;
    private ClasseTrabEstrangeiro classTrabEstrangField = ClasseTrabEstrangeiro.VistoPermanente;
    private SimNaoString casadoBrField = SimNaoString.Nao;
    private SimNaoString filhosBrField = SimNaoString.Nao;

    [XmlElement(DataType = "date")]
    public DateTime dtChegada
    {
        get => dtChegadaField;
        set
        {
            dtChegadaField = value;
            RaisePropertyChanged(nameof(dtChegada));
        }
    }

    [XmlIgnore()]
    public bool dtChegadaSpecified
    {
        get => dtChegadaFieldSpecified;
        set
        {
            dtChegadaFieldSpecified = value;
            RaisePropertyChanged(nameof(dtChegadaSpecified));
        }
    }

    public ClasseTrabEstrangeiro classTrabEstrang
    {
        get => classTrabEstrangField;
        set
        {
            classTrabEstrangField = value;
            RaisePropertyChanged(nameof(classTrabEstrang));
        }
    }

    public SimNaoString casadoBr
    {
        get => casadoBrField;
        set
        {
            casadoBrField = value;
            RaisePropertyChanged(nameof(casadoBr));
        }
    }

    public SimNaoString filhosBr
    {
        get => filhosBrField;
        set
        {
            filhosBrField = value;
            RaisePropertyChanged(nameof(filhosBr));
        }
    }
}

public partial class eSocialEvtAdmissaoTrabalhadorInfoDeficiencia : ESocialBindableObject
{
    private SimNaoString defFisicaField = SimNaoString.Nao;
    private SimNaoString defVisualField = SimNaoString.Nao;
    private SimNaoString defAuditivaField = SimNaoString.Nao;
    private SimNaoString defMentalField = SimNaoString.Nao;
    private SimNaoString defIntelectualField = SimNaoString.Nao;
    private SimNaoString reabReadapField = SimNaoString.Nao;
    private SimNaoString infoCotaField = SimNaoString.Nao;
    private string observacaoField;

    public SimNaoString defFisica
    {
        get => defFisicaField;
        set
        {
            defFisicaField = value;
            RaisePropertyChanged(nameof(defFisica));
        }
    }

    public SimNaoString defVisual
    {
        get => defVisualField;
        set
        {
            defVisualField = value;
            RaisePropertyChanged(nameof(defVisual));
        }
    }

    public SimNaoString defAuditiva
    {
        get => defAuditivaField;
        set
        {
            defAuditivaField = value;
            RaisePropertyChanged(nameof(defAuditiva));
        }
    }

    public SimNaoString defMental
    {
        get => defMentalField;
        set
        {
            defMentalField = value;
            RaisePropertyChanged(nameof(defMental));
        }
    }

    public SimNaoString defIntelectual
    {
        get => defIntelectualField;
        set
        {
            defIntelectualField = value;
            RaisePropertyChanged(nameof(defIntelectual));
        }
    }

    public SimNaoString reabReadap
    {
        get => reabReadapField;
        set
        {
            reabReadapField = value;
            RaisePropertyChanged(nameof(reabReadap));
        }
    }

    public SimNaoString infoCota
    {
        get => infoCotaField;
        set
        {
            infoCotaField = value;
            RaisePropertyChanged(nameof(infoCota));
        }
    }

    public string observacao
    {
        get => observacaoField;
        set
        {
            observacaoField = value;
            RaisePropertyChanged(nameof(observacao));
        }
    }
}

public partial class TDependente : ESocialBindableObject
{
    private string tpDepField;
    private string nmDepField;
    private DateTime dtNasctoField;
    private string cpfDepField;
    private SimNaoString depIRRFField = SimNaoString.Nao;
    private SimNaoString depSFField = SimNaoString.Nao;
    private SimNaoString incTrabField = SimNaoString.Nao;

    public string tpDep
    {
        get => tpDepField;
        set
        {
            tpDepField = value;
            RaisePropertyChanged(nameof(tpDep));
        }
    }

    public string nmDep
    {
        get => nmDepField;
        set
        {
            nmDepField = value;
            RaisePropertyChanged(nameof(nmDep));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime dtNascto
    {
        get => dtNasctoField;
        set
        {
            dtNasctoField = value;
            RaisePropertyChanged(nameof(dtNascto));
        }
    }

    public string cpfDep
    {
        get => cpfDepField;
        set
        {
            cpfDepField = value;
            RaisePropertyChanged(nameof(cpfDep));
        }
    }

    public SimNaoString depIRRF
    {
        get => depIRRFField;
        set
        {
            depIRRFField = value;
            RaisePropertyChanged(nameof(depIRRF));
        }
    }

    public SimNaoString depSF
    {
        get => depSFField;
        set
        {
            depSFField = value;
            RaisePropertyChanged(nameof(depSF));
        }
    }

    public SimNaoString incTrab
    {
        get => incTrabField;
        set
        {
            incTrabField = value;
            RaisePropertyChanged(nameof(incTrab));
        }
    }
}

public partial class eSocialEvtAdmissaoTrabalhadorAposentadoria : ESocialBindableObject
{
    private SimNaoString trabAposentField = SimNaoString.Nao;

    public SimNaoString trabAposent
    {
        get => trabAposentField;
        set
        {
            trabAposentField = value;
            RaisePropertyChanged(nameof(trabAposent));
        }
    }
}

public partial class TContato : ESocialBindableObject
{
    private string fonePrincField;
    private string foneAlternatField;
    private string emailPrincField;
    private string emailAlternatField;

    public string fonePrinc
    {
        get => fonePrincField;
        set
        {
            fonePrincField = value;
            RaisePropertyChanged(nameof(fonePrinc));
        }
    }

    public string foneAlternat
    {
        get => foneAlternatField;
        set
        {
            foneAlternatField = value;
            RaisePropertyChanged(nameof(foneAlternat));
        }
    }

    public string emailPrinc
    {
        get => emailPrincField;
        set
        {
            emailPrincField = value;
            RaisePropertyChanged(nameof(emailPrinc));
        }
    }

    public string emailAlternat
    {
        get => emailAlternatField;
        set
        {
            emailAlternatField = value;
            RaisePropertyChanged(nameof(emailAlternat));
        }
    }
}

public partial class eSocialEvtAdmissaoVinculo : ESocialBindableObject
{
    private string matriculaField;
    private VinculoTrabalhista tpRegTrabField = VinculoTrabalhista.CLT;
    private RegimePrevidenciario tpRegPrevField = RegimePrevidenciario.RGPS;
    private string nrRecInfPrelimField;
    private SimNaoString cadIniField = SimNaoString.Nao;
    private eSocialEvtAdmissaoVinculoInfoRegimeTrab infoRegimeTrabField;
    private eSocialEvtAdmissaoVinculoInfoContrato infoContratoField;
    private eSocialEvtAdmissaoVinculoSucessaoVinc sucessaoVincField;
    private eSocialEvtAdmissaoVinculoTransfDom transfDomField;
    private eSocialEvtAdmissaoVinculoMudancaCPF mudancaCPFField;
    private eSocialEvtAdmissaoVinculoAfastamento afastamentoField;
    private eSocialEvtAdmissaoVinculoDesligamento desligamentoField;

    public string matricula
    {
        get => matriculaField;
        set
        {
            matriculaField = value;
            RaisePropertyChanged(nameof(matricula));
        }
    }

    public VinculoTrabalhista tpRegTrab
    {
        get => tpRegTrabField;
        set
        {
            tpRegTrabField = value;
            RaisePropertyChanged(nameof(tpRegTrab));
        }
    }

    public RegimePrevidenciario tpRegPrev
    {
        get => tpRegPrevField;
        set
        {
            tpRegPrevField = value;
            RaisePropertyChanged(nameof(tpRegPrev));
        }
    }

    public string nrRecInfPrelim
    {
        get => nrRecInfPrelimField;
        set
        {
            nrRecInfPrelimField = value;
            RaisePropertyChanged(nameof(nrRecInfPrelim));
        }
    }

    public SimNaoString cadIni
    {
        get => cadIniField;
        set
        {
            cadIniField = value;
            RaisePropertyChanged(nameof(cadIni));
        }
    }

    public eSocialEvtAdmissaoVinculoInfoRegimeTrab infoRegimeTrab
    {
        get => infoRegimeTrabField;
        set
        {
            infoRegimeTrabField = value;
            RaisePropertyChanged(nameof(infoRegimeTrab));
        }
    }

    public eSocialEvtAdmissaoVinculoInfoContrato infoContrato
    {
        get => infoContratoField;
        set
        {
            infoContratoField = value;
            RaisePropertyChanged(nameof(infoContrato));
        }
    }

    public eSocialEvtAdmissaoVinculoSucessaoVinc sucessaoVinc
    {
        get => sucessaoVincField;
        set
        {
            sucessaoVincField = value;
            RaisePropertyChanged(nameof(sucessaoVinc));
        }
    }

    public eSocialEvtAdmissaoVinculoTransfDom transfDom
    {
        get => transfDomField;
        set
        {
            transfDomField = value;
            RaisePropertyChanged(nameof(transfDom));
        }
    }

    public eSocialEvtAdmissaoVinculoMudancaCPF mudancaCPF
    {
        get => mudancaCPFField;
        set
        {
            mudancaCPFField = value;
            RaisePropertyChanged(nameof(mudancaCPF));
        }
    }

    public eSocialEvtAdmissaoVinculoAfastamento afastamento
    {
        get => afastamentoField;
        set
        {
            afastamentoField = value;
            RaisePropertyChanged(nameof(afastamento));
        }
    }

    public eSocialEvtAdmissaoVinculoDesligamento desligamento
    {
        get => desligamentoField;
        set
        {
            desligamentoField = value;
            RaisePropertyChanged(nameof(desligamento));
        }
    }
}

public partial class eSocialEvtAdmissaoVinculoInfoRegimeTrab : ESocialBindableObject
{
    private object itemField;

    [XmlElement("infoCeletista", typeof(eSocialEvtAdmissaoVinculoInfoRegimeTrabInfoCeletista))]
    [XmlElement("infoEstatutario", typeof(eSocialEvtAdmissaoVinculoInfoRegimeTrabInfoEstatutario))]
    public object Item
    {
        get => itemField;
        set
        {
            itemField = value;
            RaisePropertyChanged(nameof(Item));
        }
    }
}

public partial class eSocialEvtAdmissaoVinculoInfoRegimeTrabInfoCeletista : ESocialBindableObject
{
    private DateTime dtAdmField;
    private TipoAdmissaoCLT tpAdmissaoField = TipoAdmissaoCLT.Admissao;
    private IndicadorAdmissao indAdmissaoField = IndicadorAdmissao.Normal;
    private VinculoRegimeJornada tpRegJorField = VinculoRegimeJornada.SubHorarioTrabalho;
    private NaturezaAtividade natAtividadeField = NaturezaAtividade.Urbano;
    private int dtBaseField;
    private bool dtBaseFieldSpecified;
    private string cnpjSindCategProfField;
    private TFgts fGTSField;
    private eSocialEvtAdmissaoVinculoInfoRegimeTrabInfoCeletistaTrabTemporario trabTemporarioField;
    private eSocialEvtAdmissaoVinculoInfoRegimeTrabInfoCeletistaAprend aprendField;

    [XmlElement(DataType = "date")]
    public DateTime dtAdm
    {
        get => dtAdmField;
        set
        {
            dtAdmField = value;
            RaisePropertyChanged(nameof(dtAdm));
        }
    }

    public TipoAdmissaoCLT tpAdmissao
    {
        get => tpAdmissaoField;
        set
        {
            tpAdmissaoField = value;
            RaisePropertyChanged(nameof(tpAdmissao));
        }
    }

    public IndicadorAdmissao indAdmissao
    {
        get => indAdmissaoField;
        set
        {
            indAdmissaoField = value;
            RaisePropertyChanged(nameof(indAdmissao));
        }
    }

    public VinculoRegimeJornada tpRegJor
    {
        get => tpRegJorField;
        set
        {
            tpRegJorField = value;
            RaisePropertyChanged(nameof(tpRegJor));
        }
    }

    public NaturezaAtividade natAtividade
    {
        get => natAtividadeField;
        set
        {
            natAtividadeField = value;
            RaisePropertyChanged(nameof(natAtividade));
        }
    }

    public sbyte dtBase
    {
        get => (sbyte)dtBaseField;
        set
        {
            dtBaseField = value;
            RaisePropertyChanged(nameof(dtBase));
        }
    }

    [XmlIgnore()]
    public bool dtBaseSpecified
    {
        get => dtBaseFieldSpecified;
        set
        {
            dtBaseFieldSpecified = value;
            RaisePropertyChanged(nameof(dtBaseSpecified));
        }
    }

    public string cnpjSindCategProf
    {
        get => cnpjSindCategProfField;
        set
        {
            cnpjSindCategProfField = value;
            RaisePropertyChanged(nameof(cnpjSindCategProf));
        }
    }

    public TFgts FGTS
    {
        get => fGTSField;
        set
        {
            fGTSField = value;
            RaisePropertyChanged(nameof(FGTS));
        }
    }

    public eSocialEvtAdmissaoVinculoInfoRegimeTrabInfoCeletistaTrabTemporario trabTemporario
    {
        get => trabTemporarioField;
        set
        {
            trabTemporarioField = value;
            RaisePropertyChanged(nameof(trabTemporario));
        }
    }

    public eSocialEvtAdmissaoVinculoInfoRegimeTrabInfoCeletistaAprend aprend
    {
        get => aprendField;
        set
        {
            aprendField = value;
            RaisePropertyChanged(nameof(aprend));
        }
    }
}

public partial class TFgts : ESocialBindableObject
{
    private OpcaoFGTS opcFGTSField = OpcaoFGTS.Optante;
    private DateTime dtOpcFGTSField;
    private bool dtOpcFGTSFieldSpecified;

    public OpcaoFGTS opcFGTS
    {
        get => opcFGTSField;
        set
        {
            opcFGTSField = value;
            RaisePropertyChanged(nameof(opcFGTS));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime dtOpcFGTS
    {
        get => dtOpcFGTSField;
        set
        {
            dtOpcFGTSField = value;
            RaisePropertyChanged(nameof(dtOpcFGTS));
        }
    }

    [XmlIgnore()]
    public bool dtOpcFGTSSpecified
    {
        get => dtOpcFGTSFieldSpecified;
        set
        {
            dtOpcFGTSFieldSpecified = value;
            RaisePropertyChanged(nameof(dtOpcFGTSSpecified));
        }
    }
}

public partial class eSocialEvtAdmissaoVinculoInfoRegimeTrabInfoCeletistaTrabTemporario : ESocialBindableObject
{
    private TrabTemporarioHipotese hipLegField = TrabTemporarioHipotese.DemandaComplementar;
    private string justContrField;
    private TrabTemporarioTpInclusao tpInclContrField = TrabTemporarioTpInclusao.Superior3Meses;
    private bool tpInclContrFieldSpecified;
    private eSocialEvtAdmissaoVinculoInfoRegimeTrabInfoCeletistaTrabTemporarioIdeTomadorServ ideTomadorServField;
    private eSocialEvtAdmissaoVinculoInfoRegimeTrabInfoCeletistaTrabTemporarioIdeTrabSubstituido[] ideTrabSubstituidoField;

    public TrabTemporarioHipotese hipLeg
    {
        get => hipLegField;
        set
        {
            hipLegField = value;
            RaisePropertyChanged(nameof(hipLeg));
        }
    }

    public string justContr
    {
        get => justContrField;
        set
        {
            justContrField = value;
            RaisePropertyChanged(nameof(justContr));
        }
    }

    public TrabTemporarioTpInclusao tpInclContr
    {
        get => tpInclContrField;
        set
        {
            tpInclContrField = value;
            RaisePropertyChanged(nameof(tpInclContr));
        }
    }

    [XmlIgnore()]
    public bool tpInclContrSpecified
    {
        get => tpInclContrFieldSpecified;
        set
        {
            tpInclContrFieldSpecified = value;
            RaisePropertyChanged(nameof(tpInclContrSpecified));
        }
    }

    public eSocialEvtAdmissaoVinculoInfoRegimeTrabInfoCeletistaTrabTemporarioIdeTomadorServ ideTomadorServ
    {
        get => ideTomadorServField;
        set
        {
            ideTomadorServField = value;
            RaisePropertyChanged(nameof(ideTomadorServ));
        }
    }

    [XmlElement("ideTrabSubstituido")]
    public eSocialEvtAdmissaoVinculoInfoRegimeTrabInfoCeletistaTrabTemporarioIdeTrabSubstituido[] ideTrabSubstituido
    {
        get => ideTrabSubstituidoField;
        set
        {
            ideTrabSubstituidoField = value;
            RaisePropertyChanged(nameof(ideTrabSubstituido));
        }
    }
}

public partial class eSocialEvtAdmissaoVinculoInfoRegimeTrabInfoCeletistaTrabTemporarioIdeTomadorServ : ESocialBindableObject
{
    private PersonalidadeJuridica tpInscField = PersonalidadeJuridica.CNPJ;
    private string nrInscField;
    private eSocialEvtAdmissaoVinculoInfoRegimeTrabInfoCeletistaTrabTemporarioIdeTomadorServIdeEstabVinc ideEstabVincField;

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

    public eSocialEvtAdmissaoVinculoInfoRegimeTrabInfoCeletistaTrabTemporarioIdeTomadorServIdeEstabVinc ideEstabVinc
    {
        get => ideEstabVincField;
        set
        {
            ideEstabVincField = value;
            RaisePropertyChanged(nameof(ideEstabVinc));
        }
    }
}

public partial class eSocialEvtAdmissaoVinculoInfoRegimeTrabInfoCeletistaTrabTemporarioIdeTomadorServIdeEstabVinc : ESocialBindableObject
{
    private PersonalidadeJuridica tpInscField = PersonalidadeJuridica.CNPJ;
    private string nrInscField;

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
}

public partial class eSocialEvtAdmissaoVinculoInfoRegimeTrabInfoCeletistaTrabTemporarioIdeTrabSubstituido : ESocialBindableObject
{
    private string cpfTrabSubstField;

    public string cpfTrabSubst
    {
        get => cpfTrabSubstField;
        set
        {
            cpfTrabSubstField = value;
            RaisePropertyChanged(nameof(cpfTrabSubst));
        }
    }
}

public partial class eSocialEvtAdmissaoVinculoInfoRegimeTrabInfoCeletistaAprend : ESocialBindableObject
{
    private PersonalidadeJuridica tpInscField;
    private string nrInscField;

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
}

public partial class eSocialEvtAdmissaoVinculoInfoRegimeTrabInfoEstatutario : ESocialBindableObject
{
    private IndicadorAdmissaoEstatutario indProvimField = IndicadorAdmissaoEstatutario.Normal;
    private TipoProvimentoEstatutario tpProvField = TipoProvimentoEstatutario.NomeacaoEfetivo;
    private DateTime dtNomeacaoField;
    private DateTime dtPosseField;
    private DateTime dtExercicioField;
    private PlanoSegregacaoMassa tpPlanRPField = PlanoSegregacaoMassa.PrevUnico;
    private bool tpPlanRPFieldSpecified;
    private eSocialEvtAdmissaoVinculoInfoRegimeTrabInfoEstatutarioInfoDecJud infoDecJudField;

    public IndicadorAdmissaoEstatutario indProvim
    {
        get => indProvimField;
        set
        {
            indProvimField = value;
            RaisePropertyChanged(nameof(indProvim));
        }
    }

    public TipoProvimentoEstatutario tpProv
    {
        get => tpProvField;
        set
        {
            tpProvField = value;
            RaisePropertyChanged(nameof(tpProv));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime dtNomeacao
    {
        get => dtNomeacaoField;
        set
        {
            dtNomeacaoField = value;
            RaisePropertyChanged(nameof(dtNomeacao));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime dtPosse
    {
        get => dtPosseField;
        set
        {
            dtPosseField = value;
            RaisePropertyChanged(nameof(dtPosse));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime dtExercicio
    {
        get => dtExercicioField;
        set
        {
            dtExercicioField = value;
            RaisePropertyChanged(nameof(dtExercicio));
        }
    }

    public PlanoSegregacaoMassa tpPlanRP
    {
        get => tpPlanRPField;
        set
        {
            tpPlanRPField = value;
            RaisePropertyChanged(nameof(tpPlanRP));
        }
    }

    [XmlIgnore()]
    public bool tpPlanRPSpecified
    {
        get => tpPlanRPFieldSpecified;
        set
        {
            tpPlanRPFieldSpecified = value;
            RaisePropertyChanged(nameof(tpPlanRPSpecified));
        }
    }

    public eSocialEvtAdmissaoVinculoInfoRegimeTrabInfoEstatutarioInfoDecJud infoDecJud
    {
        get => infoDecJudField;
        set
        {
            infoDecJudField = value;
            RaisePropertyChanged(nameof(infoDecJud));
        }
    }
}

public partial class eSocialEvtAdmissaoVinculoInfoRegimeTrabInfoEstatutarioInfoDecJud : ESocialBindableObject
{
    private string nrProcJudField;

    public string nrProcJud
    {
        get => nrProcJudField;
        set
        {
            nrProcJudField = value;
            RaisePropertyChanged(nameof(nrProcJud));
        }
    }
}

public partial class eSocialEvtAdmissaoVinculoInfoContrato : ESocialBindableObject
{
    private string codCargoField;
    private string codFuncaoField;
    private string codCategField;
    private string codCarreiraField;
    private DateTime dtIngrCarrField;
    private bool dtIngrCarrFieldSpecified;
    private TRemun remuneracaoField;
    private eSocialEvtAdmissaoVinculoInfoContratoDuracao duracaoField;
    private eSocialEvtAdmissaoVinculoInfoContratoLocalTrabalho localTrabalhoField;
    private eSocialEvtAdmissaoVinculoInfoContratoHorContratual horContratualField;
    private eSocialEvtAdmissaoVinculoInfoContratoFiliacaoSindical[] filiacaoSindicalField;
    private eSocialEvtAdmissaoVinculoInfoContratoAlvaraJudicial alvaraJudicialField;
    private eSocialEvtAdmissaoVinculoInfoContratoObservacoes[] observacoesField;

    public string codCargo
    {
        get => codCargoField;
        set
        {
            codCargoField = value;
            RaisePropertyChanged(nameof(codCargo));
        }
    }

    public string codFuncao
    {
        get => codFuncaoField;
        set
        {
            codFuncaoField = value;
            RaisePropertyChanged(nameof(codFuncao));
        }
    }

    [XmlElement(DataType = "integer")]
    public string codCateg
    {
        get => codCategField;
        set
        {
            codCategField = value;
            RaisePropertyChanged(nameof(codCateg));
        }
    }

    public string codCarreira
    {
        get => codCarreiraField;
        set
        {
            codCarreiraField = value;
            RaisePropertyChanged(nameof(codCarreira));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime dtIngrCarr
    {
        get => dtIngrCarrField;
        set
        {
            dtIngrCarrField = value;
            RaisePropertyChanged(nameof(dtIngrCarr));
        }
    }

    [XmlIgnore()]
    public bool dtIngrCarrSpecified
    {
        get => dtIngrCarrFieldSpecified;
        set
        {
            dtIngrCarrFieldSpecified = value;
            RaisePropertyChanged(nameof(dtIngrCarrSpecified));
        }
    }

    public TRemun remuneracao
    {
        get => remuneracaoField;
        set
        {
            remuneracaoField = value;
            RaisePropertyChanged(nameof(remuneracao));
        }
    }

    public eSocialEvtAdmissaoVinculoInfoContratoDuracao duracao
    {
        get => duracaoField;
        set
        {
            duracaoField = value;
            RaisePropertyChanged(nameof(duracao));
        }
    }

    public eSocialEvtAdmissaoVinculoInfoContratoLocalTrabalho localTrabalho
    {
        get => localTrabalhoField;
        set
        {
            localTrabalhoField = value;
            RaisePropertyChanged(nameof(localTrabalho));
        }
    }

    public eSocialEvtAdmissaoVinculoInfoContratoHorContratual horContratual
    {
        get => horContratualField;
        set
        {
            horContratualField = value;
            RaisePropertyChanged(nameof(horContratual));
        }
    }

    [XmlElement("filiacaoSindical")]
    public eSocialEvtAdmissaoVinculoInfoContratoFiliacaoSindical[] filiacaoSindical
    {
        get => filiacaoSindicalField;
        set
        {
            filiacaoSindicalField = value;
            RaisePropertyChanged(nameof(filiacaoSindical));
        }
    }

    public eSocialEvtAdmissaoVinculoInfoContratoAlvaraJudicial alvaraJudicial
    {
        get => alvaraJudicialField;
        set
        {
            alvaraJudicialField = value;
            RaisePropertyChanged(nameof(alvaraJudicial));
        }
    }

    [XmlElement("observacoes")]
    public eSocialEvtAdmissaoVinculoInfoContratoObservacoes[] observacoes
    {
        get => observacoesField;
        set
        {
            observacoesField = value;
            RaisePropertyChanged(nameof(observacoes));
        }
    }
}

public partial class TRemun : ESocialBindableObject
{
    private decimal vrSalFxField;
    private UnidadeSalarial undSalFixoField = UnidadeSalarial.Mes;
    private string dscSalVarField;

    public decimal vrSalFx
    {
        get => vrSalFxField;
        set
        {
            vrSalFxField = value;
            RaisePropertyChanged(nameof(vrSalFx));
        }
    }

    public UnidadeSalarial undSalFixo
    {
        get => undSalFixoField;
        set
        {
            undSalFixoField = value;
            RaisePropertyChanged(nameof(undSalFixo));
        }
    }

    public string dscSalVar
    {
        get => dscSalVarField;
        set
        {
            dscSalVarField = value;
            RaisePropertyChanged(nameof(dscSalVar));
        }
    }
}

public partial class eSocialEvtAdmissaoVinculoInfoContratoDuracao : ESocialBindableObject
{
    private TipoContrato tpContrField = TipoContrato.Indeterminado;
    private DateTime dtTermField;
    private bool dtTermFieldSpecified;
    private SimNaoString clauAssecField = SimNaoString.Nao;
    private bool clauAssecFieldSpecified = false;
    private string objDetField;

    public sbyte tpContr
    {
        get => (sbyte)tpContrField;
        set
        {
            tpContrField = (TipoContrato)value;
            RaisePropertyChanged(nameof(tpContr));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime dtTerm
    {
        get => dtTermField;
        set
        {
            dtTermField = value;
            RaisePropertyChanged(nameof(dtTerm));
        }
    }

    [XmlIgnore()]
    public bool dtTermSpecified
    {
        get => dtTermFieldSpecified;
        set
        {
            dtTermFieldSpecified = value;
            RaisePropertyChanged(nameof(dtTermSpecified));
        }
    }

    public SimNaoString clauAssec
    {
        get => clauAssecField;
        set
        {
            clauAssecField = value;
            RaisePropertyChanged(nameof(clauAssec));
        }
    }

    [XmlIgnore()]
    public bool clauAssecSpecified
    {
        get => clauAssecFieldSpecified;
        set
        {
            clauAssecFieldSpecified = value;
            RaisePropertyChanged(nameof(clauAssecSpecified));
        }
    }


    public string objDet
    {
        get => objDetField;
        set
        {
            objDetField = value;
            RaisePropertyChanged(nameof(objDet));
        }
    }
}

public partial class eSocialEvtAdmissaoVinculoInfoContratoLocalTrabalho : ESocialBindableObject
{
    private TLocalTrab localTrabGeralField;
    private EnderecoBrasileiro localTrabDomField;

    public TLocalTrab localTrabGeral
    {
        get => localTrabGeralField;
        set
        {
            localTrabGeralField = value;
            RaisePropertyChanged(nameof(localTrabGeral));
        }
    }

    public EnderecoBrasileiro localTrabDom
    {
        get => localTrabDomField;
        set
        {
            localTrabDomField = value;
            RaisePropertyChanged(nameof(localTrabDom));
        }
    }
}

public partial class TLocalTrab : ESocialBindableObject
{
    private TipoInscricao tpInscField = TipoInscricao.CNPJ;
    private string nrInscField;
    private string descCompField;

    public sbyte tpInsc
    {
        get => (sbyte)tpInscField;
        set
        {
            tpInscField = (TipoInscricao)value;
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

    public string descComp
    {
        get => descCompField;
        set
        {
            descCompField = value;
            RaisePropertyChanged(nameof(descComp));
        }
    }
}

public partial class eSocialEvtAdmissaoVinculoInfoContratoHorContratual : ESocialBindableObject
{
    private decimal qtdHrsSemField;
    private bool qtdHrsSemFieldSpecified;
    private TipoJornada tpJornadaField = TipoJornada.HorarioFixoFolgaFixa_Dom;
    private string dscTpJornField;
    private sbyte tmpParcField;
    private THorario[] horarioField;

    public decimal qtdHrsSem
    {
        get => qtdHrsSemField;
        set
        {
            qtdHrsSemField = value;
            RaisePropertyChanged(nameof(qtdHrsSem));
        }
    }

    [XmlIgnore()]
    public bool qtdHrsSemSpecified
    {
        get => qtdHrsSemFieldSpecified;
        set
        {
            qtdHrsSemFieldSpecified = value;
            RaisePropertyChanged(nameof(qtdHrsSemSpecified));
        }
    }

    public TipoJornada tpJornada
    {
        get => tpJornadaField;
        set
        {
            tpJornadaField = value;
            RaisePropertyChanged(nameof(tpJornada));
        }
    }

    public string dscTpJorn
    {
        get => dscTpJornField;
        set
        {
            dscTpJornField = value;
            RaisePropertyChanged(nameof(dscTpJorn));
        }
    }

    public sbyte tmpParc
    {
        get => tmpParcField;
        set
        {
            tmpParcField = value;
            RaisePropertyChanged(nameof(tmpParc));
        }
    }

    [XmlElement("horario")]
    public THorario[] horario
    {
        get => horarioField;
        set
        {
            horarioField = value;
            RaisePropertyChanged(nameof(horario));
        }
    }
}

public partial class THorario : ESocialBindableObject
{
    private sbyte diaField;
    private string codHorContratField;

    public sbyte dia
    {
        get => diaField;
        set
        {
            diaField = value;
            RaisePropertyChanged(nameof(dia));
        }
    }

    public string codHorContrat
    {
        get => codHorContratField;
        set
        {
            codHorContratField = value;
            RaisePropertyChanged(nameof(codHorContrat));
        }
    }
}

public partial class eSocialEvtAdmissaoVinculoInfoContratoFiliacaoSindical : ESocialBindableObject
{
    private string cnpjSindTrabField;

    public string cnpjSindTrab
    {
        get => cnpjSindTrabField;
        set
        {
            cnpjSindTrabField = value;
            RaisePropertyChanged(nameof(cnpjSindTrab));
        }
    }
}

public partial class eSocialEvtAdmissaoVinculoInfoContratoAlvaraJudicial : ESocialBindableObject
{
    private string nrProcJudField;

    public string nrProcJud
    {
        get => nrProcJudField;
        set
        {
            nrProcJudField = value;
            RaisePropertyChanged(nameof(nrProcJud));
        }
    }
}

public partial class eSocialEvtAdmissaoVinculoInfoContratoObservacoes : ESocialBindableObject
{
    private string observacaoField;

    public string observacao
    {
        get => observacaoField;
        set
        {
            observacaoField = value;
            RaisePropertyChanged(nameof(observacao));
        }
    }
}

public partial class eSocialEvtAdmissaoVinculoSucessaoVinc : ESocialBindableObject
{
    private VinculoSucecssaoAnteriorTipo tpInscAntField = VinculoSucecssaoAnteriorTipo.CNPJ;
    private string cnpjEmpregAntField;
    private string matricAntField;
    private DateTime dtTransfField;
    private string observacaoField;

    public VinculoSucecssaoAnteriorTipo tpInscAnt
    {
        get => tpInscAntField;
        set
        {
            tpInscAntField = value;
            RaisePropertyChanged(nameof(tpInscAnt));
        }
    }

    public string cnpjEmpregAnt
    {
        get => cnpjEmpregAntField;
        set
        {
            cnpjEmpregAntField = value;
            RaisePropertyChanged(nameof(cnpjEmpregAnt));
        }
    }

    public string matricAnt
    {
        get => matricAntField;
        set
        {
            matricAntField = value;
            RaisePropertyChanged(nameof(matricAnt));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime dtTransf
    {
        get => dtTransfField;
        set
        {
            dtTransfField = value;
            RaisePropertyChanged(nameof(dtTransf));
        }
    }

    public string observacao
    {
        get => observacaoField;
        set
        {
            observacaoField = value;
            RaisePropertyChanged(nameof(observacao));
        }
    }
}

public partial class eSocialEvtAdmissaoVinculoTransfDom : ESocialBindableObject
{
    private string cpfSubstituidoField;
    private string matricAntField;
    private DateTime dtTransfField;

    public string cpfSubstituido
    {
        get => cpfSubstituidoField;
        set
        {
            cpfSubstituidoField = value;
            RaisePropertyChanged(nameof(cpfSubstituido));
        }
    }

    public string matricAnt
    {
        get => matricAntField;
        set
        {
            matricAntField = value;
            RaisePropertyChanged(nameof(matricAnt));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime dtTransf
    {
        get => dtTransfField;
        set
        {
            dtTransfField = value;
            RaisePropertyChanged(nameof(dtTransf));
        }
    }
}

public partial class eSocialEvtAdmissaoVinculoMudancaCPF : ESocialBindableObject
{
    private string cpfAntField;
    private string matricAntField;
    private DateTime dtAltCPFField;
    private string observacaoField;

    public string cpfAnt
    {
        get => cpfAntField;
        set
        {
            cpfAntField = value;
            RaisePropertyChanged(nameof(cpfAnt));
        }
    }

    public string matricAnt
    {
        get => matricAntField;
        set
        {
            matricAntField = value;
            RaisePropertyChanged(nameof(matricAnt));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime dtAltCPF
    {
        get => dtAltCPFField;
        set
        {
            dtAltCPFField = value;
            RaisePropertyChanged(nameof(dtAltCPF));
        }
    }

    public string observacao
    {
        get => observacaoField;
        set
        {
            observacaoField = value;
            RaisePropertyChanged(nameof(observacao));
        }
    }
}

public partial class eSocialEvtAdmissaoVinculoAfastamento : ESocialBindableObject
{
    private DateTime dtIniAfastField;
    private string codMotAfastField;

    [XmlElement(DataType = "date")]
    public DateTime dtIniAfast
    {
        get => dtIniAfastField;
        set
        {
            dtIniAfastField = value;
            RaisePropertyChanged(nameof(dtIniAfast));
        }
    }

    public string codMotAfast
    {
        get => codMotAfastField;
        set
        {
            codMotAfastField = value;
            RaisePropertyChanged(nameof(codMotAfast));
        }
    }
}

public partial class eSocialEvtAdmissaoVinculoDesligamento : ESocialBindableObject
{
    private DateTime dtDesligField;

    [XmlElement(DataType = "date")]
    public DateTime dtDeslig
    {
        get => dtDesligField;
        set
        {
            dtDesligField = value;
            RaisePropertyChanged(nameof(dtDeslig));
        }
    }
}
