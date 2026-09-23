using System;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoE;

public class RegistroE115 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE115();
        reg.Codigo.Should().Be("E115");
    }

    [TestCase("|E115|RS12345|1000,55|Complemento|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE115(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|E115|RS12345|1000,55|Complemento|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE115("", versao)
        {
            CodigoInformacao = "RS12345",
            Valor = 1000.55d,
            DescricaoComplementar = "Complemento"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|E115|RS12345|1000,55|Complemento|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE115("", versao);
        reg.CodigoInformacao.Should().BeNull();
        reg.DescricaoComplementar.Should().BeNull();
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE115 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("E115");
        reg.Versao.Should().Be(versao);
        reg.CodigoInformacao.Should().Be("RS12345");
        reg.Valor.Should().Be(1000.55d);
        reg.DescricaoComplementar.Should().Be("Complemento");
    }
}
