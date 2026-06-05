using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Bloco0;

public class Registro0015 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0015();
        reg.Codigo.Should().Be("0015");
    }

    [TestCase("|0015|MG|0010001112233|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0015(linha, versao);
        InternalRead(reg, versao, "0010001112233");
    }

    [TestCase("|0015|MG|0010001112233|", "016")]
    [TestCase("|0015|SP|0018822000000|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var uf = result.Contains("SP") ? "SP" : "MG";
        var ie = result.Contains("0018822000000") ? "0018822000000" : "0010001112233";
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0015("", versao)
        {
            UF = uf,
            InscricaoEstadual = ie
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|0015|MG|0010001112233|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0015("", versao);
        reg.UF.Should().Be(null);
        reg.InscricaoEstadual.Should().Be(null);

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao, "0010001112233");
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0015 reg, string versao = "016", string inscricaoEstadual = "")
    {
        reg.Codigo.Should().Be("0015");
        reg.Versao.Should().Be(versao);
        reg.UF.Should().NotBeNullOrEmpty();
        reg.InscricaoEstadual.Should().NotBeNullOrEmpty();
    }
}
