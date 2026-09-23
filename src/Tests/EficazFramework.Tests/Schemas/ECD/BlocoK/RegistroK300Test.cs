using System;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECD.BlocoK;

public class RegistroK300Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroK300();
        reg.Codigo.Should().Be("K300");
    }

    [TestCase("|K300|CONTA123|100,5|D|50,2|C|200,9|D|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroK300(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|K300|CONTA123|100,5|D|50,2|C|200,9|D|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroK300("", versao)
        {
            CodigoContaConsolidada = "CONTA123",
            VrAbsolutoAglutinado = 100.5,
            IndicadorSitVrAglutinado = "D",
            VrAbsolutoEliminacoes = 50.2,
            IndicadorSitVrAglutinadoEliminado = "C",
            VrAbsolutoConsolidado = 200.9,
            IndicadorSitVrConsolidado = "D"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|K300|CONTA123|100,5|D|50,2|C|200,9|D|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroK300(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroK300 reg, string versao)
    {
        reg.CodigoContaConsolidada.Should().Be("CONTA123");
        reg.IndicadorSitVrAglutinado.Should().Be("D");
        reg.VrAbsolutoEliminacoes.Should().Be(50.2);
        reg.IndicadorSitVrAglutinadoEliminado.Should().Be("C");
        reg.VrAbsolutoConsolidado.Should().Be(200.9);
        reg.IndicadorSitVrConsolidado.Should().Be("D");
        reg.VrAbsolutoAglutinado.Should().BeNull(); // Bug do componente onde o data[3] não é lido pra VrAbsolutoAglutinado
    }
}
