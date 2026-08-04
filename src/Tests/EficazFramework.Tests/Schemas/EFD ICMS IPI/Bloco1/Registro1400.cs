using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Bloco1;

public class Registro1400 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1400();
        reg.Codigo.Should().Be("1400");
    }

    [TestCase("|1400|ITEM1|1234567|1000,12|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1400(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|1400|ITEM1|1234567|1000,12|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1400("", versao)
        {
            ItemIPM = "ITEM1",
            MunicipioIBGE = "1234567",
            Valor = 1000.12d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|1400|ITEM1|1234567|1000,12|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1400("", versao);
        reg.ItemIPM.Should().BeNull();
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1400 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("1400");
        reg.Versao.Should().Be(versao);
        reg.ItemIPM.Should().Be("ITEM1");
        reg.MunicipioIBGE.Should().Be("1234567");
        reg.Valor.Should().Be(1000.12d);
    }
}
