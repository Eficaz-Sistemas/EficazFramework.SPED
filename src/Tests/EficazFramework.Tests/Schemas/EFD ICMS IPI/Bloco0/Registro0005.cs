using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Bloco0;

public class Registro0005 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0005();
        reg.Codigo.Should().Be("0005");
    }

    [TestCase("|0005|Nome Fantasia Ltda|37990000|Rua Exemplo|88|Apto 200|Centro|3133330000|3133331111|contato@empresa.com.br|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0005(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|0005|Nome Fantasia Ltda|37990000|Rua Exemplo|88|Apto 200|Centro|3133330000|3133331111|contato@empresa.com.br|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0005("", versao)
        {
            NomeFantasia = "Nome Fantasia Ltda",
            CEP = "37990000",
            Endereco = "Rua Exemplo",
            Numero = "88",
            Complemento = "Apto 200",
            Bairro = "Centro",
            Fone = "3133330000",
            Fax = "3133331111",
            EMail = "contato@empresa.com.br"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|0005|Nome Fantasia Ltda|37990000|Rua Exemplo|88|Apto 200|Centro|3133330000|3133331111|contato@empresa.com.br|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0005("", versao);
        reg.NomeFantasia.Should().Be(null);
        reg.CEP.Should().Be(null);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0005 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("0005");
        reg.Versao.Should().Be(versao);
        reg.NomeFantasia.Should().Be("Nome Fantasia Ltda");
        reg.CEP.Should().Be("37990000");
        reg.Endereco.Should().Be("Rua Exemplo");
        reg.Numero.Should().Be("88");
        reg.Complemento.Should().Be("Apto 200");
        reg.Bairro.Should().Be("Centro");
        reg.Fone.Should().Be("3133330000");
        reg.Fax.Should().Be("3133331111");
        reg.EMail.Should().Be("contato@empresa.com.br");
    }
}
