namespace EficazFramework.SPED.Services.NFe;

public class BaseNFeTests : Tests.BaseTest
{
    internal EficazFramework.SPED.Services.NFe.NFeService CreateClient()
    {
        var client = new NFeService();
        client.SelecionaCertificado = InstanciaCertificado;
        return client;
    }


    /// <summary>
    /// Define o certificado digital a ser utilizado nas requests.
    /// </summary>
    /// <returns></returns>
    internal Func<Utilities.IcpBrasilX509Certificate2> InstanciaCertificado => () =>
    {
        string path = Configuration["SSL:NFE:CertificatePath"];
        if (!string.IsNullOrEmpty(path) && Path.Exists(path))
            return new Utilities.IcpBrasilX509Certificate2(path, Configuration["SSL:NFE:CertificatePassword"]);

        return new Utilities.IcpBrasilX509Certificate2(Resources.Certificados.WayneEnterprisesInc, "1234");
    };


    internal static TClient CreateClient<TClient>(params string[] args)
        where TClient : ISoapClient
    {
        ISoapClient client = TClient.Create(args);
        return (TClient)client;
    }

    //[Test]
    //[TestCase(Schemas.NFe.OrgaoIBGE.AC, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.AL, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.AM, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.AP, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.BA, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://hnfe.sefaz.ba.gov.br/webservices/CadConsultaCadastro4/CadConsultaCadastro4.asmx")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.CE, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.DF, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.ES, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.GO, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.MA, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.MG, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://hnfe.fazenda.mg.gov.br/nfe2/services/CadConsultaCadastro4")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.MS, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.MT, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.PA, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.PB, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.PE, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.PI, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.PR, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.RJ, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.RN, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.RO, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.RR, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.RS, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.SC, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.SE, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.SP, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.TO, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.AC, Schemas.NFe.Ambiente.Producao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.AL, Schemas.NFe.Ambiente.Producao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.AM, Schemas.NFe.Ambiente.Producao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.AP, Schemas.NFe.Ambiente.Producao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.BA, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://hnfe.sefaz.ba.gov.br/webservices/CadConsultaCadastro4/CadConsultaCadastro4.asmx")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.CE, Schemas.NFe.Ambiente.Producao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.DF, Schemas.NFe.Ambiente.Producao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.ES, Schemas.NFe.Ambiente.Producao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.GO, Schemas.NFe.Ambiente.Producao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.MA, Schemas.NFe.Ambiente.Producao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.MG, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://hnfe.fazenda.mg.gov.br/nfe2/services/CadConsultaCadastro4")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.MS, Schemas.NFe.Ambiente.Producao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.MT, Schemas.NFe.Ambiente.Producao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.PA, Schemas.NFe.Ambiente.Producao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.PB, Schemas.NFe.Ambiente.Producao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.PE, Schemas.NFe.Ambiente.Producao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.PI, Schemas.NFe.Ambiente.Producao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.PR, Schemas.NFe.Ambiente.Producao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.RJ, Schemas.NFe.Ambiente.Producao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.RN, Schemas.NFe.Ambiente.Producao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.RO, Schemas.NFe.Ambiente.Producao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.RR, Schemas.NFe.Ambiente.Producao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.RS, Schemas.NFe.Ambiente.Producao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.SC, Schemas.NFe.Ambiente.Producao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.SE, Schemas.NFe.Ambiente.Producao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.SP, Schemas.NFe.Ambiente.Producao, ExpectedResult = "")]
    //[TestCase(Schemas.NFe.OrgaoIBGE.TO, Schemas.NFe.Ambiente.Producao, ExpectedResult = "")]
    //public string VerificaUrls(
    //Schemas.NFe.OrgaoIBGE uf,
    //Schemas.NFe.Ambiente ambiente)
    //{
    //    var client = CreateClient<SoapClients.CadConsultaCadastro4SoapClient>(uf.ToString(), ambiente.ToString());
    //    return client.Endpoint.Address.Uri.AbsoluteUri;
    //}

}
