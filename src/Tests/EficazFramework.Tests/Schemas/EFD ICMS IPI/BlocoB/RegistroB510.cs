using AwesomeAssertions;
using NUnit.Framework;
using System;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoB;

public class RegistroB510 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB510();
        reg.Codigo.Should().Be("B510");
    }

    [TestCase("|B510|0|0|0|1|1|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB510(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|B510|0|0|0|1|1|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB510("", versao)
        {
            IndicadorHabilitacao = IndicadorHabilitacao.ProfissionalHabilitado,
            IndicadorEscolaridade = IndicadorEscolaridade.NivelSuperior,
            IndicadorParticipacaoSocietaria = IndicadorParticipacaoSocietaria.Socio,
            NumeroCPFProfissional = "1",
            NomeProfissional = "1"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|B510|0|0|0|1|1|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB510("", versao);
        reg.NumeroCPFProfissional.Should().BeNull();
        reg.NomeProfissional.Should().BeNull();
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB510 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("B510");
        reg.Versao.Should().Be(versao);
        reg.IndicadorHabilitacao.Should().Be(IndicadorHabilitacao.ProfissionalHabilitado);
        reg.IndicadorEscolaridade.Should().Be(IndicadorEscolaridade.NivelSuperior);
        reg.IndicadorParticipacaoSocietaria.Should().Be(IndicadorParticipacaoSocietaria.Socio);
        reg.NumeroCPFProfissional.Should().Be("1");
        reg.NomeProfissional.Should().Be("1");
    }
}
