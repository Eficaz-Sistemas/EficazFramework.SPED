using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC197 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC197();
        reg.Codigo.Should().Be("C197");
    }

    [TestCase("|C197|MG20000001|Ajuste fiscal|PROD01|1000|18|180|0|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC197(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C197|MG20000001|Ajuste fiscal|PROD01|1000|18|180|0|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC197("", versao)
        {
            CodigoAjusteBeneficio = "MG20000001",
            DescricaoAjusteBeneficio = "Ajuste fiscal",
            CodigoItem = "PROD01",
            ValorBaseCalculoICMS = 1000.0d,
            AliquotaICMS = 18.0d,
            ValorICMS = 180.0d,
            ValorOutros = 0.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C197|MG20000001|Ajuste fiscal|PROD01|1000|18|180|0|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC197("", versao);
        reg.CodigoAjusteBeneficio.Should().BeNull();
        reg.ValorICMS.HasValue.Should().BeFalse();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC197 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C197");
        reg.Versao.Should().Be(versao);
        reg.CodigoAjusteBeneficio.Should().Be("MG20000001");
        reg.DescricaoAjusteBeneficio.Should().Be("Ajuste fiscal");
        reg.CodigoItem.Should().Be("PROD01");
        reg.ValorBaseCalculoICMS.Should().Be(1000.0d);
        reg.AliquotaICMS.Should().Be(18.0d);
        reg.ValorICMS.Should().Be(180.0d);
        reg.ValorOutros.Should().Be(0.0d);
    }
}
