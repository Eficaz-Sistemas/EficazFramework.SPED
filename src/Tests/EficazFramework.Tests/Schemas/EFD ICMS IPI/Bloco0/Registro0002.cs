using FluentAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Bloco0;

public class Registro0002 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0002();
        reg.Codigo.Should().Be("0002");
    }

    
    [TestCase("|0002|02|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0002(linha, versao);
        InternalRead(reg, versao);
    }


    [TestCase("|0002|02|")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0002("", versao)
        {
            ClassificacaoEstabelecimento = TipoDeAtividade.Industrial_Montagem
        };
        reg.ToString().Should().Be(result);

    }


    [TestCase("|0002|02|")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0002("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }


    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0002 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("0002");
        reg.Versao.Should().Be(versao);
        reg.ClassificacaoEstabelecimento.Should().Be(EFD_ICMS_IPI.TipoDeAtividade.Industrial_Montagem);
    }

}
