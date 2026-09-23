using EficazFramework.SPED.Schemas.ECD;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECD.BlocoI;

public class RegistroI075Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroI075();
        reg.Codigo.Should().Be("I075");
    }

    [TestCase("|I075|HIST1|DESC_HIST1|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroI075(linha, versao);
        reg.Codigo.Should().Be("I075");
        reg.Versao.Should().Be(versao);
        InternalRead(reg, versao);
    }

    [TestCase("|I075|HIST1|DESC_HIST1|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroI075()
        {
            CodHistPadronizado = "HIST1",
            DescHistPadronizado = "DESC_HIST1"
        };
        reg.EscreveLinha().Should().Be(result);
    }

    [TestCase("|I075|HIST1|DESC_HIST1|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroI075(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroI075 reg, string versao)
    {
        reg.CodHistPadronizado.Should().Be("HIST1");
        reg.DescHistPadronizado.Should().Be("DESC_HIST1");
    }
}
