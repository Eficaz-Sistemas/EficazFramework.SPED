using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Bloco1;

public class Registro1320 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1320();
        reg.Codigo.Should().Be("1320");
    }

    [TestCase("|1320|1|12345|1|Nome Interventor|12345678901234|12345678901|1000|2000|10|50|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1320(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|1320|1|12345|1|Nome Interventor|12345678901234|12345678901|1000|2000|10|50|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1320("", versao)
        {
            NumeroBico = 1,
            NumeroIntervencao = "12345",
            MotivoIntervencao = 1.0d,
            NomeInterventor = "Nome Interventor",
            CNPJEmpresaIntervencao = "12345678901234",
            CPFTecnicoIntervencao = "12345678901",
            ValorFechamento = 1000.0d,
            ValorAbertura = 2000.0d,
            VolumeAfericoes = 10.0d,
            VolumeVendas = 50.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|1320|1|12345|1|Nome Interventor|12345678901234|12345678901|1000|2000|10|50|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1320("", versao);
        reg.NumeroIntervencao.Should().BeNull();
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1320 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("1320");
        reg.Versao.Should().Be(versao);
        reg.NumeroBico.Should().Be(1);
        reg.NumeroIntervencao.Should().Be("12345");
        reg.MotivoIntervencao.Should().Be(1.0d);
        reg.NomeInterventor.Should().Be("Nome Interventor");
        reg.CNPJEmpresaIntervencao.Should().Be("12345678901234");
        reg.CPFTecnicoIntervencao.Should().Be("12345678901");
        reg.ValorFechamento.Should().Be(1000.0d);
        reg.ValorAbertura.Should().Be(2000.0d);
        reg.VolumeAfericoes.Should().Be(10.0d);
        reg.VolumeVendas.Should().Be(50.0d);
    }
}
