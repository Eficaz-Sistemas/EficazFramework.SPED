using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Bloco1;

public class Registro1600 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1600();
        reg.Codigo.Should().Be("1600");
    }

    [TestCase("|1600|PART1|1000,12|2000,34|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1600(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|1600|PART1|1000,12|2000,34|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1600("", versao)
        {
            CodigoParticipante = "PART1",
            TotalCredito = 1000.12d,
            TotalDebito = 2000.34d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|1600|PART1|1000,12|2000,34|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1600("", versao);
        reg.CodigoParticipante.Should().BeNull();
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1600 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("1600");
        reg.Versao.Should().Be(versao);
        reg.CodigoParticipante.Should().Be("PART1");
        reg.TotalCredito.Should().Be(1000.12d);
        reg.TotalDebito.Should().Be(2000.34d);
    }
}
