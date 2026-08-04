using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Bloco1;

public class Registro1350 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1350();
        reg.Codigo.Should().Be("1350");
    }

    [TestCase("|1350|S123|FABRICANTE A|MOD1|1|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1350(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|1350|S123|FABRICANTE A|MOD1|1|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1350("", versao)
        {
            NumeroSerie = "S123",
            Fabricante = "FABRICANTE A",
            Modelo = "MOD1",
            TipoMedicao = 1
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|1350|S123|FABRICANTE A|MOD1|1|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1350("", versao);
        reg.NumeroSerie.Should().BeNull();
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1350 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("1350");
        reg.Versao.Should().Be(versao);
        reg.NumeroSerie.Should().Be("S123");
        reg.Fabricante.Should().Be("FABRICANTE A");
        reg.Modelo.Should().Be("MOD1");
        reg.TipoMedicao.Should().Be(1);
    }
}
