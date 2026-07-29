namespace EficazFramework.SPED.Schemas.eSocial;

public class S1200Test : BaseESocialTest<S1200>
{
    private int _testNumber = 0;

    [Test]
    [TestCase(Versao.v_S_01_03_00)]
    public async Task Valida(Versao versao)
    {
        _testNumber = 0;
        _versao = versao;
        ValidationSchemaNamespace = $"http://www.esocial.gov.br/schema/evt/evtRemun/{versao}";
        ValidationSchema = versao switch
        {
            _ => Resources.Schemas.eSocial.S1200_v_S_01_03_00
        };
        await TestaEvento();
    }


    // BaseESocialTest overrides
    public override void PreencheCampos(S1200 evento)
    {
        evento.Versao = _versao;
        evento.evtRemun = new()
        {
            ideEvento = new()
            {
                tpAmb = Ambiente.ProducaoRestrita_DadosReais,
                procEmi = EmissorEvento.AppEmpregador,
                perApur = "2025-02",
                verProc = "6.4"
            },
            ideEmpregador = new()
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = CnpjCpf[..8]
            },
            ideTrabalhador = new()
            {
                CpfTrab = "45019308889",
                ProcJudTrab =
                [
                    new()
                    {
                        tpProc = TributoProcessoJud.IRRF,
                        nrProc = "20250000000000000001",
                        codSusp = "1"
                    }
                ]
            },
            dmDev =
            [
                new()
                {
                    IdeDmDev = "022025MENSAL1234567890",
                    CodCateg = "101",
                    InfoPerApur = new()
                    {
                        IdeEstabLot =
                        [
                            new()
                            {
                                TpInsc = PersonalidadeJuridica.CNPJ,
                                NrInsc = CnpjCpf,
                                CodLotacao = "1",
                                RemunPerApur =
                                [
                                    new()
                                    {
                                        Matricula = "1002",
                                        ItensRemun =
                                        [
                                            new()
                                            {
                                                CodRubr = "100",
                                                IdeTabRubr = "0001",
                                                QtdRubr = 220,
                                                VrRubr = 1518,
                                                IndApurIR =0,
                                            },
                                            new()
                                            {
                                                CodRubr = "843",
                                                IdeTabRubr = "0001",
                                                VrRubr = 1518,
                                                IndApurIR =0,
                                            }
                                        ]
                                    }
                                ]
                            }
                        ]
                    }
                },
                new()
                {
                    IdeDmDev = "022025RRA0000000000001",
                    CodCateg = "101",
                    IndRRA = "S",
                    InfoRRA = new()
                    {
                        tpProcRRA = TipoProcesso.Judicial,
                        nrProcRRA = "20250000000000000002",
                        descRRA = "Diferencas salariais reconhecidas em reclamatoria",
                        qtdMesesRRA = 3,
                        despProcJud = new()
                        {
                            vlrDespCustas = 100,
                            vlrDespAdvogados = 300
                        },
                        ideAdv =
                        [
                            new()
                            {
                                tpInsc = PersonalidadeJuridica.CPF,
                                nrInsc = "45019308889",
                                vlrAdv = 200
                            },
                            new()
                            {
                                tpInsc = PersonalidadeJuridica.CPF,
                                nrInsc = "78945612300",
                                vlrAdv = 100
                            }
                        ]
                    },
                    InfoPerAnt = new()
                    {
                        IdeADC =
                        [
                            new()
                            {
                                DtAcConv = new DateTime(2025, 1, 15),
                                TpAcConv = TipoAcordoColetivo.AcordoColetivoTrabalho,
                                Descricao = "Reajuste retroativo conforme ACT 2025",
                                RemunSuc = "N",
                                IdePeriodo =
                                [
                                    new()
                                    {
                                        PerRef = "2025-01",
                                        IdeEstabLot =
                                        [
                                            new()
                                            {
                                                TpInsc = PersonalidadeJuridica.CNPJ,
                                                NrInsc = CnpjCpf,
                                                CodLotacao = "1",
                                                RemunPerAnt =
                                                [
                                                    new()
                                                    {
                                                        Matricula = "1002",
                                                        ItensRemun =
                                                        [
                                                            new()
                                                            {
                                                                CodRubr = "100",
                                                                IdeTabRubr = "0001",
                                                                VrRubr = 150,
                                                                IndApurIR = 0
                                                            }
                                                        ]
                                                    }
                                                ]
                                            }
                                        ]
                                    }
                                ]
                            }
                        ]
                    },
                    InfoComplCont = new()
                    {
                        // NatAtividade propositalmente não preenchido: campo opcional,
                        // não deve ser emitido nem causar falha de serialização.
                        CodCBO = "123456"
                    }
                }
            ]
        };
    }

    public override void ValidaInstanciasLeituraEscrita(S1200 instanciaPopulada, S1200 instanciaXml)
    {
        // TODO: verifique se os campos de instanciaXml, preenchidos a partir da leitura de um XmlDocument, 
        //       correspondem exatamente aos valores de instanciaPopulada, formado à partir do método
        //       PreencheCampos().
        instanciaPopulada.Should().NotBeNull();
        instanciaXml.Should().NotBeNull();

        // ideEvento
        instanciaXml.evtRemun.ideEvento.tpAmb.Should().Be(instanciaPopulada.evtRemun.ideEvento.tpAmb);
        instanciaXml.evtRemun.ideEvento.procEmi.Should().Be(instanciaPopulada.evtRemun.ideEvento.procEmi);
        instanciaXml.evtRemun.ideEvento.verProc.Should().Be(instanciaPopulada.evtRemun.ideEvento.verProc);
        instanciaXml.evtRemun.ideEvento.perApur.Should().Be(instanciaPopulada.evtRemun.ideEvento.perApur);

        // ideEmpregador
        instanciaXml.evtRemun.ideEmpregador.tpInsc.Should().Be(instanciaPopulada.evtRemun.ideEmpregador.tpInsc);
        instanciaXml.evtRemun.ideEmpregador.nrInsc.Should().Be(instanciaPopulada.evtRemun.ideEmpregador.nrInsc);


        // trabalhador
        instanciaXml.evtRemun.ideTrabalhador.CpfTrab.Should().Be(instanciaPopulada.evtRemun.ideTrabalhador.CpfTrab);

        // procJudTrab
        instanciaXml.evtRemun.ideTrabalhador.ProcJudTrab.Should().HaveCount(1);
        instanciaXml.evtRemun.ideTrabalhador.ProcJudTrab[0].tpProc.Should().Be(instanciaPopulada.evtRemun.ideTrabalhador.ProcJudTrab[0].tpProc);
        instanciaXml.evtRemun.ideTrabalhador.ProcJudTrab[0].nrProc.Should().Be(instanciaPopulada.evtRemun.ideTrabalhador.ProcJudTrab[0].nrProc);
        instanciaXml.evtRemun.ideTrabalhador.ProcJudTrab[0].codSusp.Should().Be(instanciaPopulada.evtRemun.ideTrabalhador.ProcJudTrab[0].codSusp);


        //// infoPerApur
        var dmdev = instanciaXml.evtRemun.dmDev.First();
        dmdev.Should().NotBeNull();
        var instanciaPopuladaDmdev = instanciaPopulada.evtRemun.dmDev.First();
        instanciaPopuladaDmdev.Should().NotBeNull();

        dmdev.IdeDmDev.Should().Be(instanciaPopuladaDmdev.IdeDmDev);
        dmdev.CodCateg.Should().Be(instanciaPopuladaDmdev.CodCateg);
        dmdev.InfoPerApur.IdeEstabLot.Should().HaveCount(1);
        instanciaPopuladaDmdev.InfoPerApur.IdeEstabLot.Should().HaveCount(1);
        dmdev.InfoPerApur.IdeEstabLot[0].TpInsc.Should().Be(instanciaPopuladaDmdev.InfoPerApur.IdeEstabLot[0].TpInsc);
        dmdev.InfoPerApur.IdeEstabLot[0].NrInsc.Should().Be(instanciaPopuladaDmdev.InfoPerApur.IdeEstabLot[0].NrInsc);
        dmdev.InfoPerApur.IdeEstabLot[0].CodLotacao.Should().Be(instanciaPopuladaDmdev.InfoPerApur.IdeEstabLot[0].CodLotacao);

        var remuneracao = dmdev.InfoPerApur.IdeEstabLot[0].RemunPerApur.First();
        var instanciaPopuladaRemuneracao = instanciaPopuladaDmdev.InfoPerApur.IdeEstabLot[0].RemunPerApur.First();

        remuneracao.Should().NotBeNull();
        instanciaPopuladaRemuneracao.Should().NotBeNull();

        remuneracao.Matricula.Should().Be(instanciaPopuladaRemuneracao.Matricula);

        remuneracao.ItensRemun.Should().HaveCount(2);
        instanciaPopuladaRemuneracao.ItensRemun.Should().HaveCount(2);

        var itemRemun = remuneracao.ItensRemun[0];
        var itemPopulado = instanciaPopuladaRemuneracao.ItensRemun[0];
        itemRemun.Should().NotBeNull();
        itemPopulado.Should().NotBeNull();
        itemRemun.CodRubr.Should().Be(itemPopulado.CodRubr);
        itemRemun.IdeTabRubr.Should().Be(itemPopulado.IdeTabRubr);
        itemRemun.QtdRubr.Should().Be(itemPopulado.QtdRubr);
        itemRemun.VrRubr.Should().Be(itemPopulado.VrRubr);
        itemRemun.IndApurIR.Should().Be(itemPopulado.IndApurIR);

        itemRemun = remuneracao.ItensRemun[1];
        itemPopulado = instanciaPopuladaRemuneracao.ItensRemun[1];
        itemRemun.Should().NotBeNull();
        itemPopulado.Should().NotBeNull();
        itemRemun.CodRubr.Should().Be(itemPopulado.CodRubr);
        itemRemun.IdeTabRubr.Should().Be(itemPopulado.IdeTabRubr);
        itemRemun.QtdRubr.Should().Be(itemPopulado.QtdRubr);
        itemRemun.VrRubr.Should().Be(itemPopulado.VrRubr);
        itemRemun.IndApurIR.Should().Be(itemPopulado.IndApurIR);

        // segundo dmDev: infoRRA (com lista de advogados), infoPerAnt (remunPerAnt) e infoComplCont
        var dmdevRRA = instanciaXml.evtRemun.dmDev[1];
        var dmdevRRAPopulada = instanciaPopulada.evtRemun.dmDev[1];

        dmdevRRA.IndRRA.Should().Be(dmdevRRAPopulada.IndRRA);
        dmdevRRA.InfoRRA.Should().NotBeNull();
        dmdevRRA.InfoRRA.tpProcRRA.Should().Be(dmdevRRAPopulada.InfoRRA.tpProcRRA);
        dmdevRRA.InfoRRA.nrProcRRA.Should().Be(dmdevRRAPopulada.InfoRRA.nrProcRRA);
        dmdevRRA.InfoRRA.descRRA.Should().Be(dmdevRRAPopulada.InfoRRA.descRRA);
        dmdevRRA.InfoRRA.qtdMesesRRA.Should().Be(dmdevRRAPopulada.InfoRRA.qtdMesesRRA);
        dmdevRRA.InfoRRA.despProcJud.vlrDespCustas.Should().Be(dmdevRRAPopulada.InfoRRA.despProcJud.vlrDespCustas);
        dmdevRRA.InfoRRA.despProcJud.vlrDespAdvogados.Should().Be(dmdevRRAPopulada.InfoRRA.despProcJud.vlrDespAdvogados);

        // ideAdv deve ser uma lista (maxOccurs=99 no leiaute), e não um único advogado
        dmdevRRA.InfoRRA.ideAdv.Should().HaveCount(2);
        dmdevRRAPopulada.InfoRRA.ideAdv.Should().HaveCount(2);
        dmdevRRA.InfoRRA.ideAdv[0].tpInsc.Should().Be(dmdevRRAPopulada.InfoRRA.ideAdv[0].tpInsc);
        dmdevRRA.InfoRRA.ideAdv[0].nrInsc.Should().Be(dmdevRRAPopulada.InfoRRA.ideAdv[0].nrInsc);
        dmdevRRA.InfoRRA.ideAdv[0].vlrAdv.Should().Be(dmdevRRAPopulada.InfoRRA.ideAdv[0].vlrAdv);
        dmdevRRA.InfoRRA.ideAdv[1].tpInsc.Should().Be(dmdevRRAPopulada.InfoRRA.ideAdv[1].tpInsc);
        dmdevRRA.InfoRRA.ideAdv[1].nrInsc.Should().Be(dmdevRRAPopulada.InfoRRA.ideAdv[1].nrInsc);
        dmdevRRA.InfoRRA.ideAdv[1].vlrAdv.Should().Be(dmdevRRAPopulada.InfoRRA.ideAdv[1].vlrAdv);

        // infoPerAnt / idePeriodo / ideEstabLot -> remunPerAnt (não remunPerApur)
        var ideADC = dmdevRRA.InfoPerAnt.IdeADC[0];
        var ideADCPopulada = dmdevRRAPopulada.InfoPerAnt.IdeADC[0];
        ideADC.DtAcConv.Should().Be(ideADCPopulada.DtAcConv);
        ideADC.TpAcConv.Should().Be(ideADCPopulada.TpAcConv);
        ideADC.Descricao.Should().Be(ideADCPopulada.Descricao);
        ideADC.RemunSuc.Should().Be(ideADCPopulada.RemunSuc);

        var estabLotAnterior = ideADC.IdePeriodo[0].IdeEstabLot[0];
        var estabLotAnteriorPopulado = ideADCPopulada.IdePeriodo[0].IdeEstabLot[0];
        estabLotAnterior.TpInsc.Should().Be(estabLotAnteriorPopulado.TpInsc);
        estabLotAnterior.NrInsc.Should().Be(estabLotAnteriorPopulado.NrInsc);
        estabLotAnterior.CodLotacao.Should().Be(estabLotAnteriorPopulado.CodLotacao);
        estabLotAnterior.RemunPerAnt.Should().HaveCount(1);
        estabLotAnterior.RemunPerAnt[0].Matricula.Should().Be(estabLotAnteriorPopulado.RemunPerAnt[0].Matricula);
        estabLotAnterior.RemunPerAnt[0].ItensRemun[0].CodRubr.Should().Be(estabLotAnteriorPopulado.RemunPerAnt[0].ItensRemun[0].CodRubr);
        estabLotAnterior.RemunPerAnt[0].ItensRemun[0].VrRubr.Should().Be(estabLotAnteriorPopulado.RemunPerAnt[0].ItensRemun[0].VrRubr);

        // infoComplCont: natAtividade não preenchido não deve gerar erro nem valor divergente
        dmdevRRA.InfoComplCont.CodCBO.Should().Be(dmdevRRAPopulada.InfoComplCont.CodCBO);
        dmdevRRA.InfoComplCont.NatAtividade.Should().Be(dmdevRRAPopulada.InfoComplCont.NatAtividade);
    }


    #region Retrocompatibilidade
    [Test]
    [TestCase(Versao.v02_04_02)]
    [TestCase(Versao.v_S_01_01_00)]
    [TestCase(Versao.v_S_01_02_00)]
    [TestCase(Versao.v_S_01_03_00)]
    public async Task ValidaLeituraXmlLegado(Versao versao)
    {
        _versao = versao;
        S1200 evento = new();
        PreencheCampos(evento);
        evento.GeraEventoID();

        string xmlContent = evento.Write();
        Evento eventoLido = await Evento.ReadAsync(xmlContent);

        eventoLido.Should().NotBeNull();
        eventoLido.Should().BeOfType<S1200>();
        eventoLido.Versao.Should().Be(versao);
        ((S1200)eventoLido).evtRemun.ideEmpregador.nrInsc.Should().Be(evento.evtRemun.ideEmpregador.nrInsc);
        ((S1200)eventoLido).evtRemun.dmDev.Should().HaveCount(evento.evtRemun.dmDev.Count);
    }
    #endregion
}