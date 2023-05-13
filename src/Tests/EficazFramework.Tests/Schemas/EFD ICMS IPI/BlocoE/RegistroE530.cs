using FluentAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoE;

public class RegistroE530 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE530();
        reg.Codigo.Should().Be("E530");
    }

    
    [TestCase("|E530|1|205,88|002|2|987654|Compensei Web|", "015")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE530(linha, versao);
        InternalRead(reg, versao);
    }


    [TestCase("|E530|1|205,88|002|2|987654|Compensei Web|", "015")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE530("", versao)
        {
            IndicadorAjuste = IndicadorAjusteIPI.Credito,
            ValorAjuste = 205.88,
            CodigoAjuste = "002",
            Origem = IndicadorOrigemAjusteIPI.PerDCOMP,
            NumeroDocumento = "987654",
            Descricao = "Compensei Web"
        };
        
       
        reg.ToString().Should().Be(result);
    }


    [TestCase("|E530|1|205,88|002|2|987654|Compensei Web|", "015")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE530("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    
    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE530 reg, string versao = "016")
    {
        reg.IndicadorAjuste.Should().Be(IndicadorAjusteIPI.Credito);
        reg.ValorAjuste.Should().Be(205.88d);
        reg.CodigoAjuste.Should().Be("002");
        reg.Origem.Should().Be(IndicadorOrigemAjusteIPI.PerDCOMP);
        reg.NumeroDocumento.Should().Be("987654");
        reg.Descricao.Should().Be("Compensei Web");
    }
}
