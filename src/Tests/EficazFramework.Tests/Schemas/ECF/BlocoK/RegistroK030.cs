using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoK;

public class RegistroK030 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroK030();
        reg.Codigo.Should().Be("K030");
    }

    [TestCase("|K030|01012022|31032022|T01|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroK030(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|K030|01012022|31032022|T01|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroK030("", versao)
        {
            DataInicial = new System.DateTime(2022, 1, 1),
            DataFinal = new System.DateTime(2022, 3, 31),
            Periodo = "T01"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|K030|01012022|31032022|T01|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroK030("", versao);
        reg.Periodo.Should().BeNull();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroK030 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("K030");
        reg.Versao.Should().Be(versao);
        reg.DataInicial.Should().Be(new System.DateTime(2022, 1, 1));
        reg.DataFinal.Should().Be(new System.DateTime(2022, 3, 31));
        reg.Periodo.Should().Be("T01");
    }
}
