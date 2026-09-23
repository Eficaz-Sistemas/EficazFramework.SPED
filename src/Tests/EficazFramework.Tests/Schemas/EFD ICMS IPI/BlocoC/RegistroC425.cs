using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC425 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC425();
        reg.Codigo.Should().Be("C425");
    }

    [TestCase("|C425|PROD01|10|UN|100|1,65|7,6|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC425(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C425|PROD01|10|UN|100|1,65|7,6|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC425("", versao)
        {
            Produto = "PROD01",
            Quantidade = 10.0d,
            Unidade = "UN",
            ValorItem = 100.0d,
            PIS = 1.65d,
            COFINS = 7.6d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C425|PROD01|10|UN|100|1,65|7,6|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC425("", versao);
        reg.Produto.Should().BeNull();
        reg.ValorItem.HasValue.Should().BeFalse();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC425 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C425");
        reg.Versao.Should().Be(versao);
        reg.Produto.Should().Be("PROD01");
        reg.Quantidade.Should().Be(10.0d);
        reg.Unidade.Should().Be("UN");
        reg.ValorItem.Should().Be(100.0d);
        reg.PIS.Should().Be(1.65d);
        reg.COFINS.Should().Be(7.6d);
    }
}
