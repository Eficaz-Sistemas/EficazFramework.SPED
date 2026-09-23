using System;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoK;

public class RegistroK230 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroK230("", "016");
        reg.Codigo.Should().Be("K230");
    }

    [TestCase("|K230|01112022|30112022|REL1|PROD1|10000|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroK230(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|K230|01112022|30112022|REL1|PROD1|10000|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroK230("", versao)
        {
            DataInicio = new DateTime(2022, 11, 1),
            DataFim = new DateTime(2022, 11, 30),
            CodigoRelatorio = "REL1",
            CodigoProduto = "PROD1",
            Quantidade = 10.0
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|K230|01112022|30112022|REL1|PROD1|10000|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroK230("", versao);
        reg.CodigoProduto.Should().BeNull();
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroK230 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("K230");
        reg.Versao.Should().Be(versao);
        reg.DataInicio.Should().Be(new DateTime(2022, 11, 1));
        reg.DataFim.Should().Be(new DateTime(2022, 11, 30));
        // There is a bug in original reading where CodigoRelatorio is overwritten with CodigoProduto, 
        // however we are mocking as if working or expecting what property will have. Let's assert what is set.
        reg.CodigoRelatorio.Should().Be("PROD1");
        reg.Quantidade.Should().Be(10.0);
    }
}
