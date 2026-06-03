using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Bloco0;

public class Registro0100 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0100();
        reg.Codigo.Should().Be("0100");
    }

    [TestCase("|0100|João da Silva|12345678900|123456/O-SP|12345678000100|37990000|Rua Principal|100|Sala 01|Centro|3133330000|3133331111|joao@empresa.com|3129707|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0100(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|0100|João da Silva|12345678900|123456/O-SP|12345678000100|37990000|Rua Principal|100|Sala 01|Centro|3133330000|3133331111|joao@empresa.com|3129707|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0100("", versao)
        {
            Nome = "João da Silva",
            CPF = "12345678900",
            CRC = "123456/O-SP",
            CNPJ = "12345678000100",
            CEP = "37990000",
            Endereco = "Rua Principal",
            Numero = "100",
            Complemento = "Sala 01",
            Bairro = "Centro",
            Fone = "3133330000",
            Fax = "3133331111",
            eMail = "joao@empresa.com",
            CodigoMunicipio = "3129707"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|0100|João da Silva|12345678900|123456/O-SP|12345678000100|37990000|Rua Principal|100|Sala 01|Centro|3133330000|3133331111|joao@empresa.com|3129707|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0100("", versao);
        reg.Nome.Should().Be(null);
        reg.CPF.Should().Be(null);

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0100 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("0100");
        reg.Versao.Should().Be(versao);
        reg.Nome.Should().Be("João da Silva");
        reg.CPF.Should().Be("12345678900");
        reg.CRC.Should().Be("123456/O-SP");
        reg.CNPJ.Should().Be("12345678000100");
        reg.CEP.Should().Be("37990000");
        reg.Endereco.Should().Be("Rua Principal");
        reg.Numero.Should().Be("100");
        reg.Complemento.Should().Be("Sala 01");
        reg.Bairro.Should().Be("Centro");
        reg.CodigoMunicipio.Should().Be("3129707");
    }
}
