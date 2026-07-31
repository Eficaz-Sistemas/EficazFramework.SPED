using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC101 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC101();
        reg.Codigo.Should().Be("C101");
    }

    [TestCase("|C101|10|50|20|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC101(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C101|10|50|20|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC101("", versao)
        {
            Vr_FCP_Uf_Destino = 10.0d,
            Vr_ICMS_UF_Destino = 50.0d,
            Vr_ICMS_UF_Remetente = 20.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C101|10|50|20|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC101("", versao);
        reg.Vr_FCP_Uf_Destino.HasValue.Should().BeFalse();
        reg.Vr_ICMS_UF_Destino.HasValue.Should().BeFalse();
        reg.Vr_ICMS_UF_Remetente.HasValue.Should().BeFalse();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC101 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C101");
        reg.Versao.Should().Be(versao);
        reg.Vr_FCP_Uf_Destino.Should().Be(10.0d);
        reg.Vr_ICMS_UF_Destino.Should().Be(50.0d);
        reg.Vr_ICMS_UF_Remetente.Should().Be(20.0d);
    }
}
