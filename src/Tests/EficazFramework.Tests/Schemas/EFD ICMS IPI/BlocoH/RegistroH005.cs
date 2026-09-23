using AwesomeAssertions;
using NUnit.Framework;
using System;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoH;

public class RegistroH005 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroH005();
        reg.Codigo.Should().Be("H005");
    }

    [TestCase("|H005|01112022|1000|01|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroH005(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|H005|01112022|10|01|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroH005("", versao)
        {
            DataInventario = new DateTime(2022, 11, 1),
            ValorEstoque = 10.0,
            Motivo = MotivoInventario.FinalPeriodo
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|H005|01112022|1000|01|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroH005("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroH005 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("H005");
        reg.Versao.Should().Be(versao);
        reg.DataInventario.Should().Be(new DateTime(2022, 11, 1));
        reg.ValorEstoque.Should().Be(10.0);
        reg.Motivo.Should().Be(MotivoInventario.FinalPeriodo);
    }
}
