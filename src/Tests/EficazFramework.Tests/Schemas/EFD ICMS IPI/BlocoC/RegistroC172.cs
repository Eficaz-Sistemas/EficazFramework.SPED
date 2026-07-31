using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC172 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC172();
        reg.Codigo.Should().Be("C172");
    }

    [TestCase("|C172|500|5|25|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC172(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C172|500|5|25|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC172("", versao)
        {
            ValorBaseCalculo = 500.0d,
            Aliquota = 5.0d,
            Valor = 25.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C172|500|5|25|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC172("", versao);
        reg.ValorBaseCalculo.HasValue.Should().BeFalse();
        reg.Valor.HasValue.Should().BeFalse();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC172 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C172");
        reg.Versao.Should().Be(versao);
        reg.ValorBaseCalculo.Should().Be(500.0d);
        reg.Aliquota.Should().Be(5.0d);
        reg.Valor.Should().Be(25.0d);
    }
}
