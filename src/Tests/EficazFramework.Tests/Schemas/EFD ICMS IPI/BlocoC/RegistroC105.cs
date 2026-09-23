using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC105 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC105();
        reg.Codigo.Should().Be("C105");
    }

    [TestCase("|C105|0|MG|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC105(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C105|0|MG|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC105("", versao)
        {
            Operacao = IndicadorTipoOperacao.CombustiveleLubrificantes,
            SiglaUFdestino_IcmsST = "MG"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C105|0|MG|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC105("", versao);
        reg.SiglaUFdestino_IcmsST.Should().BeNull();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC105 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C105");
        reg.Versao.Should().Be(versao);
        reg.Operacao.Should().Be(IndicadorTipoOperacao.CombustiveleLubrificantes);
        reg.SiglaUFdestino_IcmsST.Should().Be("MG");
    }
}
