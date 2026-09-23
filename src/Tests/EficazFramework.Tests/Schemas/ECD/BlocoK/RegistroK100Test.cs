using System;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECD.BlocoK;

public class RegistroK100Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroK100();
        reg.Codigo.Should().Be("K100");
    }

    [TestCase("|K100|01058|123|12345678000199|EMPRESA A|50,5|NENHUM|50,5|01012023|31122023|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroK100(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|K100|01058|123|12345678000199|EMPRESA A|50,5|NENHUM|50,5|01012023|31122023|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroK100("", versao)
        {
            CodPais = "01058",
            CodigoIdentifEmpresaPart = "123",
            CNPJ = "12345678000199",
            NomeEmpresarial = "EMPRESA A",
            PercentualPartConglomerado = 50.5,
            EventoSocietarioOcorrido = "NENHUM",
            DataInicialEscrituracaoEmpresaConsolidada = new DateTime(2023, 1, 1),
            DataFinalEscrituracaoEmpresaConsolidada = new DateTime(2023, 12, 31)
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|K100|01058|123|12345678000199|EMPRESA A|50,5|NENHUM|50,5|01012023|31122023|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroK100(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroK100 reg, string versao)
    {
        reg.CodPais.Should().Be("01058");
        reg.CodigoIdentifEmpresaPart.Should().Be("123");
        reg.CNPJ.Should().Be("12345678000199");
        reg.NomeEmpresarial.Should().Be("EMPRESA A");
        reg.PercentualPartConglomerado.Should().Be(50.5);
        reg.EventoSocietarioOcorrido.Should().Be("NENHUM");
        reg.PercentualConsolidacaoEmpresa.Should().BeNull();
        reg.DataInicialEscrituracaoEmpresaConsolidada.Should().Be(new DateTime(2023, 1, 1));
        reg.DataFinalEscrituracaoEmpresaConsolidada.Should().Be(new DateTime(2023, 12, 31));
    }
}
