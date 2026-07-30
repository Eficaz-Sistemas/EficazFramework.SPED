using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace EficazFramework.SPED.Schemas.eSocial;

/// <summary>
/// S-5011 - Informações das Contribuições Sociais Consolidadas por Contribuinte
/// </summary>
/// <example>
/// ```csharp
/// evento.Versao = Versao.v_S_01_03_00;
/// evento.evtCS = new S5011EvtCS()
/// {
///     ideEvento = new S5011IdeEvento()
///     {
///         indApuracao = IndicadorApuracao.Mensal,
///         perApur = "2025-02"
///     },
///     ideEmpregador = new Empregador()
///     {
///         tpInsc = PersonalidadeJuridica.CNPJ,
///         nrInsc = "34785515000166"
///     },
///     infoCS = new S5011InfoCS()
///     {
///         nrRecArqBase = "1.1.0000000000000000000",
///         indExistInfo = IndicadorExistenciaInfoCS.ComApuracao,
///         infoCPSeg = new S5011InfoCPSeg()
///         {
///             vrDescCP = 500.00m,
///             vrCpSeg = 500.00m
///         },
///         infoContrib = new S5011InfoContrib()
///         {
///             classTrib = "01",
///             infoPJ = new S5011InfoPJ()
///             {
///                 indCoop = IndicadorCooperativa.Nao,
///                 indConstr = SimNaoByte.Nao,
///                 indSubstPatr = IndicadorSubstPatronal.IntegralmenteSubstituida,
///                 percRedContrib = 0.00m,
///                 percTransf = 0.00m,
///                 indTribFolhaPisPasep = SimNaoString.Nao,
///                 infoAtConc = new S5011InfoAtConc()
///                 {
///                     fatorMes = 100.00m,
///                     fator13 = 100.00m
///                 }
///             }
///         },
///         ideEstab =
///         [
///             new S5011IdeEstab()
///             {
///                 tpInsc = PersonalidadeJuridica.CNPJ,
///                 nrInsc = "34785515000166",
///                 infoEstab = new S5011InfoEstab()
///                 {
///                     cnaePrep = "6201500",
///                     cnpjResp = "34785515000166",
///                     aliqRat = 2,
///                     fap = 1.0000m,
///                     aliqRatAjust = 2.0000m,
///                     infoEstabRef = new S5011InfoEstabRef()
///                     {
///                         aliqRat = 2,
///                         fap = 1.0000m,
///                         aliqRatAjust = 2.0000m
///                     },
///                     infoComplObra = new S5011InfoComplObra()
///                     {
///                         indSubstPatrObra = IndicadorSubstPatronalObra.ContribPatSubstituida
///                     }
///                 },
///                 ideLotacao =
///                 [
///                     new S5011IdeLotacao()
///                     {
///                         codLotacao = "LOT01",
///                         fpas = "515",
///                         codTercs = "0001",
///                         codTercsSusp = "0000",
///                         infoTercSusp =
///                         [
///                             new S5011InfoTercSusp()
///                             {
///                                 codTerc = "0001"
///                             }
///                         ],
///                         infoEmprParcial = new S5011InfoEmprParcial()
///                         {
///                             tpInscContrat = PersonalidadeJuridica.CNPJ,
///                             nrInscContrat = "12345678000199",
///                             tpInscProp = PersonalidadeJuridica.CNPJ,
///                             nrInscProp = "12345678000199",
///                             cnoObra = "123456789012"
///                         },
///                         dadosOpPort = new S5011DadosOpPort()
///                         {
///                             cnpjOpPortuario = "12345678000199",
///                             aliqRat = 2,
///                             fap = 1.0000m,
///                             aliqRatAjust = 2.0000m
///                         },
///                         basesRemun =
///                         [
///                             new S5011BasesRemun()
///                             {
///                                 indIncid = IndicadorIncidenciaCS.Normal,
///                                 codCateg = "101",
///                                 basesCp = new S5011BasesCp()
///                                 {
///                                     vrBcCp00 = 5000.00m,
///                                     vrBcCp15 = 0.00m,
///                                     vrBcCp20 = 0.00m,
///                                     vrBcCp25 = 0.00m,
///                                     vrSuspBcCp00 = 0.00m,
///                                     vrSuspBcCp15 = 0.00m,
///                                     vrSuspBcCp20 = 0.00m,
///                                     vrSuspBcCp25 = 0.00m,
///                                     vrBcCp00VA = 0.00m,
///                                     vrBcCp15VA = 0.00m,
///                                     vrBcCp20VA = 0.00m,
///                                     vrBcCp25VA = 0.00m,
///                                     vrSuspBcCp00VA = 0.00m,
///                                     vrSuspBcCp15VA = 0.00m,
///                                     vrSuspBcCp20VA = 0.00m,
///                                     vrSuspBcCp25VA = 0.00m,
///                                     vrDescSest = 0.00m,
///                                     vrCalcSest = 0.00m,
///                                     vrDescSenat = 0.00m,
///                                     vrCalcSenat = 0.00m,
///                                     vrSalFam = 0.00m,
///                                     vrSalMat = 0.00m
///                                 },
///                                 basesCp13 = new S5011BasesCp13()
///                                 {
///                                     vrBcCp00 = 0.00m,
///                                     vrBcCp15 = 0.00m,
///                                     vrBcCp20 = 0.00m,
///                                     vrBcCp25 = 0.00m,
///                                     vrSuspBcCp00 = 0.00m,
///                                     vrSuspBcCp15 = 0.00m,
///                                     vrSuspBcCp20 = 0.00m,
///                                     vrSuspBcCp25 = 0.00m
///                                 }
///                             }
///                         ],
///                         basesAvNPort = new S5011BasesAvNPort()
///                         {
///                             vrBcCp00 = 0.00m,
///                             vrBcCp15 = 0.00m,
///                             vrBcCp20 = 0.00m,
///                             vrBcCp25 = 0.00m,
///                             vrBcCp13 = 0.00m,
///                             vrDescCP = 0.00m
///                         },
///                         infoSubstPatrOpPort = new S5011InfoSubstPatrOpPort()
///                         {
///                             cnpjOpPortuario = "12345678000199"
///                         }
///                     }
///                 ],
///                 basesAquis =
///                 [
///                     new S5011BasesAquis()
///                     {
///                         indAquis = IndicadorAquisicaoS1250.ProdRuralPF,
///                         vlrAquis = 10000.00m,
///                         vrCPDescPR = 120.00m,
///                         vrCPNRet = 0.00m,
///                         vrRatNRet = 0.00m,
///                         vrSenarNRet = 0.00m,
///                         vrCPCalcPR = 120.00m,
///                         vrRatDescPR = 10.00m,
///                         vrRatCalcPR = 10.00m,
///                         vrSenarDesc = 20.00m,
///                         vrSenarCalc = 20.00m
///                     }
///                 ],
///                 basesComerc =
///                 [
///                     new S5011BasesComerc()
///                     {
///                         indComerc = IndicadorComercializacaoS1260.VarejoConsFinalOuProdRural,
///                         vrBcComPR = 5000.00m,
///                         vrCPSusp = 0.00m,
///                         vrRatSusp = 0.00m,
///                         vrSenarSusp = 0.00m
///                     }
///                 ],
///                 infoCREstab =
///                 [
///                     new S5011InfoCREstab()
///                     {
///                         tpCR = "108201",
///                         vrCR = 1000.00m,
///                         vrSuspCR = 0.00m
///                     }
///                 ],
///                 basesPisPasep = new S5011BasesPisPasep()
///                 {
///                     vrBcPisPasep = 5000.00m,
///                     vrBcPisPasepSusp = 0.00m
///                 }
///             }
///         ],
///         infoCRContrib =
///         [
///             new S5011InfoCRContrib()
///             {
///                 tpCR = "108201",
///                 vrCR = 1000.00m,
///                 vrCRSusp = 0.00m
///             }
///         ]
///     }
/// };
/// ```
/// </example>
[Serializable()]
public partial class S5011 : Evento
{
    private S5011EvtCS evtCSField;
    private SignatureType signatureField;

    public S5011()
    {
        evtCSField = new S5011EvtCS();
    }

    [XmlElement()]
    public S5011EvtCS evtCS
    {
        get => evtCSField;
        set
        {
            evtCSField = value;
            RaisePropertyChanged(nameof(evtCS));
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
        => evtCSField.Id = string.Format("ID{0}{1}{2}",
            (int)(evtCSField?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ),
            evtCSField?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000",
            eSocialTimeStampUtils.GetTimeStampIDForEvent());

    /// <exclude/>
    public override string ContribuinteCNPJ()
        => evtCSField.ideEmpregador.nrInsc;

    // --- Membros da interface IXmlSignableDocument ---

    /// <exclude/>
    public override string TagToSign => Evento.root;

    /// <exclude/>
    public override string TagId => nameof(evtCS);

    /// <exclude/>
    public override bool EmptyURI => true;

    /// <exclude/>
    public override bool SignAsSHA256 => true;
}

/// <exclude />
public partial class S5011EvtCS : ESocialBindableObject
{
    private string idField;
    private S5011IdeEvento ideEventoField;
    private Empregador ideEmpregadorField;
    private S5011InfoCS infoCSField;

    public S5011IdeEvento ideEvento
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

    public S5011InfoCS infoCS
    {
        get => infoCSField;
        set
        {
            infoCSField = value;
            RaisePropertyChanged(nameof(infoCS));
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
public partial class S5011IdeEvento : ESocialBindableObject
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
public partial class S5011InfoCS : ESocialBindableObject
{
    private string nrRecArqBaseField;
    private IndicadorExistenciaInfoCS indExistInfoField;
    private S5011InfoCPSeg infoCPSegField;
    private S5011InfoContrib infoContribField;
    private List<S5011IdeEstab> ideEstabField;
    private List<S5011InfoCRContrib> infoCRContribField;

    public string nrRecArqBase
    {
        get => nrRecArqBaseField;
        set
        {
            nrRecArqBaseField = value;
            RaisePropertyChanged(nameof(nrRecArqBase));
        }
    }

    public IndicadorExistenciaInfoCS indExistInfo
    {
        get => indExistInfoField;
        set
        {
            indExistInfoField = value;
            RaisePropertyChanged(nameof(indExistInfo));
        }
    }

    public S5011InfoCPSeg infoCPSeg
    {
        get => infoCPSegField;
        set
        {
            infoCPSegField = value;
            RaisePropertyChanged(nameof(infoCPSeg));
        }
    }

    public bool ShouldSerializeinfoCPSeg()
        => infoCPSeg != null;

    public S5011InfoContrib infoContrib
    {
        get => infoContribField;
        set
        {
            infoContribField = value;
            RaisePropertyChanged(nameof(infoContrib));
        }
    }

    [XmlElement("ideEstab")]
    public List<S5011IdeEstab> ideEstab
    {
        get => ideEstabField;
        set
        {
            ideEstabField = value;
            RaisePropertyChanged(nameof(ideEstab));
        }
    }

    public bool ShouldSerializeideEstab()
        => ideEstab != null && ideEstab.Count > 0;

    [XmlElement("infoCRContrib")]
    public List<S5011InfoCRContrib> infoCRContrib
    {
        get => infoCRContribField;
        set
        {
            infoCRContribField = value;
            RaisePropertyChanged(nameof(infoCRContrib));
        }
    }

    public bool ShouldSerializeinfoCRContrib()
        => infoCRContrib != null && infoCRContrib.Count > 0;
}

/// <exclude />
public partial class S5011InfoCPSeg : ESocialBindableObject
{
    private decimal vrDescCPField;
    private decimal vrCpSegField;

    public decimal vrDescCP
    {
        get => vrDescCPField;
        set
        {
            vrDescCPField = value;
            RaisePropertyChanged(nameof(vrDescCP));
        }
    }

    public decimal vrCpSeg
    {
        get => vrCpSegField;
        set
        {
            vrCpSegField = value;
            RaisePropertyChanged(nameof(vrCpSeg));
        }
    }
}

/// <exclude />
public partial class S5011InfoContrib : ESocialBindableObject
{
    private string classTribField;
    private S5011InfoPJ infoPJField;

    public string classTrib
    {
        get => classTribField;
        set
        {
            classTribField = value;
            RaisePropertyChanged(nameof(classTrib));
        }
    }

    public S5011InfoPJ infoPJ
    {
        get => infoPJField;
        set
        {
            infoPJField = value;
            RaisePropertyChanged(nameof(infoPJ));
        }
    }

    public bool ShouldSerializeinfoPJ()
        => infoPJ != null;
}

/// <exclude />
public partial class S5011InfoPJ : ESocialBindableObject
{
    private IndicadorCooperativa? indCoopField;
    private SimNaoByte indConstrField;
    private IndicadorSubstPatronal? indSubstPatrField;
    private decimal? percRedContribField;
    private PercentualTransformacao? percTransfField;
    private SimNaoString? indTribFolhaPisPasepField;
    private S5011InfoAtConc infoAtConcField;

    public IndicadorCooperativa? indCoop
    {
        get => indCoopField;
        set
        {
            indCoopField = value;
            RaisePropertyChanged(nameof(indCoop));
        }
    }

    public bool ShouldSerializeindCoop()
        => indCoop.HasValue;

    public SimNaoByte indConstr
    {
        get => indConstrField;
        set
        {
            indConstrField = value;
            RaisePropertyChanged(nameof(indConstr));
        }
    }

    public IndicadorSubstPatronal? indSubstPatr
    {
        get => indSubstPatrField;
        set
        {
            indSubstPatrField = value;
            RaisePropertyChanged(nameof(indSubstPatr));
        }
    }

    public bool ShouldSerializeindSubstPatr()
        => indSubstPatr.HasValue;

    public decimal? percRedContrib
    {
        get => percRedContribField;
        set
        {
            percRedContribField = value;
            RaisePropertyChanged(nameof(percRedContrib));
        }
    }

    public bool ShouldSerializepercRedContrib()
        => percRedContrib.HasValue;

    public PercentualTransformacao? percTransf
    {
        get => percTransfField;
        set
        {
            percTransfField = value;
            RaisePropertyChanged(nameof(percTransf));
        }
    }

    public bool ShouldSerializepercTransf()
        => percTransf.HasValue;

    public SimNaoString? indTribFolhaPisPasep
    {
        get => indTribFolhaPisPasepField;
        set
        {
            indTribFolhaPisPasepField = value;
            RaisePropertyChanged(nameof(indTribFolhaPisPasep));
        }
    }

    public bool ShouldSerializeindTribFolhaPisPasep()
        => indTribFolhaPisPasep.HasValue && indTribFolhaPisPasep == SimNaoString.Sim;

    public S5011InfoAtConc infoAtConc
    {
        get => infoAtConcField;
        set
        {
            infoAtConcField = value;
            RaisePropertyChanged(nameof(infoAtConc));
        }
    }

    public bool ShouldSerializeinfoAtConc()
        => infoAtConc != null;
}

/// <exclude />
public partial class S5011InfoAtConc : ESocialBindableObject
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
public partial class S5011IdeEstab : ESocialBindableObject
{
    private PersonalidadeJuridica tpInscField;
    private string nrInscField;
    private S5011InfoEstab infoEstabField;
    private List<S5011IdeLotacao> ideLotacaoField;
    private List<S5011BasesAquis> basesAquisField;
    private List<S5011BasesComerc> basesComercField;
    private List<S5011InfoCREstab> infoCREstabField;
    private S5011BasesPisPasep basesPisPasepField;

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

    public S5011InfoEstab infoEstab
    {
        get => infoEstabField;
        set
        {
            infoEstabField = value;
            RaisePropertyChanged(nameof(infoEstab));
        }
    }

    public bool ShouldSerializeinfoEstab()
        => infoEstab != null;

    [XmlElement("ideLotacao")]
    public List<S5011IdeLotacao> ideLotacao
    {
        get => ideLotacaoField;
        set
        {
            ideLotacaoField = value;
            RaisePropertyChanged(nameof(ideLotacao));
        }
    }

    public bool ShouldSerializeideLotacao()
        => ideLotacao != null && ideLotacao.Count > 0;

    [XmlElement("basesAquis")]
    public List<S5011BasesAquis> basesAquis
    {
        get => basesAquisField;
        set
        {
            basesAquisField = value;
            RaisePropertyChanged(nameof(basesAquis));
        }
    }

    public bool ShouldSerializebasesAquis()
        => basesAquis != null && basesAquis.Count > 0;

    [XmlElement("basesComerc")]
    public List<S5011BasesComerc> basesComerc
    {
        get => basesComercField;
        set
        {
            basesComercField = value;
            RaisePropertyChanged(nameof(basesComerc));
        }
    }

    public bool ShouldSerializebasesComerc()
        => basesComerc != null && basesComerc.Count > 0;

    [XmlElement("infoCREstab")]
    public List<S5011InfoCREstab> infoCREstab
    {
        get => infoCREstabField;
        set
        {
            infoCREstabField = value;
            RaisePropertyChanged(nameof(infoCREstab));
        }
    }

    public bool ShouldSerializeinfoCREstab()
        => infoCREstab != null && infoCREstab.Count > 0;

    public S5011BasesPisPasep basesPisPasep
    {
        get => basesPisPasepField;
        set
        {
            basesPisPasepField = value;
            RaisePropertyChanged(nameof(basesPisPasep));
        }
    }

    public bool ShouldSerializebasesPisPasep()
        => basesPisPasep != null;
}

/// <exclude />
public partial class S5011InfoEstab : ESocialBindableObject
{
    private string cnaePrepField;
    private string cnpjRespField;
    private int? aliqRatField;
    private decimal? fapField;
    private decimal? aliqRatAjustField;
    private S5011InfoEstabRef infoEstabRefField;
    private S5011InfoComplObra infoComplObraField;

    public string cnaePrep
    {
        get => cnaePrepField;
        set
        {
            cnaePrepField = value;
            RaisePropertyChanged(nameof(cnaePrep));
        }
    }

    public string cnpjResp
    {
        get => cnpjRespField;
        set
        {
            cnpjRespField = value;
            RaisePropertyChanged(nameof(cnpjResp));
        }
    }

    public int? aliqRat
    {
        get => aliqRatField;
        set
        {
            aliqRatField = value;
            RaisePropertyChanged(nameof(aliqRat));
        }
    }

    public bool ShouldSerializealiqRat()
        => aliqRat.HasValue;

    public decimal? fap
    {
        get => fapField;
        set
        {
            fapField = value;
            RaisePropertyChanged(nameof(fap));
        }
    }

    public bool ShouldSerializefap()
        => fap.HasValue;

    public decimal? aliqRatAjust
    {
        get => aliqRatAjustField;
        set
        {
            aliqRatAjustField = value;
            RaisePropertyChanged(nameof(aliqRatAjust));
        }
    }

    public bool ShouldSerializealiqRatAjust()
        => aliqRatAjust.HasValue;

    public S5011InfoEstabRef infoEstabRef
    {
        get => infoEstabRefField;
        set
        {
            infoEstabRefField = value;
            RaisePropertyChanged(nameof(infoEstabRef));
        }
    }

    public bool ShouldSerializeinfoEstabRef()
        => infoEstabRef != null;

    public S5011InfoComplObra infoComplObra
    {
        get => infoComplObraField;
        set
        {
            infoComplObraField = value;
            RaisePropertyChanged(nameof(infoComplObra));
        }
    }

    public bool ShouldSerializeinfoComplObra()
        => infoComplObra != null;
}

/// <exclude />
public partial class S5011InfoEstabRef : ESocialBindableObject
{
    private int aliqRatField;
    private decimal? fapField;
    private decimal? aliqRatAjustField;

    public int aliqRat
    {
        get => aliqRatField;
        set
        {
            aliqRatField = value;
            RaisePropertyChanged(nameof(aliqRat));
        }
    }

    public decimal? fap
    {
        get => fapField;
        set
        {
            fapField = value;
            RaisePropertyChanged(nameof(fap));
        }
    }

    public bool ShouldSerializefap()
        => fap.HasValue;

    public decimal? aliqRatAjust
    {
        get => aliqRatAjustField;
        set
        {
            aliqRatAjustField = value;
            RaisePropertyChanged(nameof(aliqRatAjust));
        }
    }

    public bool ShouldSerializealiqRatAjust()
        => aliqRatAjust.HasValue;
}

/// <exclude />
public partial class S5011InfoComplObra : ESocialBindableObject
{
    private IndicadorSubstPatronalObra indSubstPatrObraField;

    public IndicadorSubstPatronalObra indSubstPatrObra
    {
        get => indSubstPatrObraField;
        set
        {
            indSubstPatrObraField = value;
            RaisePropertyChanged(nameof(indSubstPatrObra));
        }
    }
}

/// <exclude />
public partial class S5011IdeLotacao : ESocialBindableObject
{
    private string codLotacaoField;
    private string fpasField;
    private string codTercsField;
    private string codTercsSuspField;
    private List<S5011InfoTercSusp> infoTercSuspField;
    private S5011InfoEmprParcial infoEmprParcialField;
    private S5011DadosOpPort dadosOpPortField;
    private List<S5011BasesRemun> basesRemunField;
    private S5011BasesAvNPort basesAvNPortField;
    private S5011InfoSubstPatrOpPort infoSubstPatrOpPortField;

    public string codLotacao
    {
        get => codLotacaoField;
        set
        {
            codLotacaoField = value;
            RaisePropertyChanged(nameof(codLotacao));
        }
    }

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

    [XmlElement("infoTercSusp")]
    public List<S5011InfoTercSusp> infoTercSusp
    {
        get => infoTercSuspField;
        set
        {
            infoTercSuspField = value;
            RaisePropertyChanged(nameof(infoTercSusp));
        }
    }

    public bool ShouldSerializeinfoTercSusp()
        => infoTercSusp != null && infoTercSusp.Count > 0;

    public S5011InfoEmprParcial infoEmprParcial
    {
        get => infoEmprParcialField;
        set
        {
            infoEmprParcialField = value;
            RaisePropertyChanged(nameof(infoEmprParcial));
        }
    }

    public bool ShouldSerializeinfoEmprParcial()
        => infoEmprParcial != null;

    public S5011DadosOpPort dadosOpPort
    {
        get => dadosOpPortField;
        set
        {
            dadosOpPortField = value;
            RaisePropertyChanged(nameof(dadosOpPort));
        }
    }

    public bool ShouldSerializedadosOpPort()
        => dadosOpPort != null;

    [XmlElement("basesRemun")]
    public List<S5011BasesRemun> basesRemun
    {
        get => basesRemunField;
        set
        {
            basesRemunField = value;
            RaisePropertyChanged(nameof(basesRemun));
        }
    }

    public bool ShouldSerializebasesRemun()
        => basesRemun != null && basesRemun.Count > 0;

    public S5011BasesAvNPort basesAvNPort
    {
        get => basesAvNPortField;
        set
        {
            basesAvNPortField = value;
            RaisePropertyChanged(nameof(basesAvNPort));
        }
    }

    public bool ShouldSerializebasesAvNPort()
        => basesAvNPort != null;

    public S5011InfoSubstPatrOpPort infoSubstPatrOpPort
    {
        get => infoSubstPatrOpPortField;
        set
        {
            infoSubstPatrOpPortField = value;
            RaisePropertyChanged(nameof(infoSubstPatrOpPort));
        }
    }

    public bool ShouldSerializeinfoSubstPatrOpPort()
        => infoSubstPatrOpPort != null;
}

/// <exclude />
public partial class S5011InfoTercSusp : ESocialBindableObject
{
    private string codTercField;

    public string codTerc
    {
        get => codTercField;
        set
        {
            codTercField = value;
            RaisePropertyChanged(nameof(codTerc));
        }
    }
}

/// <exclude />
public partial class S5011InfoEmprParcial : ESocialBindableObject
{
    private PersonalidadeJuridica tpInscContratField;
    private string nrInscContratField;
    private PersonalidadeJuridica tpInscPropField;
    private string nrInscPropField;
    private string cnoObraField;

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

    public string cnoObra
    {
        get => cnoObraField;
        set
        {
            cnoObraField = value;
            RaisePropertyChanged(nameof(cnoObra));
        }
    }
}

/// <exclude />
public partial class S5011DadosOpPort : ESocialBindableObject
{
    private string cnpjOpPortuarioField;
    private int aliqRatField;
    private decimal fapField;
    private decimal aliqRatAjustField;

    public string cnpjOpPortuario
    {
        get => cnpjOpPortuarioField;
        set
        {
            cnpjOpPortuarioField = value;
            RaisePropertyChanged(nameof(cnpjOpPortuario));
        }
    }

    public int aliqRat
    {
        get => aliqRatField;
        set
        {
            aliqRatField = value;
            RaisePropertyChanged(nameof(aliqRat));
        }
    }

    public decimal fap
    {
        get => fapField;
        set
        {
            fapField = value;
            RaisePropertyChanged(nameof(fap));
        }
    }

    public decimal aliqRatAjust
    {
        get => aliqRatAjustField;
        set
        {
            aliqRatAjustField = value;
            RaisePropertyChanged(nameof(aliqRatAjust));
        }
    }
}

/// <exclude />
public partial class S5011BasesRemun : ESocialBindableObject
{
    private IndicadorIncidenciaCS indIncidField;
    private string codCategField;
    private S5011BasesCp basesCpField;
    private S5011BasesCp13 basesCp13Field;

    public IndicadorIncidenciaCS indIncid
    {
        get => indIncidField;
        set
        {
            indIncidField = value;
            RaisePropertyChanged(nameof(indIncid));
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

    public S5011BasesCp basesCp
    {
        get => basesCpField;
        set
        {
            basesCpField = value;
            RaisePropertyChanged(nameof(basesCp));
        }
    }

    public S5011BasesCp13 basesCp13
    {
        get => basesCp13Field;
        set
        {
            basesCp13Field = value;
            RaisePropertyChanged(nameof(basesCp13));
        }
    }

    public bool ShouldSerializebasesCp13()
        => basesCp13 != null;
}

/// <exclude />
public partial class S5011BasesCp : ESocialBindableObject
{
    private decimal vrBcCp00Field;
    private decimal vrBcCp15Field;
    private decimal vrBcCp20Field;
    private decimal vrBcCp25Field;
    private decimal vrSuspBcCp00Field;
    private decimal vrSuspBcCp15Field;
    private decimal vrSuspBcCp20Field;
    private decimal vrSuspBcCp25Field;
    private decimal? vrBcCp00VAField;
    private decimal? vrBcCp15VAField;
    private decimal? vrBcCp20VAField;
    private decimal? vrBcCp25VAField;
    private decimal? vrSuspBcCp00VAField;
    private decimal? vrSuspBcCp15VAField;
    private decimal? vrSuspBcCp20VAField;
    private decimal? vrSuspBcCp25VAField;
    private decimal vrDescSestField;
    private decimal vrCalcSestField;
    private decimal vrDescSenatField;
    private decimal vrCalcSenatField;
    private decimal vrSalFamField;
    private decimal vrSalMatField;

    public decimal vrBcCp00
    {
        get => vrBcCp00Field;
        set
        {
            vrBcCp00Field = value;
            RaisePropertyChanged(nameof(vrBcCp00));
        }
    }

    public decimal vrBcCp15
    {
        get => vrBcCp15Field;
        set
        {
            vrBcCp15Field = value;
            RaisePropertyChanged(nameof(vrBcCp15));
        }
    }

    public decimal vrBcCp20
    {
        get => vrBcCp20Field;
        set
        {
            vrBcCp20Field = value;
            RaisePropertyChanged(nameof(vrBcCp20));
        }
    }

    public decimal vrBcCp25
    {
        get => vrBcCp25Field;
        set
        {
            vrBcCp25Field = value;
            RaisePropertyChanged(nameof(vrBcCp25));
        }
    }

    public decimal vrSuspBcCp00
    {
        get => vrSuspBcCp00Field;
        set
        {
            vrSuspBcCp00Field = value;
            RaisePropertyChanged(nameof(vrSuspBcCp00));
        }
    }

    public decimal vrSuspBcCp15
    {
        get => vrSuspBcCp15Field;
        set
        {
            vrSuspBcCp15Field = value;
            RaisePropertyChanged(nameof(vrSuspBcCp15));
        }
    }

    public decimal vrSuspBcCp20
    {
        get => vrSuspBcCp20Field;
        set
        {
            vrSuspBcCp20Field = value;
            RaisePropertyChanged(nameof(vrSuspBcCp20));
        }
    }

    public decimal vrSuspBcCp25
    {
        get => vrSuspBcCp25Field;
        set
        {
            vrSuspBcCp25Field = value;
            RaisePropertyChanged(nameof(vrSuspBcCp25));
        }
    }

    public decimal? vrBcCp00VA
    {
        get => vrBcCp00VAField;
        set
        {
            vrBcCp00VAField = value;
            RaisePropertyChanged(nameof(vrBcCp00VA));
        }
    }

    public bool ShouldSerializevrBcCp00VA()
        => vrBcCp00VA.HasValue;

    public decimal? vrBcCp15VA
    {
        get => vrBcCp15VAField;
        set
        {
            vrBcCp15VAField = value;
            RaisePropertyChanged(nameof(vrBcCp15VA));
        }
    }

    public bool ShouldSerializevrBcCp15VA()
        => vrBcCp15VA.HasValue;

    public decimal? vrBcCp20VA
    {
        get => vrBcCp20VAField;
        set
        {
            vrBcCp20VAField = value;
            RaisePropertyChanged(nameof(vrBcCp20VA));
        }
    }

    public bool ShouldSerializevrBcCp20VA()
        => vrBcCp20VA.HasValue;

    public decimal? vrBcCp25VA
    {
        get => vrBcCp25VAField;
        set
        {
            vrBcCp25VAField = value;
            RaisePropertyChanged(nameof(vrBcCp25VA));
        }
    }

    public bool ShouldSerializevrBcCp25VA()
        => vrBcCp25VA.HasValue;

    public decimal? vrSuspBcCp00VA
    {
        get => vrSuspBcCp00VAField;
        set
        {
            vrSuspBcCp00VAField = value;
            RaisePropertyChanged(nameof(vrSuspBcCp00VA));
        }
    }

    public bool ShouldSerializevrSuspBcCp00VA()
        => vrSuspBcCp00VA.HasValue;

    public decimal? vrSuspBcCp15VA
    {
        get => vrSuspBcCp15VAField;
        set
        {
            vrSuspBcCp15VAField = value;
            RaisePropertyChanged(nameof(vrSuspBcCp15VA));
        }
    }

    public bool ShouldSerializevrSuspBcCp15VA()
        => vrSuspBcCp15VA.HasValue;

    public decimal? vrSuspBcCp20VA
    {
        get => vrSuspBcCp20VAField;
        set
        {
            vrSuspBcCp20VAField = value;
            RaisePropertyChanged(nameof(vrSuspBcCp20VA));
        }
    }

    public bool ShouldSerializevrSuspBcCp20VA()
        => vrSuspBcCp20VA.HasValue;

    public decimal? vrSuspBcCp25VA
    {
        get => vrSuspBcCp25VAField;
        set
        {
            vrSuspBcCp25VAField = value;
            RaisePropertyChanged(nameof(vrSuspBcCp25VA));
        }
    }

    public bool ShouldSerializevrSuspBcCp25VA()
        => vrSuspBcCp25VA.HasValue;

    public decimal vrDescSest
    {
        get => vrDescSestField;
        set
        {
            vrDescSestField = value;
            RaisePropertyChanged(nameof(vrDescSest));
        }
    }

    public decimal vrCalcSest
    {
        get => vrCalcSestField;
        set
        {
            vrCalcSestField = value;
            RaisePropertyChanged(nameof(vrCalcSest));
        }
    }

    public decimal vrDescSenat
    {
        get => vrDescSenatField;
        set
        {
            vrDescSenatField = value;
            RaisePropertyChanged(nameof(vrDescSenat));
        }
    }

    public decimal vrCalcSenat
    {
        get => vrCalcSenatField;
        set
        {
            vrCalcSenatField = value;
            RaisePropertyChanged(nameof(vrCalcSenat));
        }
    }

    public decimal vrSalFam
    {
        get => vrSalFamField;
        set
        {
            vrSalFamField = value;
            RaisePropertyChanged(nameof(vrSalFam));
        }
    }

    public decimal vrSalMat
    {
        get => vrSalMatField;
        set
        {
            vrSalMatField = value;
            RaisePropertyChanged(nameof(vrSalMat));
        }
    }
}

/// <exclude />
public partial class S5011BasesCp13 : ESocialBindableObject
{
    private decimal vrBcCp00Field;
    private decimal vrBcCp15Field;
    private decimal vrBcCp20Field;
    private decimal vrBcCp25Field;
    private decimal vrSuspBcCp00Field;
    private decimal vrSuspBcCp15Field;
    private decimal vrSuspBcCp20Field;
    private decimal vrSuspBcCp25Field;

    public decimal vrBcCp00
    {
        get => vrBcCp00Field;
        set
        {
            vrBcCp00Field = value;
            RaisePropertyChanged(nameof(vrBcCp00));
        }
    }

    public decimal vrBcCp15
    {
        get => vrBcCp15Field;
        set
        {
            vrBcCp15Field = value;
            RaisePropertyChanged(nameof(vrBcCp15));
        }
    }

    public decimal vrBcCp20
    {
        get => vrBcCp20Field;
        set
        {
            vrBcCp20Field = value;
            RaisePropertyChanged(nameof(vrBcCp20));
        }
    }

    public decimal vrBcCp25
    {
        get => vrBcCp25Field;
        set
        {
            vrBcCp25Field = value;
            RaisePropertyChanged(nameof(vrBcCp25));
        }
    }

    public decimal vrSuspBcCp00
    {
        get => vrSuspBcCp00Field;
        set
        {
            vrSuspBcCp00Field = value;
            RaisePropertyChanged(nameof(vrSuspBcCp00));
        }
    }

    public decimal vrSuspBcCp15
    {
        get => vrSuspBcCp15Field;
        set
        {
            vrSuspBcCp15Field = value;
            RaisePropertyChanged(nameof(vrSuspBcCp15));
        }
    }

    public decimal vrSuspBcCp20
    {
        get => vrSuspBcCp20Field;
        set
        {
            vrSuspBcCp20Field = value;
            RaisePropertyChanged(nameof(vrSuspBcCp20));
        }
    }

    public decimal vrSuspBcCp25
    {
        get => vrSuspBcCp25Field;
        set
        {
            vrSuspBcCp25Field = value;
            RaisePropertyChanged(nameof(vrSuspBcCp25));
        }
    }
}

/// <exclude />
public partial class S5011BasesAvNPort : ESocialBindableObject
{
    private decimal vrBcCp00Field;
    private decimal vrBcCp15Field;
    private decimal vrBcCp20Field;
    private decimal vrBcCp25Field;
    private decimal vrBcCp13Field;
    private decimal vrDescCPField;

    public decimal vrBcCp00
    {
        get => vrBcCp00Field;
        set
        {
            vrBcCp00Field = value;
            RaisePropertyChanged(nameof(vrBcCp00));
        }
    }

    public decimal vrBcCp15
    {
        get => vrBcCp15Field;
        set
        {
            vrBcCp15Field = value;
            RaisePropertyChanged(nameof(vrBcCp15));
        }
    }

    public decimal vrBcCp20
    {
        get => vrBcCp20Field;
        set
        {
            vrBcCp20Field = value;
            RaisePropertyChanged(nameof(vrBcCp20));
        }
    }

    public decimal vrBcCp25
    {
        get => vrBcCp25Field;
        set
        {
            vrBcCp25Field = value;
            RaisePropertyChanged(nameof(vrBcCp25));
        }
    }

    public decimal vrBcCp13
    {
        get => vrBcCp13Field;
        set
        {
            vrBcCp13Field = value;
            RaisePropertyChanged(nameof(vrBcCp13));
        }
    }

    public decimal vrDescCP
    {
        get => vrDescCPField;
        set
        {
            vrDescCPField = value;
            RaisePropertyChanged(nameof(vrDescCP));
        }
    }
}

/// <exclude />
public partial class S5011InfoSubstPatrOpPort : ESocialBindableObject
{
    private string cnpjOpPortuarioField;

    public string cnpjOpPortuario
    {
        get => cnpjOpPortuarioField;
        set
        {
            cnpjOpPortuarioField = value;
            RaisePropertyChanged(nameof(cnpjOpPortuario));
        }
    }
}

/// <exclude />
public partial class S5011BasesAquis : ESocialBindableObject
{
    private IndicadorAquisicaoS1250 indAquisField;
    private decimal vlrAquisField;
    private decimal vrCPDescPRField;
    private decimal vrCPNRetField;
    private decimal vrRatNRetField;
    private decimal vrSenarNRetField;
    private decimal vrCPCalcPRField;
    private decimal vrRatDescPRField;
    private decimal vrRatCalcPRField;
    private decimal vrSenarDescField;
    private decimal vrSenarCalcField;

    public IndicadorAquisicaoS1250 indAquis
    {
        get => indAquisField;
        set
        {
            indAquisField = value;
            RaisePropertyChanged(nameof(indAquis));
        }
    }

    public decimal vlrAquis
    {
        get => vlrAquisField;
        set
        {
            vlrAquisField = value;
            RaisePropertyChanged(nameof(vlrAquis));
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

    public decimal vrCPNRet
    {
        get => vrCPNRetField;
        set
        {
            vrCPNRetField = value;
            RaisePropertyChanged(nameof(vrCPNRet));
        }
    }

    public decimal vrRatNRet
    {
        get => vrRatNRetField;
        set
        {
            vrRatNRetField = value;
            RaisePropertyChanged(nameof(vrRatNRet));
        }
    }

    public decimal vrSenarNRet
    {
        get => vrSenarNRetField;
        set
        {
            vrSenarNRetField = value;
            RaisePropertyChanged(nameof(vrSenarNRet));
        }
    }

    public decimal vrCPCalcPR
    {
        get => vrCPCalcPRField;
        set
        {
            vrCPCalcPRField = value;
            RaisePropertyChanged(nameof(vrCPCalcPR));
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

    public decimal vrRatCalcPR
    {
        get => vrRatCalcPRField;
        set
        {
            vrRatCalcPRField = value;
            RaisePropertyChanged(nameof(vrRatCalcPR));
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

    public decimal vrSenarCalc
    {
        get => vrSenarCalcField;
        set
        {
            vrSenarCalcField = value;
            RaisePropertyChanged(nameof(vrSenarCalc));
        }
    }
}

/// <exclude />
public partial class S5011BasesComerc : ESocialBindableObject
{
    private IndicadorComercializacaoS1260 indComercField;
    private decimal vrBcComPRField;
    private decimal? vrCPSuspField;
    private decimal? vrRatSuspField;
    private decimal? vrSenarSuspField;

    public IndicadorComercializacaoS1260 indComerc
    {
        get => indComercField;
        set
        {
            indComercField = value;
            RaisePropertyChanged(nameof(indComerc));
        }
    }

    public decimal vrBcComPR
    {
        get => vrBcComPRField;
        set
        {
            vrBcComPRField = value;
            RaisePropertyChanged(nameof(vrBcComPR));
        }
    }

    public decimal? vrCPSusp
    {
        get => vrCPSuspField;
        set
        {
            vrCPSuspField = value;
            RaisePropertyChanged(nameof(vrCPSusp));
        }
    }

    public bool ShouldSerializevrCPSusp()
        => vrCPSusp.HasValue;

    public decimal? vrRatSusp
    {
        get => vrRatSuspField;
        set
        {
            vrRatSuspField = value;
            RaisePropertyChanged(nameof(vrRatSusp));
        }
    }

    public bool ShouldSerializevrRatSusp()
        => vrRatSusp.HasValue;

    public decimal? vrSenarSusp
    {
        get => vrSenarSuspField;
        set
        {
            vrSenarSuspField = value;
            RaisePropertyChanged(nameof(vrSenarSusp));
        }
    }

    public bool ShouldSerializevrSenarSusp()
        => vrSenarSusp.HasValue;
}

/// <exclude />
public partial class S5011InfoCREstab : ESocialBindableObject
{
    private string tpCRField;
    private decimal vrCRField;
    private decimal? vrSuspCRField;

    public string tpCR
    {
        get => tpCRField;
        set
        {
            tpCRField = value;
            RaisePropertyChanged(nameof(tpCR));
        }
    }

    public decimal vrCR
    {
        get => vrCRField;
        set
        {
            vrCRField = value;
            RaisePropertyChanged(nameof(vrCR));
        }
    }

    public decimal? vrSuspCR
    {
        get => vrSuspCRField;
        set
        {
            vrSuspCRField = value;
            RaisePropertyChanged(nameof(vrSuspCR));
        }
    }

    public bool ShouldSerializevrSuspCR()
        => vrSuspCR.HasValue;
}

/// <exclude />
public partial class S5011BasesPisPasep : ESocialBindableObject
{
    private decimal vrBcPisPasepField;
    private decimal vrBcPisPasepSuspField;

    public decimal vrBcPisPasep
    {
        get => vrBcPisPasepField;
        set
        {
            vrBcPisPasepField = value;
            RaisePropertyChanged(nameof(vrBcPisPasep));
        }
    }

    public decimal vrBcPisPasepSusp
    {
        get => vrBcPisPasepSuspField;
        set
        {
            vrBcPisPasepSuspField = value;
            RaisePropertyChanged(nameof(vrBcPisPasepSusp));
        }
    }
}

/// <exclude />
public partial class S5011InfoCRContrib : ESocialBindableObject
{
    private string tpCRField;
    private decimal vrCRField;
    private decimal? vrCRSuspField;

    public string tpCR
    {
        get => tpCRField;
        set
        {
            tpCRField = value;
            RaisePropertyChanged(nameof(tpCR));
        }
    }

    public decimal vrCR
    {
        get => vrCRField;
        set
        {
            vrCRField = value;
            RaisePropertyChanged(nameof(vrCR));
        }
    }

    public decimal? vrCRSusp
    {
        get => vrCRSuspField;
        set
        {
            vrCRSuspField = value;
            RaisePropertyChanged(nameof(vrCRSusp));
        }
    }

    public bool ShouldSerializevrCRSusp()
        => vrCRSusp.HasValue;
}
