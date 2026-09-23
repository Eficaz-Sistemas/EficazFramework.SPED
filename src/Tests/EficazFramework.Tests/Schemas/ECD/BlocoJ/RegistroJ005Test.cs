using System;
using AwesomeAssertions;
using NUnit.Framework;
using EficazFramework.SPED.Schemas.ECD;

namespace EficazFramework.SPED.Schemas.ECD.BlocoJ;

public class RegistroJ005Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroJ005();
        reg.Codigo.Should().Be("J005");
    }

    [TestCase("|J005|01012023|31122023|ID|CABECALHO|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroJ005(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|J005|01012023|31122023|ID|CABECALHO|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroJ005()
        {
            DataInicialDC = new DateTime(2023, 1, 1),
            DataFinalDC = new DateTime(2023, 12, 31),
            IdentificacaoDemonstracoes = "ID",
            CabecalhoDemonstracoes = "CABECALHO"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|J005|01012023|31122023|ID|CABECALHO|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroJ005();
        reg.LeParametros(linha.Split("|"));
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroJ005 reg, string versao)
    {
        reg.DataInicialDC.Should().Be(new DateTime(2023, 1, 1));
        reg.DataFinalDC.Should().Be(new DateTime(2023, 12, 31));
        reg.IdentificacaoDemonstracoes.Should().Be("ID");
        reg.CabecalhoDemonstracoes.Should().Be("CABECALHO");
    }
}
