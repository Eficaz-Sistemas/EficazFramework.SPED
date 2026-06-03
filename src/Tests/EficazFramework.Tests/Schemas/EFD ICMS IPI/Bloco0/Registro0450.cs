using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Bloco0;

public class Registro0450 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0450();
        reg.Codigo.Should().Be("0450");
    }

    [TestCase("|0450|000001|Informação Complementar|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0450(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|0450|000001|Informação Complementar|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0450("", versao)
        {
            CodigoInfComplementar = "000001",
            TextoInfComplementar = "Informação Complementar"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|0450|000001|Informação Complementar|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0450("", versao);
        reg.CodigoInfComplementar.Should().Be(null);

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0450 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("0450");
        reg.Versao.Should().Be(versao);
        reg.CodigoInfComplementar.Should().Be("000001");
        reg.TextoInfComplementar.Should().Be("Informação Complementar");
    }
}
