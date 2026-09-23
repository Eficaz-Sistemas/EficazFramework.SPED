using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoD;

public class RegistroD110 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD110();
        reg.Codigo.Should().Be("D110");
    }

    [TestCase("|D110|1|PROD01|100|0|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD110(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|D110|1|PROD01|100|0|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD110("", versao)
        {
            NumeroSequencialItem = 1,
            CodigoProduto = "PROD01",
            ValorServico = 100.0d,
            OutrosValores = 0.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|D110|1|PROD01|100|0|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD110("", versao);
        reg.CodigoProduto.Should().BeNull();
        reg.ValorServico.HasValue.Should().BeFalse();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD110 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("D110");
        reg.Versao.Should().Be(versao);
        reg.NumeroSequencialItem.Should().Be(1);
        reg.CodigoProduto.Should().Be("PROD01");
        reg.ValorServico.Should().Be(100.0d);
        reg.OutrosValores.Should().Be(0.0d);
    }
}
