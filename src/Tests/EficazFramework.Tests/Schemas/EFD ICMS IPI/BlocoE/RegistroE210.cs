using System;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoE;

public class RegistroE210 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE210();
        reg.Codigo.Should().Be("E210");
    }

    [TestCase("|E210|1|2,2|3,3|4,4|5,5|6,6|7,7|8,8|9,9|10,1|11,11|12,12|13,13|14,14|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE210(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|E210|1|2,2|3,3|4,4|5,5|6,6|7,7|8,8|9,9|10,1|11,11|12,12|13,13|14,14|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE210("", versao)
        {
            IndicadorMovimentoST = IndicadorMovimentoST_Difal.ComOperacoes,
            SaldoCredorAnterior = 2.2d,
            ValorSTDevolucoes = 3.3d,
            ValorSTRessarcimentos = 4.4d,
            CreditosAjustes = 5.5d,
            CreditosAjustesDocFiscal = 6.6d,
            RetencaoST = 7.7d,
            DebitosAjustes = 8.8d,
            DebitosAjustesDocFiscal = 9.9d,
            SaldoDevedorApurado = 10.1d,
            DeducoesTotais = 11.11d,
            ICMSST_Recolher = 12.12d,
            SaldoCredorATransportar = 13.13d,
            DebitosExtraApuracao = 14.14d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|E210|1|2,2|3,3|4,4|5,5|6,6|7,7|8,8|9,9|10,1|11,11|12,12|13,13|14,14|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE210("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE210 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("E210");
        reg.Versao.Should().Be(versao);
        reg.IndicadorMovimentoST.Should().Be(IndicadorMovimentoST_Difal.ComOperacoes);
        reg.SaldoCredorAnterior.Should().Be(2.2d);
        reg.ValorSTDevolucoes.Should().Be(3.3d);
        reg.ValorSTRessarcimentos.Should().Be(4.4d);
        reg.CreditosAjustes.Should().Be(5.5d);
        reg.CreditosAjustesDocFiscal.Should().Be(6.6d);
        reg.RetencaoST.Should().Be(7.7d);
        reg.DebitosAjustes.Should().Be(8.8d);
        reg.DebitosAjustesDocFiscal.Should().Be(9.9d);
        reg.SaldoDevedorApurado.Should().Be(10.1d);
        reg.DeducoesTotais.Should().Be(11.11d);
        reg.ICMSST_Recolher.Should().Be(12.12d);
        reg.SaldoCredorATransportar.Should().Be(13.13d);
        reg.DebitosExtraApuracao.Should().Be(14.14d);
    }
}
