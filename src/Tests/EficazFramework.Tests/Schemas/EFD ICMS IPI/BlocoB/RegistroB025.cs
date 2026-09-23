using AwesomeAssertions;
using NUnit.Framework;
using System;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoB;

public class RegistroB025 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB025();
        reg.Codigo.Should().Be("B025");
    }

    [TestCase("|B025|1000,00|1000,00|1000,00|1000,00|1000,00|1|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB025(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|B025|1000|1000|1000|1000|1000|1|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB025("", versao)
        {
            ValorContabilParcela = 1000.0,
            ValorBcISSParcela = 1000.0,
            AliquotaISS = 1000.0,
            ValorISSParcela = 1000.0,
            ValorOpIsentasNtribISS = 1000.0,
            CodigoServico = "1"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|B025|1000,00|1000,00|1000,00|1000,00|1000,00|1|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB025("", versao);
        reg.CodigoServico.Should().BeNull();
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB025 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("B025");
        reg.Versao.Should().Be(versao);
        reg.ValorContabilParcela.Should().Be(1000.0);
        reg.ValorBcISSParcela.Should().Be(1000.0);
        reg.AliquotaISS.Should().Be(1000.0);
        reg.ValorISSParcela.Should().Be(1000.0);
        reg.ValorOpIsentasNtribISS.Should().Be(1000.0);
        reg.CodigoServico.Should().Be("1");
    }
}
