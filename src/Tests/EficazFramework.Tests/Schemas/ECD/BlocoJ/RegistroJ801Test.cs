using System;
using AwesomeAssertions;
using NUnit.Framework;
using EficazFramework.SPED.Schemas.ECD;

namespace EficazFramework.SPED.Schemas.ECD.BlocoJ;

public class RegistroJ801Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroJ801();
        reg.Codigo.Should().Be("J801");
    }

    [TestCase("|J801|TIPO|DESC|HASH|BYTES|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroJ801(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|J801|TIPO|DESC|HASH|BYTES||J801FIM|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroJ801()
        {
            TipoDoc = "TIPO",
            DescricaoArquivoRTF = "DESC",
            HashArquivoRTF = "HASH",
            SequenciaBytesArquitoRTF = "BYTES"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|J801|TIPO|DESC|HASH|BYTES|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroJ801();
        reg.LeParametros(linha.Split("|"));
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroJ801 reg, string versao)
    {
        reg.TipoDoc.Should().Be("TIPO");
        reg.DescricaoArquivoRTF.Should().Be("DESC");
        reg.HashArquivoRTF.Should().Be("HASH");
        reg.SequenciaBytesArquitoRTF.Should().Be("BYTES");
    }
}
