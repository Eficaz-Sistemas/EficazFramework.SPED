using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Bloco0;

public class Registro0990 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0990();
        reg.Codigo.Should().Be("0990");
    }

    [TestCase("|0990|50|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0990(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|0990|50|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0990("", versao)
        {
            QuantidadeLinhas = 50
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|0990|50|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0990("", versao);
        reg.QuantidadeLinhas.Should().BeNull();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0990 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("0990");
        reg.Versao.Should().Be(versao);
        reg.QuantidadeLinhas.Should().Be(50);
    }
}
