using AwesomeAssertions;
using NUnit.Framework;
using System;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoB;

public class RegistroB440 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB440();
        reg.Codigo.Should().Be("B440");
    }

    [TestCase("|B440|0|1|1000,00|1000,00|1000,00|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB440(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|B440|0|1|1000|1000|1000|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB440("", versao)
        {
            IndicadorOperacaoServicos = IndicadorOperacaoServicos.Aquisicao,
            CodParticipante = "1",
            VrContabilPrestacoesAquisicoes = 1000.0,
            VrBCISSPrestacoesAquisicoes = 1000.0,
            VrISSRetido = 1000.0
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|B440|0|1|1000,00|1000,00|1000,00|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB440("", versao);
        reg.CodParticipante.Should().BeNull();
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB440 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("B440");
        reg.Versao.Should().Be(versao);
        reg.IndicadorOperacaoServicos.Should().Be(IndicadorOperacaoServicos.Aquisicao);
        reg.CodParticipante.Should().Be("1");
        reg.VrContabilPrestacoesAquisicoes.Should().Be(1000.0);
        reg.VrBCISSPrestacoesAquisicoes.Should().Be(1000.0);
        reg.VrISSRetido.Should().Be(1000.0);
    }
}
