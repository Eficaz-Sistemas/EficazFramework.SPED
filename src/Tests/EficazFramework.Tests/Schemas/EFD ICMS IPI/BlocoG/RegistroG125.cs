using AwesomeAssertions;
using NUnit.Framework;
using System;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoG;

public class RegistroG125 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroG125();
        reg.Codigo.Should().Be("G125");
    }

    [TestCase("|G125|1|01112022|SI|1000|1000|1000|1000|001|1000|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroG125(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|G125|1|01112022|SI|1000|1000|1000|1000|001|1000|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroG125("", versao)
        {
            CodigoBem = "1",
            DataMovimento = new DateTime(2022, 11, 1),
            TipoMovimento = TipoMovimentoCIAP.SI_SaldoInicial,
            ICMS_OpPropria_Entrada = 1000.0,
            ICMS_ST_Entrada = 1000.0,
            ICMS_Frete_Entrada = 1000.0,
            ICMS_Difal_Entrada = 1000.0,
            NumeroParcela = 1.0,
            ValorParcelaAprop = 1000.0
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|G125|1|01112022|SI|1000|1000|1000|1000|001|1000|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroG125("", versao);
        reg.CodigoBem.Should().BeNull();
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroG125 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("G125");
        reg.Versao.Should().Be(versao);
        reg.CodigoBem.Should().Be("1");
        reg.DataMovimento.Should().Be(new DateTime(2022, 11, 1));
        reg.TipoMovimento.Should().Be(TipoMovimentoCIAP.SI_SaldoInicial);
        reg.ICMS_OpPropria_Entrada.Should().Be(1000.0);
        reg.ICMS_ST_Entrada.Should().Be(1000.0);
        reg.ICMS_Frete_Entrada.Should().Be(1000.0);
        reg.ICMS_Difal_Entrada.Should().Be(1000.0);
        reg.NumeroParcela.Should().Be(1.0);
        reg.ValorParcelaAprop.Should().Be(1000.0);
    }
}
