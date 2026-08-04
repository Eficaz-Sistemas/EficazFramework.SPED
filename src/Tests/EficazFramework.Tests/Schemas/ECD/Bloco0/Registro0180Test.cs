using System;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECD.Bloco0;

public class Registro0180Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new Registro0180();
        reg.Codigo.Should().Be("0180");
    }

    [TestCase("|0180|01|01012023|31122023|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new Registro0180(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|0180|01|01012023|31122023|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new Registro0180("", versao)
        {
            CodRelacionamentoTabelaSped = "01",
            DataInicioRelacionamento = new DateTime(2023, 1, 1),
            DataTerminoRelacionamento = new DateTime(2023, 12, 31)
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|0180|01|01012023|31122023|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new Registro0180(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(Registro0180 reg, string versao)
    {
        reg.CodRelacionamentoTabelaSped.Should().Be("01");
        reg.DataInicioRelacionamento.Should().Be(new DateTime(2023, 1, 1));
        reg.DataTerminoRelacionamento.Should().Be(new DateTime(2023, 12, 31));
    }
}
