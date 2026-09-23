using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.Bloco9;

public class Registro9900 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.Registro9900();
        reg.Codigo.Should().Be("9900");
    }

    [TestCase("|9900|0000|1|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.Registro9900(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|9900|0000|1|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.Registro9900("", versao)
        {
            Registro = "0000",
            TotalLinhas = 1
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|9900|0000|1|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.Registro9900("", versao);
        reg.Registro.Should().BeNull();
        reg.TotalLinhas.HasValue.Should().BeFalse();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.Registro9900 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("9900");
        reg.Versao.Should().Be(versao);
        reg.Registro.Should().Be("0000");
        reg.TotalLinhas.Should().Be(1);
    }
}
