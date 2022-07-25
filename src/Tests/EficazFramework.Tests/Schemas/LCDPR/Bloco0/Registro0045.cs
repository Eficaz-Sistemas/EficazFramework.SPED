using FluentAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.LCDPR.Bloco0;

public class Registro0045 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.LCDPR.Registro0045();
        reg.Codigo.Should().Be("0045");
    }

    
    [TestCase("0045|2|3|12345678912|JOÃO DE SOUSA|00520")]
    public void Construtor(string linha, string versao = "0013")
    {
        var reg = new EficazFramework.SPED.Schemas.LCDPR.Registro0045(linha, versao);
        InternalRead(reg, versao);
    }


    [TestCase("0045|2|3|12345678912|JOÃO DE SOUSA|00520")]
    public void Escrita(string result, string versao = "0013")
    {
        var reg = new EficazFramework.SPED.Schemas.LCDPR.Registro0045("", versao)
        {
            Imovel = 2,
            TipoContratante = TipoExploracaoTerceiro.Parceiro,
            CPF = "12345678912",
            Nome = "JOÃO DE SOUSA",
            Percentual = 5.2d,
        };
        reg.ToString().Should().Be(result);
    }


    [TestCase("0045|2|3|12345678912|JOÃO DE SOUSA|00520")]
    public void Leitura(string linha, string versao = "0013")
    {
        var reg = new EficazFramework.SPED.Schemas.LCDPR.Registro0045("", versao);
        reg.Imovel.Should().Be(null);
        reg.CPF.Should().Be(null);
        reg.Nome.Should().Be(null);

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }


    private void InternalRead(EficazFramework.SPED.Schemas.LCDPR.Registro0045 reg, string versao = "0013")
    {
        reg.Codigo.Should().Be("0045");
        reg.Versao.Should().Be(versao);
        reg.Imovel.Should().Be(2);
        reg.TipoContratante.Should().Be(TipoExploracaoTerceiro.Parceiro);
        reg.CPF.Should().Be("12345678912");
        reg.Nome.Should().Be("JOÃO DE SOUSA");
        reg.Percentual.Should().Be(5.2d);
    }

}
