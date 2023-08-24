namespace EficazFramework.SPED.Schemas.EFD_Reinf;

public class R2010Test : BaseEfdReinfTest<R2010>
{
    [Test]
    [TestCase(Versao.v1_05_01)]
    [TestCase(Versao.v2_01_01)]
    [TestCase(Versao.v2_01_02)]
    public void ValidaEvento(Versao versao)
    {
        _versao = versao;
        InstanciaDesserializada = (R2010 e) => e.Versao = versao;
        ValidationSchemaNamespace = $"http://www.reinf.esocial.gov.br/schemas/evtTomadorServicos/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v1_05_01 => Resources.Schemas.EFD_Reinf.R2010_v1_05_01,
            Versao.v2_01_01 => Resources.Schemas.EFD_Reinf.R2010_v2_01_01,
            Versao.v2_01_02 => Resources.Schemas.EFD_Reinf.R2010_v2_01_02_B,
            _ => Resources.Schemas.EFD_Reinf.R2010_v2_01_02_B
        };
        TestaEvento();
    }


    // BaseEfdReinfTest overrides
    public override void PreencheCampos(R2010 evento)
    {
        evento.Versao = _versao;
        PreencheCamposR2010(evento);
    }

    public static void PreencheCamposR2010(R2010 evento)
    {
        EficazFramework.SPED.Schemas.EFD_Reinf.R2010 registro = new EficazFramework.SPED.Schemas.EFD_Reinf.R2010();
        evento.evtServTom = new ReinfEvtServTom()
        {
            ideContri = new IdentificacaoContribuinte(),
            ideEvento = new IdentificacaoEventoR2000(),
            infoServTom = new ReinfEvtServTomInfoServTom()
        };

        //ideContri
        evento.evtServTom.ideContri.tpInsc = PersonalidadeJuridica.CNPJ;
        evento.evtServTom.ideContri.nrInsc = _cnpj.Substring(0, 8);

        //ideEvento
        evento.evtServTom.ideEvento.indRetif = IndicadorRetificacao.Original;
        evento.evtServTom.ideEvento.perApur = $"{DateTime.Now.AddMonths(-1):yyyy-MM}";
        evento.evtServTom.ideEvento.procEmi = EmissorEvento.AppContribuinte;
        evento.evtServTom.ideEvento.tpAmb = Ambiente.ProducaoRestrita_DadosReais;
        evento.evtServTom.ideEvento.verProc = "2.2";

        //evtServTom
        evento.evtServTom.infoServTom.ideEstabObra = new ReinfEvtServTomInfoServTomIdeEstabObra()
        {
            tpInscEstab = PersonalidadeJuridica.CNPJ,
            nrInscEstab = _cnpj,
            idePrestServ =  new ReinfEvtServTomInfoServTomIdeEstabObraIdePrestServ()
        };
        evento.evtServTom.infoServTom.ideEstabObra.idePrestServ.cnpjPrestador = "61918769000188";
        evento.evtServTom.infoServTom.ideEstabObra.idePrestServ.vlrTotalBruto = "600,00";
        evento.evtServTom.infoServTom.ideEstabObra.idePrestServ.vlrTotalBaseRet = "600,00";
        evento.evtServTom.infoServTom.ideEstabObra.idePrestServ.vlrTotalRetPrinc = "66,00";
        evento.evtServTom.infoServTom.ideEstabObra.idePrestServ.indCPRB = IndicadorContribuinteCPRB.NaoContribuinte;
        evento.evtServTom.infoServTom.ideEstabObra.idePrestServ.nfs.Add(new ReinfEvtServTomInfoServTomIdeEstabObraIdePrestServNfs()
        {
            serie = "0",
            numDocto = "719",
            dtEmissaoNF = new DateTime(DateTime.Now.Year, DateTime.Now.Date.AddMonths(-1).Month, 2),
            vlrBruto = "600,00",
            infoTpServ = new System.Collections.Generic.List<ReinfEvtServTomInfoServTomIdeEstabObraIdePrestServNfsInfoTpServ>()
            {
                new ReinfEvtServTomInfoServTomIdeEstabObraIdePrestServNfsInfoTpServ()
                {
                    tpServico = "100000001",
                    vlrBaseRet = "600,00",
                    vlrRetencao = "66,00"
                }
            }

    });
    }


    public override void ValidaInstanciasLeituraEscrita(R2010 instanciaPopulada, R2010 instanciaXml)
    {
        // TODO: verifique se os campos de instanciaXml, preenchidos a partir da leitura de um XmlDocument, 
        //       correspondem exatamente aos valores de instanciaPopulada, formado à partir do método
        //       PreencheCampos().


        // ideEvento
        instanciaXml.evtServTom.ideEvento.tpAmb.Should().Be(instanciaPopulada.evtServTom.ideEvento.tpAmb);
        instanciaXml.evtServTom.ideEvento.procEmi.Should().Be(instanciaPopulada.evtServTom.ideEvento.procEmi);
        instanciaXml.evtServTom.ideEvento.verProc.Should().Be(instanciaPopulada.evtServTom.ideEvento.verProc);

        // ideContri
        instanciaXml.evtServTom.ideContri.tpInsc.Should().Be(instanciaPopulada.evtServTom.ideContri.tpInsc);
        instanciaXml.evtServTom.ideContri.nrInsc.Should().Be(instanciaPopulada.evtServTom.ideContri.nrInsc);

        // evtServTom
        instanciaXml.evtServTom.infoServTom.ideEstabObra.tpInscEstab.Should().Be(instanciaPopulada.evtServTom.infoServTom.ideEstabObra.tpInscEstab);
        instanciaXml.evtServTom.infoServTom.ideEstabObra.nrInscEstab.Should().Be(instanciaPopulada.evtServTom.infoServTom.ideEstabObra.nrInscEstab);
        instanciaXml.evtServTom.infoServTom.ideEstabObra.indObra.Should().Be(instanciaPopulada.evtServTom.infoServTom.ideEstabObra.indObra);
        instanciaXml.evtServTom.infoServTom.ideEstabObra.idePrestServ.cnpjPrestador.Should().Be(instanciaPopulada.evtServTom.infoServTom.ideEstabObra.idePrestServ.cnpjPrestador);
        instanciaXml.evtServTom.infoServTom.ideEstabObra.idePrestServ.vlrTotalBruto.Should().Be(instanciaPopulada.evtServTom.infoServTom.ideEstabObra.idePrestServ.vlrTotalBruto);
        instanciaXml.evtServTom.infoServTom.ideEstabObra.idePrestServ.vlrTotalBaseRet.Should().Be(instanciaPopulada.evtServTom.infoServTom.ideEstabObra.idePrestServ.vlrTotalBaseRet);
        instanciaXml.evtServTom.infoServTom.ideEstabObra.idePrestServ.vlrTotalRetPrinc.Should().Be(instanciaPopulada.evtServTom.infoServTom.ideEstabObra.idePrestServ.vlrTotalRetPrinc);
        instanciaXml.evtServTom.infoServTom.ideEstabObra.idePrestServ.indCPRB.Should().Be(instanciaPopulada.evtServTom.infoServTom.ideEstabObra.idePrestServ.indCPRB);
        int iDetAquis = 0;
        instanciaXml.evtServTom.infoServTom.ideEstabObra.idePrestServ.nfs.ForEach(ev =>
        {
            ev.dtEmissaoNF.Should().Be(instanciaPopulada.evtServTom.infoServTom.ideEstabObra.idePrestServ.nfs[iDetAquis].dtEmissaoNF);
            ev.vlrBruto.Should().Be(instanciaPopulada.evtServTom.infoServTom.ideEstabObra.idePrestServ.nfs[iDetAquis].vlrBruto); ;
            ev.serie.Should().Be(instanciaPopulada.evtServTom.infoServTom.ideEstabObra.idePrestServ.nfs[iDetAquis].serie);
            ev.numDocto.Should().Be(instanciaPopulada.evtServTom.infoServTom.ideEstabObra.idePrestServ.nfs[iDetAquis].numDocto);
            int itpServ = 0;
            ev.infoTpServ.ForEach(tpServ =>
            {
                tpServ.tpServico.Should().Be(instanciaPopulada.evtServTom.infoServTom.ideEstabObra.idePrestServ.nfs[iDetAquis].infoTpServ[itpServ].tpServico);
                tpServ.vlrBaseRet.Should().Be(instanciaPopulada.evtServTom.infoServTom.ideEstabObra.idePrestServ.nfs[iDetAquis].infoTpServ[itpServ].vlrBaseRet);
                tpServ.vlrRetencao.Should().Be(instanciaPopulada.evtServTom.infoServTom.ideEstabObra.idePrestServ.nfs[iDetAquis].infoTpServ[itpServ].vlrRetencao);
                itpServ += 1;
            });
            iDetAquis += 1;
        });
    }
}