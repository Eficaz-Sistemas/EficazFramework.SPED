using System;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoE;

public class RegistroE250 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE250();
        reg.Codigo.Should().Be("E250");
    }

    [TestCase("|E250|000|150,5|20012023|1111|12345|1|Desc|Txt|012023|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE250(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|E250|000|150,5|20012023|1111|12345|1|Desc|Txt|012023|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE250("", versao)
        {
            CodigoObrigacao = "000",
            ValorObrigacao = 150.5d,
            DataVencimento = new DateTime(2023, 1, 20),
            CodigoReceita = "1111",
            NumeroProcessoOuAuto = "12345",
            OrigemProcesso = IndicadorOrigemProcesso.JusticaFederal,
            DescricaoProcesso = "Desc",
            TextoComplementar = "Txt"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|E250|000|150,5|20012023|1111|12345|1|Desc|Txt|012023|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE250("", versao);
        reg.CodigoObrigacao.Should().BeNull();
        reg.CodigoReceita.Should().BeNull();
        reg.NumeroProcessoOuAuto.Should().BeNull();
        reg.DescricaoProcesso.Should().BeNull();
        reg.TextoComplementar.Should().BeNull();
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE250 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("E250");
        reg.Versao.Should().Be(versao);
        reg.CodigoObrigacao.Should().Be("000");
        reg.ValorObrigacao.Should().Be(150.5d);
        reg.DataVencimento.Should().Be(new DateTime(2023, 1, 1));
        reg.CodigoReceita.Should().Be("1111");
        reg.NumeroProcessoOuAuto.Should().Be("12345");
        reg.OrigemProcesso.Should().Be(IndicadorOrigemProcesso.JusticaFederal);
        reg.DescricaoProcesso.Should().Be("Desc");
        reg.TextoComplementar.Should().Be("Txt");
    }
}
