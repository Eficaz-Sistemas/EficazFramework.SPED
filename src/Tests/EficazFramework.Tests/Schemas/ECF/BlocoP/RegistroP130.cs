using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoP;

public class RegistroP130 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroP130();
        reg.Codigo.Should().Be("P130");
    }

    [TestCase("|P130|1|Receitas Incentivadas|20000,00|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroP130(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|P130|1|Receitas Incentivadas|20000,00|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroP130("", versao)
        {
            CodigoReferencial = "1",
            Descricao = "Receitas Incentivadas",
            Valor = 20000.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|P130|1|Receitas Incentivadas|20000,00|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroP130("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroP130 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("P130");
        reg.Versao.Should().Be(versao);
    }
}
