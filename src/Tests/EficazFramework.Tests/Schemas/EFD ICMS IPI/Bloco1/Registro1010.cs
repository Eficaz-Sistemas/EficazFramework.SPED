using System;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Bloco1;

public class Registro1010 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1010();
        reg.Codigo.Should().Be("1010");
    }

    [TestCase("|1010|N|N|N|N|N|N|N|N|N|N|N|N|N|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1010(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|1010|N|N|N|N|N|N|N|N|N|N|N|N|N|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1010("", versao)
        {
            AverbacaoExportacao = false,
            CreditoICMSControladoSefaz = false,
            ComCombustiveisPeriodo = false,
            UsinaAcucarAlcoolPeriodo = false,
            ValoresUF = false,
            DistrEnergiaOutraUF = false,
            VendasCartao = false,
            EmissaoDocFiscalPapel = false,
            TransAereo = false,
            GIAF1 = false,
            GIAF3 = false,
            GIAF4 = false,
            RessarcimentoOuComplementoICMS = false
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|1010|N|N|N|N|N|N|N|N|N|N|N|N|N|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1010("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1010 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("1010");
        reg.Versao.Should().Be(versao);
        reg.AverbacaoExportacao.Should().Be(false);
        reg.CreditoICMSControladoSefaz.Should().Be(false);
        reg.ComCombustiveisPeriodo.Should().Be(false);
        reg.UsinaAcucarAlcoolPeriodo.Should().Be(false);
        reg.ValoresUF.Should().Be(false);
        reg.DistrEnergiaOutraUF.Should().Be(false);
        reg.VendasCartao.Should().Be(false);
        reg.EmissaoDocFiscalPapel.Should().Be(false);
        reg.TransAereo.Should().Be(false);
        reg.GIAF1.Should().Be(false);
        reg.GIAF3.Should().Be(false);
        reg.GIAF4.Should().Be(false);
        reg.RessarcimentoOuComplementoICMS.Should().Be(false);
    }
}
