namespace EficazFramework.SPED.Schemas.eSocial;

public class S5011Test : BaseESocialTest<S5011>
{
    [Test]
    [TestCase(Versao.v_S_01_02_00)]
    [TestCase(Versao.v_S_01_03_00)]
    public async Task Valida(Versao versao)
    {
        _versao = versao;
        ValidationSchemaNamespace = $"http://www.esocial.gov.br/schema/evt/evtCS/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v_S_01_03_00 => Resources.Schemas.eSocial.S5011_v_S_01_03_00,
            _ => Resources.Schemas.eSocial.S5011_v_S_01_02_00
        };
        await TestaEvento();
    }

    [Test]
    public async Task Read_v_S_01_03_00()
    {
        var evento = await Evento.ReadAsync(Resources.Samples.eSocial.S5011_v_S_01_03_00);
        evento.Should().NotBeNull();
        evento.Versao.Should().Be(Versao.v_S_01_03_00);
        var evt5011 = evento as S5011;
        evt5011.Should().NotBeNull();
        evt5011.evtCS.Should().NotBeNull();
        evt5011.evtCS.ideEvento.indApuracao.Should().Be(IndicadorApuracao.Mensal);
        evt5011.evtCS.ideEvento.perApur.Should().Be("2025-02");
        evt5011.evtCS.ideEmpregador.tpInsc.Should().Be(PersonalidadeJuridica.CNPJ);
        evt5011.evtCS.ideEmpregador.nrInsc.Should().Be("34785515");

        // infoCS
        evt5011.evtCS.infoCS.Should().NotBeNull();
        evt5011.evtCS.infoCS.nrRecArqBase.Should().Be("1.1.0000000000000000000");
        evt5011.evtCS.infoCS.indExistInfo.Should().Be(IndicadorExistenciaInfoCS.ComApuracao);

        // infoCPSeg
        evt5011.evtCS.infoCS.infoCPSeg.Should().NotBeNull();
        evt5011.evtCS.infoCS.infoCPSeg.vrDescCP.Should().Be(500.00m);
        evt5011.evtCS.infoCS.infoCPSeg.vrCpSeg.Should().Be(500.00m);

        // infoContrib
        evt5011.evtCS.infoCS.infoContrib.Should().NotBeNull();
        evt5011.evtCS.infoCS.infoContrib.classTrib.Should().Be("01");
        evt5011.evtCS.infoCS.infoContrib.infoPJ.Should().NotBeNull();
        evt5011.evtCS.infoCS.infoContrib.infoPJ.indCoop.Should().Be(IndicadorCooperativa.Nao);
        evt5011.evtCS.infoCS.infoContrib.infoPJ.indConstr.Should().Be(SimNaoByte.Nao);
        evt5011.evtCS.infoCS.infoContrib.infoPJ.indSubstPatr.Should().Be(IndicadorSubstPatronal.IntegralmenteSubstituida);
        evt5011.evtCS.infoCS.infoContrib.infoPJ.percRedContrib.Should().Be(0.00m);
        evt5011.evtCS.infoCS.infoContrib.infoPJ.percTransf.Should().BeNull();
        evt5011.evtCS.infoCS.infoContrib.infoPJ.indTribFolhaPisPasep.Should().BeNull();
        evt5011.evtCS.infoCS.infoContrib.infoPJ.infoAtConc.Should().NotBeNull();
        evt5011.evtCS.infoCS.infoContrib.infoPJ.infoAtConc.fatorMes.Should().Be(100.00m);
        evt5011.evtCS.infoCS.infoContrib.infoPJ.infoAtConc.fator13.Should().Be(100.00m);

        // ideEstab
        evt5011.evtCS.infoCS.ideEstab.Should().HaveCount(1);
        var estab = evt5011.evtCS.infoCS.ideEstab[0];
        estab.tpInsc.Should().Be(PersonalidadeJuridica.CNPJ);
        estab.nrInsc.Should().Be("34785515000166");
        estab.infoEstab.Should().NotBeNull();
        estab.infoEstab.cnaePrep.Should().Be("6201500");
        estab.infoEstab.cnpjResp.Should().Be("34785515000166");
        estab.infoEstab.aliqRat.Should().Be(2);
        estab.infoEstab.fap.Should().Be(1.0000m);
        estab.infoEstab.aliqRatAjust.Should().Be(2.0000m);
        estab.infoEstab.infoEstabRef.Should().NotBeNull();
        estab.infoEstab.infoEstabRef.aliqRat.Should().Be(2);
        estab.infoEstab.infoEstabRef.fap.Should().Be(1.0000m);
        estab.infoEstab.infoEstabRef.aliqRatAjust.Should().Be(2.0000m);
        estab.infoEstab.infoComplObra.Should().NotBeNull();
        estab.infoEstab.infoComplObra.indSubstPatrObra.Should().Be(IndicadorSubstPatronalObra.ContribPatSubstituida);

        // ideLotacao
        estab.ideLotacao.Should().HaveCount(1);
        var lotacao = estab.ideLotacao[0];
        lotacao.codLotacao.Should().Be("LOT01");
        lotacao.fpas.Should().Be("515");
        lotacao.codTercs.Should().Be("0001");
        lotacao.codTercsSusp.Should().Be("0000");
        lotacao.infoTercSusp.Should().HaveCount(1);
        lotacao.infoTercSusp[0].codTerc.Should().Be("0001");

        // infoEmprParcial
        lotacao.infoEmprParcial.Should().NotBeNull();
        lotacao.infoEmprParcial.tpInscContrat.Should().Be(PersonalidadeJuridica.CNPJ);
        lotacao.infoEmprParcial.nrInscContrat.Should().Be("12345678000199");
        lotacao.infoEmprParcial.tpInscProp.Should().Be(PersonalidadeJuridica.CNPJ);
        lotacao.infoEmprParcial.nrInscProp.Should().Be("12345678000199");
        lotacao.infoEmprParcial.cnoObra.Should().Be("123456789012");

        // dadosOpPort
        lotacao.dadosOpPort.Should().NotBeNull();
        lotacao.dadosOpPort.cnpjOpPortuario.Should().Be("12345678000199");
        lotacao.dadosOpPort.aliqRat.Should().Be(2);
        lotacao.dadosOpPort.fap.Should().Be(1.0000m);
        lotacao.dadosOpPort.aliqRatAjust.Should().Be(2.0000m);

        // basesRemun
        lotacao.basesRemun.Should().HaveCount(1);
        var baseRemun = lotacao.basesRemun[0];
        baseRemun.indIncid.Should().Be(IndicadorIncidenciaCS.Normal);
        baseRemun.codCateg.Should().Be("101");
        baseRemun.basesCp.Should().NotBeNull();
        baseRemun.basesCp.vrBcCp00.Should().Be(5000.00m);
        baseRemun.basesCp13.Should().NotBeNull();

        // basesAvNPort
        lotacao.basesAvNPort.Should().NotBeNull();
        lotacao.infoSubstPatrOpPort.Should().NotBeNull();
        lotacao.infoSubstPatrOpPort.cnpjOpPortuario.Should().Be("12345678000199");

        // basesAquis
        estab.basesAquis.Should().HaveCount(1);
        estab.basesAquis[0].indAquis.Should().Be(IndicadorAquisicaoS1250.ProdRuralPF);
        estab.basesAquis[0].vlrAquis.Should().Be(10000.00m);

        // basesComerc
        estab.basesComerc.Should().HaveCount(1);
        estab.basesComerc[0].indComerc.Should().Be(IndicadorComercializacaoS1260.VarejoConsFinalOuProdRural);
        estab.basesComerc[0].vrBcComPR.Should().Be(5000.00m);

        // infoCREstab
        estab.infoCREstab.Should().HaveCount(1);
        estab.infoCREstab[0].tpCR.Should().Be("108201");
        estab.infoCREstab[0].vrCR.Should().Be(1000.00m);

        // basesPisPasep
        estab.basesPisPasep.Should().NotBeNull();
        estab.basesPisPasep.vrBcPisPasep.Should().Be(5000.00m);

        // infoCRContrib
        evt5011.evtCS.infoCS.infoCRContrib.Should().HaveCount(1);
        evt5011.evtCS.infoCS.infoCRContrib[0].tpCR.Should().Be("108201");
        evt5011.evtCS.infoCS.infoCRContrib[0].vrCR.Should().Be(1000.00m);
    }

    public override void PreencheCampos(S5011 evento)
    {
        evento.Versao = _versao;
        evento.evtCS = new S5011EvtCS()
        {
            ideEvento = new S5011IdeEvento()
            {
                indApuracao = IndicadorApuracao.Mensal,
                perApur = "2025-02"
            },
            ideEmpregador = new Empregador()
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = CnpjCpf.Substring(0, 8)
            },
            infoCS = new S5011InfoCS()
            {
                nrRecArqBase = "1.1.0000000000000000000",
                indExistInfo = IndicadorExistenciaInfoCS.ComApuracao,
                infoCPSeg = new S5011InfoCPSeg()
                {
                    vrDescCP = 500.00m,
                    vrCpSeg = 500.00m
                },
                infoContrib = new S5011InfoContrib()
                {
                    classTrib = "01",
                    infoPJ = new S5011InfoPJ()
                    {
                        indCoop = IndicadorCooperativa.Nao,
                        indConstr = SimNaoByte.Nao,
                        indSubstPatr = IndicadorSubstPatronal.IntegralmenteSubstituida,
                        percRedContrib = 0.00m,
                        percTransf = _versao == Versao.v_S_01_03_00 ? PercentualTransformacao.Perc20 : null,
                        indTribFolhaPisPasep = _versao == Versao.v_S_01_03_00 ? SimNaoString.Sim : null,
                        infoAtConc = new S5011InfoAtConc()
                        {
                            fatorMes = 100.00m,
                            fator13 = 100.00m
                        }
                    }
                },
                ideEstab =
                [
                    new S5011IdeEstab()
                    {
                        tpInsc = PersonalidadeJuridica.CNPJ,
                        nrInsc = CnpjCpf,
                        infoEstab = new S5011InfoEstab()
                        {
                            cnaePrep = "6201500",
                            cnpjResp = CnpjCpf,
                            aliqRat = 2,
                            fap = 1.0000m,
                            aliqRatAjust = 2.0000m,
                            infoEstabRef = new S5011InfoEstabRef()
                            {
                                aliqRat = 2,
                                fap = 1.0000m,
                                aliqRatAjust = 2.0000m
                            },
                            infoComplObra = new S5011InfoComplObra()
                            {
                                indSubstPatrObra = IndicadorSubstPatronalObra.ContribPatSubstituida
                            }
                        },
                        ideLotacao =
                        [
                            new S5011IdeLotacao()
                            {
                                codLotacao = "LOT01",
                                fpas = "515",
                                codTercs = "0001",
                                codTercsSusp = "0000",
                                infoTercSusp =
                                [
                                    new S5011InfoTercSusp()
                                    {
                                        codTerc = "0001"
                                    }
                                ],
                                infoEmprParcial = new S5011InfoEmprParcial()
                                {
                                    tpInscContrat = PersonalidadeJuridica.CNPJ,
                                    nrInscContrat = "12345678000199",
                                    tpInscProp = PersonalidadeJuridica.CNPJ,
                                    nrInscProp = "12345678000199",
                                    cnoObra = "123456789012"
                                },
                                dadosOpPort = new S5011DadosOpPort()
                                {
                                    cnpjOpPortuario = "12345678000199",
                                    aliqRat = 2,
                                    fap = 1.0000m,
                                    aliqRatAjust = 2.0000m
                                },
                                basesRemun =
                                [
                                    new S5011BasesRemun()
                                    {
                                        indIncid = IndicadorIncidenciaCS.Normal,
                                        codCateg = "101",
                                        basesCp = new S5011BasesCp()
                                        {
                                            vrBcCp00 = 5000.00m,
                                            vrBcCp15 = 0.00m,
                                            vrBcCp20 = 0.00m,
                                            vrBcCp25 = 0.00m,
                                            vrSuspBcCp00 = 0.00m,
                                            vrSuspBcCp15 = 0.00m,
                                            vrSuspBcCp20 = 0.00m,
                                            vrSuspBcCp25 = 0.00m,
                                            vrBcCp00VA = 0.00m,
                                            vrBcCp15VA = 0.00m,
                                            vrBcCp20VA = 0.00m,
                                            vrBcCp25VA = 0.00m,
                                            vrSuspBcCp00VA = 0.00m,
                                            vrSuspBcCp15VA = 0.00m,
                                            vrSuspBcCp20VA = 0.00m,
                                            vrSuspBcCp25VA = 0.00m,
                                            vrDescSest = 0.00m,
                                            vrCalcSest = 0.00m,
                                            vrDescSenat = 0.00m,
                                            vrCalcSenat = 0.00m,
                                            vrSalFam = 0.00m,
                                            vrSalMat = 0.00m
                                        },
                                        basesCp13 = _versao == Versao.v_S_01_03_00 ? new S5011BasesCp13()
                                        {
                                            vrBcCp00 = 0.00m,
                                            vrBcCp15 = 0.00m,
                                            vrBcCp20 = 0.00m,
                                            vrBcCp25 = 0.00m,
                                            vrSuspBcCp00 = 0.00m,
                                            vrSuspBcCp15 = 0.00m,
                                            vrSuspBcCp20 = 0.00m,
                                            vrSuspBcCp25 = 0.00m
                                        } : null
                                    }
                                ],
                                basesAvNPort = new S5011BasesAvNPort()
                                {
                                    vrBcCp00 = 0.00m,
                                    vrBcCp15 = 0.00m,
                                    vrBcCp20 = 0.00m,
                                    vrBcCp25 = 0.00m,
                                    vrBcCp13 = 0.00m,
                                    vrDescCP = 0.00m
                                },
                                infoSubstPatrOpPort = new S5011InfoSubstPatrOpPort()
                                {
                                    cnpjOpPortuario = "12345678000199"
                                }
                            }
                        ],
                        basesAquis =
                        [
                            new S5011BasesAquis()
                            {
                                indAquis = IndicadorAquisicaoS1250.ProdRuralPF,
                                vlrAquis = 10000.00m,
                                vrCPDescPR = 120.00m,
                                vrCPNRet = 0.00m,
                                vrRatNRet = 0.00m,
                                vrSenarNRet = 0.00m,
                                vrCPCalcPR = 120.00m,
                                vrRatDescPR = 10.00m,
                                vrRatCalcPR = 10.00m,
                                vrSenarDesc = 20.00m,
                                vrSenarCalc = 20.00m
                            }
                        ],
                        basesComerc =
                        [
                            new S5011BasesComerc()
                            {
                                indComerc = IndicadorComercializacaoS1260.VarejoConsFinalOuProdRural,
                                vrBcComPR = 5000.00m,
                                vrCPSusp = 0.00m,
                                vrRatSusp = 0.00m,
                                vrSenarSusp = 0.00m
                            }
                        ],
                        infoCREstab =
                        [
                            new S5011InfoCREstab()
                            {
                                tpCR = "108201",
                                vrCR = 1000.00m,
                                vrSuspCR = 0.00m
                            }
                        ],
                        basesPisPasep = _versao == Versao.v_S_01_03_00 ? new S5011BasesPisPasep()
                        {
                            vrBcPisPasep = 5000.00m,
                            vrBcPisPasepSusp = 0.00m
                        } : null
                    }
                ],
                infoCRContrib =
                [
                    new S5011InfoCRContrib()
                    {
                        tpCR = "108201",
                        vrCR = 1000.00m,
                        vrCRSusp = 0.00m
                    }
                ]
            }
        };
        evento.GeraEventoID();
    }

    public override void ValidaInstanciasLeituraEscrita(S5011 instanciaPopulada, S5011 instanciaXml)
    {
        instanciaPopulada.Should().NotBeNull();
        instanciaXml.Should().NotBeNull();

        // ideEvento
        instanciaXml.evtCS.ideEvento.indApuracao.Should().Be(instanciaPopulada.evtCS.ideEvento.indApuracao);
        instanciaXml.evtCS.ideEvento.perApur.Should().Be(instanciaPopulada.evtCS.ideEvento.perApur);

        // ideEmpregador
        instanciaXml.evtCS.ideEmpregador.tpInsc.Should().Be(instanciaPopulada.evtCS.ideEmpregador.tpInsc);
        instanciaXml.evtCS.ideEmpregador.nrInsc.Should().Be(instanciaPopulada.evtCS.ideEmpregador.nrInsc);

        // infoCS
        instanciaXml.evtCS.infoCS.Should().NotBeNull();
        instanciaXml.evtCS.infoCS.nrRecArqBase.Should().Be(instanciaPopulada.evtCS.infoCS.nrRecArqBase);
        instanciaXml.evtCS.infoCS.indExistInfo.Should().Be(instanciaPopulada.evtCS.infoCS.indExistInfo);

        // infoCPSeg
        instanciaXml.evtCS.infoCS.infoCPSeg.Should().NotBeNull();
        instanciaXml.evtCS.infoCS.infoCPSeg.vrDescCP.Should().Be(instanciaPopulada.evtCS.infoCS.infoCPSeg.vrDescCP);
        instanciaXml.evtCS.infoCS.infoCPSeg.vrCpSeg.Should().Be(instanciaPopulada.evtCS.infoCS.infoCPSeg.vrCpSeg);

        // infoContrib
        instanciaXml.evtCS.infoCS.infoContrib.Should().NotBeNull();
        instanciaXml.evtCS.infoCS.infoContrib.classTrib.Should().Be(instanciaPopulada.evtCS.infoCS.infoContrib.classTrib);
        instanciaXml.evtCS.infoCS.infoContrib.infoPJ.Should().NotBeNull();
        instanciaXml.evtCS.infoCS.infoContrib.infoPJ.indCoop.Should().Be(instanciaPopulada.evtCS.infoCS.infoContrib.infoPJ.indCoop);
        instanciaXml.evtCS.infoCS.infoContrib.infoPJ.indConstr.Should().Be(instanciaPopulada.evtCS.infoCS.infoContrib.infoPJ.indConstr);
        instanciaXml.evtCS.infoCS.infoContrib.infoPJ.indSubstPatr.Should().Be(instanciaPopulada.evtCS.infoCS.infoContrib.infoPJ.indSubstPatr);
        instanciaXml.evtCS.infoCS.infoContrib.infoPJ.percRedContrib.Should().Be(instanciaPopulada.evtCS.infoCS.infoContrib.infoPJ.percRedContrib);
        instanciaXml.evtCS.infoCS.infoContrib.infoPJ.percTransf.Should().Be(instanciaPopulada.evtCS.infoCS.infoContrib.infoPJ.percTransf);
        instanciaXml.evtCS.infoCS.infoContrib.infoPJ.indTribFolhaPisPasep.Should().Be(instanciaPopulada.evtCS.infoCS.infoContrib.infoPJ.indTribFolhaPisPasep);
        instanciaXml.evtCS.infoCS.infoContrib.infoPJ.infoAtConc.Should().NotBeNull();
        instanciaXml.evtCS.infoCS.infoContrib.infoPJ.infoAtConc.fatorMes.Should().Be(instanciaPopulada.evtCS.infoCS.infoContrib.infoPJ.infoAtConc.fatorMes);
        instanciaXml.evtCS.infoCS.infoContrib.infoPJ.infoAtConc.fator13.Should().Be(instanciaPopulada.evtCS.infoCS.infoContrib.infoPJ.infoAtConc.fator13);

        // ideEstab
        instanciaXml.evtCS.infoCS.ideEstab.Should().HaveCount(1);
        var estabPop = instanciaPopulada.evtCS.infoCS.ideEstab[0];
        var estabXml = instanciaXml.evtCS.infoCS.ideEstab[0];
        estabXml.tpInsc.Should().Be(estabPop.tpInsc);
        estabXml.nrInsc.Should().Be(estabPop.nrInsc);
        estabXml.infoEstab.Should().NotBeNull();
        estabXml.infoEstab.cnaePrep.Should().Be(estabPop.infoEstab.cnaePrep);
        estabXml.infoEstab.cnpjResp.Should().Be(estabPop.infoEstab.cnpjResp);
        estabXml.infoEstab.aliqRat.Should().Be(estabPop.infoEstab.aliqRat);
        estabXml.infoEstab.fap.Should().Be(estabPop.infoEstab.fap);
        estabXml.infoEstab.aliqRatAjust.Should().Be(estabPop.infoEstab.aliqRatAjust);
        estabXml.infoEstab.infoEstabRef.Should().NotBeNull();
        estabXml.infoEstab.infoEstabRef.aliqRat.Should().Be(estabPop.infoEstab.infoEstabRef.aliqRat);
        estabXml.infoEstab.infoEstabRef.fap.Should().Be(estabPop.infoEstab.infoEstabRef.fap);
        estabXml.infoEstab.infoEstabRef.aliqRatAjust.Should().Be(estabPop.infoEstab.infoEstabRef.aliqRatAjust);
        estabXml.infoEstab.infoComplObra.Should().NotBeNull();
        estabXml.infoEstab.infoComplObra.indSubstPatrObra.Should().Be(estabPop.infoEstab.infoComplObra.indSubstPatrObra);

        // ideLotacao
        estabXml.ideLotacao.Should().HaveCount(1);
        var lotPop = estabPop.ideLotacao[0];
        var lotXml = estabXml.ideLotacao[0];
        lotXml.codLotacao.Should().Be(lotPop.codLotacao);
        lotXml.fpas.Should().Be(lotPop.fpas);
        lotXml.codTercs.Should().Be(lotPop.codTercs);
        lotXml.codTercsSusp.Should().Be(lotPop.codTercsSusp);
        lotXml.infoTercSusp.Should().HaveCount(1);
        lotXml.infoTercSusp[0].codTerc.Should().Be(lotPop.infoTercSusp[0].codTerc);

        // infoEmprParcial
        lotXml.infoEmprParcial.Should().NotBeNull();
        lotXml.infoEmprParcial.tpInscContrat.Should().Be(lotPop.infoEmprParcial.tpInscContrat);
        lotXml.infoEmprParcial.nrInscContrat.Should().Be(lotPop.infoEmprParcial.nrInscContrat);
        lotXml.infoEmprParcial.tpInscProp.Should().Be(lotPop.infoEmprParcial.tpInscProp);
        lotXml.infoEmprParcial.nrInscProp.Should().Be(lotPop.infoEmprParcial.nrInscProp);
        lotXml.infoEmprParcial.cnoObra.Should().Be(lotPop.infoEmprParcial.cnoObra);

        // dadosOpPort
        lotXml.dadosOpPort.Should().NotBeNull();
        lotXml.dadosOpPort.cnpjOpPortuario.Should().Be(lotPop.dadosOpPort.cnpjOpPortuario);
        lotXml.dadosOpPort.aliqRat.Should().Be(lotPop.dadosOpPort.aliqRat);
        lotXml.dadosOpPort.fap.Should().Be(lotPop.dadosOpPort.fap);
        lotXml.dadosOpPort.aliqRatAjust.Should().Be(lotPop.dadosOpPort.aliqRatAjust);

        // basesRemun
        lotXml.basesRemun.Should().HaveCount(1);
        var baseRemunPop = lotPop.basesRemun[0];
        var baseRemunXml = lotXml.basesRemun[0];
        baseRemunXml.indIncid.Should().Be(baseRemunPop.indIncid);
        baseRemunXml.codCateg.Should().Be(baseRemunPop.codCateg);
        baseRemunXml.basesCp.Should().NotBeNull();
        baseRemunXml.basesCp.vrBcCp00.Should().Be(baseRemunPop.basesCp.vrBcCp00);

        if (_versao == Versao.v_S_01_03_00)
        {
            baseRemunXml.basesCp13.Should().NotBeNull();
            estabXml.basesPisPasep.Should().NotBeNull();
        }
        else
        {
            baseRemunXml.basesCp13.Should().BeNull();
            estabXml.basesPisPasep.Should().BeNull();
        }

        // basesAvNPort
        lotXml.basesAvNPort.Should().NotBeNull();
        lotXml.infoSubstPatrOpPort.Should().NotBeNull();
        lotXml.infoSubstPatrOpPort.cnpjOpPortuario.Should().Be(lotPop.infoSubstPatrOpPort.cnpjOpPortuario);

        // basesAquis
        estabXml.basesAquis.Should().HaveCount(1);
        estabXml.basesAquis[0].indAquis.Should().Be(estabPop.basesAquis[0].indAquis);
        estabXml.basesAquis[0].vlrAquis.Should().Be(estabPop.basesAquis[0].vlrAquis);

        // basesComerc
        estabXml.basesComerc.Should().HaveCount(1);
        estabXml.basesComerc[0].indComerc.Should().Be(estabPop.basesComerc[0].indComerc);
        estabXml.basesComerc[0].vrBcComPR.Should().Be(estabPop.basesComerc[0].vrBcComPR);

        // infoCREstab
        estabXml.infoCREstab.Should().HaveCount(1);
        estabXml.infoCREstab[0].tpCR.Should().Be(estabPop.infoCREstab[0].tpCR);
        estabXml.infoCREstab[0].vrCR.Should().Be(estabPop.infoCREstab[0].vrCR);

        // infoCRContrib
        instanciaXml.evtCS.infoCS.infoCRContrib.Should().HaveCount(1);
        instanciaXml.evtCS.infoCS.infoCRContrib[0].tpCR.Should().Be(instanciaPopulada.evtCS.infoCS.infoCRContrib[0].tpCR);
        instanciaXml.evtCS.infoCS.infoCRContrib[0].vrCR.Should().Be(instanciaPopulada.evtCS.infoCS.infoCRContrib[0].vrCR);
    }
}
