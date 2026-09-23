using AwesomeAssertions;
using NUnit.Framework;
using System;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoB;

public class RegistroB460 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB460();
        reg.Codigo.Should().Be("B460");
    }

    [TestCase("|B460|0|1000,00|1|0|1|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB460(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|B460|0|1000|1|0|1|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB460("", versao)
        {
            IndicadorTipoDeducao = IndicadorTipoDeducao.Compensacao_ISS_CalculadoMaior,
            ValorDeducao = 1000.0,
            NumeroProcesso = "1",
            IndicadorOrigemProcesso = IndicadorOrigemProcessoServico.Sefin,
            DescricaoProcessoLcto = "1"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|B460|0|1000,00|1|0|1|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB460("", versao);
        reg.NumeroProcesso.Should().BeNull();
        reg.DescricaoProcessoLcto.Should().BeNull();
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB460 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("B460");
        reg.Versao.Should().Be(versao);
        reg.IndicadorTipoDeducao.Should().Be(IndicadorTipoDeducao.Compensacao_ISS_CalculadoMaior);
        reg.ValorDeducao.Should().Be(1000.0);
        reg.NumeroProcesso.Should().Be("1");
        reg.IndicadorOrigemProcesso.Should().Be(IndicadorOrigemProcessoServico.Sefin);
        reg.DescricaoProcessoLcto.Should().Be("1");
    }
}
