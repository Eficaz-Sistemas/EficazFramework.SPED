using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC111 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC111();
        reg.Codigo.Should().Be("C111");
    }

    [TestCase("|C111|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC111(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C111|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC111("", versao)
        {
            Ident_Proc_AtoConcessorio = "123456",
            Ind_Origem_Processo = IndicadorOrigemProcesso.SEFAZ
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C111|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC111("", versao);
        reg.Ident_Proc_AtoConcessorio.Should().BeNull();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC111 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C111");
        reg.Versao.Should().Be(versao);
    }
}
