using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoH;

public class RegistroH030 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        // RegistroH030 é uma classe stub sem implementação — verifica apenas a instanciação
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroH030();
        reg.Should().NotBeNull();
    }
}
