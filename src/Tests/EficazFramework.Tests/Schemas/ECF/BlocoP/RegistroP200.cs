using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoP;

public class RegistroP200 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroP200();
        reg.Codigo.Should().Be("P200");
    }

    [TestCase("|P200|1|Base IRPJ Lucro Presumido|32000,00|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroP200(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|P200|1|Base IRPJ Lucro Presumido|32000,00|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroP200("", versao)
        {
            CodigoReferencial = "1",
            Descricao = "Base IRPJ Lucro Presumido",
            Valor = 32000.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|P200|1|Base IRPJ Lucro Presumido|32000,00|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroP200("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroP200 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("P200");
        reg.Versao.Should().Be(versao);
    }
}
