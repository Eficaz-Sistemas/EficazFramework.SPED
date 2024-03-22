using EficazFramework.SPED.Schemas.NFe;
using EficazFramework.SPED.Tests;

namespace EficazFramework.SPED.Schemas.NFe.Tributos;

public class Icms : BaseXmlTest<ProcessoNFe>
{

    [Test]
    public async Task MonofasicoCombustiveis()
    {
        ProcessoNFe instance = await ReadAsync(Resources.Schemas.XML.NFCeNt2023_001);
        instance.Should().NotBeNull();
        ((EficazFramework.SPED.Schemas.NFe.DetalhamentoICMS)instance.NFe.InformacoesNFe.Items[0].Imposto.IcmsIpiIssqnIi[0]).Tributacao.Origem.Should().Be(OrigemMercadoria.Nacional);
        ((EficazFramework.SPED.Schemas.NFe.DetalhamentoICMS)instance.NFe.InformacoesNFe.Items[0].Imposto.IcmsIpiIssqnIi[0]).Tributacao.CST.Should().Be(CST_ICMS.CST_61);
        ((EficazFramework.SPED.Schemas.NFe.DetalhamentoICMS)instance.NFe.InformacoesNFe.Items[0].Imposto.IcmsIpiIssqnIi[0]).Tributacao.qBCMonoRet.Should().Be(16.761d);
        ((EficazFramework.SPED.Schemas.NFe.DetalhamentoICMS)instance.NFe.InformacoesNFe.Items[0].Imposto.IcmsIpiIssqnIi[0]).Tributacao.adRemICMSRet.Should().Be(1.2200d);
        ((EficazFramework.SPED.Schemas.NFe.DetalhamentoICMS)instance.NFe.InformacoesNFe.Items[0].Imposto.IcmsIpiIssqnIi[0]).Tributacao.vICMSMonoRet.Should().Be(20.44d);
    }

}
