using System;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoE;

public class RegistroE311 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE311();
        reg.Codigo.Should().Be("E311");
    }

    [TestCase("|E311|RS090001|Ajuste Difal|150,5|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE311(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|E311|RS090001|Ajuste Difal|150,5|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE311("", versao)
        {
            CodigoAjuste = "RS090001",
            DescricaoComplementar = "Ajuste Difal",
            ValorAjuste = 150.5d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|E311|RS090001|Ajuste Difal|150,5|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE311("", versao);
        reg.CodigoAjuste.Should().BeNull();
        reg.DescricaoComplementar.Should().BeNull();
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE311 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("E311");
        reg.Versao.Should().Be(versao);
        reg.CodigoAjuste.Should().Be("RS090001");
        reg.DescricaoComplementar.Should().Be("Ajuste Difal");
        reg.ValorAjuste.Should().Be(150.5d);
    }
}
