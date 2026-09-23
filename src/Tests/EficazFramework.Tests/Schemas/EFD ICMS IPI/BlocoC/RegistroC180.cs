using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC180 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC180();
        reg.Codigo.Should().Be("C180");
    }

    [TestCase("|C180|3|10|UN|100|100|120|21,6|0|0|123456|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC180(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C180|3|10|UN|100|100|120|21,6|0|0|123456|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC180("", versao)
        {
            CodRespRetencao = CodRespRetStC180.Proprio_Declarante,
            QuantidadeItem = 10.0d,
            Unidade = "UN",
            VrUnitario = 100.0d,
            VrUnitarioOpPropria = 100.0d,
            VrUnitarioBcICMSSt = 120.0d,
            VrUnitarioICMSSt = 21.6d,
            VrUnitarioFCPStAgregado = 0.0d,
            CodigoDocArrecad = CodigoDocArrecadC180.Documento_Estadual,
            NumeroDocArrecad = "123456"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C180|3|10|UN|100|100|120|21,6|0|0|123456|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC180("", versao);
        reg.Unidade.Should().BeNull();
        reg.QuantidadeItem.HasValue.Should().BeFalse();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC180 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C180");
        reg.Versao.Should().Be(versao);
        reg.CodRespRetencao.Should().Be(CodRespRetStC180.Proprio_Declarante);
        reg.QuantidadeItem.Should().Be(10.0d);
        reg.Unidade.Should().Be("UN");
        reg.VrUnitario.Should().Be(100.0d);
        reg.VrUnitarioOpPropria.Should().Be(100.0d);
        reg.VrUnitarioBcICMSSt.Should().Be(120.0d);
        reg.VrUnitarioICMSSt.Should().Be(21.6d);
        reg.VrUnitarioFCPStAgregado.Should().Be(0.0d);
        reg.CodigoDocArrecad.Should().Be(CodigoDocArrecadC180.Documento_Estadual);
        reg.NumeroDocArrecad.Should().Be("123456");
    }
}
