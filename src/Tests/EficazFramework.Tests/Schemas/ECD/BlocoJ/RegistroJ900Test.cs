using System;
using AwesomeAssertions;
using NUnit.Framework;
using EficazFramework.SPED.Schemas.ECD;

namespace EficazFramework.SPED.Schemas.ECD.BlocoJ;

public class RegistroJ900Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroJ900();
        reg.Codigo.Should().Be("J900");
    }

    [TestCase("|J900|TERMO DE ENCERRAMENTO|ORDEM|NAT|NOME|100|01012023|31122023|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroJ900(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|J900|TERMO DE ENCERRAMENTO|ORDEM|NAT|NOME|100|01012023|31122023|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroJ900()
        {
            NumeroOrdemLivro = "ORDEM",
            NaturezaLivro = "NAT",
            NomeEmpresarial = "NOME",
            QtdeLinhasArquivoTotal = 100,
            DataInicioEscrituracao = new DateTime(2023, 1, 1),
            DataTerminoEscrituracao = new DateTime(2023, 12, 31)
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|J900|TERMO DE ENCERRAMENTO|ORDEM|NAT|NOME|100|01012023|31122023|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroJ900();
        reg.LeParametros(linha.Split("|"));
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroJ900 reg, string versao)
    {
        reg.NumeroOrdemLivro.Should().Be("ORDEM");
        reg.NaturezaLivro.Should().Be("NAT");
        reg.NomeEmpresarial.Should().Be("NOME");
        reg.QtdeLinhasArquivoTotal.Should().Be(100);
        reg.DataInicioEscrituracao.Should().Be(new DateTime(2023, 1, 1));
        reg.DataTerminoEscrituracao.Should().Be(new DateTime(2023, 12, 31));
    }
}
