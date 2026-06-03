using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Bloco0;

public class Registro0400 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0400();
        reg.Codigo.Should().Be("0400");
    }

    [TestCase("|0400|01|0|Regime Ordinário|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0400(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|0400|01|0|Regime Ordinário|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0400("", versao)
        {
            CodigoNatureza = "01",
            Indicador = 0,
            Descricao = "Regime Ordinário"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|0400|01|0|Regime Ordinário|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0400("", versao);
        reg.CodigoNatureza.Should().Be(null);

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0400 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("0400");
        reg.Versao.Should().Be(versao);
        reg.CodigoNatureza.Should().Be("01");
        reg.Descricao.Should().Be("Regime Ordinário");
    }
}
