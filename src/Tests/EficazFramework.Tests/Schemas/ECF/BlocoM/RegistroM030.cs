using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoM;

public class RegistroM030 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroM030();
        reg.Codigo.Should().Be("M030");
    }

    [TestCase("|M030|01012022|31122022|A00|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroM030(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|M030|01012022|31122022|A00|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroM030("", versao)
        {
            DataInicial = new System.DateTime(2022, 1, 1),
            DataFinal = new System.DateTime(2022, 12, 31),
            Periodo = "A00"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|M030|01012022|31122022|A00|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroM030("", versao);
        reg.Periodo.Should().BeNull();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroM030 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("M030");
        reg.Versao.Should().Be(versao);
        reg.DataInicial.Should().Be(new System.DateTime(2022, 1, 1));
        reg.DataFinal.Should().Be(new System.DateTime(2022, 12, 31));
        reg.Periodo.Should().Be("A00");
    }
}
