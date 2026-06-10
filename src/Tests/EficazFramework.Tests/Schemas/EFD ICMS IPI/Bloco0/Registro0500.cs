using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Bloco0;

public class Registro0500 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0500();
        reg.Codigo.Should().Be("0500");
    }

    [TestCase("|0500|01012022|09|A|1|1|Ativo|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0500(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|0500|01012022|01|A|1|1|Ativo|", "016", ECD.TipoConta.Ativo)]
    [TestCase("|0500|01012022|02|A|1|1|Ativo|", "016", ECD.TipoConta.Passivo)]
    [TestCase("|0500|01012022|04|A|1|1|Ativo|", "016", ECD.TipoConta.Resultado)]
    public void Escrita(string result, string versao = "016", ECD.TipoConta tipoConta = ECD.TipoConta.Outras)
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0500("", versao)
        {
            DataAlteracao = new System.DateTime(2022, 1, 1),
            CodigoNatureza = tipoConta,
            IndicadorConta = "A",
            Nivel = 1,
            CodigoConta = "1",
            NomeConta = "Ativo"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|0500|01012022|01|A|1|1|Ativo|", "016", ECD.TipoConta.Ativo)]
    [TestCase("|0500|01012022|02|A|1|1|Ativo|", "016", ECD.TipoConta.Passivo)]
    [TestCase("|0500|01012022|04|A|1|1|Ativo|", "016", ECD.TipoConta.Resultado)]
    public void Leitura(string linha, string versao = "016", ECD.TipoConta tipoConta = ECD.TipoConta.Outras)
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0500("", versao);
        reg.DataAlteracao.Should().Be(null);

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao, tipoConta);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0500 reg, string versao = "016", ECD.TipoConta tipoConta = ECD.TipoConta.Outras)
    {
        reg.Codigo.Should().Be("0500");
        reg.Versao.Should().Be(versao);
        reg.DataAlteracao.Should().Be(new System.DateTime(2022, 1, 1));
        reg.IndicadorConta.Should().Be("A");
        reg.CodigoConta.Should().Be("1");
        reg.NomeConta.Should().Be("Ativo");
        reg.CodigoNatureza.Should().Be(tipoConta);
    }
}
