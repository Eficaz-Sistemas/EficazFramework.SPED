using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Bloco0;

public class Registro0001 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0001();
        reg.Codigo.Should().Be("0001");
    }

    [TestCase("|0001|0|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0001(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|0001|0|", "016", Primitives.IndicadorMovimento.ComDados)]
    [TestCase("|0001|1|", "016", Primitives.IndicadorMovimento.SemDados)]
    public void Escrita(string result, string versao = "016", Primitives.IndicadorMovimento indicadorMovimento = Primitives.IndicadorMovimento.ComDados)
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0001("", versao)
        {
            IndicadorMovimento = indicadorMovimento
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|0001|0|", "016", Primitives.IndicadorMovimento.ComDados)]
    [TestCase("|0001|1|", "016", Primitives.IndicadorMovimento.SemDados)]
    public void Leitura(string linha, string versao = "016", Primitives.IndicadorMovimento indicadorMovimento = Primitives.IndicadorMovimento.ComDados)
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0001("", versao);
        reg.IndicadorMovimento.Should().Be(indicadorMovimento);

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0001 reg, string versao = "016", Primitives.IndicadorMovimento indicadorMovimento = Primitives.IndicadorMovimento.ComDados)
    {
        reg.Codigo.Should().Be("0001");
        reg.Versao.Should().Be(versao);
        reg.IndicadorMovimento.Should().Be(indicadorMovimento);
    }
}
