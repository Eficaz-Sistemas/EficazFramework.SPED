using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Bloco1;

public class Registro1370 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1370();
        reg.Codigo.Should().Be("1370");
    }

    [TestCase("|1370|1|COD|001|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1370(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|1370|1|COD|001|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1370("", versao)
        {
            NumeroBico = "1",
            CodigoCombustivel0200 = "COD",
            NumeroTanque = "001"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|1370|1|COD|001|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1370("", versao);
        reg.NumeroBico.Should().BeNull();
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1370 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("1370");
        reg.Versao.Should().Be(versao);
        reg.NumeroBico.Should().Be("1");
        reg.CodigoCombustivel0200.Should().Be("COD");
        reg.NumeroTanque.Should().Be("001");
    }
}
