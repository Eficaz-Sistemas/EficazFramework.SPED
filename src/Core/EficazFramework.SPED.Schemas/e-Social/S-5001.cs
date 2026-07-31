using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace EficazFramework.SPED.Schemas.eSocial;

/// <summary>
/// S-5001 - Informações das Contribuições Sociais por Trabalhador
/// </summary>
/// <example>
/// ```csharp
/// evento.Versao = Versao.v_S_01_03_00;
/// evento.evtBasesTrab = new S5001EvtBasesTrab()
/// {
///     ideEvento = new S5001IdeEvento()
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
///     ideTrabalhador = new S5001IdeTrabalhador()
///     {
///         cpfTrab = "12345678901",
///         infoCompl = new S5001InfoCompl()
///         {
///             sucessaoVinc = new S5001SucessaoVinc()
///             {
///                 tpInsc = PersonalidadeJuridica.CNPJ,
///                 nrInsc = "12345678000199",
///                 matricAnt = "M123",
///                 dtAdm = new DateTime(2020, 1, 1)
///             },
///             infoInterm =
///             [
///                 new S5001InfoInterm()
///                 {
///                     dia = 15,
///                     hrsTrab = "0800"
///                 }
///             ],
///             infoComplCont =
///             [
///                 new S5001InfoComplCont()
///                 {
///                     codCBO = "123456",
///                     natAtividade = NaturezaAtividade.Urbano,
///                     qtdDiasTrab = 22
///                 }
///             ]
///         },
///         procJudTrab =
///         [
///             new S5001ProcJudTrab()
///             {
///                 nrProcJud = "12345678901234567890",
///                 codSusp = "123456"
///             }
///         ]
///     },
///     infoCpCalc =
///     [
///         new S5001InfoCpCalc()
///         {
///             tpCR = "108201",
///             vrCpSeg = 150.00m,
///             vrDescSeg = 150.00m
///         }
///     ],
///     infoCp = new S5001InfoCp()
///     {
///         classTrib = "99",
///         ideEstabLot =
///         [
///             new S5001IdeEstabLot()
///             {
///                 tpInsc = PersonalidadeJuridica.CNPJ,
///                 nrInsc = "34785515000166",
///                 codLotacao = "01",
///                 infoCategIncid =
///                 [
///                     new S5001InfoCategIncid()
///                     {
///                         matricula = "MAT123",
///                         codCateg = "101",
///                         indSimples = IndicadorSubstSimples.NaoSubstituida,
///                         infoBaseCS =
///                         [
///                             new S5001InfoBaseCS()
///                             {
///                                 ind13 = 0,
///                                 tpValor = 11,
///                                 valor = 2000.00m
///                             }
///                         ],
///                         calcTerc =
///                         [
///                             new S5001CalcTerc()
///                             {
///                                 tpCR = "121802",
///                                 vrCsSegTerc = 30.00m,
///                                 vrDescTerc = 30.00m
///                             }
///                         ],
///                         infoPerRef =
///                         [
///                             new S5001InfoPerRef()
///                             {
///                                 perRef = "2025-01",
///                                 ideADC =
///                                 [
///                                     new S5001IdeADC()
///                                     {
///                                         dtAcConv = new DateTime(2025, 1, 15),
///                                         tpAcConv = TipoAcordoColetivo.AcordoColetivoTrabalho,
///                                         dsc = "Acordo coletivo",
///                                         remunSuc = SimNaoString.Nao
///                                     }
///                                 ],
///                                 detInfoPerRef =
///                                 [
///                                     new S5001DetInfoPerRef()
///                                     {
///                                         ind13 = 0,
///                                         tpVrPerRef = 11,
///                                         vrPerRef = 500.00m
///                                     }
///                                 ]
///                             }
///                         ]
///                     }
///                 ]
///             }
///         ]
///     },
///     infoPisPasep = new S5001InfoPisPasep()
///     {
///         ideEstab =
///         [
///             new S5001IdeEstabPisPasep()
///             {
///                 tpInsc = PersonalidadeJuridica.CNPJ,
///                 nrInsc = "34785515000166",
///                 infoCategPisPasep =
///                 [
///                     new S5001InfoCategPisPasep()
///                     {
///                         matricula = "MAT123",
///                         codCateg = "101",
///                         infoBasePisPasep =
///                         [
///                             new S5001InfoBasePisPasep()
///                             {
///                                 ind13 = 0,
///                                 tpValorPisPasep = 11,
///                                 valorPisPasep = 2000.00m
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
public partial class S5001 : Evento
{
    private S5001EvtBasesTrab evtBasesTrabField;
    private SignatureType signatureField;

    public S5001()
    {
        evtBasesTrabField = new S5001EvtBasesTrab();
    }

    [XmlElement()]
    public S5001EvtBasesTrab evtBasesTrab
    {
        get => evtBasesTrabField;
        set
        {
            evtBasesTrabField = value;
            RaisePropertyChanged(nameof(evtBasesTrab));
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
        => evtBasesTrabField.Id = string.Format("ID{0}{1}{2}",
            (int)(evtBasesTrabField?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ),
            evtBasesTrabField?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000",
            eSocialTimeStampUtils.GetTimeStampIDForEvent());

    /// <exclude/>
    public override string ContribuinteCNPJ()
        => evtBasesTrabField.ideEmpregador.nrInsc;

    // --- Membros da interface IXmlSignableDocument ---

    /// <exclude/>
    public override string TagToSign => Evento.root;

    /// <exclude/>
    public override string TagId => nameof(evtBasesTrab);

    /// <exclude/>
    public override bool EmptyURI => true;

    /// <exclude/>
    public override bool SignAsSHA256 => true;
}

/// <exclude />
public partial class S5001EvtBasesTrab : ESocialBindableObject
{
    private S5001IdeEvento ideEventoField;
    private Empregador ideEmpregadorField;
    private S5001IdeTrabalhador ideTrabalhadorField;
    private List<S5001InfoCpCalc> infoCpCalcField;
    private S5001InfoCp infoCpField;
    private S5001InfoPisPasep infoPisPasepField;
    private string idField;

    public S5001IdeEvento ideEvento
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

    public S5001IdeTrabalhador ideTrabalhador
    {
        get => ideTrabalhadorField;
        set
        {
            ideTrabalhadorField = value;
            RaisePropertyChanged(nameof(ideTrabalhador));
        }
    }

    [XmlElement("infoCpCalc")]
    public List<S5001InfoCpCalc> infoCpCalc
    {
        get => infoCpCalcField;
        set
        {
            infoCpCalcField = value;
            RaisePropertyChanged(nameof(infoCpCalc));
        }
    }

    public S5001InfoCp infoCp
    {
        get => infoCpField;
        set
        {
            infoCpField = value;
            RaisePropertyChanged(nameof(infoCp));
        }
    }

    public S5001InfoPisPasep infoPisPasep
    {
        get => infoPisPasepField;
        set
        {
            infoPisPasepField = value;
            RaisePropertyChanged(nameof(infoPisPasep));
        }
    }

    public bool ShouldSerializeinfoPisPasep()
        => infoPisPasep != null;

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
public partial class S5001IdeEvento : ESocialBindableObject
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
public partial class S5001IdeTrabalhador : ESocialBindableObject
{
    private string cpfTrabField;
    private S5001InfoCompl infoComplField;
    private List<S5001ProcJudTrab> procJudTrabField;

    public string cpfTrab
    {
        get => cpfTrabField;
        set
        {
            cpfTrabField = value;
            RaisePropertyChanged(nameof(cpfTrab));
        }
    }

    public S5001InfoCompl infoCompl
    {
        get => infoComplField;
        set
        {
            infoComplField = value;
            RaisePropertyChanged(nameof(infoCompl));
        }
    }

    [XmlElement("procJudTrab")]
    public List<S5001ProcJudTrab> procJudTrab
    {
        get => procJudTrabField;
        set
        {
            procJudTrabField = value;
            RaisePropertyChanged(nameof(procJudTrab));
        }
    }
}

/// <exclude />
public partial class S5001InfoCompl : ESocialBindableObject
{
    private S5001SucessaoVinc sucessaoVincField;
    private List<S5001InfoInterm> infoIntermField;
    private List<S5001InfoComplCont> infoComplContField;

    public S5001SucessaoVinc sucessaoVinc
    {
        get => sucessaoVincField;
        set
        {
            sucessaoVincField = value;
            RaisePropertyChanged(nameof(sucessaoVinc));
        }
    }

    [XmlElement("infoInterm")]
    public List<S5001InfoInterm> infoInterm
    {
        get => infoIntermField;
        set
        {
            infoIntermField = value;
            RaisePropertyChanged(nameof(infoInterm));
        }
    }

    [XmlElement("infoComplCont")]
    public List<S5001InfoComplCont> infoComplCont
    {
        get => infoComplContField;
        set
        {
            infoComplContField = value;
            RaisePropertyChanged(nameof(infoComplCont));
        }
    }
}

/// <exclude />
public partial class S5001SucessaoVinc : ESocialBindableObject
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
public partial class S5001InfoInterm : ESocialBindableObject
{
    private byte diaField;
    private string hrsTrabField;

    public byte dia
    {
        get => diaField;
        set
        {
            diaField = value;
            RaisePropertyChanged(nameof(dia));
        }
    }

    public string hrsTrab
    {
        get => hrsTrabField;
        set
        {
            hrsTrabField = value;
            RaisePropertyChanged(nameof(hrsTrab));
        }
    }

    public bool ShouldSerializehrsTrab()
        => !string.IsNullOrEmpty(hrsTrab);
}

/// <exclude />
public partial class S5001InfoComplCont : ESocialBindableObject
{
    private string codCBOField;
    private NaturezaAtividade? natAtividadeField;
    private byte? qtdDiasTrabField;

    public string codCBO
    {
        get => codCBOField;
        set
        {
            codCBOField = value;
            RaisePropertyChanged(nameof(codCBO));
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

    public byte? qtdDiasTrab
    {
        get => qtdDiasTrabField;
        set
        {
            qtdDiasTrabField = value;
            RaisePropertyChanged(nameof(qtdDiasTrab));
        }
    }

    public bool ShouldSerializeqtdDiasTrab()
        => qtdDiasTrab.HasValue;
}

/// <exclude />
public partial class S5001ProcJudTrab : ESocialBindableObject
{
    private string nrProcJudField;
    private string codSuspField;

    public string nrProcJud
    {
        get => nrProcJudField;
        set
        {
            nrProcJudField = value;
            RaisePropertyChanged(nameof(nrProcJud));
        }
    }

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

/// <exclude />
public partial class S5001InfoCpCalc : ESocialBindableObject
{
    private string tpCRField;
    private decimal vrCpSegField;
    private decimal vrDescSegField;

    public string tpCR
    {
        get => tpCRField;
        set
        {
            tpCRField = value;
            RaisePropertyChanged(nameof(tpCR));
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

    public decimal vrDescSeg
    {
        get => vrDescSegField;
        set
        {
            vrDescSegField = value;
            RaisePropertyChanged(nameof(vrDescSeg));
        }
    }
}

/// <exclude />
public partial class S5001InfoCp : ESocialBindableObject
{
    private string classTribField;
    private List<S5001IdeEstabLot> ideEstabLotField;

    public string classTrib
    {
        get => classTribField;
        set
        {
            classTribField = value;
            RaisePropertyChanged(nameof(classTrib));
        }
    }

    [XmlElement("ideEstabLot")]
    public List<S5001IdeEstabLot> ideEstabLot
    {
        get => ideEstabLotField;
        set
        {
            ideEstabLotField = value;
            RaisePropertyChanged(nameof(ideEstabLot));
        }
    }
}

/// <exclude />
public partial class S5001IdeEstabLot : ESocialBindableObject
{
    private PersonalidadeJuridica tpInscField;
    private string nrInscField;
    private string codLotacaoField;
    private List<S5001InfoCategIncid> infoCategIncidField;

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

    public string codLotacao
    {
        get => codLotacaoField;
        set
        {
            codLotacaoField = value;
            RaisePropertyChanged(nameof(codLotacao));
        }
    }

    [XmlElement("infoCategIncid")]
    public List<S5001InfoCategIncid> infoCategIncid
    {
        get => infoCategIncidField;
        set
        {
            infoCategIncidField = value;
            RaisePropertyChanged(nameof(infoCategIncid));
        }
    }
}

/// <exclude />
public partial class S5001InfoCategIncid : ESocialBindableObject
{
    private string matriculaField;
    private string codCategField;
    private IndicadorSubstSimples? indSimplesField;
    private List<S5001InfoBaseCS> infoBaseCSField;
    private List<S5001CalcTerc> calcTercField;
    private List<S5001InfoPerRef> infoPerRefField;

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

    public IndicadorSubstSimples? indSimples
    {
        get => indSimplesField;
        set
        {
            indSimplesField = value;
            RaisePropertyChanged(nameof(indSimples));
        }
    }

    public bool ShouldSerializeindSimples()
        => indSimples.HasValue;

    [XmlElement("infoBaseCS")]
    public List<S5001InfoBaseCS> infoBaseCS
    {
        get => infoBaseCSField;
        set
        {
            infoBaseCSField = value;
            RaisePropertyChanged(nameof(infoBaseCS));
        }
    }

    [XmlElement("calcTerc")]
    public List<S5001CalcTerc> calcTerc
    {
        get => calcTercField;
        set
        {
            calcTercField = value;
            RaisePropertyChanged(nameof(calcTerc));
        }
    }

    [XmlElement("infoPerRef")]
    public List<S5001InfoPerRef> infoPerRef
    {
        get => infoPerRefField;
        set
        {
            infoPerRefField = value;
            RaisePropertyChanged(nameof(infoPerRef));
        }
    }
}

/// <exclude />
public partial class S5001InfoBaseCS : ESocialBindableObject
{
    private byte ind13Field;
    private byte tpValorField;
    private decimal valorField;

    public byte ind13
    {
        get => ind13Field;
        set
        {
            ind13Field = value;
            RaisePropertyChanged(nameof(ind13));
        }
    }

    public byte tpValor
    {
        get => tpValorField;
        set
        {
            tpValorField = value;
            RaisePropertyChanged(nameof(tpValor));
        }
    }

    public decimal valor
    {
        get => valorField;
        set
        {
            valorField = value;
            RaisePropertyChanged(nameof(valor));
        }
    }
}

/// <exclude />
public partial class S5001CalcTerc : ESocialBindableObject
{
    private string tpCRField;
    private decimal vrCsSegTercField;
    private decimal vrDescTercField;

    public string tpCR
    {
        get => tpCRField;
        set
        {
            tpCRField = value;
            RaisePropertyChanged(nameof(tpCR));
        }
    }

    public decimal vrCsSegTerc
    {
        get => vrCsSegTercField;
        set
        {
            vrCsSegTercField = value;
            RaisePropertyChanged(nameof(vrCsSegTerc));
        }
    }

    public decimal vrDescTerc
    {
        get => vrDescTercField;
        set
        {
            vrDescTercField = value;
            RaisePropertyChanged(nameof(vrDescTerc));
        }
    }
}

/// <exclude />
public partial class S5001InfoPerRef : ESocialBindableObject
{
    private string perRefField;
    private List<S5001IdeADC> ideADCField;
    private List<S5001DetInfoPerRef> detInfoPerRefField;

    public string perRef
    {
        get => perRefField;
        set
        {
            perRefField = value;
            RaisePropertyChanged(nameof(perRef));
        }
    }

    [XmlElement("ideADC")]
    public List<S5001IdeADC> ideADC
    {
        get => ideADCField;
        set
        {
            ideADCField = value;
            RaisePropertyChanged(nameof(ideADC));
        }
    }

    [XmlElement("detInfoPerRef")]
    public List<S5001DetInfoPerRef> detInfoPerRef
    {
        get => detInfoPerRefField;
        set
        {
            detInfoPerRefField = value;
            RaisePropertyChanged(nameof(detInfoPerRef));
        }
    }
}

/// <exclude />
public partial class S5001IdeADC : ESocialBindableObject
{
    private DateTime? dtAcConvField;
    private TipoAcordoColetivo tpAcConvField;
    private string dscField;
    private SimNaoString? remunSucField;

    [XmlElement(DataType = "date")]
    public DateTime? dtAcConv
    {
        get => dtAcConvField;
        set
        {
            dtAcConvField = value;
            RaisePropertyChanged(nameof(dtAcConv));
        }
    }

    public bool ShouldSerializedtAcConv()
        => dtAcConv.HasValue;

    public TipoAcordoColetivo tpAcConv
    {
        get => tpAcConvField;
        set
        {
            tpAcConvField = value;
            RaisePropertyChanged(nameof(tpAcConv));
        }
    }

    public string dsc
    {
        get => dscField;
        set
        {
            dscField = value;
            RaisePropertyChanged(nameof(dsc));
        }
    }

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
}

/// <exclude />
public partial class S5001DetInfoPerRef : ESocialBindableObject
{
    private byte ind13Field;
    private byte tpVrPerRefField;
    private decimal vrPerRefField;

    public byte ind13
    {
        get => ind13Field;
        set
        {
            ind13Field = value;
            RaisePropertyChanged(nameof(ind13));
        }
    }

    public byte tpVrPerRef
    {
        get => tpVrPerRefField;
        set
        {
            tpVrPerRefField = value;
            RaisePropertyChanged(nameof(tpVrPerRef));
        }
    }

    public decimal vrPerRef
    {
        get => vrPerRefField;
        set
        {
            vrPerRefField = value;
            RaisePropertyChanged(nameof(vrPerRef));
        }
    }
}

/// <exclude />
public partial class S5001InfoPisPasep : ESocialBindableObject
{
    private List<S5001IdeEstabPisPasep> ideEstabField;

    [XmlElement("ideEstab")]
    public List<S5001IdeEstabPisPasep> ideEstab
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
public partial class S5001IdeEstabPisPasep : ESocialBindableObject
{
    private PersonalidadeJuridica tpInscField;
    private string nrInscField;
    private List<S5001InfoCategPisPasep> infoCategPisPasepField;

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

    [XmlElement("infoCategPisPasep")]
    public List<S5001InfoCategPisPasep> infoCategPisPasep
    {
        get => infoCategPisPasepField;
        set
        {
            infoCategPisPasepField = value;
            RaisePropertyChanged(nameof(infoCategPisPasep));
        }
    }
}

/// <exclude />
public partial class S5001InfoCategPisPasep : ESocialBindableObject
{
    private string matriculaField;
    private string codCategField;
    private List<S5001InfoBasePisPasep> infoBasePisPasepField;

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

    [XmlElement("infoBasePisPasep")]
    public List<S5001InfoBasePisPasep> infoBasePisPasep
    {
        get => infoBasePisPasepField;
        set
        {
            infoBasePisPasepField = value;
            RaisePropertyChanged(nameof(infoBasePisPasep));
        }
    }
}

/// <exclude />
public partial class S5001InfoBasePisPasep : ESocialBindableObject
{
    private byte ind13Field;
    private byte tpValorPisPasepField;
    private decimal valorPisPasepField;

    public byte ind13
    {
        get => ind13Field;
        set
        {
            ind13Field = value;
            RaisePropertyChanged(nameof(ind13));
        }
    }

    public byte tpValorPisPasep
    {
        get => tpValorPisPasepField;
        set
        {
            tpValorPisPasepField = value;
            RaisePropertyChanged(nameof(tpValorPisPasep));
        }
    }

    public decimal valorPisPasep
    {
        get => valorPisPasepField;
        set
        {
            valorPisPasepField = value;
            RaisePropertyChanged(nameof(valorPisPasep));
        }
    }
}
