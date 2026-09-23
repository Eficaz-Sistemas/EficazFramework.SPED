using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EficazFramework.SPED.Schemas.eSocial;

/// <summary>
/// S-2299 - Desligamento
/// </summary>
/// <example>
/// ```csharp
/// evento.evtDeslig = new S2299EvtDeslig()
/// {
///     ideEvento = new S2299IdeEvento()
///     {
///         tpAmb = Ambiente.ProducaoRestrita_DadosReais,
///         procEmi = EmissorEvento.AppEmpregador,
///         verProc = "1.0",
///         indRetif = IndicadorRetificacao.Original
///     },
///     ideEmpregador = new Empregador()
///     {
///         tpInsc = PersonalidadeJuridica.CNPJ,
///         nrInsc = cnpjCpf.Substring(0, 8)
///     },
///     ideVinculo = new S2299IdeVinculo()
///     {
///         cpfTrab = "12345678901",
///         matricula = "123456"
///     },
///     infoDeslig = new S2299InfoDeslig()
///     {
///         mtvDeslig = "01",
///         dtDeslig = new DateTime(2024, 1, 31),
///         dtAvPrv = new DateTime(2023, 12, 31),
///         indPagtoAPI = SimNaoString.Nao,
///         dtProjFimAPI = new DateTime(2024, 2, 28),
///         pensAlim = 1,
///         percAliment = 15.5m,
///         vrAlim = 500m,
///         nrProcTrab = "12345678901234567890",
///         indPDV = SimNaoString.Sim,
///         infoInterm = new System.Collections.Generic.List<S2299InfoInterm>
///         {
///             new S2299InfoInterm { dia = 10 }
///         },
///         observacoes = new System.Collections.Generic.List<S2299Observacao>
///         {
///             new S2299Observacao { Value = "Observacao Teste" }
///         },
///         sucessaoVinc = new S2299SucessaoVinc
///         {
///             tpInsc = TipoInscricao.CNPJ,
///             nrInsc = "12345678000199"
///         },
///         transfTit = new S2299TransfTit
///         {
///             cpfSubstituto = "12345678901",
///             dtNascto = new DateTime(1980, 1, 1)
///         },
///         mudancaCPF = new S2299MudancaCPF
///         {
///             novoCPF = "12345678902"
///         },
///         remunAposDeslig = new S2299RemunAposDeslig
///         {
///             indRemun = 1,
///             dtFimRemun = new DateTime(2024, 12, 31)
///         },
///         consigFGTS = new System.Collections.Generic.List<S2299ConsigFGTS>
///         {
///             new S2299ConsigFGTS
///             {
///                 insConsig = "123456",
///                 nrContr = "1234"
///             }
///         },
///         verbasResc = new S2299VerbasResc
///         {
///             dmDev = new System.Collections.Generic.List<S2299DmDev>
///             {
///                 new S2299DmDev
///                 {
///                     ideDmDev = "IDE1",
///                     indRRA = SimNaoString.Sim,
///                     notAFT = "1234567890123",
///                     infoPerApur = new S2299InfoPerApur
///                     {
///                         ideEstabLot = new System.Collections.Generic.List<S2299IdeEstabLot>
///                         {
///                             new S2299IdeEstabLot
///                             {
///                                 tpInsc = TipoInscricao.CNPJ,
///                                 nrInsc = "12345678000199",
///                                 codLotacao = "LOT1",
///                                 detVerbas = new System.Collections.Generic.List<S2299DetVerbasDescFolha>
///                                 {
///                                     new S2299DetVerbasDescFolha
///                                     {
///                                         codRubr = "RUB1",
///                                         ideTabRubr = "TAB1",
///                                         qtdRubr = 1m,
///                                         fatorRubr = 1m,
///                                         vrRubr = 100m,
///                                         indApurIR = 0,
///                                         descFolha = new S2299DescFolha
///                                         {
///                                             tpDesc = 1,
///                                             instFinanc = "123",
///                                             nrDoc = "DOC1",
///                                             observacao = "Obs"
///                                         }
///                                     }
///                                 }
///                             }
///                         }
///                     }
///                 }
///             },
///             infoMV = new S2299InfoMV
///             {
///                 indMV = 1,
///                 remunOutrEmpr = new System.Collections.Generic.List<S2299RemunOutrasEmpresas>
///                 {
///                     new S2299RemunOutrasEmpresas { tpInsc = TipoInscricao.CNPJ, nrInsc = "12345678000199", codCateg = "101", vlrRemunOE = 1000m }
///                 }
///             },
///             procCS = new S2299ProcCS
///             {
///                 nrProcJud = "12345678901234567890"
///             }
///         }
///     }
/// };
/// ```
/// </example>
[Serializable()]
public partial class S2299 : Evento
{
    private S2299EvtDeslig evtDesligField;
    private SignatureType signatureField;

    /// <remarks/>
    public S2299EvtDeslig evtDeslig
    {
        get => evtDesligField;
        set
        {
            evtDesligField = value;
            RaisePropertyChanged(nameof(evtDeslig));
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

    /// <exclude/>
    public override void GeraEventoID()
        => evtDesligField.Id = string.Format("ID{0}{1}{2}", 
            (int)(evtDesligField?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ), 
            evtDesligField?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000", 
            eSocialTimeStampUtils.GetTimeStampIDForEvent());

    /// <exclude/>
    public override string ContribuinteCNPJ()
        => evtDesligField?.ideEmpregador?.nrInsc;

    /// <exclude/>
    public override string TagToSign => Evento.root;
    
    /// <exclude/>
    public override string TagId => nameof(evtDeslig);
    
    /// <exclude/>
    public override bool EmptyURI => true;
    
    /// <exclude/>
    public override bool SignAsSHA256 => true;
}

/// <exclude />
public partial class S2299EvtDeslig : ESocialBindableObject
{
    private S2299IdeEvento ideEventoField;
    private Empregador ideEmpregadorField;
    private S2299IdeVinculo ideVinculoField;
    private S2299InfoDeslig infoDesligField;
    private string idField;

    public S2299IdeEvento ideEvento
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

    public S2299IdeVinculo ideVinculo
    {
        get => ideVinculoField;
        set
        {
            ideVinculoField = value;
            RaisePropertyChanged(nameof(ideVinculo));
        }
    }

    public S2299InfoDeslig infoDeslig
    {
        get => infoDesligField;
        set
        {
            infoDesligField = value;
            RaisePropertyChanged(nameof(infoDeslig));
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
public partial class S2299IdeEvento : ESocialBindableObject
{
    private IndicadorGuia? indGuiaField;
    private IndicadorRetificacao indRetifField = IndicadorRetificacao.Original;
    private string nrReciboField;
    private Ambiente tpAmbField = Ambiente.Producao;
    private EmissorEvento procEmiField = EmissorEvento.AppEmpregador;
    private string verProcField;

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
public partial class S2299IdeVinculo : ESocialBindableObject
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
public partial class S2299InfoDeslig : ESocialBindableObject
{
    private string mtvDesligField;
    private DateTime dtDesligField;
    private DateTime? dtAvPrvField;
    private SimNaoString indPagtoAPIField;
    private DateTime? dtProjFimAPIField;
    private sbyte? pensAlimField;
    private decimal? percAlimentField;
    private decimal? vrAlimField;
    private string nrProcTrabField;
    private SimNaoString? indPDVField;
    private System.Collections.Generic.List<S2299InfoInterm> infoIntermField;
    private System.Collections.Generic.List<S2299Observacao> observacoesField;
    private S2299SucessaoVinc sucessaoVincField;
    private S2299TransfTit transfTitField;
    private S2299MudancaCPF mudancaCPFField;
    private S2299VerbasResc verbasRescField;
    private S2299RemunAposDeslig remunAposDesligField;
    private System.Collections.Generic.List<S2299ConsigFGTS> consigFGTSField;

    public string mtvDeslig
    {
        get => mtvDesligField;
        set
        {
            mtvDesligField = value;
            RaisePropertyChanged(nameof(mtvDeslig));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime dtDeslig
    {
        get => dtDesligField;
        set
        {
            dtDesligField = value;
            RaisePropertyChanged(nameof(dtDeslig));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime? dtAvPrv
    {
        get => dtAvPrvField;
        set
        {
            dtAvPrvField = value;
            RaisePropertyChanged(nameof(dtAvPrv));
        }
    }

    public bool ShouldSerializedtAvPrv() => dtAvPrv.HasValue;

    public SimNaoString indPagtoAPI
    {
        get => indPagtoAPIField;
        set
        {
            indPagtoAPIField = value;
            RaisePropertyChanged(nameof(indPagtoAPI));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime? dtProjFimAPI
    {
        get => dtProjFimAPIField;
        set
        {
            dtProjFimAPIField = value;
            RaisePropertyChanged(nameof(dtProjFimAPI));
        }
    }

    public bool ShouldSerializedtProjFimAPI() => dtProjFimAPI.HasValue;

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

    public SimNaoString? indPDV
    {
        get => indPDVField;
        set
        {
            indPDVField = value;
            RaisePropertyChanged(nameof(indPDV));
        }
    }

    public bool ShouldSerializeindPDV() => indPDV.HasValue;

    [XmlElement("infoInterm")]
    public System.Collections.Generic.List<S2299InfoInterm> infoInterm
    {
        get => infoIntermField;
        set
        {
            infoIntermField = value;
            RaisePropertyChanged(nameof(infoInterm));
        }
    }

    [XmlArray("observacoes")]
    [XmlArrayItem("observacao", IsNullable = false)]
    public System.Collections.Generic.List<S2299Observacao> observacoes
    {
        get => observacoesField;
        set
        {
            observacoesField = value;
            RaisePropertyChanged(nameof(observacoes));
        }
    }

    public S2299SucessaoVinc sucessaoVinc
    {
        get => sucessaoVincField;
        set
        {
            sucessaoVincField = value;
            RaisePropertyChanged(nameof(sucessaoVinc));
        }
    }

    public S2299TransfTit transfTit
    {
        get => transfTitField;
        set
        {
            transfTitField = value;
            RaisePropertyChanged(nameof(transfTit));
        }
    }

    public S2299MudancaCPF mudancaCPF
    {
        get => mudancaCPFField;
        set
        {
            mudancaCPFField = value;
            RaisePropertyChanged(nameof(mudancaCPF));
        }
    }

    public S2299VerbasResc verbasResc
    {
        get => verbasRescField;
        set
        {
            verbasRescField = value;
            RaisePropertyChanged(nameof(verbasResc));
        }
    }

    public S2299RemunAposDeslig remunAposDeslig
    {
        get => remunAposDesligField;
        set
        {
            remunAposDesligField = value;
            RaisePropertyChanged(nameof(remunAposDeslig));
        }
    }

    [XmlElement("consigFGTS")]
    public System.Collections.Generic.List<S2299ConsigFGTS> consigFGTS
    {
        get => consigFGTSField;
        set
        {
            consigFGTSField = value;
            RaisePropertyChanged(nameof(consigFGTS));
        }
    }
}

/// <exclude />
public partial class S2299InfoInterm : ESocialBindableObject
{
    private byte diaField;

    public byte dia
    {
        get => diaField;
        set
        {
            diaField = value;
            RaisePropertyChanged(nameof(dia));
        }
    }
}

/// <exclude />
public partial class S2299Observacao : ESocialBindableObject
{
    private string observacaoField;

    [XmlText()]
    public string Value
    {
        get => observacaoField;
        set
        {
            observacaoField = value;
            RaisePropertyChanged(nameof(Value));
        }
    }
}

/// <exclude />
public partial class S2299SucessaoVinc : ESocialBindableObject
{
    private TipoInscricao tpInscField;
    private string nrInscField;

    public TipoInscricao tpInsc
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
}

/// <exclude />
public partial class S2299TransfTit : ESocialBindableObject
{
    private string cpfSubstitutoField;
    private DateTime dtNasctoField;

    public string cpfSubstituto
    {
        get => cpfSubstitutoField;
        set
        {
            cpfSubstitutoField = value;
            RaisePropertyChanged(nameof(cpfSubstituto));
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
}

/// <exclude />
public partial class S2299MudancaCPF : ESocialBindableObject
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
public partial class S2299VerbasResc : ESocialBindableObject
{
    private System.Collections.Generic.List<S2299DmDev> dmDevField;
    private System.Collections.Generic.List<ProcessoJudTrabalhista> procJudTrabField;
    private S2299InfoMV infoMVField;
    private S2299ProcCS procCSField;

    [XmlElement("dmDev")]
    public System.Collections.Generic.List<S2299DmDev> dmDev
    {
        get => dmDevField;
        set
        {
            dmDevField = value;
            RaisePropertyChanged(nameof(dmDev));
        }
    }

    [XmlElement("procJudTrab")]
    public System.Collections.Generic.List<ProcessoJudTrabalhista> procJudTrab
    {
        get => procJudTrabField;
        set
        {
            procJudTrabField = value;
            RaisePropertyChanged(nameof(procJudTrab));
        }
    }

    public S2299InfoMV infoMV
    {
        get => infoMVField;
        set
        {
            infoMVField = value;
            RaisePropertyChanged(nameof(infoMV));
        }
    }

    public S2299ProcCS procCS
    {
        get => procCSField;
        set
        {
            procCSField = value;
            RaisePropertyChanged(nameof(procCS));
        }
    }
}

/// <exclude />
public partial class S2299DmDev : ESocialBindableObject
{
    private string ideDmDevField;
    private SimNaoString? indRRAField;
    private string notAFTField;
    private S2299InfoRRA infoRRAField;
    private S2299InfoPerApur infoPerApurField;
    private S2299InfoPerAnt infoPerAntField;

    public string ideDmDev
    {
        get => ideDmDevField;
        set
        {
            ideDmDevField = value;
            RaisePropertyChanged(nameof(ideDmDev));
        }
    }

    public SimNaoString? indRRA
    {
        get => indRRAField;
        set
        {
            indRRAField = value;
            RaisePropertyChanged(nameof(indRRA));
        }
    }

    public bool ShouldSerializeindRRA() => indRRA.HasValue;

    public string notAFT
    {
        get => notAFTField;
        set
        {
            notAFTField = value;
            RaisePropertyChanged(nameof(notAFT));
        }
    }

    public S2299InfoRRA infoRRA
    {
        get => infoRRAField;
        set
        {
            infoRRAField = value;
            RaisePropertyChanged(nameof(infoRRA));
        }
    }

    public S2299InfoPerApur infoPerApur
    {
        get => infoPerApurField;
        set
        {
            infoPerApurField = value;
            RaisePropertyChanged(nameof(infoPerApur));
        }
    }

    public S2299InfoPerAnt infoPerAnt
    {
        get => infoPerAntField;
        set
        {
            infoPerAntField = value;
            RaisePropertyChanged(nameof(infoPerAnt));
        }
    }
}

/// <exclude />
public partial class S2299InfoRRA : ESocialBindableObject
{
    private TipoProcesso tpProcRRAField;
    private string nrProcRRAField;
    private string descRRAField;
    private decimal qtdMesesRRAField;
    private DetalhamentoDespJud despesasField;

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

    public DetalhamentoDespJud despesas
    {
        get => despesasField;
        set
        {
            despesasField = value;
            RaisePropertyChanged(nameof(despesas));
        }
    }
}

/// <exclude />
public partial class S2299InfoPerApur : ESocialBindableObject
{
    private System.Collections.Generic.List<S2299IdeEstabLot> ideEstabLotField;

    [XmlElement("ideEstabLot")]
    public System.Collections.Generic.List<S2299IdeEstabLot> ideEstabLot
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
public partial class S2299InfoPerAnt : ESocialBindableObject
{
    private System.Collections.Generic.List<S2299IdeADC> ideADCField;

    [XmlElement("ideADC")]
    public System.Collections.Generic.List<S2299IdeADC> ideADC
    {
        get => ideADCField;
        set
        {
            ideADCField = value;
            RaisePropertyChanged(nameof(ideADC));
        }
    }
}

/// <exclude />
public partial class S2299IdeADC : ESocialBindableObject
{
    private DateTime? dtAcConvField;
    private string tpAcConvField;
    private string dscField;
    private System.Collections.Generic.List<S2299IdePeriodo> idePeriodoField;

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

    public bool ShouldSerializedtAcConv() => dtAcConv.HasValue;

    public string tpAcConv
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

    [XmlElement("idePeriodo")]
    public System.Collections.Generic.List<S2299IdePeriodo> idePeriodo
    {
        get => idePeriodoField;
        set
        {
            idePeriodoField = value;
            RaisePropertyChanged(nameof(idePeriodo));
        }
    }
}

/// <exclude />
public partial class S2299IdePeriodo : ESocialBindableObject
{
    private string perRefField;
    private System.Collections.Generic.List<S2299IdeEstabLotInfoPerAnt> ideEstabLotField;

    public string perRef
    {
        get => perRefField;
        set
        {
            perRefField = value;
            RaisePropertyChanged(nameof(perRef));
        }
    }

    [XmlElement("ideEstabLot")]
    public System.Collections.Generic.List<S2299IdeEstabLotInfoPerAnt> ideEstabLot
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
public partial class S2299IdeEstabLot : ESocialBindableObject
{
    private TipoInscricao tpInscField;
    private string nrInscField;
    private string codLotacaoField;
    private System.Collections.Generic.List<S2299DetVerbasDescFolha> detVerbasField;
    private S2299InfoAgNocivo infoAgNocivoField;
    private S2299InfoSimples infoSimplesField;

    public TipoInscricao tpInsc
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
    public System.Collections.Generic.List<S2299DetVerbasDescFolha> detVerbas
    {
        get => detVerbasField;
        set
        {
            detVerbasField = value;
            RaisePropertyChanged(nameof(detVerbas));
        }
    }

    public S2299InfoAgNocivo infoAgNocivo
    {
        get => infoAgNocivoField;
        set
        {
            infoAgNocivoField = value;
            RaisePropertyChanged(nameof(infoAgNocivo));
        }
    }

    public S2299InfoSimples infoSimples
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
public partial class S2299IdeEstabLotInfoPerAnt : ESocialBindableObject
{
    private TipoInscricao tpInscField;
    private string nrInscField;
    private string codLotacaoField;
    private System.Collections.Generic.List<S2299DetVerbas> detVerbasField;
    private S2299InfoAgNocivo infoAgNocivoField;
    private S2299InfoSimples infoSimplesField;

    public TipoInscricao tpInsc
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
    public System.Collections.Generic.List<S2299DetVerbas> detVerbas
    {
        get => detVerbasField;
        set
        {
            detVerbasField = value;
            RaisePropertyChanged(nameof(detVerbas));
        }
    }

    public S2299InfoAgNocivo infoAgNocivo
    {
        get => infoAgNocivoField;
        set
        {
            infoAgNocivoField = value;
            RaisePropertyChanged(nameof(infoAgNocivo));
        }
    }

    public S2299InfoSimples infoSimples
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
public partial class S2299DetVerbas : ESocialBindableObject
{
    private string codRubrField;
    private string ideTabRubrField;
    private decimal? qtdRubrField;
    private decimal? fatorRubrField;
    private decimal vrRubrField;
    private sbyte? indApurIRField;

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
}

/// <exclude />
public partial class S2299DetVerbasDescFolha : S2299DetVerbas
{
    private S2299DescFolha descFolhaField;

    public S2299DescFolha descFolha
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
public partial class S2299DescFolha : ESocialBindableObject
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
public partial class S2299InfoAgNocivo : ESocialBindableObject
{
    private sbyte grauExpField;

    public sbyte grauExp
    {
        get => grauExpField;
        set
        {
            grauExpField = value;
            RaisePropertyChanged(nameof(grauExp));
        }
    }
}

/// <exclude />
public partial class S2299InfoSimples : ESocialBindableObject
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
public partial class S2299InfoMV : ESocialBindableObject
{
    private sbyte indMVField;
    private System.Collections.Generic.List<S2299RemunOutrasEmpresas> remunOutrEmpField;

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
    public System.Collections.Generic.List<S2299RemunOutrasEmpresas> remunOutrEmp
    {
        get => remunOutrEmpField;
        set
        {
            remunOutrEmpField = value;
            RaisePropertyChanged(nameof(remunOutrEmp));
        }
    }
}

/// <exclude />
public partial class S2299RemunOutrasEmpresas : ESocialBindableObject
{
    private TipoInscricao tpInscField;
    private string nrInscField;
    private string codCategField;
    private decimal vlrRemunOEField;

    public TipoInscricao tpInsc
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
public partial class S2299ProcCS : ESocialBindableObject
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
public partial class S2299RemunAposDeslig : ESocialBindableObject
{
    private sbyte? indRemunField;
    private DateTime dtFimRemunField;

    public sbyte? indRemun
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

/// <exclude />
public partial class S2299ConsigFGTS : ESocialBindableObject
{
    private string insConsigField;
    private string nrContrField;

    public string insConsig
    {
        get => insConsigField;
        set
        {
            insConsigField = value;
            RaisePropertyChanged(nameof(insConsig));
        }
    }

    public string nrContr
    {
        get => nrContrField;
        set
        {
            nrContrField = value;
            RaisePropertyChanged(nameof(nrContr));
        }
    }
}
