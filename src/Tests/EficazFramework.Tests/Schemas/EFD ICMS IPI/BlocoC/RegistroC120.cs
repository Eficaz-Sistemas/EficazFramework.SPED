using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC120 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC120();
        reg.Codigo.Should().Be("C120");
    }

    [TestCase("|C120|0|1234567890|10|46|ACD123|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC120(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C120|0|1234567890|10|46|ACD123|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC120("", versao)
        {
            Documento_Importacao = DocumentoImportacao.Declaracao_Importacao,
            Numero_Doc_Imp = "1234567890",
            ValorPIS = 10.0d,
            ValorCOFINS = 46.0d,
            Numero_Acdraw = "ACD123"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C120|0|1234567890|10|46|ACD123|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC120("", versao);
        reg.Numero_Doc_Imp.Should().BeNull();
        reg.ValorPIS.HasValue.Should().BeFalse();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC120 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C120");
        reg.Versao.Should().Be(versao);
        reg.Documento_Importacao.Should().Be(DocumentoImportacao.Declaracao_Importacao);
        reg.Numero_Doc_Imp.Should().Be("1234567890");
        reg.ValorPIS.Should().Be(10.0d);
        reg.ValorCOFINS.Should().Be(46.0d);
        reg.Numero_Acdraw.Should().Be("ACD123");
    }
}
