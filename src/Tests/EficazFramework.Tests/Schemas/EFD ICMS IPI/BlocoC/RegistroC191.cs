using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC191 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC191();
        reg.Codigo.Should().Be("C191");
    }

    [TestCase("|C191|10|20|5|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC191(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C191|10|20|5|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC191("", versao)
        {
            ValorFCP = 10.0d,
            ValorFCP_ST = 20.0d,
            ValorFCP_Ret = 5.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C191|10|20|5|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC191("", versao);
        reg.ValorFCP.HasValue.Should().BeFalse();
        reg.ValorFCP_ST.HasValue.Should().BeFalse();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC191 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C191");
        reg.Versao.Should().Be(versao);
        reg.ValorFCP_ST.Should().Be(20.0d);
        reg.ValorFCP_Ret.Should().Be(5.0d);
    }
}
