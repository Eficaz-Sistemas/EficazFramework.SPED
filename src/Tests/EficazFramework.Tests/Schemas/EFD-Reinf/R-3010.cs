using System.Collections.Generic;

namespace EficazFramework.SPED.Schemas.EFD_Reinf;

public class R3010Test : BaseEfdReinfTest<R3010>
{
    [Test]
    [TestCase(Versao.v1_05_01)]
    [TestCase(Versao.v2_01_02)]
    public void ValidaEvento(Versao versao)
    {
        _versao = versao;
        InstanciaDesserializada = (R3010 e) => e.Versao = versao;
        ValidationSchemaNamespace = $"http://www.reinf.esocial.gov.br/schemas/evtEspDesportivo/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v1_05_01 => Resources.Schemas.EFD_Reinf.R3010_v1_05_01,
            Versao.v2_01_01 => Resources.Schemas.EFD_Reinf.R3010_v2_01_01,
            Versao.v2_01_02 => Resources.Schemas.EFD_Reinf.R3010_v2_01_02_B,
            _ => Resources.Schemas.EFD_Reinf.R3010_v2_01_02_B
        };
        TestaEvento();
    }


    // BaseEfdReinfTest overrides
    public override void PreencheCampos(R3010 evento)
    {
        evento.Versao = _versao;
        PreencheCamposR3010(evento, CnpjCpf);
    }

    public static void PreencheCamposR3010(R3010 evento, string cnpjCpf)
    {
        evento.evtEspDesportivo = new R3010EventoEspDesportivo()
        {
            ideContri = new R3010IdentificacaoContribuinte()
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = cnpjCpf.Substring(0, 8),
                ideEstab = new List<R3010IdentificacaoEstabelecimento>()
                {
                    new R3010IdentificacaoEstabelecimento()
                    {
                        tpInscEstab = PersonalidadeJuridica.CNPJ,
                        nrInscEstab = cnpjCpf,
                        receitaTotal = new R3010ReceitaTotal()
                        {
                            vlrReceitaTotal = 1500000M.ToString("f2"),
                            vlrReceitaClubes = 1250000M.ToString("f2"),
                            vlrCP = 125000M.ToString("f2"),
                            vlrRetParc = 0M.ToString("f2")
                        },
                        boletim = new List<R3010Boletim>()
                        {
                            new R3010Boletim()
                            {
                                nrBoletim = "1234",
                                tpCompeticao = TipoCompeticao.Oficial,
                                categEvento = CategoriaEvento.Interestadual,
                                modDesportiva = "Futebol",
                                nomeCompeticao = "Campeonato Nacional",
                                cnpjMandante = "32522866000159",
                                cnpjVisitante = "73653529000188",
                                nomeVisitante = "Rio de Janeiro FC",
                                pracaDesportiva = "Estadio do Triângulo Mineiro",
                                codMunic = 3129707,
                                codMunicSpecified = true,
                                uf = "MG",
                                qtdePagantes = 45000,
                                qtdeNaoPagantes = 2250,
                                receitaIngressos = new()
                                {
                                    new R3010ReceitaIngressos()
                                    {
                                        tpIngresso = TipoIngressoCompeticao.Geral,
                                        descIngr = "G1",
                                        qtdeIngrVendidos = 25000,
                                        precoIndiv = 30M.ToString("f2"),
                                        vlrTotal = 750000M.ToString("f2")
                                    },
                                    new R3010ReceitaIngressos()
                                    {
                                        tpIngresso = TipoIngressoCompeticao.Arquibancada,
                                        descIngr = "A1",
                                        qtdeIngrVendidos = 750,
                                        precoIndiv = 300M.ToString("f2"),
                                        vlrTotal = 225000M.ToString("f2")
                                    }
                                },
                                outrasReceitas = new()
                                {
                                    new R3010OutrasReceitas()
                                    {
                                        tpReceita = TipoReceitaCompeticao.Transmissao,
                                        descReceita = "TV",
                                        vlrReceita = 175000M.ToString("f2")
                                    },
                                    new R3010OutrasReceitas()
                                    {
                                        tpReceita = TipoReceitaCompeticao.Propaganda,
                                        descReceita = "Anunciantes",
                                        vlrReceita = 80000M.ToString("f2")
                                    }
                                }
                            }
                        }
                    }
                }
            },
            ideEvento = new R3010IdentificacaoEvento()
            {
                indRetif = IndicadorRetificacao.Original,
                dtApuracao = DateTime.Now.AddMonths(-1),
                procEmi = EmissorEvento.AppContribuinte,
                tpAmb = Ambiente.ProducaoRestrita_DadosReais,
                verProc = "2.2"
            }
        };
    }


    public override void ValidaInstanciasLeituraEscrita(R3010 instanciaPopulada, R3010 instanciaXml)
    {
        // TODO: verifique se os campos de instanciaXml, preenchidos a partir da leitura de um XmlDocument, 
        //       correspondem exatamente aos valores de instanciaPopulada, formado à partir do método
        //       PreencheCampos().


        // ideEvento
        instanciaXml.evtEspDesportivo.ideEvento.tpAmb.Should().Be(instanciaPopulada.evtEspDesportivo.ideEvento.tpAmb);
        instanciaXml.evtEspDesportivo.ideEvento.procEmi.Should().Be(instanciaPopulada.evtEspDesportivo.ideEvento.procEmi);
        instanciaXml.evtEspDesportivo.ideEvento.verProc.Should().Be(instanciaPopulada.evtEspDesportivo.ideEvento.verProc);

        // ideContri
        instanciaXml.evtEspDesportivo.ideContri.tpInsc.Should().Be(instanciaPopulada.evtEspDesportivo.ideContri.tpInsc);
        instanciaXml.evtEspDesportivo.ideContri.nrInsc.Should().Be(instanciaPopulada.evtEspDesportivo.ideContri.nrInsc);

        // evtEspDesportivo
        int iestab = 0;
        instanciaXml.evtEspDesportivo.ideContri.ideEstab.ForEach(est =>
        {
            est.tpInscEstab.Should().Be(instanciaPopulada.evtEspDesportivo.ideContri.ideEstab[iestab].tpInscEstab);
            est.nrInscEstab.Should().Be(instanciaPopulada.evtEspDesportivo.ideContri.ideEstab[iestab].nrInscEstab);
            int iboletim = 0;
            est.boletim.ForEach(b =>
            {
                b.nrBoletim.Should().Be(instanciaPopulada.evtEspDesportivo.ideContri.ideEstab[iestab].boletim[iboletim].nrBoletim);
                b.tpCompeticao.Should().Be(instanciaPopulada.evtEspDesportivo.ideContri.ideEstab[iestab].boletim[iboletim].tpCompeticao);
                b.categEvento.Should().Be(instanciaPopulada.evtEspDesportivo.ideContri.ideEstab[iestab].boletim[iboletim].categEvento);
                b.modDesportiva.Should().Be(instanciaPopulada.evtEspDesportivo.ideContri.ideEstab[iestab].boletim[iboletim].modDesportiva);
                b.nomeCompeticao.Should().Be(instanciaPopulada.evtEspDesportivo.ideContri.ideEstab[iestab].boletim[iboletim].nomeCompeticao);
                b.cnpjMandante.Should().Be(instanciaPopulada.evtEspDesportivo.ideContri.ideEstab[iestab].boletim[iboletim].cnpjMandante);
                b.cnpjVisitante.Should().Be(instanciaPopulada.evtEspDesportivo.ideContri.ideEstab[iestab].boletim[iboletim].cnpjVisitante);
                b.nomeVisitante.Should().Be(instanciaPopulada.evtEspDesportivo.ideContri.ideEstab[iestab].boletim[iboletim].nomeVisitante);
                b.pracaDesportiva.Should().Be(instanciaPopulada.evtEspDesportivo.ideContri.ideEstab[iestab].boletim[iboletim].pracaDesportiva);
                b.codMunic.Should().Be(instanciaPopulada.evtEspDesportivo.ideContri.ideEstab[iestab].boletim[iboletim].codMunic);
                b.uf.Should().Be(instanciaPopulada.evtEspDesportivo.ideContri.ideEstab[iestab].boletim[iboletim].uf);
                b.qtdePagantes.Should().Be(instanciaPopulada.evtEspDesportivo.ideContri.ideEstab[iestab].boletim[iboletim].qtdePagantes);
                b.qtdeNaoPagantes.Should().Be(instanciaPopulada.evtEspDesportivo.ideContri.ideEstab[iestab].boletim[iboletim].qtdeNaoPagantes);
                int iIngresRec = 0;
                b.receitaIngressos.ForEach(ingrRec =>
                {
                    ingrRec.tpIngresso.Should().Be(instanciaPopulada.evtEspDesportivo.ideContri.ideEstab[iestab].boletim[iboletim].receitaIngressos[iIngresRec].tpIngresso);
                    ingrRec.descIngr.Should().Be(instanciaPopulada.evtEspDesportivo.ideContri.ideEstab[iestab].boletim[iboletim].receitaIngressos[iIngresRec].descIngr);
                    ingrRec.qtdeIngrVenda.Should().Be(instanciaPopulada.evtEspDesportivo.ideContri.ideEstab[iestab].boletim[iboletim].receitaIngressos[iIngresRec].qtdeIngrVenda);
                    ingrRec.qtdeIngrVendidos.Should().Be(instanciaPopulada.evtEspDesportivo.ideContri.ideEstab[iestab].boletim[iboletim].receitaIngressos[iIngresRec].qtdeIngrVendidos);
                    ingrRec.qtdeIngrDev.Should().Be(instanciaPopulada.evtEspDesportivo.ideContri.ideEstab[iestab].boletim[iboletim].receitaIngressos[iIngresRec].qtdeIngrDev);
                    ingrRec.precoIndiv.Should().Be(instanciaPopulada.evtEspDesportivo.ideContri.ideEstab[iestab].boletim[iboletim].receitaIngressos[iIngresRec].precoIndiv);
                    ingrRec.vlrTotal.Should().Be(instanciaPopulada.evtEspDesportivo.ideContri.ideEstab[iestab].boletim[iboletim].receitaIngressos[iIngresRec].vlrTotal);
                    iIngresRec += 1;
                });
                int iOutrasRec = 0;
                b.outrasReceitas.ForEach(outrRec =>
                {
                    outrRec.tpReceita.Should().Be(instanciaPopulada.evtEspDesportivo.ideContri.ideEstab[iestab].boletim[iboletim].outrasReceitas[iOutrasRec].tpReceita);
                    outrRec.vlrReceita.Should().Be(instanciaPopulada.evtEspDesportivo.ideContri.ideEstab[iestab].boletim[iboletim].outrasReceitas[iOutrasRec].vlrReceita);
                    outrRec.descReceita.Should().Be(instanciaPopulada.evtEspDesportivo.ideContri.ideEstab[iestab].boletim[iboletim].outrasReceitas[iOutrasRec].descReceita);
                    iOutrasRec += 1;
                });
                iboletim += 1;
            });
            iestab += 1;
        });
    }
}