using EficazFramework.SPED.Schemas.IntegraContador;
using EficazFramework.SPED.Schemas.IntegraContador.IntegraProcuracoes;

namespace EficazFramework.SPED.Services.IntegraContador;

/// <summary>
/// Integra-Procurações: PROCURACOES / OBTERPROCURACAO41, com o exemplo de retorno da documentação.
/// </summary>
public class IntegraProcuracoesTests : BaseIntegraContadorTests
{
    [Test]
    public async Task ProcuracoesObter_DeveEnviarOutorganteEOutorgadoELerProcuracoes()
    {
        var handler = new HandlerFalso
        {
            Dados = """[{"dtexpiracao":"20230414", "nrsistemas":2,"sistemas":["Caixa Postal - Mensagens","Caixa Postal - Termo de Opção pelo Domicílio Tributário Eletrônico"]},{"dtexpiracao":"20221231", "nrsistemas":3,"sistemas":["Declarações - DIRPF","Meu Imposto de Renda","Opção de Impressão do IRPF"]}]"""
        };
        using var service = CriarServico(handler);

        var resposta = await service.ProcuracoesObterAsync(Contribuinte,
            ObterProcuracao.Criar(Identificacao.Cnpj("99999999999999"), Identificacao.Cpf("99999999999")));

        var pedido = handler.Chamadas.Single();
        pedido.Url.Should().EndWith("/Consultar");
        pedido.Requisicao.PedidoDados.IdSistema.Should().Be("PROCURACOES");
        pedido.Requisicao.PedidoDados.IdServico.Should().Be("OBTERPROCURACAO41");
        pedido.Requisicao.PedidoDados.VersaoSistema.Should().Be("1");

        var dados = DadosEnviados(handler);
        dados.GetProperty("outorgante").GetString().Should().Be("99999999999999");
        dados.GetProperty("tipoOutorgante").GetString().Should().Be("2");
        dados.GetProperty("outorgado").GetString().Should().Be("99999999999");
        dados.GetProperty("tipoOutorgado").GetString().Should().Be("1");

        resposta.Retorno.Should().HaveCount(2);
        var procuracao = resposta.Retorno![0];
        procuracao.DtExpiracao.Should().Be("20230414");
        procuracao.NrSistemas.Should().Be(2);
        procuracao.Sistemas.Should().Equal("Caixa Postal - Mensagens", "Caixa Postal - Termo de Opção pelo Domicílio Tributário Eletrônico");
        resposta.Retorno[1].NrSistemas.Should().Be(3);
        resposta.Retorno[1].Sistemas.Should().HaveCount(3);
    }

    [Test]
    public async Task ProcuracoesObter_DadosNulos_DeveLancarArgumentNull()
    {
        using var service = CriarServico(new HandlerFalso());

        await FluentActions.Awaiting(() => service.ProcuracoesObterAsync(Contribuinte, null!))
            .Should().ThrowAsync<ArgumentNullException>().WithParameterName("dados");
    }
}
