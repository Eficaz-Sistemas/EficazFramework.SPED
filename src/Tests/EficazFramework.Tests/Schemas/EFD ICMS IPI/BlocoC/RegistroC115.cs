using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC115 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC115();
        reg.Codigo.Should().Be("C115");
    }

    [TestCase("|C115|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC115(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C115|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC115("", versao)
        {
            IndicadorTipoTransporte = IndicadorTipoTransporte.Rodoviario,
            CNPJ_Coleta = "12345678000100",
            IE_coleta = "001001",
            CPF_Coleta = "",
            Codigo_Municipio_Coleta = "3129707",
            CNPJ_Entrega = "98765432000199",
            IE_Entrega = "002002",
            CPF_Entrega = "",
            Codigo_Municipio_Entrega = "3129707"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C115|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC115("", versao);
        reg.CNPJ_Coleta.Should().BeNull();
        reg.CNPJ_Entrega.Should().BeNull();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC115 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C115");
        reg.Versao.Should().Be(versao);
    }
}
