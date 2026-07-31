using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC165 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC165();
        reg.Codigo.Should().Be("C165");
    }

    [TestCase("|C165|PART01|ABC1234|SEFAZ123|PAS123|143000|25|100|500|450|JOAO|12345678901|MG|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC165(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C165|PART01|ABC1234|SEFAZ123|PAS123||25|100|500|450|JOAO|12345678901|MG|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC165("", versao)
        {
            CodParticipante = "PART01",
            PlacaIdentificacaoVeiculo = "ABC1234",
            CodAutorizacaoSefaz = "SEFAZ123",
            NumPasseFiscal = "PAS123",
            TemperaturaVolumeCombustivel = 25.0d,
            QuantVolumesTransportados = "100",
            PesoBrutoVolumes = 500.0d,
            PesoLiquidoVolumes = 450.0d,
            NomeMotorista = "JOAO",
            CPFMotorista = "12345678901",
            UFPlacaVeiculo = "MG"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C165|PART01|ABC1234|SEFAZ123|PAS123|143000|25|100|500|450|JOAO|12345678901|MG|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC165("", versao);
        reg.CodParticipante.Should().BeNull();
        reg.PlacaIdentificacaoVeiculo.Should().BeNull();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC165 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C165");
        reg.Versao.Should().Be(versao);
        reg.CodParticipante.Should().Be("PART01");
        reg.PlacaIdentificacaoVeiculo.Should().Be("ABC1234");
        reg.CodAutorizacaoSefaz.Should().Be("SEFAZ123");
        reg.NumPasseFiscal.Should().Be("PAS123");
        reg.HoraSaideMercadorias.Should().Be(new System.TimeSpan(14, 30, 0));
        reg.TemperaturaVolumeCombustivel.Should().Be(25.0d);
        reg.QuantVolumesTransportados.Should().Be("100");
        reg.PesoBrutoVolumes.Should().Be(500.0d);
        reg.PesoLiquidoVolumes.Should().Be(450.0d);
        reg.NomeMotorista.Should().Be("JOAO");
        reg.CPFMotorista.Should().Be("12345678901");
        reg.UFPlacaVeiculo.Should().Be("MG");
    }
}
