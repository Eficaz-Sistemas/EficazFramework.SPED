using System;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoE;

public class RegistroE200 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE200();
        reg.Codigo.Should().Be("E200");
    }

    [TestCase("|E200|SP|01012023|31012023|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE200(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|E200|SP|01012023|31012023|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE200("", versao)
        {
            UF = "SP",
            DataInicial = new DateTime(2023, 1, 1),
            DataFinal = new DateTime(2023, 1, 31)
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|E200|SP|01012023|31012023|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE200("", versao);
        reg.UF.Should().BeNull();
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE200 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("E200");
        reg.Versao.Should().Be(versao);
        reg.UF.Should().Be("SP");
        reg.DataInicial.Should().Be(new DateTime(2023, 1, 1));
        reg.DataFinal.Should().Be(new DateTime(2023, 1, 31));
    }
}
