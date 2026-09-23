using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC410 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC410();
        reg.Codigo.Should().Be("C410");
    }

    [TestCase("|C410|16,5|76|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC410(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C410|16,5|76|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC410("", versao)
        {
            PIS = 16.5d,
            COFINS = 76.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C410|16,5|76|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC410("", versao);
        reg.PIS.HasValue.Should().BeFalse();
        reg.COFINS.HasValue.Should().BeFalse();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC410 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C410");
        reg.Versao.Should().Be(versao);
        reg.PIS.Should().Be(16.5d);
        reg.COFINS.Should().Be(76.0d);
    }
}
