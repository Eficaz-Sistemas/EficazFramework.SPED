using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC181 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC181();
        reg.Codigo.Should().Be("C181");
    }

    [TestCase("|C181|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC181(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C181|MOT01|10|UN|55|1||123456|35191100000000000000550010001234561001234567|01112022|1|100||||||||||", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC181("", versao)
        {
            CodMotivoRestituicao = "MOT01",
            QuantidadeItem = 10.0d,
            Unidade = "UN",
            EspecieDocSaida = "55",
            SerieDocSaida = "1",
            NumeroDocSaida = 123456,
            ChaveDocSaida = "35191100000000000000550010001234561001234567",
            DataDocSaida = new System.DateTime(2022, 11, 1),
            NumeroItemDocSaida = 1,
            VrUnitarioSaida = 100.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C181|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC181("", versao);
        reg.CodMotivoRestituicao.Should().BeNull();
        reg.QuantidadeItem.HasValue.Should().BeFalse();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC181 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C181");
        reg.Versao.Should().Be(versao);
    }
}
