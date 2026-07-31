using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC400 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC400();
        reg.Codigo.Should().Be("C400");
    }

    [TestCase("|C400|2D|ECF|SERIE123|1|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC400(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C400|2D|ECF|SERIE123|1|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC400("", versao)
        {
            CodigoModelo = "2D",
            Especie = "ECF",
            NumeroSerie = "SERIE123",
            NumeroCaixa = 1
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C400|2D|ECF|SERIE123|1|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC400("", versao);
        reg.CodigoModelo.Should().BeNull();
        reg.NumeroSerie.Should().BeNull();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC400 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C400");
        reg.Versao.Should().Be(versao);
        reg.CodigoModelo.Should().Be("2D");
        reg.Especie.Should().Be("ECF");
        reg.NumeroSerie.Should().Be("SERIE123");
        reg.NumeroCaixa.Should().Be(1);
    }
}
