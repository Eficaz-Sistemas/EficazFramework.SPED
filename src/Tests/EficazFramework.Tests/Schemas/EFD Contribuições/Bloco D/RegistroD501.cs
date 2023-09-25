using FluentAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes.BlocoD;

public class RegistroD501 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_Contribuicoes.RegistroD501();
        reg.Codigo.Should().Be("D501");
    }

    
    [TestCase("|D501|50|199,9|03|199,9|1,65|3,3|50038|", "006")]
    public void Construtor(string linha, string versao = "006", bool omitirTributo = false)
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_Contribuicoes.RegistroD501(linha, versao);
        InternalRead(reg, versao, omitirTributo);
    }

    
    [TestCase("|D501|50|199,9|03|199,9|1,65|3,3|50038|", "006")]
    [TestCase("|D501|50|199,9||199,9|1,65||50038|", "006", true)]
    public void Escrita(string result, string versao = "006", bool omitirTributo = false)
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_Contribuicoes.RegistroD501("", versao)
        {
            CSTPis = "50",
            AliquotaPis = 1.65d,
            CodigoContaContabil = "50038",
            NatBcCalculo = NaturezaBaseCalculo.AquisServicosInsumo,
            VrBCPis = 199.9d,
            VrPis = 3.3d,
            VrTotalItens = 199.9d
        };

        if (omitirTributo)
            reg.VrPis = null;
        
        reg.ToString().Should().Be(result);
    }


    [TestCase("|D501|50|199,9|03|199,9|1,65|3,3|50038|", "006")]
    [TestCase("|D501|50|199,9||199,9|1,65||50038|", "006", true)]
    public void Leitura(string linha, string versao = "006", bool omitirTributo = false)
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_Contribuicoes.RegistroD501("", versao);
        reg.VrPis.Should().Be(null);
        reg.NatBcCalculo.Should().Be(NaturezaBaseCalculo.OutOpDireitoCredito);

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao, omitirTributo);
    }

    
    private void InternalRead(EficazFramework.SPED.Schemas.EFD_Contribuicoes.RegistroD501 reg, string versao = "006", bool omitirTributo = false)
    {
        reg.Codigo.Should().Be("D501");
        reg.Versao.Should().Be(versao);
        reg.CSTPis.Should().Be("50");
        reg.CodigoContaContabil.Should().Be("50038");
        reg.VrBCPis.Should().Be(199.9d);
        reg.AliquotaPis.Should().Be(1.65d);
        reg.VrTotalItens.Should().Be(199.9d);
        if (omitirTributo)
        {
            reg.NatBcCalculo.Should().Be(NaturezaBaseCalculo.OutOpDireitoCredito);
            reg.VrPis.Should().BeNull();
        }
        else
        {
            reg.NatBcCalculo.Should().Be(NaturezaBaseCalculo.AquisServicosInsumo);
            reg.VrPis.Should().Be(3.3d);
        }

    }
}
