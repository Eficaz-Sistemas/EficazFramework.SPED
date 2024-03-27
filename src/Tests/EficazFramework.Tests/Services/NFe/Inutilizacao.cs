namespace EficazFramework.SPED.Services.NFe;

public class InutilizacaoTests : BaseNFeTests
{
    [Test]
    [TestCase(Schemas.NFe.OrgaoIBGE.MG, 75, 77, Schemas.NFe.ModeloDocumento.NFe, 99, "falha na sequencia de numeração.", SPED.Schemas.NFe.Ambiente.Homologacao)]
    public async Task InutilizaAsyncAsync(
        Schemas.NFe.OrgaoIBGE uf,
        long NfInicio, 
        long NfFim,
        Schemas.NFe.ModeloDocumento modelo, 
        int serie,
        string justificativa,
        Schemas.NFe.Ambiente ambiente)
    {
        var client = CreateClient();
        client.SelecionaCertificado = InstanciaCertificadoAutorizacao; // aqui estamos fazendo algumas mudanças para usar outro certificado
        var result = await client.InutilizaAsync(Configuration["SSL:NFEAUTH:CertificateCnpjCpf"], uf, [NfInicio, NfFim], serie, justificativa, modelo, ambiente);
        result.Should().NotBeNull();
        result.infInut.Should().NotBeNull();
        result.infInut.tpAmb.Should().Be(ambiente);
        result.infInut.cStat.Should().NotBeNull();
    }





    /// <summary>
    /// Define o certificado digital a ser utilizado nas requests.
    /// </summary>
    /// <returns></returns>
    internal Func<Utilities.IcpBrasilX509Certificate2> InstanciaCertificadoAutorizacao => () =>
    {
        string path = Configuration["SSL:NFEAUTH:CertificatePath"];
        if (!string.IsNullOrEmpty(path) && Path.Exists(path))
            return new Utilities.IcpBrasilX509Certificate2(path, Configuration["SSL:NFEAUTH:CertificatePassword"]);

        return new Utilities.IcpBrasilX509Certificate2(Resources.Certificados.WayneEnterprisesInc, "1234");
    };

}
