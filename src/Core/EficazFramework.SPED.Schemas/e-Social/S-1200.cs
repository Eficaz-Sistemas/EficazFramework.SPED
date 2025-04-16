using System.Security.Cryptography;

namespace EficazFramework.SPED.Schemas.eSocial;

[Serializable()]
public class S1200 : Evento
{
    private EvtRemun evtRemunField;
    private SignatureType signatureField;

    public EvtRemun evtRemun
    {
        get => evtRemunField;
        set
        {
            evtRemunField = value;
            RaisePropertyChanged(nameof(evtRemun));
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


    // Evento Members
    /// <exclude/>
    public override string ContribuinteCNPJ()
        => evtRemun.ideEmpregador.nrInsc;

    /// <exclude/>
    public override void GeraEventoID()
        => evtRemun.Id = string.Format("ID{0}{1}{2}", (int)(evtRemun?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtRemun?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000", eSocialTimeStampUtils.GetTimeStampIDForEvent());


    // IXmlSignableDocument Members
    /// <exclude/>
    public override string TagToSign => Evento.root;
    /// <exclude/>
    public override string TagId { get; }
    /// <exclude/>
    public override bool EmptyURI => true;
    /// <exclude/>
    public override bool SignAsSHA256 => true;
}

public class EvtRemun : ESocialBindableObject
{
    private IdeEventoPeriodico ideEventoField;
    private Empregador ideEmpregadorField;
    private Trabalhador ideTrabalhadorField;
    private List<DemonstracaoValorDevido> dmDevField;
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

    public Trabalhador ideTrabalhador
    {
        get => ideTrabalhadorField;
        set
        {
            ideTrabalhadorField = value;
            RaisePropertyChanged(nameof(ideTrabalhador));
        }
    }

    /// <summary>
    /// Identificação de cada um dos demonstrativos de valores devidos ao trabalhador.
    /// </summary>
    public List<DemonstracaoValorDevido> dmDev
    {
        get => dmDevField;
        set
        {
            dmDevField = value;
            RaisePropertyChanged(nameof(dmDev));
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

public class Trabalhador : ESocialBindableObject
{
    private string cpfTrab;
    private InfoMultiplosVinculos infoMV;
    private TrabalhadorInfoComplem infoComplem;
    private List<ProcessoJudTrabalhista> procJudTrab;
    private List<InforTrabIntermitente> infoInterm;

    [XmlElement(ElementName = "cpfTrab")]
    public string CpfTrab
    {
        get => cpfTrab;
        set
        {
            cpfTrab = value;
            RaisePropertyChanged(nameof(CpfTrab));
        }
    }

    [XmlElement(ElementName = "infoMV")]
    public InfoMultiplosVinculos InfoMV
    {
        get => infoMV;
        set
        {
            infoMV = value;
            RaisePropertyChanged(nameof(InfoMV));
        }
    }

    [XmlElement(ElementName = "infoComplem")]
    public TrabalhadorInfoComplem InfoComplem
    {
        get => infoComplem;
        set
        {
            infoComplem = value;
            RaisePropertyChanged(nameof(InfoComplem));
        }
    }

    [XmlElement(ElementName = "procJudTrab")]
    public List<ProcessoJudTrabalhista> ProcJudTrab
    {
        get => procJudTrab;
        set
        {
            procJudTrab = value;
            RaisePropertyChanged(nameof(ProcJudTrab));
        }
    }

    [XmlElement(ElementName = "infoInterm")]
    public List<InforTrabIntermitente> InfoInterm
    {
        get => infoInterm;
        set
        {
            infoInterm = value;
            RaisePropertyChanged(nameof(InfoInterm));
        }
    }
}

public class TrabalhadorInfoComplem : ESocialBindableObject
{
    private string nmTrab;
    private DateTime dtNascto;
    private TrabalhadorSucessaoVinc sucessaoVinc;

    [XmlElement(ElementName = "nmTrab")]
    public string NmTrab
    {
        get => nmTrab;
        set
        {
            nmTrab = value;
            RaisePropertyChanged(nameof(NmTrab));
        }
    }

    [XmlElement(ElementName = "dtNascto")]
    public DateTime DtNascto
    {
        get => dtNascto;
        set
        {
            dtNascto = value;
            RaisePropertyChanged(nameof(DtNascto));
        }
    }

    [XmlElement(ElementName = "sucessaoVinc")]
    public TrabalhadorSucessaoVinc SucessaoVinc
    {
        get => sucessaoVinc;
        set
        {
            sucessaoVinc = value;
            RaisePropertyChanged(nameof(SucessaoVinc));
        }
    }
}

public class TrabalhadorSucessaoVinc : ESocialBindableObject
{
    private PersonalidadeJuridica tpInsc;
    private string nrInsc;
    private string matricAnt;
    private DateTime dtAdm;
    private string observacao;

    [XmlElement(ElementName = "tpInsc")]
    public PersonalidadeJuridica TpInsc
    {
        get => tpInsc;
        set
        {
            tpInsc = value;
            RaisePropertyChanged(nameof(TpInsc));
        }
    }

    [XmlElement(ElementName = "nrInsc")]
    public string NrInsc
    {
        get => nrInsc;
        set
        {
            nrInsc = value;
            RaisePropertyChanged(nameof(NrInsc));
        }
    }

    [XmlElement(ElementName = "matricAnt")]
    public string MatricAnt
    {
        get => matricAnt;
        set
        {
            matricAnt = value;
            RaisePropertyChanged(nameof(MatricAnt));
        }
    }

    [XmlElement(ElementName = "dtAdm")]
    public DateTime DtAdm
    {
        get => dtAdm;
        set
        {
            dtAdm = value;
            RaisePropertyChanged(nameof(DtAdm));
        }
    }

    [XmlElement(ElementName = "observacao")]
    public string Observacao
    {
        get => observacao;
        set
        {
            observacao = value;
            RaisePropertyChanged(nameof(Observacao));
        }
    }
}

public class InfoMultiplosVinculos : ESocialBindableObject
{
    private int indMV = 3;
    private List<RemuneracaoOutrasEmpresas> remunOutrEmpr;

    /// <summary>
    /// <b>Valores válidos:</b><br/><br/>
    /// 1. O declarante aplica a(s) alíquota(s) de desconto do segurado sobre a remuneração por ele 
    /// informada (o percentual da(s) alíquota(s) será(ão) obtido(s) considerando a remuneração total 
    /// do trabalhador)<br/><br/>
    /// 2. O declarante aplica a(s) alíquota(s) de desconto do segurado sobre a diferença entre o 
    /// limite máximo do salário de contribuição e a remuneração de outra(s) empresa(s) para as quais 
    /// o trabalhador informou que houve o desconto<br/><br/>
    /// 3 - O declarante não realiza desconto do segurado, uma vez que houve desconto sobre o limite 
    /// máximo de salário de contribuição em outra(s) empresa(s)
    /// </summary>
    [XmlElement(ElementName = "indMV")]
    public int IndMV
    {
        get => indMV;
        set
        {
            indMV = value;
            RaisePropertyChanged(nameof(IndMV));
        }
    }

    [XmlElement(ElementName = "remunOutrEmpr")]
    public List<RemuneracaoOutrasEmpresas> RemunOutrEmpr
    {
        get => remunOutrEmpr;
        set
        {
            remunOutrEmpr = value;
            RaisePropertyChanged(nameof(RemunOutrEmpr));
        }
    }
}

public class RemuneracaoOutrasEmpresas : ESocialBindableObject
{
    private PersonalidadeJuridica tpInsc;
    private string nrInsc;
    private string codCateg;
    private decimal vlrRemunOE;

    [XmlElement(ElementName = "tpInsc")]
    public PersonalidadeJuridica TpInsc
    {
        get => tpInsc;
        set
        {
            tpInsc = value;
            RaisePropertyChanged(nameof(TpInsc));
        }
    }

    [XmlElement(ElementName = "nrInsc")]
    public string NrInsc
    {
        get => nrInsc;
        set
        {
            nrInsc = value;
            RaisePropertyChanged(nameof(NrInsc));
        }
    }

    [XmlElement(ElementName = "codCateg")]
    public string CodCateg
    {
        get => codCateg;
        set
        {
            codCateg = value;
            RaisePropertyChanged(nameof(CodCateg));
        }
    }

    [XmlElement(ElementName = "vlrRemunOE")]
    public decimal VlrRemunOE
    {
        get => vlrRemunOE;
        set
        {
            vlrRemunOE = value;
            RaisePropertyChanged(nameof(VlrRemunOE));
        }
    }
}

public class InforTrabIntermitente : ESocialBindableObject
{
    private int diaField = 0;
    public int dia
    {
        get => diaField;
        set
        {
            diaField = value;
            RaisePropertyChanged(nameof(dia));
        }
    }

    private string hrsTrabField;

    public string hrsTrab
    {
        get => hrsTrabField;
        set
        {
            hrsTrabField = value;
            RaisePropertyChanged(nameof(hrsTrab));
        }
    }
}

public class DemonstracaoValorDevido : ESocialBindableObject
{
    private string ideDmDev;
    private string codCateg;
    private string indRRA;
    private InfoRRA infoRRA;
    private InfoPerApur infoPerApur;
    private InfoPeriodoAnterior infoPerAnt;
    private InfoComplCont infoComplCont;

    /// <summary>
    /// Identificador atribuído pela empresa para o demonstrativo de valores devidos ao trabalhador. 
    /// O empregador pode preencher este campo utilizando-se de um identificador padrão para todos os 
    /// trabalhadores; no entanto, havendo mais de um demonstrativo relativo a uma mesma competência, 
    /// devem ser utilizados identificadores diferentes para cada um dos demonstrativos.
    /// </summary>
    [XmlElement(ElementName = "ideDmDev")]
    public string IdeDmDev
    {
        get => ideDmDev;
        set
        {
            ideDmDev = value;
            RaisePropertyChanged(nameof(IdeDmDev));
        }
    }

    [XmlElement(ElementName = "codCateg")]
    public string CodCateg
    {
        get => codCateg;
        set
        {
            codCateg = value;
            RaisePropertyChanged(nameof(CodCateg));
        }
    }

    /// <summary>
    /// Indicativo de Rendimentos Recebidos Acumuladamente - RRA.
    /// Somente preencher este campo se for um demonstrativo de RRA.<br/><br/>
    /// <b>Valores Válidos:</b><br/><br/>
    /// <b>S</b> - Sim
    /// </summary>
    [XmlElement(ElementName = "indRRA")]
    public string IndRRA
    {
        get => indRRA;
        set
        {
            indRRA = value;
            RaisePropertyChanged(nameof(IndRRA));
        }
    }

    public bool ShouldSerializeIndRRA() => 
        !string.IsNullOrEmpty(indRRA);


    [XmlElement(ElementName = "infoRRA")]
    public InfoRRA InfoRRA
    {
        get => infoRRA;
        set
        {
            infoRRA = value;
            RaisePropertyChanged(nameof(InfoRRA));
        }
    }

    [XmlElement(ElementName = "infoPerApur")]
    public InfoPerApur InfoPerApur
    {
        get => infoPerApur;
        set
        {
            infoPerApur = value;
            RaisePropertyChanged(nameof(InfoPerApur));
        }
    }

    [XmlElement(ElementName = "infoPerAnt")]
    public InfoPeriodoAnterior InfoPerAnt
    {
        get => infoPerAnt;
        set
        {
            infoPerAnt = value;
            RaisePropertyChanged(nameof(InfoPerAnt));
        }
    }

    [XmlElement(ElementName = "infoComplCont")]
    public InfoComplCont InfoComplCont
    {
        get => infoComplCont;
        set
        {
            infoComplCont = value;
            RaisePropertyChanged(nameof(InfoComplCont));
        }
    }
}

public class InfoRRA : ESocialBindableObject
{
    private TipoProcesso tpProcRRAField;
    private string nrProcRRAField;
    private string descRRAField;
    private int qtdMesesRRAField;
    private DetalhamentoDespJud despProcJudField;
    private Advogado ideAdvField;

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

    public int qtdMesesRRA
    {
        get => qtdMesesRRAField;
        set
        {
            qtdMesesRRAField = value;
            RaisePropertyChanged(nameof(qtdMesesRRA));
        }
    }

    public DetalhamentoDespJud despProcJud
    {
        get => despProcJudField;
        set
        {
            despProcJudField = value;
            RaisePropertyChanged(nameof(despProcJud));
        }
    }

    public Advogado ideAdv
    {
        get => ideAdvField;
        set
        {
            ideAdvField = value;
            RaisePropertyChanged(nameof(ideAdv));
        }
    }

}

public class InfoPerApur : ESocialBindableObject
{
    private List<IdeEstabelecimentoLotacao> ideEstabLot;

    [XmlElement(ElementName = "ideEstabLot")]
    public List<IdeEstabelecimentoLotacao> IdeEstabLot
    {
        get => ideEstabLot;
        set
        {
            ideEstabLot = value;
            RaisePropertyChanged(nameof(IdeEstabLot));
        }
    }
}

public class IdeEstabelecimentoLotacao : ESocialBindableObject
{
    private PersonalidadeJuridica tpInsc;
    private string nrInsc;
    private string codLotacao;
    private int qtdDiasAv = -1;
    private List<RemuneracaoPeriodoApuracao> remunPerApur;

    [XmlElement(ElementName = "tpInsc")]
    public PersonalidadeJuridica TpInsc
    {
        get => tpInsc;
        set
        {
            tpInsc = value;
            RaisePropertyChanged(nameof(TpInsc));
        }
    }

    [XmlElement(ElementName = "nrInsc")]
    public string NrInsc
    {
        get => nrInsc;
        set
        {
            nrInsc = value;
            RaisePropertyChanged(nameof(NrInsc));
        }
    }

    [XmlElement(ElementName = "codLotacao")]
    public string CodLotacao
    {
        get => codLotacao;
        set
        {
            codLotacao = value;
            RaisePropertyChanged(nameof(CodLotacao));
        }
    }

    [XmlElement(ElementName = "qtdDiasAv")]
    public int QtdDiasAv
    {
        get => qtdDiasAv;
        set
        {
            qtdDiasAv = value;
            RaisePropertyChanged(nameof(QtdDiasAv));
        }
    }

    public bool ShouldSerializeQtdDiasAv() =>
        QtdDiasAv > 0;


    [XmlElement(ElementName = "remunPerApur")]
    public List<RemuneracaoPeriodoApuracao> RemunPerApur
    {
        get => remunPerApur;
        set
        {
            remunPerApur = value;
            RaisePropertyChanged(nameof(RemunPerApur));
        }
    }
}

public class RemuneracaoPeriodoApuracao : ESocialBindableObject
{
    private string matricula;
    private IndicadorSubstSimples indSimples;
    private List<ItensRemuneracao> itensRemun;
    private InforAgenteNocivo infoAgNocivo;

    [XmlElement(ElementName = "matricula")]
    public string Matricula
    {
        get => matricula;
        set
        {
            matricula = value;
            RaisePropertyChanged(nameof(Matricula));
        }
    }

    [XmlElement(ElementName = "indSimples")]
    public IndicadorSubstSimples IndSimples
    {
        get => indSimples;
        set
        {
            indSimples = value;
            RaisePropertyChanged(nameof(IndSimples));
        }
    }

    public bool ShouldSerializeIndSimples() => 
        IndSimples != IndicadorSubstSimples.NA;


    [XmlElement(ElementName = "itensRemun")]
    public List<ItensRemuneracao> ItensRemun
    {
        get => itensRemun;
        set
        {
            itensRemun = value;
            RaisePropertyChanged(nameof(ItensRemun));
        }
    }

    [XmlElement(ElementName = "infoAgNocivo")]
    public InforAgenteNocivo InfoAgNocivo
    {
        get => infoAgNocivo;
        set
        {
            infoAgNocivo = value;
            RaisePropertyChanged(nameof(InfoAgNocivo));
        }
    }
}

public class ItensRemuneracao : ESocialBindableObject
{
    private string codRubr;
    private string ideTabRubr;
    private decimal qtdRubr;
    private decimal fatorRubr;
    private decimal vrRubr;
    private int indApurIR;
    private DescontoRemuneracao descFolhaField;

    [XmlElement(ElementName = "codRubr")]
    public string CodRubr
    {
        get => codRubr;
        set
        {
            codRubr = value;
            RaisePropertyChanged(nameof(CodRubr));
        }
    }

    [XmlElement(ElementName = "ideTabRubr")]
    public string IdeTabRubr
    {
        get => ideTabRubr;
        set
        {
            ideTabRubr = value;
            RaisePropertyChanged(nameof(IdeTabRubr));
        }
    }

    [XmlElement(ElementName = "qtdRubr")]
    public decimal QtdRubr
    {
        get => qtdRubr;
        set
        {
            qtdRubr = value;
            RaisePropertyChanged(nameof(QtdRubr));
        }
    }

    [XmlElement(ElementName = "fatorRubr")]
    public decimal FatorRubr
    {
        get => fatorRubr;
        set
        {
            fatorRubr = value;
            RaisePropertyChanged(nameof(FatorRubr));
        }
    }

    [XmlElement(ElementName = "vrRubr")]
    public decimal VrRubr
    {
        get => vrRubr;
        set
        {
            vrRubr = value;
            RaisePropertyChanged(nameof(VrRubr));
        }
    }

    /// <summary>
    /// <b>Valores válidos:</b><br/><br/>
    /// 0 - Normal(apuração sob a folha de pagamento declarada no eSocial)<br/>
    /// 1 - Situação especial de apuração de IR
    /// </summary>
    [XmlElement(ElementName = "indApurIR")]
    public int IndApurIR
    {
        get => indApurIR;
        set
        {
            indApurIR = value;
            RaisePropertyChanged(nameof(IndApurIR));
        }
    }

    public bool ShouldSerializeIndApurIR() => 
        indApurIR == 0 || indApurIR == 1;


    public DescontoRemuneracao descFolha
    {
        get => descFolhaField;
        set 
        {
            descFolhaField = value;
            RaisePropertyChanged(nameof(descFolha));
        }
    }

}

public class DescontoRemuneracao : ESocialBindableObject
{
    private TipoDescontoFolha tpDescField;
    private string instFinancField;
    private string nrDocField;
    private string observacaoField;

    [XmlElement(ElementName = "tpDesc")]
    public TipoDescontoFolha TpDesc
    {
        get => tpDescField;
        set
        {
            tpDescField = value;
            RaisePropertyChanged(nameof(TpDesc));
        }
    }

    [XmlElement(ElementName = "instFinanc")]
    public string InstFinanc
    {
        get => instFinancField;
        set
        {
            instFinancField = value;
            RaisePropertyChanged(nameof(InstFinanc));
        }
    }

    [XmlElement(ElementName = "nrDoc")]
    public string NrDoc
    {
        get => nrDocField;
        set
        {
            nrDocField = value;
            RaisePropertyChanged(nameof(NrDoc));
        }
    }

    [XmlElement(ElementName = "observacao")]
    public string Observacao
    {
        get => observacaoField;
        set
        {
            observacaoField = value;
            RaisePropertyChanged(nameof(Observacao));
        }
    }
}

public class InforAgenteNocivo : ESocialBindableObject
{
    private GrauExposicao grauExp;

    [XmlElement(ElementName = "grauExp")]
    public GrauExposicao GrauExp
    {
        get => grauExp;
        set
        {
            grauExp = value;
            RaisePropertyChanged(nameof(GrauExp));
        }
    }
}

public class InfoPeriodoAnterior : ESocialBindableObject
{
    private List<IdeAcordoColetivo> ideADC;

    [XmlElement(ElementName = "ideADC")]
    public List<IdeAcordoColetivo> IdeADC
    {
        get => ideADC;
        set
        {
            ideADC = value;
            RaisePropertyChanged(nameof(IdeADC));
        }
    }
}

public class IdeAcordoColetivo : ESocialBindableObject
{
    private DateTime dtAcConvField;
    private TipoAcordoColetivo tpAcConvField;
    private string dscField;
    private string remunSucField;
    private List<IdePeriodoDiferencas> idePeriodoField;

    /// <summary>
    /// Data da assinatura do acordo, convenção coletiva, sentença normativa ou da conversão da 
    /// licença saúde em acidente de trabalho.
    /// </summary>
    [XmlElement(ElementName = "dtAcConv")]
    public DateTime DtAcConv
    {
        get => dtAcConvField;
        set
        {
            dtAcConvField = value;
            RaisePropertyChanged(nameof(DtAcConv));
        }
    }

    [XmlElement(ElementName = "tpAcConv")]
    public TipoAcordoColetivo TpAcConv
    {
        get => tpAcConvField;
        set
        {
            tpAcConvField = value;
            RaisePropertyChanged(nameof(TpAcConv));
        }
    }

    [XmlElement(ElementName = "dsc")]
    public string Descricao
    {
        get => dscField;
        set
        {
            dscField = value;
            RaisePropertyChanged(nameof(Descricao));
        }
    }

    [XmlElement(ElementName = "remunSuc")]
    public string RemunSuc
    {
        get => remunSucField;
        set
        {
            remunSucField = value;
            RaisePropertyChanged(nameof(RemunSuc));
        }
    }

    [XmlElement(ElementName = "idePeriodo")]
    public List<IdePeriodoDiferencas> IdePeriodo
    {
        get => idePeriodoField;
        set
        {
            idePeriodoField = value;
            RaisePropertyChanged(nameof(IdePeriodo));
        }
    }
}

public class IdePeriodoDiferencas : ESocialBindableObject
{
    private string perRef;
    private List<IdeEstabelecimentoLotacao> ideEstabLot;

    /// <summary>
    /// Informar o período ao qual se refere o complemento de remuneração, no formato AAAA-MM.
    /// </summary>
    [XmlElement(ElementName = "perRef")]
    public string PerRef
    {
        get => perRef;
        set
        {
            perRef = value;
            RaisePropertyChanged(nameof(PerRef));
        }
    }

    [XmlElement(ElementName = "ideEstabLot")]
    public List<IdeEstabelecimentoLotacao> IdeEstabLot
    {
        get => ideEstabLot;
        set
        {
            ideEstabLot = value;
            RaisePropertyChanged(nameof(IdeEstabLot));
        }
    }
}

public class InfoComplCont : ESocialBindableObject
{
    private string codCBO;
    private NaturezaAtividade natAtividade;
    private int qtdDiasTrab;

    [XmlElement(ElementName = "codCBO")]
    public string CodCBO
    {
        get => codCBO;
        set
        {
            codCBO = value;
            RaisePropertyChanged(nameof(CodCBO));
        }
    }

    [XmlElement(ElementName = "natAtividade")]
    public NaturezaAtividade NatAtividade
    {
        get => natAtividade;
        set
        {
            natAtividade = value;
            RaisePropertyChanged(nameof(NatAtividade));
        }
    }

    [XmlElement(ElementName = "qtdDiasTrab")]
    public int QtdDiasTrab
    {
        get => qtdDiasTrab;
        set
        {
            qtdDiasTrab = value;
            RaisePropertyChanged(nameof(QtdDiasTrab));
        }
    }
}
