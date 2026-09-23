using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC110 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC110();
        reg.Codigo.Should().Be("C110");
    }

    [TestCase("|C110|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC110(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C110|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC110("", versao)
        {
            Cod_Inf = "INF001",
            TXT_Complementar = "Texto observacao"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C110|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC110("", versao);
        reg.Cod_Inf.Should().BeNull();
        reg.TXT_Complementar.Should().BeNull();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC110 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C110");
        reg.Versao.Should().Be(versao);
    }
}
