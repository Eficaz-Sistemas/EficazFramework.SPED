using System;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECD.Bloco0;

public class Registro0035Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new Registro0035();
        reg.Codigo.Should().Be("0035");
    }

    [TestCase("|0035|12345678000199|NOME SCP|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new Registro0035(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|0035|12345678000199|NOME SCP|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new Registro0035("", versao)
        {
            IdentificacaoSCPCNPJ = "12345678000199",
            NomeSCP = "NOME SCP"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|0035|12345678000199|NOME SCP|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new Registro0035(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(Registro0035 reg, string versao)
    {
        reg.IdentificacaoSCPCNPJ.Should().Be("12345678000199");
        reg.NomeSCP.Should().Be("NOME SCP");
    }
}
