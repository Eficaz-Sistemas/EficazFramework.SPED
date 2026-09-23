using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC176 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC176();
        reg.Codigo.Should().Be("C176");
    }

    [TestCase("|C176|55|123456|1|01112022|PART01|10|100|120|||||||||3|1||||||0|123|0|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC176(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C176|55|123456|1|01112022|PART01|10|100|120|||||||||3|1||||||0|123|0|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC176("", versao)
        {
            ModeloDocFiscal = "55",
            NumeroDocFiscal = 123456,
            SerieDocFiscal = "1",
            DataDocFiscal = new System.DateTime(2022, 11, 1),
            CodigoParticipante = "PART01",
            QuantidadeItem = 10.0d,
            ValorUnitarioItem = 100.0d,
            Valor_BC_ST_UnitarioItem = 120.0d,
            ResponsavelRetencao = ResponsavelRetencaoST.ProprioDeclarante,
            MotivoRessarcimento = MotimoRessarcimentoST.VendaOutraUF,
            ModeloDocumentoArrecadacao = ModeloDocumentoArrecadacaoC176.DAE,
            NumeroDocumentoArrecadacao = "123",
            VlrUnitarioResFCP = 0.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C176|55|123456|1|01112022|PART01|10|100|120|||||||||3|1||||||0|123|0|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC176("", versao);
        reg.ModeloDocFiscal.Should().BeNull();
        reg.NumeroDocFiscal.HasValue.Should().BeFalse();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC176 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C176");
        reg.Versao.Should().Be(versao);
        reg.ModeloDocFiscal.Should().Be("55");
        reg.NumeroDocFiscal.Should().Be(123456);
        reg.SerieDocFiscal.Should().Be("1");
        reg.DataDocFiscal.Should().Be(new System.DateTime(2022, 11, 1));
        reg.CodigoParticipante.Should().Be("PART01");
        reg.QuantidadeItem.Should().Be(10.0d);
        reg.ValorUnitarioItem.Should().Be(100.0d);
        reg.Valor_BC_ST_UnitarioItem.Should().Be(120.0d);
    }
}
