using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Bloco0;

public class Registro0175 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0175();
        reg.Codigo.Should().Be("0175");
    }

    [TestCase("|0175|15062022|03|Fornecedor XYZ|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0175(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|0175|15062022|03|Fornecedor XYZ|", "016", CampoAlterado.Nome)]
    public void Escrita(string result, string versao = "016", CampoAlterado campoAlterado = CampoAlterado.Nome)
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0175("", versao)
        {
            DataAlteracao = new System.DateTime(2022, 6, 15),
            CampoAlterado = campoAlterado,
            ConteudoAnterior = "Fornecedor XYZ",
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|0175|15062022|03|Fornecedor XYZ|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0175("", versao);
        reg.DataAlteracao.Should().Be(null);
        reg.ConteudoAnterior.Should().Be(null);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0175 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("0175");
        reg.Versao.Should().Be(versao);
        reg.DataAlteracao.Should().Be(new System.DateTime(2022, 6, 15));
        reg.CampoAlterado.Should().Be(CampoAlterado.Nome);
        reg.ConteudoAnterior.Should().Be("Fornecedor XYZ");
    }
}
