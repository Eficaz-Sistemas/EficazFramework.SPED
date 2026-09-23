using System;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoK;

public class RegistroK100 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroK100();
        reg.Codigo.Should().Be("K100");
    }

    [TestCase("|K100|01112022|30112022|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroK100(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|K100|01112022|30112022|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroK100("", versao)
        {
            DataInicial = new DateTime(2022, 11, 1),
            DataFinal = new DateTime(2022, 11, 30)
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|K100|01112022|30112022|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroK100("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroK100 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("K100");
        reg.Versao.Should().Be(versao);
        reg.DataInicial.Should().Be(new DateTime(2022, 11, 1));
        reg.DataFinal.Should().Be(new DateTime(2022, 11, 30));
    }
}
