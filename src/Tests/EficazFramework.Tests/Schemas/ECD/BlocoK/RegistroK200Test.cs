using System;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECD.BlocoK;

public class RegistroK200Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroK200();
        reg.Codigo.Should().Be("K200");
    }

    [TestCase("|K200|01|S|1|100|000|ATIVO|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroK200(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|K200|01|S|1|100|000|ATIVO|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroK200("", versao)
        {
            CodigoNaturezaContas = "01",
            IndicadorTipoConta = "S",
            NivelConta = "1",
            CodigoConta = "100",
            CodigoContaSuperior = "000",
            NomeConta = "ATIVO"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|K200|01|S|1|100|000|ATIVO|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroK200(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroK200 reg, string versao)
    {
        reg.CodigoNaturezaContas.Should().Be("01");
        reg.IndicadorTipoConta.Should().Be("S");
        reg.NivelConta.Should().Be("1");
        reg.CodigoConta.Should().Be("100");
        reg.CodigoContaSuperior.Should().Be("000");
        reg.NomeConta.Should().Be("ATIVO");
    }
}
