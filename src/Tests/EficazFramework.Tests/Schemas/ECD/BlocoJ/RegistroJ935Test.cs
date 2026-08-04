using System;
using AwesomeAssertions;
using NUnit.Framework;
using EficazFramework.SPED.Schemas.ECD;

namespace EficazFramework.SPED.Schemas.ECD.BlocoJ;

public class RegistroJ935Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroJ935();
        reg.Codigo.Should().Be("J935");
    }

    [TestCase("|J935|CNPJ|NOME|REG|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroJ935(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|J935|CNPJ|NOME|REG|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroJ935("", versao)
        {
            CNPJCPFAuditor = "CNPJ",
            NomeAuditor = "NOME",
            RegistroAuditorCVM = "REG"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|J935|CNPJ|NOME|REG|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroJ935(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroJ935 reg, string versao)
    {
        reg.CNPJCPFAuditor.Should().Be("CNPJ");
        reg.NomeAuditor.Should().Be("NOME");
        reg.RegistroAuditorCVM.Should().Be("REG");
    }
}
