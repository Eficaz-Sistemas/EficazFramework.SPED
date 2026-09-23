using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoY;

public class RegistroY600 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroY600();
        reg.Codigo.Should().Be("Y600");
    }

    [TestCase("|Y600|01012022||105|PF|12345678901|Sócio Teste|226|50,00|50,00|||10000,00|20000,00|0,00|0,00|1000,00|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroY600(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|Y600|01012022||105|PF|12345678901|Sócio Teste|226|50,00|50,00|||10000,00|20000,00|0,00|0,00|1000,00|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroY600("", versao)
        {
            DataAlteracao = new System.DateTime(2022, 1, 1),
            Pais = "105",
            IndicadorQualificacao = "PF",
            CNPJ_CPF = "12345678901",
            Nome = "Sócio Teste",
            Qualificacao = "226",
            PercentualCapitalTotal = 50.0d,
            PercentualCapitalVotante = 50.0d,
            ValorRemuneracao = 10000.0d,
            ValorLucrosDividendos = 20000.0d,
            ValorJurosCapitalProprio = 0.0d,
            ValorDemaisRendimentos = 0.0d,
            ValorIR_Retido = 1000.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|Y600|01012022||105|PF|12345678901|Sócio Teste|226|50,00|50,00|||10000,00|20000,00|0,00|0,00|1000,00|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroY600("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroY600 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("Y600");
        reg.Versao.Should().Be(versao);
    }
}
