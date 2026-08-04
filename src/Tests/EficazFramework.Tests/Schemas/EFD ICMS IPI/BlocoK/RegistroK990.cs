using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoK;

public class RegistroK990 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroK990();
        reg.Codigo.Should().Be("K990");
    }

    [TestCase("|K990|15|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroK990(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|K990|15|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroK990("", versao)
        {
            QuantidadeLinhas = 15
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|K990|15|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroK990("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroK990 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("K990");
        reg.Versao.Should().Be(versao);
        reg.QuantidadeLinhas.Should().Be(15);
    }
}
