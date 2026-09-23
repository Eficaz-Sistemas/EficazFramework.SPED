using EficazFramework.SPED.Schemas.ECD;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECD.BlocoI;

public class RegistroI020Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroI020();
        reg.Codigo.Should().Be("I020");
    }

    [TestCase("|I020|COD1|1|NOME1|DESC1|TIPO1|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroI020(linha, versao);
        reg.Codigo.Should().Be("I020");
        reg.Versao.Should().Be(versao);
        InternalRead(reg, versao);
    }

    [TestCase("|I020|COD1|1|NOME1|DESC1|TIPO1|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroI020()
        {
            CodigoRegistroRecepCampoAdicional = "COD1",
            NumSeqCampoAdicional = 1,
            NomeCampoAdicional = "NOME1",
            DescricaoCampoAdicional = "DESC1",
            IndicacaoTipoData = "TIPO1"
        };
        reg.EscreveLinha().Should().Be(result);
    }

    [TestCase("|I020|COD1|1|NOME1|DESC1|TIPO1|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroI020(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroI020 reg, string versao)
    {
        reg.CodigoRegistroRecepCampoAdicional.Should().Be("COD1");
        reg.NumSeqCampoAdicional.Should().Be(1);
        reg.NomeCampoAdicional.Should().Be("NOME1");
        reg.DescricaoCampoAdicional.Should().Be("DESC1");
        reg.IndicacaoTipoData.Should().Be("TIPO1");
    }
}
