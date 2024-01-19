using FluentAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.Bloco0;

public class Registro0021 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.Registro0021();
        reg.Codigo.Should().Be("0021");
    }


    [TestCase("|0021|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|", "00009")]
    [TestCase("|0021|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|N|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.Registro0021("", versao) { };
        reg.ToString().Should().Be(result);
    }

}
