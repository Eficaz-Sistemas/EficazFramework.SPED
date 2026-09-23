using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC140 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC140();
        reg.Codigo.Should().Be("C140");
    }

    [TestCase("|C140|0|00|Duplicata A|DUP123|3|300|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC140(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C140|0|00|Duplicata A|DUP123|3|300|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC140("", versao)
        {
            Indicador_emitente_titulo = IndicadorEmitente.Propria,
            Indicador_Tipo_titulo = IndicadorTituloCredito.Duplicata,
            Descricao_Compl_titulo = "Duplicata A",
            Num_tituto = "DUP123",
            Qtd_Parcelas = 3,
            Vr_titulototal = 300.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C140|0|00|Duplicata A|DUP123|3|300|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC140("", versao);
        reg.Descricao_Compl_titulo.Should().BeNull();
        reg.Num_tituto.Should().BeNull();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC140 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C140");
        reg.Versao.Should().Be(versao);
        reg.Indicador_emitente_titulo.Should().Be(IndicadorEmitente.Propria);
        reg.Indicador_Tipo_titulo.Should().Be(IndicadorTituloCredito.Duplicata);
        reg.Descricao_Compl_titulo.Should().Be("Duplicata A");
        reg.Num_tituto.Should().Be("DUP123");
        reg.Qtd_Parcelas.Should().Be(3);
        reg.Vr_titulototal.Should().Be(300.0d);
    }
}
