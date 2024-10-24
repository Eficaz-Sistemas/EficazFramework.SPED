namespace EficazFramework.SPED.Services.NFe;

public class NFeDistribuicaoDFeTests : BaseNFeTests
{
    [Test]
    [TestCase(SPED.Schemas.NFe.OrgaoIBGE.MG, SPED.Schemas.NFe.Ambiente.Homologacao)]
    [TestCase(SPED.Schemas.NFe.OrgaoIBGE.MG, SPED.Schemas.NFe.Ambiente.Producao)]
    public async Task NsuTest(Schemas.NFe.OrgaoIBGE uf, SPED.Schemas.NFe.Ambiente ambiente)
    {
        var client = CreateClient();
        var result = await client.DistribuicaoDFeAsync(uf, Configuration["SSL:NFE:CertificateCnpjCpf"], 0, ambiente, null);
        result.Should().NotBeNull();  
        
        if (result.cStat == "656" && result.xMotivo.Contains("Deve ser utilizado o ultNSU"))
        {
            result.loteDistDFeInt?.docZip?.Should().HaveCount(0);
            result.ultNSU.Should().NotBe("000000000000000");
            var ultNsuResult = await client.DistribuicaoDFeAsync(uf, Configuration["SSL:NFE:CertificateCnpjCpf"], int.Parse(result.ultNSU), ambiente, null);
            ultNsuResult.Should().NotBeNull();
        }

        if (result.cStat == "137")
            result.loteDistDFeInt?.docZip.Should().HaveCount(0);

        if (result.cStat == "138")
        {
            result.loteDistDFeInt.docZip.Should().HaveCountGreaterThan(0);
        }
    }

    [Test]
    [TestCase("31240209041929000133550010000273651000332943", SPED.Schemas.NFe.OrgaoIBGE.MG, SPED.Schemas.NFe.Ambiente.Producao, "632")]
    [TestCase("31240209041929000133550010000273651000332942", SPED.Schemas.NFe.OrgaoIBGE.MG, SPED.Schemas.NFe.Ambiente.Producao, "236")]
    [TestCase("31210109041929000133550010000226381000273464", SPED.Schemas.NFe.OrgaoIBGE.MG, SPED.Schemas.NFe.Ambiente.Producao, "632")]
    public async Task ChaveTest(string chave, Schemas.NFe.OrgaoIBGE uf, SPED.Schemas.NFe.Ambiente ambiente, string resultadoCodigo)
    {
        var client = CreateClient();
        var result = await client.DistribuicaoDFeAsync(uf, Configuration["SSL:NFE:CertificateCnpjCpf"], 0, ambiente, chave);
        result.Should().NotBeNull();
        result.cStat.Should().Be(resultadoCodigo);

        if (result.cStat == "137")
            result.loteDistDFeInt.docZip.Should().HaveCount(0);

        if (result.cStat == "138")
        {
            result.loteDistDFeInt.docZip.Should().HaveCount(1);
            result.loteDistDFeInt.docZip[0].schema.Should().Be("procNFe_v4.00.xsd");
            Schemas.NFe.ProcessoNFe instancia = await Schemas.NFe.ProcessoNFe.LoadFromAsync(new System.IO.MemoryStream(await result.loteDistDFeInt.docZip[0].DescompactaAsync()));
            instancia.Should().NotBeNull();
            instancia.Chave.Should().Be(chave);
        }
    }



    [Test]
    [TestCase(Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://hom1.nfe.fazenda.gov.br/NFeDistribuicaoDFe/NFeDistribuicaoDFe.asmx")]
    [TestCase(Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://www1.nfe.fazenda.gov.br/NFeDistribuicaoDFe/NFeDistribuicaoDFe.asmx")]

    public string VerificaUrls(Schemas.NFe.Ambiente ambiente)
    {
        var client = CreateClient<SoapClients.NFeDistribuicaoDFeSoapClient>(ambiente.ToString());
        return client.Endpoint.Address.Uri.AbsoluteUri;
    }
}
