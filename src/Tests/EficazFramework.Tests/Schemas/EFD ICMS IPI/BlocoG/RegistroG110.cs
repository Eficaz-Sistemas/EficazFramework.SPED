using AwesomeAssertions;
using NUnit.Framework;
using System;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoG;

public class RegistroG110 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroG110();
        reg.Codigo.Should().Be("G110");
    }

    [TestCase("|G110|01112022|01112022|1000|1000|1000|1000|1000|1000|1000|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroG110(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|G110|01112022|01112022|1000|1000|1000|1000|1000|1000|1000|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroG110("", versao)
        {
            DataInicial = new DateTime(2022, 11, 1),
            DataFinal = new DateTime(2022, 11, 1),
            SaldoInicial = 1000.0,
            SomatoriosParcelas = 1000.0,
            SaidasTributadasOuExportacao = 1000.0,
            TotalSaidas = 1000.0,
            IndiceParticipacao = 1000.0,
            ICMSApropriado = 1000.0,
            SomaICMSOutrosCreditos = 1000.0
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|G110|01112022|01112022|1000|1000|1000|1000|1000|1000|1000|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroG110("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroG110 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("G110");
        reg.Versao.Should().Be(versao);
        reg.DataInicial.Should().Be(new DateTime(2022, 11, 1));
        reg.DataFinal.Should().Be(new DateTime(2022, 11, 1));
        reg.SaldoInicial.Should().Be(1000.0);
        reg.SomatoriosParcelas.Should().Be(1000.0);
        reg.SaidasTributadasOuExportacao.Should().Be(1000.0);
        reg.TotalSaidas.Should().Be(1000.0);
        reg.IndiceParticipacao.Should().Be(1000.0);
        reg.ICMSApropriado.Should().Be(1000.0);
        reg.SomaICMSOutrosCreditos.Should().Be(1000.0);
    }
}
