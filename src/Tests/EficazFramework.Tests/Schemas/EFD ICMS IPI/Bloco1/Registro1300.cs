using System;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Bloco1;

public class Registro1300 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1300();
        reg.Codigo.Should().Be("1300");
    }

    [TestCase("|1300|COD|01112022|1000,123|200,12|1200,243|300,1|900,143|10|20|890,143|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1300(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|1300|COD|01112022|1000,123|200,12|1200,243|300,1|900,143|10|20|890,143|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1300("", versao)
        {
            CodigoCombustivel0200 = "COD",
            DataFechamento = new DateTime(2022, 11, 1),
            EstoqueAbertura = 1000.123d,
            VolumeEntradas = 200.12d,
            VolumeDisponivel = 1200.243d,
            VolumeSaidas = 300.1d,
            EstoqueEscritural = 900.143d,
            AjustesPerda = 10.0d,
            AjustesGanho = 20.0d,
            EstoqueFechamento = 890.143d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|1300|COD|01112022|1000,123|200,12|1200,243|300,1|900,143|10|20|890,143|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1300("", versao);
        reg.CodigoCombustivel0200.Should().BeNull();
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1300 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("1300");
        reg.Versao.Should().Be(versao);
        reg.CodigoCombustivel0200.Should().Be("COD");
        reg.DataFechamento.Should().Be(new DateTime(2022, 11, 1));
        reg.EstoqueAbertura.Should().Be(1000.123d);
        reg.VolumeEntradas.Should().Be(200.12d);
        reg.VolumeDisponivel.Should().Be(1200.243d);
        reg.VolumeSaidas.Should().Be(300.1d);
        reg.EstoqueEscritural.Should().Be(900.143d);
        reg.AjustesPerda.Should().Be(10.0d);
        reg.AjustesGanho.Should().Be(20.0d);
        reg.EstoqueFechamento.Should().Be(890.143d);
    }
}
