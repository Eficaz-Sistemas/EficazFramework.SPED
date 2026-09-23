using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoM;

public class RegistroM362 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroM362();
        reg.Codigo.Should().Be("M362");
    }

    [TestCase("|M362|LAN123|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroM362(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|M362|LAN123|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroM362("", versao)
        {
            NumeroLancto = "LAN123"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|M362|LAN123|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroM362("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroM362 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("M362");
        reg.Versao.Should().Be(versao);
    }
}
