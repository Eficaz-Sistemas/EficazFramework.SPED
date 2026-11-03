using EficazFramework.SPED.Schemas.IntegraContador;
using EficazFramework.SPED.Schemas.IntegraContador.Gerenciador;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.Xml;
using System.Text;

namespace EficazFramework.SPED.Services.IntegraContador;

/// <summary>
/// AUTENTICAPROCURADOR: geração e assinatura do termo de autorização e obtenção do token do procurador.
/// </summary>
public class ProcuradorTests : BaseIntegraContadorTests
{
    private const string TokenProcurador = "b06feea3-1ca8-49f4-bdb4-211ab006cb92";

    private static TermoAutorizacao Termo => new()
    {
        CnpjContratante = CnpjContratante,
        NomeContratante = "EMPRESA CONTRATANTE",
        NumeroAutor = "00000000000000",
        NomeAutor = "ESCRITORIO CONTABIL",
        TipoAutor = TipoIdentificacao.CNPJ,
        DataAssinatura = new DateTime(2026, 10, 28),
        Vigencia = new DateTime(2027, 10, 28)
    };

    [Test]
    public void GerarXml_DeveSeguirLayoutDoTermo()
    {
        var xml = Termo.GerarXml();

        xml.FirstChild.Should().BeOfType<XmlElement>("o exemplo da documentação não tem declaração XML");
        xml.DocumentElement!.Name.Should().Be("termoDeAutorizacao");
        var dados = xml.DocumentElement["dados"]!;
        dados.ChildNodes.Cast<XmlElement>().Select(e => e.Name).Should().Equal(
            "sistema", "termo", "avisoLegal", "finalidade", "dataAssinatura", "vigencia", "destinatario", "assinadoPor");
        dados["sistema"]!.GetAttribute("id").Should().Be("API Integra Contador");
        dados["termo"]!.GetAttribute("texto").Should().StartWith("Autorizo a empresa CONTRATANTE");
        dados["dataAssinatura"]!.GetAttribute("data").Should().Be("20261028");
        dados["vigencia"]!.GetAttribute("data").Should().Be("20271028");
        dados["destinatario"]!.GetAttribute("numero").Should().Be(CnpjContratante);
        dados["destinatario"]!.GetAttribute("tipo").Should().Be("PJ");
        dados["destinatario"]!.GetAttribute("papel").Should().Be("contratante");
        dados["assinadoPor"]!.GetAttribute("tipo").Should().Be("PJ");
        dados["assinadoPor"]!.GetAttribute("papel").Should().Be("autor pedido de dados");
        xml.OuterXml.Should().NotContain("\n");
    }

    [Test]
    public void AssinarTermo_DeveGerarAssinaturaEnvelopedRsaSha256Valida()
    {
        using var service = CriarServico(new HandlerFalso());

        var base64 = service.AssinarTermo(Termo);

        var xml = new XmlDocument { PreserveWhitespace = true };
        xml.LoadXml(Encoding.UTF8.GetString(Convert.FromBase64String(base64)));
        var assinatura = (XmlElement)xml.DocumentElement!.LastChild!;
        assinatura.LocalName.Should().Be("Signature");
        assinatura.NamespaceURI.Should().Be("http://www.w3.org/2000/09/xmldsig#");

        var signed = new SignedXml(xml);
        signed.LoadXml(assinatura);
        signed.SignatureMethod.Should().Be("http://www.w3.org/2001/04/xmldsig-more#rsa-sha256");
        var referencia = (Reference)signed.SignedInfo!.References[0]!;
        referencia.Uri.Should().BeEmpty();
        referencia.DigestMethod.Should().Be("http://www.w3.org/2001/04/xmlenc#sha256");
        signed.CheckSignature().Should().BeTrue();
    }

    [Test]
    public async Task AutenticarProcurador_DeveEnviarTermoEGuardarToken()
    {
        var handler = new HandlerFalso { Dados = $"{{\"autenticar_procurador_token\":\"{TokenProcurador}\",\"data_hora_expiracao\":\"2026-10-30T00:00:01\"}}" };
        using var service = CriarServico(handler);

        var resposta = await service.AutenticarProcuradorAsync(Termo);

        var pedido = handler.Chamadas.Single();
        pedido.Url.Should().EndWith("/Apoiar");
        var requisicao = pedido.Requisicao;
        requisicao.PedidoDados.IdSistema.Should().Be("AUTENTICAPROCURADOR");
        requisicao.PedidoDados.IdServico.Should().Be("ENVIOXMLASSINADO81");
        requisicao.AutorPedidoDados.Should().Be(Identificacao.Cnpj("00000000000000"));
        DadosEnviados(handler).GetProperty("xml").GetString().Should().NotBeNullOrEmpty();

        resposta.Retorno!.Token.Should().Be(TokenProcurador);
        resposta.Retorno.DataHoraExpiracao.Should().Be(new DateTime(2026, 10, 30, 0, 0, 1));
        service.TokenProcurador.Should().Be(TokenProcurador);
        service.AutorPedidoDados.Should().Be(Identificacao.Cnpj("00000000000000"));

        // chamadas seguintes usam o autor e o token do procurador
        await service.ExecutarAsync(Catalogo.Pgdasd.GerarDas, Contribuinte, "{}");
        handler.Chamadas.Last().Cabecalho("autenticar_procurador_token").Should().Be(TokenProcurador);
        handler.Chamadas.Last().Requisicao.AutorPedidoDados.Should().Be(Identificacao.Cnpj("00000000000000"));
    }

    [Test]
    public async Task AutenticarProcurador_304_DeveLerTokenDoCache()
    {
        var expira = new DateTimeOffset(2026, 10, 30, 3, 0, 1, TimeSpan.Zero);
        var handler = new HandlerFalso();
        handler.Respostas.Enqueue(() =>
        {
            var r = new HttpResponseMessage(HttpStatusCode.NotModified) { Content = new StringContent("") };
            r.Headers.TryAddWithoutValidation("ETag", $"\"autenticar_procurador_token:{TokenProcurador}\"");
            r.Content.Headers.Expires = expira;
            return r;
        });
        using var service = CriarServico(handler);

        var resposta = await service.AutenticarProcuradorAsync("PHRlcm1v", Identificacao.Cpf("11111111111"));

        resposta.StatusCode.Should().Be(304);
        resposta.Retorno!.Token.Should().Be(TokenProcurador);
        resposta.Expires.Should().Be(expira);
        service.TokenProcurador.Should().Be(TokenProcurador);
    }
}
