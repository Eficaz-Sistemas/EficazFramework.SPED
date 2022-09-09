using FluentAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.LCDPR.Bloco0;

public class Registro0010 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.LCDPR.Registro0010();
        reg.Codigo.Should().Be("0010");
    }


    [TestCase("0010|1", "0013", FormaApuracao.LivroCaixa)]
    [TestCase("0010|2", "0013", FormaApuracao.ApLucroArt5Lei8023_90)]
    public void Construtor(string linha, string versao = "0013", FormaApuracao formaApuracao = FormaApuracao.LivroCaixa)
    {
        var reg = new EficazFramework.SPED.Schemas.LCDPR.Registro0010(linha, versao);
        InternalRead(reg, versao, formaApuracao);
    }


    [TestCase("0010|2")]
    public void Escrita(string result, string versao = "0013")
    {
        var reg = new EficazFramework.SPED.Schemas.LCDPR.Registro0010("", versao)
        {
            FormaApuracao = FormaApuracao.ApLucroArt5Lei8023_90
        };
        reg.ToString().Should().Be(result);

    }


    [TestCase("0010|1", "0013", FormaApuracao.LivroCaixa)]
    [TestCase("0010|2", "0013", FormaApuracao.ApLucroArt5Lei8023_90)]
    public void Leitura(string linha, string versao = "0013", FormaApuracao formaApuracao = FormaApuracao.LivroCaixa)
    {
        var reg = new EficazFramework.SPED.Schemas.LCDPR.Registro0010("", versao);
        reg.FormaApuracao = FormaApuracao.LivroCaixa;

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao, formaApuracao);
    }


    private void InternalRead(EficazFramework.SPED.Schemas.LCDPR.Registro0010 reg, string versao = "0013", FormaApuracao formaApuracao = FormaApuracao.LivroCaixa)
    {
        reg.Codigo.Should().Be("0010");
        reg.Versao.Should().Be(versao);
        reg.FormaApuracao.Should().Be(formaApuracao);
    }

}
