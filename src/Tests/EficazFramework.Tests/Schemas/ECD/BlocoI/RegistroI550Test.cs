using System;
using AwesomeAssertions;
using NUnit.Framework;
using EficazFramework.SPED.Schemas.ECD;

namespace EficazFramework.SPED.Schemas.ECD.BlocoI;

public class RegistroI550Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroI550();
        reg.Codigo.Should().Be("I550");
    }

    [TestCase("|I550|PROD|DESC|10|150,5|1505|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroI550(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|I550|PROD|DESC|10|150,5|1505|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroI550()
        {
            CodProduto = "PROD",
            DescricaoProduto = "DESC",
            QtdeProduto = 10,
            VrUnitario = 150.5,
            VrTotal = 1505
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|I550|PROD|DESC|10|150,5|1505|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroI550();
        reg.LeParametros(linha.Split("|"));
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroI550 reg, string versao)
    {
        reg.CodProduto.Should().Be("PROD");
        reg.DescricaoProduto.Should().Be("DESC");
        reg.QtdeProduto.Should().Be(10);
        reg.VrUnitario.Should().Be(150.5);
        reg.VrTotal.Should().Be(1505);
    }
}
