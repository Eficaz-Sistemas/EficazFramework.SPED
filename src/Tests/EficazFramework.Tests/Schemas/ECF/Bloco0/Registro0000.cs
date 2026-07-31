using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.Bloco0;

public class Registro0000 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.Registro0000();
        reg.Codigo.Should().Be("0000");
    }

    [TestCase("|0000|LECF|00010|12345678000100|Empresa Teste ECF|0|0|0,0000||01012022|31122022|N||0||", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.Registro0000(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|0000|LECF|00010|12345678000100|Empresa Teste ECF|0|0|0,0000||01012022|31122022|N||0||", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.Registro0000("", versao)
        {
            CNPJ = "12345678000100",
            NomeEmpresarial = "Empresa Teste ECF",
            IndicadorSitInicioPeriodo = SituacaoInicioPeriodo.Regular,
            SituacaoEspecial = SituacaoEspecial.NaoAplicavel,
            PatrimonioRemanescente = 0.0d,
            DataInicial = new System.DateTime(2022, 1, 1),
            DataFinal = new System.DateTime(2022, 12, 31),
            Retificadora = false,
            TipoECF = TipoECF.NaoSCP
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|0000|LECF|00010|12345678000100|Empresa Teste ECF|0|0|0,0000||01012022|31122022|N||0||", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.Registro0000("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.Registro0000 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("0000");
        reg.Versao.Should().Be(versao);
    }
}
