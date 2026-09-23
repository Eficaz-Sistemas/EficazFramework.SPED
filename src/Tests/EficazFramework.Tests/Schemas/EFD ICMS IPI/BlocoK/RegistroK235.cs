using System;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoK;

public class RegistroK235 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroK235("", "016");
        reg.Codigo.Should().Be("K235");
    }

    [TestCase("|K235|01112022|INS1|10000|INS2|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroK235(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|K235|01112022|INS1|10000|INS2|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroK235("", versao)
        {
            DataSaida = new DateTime(2022, 11, 1),
            CodigoInsumo = "INS1",
            Quantidade = 10.0,
            CodigoInsumoSubstituido = "INS2"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|K235|01112022|INS1|10000|INS2|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroK235("", versao);
        reg.CodigoInsumo.Should().BeNull();
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroK235 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("K235");
        reg.Versao.Should().Be(versao);
        reg.DataSaida.Should().Be(new DateTime(2022, 11, 1));
        reg.CodigoInsumo.Should().Be("INS1");
        reg.Quantidade.Should().Be(10.0);
        reg.CodigoInsumoSubstituido.Should().Be("INS2");
    }
}
