using FluentAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoE;

public class RegistroE531 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE531();
        reg.Codigo.Should().Be("E531");
    }

    
    [TestCase("|E531|108555|01|001|A|987654|01042021|XYZ999|105,87|31155444888518|", "015")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE531(linha, versao);
        InternalRead(reg, versao);
    }


    [TestCase("|E531|108555|01|001|A|987654|01042021|XYZ999|105,87|31155444888518|", "015")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE531("", versao)
        {
            CodigoParticipante = "108555",
            EspecieDocumento = "01",
            Serie = "001",
            SubSerie = "A",
            Numero = 987654,
            DataEmissao = new DateTime(2021, 04, 01),
            CodigoProduto = "XYZ999",
            ValorAjuste = 105.87d,
            ChaveNFe = "31155444888518"
        };
        
       
        reg.ToString().Should().Be(result);
    }


    [TestCase("|E531|108555|01|001|A|987654|01042021|XYZ999|105,87|31155444888518|", "015")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE531("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    
    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE531 reg, string versao = "016")
    {
        reg.CodigoParticipante.Should().Be("108555");
        reg.EspecieDocumento.Should().Be("01");
        reg.Serie.Should().Be("001");
        reg.SubSerie.Should().Be("A");
        reg.Numero.Should().Be(987654);
        reg.DataEmissao.Should().Be(new DateTime(2021, 04, 01));
        reg.CodigoProduto.Should().Be("XYZ999");
        reg.ValorAjuste.Should().Be(105.87d);
        reg.ChaveNFe.Should().Be("31155444888518");
    }
}
