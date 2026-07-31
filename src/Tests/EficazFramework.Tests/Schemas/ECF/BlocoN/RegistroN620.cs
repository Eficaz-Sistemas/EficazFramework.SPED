using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoN;

public class RegistroN620 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroN620();
        reg.Codigo.Should().Be("N620");
    }

    [TestCase("|N620|1|IRPJ Estimativa Mensal|15000,00|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroN620(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|N620|1|IRPJ Estimativa Mensal|15000,00|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroN620("", versao)
        {
            CodigoReferencial = "1",
            Descricao = "IRPJ Estimativa Mensal",
            Valor = 15000.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|N620|1|IRPJ Estimativa Mensal|15000,00|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroN620("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroN620 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("N620");
        reg.Versao.Should().Be(versao);
    }
}
