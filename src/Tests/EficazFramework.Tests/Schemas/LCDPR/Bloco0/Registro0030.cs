using EficazFramework.SPED.Schemas.GNRE;
using FluentAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.LCDPR.Bloco0;

public class Registro0030 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.LCDPR.Registro0030();
        reg.Codigo.Should().Be("0030");
    }

    
    [TestCase("0030|Rua Tiradentes|145||Centro|MG|3129707|37990000||cadastro@eficazcs.com.br")]
    public void Construtor(string linha, string versao = "0013")
    {
        var reg = new EficazFramework.SPED.Schemas.LCDPR.Registro0030(linha, versao);
        InternalRead(reg, versao);
    }


    [TestCase("0030|Rua Tiradentes|145||Centro|MG|3129707|37990000||cadastro@eficazcs.com.br")]
    public void Escrita(string result, string versao = "0013")
    {
        var reg = new EficazFramework.SPED.Schemas.LCDPR.Registro0030("", versao)
        {
            Endereco = "Rua Tiradentes",
            Numero = "145",
            Bairro = "Centro",
            UF = "MG",
            CodigoMunicipio = "3129707",
            CEP = "37990000",
            EMail = "cadastro@eficazcs.com.br"
        };
        reg.ToString().Should().Be(result);
    }


    [TestCase("0030|Rua Tiradentes|145||Centro|MG|3129707|37990000||cadastro@eficazcs.com.br")]
    public void Leitura(string linha, string versao = "0013")
    {
        var reg = new EficazFramework.SPED.Schemas.LCDPR.Registro0030("", versao);
        reg.Endereco.Should().Be(null);
        reg.Numero.Should().Be(null);
        reg.Bairro.Should().Be(null);
        reg.Complemento.Should().Be(null);
        reg.CodigoMunicipio.Should().Be(null);
        reg.CEP.Should().Be(null);
        reg.Telefone.Should().Be(null);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    public void TestRegularConvertFunctionToRegularExpression()
    {
        var stringArray = new string[] { "Teste", "Teste", "Registro", "0030" };
        var reg = new EficazFramework.SPED.Schemas.LCDPR.Registro0030("", "0013");
        var result = reg.ConvertStringArrayInDefaultSchema(stringArray);
        Assert.AreEqual(result, "Teste|Teste|Registro|0030");
    }

    private void InternalRead(EficazFramework.SPED.Schemas.LCDPR.Registro0030 reg, string versao = "0013")
    {
        reg.Endereco.Should().Be("Rua Tiradentes");
        reg.Numero.Should().Be("145");
        reg.Bairro.Should().Be("Centro");
        reg.Complemento.Should().BeEmpty();
        reg.CodigoMunicipio.Should().Be("3129707");
        reg.CEP.Should().Be("37990000");
        reg.Telefone.Should().BeEmpty();
    }

}
