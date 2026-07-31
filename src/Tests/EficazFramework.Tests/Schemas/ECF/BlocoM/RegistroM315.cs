using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoM;

public class RegistroM315 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroM315();
        reg.Codigo.Should().Be("M315");
    }

    [TestCase("|M315|1|PROC123|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroM315(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|M315|1|PROC123|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroM315("", versao)
        {
            IndicadorTipoProcesso = TipoProcessoLancto.Judicial,
            NumeroLancto = "PROC123"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|M315|1|PROC123|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroM315("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroM315 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("M315");
        reg.Versao.Should().Be(versao);
    }
}
