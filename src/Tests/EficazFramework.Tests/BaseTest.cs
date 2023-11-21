using Microsoft.Extensions.Configuration;

namespace EficazFramework.SPED.Tests;

public class BaseTest
{
    public IConfiguration Configuration { get; }


    public BaseTest()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"))
            .AddUserSecrets<EficazFramework.SPED.Tests.BaseTest>()
            .Build();

        Configuration = configuration;
    }


    [SetUp]
    public void Setup()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("pt-BR");
        System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("pt-BR");
    }

}
