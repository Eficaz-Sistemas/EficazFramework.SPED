using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Bloco9;

public class Registro9999 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro9999();
        reg.Codigo.Should().Be("9999");
    }

    [TestCase("|9999|1|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro9999(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|9999|1|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro9999("", versao)
        {
            TotalLinhas = 1
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|9999|1|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro9999("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro9999 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("9999");
        reg.Versao.Should().Be(versao);
        reg.TotalLinhas.Should().Be(1);
    }
}
