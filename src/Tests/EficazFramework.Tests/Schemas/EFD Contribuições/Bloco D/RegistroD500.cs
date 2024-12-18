using FluentAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes.BlocoD;

public class RegistroD500 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_Contribuicoes.RegistroD500();
        reg.Codigo.Should().Be("D500");
    }


    [TestCase("|D500|0|1|12345678|62|00|001||963258|05102023|06102023|100|||||||||1,65|7,6|", "005")]
    [TestCase("|D500|0|1|12345678|62|00|001||963258|05042025|05042025|100|||||||||1,65|7,6|chavechavechave|", "006")]
    public void Construtor(string linha, string versao = "006")
    { 
        var reg = new EficazFramework.SPED.Schemas.EFD_Contribuicoes.RegistroD500(linha, versao);
        InternalRead(reg, versao);
    }


    [TestCase("|D500|0|1|12345678|62|00|001||963258|05102023|06102023|100|||||||||1,65|7,6|", "006", false)]
    [TestCase("|D500|0|1|12345678|62|00|001||963258|05042025|05042025|100|||||||||1,65|7,6|chavechavechave|", "006", true)]
    public void Escrita(string result, string versao = "006", bool chave = false)
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_Contribuicoes.RegistroD500("", versao)
        {
            CodigoParticipante = "12345678",
            CodigoModeloDocFiscal = "62",
            CodigoSituacaoDocFiscal = "00",
            IndicadorEmitenteDocFiscal = EFD_ICMS_IPI.IndicadorEmitente.Terceiros,
            SerieDocFiscal = "001",
            NumeroDocFiscal = 963258,
            DataEmissaoDocFiscal = new System.DateTime(2023,10,05),
            DataEntrada = new System.DateTime(2023, 10, 06),
            VrTotalDocFiscal = 100d,
            VrPis = 1.65d,
            VrCofins = 7.6d,
            ChaveDocumentoEletronico = "chavechavechave",
        };
        if (chave)
        {
            reg.DataEmissaoDocFiscal = new System.DateTime(2025, 04, 05);
            reg.DataEntrada = new System.DateTime(2025, 04, 05);
        }
        reg.ToString().Should().Be(result);
    }


    [TestCase("|D500|0|1|12345678|62|00|001||963258|05102023|06102023|100|||||||||1,65|7,6|", "006")]
    [TestCase("|D500|0|1|12345678|62|00|001||963258|05042025|05042025|100|||||||||1,65|7,6|chavechavechave|", "006")]
    public void Leitura(string linha, string versao = "006")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_Contribuicoes.RegistroD500("", versao);
        reg.CodigoParticipante.Should().Be(null);
        reg.VrTotalDocFiscal.HasValue.Should().Be(false);

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    
    private void InternalRead(EficazFramework.SPED.Schemas.EFD_Contribuicoes.RegistroD500 reg, string versao = "006")
    {
        reg.Codigo.Should().Be("D500");
        reg.Versao.Should().Be(versao);
        reg.CodigoParticipante.Should().Be("12345678");
        reg.CodigoModeloDocFiscal.Should().Be("62");
        reg.CodigoSituacaoDocFiscal.Should().Be("00");
        reg.NumeroDocFiscal.Should().Be(963258);
        reg.SerieDocFiscal.Should().Be("001");
        reg.VrTotalDocFiscal.Should().Be(100d);
        reg.VrPis.Should().Be(1.65d);
        reg.VrCofins.Should().Be(7.6d);

        if ((reg.DataEmissaoDocFiscal ?? DateTime.MinValue) >= new DateTime(2025, 4, 1))
        {
            reg.DataEmissaoDocFiscal.Should().Be(new System.DateTime(2025, 04, 05));
            reg.DataEntrada.Should().Be(new System.DateTime(2025, 04, 05));
            reg.ChaveDocumentoEletronico.Should().Be("chavechavechave");
        }
        else
        {
            reg.DataEmissaoDocFiscal.Should().Be(new System.DateTime(2023, 10, 05));
            reg.DataEntrada.Should().Be(new System.DateTime(2023, 10, 06));
            reg.ChaveDocumentoEletronico.Should().BeNullOrEmpty();
        }
    }
}
