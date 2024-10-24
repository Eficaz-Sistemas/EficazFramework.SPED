using System.Collections.ObjectModel;

namespace EficazFramework.SPED.Schemas.eSocial;


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
    public decimal vrCPDesc => ideAdquirField.Sum(f => f.vrCPDesc);

    [XmlIgnore()]
    public decimal vrRatDescPR => ideAdquirField.Sum(f => f.vrRatDescPR);

    [XmlIgnore()]
    public decimal vrSenarDesc => ideAdquirField.Sum(f => f.vrSenarDesc);


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
    public decimal vrCPDesc => nfs.Sum(f => f.vrCPDescPR);

    [XmlIgnore()]
    public decimal vrRatDescPR => nfs.Sum(f => f.vrRatDescPR);

    [XmlIgnore()]
    public decimal vrSenarDesc => nfs.Sum(f => f.vrSenarDesc);


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