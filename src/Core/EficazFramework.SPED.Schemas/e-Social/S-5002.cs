using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace EficazFramework.SPED.Schemas.eSocial;

/// <summary>
/// S-5002 - Imposto de Renda Retido na Fonte por Trabalhador
/// </summary>
/// <example>
/// ```csharp
/// evento.Versao = Versao.v_S_01_03_00;
/// evento.evtIrrfBenef = new S5002EvtIrrfBenef()
/// {
///     ideEvento = new S5002IdeEvento()
///     {
///         nrRecArqBase = "1.1.0000000000000000000",
///         perApur = "2025-02"
///     },
///     ideEmpregador = new Empregador()
///     {
///         tpInsc = PersonalidadeJuridica.CNPJ,
///         nrInsc = "34785515000166"
///     },
///     ideTrabalhador = new S5002IdeTrabalhador()
///     {
///         cpfBenef = "12345678901",
///         dmDev =
///         [
///             new S5002DmDev()
///             {
///                 perRef = "2025-02",
///                 ideDmDev = "DEMO001",
///                 tpPgto = TipoPagamento.RemuneracaoS1200,
///                 dtPgto = new DateTime(2025, 2, 28),
///                 codCateg = "101",
///                 infoIR =
///                 [
///                     new S5002InfoIR()
///                     {
///                         tpInfoIR = "11",
///                         valor = 3500.00m,
///                         descRendimento = "Salário Base",
///                         infoProcJudRub =
///                         [
///                             new S5002InfoProcJudRub()
///                             {
///                                 nrProc = "12345678901234567890",
///                                 ufVara = UFCadastro.SP,
///                                 codMunic = "3550308",
///                                 idVara = 1
///                             }
///                         ]
///                     }
///                 ],
///                 totApurMen =
///                 [
///                     new S5002TotApurMen()
///                     {
///                         CRMen = "056107",
///                         vlrRendTrib = 3500.00m,
///                         vlrPrevOficial = 385.00m,
///                         vlrCRMen = 120.00m,
///                         descRendimento = "Demais Isenções"
///                     }
///                 ],
///                 totApurDia =
///                 [
///                     new S5002TotApurDia()
///                     {
///                         perApurDia = 28,
///                         CRDia = "047301",
///                         frmTribut = "01",
///                         paisResidExt = "105",
///                         vlrPagoDia = 3500.00m,
///                         vlrCRDia = 120.00m
///                     }
///                 ],
///                 infoRRA = new S5002InfoRRA()
///                 {
///                     tpProcRRA = TipoProcesso.Judicial,
///                     nrProcRRA = "00012345620255010001",
///                     descRRA = "Processo RRA",
///                     qtdMesesRRA = 12.0m,
///                     despProcJud = new S5002DespProcJud()
///                     {
///                         vlrDespCustas = 100.00m,
///                         vlrDespAdvogados = 500.00m
///                     },
///                     ideAdv =
///                     [
///                         new S5002IdeAdv()
///                         {
///                             tpInsc = PersonalidadeJuridica.CPF,
///                             nrInsc = "98765432100",
///                             vlrAdv = 500.00m
///                         }
///                     ]
///                 },
///                 infoPgtoExt = new S5002InfoPgtoExt()
///                 {
///                     paisResidExt = "105",
///                     indNIF = IndicadorNIF.PossuiNIF,
///                     nifBenef = "NIF12345",
///                     frmTribut = "01",
///                     endExt = new S5002EndExt()
///                     {
///                         endDscLograd = "Main Street",
///                         endNrLograd = "100",
///                         endComplem = "Apt 2",
///                         endBairro = "Downtown",
///                         endCidade = "New York",
///                         endEstado = "NY",
///                         endCodPostal = "10001",
///                         telef = "11999998888"
///                     }
///                 }
///             }
///         ],
///         totInfoIR = new S5002TotInfoIR()
///         {
///             consolidApurMen =
///             [
///                 new S5002ConsolidApurMen()
///                 {
///                     CRMen = "056107",
///                     vlrRendTrib = 3500.00m,
///                     vlrPrevOficial = 385.00m,
///                     vlrCRMen = 120.00m,
///                     descRendimento = "Totais Consolidados"
///                 }
///             ]
///         },
///         infoIRComplem =
///         [
///             new S5002InfoIRComplem()
///             {
///                 dtLaudo = new DateTime(2024, 1, 1),
///                 perAnt = new S5002PerAnt()
///                 {
///                     perRefAjuste = "2024-12",
///                     nrRec1210Orig = "1.1.0000000000000000001"
///                 },
///                 ideDep =
///                 [
///                     new S5002IdeDep()
///                     {
///                         cpfDep = "98765432100",
///                         depIRRF = SimNaoString.Sim,
///                         dtNascto = new DateTime(2015, 5, 20),
///                         nome = "Filho Exemplo",
///                         tpDep = "01",
///                         descrDep = "Filho"
///                     }
///                 ],
///                 infoIRCR =
///                 [
///                     new S5002InfoIRCR()
///                     {
///                         tpCR = "056107",
///                         dedDepen =
///                         [
///                             new S5002DedDepen()
///                             {
///                                 tpRend = TipoRendimentoDependente.RemuneracaoMensal,
///                                 cpfDep = "98765432100",
///                                 vlrDedDep = 189.59m
///                             }
///                         ],
///                         penAlim =
///                         [
///                             new S5002PenAlim()
///                             {
///                                 tpRend = TipoRendimentoPensaoAlimenticia.RemuneracaoMensal,
///                                 cpfDep = "98765432100",
///                                 vlrDedPenAlim = 300.00m
///                             }
///                         ],
///                         previdCompl =
///                         [
///                             new S5002PrevidCompl()
///                             {
///                                 tpPrev = TipoPrevidenciaComplementar.SociedadeAberta,
///                                 cnpjEntidPC = "12345678000195",
///                                 vlrDedPC = 200.00m
///                             }
///                         ],
///                         infoProcRet =
///                         [
///                             new S5002InfoProcRet()
///                             {
///                                 tpProcRet = TipoProcesso.Judicial,
///                                 nrProcRet = "12345678901234567890",
///                                 codSusp = "123456",
///                                 infoValores =
///                                 [
///                                     new S5002InfoValores()
///                                     {
///                                         indApuracao = IndicadorApuracao.Mensal,
///                                         vlrNRetido = 50.00m,
///                                         vlrDepJud = 50.00m,
///                                         dedSusp =
///                                         [
///                                             new S5002DedSusp()
///                                             {
///                                                 indTpDeducao = IndicadorTipoDeducao.PrevidenciaOficial,
///                                                 vlrDedSusp = 50.00m,
///                                                 cnpjEntidPC = "12345678000195",
///                                                 benefPen =
///                                                 [
///                                                     new S5002BenefPen()
///                                                     {
///                                                         cpfDep = "98765432100",
///                                                         vlrDepenSusp = 50.00m
///                                                     }
///                                                 ]
///                                             }
///                                         ]
///                                     }
///                                 ]
///                             }
///                         ]
///                     }
///                 ],
///                 planSaude =
///                 [
///                     new S5002PlanSaude()
///                     {
///                         cnpjOper = "12345678000195",
///                         regANS = "123456",
///                         vlrSaudeTit = 250.00m,
///                         infoDepSau =
///                         [
///                             new S5002InfoDepSau()
///                             {
///                                 cpfDep = "98765432100",
///                                 vlrSaudeDep = 150.00m
///                             }
///                         ]
///                     }
///                 ],
///                 infoReembMed =
///                 [
///                     new S5002InfoReembMed()
///                     {
///                         indOrgReemb = IndicadorOrigemReembolso.PlanoSaude,
///                         cnpjOper = "12345678000195",
///                         regANS = "123456",
///                         detReembTit =
///                         [
///                             new S5002DetReemb()
///                             {
///                                 tpInsc = PersonalidadeJuridica.CNPJ,
///                                 nrInsc = "12345678000195",
///                                 vlrReemb = 100.00m
///                             }
///                         ],
///                         infoReembDep =
///                         [
///                             new S5002InfoReembDep()
///                             {
///                                 cpfBenef = "98765432100",
///                                 detReembDep =
///                                 [
///                                     new S5002DetReemb()
///                                     {
///                                         tpInsc = PersonalidadeJuridica.CNPJ,
///                                         nrInsc = "12345678000195",
///                                         vlrReemb = 50.00m
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
public partial class S5002 : Evento
{
    private S5002EvtIrrfBenef evtIrrfBenefField;
    private SignatureType signatureField;

    public S5002()
    {
        evtIrrfBenefField = new S5002EvtIrrfBenef();
    }

    [XmlElement()]
    public S5002EvtIrrfBenef evtIrrfBenef
    {
        get => evtIrrfBenefField;
        set
        {
            evtIrrfBenefField = value;
            RaisePropertyChanged(nameof(evtIrrfBenef));
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
        => evtIrrfBenefField.Id = string.Format("ID{0}{1}{2}",
            (int)(evtIrrfBenefField?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ),
            evtIrrfBenefField?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000",
            eSocialTimeStampUtils.GetTimeStampIDForEvent());

    /// <exclude/>
    public override string ContribuinteCNPJ()
        => evtIrrfBenefField.ideEmpregador.nrInsc;

    // --- Membros da interface IXmlSignableDocument ---

    /// <exclude/>
    public override string TagToSign => Evento.root;

    /// <exclude/>
    public override string TagId => nameof(evtIrrfBenef);

    /// <exclude/>
    public override bool EmptyURI => true;

    /// <exclude/>
    public override bool SignAsSHA256 => true;
}

/// <exclude />
public partial class S5002EvtIrrfBenef : ESocialBindableObject
{
    private S5002IdeEvento ideEventoField;
    private Empregador ideEmpregadorField;
    private S5002IdeTrabalhador ideTrabalhadorField;
    private string idField;

    public S5002IdeEvento ideEvento
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

    public S5002IdeTrabalhador ideTrabalhador
    {
        get => ideTrabalhadorField;
        set
        {
            ideTrabalhadorField = value;
            RaisePropertyChanged(nameof(ideTrabalhador));
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
public partial class S5002IdeEvento : ESocialBindableObject
{
    private string nrRecArqBaseField;
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
public partial class S5002IdeTrabalhador : ESocialBindableObject
{
    private string cpfBenefField;
    private List<S5002DmDev> dmDevField;
    private S5002TotInfoIR totInfoIRField;
    private List<S5002InfoIRComplem> infoIRComplemField;

    public string cpfBenef
    {
        get => cpfBenefField;
        set
        {
            cpfBenefField = value;
            RaisePropertyChanged(nameof(cpfBenef));
        }
    }

    [XmlElement("dmDev")]
    public List<S5002DmDev> dmDev
    {
        get => dmDevField;
        set
        {
            dmDevField = value;
            RaisePropertyChanged(nameof(dmDev));
        }
    }

    public S5002TotInfoIR totInfoIR
    {
        get => totInfoIRField;
        set
        {
            totInfoIRField = value;
            RaisePropertyChanged(nameof(totInfoIR));
        }
    }

    [XmlElement("infoIRComplem")]
    public List<S5002InfoIRComplem> infoIRComplem
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
public partial class S5002DmDev : ESocialBindableObject
{
    private string perRefField;
    private string ideDmDevField;
    private TipoPagamento tpPgtoField;
    private DateTime dtPgtoField;
    private string codCategField;
    private List<S5002InfoIR> infoIRField;
    private List<S5002TotApurMen> totApurMenField;
    private List<S5002TotApurDia> totApurDiaField;
    private S5002InfoRRA infoRRAField;
    private S5002InfoPgtoExt infoPgtoExtField;

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

    public TipoPagamento tpPgto
    {
        get => tpPgtoField;
        set
        {
            tpPgtoField = value;
            RaisePropertyChanged(nameof(tpPgto));
        }
    }

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

    public string codCateg
    {
        get => codCategField;
        set
        {
            codCategField = value;
            RaisePropertyChanged(nameof(codCateg));
        }
    }

    [XmlElement("infoIR")]
    public List<S5002InfoIR> infoIR
    {
        get => infoIRField;
        set
        {
            infoIRField = value;
            RaisePropertyChanged(nameof(infoIR));
        }
    }

    [XmlElement("totApurMen")]
    public List<S5002TotApurMen> totApurMen
    {
        get => totApurMenField;
        set
        {
            totApurMenField = value;
            RaisePropertyChanged(nameof(totApurMen));
        }
    }

    [XmlElement("totApurDia")]
    public List<S5002TotApurDia> totApurDia
    {
        get => totApurDiaField;
        set
        {
            totApurDiaField = value;
            RaisePropertyChanged(nameof(totApurDia));
        }
    }

    public S5002InfoRRA infoRRA
    {
        get => infoRRAField;
        set
        {
            infoRRAField = value;
            RaisePropertyChanged(nameof(infoRRA));
        }
    }

    public S5002InfoPgtoExt infoPgtoExt
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
public partial class S5002InfoIR : ESocialBindableObject
{
    private string tpInfoIRField;
    private decimal valorField;
    private string descRendimentoField;
    private List<S5002InfoProcJudRub> infoProcJudRubField;

    public string tpInfoIR
    {
        get => tpInfoIRField;
        set
        {
            tpInfoIRField = value;
            RaisePropertyChanged(nameof(tpInfoIR));
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

    public string descRendimento
    {
        get => descRendimentoField;
        set
        {
            descRendimentoField = value;
            RaisePropertyChanged(nameof(descRendimento));
        }
    }

    [XmlElement("infoProcJudRub")]
    public List<S5002InfoProcJudRub> infoProcJudRub
    {
        get => infoProcJudRubField;
        set
        {
            infoProcJudRubField = value;
            RaisePropertyChanged(nameof(infoProcJudRub));
        }
    }
}

/// <exclude />
public partial class S5002InfoProcJudRub : ESocialBindableObject
{
    private string nrProcField;
    private UFCadastro ufVaraField;
    private string codMunicField;
    private ushort idVaraField;

    public string nrProc
    {
        get => nrProcField;
        set
        {
            nrProcField = value;
            RaisePropertyChanged(nameof(nrProc));
        }
    }

    public UFCadastro ufVara
    {
        get => ufVaraField;
        set
        {
            ufVaraField = value;
            RaisePropertyChanged(nameof(ufVara));
        }
    }

    public string codMunic
    {
        get => codMunicField;
        set
        {
            codMunicField = value;
            RaisePropertyChanged(nameof(codMunic));
        }
    }

    public ushort idVara
    {
        get => idVaraField;
        set
        {
            idVaraField = value;
            RaisePropertyChanged(nameof(idVara));
        }
    }
}

/// <exclude />
public partial class S5002TotApurMen : ESocialBindableObject
{
    private string CRMenField;
    private decimal? vlrRendTribField;
    private decimal? vlrRendTrib13Field;
    private decimal? vlrPrevOficialField;
    private decimal? vlrPrevOficial13Field;
    private decimal vlrCRMenField;
    private decimal? vlrCR13MenField;
    private decimal? vlrParcIsenta65Field;
    private decimal? vlrParcIsenta65DecField;
    private decimal? vlrDiariasField;
    private decimal? vlrAjudaCustoField;
    private decimal? vlrIndResContratoField;
    private decimal? vlrAbonoPecField;
    private decimal? vlrRendMoleGraveField;
    private decimal? vlrRendMoleGrave13Field;
    private decimal? vlrAuxMoradiaField;
    private decimal? vlrBolsaMedicoField;
    private decimal? vlrBolsaMedico13Field;
    private decimal? vlrJurosMoraField;
    private decimal? vlrIsenOutrosField;
    private string descRendimentoField;

    public string CRMen
    {
        get => CRMenField;
        set
        {
            CRMenField = value;
            RaisePropertyChanged(nameof(CRMen));
        }
    }

    public decimal? vlrRendTrib
    {
        get => vlrRendTribField;
        set
        {
            vlrRendTribField = value;
            RaisePropertyChanged(nameof(vlrRendTrib));
        }
    }

    public bool ShouldSerializevlrRendTrib()
        => vlrRendTrib.HasValue;

    public decimal? vlrRendTrib13
    {
        get => vlrRendTrib13Field;
        set
        {
            vlrRendTrib13Field = value;
            RaisePropertyChanged(nameof(vlrRendTrib13));
        }
    }

    public bool ShouldSerializevlrRendTrib13()
        => vlrRendTrib13.HasValue;

    public decimal? vlrPrevOficial
    {
        get => vlrPrevOficialField;
        set
        {
            vlrPrevOficialField = value;
            RaisePropertyChanged(nameof(vlrPrevOficial));
        }
    }

    public bool ShouldSerializevlrPrevOficial()
        => vlrPrevOficial.HasValue;

    public decimal? vlrPrevOficial13
    {
        get => vlrPrevOficial13Field;
        set
        {
            vlrPrevOficial13Field = value;
            RaisePropertyChanged(nameof(vlrPrevOficial13));
        }
    }

    public bool ShouldSerializevlrPrevOficial13()
        => vlrPrevOficial13.HasValue;

    public decimal vlrCRMen
    {
        get => vlrCRMenField;
        set
        {
            vlrCRMenField = value;
            RaisePropertyChanged(nameof(vlrCRMen));
        }
    }

    public decimal? vlrCR13Men
    {
        get => vlrCR13MenField;
        set
        {
            vlrCR13MenField = value;
            RaisePropertyChanged(nameof(vlrCR13Men));
        }
    }

    public bool ShouldSerializevlrCR13Men()
        => vlrCR13Men.HasValue;

    public decimal? vlrParcIsenta65
    {
        get => vlrParcIsenta65Field;
        set
        {
            vlrParcIsenta65Field = value;
            RaisePropertyChanged(nameof(vlrParcIsenta65));
        }
    }

    public bool ShouldSerializevlrParcIsenta65()
        => vlrParcIsenta65.HasValue;

    public decimal? vlrParcIsenta65Dec
    {
        get => vlrParcIsenta65DecField;
        set
        {
            vlrParcIsenta65DecField = value;
            RaisePropertyChanged(nameof(vlrParcIsenta65Dec));
        }
    }

    public bool ShouldSerializevlrParcIsenta65Dec()
        => vlrParcIsenta65Dec.HasValue;

    public decimal? vlrDiarias
    {
        get => vlrDiariasField;
        set
        {
            vlrDiariasField = value;
            RaisePropertyChanged(nameof(vlrDiarias));
        }
    }

    public bool ShouldSerializevlrDiarias()
        => vlrDiarias.HasValue;

    public decimal? vlrAjudaCusto
    {
        get => vlrAjudaCustoField;
        set
        {
            vlrAjudaCustoField = value;
            RaisePropertyChanged(nameof(vlrAjudaCusto));
        }
    }

    public bool ShouldSerializevlrAjudaCusto()
        => vlrAjudaCusto.HasValue;

    public decimal? vlrIndResContrato
    {
        get => vlrIndResContratoField;
        set
        {
            vlrIndResContratoField = value;
            RaisePropertyChanged(nameof(vlrIndResContrato));
        }
    }

    public bool ShouldSerializevlrIndResContrato()
        => vlrIndResContrato.HasValue;

    public decimal? vlrAbonoPec
    {
        get => vlrAbonoPecField;
        set
        {
            vlrAbonoPecField = value;
            RaisePropertyChanged(nameof(vlrAbonoPec));
        }
    }

    public bool ShouldSerializevlrAbonoPec()
        => vlrAbonoPec.HasValue;

    public decimal? vlrRendMoleGrave
    {
        get => vlrRendMoleGraveField;
        set
        {
            vlrRendMoleGraveField = value;
            RaisePropertyChanged(nameof(vlrRendMoleGrave));
        }
    }

    public bool ShouldSerializevlrRendMoleGrave()
        => vlrRendMoleGrave.HasValue;

    public decimal? vlrRendMoleGrave13
    {
        get => vlrRendMoleGrave13Field;
        set
        {
            vlrRendMoleGrave13Field = value;
            RaisePropertyChanged(nameof(vlrRendMoleGrave13));
        }
    }

    public bool ShouldSerializevlrRendMoleGrave13()
        => vlrRendMoleGrave13.HasValue;

    public decimal? vlrAuxMoradia
    {
        get => vlrAuxMoradiaField;
        set
        {
            vlrAuxMoradiaField = value;
            RaisePropertyChanged(nameof(vlrAuxMoradia));
        }
    }

    public bool ShouldSerializevlrAuxMoradia()
        => vlrAuxMoradia.HasValue;

    public decimal? vlrBolsaMedico
    {
        get => vlrBolsaMedicoField;
        set
        {
            vlrBolsaMedicoField = value;
            RaisePropertyChanged(nameof(vlrBolsaMedico));
        }
    }

    public bool ShouldSerializevlrBolsaMedico()
        => vlrBolsaMedico.HasValue;

    public decimal? vlrBolsaMedico13
    {
        get => vlrBolsaMedico13Field;
        set
        {
            vlrBolsaMedico13Field = value;
            RaisePropertyChanged(nameof(vlrBolsaMedico13));
        }
    }

    public bool ShouldSerializevlrBolsaMedico13()
        => vlrBolsaMedico13.HasValue;

    public decimal? vlrJurosMora
    {
        get => vlrJurosMoraField;
        set
        {
            vlrJurosMoraField = value;
            RaisePropertyChanged(nameof(vlrJurosMora));
        }
    }

    public bool ShouldSerializevlrJurosMora()
        => vlrJurosMora.HasValue;

    public decimal? vlrIsenOutros
    {
        get => vlrIsenOutrosField;
        set
        {
            vlrIsenOutrosField = value;
            RaisePropertyChanged(nameof(vlrIsenOutros));
        }
    }

    public bool ShouldSerializevlrIsenOutros()
        => vlrIsenOutros.HasValue;

    public string descRendimento
    {
        get => descRendimentoField;
        set
        {
            descRendimentoField = value;
            RaisePropertyChanged(nameof(descRendimento));
        }
    }
}

/// <exclude />
public partial class S5002TotApurDia : ESocialBindableObject
{
    private byte perApurDiaField;
    private string CRDiaField;
    private string frmTributField;
    private string paisResidExtField;
    private decimal? vlrPagoDiaField;
    private decimal vlrCRDiaField;

    public byte perApurDia
    {
        get => perApurDiaField;
        set
        {
            perApurDiaField = value;
            RaisePropertyChanged(nameof(perApurDia));
        }
    }

    public string CRDia
    {
        get => CRDiaField;
        set
        {
            CRDiaField = value;
            RaisePropertyChanged(nameof(CRDia));
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

    public string paisResidExt
    {
        get => paisResidExtField;
        set
        {
            paisResidExtField = value;
            RaisePropertyChanged(nameof(paisResidExt));
        }
    }

    public decimal? vlrPagoDia
    {
        get => vlrPagoDiaField;
        set
        {
            vlrPagoDiaField = value;
            RaisePropertyChanged(nameof(vlrPagoDia));
        }
    }

    public bool ShouldSerializevlrPagoDia()
        => vlrPagoDia.HasValue;

    public decimal vlrCRDia
    {
        get => vlrCRDiaField;
        set
        {
            vlrCRDiaField = value;
            RaisePropertyChanged(nameof(vlrCRDia));
        }
    }
}

/// <exclude />
public partial class S5002InfoRRA : ESocialBindableObject
{
    private TipoProcesso tpProcRRAField;
    private string nrProcRRAField;
    private string descRRAField;
    private decimal qtdMesesRRAField;
    private S5002DespProcJud despProcJudField;
    private List<S5002IdeAdv> ideAdvField;

    public TipoProcesso tpProcRRA
    {
        get => tpProcRRAField;
        set
        {
            tpProcRRAField = value;
            RaisePropertyChanged(nameof(tpProcRRA));
        }
    }

    public string nrProcRRA
    {
        get => nrProcRRAField;
        set
        {
            nrProcRRAField = value;
            RaisePropertyChanged(nameof(nrProcRRA));
        }
    }

    public string descRRA
    {
        get => descRRAField;
        set
        {
            descRRAField = value;
            RaisePropertyChanged(nameof(descRRA));
        }
    }

    public decimal qtdMesesRRA
    {
        get => qtdMesesRRAField;
        set
        {
            qtdMesesRRAField = value;
            RaisePropertyChanged(nameof(qtdMesesRRA));
        }
    }

    public S5002DespProcJud despProcJud
    {
        get => despProcJudField;
        set
        {
            despProcJudField = value;
            RaisePropertyChanged(nameof(despProcJud));
        }
    }

    [XmlElement("ideAdv")]
    public List<S5002IdeAdv> ideAdv
    {
        get => ideAdvField;
        set
        {
            ideAdvField = value;
            RaisePropertyChanged(nameof(ideAdv));
        }
    }
}

/// <exclude />
public partial class S5002DespProcJud : ESocialBindableObject
{
    private decimal vlrDespCustasField;
    private decimal vlrDespAdvogadosField;

    public decimal vlrDespCustas
    {
        get => vlrDespCustasField;
        set
        {
            vlrDespCustasField = value;
            RaisePropertyChanged(nameof(vlrDespCustas));
        }
    }

    public decimal vlrDespAdvogados
    {
        get => vlrDespAdvogadosField;
        set
        {
            vlrDespAdvogadosField = value;
            RaisePropertyChanged(nameof(vlrDespAdvogados));
        }
    }
}

/// <exclude />
public partial class S5002IdeAdv : ESocialBindableObject
{
    private PersonalidadeJuridica tpInscField;
    private string nrInscField;
    private decimal? vlrAdvField;

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

    public decimal? vlrAdv
    {
        get => vlrAdvField;
        set
        {
            vlrAdvField = value;
            RaisePropertyChanged(nameof(vlrAdv));
        }
    }

    public bool ShouldSerializevlrAdv()
        => vlrAdv.HasValue;
}

/// <exclude />
public partial class S5002InfoPgtoExt : ESocialBindableObject
{
    private string paisResidExtField;
    private IndicadorNIF indNIFField;
    private string nifBenefField;
    private string frmTributField;
    private S5002EndExt endExtField;

    public string paisResidExt
    {
        get => paisResidExtField;
        set
        {
            paisResidExtField = value;
            RaisePropertyChanged(nameof(paisResidExt));
        }
    }

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

    public S5002EndExt endExt
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
public partial class S5002EndExt : ESocialBindableObject
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
public partial class S5002TotInfoIR : ESocialBindableObject
{
    private List<S5002ConsolidApurMen> consolidApurMenField;

    [XmlElement("consolidApurMen")]
    public List<S5002ConsolidApurMen> consolidApurMen
    {
        get => consolidApurMenField;
        set
        {
            consolidApurMenField = value;
            RaisePropertyChanged(nameof(consolidApurMen));
        }
    }
}

/// <exclude />
public partial class S5002ConsolidApurMen : ESocialBindableObject
{
    private string CRMenField;
    private decimal? vlrRendTribField;
    private decimal? vlrRendTrib13Field;
    private decimal? vlrPrevOficialField;
    private decimal? vlrPrevOficial13Field;
    private decimal vlrCRMenField;
    private decimal? vlrCR13MenField;
    private decimal? vlrParcIsenta65Field;
    private decimal? vlrParcIsenta65DecField;
    private decimal? vlrDiariasField;
    private decimal? vlrAjudaCustoField;
    private decimal? vlrIndResContratoField;
    private decimal? vlrAbonoPecField;
    private decimal? vlrRendMoleGraveField;
    private decimal? vlrRendMoleGrave13Field;
    private decimal? vlrAuxMoradiaField;
    private decimal? vlrBolsaMedicoField;
    private decimal? vlrBolsaMedico13Field;
    private decimal? vlrJurosMoraField;
    private decimal? vlrIsenOutrosField;
    private string descRendimentoField;

    public string CRMen
    {
        get => CRMenField;
        set
        {
            CRMenField = value;
            RaisePropertyChanged(nameof(CRMen));
        }
    }

    public decimal? vlrRendTrib
    {
        get => vlrRendTribField;
        set
        {
            vlrRendTribField = value;
            RaisePropertyChanged(nameof(vlrRendTrib));
        }
    }

    public bool ShouldSerializevlrRendTrib()
        => vlrRendTrib.HasValue;

    public decimal? vlrRendTrib13
    {
        get => vlrRendTrib13Field;
        set
        {
            vlrRendTrib13Field = value;
            RaisePropertyChanged(nameof(vlrRendTrib13));
        }
    }

    public bool ShouldSerializevlrRendTrib13()
        => vlrRendTrib13.HasValue;

    public decimal? vlrPrevOficial
    {
        get => vlrPrevOficialField;
        set
        {
            vlrPrevOficialField = value;
            RaisePropertyChanged(nameof(vlrPrevOficial));
        }
    }

    public bool ShouldSerializevlrPrevOficial()
        => vlrPrevOficial.HasValue;

    public decimal? vlrPrevOficial13
    {
        get => vlrPrevOficial13Field;
        set
        {
            vlrPrevOficial13Field = value;
            RaisePropertyChanged(nameof(vlrPrevOficial13));
        }
    }

    public bool ShouldSerializevlrPrevOficial13()
        => vlrPrevOficial13.HasValue;

    public decimal vlrCRMen
    {
        get => vlrCRMenField;
        set
        {
            vlrCRMenField = value;
            RaisePropertyChanged(nameof(vlrCRMen));
        }
    }

    public decimal? vlrCR13Men
    {
        get => vlrCR13MenField;
        set
        {
            vlrCR13MenField = value;
            RaisePropertyChanged(nameof(vlrCR13Men));
        }
    }

    public bool ShouldSerializevlrCR13Men()
        => vlrCR13Men.HasValue;

    public decimal? vlrParcIsenta65
    {
        get => vlrParcIsenta65Field;
        set
        {
            vlrParcIsenta65Field = value;
            RaisePropertyChanged(nameof(vlrParcIsenta65));
        }
    }

    public bool ShouldSerializevlrParcIsenta65()
        => vlrParcIsenta65.HasValue;

    public decimal? vlrParcIsenta65Dec
    {
        get => vlrParcIsenta65DecField;
        set
        {
            vlrParcIsenta65DecField = value;
            RaisePropertyChanged(nameof(vlrParcIsenta65Dec));
        }
    }

    public bool ShouldSerializevlrParcIsenta65Dec()
        => vlrParcIsenta65Dec.HasValue;

    public decimal? vlrDiarias
    {
        get => vlrDiariasField;
        set
        {
            vlrDiariasField = value;
            RaisePropertyChanged(nameof(vlrDiarias));
        }
    }

    public bool ShouldSerializevlrDiarias()
        => vlrDiarias.HasValue;

    public decimal? vlrAjudaCusto
    {
        get => vlrAjudaCustoField;
        set
        {
            vlrAjudaCustoField = value;
            RaisePropertyChanged(nameof(vlrAjudaCusto));
        }
    }

    public bool ShouldSerializevlrAjudaCusto()
        => vlrAjudaCusto.HasValue;

    public decimal? vlrIndResContrato
    {
        get => vlrIndResContratoField;
        set
        {
            vlrIndResContratoField = value;
            RaisePropertyChanged(nameof(vlrIndResContrato));
        }
    }

    public bool ShouldSerializevlrIndResContrato()
        => vlrIndResContrato.HasValue;

    public decimal? vlrAbonoPec
    {
        get => vlrAbonoPecField;
        set
        {
            vlrAbonoPecField = value;
            RaisePropertyChanged(nameof(vlrAbonoPec));
        }
    }

    public bool ShouldSerializevlrAbonoPec()
        => vlrAbonoPec.HasValue;

    public decimal? vlrRendMoleGrave
    {
        get => vlrRendMoleGraveField;
        set
        {
            vlrRendMoleGraveField = value;
            RaisePropertyChanged(nameof(vlrRendMoleGrave));
        }
    }

    public bool ShouldSerializevlrRendMoleGrave()
        => vlrRendMoleGrave.HasValue;

    public decimal? vlrRendMoleGrave13
    {
        get => vlrRendMoleGrave13Field;
        set
        {
            vlrRendMoleGrave13Field = value;
            RaisePropertyChanged(nameof(vlrRendMoleGrave13));
        }
    }

    public bool ShouldSerializevlrRendMoleGrave13()
        => vlrRendMoleGrave13.HasValue;

    public decimal? vlrAuxMoradia
    {
        get => vlrAuxMoradiaField;
        set
        {
            vlrAuxMoradiaField = value;
            RaisePropertyChanged(nameof(vlrAuxMoradia));
        }
    }

    public bool ShouldSerializevlrAuxMoradia()
        => vlrAuxMoradia.HasValue;

    public decimal? vlrBolsaMedico
    {
        get => vlrBolsaMedicoField;
        set
        {
            vlrBolsaMedicoField = value;
            RaisePropertyChanged(nameof(vlrBolsaMedico));
        }
    }

    public bool ShouldSerializevlrBolsaMedico()
        => vlrBolsaMedico.HasValue;

    public decimal? vlrBolsaMedico13
    {
        get => vlrBolsaMedico13Field;
        set
        {
            vlrBolsaMedico13Field = value;
            RaisePropertyChanged(nameof(vlrBolsaMedico13));
        }
    }

    public bool ShouldSerializevlrBolsaMedico13()
        => vlrBolsaMedico13.HasValue;

    public decimal? vlrJurosMora
    {
        get => vlrJurosMoraField;
        set
        {
            vlrJurosMoraField = value;
            RaisePropertyChanged(nameof(vlrJurosMora));
        }
    }

    public bool ShouldSerializevlrJurosMora()
        => vlrJurosMora.HasValue;

    public decimal? vlrIsenOutros
    {
        get => vlrIsenOutrosField;
        set
        {
            vlrIsenOutrosField = value;
            RaisePropertyChanged(nameof(vlrIsenOutros));
        }
    }

    public bool ShouldSerializevlrIsenOutros()
        => vlrIsenOutros.HasValue;

    public string descRendimento
    {
        get => descRendimentoField;
        set
        {
            descRendimentoField = value;
            RaisePropertyChanged(nameof(descRendimento));
        }
    }
}

/// <exclude />
public partial class S5002InfoIRComplem : ESocialBindableObject
{
    private DateTime? dtLaudoField;
    private S5002PerAnt perAntField;
    private List<S5002IdeDep> ideDepField;
    private List<S5002InfoIRCR> infoIRCRField;
    private List<S5002PlanSaude> planSaudeField;
    private List<S5002InfoReembMed> infoReembMedField;

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

    public S5002PerAnt perAnt
    {
        get => perAntField;
        set
        {
            perAntField = value;
            RaisePropertyChanged(nameof(perAnt));
        }
    }

    [XmlElement("ideDep")]
    public List<S5002IdeDep> ideDep
    {
        get => ideDepField;
        set
        {
            ideDepField = value;
            RaisePropertyChanged(nameof(ideDep));
        }
    }

    [XmlElement("infoIRCR")]
    public List<S5002InfoIRCR> infoIRCR
    {
        get => infoIRCRField;
        set
        {
            infoIRCRField = value;
            RaisePropertyChanged(nameof(infoIRCR));
        }
    }

    [XmlElement("planSaude")]
    public List<S5002PlanSaude> planSaude
    {
        get => planSaudeField;
        set
        {
            planSaudeField = value;
            RaisePropertyChanged(nameof(planSaude));
        }
    }

    [XmlElement("infoReembMed")]
    public List<S5002InfoReembMed> infoReembMed
    {
        get => infoReembMedField;
        set
        {
            infoReembMedField = value;
            RaisePropertyChanged(nameof(infoReembMed));
        }
    }
}

/// <exclude />
public partial class S5002PerAnt : ESocialBindableObject
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
public partial class S5002IdeDep : ESocialBindableObject
{
    private string cpfDepField;
    private SimNaoString? depIRRFField;
    private DateTime? dtNasctoField;
    private string nomeField;
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
public partial class S5002InfoIRCR : ESocialBindableObject
{
    private string tpCRField;
    private List<S5002DedDepen> dedDepenField;
    private List<S5002PenAlim> penAlimField;
    private List<S5002PrevidCompl> previdComplField;
    private List<S5002InfoProcRet> infoProcRetField;

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
    public List<S5002DedDepen> dedDepen
    {
        get => dedDepenField;
        set
        {
            dedDepenField = value;
            RaisePropertyChanged(nameof(dedDepen));
        }
    }

    [XmlElement("penAlim")]
    public List<S5002PenAlim> penAlim
    {
        get => penAlimField;
        set
        {
            penAlimField = value;
            RaisePropertyChanged(nameof(penAlim));
        }
    }

    [XmlElement("previdCompl")]
    public List<S5002PrevidCompl> previdCompl
    {
        get => previdComplField;
        set
        {
            previdComplField = value;
            RaisePropertyChanged(nameof(previdCompl));
        }
    }

    [XmlElement("infoProcRet")]
    public List<S5002InfoProcRet> infoProcRet
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
public partial class S5002DedDepen : ESocialBindableObject
{
    private TipoRendimentoDependente tpRendField;
    private string cpfDepField;
    private decimal vlrDedDepField;

    public TipoRendimentoDependente tpRend
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
public partial class S5002PenAlim : ESocialBindableObject
{
    private TipoRendimentoPensaoAlimenticia tpRendField;
    private string cpfDepField;
    private decimal vlrDedPenAlimField;

    public TipoRendimentoPensaoAlimenticia tpRend
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
public partial class S5002PrevidCompl : ESocialBindableObject
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
public partial class S5002InfoProcRet : ESocialBindableObject
{
    private TipoProcesso tpProcRetField;
    private string nrProcRetField;
    private string codSuspField;
    private List<S5002InfoValores> infoValoresField;

    public TipoProcesso tpProcRet
    {
        get => tpProcRetField;
        set
        {
            tpProcRetField = value;
            RaisePropertyChanged(nameof(tpProcRet));
        }
    }

    public string nrProcRet
    {
        get => nrProcRetField;
        set
        {
            nrProcRetField = value;
            RaisePropertyChanged(nameof(nrProcRet));
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
    public List<S5002InfoValores> infoValores
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
public partial class S5002InfoValores : ESocialBindableObject
{
    private IndicadorApuracao indApuracaoField;
    private decimal? vlrNRetidoField;
    private decimal? vlrDepJudField;
    private decimal? vlrCmpAnoCalField;
    private decimal? vlrCmpAnoAntField;
    private decimal? vlrRendSuspField;
    private List<S5002DedSusp> dedSuspField;

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
    public List<S5002DedSusp> dedSusp
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
public partial class S5002DedSusp : ESocialBindableObject
{
    private IndicadorTipoDeducao indTpDeducaoField;
    private decimal? vlrDedSuspField;
    private string cnpjEntidPCField;
    private decimal? vlrPatrocFunpField;
    private List<S5002BenefPen> benefPenField;

    public IndicadorTipoDeducao indTpDeducao
    {
        get => indTpDeducaoField;
        set
        {
            indTpDeducaoField = value;
            RaisePropertyChanged(nameof(indTpDeducao));
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

    [XmlElement("benefPen")]
    public List<S5002BenefPen> benefPen
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
public partial class S5002BenefPen : ESocialBindableObject
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

/// <exclude />
public partial class S5002PlanSaude : ESocialBindableObject
{
    private string cnpjOperField;
    private string regANSField;
    private decimal vlrSaudeTitField;
    private List<S5002InfoDepSau> infoDepSauField;

    public string cnpjOper
    {
        get => cnpjOperField;
        set
        {
            cnpjOperField = value;
            RaisePropertyChanged(nameof(cnpjOper));
        }
    }

    public string regANS
    {
        get => regANSField;
        set
        {
            regANSField = value;
            RaisePropertyChanged(nameof(regANS));
        }
    }

    public decimal vlrSaudeTit
    {
        get => vlrSaudeTitField;
        set
        {
            vlrSaudeTitField = value;
            RaisePropertyChanged(nameof(vlrSaudeTit));
        }
    }

    [XmlElement("infoDepSau")]
    public List<S5002InfoDepSau> infoDepSau
    {
        get => infoDepSauField;
        set
        {
            infoDepSauField = value;
            RaisePropertyChanged(nameof(infoDepSau));
        }
    }
}

/// <exclude />
public partial class S5002InfoDepSau : ESocialBindableObject
{
    private string cpfDepField;
    private decimal vlrSaudeDepField;

    public string cpfDep
    {
        get => cpfDepField;
        set
        {
            cpfDepField = value;
            RaisePropertyChanged(nameof(cpfDep));
        }
    }

    public decimal vlrSaudeDep
    {
        get => vlrSaudeDepField;
        set
        {
            vlrSaudeDepField = value;
            RaisePropertyChanged(nameof(vlrSaudeDep));
        }
    }
}

/// <exclude />
public partial class S5002InfoReembMed : ESocialBindableObject
{
    private IndicadorOrigemReembolso indOrgReembField;
    private string cnpjOperField;
    private string regANSField;
    private List<S5002DetReemb> detReembTitField;
    private List<S5002InfoReembDep> infoReembDepField;

    public IndicadorOrigemReembolso indOrgReemb
    {
        get => indOrgReembField;
        set
        {
            indOrgReembField = value;
            RaisePropertyChanged(nameof(indOrgReemb));
        }
    }

    public string cnpjOper
    {
        get => cnpjOperField;
        set
        {
            cnpjOperField = value;
            RaisePropertyChanged(nameof(cnpjOper));
        }
    }

    public string regANS
    {
        get => regANSField;
        set
        {
            regANSField = value;
            RaisePropertyChanged(nameof(regANS));
        }
    }

    [XmlElement("detReembTit")]
    public List<S5002DetReemb> detReembTit
    {
        get => detReembTitField;
        set
        {
            detReembTitField = value;
            RaisePropertyChanged(nameof(detReembTit));
        }
    }

    [XmlElement("infoReembDep")]
    public List<S5002InfoReembDep> infoReembDep
    {
        get => infoReembDepField;
        set
        {
            infoReembDepField = value;
            RaisePropertyChanged(nameof(infoReembDep));
        }
    }
}

/// <exclude />
public partial class S5002InfoReembDep : ESocialBindableObject
{
    private string cpfBenefField;
    private List<S5002DetReemb> detReembDepField;

    public string cpfBenef
    {
        get => cpfBenefField;
        set
        {
            cpfBenefField = value;
            RaisePropertyChanged(nameof(cpfBenef));
        }
    }

    [XmlElement("detReembDep")]
    public List<S5002DetReemb> detReembDep
    {
        get => detReembDepField;
        set
        {
            detReembDepField = value;
            RaisePropertyChanged(nameof(detReembDep));
        }
    }
}

/// <exclude />
public partial class S5002DetReemb : ESocialBindableObject
{
    private PersonalidadeJuridica tpInscField;
    private string nrInscField;
    private decimal? vlrReembField;
    private decimal? vlrReembAntField;

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

    public decimal? vlrReemb
    {
        get => vlrReembField;
        set
        {
            vlrReembField = value;
            RaisePropertyChanged(nameof(vlrReemb));
        }
    }

    public bool ShouldSerializevlrReemb()
        => vlrReemb.HasValue;

    public decimal? vlrReembAnt
    {
        get => vlrReembAntField;
        set
        {
            vlrReembAntField = value;
            RaisePropertyChanged(nameof(vlrReembAnt));
        }
    }

    public bool ShouldSerializevlrReembAnt()
        => vlrReembAnt.HasValue;
}
