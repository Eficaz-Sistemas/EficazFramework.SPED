using System.Runtime.CompilerServices;

// REFERE-SE AOS TIPOS BÁSICOS COMUNS PARA TODOS OS SCHEMAS DO SPED
// RELATIVOS AOS TRIBUTOS DA REFORMA TRIBUTÁRIA: IBS, CBS E IS
// DFeTiposBasicos_v1.00.xsd

namespace EficazFramework.SPED.Schemas.DFeBase;

/// <summary>
/// Classe base para notificação de mudanças nas propriedades.
/// </summary>
public abstract class IbsCbsBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null!)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

// Enums

/// <summary>
/// Código Situação Tributária do IBS/CBS
/// </summary>
public enum Cst
{
    [XmlEnum("000")]
    CST_000,
    [XmlEnum("100")]
    CST_100,
    [XmlEnum("200")]
    CST_200,
    [XmlEnum("300")]
    CST_300,
    [XmlEnum("400")]
    CST_400,
    [XmlEnum("500")]
    CST_500,
    [XmlEnum("600")]
    CST_600,
    [XmlEnum("700")]
    CST_700,
    [XmlEnum("800")]
    CST_800,
    [XmlEnum("900")]
    CST_900
    // Adicione outros conforme necessário
}

public enum TipoOperacaoCompraGov
{
    [XmlEnum("1")]
    Fornecimento = 1,
    [XmlEnum("2")]
    RecebimentoPagamento = 2
}

public enum EnteGovernamental
{
    [XmlEnum("1")]
    Uniao = 1,
    [XmlEnum("2")]
    Estado = 2,
    [XmlEnum("3")]
    DistritoFederal = 3,
    [XmlEnum("4")]
    Municipio = 4
}

public enum TipoCreditoPresIbsZfm
{
    [XmlEnum("0")]
    SemCreditoPresumido = 0,
    [XmlEnum("1")]
    BensConsumoFinal = 1,
    [XmlEnum("2")]
    BensCapital = 2,
    [XmlEnum("3")]
    BensIntermediarios = 3,
    [XmlEnum("4")]
    InformaticaOutros = 4
}

// Tipos Complexos

public class TributacaoNfCom : IbsCbsBase
{
    private Cst _cst;
    private string? _cClassTrib;
    private IbsCbs? _gIBSCBS;

    public Cst CST { get => _cst; set { _cst = value; OnPropertyChanged(); } }
    public string? cClassTrib { get => _cClassTrib; set { _cClassTrib = value; OnPropertyChanged(); } }
    public IbsCbs? gIBSCBS { get => _gIBSCBS; set { _gIBSCBS = value; OnPropertyChanged(); } }
}

public class TributacaoNf3e : IbsCbsBase
{
    private Cst _cst;
    private string? _cClassTrib;
    private IbsCbs? _gIBSCBS;

    public Cst CST { get => _cst; set { _cst = value; OnPropertyChanged(); } }
    public string? cClassTrib { get => _cClassTrib; set { _cClassTrib = value; OnPropertyChanged(); } }
    public IbsCbs? gIBSCBS { get => _gIBSCBS; set { _gIBSCBS = value; OnPropertyChanged(); } }
}

public class TributacaoCte : IbsCbsBase
{
    private Cst _cst;
    private string? _cClassTrib;
    private IbsCbs? _gIBSCBS;

    public Cst CST { get => _cst; set { _cst = value; OnPropertyChanged(); } }
    public string? cClassTrib { get => _cClassTrib; set { _cClassTrib = value; OnPropertyChanged(); } }
    public IbsCbs? gIBSCBS { get => _gIBSCBS; set { _gIBSCBS = value; OnPropertyChanged(); } }
}

public class TributacaoBpe : IbsCbsBase
{
    private Cst _cst;
    private string? _cClassTrib;
    private IbsCbs? _gIBSCBS;

    public Cst CST { get => _cst; set { _cst = value; OnPropertyChanged(); } }
    public string? cClassTrib { get => _cClassTrib; set { _cClassTrib = value; OnPropertyChanged(); } }
    public IbsCbs? gIBSCBS { get => _gIBSCBS; set { _gIBSCBS = value; OnPropertyChanged(); } }
}

public class TributacaoNfce : IbsCbsBase
{
    private Cst _cst;
    private string? _cClassTrib;
    private IbsCbs? _gIBSCBS;
    private TMonofasia? _gIBSCBSMono;

    public Cst CST { get => _cst; set { _cst = value; OnPropertyChanged(); } }
    public string? cClassTrib { get => _cClassTrib; set { _cClassTrib = value; OnPropertyChanged(); } }
    public IbsCbs? gIBSCBS { get => _gIBSCBS; set { _gIBSCBS = value; OnPropertyChanged(); } }
    public TMonofasia? gIBSCBSMono { get => _gIBSCBSMono; set { _gIBSCBSMono = value; OnPropertyChanged(); } }
}

public class TributacaoNfe : IbsCbsBase
{
    private Cst _cst;
    private string? _cClassTrib;
    private IbsCbs? _gIBSCBS;
    private TMonofasia? _gIBSCBSMono;
    private TransferenciaCredito? _gTransfCred;
    private CreditoPresIbsZfm? _gCredPresIBSZFM;

    public Cst CST { get => _cst; set { _cst = value; OnPropertyChanged(); } }
    public string? cClassTrib { get => _cClassTrib; set { _cClassTrib = value; OnPropertyChanged(); } }
    public IbsCbs? gIBSCBS { get => _gIBSCBS; set { _gIBSCBS = value; OnPropertyChanged(); } }
    public TMonofasia? gIBSCBSMono { get => _gIBSCBSMono; set { _gIBSCBSMono = value; OnPropertyChanged(); } }
    public TransferenciaCredito? gTransfCred { get => _gTransfCred; set { _gTransfCred = value; OnPropertyChanged(); } }
    public CreditoPresIbsZfm? gCredPresIBSZFM { get => _gCredPresIBSZFM; set { _gCredPresIBSZFM = value; OnPropertyChanged(); } }
}

public class ImpostoSeletivo : IbsCbsBase
{
    private Cst _cstis;
    private string? _cClassTribIS;
    private decimal _vBCIS;
    private decimal _pIS;
    private decimal? _pISEspec;
    private string? _uTrib;
    private decimal? _qTrib;
    private decimal _vIS;

    public Cst CSTIS { get => _cstis; set { _cstis = value; OnPropertyChanged(); } }
    public string? cClassTribIS { get => _cClassTribIS; set { _cClassTribIS = value; OnPropertyChanged(); } }
    public decimal vBCIS { get => _vBCIS; set { _vBCIS = value; OnPropertyChanged(); } }
    public decimal pIS { get => _pIS; set { _pIS = value; OnPropertyChanged(); } }
    public decimal? pISEspec { get => _pISEspec; set { _pISEspec = value; OnPropertyChanged(); } }
    public string? uTrib { get => _uTrib; set { _uTrib = value; OnPropertyChanged(); } }
    public decimal? qTrib { get => _qTrib; set { _qTrib = value; OnPropertyChanged(); } }
    public decimal vIS { get => _vIS; set { _vIS = value; OnPropertyChanged(); } }
}

public class TotaisImpostoSeletivo : IbsCbsBase
{
    private decimal _vIS;
    public decimal vIS { get => _vIS; set { _vIS = value; OnPropertyChanged(); } }
}

public class TotaisIbsCbs : IbsCbsBase
{
    private decimal _vBCIBSCBS;
    private TotalIbs? _gIBS;
    private TotalCbs? _gCBS;

    public decimal vBCIBSCBS { get => _vBCIBSCBS; set { _vBCIBSCBS = value; OnPropertyChanged(); } }
    public TotalIbs? gIBS { get => _gIBS; set { _gIBS = value; OnPropertyChanged(); } }
    public TotalCbs? gCBS { get => _gCBS; set { _gCBS = value; OnPropertyChanged(); } }
}

public class TotaisIbsCbsMonofasico : IbsCbsBase
{
    private decimal _vBCIBSCBS;
    private TotalIbs? _gIBS;
    private TotalCbs? _gCBS;
    private Monofasico? _gMono;

    public decimal vBCIBSCBS { get => _vBCIBSCBS; set { _vBCIBSCBS = value; OnPropertyChanged(); } }
    public TotalIbs? gIBS { get => _gIBS; set { _gIBS = value; OnPropertyChanged(); } }
    public TotalCbs? gCBS { get => _gCBS; set { _gCBS = value; OnPropertyChanged(); } }
    public Monofasico? gMono { get => _gMono; set { _gMono = value; OnPropertyChanged(); } }
}

public class Monofasico : IbsCbsBase
{
    private decimal _vIBSMono;
    private decimal _vCBSMono;
    private decimal _vIBSMonoReten;
    private decimal _vCBSMonoReten;
    private decimal _vIBSMonoRet;
    private decimal _vCBSMonoRet;

    public decimal vIBSMono { get => _vIBSMono; set { _vIBSMono = value; OnPropertyChanged(); } }
    public decimal vCBSMono { get => _vCBSMono; set { _vCBSMono = value; OnPropertyChanged(); } }
    public decimal vIBSMonoReten { get => _vIBSMonoReten; set { _vIBSMonoReten = value; OnPropertyChanged(); } }
    public decimal vCBSMonoReten { get => _vCBSMonoReten; set { _vCBSMonoReten = value; OnPropertyChanged(); } }
    public decimal vIBSMonoRet { get => _vIBSMonoRet; set { _vIBSMonoRet = value; OnPropertyChanged(); } }
    public decimal vCBSMonoRet { get => _vCBSMonoRet; set { _vCBSMonoRet = value; OnPropertyChanged(); } }
}

public class TotalIbs : IbsCbsBase
{
    private TotalIbsEstadual? _gIBSUF;
    private TotalIbsMunicipal? _gIBSMun;
    private decimal _vIBS;
    private decimal _vCredPres;
    private decimal _vCredPresCondSus;

    public TotalIbsEstadual? gIBSUF { get => _gIBSUF; set { _gIBSUF = value; OnPropertyChanged(); } }
    public TotalIbsMunicipal? gIBSMun { get => _gIBSMun; set { _gIBSMun = value; OnPropertyChanged(); } }
    public decimal vIBS { get => _vIBS; set { _vIBS = value; OnPropertyChanged(); } }
    public decimal vCredPres { get => _vCredPres; set { _vCredPres = value; OnPropertyChanged(); } }
    public decimal vCredPresCondSus { get => _vCredPresCondSus; set { _vCredPresCondSus = value; OnPropertyChanged(); } }
}

public class TotalIbsEstadual : IbsCbsBase
{
    private decimal _vDif;
    private decimal _vDevTrib;
    private decimal _vIBSUF;

    public decimal vDif { get => _vDif; set { _vDif = value; OnPropertyChanged(); } }
    public decimal vDevTrib { get => _vDevTrib; set { _vDevTrib = value; OnPropertyChanged(); } }
    public decimal vIBSUF { get => _vIBSUF; set { _vIBSUF = value; OnPropertyChanged(); } }
}

public class TotalIbsMunicipal : IbsCbsBase
{
    private decimal _vDif;
    private decimal _vDevTrib;
    private decimal _vIBSMun;

    public decimal vDif { get => _vDif; set { _vDif = value; OnPropertyChanged(); } }
    public decimal vDevTrib { get => _vDevTrib; set { _vDevTrib = value; OnPropertyChanged(); } }
    public decimal vIBSMun { get => _vIBSMun; set { _vIBSMun = value; OnPropertyChanged(); } }
}

public class TotalCbs : IbsCbsBase
{
    private decimal _vDif;
    private decimal _vDevTrib;
    private decimal _vCBS;
    private decimal _vCredPres;
    private decimal _vCredPresCondSus;

    public decimal vDif { get => _vDif; set { _vDif = value; OnPropertyChanged(); } }
    public decimal vDevTrib { get => _vDevTrib; set { _vDevTrib = value; OnPropertyChanged(); } }
    public decimal vCBS { get => _vCBS; set { _vCBS = value; OnPropertyChanged(); } }
    public decimal vCredPres { get => _vCredPres; set { _vCredPres = value; OnPropertyChanged(); } }
    public decimal vCredPresCondSus { get => _vCredPresCondSus; set { _vCredPresCondSus = value; OnPropertyChanged(); } }
}

public class TMonofasia : IbsCbsBase
{
    private decimal? _qBCMono;
    private decimal? _adRemIBS;
    private decimal? _adRemCBS;
    private decimal? _vIBSMono;
    private decimal? _vCBSMono;
    private decimal? _qBCMonoReten;
    private decimal? _adRemIBSReten;
    private decimal? _vIBSMonoReten;
    private decimal? _adRemCBSReten;
    private decimal? _vCBSMonoReten;
    private decimal? _qBCMonoRet;
    private decimal? _adRemIBSRet;
    private decimal? _vIBSMonoRet;
    private decimal? _adRemCBSRet;
    private decimal? _vCBSMonoRet;
    private decimal? _pDifIBS;
    private decimal? _vIBSMonoDif;
    private decimal? _pDifCBS;
    private decimal? _vCBSMonoDif;
    private decimal _vTotIBSMonoItem;
    private decimal _vTotCBSMonoItem;

    public decimal? qBCMono { get => _qBCMono; set { _qBCMono = value; OnPropertyChanged(); } }
    public decimal? adRemIBS { get => _adRemIBS; set { _adRemIBS = value; OnPropertyChanged(); } }
    public decimal? adRemCBS { get => _adRemCBS; set { _adRemCBS = value; OnPropertyChanged(); } }
    public decimal? vIBSMono { get => _vIBSMono; set { _vIBSMono = value; OnPropertyChanged(); } }
    public decimal? vCBSMono { get => _vCBSMono; set { _vCBSMono = value; OnPropertyChanged(); } }
    public decimal? qBCMonoReten { get => _qBCMonoReten; set { _qBCMonoReten = value; OnPropertyChanged(); } }
    public decimal? adRemIBSReten { get => _adRemIBSReten; set { _adRemIBSReten = value; OnPropertyChanged(); } }
    public decimal? vIBSMonoReten { get => _vIBSMonoReten; set { _vIBSMonoReten = value; OnPropertyChanged(); } }
    public decimal? adRemCBSReten { get => _adRemCBSReten; set { _adRemCBSReten = value; OnPropertyChanged(); } }
    public decimal? vCBSMonoReten { get => _vCBSMonoReten; set { _vCBSMonoReten = value; OnPropertyChanged(); } }
    public decimal? qBCMonoRet { get => _qBCMonoRet; set { _qBCMonoRet = value; OnPropertyChanged(); } }
    public decimal? adRemIBSRet { get => _adRemIBSRet; set { _adRemIBSRet = value; OnPropertyChanged(); } }
    public decimal? vIBSMonoRet { get => _vIBSMonoRet; set { _vIBSMonoRet = value; OnPropertyChanged(); } }
    public decimal? adRemCBSRet { get => _adRemCBSRet; set { _adRemCBSRet = value; OnPropertyChanged(); } }
    public decimal? vCBSMonoRet { get => _vCBSMonoRet; set { _vCBSMonoRet = value; OnPropertyChanged(); } }
    public decimal? pDifIBS { get => _pDifIBS; set { _pDifIBS = value; OnPropertyChanged(); } }
    public decimal? vIBSMonoDif { get => _vIBSMonoDif; set { _vIBSMonoDif = value; OnPropertyChanged(); } }
    public decimal? pDifCBS { get => _pDifCBS; set { _pDifCBS = value; OnPropertyChanged(); } }
    public decimal? vCBSMonoDif { get => _vCBSMonoDif; set { _vCBSMonoDif = value; OnPropertyChanged(); } }
    public decimal vTotIBSMonoItem { get => _vTotIBSMonoItem; set { _vTotIBSMonoItem = value; OnPropertyChanged(); } }
    public decimal vTotCBSMonoItem { get => _vTotCBSMonoItem; set { _vTotCBSMonoItem = value; OnPropertyChanged(); } }
}

public class IbsCbs : IbsCbsBase
{
    private decimal _vBC;
    private IbsEstadual? _gIBSUF;
    private IbsMunicipal? _gIBSMun;
    private Cbs? _gCBS;
    private TributacaoRegular? _gTribRegular;
    private CreditoPresumido? _gIBSCredPres;
    private CreditoPresumido? _gCBSCredPres;
    private TributacaoCompraGov? _gTribCompraGov;

    public decimal vBC { get => _vBC; set { _vBC = value; OnPropertyChanged(); } }
    public IbsEstadual? gIBSUF { get => _gIBSUF; set { _gIBSUF = value; OnPropertyChanged(); } }
    public IbsMunicipal? gIBSMun { get => _gIBSMun; set { _gIBSMun = value; OnPropertyChanged(); } }
    public Cbs? gCBS { get => _gCBS; set { _gCBS = value; OnPropertyChanged(); } }
    public TributacaoRegular? gTribRegular { get => _gTribRegular; set { _gTribRegular = value; OnPropertyChanged(); } }
    public CreditoPresumido? gIBSCredPres { get => _gIBSCredPres; set { _gIBSCredPres = value; OnPropertyChanged(); } }
    public CreditoPresumido? gCBSCredPres { get => _gCBSCredPres; set { _gCBSCredPres = value; OnPropertyChanged(); } }
    public TributacaoCompraGov? gTribCompraGov { get => _gTribCompraGov; set { _gTribCompraGov = value; OnPropertyChanged(); } }
}

public class IbsEstadual : IbsCbsBase
{
    private decimal _pIBSUF;
    private Diferimento? _gDif;
    private TDevTrib? _gDevTrib;
    private ReducaoAliquota? _gRed;
    private decimal _vIBSUF;

    public decimal pIBSUF { get => _pIBSUF; set { _pIBSUF = value; OnPropertyChanged(); } }
    public Diferimento? gDif { get => _gDif; set { _gDif = value; OnPropertyChanged(); } }
    public TDevTrib? gDevTrib { get => _gDevTrib; set { _gDevTrib = value; OnPropertyChanged(); } }
    public ReducaoAliquota? gRed { get => _gRed; set { _gRed = value; OnPropertyChanged(); } }
    public decimal vIBSUF { get => _vIBSUF; set { _vIBSUF = value; OnPropertyChanged(); } }
}

public class IbsMunicipal : IbsCbsBase
{
    private decimal _pIBSMun;
    private Diferimento? _gDif;
    private TDevTrib? _gDevTrib;
    private ReducaoAliquota? _gRed;
    private decimal _vIBSMun;

    public decimal pIBSMun { get => _pIBSMun; set { _pIBSMun = value; OnPropertyChanged(); } }
    public Diferimento? gDif { get => _gDif; set { _gDif = value; OnPropertyChanged(); } }
    public TDevTrib? gDevTrib { get => _gDevTrib; set { _gDevTrib = value; OnPropertyChanged(); } }
    public ReducaoAliquota? gRed { get => _gRed; set { _gRed = value; OnPropertyChanged(); } }
    public decimal vIBSMun { get => _vIBSMun; set { _vIBSMun = value; OnPropertyChanged(); } }
}

public class Cbs : IbsCbsBase
{
    private decimal _pCBS;
    private Diferimento? _gDif;
    private TDevTrib? _gDevTrib;
    private ReducaoAliquota? _gRed;
    private decimal _vCBS;

    public decimal pCBS { get => _pCBS; set { _pCBS = value; OnPropertyChanged(); } }
    public Diferimento? gDif { get => _gDif; set { _gDif = value; OnPropertyChanged(); } }
    public TDevTrib? gDevTrib { get => _gDevTrib; set { _gDevTrib = value; OnPropertyChanged(); } }
    public ReducaoAliquota? gRed { get => _gRed; set { _gRed = value; OnPropertyChanged(); } }
    public decimal vCBS { get => _vCBS; set { _vCBS = value; OnPropertyChanged(); } }
}

public class ReducaoAliquota : IbsCbsBase
{
    private decimal _pRedAliq;
    private decimal _pAliqEfet;

    public decimal pRedAliq { get => _pRedAliq; set { _pRedAliq = value; OnPropertyChanged(); } }
    public decimal pAliqEfet { get => _pAliqEfet; set { _pAliqEfet = value; OnPropertyChanged(); } }
}

public class CreditoPresumido : IbsCbsBase
{
    private string? _cCredPres;
    private decimal _pCredPres;
    private decimal? _vCredPres;
    private decimal? _vCredPresCondSus;

    public string? cCredPres { get => _cCredPres; set { _cCredPres = value; OnPropertyChanged(); } }
    public decimal pCredPres { get => _pCredPres; set { _pCredPres = value; OnPropertyChanged(); } }
    public decimal? vCredPres { get => _vCredPres; set { _vCredPres = value; OnPropertyChanged(); } }
    public decimal? vCredPresCondSus { get => _vCredPresCondSus; set { _vCredPresCondSus = value; OnPropertyChanged(); } }
}

public class Diferimento : IbsCbsBase
{
    private decimal _pDif;
    private decimal _vDif;

    public decimal pDif { get => _pDif; set { _pDif = value; OnPropertyChanged(); } }
    public decimal vDif { get => _vDif; set { _vDif = value; OnPropertyChanged(); } }
}

public class TDevTrib : IbsCbsBase
{
    private decimal _vDevTrib;
    public decimal vDevTrib { get => _vDevTrib; set { _vDevTrib = value; OnPropertyChanged(); } }
}

public class TributacaoRegular : IbsCbsBase
{
    private Cst _cstReg;
    private string? _cClassTribReg;
    private decimal _pAliqEfetRegIBSUF;
    private decimal _vTribRegIBSUF;
    private decimal _pAliqEfetRegIBSMun;
    private decimal _vTribRegIBSMun;
    private decimal _pAliqEfetRegCBS;
    private decimal _vTribRegCBS;

    public Cst CSTReg { get => _cstReg; set { _cstReg = value; OnPropertyChanged(); } }
    public string? cClassTribReg { get => _cClassTribReg; set { _cClassTribReg = value; OnPropertyChanged(); } }
    public decimal pAliqEfetRegIBSUF { get => _pAliqEfetRegIBSUF; set { _pAliqEfetRegIBSUF = value; OnPropertyChanged(); } }
    public decimal vTribRegIBSUF { get => _vTribRegIBSUF; set { _vTribRegIBSUF = value; OnPropertyChanged(); } }
    public decimal pAliqEfetRegIBSMun { get => _pAliqEfetRegIBSMun; set { _pAliqEfetRegIBSMun = value; OnPropertyChanged(); } }
    public decimal vTribRegIBSMun { get => _vTribRegIBSMun; set { _vTribRegIBSMun = value; OnPropertyChanged(); } }
    public decimal pAliqEfetRegCBS { get => _pAliqEfetRegCBS; set { _pAliqEfetRegCBS = value; OnPropertyChanged(); } }
    public decimal vTribRegCBS { get => _vTribRegCBS; set { _vTribRegCBS = value; OnPropertyChanged(); } }
}

public class TributacaoCompraGov : IbsCbsBase
{
    private decimal _pAliqIBSUF;
    private decimal _vTribIBSUF;
    private decimal _pAliqIBSMun;
    private decimal _vTribIBSMun;
    private decimal _pAliqCBS;
    private decimal _vTribCBS;

    public decimal pAliqIBSUF { get => _pAliqIBSUF; set { _pAliqIBSUF = value; OnPropertyChanged(); } }
    public decimal vTribIBSUF { get => _vTribIBSUF; set { _vTribIBSUF = value; OnPropertyChanged(); } }
    public decimal pAliqIBSMun { get => _pAliqIBSMun; set { _pAliqIBSMun = value; OnPropertyChanged(); } }
    public decimal vTribIBSMun { get => _vTribIBSMun; set { _vTribIBSMun = value; OnPropertyChanged(); } }
    public decimal pAliqCBS { get => _pAliqCBS; set { _pAliqCBS = value; OnPropertyChanged(); } }
    public decimal vTribCBS { get => _vTribCBS; set { _vTribCBS = value; OnPropertyChanged(); } }
}

public class TributacaoCompraGovReduzido : IbsCbsBase
{
    private EnteGovernamental _tpEnteGov;
    private decimal _pRedutor;

    public EnteGovernamental tpEnteGov { get => _tpEnteGov; set { _tpEnteGov = value; OnPropertyChanged(); } }
    public decimal pRedutor { get => _pRedutor; set { _pRedutor = value; OnPropertyChanged(); } }
}

public class CompraGov : IbsCbsBase
{
    private EnteGovernamental _tpEnteGov;
    private decimal _pRedutor;
    private TipoOperacaoCompraGov _tpOperGov;

    public EnteGovernamental tpEnteGov { get => _tpEnteGov; set { _tpEnteGov = value; OnPropertyChanged(); } }
    public decimal pRedutor { get => _pRedutor; set { _pRedutor = value; OnPropertyChanged(); } }
    public TipoOperacaoCompraGov tpOperGov { get => _tpOperGov; set { _tpOperGov = value; OnPropertyChanged(); } }
}

public class TransferenciaCredito : IbsCbsBase
{
    private decimal _vIBS;
    private decimal _vCBS;

    public decimal vIBS { get => _vIBS; set { _vIBS = value; OnPropertyChanged(); } }
    public decimal vCBS { get => _vCBS; set { _vCBS = value; OnPropertyChanged(); } }
}

public class CreditoPresIbsZfm : IbsCbsBase
{
    private TipoCreditoPresIbsZfm _tpCredPresIBSZFM;
    private decimal? _vCredPresIBSZFM;

    public TipoCreditoPresIbsZfm tpCredPresIBSZFM { get => _tpCredPresIBSZFM; set { _tpCredPresIBSZFM = value; OnPropertyChanged(); } }
    public decimal? vCredPresIBSZFM { get => _vCredPresIBSZFM; set { _vCredPresIBSZFM = value; OnPropertyChanged(); } }
}
