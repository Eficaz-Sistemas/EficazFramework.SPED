using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC174 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC174();
        reg.Codigo.Should().Be("C174");
    }

    [TestCase("|C174|0|SERIE123|Pistola|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC174(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C174|0|SERIE123|Pistola|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC174("", versao)
        {
            IndicadorTipoArmaFogo = IndicadorTipoArmaFogo.UsoPermitido,
            NumSerieFabricacao = "SERIE123",
            DescricaoArma = "Pistola"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C174|0|SERIE123|Pistola|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC174("", versao);
        reg.NumSerieFabricacao.Should().BeNull();
        reg.DescricaoArma.Should().BeNull();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC174 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C174");
        reg.Versao.Should().Be(versao);
        reg.IndicadorTipoArmaFogo.Should().Be(IndicadorTipoArmaFogo.UsoPermitido);
        reg.NumSerieFabricacao.Should().Be("SERIE123");
        reg.DescricaoArma.Should().Be("Pistola");
    }
}
