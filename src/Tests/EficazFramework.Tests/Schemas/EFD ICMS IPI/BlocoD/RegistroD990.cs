using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoD;

public class RegistroD990 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD990();
        reg.Codigo.Should().Be("D990");
    }

    [TestCase("|D990|10|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD990(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|D990|10|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD990("", versao)
        {
            QuantidadeLinhas = 10
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|D990|10|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD990("", versao);
        reg.QuantidadeLinhas.HasValue.Should().BeFalse();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD990 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("D990");
        reg.Versao.Should().Be(versao);
        reg.QuantidadeLinhas.Should().Be(10);
    }
}
