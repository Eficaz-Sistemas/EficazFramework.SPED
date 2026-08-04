using System;
using EficazFramework.SPED.Schemas.ECD;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECD.BlocoI;

public class RegistroI030Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroI030();
        reg.Codigo.Should().Be("I030");
    }

    [TestCase("|I030|TERMO DE ABERTURA|1|NAT_LIVRO|100|EMPRESA|NIRE123|12345678000199|01012023|02012023|MUNICIPIO|31122023|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroI030(linha, versao);
        reg.Codigo.Should().Be("I030");
        reg.Versao.Should().Be(versao);
        InternalRead(reg, versao);
    }

    [TestCase("|I030|TERMO DE ABERTURA|1|NAT_LIVRO|100|EMPRESA|NIRE123|12345678000199|01012023|02012023|MUNICIPIO|31122023|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroI030()
        {
            NumeroOrdemEscrituracao = 1,
            NaturezaLivro = "NAT_LIVRO",
            QtdeLinhasArquivo = 100,
            NomeEmpresarial = "EMPRESA",
            Nire = "NIRE123",
            CNPJ = "12345678000199",
            DataArquivamentoAtos = new DateTime(2023, 1, 1),
            DataArquivAtoConversao = new DateTime(2023, 1, 2),
            Municipio = "MUNICIPIO",
            DataEncerrExSocial = new DateTime(2023, 12, 31)
        };
        reg.EscreveLinha().Should().Be(result);
    }

    [TestCase("|I030|TERMO DE ABERTURA|1|NAT_LIVRO|100|EMPRESA|NIRE123|12345678000199|01012023|02012023|MUNICIPIO|31122023|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroI030(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroI030 reg, string versao)
    {
        reg.NumeroOrdemEscrituracao.Should().Be(1);
        reg.NaturezaLivro.Should().Be("NAT_LIVRO");
        reg.QtdeLinhasArquivo.Should().Be(100);
        reg.NomeEmpresarial.Should().Be("EMPRESA");
        reg.Nire.Should().Be("NIRE123");
        reg.CNPJ.Should().Be("12345678000199");
        reg.DataArquivamentoAtos.Should().Be(new DateTime(2023, 1, 1));
        reg.DataArquivAtoConversao.Should().Be(new DateTime(2023, 1, 2));
        reg.Municipio.Should().Be("MUNICIPIO");
        reg.DataEncerrExSocial.Should().Be(new DateTime(2023, 12, 31));
    }
}
