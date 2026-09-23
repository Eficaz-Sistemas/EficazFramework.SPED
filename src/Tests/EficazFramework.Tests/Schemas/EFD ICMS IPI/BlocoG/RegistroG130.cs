using AwesomeAssertions;
using NUnit.Framework;
using System;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoG;

public class RegistroG130 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroG130();
        reg.Codigo.Should().Be("G130");
    }

    [TestCase("|G130|0|1|1|1|1|CHAVE|01112022|1|", "016")] // Versão 016 >= 14, escreve campo 09
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroG130(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|G130|0|1|1|1|1|CHAVE|01112022|1|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroG130("", versao)
        {
            IndicadorEmissao = IndicadorEmitente.Propria,
            CodigoParticipante = "1",
            Modelo = "1",
            Serie = "1",
            Numero = 1,
            Chave_NFeCTe = "CHAVE",
            DataEmissao = new DateTime(2022, 11, 1),
            NumeroDocArrecadacao = "1"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|G130|0|1|1|1|1|CHAVE|01112022|1|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroG130("", versao);
        reg.CodigoParticipante.Should().BeNull();
        reg.Modelo.Should().BeNull();
        reg.Serie.Should().BeNull();
        reg.Chave_NFeCTe.Should().BeNull();
        reg.NumeroDocArrecadacao.Should().BeNull();
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroG130 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("G130");
        reg.Versao.Should().Be(versao);
        reg.IndicadorEmissao.Should().Be(IndicadorEmitente.Propria);
        reg.CodigoParticipante.Should().Be("1");
        reg.Modelo.Should().Be("1");
        reg.Serie.Should().Be("1");
        reg.Numero.Should().Be(1);
        reg.Chave_NFeCTe.Should().Be("CHAVE");
        reg.DataEmissao.Should().Be(new DateTime(2022, 11, 1));
        reg.NumeroDocArrecadacao.Should().Be("1");
    }
}
