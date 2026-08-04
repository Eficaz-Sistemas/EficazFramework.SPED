using System;
using AwesomeAssertions;
using NUnit.Framework;
using EficazFramework.SPED.Schemas.ECD;

namespace EficazFramework.SPED.Schemas.ECD.BlocoI;

public class RegistroI510Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroI510();
        reg.Codigo.Should().Be("I510");
    }

    [TestCase("|I510|NOME|DESC|T|10|2|5|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroI510(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|I510|NOME|DESC|T|10|2|5|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroI510()
        {
            NomeCampo = "NOME",
            DescricaoCampo = "DESC",
            TipoCampo = "T",
            TamanhoCampo = 10,
            QtdeCasasDecimais = 2,
            LarguraColunaRelatorio = 5
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|I510|NOME|DESC|T|10|2|5|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroI510();
        reg.LeParametros(linha.Split("|"));
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroI510 reg, string versao)
    {
        reg.NomeCampo.Should().Be("NOME");
        reg.DescricaoCampo.Should().Be("DESC");
        reg.TipoCampo.Should().Be("T");
        reg.TamanhoCampo.Should().Be(10);
        reg.QtdeCasasDecimais.Should().Be(2);
        reg.LarguraColunaRelatorio.Should().Be(5);
    }
}
