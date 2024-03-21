using EficazFramework.SPED.Schemas;

namespace EficazFramework.SPED.Services.CTe;

public class CTeDistribuicaoDF : BaseCTeTests
{
    [Test]
    [TestCase(SPED.Schemas.NFe.OrgaoIBGE.MG, SPED.Schemas.NFe.Ambiente.Producao)]
    public async Task NsuTest(Schemas.NFe.OrgaoIBGE uf, SPED.Schemas.NFe.Ambiente ambiente)
    {
        var client = CreateClient();
        var result = await client.DistribuicaoDFeAsync(uf, Configuration["SSL:NFE:CertificateCnpjCpf"], 0, ambiente);
        result.Should().NotBeNull();  
        
        if (result.cStat == "656" && result.xMotivo.Contains("Deve ser utilizado o ultNSU"))
        {
            result.loteDistDFeInt?.DocZip?.Should().HaveCount(0);
            result.ultNSU.Should().NotBe("000000000000000");
            var ultNsuResult = await client.DistribuicaoDFeAsync(uf, Configuration["SSL:NFE:CertificateCnpjCpf"], int.Parse(result.ultNSU), ambiente);
            ultNsuResult.Should().NotBeNull();
        }

        if (result.cStat == "137")
            result.loteDistDFeInt.DocZip.Should().HaveCount(0);

        if (result.cStat == "138")
        {
            result.loteDistDFeInt.DocZip.Should().HaveCountGreaterThan(0);
            var someCte = result.loteDistDFeInt.DocZip.Where(z => z.schema == "procCTe_v3.00.xsd").FirstOrDefault();
            if (someCte != null)
            {
                var cteArray = await someCte.DescompactaAsync();
                IXmlSpedDocument cte = await EficazFramework.SPED.Utilities.XML.Operations.OpenAsync(new MemoryStream(cteArray));
                cte.DocumentType.Should().Be(Schemas.XmlDocumentType.CTeWithProtocol);
                Console.WriteLine(cte.Chave);
            }
        }
    }
}
