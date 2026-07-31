namespace EficazFramework.SPED.Schemas.eSocial;

public class S5001Test : BaseESocialTest<S5001>
{
    [Test]
    [TestCase(Versao.v_S_01_02_00)]
    [TestCase(Versao.v_S_01_03_00)]
    public async Task Valida(Versao versao)
    {
        _versao = versao;
        ValidationSchemaNamespace = $"http://www.esocial.gov.br/schema/evt/evtBasesTrab/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v_S_01_03_00 => Resources.Schemas.eSocial.S5001_v_S_01_03_00,
            _ => Resources.Schemas.eSocial.S5001_v_S_01_02_00
        };
        await TestaEvento();
    }

    [Test]
    public async Task Read_v_S_01_03_00()
    {
        var evento = await Evento.ReadAsync(Resources.Samples.eSocial.S5001_v_S_01_03_00);
        evento.Should().NotBeNull();
        evento.Versao.Should().Be(Versao.v_S_01_03_00);
        var evt5001 = evento as S5001;
        evt5001.Should().NotBeNull();
        evt5001.evtBasesTrab.Should().NotBeNull();
        evt5001.evtBasesTrab.ideEvento.nrRecArqBase.Should().Be("1.1.0000000000000000000");
        evt5001.evtBasesTrab.ideEvento.indApuracao.Should().Be(IndicadorApuracao.Mensal);
        evt5001.evtBasesTrab.ideEvento.perApur.Should().Be("2025-02");
        evt5001.evtBasesTrab.ideEmpregador.tpInsc.Should().Be(PersonalidadeJuridica.CNPJ);
        evt5001.evtBasesTrab.ideEmpregador.nrInsc.Should().Be("34785515");
        evt5001.evtBasesTrab.ideTrabalhador.cpfTrab.Should().Be("12345678901");

        // infoCpCalc
        evt5001.evtBasesTrab.infoCpCalc.Should().HaveCount(1);
        evt5001.evtBasesTrab.infoCpCalc[0].tpCR.Should().Be("108201");
        evt5001.evtBasesTrab.infoCpCalc[0].vrCpSeg.Should().Be(150.00m);
        evt5001.evtBasesTrab.infoCpCalc[0].vrDescSeg.Should().Be(150.00m);

        // infoCp
        evt5001.evtBasesTrab.infoCp.Should().NotBeNull();
        evt5001.evtBasesTrab.infoCp.classTrib.Should().Be("99");
        evt5001.evtBasesTrab.infoCp.ideEstabLot.Should().HaveCount(1);
        var estab = evt5001.evtBasesTrab.infoCp.ideEstabLot[0];
        estab.tpInsc.Should().Be(PersonalidadeJuridica.CNPJ);
        estab.nrInsc.Should().Be("34785515000166");
        estab.codLotacao.Should().Be("01");
        estab.infoCategIncid.Should().HaveCount(1);
        var categ = estab.infoCategIncid[0];
        categ.matricula.Should().Be("MAT123");
        categ.codCateg.Should().Be("101");
        categ.indSimples.Should().Be(IndicadorSubstSimples.NaoSubstituida);
        categ.infoBaseCS.Should().HaveCount(1);
        categ.infoBaseCS[0].ind13.Should().Be(0);
        categ.infoBaseCS[0].tpValor.Should().Be(11);
        categ.infoBaseCS[0].valor.Should().Be(2000.00m);

        // calcTerc
        categ.calcTerc.Should().HaveCount(1);
        categ.calcTerc[0].tpCR.Should().Be("121802");
        categ.calcTerc[0].vrCsSegTerc.Should().Be(30.00m);
        categ.calcTerc[0].vrDescTerc.Should().Be(30.00m);

        // infoPerRef
        categ.infoPerRef.Should().HaveCount(1);
        categ.infoPerRef[0].perRef.Should().Be("2025-01");
        categ.infoPerRef[0].ideADC.Should().HaveCount(1);
        categ.infoPerRef[0].ideADC[0].dtAcConv.Should().Be(new DateTime(2025, 1, 15));
        categ.infoPerRef[0].ideADC[0].tpAcConv.Should().Be(TipoAcordoColetivo.AcordoColetivoTrabalho);
        categ.infoPerRef[0].ideADC[0].dsc.Should().Be("Acordo coletivo");
        categ.infoPerRef[0].ideADC[0].remunSuc.Should().Be(SimNaoString.Nao);
        categ.infoPerRef[0].detInfoPerRef.Should().HaveCount(1);
        categ.infoPerRef[0].detInfoPerRef[0].ind13.Should().Be(0);
        categ.infoPerRef[0].detInfoPerRef[0].tpVrPerRef.Should().Be(11);
        categ.infoPerRef[0].detInfoPerRef[0].vrPerRef.Should().Be(500.00m);

        // infoPisPasep
        evt5001.evtBasesTrab.infoPisPasep.Should().NotBeNull();
        evt5001.evtBasesTrab.infoPisPasep.ideEstab.Should().HaveCount(1);
        var estabPis = evt5001.evtBasesTrab.infoPisPasep.ideEstab[0];
        estabPis.tpInsc.Should().Be(PersonalidadeJuridica.CNPJ);
        estabPis.nrInsc.Should().Be("34785515000166");
        estabPis.infoCategPisPasep.Should().HaveCount(1);
        var categPis = estabPis.infoCategPisPasep[0];
        categPis.matricula.Should().Be("MAT123");
        categPis.codCateg.Should().Be("101");
        categPis.infoBasePisPasep.Should().HaveCount(1);
        categPis.infoBasePisPasep[0].ind13.Should().Be(0);
        categPis.infoBasePisPasep[0].tpValorPisPasep.Should().Be(11);
        categPis.infoBasePisPasep[0].valorPisPasep.Should().Be(2000.00m);
    }

    public override void PreencheCampos(S5001 evento)
    {
        evento.Versao = _versao;
        evento.evtBasesTrab = new S5001EvtBasesTrab()
        {
            ideEvento = new S5001IdeEvento()
            {
                nrRecArqBase = "1.1.0000000000000000000",
                indApuracao = IndicadorApuracao.Mensal,
                perApur = "2025-02"
            },
            ideEmpregador = new Empregador()
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = CnpjCpf[..8]
            },
            ideTrabalhador = new S5001IdeTrabalhador()
            {
                cpfTrab = "12345678901",
                infoCompl = new S5001InfoCompl()
                {
                    sucessaoVinc = new S5001SucessaoVinc()
                    {
                        tpInsc = PersonalidadeJuridica.CNPJ,
                        nrInsc = "12345678000199",
                        matricAnt = "M123",
                        dtAdm = new DateTime(2020, 1, 1)
                    },
                    infoInterm =
                    [
                        new S5001InfoInterm()
                        {
                            dia = 15,
                            hrsTrab = _versao == Versao.v_S_01_03_00 ? "0800" : null
                        }
                    ],
                    infoComplCont =
                    [
                        new S5001InfoComplCont()
                        {
                            codCBO = "123456",
                            natAtividade = NaturezaAtividade.Urbano,
                            qtdDiasTrab = 22
                        }
                    ]
                },
                procJudTrab =
                [
                    new S5001ProcJudTrab()
                    {
                        nrProcJud = "12345678901234567890",
                        codSusp = "123456"
                    }
                ]
            },
            infoCpCalc =
            [
                new S5001InfoCpCalc()
                {
                    tpCR = "108201",
                    vrCpSeg = 150.00m,
                    vrDescSeg = 150.00m
                }
            ],
            infoCp = new S5001InfoCp()
            {
                classTrib = "99",
                ideEstabLot =
                [
                    new S5001IdeEstabLot()
                    {
                        tpInsc = PersonalidadeJuridica.CNPJ,
                        nrInsc = CnpjCpf,
                        codLotacao = "01",
                        infoCategIncid =
                        [
                            new S5001InfoCategIncid()
                            {
                                matricula = "MAT123",
                                codCateg = "101",
                                indSimples = IndicadorSubstSimples.NaoSubstituida,
                                infoBaseCS =
                                [
                                    new S5001InfoBaseCS()
                                    {
                                        ind13 = 0,
                                        tpValor = 11,
                                        valor = 2000.00m
                                    }
                                ],
                                calcTerc =
                                [
                                    new S5001CalcTerc()
                                    {
                                        tpCR = "121802",
                                        vrCsSegTerc = 30.00m,
                                        vrDescTerc = 30.00m
                                    }
                                ],
                                infoPerRef =
                                [
                                    new S5001InfoPerRef()
                                    {
                                        perRef = "2025-01",
                                        ideADC =
                                        [
                                            new S5001IdeADC()
                                            {
                                                dtAcConv = new DateTime(2025, 1, 15),
                                                tpAcConv = TipoAcordoColetivo.AcordoColetivoTrabalho,
                                                dsc = "Acordo coletivo",
                                                remunSuc = SimNaoString.Nao
                                            }
                                        ],
                                        detInfoPerRef =
                                        [
                                            new S5001DetInfoPerRef()
                                            {
                                                ind13 = 0,
                                                tpVrPerRef = 11,
                                                vrPerRef = 500.00m
                                            }
                                        ]
                                    }
                                ]
                            }
                        ]
                    }
                ]
            },
            infoPisPasep = _versao == Versao.v_S_01_03_00 ? new S5001InfoPisPasep()
            {
                ideEstab =
                [
                    new S5001IdeEstabPisPasep()
                    {
                        tpInsc = PersonalidadeJuridica.CNPJ,
                        nrInsc = CnpjCpf,
                        infoCategPisPasep =
                        [
                            new S5001InfoCategPisPasep()
                            {
                                matricula = "MAT123",
                                codCateg = "101",
                                infoBasePisPasep =
                                [
                                    new S5001InfoBasePisPasep()
                                    {
                                        ind13 = 0,
                                        tpValorPisPasep = 11,
                                        valorPisPasep = 2000.00m
                                    }
                                ]
                            }
                        ]
                    }
                ]
            } : null
        };
    }

    public override void ValidaInstanciasLeituraEscrita(S5001 instanciaPopulada, S5001 instanciaXml)
    {
        instanciaPopulada.Should().NotBeNull();
        instanciaXml.Should().NotBeNull();

        // ideEvento
        instanciaXml.evtBasesTrab.ideEvento.nrRecArqBase.Should().Be(instanciaPopulada.evtBasesTrab.ideEvento.nrRecArqBase);
        instanciaXml.evtBasesTrab.ideEvento.indApuracao.Should().Be(instanciaPopulada.evtBasesTrab.ideEvento.indApuracao);
        instanciaXml.evtBasesTrab.ideEvento.perApur.Should().Be(instanciaPopulada.evtBasesTrab.ideEvento.perApur);

        // ideEmpregador
        instanciaXml.evtBasesTrab.ideEmpregador.tpInsc.Should().Be(instanciaPopulada.evtBasesTrab.ideEmpregador.tpInsc);
        instanciaXml.evtBasesTrab.ideEmpregador.nrInsc.Should().Be(instanciaPopulada.evtBasesTrab.ideEmpregador.nrInsc);

        // ideTrabalhador
        instanciaXml.evtBasesTrab.ideTrabalhador.cpfTrab.Should().Be(instanciaPopulada.evtBasesTrab.ideTrabalhador.cpfTrab);

        // infoCompl
        var infoComplPop = instanciaPopulada.evtBasesTrab.ideTrabalhador.infoCompl;
        var infoComplXml = instanciaXml.evtBasesTrab.ideTrabalhador.infoCompl;
        infoComplPop.Should().NotBeNull();
        infoComplXml.Should().NotBeNull();
        infoComplXml.sucessaoVinc.tpInsc.Should().Be(infoComplPop.sucessaoVinc.tpInsc);
        infoComplXml.sucessaoVinc.nrInsc.Should().Be(infoComplPop.sucessaoVinc.nrInsc);
        infoComplXml.sucessaoVinc.matricAnt.Should().Be(infoComplPop.sucessaoVinc.matricAnt);
        infoComplXml.sucessaoVinc.dtAdm.Should().Be(infoComplPop.sucessaoVinc.dtAdm);

        infoComplXml.infoInterm.Should().HaveCount(1);
        infoComplXml.infoInterm[0].dia.Should().Be(infoComplPop.infoInterm[0].dia);
        infoComplXml.infoInterm[0].hrsTrab.Should().Be(infoComplPop.infoInterm[0].hrsTrab);

        infoComplXml.infoComplCont.Should().HaveCount(1);
        infoComplXml.infoComplCont[0].codCBO.Should().Be(infoComplPop.infoComplCont[0].codCBO);
        infoComplXml.infoComplCont[0].natAtividade.Should().Be(infoComplPop.infoComplCont[0].natAtividade);
        infoComplXml.infoComplCont[0].qtdDiasTrab.Should().Be(infoComplPop.infoComplCont[0].qtdDiasTrab);

        // procJudTrab
        instanciaXml.evtBasesTrab.ideTrabalhador.procJudTrab.Should().HaveCount(1);
        instanciaXml.evtBasesTrab.ideTrabalhador.procJudTrab[0].nrProcJud.Should().Be(instanciaPopulada.evtBasesTrab.ideTrabalhador.procJudTrab[0].nrProcJud);
        instanciaXml.evtBasesTrab.ideTrabalhador.procJudTrab[0].codSusp.Should().Be(instanciaPopulada.evtBasesTrab.ideTrabalhador.procJudTrab[0].codSusp);

        // infoCpCalc
        instanciaXml.evtBasesTrab.infoCpCalc.Should().HaveCount(1);
        instanciaXml.evtBasesTrab.infoCpCalc[0].tpCR.Should().Be(instanciaPopulada.evtBasesTrab.infoCpCalc[0].tpCR);
        instanciaXml.evtBasesTrab.infoCpCalc[0].vrCpSeg.Should().Be(instanciaPopulada.evtBasesTrab.infoCpCalc[0].vrCpSeg);
        instanciaXml.evtBasesTrab.infoCpCalc[0].vrDescSeg.Should().Be(instanciaPopulada.evtBasesTrab.infoCpCalc[0].vrDescSeg);

        // infoCp
        instanciaXml.evtBasesTrab.infoCp.classTrib.Should().Be(instanciaPopulada.evtBasesTrab.infoCp.classTrib);
        instanciaXml.evtBasesTrab.infoCp.ideEstabLot.Should().HaveCount(1);
        var estabXml = instanciaXml.evtBasesTrab.infoCp.ideEstabLot[0];
        var estabPop = instanciaPopulada.evtBasesTrab.infoCp.ideEstabLot[0];
        estabXml.tpInsc.Should().Be(estabPop.tpInsc);
        estabXml.nrInsc.Should().Be(estabPop.nrInsc);
        estabXml.codLotacao.Should().Be(estabPop.codLotacao);

        var categXml = estabXml.infoCategIncid[0];
        var categPop = estabPop.infoCategIncid[0];
        categXml.matricula.Should().Be(categPop.matricula);
        categXml.codCateg.Should().Be(categPop.codCateg);
        categXml.indSimples.Should().Be(categPop.indSimples);

        categXml.infoBaseCS.Should().HaveCount(1);
        categXml.infoBaseCS[0].ind13.Should().Be(categPop.infoBaseCS[0].ind13);
        categXml.infoBaseCS[0].tpValor.Should().Be(categPop.infoBaseCS[0].tpValor);
        categXml.infoBaseCS[0].valor.Should().Be(categPop.infoBaseCS[0].valor);

        categXml.calcTerc.Should().HaveCount(1);
        categXml.calcTerc[0].tpCR.Should().Be(categPop.calcTerc[0].tpCR);
        categXml.calcTerc[0].vrCsSegTerc.Should().Be(categPop.calcTerc[0].vrCsSegTerc);
        categXml.calcTerc[0].vrDescTerc.Should().Be(categPop.calcTerc[0].vrDescTerc);

        categXml.infoPerRef.Should().HaveCount(1);
        var perRefXml = categXml.infoPerRef[0];
        var perRefPop = categPop.infoPerRef[0];
        perRefXml.perRef.Should().Be(perRefPop.perRef);

        perRefXml.ideADC.Should().HaveCount(1);
        perRefXml.ideADC[0].dtAcConv.Should().Be(perRefPop.ideADC[0].dtAcConv);
        perRefXml.ideADC[0].tpAcConv.Should().Be(perRefPop.ideADC[0].tpAcConv);
        perRefXml.ideADC[0].dsc.Should().Be(perRefPop.ideADC[0].dsc);
        perRefXml.ideADC[0].remunSuc.Should().Be(perRefPop.ideADC[0].remunSuc);

        perRefXml.detInfoPerRef.Should().HaveCount(1);
        perRefXml.detInfoPerRef[0].ind13.Should().Be(perRefPop.detInfoPerRef[0].ind13);
        perRefXml.detInfoPerRef[0].tpVrPerRef.Should().Be(perRefPop.detInfoPerRef[0].tpVrPerRef);
        perRefXml.detInfoPerRef[0].vrPerRef.Should().Be(perRefPop.detInfoPerRef[0].vrPerRef);

        // infoPisPasep
        if (instanciaPopulada.evtBasesTrab.infoPisPasep != null)
        {
            instanciaXml.evtBasesTrab.infoPisPasep.Should().NotBeNull();
            instanciaXml.evtBasesTrab.infoPisPasep.ideEstab.Should().HaveCount(1);
            var estabPisXml = instanciaXml.evtBasesTrab.infoPisPasep.ideEstab[0];
            var estabPisPop = instanciaPopulada.evtBasesTrab.infoPisPasep.ideEstab[0];
            estabPisXml.tpInsc.Should().Be(estabPisPop.tpInsc);
            estabPisXml.nrInsc.Should().Be(estabPisPop.nrInsc);

            var categPisXml = estabPisXml.infoCategPisPasep[0];
            var categPisPop = estabPisPop.infoCategPisPasep[0];
            categPisXml.matricula.Should().Be(categPisPop.matricula);
            categPisXml.codCateg.Should().Be(categPisPop.codCateg);

            categPisXml.infoBasePisPasep.Should().HaveCount(1);
            categPisXml.infoBasePisPasep[0].ind13.Should().Be(categPisPop.infoBasePisPasep[0].ind13);
            categPisXml.infoBasePisPasep[0].tpValorPisPasep.Should().Be(categPisPop.infoBasePisPasep[0].tpValorPisPasep);
            categPisXml.infoBasePisPasep[0].valorPisPasep.Should().Be(categPisPop.infoBasePisPasep[0].valorPisPasep);
        }
    }
}
