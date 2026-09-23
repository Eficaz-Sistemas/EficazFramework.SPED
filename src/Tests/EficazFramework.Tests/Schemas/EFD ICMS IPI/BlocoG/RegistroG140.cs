using AwesomeAssertions;
using NUnit.Framework;
using System;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoG;

public class RegistroG140 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroG140();
        reg.Codigo.Should().Be("G140");
    }

    [TestCase("|G140|1|1|1000|1|1000|1000|1000|1000|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroG140(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|G140|1|1|1000|1|1000|1000|1000|1000|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroG140("", versao)
        {
            NumeroItem = 1,
            CodigoItem0200 = "1",
            Quantidade = 1000.0,
            Unidade = "1",
            VlrIcmsOpPropriaEntrada = 1000.0,
            VlrIcmsSTEntrada = 1000.0,
            VlrIcmsFreteEntrada = 1000.0,
            VlrIcmsDifAliquotaEntrada = 1000.0
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|G140|1|1|1000|1|1000|1000|1000|1000|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroG140("", versao);
        reg.CodigoItem0200.Should().BeNull();
        reg.Unidade.Should().BeNull();
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroG140 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("G140");
        reg.Versao.Should().Be(versao);
        reg.NumeroItem.Should().Be(1);
        reg.CodigoItem0200.Should().Be("1");
        reg.Quantidade.Should().Be(1000.0);
        reg.Unidade.Should().Be("1");
        reg.VlrIcmsOpPropriaEntrada.Should().Be(1000.0);
        reg.VlrIcmsSTEntrada.Should().Be(1000.0);
        reg.VlrIcmsFreteEntrada.Should().Be(1000.0);
        reg.VlrIcmsDifAliquotaEntrada.Should().Be(1000.0);
    }
}
