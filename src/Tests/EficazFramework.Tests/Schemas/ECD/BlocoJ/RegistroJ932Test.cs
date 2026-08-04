using System;
using AwesomeAssertions;
using NUnit.Framework;
using EficazFramework.SPED.Schemas.ECD;

namespace EficazFramework.SPED.Schemas.ECD.BlocoJ;

public class RegistroJ932Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroJ932();
        reg.Codigo.Should().Be("J932");
    }

    [TestCase("|J932|NOME|CPF|QUAL|COD|CRC|EMAIL|FONE|UF|SEQ|01012023|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroJ932(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|J932|NOME|CPF|QUAL|COD|CRC|EMAIL|FONE|UF|SEQ|01012023|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroJ932()
        {
            NomeSignatario = "NOME",
            CPFOuCNPJ = "CPF",
            QualificacaoAssinante = "QUAL",
            CodigodeQualificacaoAssinante = "COD",
            NumeroInscCRC = "CRC",
            EmailSignatario = "EMAIL",
            Fone = "FONE",
            UFCRC = "UF",
            NumSequencialCRC = "SEQ",
            DataValidCRC = new DateTime(2023, 1, 1)
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|J932|NOME|CPF|QUAL|COD|CRC|EMAIL|FONE|UF|SEQ|01012023|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroJ932();
        reg.LeParametros(linha.Split("|"));
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroJ932 reg, string versao)
    {
        reg.NomeSignatario.Should().Be("NOME");
        reg.CPFOuCNPJ.Should().Be("CPF");
        reg.QualificacaoAssinante.Should().Be("QUAL");
        reg.CodigodeQualificacaoAssinante.Should().Be("COD");
        reg.NumeroInscCRC.Should().Be("CRC");
        reg.EmailSignatario.Should().Be("EMAIL");
        reg.Fone.Should().Be("FONE");
        reg.UFCRC.Should().Be("UF");
        reg.NumSequencialCRC.Should().Be("SEQ");
        reg.DataValidCRC.Should().Be(new DateTime(2023, 1, 1));
    }
}
