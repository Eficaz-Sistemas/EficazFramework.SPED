using AwesomeAssertions;
using NUnit.Framework;
using System;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoB;

public class RegistroB001 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB001();
        reg.Codigo.Should().Be("B001");
    }

    [TestCase("|B001|0|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB001(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|B001|0|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB001("", versao)
        {
            IndicadorMovimento = Primitives.IndicadorMovimento.ComDados
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|B001|0|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB001("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB001 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("B001");
        reg.Versao.Should().Be(versao);
        reg.IndicadorMovimento.Should().Be(Primitives.IndicadorMovimento.ComDados);
    }
}
