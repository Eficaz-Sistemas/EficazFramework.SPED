using FluentAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes.BlocoC;

public class RegistroC500 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_Contribuicoes.RegistroC500();
        reg.Codigo.Should().Be("C500");
    }


    [TestCase("|C500|12345678|66|00|001||963258|05102023|06102023|100|||1,65|7,6|", "005")]
    [TestCase("|C500|12345678|66|00|001||963258|05102023|06102023|100|||1,65|7,6|chavechavechave|", "006")]
    public void Construtor(string linha, string versao = "006")
    { 
        var reg = new EficazFramework.SPED.Schemas.EFD_Contribuicoes.RegistroC500(linha, versao);
        InternalRead(reg, versao);
    }


    [TestCase("|C500|12345678|66|00|001||963258|05102023|06102023|100|||1,65|7,6|", "005")]
    [TestCase("|C500|12345678|66|00|001||963258|05102023|06102023|100|||1,65|7,6|chavechavechave|", "006")]
    public void Escrita(string result, string versao = "006")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_Contribuicoes.RegistroC500("", versao)
        {
            CodigoParticipante = "12345678",
            CodigoModeloDocFiscal = "66",
            CodigoSitDocFiscal = "00",
            SerieDocFiscal = "001",
            NumeroDocFiscal = "963258",
            DataDocFiscal = new System.DateTime(2023,10,05),
            DataEntrada = new System.DateTime(2023, 10, 06),
            VrTotalDocFiscal = 100d,
            VrPis = 1.65d,
            VrCofins = 7.6d,
            ChaveDocEletronico = "chavechavechave",
        };
        reg.ToString().Should().Be(result);
    }


    [TestCase("|C500|12345678|66|00|001||963258|05102023|06102023|100|||1,65|7,6|", "005")]
    [TestCase("|C500|12345678|66|00|001||963258|05102023|06102023|100|||1,65|7,6|chavechavechave|", "006")]
    public void Leitura(string linha, string versao = "006")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_Contribuicoes.RegistroC500("", versao);
        reg.CodigoParticipante.Should().Be(null);
        reg.VrTotalDocFiscal.HasValue.Should().Be(false);

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    
    private void InternalRead(EficazFramework.SPED.Schemas.EFD_Contribuicoes.RegistroC500 reg, string versao = "006")
    {
        reg.Codigo.Should().Be("C500");
        reg.Versao.Should().Be(versao);
        reg.CodigoParticipante.Should().Be("12345678");
        reg.CodigoModeloDocFiscal.Should().Be("66");
        reg.CodigoSitDocFiscal.Should().Be("00");
        reg.NumeroDocFiscal.Should().Be("963258");
        reg.SerieDocFiscal.Should().Be("001");
        reg.DataDocFiscal.Should().Be(new System.DateTime(2023, 10, 05));
        reg.DataEntrada.Should().Be(new System.DateTime(2023, 10, 06));
        reg.VrTotalDocFiscal.Should().Be(100d);
        reg.VrPis.Should().Be(1.65d);
        reg.VrCofins.Should().Be(7.6d);

        if (int.Parse(versao) >= 6)
            reg.ChaveDocEletronico.Should().Be("chavechavechave");
        else
            reg.ChaveDocEletronico.Should().BeNull();
    }
}
