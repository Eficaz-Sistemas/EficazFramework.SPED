using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace EficazFramework.SPED.Schemas.eSocial;

/// <summary>
/// S-5003 - Informações do FGTS por Trabalhador
/// </summary>
/// <example>
/// ```csharp
/// evento.Versao = Versao.v_S_01_03_00;
/// evento.evtBasesFGTS = new S5003EvtBasesFGTS()
/// {
///     ideEvento = new S5003IdeEvento()
///     {
///         nrRecArqBase = "1.1.0000000000000000000",
///         indApuracao = IndicadorApuracao.Mensal,
///         perApur = "2025-02"
///     },
///     ideEmpregador = new Empregador()
///     {
///         tpInsc = PersonalidadeJuridica.CNPJ,
///         nrInsc = "34785515000166"
///     },
///     ideTrabalhador = new S5003IdeTrabalhador()
///     {
///         cpfTrab = "12345678901"
///     },
///     infoFGTS = new S5003InfoFGTS()
///     {
///         dtVenc = new DateTime(2025, 3, 7),
///         classTrib = "04",
///         ideEstab =
///         [
///             new S5003IdeEstab()
///             {
///                 tpInsc = PersonalidadeJuridica.CNPJ,
///                 nrInsc = "34785515000166",
///                 ideLotacao =
///                 [
///                     new S5003IdeLotacao()
///                     {
///                         codLotacao = "LOT01",
///                         tpLotacao = "01",
///                         tpInsc = PersonalidadeJuridica.CNPJ,
///                         nrInsc = "34785515000166",
///                         infoTrabFGTS =
///                         [
///                             new S5003InfoTrabFGTS()
///                             {
///                                 matricula = "MAT123",
///                                 codCateg = "101",
///                                 categOrig = "101",
///                                 tpRegTrab = VinculoTrabalhista.CLT,
///                                 remunSuc = SimNaoString.Nao,
///                                 dtDeslig = new DateTime(2025, 2, 28),
///                                 mtvDeslig = "02",
///                                 dtTerm = new DateTime(2025, 2, 28),
///                                 mtvDesligTSV = "01",
///                                 sucessaoVinc = new S5003SucessaoVinc()
///                                 {
///                                     tpInsc = PersonalidadeJuridica.CNPJ,
///                                     nrInsc = "12345678000199",
///                                     matricAnt = "MATOLD",
///                                     dtAdm = new DateTime(2020, 1, 1)
///                                 },
///                                 infoBaseFGTS = new S5003InfoBaseFGTS()
///                                 {
///                                     basePerApur =
///                                     [
///                                         new S5003BasePerApur()
///                                         {
///                                             tpValor = 11,
///                                             indIncid = IndicadorIncidenciaFGTS.Normal,
///                                             remFGTS = 3000.00m,
///                                             dpsFGTS = 240.00m,
///                                             notAFT = "123456",
///                                             natRubr = "1000",
///                                             detRubrSusp =
///                                             [
///                                                 new S5003DetRubrSusp()
///                                                 {
///                                                     codRubr = "RUB01",
///                                                     ideTabRubr = "TAB01",
///                                                     vrRubr = 100.00m,
///                                                     ideProcessoFGTS =
///                                                     [
///                                                         new S5003IdeProcessoFGTS()
///                                                         {
///                                                             nrProc = "12345678901234567890"
///                                                         }
///                                                     ]
///                                                 }
///                                             ]
///                                         }
///                                     ],
///                                     infoBasePerAntE =
///                                     [
///                                         new S5003InfoBasePerAntE()
///                                         {
///                                             perRef = "2024-12",
///                                             tpAcConv = TipoAcordoColetivo.ConversaoLicencaSaudeAcidenteTrabalho,
///                                             basePerAntE =
///                                             [
///                                                 new S5003BasePerAntE()
///                                                 {
///                                                     tpValorE = 13,
///                                                     indIncidE = IndicadorIncidenciaFGTS.Normal,
///                                                     remFGTSE = 1500.00m,
///                                                     dpsFGTSE = 120.00m,
///                                                     detRubrSusp =
///                                                     [
///                                                         new S5003DetRubrSusp()
///                                                         {
///                                                             codRubr = "RUB02",
///                                                             ideTabRubr = "TAB01",
///                                                             vrRubr = 50.00m,
///                                                             ideProcessoFGTS =
///                                                             [
///                                                                 new S5003IdeProcessoFGTS()
///                                                                 {
///                                                                     nrProc = "12345678901234567890"
///                                                                 }
///                                                             ]
///                                                         }
///                                                     ]
///                                                 }
///                                             ]
///                                         }
///                                     ]
///                                 },
///                                 procCS = new S5003ProcCS()
///                                 {
///                                     nrProcJud = "12345678901234567890"
///                                 },
///                                 eConsignado =
///                                 [
///                                     new S5003EConsignado()
///                                     {
///                                         instFinanc = "001",
///                                         nrContrato = "CTRL123",
///                                         vreConsignado = 150.00m
///                                     }
///                                 ]
///                             }
///                         ]
///                     }
///                 ]
///             }
///         ]
///     }
/// };
/// ```
/// </example>
[Serializable()]
public partial class S5003 : Evento
{
    private S5003EvtBasesFGTS evtBasesFGTSField;
    private SignatureType signatureField;

    public S5003()
    {
        evtBasesFGTSField = new S5003EvtBasesFGTS();
    }

    [XmlElement()]
    public S5003EvtBasesFGTS evtBasesFGTS
    {
        get => evtBasesFGTSField;
        set
        {
            evtBasesFGTSField = value;
            RaisePropertyChanged(nameof(evtBasesFGTS));
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
        => evtBasesFGTSField.Id = string.Format("ID{0}{1}{2}",
            (int)(evtBasesFGTSField?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ),
            evtBasesFGTSField?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000",
            eSocialTimeStampUtils.GetTimeStampIDForEvent());

    /// <exclude/>
    public override string ContribuinteCNPJ()
        => evtBasesFGTSField.ideEmpregador.nrInsc;

    // --- Membros da interface IXmlSignableDocument ---

    /// <exclude/>
    public override string TagToSign => Evento.root;

    /// <exclude/>
    public override string TagId => nameof(evtBasesFGTS);

    /// <exclude/>
    public override bool EmptyURI => true;

    /// <exclude/>
    public override bool SignAsSHA256 => true;
}

/// <exclude />
public partial class S5003EvtBasesFGTS : ESocialBindableObject
{
    private S5003IdeEvento ideEventoField;
    private Empregador ideEmpregadorField;
    private S5003IdeTrabalhador ideTrabalhadorField;
    private S5003InfoFGTS infoFGTSField;
    private string idField;

    public S5003IdeEvento ideEvento
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

    public S5003IdeTrabalhador ideTrabalhador
    {
        get => ideTrabalhadorField;
        set
        {
            ideTrabalhadorField = value;
            RaisePropertyChanged(nameof(ideTrabalhador));
        }
    }

    public S5003InfoFGTS infoFGTS
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
public partial class S5003IdeEvento : ESocialBindableObject
{
    private string nrRecArqBaseField;
    private IndicadorApuracao indApuracaoField;
    private string perApurField;

    public string nrRecArqBase
    {
        get => nrRecArqBaseField;
        set
        {
            nrRecArqBaseField = value;
            RaisePropertyChanged(nameof(nrRecArqBase));
        }
    }

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
public partial class S5003IdeTrabalhador : ESocialBindableObject
{
    private string cpfTrabField;

    public string cpfTrab
    {
        get => cpfTrabField;
        set
        {
            cpfTrabField = value;
            RaisePropertyChanged(nameof(cpfTrab));
        }
    }
}

/// <exclude />
public partial class S5003InfoFGTS : ESocialBindableObject
{
    private DateTime? dtVencField;
    private string classTribField;
    private List<S5003IdeEstab> ideEstabField;

    [XmlElement(DataType = "date")]
    public DateTime? dtVenc
    {
        get => dtVencField;
        set
        {
            dtVencField = value;
            RaisePropertyChanged(nameof(dtVenc));
        }
    }

    public bool ShouldSerializedtVenc()
        => dtVenc.HasValue;

    public string classTrib
    {
        get => classTribField;
        set
        {
            classTribField = value;
            RaisePropertyChanged(nameof(classTrib));
        }
    }

    public bool ShouldSerializeclassTrib()
        => !string.IsNullOrEmpty(classTrib);

    [XmlElement("ideEstab")]
    public List<S5003IdeEstab> ideEstab
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
public partial class S5003IdeEstab : ESocialBindableObject
{
    private PersonalidadeJuridica? tpInscField;
    private string nrInscField;
    private List<S5003IdeLotacao> ideLotacaoField;

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

    [XmlElement("ideLotacao")]
    public List<S5003IdeLotacao> ideLotacao
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
public partial class S5003IdeLotacao : ESocialBindableObject
{
    private string codLotacaoField;
    private string tpLotacaoField;
    private PersonalidadeJuridica? tpInscField;
    private string nrInscField;
    private List<S5003InfoTrabFGTS> infoTrabFGTSField;

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

    [XmlElement("infoTrabFGTS")]
    public List<S5003InfoTrabFGTS> infoTrabFGTS
    {
        get => infoTrabFGTSField;
        set
        {
            infoTrabFGTSField = value;
            RaisePropertyChanged(nameof(infoTrabFGTS));
        }
    }
}

/// <exclude />
public partial class S5003InfoTrabFGTS : ESocialBindableObject
{
    private string matriculaField;
    private string codCategField;
    private string categOrigField;
    private VinculoTrabalhista? tpRegTrabField;
    private SimNaoString? remunSucField;
    private DateTime? dtDesligField;
    private string mtvDesligField;
    private DateTime? dtTermField;
    private string mtvDesligTSVField;
    private S5003SucessaoVinc sucessaoVincField;
    private S5003InfoBaseFGTS infoBaseFGTSField;
    private S5003ProcCS procCSField;
    private List<S5003EConsignado> eConsignadoField;

    public string matricula
    {
        get => matriculaField;
        set
        {
            matriculaField = value;
            RaisePropertyChanged(nameof(matricula));
        }
    }

    public string codCateg
    {
        get => codCategField;
        set
        {
            codCategField = value;
            RaisePropertyChanged(nameof(codCateg));
        }
    }

    public string categOrig
    {
        get => categOrigField;
        set
        {
            categOrigField = value;
            RaisePropertyChanged(nameof(categOrig));
        }
    }

    public VinculoTrabalhista? tpRegTrab
    {
        get => tpRegTrabField;
        set
        {
            tpRegTrabField = value;
            RaisePropertyChanged(nameof(tpRegTrab));
        }
    }

    public bool ShouldSerializetpRegTrab()
        => tpRegTrab.HasValue;

    public SimNaoString? remunSuc
    {
        get => remunSucField;
        set
        {
            remunSucField = value;
            RaisePropertyChanged(nameof(remunSuc));
        }
    }

    public bool ShouldSerializeremunSuc()
        => remunSuc.HasValue;

    [XmlElement(DataType = "date")]
    public DateTime? dtDeslig
    {
        get => dtDesligField;
        set
        {
            dtDesligField = value;
            RaisePropertyChanged(nameof(dtDeslig));
        }
    }

    public bool ShouldSerializedtDeslig()
        => dtDeslig.HasValue;

    public string mtvDeslig
    {
        get => mtvDesligField;
        set
        {
            mtvDesligField = value;
            RaisePropertyChanged(nameof(mtvDeslig));
        }
    }

    public bool ShouldSerializemtvDeslig()
        => !string.IsNullOrEmpty(mtvDeslig);

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

    public string mtvDesligTSV
    {
        get => mtvDesligTSVField;
        set
        {
            mtvDesligTSVField = value;
            RaisePropertyChanged(nameof(mtvDesligTSV));
        }
    }

    public bool ShouldSerializemtvDesligTSV()
        => !string.IsNullOrEmpty(mtvDesligTSV);

    public S5003SucessaoVinc sucessaoVinc
    {
        get => sucessaoVincField;
        set
        {
            sucessaoVincField = value;
            RaisePropertyChanged(nameof(sucessaoVinc));
        }
    }

    public S5003InfoBaseFGTS infoBaseFGTS
    {
        get => infoBaseFGTSField;
        set
        {
            infoBaseFGTSField = value;
            RaisePropertyChanged(nameof(infoBaseFGTS));
        }
    }

    public S5003ProcCS procCS
    {
        get => procCSField;
        set
        {
            procCSField = value;
            RaisePropertyChanged(nameof(procCS));
        }
    }

    [XmlElement("eConsignado")]
    public List<S5003EConsignado> eConsignado
    {
        get => eConsignadoField;
        set
        {
            eConsignadoField = value;
            RaisePropertyChanged(nameof(eConsignado));
        }
    }
}

/// <exclude />
public partial class S5003SucessaoVinc : ESocialBindableObject
{
    private PersonalidadeJuridica tpInscField;
    private string nrInscField;
    private string matricAntField;
    private DateTime dtAdmField;

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
    public DateTime dtAdm
    {
        get => dtAdmField;
        set
        {
            dtAdmField = value;
            RaisePropertyChanged(nameof(dtAdm));
        }
    }
}

/// <exclude />
public partial class S5003InfoBaseFGTS : ESocialBindableObject
{
    private List<S5003BasePerApur> basePerApurField;
    private List<S5003InfoBasePerAntE> infoBasePerAntEField;

    [XmlElement("basePerApur")]
    public List<S5003BasePerApur> basePerApur
    {
        get => basePerApurField;
        set
        {
            basePerApurField = value;
            RaisePropertyChanged(nameof(basePerApur));
        }
    }

    [XmlElement("infoBasePerAntE")]
    public List<S5003InfoBasePerAntE> infoBasePerAntE
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
public partial class S5003BasePerApur : ESocialBindableObject
{
    private byte tpValorField;
    private IndicadorIncidenciaFGTS indIncidField;
    private decimal remFGTSField;
    private decimal? dpsFGTSField;
    private string notAFTField;
    private string natRubrField;
    private List<S5003DetRubrSusp> detRubrSuspField;

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

    public decimal remFGTS
    {
        get => remFGTSField;
        set
        {
            remFGTSField = value;
            RaisePropertyChanged(nameof(remFGTS));
        }
    }

    public decimal? dpsFGTS
    {
        get => dpsFGTSField;
        set
        {
            dpsFGTSField = value;
            RaisePropertyChanged(nameof(dpsFGTS));
        }
    }

    public bool ShouldSerializedpsFGTS()
        => dpsFGTS.HasValue;

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

    [XmlElement("detRubrSusp")]
    public List<S5003DetRubrSusp> detRubrSusp
    {
        get => detRubrSuspField;
        set
        {
            detRubrSuspField = value;
            RaisePropertyChanged(nameof(detRubrSusp));
        }
    }
}

/// <exclude />
public partial class S5003InfoBasePerAntE : ESocialBindableObject
{
    private string perRefField;
    private TipoAcordoColetivo tpAcConvField;
    private List<S5003BasePerAntE> basePerAntEField;

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
    public List<S5003BasePerAntE> basePerAntE
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
public partial class S5003BasePerAntE : ESocialBindableObject
{
    private byte tpValorEField;
    private IndicadorIncidenciaFGTS indIncidEField;
    private decimal remFGTSEField;
    private decimal? dpsFGTSEField;
    private List<S5003DetRubrSusp> detRubrSuspField;

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

    public decimal remFGTSE
    {
        get => remFGTSEField;
        set
        {
            remFGTSEField = value;
            RaisePropertyChanged(nameof(remFGTSE));
        }
    }

    public decimal? dpsFGTSE
    {
        get => dpsFGTSEField;
        set
        {
            dpsFGTSEField = value;
            RaisePropertyChanged(nameof(dpsFGTSE));
        }
    }

    public bool ShouldSerializedpsFGTSE()
        => dpsFGTSE.HasValue;

    [XmlElement("detRubrSusp")]
    public List<S5003DetRubrSusp> detRubrSusp
    {
        get => detRubrSuspField;
        set
        {
            detRubrSuspField = value;
            RaisePropertyChanged(nameof(detRubrSusp));
        }
    }
}

/// <exclude />
public partial class S5003DetRubrSusp : ESocialBindableObject
{
    private string codRubrField;
    private string ideTabRubrField;
    private decimal vrRubrField;
    private List<S5003IdeProcessoFGTS> ideProcessoFGTSField;

    public string codRubr
    {
        get => codRubrField;
        set
        {
            codRubrField = value;
            RaisePropertyChanged(nameof(codRubr));
        }
    }

    public string ideTabRubr
    {
        get => ideTabRubrField;
        set
        {
            ideTabRubrField = value;
            RaisePropertyChanged(nameof(ideTabRubr));
        }
    }

    public decimal vrRubr
    {
        get => vrRubrField;
        set
        {
            vrRubrField = value;
            RaisePropertyChanged(nameof(vrRubr));
        }
    }

    [XmlElement("ideProcessoFGTS")]
    public List<S5003IdeProcessoFGTS> ideProcessoFGTS
    {
        get => ideProcessoFGTSField;
        set
        {
            ideProcessoFGTSField = value;
            RaisePropertyChanged(nameof(ideProcessoFGTS));
        }
    }
}

/// <exclude />
public partial class S5003IdeProcessoFGTS : ESocialBindableObject
{
    private string nrProcField;

    public string nrProc
    {
        get => nrProcField;
        set
        {
            nrProcField = value;
            RaisePropertyChanged(nameof(nrProc));
        }
    }
}

/// <exclude />
public partial class S5003ProcCS : ESocialBindableObject
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

/// <exclude />
public partial class S5003EConsignado : ESocialBindableObject
{
    private string instFinancField;
    private string nrContratoField;
    private decimal vreConsignadoField;

    public string instFinanc
    {
        get => instFinancField;
        set
        {
            instFinancField = value;
            RaisePropertyChanged(nameof(instFinanc));
        }
    }

    public string nrContrato
    {
        get => nrContratoField;
        set
        {
            nrContratoField = value;
            RaisePropertyChanged(nameof(nrContrato));
        }
    }

    public decimal vreConsignado
    {
        get => vreConsignadoField;
        set
        {
            vreConsignadoField = value;
            RaisePropertyChanged(nameof(vreConsignado));
        }
    }
}
