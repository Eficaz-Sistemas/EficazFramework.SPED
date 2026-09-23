using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Bloco1;

public class Registro1990 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1990();
        reg.Codigo.Should().Be("1990");
    }

    [TestCase("|1990|15|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1990(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|1990|15|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1990("", versao)
        {
            QuantidadeLinhas = 15
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|1990|15|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1990("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1990 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("1990");
        reg.Versao.Should().Be(versao);
        reg.QuantidadeLinhas.Should().Be(15);
    }
}
