using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.Bloco0;

public class Registro0930 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.Registro0930();
        reg.Codigo.Should().Be("0930");
    }

    [TestCase("|0930|João Contador|12345678901|000|CRC12345|contador@teste.com|11999998888|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.Registro0930(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|0930|João Contador|12345678901|000|CRC12345|contador@teste.com|11999998888|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.Registro0930("", versao)
        {
            Nome = "João Contador",
            CNPJ_CPF = "12345678901",
            Qualificacao = null,
            CRC_Contador = "CRC12345",
            EMail = "contador@teste.com",
            Telefone = "11999998888"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|0930|João Contador|12345678901|000|CRC12345|contador@teste.com|11999998888|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.Registro0930("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.Registro0930 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("0930");
        reg.Versao.Should().Be(versao);
    }
}
