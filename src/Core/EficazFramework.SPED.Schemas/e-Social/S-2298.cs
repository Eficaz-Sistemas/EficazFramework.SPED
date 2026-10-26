using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EficazFramework.SPED.Schemas.eSocial;

/// <summary>
/// Reintegração/Outros Provimentos
/// </summary>
/// <example>
/// ```csharp
/// evento.Versao = Versao.v_S_01_03_00;
///
/// evento.evtReintegr = new S2298EvtReintegr
/// {
///     ideEvento = new S2298IdeEvento
///     {
///         indRetif = IndicadorRetificacao.Original,
///         nrRecibo = null,
///         tpAmb = Ambiente.ProducaoRestrita_DadosReais,
///         procEmi = EmissorEvento.AppEmpregador,
///         verProc = "EficazFramework"
///     },
///
///     ideEmpregador = new Empregador
///     {
///         tpInsc = PersonalidadeJuridica.CNPJ,
///         nrInsc = "12345678000199"
///     },
///
///     ideVinculo = new S2298IdeVinculo
///     {
///         cpfTrab = "12345678901",
///         matricula = "123"
///     },
///
///     infoReintegr = new S2298InfoReintegr
///     {
///         tpReint = TipoReintegracao.DecisaoJudicial,
///         nrProcJud = "12345678901234567890",
///         nrLeiAnistia = null,
///         dtEfetRetorno = new DateTime(2026, 10, 15),
///         dtEfeito = new DateTime(2026, 10, 1)
///     }
/// };
/// ```
/// </example>
[Serializable()]
public partial class S2298 : Evento
{
    private S2298EvtReintegr evtReintegrField;
    private SignatureType signatureField;

    public S2298()
    {
        evtReintegrField = new S2298EvtReintegr();
    }

    [XmlElement()]
    public S2298EvtReintegr evtReintegr
    {
        get => evtReintegrField;
        set
        {
            evtReintegrField = value;
            RaisePropertyChanged(nameof(evtReintegr));
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

    public override void GeraEventoID()
        => evtReintegrField.Id = string.Format("ID{0}{1}{2}",
            (int)(evtReintegrField?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ),
            evtReintegrField?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000",
            eSocialTimeStampUtils.GetTimeStampIDForEvent());

    public override string ContribuinteCNPJ()
        => evtReintegrField.ideEmpregador.nrInsc;

    public override string TagToSign => Evento.root;
    public override string TagId => nameof(evtReintegr);
    public override bool EmptyURI => true;
    public override bool SignAsSHA256 => true;
}

/// <exclude />
public partial class S2298EvtReintegr : ESocialBindableObject
{
    private string idField;
    private S2298IdeEvento ideEventoField;
    private Empregador ideEmpregadorField;
    private S2298IdeVinculo ideVinculoField;
    private S2298InfoReintegr infoReintegrField;

    public S2298EvtReintegr()
    {
        ideEventoField = new S2298IdeEvento();
        ideEmpregadorField = new Empregador();
        ideVinculoField = new S2298IdeVinculo();
        infoReintegrField = new S2298InfoReintegr();
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

    [XmlElement()]
    public S2298IdeEvento ideEvento
    {
        get => ideEventoField;
        set
        {
            ideEventoField = value;
            RaisePropertyChanged(nameof(ideEvento));
        }
    }

    [XmlElement()]
    public Empregador ideEmpregador
    {
        get => ideEmpregadorField;
        set
        {
            ideEmpregadorField = value;
            RaisePropertyChanged(nameof(ideEmpregador));
        }
    }

    [XmlElement()]
    public S2298IdeVinculo ideVinculo
    {
        get => ideVinculoField;
        set
        {
            ideVinculoField = value;
            RaisePropertyChanged(nameof(ideVinculo));
        }
    }

    [XmlElement()]
    public S2298InfoReintegr infoReintegr
    {
        get => infoReintegrField;
        set
        {
            infoReintegrField = value;
            RaisePropertyChanged(nameof(infoReintegr));
        }
    }
}

public enum TipoReintegracao
{
    [XmlEnum("1")]
    [Description("Reintegração por decisão judicial")]
    DecisaoJudicial = 1,

    [XmlEnum("2")]
    [Description("Reintegração por anistia legal")]
    AnistiaLegal = 2,

    [XmlEnum("3")]
    [Description("Reversão de servidor público")]
    ReversaoServidorPublico = 3,

    [XmlEnum("4")]
    [Description("Recondução de servidor público")]
    ReconducaoServidorPublico = 4,

    [XmlEnum("5")]
    [Description("Reinclusão de militar")]
    ReinclusaoMilitar = 5,

    [XmlEnum("6")]
    [Description("Revisão de reforma de militar")]
    RevisaoReformaMilitar = 6,

    [XmlEnum("9")]
    [Description("Outros")]
    Outros = 9
}

/// <exclude />
public partial class S2298IdeEvento : ESocialBindableObject
{
    private IndicadorRetificacao indRetifField = IndicadorRetificacao.Original;
    private string nrReciboField;
    private Ambiente tpAmbField = Ambiente.Producao;
    private EmissorEvento procEmiField = EmissorEvento.AppEmpregador;
    private string verProcField;

    public IndicadorRetificacao indRetif
    {
        get => indRetifField;
        set
        {
            indRetifField = value;
            RaisePropertyChanged(nameof(indRetif));
        }
    }

    public string nrRecibo
    {
        get => nrReciboField;
        set
        {
            nrReciboField = value;
            RaisePropertyChanged(nameof(nrRecibo));
        }
    }

    public Ambiente tpAmb
    {
        get => tpAmbField;
        set
        {
            tpAmbField = value;
            RaisePropertyChanged(nameof(tpAmb));
        }
    }

    public EmissorEvento procEmi
    {
        get => procEmiField;
        set
        {
            procEmiField = value;
            RaisePropertyChanged(nameof(procEmi));
        }
    }

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

/// <exclude />
public partial class S2298IdeVinculo : ESocialBindableObject
{
    private string cpfTrabField;
    private string matriculaField;

    public string cpfTrab
    {
        get => cpfTrabField;
        set
        {
            cpfTrabField = value;
            RaisePropertyChanged(nameof(cpfTrab));
        }
    }

    public string matricula
    {
        get => matriculaField;
        set
        {
            matriculaField = value;
            RaisePropertyChanged(nameof(matricula));
        }
    }
}

/// <exclude />
public partial class S2298InfoReintegr : ESocialBindableObject
{
    private TipoReintegracao tpReintField;
    private string nrProcJudField;
    private string nrLeiAnistiaField;
    private DateTime dtEfetRetornoField;
    private DateTime dtEfeitoField;

    public TipoReintegracao tpReint
    {
        get => tpReintField;
        set
        {
            tpReintField = value;
            RaisePropertyChanged(nameof(tpReint));
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

    public string nrLeiAnistia
    {
        get => nrLeiAnistiaField;
        set
        {
            nrLeiAnistiaField = value;
            RaisePropertyChanged(nameof(nrLeiAnistia));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime dtEfetRetorno
    {
        get => dtEfetRetornoField;
        set
        {
            dtEfetRetornoField = value;
            RaisePropertyChanged(nameof(dtEfetRetorno));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime dtEfeito
    {
        get => dtEfeitoField;
        set
        {
            dtEfeitoField = value;
            RaisePropertyChanged(nameof(dtEfeito));
        }
    }
}
