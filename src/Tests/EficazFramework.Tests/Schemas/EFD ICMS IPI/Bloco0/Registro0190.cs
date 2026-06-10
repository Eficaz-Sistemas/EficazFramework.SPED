using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Bloco0;

public class Registro0190 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0190();
        reg.Codigo.Should().Be("0190");
    }

    [TestCase("|0190|UN|Unidade|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0190(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|0190|UN|Unidade|", "016")]
    [TestCase("|0190|KG|Quilograma|", "016")]
    [TestCase("|0190|L|Litro|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var unidade = result.Contains("KG") ? "KG" : (result.Contains('L') ? "L" : "UN");
        var descricao = result.Contains("Quilograma") ? "Quilograma" : (result.Contains("Litro") ? "Litro" : "Unidade");
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0190("", versao)
        {
            Unidade = unidade,
            Descricao = descricao
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|0190|UN|Unidade|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0190("", versao);
        reg.Unidade.Should().Be(null);
        reg.Descricao.Should().Be(null);

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0190 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("0190");
        reg.Versao.Should().Be(versao);
        reg.Unidade.Should().NotBeNullOrEmpty();
        reg.Descricao.Should().NotBeNullOrEmpty();
    }
}
