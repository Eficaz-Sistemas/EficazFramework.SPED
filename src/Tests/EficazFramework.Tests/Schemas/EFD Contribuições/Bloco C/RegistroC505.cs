using FluentAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes.BlocoC;

public class RegistroC505 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_Contribuicoes.RegistroC505();
        reg.Codigo.Should().Be("C505");
    }

    
    [TestCase("|C505|50|153,09|04|153,09|7,6|11,63|50036|", "006")]
    public void Construtor(string linha, string versao = "006", bool indicadorContribIcms = false)
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_Contribuicoes.RegistroC505(linha, versao);
        InternalRead(reg, versao, indicadorContribIcms);
    }

    
    [TestCase("|C505|50|153,09|04|153,09|7,6|11,63|50036|", "006")]
    [TestCase("|C505|50|153,09||153,09|7,6||50036|", "006", true)]
    public void Escrita(string result, string versao = "006", bool omitirTributo = false)
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_Contribuicoes.RegistroC505("", versao)
        {
            CstCofins = "50",
            AliquotaCofins = 1.65d,
            CodContaContabil = "50036",
            NatBaseCalculo = NaturezaBaseCalculo.EnEletrica,
            VrBaseCalculoCofins = 153.09d,
            VrCofins = 11.63d,
            VrTotalItens = 153.09d
        };

        if (omitirTributo)
            reg.VrCofins = null;
        
        reg.ToString().Should().Be(result);
    }


    [TestCase("|C505|50|153,09|04|153,09|7,6|11,63|50036|", "006")]
    [TestCase("|C505|50|153,09||153,09|7,6||50036|", "006", true)]
    public void Leitura(string linha, string versao = "006", bool omitirTributo = false)
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_Contribuicoes.RegistroC505("", versao);
        reg.CstCofins.Should().Be(null);
        reg.NatBaseCalculo.Should().Be(NaturezaBaseCalculo.OutOpDireitoCredito);

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao, omitirTributo);
    }

    
    private void InternalRead(EficazFramework.SPED.Schemas.EFD_Contribuicoes.RegistroC505 reg, string versao = "006", bool omitirTributo = false)
    {
        reg.Codigo.Should().Be("C505");
        reg.Versao.Should().Be(versao);
        reg.CstCofins.Should().Be("50");
        reg.CodContaContabil.Should().Be("50036");
        reg.VrBaseCalculoCofins.Should().Be(153.09d);
        reg.VrTotalItens.Should().Be(153.09d);
        if (omitirTributo)
        {
            reg.NatBaseCalculo.Should().Be(NaturezaBaseCalculo.OutOpDireitoCredito);
            reg.VrCofins.Should().BeNull();
        }
        else
        {
            reg.NatBaseCalculo.Should().Be(NaturezaBaseCalculo.EnEletrica);
            reg.VrCofins.Should().Be(11.63d);
        }

    }
}
