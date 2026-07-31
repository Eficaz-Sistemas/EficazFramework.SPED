using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC171 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC171();
        reg.Codigo.Should().Be("C171");
    }

    [TestCase("|C171|01|1000|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC171(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C171|01|1000|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC171("", versao)
        {
            NumTanque = "01",
            QuantidadeVolumeArmazenado = 1000.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C171|01|1000|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC171("", versao);
        reg.NumTanque.Should().BeNull();
        reg.QuantidadeVolumeArmazenado.HasValue.Should().BeFalse();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC171 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C171");
        reg.Versao.Should().Be(versao);
        reg.NumTanque.Should().Be("01");
        reg.QuantidadeVolumeArmazenado.Should().Be(1000.0d);
    }
}
