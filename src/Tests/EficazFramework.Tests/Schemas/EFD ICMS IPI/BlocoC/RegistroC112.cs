using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC112 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC112();
        reg.Codigo.Should().Be("C112");
    }

    [TestCase("|C112|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC112(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C112|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC112("", versao)
        {
            Codigo_Modelo_Doc_Arrec = CodigoModeloDocArrec.DAE,
            UF = "MG",
            Numero = "123456",
            Cod_Autent_Bancaria = "AUT123",
            Vr_Doc_Arrec = 150.0d,
            Data_Vecto = new System.DateTime(2022, 11, 10),
            Data_Pgto = new System.DateTime(2022, 11, 8)
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C112|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC112("", versao);
        reg.UF.Should().BeNull();
        reg.Numero.Should().BeNull();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC112 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C112");
        reg.Versao.Should().Be(versao);
    }
}
