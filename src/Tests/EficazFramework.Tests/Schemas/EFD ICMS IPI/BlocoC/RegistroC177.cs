using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC177 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC177();
        reg.Codigo.Should().Be("C177");
    }

    [TestCase("|C177|INF001|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC177(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C177|INF001|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC177("", versao)
        {
            CodigoInformAdicional = "INF001"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C177|INF001|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC177("", versao);
        reg.CodigoInformAdicional.Should().BeNull();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC177 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C177");
        reg.Versao.Should().Be(versao);
        reg.CodigoInformAdicional.Should().Be("INF001");
    }
}
