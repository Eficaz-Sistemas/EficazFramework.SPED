using System;
using AwesomeAssertions;
using NUnit.Framework;
using EficazFramework.SPED.Schemas.ECD;

namespace EficazFramework.SPED.Schemas.ECD.BlocoJ;

public class RegistroJ930Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroJ930();
        reg.Codigo.Should().Be("J930");
    }

    [TestCase("|J930|NOME|CPF|QUAL|COD|CRC|EMAIL|FONE|UF|SEQ|01012023|ID|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroJ930(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|J930|NOME|CPF|QUAL|COD|CRC|EMAIL|FONE|UF|SEQ|01012023|ID|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroJ930()
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
            DataValidCRC = new DateTime(2023, 1, 1),
            IdentificacaoResponsavel = "ID"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|J930|NOME|CPF|QUAL|COD|CRC|EMAIL|FONE|UF|SEQ|01012023|ID|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroJ930();
        reg.LeParametros(linha.Split("|"));
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroJ930 reg, string versao)
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
        reg.IdentificacaoResponsavel.Should().Be("ID");
    }
}
