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
}
