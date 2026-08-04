using System;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECD.BlocoK;

public class RegistroK315Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroK315();
        reg.Codigo.Should().Be("K315");
    }

    [TestCase("|K315|EMP01|CONTA321|50,2|C|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroK315(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|K315|EMP01|CONTA321|50,2|C|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroK315("", versao)
        {
            CodigoEmpresaContrapartida = "EMP01",
            CodigoContaConsolidadaContrapartida = "CONTA321",
            ParcelaContrapartidaVrEliminado = 50.2,
            IndicadorSitVrEliminado = "C"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|K315|EMP01|CONTA321|50,2|C|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroK315(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroK315 reg, string versao)
    {
        reg.CodigoEmpresaContrapartida.Should().Be("EMP01");
        reg.CodigoContaConsolidadaContrapartida.Should().Be("CONTA321");
        reg.ParcelaContrapartidaVrEliminado.Should().Be(50.2);
        reg.IndicadorSitVrEliminado.Should().Be("C");
    }
}
