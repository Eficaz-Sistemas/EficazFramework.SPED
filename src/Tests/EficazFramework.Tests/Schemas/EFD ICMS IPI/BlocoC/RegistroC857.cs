using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC857 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC857();
        reg.Codigo.Should().Be("C857");
    }

    [TestCase("|C857|BENEF01|Desc beneficio|PROD01|100|18|18|0|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC857(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C857|BENEF01|Desc beneficio|PROD01|100|18|18|0|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC857("", versao)
        {
            CodigoAjusteBeneficio = "BENEF01",
            DescricaoAjusteBeneficio = "Desc beneficio",
            CodigoItem = "PROD01",
            ValorBaseCalculoICMS = 100.0d,
            AliquotaICMS = 18.0d,
            ValorICMS = 18.0d,
            ValorOutros = 0.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C857|BENEF01|Desc beneficio|PROD01|100|18|18|0|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC857("", versao);
        reg.CodigoAjusteBeneficio.Should().BeNull();
        reg.ValorICMS.HasValue.Should().BeFalse();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC857 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C857");
        reg.Versao.Should().Be(versao);
        reg.CodigoAjusteBeneficio.Should().Be("BENEF01");
        reg.DescricaoAjusteBeneficio.Should().Be("Desc beneficio");
        reg.CodigoItem.Should().Be("PROD01");
        reg.ValorBaseCalculoICMS.Should().Be(100.0d);
        reg.AliquotaICMS.Should().Be(18.0d);
        reg.ValorICMS.Should().Be(18.0d);
        reg.ValorOutros.Should().Be(0.0d);
    }
}
