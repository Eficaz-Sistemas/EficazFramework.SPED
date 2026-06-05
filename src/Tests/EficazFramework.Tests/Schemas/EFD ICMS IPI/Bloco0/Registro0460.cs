using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Bloco0;

public class Registro0460 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0460();
        reg.Codigo.Should().Be("0460");
    }

    [TestCase("|0460|1|Observação Padrão|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0460(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|0460|1|Observação Padrão|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0460("", versao)
        {
            CodigoObservacao = 1,
            Descricao = "Observação Padrão"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|0460|1|Observação Padrão|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0460("", versao);
        reg.CodigoObservacao.Should().Be(null);

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0460 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("0460");
        reg.Versao.Should().Be(versao);
        reg.CodigoObservacao.Should().Be(1);
        reg.Descricao.Should().Be("Observação Padrão");
    }
}
