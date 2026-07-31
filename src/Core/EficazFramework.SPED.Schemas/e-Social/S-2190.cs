using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace EficazFramework.SPED.Schemas.eSocial;

/// <summary>
/// S-2190 - Registro Preliminar de Trabalhador
/// </summary>
/// <example>
/// ```csharp
/// evento.Versao = Versao.v_S_01_03_00;
/// evento.evtAdmPrelim = new S2190EvtAdmPrelim()
/// {
///     ideEvento = new IdeEventoNaoPeriodico()
///     {
///         indRetif = IndicadorRetificacao.Original,
///         tpAmb = Ambiente.ProducaoRestrita_DadosReais,
///         procEmi = EmissorEvento.AppEmpregador,
///         verProc = "2.2"
///     },
///     ideEmpregador = new Empregador()
///     {
///         tpInsc = PersonalidadeJuridica.CNPJ,
///         nrInsc = "34785515"
///     },
///     infoRegPrelim = new S2190InfoRegPrelim()
///     {
///         cpfTrab = "12345678901",
///         dtNascto = new DateTime(1990, 1, 1),
///         dtAdm = new DateTime(2024, 1, 1),
///         matricula = "123456",
///         codCateg = "101",
///         natAtividade = NaturezaAtividade.Urbano,
///         infoRegCTPS = new S2190InfoRegCTPS()
///         {
///             CBOCargo = "123456",
///             vrSalFx = 2500.50m,
///             undSalFixo = UnidadeSalarial.Mes,
///             tpContr = TipoContrato.Indeterminado,
///             dtTerm = new DateTime(2024, 12, 31)
///         }
///     }
/// };
/// ```
/// </example>
[Serializable()]
public partial class S2190 : Evento
{
    private S2190EvtAdmPrelim evtAdmPrelimField;
    private SignatureType signatureField;

    /// <remarks/>
    public S2190EvtAdmPrelim evtAdmPrelim
    {
        get => evtAdmPrelimField;
        set
        {
            evtAdmPrelimField = value;
            RaisePropertyChanged(nameof(evtAdmPrelim));
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

    // --- Overrides Obrigatórios do Evento ---

    /// <exclude/>
    public override void GeraEventoID()
        => evtAdmPrelimField.Id = string.Format("ID{0}{1}{2}",
            (int)(evtAdmPrelimField?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ),
            evtAdmPrelimField?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000",
            eSocialTimeStampUtils.GetTimeStampIDForEvent());

    /// <exclude/>
    public override string ContribuinteCNPJ()
        => evtAdmPrelimField?.ideEmpregador?.nrInsc;

    // --- Membros da interface IXmlSignableDocument ---

    /// <exclude/>
    public override string TagToSign => Evento.root;

    /// <exclude/>
    public override string TagId => nameof(evtAdmPrelim);

    /// <exclude/>
    public override bool EmptyURI => true;

    /// <exclude/>
    public override bool SignAsSHA256 => true;
}

/// <exclude />
public partial class S2190EvtAdmPrelim : ESocialBindableObject
{
    private IdeEventoNaoPeriodico ideEventoField;
    private Empregador ideEmpregadorField;
    private S2190InfoRegPrelim infoRegPrelimField;
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

    public S2190InfoRegPrelim infoRegPrelim
    {
        get => infoRegPrelimField;
        set
        {
            infoRegPrelimField = value;
            RaisePropertyChanged(nameof(infoRegPrelim));
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

/// <exclude />
public partial class S2190InfoRegPrelim : ESocialBindableObject
{
    private string cpfTrabField;
    private DateTime dtNasctoField;
    private DateTime dtAdmField;
    private string matriculaField;
    private string codCategField;
    private NaturezaAtividade? natAtividadeField;
    private S2190InfoRegCTPS infoRegCTPSField;

    public string cpfTrab
    {
        get => cpfTrabField;
        set
        {
            cpfTrabField = value;
            RaisePropertyChanged(nameof(cpfTrab));
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

    public string matricula
    {
        get => matriculaField;
        set
        {
            matriculaField = value;
            RaisePropertyChanged(nameof(matricula));
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

    public NaturezaAtividade? natAtividade
    {
        get => natAtividadeField;
        set
        {
            natAtividadeField = value;
            RaisePropertyChanged(nameof(natAtividade));
        }
    }

    public bool ShouldSerializenatAtividade()
        => natAtividade.HasValue;

    public S2190InfoRegCTPS infoRegCTPS
    {
        get => infoRegCTPSField;
        set
        {
            infoRegCTPSField = value;
            RaisePropertyChanged(nameof(infoRegCTPS));
        }
    }
}

/// <exclude />
public partial class S2190InfoRegCTPS : ESocialBindableObject
{
    private string cBOCargoField;
    private decimal vrSalFxField;
    private UnidadeSalarial undSalFixoField;
    private TipoContrato tpContrField;
    private DateTime? dtTermField;

    public string CBOCargo
    {
        get => cBOCargoField;
        set
        {
            cBOCargoField = value;
            RaisePropertyChanged(nameof(CBOCargo));
        }
    }

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

    public TipoContrato tpContr
    {
        get => tpContrField;
        set
        {
            tpContrField = value;
            RaisePropertyChanged(nameof(tpContr));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime? dtTerm
    {
        get => dtTermField;
        set
        {
            dtTermField = value;
            RaisePropertyChanged(nameof(dtTerm));
        }
    }

    public bool ShouldSerializedtTerm()
        => dtTerm.HasValue;
}
