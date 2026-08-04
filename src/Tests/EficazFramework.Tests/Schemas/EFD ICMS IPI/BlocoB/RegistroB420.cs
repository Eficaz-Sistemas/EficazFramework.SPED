using AwesomeAssertions;
using NUnit.Framework;
using System;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoB;

public class RegistroB420 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB420();
        reg.Codigo.Should().Be("B420");
    }

    [TestCase("|B420|1000,00|1000,00|1000,00|1000,00|1000,00|1|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB420(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|B420|1000|1000|1000|1000|1000|1|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB420("", versao)
        {
            ValorContabil = 1000.0,
            ValorBcISS = 1000.0,
            AliquotaISS = 1000.0,
            TotalValorOpIsentas = 1000.0,
            TotalCombAliqISS = 1000.0,
            CodServico = "1"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|B420|1000,00|1000,00|1000,00|1000,00|1000,00|1|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB420("", versao);
        reg.CodServico.Should().BeNull();
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB420 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("B420");
        reg.Versao.Should().Be(versao);
        reg.ValorContabil.Should().Be(1000.0);
        reg.ValorBcISS.Should().Be(1000.0);
        reg.AliquotaISS.Should().Be(1000.0);
        reg.TotalValorOpIsentas.Should().Be(1000.0);
        reg.TotalCombAliqISS.Should().Be(1000.0);
        reg.CodServico.Should().Be("1");
    }
}
