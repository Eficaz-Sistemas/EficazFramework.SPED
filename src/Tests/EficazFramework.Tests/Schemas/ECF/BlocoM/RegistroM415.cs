using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoM;

public class RegistroM415 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroM415();
        reg.Codigo.Should().Be("M415");
    }

    [TestCase("|M415|1|PROC123|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroM415(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|M415|1|PROC123|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroM415("", versao)
        {
            IndicadorTipoProcesso = TipoProcessoLancto.Judicial,
            NumeroLancto = "PROC123"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|M415|1|PROC123|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroM415("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroM415 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("M415");
        reg.Versao.Should().Be(versao);
    }
}
