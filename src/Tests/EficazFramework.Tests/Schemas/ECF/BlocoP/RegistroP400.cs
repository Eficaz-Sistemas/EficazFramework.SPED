using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoP;

public class RegistroP400 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroP400();
        reg.Codigo.Should().Be("P400");
    }

    [TestCase("|P400|1|Base CSLL Lucro Presumido|32000,00|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroP400(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|P400|1|Base CSLL Lucro Presumido|32000,00|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroP400("", versao)
        {
            CodigoReferencial = "1",
            Descricao = "Base CSLL Lucro Presumido",
            Valor = 32000.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|P400|1|Base CSLL Lucro Presumido|32000,00|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroP400("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroP400 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("P400");
        reg.Versao.Should().Be(versao);
    }
}
