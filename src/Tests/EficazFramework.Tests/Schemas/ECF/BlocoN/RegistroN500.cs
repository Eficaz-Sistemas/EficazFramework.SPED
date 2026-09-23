using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoN;

public class RegistroN500 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroN500();
        reg.Codigo.Should().Be("N500");
    }

    [TestCase("|N500|1|Base IRPJ|100000,00|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroN500(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|N500|1|Base IRPJ|100000,00|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroN500("", versao)
        {
            CodigoReferencial = "1",
            Descricao = "Base IRPJ",
            Valor = 100000.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|N500|1|Base IRPJ|100000,00|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroN500("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroN500 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("N500");
        reg.Versao.Should().Be(versao);
    }
}
