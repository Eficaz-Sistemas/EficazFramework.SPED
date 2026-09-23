using System;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECD.Bloco0;

public class Registro0007Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new Registro0007();
        reg.Codigo.Should().Be("0007");
    }

    [TestCase("|0007|01|12345|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new Registro0007(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|0007|01|12345|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new Registro0007("", versao)
        {
            CodigoInstRespAdmCadastro = "01",
            CodigoCadastralPJInst = "12345"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|0007|01|12345|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new Registro0007(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(Registro0007 reg, string versao)
    {
        reg.CodigoInstRespAdmCadastro.Should().Be("01");
        reg.CodigoCadastralPJInst.Should().Be("12345");
    }
}
