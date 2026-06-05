using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Bloco0;

public class Registro0305 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0305();
        reg.Codigo.Should().Be("0305");
    }

    [TestCase("|0305|CC001|Uso Administrativo|120|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0305(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|0305|CC001|Uso Administrativo|120|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0305("", versao)
        {
            CentroDeCusto = "CC001",
            DescricaoFuncaoBem = "Uso Administrativo",
            VidaUtil = 120
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|0305|CC001|Uso Administrativo|120|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0305("", versao);
        reg.CentroDeCusto.Should().Be(null);

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0305 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("0305");
        reg.Versao.Should().Be(versao);
        reg.CentroDeCusto.Should().Be("CC001");
        reg.DescricaoFuncaoBem.Should().Be("Uso Administrativo");
        reg.VidaUtil.Should().Be(120);
    }
}
