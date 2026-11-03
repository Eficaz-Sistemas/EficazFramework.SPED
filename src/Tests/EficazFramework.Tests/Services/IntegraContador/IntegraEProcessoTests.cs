using EficazFramework.SPED.Schemas.IntegraContador.IntegraEProcesso;
using System.Net;

namespace EficazFramework.SPED.Services.IntegraContador;

/// <summary>
/// Integra-e-Processo: EPROCESSO / CONSPROCPORINTER271, com o exemplo de retorno da documentação.
/// </summary>
public class IntegraEProcessoTests : BaseIntegraContadorTests
{
    private const string ProcessosJson = """
        [{"numeroDoProcesso":"00000000000000001","relacaoDoInteressadoComOProcesso":"INTERESSADO","dataDeProtocolo":"01/01/2020",
          "tipoDoProcesso":"AÇÃO FISCAL","subtipoDoProcesso":"MEMORIAL","localizacao":"DRJ","situacao":"CONFIRMADO","ultimoEncaminhamentoExterno":null},
         {"numeroDoProcesso":"00000000000000002","relacaoDoInteressadoComOProcesso":"INTERESSADO","dataDeProtocolo":"01/01/2020",
          "tipoDoProcesso":"AÇÃO FISCAL","subtipoDoProcesso":"MEMORIAL","localizacao":"CARF","situacao":"CONFIRMADO","ultimoEncaminhamentoExterno":null}]
        """;

    [Test]
    public async Task EProcessoConsultarProcessos_DeveEnviarDadosVaziosELerProcessos()
    {
        var handler = new HandlerFalso { Dados = ProcessosJson };
        using var service = CriarServico(handler);

        var resposta = await service.EProcessoConsultarProcessosAsync(Contribuinte);

        var pedido = handler.Chamadas.Single();
        pedido.Url.Should().EndWith("/Consultar");
        pedido.Requisicao.PedidoDados.IdSistema.Should().Be("EPROCESSO");
        pedido.Requisicao.PedidoDados.IdServico.Should().Be("CONSPROCPORINTER271");
        pedido.Requisicao.PedidoDados.VersaoSistema.Should().Be("2.0");
        pedido.Requisicao.PedidoDados.Dados.Should().BeEmpty();

        resposta.Retorno.Should().HaveCount(2);
        var processo = resposta.Retorno![0];
        processo.NumeroDoProcesso.Should().Be("00000000000000001");
        processo.RelacaoDoInteressadoComOProcesso.Should().Be("INTERESSADO");
        processo.DataDeProtocolo.Should().Be("01/01/2020");
        processo.TipoDoProcesso.Should().Be("AÇÃO FISCAL");
        processo.SubtipoDoProcesso.Should().Be("MEMORIAL");
        processo.Localizacao.Should().Be("DRJ");
        processo.Situacao.Should().Be("CONFIRMADO");
        processo.UltimoEncaminhamentoExterno.Should().BeNull();
        resposta.Retorno[1].Localizacao.Should().Be("CARF");
    }

    [Test]
    public async Task EProcessoConsultarProcessos_DeveAceitarDadosComoArrayJson()
    {
        // o exemplo de retorno da documentação traz "dados" como array JSON, e não como string escapada
        var handler = new HandlerFalso();
        handler.Respostas.Enqueue(() => HandlerFalso.Json(HttpStatusCode.OK,
            $$"""{"status":200,"dados":{{ProcessosJson}},"mensagens":[{"codigo":"[Sucesso-EPROCESSO-SC_001]","texto":"Requisição efetuada com sucesso."}]}"""));
        using var service = CriarServico(handler);

        var resposta = await service.EProcessoConsultarProcessosAsync(Contribuinte);

        resposta.Retorno.Should().HaveCount(2);
        resposta.Retorno![1].NumeroDoProcesso.Should().Be("00000000000000002");
    }
}
