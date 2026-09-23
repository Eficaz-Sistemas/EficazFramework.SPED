namespace EficazFramework.SPED.Schemas.eSocial;

public class S5003Test : BaseESocialTest<S5003>
{
    [Test]
    [TestCase(Versao.v_S_01_02_00)]
    [TestCase(Versao.v_S_01_03_00)]
    public async Task Valida(Versao versao)
    {
        _versao = versao;
        ValidationSchemaNamespace = $"http://www.esocial.gov.br/schema/evt/evtBasesFGTS/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v_S_01_03_00 => Resources.Schemas.eSocial.S5003_v_S_01_03_00,
            _ => Resources.Schemas.eSocial.S5003_v_S_01_02_00
        };
        await TestaEvento();
    }

    [Test]
    public async Task Read_v_S_01_03_00()
    {
        var evento = await Evento.ReadAsync(Resources.Samples.eSocial.S5003_v_S_01_03_00);
        evento.Should().NotBeNull();
        evento.Versao.Should().Be(Versao.v_S_01_03_00);
        var evt5003 = evento as S5003;
        evt5003.Should().NotBeNull();
        evt5003.evtBasesFGTS.Should().NotBeNull();
        evt5003.evtBasesFGTS.ideEvento.nrRecArqBase.Should().Be("1.1.0000000000000000000");
        evt5003.evtBasesFGTS.ideEvento.indApuracao.Should().Be(IndicadorApuracao.Mensal);
        evt5003.evtBasesFGTS.ideEvento.perApur.Should().Be("2025-02");
        evt5003.evtBasesFGTS.ideEmpregador.tpInsc.Should().Be(PersonalidadeJuridica.CNPJ);
        evt5003.evtBasesFGTS.ideEmpregador.nrInsc.Should().Be("34785515");
        evt5003.evtBasesFGTS.ideTrabalhador.cpfTrab.Should().Be("12345678901");

        // infoFGTS
        evt5003.evtBasesFGTS.infoFGTS.Should().NotBeNull();
        evt5003.evtBasesFGTS.infoFGTS.dtVenc.Should().Be(new DateTime(2025, 3, 7));
        evt5003.evtBasesFGTS.infoFGTS.classTrib.Should().Be("04");

        // ideEstab
        evt5003.evtBasesFGTS.infoFGTS.ideEstab.Should().HaveCount(1);
        var estab = evt5003.evtBasesFGTS.infoFGTS.ideEstab[0];
        estab.tpInsc.Should().Be(PersonalidadeJuridica.CNPJ);
        estab.nrInsc.Should().Be("34785515000166");

        // ideLotacao
        estab.ideLotacao.Should().HaveCount(1);
        var lotacao = estab.ideLotacao[0];
        lotacao.codLotacao.Should().Be("LOT01");
        lotacao.tpLotacao.Should().Be("01");
        lotacao.tpInsc.Should().Be(PersonalidadeJuridica.CNPJ);
        lotacao.nrInsc.Should().Be("34785515000166");

        // infoTrabFGTS
        lotacao.infoTrabFGTS.Should().HaveCount(1);
        var trab = lotacao.infoTrabFGTS[0];
        trab.matricula.Should().Be("MAT123");
        trab.codCateg.Should().Be("101");
        trab.categOrig.Should().Be("101");
        trab.tpRegTrab.Should().Be(VinculoTrabalhista.CLT);
        trab.remunSuc.Should().Be(SimNaoString.Nao);
        trab.dtDeslig.Should().Be(new DateTime(2025, 2, 28));
        trab.mtvDeslig.Should().Be("02");
        trab.dtTerm.Should().Be(new DateTime(2025, 2, 28));
        trab.mtvDesligTSV.Should().Be("01");

        // sucessaoVinc
        trab.sucessaoVinc.Should().NotBeNull();
        trab.sucessaoVinc.tpInsc.Should().Be(PersonalidadeJuridica.CNPJ);
        trab.sucessaoVinc.nrInsc.Should().Be("12345678000199");
        trab.sucessaoVinc.matricAnt.Should().Be("MATOLD");
        trab.sucessaoVinc.dtAdm.Should().Be(new DateTime(2020, 1, 1));

        // infoBaseFGTS
        trab.infoBaseFGTS.Should().NotBeNull();
        trab.infoBaseFGTS.basePerApur.Should().HaveCount(1);
        var basePerApur = trab.infoBaseFGTS.basePerApur[0];
        basePerApur.tpValor.Should().Be((byte)11);
        basePerApur.indIncid.Should().Be(IndicadorIncidenciaFGTS.Normal);
        basePerApur.remFGTS.Should().Be(3000.00m);
        basePerApur.dpsFGTS.Should().Be(240.00m);
        basePerApur.notAFT.Should().Be("123456789");
        basePerApur.natRubr.Should().Be("1000");

        basePerApur.detRubrSusp.Should().HaveCount(1);
        var detRubrSusp = basePerApur.detRubrSusp[0];
        detRubrSusp.codRubr.Should().Be("RUB01");
        detRubrSusp.ideTabRubr.Should().Be("TAB01");
        detRubrSusp.vrRubr.Should().Be(100.00m);
        detRubrSusp.ideProcessoFGTS.Should().HaveCount(1);
        detRubrSusp.ideProcessoFGTS[0].nrProc.Should().Be("12345678901234567890");

        // infoBasePerAntE
        trab.infoBaseFGTS.infoBasePerAntE.Should().HaveCount(1);
        var infoBasePerAntE = trab.infoBaseFGTS.infoBasePerAntE[0];
        infoBasePerAntE.perRef.Should().Be("2024-12");
        infoBasePerAntE.tpAcConv.Should().Be(TipoAcordoColetivo.ConversaoLicencaSaudeAcidenteTrabalho);
        infoBasePerAntE.basePerAntE.Should().HaveCount(1);
        var basePerAntE = infoBasePerAntE.basePerAntE[0];
        basePerAntE.tpValorE.Should().Be((byte)13);
        basePerAntE.indIncidE.Should().Be(IndicadorIncidenciaFGTS.Normal);
        basePerAntE.remFGTSE.Should().Be(1500.00m);
        basePerAntE.dpsFGTSE.Should().Be(120.00m);
        basePerAntE.detRubrSusp.Should().HaveCount(1);
        basePerAntE.detRubrSusp[0].codRubr.Should().Be("RUB02");

        // procCS
        trab.procCS.Should().NotBeNull();
        trab.procCS.nrProcJud.Should().Be("12345678901234567890");

        // eConsignado
        trab.eConsignado.Should().HaveCount(1);
        trab.eConsignado[0].instFinanc.Should().Be("001");
        trab.eConsignado[0].nrContrato.Should().Be("12345678");
        trab.eConsignado[0].vreConsignado.Should().Be(150.00m);
    }

    public override void PreencheCampos(S5003 evento)
    {
        bool isV0103 = _versao == Versao.v_S_01_03_00;
        evento.Versao = _versao;
        evento.evtBasesFGTS = new S5003EvtBasesFGTS()
        {
            ideEvento = new S5003IdeEvento()
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
            ideTrabalhador = new S5003IdeTrabalhador()
            {
                cpfTrab = "12345678901"
            },
            infoFGTS = new S5003InfoFGTS()
            {
                dtVenc = new DateTime(2025, 3, 7),
                classTrib = "04",
                ideEstab =
                [
                    new S5003IdeEstab()
                    {
                        tpInsc = PersonalidadeJuridica.CNPJ,
                        nrInsc = "34785515000166",
                        ideLotacao =
                        [
                            new S5003IdeLotacao()
                            {
                                codLotacao = "LOT01",
                                tpLotacao = "01",
                                tpInsc = PersonalidadeJuridica.CNPJ,
                                nrInsc = "34785515000166",
                                infoTrabFGTS =
                                [
                                    new S5003InfoTrabFGTS()
                                    {
                                        matricula = "MAT123",
                                        codCateg = "101",
                                        categOrig = "101",
                                        tpRegTrab = VinculoTrabalhista.CLT,
                                        remunSuc = SimNaoString.Nao,
                                        dtDeslig = new DateTime(2025, 2, 28),
                                        mtvDeslig = "02",
                                        dtTerm = new DateTime(2025, 2, 28),
                                        mtvDesligTSV = "01",
                                        sucessaoVinc = new S5003SucessaoVinc()
                                        {
                                            tpInsc = PersonalidadeJuridica.CNPJ,
                                            nrInsc = "12345678000199",
                                            matricAnt = "MATOLD",
                                            dtAdm = new DateTime(2020, 1, 1)
                                        },
                                        infoBaseFGTS = new S5003InfoBaseFGTS()
                                        {
                                            basePerApur =
                                            [
                                                new S5003BasePerApur()
                                                {
                                                    tpValor = 11,
                                                    indIncid = IndicadorIncidenciaFGTS.Normal,
                                                    remFGTS = 3000.00m,
                                                    dpsFGTS = 240.00m,
                                                    notAFT = isV0103 ? "123456789" : null,
                                                    natRubr = isV0103 ? "1000" : null,
                                                    detRubrSusp =
                                                    [
                                                        new S5003DetRubrSusp()
                                                        {
                                                            codRubr = "RUB01",
                                                            ideTabRubr = "TAB01",
                                                            vrRubr = 100.00m,
                                                            ideProcessoFGTS =
                                                            [
                                                                new S5003IdeProcessoFGTS()
                                                                {
                                                                    nrProc = "12345678901234567890"
                                                                }
                                                            ]
                                                        }
                                                    ]
                                                }
                                            ],
                                            infoBasePerAntE =
                                            [
                                                new S5003InfoBasePerAntE()
                                                {
                                                    perRef = "2024-12",
                                                    tpAcConv = TipoAcordoColetivo.ConversaoLicencaSaudeAcidenteTrabalho,
                                                    basePerAntE =
                                                    [
                                                        new S5003BasePerAntE()
                                                        {
                                                            tpValorE = 13,
                                                            indIncidE = IndicadorIncidenciaFGTS.Normal,
                                                            remFGTSE = 1500.00m,
                                                            dpsFGTSE = 120.00m,
                                                            detRubrSusp =
                                                            [
                                                                new S5003DetRubrSusp()
                                                                {
                                                                    codRubr = "RUB02",
                                                                    ideTabRubr = "TAB01",
                                                                    vrRubr = 50.00m,
                                                                    ideProcessoFGTS =
                                                                    [
                                                                        new S5003IdeProcessoFGTS()
                                                                        {
                                                                            nrProc = "12345678901234567890"
                                                                        }
                                                                    ]
                                                                }
                                                            ]
                                                        }
                                                    ]
                                                }
                                            ]
                                        },
                                        procCS = new S5003ProcCS()
                                        {
                                            nrProcJud = "12345678901234567890"
                                        },
                                        eConsignado =
                                        [
                                            new S5003EConsignado()
                                            {
                                                instFinanc = "001",
                                                nrContrato = "12345678",
                                                vreConsignado = 150.00m
                                            }
                                        ]
                                    }
                                ]
                            }
                        ]
                    }
                ]
            }
        };
    }

    public override void ValidaInstanciasLeituraEscrita(S5003 instanciaPopulada, S5003 instanciaXml)
    {
        instanciaPopulada.Should().NotBeNull();
        instanciaXml.Should().NotBeNull();

        // ideEvento
        instanciaXml.evtBasesFGTS.ideEvento.nrRecArqBase.Should().Be(instanciaPopulada.evtBasesFGTS.ideEvento.nrRecArqBase);
        instanciaXml.evtBasesFGTS.ideEvento.indApuracao.Should().Be(instanciaPopulada.evtBasesFGTS.ideEvento.indApuracao);
        instanciaXml.evtBasesFGTS.ideEvento.perApur.Should().Be(instanciaPopulada.evtBasesFGTS.ideEvento.perApur);

        // ideEmpregador
        instanciaXml.evtBasesFGTS.ideEmpregador.tpInsc.Should().Be(instanciaPopulada.evtBasesFGTS.ideEmpregador.tpInsc);
        instanciaXml.evtBasesFGTS.ideEmpregador.nrInsc.Should().Be(instanciaPopulada.evtBasesFGTS.ideEmpregador.nrInsc);

        // ideTrabalhador
        instanciaXml.evtBasesFGTS.ideTrabalhador.cpfTrab.Should().Be(instanciaPopulada.evtBasesFGTS.ideTrabalhador.cpfTrab);

        // infoFGTS
        instanciaXml.evtBasesFGTS.infoFGTS.Should().NotBeNull();
        instanciaXml.evtBasesFGTS.infoFGTS.dtVenc.Should().Be(instanciaPopulada.evtBasesFGTS.infoFGTS.dtVenc);
        instanciaXml.evtBasesFGTS.infoFGTS.classTrib.Should().Be(instanciaPopulada.evtBasesFGTS.infoFGTS.classTrib);

        // ideEstab
        instanciaXml.evtBasesFGTS.infoFGTS.ideEstab.Should().HaveCount(1);
        var estabPop = instanciaPopulada.evtBasesFGTS.infoFGTS.ideEstab[0];
        var estabXml = instanciaXml.evtBasesFGTS.infoFGTS.ideEstab[0];
        estabXml.tpInsc.Should().Be(estabPop.tpInsc);
        estabXml.nrInsc.Should().Be(estabPop.nrInsc);

        // ideLotacao
        estabXml.ideLotacao.Should().HaveCount(1);
        var lotPop = estabPop.ideLotacao[0];
        var lotXml = estabXml.ideLotacao[0];
        lotXml.codLotacao.Should().Be(lotPop.codLotacao);
        lotXml.tpLotacao.Should().Be(lotPop.tpLotacao);
        lotXml.tpInsc.Should().Be(lotPop.tpInsc);
        lotXml.nrInsc.Should().Be(lotPop.nrInsc);

        // infoTrabFGTS
        lotXml.infoTrabFGTS.Should().HaveCount(1);
        var trabPop = lotPop.infoTrabFGTS[0];
        var trabXml = lotXml.infoTrabFGTS[0];
        trabXml.matricula.Should().Be(trabPop.matricula);
        trabXml.codCateg.Should().Be(trabPop.codCateg);
        trabXml.categOrig.Should().Be(trabPop.categOrig);
        trabXml.tpRegTrab.Should().Be(trabPop.tpRegTrab);
        trabXml.remunSuc.Should().Be(trabPop.remunSuc);
        trabXml.dtDeslig.Should().Be(trabPop.dtDeslig);
        trabXml.mtvDeslig.Should().Be(trabPop.mtvDeslig);
        trabXml.dtTerm.Should().Be(trabPop.dtTerm);
        trabXml.mtvDesligTSV.Should().Be(trabPop.mtvDesligTSV);

        // sucessaoVinc
        trabXml.sucessaoVinc.Should().NotBeNull();
        trabXml.sucessaoVinc.tpInsc.Should().Be(trabPop.sucessaoVinc.tpInsc);
        trabXml.sucessaoVinc.nrInsc.Should().Be(trabPop.sucessaoVinc.nrInsc);
        trabXml.sucessaoVinc.matricAnt.Should().Be(trabPop.sucessaoVinc.matricAnt);
        trabXml.sucessaoVinc.dtAdm.Should().Be(trabPop.sucessaoVinc.dtAdm);

        // infoBaseFGTS
        trabXml.infoBaseFGTS.Should().NotBeNull();

        // basePerApur
        trabXml.infoBaseFGTS.basePerApur.Should().HaveCount(1);
        var basePop = trabPop.infoBaseFGTS.basePerApur[0];
        var baseXml = trabXml.infoBaseFGTS.basePerApur[0];
        baseXml.tpValor.Should().Be(basePop.tpValor);
        baseXml.indIncid.Should().Be(basePop.indIncid);
        baseXml.remFGTS.Should().Be(basePop.remFGTS);
        baseXml.dpsFGTS.Should().Be(basePop.dpsFGTS);
        baseXml.notAFT.Should().Be(basePop.notAFT);
        baseXml.natRubr.Should().Be(basePop.natRubr);

        baseXml.detRubrSusp.Should().HaveCount(1);
        baseXml.detRubrSusp[0].codRubr.Should().Be(basePop.detRubrSusp[0].codRubr);
        baseXml.detRubrSusp[0].ideTabRubr.Should().Be(basePop.detRubrSusp[0].ideTabRubr);
        baseXml.detRubrSusp[0].vrRubr.Should().Be(basePop.detRubrSusp[0].vrRubr);
        baseXml.detRubrSusp[0].ideProcessoFGTS.Should().HaveCount(1);
        baseXml.detRubrSusp[0].ideProcessoFGTS[0].nrProc.Should().Be(basePop.detRubrSusp[0].ideProcessoFGTS[0].nrProc);

        // infoBasePerAntE
        trabXml.infoBaseFGTS.infoBasePerAntE.Should().HaveCount(1);
        var antPop = trabPop.infoBaseFGTS.infoBasePerAntE[0];
        var antXml = trabXml.infoBaseFGTS.infoBasePerAntE[0];
        antXml.perRef.Should().Be(antPop.perRef);
        antXml.tpAcConv.Should().Be(antPop.tpAcConv);

        antXml.basePerAntE.Should().HaveCount(1);
        antXml.basePerAntE[0].tpValorE.Should().Be(antPop.basePerAntE[0].tpValorE);
        antXml.basePerAntE[0].indIncidE.Should().Be(antPop.basePerAntE[0].indIncidE);
        antXml.basePerAntE[0].remFGTSE.Should().Be(antPop.basePerAntE[0].remFGTSE);
        antXml.basePerAntE[0].dpsFGTSE.Should().Be(antPop.basePerAntE[0].dpsFGTSE);

        antXml.basePerAntE[0].detRubrSusp.Should().HaveCount(1);
        antXml.basePerAntE[0].detRubrSusp[0].codRubr.Should().Be(antPop.basePerAntE[0].detRubrSusp[0].codRubr);

        // procCS
        trabXml.procCS.Should().NotBeNull();
        trabXml.procCS.nrProcJud.Should().Be(trabPop.procCS.nrProcJud);

        // eConsignado
        trabXml.eConsignado.Should().HaveCount(1);
        trabXml.eConsignado[0].instFinanc.Should().Be(trabPop.eConsignado[0].instFinanc);
        trabXml.eConsignado[0].nrContrato.Should().Be(trabPop.eConsignado[0].nrContrato);
        trabXml.eConsignado[0].vreConsignado.Should().Be(trabPop.eConsignado[0].vreConsignado);
    }
}
