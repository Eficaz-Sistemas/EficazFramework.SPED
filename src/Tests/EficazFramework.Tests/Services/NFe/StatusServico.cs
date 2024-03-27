namespace EficazFramework.SPED.Services.NFe;

public class StatusServicoTests : BaseNFeTests
{
    [Test]
    [TestCase(Schemas.NFe.OrgaoIBGE.MG, "55", SPED.Schemas.NFe.Ambiente.Producao)]
    [TestCase(Schemas.NFe.OrgaoIBGE.MG, "65", SPED.Schemas.NFe.Ambiente.Producao)]
    public async Task ConsultaProtocoloAsync(Schemas.NFe.OrgaoIBGE uf, string modelo, Schemas.NFe.Ambiente ambiente)
    {
        var client = CreateClient();
        var result = await client.ConsultaStatusServicoAsync(uf, modelo, ambiente);
        result.Should().NotBeNull();    
        result.Ambiente.Should().Be(ambiente);
        result.DataRetorno.Should().NotBeNull();
    }
}
