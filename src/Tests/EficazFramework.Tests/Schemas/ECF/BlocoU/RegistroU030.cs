using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoU;

public class RegistroU030 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroU030();
        reg.Codigo.Should().Be("U030");
    }

    [TestCase("|U030|01012022|31032022|T01|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroU030(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|U030|01012022|31032022|T01|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroU030("", versao)
        {
            DataInicial = new System.DateTime(2022, 1, 1),
            DataFinal = new System.DateTime(2022, 3, 31),
            Periodo = "T01"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|U030|01012022|31032022|T01|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroU030("", versao);
        reg.Periodo.Should().BeNull();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroU030 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("U030");
        reg.Versao.Should().Be(versao);
        reg.DataInicial.Should().Be(new System.DateTime(2022, 1, 1));
        reg.DataFinal.Should().Be(new System.DateTime(2022, 3, 31));
        reg.Periodo.Should().Be("T01");
    }
}
