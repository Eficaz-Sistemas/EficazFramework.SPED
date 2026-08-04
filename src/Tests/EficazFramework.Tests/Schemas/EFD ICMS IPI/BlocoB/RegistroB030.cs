using AwesomeAssertions;
using NUnit.Framework;
using System;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoB;

public class RegistroB030 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB030();
        reg.Codigo.Should().Be("B030");
    }

    [TestCase("|B030|1|1|1|1|01112022|1|1000,00|1000,00|1000,00|1000,00|1|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB030(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|B030|1|1|1|1|01/11/2022 00:00:00|1|1000|1000|1000|1000|1|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB030("", versao)
        {
            CodigoModeloDocFiscal = "1",
            SerieDocFiscal = "1",
            NumeroDocInicialDia = 1,
            NumeroDocFinalDia = 1,
            DataEmissaoDocFiscal = new DateTime(2022, 11, 1),
            QuantDocCanc = 1,
            ValorContabilTotalDocs = 1000.0,
            ValorAcumOpIsentasNTribISS = 1000.0,
            ValorAcumBCISS = 1000.0,
            ValorISSDestacado = 1000.0,
            CodigoObsLctoFiscal = "1"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|B030|1|1|1|1|01112022|1|1000,00|1000,00|1000,00|1000,00|1|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB030("", versao);
        reg.CodigoModeloDocFiscal.Should().BeNull();
        reg.SerieDocFiscal.Should().BeNull();
        reg.CodigoObsLctoFiscal.Should().BeNull();
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB030 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("B030");
        reg.Versao.Should().Be(versao);
        reg.CodigoModeloDocFiscal.Should().Be("1");
        reg.SerieDocFiscal.Should().Be("1");
        reg.NumeroDocInicialDia.Should().Be(1);
        reg.NumeroDocFinalDia.Should().Be(1);
        reg.DataEmissaoDocFiscal.Should().Be(new DateTime(2022, 11, 1));
        reg.QuantDocCanc.Should().Be(1);
        reg.ValorContabilTotalDocs.Should().Be(1000.0);
        reg.ValorAcumOpIsentasNTribISS.Should().Be(1000.0);
        reg.ValorAcumBCISS.Should().Be(1000.0);
        reg.ValorISSDestacado.Should().Be(1000.0);
        reg.CodigoObsLctoFiscal.Should().Be("1");
    }
}
