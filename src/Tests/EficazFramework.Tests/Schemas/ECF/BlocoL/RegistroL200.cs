using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoL;

public class RegistroL200 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroL200();
        reg.Codigo.Should().Be("L200");
    }

    [TestCase("|L200|1|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroL200(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|L200|1|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroL200("", versao)
        {
            Metodo = MetodoAvEstoque.CustoMedioPonderado
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|L200|1|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroL200("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroL200 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("L200");
        reg.Versao.Should().Be(versao);
        reg.Metodo.Should().Be(MetodoAvEstoque.CustoMedioPonderado);
    }
}
