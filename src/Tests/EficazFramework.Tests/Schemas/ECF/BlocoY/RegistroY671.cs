using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoY;

public class RegistroY671 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroY671();
        reg.Codigo.Should().Be("Y671");
    }

    [TestCase("|Y671|0,00|0,00|0,00|50000,00|0,00|0,00|0,00|0,00|0,00|0,00|0,0000|1|1|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroY671(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|Y671|0,00|0,00|0,00|50000,00|0,00|0,00|0,00|0,00|0,00|0,00|0,0000|1|1|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroY671("", versao)
        {
            AquisMaquinasInstrEquipNovos = 0.0d,
            DoacaoFundoDirCriancaAdolesc = 0.0d,
            DoacaoIdosos = 0.0d,
            AquisAtivoImobilizado = 50000.0d,
            BaixasAtivoImobilizado = 0.0d,
            ValorInicialBens_Lei_11051_2014 = 0.0d,
            ValorFinalBens_Lei_11051_2014 = 0.0d,
            CreditoCSLLDepreciacaoInicial = 0.0d,
            ValorOpCambioIsentoIOF = 0.0d,
            ValorFolhaPagtoAliqReduzica = 0.0d,
            AliquotaReduzidaFolhaPagto = 0.0d,
            AlteracaoCapitalSocial = false,
            Indicador_BC_CSLL_Negativa_Ativo = false
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|Y671|0,00|0,00|0,00|50000,00|0,00|0,00|0,00|0,00|0,00|0,00|0,0000|1|1|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroY671("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroY671 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("Y671");
        reg.Versao.Should().Be(versao);
    }
}
