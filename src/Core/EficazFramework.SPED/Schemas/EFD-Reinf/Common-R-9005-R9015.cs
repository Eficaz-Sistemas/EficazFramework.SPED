namespace EficazFramework.SPED.Schemas.EFD_Reinf;

/// <summary>
/// Identificacao do estabelecimento com seus totais
/// </summary>
public partial class TotalSerieR4000 : EfdReinfBindableObject
{
    private TotalizadorR4000[] totApurMenField;
    private TotalizadorR4000[] totApurQuiField;
    private TotalizadorR4000[] totApurDecField;
    private TotalizadorR4000[] totApurSemField;
    private TotalizadorR4000[] totApurDiaField;


    /// <summary>
    /// Bases e tributos com periodo de apuracao mensal
    /// </summary>
    [XmlElement("totApurMen")]
    public TotalizadorR4000[] TotalApuracaoMensal
    {
        get => totApurMenField;
        set
        {
            totApurMenField = value;
            RaisePropertyChanged(nameof(TotalApuracaoMensal));
        }
    }

    /// <summary>
    /// Bases e tributos com periodo de apuracao quinzenal
    /// </summary>
    [XmlElement("totApurQui")]
    public TotalizadorR4000[] TotalApuracaoQuinzenal
    {
        get => totApurQuiField;
        set
        {
            totApurQuiField = value;
            RaisePropertyChanged(nameof(TotalApuracaoQuinzenal));
        }
    }

    /// <summary>
    /// Bases e tributos com periodo de apuracao decendial
    /// </summary>
    [XmlElement("totApurDec")]
    public TotalizadorR4000[] TotalApuracaoDecendial
    {
        get => totApurDecField;
        set
        {
            totApurDecField = value;
            RaisePropertyChanged(nameof(TotalApuracaoDecendial));
        }
    }

    /// <summary>
    /// Bases e tributos com periodo de apuracao semanal
    /// </summary>
    [XmlElement("totApurSem")]
    public TotalizadorR4000[] TotalApuracaoSemanal
    {
        get => totApurSemField;
        set
        {
            totApurSemField = value;
            RaisePropertyChanged(nameof(TotalApuracaoSemanal));
        }
    }

    /// <summary>
    /// Bases e tributos com periodo de apuracao diária
    /// </summary>
    [XmlElement("totApurDia")]
    public TotalizadorR4000[] TotalApuracaoDiaria
    {
        get => totApurDiaField;
        set
        {
            totApurDiaField = value;
            RaisePropertyChanged(nameof(TotalApuracaoDiaria));
        }
    }
}


/// <summary>
/// Bases e tributos com periodo de apuracao da série R-4000
/// </summary>
public partial class TotalizadorR4000 : EfdReinfBindableObject
{
    private ushort perApuField = 0;
    [XmlIgnore()]
    public PeriodoR9005Fracao PeriodoFracao { get; set; } = PeriodoR9005Fracao.Mensal;
    [XmlIgnore()]
    public PeriodoR9005CodigoRecolhimento PeriodoCR { get; set; } = PeriodoR9005CodigoRecolhimento.Mensal;
    [XmlIgnore()]
    public PeriodoR9005Apuracao PeriodoApuracao { get; set; } = PeriodoR9005Apuracao.Mensal;
    [XmlIgnore()]
    public PeriodoR9005BaseCR PeriodoVlrBaseCR { get; set; } = PeriodoR9005BaseCR.Mensal;
    [XmlIgnore()]
    public PeriodoR9005BaseCR PeriodoVlrBaseCRSusp { get; set; } = PeriodoR9005BaseCR.MensalSuspenso;

    private string CRField;
    private string vlrBaseCRField;
    private string vlrCRAquisSuspField;
    private string natRendField;
    private ApuracaoTributoR4000 totApurTribField;

    /// <summary>
    /// Periodo de apuracao
    /// </summary>
    [XmlChoiceIdentifier("PeriodoFracao")]
    [XmlElement("perApurQui")]
    [XmlElement("perApurDec")]
    [XmlElement("perApurSem")]
    [XmlElement("perApurDia")]
    public ushort FracaoPeriodo
    {
        get => perApuField;
        set
        {
            perApuField = value;
            this.RaisePropertyChanged(nameof(FracaoPeriodo));
        }
    }

    /// <summary>
    /// Codigo de Receita - CR
    /// </summary>
    [XmlChoiceIdentifier("PeriodoCR")]
    [XmlElement("CRMen")]
    [XmlElement("CRQui")]
    [XmlElement("CRDec")]
    [XmlElement("CRSem")]
    [XmlElement("CRDia")]
    public string CodigoReceita
    {
        get => CRField;
        set
        {
            CRField = value;
            this.RaisePropertyChanged(nameof(CodigoReceita));
        }
    }

    /// <summary>
    /// Valor da base do tributo com apuracao mensal
    /// </summary>
    [XmlChoiceIdentifier("PeriodoVlrBaseCR")]
    [XmlElement("vlrBaseCRMen")]
    [XmlElement("vlrBaseCRQui")]
    [XmlElement("vlrBaseCRDec")]
    [XmlElement("vlrBaseCRSem")]
    [XmlElement("vlrBaseCRDia")]
    public string ValorBaseCR
    {
        get => vlrBaseCRField;
        set
        {
            vlrBaseCRField = value;
            this.RaisePropertyChanged(nameof(ValorBaseCR));
        }
    }

    /// <summary>
    /// Valor da base do tributo de apuracao mensal suspenso
    /// </summary>
    [XmlChoiceIdentifier("PeriodoVlrBaseCRSusp")]
    [XmlElement("vlrBaseCRMenSusp")]
    [XmlElement("vlrBaseCRQuiSusp")]
    [XmlElement("vlrBaseCRDecSusp")]
    [XmlElement("vlrBaseCRSemSusp")]
    [XmlElement("vlrBaseCRDiaSusp")]
    public string ValorBaseCRSusp
    {
        get => vlrCRAquisSuspField;
        set
        {
            vlrCRAquisSuspField = value;
            this.RaisePropertyChanged(nameof(ValorBaseCRSusp));
        }
    }

    /// <summary>
    /// Natureza do Rendimento
    /// </summary>
    public string natRend
    {
        get => natRendField;
        set
        {
            natRendField = value;
            RaisePropertyChanged(nameof(natRend));
        }
    }

    /// <summary>
    /// Apuracao e retencao dos tributos
    /// </summary>
    [XmlChoiceIdentifier("PeriodoApuracao")]
    [XmlElement("totApurTribMen")]
    [XmlElement("totApurTribQui")]
    [XmlElement("totApurTribDec")]
    [XmlElement("totApurTribSem")]
    [XmlElement("totApurTribDia")]
    public ApuracaoTributoR4000 TotalApuracaoTributo
    {
        get => totApurTribField;
        set
        {
            totApurTribField = value;
            RaisePropertyChanged("totApurTrib");
        }
    }
}


/// <summary>
/// Apuracao e retencao dos tributos com periodo de apuracao da série R-4000
/// </summary>
public partial class ApuracaoTributoR4000 : EfdReinfBindableObject
{
    [XmlIgnore()]
    public PeriodoR9005VlrCR PeriodoVlrCRInf { get; set; } = PeriodoR9005VlrCR.MensalInformado;
    [XmlIgnore()]
    public PeriodoR9005VlrCR PeriodoVlrCRCalc { get; set; } = PeriodoR9005VlrCR.MensalCalculado;
    [XmlIgnore()]
    public PeriodoR9005VlrCR PeriodoVlrCRSuspInf { get; set; } = PeriodoR9005VlrCR.MensalInfomadoSuspenso;
    [XmlIgnore()]
    public PeriodoR9005VlrCR PeriodoVlrCRSuspCalc { get; set; } = PeriodoR9005VlrCR.MensalCalculadoSuspenso;

    private string vlrCRInfField;
    private string vlrCRCalcField;
    private string vlrCRSuspInfField;
    private string vlrCRSuspCalcField;

    /// <summary>
    /// Valor informado do tributo retido
    /// </summary>
    [XmlChoiceIdentifier("PeriodoVlrCRInf")]
    [XmlElement("vlrCRMenInf")]
    [XmlElement("vlrCRQuiInf")]
    [XmlElement("vlrCRDecInf")]
    [XmlElement("vlrCRSemInf")]
    [XmlElement("vlrCRDiaInf")]
    public string ValorCRInformado
    {
        get => vlrCRInfField;
        set
        {
            vlrCRInfField = value;
            this.RaisePropertyChanged(nameof(ValorCRInformado));
        }
    }

    /// <summary>
    /// Valor calculado do tributo retido
    /// </summary>
    [XmlChoiceIdentifier("PeriodoVlrCRCalc")]
    [XmlElement(ElementName = "vlrCRMenCalc")]
    [XmlElement(ElementName = "vlrCRQuiCalc")]
    [XmlElement(ElementName = "vlrCRDecCalc")]
    [XmlElement(ElementName = "vlrCRSemCalc")]
    [XmlElement(ElementName = "vlrCRDiaCalc")]
    public string ValorCRCalculado
    {
        get => vlrCRCalcField;
        set
        {
            vlrCRCalcField = value;
            this.RaisePropertyChanged(nameof(ValorCRCalculado));
        }
    }

    /// <summary>
    /// Valor informado do tributo suspenso
    /// </summary>
    [XmlChoiceIdentifier("PeriodoVlrCRSuspInf")]
    [XmlElement(ElementName = "vlrCRMenSuspInf")]
    [XmlElement(ElementName = "vlrCRQuiSuspInf")]
    [XmlElement(ElementName = "vlrCRDecSuspInf")]
    [XmlElement(ElementName = "vlrCRSemSuspInf")]
    [XmlElement(ElementName = "vlrCRDiaSuspInf")]
    public string ValorCRSuspInformado
    {
        get => vlrCRSuspInfField;
        set
        {
            vlrCRSuspInfField = value;
            this.RaisePropertyChanged(nameof(ValorCRSuspInformado));
        }
    }

    /// <summary>
    /// Valor calculado do tributo suspenso
    /// </summary>
    [XmlChoiceIdentifier("PeriodoVlrCRSuspCalc")]
    [XmlElement(ElementName = "vlrCRMenSuspCalc")]
    [XmlElement(ElementName = "vlrCRQuiSuspCalc")]
    [XmlElement(ElementName = "vlrCRDecSuspCalc")]
    [XmlElement(ElementName = "vlrCRSemSuspCalc")]
    [XmlElement(ElementName = "vlrCRDiaSuspCalc")]
    public string ValorCRSuspCalculado
    {
        get => vlrCRSuspCalcField;
        set
        {
            vlrCRSuspCalcField = value;
            this.RaisePropertyChanged(nameof(ValorCRSuspCalculado));
        }
    }
}


/// <summary>
/// Retornado no evento R-9015
/// </summary>
public partial class ApuracaoTributoR4000Fechamento : ApuracaoTributoR4000
{
    private ushort perApuField = 0;
    private string CRField;
    private string vlrCRDCTFField;
    private string vlrCRSuspDCTFField;
    private string natRendField;


    [XmlIgnore()]
    public PeriodoR9005Fracao PeriodoFracao { get; set; } = PeriodoR9005Fracao.Mensal;
    /// <summary>
    /// Periodo de apuracao
    /// </summary>
    [XmlChoiceIdentifier("PeriodoFracao")]
    [XmlElement("perApurQui")]
    [XmlElement("perApurDec")]
    [XmlElement("perApurSem")]
    [XmlElement("perApurDia")]
    public ushort FracaoPeriodo
    {
        get => perApuField;
        set
        {
            perApuField = value;
            this.RaisePropertyChanged(nameof(FracaoPeriodo));
        }
    }

    [XmlIgnore()]
    public PeriodoR9005CodigoRecolhimento PeriodoCR { get; set; } = PeriodoR9005CodigoRecolhimento.Mensal;
    /// <summary>
    /// Codigo de Receita - CR
    /// </summary>
    [XmlChoiceIdentifier("PeriodoCR")]
    [XmlElement("CRMen")]
    [XmlElement("CRQui")]
    [XmlElement("CRDec")]
    [XmlElement("CRSem")]
    [XmlElement("CRDia")]
    public string CodigoReceita
    {
        get => CRField;
        set
        {
            CRField = value;
            this.RaisePropertyChanged(nameof(CodigoReceita));
        }
    }

    [XmlIgnore()]
    public PeriodoR9005VlrCR PeriodoVlrCRDCTF { get; set; } = PeriodoR9005VlrCR.MensalDctf;
    /// <summary>
    /// Valor informado do tributo retido
    /// </summary>
    [XmlChoiceIdentifier("PeriodoVlrCRDCTF")]
    [XmlElement("vlrCRMenDCTF")]
    [XmlElement("vlrCRQuiDCTF")]
    [XmlElement("vlrCRDecDCTF")]
    [XmlElement("vlrCRSemDCTF")]
    [XmlElement("vlrCRDiaDCTF")]
    public string ValorCrDctf
    {
        get => vlrCRDCTFField;
        set
        {
            vlrCRDCTFField = value;
            this.RaisePropertyChanged(nameof(ValorCrDctf));
        }
    }

    [XmlIgnore()]
    public PeriodoR9005VlrCR PeriodoVlrCRSuspDCTF { get; set; } = PeriodoR9005VlrCR.MensalDctfSuspenso;
    /// <summary>
    /// Valor informado do tributo retido
    /// </summary>
    [XmlChoiceIdentifier("PeriodoVlrCRSuspDCTF")]
    [XmlElement("vlrCRMenSuspDCTF")]
    [XmlElement("vlrCRQuiSuspDCTF")]
    [XmlElement("vlrCRDecSuspDCTF")]
    [XmlElement("vlrCRSemSuspDCTF")]
    [XmlElement("vlrCRDiaSuspDCTF")]
    public string ValorCrSuspensoDctf
    {
        get => vlrCRSuspDCTFField;
        set
        {
            vlrCRSuspDCTFField = value;
            this.RaisePropertyChanged(nameof(ValorCrSuspensoDctf));
        }
    }

    /// <summary>
    /// Natureza do Rendimento
    /// </summary>
    public string natRend
    {
        get => natRendField;
        set
        {
            natRendField = value;
            RaisePropertyChanged(nameof(natRend));
        }
    }
}


[XmlType(IncludeInSchema = false)]
public enum PeriodoR9005Fracao
{
    [XmlEnum("perApurMen")]
    Mensal = 0,
    [XmlEnum("perApurQui")]
    Quinzenal = 1,
    [XmlEnum("perApurDec")]
    Decendial = 2,
    [XmlEnum("perApurSem")]
    Semanal = 3,
    [XmlEnum("perApurDia")]
    Diario = 4
}


[XmlType(IncludeInSchema = false)]
public enum PeriodoR9005CodigoRecolhimento
{
    [XmlEnum("CRMen")]
    Mensal = 0,
    [XmlEnum("CRQui")]
    Quinzenal = 1,
    [XmlEnum("CRDec")]
    Decendial = 2,
    [XmlEnum("CRSem")]
    Semanal = 3,
    [XmlEnum("CRDia")]
    Diario = 4
}


[XmlType(IncludeInSchema = false)]
public enum PeriodoR9005Apuracao
{
    [XmlEnum("totApurTribMen")]
    Mensal = 0,
    [XmlEnum("totApurTribQui")]
    Quinzenal = 1,
    [XmlEnum("totApurTribDec")]
    Decencial = 2,
    [XmlEnum("totApurTribSem")]
    Semanal = 3,
    [XmlEnum("totApurTribDia")]
    Diario = 4
}


[XmlType(IncludeInSchema = false)]
public enum PeriodoR9005BaseCR
{
    [XmlEnum("vlrBaseCRMen")]
    Mensal = 0,
    [XmlEnum("vlrBaseCRQui")]
    Quinzenal = 1,
    [XmlEnum("vlrBaseCRDec")]
    Decencial = 2,
    [XmlEnum("vlrBaseCRSem")]
    Semanal = 3,
    [XmlEnum("vlrBaseCRDia")]
    Diario = 4,

    [XmlEnum("vlrBaseCRMenSusp")]
    MensalSuspenso = 10,
    [XmlEnum("vlrBaseCRQuiSusp")]
    QuinzenalSuspenso = 11,
    [XmlEnum("vlrBaseCRDecSusp")]
    DecencialSuspenso = 12,
    [XmlEnum("vlrBaseCRSemSusp")]
    SemanalSuspenso = 13,
    [XmlEnum("vlrBaseCRDiaSusp")]
    DiarioSuspenso = 14
}


[XmlType(IncludeInSchema = false)]
public enum PeriodoR9005VlrCR
{
    [XmlEnum("vlrCRMenInf")]
    MensalInformado = 0,
    [XmlEnum("vlrCRQuiInf")]
    QuinzenalInformado = 1,
    [XmlEnum("vlrCRDecInf")]
    DecencialInformado = 2,
    [XmlEnum("vlrCRSemInf")]
    SemanalInformado = 3,
    [XmlEnum("vlrCRDiaInf")]
    DiarioInformado = 4,

    [XmlEnum("vlrCRMenCalc")]
    MensalCalculado = 10,
    [XmlEnum("vlrCRQuiCalc")]
    QuinzenalCalculado = 11,
    [XmlEnum("vlrCRDecCalc")]
    DecencialCalculado = 12,
    [XmlEnum("vlrCRSemCalc")]
    SemanalCalculado = 13,
    [XmlEnum("vlrCRDiaCalc")]
    DiarioCalculado = 14,

    [XmlEnum("vlrCRMenDCTF")]
    MensalDctf = 20,
    [XmlEnum("vlrCRQuiDCTF")]
    QuinzenalDctf = 21,
    [XmlEnum("vlrCRDecDCTF")]
    DecencialDctf = 22,
    [XmlEnum("vlrCRSemDCTF")]
    SemanalDctf = 23,
    [XmlEnum("vlrCRDiaDCTF")]
    DiarioDctf = 24,


    [XmlEnum("vlrCRMenSuspInf")]
    MensalInfomadoSuspenso = 30,
    [XmlEnum("vlrCRQuiSuspInf")]
    QuinzenalInformadoSuspenso = 31,
    [XmlEnum("vlrCRDecSuspInf")]
    DecencialInformadoSuspenso = 32,
    [XmlEnum("vlrCRSemSuspInf")]
    SemanalInformadoSuspenso = 33,
    [XmlEnum("vlrCRDiaSuspInf")]
    DiarioInformadoSuspenso = 34,

    [XmlEnum("vlrCRMenSuspCalc")]
    MensalCalculadoSuspenso = 40,
    [XmlEnum("vlrCRQuiSuspCalc")]
    QuinzenalCalculadoSuspenso = 41,
    [XmlEnum("vlrCRDecSuspCalc")]
    DecencialCalculadoSuspenso = 42,
    [XmlEnum("vlrCRSemSuspCalc")]
    SemanalCalculadoSuspenso = 43,
    [XmlEnum("vlrCRDiaSuspCalc")]
    DiarioCalculadoSuspenso = 44,

    [XmlEnum("vlrCRMenSuspDCTF")]
    MensalDctfSuspenso = 50,
    [XmlEnum("vlrCRQuiSuspDCTF")]
    QuinzenalDctfSuspenso = 51,
    [XmlEnum("vlrCRDecSuspDCTF")]
    DecencialDctfSuspenso = 52,
    [XmlEnum("vlrCRSemSuspDCTF")]
    SemanalDctfSuspenso = 53,
    [XmlEnum("vlrCRDiaSuspDCTF")]
    DiarioDctfSuspenso = 54
}