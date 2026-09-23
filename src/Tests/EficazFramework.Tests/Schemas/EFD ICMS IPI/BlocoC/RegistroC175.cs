using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC175 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC175();
        reg.Codigo.Should().Be("C175");
    }

    [TestCase("|C175|0|12345678000100|MG|9BWZZZ377VT004251|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC175(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C175|0|12345678000100|MG|9BWZZZ377VT004251|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC175("", versao)
        {
            IndicadorTipoOperacaoVeiculo = IndicadorTipoOperacaoVeiculo.Venda_Concessionaria,
            CNPJ = "12345678000100",
            UFConcessionaria = "MG",
            ChassiVeiculo = "9BWZZZ377VT004251"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C175|0|12345678000100|MG|9BWZZZ377VT004251|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC175("", versao);
        reg.CNPJ.Should().BeNull();
        reg.ChassiVeiculo.Should().BeNull();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC175 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C175");
        reg.Versao.Should().Be(versao);
        reg.IndicadorTipoOperacaoVeiculo.Should().Be(IndicadorTipoOperacaoVeiculo.Venda_Concessionaria);
        reg.CNPJ.Should().Be("12345678000100");
        reg.UFConcessionaria.Should().Be("MG");
        reg.ChassiVeiculo.Should().Be("9BWZZZ377VT004251");
    }
}
