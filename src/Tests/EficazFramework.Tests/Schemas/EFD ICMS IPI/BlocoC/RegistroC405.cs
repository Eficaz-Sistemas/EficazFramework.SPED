using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC405 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC405();
        reg.Codigo.Should().Be("C405");
    }

    [TestCase("|C405|01112022|1|10|100|5000|1000|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC405(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C405|01112022|1|10|100|5000|1000|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC405("", versao)
        {
            Data = new System.DateTime(2022, 11, 1),
            CRO = 1,
            CRZ = 10,
            COO = 100,
            GrandeTotalFinal = 5000.0d,
            VendaBruta = 1000.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C405|01112022|1|10|100|5000|1000|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC405("", versao);
        reg.Data.HasValue.Should().BeFalse();
        reg.CRO.HasValue.Should().BeFalse();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC405 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C405");
        reg.Versao.Should().Be(versao);
        reg.Data.Should().Be(new System.DateTime(2022, 11, 1));
        reg.CRO.Should().Be(1);
        reg.CRZ.Should().Be(10);
        reg.COO.Should().Be(100);
        reg.GrandeTotalFinal.Should().Be(5000.0d);
        reg.VendaBruta.Should().Be(1000.0d);
    }
}
