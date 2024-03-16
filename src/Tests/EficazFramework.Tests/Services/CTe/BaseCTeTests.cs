namespace EficazFramework.SPED.Services.CTe;

public class BaseCTeTests : Tests.BaseTest
{
    internal EficazFramework.SPED.Services.CTe.CTeService CreateClient()
    {
        var client = new CTeService
        {
            SelecionaCertificado = InstanciaCertificado
        };
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

}
