using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoD;

public class RegistroD197 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD197();
        reg.Codigo.Should().Be("D19");
    }

    [TestCase("|D197|BENEF01|Desc beneficio D197|PROD01|100|12|12|0|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD197(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|D197|BENEF01|Desc beneficio D197|PROD01|100|12|12|0|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD197("", versao)
        {
            CodigoAjusteBeneficio = "BENEF01",
            DescricaoAjusteBeneficio = "Desc beneficio D197",
            CodigoItem = "PROD01",
            ValorBaseCalculoICMS = 100.0d,
            AliquotaICMS = 12.0d,
            ValorICMS = 12.0d,
            ValorOutros = 0.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|D197|BENEF01|Desc beneficio D197|PROD01|100|12|12|0|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD197("", versao);
        reg.CodigoAjusteBeneficio.Should().BeNull();
        reg.ValorICMS.HasValue.Should().BeFalse();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD197 reg, string versao = "016")
    {
        reg.Codigo.Should().StartWith("D19");
        reg.Versao.Should().Be(versao);
        reg.CodigoAjusteBeneficio.Should().Be("BENEF01");
        reg.DescricaoAjusteBeneficio.Should().Be("Desc beneficio D197");
        reg.CodigoItem.Should().Be("PROD01");
        reg.ValorBaseCalculoICMS.Should().Be(100.0d);
        reg.AliquotaICMS.Should().Be(12.0d);
        reg.ValorICMS.Should().Be(12.0d);
        reg.ValorOutros.Should().Be(0.0d);
    }
}
