using System;
using AwesomeAssertions;
using NUnit.Framework;
using EficazFramework.SPED.Schemas.ECD;

namespace EficazFramework.SPED.Schemas.ECD.BlocoI;

public class RegistroI200Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroI200();
        reg.Codigo.Should().Be("I200");
    }

    [TestCase("|I200|ID|01012023|1500,75|X|01012023|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroI200(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|I200|ID|01012023|1500,75|X|01012023|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroI200("", versao)
        {
            CodIdentUnicaLcto = "ID",
            DataLcto = new DateTime(2023, 1, 1),
            VrLcto = 1500.75,
            IndicadorTipoLancamento = "X",
            DataLctoExtemporaneo = new DateTime(2023, 1, 1)
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|I200|ID|01012023|1500,75|X|01012023|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroI200(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroI200 reg, string versao)
    {
        reg.CodIdentUnicaLcto.Should().Be("ID");
        reg.DataLcto.Should().Be(new DateTime(2023, 1, 1));
        reg.VrLcto.Should().Be(1500.75);
        reg.IndicadorTipoLancamento.Should().Be("X");
        reg.DataLctoExtemporaneo.Should().Be(new DateTime(2023, 1, 1));
    }
}
