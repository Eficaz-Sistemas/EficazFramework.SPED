using System;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoE;

public class RegistroE001 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE001();
        reg.Codigo.Should().Be("E001");
    }

    [TestCase("|E001|1|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE001(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|E001|1|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE001("", versao)
        {
            IndicadorMovimento = Primitives.IndicadorMovimento.SemDados
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|E001|1|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE001("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE001 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("E001");
        reg.Versao.Should().Be(versao);
        reg.IndicadorMovimento.Should().Be(Primitives.IndicadorMovimento.SemDados);
    }
}
