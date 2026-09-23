using AwesomeAssertions;
using NUnit.Framework;
using System;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoH;

public class RegistroH010 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroH010();
        reg.Codigo.Should().Be("H010");
    }

    [TestCase("|H010|1|1|1000|1000|1000|0|1|1|1|1000|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroH010(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|H010|1|1|1000|1000|1000|0|1|1|1|10|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroH010("", versao)
        {
            CodigoProduto = "1",
            UnidadeInventariada = "1",
            Quantidade = 1000.0,
            ValorUnitario = 1000.0,
            ValorTotal = 1000.0,
            IndicadorPosse = IndicadorPropriedade.InformanteEmPoder,
            CodigoParticipante = "1",
            TextoComplementar = "1",
            ContaAnaliticaContabil = "1",
            ValotTotalRIR = 10.0
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|H010|1|1|1000|1000|1000|0|1|1|1|1000|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroH010("", versao);
        reg.CodigoProduto.Should().BeNull();
        reg.UnidadeInventariada.Should().BeNull();
        reg.CodigoParticipante.Should().BeNull();
        reg.TextoComplementar.Should().BeNull();
        reg.ContaAnaliticaContabil.Should().BeNull();
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroH010 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("H010");
        reg.Versao.Should().Be(versao);
        reg.CodigoProduto.Should().Be("1");
        reg.UnidadeInventariada.Should().Be("1");
        reg.Quantidade.Should().Be(1000.0);
        reg.ValorUnitario.Should().Be(1000.0);
        reg.ValorTotal.Should().Be(1000.0);
        reg.IndicadorPosse.Should().Be(IndicadorPropriedade.InformanteEmPoder);
        reg.CodigoParticipante.Should().Be("1");
        reg.TextoComplementar.Should().Be("1");
        reg.ContaAnaliticaContabil.Should().Be("1");
        reg.ValotTotalRIR.Should().Be(10.0);
    }
}
