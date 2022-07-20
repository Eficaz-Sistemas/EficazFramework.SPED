using FluentAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

public class Bloco1 : Tests.BaseTest
{

    [Test]
    public void Registro1601()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1601("", "016")
        {
            CodigoParticipante = "456",
            CodigoParticipanteIntermediador = "789",
            TotalBrutoIncIcms = 539.555d,
            TotalBrutoIncIss = 100d,
            TotalOutros = 1.5d
        };
        reg.ToString().Should().Be("|1601|456|789|539,56|100|1,5|");
    }
}
