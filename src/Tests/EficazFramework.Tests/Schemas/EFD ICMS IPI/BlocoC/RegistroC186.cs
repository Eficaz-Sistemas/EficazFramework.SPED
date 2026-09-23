using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC186 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC186();
        reg.Codigo.Should().Be("C186");
    }

    [TestCase("|C186|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC186(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C186|1|PROD01|000|1102|MOT01|10|UN||||||||||||", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC186("", versao)
        {
            NumeroItem = 1,
            CodigoProduto = "PROD01",
            Origem = NFe.OrigemMercadoria.Nacional,
            CST_ICMS = NFe.CST_ICMS.CST_00,
            CFOP = "1102",
            CodMotivoRestituicao = "MOT01",
            QuantidadeItem = 10.0d,
            Unidade = "UN"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C186|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC186("", versao);
        reg.CodigoProduto.Should().BeNull();
        reg.NumeroItem.HasValue.Should().BeFalse();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC186 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C186");
        reg.Versao.Should().Be(versao);
    }
}
