using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC860 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC860();
        reg.Codigo.Should().Be("C860");
    }

    [TestCase("|C860|59|900001234|01112022|1|100|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC860(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C860|59|900001234|01112022|1|100|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC860("", versao)
        {
            EspecieDocumento = "59",
            NumeroSerieSAT = 900001234,
            DataEmissao = new System.DateTime(2022, 11, 1),
            DocInicial = 1,
            DocFinal = 100
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C860|59|900001234|01112022|1|100|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC860("", versao);
        reg.EspecieDocumento.Should().BeNull();
        reg.NumeroSerieSAT.HasValue.Should().BeFalse();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC860 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C860");
        reg.Versao.Should().Be(versao);
        reg.EspecieDocumento.Should().Be("59");
        reg.NumeroSerieSAT.Should().Be(900001234);
        reg.DataEmissao.Should().Be(new System.DateTime(2022, 11, 1));
        reg.DocInicial.Should().Be(1);
        reg.DocFinal.Should().Be(100);
    }
}
