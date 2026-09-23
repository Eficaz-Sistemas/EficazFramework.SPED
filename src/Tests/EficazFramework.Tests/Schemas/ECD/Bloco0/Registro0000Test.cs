using System;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECD.Bloco0;

public class Registro0000Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new Registro0000();
        reg.Codigo.Should().Be("0000");
    }

    [TestCase("|0000|LECD|01012023|31122023|EMPRESA TESTE|12345678000199|MG|123456|3106200|987654|0|1|1|0|HASH|0|0|SCP|S|N|0|0|1|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new Registro0000(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|0000|LECD|01012023|31122023|EMPRESA TESTE|12345678000199|MG|123456|3106200|987654|0|1|1|0|HASH|0|0|SCP|S|N|0|0|1|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new Registro0000("", versao)
        {
            DataInicial = new DateTime(2023, 1, 1),
            DataFinal = new DateTime(2023, 12, 31),
            NomeEmpresarialPJ = "EMPRESA TESTE",
            CNPJ = "12345678000199",
            UF = "MG",
            IEPj = "123456",
            CodMunicipio = "3106200",
            InscMunicipal = "987654",
            IndicadorSitEspecial = "0",
            IndicadorSitInicioPeriodo = "1",
            IndicadorExistNire = IndicadorExistNire.EmpresaPossuiRegistroJunta,
            IndicadorFinalidadeEscrit = IndicadorFinalidadeEscrit.Original,
            CodigoHash = "HASH",
            IndicadorGrandePorte = IndicadorGrandePorte.EmpresaNaoSujeitaAuditoria,
            IndicadorTipoECD = IndicadorTipoECD.ECDempresaNaoParticipanteSCP,
            IdentificacaoSCP = "SCP",
            IdentificacaoMoedaFuncional = true,
            EscritContConsolidades = false,
            IndicadorCentralizada = true,
            IndicadorMudancaPlanoContas = false,
            CodigoPlanoContasReferencial = 1
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|0000|LECD|01012023|31122023|EMPRESA TESTE|12345678000199|MG|123456|3106200|987654|0|1|1|0|HASH|0|0|SCP|S|N|0|0|1|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new Registro0000(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(Registro0000 reg, string versao)
    {
        reg.DataInicial.Should().Be(new DateTime(2023, 1, 1));
        reg.DataFinal.Should().Be(new DateTime(2023, 12, 31));
        reg.NomeEmpresarialPJ.Should().Be("EMPRESA TESTE");
        reg.CNPJ.Should().Be("12345678000199");
        reg.UF.Should().Be("MG");
        reg.IEPj.Should().Be("123456");
        reg.CodMunicipio.Should().Be("3106200");
        reg.InscMunicipal.Should().Be("987654");
        reg.IndicadorSitEspecial.Should().Be("0");
        reg.IndicadorSitInicioPeriodo.Should().Be("1");
        reg.IndicadorExistNire.Should().Be(IndicadorExistNire.EmpresaPossuiRegistroJunta);
        reg.IndicadorFinalidadeEscrit.Should().Be(IndicadorFinalidadeEscrit.Original);
        reg.CodigoHash.Should().Be("HASH");
        reg.IndicadorGrandePorte.Should().Be(IndicadorGrandePorte.EmpresaNaoSujeitaAuditoria);
        reg.IndicadorTipoECD.Should().Be(IndicadorTipoECD.ECDempresaNaoParticipanteSCP);
        reg.IdentificacaoSCP.Should().Be("SCP");
        reg.IdentificacaoMoedaFuncional.Should().BeTrue();
        reg.EscritContConsolidades.Should().BeFalse();
        reg.IndicadorCentralizada.Should().BeTrue();
        reg.IndicadorMudancaPlanoContas.Should().BeFalse();
        reg.CodigoPlanoContasReferencial.Should().Be(1);
    }
}
