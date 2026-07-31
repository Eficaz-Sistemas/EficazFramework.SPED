using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EficazFramework.SPED.Schemas.eSocial;

/// <summary>
/// Trabalhador Sem Vínculo de Emprego/Estatutário - Término
/// </summary>
/// <example>
/// ```csharp
/// evento.Versao = Versao.v_S_01_03_00;
/// 
/// evento.evtTSVTermino = new S2399EvtTSVTermino
/// {
///     ideEvento = new S2399IdeEvento
///     {
///         indRetif = IndicadorRetificacao.Original,
///         nrRecibo = null,
///         indGuia = IndicadorGuia.DAE,
///         tpAmb = Ambiente.ProducaoRestrita_DadosReais,
///         procEmi = EmissorEvento.AppEmpregador,
///         verProc = "EficazFramework"
///     },
///     ideEmpregador = new Empregador
///     {
///         tpInsc = PersonalidadeJuridica.CNPJ,
///         nrInsc = "12345678000199"
///     },
///     ideTrabSemVinculo = new S2399IdeTrabSemVinculo
///     {
///         cpfTrab = "12345678901",
///         matricula = "123",
///         codCateg = "721"
///     },
///     infoTSVTermino = new S2399InfoTSVTermino
///     {
///         dtTerm = new DateTime(2024, 5, 20),
///         mtvDesligTSV = MotivoDesligamentoTSV.ExoneracaoSemJustaCausa,
///         pensAlim = 1,
///         percAliment = 15.5m,
///         vrAlim = 1500m,
///         nrProcTrab = "12345678901234567890",
///         
///         mudancaCPF = new S2399MudancaCPF
///         {
///             novoCPF = "09876543210"
///         },
///         
///         verbasResc = new S2399VerbasResc
///         {
///             dmDev = new List<S2399DmDev>
///             {
///                 new S2399DmDev
///                 {
///                     ideDmDev = "DM123",
///                     indRRA = SimNaoString.Sim,
///                     infoRRA = new S2399InfoRRA
///                     {
///                         tpProcRRA = TipoProcesso.Administrativo,
///                         nrProcRRA = "123456789012345678901",
///                         descRRA = "Descrição RRA",
///                         qtdMesesRRA = 10,
///                         despProcJud = new DetalhamentoDespJud
///                         {
///                             vlrDespCustas = 100m,
///                             vlrDespAdvogados = 200m
///                         }
///                     },
///                     ideEstabLot = new List<S2399IdeEstabLot>
///                     {
///                         new S2399IdeEstabLot
///                         {
///                             tpInsc = PersonalidadeJuridica.CNPJ,
///                             nrInsc = "12345678000199",
///                             codLotacao = "LOT01",
///                             detVerbas = new List<S2399DetVerbas>
///                             {
///                                 new S2399DetVerbas
///                                 {
///                                     codRubr = "R01",
///                                     ideTabRubr = "T01",
///                                     qtdRubr = 1,
///                                     fatorRubr = 1,
///                                     vrRubr = 1000m,
///                                     indApurIR = 0,
///                                     descFolha = new S2399DescFolha
///                                     {
///                                         tpDesc = 1,
///                                         instFinanc = "001",
///                                         nrDoc = "12345",
///                                         observacao = "Obs"
///                                     }
///                                 }
///                             },
///                             infoSimples = new S2399InfoSimples
///                             {
///                                 indSimples = 1
///                             }
///                         }
///                     }
///                 }
///             },
///             procJudTrab = new List<S2399ProcJudTrab>
///             {
///                 new S2399ProcJudTrab
///                 {
///                     tpTrib = TipoProcesso.Judicial,
///                     nrProcJud = "12345678901234567890",
///                     codSusp = "12345678901234"
///                 }
///             },
///             infoMV = new S2399InfoMV
///             {
///                 indMV = 1,
///                 remunOutrEmpr = new List<S2399RemunOutrasEmpresas>
///                 {
///                     new S2399RemunOutrasEmpresas
///                     {
///                         tpInsc = PersonalidadeJuridica.CNPJ,
///                         nrInsc = "98765432000199",
///                         codCateg = "721",
///                         vlrRemunOE = 500m
///                     }
///                 }
///             }
///         },
///         
///         remunAposTerm = new S2399RemunAposTerm
///         {
///             indRemun = IndicadorRemuneracaoTSV.Quarentena,
///             dtFimRemun = new DateTime(2024, 6, 20)
///         }
///     }
/// };
/// ```
/// </example>
[Serializable()]
public partial class S2399 : Evento
{
    private S2399EvtTSVTermino evtTSVTerminoField;
    private SignatureType signatureField;

    public S2399()
    {
        evtTSVTerminoField = new S2399EvtTSVTermino();
    }

    [XmlElement()]
    public S2399EvtTSVTermino evtTSVTermino
    {
        get => evtTSVTerminoField;
        set
        {
            evtTSVTerminoField = value;
            RaisePropertyChanged(nameof(evtTSVTermino));
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
        => evtTSVTerminoField.Id = string.Format("ID{0}{1}{2}",
            (int)(evtTSVTerminoField?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ),
            evtTSVTerminoField?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000",
            eSocialTimeStampUtils.GetTimeStampIDForEvent());

    public override string ContribuinteCNPJ()
        => evtTSVTerminoField.ideEmpregador.nrInsc;

    public override string TagToSign => Evento.root;
    public override string TagId => nameof(evtTSVTermino);
    public override bool EmptyURI => true;
    public override bool SignAsSHA256 => true;
}

/// <exclude />
public partial class S2399EvtTSVTermino : ESocialBindableObject
{
    private string idField;
    private S2399IdeEvento ideEventoField;
    private Empregador ideEmpregadorField;
    private S2399IdeTrabSemVinculo ideTrabSemVinculoField;
    private S2399InfoTSVTermino infoTSVTerminoField;

    public S2399EvtTSVTermino()
    {
        ideEventoField = new S2399IdeEvento();
        ideEmpregadorField = new Empregador();
        ideTrabSemVinculoField = new S2399IdeTrabSemVinculo();
        infoTSVTerminoField = new S2399InfoTSVTermino();
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
    public S2399IdeEvento ideEvento
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
    public S2399IdeTrabSemVinculo ideTrabSemVinculo
    {
        get => ideTrabSemVinculoField;
        set
        {
            ideTrabSemVinculoField = value;
            RaisePropertyChanged(nameof(ideTrabSemVinculo));
        }
    }

    [XmlElement()]
    public S2399InfoTSVTermino infoTSVTermino
    {
        get => infoTSVTerminoField;
        set
        {
            infoTSVTerminoField = value;
            RaisePropertyChanged(nameof(infoTSVTermino));
        }
    }
}

public enum MotivoDesligamentoTSV
{
    [XmlEnum("01")]
    [Description("Exoneração do diretor não empregado sem justa causa, por deliberação da assembleia, dos sócios cotistas ou da autoridade competente")]
    ExoneracaoSemJustaCausa = 1,

    [XmlEnum("02")]
    [Description("Término de mandato do diretor não empregado que não tenha sido reconduzido ao cargo")]
    TerminoMandato = 2,

    [XmlEnum("03")]
    [Description("Exoneração a pedido de diretor não empregado")]
    ExoneracaoAPedido = 3,

    [XmlEnum("04")]
    [Description("Exoneração do diretor não empregado por culpa recíproca ou força maior")]
    ExoneracaoCulpaReciproca = 4,

    [XmlEnum("05")]
    [Description("Morte do diretor não empregado")]
    Morte = 5,

    [XmlEnum("06")]
    [Description("Exoneração do diretor não empregado por falência, encerramento ou supressão de parte da empresa")]
    ExoneracaoFalencia = 6,

    [XmlEnum("07")]
    [Description("Mudança de CPF")]
    MudancaCPF = 7,

    [XmlEnum("99")]
    [Description("Outros")]
    Outros = 99
}

public enum IndicadorRemuneracaoTSV
{
    [XmlEnum("1")]
    [Description("Quarentena")]
    Quarentena = 1,

    [XmlEnum("2")]
    [Description("Término reconhecido judicialmente com data anterior a competências com remunerações já informadas no eSocial")]
    TerminoJudicial = 2
}

/// <exclude />
public partial class S2399IdeEvento : ESocialBindableObject
{
    private IndicadorRetificacao indRetifField = IndicadorRetificacao.Original;
    private string nrReciboField;
    private IndicadorGuia? indGuiaField;
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

    [XmlElement()]
    public IndicadorGuia? indGuia
    {
        get => indGuiaField;
        set
        {
            indGuiaField = value;
            RaisePropertyChanged(nameof(indGuia));
        }
    }

    public bool ShouldSerializeindGuia() => indGuia.HasValue;

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
public partial class S2399IdeTrabSemVinculo : ESocialBindableObject
{
    private string cpfTrabField;
    private string matriculaField;
    private string codCategField;

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

    public string codCateg
    {
        get => codCategField;
        set
        {
            codCategField = value;
            RaisePropertyChanged(nameof(codCateg));
        }
    }
}

/// <exclude />
public partial class S2399InfoTSVTermino : ESocialBindableObject
{
    private DateTime dtTermField;
    private MotivoDesligamentoTSV? mtvDesligTSVField;
    private sbyte? pensAlimField;
    private decimal? percAlimentField;
    private decimal? vrAlimField;
    private string nrProcTrabField;
    private S2399MudancaCPF mudancaCPFField;
    private S2399VerbasResc verbasRescField;
    private S2399RemunAposTerm remunAposTermField;

    [XmlElement(DataType = "date")]
    public DateTime dtTerm
    {
        get => dtTermField;
        set
        {
            dtTermField = value;
            RaisePropertyChanged(nameof(dtTerm));
        }
    }

    public MotivoDesligamentoTSV? mtvDesligTSV
    {
        get => mtvDesligTSVField;
        set
        {
            mtvDesligTSVField = value;
            RaisePropertyChanged(nameof(mtvDesligTSV));
        }
    }

    public bool ShouldSerializemtvDesligTSV() => mtvDesligTSV.HasValue;

    public sbyte? pensAlim
    {
        get => pensAlimField;
        set
        {
            pensAlimField = value;
            RaisePropertyChanged(nameof(pensAlim));
        }
    }

    public bool ShouldSerializepensAlim() => pensAlim.HasValue;

    public decimal? percAliment
    {
        get => percAlimentField;
        set
        {
            percAlimentField = value;
            RaisePropertyChanged(nameof(percAliment));
        }
    }

    public bool ShouldSerializepercAliment() => percAliment.HasValue;

    public decimal? vrAlim
    {
        get => vrAlimField;
        set
        {
            vrAlimField = value;
            RaisePropertyChanged(nameof(vrAlim));
        }
    }

    public bool ShouldSerializevrAlim() => vrAlim.HasValue;

    public string nrProcTrab
    {
        get => nrProcTrabField;
        set
        {
            nrProcTrabField = value;
            RaisePropertyChanged(nameof(nrProcTrab));
        }
    }

    public S2399MudancaCPF mudancaCPF
    {
        get => mudancaCPFField;
        set
        {
            mudancaCPFField = value;
            RaisePropertyChanged(nameof(mudancaCPF));
        }
    }

    public S2399VerbasResc verbasResc
    {
        get => verbasRescField;
        set
        {
            verbasRescField = value;
            RaisePropertyChanged(nameof(verbasResc));
        }
    }

    public S2399RemunAposTerm remunAposTerm
    {
        get => remunAposTermField;
        set
        {
            remunAposTermField = value;
            RaisePropertyChanged(nameof(remunAposTerm));
        }
    }
}

/// <exclude />
public partial class S2399MudancaCPF : ESocialBindableObject
{
    private string novoCPFField;

    public string novoCPF
    {
        get => novoCPFField;
        set
        {
            novoCPFField = value;
            RaisePropertyChanged(nameof(novoCPF));
        }
    }
}

/// <exclude />
public partial class S2399VerbasResc : ESocialBindableObject
{
    private List<S2399DmDev> dmDevField;
    private List<S2399ProcJudTrab> procJudTrabField;
    private S2399InfoMV infoMVField;

    [XmlElement("dmDev")]
    public List<S2399DmDev> dmDev
    {
        get => dmDevField;
        set
        {
            dmDevField = value;
            RaisePropertyChanged(nameof(dmDev));
        }
    }

    [XmlElement("procJudTrab")]
    public List<S2399ProcJudTrab> procJudTrab
    {
        get => procJudTrabField;
        set
        {
            procJudTrabField = value;
            RaisePropertyChanged(nameof(procJudTrab));
        }
    }

    public S2399InfoMV infoMV
    {
        get => infoMVField;
        set
        {
            infoMVField = value;
            RaisePropertyChanged(nameof(infoMV));
        }
    }
}

/// <exclude />
public partial class S2399DmDev : ESocialBindableObject
{
    private string ideDmDevField;
    private SimNaoString indRRAField;
    private S2399InfoRRA infoRRAField;
    private List<S2399IdeEstabLot> ideEstabLotField;

    public string ideDmDev
    {
        get => ideDmDevField;
        set
        {
            ideDmDevField = value;
            RaisePropertyChanged(nameof(ideDmDev));
        }
    }

    public SimNaoString indRRA
    {
        get => indRRAField;
        set
        {
            indRRAField = value;
            RaisePropertyChanged(nameof(indRRA));
        }
    }

    public bool ShouldSerializeindRRA() => indRRA != null;

    [XmlElement()]
    public S2399InfoRRA infoRRA
    {
        get => infoRRAField;
        set
        {
            infoRRAField = value;
            RaisePropertyChanged(nameof(infoRRA));
        }
    }

    [XmlElement("ideEstabLot")]
    public List<S2399IdeEstabLot> ideEstabLot
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
public partial class S2399InfoRRA : ESocialBindableObject
{
    private TipoProcesso tpProcRRAField;
    private string nrProcRRAField;
    private string descRRAField;
    private decimal qtdMesesRRAField;
    private DetalhamentoDespJud despProcJudField;

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

    [XmlElement()]
    public DetalhamentoDespJud despProcJud
    {
        get => despProcJudField;
        set
        {
            despProcJudField = value;
            RaisePropertyChanged(nameof(despProcJud));
        }
    }
}

/// <exclude />
public partial class S2399IdeEstabLot : ESocialBindableObject
{
    private PersonalidadeJuridica tpInscField;
    private string nrInscField;
    private string codLotacaoField;
    private List<S2399DetVerbas> detVerbasField;
    private S2399InfoSimples infoSimplesField;

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

    [XmlElement("detVerbas")]
    public List<S2399DetVerbas> detVerbas
    {
        get => detVerbasField;
        set
        {
            detVerbasField = value;
            RaisePropertyChanged(nameof(detVerbas));
        }
    }

    public S2399InfoSimples infoSimples
    {
        get => infoSimplesField;
        set
        {
            infoSimplesField = value;
            RaisePropertyChanged(nameof(infoSimples));
        }
    }
}

/// <exclude />
public partial class S2399DetVerbas : ESocialBindableObject
{
    private string codRubrField;
    private string ideTabRubrField;
    private decimal? qtdRubrField;
    private decimal? fatorRubrField;
    private decimal vrRubrField;
    private sbyte? indApurIRField;
    private S2399DescFolha descFolhaField;

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

    public decimal? qtdRubr
    {
        get => qtdRubrField;
        set
        {
            qtdRubrField = value;
            RaisePropertyChanged(nameof(qtdRubr));
        }
    }

    public bool ShouldSerializeqtdRubr() => qtdRubr.HasValue;

    public decimal? fatorRubr
    {
        get => fatorRubrField;
        set
        {
            fatorRubrField = value;
            RaisePropertyChanged(nameof(fatorRubr));
        }
    }

    public bool ShouldSerializefatorRubr() => fatorRubr.HasValue;

    public decimal vrRubr
    {
        get => vrRubrField;
        set
        {
            vrRubrField = value;
            RaisePropertyChanged(nameof(vrRubr));
        }
    }

    public sbyte? indApurIR
    {
        get => indApurIRField;
        set
        {
            indApurIRField = value;
            RaisePropertyChanged(nameof(indApurIR));
        }
    }

    public bool ShouldSerializeindApurIR() => indApurIR.HasValue;

    public S2399DescFolha descFolha
    {
        get => descFolhaField;
        set
        {
            descFolhaField = value;
            RaisePropertyChanged(nameof(descFolha));
        }
    }
}

/// <exclude />
public partial class S2399DescFolha : ESocialBindableObject
{
    private sbyte tpDescField;
    private string instFinancField;
    private string nrDocField;
    private string observacaoField;

    public sbyte tpDesc
    {
        get => tpDescField;
        set
        {
            tpDescField = value;
            RaisePropertyChanged(nameof(tpDesc));
        }
    }

    public string instFinanc
    {
        get => instFinancField;
        set
        {
            instFinancField = value;
            RaisePropertyChanged(nameof(instFinanc));
        }
    }

    public string nrDoc
    {
        get => nrDocField;
        set
        {
            nrDocField = value;
            RaisePropertyChanged(nameof(nrDoc));
        }
    }

    public string observacao
    {
        get => observacaoField;
        set
        {
            observacaoField = value;
            RaisePropertyChanged(nameof(observacao));
        }
    }
}

/// <exclude />
public partial class S2399InfoSimples : ESocialBindableObject
{
    private sbyte indSimplesField;

    public sbyte indSimples
    {
        get => indSimplesField;
        set
        {
            indSimplesField = value;
            RaisePropertyChanged(nameof(indSimples));
        }
    }
}

/// <exclude />
public partial class S2399ProcJudTrab : ESocialBindableObject
{
    private TipoProcesso tpTribField;
    private string nrProcJudField;
    private string codSuspField;

    public TipoProcesso tpTrib
    {
        get => tpTribField;
        set
        {
            tpTribField = value;
            RaisePropertyChanged(nameof(tpTrib));
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
public partial class S2399InfoMV : ESocialBindableObject
{
    private sbyte indMVField;
    private List<S2399RemunOutrasEmpresas> remunOutrEmprField;

    public sbyte indMV
    {
        get => indMVField;
        set
        {
            indMVField = value;
            RaisePropertyChanged(nameof(indMV));
        }
    }

    [XmlElement("remunOutrEmpr")]
    public List<S2399RemunOutrasEmpresas> remunOutrEmpr
    {
        get => remunOutrEmprField;
        set
        {
            remunOutrEmprField = value;
            RaisePropertyChanged(nameof(remunOutrEmpr));
        }
    }
}

/// <exclude />
public partial class S2399RemunOutrasEmpresas : ESocialBindableObject
{
    private PersonalidadeJuridica tpInscField;
    private string nrInscField;
    private string codCategField;
    private decimal vlrRemunOEField;

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

    public string codCateg
    {
        get => codCategField;
        set
        {
            codCategField = value;
            RaisePropertyChanged(nameof(codCateg));
        }
    }

    public decimal vlrRemunOE
    {
        get => vlrRemunOEField;
        set
        {
            vlrRemunOEField = value;
            RaisePropertyChanged(nameof(vlrRemunOE));
        }
    }
}

/// <exclude />
public partial class S2399RemunAposTerm : ESocialBindableObject
{
    private IndicadorRemuneracaoTSV? indRemunField;
    private DateTime dtFimRemunField;

    public IndicadorRemuneracaoTSV? indRemun
    {
        get => indRemunField;
        set
        {
            indRemunField = value;
            RaisePropertyChanged(nameof(indRemun));
        }
    }

    public bool ShouldSerializeindRemun() => indRemun.HasValue;

    [XmlElement(DataType = "date")]
    public DateTime dtFimRemun
    {
        get => dtFimRemunField;
        set
        {
            dtFimRemunField = value;
            RaisePropertyChanged(nameof(dtFimRemun));
        }
    }
}
