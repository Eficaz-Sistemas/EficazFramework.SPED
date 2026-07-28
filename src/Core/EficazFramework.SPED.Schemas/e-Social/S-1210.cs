using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace EficazFramework.SPED.Schemas.eSocial;

/// <summary>
/// Pagamentos de Rendimentos do Trabalho
/// </summary>
/// <example>
/// ```csharp
///  evento.evtPgtos = new S1210EvtPgtos()
///  {
///      ideEvento = new IdeEventoFolhaMensal()
///      {
///          indRetif = IndicadorRetificacao.Original,
///          tpAmb = Ambiente.ProducaoRestrita_DadosReais,
///          procEmi = EmissorEvento.AppEmpregador,
///          perApur = "2025-02",
///          verProc = "2.2"
///      },
///      ideEmpregador = new Empregador()
///      {
///          tpInsc = PersonalidadeJuridica.CNPJ,
///          nrInsc = "12345678"
///      },
///      ideBenef = new S1210IdeBenef()
///      {
///          cpfBenef = "15273627877",
///          infoPgto =
///          [
///              new S1210InfoPgto()
///              {
///                  dtPgto = new DateTime(2025, 2, 28),
///                  tpPgto = TipoPagamento.RemuneracaoS1200,
///                  perRef = "2025-02",
///                  ideDmDev = "022025MENSAL14022025155159",
///                  vrLiq = 1351.02m,
///                  paisResidExt = "031",
///                  infoPgtoExt = new()
///                  {
///                      indNIF = IndicadorNIF.PossuiNIF,
///                      nifBenef = "123",
///                      frmTribut = "40",
///                      endExt = new()
///                      {
///                          endDscLograd = "1243 Street",
///                          endNrLograd = "123",
///                          endComplem = "não há",
///                          endBairro = "Center",
///                          endCidade = "??",
///                          endEstado = "??",
///                          endCodPostal = "1A",
///                          telef = "3535441234"
///                      }
///                  }
///              }
///          ],
///          infoIRComplem = 
///          [
///              new S1210InfoIRComplem()
///              {
///                  dtLaudo = new DateTime(2025, 2, 28),
///                  perAnt = new()
///                  {
///                      perRefAjuste = "2025-02",
///                      nrRec1210Orig = "1.5.1234567890123456789"
///                  },
///                  infoDep =
///                  [
///                      new S1210InfoDep()
///                      {
///                          cpfDep = "15273627877",
///                          dtNascto = new DateTime(2020, 1, 1),
///                          nome = "Filho",
///                          depIRRF = SimNaoString.Sim,
///                          tpDep = "03",
///                          descrDep = "filho",
///                      }
///                  ],
///                  infoIRCR = 
///                  [
///                      new S1210InfoIRCR()
///                      {
///                          tpCR = "056107",
///                          dedDepen =
///                          [
///                              new S1210DedDepen()
///                              {
///                                  tpRend = "11",
///                                  cpfDep = "15273627877",
///                                  vlrDedDep = 125.45m
///                              }
///                          ],
///                          penAlim =
///                          [
///                              new S1210PenAlim()
///                              {
///                                  tpRend = "11",
///                                  cpfDep = "15273627877",
///                                  vlrDedPenAlim = 5200.00m
///                              }
///                          ],
///                          previdCompl = 
///                          [
///                              new S1210PrevidCompl()
///                              {
///                                  tpPrev = TipoPrevidenciaComplementar.EntidadeFechada,
///                                  cnpjEntidPC = "12456789000100",
///                                  vlrDedPC = 100.58m,
///                                  vlrDedPC13 = 1.99m,
///                                  vlrPatrocFunp = 2.98m,
///                                  vlrPatrocFunp13 = 1.98m
///                              }
///                          ],
///                          infoProcRet =
///                          [
///                              new S1210InfoProcRet()
///                              {
///                                  tpRend = "2",
///                                  nrProc = "12345678901234567890",
///                                  codSusp = "123456",
///                                  infoValores =
///                                  [
///                                      new S1210InfoValores()
///                                      {
///                                          indApuracao = IndicadorApuracao.Mensal,
///                                          vlrNRetido = 12.34m,
///                                          vlrDepJud = 56.78m,
///                                          vlrCmpAnoCal = 90.12m,
///                                          vlrCmpAnoAnt = 34.56m,
///                                          vlrRendSusp = 78.90m,
///                                          dedSusp = 
///                                          [
///                                              new S1210DedSusp()
///                                              {
///                                                  tpDed = "7",
///                                                  vlrDedSusp = 67.89m,
///                                                  cnpjEntidPC = "12456789000100",
///                                                  benefPen = 
///                                                  [
///                                                      new S1210BenefPen()
///                                                      {
///                                                          cpfDep = "15273627877",
///                                                          vlrDepenSusp = 67.89m
///                                                      }
///                                                  ]
///                                              }
///                                          ]
///                                      }
///                                  ]
///                              }
///                          ]
///                      }
///                  ]
///              }
///          ]
///      }
///  };
/// ```
/// </example>
[Serializable()]
public partial class S1210 : Evento
{
    private S1210EvtPgtos evtPgtosField;
    private SignatureType signatureField;

    public S1210EvtPgtos evtPgtos
    {
        get => evtPgtosField;
        set
        {
            evtPgtosField = value;
            RaisePropertyChanged(nameof(evtPgtos));
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
        => evtPgtosField.Id = string.Format("ID{0}{1}{2}",
            (int)(evtPgtosField?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ),
            evtPgtosField?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000",
            eSocialTimeStampUtils.GetTimeStampIDForEvent());

    /// <exclude/>
    public override string ContribuinteCNPJ()
        => evtPgtosField.ideEmpregador.nrInsc;

    // --- Membros da interface IXmlSignableDocument ---

    /// <exclude/>
    public override string TagToSign => Evento.root;

    /// <exclude/>
    public override string TagId => nameof(evtPgtos);

    /// <exclude/>
    public override bool EmptyURI => true;

    /// <exclude/>
    public override bool SignAsSHA256 => true;
}

/// <exclude />
public partial class S1210EvtPgtos : ESocialBindableObject
{
    private IdeEventoFolhaMensal ideEventoField;
    private Empregador ideEmpregadorField;
    private S1210IdeBenef ideBenefField;
    private string idField;

    public IdeEventoFolhaMensal ideEvento
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

    public S1210IdeBenef ideBenef
    {
        get => ideBenefField;
        set
        {
            ideBenefField = value;
            RaisePropertyChanged(nameof(ideBenef));
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
public partial class IdeEventoFolhaMensal : ESocialBindableObject
{
    private IndicadorRetificacao indRetifField = IndicadorRetificacao.Original;
    private string nrReciboField;
    private string perApurField;
    private IndicadorGuia indGuiaField = IndicadorGuia.DAE;
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

    public string perApur
    {
        get => perApurField;
        set
        {
            perApurField = value;
            RaisePropertyChanged(nameof(perApur));
        }
    }

    public IndicadorGuia indGuia
    {
        get => indGuiaField;
        set
        {
            indGuiaField = value;
            RaisePropertyChanged(nameof(indGuia));
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
public partial class S1210IdeBenef : ESocialBindableObject
{
    private string cpfBenefField;
    private List<S1210InfoPgto> infoPgtoField;
    private List<S1210InfoIRComplem> infoIRComplemField;

    public string cpfBenef
    {
        get => cpfBenefField;
        set
        {
            cpfBenefField = value;
            RaisePropertyChanged(nameof(cpfBenef));
        }
    }

    [XmlElement("infoPgto")]
    public List<S1210InfoPgto> infoPgto
    {
        get => infoPgtoField;
        set
        {
            infoPgtoField = value;
            RaisePropertyChanged(nameof(infoPgto));
        }
    }

    [XmlElement("infoIRComplem")]
    public List<S1210InfoIRComplem> infoIRComplem
    {
        get => infoIRComplemField;
        set
        {
            infoIRComplemField = value;
            RaisePropertyChanged(nameof(infoIRComplem));
        }
    }
}

/// <exclude />
public partial class S1210InfoPgto : ESocialBindableObject
{
    private DateTime dtPgtoField;
    private TipoPagamento tpPgtoField;
    private string perRefField;
    private string ideDmDevField;
    private decimal vrLiqField;
    private string paisResidExtField;
    private S1210InfoPgtoExt infoPgtoExtField;

    [XmlElement(DataType = "date")]
    public DateTime dtPgto
    {
        get => dtPgtoField;
        set
        {
            dtPgtoField = value;
            RaisePropertyChanged(nameof(dtPgto));
        }
    }

    public TipoPagamento tpPgto
    {
        get => tpPgtoField;
        set
        {
            tpPgtoField = value;
            RaisePropertyChanged(nameof(tpPgto));
        }
    }

    public string perRef
    {
        get => perRefField;
        set
        {
            perRefField = value;
            RaisePropertyChanged(nameof(perRef));
        }
    }

    public string ideDmDev
    {
        get => ideDmDevField;
        set
        {
            ideDmDevField = value;
            RaisePropertyChanged(nameof(ideDmDev));
        }
    }

    public decimal vrLiq
    {
        get => vrLiqField;
        set
        {
            vrLiqField = value;
            RaisePropertyChanged(nameof(vrLiq));
        }
    }

    public string paisResidExt
    {
        get => paisResidExtField;
        set
        {
            paisResidExtField = value;
            RaisePropertyChanged(nameof(paisResidExt));
        }
    }

    public S1210InfoPgtoExt infoPgtoExt
    {
        get => infoPgtoExtField;
        set
        {
            infoPgtoExtField = value;
            RaisePropertyChanged(nameof(infoPgtoExt));
        }
    }
}

/// <exclude />
public partial class S1210InfoPgtoExt : ESocialBindableObject
{
    private IndicadorNIF indNIFField;
    private string nifBenefField;
    private string frmTributField;
    private S1210EndExt endExtField;

    public IndicadorNIF indNIF
    {
        get => indNIFField;
        set
        {
            indNIFField = value;
            RaisePropertyChanged(nameof(indNIF));
        }
    }

    public string nifBenef
    {
        get => nifBenefField;
        set
        {
            nifBenefField = value;
            RaisePropertyChanged(nameof(nifBenef));
        }
    }

    public string frmTribut
    {
        get => frmTributField;
        set
        {
            frmTributField = value;
            RaisePropertyChanged(nameof(frmTribut));
        }
    }

    public S1210EndExt endExt
    {
        get => endExtField;
        set
        {
            endExtField = value;
            RaisePropertyChanged(nameof(endExt));
        }
    }
}

/// <exclude />
public partial class S1210EndExt : ESocialBindableObject
{
    private string endDscLogradField;
    private string endNrLogradField;
    private string endComplemField;
    private string endBairroField;
    private string endCidadeField;
    private string endEstadoField;
    private string endCodPostalField;
    private string telefField;

    public string endDscLograd
    {
        get => endDscLogradField;
        set
        {
            endDscLogradField = value;
            RaisePropertyChanged(nameof(endDscLograd));
        }
    }

    public string endNrLograd
    {
        get => endNrLogradField;
        set
        {
            endNrLogradField = value;
            RaisePropertyChanged(nameof(endNrLograd));
        }
    }

    public string endComplem
    {
        get => endComplemField;
        set
        {
            endComplemField = value;
            RaisePropertyChanged(nameof(endComplem));
        }
    }

    public string endBairro
    {
        get => endBairroField;
        set
        {
            endBairroField = value;
            RaisePropertyChanged(nameof(endBairro));
        }
    }

    public string endCidade
    {
        get => endCidadeField;
        set
        {
            endCidadeField = value;
            RaisePropertyChanged(nameof(endCidade));
        }
    }

    public string endEstado
    {
        get => endEstadoField;
        set
        {
            endEstadoField = value;
            RaisePropertyChanged(nameof(endEstado));
        }
    }

    public string endCodPostal
    {
        get => endCodPostalField;
        set
        {
            endCodPostalField = value;
            RaisePropertyChanged(nameof(endCodPostal));
        }
    }

    public string telef
    {
        get => telefField;
        set
        {
            telefField = value;
            RaisePropertyChanged(nameof(telef));
        }
    }
}

/// <exclude />
public partial class S1210InfoIRComplem : ESocialBindableObject
{
    private DateTime? dtLaudoField;
    private S1210PerAnt perAntField;
    private List<S1210InfoDep> infoDepField;
    private List<S1210InfoIRCR> infoIRCRField;

    [XmlElement(DataType = "date")]
    public DateTime? dtLaudo
    {
        get => dtLaudoField;
        set
        {
            dtLaudoField = value;
            RaisePropertyChanged(nameof(dtLaudo));
        }
    }

    public bool ShouldSerializedtLaudo()
        => dtLaudo.HasValue;

    public S1210PerAnt perAnt
    {
        get => perAntField;
        set
        {
            perAntField = value;
            RaisePropertyChanged(nameof(perAnt));
        }
    }

    [XmlElement("infoDep")]
    public List<S1210InfoDep> infoDep
    {
        get => infoDepField;
        set
        {
            infoDepField = value;
            RaisePropertyChanged(nameof(infoDep));
        }
    }

    [XmlElement("infoIRCR")]
    public List<S1210InfoIRCR> infoIRCR
    {
        get => infoIRCRField;
        set
        {
            infoIRCRField = value;
            RaisePropertyChanged(nameof(infoIRCR));
        }
    }
}

/// <exclude />
public partial class S1210PerAnt : ESocialBindableObject
{
    private string perRefAjusteField;
    private string nrRec1210OrigField;

    public string perRefAjuste
    {
        get => perRefAjusteField;
        set
        {
            perRefAjusteField = value;
            RaisePropertyChanged(nameof(perRefAjuste));
        }
    }

    public string nrRec1210Orig
    {
        get => nrRec1210OrigField;
        set
        {
            nrRec1210OrigField = value;
            RaisePropertyChanged(nameof(nrRec1210Orig));
        }
    }
}

/// <exclude />
public partial class S1210InfoDep : ESocialBindableObject
{
    private string cpfDepField;
    private DateTime? dtNasctoField;
    private string nomeField;
    private SimNaoString? depIRRFField;
    private string tpDepField;
    private string descrDepField;

    public string cpfDep
    {
        get => cpfDepField;
        set
        {
            cpfDepField = value;
            RaisePropertyChanged(nameof(cpfDep));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime? dtNascto
    {
        get => dtNasctoField;
        set
        {
            dtNasctoField = value;
            RaisePropertyChanged(nameof(dtNascto));
        }
    }

    public bool ShouldSerializedtNascto()
        => dtNascto.HasValue;

    public string nome
    {
        get => nomeField;
        set
        {
            nomeField = value;
            RaisePropertyChanged(nameof(nome));
        }
    }

    public SimNaoString? depIRRF
    {
        get => depIRRFField;
        set
        {
            depIRRFField = value;
            RaisePropertyChanged(nameof(depIRRF));
        }
    }

    public bool ShouldSerializedepIRRF()
        => depIRRF.HasValue;

    public string tpDep
    {
        get => tpDepField;
        set
        {
            tpDepField = value;
            RaisePropertyChanged(nameof(tpDep));
        }
    }

    public string descrDep
    {
        get => descrDepField;
        set
        {
            descrDepField = value;
            RaisePropertyChanged(nameof(descrDep));
        }
    }
}

/// <exclude />
public partial class S1210InfoIRCR : ESocialBindableObject
{
    private string tpCRField;
    private List<S1210DedDepen> dedDepenField;
    private List<S1210PenAlim> penAlimField;
    private List<S1210PrevidCompl> previdComplField;
    private List<S1210InfoProcRet> infoProcRetField;

    public string tpCR
    {
        get => tpCRField;
        set
        {
            tpCRField = value;
            RaisePropertyChanged(nameof(tpCR));
        }
    }

    [XmlElement("dedDepen")]
    public List<S1210DedDepen> dedDepen
    {
        get => dedDepenField;
        set
        {
            dedDepenField = value;
            RaisePropertyChanged(nameof(dedDepen));
        }
    }

    [XmlElement("penAlim")]
    public List<S1210PenAlim> penAlim
    {
        get => penAlimField;
        set
        {
            penAlimField = value;
            RaisePropertyChanged(nameof(penAlim));
        }
    }

    [XmlElement("previdCompl")]
    public List<S1210PrevidCompl> previdCompl
    {
        get => previdComplField;
        set
        {
            previdComplField = value;
            RaisePropertyChanged(nameof(previdCompl));
        }
    }

    [XmlElement("infoProcRet")]
    public List<S1210InfoProcRet> infoProcRet
    {
        get => infoProcRetField;
        set
        {
            infoProcRetField = value;
            RaisePropertyChanged(nameof(infoProcRet));
        }
    }
}

/// <exclude />
public partial class S1210DedDepen : ESocialBindableObject
{
    private string tpRendField;
    private string cpfDepField;
    private decimal vlrDedDepField;

    public string tpRend
    {
        get => tpRendField;
        set
        {
            tpRendField = value;
            RaisePropertyChanged(nameof(tpRend));
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

    public decimal vlrDedDep
    {
        get => vlrDedDepField;
        set
        {
            vlrDedDepField = value;
            RaisePropertyChanged(nameof(vlrDedDep));
        }
    }
}

/// <exclude />
public partial class S1210PenAlim : ESocialBindableObject
{
    private string tpRendField;
    private string cpfDepField;
    private decimal vlrDedPenAlimField;

    public string tpRend
    {
        get => tpRendField;
        set
        {
            tpRendField = value;
            RaisePropertyChanged(nameof(tpRend));
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

    public decimal vlrDedPenAlim
    {
        get => vlrDedPenAlimField;
        set
        {
            vlrDedPenAlimField = value;
            RaisePropertyChanged(nameof(vlrDedPenAlim));
        }
    }
}

/// <exclude />
public partial class S1210PrevidCompl : ESocialBindableObject
{
    private TipoPrevidenciaComplementar tpPrevField;
    private string cnpjEntidPCField;
    private decimal? vlrDedPCField;
    private decimal? vlrDedPC13Field;
    private decimal? vlrPatrocFunpField;
    private decimal? vlrPatrocFunp13Field;

    public TipoPrevidenciaComplementar tpPrev
    {
        get => tpPrevField;
        set
        {
            tpPrevField = value;
            RaisePropertyChanged(nameof(tpPrev));
        }
    }

    public string cnpjEntidPC
    {
        get => cnpjEntidPCField;
        set
        {
            cnpjEntidPCField = value;
            RaisePropertyChanged(nameof(cnpjEntidPC));
        }
    }

    public decimal? vlrDedPC
    {
        get => vlrDedPCField;
        set
        {
            vlrDedPCField = value;
            RaisePropertyChanged(nameof(vlrDedPC));
        }
    }

    public bool ShouldSerializevlrDedPC()
        => vlrDedPC.HasValue;

    public decimal? vlrDedPC13
    {
        get => vlrDedPC13Field;
        set
        {
            vlrDedPC13Field = value;
            RaisePropertyChanged(nameof(vlrDedPC13));
        }
    }

    public bool ShouldSerializevlrDedPC13()
        => vlrDedPC13.HasValue;

    public decimal? vlrPatrocFunp
    {
        get => vlrPatrocFunpField;
        set
        {
            vlrPatrocFunpField = value;
            RaisePropertyChanged(nameof(vlrPatrocFunp));
        }
    }

    public bool ShouldSerializevlrPatrocFunp()
        => vlrPatrocFunp.HasValue;

    public decimal? vlrPatrocFunp13
    {
        get => vlrPatrocFunp13Field;
        set
        {
            vlrPatrocFunp13Field = value;
            RaisePropertyChanged(nameof(vlrPatrocFunp13));
        }
    }

    public bool ShouldSerializevlrPatrocFunp13()
        => vlrPatrocFunp13.HasValue;
}

/// <exclude />
public partial class S1210InfoProcRet : ESocialBindableObject
{
    private string tpRendField;
    private string nrProcField;
    private string codSuspField;
    private List<S1210InfoValores> infoValoresField;

    [XmlElement("tpProcRet")]
    public string tpRend
    {
        get => tpRendField;
        set
        {
            tpRendField = value;
            RaisePropertyChanged(nameof(tpRend));
        }
    }

    [XmlElement("nrProcRet")]
    public string nrProc
    {
        get => nrProcField;
        set
        {
            nrProcField = value;
            RaisePropertyChanged(nameof(nrProc));
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

    [XmlElement("infoValores")]
    public List<S1210InfoValores> infoValores
    {
        get => infoValoresField;
        set
        {
            infoValoresField = value;
            RaisePropertyChanged(nameof(infoValores));
        }
    }
}

/// <exclude />
public partial class S1210InfoValores : ESocialBindableObject
{
    private IndicadorApuracao indApuracaoField;
    private decimal? vlrNRetidoField;
    private decimal? vlrDepJudField;
    private decimal? vlrCmpAnoCalField;
    private decimal? vlrCmpAnoAntField;
    private decimal? vlrRendSuspField;
    private List<S1210DedSusp> dedSuspField;

    public IndicadorApuracao indApuracao
    {
        get => indApuracaoField;
        set
        {
            indApuracaoField = value;
            RaisePropertyChanged(nameof(indApuracao));
        }
    }

    public decimal? vlrNRetido
    {
        get => vlrNRetidoField;
        set
        {
            vlrNRetidoField = value;
            RaisePropertyChanged(nameof(vlrNRetido));
        }
    }

    public bool ShouldSerializevlrNRetido()
        => vlrNRetido.HasValue;

    public decimal? vlrDepJud
    {
        get => vlrDepJudField;
        set
        {
            vlrDepJudField = value;
            RaisePropertyChanged(nameof(vlrDepJud));
        }
    }

    public bool ShouldSerializevlrDepJud()
        => vlrDepJud.HasValue;

    public decimal? vlrCmpAnoCal
    {
        get => vlrCmpAnoCalField;
        set
        {
            vlrCmpAnoCalField = value;
            RaisePropertyChanged(nameof(vlrCmpAnoCal));
        }
    }

    public bool ShouldSerializevlrCmpAnoCal()
        => vlrCmpAnoCal.HasValue;

    public decimal? vlrCmpAnoAnt
    {
        get => vlrCmpAnoAntField;
        set
        {
            vlrCmpAnoAntField = value;
            RaisePropertyChanged(nameof(vlrCmpAnoAnt));
        }
    }

    public bool ShouldSerializevlrCmpAnoAnt()
        => vlrCmpAnoAnt.HasValue;

    [XmlElement("vlrRendSusp")]
    public decimal? vlrRendSusp
    {
        get => vlrRendSuspField;
        set
        {
            vlrRendSuspField = value;
            RaisePropertyChanged(nameof(vlrRendSusp));
        }
    }

    public bool ShouldSerializevlrRendSusp()
        => vlrRendSusp.HasValue;

    [XmlElement("dedSusp")]
    public List<S1210DedSusp> dedSusp
    {
        get => dedSuspField;
        set
        {
            dedSuspField = value;
            RaisePropertyChanged(nameof(dedSusp));
        }
    }
}

/// <exclude />
public partial class S1210DedSusp : ESocialBindableObject
{
    private string tpDedField;
    private decimal? vlrDedSuspField;
    private string cnpjEntidPCField;
    private List<S1210BenefPen> benefPenField;

    [XmlElement("indTpDeducao")]
    public string tpDed
    {
        get => tpDedField;
        set
        {
            tpDedField = value;
            RaisePropertyChanged(nameof(tpDed));
        }
    }

    public decimal? vlrDedSusp
    {
        get => vlrDedSuspField;
        set
        {
            vlrDedSuspField = value;
            RaisePropertyChanged(nameof(vlrDedSusp));
        }
    }

    public bool ShouldSerializevlrDedSusp()
        => vlrDedSusp.HasValue;

    public string cnpjEntidPC
    {
        get => cnpjEntidPCField;
        set
        {
            cnpjEntidPCField = value;
            RaisePropertyChanged(nameof(cnpjEntidPC));
        }
    }

    [XmlElement("benefPen")]
    public List<S1210BenefPen> benefPen
    {
        get => benefPenField;
        set
        {
            benefPenField = value;
            RaisePropertyChanged(nameof(benefPen));
        }
    }
}

/// <exclude />
public partial class S1210BenefPen : ESocialBindableObject
{
    private string cpfDepField;
    private decimal vlrDepenSuspField;

    public string cpfDep
    {
        get => cpfDepField;
        set
        {
            cpfDepField = value;
            RaisePropertyChanged(nameof(cpfDep));
        }
    }

    public decimal vlrDepenSusp
    {
        get => vlrDepenSuspField;
        set
        {
            vlrDepenSuspField = value;
            RaisePropertyChanged(nameof(vlrDepenSusp));
        }
    }
}
