using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC116 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC116();
        reg.Codigo.Should().Be("C116");
    }

    [TestCase("|C116|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC116(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C116|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC116("", versao)
        {
            Cod_Modelo = "59",
            Num_Serie_SAT = "900001234",
            Chave_Cupom_Eletronico = "35191100000000000000599000012345100123456789",
            Num_CFE = "000123",
            DataDoc = new System.DateTime(2022, 11, 1)
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C116|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC116("", versao);
        reg.Cod_Modelo.Should().BeNull();
        reg.Chave_Cupom_Eletronico.Should().BeNull();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC116 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C116");
        reg.Versao.Should().Be(versao);
    }
}
