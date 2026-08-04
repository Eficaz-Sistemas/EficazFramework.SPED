using EficazFramework.SPED.Schemas.ECD;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECD.BlocoI;

public class RegistroI012Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroI012();
        reg.Codigo.Should().Be("I012");
    }

    [TestCase("|I012|1|LIVRO_NATUREZA|0|HASH123|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroI012(linha, versao);
        reg.Codigo.Should().Be("I012");
        reg.Versao.Should().Be(versao);
        InternalRead(reg, versao);
    }

    [TestCase("|I012|1|LIVRO_NATUREZA|0|HASH123|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroI012()
        {
            NumeroOrdemInstAssociado = 1,
            NaturezaLivroAssociado = "LIVRO_NATUREZA",
            TipoEscrituracao = TipoEscrituracao.Digital,
            CodigoHASHLivroAuxiliar = "HASH123"
        };
        reg.EscreveLinha().Should().Be(result);
    }

    [TestCase("|I012|1|LIVRO_NATUREZA|0|HASH123|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroI012(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroI012 reg, string versao)
    {
        reg.NumeroOrdemInstAssociado.Should().Be(1);
        reg.NaturezaLivroAssociado.Should().Be("LIVRO_NATUREZA");
        reg.TipoEscrituracao.Should().Be(TipoEscrituracao.Digital);
        reg.CodigoHASHLivroAuxiliar.Should().Be("HASH123");
    }
}
