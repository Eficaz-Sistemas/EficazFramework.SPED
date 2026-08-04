using System;
using AwesomeAssertions;
using NUnit.Framework;
using EficazFramework.SPED.Schemas.ECD;

namespace EficazFramework.SPED.Schemas.ECD.BlocoJ;

public class RegistroJ200Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroJ200();
        reg.Codigo.Should().Be("J200");
    }

    [TestCase("|J200|COD|DESC|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroJ200(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|J200|COD|DESC|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroJ200()
        {
            CodHistoricoFatoContabil = "COD",
            DescFatoContabil = "DESC"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|J200|COD|DESC|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroJ200();
        reg.LeParametros(linha.Split("|"));
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroJ200 reg, string versao)
    {
        reg.CodHistoricoFatoContabil.Should().Be("COD");
        reg.DescFatoContabil.Should().Be("DESC");
    }
}
