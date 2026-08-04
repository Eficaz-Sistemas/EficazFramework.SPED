using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Bloco1;

public class Registro1310 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1310();
        reg.Codigo.Should().Be("1310");
    }

    [TestCase("|1310|001|1000,123|200,12|1200,243|300,1|900,143|10|20|890,143|", "016")]
    [TestCase("|1310|001|1000,123|200,12|1200,243|300,1|900,143|10|20|890,143|50000|", "020")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1310(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|1310|001|1000,123|200,12|1200,243|300,1|900,143|10|20|890,143|", "016")]
    [TestCase("|1310|001|1000,123|200,12|1200,243|300,1|900,143|10|20|890,143|50000|", "020")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1310("", versao)
        {
            NumeroTanque = "001",
            EstoqueAbertura = 1000.123d,
            VolumeEntradas = 200.12d,
            VolumeDisponivel = 1200.243d,
            VolumeSaidas = 300.1d,
            EstoqueEscritural = 900.143d,
            AjustesPerda = 10.0d,
            AjustesGanho = 20.0d,
            EstoqueFechamento = 890.143d,
            CapacidadeTanque = 50000.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|1310|001|1000,123|200,12|1200,243|300,1|900,143|10|20|890,143|", "016")]
    [TestCase("|1310|001|1000,123|200,12|1200,243|300,1|900,143|10|20|890,143|50000|", "020")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1310("", versao);
        reg.NumeroTanque.Should().BeNull();
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1310 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("1310");
        reg.Versao.Should().Be(versao);
        reg.NumeroTanque.Should().Be("001");
        reg.EstoqueAbertura.Should().Be(1000.123d);
        reg.VolumeEntradas.Should().Be(200.12d);
        reg.VolumeDisponivel.Should().Be(1200.243d);
        reg.VolumeSaidas.Should().Be(300.1d);
        reg.EstoqueEscritural.Should().Be(900.143d);
        reg.AjustesPerda.Should().Be(10.0d);
        reg.AjustesGanho.Should().Be(20.0d);
        reg.EstoqueFechamento.Should().Be(890.143d);
        if (int.Parse(versao) >= 20)
        {
            reg.CapacidadeTanque.Should().Be(50000.0d);
        }
    }
}
