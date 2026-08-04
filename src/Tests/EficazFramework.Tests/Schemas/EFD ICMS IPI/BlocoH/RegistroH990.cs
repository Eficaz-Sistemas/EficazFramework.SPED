using AwesomeAssertions;
using NUnit.Framework;
using System;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoH;

public class RegistroH990 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroH990();
        reg.Codigo.Should().Be("H990");
    }

    [TestCase("|H990|1|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroH990(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|H990|1|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroH990("", versao)
        {
            QuantidadeLinhas = 1
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|H990|1|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroH990("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroH990 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("H990");
        reg.Versao.Should().Be(versao);
        reg.QuantidadeLinhas.Should().Be(1);
    }
}
