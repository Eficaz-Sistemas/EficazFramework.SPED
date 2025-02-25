namespace EficazFramework.SPED.Schemas.MIT;

public partial class Escrituracao
{
    public PeriodoApuracao? PeriodoApuracao { get; set; }
    public List<EventoEspecial>? ListaEventosEspeciais { get; set; }
    public DadosIniciais? DadosIniciais { get; set; }
    public Debitos? Debitos { get; set; }
    public List<Suspensao>? ListaSuspensoes { get; set; }
}

public partial class PeriodoApuracao
{
    public int MesApuracao { get; set; }
    public int AnoApuracao { get; set; }
}

public partial class EventoEspecial
{
    public int IdEvento { get; set; }
    public int DiaEvento { get; set; }
    public int TipoEvento { get; set; }
}

public partial class DadosIniciais
{
    public bool SemMovimento { get; set; }
    public int QualificacaoPj { get; set; }
    public int TributacaoLucro { get; set; }
    public int? VariacoesMonetarias { get; set; }
    public int? RegimePisCofins { get; set; }
    public ResponsavelApuracao? ResponsavelApuracao { get; set; }
}

public partial class ResponsavelApuracao
{
    public string? CpfResponsavel { get; set; }
    public Telefone? TelResponsavel { get; set; }
    public string? EmailResponsavel { get; set; }
    public RegistroCrc? RegistroCrc { get; set; }
}

public partial class Telefone
{
    public string? Ddd { get; set; }
    public string? NumTelefone { get; set; }
}

public partial class RegistroCrc
{
    public string? UfRegistro { get; set; }
    public string? NumRegistro { get; set; }
}

public partial class Debitos
{
    public bool? BalancoLucroReal { get; set; }
    public Irpj? Irpj { get; set; }
    public Csll? Csll { get; set; }
    public Irrf? Irrf { get; set; }
    public Ipi? Ipi { get; set; }
    public Iof? Iof { get; set; }
    public PisPasep? PisPasep { get; set; }
    public Cofins? Cofins { get; set; }
    public ContribuicoesDiversas? ContribuicoesDiversas { get; set; }
    public Cpss? Cpss { get; set; }
    public RetPagamentoUnificado? RetPagamentoUnificado { get; set; }
}

public abstract partial class TributoDebito
{
    public List<DetalhamentoDebito>? ListaDebitos { get; set; }
    public List<DetalhamentoDebito>? ListaDebitosAposEvento { get; set; }

    public void AddDebito(DetalhamentoDebito debito)
    {
        ListaDebitos ??= [];
        ListaDebitos.Add(debito);
        debito.IdDebito = ((ListaDebitos?.Count) ?? 0) + ((ListaDebitosAposEvento?.Count) ?? 0);
    }

    public void AddDebitoAposEvento(DetalhamentoDebito debito)
    {
        ListaDebitosAposEvento ??= [];
        ListaDebitosAposEvento.Add(debito);
        debito.IdDebito = ((ListaDebitos?.Count) ?? 0) + ((ListaDebitosAposEvento?.Count) ?? 0);
    }
}

public partial class DetalhamentoDebito
{
    public int IdDebito { get; set; }
    public int? IdEventoDebito { get; set; }
    public string? CodigoDebito { get; set; }

    /// <summary>
    /// Perнodo de apuraзгo do dйbito, sendo: <br/>
    /// 1 a 31: para periodicidade diбria; <br/>
    /// 1 a 3: para periodicidade decendial; <br/>
    /// 1 ou 2: para periodicidade quinzenal
    /// </summary>
    public int? PaDebito { get; set; }

    public int? AnoPostergado { get; set; }
    public int? TrimPostergado { get; set; }
    public int? AnoDebito { get; set; }

    /// <summary>
    /// Ultimos 06 dнgitos do CNPJ do Estabelecimento <br/>
    /// Obrigatуrio para IPI ou cуdigo de Dйbito for do grupo CIDE
    /// </summary>
    public string? CnpjEstabelecimento { get; set; }

    /// <summary>
    /// Ultimos 06 dнgitos do CNPJ do Estabelecimento <br/>
    /// Obrigatуrio para RetPagamentoUnificado
    /// </summary>
    public string? CnpjIncorporacao { get; set; }

    public string? CnpjScp { get; set; }

    /// <summary>
    /// Cуdigo IBGE do municнpio de origem do ouro com 7 dнgitos. <br/>
    /// Obrigatуrio para IOF
    /// </summary>
    public string? CodigoMunicipioOuro { get; set; }

    public decimal ValorDebito { get; set; } = 0.0M;
}


public partial class Irpj : TributoDebito { }

public partial class Csll : TributoDebito { }

public partial class Irrf : TributoDebito { }

public partial class Ipi : TributoDebito { }

public partial class Iof : TributoDebito { }

public partial class PisPasep : TributoDebito { }

public partial class Cofins : TributoDebito { }

public partial class ContribuicoesDiversas : TributoDebito { }

public partial class Cpss : TributoDebito { }

public partial class RetPagamentoUnificado : TributoDebito { }


public partial class Suspensao
{
    public int TipoSuspensao { get; set; }
    public int MotivoSuspensao { get; set; }
    public bool ComDeposito { get; set; }
    public string? NumeroProcesso { get; set; }
    public bool ProcessoTerceiro { get; set; }

    /// <summary>
    /// Formato AAAAMMDD
    /// </summary>
    public int DataDecisao { get; set; }

    public int VaraJudiciaria { get; set; }

    /// <summary>
    /// Cуdigo IBGE do municнpio sede da subseзгo judiciбria onde tramita o processo, com 7 dнgitos
    /// </summary>
    public string? CodigoMunicipioSj { get; set; }

    public List<DebitoSuspenso>? ListaDebitosSuspensos { get; set; }
}


public partial class DebitoSuspenso
{
    public int IdDebitoSuspenso { get; set; }
    public decimal ValorSuspenso { get; set; }
}