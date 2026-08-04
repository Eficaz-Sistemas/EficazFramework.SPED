using AwesomeAssertions;
using NUnit.Framework;
using System;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoH;

public class RegistroH001 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroH001();
        reg.Codigo.Should().Be("H001");
    }

    [TestCase("|H001|0|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroH001(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|H001|0|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroH001("", versao)
        {
            IndicadorMovimento = Primitives.IndicadorMovimento.ComDados
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|H001|0|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroH001("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroH001 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("H001");
        reg.Versao.Should().Be(versao);
        reg.IndicadorMovimento.Should().Be(Primitives.IndicadorMovimento.ComDados);
    }
}
