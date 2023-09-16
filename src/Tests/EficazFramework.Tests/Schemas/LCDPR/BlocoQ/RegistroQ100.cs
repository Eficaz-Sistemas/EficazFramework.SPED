using FluentAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.LCDPR.BlocoQ;

public class RegistroQ100 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.LCDPR.RegistroQ100();
        reg.Codigo.Should().Be("Q100");
    }

    
    [TestCase("Q100|01012021|1|1|123456|1|Pg. ref. aquisição de fertilizantes|12345678900|2||50000|50000|N")]
    public void Construtor(string linha, string versao = "0013")
    {
        var reg = new EficazFramework.SPED.Schemas.LCDPR.RegistroQ100(linha, versao);
        InternalRead(reg, versao);
    }


    [TestCase("Q100|01012021|1|1|123456|1|Pg. ref. aquisição de fertilizantes|12345678900|2||50000|50000|N")]
    public void Escrita(string result, string versao = "0013")
    {
        var reg = new EficazFramework.SPED.Schemas.LCDPR.RegistroQ100("", versao)
        {
            DataMov = new System.DateTime(2021, 1, 1),
            CodImovel = 1,
            CodigoContaBanco = "1",
            NumeroDoc = "123456",
            TipoDocumento = TipoDocumento.NF,
            Historico = "Pg. ref. aquisição de fertilizantes",
            TerceiroID = "12345678900",
            TipoLancamento = TipoLancamento.Despesa,
            ValorSaida = 500d,
            SaldoFinal = 500d,
            SaldoFinal_Natureza = "N"
        };
        reg.ToString().Should().Be(result);

    }


    [TestCase("Q100|01012021|1|1|123456|1|Pg. ref. aquisição de fertilizantes|12345678900|2||50000|50000|N")]
    public void Leitura(string linha, string versao = "0013")
    {
        var reg = new EficazFramework.SPED.Schemas.LCDPR.RegistroQ100("", versao);
        reg.DataMov.Should().Be(null);
        reg.CodImovel.Should().Be(null);
        reg.CodigoContaBanco.Should().Be(null);
        reg.NumeroDoc.Should().Be(null);
        reg.TipoDocumento.Should().Be(TipoDocumento.NF);
        reg.Historico.Should().Be(null);
        reg.TipoLancamento.Should().Be(TipoLancamento.Despesa);
        reg.TerceiroID.Should().Be(null);
        reg.ValorEntrada.Should().Be(null);
        reg.ValorSaida.Should().Be(null);
        reg.SaldoFinal.Should().Be(null);
        reg.SaldoFinal_Natureza.Should().Be(null);

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }


    private void InternalRead(EficazFramework.SPED.Schemas.LCDPR.RegistroQ100 reg, string versao = "0013")
    {
        reg.Codigo.Should().Be("Q100");
        reg.Versao.Should().Be(versao);
        reg.DataMov.Should().Be(new System.DateTime(2021, 1, 1));
        reg.CodImovel.Should().Be(1);
        reg.CodigoContaBanco.Should().Be("1");
        reg.NumeroDoc.Should().Be("123456");
        reg.TipoDocumento.Should().Be(TipoDocumento.NF);
        reg.TipoLancamento.Should().Be(TipoLancamento.Despesa);
        reg.TerceiroID.Should().Be("12345678900");
        reg.ValorEntrada.Should().Be(null);
        reg.ValorSaida.Should().Be(500D);
        reg.SaldoFinal.Should().Be(500D);
        reg.SaldoFinal_Natureza.Should().Be("N");
    }

}
