using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoJ;

public class RegistroJ050 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroJ050();
        reg.Codigo.Should().Be("J050");
    }

    [TestCase("|J050|01012022|01|A|4|1.01.01.001|1.01.01|Caixa Geral|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroJ050(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|J050|01012022|01|A|4|1.01.01.001|1.01.01|Caixa Geral|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroJ050("", versao)
        {
            DataInclusaoAlteracao = new System.DateTime(2022, 1, 1),
            CodNaturezaContaGrupo = "01",
            IndicadorTipoConta = ECD.IndicadorConta.Analitica,
            NivelContaAnaliticaGrupo = 4,
            CodContaAnaliticaGrupo = "1.01.01.001",
            CodContaSuperior = "1.01.01",
            NomeContaAnaliticaGrupo = "Caixa Geral"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|J050|01012022|01|A|4|1.01.01.001|1.01.01|Caixa Geral|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroJ050("", versao);
        reg.CodNaturezaContaGrupo.Should().BeNull();
        reg.CodContaAnaliticaGrupo.Should().BeNull();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroJ050 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("J050");
        reg.Versao.Should().Be(versao);
        reg.DataInclusaoAlteracao.Should().Be(new System.DateTime(2022, 1, 1));
        reg.CodNaturezaContaGrupo.Should().Be("01");
        reg.IndicadorTipoConta.Should().Be(ECD.IndicadorConta.Analitica);
        reg.NivelContaAnaliticaGrupo.Should().Be((short)4);
        reg.CodContaAnaliticaGrupo.Should().Be("1.01.01.001");
        reg.CodContaSuperior.Should().Be("1.01.01");
        reg.NomeContaAnaliticaGrupo.Should().Be("Caixa Geral");
    }
}
