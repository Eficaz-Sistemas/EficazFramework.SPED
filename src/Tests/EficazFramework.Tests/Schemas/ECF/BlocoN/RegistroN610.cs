using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoN;

public class RegistroN610 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroN610();
        reg.Codigo.Should().Be("N610");
    }

    [TestCase("|N610|1|Isenção e Redução IRPJ|7500,00|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroN610(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|N610|1|Isenção e Redução IRPJ|7500,00|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroN610("", versao)
        {
            CodigoReferencial = "1",
            Descricao = "Isenção e Redução IRPJ",
            Valor = 7500.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|N610|1|Isenção e Redução IRPJ|7500,00|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroN610("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroN610 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("N610");
        reg.Versao.Should().Be(versao);
    }
}
