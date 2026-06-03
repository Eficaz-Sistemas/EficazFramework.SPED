using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Bloco0;

public class Registro0205 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0205();
        reg.Codigo.Should().Be("0205");
    }

    [TestCase("|0205|Produto Anterior|01012021|30062021|001|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0205(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|0205|Produto Anterior|01012021|30062021|001|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0205("", versao)
        {
            DescrAnteriorItem = "Produto Anterior",
            DataInicialUtilizacaoItem = new System.DateTime(2021, 1, 1),
            DataFinalUtilizacaoItem = new System.DateTime(2021, 6, 30),
            CodAnteriorItem = "001"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|0205|Produto Anterior|01012021|30062021|001|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0205("", versao);
        reg.DescrAnteriorItem.Should().Be(null);

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0205 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("0205");
        reg.Versao.Should().Be(versao);
        reg.DescrAnteriorItem.Should().Be("Produto Anterior");
        reg.CodAnteriorItem.Should().Be("001");
    }
}
