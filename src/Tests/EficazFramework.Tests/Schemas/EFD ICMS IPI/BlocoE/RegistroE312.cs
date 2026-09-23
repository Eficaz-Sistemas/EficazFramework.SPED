using System;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoE;

public class RegistroE312 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE312();
        reg.Codigo.Should().Be("E312");
    }

    [TestCase("|E312|12345|PROC54321|1|Despacho|Ajuste ref processo|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE312(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|E312|12345|PROC54321|1|Despacho|Ajuste ref processo|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE312("", versao)
        {
            NumeroDocArrecadacao = "12345",
            NumeroProcessoRef = "PROC54321",
            OrigemProcessoRef = IndicadorOrigemProcesso.JusticaFederal,
            DescricaoProcessoRef = "Despacho",
            DescricaoComplementar = "Ajuste ref processo"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|E312|12345|PROC54321|1|Despacho|Ajuste ref processo|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE312("", versao);
        reg.NumeroDocArrecadacao.Should().BeNull();
        reg.NumeroProcessoRef.Should().BeNull();
        reg.DescricaoProcessoRef.Should().BeNull();
        reg.DescricaoComplementar.Should().BeNull();
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE312 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("E312");
        reg.Versao.Should().Be(versao);
        reg.NumeroDocArrecadacao.Should().Be("12345");
        reg.NumeroProcessoRef.Should().Be("PROC54321");
        reg.OrigemProcessoRef.Should().Be(IndicadorOrigemProcesso.JusticaFederal);
        reg.DescricaoProcessoRef.Should().Be("Despacho");
        reg.DescricaoComplementar.Should().Be("Ajuste ref processo");
    }
}
