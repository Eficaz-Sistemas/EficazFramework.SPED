using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Bloco0;

public class Registro0210 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0210();
        reg.Codigo.Should().Be("0210");
    }

    [TestCase("|0210|001|100.5|0.5|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0210(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|0210|001|100.5|0.5|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0210("", versao)
        {
            CodigoItem = "001",
            QuantidadeItem = 100.5d,
            Perda = 0.5d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|0210|001|100.5|0.5|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0210("", versao);
        reg.CodigoItem.Should().Be(null);

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0210 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("0210");
        reg.Versao.Should().Be(versao);
        reg.CodigoItem.Should().Be("001");
        reg.QuantidadeItem.Should().Be(100.5d);
        reg.Perda.Should().Be(0.5d);
    }
}
