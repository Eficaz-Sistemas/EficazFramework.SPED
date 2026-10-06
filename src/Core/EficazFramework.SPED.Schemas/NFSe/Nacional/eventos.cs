namespace EficazFramework.SPED.Schemas.NFSe.Nacional;

// Leiautes de eventos da NFS-e Nacional v1.01 (pedRegEvento_v1.01.xsd, evento_v1.01.xsd, tiposEventos_v1.01.xsd).

#region Enumerações

/// <summary>
/// Tipos de evento da NFS-e Nacional. O valor é o código de 6 dígitos do evento (grupo <c>eNNNNNN</c>).
/// </summary>
public enum TipoEventoNfse
{
    /// <summary>e101101 - Cancelamento de NFS-e (emitente).</summary>
    Cancelamento = 101101,
    /// <summary>e105102 - Cancelamento de NFS-e por Substituição.</summary>
    CancelamentoPorSubstituicao = 105102,
    /// <summary>e101103 - Solicitação de Análise Fiscal para Cancelamento de NFS-e.</summary>
    SolicitacaoAnaliseFiscalCancelamento = 101103,
    /// <summary>e105104 - Cancelamento de NFS-e Deferido por Análise Fiscal.</summary>
    CancelamentoDeferido = 105104,
    /// <summary>e105105 - Cancelamento de NFS-e Indeferido por Análise Fiscal.</summary>
    CancelamentoIndeferido = 105105,
    /// <summary>e202201 - Manifestação: Confirmação do Prestador.</summary>
    ConfirmacaoPrestador = 202201,
    /// <summary>e203202 - Manifestação: Confirmação do Tomador.</summary>
    ConfirmacaoTomador = 203202,
    /// <summary>e204203 - Manifestação: Confirmação do Intermediário.</summary>
    ConfirmacaoIntermediario = 204203,
    /// <summary>e205204 - Manifestação: Confirmação Tácita.</summary>
    ConfirmacaoTacita = 205204,
    /// <summary>e202205 - Manifestação: Rejeição do Prestador.</summary>
    RejeicaoPrestador = 202205,
    /// <summary>e203206 - Manifestação: Rejeição do Tomador.</summary>
    RejeicaoTomador = 203206,
    /// <summary>e204207 - Manifestação: Rejeição do Intermediário.</summary>
    RejeicaoIntermediario = 204207,
    /// <summary>e205208 - Manifestação: Anulação da Rejeição.</summary>
    AnulacaoRejeicao = 205208,
    /// <summary>e305101 - Cancelamento de NFS-e por Ofício.</summary>
    CancelamentoPorOficio = 305101,
    /// <summary>e305102 - Bloqueio de NFS-e por Ofício.</summary>
    BloqueioPorOficio = 305102,
    /// <summary>e305103 - Desbloqueio de NFS-e por Ofício.</summary>
    DesbloqueioPorOficio = 305103
}

/// <summary>
/// Código de justificativa de cancelamento (TSCodJustCanc) — também usado na solicitação de análise fiscal (TSCodJustAnaliseFiscalCanc).
/// </summary>
public enum MotivoCancelamentoNfse
{
    /// <summary>1 - Erro na Emissão.</summary>
    [XmlEnum("1")]
    ErroNaEmissao = 1,
    /// <summary>2 - Serviço não Prestado.</summary>
    [XmlEnum("2")]
    ServicoNaoPrestado = 2,
    /// <summary>9 - Outros.</summary>
    [XmlEnum("9")]
    Outros = 9
}

/// <summary>
/// Ambiente gerador do evento (TSAmbGeradorEvt).
/// </summary>
public enum AmbienteGeradorEvento
{
    /// <summary>1 - Sistema próprio do município (Prefeitura).</summary>
    [XmlEnum("1")]
    Prefeitura = 1,
    /// <summary>2 - Sefin Nacional NFS-e.</summary>
    [XmlEnum("2")]
    SefinNacional = 2,
    /// <summary>3 - Ambiente de Dados Nacional (ADN) NFS-e.</summary>
    [XmlEnum("3")]
    AmbienteNacional = 3
}

#endregion

#region Evento (registrado)

/// <summary>
/// Evento registrado em uma NFS-e (elemento raiz <c>evento</c>, tipo <c>TCEvento</c>): devolvido pela Sefin Nacional / ADN
/// com o pedido de registro (<see cref="PedidoRegistroEvento"/>) e a assinatura do ambiente gerador.
/// </summary>
[XmlRoot("evento", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
[XmlType("TCEvento", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class EventoNfse : NFSeNacionalBase, IXmlSpedDocument
{
    private InformacoesEvento? _infEvento;
    private XmlElement? _signature;
    private string? _versao = "1.01";

    /// <summary>Informações do evento registrado.</summary>
    [XmlElement("infEvento")]
    public InformacoesEvento? InfEvento
    {
        get => _infEvento;
        set { _infEvento = value; OnPropertyChanged(); }
    }

    /// <summary>Assinatura XML (XML Digital Signature) do ambiente gerador.</summary>
    [XmlElement("Signature", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public XmlElement? Signature
    {
        get => _signature;
        set { _signature = value; OnPropertyChanged(); }
    }

    /// <summary>Versão do leiaute (atributo obrigatório).</summary>
    [XmlAttribute("versao")]
    public string? versao
    {
        get => _versao;
        set { _versao = value; OnPropertyChanged(); }
    }

    public XmlDocumentType DocumentType => XmlDocumentType.NFS_e_Nacional_Evento;
    public DateTime? DataEmissao => InfEvento?.DataHoraProcessamento?.DateTime;
    public string Chave => InfEvento?.Id ?? string.Empty;

    /// <summary>Chave de acesso da NFS-e à qual o evento está vinculado.</summary>
    [XmlIgnore]
    public string? ChaveAcesso =>
        InfEvento?.PedidoRegistroEvento?.InfPedReg?.ChaveAcesso
        ?? (InfEvento?.Id is { Length: >= 53 } id ? id.Substring(3, 50) : null);

    /// <summary>Tipo do evento (do grupo <c>eNNNNNN</c> do pedido; senão, do <c>Id</c>: EVT + chave(50) + código(6) + nº(3)).</summary>
    [XmlIgnore]
    public TipoEventoNfse? TipoEvento =>
        InfEvento?.PedidoRegistroEvento?.InfPedReg?.TipoEvento
        ?? (InfEvento?.Id is { Length: >= 59 } id && int.TryParse(id.AsSpan(53, 6), out var codigo) && Enum.IsDefined(typeof(TipoEventoNfse), codigo)
            ? (TipoEventoNfse)codigo
            : null);

    /// <summary>
    /// O evento deixa a NFS-e cancelada: cancelamento (101101), por substituição (105102),
    /// deferido por análise fiscal (105104) ou por ofício (305101).
    /// </summary>
    [XmlIgnore]
    public bool CancelaNfse => TipoEvento is TipoEventoNfse.Cancelamento
        or TipoEventoNfse.CancelamentoPorSubstituicao
        or TipoEventoNfse.CancelamentoDeferido
        or TipoEventoNfse.CancelamentoPorOficio;

    private static XmlSerializer sSerializer = null!;
    private static XmlSerializer Serializer
    {
        get
        {
            sSerializer ??= new XmlSerializer(typeof(EventoNfse));
            return sSerializer;
        }
    }

    /// <summary>Serializa a instância atual em uma string XML.</summary>
    public virtual string Serialize() => NFSeNacionalXml.Serialize(Serializer, this);

    public static bool CanDeserialize(string xml, ref EventoNfse obj, ref Exception exception)
    {
        exception = null!;
        obj = default!;
        try
        {
            obj = Deserialize(xml);
            return true;
        }
        catch (Exception ex)
        {
            exception = ex;
            return false;
        }
    }

    public static bool CanDeserialize(string xml, ref EventoNfse obj)
    {
        Exception exception = null!;
        return CanDeserialize(xml, ref obj, ref exception);
    }

    public static EventoNfse Deserialize(string xml) => NFSeNacionalXml.Deserialize<EventoNfse>(Serializer, xml);

    public static EventoNfse Deserialize(System.IO.Stream s) => (EventoNfse)Serializer.Deserialize(s)!;

    /// <summary>Grava o XML no stream informado (o stream é fechado ao final, como nos demais documentos).</summary>
    public virtual void SaveTo(System.IO.Stream target) => NFSeNacionalXml.SaveTo(target, Serialize());

    /// <summary>Grava o XML no stream informado (o stream é fechado ao final, como nos demais documentos).</summary>
    public virtual Task SaveToAsync(System.IO.Stream target) => NFSeNacionalXml.SaveToAsync(target, Serialize());

    public static EventoNfse LoadFrom(System.IO.Stream source) => Deserialize(NFSeNacionalXml.Read(source, closeStream: true));

    public static async Task<EventoNfse> LoadFromAsync(System.IO.Stream source, bool close_stream = true) =>
        Deserialize(await NFSeNacionalXml.ReadAsync(source, close_stream));
}

/// <summary>
/// Informações do evento registrado (tipo <c>TCInfEvento</c>).
/// </summary>
[XmlType("TCInfEvento", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class InformacoesEvento : NFSeNacionalBase
{
    private string? _id;
    private string? _verAplic;
    private AmbienteGeradorEvento _ambGer;
    private int _nSeqEvento;
    private DateTimeOffset? _dhProc;
    private string? _nDFSe;
    private PedidoRegistroEvento? _pedRegEvento;

    /// <summary>Identificador do evento: <c>EVT</c> + chave de acesso (50) + código do evento (6) + nº sequencial (3).</summary>
    [XmlAttribute("Id")]
    public string? Id
    {
        get => _id;
        set { _id = value; OnPropertyChanged(); }
    }

    /// <summary>Versão do aplicativo que gerou o evento.</summary>
    [XmlElement("verAplic")]
    public string? VersaoAplicativo
    {
        get => _verAplic;
        set { _verAplic = value; OnPropertyChanged(); }
    }

    /// <summary>Ambiente gerador do evento.</summary>
    [XmlElement("ambGer")]
    public AmbienteGeradorEvento AmbienteGerador
    {
        get => _ambGer;
        set { _ambGer = value; OnPropertyChanged(); }
    }

    /// <summary>Número sequencial do evento para o mesmo tipo (cancelamento: 1).</summary>
    [XmlElement("nSeqEvento")]
    public int NumeroSequencial
    {
        get => _nSeqEvento;
        set { _nSeqEvento = value; OnPropertyChanged(); }
    }

    /// <summary>Data/hora do registro do evento.</summary>
    [XmlElement("dhProc")]
    public DateTimeOffset? DataHoraProcessamento
    {
        get => _dhProc;
        set { _dhProc = value; OnPropertyChanged(); }
    }

    /// <summary>Número sequencial do documento gerado pelo ambiente gerador.</summary>
    [XmlElement("nDFSe")]
    public string? NumeroDFSe
    {
        get => _nDFSe;
        set { _nDFSe = value; OnPropertyChanged(); }
    }

    /// <summary>Pedido de registro do evento, como enviado pelo autor.</summary>
    [XmlElement("pedRegEvento")]
    public PedidoRegistroEvento? PedidoRegistroEvento
    {
        get => _pedRegEvento;
        set { _pedRegEvento = value; OnPropertyChanged(); }
    }
}

#endregion

#region Pedido de registro de evento

/// <summary>
/// Pedido de registro de evento (elemento raiz <c>pedRegEvento</c>, tipo <c>TCPedRegEvt</c>), assinado pelo autor
/// e enviado em POST /nfse/{chaveAcesso}/eventos.
/// </summary>
[XmlRoot("pedRegEvento", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
[XmlType("TCPedRegEvt", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class PedidoRegistroEvento : NFSeNacionalBase, IXmlSpedDocument
{
    private InformacoesPedidoRegistroEvento? _infPedReg;
    private XmlElement? _signature;
    private string? _versao = "1.01";

    /// <summary>Informações do pedido.</summary>
    [XmlElement("infPedReg")]
    public InformacoesPedidoRegistroEvento? InfPedReg
    {
        get => _infPedReg;
        set { _infPedReg = value; OnPropertyChanged(); }
    }

    /// <summary>Assinatura XML do autor (opcional no leiaute; exigida no envio).</summary>
    [XmlElement("Signature", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public XmlElement? Signature
    {
        get => _signature;
        set { _signature = value; OnPropertyChanged(); }
    }

    /// <summary>Versão do leiaute (atributo obrigatório).</summary>
    [XmlAttribute("versao")]
    public string? versao
    {
        get => _versao;
        set { _versao = value; OnPropertyChanged(); }
    }

    public XmlDocumentType DocumentType => XmlDocumentType.NFS_e_Nacional_PedidoEvento;
    public DateTime? DataEmissao => InfPedReg?.DataHoraEvento?.DateTime;
    public string Chave => InfPedReg?.Id ?? string.Empty;

    private static XmlSerializer sSerializer = null!;
    private static XmlSerializer Serializer
    {
        get
        {
            sSerializer ??= new XmlSerializer(typeof(PedidoRegistroEvento));
            return sSerializer;
        }
    }

    /// <summary>Serializa a instância atual em uma string XML.</summary>
    public virtual string Serialize() => NFSeNacionalXml.Serialize(Serializer, this);

    public static bool CanDeserialize(string xml, ref PedidoRegistroEvento obj, ref Exception exception)
    {
        exception = null!;
        obj = default!;
        try
        {
            obj = Deserialize(xml);
            return true;
        }
        catch (Exception ex)
        {
            exception = ex;
            return false;
        }
    }

    public static bool CanDeserialize(string xml, ref PedidoRegistroEvento obj)
    {
        Exception exception = null!;
        return CanDeserialize(xml, ref obj, ref exception);
    }

    public static PedidoRegistroEvento Deserialize(string xml) => NFSeNacionalXml.Deserialize<PedidoRegistroEvento>(Serializer, xml);

    public static PedidoRegistroEvento Deserialize(System.IO.Stream s) => (PedidoRegistroEvento)Serializer.Deserialize(s)!;

    /// <summary>Grava o XML no stream informado (o stream é fechado ao final, como nos demais documentos).</summary>
    public virtual void SaveTo(System.IO.Stream target) => NFSeNacionalXml.SaveTo(target, Serialize());

    /// <summary>Grava o XML no stream informado (o stream é fechado ao final, como nos demais documentos).</summary>
    public virtual Task SaveToAsync(System.IO.Stream target) => NFSeNacionalXml.SaveToAsync(target, Serialize());

    public static PedidoRegistroEvento LoadFrom(System.IO.Stream source) => Deserialize(NFSeNacionalXml.Read(source, closeStream: true));

    public static async Task<PedidoRegistroEvento> LoadFromAsync(System.IO.Stream source, bool close_stream = true) =>
        Deserialize(await NFSeNacionalXml.ReadAsync(source, close_stream));
}

/// <summary>
/// Informações do pedido de registro de evento (tipo <c>TCInfPedReg</c>).
/// </summary>
[XmlType("TCInfPedReg", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class InformacoesPedidoRegistroEvento : NFSeNacionalBase
{
    private string? _id;
    private Ambiente _tpAmb;
    private string? _verAplic;
    private DateTimeOffset? _dhEvento;
    private string? _cnpjAutor;
    private string? _cpfAutor;
    private string? _chNFSe;
    private DetalheEventoNfse? _detalhe;

    /// <summary>Identificador do pedido: <c>PRE</c> + chave de acesso (50) + código do evento (6) — TSIdPedRegEvt.</summary>
    [XmlAttribute("Id")]
    public string? Id
    {
        get => _id;
        set { _id = value; OnPropertyChanged(); }
    }

    /// <summary>Ambiente: 1 - Produção; 2 - Homologação.</summary>
    [XmlElement("tpAmb")]
    public Ambiente TipoAmbiente
    {
        get => _tpAmb;
        set { _tpAmb = value; OnPropertyChanged(); }
    }

    /// <summary>Versão do aplicativo que gerou o pedido (1 a 20 caracteres).</summary>
    [XmlElement("verAplic")]
    public string? VersaoAplicativo
    {
        get => _verAplic;
        set { _verAplic = value; OnPropertyChanged(); }
    }

    /// <summary>Data/hora do evento (AAAA-MM-DDThh:mm:ssTZD, sem frações de segundo).</summary>
    [XmlElement("dhEvento")]
    public DateTimeOffset? DataHoraEvento
    {
        get => _dhEvento;
        set { _dhEvento = value; OnPropertyChanged(); }
    }

    /// <summary>CNPJ do autor do evento (preencher este ou <see cref="CPFAutor"/>).</summary>
    [XmlElement("CNPJAutor")]
    public string? CNPJAutor
    {
        get => _cnpjAutor;
        set { _cnpjAutor = value; OnPropertyChanged(); }
    }

    /// <summary>CPF do autor do evento (preencher este ou <see cref="CNPJAutor"/>).</summary>
    [XmlElement("CPFAutor")]
    public string? CPFAutor
    {
        get => _cpfAutor;
        set { _cpfAutor = value; OnPropertyChanged(); }
    }

    /// <summary>Chave de acesso da NFS-e (50 dígitos).</summary>
    [XmlElement("chNFSe")]
    public string? ChaveAcesso
    {
        get => _chNFSe;
        set { _chNFSe = value; OnPropertyChanged(); }
    }

    /// <summary>Grupo específico do evento (escolha entre os 16 tipos do leiaute).</summary>
    [XmlElement("e101101", typeof(EventoCancelamento))]
    [XmlElement("e105102", typeof(EventoCancelamentoSubstituicao))]
    [XmlElement("e101103", typeof(EventoSolicitacaoAnaliseFiscal))]
    [XmlElement("e105104", typeof(EventoCancelamentoDeferido))]
    [XmlElement("e105105", typeof(EventoCancelamentoIndeferido))]
    [XmlElement("e202201", typeof(EventoConfirmacaoPrestador))]
    [XmlElement("e203202", typeof(EventoConfirmacaoTomador))]
    [XmlElement("e204203", typeof(EventoConfirmacaoIntermediario))]
    [XmlElement("e205204", typeof(EventoConfirmacaoTacita))]
    [XmlElement("e202205", typeof(EventoRejeicaoPrestador))]
    [XmlElement("e203206", typeof(EventoRejeicaoTomador))]
    [XmlElement("e204207", typeof(EventoRejeicaoIntermediario))]
    [XmlElement("e205208", typeof(EventoAnulacaoRejeicao))]
    [XmlElement("e305101", typeof(EventoCancelamentoOficio))]
    [XmlElement("e305102", typeof(EventoBloqueioOficio))]
    [XmlElement("e305103", typeof(EventoDesbloqueioOficio))]
    public DetalheEventoNfse? Detalhe
    {
        get => _detalhe;
        set { _detalhe = value; OnPropertyChanged(); }
    }

    /// <summary>Tipo do evento, conforme o grupo em <see cref="Detalhe"/>.</summary>
    [XmlIgnore]
    public TipoEventoNfse? TipoEvento => Detalhe?.Tipo;
}

#endregion

#region Grupos específicos dos eventos (TE*)

/// <summary>
/// Base dos grupos específicos de evento (<c>eNNNNNN</c>): todos começam pela descrição fixa (<c>xDesc</c>).
/// </summary>
[XmlType("DetalheEventoNfse", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public abstract class DetalheEventoNfse : NFSeNacionalBase
{
    private string? _xDesc;

    /// <summary>Tipo do evento representado pelo grupo.</summary>
    [XmlIgnore]
    public abstract TipoEventoNfse Tipo { get; }

    /// <summary>Descrição fixa do evento definida no leiaute.</summary>
    [XmlIgnore]
    public abstract string DescricaoPadrao { get; }

    /// <summary>Descrição do evento (<c>xDesc</c>); padrão: <see cref="DescricaoPadrao"/>.</summary>
    [XmlElement("xDesc")]
    public string? Descricao
    {
        get => _xDesc ?? DescricaoPadrao;
        set { _xDesc = value; OnPropertyChanged(); }
    }
}

/// <summary>e101101 - Cancelamento de NFS-e (TE101101).</summary>
[XmlType("TE101101", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class EventoCancelamento : DetalheEventoNfse
{
    private MotivoCancelamentoNfse _cMotivo;
    private string? _xMotivo;

    public override TipoEventoNfse Tipo => TipoEventoNfse.Cancelamento;
    public override string DescricaoPadrao => "Cancelamento de NFS-e";

    /// <summary>Código de justificativa do cancelamento.</summary>
    [XmlElement("cMotivo")]
    public MotivoCancelamentoNfse Motivo
    {
        get => _cMotivo;
        set { _cMotivo = value; OnPropertyChanged(); }
    }

    /// <summary>Descrição do motivo (15 a 255 caracteres).</summary>
    [XmlElement("xMotivo")]
    public string? DescricaoMotivo
    {
        get => _xMotivo;
        set { _xMotivo = value; OnPropertyChanged(); }
    }
}

/// <summary>e105102 - Cancelamento de NFS-e por Substituição (TE105102).</summary>
[XmlType("TE105102", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class EventoCancelamentoSubstituicao : DetalheEventoNfse
{
    private string? _cMotivo;
    private string? _xMotivo;
    private string? _chSubstituta;

    public override TipoEventoNfse Tipo => TipoEventoNfse.CancelamentoPorSubstituicao;
    public override string DescricaoPadrao => "Cancelamento de NFS-e por Substituição";

    /// <summary>Código de justificativa da substituição (01, 02, 03, 04, 05 ou 99), da DPS substituta.</summary>
    [XmlElement("cMotivo")]
    public string? Motivo
    {
        get => _cMotivo;
        set { _cMotivo = value; OnPropertyChanged(); }
    }

    /// <summary>Descrição do motivo (opcional).</summary>
    [XmlElement("xMotivo")]
    public string? DescricaoMotivo
    {
        get => _xMotivo;
        set { _xMotivo = value; OnPropertyChanged(); }
    }

    /// <summary>Chave de acesso da NFS-e substituta.</summary>
    [XmlElement("chSubstituta")]
    public string? ChaveSubstituta
    {
        get => _chSubstituta;
        set { _chSubstituta = value; OnPropertyChanged(); }
    }
}

/// <summary>e101103 - Solicitação de Análise Fiscal para Cancelamento de NFS-e (TE101103).</summary>
[XmlType("TE101103", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class EventoSolicitacaoAnaliseFiscal : DetalheEventoNfse
{
    private MotivoCancelamentoNfse _cMotivo;
    private string? _xMotivo;

    public override TipoEventoNfse Tipo => TipoEventoNfse.SolicitacaoAnaliseFiscalCancelamento;
    public override string DescricaoPadrao => "Solicitação de Análise Fiscal para Cancelamento de NFS-e";

    /// <summary>Código do motivo da solicitação.</summary>
    [XmlElement("cMotivo")]
    public MotivoCancelamentoNfse Motivo
    {
        get => _cMotivo;
        set { _cMotivo = value; OnPropertyChanged(); }
    }

    /// <summary>Descrição do motivo (15 a 255 caracteres).</summary>
    [XmlElement("xMotivo")]
    public string? DescricaoMotivo
    {
        get => _xMotivo;
        set { _xMotivo = value; OnPropertyChanged(); }
    }
}

/// <summary>Base das respostas à análise fiscal (deferimento/indeferimento) registradas pelo município.</summary>
[XmlType("EventoRespostaAnaliseFiscal", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public abstract class EventoRespostaAnaliseFiscal : DetalheEventoNfse
{
    private string? _cpfAgTrib;
    private string? _nProcAdm;
    private string? _cMotivo;
    private string? _xMotivo;

    /// <summary>CPF do agente da administração tributária municipal.</summary>
    [XmlElement("CPFAgTrib")]
    public string? CPFAgenteTributario
    {
        get => _cpfAgTrib;
        set { _cpfAgTrib = value; OnPropertyChanged(); }
    }

    /// <summary>Número do processo administrativo municipal (opcional).</summary>
    [XmlElement("nProcAdm")]
    public string? NumeroProcessoAdministrativo
    {
        get => _nProcAdm;
        set { _nProcAdm = value; OnPropertyChanged(); }
    }

    /// <summary>Código da resposta da análise fiscal.</summary>
    [XmlElement("cMotivo")]
    public string? Motivo
    {
        get => _cMotivo;
        set { _cMotivo = value; OnPropertyChanged(); }
    }

    /// <summary>Descrição do motivo.</summary>
    [XmlElement("xMotivo")]
    public string? DescricaoMotivo
    {
        get => _xMotivo;
        set { _xMotivo = value; OnPropertyChanged(); }
    }
}

/// <summary>e105104 - Cancelamento de NFS-e Deferido por Análise Fiscal (TE105104).</summary>
[XmlType("TE105104", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class EventoCancelamentoDeferido : EventoRespostaAnaliseFiscal
{
    public override TipoEventoNfse Tipo => TipoEventoNfse.CancelamentoDeferido;
    public override string DescricaoPadrao => "Cancelamento de NFS-e Deferido por Análise Fiscal";
}

/// <summary>e105105 - Cancelamento de NFS-e Indeferido por Análise Fiscal (TE105105).</summary>
[XmlType("TE105105", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class EventoCancelamentoIndeferido : EventoRespostaAnaliseFiscal
{
    public override TipoEventoNfse Tipo => TipoEventoNfse.CancelamentoIndeferido;
    public override string DescricaoPadrao => "Cancelamento de NFS-e Indeferido por Análise Fiscal";
}

/// <summary>e202201 - Manifestação de NFS-e: Confirmação do Prestador (TE202201).</summary>
[XmlType("TE202201", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class EventoConfirmacaoPrestador : DetalheEventoNfse
{
    public override TipoEventoNfse Tipo => TipoEventoNfse.ConfirmacaoPrestador;
    public override string DescricaoPadrao => "Manifestação de NFS-e - Confirmação do Prestador";
}

/// <summary>e203202 - Manifestação de NFS-e: Confirmação do Tomador (TE203202).</summary>
[XmlType("TE203202", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class EventoConfirmacaoTomador : DetalheEventoNfse
{
    public override TipoEventoNfse Tipo => TipoEventoNfse.ConfirmacaoTomador;
    public override string DescricaoPadrao => "Manifestação de NFS-e - Confirmação do Tomador";
}

/// <summary>e204203 - Manifestação de NFS-e: Confirmação do Intermediário (TE204203).</summary>
[XmlType("TE204203", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class EventoConfirmacaoIntermediario : DetalheEventoNfse
{
    public override TipoEventoNfse Tipo => TipoEventoNfse.ConfirmacaoIntermediario;
    public override string DescricaoPadrao => "Manifestação de NFS-e - Confirmação do Intermediário";
}

/// <summary>e205204 - Manifestação de NFS-e: Confirmação Tácita (TE205204).</summary>
[XmlType("TE205204", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class EventoConfirmacaoTacita : DetalheEventoNfse
{
    public override TipoEventoNfse Tipo => TipoEventoNfse.ConfirmacaoTacita;
    public override string DescricaoPadrao => "Manifestação de NFS-e - Confirmação Tácita";
}

/// <summary>Base das rejeições (prestador, tomador, intermediário).</summary>
[XmlType("EventoRejeicao", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public abstract class EventoRejeicao : DetalheEventoNfse
{
    private string? _cMotivo;
    private string? _xMotivo;

    /// <summary>Motivo da rejeição (1, 2, 3, 4, 5 ou 9 — TSCodMotivoRejeicao).</summary>
    [XmlElement("cMotivo")]
    public string? Motivo
    {
        get => _cMotivo;
        set { _cMotivo = value; OnPropertyChanged(); }
    }

    /// <summary>Descrição do motivo (opcional).</summary>
    [XmlElement("xMotivo")]
    public string? DescricaoMotivo
    {
        get => _xMotivo;
        set { _xMotivo = value; OnPropertyChanged(); }
    }
}

/// <summary>e202205 - Manifestação de NFS-e: Rejeição do Prestador (TE202205).</summary>
[XmlType("TE202205", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class EventoRejeicaoPrestador : EventoRejeicao
{
    public override TipoEventoNfse Tipo => TipoEventoNfse.RejeicaoPrestador;
    public override string DescricaoPadrao => "Manifestação de NFS-e - Rejeição do Prestador";
}

/// <summary>e203206 - Manifestação de NFS-e: Rejeição do Tomador (TE203206).</summary>
[XmlType("TE203206", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class EventoRejeicaoTomador : EventoRejeicao
{
    public override TipoEventoNfse Tipo => TipoEventoNfse.RejeicaoTomador;
    public override string DescricaoPadrao => "Manifestação de NFS-e - Rejeição do Tomador";
}

/// <summary>e204207 - Manifestação de NFS-e: Rejeição do Intermediário (TE204207).</summary>
[XmlType("TE204207", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class EventoRejeicaoIntermediario : EventoRejeicao
{
    public override TipoEventoNfse Tipo => TipoEventoNfse.RejeicaoIntermediario;
    public override string DescricaoPadrao => "Manifestação de NFS-e - Rejeição do Intermediário";
}

/// <summary>e205208 - Manifestação de NFS-e: Anulação da Rejeição (TE205208).</summary>
[XmlType("TE205208", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class EventoAnulacaoRejeicao : DetalheEventoNfse
{
    private string? _cpfAgTrib;
    private string? _idEvManifRej;
    private string? _xMotivo;

    public override TipoEventoNfse Tipo => TipoEventoNfse.AnulacaoRejeicao;
    public override string DescricaoPadrao => "Manifestação de NFS-e - Anulação da Rejeição";

    /// <summary>CPF do agente da administração tributária municipal.</summary>
    [XmlElement("CPFAgTrib")]
    public string? CPFAgenteTributario
    {
        get => _cpfAgTrib;
        set { _cpfAgTrib = value; OnPropertyChanged(); }
    }

    /// <summary>Referência ao Id (59 dígitos) do evento de rejeição anulado.</summary>
    [XmlElement("idEvManifRej")]
    public string? IdEventoRejeicao
    {
        get => _idEvManifRej;
        set { _idEvManifRej = value; OnPropertyChanged(); }
    }

    /// <summary>Descrição do motivo.</summary>
    [XmlElement("xMotivo")]
    public string? DescricaoMotivo
    {
        get => _xMotivo;
        set { _xMotivo = value; OnPropertyChanged(); }
    }
}

/// <summary>e305101 - Cancelamento de NFS-e por Ofício (TE305101).</summary>
[XmlType("TE305101", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class EventoCancelamentoOficio : DetalheEventoNfse
{
    private string? _cpfAgTrib;
    private string? _nProcAdm;
    private string? _xProcAdm;

    public override TipoEventoNfse Tipo => TipoEventoNfse.CancelamentoPorOficio;
    public override string DescricaoPadrao => "Cancelamento de NFS-e por Ofício";

    /// <summary>CPF do agente da administração tributária municipal.</summary>
    [XmlElement("CPFAgTrib")]
    public string? CPFAgenteTributario
    {
        get => _cpfAgTrib;
        set { _cpfAgTrib = value; OnPropertyChanged(); }
    }

    /// <summary>Número do processo administrativo municipal.</summary>
    [XmlElement("nProcAdm")]
    public string? NumeroProcessoAdministrativo
    {
        get => _nProcAdm;
        set { _nProcAdm = value; OnPropertyChanged(); }
    }

    /// <summary>Descrição do motivo do processo administrativo.</summary>
    [XmlElement("xProcAdm")]
    public string? DescricaoProcessoAdministrativo
    {
        get => _xProcAdm;
        set { _xProcAdm = value; OnPropertyChanged(); }
    }
}

/// <summary>e305102 - Bloqueio de NFS-e por Ofício (TE305102).</summary>
[XmlType("TE305102", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class EventoBloqueioOficio : DetalheEventoNfse
{
    private string? _cpfAgTrib;
    private string? _codEvento;
    private string? _xMotivo;

    public override TipoEventoNfse Tipo => TipoEventoNfse.BloqueioPorOficio;
    public override string DescricaoPadrao => "Bloqueio de NFS-e por Ofício";

    /// <summary>CPF do agente da administração tributária municipal.</summary>
    [XmlElement("CPFAgTrib")]
    public string? CPFAgenteTributario
    {
        get => _cpfAgTrib;
        set { _cpfAgTrib = value; OnPropertyChanged(); }
    }

    /// <summary>Evento bloqueado (e101101, e105102, e105104, e105105 ou e305101).</summary>
    [XmlElement("codEvento")]
    public string? CodigoEventoBloqueado
    {
        get => _codEvento;
        set { _codEvento = value; OnPropertyChanged(); }
    }

    /// <summary>Descrição do motivo.</summary>
    [XmlElement("xMotivo")]
    public string? DescricaoMotivo
    {
        get => _xMotivo;
        set { _xMotivo = value; OnPropertyChanged(); }
    }
}

/// <summary>e305103 - Desbloqueio de NFS-e por Ofício (TE305103).</summary>
[XmlType("TE305103", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class EventoDesbloqueioOficio : DetalheEventoNfse
{
    private string? _cpfAgTrib;
    private string? _idBloqOfic;

    public override TipoEventoNfse Tipo => TipoEventoNfse.DesbloqueioPorOficio;
    public override string DescricaoPadrao => "Desbloqueio de NFS-e por Ofício";

    /// <summary>CPF do agente da administração tributária municipal.</summary>
    [XmlElement("CPFAgTrib")]
    public string? CPFAgenteTributario
    {
        get => _cpfAgTrib;
        set { _cpfAgTrib = value; OnPropertyChanged(); }
    }

    /// <summary>Referência ao Id (59 dígitos) do bloqueio de ofício.</summary>
    [XmlElement("idBloqOfic")]
    public string? IdBloqueio
    {
        get => _idBloqOfic;
        set { _idBloqOfic = value; OnPropertyChanged(); }
    }
}

#endregion

#region Utilitários de serialização

/// <summary>
/// Rotinas comuns de serialização dos documentos da NFS-e Nacional (mesmo comportamento de <see cref="NFSe"/>).
/// </summary>
internal static class NFSeNacionalXml
{
    internal static string Serialize(XmlSerializer serializer, object instancia)
    {
        using var memoryStream = new System.IO.MemoryStream();
        serializer.Serialize(memoryStream, instancia);
        memoryStream.Seek(0L, System.IO.SeekOrigin.Begin);
        using var streamReader = new System.IO.StreamReader(memoryStream);
        return streamReader.ReadToEnd();
    }

    internal static T Deserialize<T>(XmlSerializer serializer, string xml)
    {
        using var stringReader = new System.IO.StringReader(xml);
        using var xmlReader = XmlReader.Create(stringReader);
        return (T)serializer.Deserialize(xmlReader)!;
    }

    internal static void SaveTo(System.IO.Stream target, string xml)
    {
        if (target is null)
            throw new ArgumentException(Resources.Strings.Validation.Classes_Save_NullStreamExceptionMessage);
        using var streamWriter = new System.IO.StreamWriter(target);
        streamWriter.WriteLine(xml);
        streamWriter.Flush();
    }

    internal static async Task SaveToAsync(System.IO.Stream target, string xml)
    {
        if (target is null)
            throw new ArgumentException(Resources.Strings.Validation.Classes_Save_NullStreamExceptionMessage);
        await using var streamWriter = new System.IO.StreamWriter(target);
        await streamWriter.WriteLineAsync(xml);
        await streamWriter.FlushAsync();
    }

    internal static string Read(System.IO.Stream source, bool closeStream)
    {
        if (source is null)
            throw new ArgumentException(Resources.Strings.Validation.Classes_Load_NullStreamExceptionMessage);
        using var reader = new System.IO.StreamReader(source, leaveOpen: !closeStream);
        return reader.ReadToEnd();
    }

    internal static async Task<string> ReadAsync(System.IO.Stream source, bool closeStream)
    {
        if (source is null)
            throw new ArgumentException(Resources.Strings.Validation.Classes_Load_NullStreamExceptionMessage);
        using var reader = new System.IO.StreamReader(source, leaveOpen: !closeStream);
        return await reader.ReadToEndAsync();
    }
}

#endregion
