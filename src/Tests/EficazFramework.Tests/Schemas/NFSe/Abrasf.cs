using EficazFramework.SPED.Tests;

namespace EficazFramework.SPED.Schemas.NFSe;

public class AbrasfTcCompNfse : BaseXmlTest<ABRASF.tcCompNfse>
{
    [Test]
    public async Task Read()
    {
        ABRASF.tcCompNfse instance = await ReadAsync(Resources.Schemas.XML.NFSe_Common);
        instance.Should().NotBeNull();

        instance.Chave.Should().Be("XWXK-LEDO");
        instance.Nfse.InfNfse.Numero.Should().Be("4347");
        instance.Nfse.InfNfse.DataEmissao.Should().BeSameDateAs(new(2025, 02, 26));
        instance.Nfse.InfNfse.ValoresNfse.BaseCalculo.Should().Be(51615.88M);
        instance.Nfse.InfNfse.ValoresNfse.Aliquota.Should().Be(3M);
        instance.Nfse.InfNfse.ValoresNfse.ValorIss.Should().Be(1548.48M);
        instance.Nfse.InfNfse.ValoresNfse.ValorLiquidoNfse.Should().Be(48441.5M);
        instance.Nfse.InfNfse.PrestadorServico.IdentificacaoPrestador.CpfCnpj.Identificador.Should().Be("12.398.333/0001-08");
        instance.Nfse.InfNfse.PrestadorServico.IdentificacaoPrestador.InscricaoMunicipal.Should().Be("0");
        instance.Nfse.InfNfse.PrestadorServico.RazaoSocial.Should().Be("CODEBIT DESENVOLVIMENTO DE SOFTWARES CUSTOMIZADOS LTDA");
        instance.Nfse.InfNfse.PrestadorServico.NomeFantasia.Should().Be("CODEBIT DESENVOLVIMENTO DE SOFTWARES CUSTOMIZADOS LTDA");
        instance.Nfse.InfNfse.PrestadorServico.Endereco.Uf.Should().Be("SP");
        instance.Nfse.InfNfse.Declaracao.Should().NotBeNull();
        instance.Nfse.InfNfse.Declaracao.InfNfse.Prestador.CpfCnpj.Identificador.Should().Be("12.398.333/0001-08");
        instance.Nfse.InfNfse.Declaracao.InfNfse.Tomador.IdentificacaoTomador.CpfCnpj.Identificador.Should().Be("29302348000115");
        instance.Nfse.InfNfse.Declaracao.InfNfse.Servico.ItemListaServico.Should().Be("1.01");
        instance.Nfse.InfNfse.Declaracao.InfNfse.Servico.Valores.ValorServicos.Should().Be(51615.88M);
        instance.Nfse.InfNfse.Declaracao.InfNfse.Servico.Valores.ValorDeducoes.Should().Be(0M);
        instance.Nfse.InfNfse.Declaracao.InfNfse.Servico.Valores.ValorPis.Should().Be(335.50M);
        instance.Nfse.InfNfse.Declaracao.InfNfse.Servico.Valores.ValorCofins.Should().Be(1548.48M);
        instance.Nfse.InfNfse.Declaracao.InfNfse.Servico.Valores.ValorInss.Should().Be(0M);
        instance.Nfse.InfNfse.Declaracao.InfNfse.Servico.Valores.ValorIr.Should().Be(774.24M);
        instance.Nfse.InfNfse.Declaracao.InfNfse.Servico.Valores.ValorCsll.Should().Be(516.16M);
        instance.Nfse.InfNfse.Declaracao.InfNfse.Servico.Valores.OutrasRetencoes.Should().Be(0M);
        instance.Nfse.InfNfse.Declaracao.InfNfse.Servico.Valores.ValorIss.Should().Be(1548.48M);
        instance.Nfse.InfNfse.Declaracao.InfNfse.Servico.Valores.Aliquota.Should().Be(3M);
        instance.Nfse.InfNfse.Declaracao.InfNfse.Servico.IssRetido.Should().Be(2);
    }
}

public class AbrasfConsultarNFseResposta : BaseXmlTest<ABRASF.ConsultarNFseResposta>
{
    [Test]
    public async Task ReadLote()
    {
        ABRASF.ConsultarNFseResposta instance = await ReadAsync(Resources.Schemas.XML.NFse_Abrasf_lote);
        instance.Should().NotBeNull();
        ((ABRASF.ConsultarNFseResposta)instance).Documentos.Items.Should().HaveCount(10);
        foreach (var item in ((ABRASF.ConsultarNFseResposta)instance).Documentos.Items)
        {
            item.Nfse.InfNfse.ValoresNfse.ValorLiquidoNfse.Should().BeGreaterThan(0.0m);
            item.Nfse.InfNfse.Declaracao.InfNfse.Servico.Valores.ValorServicos.Should().BeGreaterThan(0.0m);
        }
    }

    [Test]
    public async Task ReadLote2()
    {
        ABRASF.ConsultarNFseResposta instance = await ReadAsync(Resources.Schemas.XML.NFe_Abrasf_New);
        instance.Should().NotBeNull();
        ((ABRASF.ConsultarNFseResposta)instance).Documentos.Items.Should().HaveCount(27);
        foreach (var item in ((ABRASF.ConsultarNFseResposta)instance).Documentos.Items)
        {
            item.Nfse.InfNfse.ValoresNfse.ValorLiquidoNfse.Should().BeGreaterThan(0.0m);
            item.Nfse.InfNfse.Declaracao.InfNfse.Servico.Valores.ValorServicos.Should().BeGreaterThan(0.0m);
        }
    }

}

