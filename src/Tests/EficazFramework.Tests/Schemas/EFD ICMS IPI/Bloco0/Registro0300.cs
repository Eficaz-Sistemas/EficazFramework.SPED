using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Bloco0;

public class Registro0300 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0300();
        reg.Codigo.Should().Be("0300");
    }

    [TestCase("|0300|BEM001|0|Máquina Impressora|BEM001|1.1.2.01|60|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0300(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|0300|BEM001|0|Máquina Impressora|BEM001|1.1.2.01|60|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0300("", versao)
        {
            CodigoProduto = "BEM001",
            IdentificacaoTipo = TipoMercadoriaImobilizado.Bem,
            Descricao = "Máquina Impressora",
            CodigoBemPrincipal = "BEM001",
            CodigoContaContabil = "1.1.2.01",
            NumeroParcelas = 60
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|0300|BEM001|0|Máquina Impressora|BEM001|1.1.2.01|60|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0300("", versao);
        reg.CodigoProduto.Should().Be(null);

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0300 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("0300");
        reg.Versao.Should().Be(versao);
        reg.CodigoProduto.Should().Be("BEM001");
        reg.Descricao.Should().Be("Máquina Impressora");
    }
}
