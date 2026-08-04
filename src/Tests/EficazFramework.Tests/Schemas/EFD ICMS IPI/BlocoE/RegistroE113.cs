using System;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoE;

public class RegistroE113 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE113();
        reg.Codigo.Should().Be("E113");
    }

    [TestCase("|E113|PART1|55|1||123456|01012023|ITEM1|150,5|12345678901234567890123456789012345678901234|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE113(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|E113|PART1|55|1||123456|01012023|ITEM1|150,5|12345678901234567890123456789012345678901234|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE113("", versao)
        {
            CodigoParticipante = "PART1",
            Modelo = "55",
            Serie = "1",
            SubSerie = "",
            Numero = 123456,
            DataEmissao = new DateTime(2023, 1, 1),
            CodigoItem0200 = "ITEM1",
            ValorAjusteItem = 150.5d,
            ChaveDocEletronico = "12345678901234567890123456789012345678901234"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|E113|PART1|55|1||123456|01012023|ITEM1|150,5|12345678901234567890123456789012345678901234|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE113("", versao);
        reg.CodigoParticipante.Should().BeNull();
        reg.Modelo.Should().BeNull();
        reg.Serie.Should().BeNull();
        reg.SubSerie.Should().BeNull();
        reg.CodigoItem0200.Should().BeNull();
        reg.ChaveDocEletronico.Should().BeNull();
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE113 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("E113");
        reg.Versao.Should().Be(versao);
        reg.CodigoParticipante.Should().Be("PART1");
        reg.Modelo.Should().Be("55");
        reg.Serie.Should().Be("1");
        reg.SubSerie.Should().Be("");
        reg.Numero.Should().Be(123456);
        reg.DataEmissao.Should().Be(new DateTime(2023, 1, 1));
        reg.CodigoItem0200.Should().Be("ITEM1");
        reg.ValorAjusteItem.Should().Be(150.5d);
        reg.ChaveDocEletronico.Should().Be("12345678901234567890123456789012345678901234");
    }
}
