using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC895 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC895();
        reg.Codigo.Should().Be("C895");
    }

    [TestCase("|C895|OBS01|Obs C895|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC895(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C895|OBS01|Obs C895|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC895("", versao)
        {
            CodigoObs0460 = "OBS01",
            Descricao = "Obs C895"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C895|OBS01|Obs C895|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC895("", versao);
        reg.CodigoObs0460.Should().BeNull();
        reg.Descricao.Should().BeNull();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC895 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C895");
        reg.Versao.Should().Be(versao);
        reg.CodigoObs0460.Should().Be("OBS01");
        reg.Descricao.Should().Be("Obs C895");
    }
}
