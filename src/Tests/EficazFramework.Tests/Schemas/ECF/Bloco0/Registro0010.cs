using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.Bloco0;

public class Registro0010 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.Registro0010();
        reg.Codigo.Should().Be("0010");
    }

    [TestCase("|0010|HASH123|N|1|A|01|RRRR|EEEEEEEEEEEE|C|||||", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.Registro0010(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|0010|HASH123|N|1|A|01|RRRR|EEEEEEEEEEEE|C|||||", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.Registro0010("", versao)
        {
            HashEcfAnterior = "HASH123",
            OpptanteRefis = false,
            FormaTributacao = FormaTributacao.LucroReal,
            FormaApuracao = FormaApuracao.Anual,
            QualificacaoPJ = QualificacaoPJ.PjemGeral,
            FormaTributacaoTrimestre = "RRRR",
            FormaTributacaoMes = "EEEEEEEEEEEE",
            ObrigatoriedadeECD = "C",
            TipoPJImuneIsenta = TipoPJImuneOuIsenta.NaoAplicavel
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|0010|HASH123|N|1|A|01|RRRR|EEEEEEEEEEEE|C|||||", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.Registro0010("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.Registro0010 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("0010");
        reg.Versao.Should().Be(versao);
    }
}
