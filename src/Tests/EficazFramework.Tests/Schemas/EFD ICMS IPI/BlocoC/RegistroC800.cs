using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC800 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC800();
        reg.Codigo.Should().Be("C800");
    }

    [TestCase("|C800|59|00|123456|01112022|100|1,65|7,6|12345678000100|900001234|35191100000000000000599000012345100123456789|0|100|0|18|0|0|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC800(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C800|59|00|123456|01112022|100|1,65|7,6|12345678000100|900001234|35191100000000000000599000012345100123456789|0|100|0|18|0|0|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC800("", versao)
        {
            EspecieDocumento = "59",
            SituacaoDocumento = SituacaoDocumento.Regular,
            Numero = 123456,
            DataEmissao = new System.DateTime(2022, 11, 1),
            ValorTotalDocumento = 100.0d,
            ValorPIS = 1.65d,
            ValorCofins = 7.6d,
            CNPJ_CPF = "12345678000100",
            NumeroSerieSAT = 900001234,
            ChaveCFe = "35191100000000000000599000012345100123456789",
            ValorDesconto = 0.0d,
            ValorTotalMercadorias = 100.0d,
            ValorOutrasDespesas = 0.0d,
            ValorICMS = 18.0d,
            ValorPISST = 0.0d,
            ValorCofinsST = 0.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C800|59|00|123456|01112022|100|1,65|7,6|12345678000100|900001234|35191100000000000000599000012345100123456789|0|100|0|18|0|0|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC800("", versao);
        reg.EspecieDocumento.Should().BeNull();
        reg.ValorTotalDocumento.HasValue.Should().BeFalse();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC800 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C800");
        reg.Versao.Should().Be(versao);
        reg.EspecieDocumento.Should().Be("59");
        reg.SituacaoDocumento.Should().Be(SituacaoDocumento.Regular);
        reg.Numero.Should().Be(123456);
        reg.DataEmissao.Should().Be(new System.DateTime(2022, 11, 1));
        reg.ValorTotalDocumento.Should().Be(100.0d);
        reg.ValorPIS.Should().Be(1.65d);
        reg.ValorCofins.Should().Be(7.6d);
        reg.CNPJ_CPF.Should().Be("12345678000100");
        reg.NumeroSerieSAT.Should().Be(900001234);
        reg.ChaveCFe.Should().Be("35191100000000000000599000012345100123456789");
    }
}
