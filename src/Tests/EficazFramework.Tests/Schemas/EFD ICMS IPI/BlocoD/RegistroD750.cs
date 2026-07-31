using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoD;

public class RegistroD750 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD750();
        reg.Codigo.Should().Be("D750");
    }

    [TestCase("|D750|62|1|01112022|10|0|1000|1000|0|0|0|0|1000|120|16,5|76|0|", "019")]
    public void Construtor(string linha, string versao = "019")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD750(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|D750|62|1|01112022|10|0|1000|1000|0|0|0|0|1000|120|16,5|76|0|", "019")]
    public void Escrita(string result, string versao = "019")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD750("", versao)
        {
            EspecieDocumento = "62",
            Serie = "1",
            DataEmissao = new System.DateTime(2022, 11, 1),
            Quantidade = 10,
            IndicadorPrePago = IndicadorPrePago.PrePago,
            ValorTotalDocumentos = 1000.0d,
            ValorServicos = 1000.0d,
            ValorServicosNT = 0.0d,
            ValorCobradoTerceiros = 0.0d,
            ValorDesconto = 0.0d,
            ValorDespesasAcessorias = 0.0d,
            ValorBaseCalculoICMS = 1000.0d,
            ValorICMS = 120.0d,
            ValorPIS = 16.5d,
            ValorCofins = 76.0d,
            Deducoes = 0.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|D750|62|1|01112022|10|0|1000|1000|0|0|0|0|1000|120|16,5|76|0|", "019")]
    public void Leitura(string linha, string versao = "019")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD750("", versao);
        reg.EspecieDocumento.Should().BeNull();
        reg.ValorTotalDocumentos.HasValue.Should().BeFalse();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD750 reg, string versao = "019")
    {
        reg.Codigo.Should().Be("D750");
        reg.Versao.Should().Be(versao);
        reg.EspecieDocumento.Should().Be("62");
        reg.Serie.Should().Be("1");
        reg.DataEmissao.Should().Be(new System.DateTime(2022, 11, 1));
        reg.Quantidade.Should().Be(10);
        reg.IndicadorPrePago.Should().Be(IndicadorPrePago.PrePago);
        reg.ValorTotalDocumentos.Should().Be(1000.0d);
        reg.ValorServicos.Should().Be(1000.0d);
        reg.ValorServicosNT.Should().Be(0.0d);
        reg.ValorCobradoTerceiros.Should().Be(0.0d);
        reg.ValorDesconto.Should().Be(0.0d);
        reg.ValorDespesasAcessorias.Should().Be(0.0d);
        reg.ValorBaseCalculoICMS.Should().Be(1000.0d);
        reg.ValorICMS.Should().Be(120.0d);
        reg.ValorPIS.Should().Be(16.5d);
        reg.ValorCofins.Should().Be(76.0d);
        reg.Deducoes.Should().Be(0.0d);
    }
}
