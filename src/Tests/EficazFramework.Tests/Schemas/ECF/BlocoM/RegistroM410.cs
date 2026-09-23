using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoM;

public class RegistroM410 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroM410();
        reg.Codigo.Should().Be("M410");
    }

    [TestCase("|M410|CB001|I|10000,00|DB|CB002|Transf Saldo|N|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroM410(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|M410|CB001|I|10000,00|DB|CB002|Transf Saldo|N|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroM410("", versao)
        {
            CodigoContaParteB = "CB001",
            CodigoTributo = "I",
            Valor = 10000.0d,
            IndicadorRelacao = "DB",
            CodigoContaParteB_Destino = "CB002",
            Historico = "Transf Saldo",
            LanctoExerciciosAnteriores = false
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|M410|CB001|I|10000,00|DB|CB002|Transf Saldo|N|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroM410("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroM410 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("M410");
        reg.Versao.Should().Be(versao);
    }
}
