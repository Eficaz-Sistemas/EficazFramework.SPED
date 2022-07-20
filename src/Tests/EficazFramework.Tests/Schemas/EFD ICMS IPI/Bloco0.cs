using FluentAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

public class Bloco0 : Tests.BaseTest
{

    [Test]
    public void Registro0220()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0220("", "015")
        {
            UnidadeComercialConvertida = "To",
            FatorConversao = 1000d,
            CodigoBarras = "0110110"
        };
        reg.ToString().Should().Be("|0220|To|1000|");

        reg.OverrideVersao("016");
        reg.ToString().Should().Be("|0220|To|1000|0110110|");
    }
}
