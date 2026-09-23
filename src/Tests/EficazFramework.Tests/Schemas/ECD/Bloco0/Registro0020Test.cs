using System;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECD.Bloco0;

public class Registro0020Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new Registro0020();
        reg.Codigo.Should().Be("0020");
    }

    [TestCase("|0020|0|12345678000199|MG|123456|3106200|987654|NIRE123|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new Registro0020(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|0020|0|12345678000199|MG|123456|3106200|987654|NIRE123|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new Registro0020("", versao)
        {
            IndicadorDescentralizacao = IndicadorDescentralizacao.EscrituracaoMatriz,
            CNPJ = "12345678000199",
            UF = "MG",
            InscEstadual = "123456",
            CodigoMunicipal = "3106200",
            InscMunicipal = "987654",
            Nire = "NIRE123"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|0020|0|12345678000199|MG|123456|3106200|987654|NIRE123|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new Registro0020(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(Registro0020 reg, string versao)
    {
        reg.IndicadorDescentralizacao.Should().Be(IndicadorDescentralizacao.EscrituracaoMatriz);
        reg.CNPJ.Should().Be("12345678000199");
        reg.UF.Should().Be("MG");
        reg.InscEstadual.Should().Be("123456");
        reg.CodigoMunicipal.Should().Be("3106200");
        reg.InscMunicipal.Should().Be("987654");
        reg.Nire.Should().Be("NIRE123");
    }
}
