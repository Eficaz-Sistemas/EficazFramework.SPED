using AwesomeAssertions;
using NUnit.Framework;
using System;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoB;

public class RegistroB350 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB350();
        reg.Codigo.Should().Be("B350");
    }

    [TestCase("|B350|1|1|1|1|1|1000,00|1000,00|1000,00|1000,00|1|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB350(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|B350|1|1|1|1|1|1000|1000|1000|1000|1|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB350("", versao)
        {
            CodContaPlano = "1",
            DescContaPlano = "1",
            CodCosifInstFin = "1",
            QuantOcorrConta = 1,
            CodServico = "1",
            ValorContabil = 1000.0,
            ValorBCISS = 1000.0,
            AliquotaISS = 1000.0,
            ValorISS = 1000.0,
            CodObsLacto = "1"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|B350|1|1|1|1|1|1000,00|1000,00|1000,00|1000,00|1|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB350("", versao);
        reg.CodContaPlano.Should().BeNull();
        reg.DescContaPlano.Should().BeNull();
        reg.CodCosifInstFin.Should().BeNull();
        reg.CodServico.Should().BeNull();
        reg.CodObsLacto.Should().BeNull();
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB350 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("B350");
        reg.Versao.Should().Be(versao);
        reg.CodContaPlano.Should().Be("1");
        reg.DescContaPlano.Should().Be("1");
        reg.CodCosifInstFin.Should().Be("1");
        reg.QuantOcorrConta.Should().Be(1);
        reg.CodServico.Should().Be("1");
        reg.ValorContabil.Should().Be(1000.0);
        reg.ValorBCISS.Should().Be(1000.0);
        reg.AliquotaISS.Should().Be(1000.0);
        reg.ValorISS.Should().Be(1000.0);
        reg.CodObsLacto.Should().Be("1");
    }
}
