using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoY;

public class RegistroY540 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroY540();
        reg.Codigo.Should().Be("Y540");
    }

    [TestCase("|Y540|12345678000100|150000,00|6201500|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroY540(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|Y540|12345678000100|150000,00|6201500|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroY540("", versao)
        {
            CNPJEstabelecimento = "12345678000100",
            ValorReceitas = 150000.0d,
            CNAE = "6201500"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|Y540|12345678000100|150000,00|6201500|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroY540("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroY540 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("Y540");
        reg.Versao.Should().Be(versao);
    }
}
