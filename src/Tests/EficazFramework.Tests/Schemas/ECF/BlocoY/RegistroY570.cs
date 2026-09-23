using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoY;

public class RegistroY570 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroY550();
        reg.Codigo.Should().Be("Y570");
    }

    [TestCase("|Y570|12345678000100|Empresa Pagadora LTDA|N|1708|100000,00|1500,00|1000,00|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroY550(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|Y570|12345678000100|Empresa Pagadora LTDA|N|1708|100000,00|1500,00|1000,00|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroY550("", versao)
        {
            CNPJ_FontePagadora = "12345678000100",
            NomeEmpresarial = "Empresa Pagadora LTDA",
            IndicadorOrgaoPublico = false,
            CodigoRecolhimento = "1708",
            RendimentoBruto = 100000.0d,
            IR_Retido = 1500.0d,
            CSLL_Retida = 1000.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|Y570|12345678000100|Empresa Pagadora LTDA|N|1708|100000,00|1500,00|1000,00|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroY550(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroY550 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("Y570");
        reg.Versao.Should().Be(versao);
    }
}
