using System;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECD.BlocoK;

public class RegistroK115Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroK115();
        reg.Codigo.Should().Be("K115");
    }

    [TestCase("|K115|123|2|50,5|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroK115(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|K115|123|2|50,5|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroK115("", versao)
        {
            CodigoEmpresaEnvolvidaOperacao = "123",
            CondicaoEmpresaRelacionada = CondicaoEmpresaRelacionada.Adquirente,
            PercentualEmpPartEnvolvidaOper = 50.5
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|K115|123|2|50,5|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroK115(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroK115 reg, string versao)
    {
        reg.CodigoEmpresaEnvolvidaOperacao.Should().Be("123");
        reg.CondicaoEmpresaRelacionada.Should().Be(CondicaoEmpresaRelacionada.Adquirente);
        reg.PercentualEmpPartEnvolvidaOper.Should().Be(50.5);
    }
}
