namespace EficazFramework.SPED.Services.NFe;

public class ConsultaProtocoloTests : BaseNFeTests
{
    [Test]
    [TestCase("31231211211692000133550020000514371000517813", SPED.Schemas.NFe.Ambiente.Producao, "100")]
    [TestCase("31240134557109000146550010000001011828480400", SPED.Schemas.NFe.Ambiente.Producao, "101")]
    public async Task ConsultaProtocoloAsync(string chave, SPED.Schemas.NFe.Ambiente ambiente, string resultadoCodigo)
    {
        var client = CreateClient();
        var result = await client.ConsultaProtocolo4Async(chave, ambiente);
        result.Should().NotBeNull();    
        result.ChaveNFe.Should().Be(chave);
        result.Ambiente.Should().Be(ambiente);
        result.RetornoCodigo.Should().Be(resultadoCodigo);
        result.ProtocoloNFe.Should().NotBeNull();
        result.ProtocoloNFe.InformacoesProtocolo.Should().NotBeNull();
        result.ProtocoloNFe.InformacoesProtocolo.Ambiente.Should().Be(ambiente);
        result.ProtocoloNFe.InformacoesProtocolo.ChaveNFe.Should().Be(chave);
    }
}
