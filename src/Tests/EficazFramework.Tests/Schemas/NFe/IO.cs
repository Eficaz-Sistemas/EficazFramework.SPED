using EficazFramework.SPED.Schemas.NFe;
using EficazFramework.SPED.Tests;

namespace EficazFramework.SPED.Schemas.NFe;

public class IO : BaseXmlTest<ProcessoNFe>
{
    [Test]
    public async Task ReadNfceCombustivelFromStringAsync()
    {
        ProcessoNFe instance = await ReadAsync(Resources.Schemas.XML.NFCeNt2023_001);
        instance.Should().NotBeNull();

        instance.Chave.Should().Be("31231120855151000139650040000938509100660678");
        instance.NFe.InformacoesNFe.Id.Should().Be("NFe31231120855151000139650040000938509100660678");
        instance.NFe.InformacoesNFe.Versao.Should().Be("4.00");

        instance.NFe.InformacoesNFe.IdentificacaoOperacao.UF.Should().Be(OrgaoIBGE.MG);
        instance.NFe.InformacoesNFe.IdentificacaoOperacao.Chave.Should().Be("10066067");
        instance.NFe.InformacoesNFe.IdentificacaoOperacao.NaturezaOperacao.Should().Be("VENDA");
        instance.NFe.InformacoesNFe.IdentificacaoOperacao.Modelo.Should().Be(ModeloDocumento.NFCe);
        instance.NFe.InformacoesNFe.IdentificacaoOperacao.Serie.Should().Be(4);
        instance.NFe.InformacoesNFe.IdentificacaoOperacao.Numero.Should().Be(93850);
        instance.NFe.InformacoesNFe.IdentificacaoOperacao.DataHoraEmissao.Should().BeSameDateAs(new(2023,11,1));
        instance.NFe.InformacoesNFe.IdentificacaoOperacao.TipoOperacao.Should().Be(OperacaoNFe.Saida);
        instance.NFe.InformacoesNFe.IdentificacaoOperacao.DestinoOperacao.Should().Be(DestinoOperacao.Interna);
        instance.NFe.InformacoesNFe.IdentificacaoOperacao.CodigoMunicipio.Should().Be("3129707");
        instance.NFe.InformacoesNFe.IdentificacaoOperacao.TipoImpressao.Should().Be(TipoImpressao.DanfeNFCe);
        instance.NFe.InformacoesNFe.IdentificacaoOperacao.FormaEmissao.Should().Be(FormaEmissao.ContingenciaOffLine_NFCe);
        instance.NFe.InformacoesNFe.IdentificacaoOperacao.ChaveDigitoVerificador.Should().Be("8");
        instance.NFe.InformacoesNFe.IdentificacaoOperacao.Ambiente.Should().Be(Ambiente.Producao);
        instance.NFe.InformacoesNFe.IdentificacaoOperacao.Finalidade.Should().Be(FinalidadeEmissao.Normal);
        instance.NFe.InformacoesNFe.IdentificacaoOperacao.ConsumidorFinal.Should().Be(IndicadorConsumidorFinal.Sim);
        instance.NFe.InformacoesNFe.IdentificacaoOperacao.ProcessoDeEmissao.Should().Be(ProcessoEmissao.AplicativoContribuinte);
        instance.NFe.InformacoesNFe.IdentificacaoOperacao.VersaoProcessoEmissao.Should().Be("43.81");
        instance.NFe.InformacoesNFe.IdentificacaoOperacao.DataHoraContingencia.Should().BeSameDateAs(new(2023,11,1));
        instance.NFe.InformacoesNFe.IdentificacaoOperacao.JustificativaContingencia.Should().Be("(SERVER) CONEXAO COM A INTERNET INDISPONIVEL");

        instance.NFe.InformacoesNFe.Emitente.CNPJ_CPF.Should().Be("20855151000139");
        instance.NFe.InformacoesNFe.Emitente.RazaoSocial.Should().Be("TESTE");
        instance.NFe.InformacoesNFe.Emitente.NomeFantasia.Should().Be("TESTE");
        instance.NFe.InformacoesNFe.Emitente.Endereco.Logradouro.Should().Be("RUA TESTE");
        instance.NFe.InformacoesNFe.Emitente.Endereco.Numero.Should().Be("0");
        instance.NFe.InformacoesNFe.Emitente.Endereco.Bairro.Should().Be("CENTRO");
        instance.NFe.InformacoesNFe.Emitente.Endereco.MunicipioCodigo.Should().Be("3129707");
        instance.NFe.InformacoesNFe.Emitente.Endereco.MunicipioNome.Should().Be("IBIRACI");
        instance.NFe.InformacoesNFe.Emitente.Endereco.UF.Should().Be(Estado.MG);
        instance.NFe.InformacoesNFe.Emitente.Endereco.CEP.Should().Be("37990000");
        instance.NFe.InformacoesNFe.Emitente.Endereco.PaisCodigo.Should().Be("1058");
        instance.NFe.InformacoesNFe.Emitente.Endereco.PaisNome.Should().Be("BRASIL");
        instance.NFe.InformacoesNFe.Emitente.Endereco.Fone.Should().Be("3500000000");
        instance.NFe.InformacoesNFe.Emitente.InscricaoEstadual = "ISENTO";
        instance.NFe.InformacoesNFe.Emitente.RegimeTributario.Should().Be(RegimeTributario.RegimeNormal);

        instance.NFe.InformacoesNFe.Items.Should().HaveCount(1);
        instance.NFe.InformacoesNFe.Items[0].NumeroSequencial.Should().Be("1");

        instance.NFe.InformacoesNFe.Items[0].Dados.Codigo.Should().Be("1");
        instance.NFe.InformacoesNFe.Items[0].Dados.GTIN.Should().Be("SEM GTIN");
        instance.NFe.InformacoesNFe.Items[0].Dados.GTIN_Tributavel.Should().Be("SEM GTIN");
        instance.NFe.InformacoesNFe.Items[0].Dados.Descricao.Should().Be("GASOLINA COMUM");
        instance.NFe.InformacoesNFe.Items[0].Dados.NCM.Should().Be("27101259");
        instance.NFe.InformacoesNFe.Items[0].Dados.CFOP.Should().Be("5656");
        instance.NFe.InformacoesNFe.Items[0].Dados.UnidadeComercial.Should().Be("L");
        instance.NFe.InformacoesNFe.Items[0].Dados.UnidadeTributavel.Should().Be("L");
        instance.NFe.InformacoesNFe.Items[0].Dados.QuantidadeComercial.Should().Be(16.761d);
        instance.NFe.InformacoesNFe.Items[0].Dados.QuantidadeTributavel.Should().Be(16.761d);
        instance.NFe.InformacoesNFe.Items[0].Dados.ValorUnitarioComercial.Should().Be(5.970d);
        instance.NFe.InformacoesNFe.Items[0].Dados.ValorUnitarioTributavel.Should().Be(5.970d);
        instance.NFe.InformacoesNFe.Items[0].Dados.IndicadorComposicaoTotal.Should().Be(IndicadorTotal.CompoeTotal);
        instance.NFe.InformacoesNFe.Items[0].Dados.DetalhamentoCombustivel.cProdANP.Should().Be("320102001");
        instance.NFe.InformacoesNFe.Items[0].Dados.DetalhamentoCombustivel.descANP.Should().Be("GASOLINA C COMUM");
        instance.NFe.InformacoesNFe.Items[0].Dados.DetalhamentoCombustivel.UFCons.Should().Be(Estado.MG);
        instance.NFe.InformacoesNFe.Items[0].Dados.DetalhamentoCombustivel.encerrante.nBico.Should().Be("6");
        instance.NFe.InformacoesNFe.Items[0].Dados.DetalhamentoCombustivel.encerrante.nBomba.Should().Be("3");
        instance.NFe.InformacoesNFe.Items[0].Dados.DetalhamentoCombustivel.encerrante.nTanque.Should().Be("5");
        instance.NFe.InformacoesNFe.Items[0].Dados.DetalhamentoCombustivel.encerrante.vEncIni.Should().Be(312694.279d);
        instance.NFe.InformacoesNFe.Items[0].Dados.DetalhamentoCombustivel.encerrante.vEncFin.Should().Be(312711.040d);

        instance.NFe.InformacoesNFe.Items[0].Imposto.ValorTotalTributos.Should().Be(18.01d);

        instance.NFe.InformacoesNFe.Items[0].Imposto.ICMS.Tributacao.Origem.Should().Be(OrigemMercadoria.Nacional);
        instance.NFe.InformacoesNFe.Items[0].Imposto.ICMS.Tributacao.CST.Should().Be(CST_ICMS.CST_61);
        instance.NFe.InformacoesNFe.Items[0].Imposto.ICMS.Tributacao.qBCMonoRet.Should().Be(16.761d);
        instance.NFe.InformacoesNFe.Items[0].Imposto.ICMS.Tributacao.adRemICMSRet.Should().Be(1.2200d);
        instance.NFe.InformacoesNFe.Items[0].Imposto.ICMS.Tributacao.vICMSMonoRet.Should().Be(20.44d);

        instance.NFe.InformacoesNFe.Items[0].Imposto.PIS.Tributacao.CST.Should().Be(CST_PIS.OutrasOpSaidas);
        instance.NFe.InformacoesNFe.Items[0].Imposto.PIS.Tributacao.vBC.Should().Be(100.06d);
        instance.NFe.InformacoesNFe.Items[0].Imposto.PIS.Tributacao.pPIS.Should().Be(0d);
        instance.NFe.InformacoesNFe.Items[0].Imposto.PIS.Tributacao.vPIS.Should().Be(0d);

        instance.NFe.InformacoesNFe.Items[0].Imposto.COFINS.Tributacao.CST.Should().Be(CST_COFINS.OutrasOpSaidas);
        instance.NFe.InformacoesNFe.Items[0].Imposto.COFINS.Tributacao.vBC.Should().Be(100.06d);
        instance.NFe.InformacoesNFe.Items[0].Imposto.COFINS.Tributacao.pCOFINS.Should().Be(0d);
        instance.NFe.InformacoesNFe.Items[0].Imposto.COFINS.Tributacao.vCOFINS.Should().Be(0d);

        instance.NFe.InformacoesNFe.Totais.ISSQN.Should().BeNull();
        instance.NFe.InformacoesNFe.Totais.Retencoes.Should().BeNull();
        instance.NFe.InformacoesNFe.Totais.ICMS.Should().NotBeNull();
        instance.NFe.InformacoesNFe.Totais.ICMS.BaseDeCalculo.Should().Be(0d);
        instance.NFe.InformacoesNFe.Totais.ICMS.ICMS.Should().Be(0d);
        instance.NFe.InformacoesNFe.Totais.ICMS.BaseDeCalculoST.Should().Be(0d);
        instance.NFe.InformacoesNFe.Totais.ICMS.ICMSST.Should().Be(0d);
        instance.NFe.InformacoesNFe.Totais.ICMS.Produtos.Should().Be(100.06d);
        instance.NFe.InformacoesNFe.Totais.ICMS.Frete.Should().Be(0d);
        instance.NFe.InformacoesNFe.Totais.ICMS.Seguros.Should().Be(0d);
        instance.NFe.InformacoesNFe.Totais.ICMS.Desconto.Should().Be(0d);
        instance.NFe.InformacoesNFe.Totais.ICMS.II.Should().Be(0d);
        instance.NFe.InformacoesNFe.Totais.ICMS.IPI.Should().Be(0d);
        instance.NFe.InformacoesNFe.Totais.ICMS.vIPIDevol.Should().Be(0d);
        instance.NFe.InformacoesNFe.Totais.ICMS.PIS.Should().Be(0d);
        instance.NFe.InformacoesNFe.Totais.ICMS.COFINS.Should().Be(0d);
        instance.NFe.InformacoesNFe.Totais.ICMS.Outros.Should().Be(0d);
        instance.NFe.InformacoesNFe.Totais.ICMS.TotalNF.Should().Be(100.06d);

        instance.NFe.InformacoesNFe.Transporte.Modalidade.Should().Be(ModalidadeFrete.SemFrete);
        instance.NFe.InformacoesNFe.Pagamento.DetalhamentoPagamentos.Should().HaveCount(1);
        instance.NFe.InformacoesNFe.Pagamento.DetalhamentoPagamentos[0].tPag.Should().Be(FormaPagamento.CreditoLoja);
        instance.NFe.InformacoesNFe.Pagamento.DetalhamentoPagamentos[0].vPag.Should().Be(100.06d);

        instance.NFe.InformacoesNFe.InformacoesAdicionais.infCpl.Should().Contain("BI:6 BO:3 TQ:5 EI:312694,279 EF:312711,040. CX:TURNO 1 OP:");
        instance.NFe.InformacoesNFe.InformacoesAdicionais.infCpl.Should().Contain("COMBUSTIVEIS COBRADO ANTERIORMENTE CONFORME CONVENIO ICMS 15/2023");
        instance.NFe.InformacoesNFe.InformacoesAdicionais.infCpl.Should().Contain("MONORET 16,760, VALOR ICMS MONORET R$ 20,44");

        instance.NFe.Signature.Should().NotBeNull();
        instance.ProtocoloAutorizacao.Should().NotBeNull();
        instance.ProtocoloAutorizacao.InformacoesProtocolo.Ambiente.Should().Be(Ambiente.Producao);
        instance.ProtocoloAutorizacao.InformacoesProtocolo.VersaoAplicativo.Should().Be("W-1.5.10");
        instance.ProtocoloAutorizacao.InformacoesProtocolo.ChaveNFe.Should().Be("31231120855151000139650040000938509100660678");
        instance.ProtocoloAutorizacao.InformacoesProtocolo.DataHoraRecebimento.Should().BeSameDateAs(new(2023,11,1));
        instance.ProtocoloAutorizacao.InformacoesProtocolo.Protocolo.Should().Be("131230964542575");
        instance.ProtocoloAutorizacao.InformacoesProtocolo.StatusNFeCodigo.Should().Be("100");
        instance.ProtocoloAutorizacao.InformacoesProtocolo.StatusNfeMotivo.Should().Be("Autorizado o uso da NF-e");
    }

    [Test]
    public void ValidaPreenchimentoGeral()
    {
        NFe instance = Mock.NFe.PreencheNFeFake();
        BaseXmlTest<NFe> mockSvc = new();
        var result = mockSvc.ValidateSchemaAsync(
            instance, 
            [ 
                "http://www.portalfiscal.inf.br/nfe",
                "http://www.portalfiscal.inf.br/nfe",
                "http://www.portalfiscal.inf.br/nfe"
            ],
            [
                Resources.Schemas.XML.nfe_v4_00,
                Resources.Schemas.XML.leiauteNFe_v4_00,
                Resources.Schemas.XML.tiposBasico_v4_00
            ],
            "infNFe");
        Console.Write(instance.Serialize());
        result.Should().HaveCountLessThanOrEqualTo(0);
    }
}
