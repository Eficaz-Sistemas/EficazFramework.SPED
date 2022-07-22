using FluentAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Bloco0;

public class Registro0000 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0000();
        reg.Codigo.Should().Be("0000");
    }

    
    [TestCase("|0000|016|0|01062022|30062022|Cooperativa ABC|12345678000100||MG|0011234560001|3129707|||B|1|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0000(linha, versao);
        InternalRead(reg, versao);
    }


    [TestCase("|0000|016|0|01062022|30062022|Cooperativa ABC|12345678000100||MG|0011234560001|3129707|||A|1|", "016", Perfil.A)]
    [TestCase("|0000|016|0|01062022|30062022|Cooperativa ABC|12345678000100||MG|0011234560001|3129707|||B|1|", "016", Perfil.B)]
    [TestCase("|0000|016|0|01062022|30062022|Cooperativa ABC|12345678000100||MG|0011234560001|3129707|||C|1|", "016", Perfil.C)]
    public void Escrita(string result, string versao = "016", Perfil perfil = Perfil.B)
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0000("", versao)
        {
            DataInicial = new System.DateTime(2022, 6, 1),
            DataFinal = new System.DateTime(2022, 6, 30),
            RazaoSocial = "Cooperativa ABC",
            CNPJ = "12345678000100",
            UF = "MG",
            InscricaoEstadual = "0011234560001",
            MunicipioCodigo = "3129707",
            Perfil = perfil
        };
        reg.ToString().Should().Be(result);

    }


    [TestCase("|0000|016|0|01062022|30062022|Cooperativa ABC|12345678000100||MG|0011234560001|3129707|||B|1|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0000("", versao);
        reg.DataInicial.Should().Be(null);
        reg.DataFinal.Should().Be(null);
        reg.RazaoSocial.Should().Be(null);
        reg.CNPJ.Should().Be(null);
        reg.UF.Should().Be(null);
        reg.InscricaoEstadual.Should().Be(null);

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }


    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0000 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("0000");
        reg.Versao.Should().Be(versao);
        reg.DataInicial.Should().Be(new System.DateTime(2022, 6, 1));
        reg.DataFinal.Should().Be(new System.DateTime(2022, 6, 30));
        reg.RazaoSocial.Should().Be("Cooperativa ABC");
        reg.CNPJ.Should().Be("12345678000100");
        reg.UF.Should().Be("MG");
        reg.InscricaoEstadual.Should().Be("0011234560001");
        reg.MunicipioCodigo.Should().Be("3129707");
        reg.Perfil.Should().Be(Perfil.B);
    }

}
