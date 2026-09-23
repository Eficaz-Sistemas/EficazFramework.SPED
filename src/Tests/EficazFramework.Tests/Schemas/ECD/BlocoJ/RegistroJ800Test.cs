using System;
using AwesomeAssertions;
using NUnit.Framework;
using EficazFramework.SPED.Schemas.ECD;

namespace EficazFramework.SPED.Schemas.ECD.BlocoJ;

public class RegistroJ800Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroJ800();
        reg.Codigo.Should().Be("J800");
    }

    [TestCase("|J800|BYTES|", "900")] // The EscreveLinha appends J800FIM
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroJ800(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|J800|BYTES||J800FIM|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroJ800()
        {
            SequenciaBytesArquitoRTF = "BYTES"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|J800|BYTES|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroJ800();
        reg.LeParametros(linha.Split("|"));
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroJ800 reg, string versao)
    {
        reg.SequenciaBytesArquitoRTF.Should().Be("BYTES");
    }
}
