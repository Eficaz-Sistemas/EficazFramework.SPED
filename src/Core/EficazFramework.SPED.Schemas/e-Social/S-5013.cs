using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace EficazFramework.SPED.Schemas.eSocial;

/// <summary>
/// S-5013 - Informações do FGTS Consolidadas por Contribuinte
/// </summary>
/// <example>
/// ```csharp
/// evento.Versao = Versao.v_S_01_03_00;
/// evento.evtFGTS = new S5013EvtFGTS()
/// {
///     ideEvento = new S5013IdeEvento()
///     {
///         indApuracao = IndicadorApuracao.Mensal,
///         perApur = "2025-02"
///     },
///     ideEmpregador = new Empregador()
///     {
///         tpInsc = PersonalidadeJuridica.CNPJ,
///         nrInsc = "34785515000166"
///     },
///     infoFGTS = new S5013InfoFGTS()
///     {
///         nrRecArqBase = "1.1.0000000000000000000",
///         indExistInfo = IndicadorExistenciaInfoFGTS.HaInformacoesFGTS,
///         ideEstab =
///         [
///             new S5013IdeEstab()
///             {
///                 tpInsc = PersonalidadeJuridica.CNPJ,
///                 nrInsc = "34785515000166",
///                 ideLotacao =
///                 [
///                     new S5013IdeLotacao()
///                     {
///                         codLotacao = "LOT01",
///                         tpLotacao = "01",
///                         tpInsc = PersonalidadeJuridica.CNPJ,
///                         nrInsc = "34785515000166",
///                         infoBaseFGTS = new S5013InfoBaseFGTS()
///                         {
///                             basePerApur =
///                             [
///                                 new S5013BasePerApur()
///                                 {
///                                     tpValor = 11,
///                                     indIncid = IndicadorIncidenciaFGTS.Normal,
///                                     baseFGTS = 5000.00m,
///                                     vrFGTS = 400.00m,
///                                     notAFT = "123456",
///                                     natRubr = "1000"
///                                 }
///                             ],
///                             infoBasePerAntE =
///                             [
///                                 new S5013InfoBasePerAntE()
///                                 {
///                                     perRef = "2024-12",
///                                     tpAcConv = TipoAcordoColetivo.ConversaoLicencaSaudeAcidenteTrabalho,
///                                     basePerAntE =
///                                     [
///                                         new S5013BasePerAntE()
///                                         {
///                                             tpValorE = 13,
///                                             indIncidE = IndicadorIncidenciaFGTS.Normal,
///                                             baseFGTSE = 2500.00m,
///                                             vrFGTSE = 200.00m
///                                         }
///                                     ]
///                                 }
///                             ]
///                         }
///                     }
///                 ]
///             }
///         ]
///     }
/// };
/// ```
/// </example>
[Serializable()]
public partial class S5013 : Evento
{
    private S5013EvtFGTS evtFGTSField;
    private SignatureType signatureField;

    public S5013()
    {
        evtFGTSField = new S5013EvtFGTS();
    }

    [XmlElement()]
    public S5013EvtFGTS evtFGTS
    {
        get => evtFGTSField;
        set
        {
            evtFGTSField = value;
            RaisePropertyChanged(nameof(evtFGTS));
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

    // --- Overrides Obrigatórios do Evento ---

    /// <exclude/>
    public override void GeraEventoID()
        => evtFGTSField.Id = string.Format("ID{0}{1}{2}",
            (int)(evtFGTSField?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ),
            evtFGTSField?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000",
            eSocialTimeStampUtils.GetTimeStampIDForEvent());

    /// <exclude/>
    public override string ContribuinteCNPJ()
        => evtFGTSField.ideEmpregador.nrInsc;

    // --- Membros da interface IXmlSignableDocument ---

    /// <exclude/>
    public override string TagToSign => Evento.root;

    /// <exclude/>
    public override string TagId => nameof(evtFGTS);

    /// <exclude/>
    public override bool EmptyURI => true;

    /// <exclude/>
    public override bool SignAsSHA256 => true;
}

/// <exclude />
public partial class S5013EvtFGTS : ESocialBindableObject
{
    private string idField;
    private S5013IdeEvento ideEventoField;
    private Empregador ideEmpregadorField;
    private S5013InfoFGTS infoFGTSField;

    public S5013IdeEvento ideEvento
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

    public S5013InfoFGTS infoFGTS
    {
        get => infoFGTSField;
        set
        {
            infoFGTSField = value;
            RaisePropertyChanged(nameof(infoFGTS));
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
public partial class S5013IdeEvento : ESocialBindableObject
{
    private IndicadorApuracao indApuracaoField;
    private string perApurField;

    public IndicadorApuracao indApuracao
    {
        get => indApuracaoField;
        set
        {
            indApuracaoField = value;
            RaisePropertyChanged(nameof(indApuracao));
        }
    }

    public string perApur
    {
        get => perApurField;
        set
        {
            perApurField = value;
            RaisePropertyChanged(nameof(perApur));
        }
    }
}

/// <exclude />
public partial class S5013InfoFGTS : ESocialBindableObject
{
    private string nrRecArqBaseField;
    private IndicadorExistenciaInfoFGTS indExistInfoField;
    private List<S5013IdeEstab> ideEstabField;

    public string nrRecArqBase
    {
        get => nrRecArqBaseField;
        set
        {
            nrRecArqBaseField = value;
            RaisePropertyChanged(nameof(nrRecArqBase));
        }
    }

    public IndicadorExistenciaInfoFGTS indExistInfo
    {
        get => indExistInfoField;
        set
        {
            indExistInfoField = value;
            RaisePropertyChanged(nameof(indExistInfo));
        }
    }

    [XmlElement("ideEstab")]
    public List<S5013IdeEstab> ideEstab
    {
        get => ideEstabField;
        set
        {
            ideEstabField = value;
            RaisePropertyChanged(nameof(ideEstab));
        }
    }
}

/// <exclude />
public partial class S5013IdeEstab : ESocialBindableObject
{
    private PersonalidadeJuridica tpInscField;
    private string nrInscField;
    private List<S5013IdeLotacao> ideLotacaoField;

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

    [XmlElement("ideLotacao")]
    public List<S5013IdeLotacao> ideLotacao
    {
        get => ideLotacaoField;
        set
        {
            ideLotacaoField = value;
            RaisePropertyChanged(nameof(ideLotacao));
        }
    }
}

/// <exclude />
public partial class S5013IdeLotacao : ESocialBindableObject
{
    private string codLotacaoField;
    private string tpLotacaoField;
    private PersonalidadeJuridica? tpInscField;
    private string nrInscField;
    private S5013InfoBaseFGTS infoBaseFGTSField;

    public string codLotacao
    {
        get => codLotacaoField;
        set
        {
            codLotacaoField = value;
            RaisePropertyChanged(nameof(codLotacao));
        }
    }

    public string tpLotacao
    {
        get => tpLotacaoField;
        set
        {
            tpLotacaoField = value;
            RaisePropertyChanged(nameof(tpLotacao));
        }
    }

    public PersonalidadeJuridica? tpInsc
    {
        get => tpInscField;
        set
        {
            tpInscField = value;
            RaisePropertyChanged(nameof(tpInsc));
        }
    }

    public bool ShouldSerializetpInsc()
        => tpInsc.HasValue;

    public string nrInsc
    {
        get => nrInscField;
        set
        {
            nrInscField = value;
            RaisePropertyChanged(nameof(nrInsc));
        }
    }

    public S5013InfoBaseFGTS infoBaseFGTS
    {
        get => infoBaseFGTSField;
        set
        {
            infoBaseFGTSField = value;
            RaisePropertyChanged(nameof(infoBaseFGTS));
        }
    }
}

/// <exclude />
public partial class S5013InfoBaseFGTS : ESocialBindableObject
{
    private List<S5013BasePerApur> basePerApurField;
    private List<S5013InfoBasePerAntE> infoBasePerAntEField;

    [XmlElement("basePerApur")]
    public List<S5013BasePerApur> basePerApur
    {
        get => basePerApurField;
        set
        {
            basePerApurField = value;
            RaisePropertyChanged(nameof(basePerApur));
        }
    }

    [XmlElement("infoBasePerAntE")]
    public List<S5013InfoBasePerAntE> infoBasePerAntE
    {
        get => infoBasePerAntEField;
        set
        {
            infoBasePerAntEField = value;
            RaisePropertyChanged(nameof(infoBasePerAntE));
        }
    }
}

/// <exclude />
public partial class S5013BasePerApur : ESocialBindableObject
{
    private byte tpValorField;
    private IndicadorIncidenciaFGTS indIncidField;
    private decimal baseFGTSField;
    private decimal? vrFGTSField;
    private string notAFTField;
    private string natRubrField;

    public byte tpValor
    {
        get => tpValorField;
        set
        {
            tpValorField = value;
            RaisePropertyChanged(nameof(tpValor));
        }
    }

    public IndicadorIncidenciaFGTS indIncid
    {
        get => indIncidField;
        set
        {
            indIncidField = value;
            RaisePropertyChanged(nameof(indIncid));
        }
    }

    public decimal baseFGTS
    {
        get => baseFGTSField;
        set
        {
            baseFGTSField = value;
            RaisePropertyChanged(nameof(baseFGTS));
        }
    }

    public decimal? vrFGTS
    {
        get => vrFGTSField;
        set
        {
            vrFGTSField = value;
            RaisePropertyChanged(nameof(vrFGTS));
        }
    }

    public bool ShouldSerializevrFGTS()
        => vrFGTS.HasValue;

    public string notAFT
    {
        get => notAFTField;
        set
        {
            notAFTField = value;
            RaisePropertyChanged(nameof(notAFT));
        }
    }

    public bool ShouldSerializenotAFT()
        => !string.IsNullOrEmpty(notAFT);

    public string natRubr
    {
        get => natRubrField;
        set
        {
            natRubrField = value;
            RaisePropertyChanged(nameof(natRubr));
        }
    }

    public bool ShouldSerializenatRubr()
        => !string.IsNullOrEmpty(natRubr);
}

/// <exclude />
public partial class S5013InfoBasePerAntE : ESocialBindableObject
{
    private string perRefField;
    private TipoAcordoColetivo tpAcConvField;
    private List<S5013BasePerAntE> basePerAntEField;

    public string perRef
    {
        get => perRefField;
        set
        {
            perRefField = value;
            RaisePropertyChanged(nameof(perRef));
        }
    }

    public TipoAcordoColetivo tpAcConv
    {
        get => tpAcConvField;
        set
        {
            tpAcConvField = value;
            RaisePropertyChanged(nameof(tpAcConv));
        }
    }

    [XmlElement("basePerAntE")]
    public List<S5013BasePerAntE> basePerAntE
    {
        get => basePerAntEField;
        set
        {
            basePerAntEField = value;
            RaisePropertyChanged(nameof(basePerAntE));
        }
    }
}

/// <exclude />
public partial class S5013BasePerAntE : ESocialBindableObject
{
    private byte tpValorEField;
    private IndicadorIncidenciaFGTS indIncidEField;
    private decimal baseFGTSEField;
    private decimal? vrFGTSEField;

    public byte tpValorE
    {
        get => tpValorEField;
        set
        {
            tpValorEField = value;
            RaisePropertyChanged(nameof(tpValorE));
        }
    }

    public IndicadorIncidenciaFGTS indIncidE
    {
        get => indIncidEField;
        set
        {
            indIncidEField = value;
            RaisePropertyChanged(nameof(indIncidE));
        }
    }

    public decimal baseFGTSE
    {
        get => baseFGTSEField;
        set
        {
            baseFGTSEField = value;
            RaisePropertyChanged(nameof(baseFGTSE));
        }
    }

    public decimal? vrFGTSE
    {
        get => vrFGTSEField;
        set
        {
            vrFGTSEField = value;
            RaisePropertyChanged(nameof(vrFGTSE));
        }
    }

    public bool ShouldSerializevrFGTSE()
        => vrFGTSE.HasValue;
}
