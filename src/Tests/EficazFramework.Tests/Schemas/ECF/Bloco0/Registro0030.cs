using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.Bloco0;

public class Registro0030 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.Registro0030();
        reg.Codigo.Should().Be("0030");
    }

    [TestCase("|0030|2062|6201500|Rua Teste|100|Sala 1|Centro|SP|3550308|01001000|1133334444|teste@teste.com|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.Registro0030(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|0030|2062|6201500|Rua Teste|100|Sala 1|Centro|SP|3550308|01001000|1133334444|teste@teste.com|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.Registro0030("", versao)
        {
            NaturezaJuridica = "2062",
            CNAE = "6201500",
            Endereco = "Rua Teste",
            Numero = "100",
            Complemento = "Sala 1",
            Bairro = "Centro",
            UF = "SP",
            CodigoMunicipio = "3550308",
            CEP = "01001000",
            Telefone = "1133334444",
            EMail = "teste@teste.com"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|0030|2062|6201500|Rua Teste|100|Sala 1|Centro|SP|3550308|01001000|1133334444|teste@teste.com|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.Registro0030("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.Registro0030 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("0030");
        reg.Versao.Should().Be(versao);
    }
}
