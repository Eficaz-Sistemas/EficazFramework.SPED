using System;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECD.BlocoK;

public class RegistroK210Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroK210();
        reg.Codigo.Should().Be("K210");
    }

    [TestCase("|K210|EMP01|200|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroK210(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|K210|EMP01|200|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroK210("", versao)
        {
            CodigoIdentEmpresaParticipante = "EMP01",
            CodigoContaEmpresaParticipante = "200"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|K210|EMP01|200|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroK210(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroK210 reg, string versao)
    {
        reg.CodigoIdentEmpresaParticipante.Should().Be("EMP01");
        reg.CodigoContaEmpresaParticipante.Should().Be("200");
    }
}
