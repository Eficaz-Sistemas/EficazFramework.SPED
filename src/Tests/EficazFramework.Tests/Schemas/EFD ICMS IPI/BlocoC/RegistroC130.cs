using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC130 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC130();
        reg.Codigo.Should().Be("C130");
    }

    [TestCase("|C130|100|200|10|200|3|200|22|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC130(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C130|100|200|10|200|3|200|22|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC130("", versao)
        {
            Vr_Serv_NaoIncidenciaICMS = 100.0d,
            Vr_Base_ISSQN = 200.0d,
            Vr_ISSQN = 10.0d,
            Vr_BC_IRRF = 200.0d,
            Vr_IRRF = 3.0d,
            Vr_BC_Prev = 200.0d,
            Vr_Previdencia = 22.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C130|100|200|10|200|3|200|22|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC130("", versao);
        reg.Vr_Serv_NaoIncidenciaICMS.HasValue.Should().BeFalse();
        reg.Vr_Base_ISSQN.HasValue.Should().BeFalse();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC130 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C130");
        reg.Versao.Should().Be(versao);
        reg.Vr_Serv_NaoIncidenciaICMS.Should().Be(100.0d);
        reg.Vr_Base_ISSQN.Should().Be(200.0d);
        reg.Vr_ISSQN.Should().Be(10.0d);
        reg.Vr_BC_IRRF.Should().Be(200.0d);
        reg.Vr_IRRF.Should().Be(3.0d);
        reg.Vr_BC_Prev.Should().Be(200.0d);
        reg.Vr_Previdencia.Should().Be(22.0d);
    }
}
