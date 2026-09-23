using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoN;

public class RegistroN600 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroN600();
        reg.Codigo.Should().Be("N600");
    }

    [TestCase("|N600|1|Lucro Exploração|50000,00|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroN600(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|N600|1|Lucro Exploração|50000,00|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroN600("", versao)
        {
            CodigoReferencial = "1",
            Descricao = "Lucro Exploração",
            Valor = 50000.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|N600|1|Lucro Exploração|50000,00|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroN600("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroN600 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("N600");
        reg.Versao.Should().Be(versao);
    }
}
