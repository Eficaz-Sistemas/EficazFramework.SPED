using System;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECD.BlocoK;

public class RegistroK110Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroK110();
        reg.Codigo.Should().Be("K110");
    }

    [TestCase("|K110|2|01012023|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroK110(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|K110|2|01012023|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroK110("", versao)
        {
            EventoSocietario = EventoSocietario.Alienacao,
            DataEventoSocietario = new DateTime(2023, 1, 1)
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|K110|2|01012023|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroK110(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroK110 reg, string versao)
    {
        reg.EventoSocietario.Should().Be(EventoSocietario.Alienacao);
        reg.DataEventoSocietario.Should().Be(new DateTime(2023, 1, 1));
    }
}
