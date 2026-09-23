using System;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Bloco1;

public class Registro1360 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1360();
        reg.Codigo.Should().Be("1360");
    }

    [TestCase("|1360|L123|01112022|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1360(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|1360|L123|01112022|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1360("", versao)
        {
            NumeroLacre = "L123",
            DataAplicacao = new DateTime(2022, 11, 1)
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|1360|L123|01112022|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1360("", versao);
        reg.NumeroLacre.Should().BeNull();
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1360 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("1360");
        reg.Versao.Should().Be(versao);
        reg.NumeroLacre.Should().Be("L123");
        reg.DataAplicacao.Should().Be(new DateTime(2022, 11, 1));
    }
}
