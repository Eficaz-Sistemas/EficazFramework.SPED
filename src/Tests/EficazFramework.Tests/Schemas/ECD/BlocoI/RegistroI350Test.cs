using System;
using AwesomeAssertions;
using NUnit.Framework;
using EficazFramework.SPED.Schemas.ECD;

namespace EficazFramework.SPED.Schemas.ECD.BlocoI;

public class RegistroI350Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroI350();
        reg.Codigo.Should().Be("I350");
    }

    [TestCase("|I350|01012023|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroI350(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|I350|01012023|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroI350()
        {
            DataApuracaoResultado = new DateTime(2023, 1, 1)
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|I350|01012023|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroI350();
        reg.LeParametros(linha.Split("|"));
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroI350 reg, string versao)
    {
        reg.DataApuracaoResultado.Should().Be(new DateTime(2023, 1, 1));
    }
}
