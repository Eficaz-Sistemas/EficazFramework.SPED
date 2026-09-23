using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoN;

public class RegistroN660 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroN660();
        reg.Codigo.Should().Be("N660");
    }

    [TestCase("|N660|1|CSLL Estimativa Mensal|8100,00|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroN660(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|N660|1|CSLL Estimativa Mensal|8100,00|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroN660("", versao)
        {
            CodigoReferencial = "1",
            Descricao = "CSLL Estimativa Mensal",
            Valor = 8100.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|N660|1|CSLL Estimativa Mensal|8100,00|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroN660("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroN660 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("N660");
        reg.Versao.Should().Be(versao);
    }
}
