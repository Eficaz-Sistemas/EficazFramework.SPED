using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC178 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC178();
        reg.Codigo.Should().Be("C178");
    }

    [TestCase("|C178|CLASS01|10|100|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC178(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C178|CLASS01|10|100|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC178("", versao)
        {
            CodClasseEnquadIPI = "CLASS01",
            VrUnidPadraoTrib = 10.0d,
            QtdeTotalProd = 100.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C178|CLASS01|10|100|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC178("", versao);
        reg.CodClasseEnquadIPI.Should().BeNull();
        reg.VrUnidPadraoTrib.HasValue.Should().BeFalse();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC178 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C178");
        reg.Versao.Should().Be(versao);
        reg.CodClasseEnquadIPI.Should().Be("CLASS01");
        reg.VrUnidPadraoTrib.Should().Be(10.0d);
        reg.QtdeTotalProd.Should().Be(100.0d);
    }
}
