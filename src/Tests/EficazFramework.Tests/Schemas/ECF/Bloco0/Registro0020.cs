using FluentAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.Bloco0;

public class Registro0020 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.Registro0020();
        reg.Codigo.Should().Be("0020");
    }

    
    [TestCase("|0020|1||N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|", "00009")]
    [TestCase("|0020|1||N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.Registro0020("", versao) { };
        reg.ToString().Should().Be(result);
    }

}
