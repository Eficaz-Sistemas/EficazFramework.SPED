using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoN;

public class RegistroN670 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroN670();
        reg.Codigo.Should().Be("N670");
    }

    [TestCase("|N670|1|Apuração CSLL Lucro Real|8100,00|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroN670(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|N670|1|Apuração CSLL Lucro Real|8100,00|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroN670("", versao)
        {
            CodigoReferencial = "1",
            Descricao = "Apuração CSLL Lucro Real",
            Valor = 8100.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|N670|1|Apuração CSLL Lucro Real|8100,00|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroN670("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroN670 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("N670");
        reg.Versao.Should().Be(versao);
    }
}
