using System;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoK;

public class RegistroK200 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroK200();
        reg.Codigo.Should().Be("K200");
    }

    [TestCase("|K200|01112022|PROD1|1000,123|0|PART1|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroK200(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|K200|01112022|PROD1|1000,123|0|PART1|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroK200("", versao)
        {
            DataEscrituracao = new DateTime(2022, 11, 1),
            CodigoProduto = "PROD1",
            Quantidade = 1000.123d,
            IndicadorPosse = IndicadorPropriedade.InformanteEmPoder,
            CodigoParticipante = "PART1"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|K200|01112022|PROD1|1000,123|0|PART1|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroK200("", versao);
        reg.CodigoProduto.Should().BeNull();
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroK200 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("K200");
        reg.Versao.Should().Be(versao);
        reg.DataEscrituracao.Should().Be(new DateTime(2022, 11, 1));
        reg.CodigoProduto.Should().Be("PROD1");
        reg.Quantidade.Should().Be(1000.123d);
        reg.IndicadorPosse.Should().Be(IndicadorPropriedade.InformanteEmPoder);
        reg.CodigoParticipante.Should().Be("PART1");
    }
}
