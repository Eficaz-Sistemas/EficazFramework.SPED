using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Bloco0;

public class Registro0200 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0200();
        reg.Codigo.Should().Be("0200");
    }

    [TestCase("|0200|001|Produto A|1234567890|00|UN|01|12345678||00|0000|18,00|", "010")]
    [TestCase("|0200|001|Produto A|1234567890|00|UN|01|12345678||00|0000|18,00|0305600|", "011")]
    public void Construtor(string linha, string versao = "011")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0200(linha, versao);
        InternalRead(reg, versao, TipoItem.MateriaPrima);
    }

    [TestCase("|0200|001|Produto A|1234567890|00|UN|00|12345678||00|0000|18,00|", "010", TipoItem.MercadoriaRevenda)]
    [TestCase("|0200|001|Produto A|1234567890|00|UN|04|12345678||00|0000|18,00|0305600|", "011", TipoItem.ProdutoAcabado)]
    public void Escrita(string result, string versao = "011", TipoItem tipoItem = TipoItem.MateriaPrima)
    {
        var cest = result.EndsWith("0305600|") ? "0305600" : "";
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0200("", versao)
        {
            ID = "001",
            Descricao = "Produto A",
            CodigoBarras = "1234567890",
            IDAnterior = "00",
            UnidadeMedida = "UN",
            TipoItem = tipoItem,
            NCM = "12345678",
            EX_IPI = "",
            Genero = 0,
            ID_Servico = 0,
            AliquotaICMS = 18.00D,
            CEST = cest
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|0200|001|Produto A|1234567890|00|UN|00|12345678||00|0000|18,00|", "010")]
    public void Leitura(string linha, string versao = "011")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0200("", versao);
        reg.ID.Should().Be(null);
        reg.Descricao.Should().Be(null);

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0200 reg, string versao = "011", TipoItem tipoItem = TipoItem.MercadoriaRevenda)
    {
        reg.Codigo.Should().Be("0200");
        reg.Versao.Should().Be(versao);
        reg.ID.Should().Be("001");
        reg.Descricao.Should().NotBeNullOrEmpty();
        reg.TipoItem.Should().Be(tipoItem);
        reg.Descricao.Should().Be("Produto A");
        reg.NCM.Should().Be("12345678");
        reg.UnidadeMedida.Should().Be("UN");
        reg.AliquotaICMS.Should().Be(18.00D);
        reg.EX_IPI.Should().BeNullOrEmpty();
        reg.Genero.Should().Be(0);
    }
}
