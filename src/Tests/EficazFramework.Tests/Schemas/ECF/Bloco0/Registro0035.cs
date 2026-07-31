using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.Bloco0;

public class Registro0035 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.Registro0035();
        reg.Codigo.Should().Be("0035");
    }

    [TestCase("|0035|SCP001|SCP Teste|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.Registro0035(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|0035|SCP001|SCP Teste|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.Registro0035("", versao)
        {
            CodigoSCP = "SCP001",
            NomeSCP = "SCP Teste"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|0035|SCP001|SCP Teste|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.Registro0035("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.Registro0035 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("0035");
        reg.Versao.Should().Be(versao);
    }
}
