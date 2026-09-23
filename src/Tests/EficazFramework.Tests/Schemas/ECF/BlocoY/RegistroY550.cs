using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoY;

public class RegistroY550 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroY570();
        reg.Codigo.Should().Be("Y550");
    }

    [TestCase("|Y550|12345678000100|84713012|50000,00|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroY570(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|Y550|12345678000100|84713012|50000,00|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroY570("", versao)
        {
            CNPJ_Exportadora = "12345678000100",
            NCM = "84713012",
            ValorVenda = 50000.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|Y550|12345678000100|84713012|50000,00|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroY570(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroY570 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("Y550");
        reg.Versao.Should().Be(versao);
    }
}
