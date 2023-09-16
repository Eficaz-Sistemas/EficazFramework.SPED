using FluentAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoE;

public class RegistroE520 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE520();
        reg.Codigo.Should().Be("E520");
    }

    
    [TestCase("|E520|0,05|100,79|200,4|15,12|20,2|4,09|9,06|", "015")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE520(linha, versao);
        InternalRead(reg, versao);
    }


    [TestCase("|E520|0,05|100,79|200,4|15,12|20,2|4,09|9,06|", "015")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE520("", versao)
        {
            SaldoCredorAnterior = 0.05d,
            Debitos = 100.79d,
            Creditos = 200.4d,
            OutrosDebitos_EstornoCreditos = 15.12d,
            OutrosCreditos_EstornoDebitos = 20.2d,
            SaldoCredorATransportar = 4.09d,
            SaldoDevedor = 9.06d
        };
        
       
        reg.ToString().Should().Be(result);
    }


    [TestCase("|E520|0,05|100,79|200,4|15,12|20,2|4,09|9,06|", "015")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE520("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    
    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE520 reg, string versao = "016")
    {
        reg.SaldoCredorAnterior.Should().Be(0.05d);
        reg.Debitos.Should().Be(100.79d);
        reg.Creditos.Should().Be(200.4d);
        reg.OutrosDebitos_EstornoCreditos.Should().Be(15.12d);
        reg.OutrosCreditos_EstornoDebitos.Should().Be(20.2d);
        reg.SaldoCredorATransportar.Should().Be(4.09d);
        reg.SaldoDevedor.Should().Be(9.06d);
    }
}
