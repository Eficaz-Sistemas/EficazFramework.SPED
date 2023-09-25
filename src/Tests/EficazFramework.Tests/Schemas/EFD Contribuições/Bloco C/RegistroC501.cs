using FluentAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes.BlocoC;

public class RegistroC501 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_Contribuicoes.RegistroC501();
        reg.Codigo.Should().Be("C501");
    }

    
    [TestCase("|C501|50|153,09|04|153,09|1,65|2,53|50036|", "006")]
    public void Construtor(string linha, string versao = "006", bool indicadorContribIcms = false)
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_Contribuicoes.RegistroC501(linha, versao);
        InternalRead(reg, versao, indicadorContribIcms);
    }

    
    [TestCase("|C501|50|153,09|04|153,09|1,65|2,53|50036|", "006")]
    [TestCase("|C501|50|153,09||153,09|1,65||50036|", "006", true)]
    public void Escrita(string result, string versao = "006", bool omitirTributo = false)
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_Contribuicoes.RegistroC501("", versao)
        {
            CstPis = "50",
            AliquotaPis = 1.65d,
            CodContaContabil = "50036",
            NatBaseCalculo = NaturezaBaseCalculo.EnEletrica,
            VrBaseCalculoPis = 153.09d,
            VrPis = 2.53d,
            VrTotalItens = 153.09d
        };

        if (omitirTributo)
            reg.VrPis = null;
        
        reg.ToString().Should().Be(result);
    }


    [TestCase("|C501|50|153,09|04|153,09|1,65|2,53|50036|", "006")]
    [TestCase("|C501|50|153,09||153,09|1,65||50036|", "006", true)]
    public void Leitura(string linha, string versao = "006", bool omitirTributo = false)
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_Contribuicoes.RegistroC501("", versao);
        reg.VrPis.Should().Be(null);
        reg.NatBaseCalculo.Should().Be(NaturezaBaseCalculo.OutOpDireitoCredito);

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao, omitirTributo);
    }

    
    private void InternalRead(EficazFramework.SPED.Schemas.EFD_Contribuicoes.RegistroC501 reg, string versao = "006", bool omitirTributo = false)
    {
        reg.Codigo.Should().Be("C501");
        reg.Versao.Should().Be(versao);
        reg.CstPis.Should().Be("50");
        reg.CodContaContabil.Should().Be("50036");
        reg.VrBaseCalculoPis.Should().Be(153.09d);
        reg.VrTotalItens.Should().Be(153.09d);
        if (omitirTributo)
        {
            reg.NatBaseCalculo.Should().Be(NaturezaBaseCalculo.OutOpDireitoCredito);
            reg.VrPis.Should().BeNull();
        }
        else
        {
            reg.NatBaseCalculo.Should().Be(NaturezaBaseCalculo.EnEletrica);
            reg.VrPis.Should().Be(2.53d);
        }

    }
}
