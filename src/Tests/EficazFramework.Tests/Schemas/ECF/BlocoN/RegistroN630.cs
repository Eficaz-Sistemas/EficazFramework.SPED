using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoN;

public class RegistroN630 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroN630();
        reg.Codigo.Should().Be("N630");
    }

    [TestCase("|N630|1|Apuração IRPJ Lucro Real|15000,00|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroN630(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|N630|1|Apuração IRPJ Lucro Real|15000,00|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroN630("", versao)
        {
            CodigoReferencial = "1",
            Descricao = "Apuração IRPJ Lucro Real",
            Valor = 15000.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|N630|1|Apuração IRPJ Lucro Real|15000,00|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroN630("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroN630 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("N630");
        reg.Versao.Should().Be(versao);
    }
}
