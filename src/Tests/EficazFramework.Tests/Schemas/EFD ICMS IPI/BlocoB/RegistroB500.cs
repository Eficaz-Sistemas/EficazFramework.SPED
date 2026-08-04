using AwesomeAssertions;
using NUnit.Framework;
using System;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoB;

public class RegistroB500 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB500();
        reg.Codigo.Should().Be("B500");
    }

    [TestCase("|B500|1000,00|1|1000,00|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB500(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|B500|1000|1|1000|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB500("", versao)
        {
            VrMensalReceitasSocUniprofissional = 1000.0,
            QuantProfissionaisHabilitados = 1,
            VrISSDevido = 1000.0
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|B500|1000,00|1|1000,00|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB500("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB500 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("B500");
        reg.Versao.Should().Be(versao);
        reg.VrMensalReceitasSocUniprofissional.Should().Be(1000.0);
        reg.QuantProfissionaisHabilitados.Should().Be(1);
        reg.VrISSDevido.Should().Be(1000.0);
    }
}
