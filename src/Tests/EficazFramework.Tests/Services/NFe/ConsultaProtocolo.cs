namespace EficazFramework.SPED.Services.NFe;

public class ConsultaProtocoloTests : BaseNFeTests
{
    [Test]
    [TestCase("31240134557109000146550010000001011828480400", SPED.Schemas.NFe.Ambiente.Producao)]
    public async Task ConsultaProtocoloAsync(string chave, SPED.Schemas.NFe.Ambiente ambiente)
    {
        var client = CreateClient();
        await client.ConsultaProtocoloAsync(chave, ambiente);

    }
}
