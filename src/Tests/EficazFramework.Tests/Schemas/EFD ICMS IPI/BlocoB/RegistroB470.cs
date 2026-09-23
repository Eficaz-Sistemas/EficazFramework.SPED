using AwesomeAssertions;
using NUnit.Framework;
using System;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoB;

public class RegistroB470 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB470();
        reg.Codigo.Should().Be("B470");
    }

    [TestCase("|B470|1000,00|1000,00|1000,00|1000,00|1000,00|1000,00|1000,00|1000,00|1000,00|1000,00|1000,00|1000,00|1000,00|1000,00|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB470(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|B470|1000|1000|1000|1000|1000|1000|1000|1000|1000|1000|1000|1000|1000|1000|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB470("", versao)
        {
            VrTotalPrestacaoServico = 1000.0,
            VrTotalMaterialTerceiros = 1000.0,
            VrTotalMaterialProprio = 1000.0,
            VrTotalSubempreitadas = 1000.0,
            VrTotalOperIsentasNtributaISS = 1000.0,
            VrTotalDedBC = 1000.0,
            VrTotalBCISS = 1000.0,
            VrTotalBCRetencaoISSPrestDeclarante = 1000.0,
            VrTotalISSDestacado = 1000.0,
            VrTotalISSRetidoTomador = 1000.0,
            VrTotalDeducoesISSProprio = 1000.0,
            VrTotalApuradoISSProprioRecolher = 1000.0,
            VrTotalISSsubstitutoRecolher = 1000.0,
            VrISSProprioRecolherSociedUniprofissional = 1000.0
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|B470|1000,00|1000,00|1000,00|1000,00|1000,00|1000,00|1000,00|1000,00|1000,00|1000,00|1000,00|1000,00|1000,00|1000,00|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB470("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB470 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("B470");
        reg.Versao.Should().Be(versao);
        reg.VrTotalPrestacaoServico.Should().Be(1000.0);
        reg.VrTotalMaterialTerceiros.Should().Be(1000.0);
        reg.VrTotalMaterialProprio.Should().Be(1000.0);
        reg.VrTotalSubempreitadas.Should().Be(1000.0);
        reg.VrTotalOperIsentasNtributaISS.Should().Be(1000.0);
        reg.VrTotalDedBC.Should().Be(1000.0);
        reg.VrTotalBCISS.Should().Be(1000.0);
        reg.VrTotalBCRetencaoISSPrestDeclarante.Should().Be(1000.0);
        reg.VrTotalISSDestacado.Should().Be(1000.0);
        reg.VrTotalISSRetidoTomador.Should().Be(1000.0);
        reg.VrTotalDeducoesISSProprio.Should().Be(1000.0);
        reg.VrTotalApuradoISSProprioRecolher.Should().Be(1000.0);
        reg.VrTotalISSsubstitutoRecolher.Should().Be(1000.0);
        reg.VrISSProprioRecolherSociedUniprofissional.Should().Be(1000.0);
    }
}
