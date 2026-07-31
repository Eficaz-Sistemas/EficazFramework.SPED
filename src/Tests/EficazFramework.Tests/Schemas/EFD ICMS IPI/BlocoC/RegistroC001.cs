using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC001 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC001();
        reg.Codigo.Should().Be("C001");
    }

    [TestCase("|C001|0|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC001(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C001|0|", "016", Primitives.IndicadorMovimento.ComDados)]
    [TestCase("|C001|1|", "016", Primitives.IndicadorMovimento.SemDados)]
    public void Escrita(string result, string versao = "016", Primitives.IndicadorMovimento indicadorMovimento = Primitives.IndicadorMovimento.ComDados)
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC001("", versao)
        {
            IndicadorMovimento = indicadorMovimento
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C001|0|", "016", Primitives.IndicadorMovimento.ComDados)]
    [TestCase("|C001|1|", "016", Primitives.IndicadorMovimento.SemDados)]
    public void Leitura(string linha, string versao = "016", Primitives.IndicadorMovimento indicadorMovimento = Primitives.IndicadorMovimento.ComDados)
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC001("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao, indicadorMovimento);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC001 reg, string versao = "016", Primitives.IndicadorMovimento indicadorMovimento = Primitives.IndicadorMovimento.ComDados)
    {
        reg.Codigo.Should().Be("C001");
        reg.Versao.Should().Be(versao);
        reg.IndicadorMovimento.Should().Be(indicadorMovimento);
    }
}
