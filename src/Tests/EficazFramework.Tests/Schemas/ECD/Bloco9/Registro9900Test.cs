using System;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECD.Bloco9;

public class Registro9900Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new Registro9900();
        reg.Codigo.Should().Be("9900");
    }

    [TestCase("|9900|I010|50|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new Registro9900(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|9900|I010|50|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new Registro9900("", versao)
        {
            Registro = "I010",
            TotalLinhas = 50
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|9900|I010|50|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new Registro9900(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(Registro9900 reg, string versao)
    {
        reg.Registro.Should().Be("I010");
        reg.TotalLinhas.Should().Be(50);
    }
}
