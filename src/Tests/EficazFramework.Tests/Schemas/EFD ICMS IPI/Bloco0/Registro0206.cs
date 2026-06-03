using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Bloco0;

public class Registro0206 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0206();
        reg.Codigo.Should().Be("0206");
    }

    [TestCase("|0206|7501|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0206(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|0206|7501|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0206("", versao)
        {
            CodigoANP = "7501"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|0206|7501|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0206("", versao);
        reg.CodigoANP.Should().Be(null);

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0206 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("0206");
        reg.Versao.Should().Be(versao);
        reg.CodigoANP.Should().Be("7501");
    }
}
