using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace EficazFramework.SPED.Schemas.eSocial;

/// <summary>
/// S-1280 - Informações Complementares aos Eventos Periódicos
/// </summary>
/// <example>
/// ```csharp
/// evento.evtInfoComplPer = new S1280InfoComplPer()
/// {
///     ideEvento = new IdeEventoPeriodico()
///     {
///         indRetif = IndicadorRetificacao.Original,
///         perApur = "2025-02",
///         tpAmb = Ambiente.ProducaoRestrita_DadosReais,
///         procEmi = EmissorEvento.AppEmpregador,
///         verProc = "v_S_01_03_00"
///     },
///     ideEmpregador = new Empregador()
///     {
///         tpInsc = PersonalidadeJuridica.CNPJ,
///         nrInsc = "12345678"
///     },
///     infoSubstPatr = new S1280InfoSubstPatr()
///     {
///         indSubstPatr = IndicadorSubstPatronal.ParcialmenteSubstituida,
///         percRedContrib = 50.5m
///     },
///     infoSubstPatrOpPort = new List<S1280InfoSubstPatrOpPort>()
///     {
///         new S1280InfoSubstPatrOpPort() { codLotacao = "L01" }
///     },
///     infoAtivConcom = new S1280InfoAtivConcom()
///     {
///         fatorMes = 1.2m,
///         fator13 = 1.5m
///     },
///     infoPercTransf11096 = new S1280InfoPercTransf11096()
///     {
///         percTransf = PercentualTransformacao.Perc20
///     }
/// };
/// ```
/// </example>
[Serializable()]
public partial class S1280 : Evento
{
    private S1280InfoComplPer evtInfoComplPerField;
    private SignatureType signatureField;

    /// <remarks/>
    public S1280InfoComplPer evtInfoComplPer
    {
        get => evtInfoComplPerField;
        set
        {
            evtInfoComplPerField = value;
            RaisePropertyChanged(nameof(evtInfoComplPer));
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
        => evtInfoComplPerField.Id = string.Format("ID{0}{1}{2}", 
            (int)(evtInfoComplPerField?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ), 
            evtInfoComplPerField?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000", 
            eSocialTimeStampUtils.GetTimeStampIDForEvent());

    /// <exclude/>
    public override string ContribuinteCNPJ() 
        => evtInfoComplPerField.ideEmpregador.nrInsc;

    // --- Membros da interface IXmlSignableDocument ---

    /// <exclude/>
    public override string TagToSign => Evento.root;

    /// <exclude/>
    public override string TagId => nameof(evtInfoComplPer);

    /// <exclude/>
    public override bool EmptyURI => true;

    /// <exclude/>
    public override bool SignAsSHA256 => true;
}

/// <exclude />
public partial class S1280InfoComplPer : ESocialBindableObject
{
    private IdeEventoPeriodico ideEventoField;
    private Empregador ideEmpregadorField;
    private S1280InfoSubstPatr infoSubstPatrField;
    private List<S1280InfoSubstPatrOpPort> infoSubstPatrOpPortField;
    private S1280InfoAtivConcom infoAtivConcomField;
    private S1280InfoPercTransf11096 infoPercTransf11096Field;
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

    public S1280InfoSubstPatr infoSubstPatr
    {
        get => infoSubstPatrField;
        set
        {
            infoSubstPatrField = value;
            RaisePropertyChanged(nameof(infoSubstPatr));
        }
    }

    [XmlElement("infoSubstPatrOpPort")]
    public List<S1280InfoSubstPatrOpPort> infoSubstPatrOpPort
    {
        get => infoSubstPatrOpPortField;
        set
        {
            infoSubstPatrOpPortField = value;
            RaisePropertyChanged(nameof(infoSubstPatrOpPort));
        }
    }

    public S1280InfoAtivConcom infoAtivConcom
    {
        get => infoAtivConcomField;
        set
        {
            infoAtivConcomField = value;
            RaisePropertyChanged(nameof(infoAtivConcom));
        }
    }

    public S1280InfoPercTransf11096 infoPercTransf11096
    {
        get => infoPercTransf11096Field;
        set
        {
            infoPercTransf11096Field = value;
            RaisePropertyChanged(nameof(infoPercTransf11096));
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
public partial class S1280InfoSubstPatr : ESocialBindableObject
{
    private IndicadorSubstPatronal indSubstPatrField;
    private decimal percRedContribField;

    public IndicadorSubstPatronal indSubstPatr
    {
        get => indSubstPatrField;
        set
        {
            indSubstPatrField = value;
            RaisePropertyChanged(nameof(indSubstPatr));
        }
    }

    public decimal percRedContrib
    {
        get => percRedContribField;
        set
        {
            percRedContribField = value;
            RaisePropertyChanged(nameof(percRedContrib));
        }
    }
}

/// <exclude />
public partial class S1280InfoSubstPatrOpPort : ESocialBindableObject
{
    private string codLotacaoField;

    public string codLotacao
    {
        get => codLotacaoField;
        set
        {
            codLotacaoField = value;
            RaisePropertyChanged(nameof(codLotacao));
        }
    }
}

/// <exclude />
public partial class S1280InfoAtivConcom : ESocialBindableObject
{
    private decimal fatorMesField;
    private decimal fator13Field;

    public decimal fatorMes
    {
        get => fatorMesField;
        set
        {
            fatorMesField = value;
            RaisePropertyChanged(nameof(fatorMes));
        }
    }

    public decimal fator13
    {
        get => fator13Field;
        set
        {
            fator13Field = value;
            RaisePropertyChanged(nameof(fator13));
        }
    }
}

/// <exclude />
public partial class S1280InfoPercTransf11096 : ESocialBindableObject
{
    private PercentualTransformacao percTransfField;

    public PercentualTransformacao percTransf
    {
        get => percTransfField;
        set
        {
            percTransfField = value;
            RaisePropertyChanged(nameof(percTransf));
        }
    }
}
