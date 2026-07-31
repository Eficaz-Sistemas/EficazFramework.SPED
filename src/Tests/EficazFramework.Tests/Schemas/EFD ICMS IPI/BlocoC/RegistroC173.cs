using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC173 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC173();
        reg.Codigo.Should().Be("C173");
    }

    [TestCase("|C173|LOTE123|100|01012022|01012024|0|0|50|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC173(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C173|LOTE123|100|01/01/2022 00:00:00|01/01/2024 00:00:00|0|0|50|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC173("", versao)
        {
            NumLoteFabricMedic = "LOTE123",
            QtdeItemLote = 100.0d,
            DataFabricMedic = new System.DateTime(2022, 1, 1),
            DataExpValidMedic = new System.DateTime(2024, 1, 1),
            IndicadorTipoCalculoST = IndicadorTipoCalculoST.Base_Calculo_Preco,
            TipoProduto = TipoProduto.Similar,
            VrPrecoTabPrecoMaximo = 50.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C173|LOTE123|100|01012022|01012024|0|0|50|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC173("", versao);
        reg.NumLoteFabricMedic.Should().BeNull();
        reg.QtdeItemLote.HasValue.Should().BeFalse();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC173 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C173");
        reg.Versao.Should().Be(versao);
        reg.NumLoteFabricMedic.Should().Be("LOTE123");
        reg.QtdeItemLote.Should().Be(100.0d);
        reg.DataFabricMedic.Should().Be(new System.DateTime(2022, 1, 1));
        reg.DataExpValidMedic.Should().Be(new System.DateTime(2024, 1, 1));
        reg.IndicadorTipoCalculoST.Should().Be(IndicadorTipoCalculoST.Base_Calculo_Preco);
        reg.VrPrecoTabPrecoMaximo.Should().Be(50.0d);
    }
}
