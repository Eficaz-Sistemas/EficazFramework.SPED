using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC160 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC160();
        reg.Codigo.Should().Be("C160");
    }

    [TestCase("|C160|PART01|ABC1234|10|500|450|MG|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC160(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C160|PART01|ABC1234|10|500|450|MG|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC160("", versao)
        {
            CodParticipante = "PART01",
            PlacaVeiculoIdent = "ABC1234",
            QuantVolumeTransp = "10",
            PesoBrutoTransp = 500.0d,
            PesoLiquidoTransp = 450.0d,
            UFPlacaVeiculo = "MG"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C160|PART01|ABC1234|10|500|450|MG|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC160("", versao);
        reg.CodParticipante.Should().BeNull();
        reg.PlacaVeiculoIdent.Should().BeNull();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC160 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C160");
        reg.Versao.Should().Be(versao);
        reg.CodParticipante.Should().Be("PART01");
        reg.PlacaVeiculoIdent.Should().Be("ABC1234");
        reg.QuantVolumeTransp.Should().Be("10");
        reg.PesoBrutoTransp.Should().Be(500.0d);
        reg.PesoLiquidoTransp.Should().Be(450.0d);
        reg.UFPlacaVeiculo.Should().Be("MG");
    }
}
