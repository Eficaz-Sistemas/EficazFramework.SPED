using FluentAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes.BlocoD;

public class RegistroD505 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_Contribuicoes.RegistroD505();
        reg.Codigo.Should().Be("D505");
    }

    
    [TestCase("|D505|50|199,9|03|199,9|7,6|15,19|50038|", "006")]
    public void Construtor(string linha, string versao = "006", bool omitirTributo = false)
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_Contribuicoes.RegistroD505(linha, versao);
        InternalRead(reg, versao, omitirTributo);
    }

    
    [TestCase("|D505|50|199,9|03|199,9|7,6|15,19|50038|", "006")]
    [TestCase("|D505|50|199,9||199,9|7,6||50038|", "006", true)]
    public void Escrita(string result, string versao = "006", bool omitirTributo = false)
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_Contribuicoes.RegistroD505("", versao)
        {
            CSTCofins = "50",
            AliquotaCofins = 7.6d,
            CodigoContaContabil = "50038",
            NatBcCalculo = NaturezaBaseCalculo.AquisServicosInsumo,
            VrBCCofins = 199.9d,
            VrCofins = 15.19d,
            VrTotalItens = 199.9d
        };

        if (omitirTributo)
            reg.VrCofins = null;
        
        reg.ToString().Should().Be(result);
    }


    [TestCase("|D505|50|199,9|03|199,9|7,6|15,19|50038|", "006")]
    [TestCase("|D505|50|199,9||199,9|7,6||50038|", "006", true)]
    public void Leitura(string linha, string versao = "006", bool omitirTributo = false)
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_Contribuicoes.RegistroD505("", versao);
        reg.VrCofins.Should().Be(null);
        reg.NatBcCalculo.Should().Be(NaturezaBaseCalculo.OutOpDireitoCredito);

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao, omitirTributo);
    }

    
    private void InternalRead(EficazFramework.SPED.Schemas.EFD_Contribuicoes.RegistroD505 reg, string versao = "006", bool omitirTributo = false)
    {
        reg.Codigo.Should().Be("D505");
        reg.Versao.Should().Be(versao);
        reg.CSTCofins.Should().Be("50");
        reg.CodigoContaContabil.Should().Be("50038");
        reg.AliquotaCofins.Should().Be(7.6d);
        reg.VrBCCofins.Should().Be(199.9d);
        reg.VrTotalItens.Should().Be(199.9d);
        if (omitirTributo)
        {
            reg.NatBcCalculo.Should().Be(NaturezaBaseCalculo.OutOpDireitoCredito);
            reg.VrCofins.Should().BeNull();
        }
        else
        {
            reg.NatBcCalculo.Should().Be(NaturezaBaseCalculo.AquisServicosInsumo);
            reg.VrCofins.Should().Be(15.19d);
        }

    }
}
