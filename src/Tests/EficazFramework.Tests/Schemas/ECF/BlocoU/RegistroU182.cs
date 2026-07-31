using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoU;

public class RegistroU182 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroU182();
        reg.Codigo.Should().Be("U182");
    }

    [TestCase("|U182|1|Cálculo CSLL Imunes Isentas|0,00|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroU182(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|U182|1|Cálculo CSLL Imunes Isentas|0,00|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroU182("", versao)
        {
            CodigoReferencial = "1",
            Descricao = "Cálculo CSLL Imunes Isentas",
            Valor = 0.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|U182|1|Cálculo CSLL Imunes Isentas|0,00|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroU182("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroU182 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("U182");
        reg.Versao.Should().Be(versao);
    }
}
