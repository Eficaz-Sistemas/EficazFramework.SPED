using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC114 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC114();
        reg.Codigo.Should().Be("C114");
    }

    [TestCase("|C114|2D|FAB123456|001|000000123|01112022|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC114(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C114|2D|FAB123456|001|000000123|01112022|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC114("", versao)
        {
            Cod_Modelo = "2D",
            ECF_FAB = "FAB123456",
            ECF_CX = "001",
            Num_Doc = "000000123",
            DataDoc = new System.DateTime(2022, 11, 1)
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C114|2D|FAB123456|001|000000123|01112022|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC114("", versao);
        reg.Cod_Modelo.Should().BeNull();
        reg.ECF_FAB.Should().BeNull();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC114 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C114");
        reg.Versao.Should().Be(versao);
        reg.Cod_Modelo.Should().Be("2D");
        reg.ECF_FAB.Should().Be("FAB123456");
        reg.ECF_CX.Should().Be("001");
        reg.Num_Doc.Should().Be("000000123");
        reg.DataDoc.Should().Be(new System.DateTime(2022, 11, 1));
    }
}
