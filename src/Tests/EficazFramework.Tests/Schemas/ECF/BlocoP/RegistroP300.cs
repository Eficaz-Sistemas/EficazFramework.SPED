using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoP;

public class RegistroP300 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroP300();
        reg.Codigo.Should().Be("P300");
    }

    [TestCase("|P300|1|Cálculo IRPJ Presumido|4800,00|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroP300(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|P300|1|Cálculo IRPJ Presumido|4800,00|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroP300("", versao)
        {
            CodigoReferencial = "1",
            Descricao = "Cálculo IRPJ Presumido",
            Valor = 4800.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|P300|1|Cálculo IRPJ Presumido|4800,00|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroP300("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroP300 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("P300");
        reg.Versao.Should().Be(versao);
    }
}
