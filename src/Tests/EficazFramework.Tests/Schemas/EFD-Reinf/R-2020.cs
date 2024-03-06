using System.Collections.Generic;

namespace EficazFramework.SPED.Schemas.EFD_Reinf;

public class R2020Test : BaseEfdReinfTest<R2020>
{
    [Test]
    [TestCase(Versao.v1_05_01)]
    [TestCase(Versao.v2_01_01)]
    [TestCase(Versao.v2_01_02)]
    public void ValidaEvento(Versao versao)
    {
        _versao = versao;
        InstanciaDesserializada = (R2020 e) => e.Versao = versao;
        ValidationSchemaNamespace = $"http://www.reinf.esocial.gov.br/schemas/evtPrestadorServicos/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v1_05_01 => Resources.Schemas.EFD_Reinf.R2020_v1_05_01,
            Versao.v2_01_01 => Resources.Schemas.EFD_Reinf.R2020_v2_01_01,
            Versao.v2_01_02 => Resources.Schemas.EFD_Reinf.R2020_v2_01_02_B,
            _ => Resources.Schemas.EFD_Reinf.R2020_v2_01_02_B
        };
        TestaEvento();
    }


    // BaseEfdReinfTest overrides
    public override void PreencheCampos(R2020 evento)
    {
        evento.Versao = _versao;
        PreencheCamposR2020(evento, CnpjCpf);
    }

    public static void PreencheCamposR2020(R2020 evento, string cnpjCpf)
    {
        DateTime dtbase = DateTime.Now.AddMonths(-1);
        evento.evtServPrest = new R2020EventoServicoPrestado()
        {
            ideContri = new IdentificacaoContribuinte()
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = cnpjCpf.Substring(0, 8)
            },
            ideEvento = new IdentificacaoEventoPeriodico()
            {
                indRetif = IndicadorRetificacao.Original,
                perApur = $"{dtbase:yyyy-MM}",
                procEmi = EmissorEvento.AppContribuinte,
                tpAmb = Ambiente.ProducaoRestrita_DadosReais,
                verProc = "2.2"
            },
            infoServPrest = new R2020ServicoPrestado()
            {
                ideEstabPrest = new R2020IdentificacaoEstabPrestacao()
                {
                    tpInscEstabPrest = PersonalidadeJuridica.CNPJ,
                    nrInscEstabPrest = cnpjCpf,
                    ideTomador = new R2020IdentificacaoTomadorServico()
                    {
                        tpInscTomador = PersonalidadeJuridica.CNPJ,
                        nrInscTomador = "61918769000188",
                        vlrTotalBruto = "600,00",
                        vlrTotalBaseRet = "600,00",
                        vlrTotalRetPrinc = "66,00",
                        indObra = IndicadorObra.NaoSujeitoCEI,
                        nfs = new List<R2010eR2020Nfs>()
                        {
                            new R2010eR2020Nfs()
                            {
                                serie = "0",
                                numDocto = "719",
                                dtEmissaoNF = dtbase,
                                vlrBruto = "600,00",
                                infoTpServ = new List<R2010eR2020InformacaoServico>()
                                {
                                    new R2010eR2020InformacaoServico()
                                    {
                                        tpServico = "100000001",
                                        vlrBaseRet = "600,00",
                                        vlrRetencao = "66,00"
                                    }
                                }
                            }
                        }
                    }
                }
            },
        };
    }

    public override void ValidaInstanciasLeituraEscrita(R2020 instanciaPopulada, R2020 instanciaXml)
    {
        // TODO: verifique se os campos de instanciaXml, preenchidos a partir da leitura de um XmlDocument, 
        //       correspondem exatamente aos valores de instanciaPopulada, formado à partir do método
        //       PreencheCampos().


        // ideEvento
        instanciaXml.evtServPrest.ideEvento.tpAmb.Should().Be(instanciaPopulada.evtServPrest.ideEvento.tpAmb);
        instanciaXml.evtServPrest.ideEvento.procEmi.Should().Be(instanciaPopulada.evtServPrest.ideEvento.procEmi);
        instanciaXml.evtServPrest.ideEvento.verProc.Should().Be(instanciaPopulada.evtServPrest.ideEvento.verProc);

        // ideContri
        instanciaXml.evtServPrest.ideContri.tpInsc.Should().Be(instanciaPopulada.evtServPrest.ideContri.tpInsc);
        instanciaXml.evtServPrest.ideContri.nrInsc.Should().Be(instanciaPopulada.evtServPrest.ideContri.nrInsc);

        // evtServTom
        instanciaXml.evtServPrest.infoServPrest.ideEstabPrest.tpInscEstabPrest.Should().Be(instanciaPopulada.evtServPrest.infoServPrest.ideEstabPrest.tpInscEstabPrest);
        instanciaXml.evtServPrest.infoServPrest.ideEstabPrest.nrInscEstabPrest.Should().Be(instanciaPopulada.evtServPrest.infoServPrest.ideEstabPrest.nrInscEstabPrest);
        instanciaXml.evtServPrest.infoServPrest.ideEstabPrest.ideTomador.tpInscTomador.Should().Be(instanciaPopulada.evtServPrest.infoServPrest.ideEstabPrest.ideTomador.tpInscTomador);
        instanciaXml.evtServPrest.infoServPrest.ideEstabPrest.ideTomador.nrInscTomador.Should().Be(instanciaPopulada.evtServPrest.infoServPrest.ideEstabPrest.ideTomador.nrInscTomador);
        instanciaXml.evtServPrest.infoServPrest.ideEstabPrest.ideTomador.indObra.Should().Be(instanciaPopulada.evtServPrest.infoServPrest.ideEstabPrest.ideTomador.indObra);
        instanciaXml.evtServPrest.infoServPrest.ideEstabPrest.ideTomador.vlrTotalBruto.Should().Be(instanciaPopulada.evtServPrest.infoServPrest.ideEstabPrest.ideTomador.vlrTotalBruto);
        instanciaXml.evtServPrest.infoServPrest.ideEstabPrest.ideTomador.vlrTotalBaseRet.Should().Be(instanciaPopulada.evtServPrest.infoServPrest.ideEstabPrest.ideTomador.vlrTotalBaseRet);
        instanciaXml.evtServPrest.infoServPrest.ideEstabPrest.ideTomador.vlrTotalRetPrinc.Should().Be(instanciaPopulada.evtServPrest.infoServPrest.ideEstabPrest.ideTomador.vlrTotalRetPrinc);
        int iDetAquis = 0;
        instanciaXml.evtServPrest.infoServPrest.ideEstabPrest.ideTomador.nfs.ForEach(ev =>
        {
            ev.dtEmissaoNF.Should().BeSameDateAs(instanciaPopulada.evtServPrest.infoServPrest.ideEstabPrest.ideTomador.nfs[iDetAquis].dtEmissaoNF);
            ev.vlrBruto.Should().Be(instanciaPopulada.evtServPrest.infoServPrest.ideEstabPrest.ideTomador.nfs[iDetAquis].vlrBruto); ;
            ev.serie.Should().Be(instanciaPopulada.evtServPrest.infoServPrest.ideEstabPrest.ideTomador.nfs[iDetAquis].serie);
            ev.numDocto.Should().Be(instanciaPopulada.evtServPrest.infoServPrest.ideEstabPrest.ideTomador.nfs[iDetAquis].numDocto);
            int itpServ = 0;
            ev.infoTpServ.ForEach(tpServ =>
            {
                tpServ.tpServico.Should().Be(instanciaPopulada.evtServPrest.infoServPrest.ideEstabPrest.ideTomador.nfs[iDetAquis].infoTpServ[itpServ].tpServico);
                tpServ.vlrBaseRet.Should().Be(instanciaPopulada.evtServPrest.infoServPrest.ideEstabPrest.ideTomador.nfs[iDetAquis].infoTpServ[itpServ].vlrBaseRet);
                tpServ.vlrRetencao.Should().Be(instanciaPopulada.evtServPrest.infoServPrest.ideEstabPrest.ideTomador.nfs[iDetAquis].infoTpServ[itpServ].vlrRetencao);
                itpServ += 1;
            });
            iDetAquis += 1;
        });
    }


}