using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoY;

public class RegistroY612 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroY612();
        reg.Codigo.Should().Be("Y612");
    }

    [TestCase("|Y612|12345678901|Dirigente Teste|226|15000,00|0,00|2500,00|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroY612(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|Y612|12345678901|Dirigente Teste|226|15000,00|0,00|2500,00|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroY612("", versao)
        {
            CPF = "12345678901",
            Nome = "Dirigente Teste",
            Qualificacao = "226",
            ValorRemuneracao = 15000.0d,
            ValorDemaisRendimentos = 0.0d,
            ValorIR_Retido = 2500.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|Y612|12345678901|Dirigente Teste|226|15000,00|0,00|2500,00|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroY612("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroY612 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("Y612");
        reg.Versao.Should().Be(versao);
    }
}
