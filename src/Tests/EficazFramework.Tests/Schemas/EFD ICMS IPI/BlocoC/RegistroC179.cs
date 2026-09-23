using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC179 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC179();
        reg.Codigo.Should().Be("C179");
    }

    [TestCase("|C179|100|18|0|0|0|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC179(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C179|100|18|0|0|0|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC179("", versao)
        {
            VrBCSTOperacoesInterest = 100.0d,
            VrICMSSTOperacoesInterest = 18.0d,
            VrICMSSTComplementarUFDestino = 0.0d,
            VrBCRetRemessaST = 0.0d,
            VrParcelaImpostoRetidoST = 0.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C179|100|18|0|0|0|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC179("", versao);
        reg.VrBCSTOperacoesInterest.HasValue.Should().BeFalse();
        reg.VrICMSSTOperacoesInterest.HasValue.Should().BeFalse();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC179 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C179");
        reg.Versao.Should().Be(versao);
        reg.VrBCSTOperacoesInterest.Should().Be(100.0d);
        reg.VrICMSSTOperacoesInterest.Should().Be(18.0d);
        reg.VrICMSSTComplementarUFDestino.Should().Be(0.0d);
        reg.VrBCRetRemessaST.Should().Be(0.0d);
        reg.VrParcelaImpostoRetidoST.Should().Be(0.0d);
    }
}
