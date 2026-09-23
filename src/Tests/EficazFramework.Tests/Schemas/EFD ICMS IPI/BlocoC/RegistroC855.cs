using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC855 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC855();
        reg.Codigo.Should().Be("C855");
    }

    [TestCase("|C855|OBS01|Obs fiscal C855|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC855(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C855|OBS01|Obs fiscal C855|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC855("", versao)
        {
            CodigoObs0460 = "OBS01",
            Descricao = "Obs fiscal C855"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C855|OBS01|Obs fiscal C855|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC855("", versao);
        reg.CodigoObs0460.Should().BeNull();
        reg.Descricao.Should().BeNull();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC855 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C855");
        reg.Versao.Should().Be(versao);
        reg.CodigoObs0460.Should().Be("OBS01");
        reg.Descricao.Should().Be("Obs fiscal C855");
    }
}
