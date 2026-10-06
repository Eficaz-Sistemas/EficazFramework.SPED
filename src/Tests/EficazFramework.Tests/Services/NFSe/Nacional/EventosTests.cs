using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Xml.Linq;
using EficazFramework.SPED.Schemas;
using EficazFramework.SPED.Schemas.NFSe.Nacional;
using EficazFramework.SPED.Utilities.XML;
using XmlDocumentType = EficazFramework.SPED.Schemas.XmlDocumentType;

namespace EficazFramework.SPED.Services.NFSe.Nacional;

/// <summary>
/// Eventos da NFS-e Nacional: pedido de cancelamento validado contra o leiaute oficial (pedRegEvento v1.01)
/// e registro/consulta de eventos com handler HTTP falso (sem rede).
/// </summary>
public class EventosTests : BaseNFseTests
{
    private const string Chave = "35503082219574916000183000000000000126010000000001";
    private const string CnpjAutor = "19574916000183";
    private const string Motivo = "Valor do servico informado incorretamente na emissao";

    private static string PastaSchemas =>
        Path.Combine(AppContext.BaseDirectory, "Resources", "Schemas", "NFSe", "Nacional");

    [Test]
    public void PedidoCancelamento_DeveSeguirOLeiauteEOIdPRE()
    {
        var pedido = EventosNfseNacional.MontarPedidoCancelamento(
            Chave, CnpjAutor, MotivoCancelamentoNfse.ErroNaEmissao, Motivo,
            Schemas.NFSe.Nacional.Ambiente.Homologacao, "EficazFramework.SPED",
            new DateTimeOffset(2026, 10, 6, 10, 30, 15, TimeSpan.FromHours(-3)));

        var ns = (XNamespace)"http://www.sped.fazenda.gov.br/nfse";
        var doc = XDocument.Parse(pedido.Serialize());
        var inf = doc.Root!.Element(ns + "infPedReg")!;

        doc.Root.Attribute("versao")!.Value.Should().Be("1.01");
        inf.Attribute("Id")!.Value.Should().Be($"PRE{Chave}101101");
        inf.Element(ns + "tpAmb")!.Value.Should().Be("2");
        inf.Element(ns + "dhEvento")!.Value.Should().Be("2026-10-06T10:30:15-03:00");
        inf.Element(ns + "CNPJAutor")!.Value.Should().Be(CnpjAutor);
        inf.Element(ns + "CPFAutor").Should().BeNull();
        inf.Element(ns + "e101101")!.Element(ns + "xDesc")!.Value.Should().Be("Cancelamento de NFS-e");
        inf.Element(ns + "e101101")!.Element(ns + "cMotivo")!.Value.Should().Be("1");
        pedido.DocumentType.Should().Be(XmlDocumentType.NFS_e_Nacional_PedidoEvento);
        pedido.Chave.Should().Be($"PRE{Chave}101101");
    }

    [Test]
    public void PedidoRegistroEvento_DeveSerializarEDesserializar()
    {
        var pedido = EventosNfseNacional.MontarPedidoCancelamento(
            Chave, CnpjAutor, MotivoCancelamentoNfse.Outros, Motivo,
            Schemas.NFSe.Nacional.Ambiente.Producao, "EficazFramework.SPED");

        var lido = PedidoRegistroEvento.Deserialize(pedido.Serialize());

        lido.InfPedReg!.Id.Should().Be($"PRE{Chave}101101");
        lido.InfPedReg.TipoAmbiente.Should().Be(Schemas.NFSe.Nacional.Ambiente.Producao);
        lido.InfPedReg.TipoEvento.Should().Be(TipoEventoNfse.Cancelamento);
        var cancelamento = lido.InfPedReg.Detalhe.Should().BeOfType<EventoCancelamento>().Subject;
        cancelamento.Motivo.Should().Be(MotivoCancelamentoNfse.Outros);
        cancelamento.DescricaoMotivo.Should().Be(Motivo);
    }

    [Test]
    public void PedidoCancelamentoAssinado_DeveValidarNoXsdOficial()
    {
        using var service = CreateClient();
        var pedido = EventosNfseNacional.MontarPedidoCancelamento(
            Chave, CnpjAutor, MotivoCancelamentoNfse.ServicoNaoPrestado, Motivo,
            Schemas.NFSe.Nacional.Ambiente.Homologacao, service.VersaoAplicativo);

        var assinado = service.AssinarPedidoEvento(pedido);

        var erros = ValidarNoXsd(assinado.OuterXml, "pedRegEvento_v1.01.xsd");
        erros.Should().BeEmpty();
        assinado.GetElementsByTagName("Signature", "http://www.w3.org/2000/09/xmldsig#").Count.Should().Be(1);
    }

    [TestCase("curto")]
    [TestCase("")]
    public void PedidoCancelamento_MotivoForaDoTamanho_DeveLancar(string motivo) =>
        FluentActions.Invoking(() => EventosNfseNacional.MontarPedidoCancelamento(
                Chave, CnpjAutor, MotivoCancelamentoNfse.Outros, motivo,
                Schemas.NFSe.Nacional.Ambiente.Homologacao, "EficazFramework.SPED"))
            .Should().Throw<ArgumentException>();

    [Test]
    public void PedidoCancelamento_ChaveInvalida_DeveLancar() =>
        FluentActions.Invoking(() => EventosNfseNacional.MontarPedidoCancelamento(
                "123", CnpjAutor, MotivoCancelamentoNfse.Outros, Motivo,
                Schemas.NFSe.Nacional.Ambiente.Homologacao, "EficazFramework.SPED"))
            .Should().Throw<ArgumentException>();

    [Test]
    public async Task CancelarNfseAsync_DeveEnviarPedidoAssinadoELerOEventoRegistrado()
    {
        var handler = new HandlerFalso(HttpStatusCode.Created,
            JsonSerializer.Serialize(new
            {
                tipoAmbiente = 2,
                versaoAplicativo = "SefinNacional_1.0",
                dataHoraProcessamento = "2026-10-06T10:31:00",
                eventoXmlGZipB64 = NfseNacionalCompression.CompressToGZipBase64(XmlEvento("101101", "Cancelamento de NFS-e"))
            }));
        using var service = new NfseNacionalService(handler) { SelecionaCertificado = InstanciaCertificado };

        var retorno = await service.CancelarNfseAsync(Chave, MotivoCancelamentoNfse.ErroNaEmissao, Motivo,
            Schemas.NFSe.Nacional.Ambiente.Homologacao, CnpjAutor);

        handler.Url.Should().Be($"https://sefin.producaorestrita.nfse.gov.br/SefinNacional/nfse/{Chave}/eventos");
        handler.Metodo.Should().Be(HttpMethod.Post);

        using var corpo = JsonDocument.Parse(handler.Corpo!);
        var xmlEnviado = NfseNacionalCompression.DecompressFromGZipBase64(corpo.RootElement.GetProperty("pedidoRegistroEventoXmlGZipB64").GetString());
        xmlEnviado.Should().Contain("<pedRegEvento").And.Contain("Signature").And.Contain($"PRE{Chave}101101");

        retorno.Sucesso.Should().BeTrue();
        retorno.StatusCode.Should().Be(201);
        retorno.Erros.Should().BeEmpty();
        retorno.Evento.Should().NotBeNull();
        retorno.Evento!.TipoEvento.Should().Be(TipoEventoNfse.Cancelamento);
        retorno.Evento.CancelaNfse.Should().BeTrue();
        retorno.Evento.ChaveAcesso.Should().Be(Chave);
        retorno.Evento.InfEvento!.NumeroSequencial.Should().Be(1);
        retorno.Evento.InfEvento.AmbienteGerador.Should().Be(AmbienteGeradorEvento.SefinNacional);
        retorno.Evento.DocumentType.Should().Be(XmlDocumentType.NFS_e_Nacional_Evento);
    }

    [Test]
    public async Task RegistrarEventoAsync_Rejeicao_DeveReunirOsErros()
    {
        var handler = new HandlerFalso(HttpStatusCode.BadRequest,
            "{\"tipoAmbiente\":2,\"erros\":[{\"codigo\":\"E0840\",\"descricao\":\"NFS-e ja cancelada\"}]}");
        using var service = new NfseNacionalService(handler) { SelecionaCertificado = InstanciaCertificado };

        var retorno = await service.CancelarNfseAsync(Chave, MotivoCancelamentoNfse.Outros, Motivo,
            Schemas.NFSe.Nacional.Ambiente.Homologacao, CnpjAutor);

        retorno.Sucesso.Should().BeFalse();
        retorno.Erros.Should().ContainSingle(e => e.Codigo == "E0840");
        retorno.Evento.Should().BeNull();
    }

    [Test]
    public async Task ConsultarEventosAsync_DeveIndicarNotaCancelada()
    {
        var handler = new HandlerFalso(HttpStatusCode.OK,
            JsonSerializer.Serialize(new
            {
                tipoAmbiente = 2,
                eventos = new[]
                {
                    new { eventoXmlGZipB64 = NfseNacionalCompression.CompressToGZipBase64(XmlEvento("202201", "Manifestação de NFS-e - Confirmação do Prestador")) },
                    new { eventoXmlGZipB64 = NfseNacionalCompression.CompressToGZipBase64(XmlEvento("101101", "Cancelamento de NFS-e")) }
                }
            }));
        using var service = new NfseNacionalService(handler) { SelecionaCertificado = InstanciaCertificado };

        var retorno = await service.ConsultarEventosAsync(Chave, Schemas.NFSe.Nacional.Ambiente.Producao);

        handler.Url.Should().Be($"https://sefin.nfse.gov.br/nfse/{Chave}/eventos");
        retorno.Eventos.Should().HaveCount(2);
        retorno.NfseCancelada.Should().BeTrue();
    }

    [Test]
    public async Task ConsultarEventosAsync_PorTipoESequencia_DeveMontarARota()
    {
        var handler = new HandlerFalso(HttpStatusCode.NotFound, string.Empty);
        using var service = new NfseNacionalService(handler) { SelecionaCertificado = InstanciaCertificado };

        var retorno = await service.ConsultarEventosAsync(Chave, Schemas.NFSe.Nacional.Ambiente.Homologacao, TipoEventoNfse.Cancelamento, 1);

        handler.Url.Should().EndWith($"/nfse/{Chave}/eventos/101101/1");
        retorno.StatusCode.Should().Be(404);
        retorno.Eventos.Should().BeEmpty();
        retorno.NfseCancelada.Should().BeFalse();
    }

    [Test]
    public async Task ConsultarEventosAsync_SequenciaSemTipo_DeveLancar()
    {
        using var service = new NfseNacionalService(new HandlerFalso(HttpStatusCode.OK, "{}")) { SelecionaCertificado = InstanciaCertificado };

        await FluentActions.Awaiting(() => service.ConsultarEventosAsync(Chave, numeroSequencial: 1))
            .Should().ThrowAsync<ArgumentException>();
    }

    [Test]
    public async Task OpenAsync_DeveReconhecerEventoEPedido()
    {
        using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(XmlEvento("101101", "Cancelamento de NFS-e"))))
        {
            var documento = await Operations.OpenAsync(stream);
            var evento = documento.Should().BeOfType<EventoNfse>().Subject;
            evento.DocumentType.Should().Be(XmlDocumentType.NFS_e_Nacional_Evento);
            evento.Chave.Should().Be($"EVT{Chave}101101001");
            evento.CancelaNfse.Should().BeTrue();
            evento.InfEvento!.PedidoRegistroEvento!.InfPedReg!.Detalhe.Should().BeOfType<EventoCancelamento>();
        }

        using var service = CreateClient();
        var pedido = EventosNfseNacional.MontarPedidoCancelamento(
            Chave, CnpjAutor, MotivoCancelamentoNfse.ErroNaEmissao, Motivo,
            Schemas.NFSe.Nacional.Ambiente.Homologacao, service.VersaoAplicativo);
        var assinado = service.AssinarPedidoEvento(pedido);

        using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(assinado.OuterXml)))
        {
            var documento = await Operations.OpenAsync(stream);
            var lido = documento.Should().BeOfType<PedidoRegistroEvento>().Subject;
            lido.DocumentType.Should().Be(XmlDocumentType.NFS_e_Nacional_PedidoEvento);
            lido.Signature.Should().NotBeNull();
            lido.InfPedReg!.ChaveAcesso.Should().Be(Chave);
        }
    }

    [Test]
    public void LerEvento_XmlQueNaoEEvento_DeveDevolverNulo()
    {
        EventosNfseNacional.LerEvento("<outro/>").Should().BeNull();
        EventosNfseNacional.LerEvento("nao e xml").Should().BeNull();
        EventosNfseNacional.LerEvento(null).Should().BeNull();
    }

    // ─── Auxiliares ───

    /// <summary>XML de um evento como devolvido pela Sefin (infEvento com o pedido dentro).</summary>
    private static string XmlEvento(string codigo, string descricao) =>
        $"""
        <evento xmlns="http://www.sped.fazenda.gov.br/nfse" versao="1.01">
          <infEvento Id="EVT{Chave}{codigo}001">
            <verAplic>SefinNacional_1.0</verAplic>
            <ambGer>2</ambGer>
            <nSeqEvento>1</nSeqEvento>
            <dhProc>2026-10-06T10:31:00-03:00</dhProc>
            <nDFSe>123</nDFSe>
            <pedRegEvento versao="1.01">
              <infPedReg Id="PRE{Chave}{codigo}">
                <tpAmb>2</tpAmb>
                <verAplic>EficazFramework.SPED</verAplic>
                <dhEvento>2026-10-06T10:30:15-03:00</dhEvento>
                <CNPJAutor>{CnpjAutor}</CNPJAutor>
                <chNFSe>{Chave}</chNFSe>
                <e{codigo}>
                  <xDesc>{descricao}</xDesc>
                </e{codigo}>
              </infPedReg>
            </pedRegEvento>
          </infEvento>
        </evento>
        """;

    /// <summary>Valida o XML contra o XSD oficial (com os includes e o xmldsig).</summary>
    private static List<string> ValidarNoXsd(string xml, string xsd)
    {
        var erros = new List<string>();
        var leitura = new XmlReaderSettings { DtdProcessing = DtdProcessing.Parse, XmlResolver = new XmlUrlResolver() };
        var schemas = new XmlSchemaSet { XmlResolver = new XmlUrlResolver() };
        using (var reader = XmlReader.Create(Path.Combine(PastaSchemas, xsd), leitura))
            schemas.Add(null, reader);
        schemas.Compile();

        var validacao = new XmlReaderSettings { ValidationType = ValidationType.Schema, Schemas = schemas };
        validacao.ValidationEventHandler += (_, e) => erros.Add($"{e.Severity}: {e.Message}");
        using var leitor = XmlReader.Create(new StringReader(xml), validacao);
        while (leitor.Read()) { }
        return erros;
    }

    /// <summary>Registra a requisição e devolve a resposta configurada.</summary>
    private sealed class HandlerFalso(HttpStatusCode status, string resposta) : HttpMessageHandler
    {
        public string? Url { get; private set; }
        public HttpMethod? Metodo { get; private set; }
        public string? Corpo { get; private set; }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Url = request.RequestUri!.ToString();
            Metodo = request.Method;
            Corpo = request.Content is null ? null : await request.Content.ReadAsStringAsync(cancellationToken);
            return new HttpResponseMessage(status) { Content = new StringContent(resposta, Encoding.UTF8, "application/json") };
        }
    }
}
