using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoM;

public class RegistroM355 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroM355();
        reg.Codigo.Should().Be("M355");
    }

    [TestCase("|M355|CB001|5000,00|D|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroM355(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|M355|CB001|5000,00|D|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroM355("", versao)
        {
            CodigoContaB = "CB001",
            Valor = 5000.0d,
            Natureza = "D"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|M355|CB001|5000,00|D|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroM355("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroM355 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("M355");
        reg.Versao.Should().Be(versao);
    }
}
