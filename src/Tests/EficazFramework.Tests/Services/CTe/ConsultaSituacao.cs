namespace EficazFramework.SPED.Services.CTe;

public class ConsultaSituacaoTests : BaseCTeTests
{
    [Test]
    [TestCase("35231029749080000164570000000034431199972606", SPED.Schemas.NFe.Ambiente.Producao, "100")]
    [TestCase("35231029749080000164570000000034391173440531", SPED.Schemas.NFe.Ambiente.Producao, "101")]
    public async Task ConsultaProtocoloAsync(string chave, SPED.Schemas.NFe.Ambiente ambiente, string resultadoCodigo)
    {
        var client = CreateClient();
        var result = await client.ConsultaSituacaoAsync(chave, ambiente);
        result.Should().NotBeNull();    
        result.Ambiente.Should().Be(ambiente);
        result.RetornoCodigo.Should().BeOneOf(resultadoCodigo, "731");
        if (result.RetornoCodigo != "731")
        {
            result.ProtocoloCTe.Should().NotBeNull();
            result.ProtocoloCTe.infProt.Should().NotBeNull();
            result.ProtocoloCTe.infProt.tpAmb.Should().Be(ambiente);
            result.ProtocoloCTe.infProt.chCTe.Should().Be(chave);
        }
    }
}
