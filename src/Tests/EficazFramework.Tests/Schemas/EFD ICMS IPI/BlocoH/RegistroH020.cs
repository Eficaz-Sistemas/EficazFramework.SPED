using AwesomeAssertions;
using NUnit.Framework;
using System;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoH;

public class RegistroH020 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroH020();
        reg.Codigo.Should().Be("H020");
    }

    [TestCase("|H020|1|100000|100000|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroH020(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|H020|1|1000|1000|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroH020("", versao)
        {
            CST = "1",
            BaseCalculoICMS = 1000.0,
            ValorICMS = 1000.0
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|H020|1|100000|100000|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroH020("", versao);
        reg.CST.Should().BeNull();
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroH020 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("H020");
        reg.Versao.Should().Be(versao);
        reg.CST.Should().Be("1");
        reg.BaseCalculoICMS.Should().Be(1000.0);
        reg.ValorICMS.Should().Be(1000.0);
    }
}
