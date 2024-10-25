using System.Collections.ObjectModel;

namespace EficazFramework.SPED.Schemas.eSocial;










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