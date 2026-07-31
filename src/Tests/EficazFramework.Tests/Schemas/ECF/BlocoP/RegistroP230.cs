using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoP;

public class RegistroP230 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroP230();
        reg.Codigo.Should().Be("P230");
    }

    [TestCase("|P230|1|Isenção e Redução P230|2000,00|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroP230(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|P230|1|Isenção e Redução P230|2000,00|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroP230("", versao)
        {
            CodigoReferencial = "1",
            Descricao = "Isenção e Redução P230",
            Valor = 2000.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|P230|1|Isenção e Redução P230|2000,00|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroP230("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroP230 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("P230");
        reg.Versao.Should().Be(versao);
    }
}
