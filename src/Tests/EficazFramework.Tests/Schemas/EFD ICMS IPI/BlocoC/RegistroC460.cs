using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC460 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC460();
        reg.Codigo.Should().Be("C460");
    }

    [TestCase("|C460|2D|00|12345|01112022|100|1,65|7,6|12345678000100|Cliente Consumidor|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC460(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C460|2D|00|12345|01112022|100|1,65|7,6|12345678000100|Cliente Consumidor|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC460("", versao)
        {
            CodigoModelo = "2D",
            Situacao = SituacaoDocumento.Regular,
            Numero = 12345,
            Data = new System.DateTime(2022, 11, 1),
            ValorTotal = 100.0d,
            ValorPIS = 1.65d,
            ValorCofins = 7.6d,
            CNPJ_CPF = "12345678000100",
            NomeAdquirente = "Cliente Consumidor"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C460|2D|00|12345|01112022|100|1,65|7,6|12345678000100|Cliente Consumidor|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC460("", versao);
        reg.CodigoModelo.Should().BeNull();
        reg.ValorTotal.HasValue.Should().BeFalse();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC460 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C460");
        reg.Versao.Should().Be(versao);
        reg.CodigoModelo.Should().Be("2D");
        reg.Situacao.Should().Be(SituacaoDocumento.Regular);
        reg.Numero.Should().Be(12345);
        reg.Data.Should().Be(new System.DateTime(2022, 11, 1));
        reg.ValorTotal.Should().Be(100.0d);
        reg.ValorPIS.Should().Be(1.65d);
        reg.ValorCofins.Should().Be(7.6d);
        reg.CNPJ_CPF.Should().Be("12345678000100");
        reg.NomeAdquirente.Should().Be("Cliente Consumidor");
    }
}
