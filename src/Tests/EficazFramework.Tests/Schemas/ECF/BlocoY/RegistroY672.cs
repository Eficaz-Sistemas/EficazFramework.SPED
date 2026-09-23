using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoY;

public class RegistroY672 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroY672();
        reg.Codigo.Should().Be("Y672");
    }

    [TestCase("|Y672|100000,00|100000,00|20000,00|25000,00|5000,00|8000,00|0,00|0,00|10000,00|12000,00|8000,00|9000,00|30000,00|5000,00|0,00|145000,00|0,00|0,0000|1|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroY672(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|Y672|100000,00|100000,00|20000,00|25000,00|5000,00|8000,00|0,00|0,00|10000,00|12000,00|8000,00|9000,00|30000,00|5000,00|0,00|145000,00|0,00|0,0000|1|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroY672("", versao)
        {
            CapitalSocial_Anterior = 100000.0d,
            CapitalSocial = 100000.0d,
            Estoque_Anterior = 20000.0d,
            Estoque = 25000.0d,
            CaixaBancos_Anterior = 5000.0d,
            CaixaBancos = 8000.0d,
            AplicacoesFinanceiras_Anterior = 0.0d,
            AplicacoesFinanceiras = 0.0d,
            ContasReceber_Anterior = 10000.0d,
            ContasReceber = 12000.0d,
            ContasPagar_Anterior = 8000.0d,
            ContasPagar = 9000.0d,
            CompraMercadorias = 30000.0d,
            CompraAtivo = 5000.0d,
            ReceitasNaoTributaveisOuExclusivFonte = 0.0d,
            TotalAtivo = 145000.0d,
            ValorFolhaPagtoAliqReduzica = 0.0d,
            AliquotaReduzidaFolhaPagto = 0.0d,
            AvaliacaoEstoque = MetodoAvEstoque.CustoMedioPonderado
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|Y672|100000,00|100000,00|20000,00|25000,00|5000,00|8000,00|0,00|0,00|10000,00|12000,00|8000,00|9000,00|30000,00|5000,00|0,00|145000,00|0,00|0,0000|1|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroY672("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroY672 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("Y672");
        reg.Versao.Should().Be(versao);
    }
}
