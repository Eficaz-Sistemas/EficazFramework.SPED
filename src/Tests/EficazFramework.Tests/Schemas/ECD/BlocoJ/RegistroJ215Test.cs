using System;
using AwesomeAssertions;
using NUnit.Framework;
using EficazFramework.SPED.Schemas.ECD;

namespace EficazFramework.SPED.Schemas.ECD.BlocoJ;

public class RegistroJ215Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroJ215();
        reg.Codigo.Should().Be("J215");
    }

    [TestCase("|J215|COD|DESC|150,5|D|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroJ215(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|J215|COD|DESC|150,5|D|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroJ215("", versao)
        {
            CodigoHistFatoContabil = "COD",
            DescricaoFatoContabil = "DESC",
            VrFatoContabil = 150.5,
            IndicadorSitSaldoFatoContabil = "D"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|J215|COD|DESC|150,5|D|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroJ215(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroJ215 reg, string versao)
    {
        reg.CodigoHistFatoContabil.Should().Be("COD");
        reg.DescricaoFatoContabil.Should().Be("DESC");
        reg.VrFatoContabil.Should().Be(150.5);
        reg.IndicadorSitSaldoFatoContabil.Should().Be("D");
    }
}
