using System;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoE;

public class RegistroE310 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE310();
        reg.Codigo.Should().Be("E310");
    }

    [TestCase("|E310|1|2,2|3,3|4,4|5,5|6,6|7,7|8,8|9,9|10,1|11,11|12,12|13,13|14,14|15,15|16,16|17,17|18,18|19,19|20,2|21,21|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE310(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|E310|1|2,2|3,3|4,4|5,5|6,6|7,7|8,8|9,9|10,1|11,11|12,12|13,13|14,14|15,15|16,16|17,17|18,18|19,19|20,2|21,21|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE310("", versao)
        {
            IndicadorMovimentoDifal = IndicadorMovimentoST_Difal.ComOperacoes,
            SaldoCredorAnterior = 2.2d,
            DebitosDifal = 3.3d,
            OutrosDebitos = 4.4d,
            CreditosDifal = 5.5d,
            OutrosCreditos = 6.6d,
            SaldoDevedorApurado = 7.7d,
            DeducoesDifal = 8.8d,
            ICMSDifal_Recolher = 9.9d,
            SaldoCredorATransportar = 10.1d,
            DebitosExtraApuracao = 11.11d,
            SaldoCredorAnteriorFCP = 12.12d,
            DebitosFCP = 13.13d,
            OutrosDebitosFCP = 14.14d,
            CreditosFCP = 15.15d,
            OutrosCreditosFCP = 16.16d,
            SaldoDevedorApuradoFCP = 17.17d,
            DeducoesFCP = 18.18d,
            ICMSFCP_Recolher = 19.19d,
            SaldoCredorATransportarFCP = 20.2d,
            DebitosExtraApuracaoFCP = 21.21d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|E310|1|2,2|3,3|4,4|5,5|6,6|7,7|8,8|9,9|10,1|11,11|12,12|13,13|14,14|15,15|16,16|17,17|18,18|19,19|20,2|21,21|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE310("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE310 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("E310");
        reg.Versao.Should().Be(versao);
        reg.IndicadorMovimentoDifal.Should().Be(IndicadorMovimentoST_Difal.ComOperacoes);
        reg.SaldoCredorAnterior.Should().Be(2.2d);
        reg.DebitosDifal.Should().Be(3.3d);
        reg.OutrosDebitos.Should().Be(4.4d);
        reg.CreditosDifal.Should().Be(5.5d);
        reg.OutrosCreditos.Should().Be(6.6d);
        reg.SaldoDevedorApurado.Should().Be(7.7d);
        reg.DeducoesDifal.Should().Be(8.8d);
        reg.ICMSDifal_Recolher.Should().Be(9.9d);
        reg.SaldoCredorATransportar.Should().Be(10.1d);
        reg.DebitosExtraApuracao.Should().Be(11.11d);
        reg.SaldoCredorAnteriorFCP.Should().Be(12.12d);
        reg.DebitosFCP.Should().Be(13.13d);
        reg.OutrosDebitosFCP.Should().Be(14.14d);
        reg.CreditosFCP.Should().Be(15.15d);
        reg.OutrosCreditosFCP.Should().Be(16.16d);
        reg.SaldoDevedorApuradoFCP.Should().Be(17.17d);
        reg.DeducoesFCP.Should().Be(18.18d);
        reg.ICMSFCP_Recolher.Should().Be(19.19d);
        reg.SaldoCredorATransportarFCP.Should().Be(20.2d);
        reg.DebitosExtraApuracaoFCP.Should().Be(21.21d);
    }
}
