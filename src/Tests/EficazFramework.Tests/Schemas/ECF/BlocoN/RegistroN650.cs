using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoN;

public class RegistroN650 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroN650();
        reg.Codigo.Should().Be("N650");
    }

    [TestCase("|N650|1|Base CSLL Apos Comp|90000,00|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroN650(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|N650|1|Base CSLL Apos Comp|90000,00|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroN650("", versao)
        {
            CodigoReferencial = "1",
            Descricao = "Base CSLL Apos Comp",
            Valor = 90000.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|N650|1|Base CSLL Apos Comp|90000,00|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroN650("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroN650 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("N650");
        reg.Versao.Should().Be(versao);
    }
}
