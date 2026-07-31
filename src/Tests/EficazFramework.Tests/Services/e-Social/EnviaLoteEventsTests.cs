namespace EficazFramework.SPED.Services.eSocial;

public class EnviaLoteEventsTests : BaseESocialTests
{
    [Test]
    public async Task EnviaLoteEventosCadastraisAsync()
    {

        var empregador = new EficazFramework.SPED.Schemas.eSocial.Empregador()
        {
            nrInsc = Configuration["SSL:ESOCIAL:CertificateCnpjCpf"],
            tpInsc = Schemas.eSocial.PersonalidadeJuridica.CNPJ
        };
        var s1000 = new EficazFramework.SPED.Schemas.eSocial.S1000();
        EficazFramework.SPED.Schemas.eSocial.S1000Test.PreencheCamposInclusao(s1000, Configuration["SSL:ESOCIAL:CertificateCnpjCpf"]);

        var client = CreateClient();
        client.SelecionaCertificado = InstanciaCertificado;
        var result = await client.EnviaEventosAsync([s1000], empregador, Schemas.eSocial.Ambiente.ProducaoRestrita_DadosReais);
        result.Should().NotBeNull();
        //result.retornoEnvioLoteEventos.dadosRecepcaoLote..Should().Be(Schemas.eSocial.Ambiente.ProducaoRestrita_DadosReais);
        //result.RetornoCodigo.Should().Be("104");
        //result.ProtocoloRecebimento.Should().NotBeNull();
        //result.ProtocoloRecebimento.InformacoesProtocolo.StatusNFeCodigo.Should().BeOneOf("203", "230", "231"); //Emitente não cadastrado para emissão de NFe
    }
}