using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC141 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC141();
        reg.Codigo.Should().Be("C141");
    }

    [TestCase("|C141|1|01122022|100|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC141(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C141|1|01122022|100|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC141("", versao)
        {
            Numero_Parcela = 1,
            Data_vecto_parcela = new System.DateTime(2022, 12, 1),
            Valor_parcela = 100.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C141|1|01122022|100|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC141("", versao);
        reg.Numero_Parcela.HasValue.Should().BeFalse();
        reg.Valor_parcela.HasValue.Should().BeFalse();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC141 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C141");
        reg.Versao.Should().Be(versao);
        reg.Numero_Parcela.Should().Be(1);
        reg.Data_vecto_parcela.Should().Be(new System.DateTime(2022, 12, 1));
        reg.Valor_parcela.Should().Be(100.0d);
    }
}
