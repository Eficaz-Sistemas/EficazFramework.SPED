namespace EficazFramework.SPED.Schemas.eSocial;

[Serializable()]
public class S1210 : Evento
{
    private EvtPgtos evtPgtosField;
    private string signatureField;

    [XmlElement(ElementName = "evtPgtos")]
    public EvtPgtos evtPgtos
    {
        get => evtPgtosField;
        set
        {
            evtPgtosField = value;
            RaisePropertyChanged(nameof(evtPgtos));
        }
    }

    [XmlElement(ElementName = "Signature", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public string Signature
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
        => evtPgtos.IdeEmpregador.nrInsc;

    public override void GeraEventoID()
        => evtPgtos.Id = string.Format("ID{0}{1}{2}", (int)(evtPgtos?.IdeEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtPgtos?.IdeEmpregador?.NumeroInscricaoTag() ?? "00000000000000", eSocialTimeStampUtils.GetTimeStampIDForEvent());


    // IXmlSignableDocument Members
    /// <exclude/>
    public override string TagToSign => Evento.root;
    /// <exclude/>
    public override string TagId => nameof(evtPgtos);
    /// <exclude/>
    public override bool EmptyURI => true;
    /// <exclude/>
    public override bool SignAsSHA256 => true;
}

public class EvtPgtos : ESocialBindableObject
{
    private string idField;
    private IdeEventoPeriodico ideEventoField;
    private Empregador ideEmpregadorField;
    private List<IdeBeneficario> ideBenefField;

    [XmlAttribute(AttributeName = "Id")]
    public string Id
    {
        get => idField;
        set
        {
            idField = value;
            RaisePropertyChanged(nameof(Id));
        }
    }

    [XmlElement(ElementName = "ideEvento")]
    public IdeEventoPeriodico IdeEvento
    {
        get => ideEventoField;
        set
        {
            ideEventoField = value;
            RaisePropertyChanged(nameof(IdeEvento));
        }
    }

    [XmlElement(ElementName = "ideEmpregador")]
    public Empregador IdeEmpregador
    {
        get => ideEmpregadorField;
        set
        {
            ideEmpregadorField = value;
            RaisePropertyChanged(nameof(IdeEmpregador));
        }
    }

    [XmlElement(ElementName = "ideBenef")]
    public List<IdeBeneficario> IdeBenef
    {
        get => ideBenefField;
        set
        {
            ideBenefField = value;
            RaisePropertyChanged(nameof(IdeBenef));
        }
    }
}

public class IdeBeneficario : ESocialBindableObject
{
    private string cpfBenefField;
    private List<InfoPagamento> infoPgtoField;
    private List<InfoIRetencao> infoIRComplemField;

    [XmlElement(ElementName = "cpfBenef")]
    public string CpfBenef
    {
        get => cpfBenefField;
        set
        {
            cpfBenefField = value;
            RaisePropertyChanged(nameof(CpfBenef));
        }
    }

    [XmlElement(ElementName = "infoPgto")]
    public List<InfoPagamento> InfoPgto
    {
        get => infoPgtoField;
        set
        {
            infoPgtoField = value;
            RaisePropertyChanged(nameof(InfoPgto));
        }
    }

    [XmlElement(ElementName = "infoIRComplem")]
    public List<InfoIRetencao> InfoIRComplem
    {
        get => infoIRComplemField;
        set
        {
            infoIRComplemField = value;
            RaisePropertyChanged(nameof(InfoIRComplem));
        }
    }
}

public class InfoPagamento : ESocialBindableObject
{
    private DateTime dtPgtoField;
    private TipoPagamento tpPgtoField;
    private string perRefField;
    private string ideDmDevField;
    private decimal vrLiqField;
    private string paisResidExtField;
    private InfoPagamentoExterior infoPgtoExtField;

    [XmlElement(ElementName = "dtPgto")]
    public DateTime DtPgto
    {
        get => dtPgtoField;
        set
        {
            dtPgtoField = value;
            RaisePropertyChanged(nameof(DtPgto));
        }
    }

    [XmlElement(ElementName = "tpPgto")]
    public TipoPagamento TpPgto
    {
        get => tpPgtoField;
        set
        {
            tpPgtoField = value;
            RaisePropertyChanged(nameof(TpPgto));
        }
    }

    /// <summary>
    /// Referência de Período de Apuração, no formato AAAA-MM, correspondente ao mês de competência do pagamento.
    /// </summary>
    [XmlElement(ElementName = "perRef")]
    public string PerRef
    {
        get => perRefField;
        set
        {
            perRefField = value;
            RaisePropertyChanged(nameof(PerRef));
        }
    }

    /// <summary>
    /// Identificador atribuído pela fonte pagadora para o demonstrativo de valores devidos ao trabalhador conforme definido em 
    /// S-1200, S-1202, S-1207, S-2299 ou S-2399.<br/><br/>
    ///  <b>Validação:</b> Deve ser um valor atribuído pela fonte pagadora em S-1200, S-1202, S-1207, S-2299 ou S-2399 no 
    ///  campo { ideDmDev }, obedecendo à relação:<br/><br/>
    ///  Se <b>tpPgto = [1]</b>, em S-1200;<br/>
    ///  Se <b>tpPgto = [2]</b>, em S-2299;<br/>
    ///  Se <b>tpPgto = [3]</b>, em S-2399;<br/>
    ///  Se <b>tpPgto = [4]</b>, em S-1202;<br/>
    ///  Se <b>tpPgto = [5]</b>, em S-1207.
    /// </summary>
    [XmlElement(ElementName = "ideDmDev")]
    public string IdeDmDev
    {
        get => ideDmDevField;
        set
        {
            ideDmDevField = value;
            RaisePropertyChanged(nameof(IdeDmDev));
        }
    }

    [XmlElement(ElementName = "vrLiq")]
    public decimal VrLiq
    {
        get => vrLiqField;
        set
        {
            vrLiqField = value;
            RaisePropertyChanged(nameof(VrLiq));
        }
    }

    [XmlElement(ElementName = "paisResidExt")]
    public string PaisResidExt
    {
        get => paisResidExtField;
        set
        {
            paisResidExtField = value;
            RaisePropertyChanged(nameof(PaisResidExt));
        }
    }

    [XmlElement(ElementName = "infoPgtoExt")]
    public InfoPagamentoExterior InfoPgtoExt
    {
        get => infoPgtoExtField;
        set
        {
            infoPgtoExtField = value;
            RaisePropertyChanged(nameof(InfoPgtoExt));
        }
    }
}

public class InfoPagamentoExterior : ESocialBindableObject
{
    private IndicativoNIF indNIFField;
    private string nifBenefField;
    private string frmTributField;
    private EnderecoExterior endExtField;

    [XmlElement(ElementName = "indNIF")]
    public IndicativoNIF IndNIF
    {
        get => indNIFField;
        set
        {
            indNIFField = value;
            RaisePropertyChanged(nameof(IndNIF));
        }
    }

    [XmlElement(ElementName = "nifBenef")]
    public string NifBenef
    {
        get => nifBenefField;
        set
        {
            nifBenefField = value;
            RaisePropertyChanged(nameof(NifBenef));
        }
    }

    [XmlElement(ElementName = "frmTribut")]
    public string FrmTribut
    {
        get => frmTributField;
        set
        {
            frmTributField = value;
            RaisePropertyChanged(nameof(FrmTribut));
        }
    }

    [XmlElement(ElementName = "endExt")]
    public EnderecoExterior EndExt
    {
        get => endExtField;
        set
        {
            endExtField = value;
            RaisePropertyChanged(nameof(EndExt));
        }
    }
}

public class InfoIRetencao : ESocialBindableObject
{
    private DateTime? dtLaudoField;
    private PeriodoAnteriorS1210 perAntField;
    private List<InfoDependente> infoDepField;
    private List<InfoIRCR> infoIRCRField;

    [XmlElement(ElementName = "dtLaudo")]
    public DateTime? DtLaudo
    {
        get => dtLaudoField;
        set
        {
            dtLaudoField = value;
            RaisePropertyChanged(nameof(DtLaudo));
        }
    }

    /// <summary>
    /// Identificação do evento S-1210 original e perRef cujas informações de infoIRComplem serão alteradas.
    /// </summary>
    [XmlElement(ElementName = "perAnt")]
    public PeriodoAnteriorS1210 PerAnt
    {
        get => perAntField;
        set
        {
            perAntField = value;
            RaisePropertyChanged(nameof(PerAnt));
        }
    }

    /// <summary>
    /// Informações de dependentes não cadastrados pelo S-2200/S-2205/S-2300/S-2400/S-2405. 
    /// </summary>
    [XmlElement(ElementName = "infoDep")]
    public List<InfoDependente> InfoDep
    {
        get => infoDepField;
        set
        {
            infoDepField = value;
            RaisePropertyChanged(nameof(InfoDep));
        }
    }

    /// <summary>
    /// Informações de Imposto de Renda, por Código de Receita - CR.
    /// </summary>
    [XmlElement(ElementName = "infoIRCR")]
    public List<InfoIRCR> InfoIRCR
    {
        get => infoIRCRField;
        set
        {
            infoIRCRField = value;
            RaisePropertyChanged(nameof(InfoIRCR));
        }
    }

}

public class PeriodoAnteriorS1210 : ESocialBindableObject
{
    private string perRefAjusteField;
    private string nrRec1210OrigField;

    /// <summary>
    /// Informar perApur do S-1210 cujo infoIRComplem será alterado.<br/>
    /// <b>Validação:</b> Deve corresponder a um mês do ano anterior (ano de perApur - 1)
    /// </summary>
    [XmlElement(ElementName = "perRefAjuste")]
    public string PerRefAjuste
    {
        get => perRefAjusteField;
        set
        {
            perRefAjusteField = value;
            RaisePropertyChanged(nameof(PerRefAjuste));
        }
    }

    /// <summary>
    /// Número do recibo do S-1210 original cujas informações de infoIRComplem serão alteradas.
    /// </summary>
    [XmlElement(ElementName = "nrRec1210Orig")]
    public string NrRec1210Orig
    {
        get => nrRec1210OrigField;
        set
        {
            nrRec1210OrigField = value;
            RaisePropertyChanged(nameof(NrRec1210Orig));
        }
    }
}

public class InfoDependente : ESocialBindableObject
{
    private string cpfDepField;
    private DateTime? dtNasctoField;
    private string nomeField;
    private SimNaoString depIRRFField;
    private string tpDepField;
    private string descrDepField;

    [XmlElement(ElementName = "cpfDep")]
    public string CpfDep
    {
        get => cpfDepField;
        set
        {
            cpfDepField = value;
            RaisePropertyChanged(nameof(CpfDep));
        }
    }

    [XmlElement(ElementName = "dtNascto")]
    public DateTime? DtNascto
    {
        get => dtNasctoField;
        set
        {
            dtNasctoField = value;
            RaisePropertyChanged(nameof(DtNascto));
        }
    }

    [XmlElement(ElementName = "nome")]
    public string Nome
    {
        get => nomeField;
        set
        {
            nomeField = value;
            RaisePropertyChanged(nameof(Nome));
        }
    }

    [XmlElement(ElementName = "depIRRF")]
    public SimNaoString DepIRRF
    {
        get => depIRRFField;
        set
        {
            depIRRFField = value;
            RaisePropertyChanged(nameof(DepIRRF));
        }
    }

    [XmlElement(ElementName = "tpDep")]
    public string TpDep
    {
        get => tpDepField;
        set
        {
            tpDepField = value;
            RaisePropertyChanged(nameof(TpDep));
        }
    }

    [XmlElement(ElementName = "descrDep")]
    public string DescrDep
    {
        get => descrDepField;
        set
        {
            descrDepField = value;
            RaisePropertyChanged(nameof(DescrDep));
        }
    }
}

public class InfoIRCR : ESocialBindableObject
{
    private string tpCRField;
    private List<DeducaoDependente> dedDepenField;
    private List<PensaoAlimenticia> penAlimField;
    private List<PrevidenciaComplementar> previdComplField;
    private List<InfoProcessoNaoRetencao> infoProcRetField;

    [XmlElement(ElementName = "tpCR")]
    public string TpCR
    {
        get => tpCRField;
        set
        {
            tpCRField = value;
            RaisePropertyChanged(nameof(TpCR));
        }
    }

    /// <summary>
    /// Dedução do rendimento tributável relativa a dependentes.
    /// </summary>
    [XmlElement(ElementName = "dedDepen")]
    public List<DeducaoDependente> DedDepen
    {
        get => dedDepenField;
        set
        {
            dedDepenField = value;
            RaisePropertyChanged(nameof(DedDepen));
        }
    }

    [XmlElement(ElementName = "penAlim")]
    public List<PensaoAlimenticia> PenAlim
    {
        get => penAlimField;
        set
        {
            penAlimField = value;
            RaisePropertyChanged(nameof(PenAlim));
        }
    }

    [XmlElement(ElementName = "previdCompl")]
    public List<PrevidenciaComplementar> PrevidCompl
    {
        get => previdComplField;
        set
        {
            previdComplField = value;
            RaisePropertyChanged(nameof(PrevidCompl));
        }
    }

    /// <summary>
    /// Informações de processos relacionados a não retenção de tributos ou a depósitos judiciais.
    /// </summary>
    [XmlElement(ElementName = "infoProcRet")]
    public List<InfoProcessoNaoRetencao> InfoProcRet
    {
        get => infoProcRetField;
        set
        {
            infoProcRetField = value;
            RaisePropertyChanged(nameof(InfoProcRet));
        }
    }
}

public class DeducaoDependente : ESocialBindableObject
{
    private TipoRendimento tpRendField;
    private string cpfDepField;
    private decimal vlrDedDepField;

    /// <summary>  
    /// Valores válidos: <br/><br/>  
    /// <b>11</b> - Remuneração mensal<br/>  
    /// <b>12</b> - 13º salário<br/>  
    /// <b>13</b> - Férias  
    /// </summary>  
    [XmlElement(ElementName = "tpRend")]
    public TipoRendimento TpRend
    {
        get => tpRendField;
        set
        {
            tpRendField = value;
            RaisePropertyChanged(nameof(TpRend));
        }
    }

    [XmlElement(ElementName = "cpfDep")]
    public string CpfDep
    {
        get => cpfDepField;
        set
        {
            cpfDepField = value;
            RaisePropertyChanged(nameof(CpfDep));
        }
    }

    [XmlElement(ElementName = "vlrDedDep")]
    public decimal VlrDedDep
    {
        get => vlrDedDepField;
        set
        {
            vlrDedDepField = value;
            RaisePropertyChanged(nameof(VlrDedDep));
        }
    }
}

public class PensaoAlimenticia : ESocialBindableObject
{
    private TipoRendimento tpRendField;
    private string cpfDepField;
    private decimal vlrDedPenAlimField;

    /// <summary>  
    /// Valores válidos: <br/><br/>  
    /// <b>11</b> - Remuneração mensal<br/>  
    /// <b>12</b> - 13º salário<br/>  
    /// <b>13</b> - Férias<br/>  
    /// <b>14</b> - PLR<br/>  
    /// <b>18</b> - RRA<br/>  
    /// <b>79</b> - Rendimento isento ou não tributável  
    /// </summary>  
    [XmlElement(ElementName = "tpRend")]
    public TipoRendimento TpRend
    {
        get => tpRendField;
        set
        {
            tpRendField = value;
            RaisePropertyChanged(nameof(TpRend));
        }
    }

    [XmlElement(ElementName = "cpfDep")]
    public string CpfDep
    {
        get => cpfDepField;
        set
        {
            cpfDepField = value;
            RaisePropertyChanged(nameof(CpfDep));
        }
    }

    [XmlElement(ElementName = "vlrDedPenAlim")]
    public decimal VlrDedPenAlim
    {
        get => vlrDedPenAlimField;
        set
        {
            vlrDedPenAlimField = value;
            RaisePropertyChanged(nameof(VlrDedPenAlim));
        }
    }
}

public class PrevidenciaComplementar : ESocialBindableObject
{
    private TipoPrevidenciaComplementar tpPrevField;
    private string cnpjEntidPCField;
    private decimal? vlrDedPCField;
    private decimal? vlrDedPC13Field;
    private decimal? vlrPatrocFunpField;
    private decimal? vlrPatrocFunp13Field;

    [XmlElement(ElementName = "tpPrev")]
    public TipoPrevidenciaComplementar TpPrev
    {
        get => tpPrevField;
        set
        {
            tpPrevField = value;
            RaisePropertyChanged(nameof(TpPrev));
        }
    }

    [XmlElement(ElementName = "cnpjEntidPC")]
    public string CnpjEntidPC
    {
        get => cnpjEntidPCField;
        set
        {
            cnpjEntidPCField = value;
            RaisePropertyChanged(nameof(CnpjEntidPC));
        }
    }

    [XmlElement(ElementName = "vlrDedPC")]
    public decimal? VlrDedPC
    {
        get => vlrDedPCField;
        set
        {
            vlrDedPCField = value;
            RaisePropertyChanged(nameof(VlrDedPC));
        }
    }
    public bool ShouldGenerateVlrDedPC() => VlrDedPC.HasValue;

    [XmlElement(ElementName = "vlrDedPC13")]
    public decimal? VlrDedPC13
    {
        get => vlrDedPC13Field;
        set
        {
            vlrDedPC13Field = value;
            RaisePropertyChanged(nameof(VlrDedPC13));
        }
    }
    public bool ShouldGenerateVlrDedPC13() => VlrDedPC13.HasValue;

    [XmlElement(ElementName = "vlrPatrocFunp")]
    public decimal? VlrPatrocFunp
    {
        get => vlrPatrocFunpField;
        set
        {
            vlrPatrocFunpField = value;
            RaisePropertyChanged(nameof(VlrPatrocFunp));
        }
    }
    public bool ShouldGenerateVlrPatrocFunp() => VlrPatrocFunp.HasValue;

    [XmlElement(ElementName = "vlrPatrocFunp13")]
    public decimal? VlrPatrocFunp13
    {
        get => vlrPatrocFunp13Field;
        set
        {
            vlrPatrocFunp13Field = value;
            RaisePropertyChanged(nameof(VlrPatrocFunp13));
        }
    }
    public bool ShouldGenerateVlrPatrocFunp13() => VlrPatrocFunp13.HasValue;
}

public class InfoProcessoNaoRetencao : ESocialBindableObject
{
    private TipoProcesso tpProcRetField;
    private string nrProcRetField;
    private string codSuspField;
    private List<InfoValoresProcesso> infoValoresField;

    [XmlElement(ElementName = "tpProcRet")]
    public TipoProcesso TpProcRet
    {
        get => tpProcRetField;
        set
        {
            tpProcRetField = value;
            RaisePropertyChanged(nameof(TpProcRet));
        }
    }

    [XmlElement(ElementName = "nrProcRet")]
    public string NrProcRet
    {
        get => nrProcRetField;
        set
        {
            nrProcRetField = value;
            RaisePropertyChanged(nameof(NrProcRet));
        }
    }

    [XmlElement(ElementName = "codSusp")]
    public string CodSusp
    {
        get => codSuspField;
        set
        {
            codSuspField = value;
            RaisePropertyChanged(nameof(CodSusp));
        }
    }

    [XmlElement(ElementName = "infoValores")]
    public List<InfoValoresProcesso> InfoValores
    {
        get => infoValoresField;
        set
        {
            infoValoresField = value;
            RaisePropertyChanged(nameof(InfoValores));
        }
    }
}

public class InfoValoresProcesso : ESocialBindableObject
{
    private IndicadorApuracao indApuracaoField;
    private decimal? vlrNRetidoField;
    private decimal? vlrDepJudField;
    private decimal? vlrCmpAnoCalField;
    private decimal? vlrCmpAnoAntField;
    private decimal? vlrRendSuspField;
    private List<DetalhamentoDeducao> dedSuspField;

    [XmlElement(ElementName = "indApuracao")]
    public IndicadorApuracao IndApuracao
    {
        get => indApuracaoField;
        set
        {
            indApuracaoField = value;
            RaisePropertyChanged(nameof(IndApuracao));
        }
    }

    [XmlElement(ElementName = "vlrNRetido")]
    public decimal? VlrNRetido
    {
        get => vlrNRetidoField;
        set
        {
            vlrNRetidoField = value;
            RaisePropertyChanged(nameof(VlrNRetido));
        }
    }
    public bool ShouldGenerateVlrNRetido() => VlrNRetido.HasValue;

    [XmlElement(ElementName = "vlrDepJud")]
    public decimal? VlrDepJud
    {
        get => vlrDepJudField;
        set
        {
            vlrDepJudField = value;
            RaisePropertyChanged(nameof(VlrDepJud));
        }
    }
    public bool ShouldGenerateVlrDepJud() => VlrDepJud.HasValue;

    [XmlElement(ElementName = "vlrCmpAnoCal")]
    public decimal? VlrCmpAnoCal
    {
        get => vlrCmpAnoCalField;
        set
        {
            vlrCmpAnoCalField = value;
            RaisePropertyChanged(nameof(VlrCmpAnoCal));
        }
    }
    public bool ShouldGenerateVlrCmpAnoCal() => VlrCmpAnoCal.HasValue;

    [XmlElement(ElementName = "vlrCmpAnoAnt")]
    public decimal? VlrCmpAnoAnt
    {
        get => vlrCmpAnoAntField;
        set
        {
            vlrCmpAnoAntField = value;
            RaisePropertyChanged(nameof(VlrCmpAnoAnt));
        }
    }
    public bool ShouldGenerateVlrCmpAnoAnt() => VlrCmpAnoAnt.HasValue;


    [XmlElement(ElementName = "vlrRendSusp")]
    public decimal? VlrRendSusp
    {
        get => vlrRendSuspField;
        set
        {
            vlrRendSuspField = value;
            RaisePropertyChanged(nameof(VlrRendSusp));
        }
    }
    public bool ShouldGenerateVlrRendSusp() => VlrRendSusp.HasValue;


    [XmlElement(ElementName = "dedSusp")]
    public List<DetalhamentoDeducao> DedSusp
    {
        get => dedSuspField;
        set
        {
            dedSuspField = value;
            RaisePropertyChanged(nameof(DedSusp));
        }
    }
}

public class DetalhamentoDeducao : ESocialBindableObject
{
    private TipoDeducao indTpDeducaoField;
    private decimal? vlrDedSuspField;
    private string cnpjEntidPCField;
    private decimal? vlrPatrocFunpField;
    private List<BeneficiarioPensao> benefPenField;

    [XmlElement(ElementName = "indTpDeducao")]
    public TipoDeducao IndTpDeducao
    {
        get => indTpDeducaoField;
        set
        {
            indTpDeducaoField = value;
            RaisePropertyChanged(nameof(IndTpDeducao));
        }
    }

    [XmlElement(ElementName = "vlrDedSusp")]
    public decimal? VlrDedSusp
    {
        get => vlrDedSuspField;
        set
        {
            vlrDedSuspField = value;
            RaisePropertyChanged(nameof(VlrDedSusp));
        }
    }
    public bool ShouldGenerateVlrDedSusp() => VlrDedSusp.HasValue;

    [XmlElement(ElementName = "cnpjEntidPC")]
    public string CnpjEntidPC
    {
        get => cnpjEntidPCField;
        set
        {
            cnpjEntidPCField = value;
            RaisePropertyChanged(nameof(CnpjEntidPC));
        }
    }

    [XmlElement(ElementName = "vlrPatrocFunp")]
    public decimal? VlrPatrocFunp
    {
        get => vlrPatrocFunpField;
        set
        {
            vlrPatrocFunpField = value;
            RaisePropertyChanged(nameof(VlrPatrocFunp));
        }
    }
    public bool ShouldGenerateVlrPatrocFunp() => VlrPatrocFunp.HasValue;

    [XmlElement(ElementName = "benefPen")]
    public List<BeneficiarioPensao> BenefPen
    {
        get => benefPenField;
        set
        {
            benefPenField = value;
            RaisePropertyChanged(nameof(BenefPen));
        }
    }
}

public class BeneficiarioPensao : ESocialBindableObject
{
    private string cpfDepField;
    private decimal vlrDepenSuspField;

    [XmlElement(ElementName = "cpfDep")]
    public string CpfDep
    {
        get => cpfDepField;
        set
        {
            cpfDepField = value;
            RaisePropertyChanged(nameof(CpfDep));
        }
    }

    [XmlElement(ElementName = "vlrDepenSusp")]
    public decimal VlrDepenSusp
    {
        get => vlrDepenSuspField;
        set
        {
            vlrDepenSuspField = value;
            RaisePropertyChanged(nameof(VlrDepenSusp));
        }
    }
}
