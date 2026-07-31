using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC113 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC113();
        reg.Codigo.Should().Be("C113");
    }

    [TestCase("|C113|0|0|PART01|55|1|0|12345|01112022|35191100000000000000550010000123451001234567|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC113(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C113|0|0|PART01|55|1|0|12345|01112022|35191100000000000000550010000123451001234567|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC113("", versao)
        {
            Operacao = IndicadorOperacao.Entrada,
            Emissao = IndicadorEmitente.Propria,
            CodigoParticipante = "PART01",
            EspecieDocumento = "55",
            Serie = "1",
            SubSerie = 0,
            Numero = 12345,
            Data = new System.DateTime(2022, 11, 1),
            ChaveDoce = "35191100000000000000550010000123451001234567"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C113|0|0|PART01|55|1|0|12345|01112022|35191100000000000000550010000123451001234567|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC113("", versao);
        reg.CodigoParticipante.Should().BeNull();
        reg.Numero.HasValue.Should().BeFalse();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC113 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C113");
        reg.Versao.Should().Be(versao);
        reg.Operacao.Should().Be(IndicadorOperacao.Entrada);
        reg.Emissao.Should().Be(IndicadorEmitente.Propria);
        reg.CodigoParticipante.Should().Be("PART01");
        reg.EspecieDocumento.Should().Be("55");
        reg.Serie.Should().Be("1");
        reg.SubSerie.Should().Be(0);
        reg.Numero.Should().Be(12345);
        reg.Data.Should().Be(new System.DateTime(2022, 11, 1));
        reg.ChaveDoce.Should().Be("35191100000000000000550010000123451001234567");
    }
}
