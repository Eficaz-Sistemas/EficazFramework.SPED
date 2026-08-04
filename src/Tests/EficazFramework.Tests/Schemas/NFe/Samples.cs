using System;
using System.IO;
using System.Threading.Tasks;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.NFe;

public class Samples : EficazFramework.SPED.Tests.BaseXmlTest<ProcessoNFe>
{
    private string GetNfePath(string fileName)
    {
        return Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "Samples", "NFe", fileName);
    }

    [Test]
    public async Task ParseNFeSample001()
    {
        string path = GetNfePath("001.xml");
        string xml = await File.ReadAllTextAsync(path);
        ProcessoNFe instance = await ReadAsync(xml);
        instance.Should().NotBeNull();

        instance.Chave.Should().Be("99999999999999999999999999999999999999999999");
        instance.NFe.InformacoesNFe.Id.Should().Be("NFe99999999999999999999999999999999999999999999");
        instance.NFe.InformacoesNFe.Versao.Should().Be("4.00");

        var ide = instance.NFe.InformacoesNFe.IdentificacaoOperacao;
        ide.UF.Should().Be(OrgaoIBGE.SP);
        ide.Chave.Should().Be("12345678");
        ide.NaturezaOperacao.Should().Be("DEVOLUCAO DE VENDA");
        ide.Modelo.Should().Be(ModeloDocumento.NFe);
        ide.Serie.Should().Be(99);
        ide.Numero.Should().Be(99999);
        ide.DataHoraEmissao.Should().BeSameDateAs(new DateTime(2025, 3, 3));
        ide.Finalidade.Should().Be(FinalidadeEmissao.Devolucao);
        ide.ConsumidorFinal.Should().Be(IndicadorConsumidorFinal.Sim);

        var emit = instance.NFe.InformacoesNFe.Emitente;
        emit.CNPJ_CPF.Should().Be("12345678000199");
        emit.RazaoSocial.Should().Be("EMPRESA FICTICIA LTDA");
        emit.InscricaoEstadual.Should().Be("123456789000");

        var dest = instance.NFe.InformacoesNFe.Destinatario;
        dest.CNPJ_CPF.Should().Be("00011122233");
        dest.RazaoSocial.Should().Be("JOAO SILVA");

        var item = instance.NFe.InformacoesNFe.Items[0];
        item.NumeroSequencial.Should().Be("1");
        item.Dados.Codigo.Should().Be("999999");
        item.Dados.Descricao.Should().Be("PRODUTO FICTICIO TESTE");
        item.Dados.NCM.Should().Be("00000000");
        item.Dados.CFOP.Should().Be("2202");
        item.Dados.UnidadeComercial.Should().Be("UN");
        item.Dados.QuantidadeComercial.Should().Be(1.0);
        item.Dados.ValorUnitarioComercial.Should().Be(5723.99);
        item.Dados.ValorTotalBruto.Should().Be(5723.99);
        item.Dados.ValorFrete.Should().Be(377.03);

        item.Imposto.ICMS.Tributacao.Origem.Should().Be(OrigemMercadoria.Nacional);
        item.Imposto.ICMS.Tributacao.CST.Should().Be(CST_ICMS.CST_20);
        item.Imposto.ICMS.Tributacao.vBC.Should().Be(4473.88);
        item.Imposto.ICMS.Tributacao.pICMS.Should().Be(12.00);
        item.Imposto.ICMS.Tributacao.vICMS.Should().Be(536.87);

        item.Imposto.PIS.Tributacao.CST.Should().Be(CST_PIS.CreditoTribMercadoInterno);
        item.Imposto.PIS.Tributacao.vBC.Should().Be(5446.25);
        item.Imposto.PIS.Tributacao.pPIS.Should().Be(1.65);
        item.Imposto.PIS.Tributacao.vPIS.Should().Be(89.86);

        item.Imposto.COFINS.Tributacao.CST.Should().Be(CST_COFINS.CreditoTribMercadoInterno);
        item.Imposto.COFINS.Tributacao.vBC.Should().Be(5446.25);
        item.Imposto.COFINS.Tributacao.pCOFINS.Should().Be(7.60);
        item.Imposto.COFINS.Tributacao.vCOFINS.Should().Be(413.92);

        item.Imposto.ICMSUFDestino.BaseCalculoUFDestino.Should().Be(3637.55);
        item.Imposto.ICMSUFDestino.ValorICMS_UFRemetente.Should().Be(117.90);

        var total = instance.NFe.InformacoesNFe.Totais.ICMS;
        total.BaseDeCalculo.Should().Be(4473.88);
        total.ICMS.Should().Be(536.87);
        total.Produtos.Should().Be(5723.99);
        total.Frete.Should().Be(377.03);
        total.PIS.Should().Be(89.86);
        total.COFINS.Should().Be(413.92);
        total.TotalNF.Should().Be(6101.02);
    }

    [Test]
    public async Task ParseNFeSample002()
    {
        string path = GetNfePath("002.xml");
        string xml = await File.ReadAllTextAsync(path);
        ProcessoNFe instance = await ReadAsync(xml);
        instance.Should().NotBeNull();

        instance.NFe.InformacoesNFe.Versao.Should().Be("4.00");

        var ide = instance.NFe.InformacoesNFe.IdentificacaoOperacao;
        ide.UF.Should().Be(OrgaoIBGE.SP);
        ide.NaturezaOperacao.Should().Be("VENDA DE MERCADORIA");
        ide.Modelo.Should().Be(ModeloDocumento.NFe);
        ide.Numero.Should().Be(99999);

        var emit = instance.NFe.InformacoesNFe.Emitente;
        emit.CNPJ_CPF.Should().Be("11111111000111");
        emit.RazaoSocial.Should().Be("EMPRESA FAKE LTDA");

        var dest = instance.NFe.InformacoesNFe.Destinatario;
        dest.CNPJ_CPF.Should().Be("22222222000222");
        dest.RazaoSocial.Should().Be("CLIENTE FAKE S.A.");

        var item = instance.NFe.InformacoesNFe.Items[0];
        item.Dados.Codigo.Should().Be("11882");
        item.Dados.Descricao.Should().Be("SH LIXADEIRA PAREDE E TETO SUPER LEVE TURBO C/ COLETOR 1200W 900B");
        item.Dados.QuantidadeComercial.Should().Be(2.0);
        item.Dados.ValorTotalBruto.Should().Be(3980.00);

        item.Imposto.ICMS.Tributacao.CST.Should().Be(CST_ICMS.CST_20);
        item.Imposto.ICMS.Tributacao.vBC.Should().Be(1945.82);
        item.Imposto.ICMS.Tributacao.pICMS.Should().Be(18.00);
        item.Imposto.ICMS.Tributacao.vICMS.Should().Be(350.25);

        // IBS/CBS assertions
        var ibscbs = item.Imposto.IBSCBS;
        ibscbs.Should().NotBeNull();
        ibscbs.CST.Should().Be(DFeBase.Cst.CST_000);
        ibscbs.cClassTrib.Should().Be("000001");
        ibscbs.gIBSCBS.vBC.Should().Be(3294.00m);
        ibscbs.gIBSCBS.gIBSUF.pIBSUF.Should().Be(0.1000m);
        ibscbs.gIBSCBS.gIBSUF.vIBSUF.Should().Be(3.29m);
        ibscbs.gIBSCBS.gIBSMun.pIBSMun.Should().Be(0.0000m);
        ibscbs.gIBSCBS.gIBSMun.vIBSMun.Should().Be(0.00m);
        ibscbs.gIBSCBS.vIBS.Should().Be(3.29m);
        ibscbs.gIBSCBS.gCBS.pCBS.Should().Be(0.9000m);
        ibscbs.gIBSCBS.gCBS.vCBS.Should().Be(29.65m);

        var total = instance.NFe.InformacoesNFe.Totais;
        total.ICMS.TotalNF.Should().Be(3980.00);
        total.IBSCBSTot.vBCIBSCBS.Should().Be(3294.00m);
        total.IBSCBSTot.gIBS.gIBSUF.vIBSUF.Should().Be(3.29m);
        total.IBSCBSTot.gIBS.gIBSMun.vIBSMun.Should().Be(0.00m);
        total.IBSCBSTot.gIBS.vIBS.Should().Be(3.29m);
        total.IBSCBSTot.gCBS.vCBS.Should().Be(29.65m);
        total.vNFTot.Should().Be(3980.00m);
    }

    [Test]
    public async Task ParseNFeSample003()
    {
        string path = GetNfePath("003.xml");
        string xml = await File.ReadAllTextAsync(path);
        ProcessoNFe instance = await ReadAsync(xml);
        instance.Should().NotBeNull();

        var ide = instance.NFe.InformacoesNFe.IdentificacaoOperacao;
        ide.NaturezaOperacao.Should().Be("VENDA DE MERCADORIA");
        ide.Numero.Should().Be(99999);

        var emit = instance.NFe.InformacoesNFe.Emitente;
        emit.CNPJ_CPF.Should().Be("11111111000111");
        emit.RazaoSocial.Should().Be("EMPRESA DEMO INDUSTRIAL LTDA");

        var dest = instance.NFe.InformacoesNFe.Destinatario;
        dest.CNPJ_CPF.Should().Be("22222222000222");
        dest.RazaoSocial.Should().Be("CLIENTE DEMO INDUSTRIAL S.A.");

        instance.NFe.InformacoesNFe.Items.Should().HaveCount(2);

        var item1 = instance.NFe.InformacoesNFe.Items[0];
        item1.Dados.Codigo.Should().Be("11907");
        item1.Dados.Descricao.Should().Be("SH AIRLESS PORTATIL REF. SH204 BIVOLT");
        item1.Dados.QuantidadeComercial.Should().Be(4.0);
        item1.Dados.ValorTotalBruto.Should().Be(10480.00);
        item1.Imposto.IBSCBS.gIBSCBS.vBC.Should().Be(8673.65m);
        item1.Imposto.IBSCBS.gIBSCBS.gIBSUF.vIBSUF.Should().Be(8.67m);
        item1.Imposto.IBSCBS.gIBSCBS.gCBS.vCBS.Should().Be(78.06m);

        var item2 = instance.NFe.InformacoesNFe.Items[1];
        item2.Dados.Codigo.Should().Be("11303");
        item2.Dados.Descricao.Should().Be("SH LIXADEIRA PAREDE BLACK STONE HAMMER ROTO ORBITAL 220V");
        item2.Dados.QuantidadeComercial.Should().Be(5.0);
        item2.Dados.ValorTotalBruto.Should().Be(7150.00);
        item2.Imposto.IBSCBS.gIBSCBS.vBC.Should().Be(5917.61m);
        item2.Imposto.IBSCBS.gIBSCBS.gIBSUF.vIBSUF.Should().Be(5.92m);
        item2.Imposto.IBSCBS.gIBSCBS.gCBS.vCBS.Should().Be(53.26m);

        var total = instance.NFe.InformacoesNFe.Totais;
        total.ICMS.TotalNF.Should().Be(17630.00);
        total.IBSCBSTot.vBCIBSCBS.Should().Be(14591.26m);
        total.IBSCBSTot.gIBS.gIBSUF.vIBSUF.Should().Be(14.59m);
        total.IBSCBSTot.gIBS.gIBSMun.vIBSMun.Should().Be(0.00m);
        total.IBSCBSTot.gIBS.vIBS.Should().Be(14.59m);
        total.IBSCBSTot.gCBS.vCBS.Should().Be(131.32m);
        total.vNFTot.Should().Be(17630.00m);
    }

    [Test]
    public async Task ParseNFeSample004()
    {
        string path = GetNfePath("004.xml");
        string xml = await File.ReadAllTextAsync(path);
        ProcessoNFe instance = await ReadAsync(xml);
        instance.Should().NotBeNull();

        var ide = instance.NFe.InformacoesNFe.IdentificacaoOperacao;
        ide.NaturezaOperacao.Should().Be("NOTA DEBITO JUROS E MULTA");
        ide.Numero.Should().Be(1088999);
        ide.Finalidade.Should().Be(FinalidadeEmissao.NotaDebito); // finNFe = 6 (Nota de Debito)

        var emit = instance.NFe.InformacoesNFe.Emitente;
        emit.CNPJ_CPF.Should().Be("01501125000168");
        emit.RazaoSocial.Should().Be("PRODUTOS HIDRAULICOS LTDA");

        var dest = instance.NFe.InformacoesNFe.Destinatario;
        dest.CNPJ_CPF.Should().Be("12123456000100");
        dest.RazaoSocial.Should().Be("ADMINISTRACAO DE BENS PROPRIOS LTDA");

        instance.NFe.InformacoesNFe.Items.Should().HaveCount(3);
        
        var item3 = instance.NFe.InformacoesNFe.Items[2];
        item3.Dados.Codigo.Should().Be("60586");
        item3.Dados.Descricao.Should().Be("TOMADA 1176 2P+T PADR BRASIL 20A  S/P VERMELHA (SC) BARI");
        item3.Dados.ValorTotalBruto.Should().Be(0.01);
        item3.Imposto.IBSCBS.gIBSCBS.vBC.Should().Be(0.01m);

        var total = instance.NFe.InformacoesNFe.Totais;
        total.IBSCBSTot.vBCIBSCBS.Should().Be(0.01m);
        total.vNFTot.Should().Be(0.21m);
    }
}
