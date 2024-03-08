namespace EficazFramework.SPED.Services.NFe;

public class RecepcaoEvento4Tests : BaseNFeTests
{
    [Test]
    [TestCase("31240209041929000133550010000273651000332943")]
    public async Task CienciaOperacaoTest(string chave)
    {
        var client = CreateClient();
        var result = await client.EnvioEventoAsync(Configuration["SSL:NFE:CertificateCnpjCpf"], chave, Schemas.NFe.CodigoEvento.Ciencia, Schemas.NFe.Ambiente.Homologacao, null);
        result.Should().NotBeNull();

        result.RespostaCodigo.Should().Be("128"); 
        result.ResultadoEventos.Should().HaveCount(1);
        //estamos tentando dar Ciência em ambiente de homologação em documento que foi emitido em produção,
        //contudo, se a resposta for 252, ao menos o schema XML temos assegurado conformidade.
        result.ResultadoEventos[0].InformacaoEventoRetorno.RespostaCodigo.Should().Be("252");
        result.ResultadoEventos[0].InformacaoEventoRetorno.EventoCodigo.Should().Be(Schemas.NFe.CodigoEvento.Ciencia);
        result.ResultadoEventos[0].InformacaoEventoRetorno.ChaveNFe.Should().Be(chave);
    }
}
