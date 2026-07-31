using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.Bloco0;

public class Registro0020 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.Registro0020();
        reg.Codigo.Should().Be("0020");
    }

    [TestCase("|0020|1||N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.Registro0020(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|0020|1||N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.Registro0020("", versao)
        {
            FormaTributacao = IndicadorAliquotaCSLL2015.NovePorcento
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|0020|1||N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.Registro0020("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.Registro0020 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("0020");
        reg.Versao.Should().Be(versao);
    }
}
