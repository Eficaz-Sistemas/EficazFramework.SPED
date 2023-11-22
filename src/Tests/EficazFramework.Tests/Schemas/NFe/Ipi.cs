using EficazFramework.SPED.Schemas.NFe;
using EficazFramework.SPED.Tests;

namespace EficazFramework.SPED.Schemas.NFe.Tributos;

public class Ipi : BaseXmlTest<ProcessoNFe>
{
    [Test]
    public async Task ValorDevolvidoAsync()
    {
        ProcessoNFe instance = await ReadAsync(Resources.Schemas.XML.NFeIpiDevolvido);
        instance.Should().NotBeNull();
        instance.NFe.InformacoesNFe.Items.Should().HaveCount(86);
        instance.NFe.InformacoesNFe.Items[0].ImpostoDevolvido.Should().NotBeNull();
        instance.NFe.InformacoesNFe.Items[0].ImpostoDevolvido.pDevol.Should().Be(0.0);
        instance.NFe.InformacoesNFe.Items[0].ImpostoDevolvido.IPI.vIPIDevol.Should().Be(1.4);
        instance.NFe.InformacoesNFe.Items[22].ImpostoDevolvido.Should().NotBeNull();
        instance.NFe.InformacoesNFe.Items[22].ImpostoDevolvido.pDevol.Should().Be(0.0);
        instance.NFe.InformacoesNFe.Items[22].ImpostoDevolvido.IPI.vIPIDevol.Should().Be(59.98);
        instance.NFe.InformacoesNFe.Totais.ICMS.vIPIDevol.Should().Be(1375.71);
        instance.NFe.InformacoesNFe.Items.Sum(dv => dv.ImpostoDevolvido?.IPI?.vIPIDevol ?? 0.00).Should().Be(1375.71);
    }
}
