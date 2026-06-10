using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Bloco0;

public class Registro0600 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0600();
        reg.Codigo.Should().Be("0600");
    }

    [TestCase("|0600|01012022|CC001|Centro Administrativo|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0600(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|0600|01012022|CC001|Centro Administrativo|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0600("", versao)
        {
            DataAlteracao = new System.DateTime(2022, 1, 1),
            CodigoCC = "CC001",
            NomeCC = "Centro Administrativo"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|0600|01012022|CC001|Centro Administrativo|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0600("", versao);
        reg.DataAlteracao.Should().Be(null);

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0600 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("0600");
        reg.Versao.Should().Be(versao);
        reg.DataAlteracao.Should().Be(new System.DateTime(2022, 1, 1));
        reg.CodigoCC.Should().Be("CC001");
        reg.NomeCC.Should().Be("Centro Administrativo");
    }
}
