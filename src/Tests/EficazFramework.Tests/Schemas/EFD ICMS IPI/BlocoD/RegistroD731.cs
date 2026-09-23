using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoD;

public class RegistroD731 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD731();
        reg.Codigo.Should().Be("D731");
    }

    [TestCase("|D731|2|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD731(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|D731|2|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD731("", versao)
        {
            ValorFCP = 2.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|D731|2|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD731("", versao);
        reg.ValorFCP.HasValue.Should().BeFalse();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD731 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("D731");
        reg.Versao.Should().Be(versao);
        reg.ValorFCP.Should().Be(2.0d);
    }
}
