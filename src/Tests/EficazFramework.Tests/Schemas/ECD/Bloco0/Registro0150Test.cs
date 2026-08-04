using System;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECD.Bloco0;

public class Registro0150Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new Registro0150();
        reg.Codigo.Should().Be("0150");
    }

    [TestCase("|0150|COD123|NOME EMPRESA|01058|12345678000199|||MG|123456|123456ST|3106200|987654|SUFRAMA123|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new Registro0150(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|0150|COD123|NOME EMPRESA|01058|12345678000199|||MG|123456|123456ST|3106200|987654|SUFRAMA123|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new Registro0150("", versao)
        {
            CodigoParticipante = "COD123",
            NomeEmpresarial = "NOME EMPRESA",
            CodigoPais = "01058",
            CNPJParticipante = "12345678000199",
            CPFParticipante = "",
            NitPisPasepSus = "",
            UFParticipante = "MG",
            IEParticipante = "123456",
            IESTParticipante = "123456ST",
            CodMunicipio = "3106200",
            InscMunicipal = "987654",
            InscSuframa = "SUFRAMA123"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|0150|COD123|NOME EMPRESA|01058|12345678000199|||MG|123456|123456ST|3106200|987654|SUFRAMA123|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new Registro0150(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(Registro0150 reg, string versao)
    {
        reg.CodigoParticipante.Should().Be("COD123");
        reg.NomeEmpresarial.Should().Be("NOME EMPRESA");
        reg.CodigoPais.Should().Be("01058");
        reg.CNPJParticipante.Should().Be("12345678000199");
        reg.CPFParticipante.Should().Be("");
        reg.NitPisPasepSus.Should().Be("");
        reg.UFParticipante.Should().Be("MG");
        reg.IEParticipante.Should().Be("123456");
        reg.IESTParticipante.Should().Be("123456ST");
        reg.CodMunicipio.Should().Be("3106200");
        reg.InscMunicipal.Should().Be("987654");
        reg.InscSuframa.Should().Be("SUFRAMA123");
    }
}
