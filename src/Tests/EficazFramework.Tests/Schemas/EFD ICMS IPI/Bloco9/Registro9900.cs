using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Bloco9;

public class Registro9900 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro9900();
        reg.Codigo.Should().Be("9900");
    }

    [TestCase("|9900|9900|1|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro9900(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|9900|9900|1|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro9900("", versao)
        {
            Registro = "9900",
            TotalLinhas = 1
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|9900|9900|1|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro9900("", versao);
        reg.Registro.Should().BeNull();
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro9900 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("9900");
        reg.Versao.Should().Be(versao);
        reg.Registro.Should().Be("9900");
        reg.TotalLinhas.Should().Be(1);
    }
}
