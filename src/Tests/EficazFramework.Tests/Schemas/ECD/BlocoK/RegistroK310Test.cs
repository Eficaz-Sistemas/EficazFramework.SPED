using System;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECD.BlocoK;

public class RegistroK310Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroK310();
        reg.Codigo.Should().Be("K310");
    }

    [TestCase("|K310|EMP01|50,2|C|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroK310(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|K310|EMP01|50,2|C|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroK310("", versao)
        {
            CodigoEmpresaDetVrAglutinadoEliminado = "EMP01",
            ParcelaVrEliminadoTotal = 50.2,
            IndicadorSitVrEliminada = "C"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|K310|EMP01|50,2|C|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroK310(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroK310 reg, string versao)
    {
        reg.CodigoEmpresaDetVrAglutinadoEliminado.Should().Be("EMP01");
        reg.ParcelaVrEliminadoTotal.Should().Be(50.2);
        reg.IndicadorSitVrEliminada.Should().Be("C");
    }
}
