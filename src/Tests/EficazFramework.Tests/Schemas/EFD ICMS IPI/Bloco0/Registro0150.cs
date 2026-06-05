using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Bloco0;

public class Registro0150 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0150();
        reg.Codigo.Should().Be("0150");
    }

    [TestCase("|0150|001|Fornecedor ABC Ltda|1058|12345678000100||001001|3129707||Rua Fornecedor|500|Galpão A|Zona Industrial|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0150(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|0150|001|Fornecedor ABC Ltda|1058|12345678000100||001001|3129707||Rua Fornecedor|500|Galpão A|Zona Industrial|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0150("", versao)
        {
            ID = "001",
            Nome = "Fornecedor ABC Ltda",
            CodigoPais = "1058",
            CNPJ = "12345678000100",
            CPF = "",
            InscricaoEstadual = "001001",
            CodigoMunicipio = "3129707",
            Suframa = "",
            Endereco = "Rua Fornecedor",
            Numero = "500",
            Complemento = "Galpão A",
            Bairro = "Zona Industrial"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|0150|001|Fornecedor ABC Ltda|1058|12345678000100||001001|3129707||Rua Fornecedor|500|Galpão A|Zona Industrial|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0150("", versao);
        reg.ID.Should().Be(null);
        reg.Nome.Should().Be(null);

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0150 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("0150");
        reg.Versao.Should().Be(versao);
        reg.ID.Should().Be("001");
        reg.Nome.Should().Be("Fornecedor ABC Ltda");
        reg.CodigoPais.Should().Be("1058");
        reg.CNPJ.Should().Be("12345678000100");
        reg.CPF.Should().BeNullOrEmpty();
        reg.InscricaoEstadual.Should().Be("001001");
        reg.CodigoMunicipio.Should().Be("3129707");
        reg.Endereco.Should().Be("Rua Fornecedor");
    }
}
