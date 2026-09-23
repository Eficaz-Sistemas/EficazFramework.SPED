namespace EficazFramework.SPED.Services.eSocial;

public class EnviaLoteEventsTests : BaseESocialTests
{
    [Test]
    public async Task EnviaLoteEventosCadastraisAsync()
    {

        var empregador = new EficazFramework.SPED.Schemas.eSocial.Empregador()
        {
            nrInsc = Configuration["SSL:ESOCIAL:CertificateCnpjCpf"][..8],
            tpInsc = Schemas.eSocial.PersonalidadeJuridica.CNPJ
        };
        var s1000 = new EficazFramework.SPED.Schemas.eSocial.S1000();
        EficazFramework.SPED.Schemas.eSocial.S1000Test.PreencheCamposInclusao(s1000, Configuration["SSL:ESOCIAL:CertificateCnpjCpf"]);

        var client = CreateClient();
        client.SelecionaCertificado = InstanciaCertificado;
        var result = await client.EnviaEventosAsync([s1000], empregador, Schemas.eSocial.Ambiente.ProducaoRestrita_DadosReais);
        result.Should().NotBeNull();
        result.retornoEnvioLoteEventos.Should().NotBeNull();
        result.retornoEnvioLoteEventos.status.cdResposta.Should().Be(201);
        result.retornoEnvioLoteEventos.status.descResposta.Should().Be("Lote Recebido com Sucesso.");
        result.retornoEnvioLoteEventos.dadosRecepcaoLote.protocoloEnvio.Should().NotBeNullOrEmpty();
    }
}