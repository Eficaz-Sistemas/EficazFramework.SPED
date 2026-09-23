using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoL;

public class RegistroL210 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroL210();
        reg.Codigo.Should().Be("L210");
    }

    [TestCase("|L210|REF01|Mão de Obra Direta|15000,00|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroL210(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|L210|REF01|Mão de Obra Direta|15000,00|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroL210("", versao)
        {
            CodigoReferencial = "REF01",
            Descricao = "Mão de Obra Direta",
            Valor = 15000.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|L210|REF01|Mão de Obra Direta|15000,00|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroL210("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroL210 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("L210");
        reg.Versao.Should().Be(versao);
    }
}
