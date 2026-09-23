using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC897 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC897();
        reg.Codigo.Should().Be("C897");
    }

    [TestCase("|C897|BENEF01|Desc beneficio C897|PROD01|100|18|18|0|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC897(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C897|BENEF01|Desc beneficio C897|PROD01|100|18|18|0|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC897("", versao)
        {
            CodigoAjusteBeneficio = "BENEF01",
            DescricaoAjusteBeneficio = "Desc beneficio C897",
            CodigoItem = "PROD01",
            ValorBaseCalculoICMS = 100.0d,
            AliquotaICMS = 18.0d,
            ValorICMS = 18.0d,
            ValorOutros = 0.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C897|BENEF01|Desc beneficio C897|PROD01|100|18|18|0|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC897("", versao);
        reg.CodigoAjusteBeneficio.Should().BeNull();
        reg.ValorICMS.HasValue.Should().BeFalse();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC897 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C897");
        reg.Versao.Should().Be(versao);
        reg.CodigoAjusteBeneficio.Should().Be("BENEF01");
        reg.DescricaoAjusteBeneficio.Should().Be("Desc beneficio C897");
        reg.CodigoItem.Should().Be("PROD01");
        reg.ValorBaseCalculoICMS.Should().Be(100.0d);
        reg.AliquotaICMS.Should().Be(18.0d);
        reg.ValorICMS.Should().Be(18.0d);
        reg.ValorOutros.Should().Be(0.0d);
    }
}
