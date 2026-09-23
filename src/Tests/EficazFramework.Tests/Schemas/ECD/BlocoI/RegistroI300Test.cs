using System;
using AwesomeAssertions;
using NUnit.Framework;
using EficazFramework.SPED.Schemas.ECD;

namespace EficazFramework.SPED.Schemas.ECD.BlocoI;

public class RegistroI300Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroI300();
        reg.Codigo.Should().Be("I300");
    }

    [TestCase("|I300|01012023|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroI300(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|I300|01012023|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroI300()
        {
            DataBalancete = new DateTime(2023, 1, 1)
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|I300|01012023|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroI300();
        reg.LeParametros(linha.Split("|"));
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroI300 reg, string versao)
    {
        reg.DataBalancete.Should().Be(new DateTime(2023, 1, 1));
    }
}
