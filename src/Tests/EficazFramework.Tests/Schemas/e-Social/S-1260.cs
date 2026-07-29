namespace EficazFramework.SPED.Schemas.eSocial;

public class S1260Test : BaseESocialTest<S1260>
{
    [Test]
    [TestCase(Versao.v_S_01_02_00)]
    [TestCase(Versao.v_S_01_03_00)]
    public async Task Valida(Versao versao)
    {
        _versao = versao;
        ValidationSchemaNamespace = $"http://www.esocial.gov.br/schema/evt/evtComProd/{versao}";
        await TestaEvento();
    }

    [Test]
    public async Task ImportaXmlLegado()
    {
        string xmlLegado = $@"<eSocial xmlns=""http://www.esocial.gov.br/schema/evt/evtComProd/v_S_01_01_00"">
  <evtComProd Id=""ID1347855150001662025020112000000001"">
    <ideEvento>
      <indRetif>1</indRetif>
      <indApuracao>1</indApuracao>
      <perApur>2025-02</perApur>
      <tpAmb>2</tpAmb>
      <procEmi>1</procEmi>
      <verProc>1.0</verProc>
    </ideEvento>
    <ideEmpregador>
      <tpInsc>1</tpInsc>
      <nrInsc>{CnpjCpf[..8]}</nrInsc>
    </ideEmpregador>
    <infoComProd>
      <ideEstabel>
        <nrInscEstabRural>12345678901234</nrInscEstabRural>
        <tpComerc>
          <indComerc>3</indComerc>
          <vrTotCom>15000.50</vrTotCom>
          <ideAdquir>
            <tpInsc>1</tpInsc>
            <nrInsc>98765432000199</nrInsc>
            <vrComerc>15000.50</vrComerc>
            <nfs>
              <serie>1</serie>
              <nrDocto>1001</nrDocto>
              <dtEmisNF>2025-02-15</dtEmisNF>
              <vlrBruto>15000.50</vlrBruto>
              <vrCPDescPR>225.00</vrCPDescPR>
              <vrRatDescPR>15.00</vrRatDescPR>
              <vrSenarDesc>30.00</vrSenarDesc>
            </nfs>
          </ideAdquir>
          <infoProcJud>
            <tpProc>1</tpProc>
            <nrProc>00012345620255010000</nrProc>
            <codSusp>123456789</codSusp>
            <vrCPSusp>100.00</vrCPSusp>
            <vrRatSusp>10.00</vrRatSusp>
            <vrSenarSusp>5.00</vrSenarSusp>
          </infoProcJud>
        </tpComerc>
      </ideEstabel>
    </infoComProd>
  </evtComProd>
</eSocial>";

        var evento = (S1260)(await Evento.ReadAsync(xmlLegado));
        evento.Should().NotBeNull();
        evento.evtComProd.Should().NotBeNull();

        // ideEvento
        evento.evtComProd.ideEvento.perApur.Should().Be("2025-02");
        evento.evtComProd.ideEvento.tpAmb.Should().Be(Ambiente.ProducaoRestrita_DadosReais);
        evento.evtComProd.ideEvento.procEmi.Should().Be(EmissorEvento.AppEmpregador);

        // ideEmpregador
        evento.evtComProd.ideEmpregador.tpInsc.Should().Be(PersonalidadeJuridica.CNPJ);
        evento.evtComProd.ideEmpregador.nrInsc.Should().Be(CnpjCpf[..8]);

        // infoComProd
        var estabel = evento.evtComProd.infoComProd.ideEstabel;
        estabel.Should().NotBeNull();
        estabel.nrInscEstabRural.Should().Be("12345678901234");
        estabel.tpComerc.Should().HaveCount(1);

        var tpCom = estabel.tpComerc.First();
        tpCom.indComerc.Should().Be(IndicadorComercializacaoS1260.Vendas_a_PJ);
        tpCom.vrTotCom.Should().Be(15000.50m);

        // ideAdquir
        tpCom.ideAdquir.Should().HaveCount(1);
        var adquir = tpCom.ideAdquir.First();
        adquir.tpInsc.Should().Be(PersonalidadeJuridica.CNPJ);
        adquir.nrInsc.Should().Be("98765432000199");
        adquir.vrComerc.Should().Be(15000.50m);

        // nfs
        adquir.nfs.Should().HaveCount(1);
        var nf = adquir.nfs.First();
        nf.serie.Should().Be("1");
        nf.nrDocto.Should().Be("1001");
        nf.dtEmisNF.Should().Be(new DateTime(2025, 2, 15));
        nf.vlrBruto.Should().Be(15000.50m);
        nf.vrCPDescPR.Should().Be(225.00m);
        nf.vrRatDescPR.Should().Be(15.00m);
        nf.vrSenarDesc.Should().Be(30.00m);

        // infoProcJud
        tpCom.infoProcJud.Should().HaveCount(1);
        var procJud = tpCom.infoProcJud.First();
        procJud.tpProc.Should().Be((sbyte)1);
        procJud.nrProc.Should().Be("00012345620255010000");
        procJud.codSusp.Should().Be("123456789");
        procJud.vrCPSusp.Should().Be(100.00m);
        procJud.vrRatSusp.Should().Be(10.00m);
        procJud.vrSenarSusp.Should().Be(5.00m);
    }

    public override void PreencheCampos(S1260 evento)
    {
        evento.Versao = _versao;
        evento.evtComProd = new S1260ComercializacaoProd
        {
            ideEvento = new IdeEventoPeriodico
            {
                indRetif = IndicadorRetificacao.Original,
                indApuracao = IndicadorApuracao.Mensal,
                perApur = "2025-02",
                tpAmb = Ambiente.ProducaoRestrita_DadosReais,
                procEmi = EmissorEvento.AppEmpregador,
                verProc = "1.0"
            },
            ideEmpregador = new Empregador
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = CnpjCpf[..8]
            },
            infoComProd = new S1260InfoComProducao
            {
                ideEstabel = new S1260IdeEstabelecimento
                {
                    nrInscEstabRural = "12345678901234",
                    tpComerc =
                    [
                        new S1260TipoComercializacao
                        {
                            indComerc = IndicadorComercializacaoS1260.Vendas_a_PJ,
                            vrTotCom = 25000.00m,
                            ideAdquir =
                            [
                                new S1260TpComercIdeAdquirente
                                {
                                    tpInsc = PersonalidadeJuridica.CNPJ,
                                    nrInsc = "98765432000199",
                                    vrComerc = 25000.00m,
                                    nfs =
                                    [
                                        new S1260IdeAdquirenteNf
                                        {
                                            serie = "1",
                                            nrDocto = "2002",
                                            dtEmisNF = new DateTime(2025, 2, 20),
                                            vlrBruto = 25000.00m,
                                            vrCPDescPR = 375.00m,
                                            vrRatDescPR = 25.00m,
                                            vrSenarDesc = 50.00m
                                        }
                                    ]
                                }
                            ],
                            infoProcJud =
                            [
                                new S1260TipoComercializacaoInfoProcJudicial
                                {
                                    tpProc = 2,
                                    nrProc = "50012345620255010000",
                                    codSusp = "987654321",
                                    vrCPSusp = 150.00m,
                                    vrCPSuspSpecified = true,
                                    vrRatSusp = 15.00m,
                                    vrRatSuspSpecified = true,
                                    vrSenarSusp = 8.00m,
                                    vrSenarSuspSpecified = true
                                }
                            ]
                        }
                    ]
                }
            }
        };
    }

    public override void ValidaInstanciasLeituraEscrita(S1260 instanciaPopulada, S1260 instanciaXml)
    {
        instanciaPopulada.Should().NotBeNull();
        instanciaXml.Should().NotBeNull();

        // ideEvento
        instanciaXml.evtComProd.ideEvento.tpAmb.Should().Be(instanciaPopulada.evtComProd.ideEvento.tpAmb);
        instanciaXml.evtComProd.ideEvento.procEmi.Should().Be(instanciaPopulada.evtComProd.ideEvento.procEmi);
        instanciaXml.evtComProd.ideEvento.verProc.Should().Be(instanciaPopulada.evtComProd.ideEvento.verProc);
        instanciaXml.evtComProd.ideEvento.perApur.Should().Be(instanciaPopulada.evtComProd.ideEvento.perApur);

        // ideEmpregador
        instanciaXml.evtComProd.ideEmpregador.tpInsc.Should().Be(instanciaPopulada.evtComProd.ideEmpregador.tpInsc);
        instanciaXml.evtComProd.ideEmpregador.nrInsc.Should().Be(instanciaPopulada.evtComProd.ideEmpregador.nrInsc);

        // infoComProd / ideEstabel
        var estabelPopulado = instanciaPopulada.evtComProd.infoComProd.ideEstabel;
        var estabelXml = instanciaXml.evtComProd.infoComProd.ideEstabel;
        estabelXml.Should().NotBeNull();
        estabelXml.nrInscEstabRural.Should().Be(estabelPopulado.nrInscEstabRural);
        estabelXml.tpComerc.Should().HaveCount(estabelPopulado.tpComerc.Count);

        // tpComerc
        var tpComPopulada = estabelPopulado.tpComerc.First();
        var tpComXml = estabelXml.tpComerc.First();
        tpComXml.indComerc.Should().Be(tpComPopulada.indComerc);
        tpComXml.vrTotCom.Should().Be(tpComPopulada.vrTotCom);

        // ideAdquir
        tpComXml.ideAdquir.Should().HaveCount(tpComPopulada.ideAdquir.Count);
        var adquirPopulada = tpComPopulada.ideAdquir.First();
        var adquirXml = tpComXml.ideAdquir.First();
        adquirXml.tpInsc.Should().Be(adquirPopulada.tpInsc);
        adquirXml.nrInsc.Should().Be(adquirPopulada.nrInsc);
        adquirXml.vrComerc.Should().Be(adquirPopulada.vrComerc);

        // nfs
        adquirXml.nfs.Should().HaveCount(adquirPopulada.nfs.Count);
        var nfPopulada = adquirPopulada.nfs.First();
        var nfXml = adquirXml.nfs.First();
        nfXml.serie.Should().Be(nfPopulada.serie);
        nfXml.nrDocto.Should().Be(nfPopulada.nrDocto);
        nfXml.dtEmisNF.Should().Be(nfPopulada.dtEmisNF);
        nfXml.vlrBruto.Should().Be(nfPopulada.vlrBruto);
        nfXml.vrCPDescPR.Should().Be(nfPopulada.vrCPDescPR);
        nfXml.vrRatDescPR.Should().Be(nfPopulada.vrRatDescPR);
        nfXml.vrSenarDesc.Should().Be(nfPopulada.vrSenarDesc);

        // infoProcJud
        tpComXml.infoProcJud.Should().HaveCount(tpComPopulada.infoProcJud.Count);
        var procPopulado = tpComPopulada.infoProcJud.First();
        var procXml = tpComXml.infoProcJud.First();
        procXml.tpProc.Should().Be(procPopulado.tpProc);
        procXml.nrProc.Should().Be(procPopulado.nrProc);
        procXml.codSusp.Should().Be(procPopulado.codSusp);
        procXml.vrCPSusp.Should().Be(procPopulado.vrCPSusp);
        procXml.vrRatSusp.Should().Be(procPopulado.vrRatSusp);
        procXml.vrSenarSusp.Should().Be(procPopulado.vrSenarSusp);
    }
}
