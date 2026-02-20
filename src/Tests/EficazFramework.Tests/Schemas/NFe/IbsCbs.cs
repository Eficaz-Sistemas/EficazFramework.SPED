using EficazFramework.SPED.Tests;

namespace EficazFramework.SPED.Schemas.NFe.RTC;

internal class IbsCbs : BaseXmlTest<ProcessoNFe>
{

    [Test]
    public async Task ParseIbsCbsTribNormalTest()
    {
        ProcessoNFe instance = await ReadAsync(Resources.Schemas.XML.NFeIbsCbs_202510);
        instance.Should().NotBeNull();

        instance.NFe.InformacoesNFe.Items[0].ValorItem.Should().Be(10.0m);
        instance.NFe.InformacoesNFe.Items[0].Imposto.IBSCBS.CST.Should().Be(DFeBase.Cst.CST_000);
        instance.NFe.InformacoesNFe.Items[0].Imposto.IBSCBS.cClassTrib.Should().Be("000001");

        instance.NFe.InformacoesNFe.Items[0].Imposto.IBSCBS.gIBSCBS.Should().NotBeNull();
        instance.NFe.InformacoesNFe.Items[0].Imposto.IBSCBS.gIBSCBS.vBC.Should().Be(12.0m);
        instance.NFe.InformacoesNFe.Items[0].Imposto.IBSCBS.gIBSCBS.gIBSUF.gDevTrib.Should().BeNull();
        instance.NFe.InformacoesNFe.Items[0].Imposto.IBSCBS.gIBSCBS.gIBSUF.gDif.Should().BeNull();
        instance.NFe.InformacoesNFe.Items[0].Imposto.IBSCBS.gIBSCBS.gIBSUF.gRed.Should().BeNull();
        instance.NFe.InformacoesNFe.Items[0].Imposto.IBSCBS.gIBSCBS.gIBSUF.pIBSUF.Should().Be(0.1m);
        instance.NFe.InformacoesNFe.Items[0].Imposto.IBSCBS.gIBSCBS.gIBSUF.vIBSUF.Should().Be(0.01m);
        instance.NFe.InformacoesNFe.Items[0].Imposto.IBSCBS.gIBSCBS.gIBSMun.gDevTrib.Should().BeNull();
        instance.NFe.InformacoesNFe.Items[0].Imposto.IBSCBS.gIBSCBS.gIBSMun.gDif.Should().BeNull();
        instance.NFe.InformacoesNFe.Items[0].Imposto.IBSCBS.gIBSCBS.gIBSMun.gRed.Should().BeNull();
        instance.NFe.InformacoesNFe.Items[0].Imposto.IBSCBS.gIBSCBS.gIBSMun.pIBSMun.Should().Be(0.0m);
        instance.NFe.InformacoesNFe.Items[0].Imposto.IBSCBS.gIBSCBS.gIBSMun.vIBSMun.Should().Be(0.0m);

        instance.NFe.InformacoesNFe.Items[0].Imposto.IBSCBS.gIBSCBS.gCBS.Should().NotBeNull();
        instance.NFe.InformacoesNFe.Items[0].Imposto.IBSCBS.gIBSCBS.gCBS.gDevTrib.Should().BeNull();
        instance.NFe.InformacoesNFe.Items[0].Imposto.IBSCBS.gIBSCBS.gCBS.gDif.Should().BeNull();
        instance.NFe.InformacoesNFe.Items[0].Imposto.IBSCBS.gIBSCBS.gCBS.gRed.Should().BeNull();
        instance.NFe.InformacoesNFe.Items[0].Imposto.IBSCBS.gIBSCBS.gCBS.pCBS.Should().Be(0.9m);
        instance.NFe.InformacoesNFe.Items[0].Imposto.IBSCBS.gIBSCBS.gCBS.vCBS.Should().Be(0.11m);


    }

    [Test]
    public async Task ParseIbsCbsTotaisTest()
    {
        ProcessoNFe instance = await ReadAsync(Resources.Schemas.XML.NFeIbsCbs_202510);
        instance.Should().NotBeNull();

        instance.NFe.InformacoesNFe.Totais.IBSCBSTot.gCBS.vCBS.Should().Be(0.42m);
        instance.NFe.InformacoesNFe.Totais.IBSCBSTot.gCBS.vCredPres.Should().Be(0.0m);
        instance.NFe.InformacoesNFe.Totais.IBSCBSTot.gCBS.vCredPresCondSus.Should().Be(0.0m);
        instance.NFe.InformacoesNFe.Totais.IBSCBSTot.gCBS.vDevTrib.Should().Be(0.0m);
        instance.NFe.InformacoesNFe.Totais.IBSCBSTot.gCBS.vDif.Should().Be(0.0m);

        instance.NFe.InformacoesNFe.Totais.IBSCBSTot.gIBS.gIBSMun.vDevTrib.Should().Be(0.0m);
        instance.NFe.InformacoesNFe.Totais.IBSCBSTot.gIBS.gIBSMun.vDif.Should().Be(0.0m);
        instance.NFe.InformacoesNFe.Totais.IBSCBSTot.gIBS.gIBSMun.vIBSMun.Should().Be(0.0m);

        instance.NFe.InformacoesNFe.Totais.IBSCBSTot.gIBS.gIBSUF.vDevTrib.Should().Be(0.0m);
        instance.NFe.InformacoesNFe.Totais.IBSCBSTot.gIBS.gIBSUF.vDif.Should().Be(0.0m);
        instance.NFe.InformacoesNFe.Totais.IBSCBSTot.gIBS.gIBSUF.vIBSUF.Should().Be(0.04m);

        instance.NFe.InformacoesNFe.Totais.IBSCBSTot.gIBS.vCredPres.Should().Be(0.0m);
        instance.NFe.InformacoesNFe.Totais.IBSCBSTot.gIBS.vCredPresCondSus.Should().Be(0.0m);
        instance.NFe.InformacoesNFe.Totais.IBSCBSTot.gIBS.vIBS.Should().Be(0.04m);

        instance.NFe.InformacoesNFe.Totais.IBSCBSTot.gMono.Should().BeNull();
        instance.NFe.InformacoesNFe.Totais.IBSCBSTot.vBCIBSCBS.Should().Be(46.0m);
    }

}
