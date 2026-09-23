using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC420 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC420();
        reg.Codigo.Should().Be("C420");
    }

    [TestCase("|C420|T1800|1000|1|Tributado ICMS 18%|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC420(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C420|T1800|1000|1|Tributado ICMS 18%|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC420("", versao)
        {
            CodigoTotalizador = "T1800",
            ValorAcumulado = 1000.0d,
            Numero = 1,
            Descricao = "Tributado ICMS 18%"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C420|T1800|1000|1|Tributado ICMS 18%|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC420("", versao);
        reg.CodigoTotalizador.Should().BeNull();
        reg.ValorAcumulado.HasValue.Should().BeFalse();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC420 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C420");
        reg.Versao.Should().Be(versao);
        reg.CodigoTotalizador.Should().Be("T1800");
        reg.ValorAcumulado.Should().Be(1000.0d);
        reg.Numero.Should().Be(1);
        reg.Descricao.Should().Be("Tributado ICMS 18%");
    }
}
