using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Bloco0;

public class Registro0221 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0221();
        reg.Codigo.Should().Be("0221");
    }

    [TestCase("|0221|002|12|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0221(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|0221|002|12|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0221("", versao)
        {
            CodigoItemAtomico = "002",
            QuantidadeContida = 12d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|0221|002|12|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0221("", versao);
        reg.CodigoItemAtomico.Should().Be(null);

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0221 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("0221");
        reg.Versao.Should().Be(versao);
        reg.CodigoItemAtomico.Should().Be("002");
        reg.QuantidadeContida.Should().Be(12d);
    }
}
