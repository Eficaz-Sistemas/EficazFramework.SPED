namespace EficazFramework.SPED.Schemas.eSocial;

public class S5002Test : BaseESocialTest<S5002>
{
    [Test]
    [TestCase(Versao.v_S_01_02_00)]
    [TestCase(Versao.v_S_01_03_00)]
    public async Task Valida(Versao versao)
    {
        _versao = versao;
        ValidationSchemaNamespace = $"http://www.esocial.gov.br/schema/evt/evtIrrfBenef/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v_S_01_03_00 => Resources.Schemas.eSocial.S5002_v_S_01_03_00,
            _ => Resources.Schemas.eSocial.S5002_v_S_01_02_00
        };
        await TestaEvento();
    }

    [Test]
    public async Task Read_v_S_01_03_00()
    {
        var evento = await Evento.ReadAsync(Resources.Samples.eSocial.S5002_v_S_01_03_00);
        evento.Should().NotBeNull();
        evento.Versao.Should().Be(Versao.v_S_01_03_00);
        var evt5002 = evento as S5002;
        evt5002.Should().NotBeNull();
        evt5002.evtIrrfBenef.Should().NotBeNull();
        evt5002.evtIrrfBenef.ideEvento.nrRecArqBase.Should().Be("1.1.0000000000000000000");
        evt5002.evtIrrfBenef.ideEvento.perApur.Should().Be("2025-02");
        evt5002.evtIrrfBenef.ideEmpregador.tpInsc.Should().Be(PersonalidadeJuridica.CNPJ);
        evt5002.evtIrrfBenef.ideEmpregador.nrInsc.Should().Be("34785515");
        evt5002.evtIrrfBenef.ideTrabalhador.cpfBenef.Should().Be("12345678901");

        // dmDev
        evt5002.evtIrrfBenef.ideTrabalhador.dmDev.Should().HaveCount(1);
        var dmDev = evt5002.evtIrrfBenef.ideTrabalhador.dmDev[0];
        dmDev.perRef.Should().Be("2025-02");
        dmDev.ideDmDev.Should().Be("DEMO001");
        dmDev.tpPgto.Should().Be(TipoPagamento.RemuneracaoS1200);
        dmDev.dtPgto.Should().Be(new DateTime(2025, 2, 28));
        dmDev.codCateg.Should().Be("101");

        // infoIR
        dmDev.infoIR.Should().HaveCount(1);
        dmDev.infoIR[0].tpInfoIR.Should().Be("11");
        dmDev.infoIR[0].valor.Should().Be(3500.00m);
        dmDev.infoIR[0].descRendimento.Should().Be("Salário Base");
        dmDev.infoIR[0].infoProcJudRub.Should().HaveCount(1);
        dmDev.infoIR[0].infoProcJudRub[0].nrProc.Should().Be("12345678901234567890");
        dmDev.infoIR[0].infoProcJudRub[0].ufVara.Should().Be(UFCadastro.SP);
        dmDev.infoIR[0].infoProcJudRub[0].codMunic.Should().Be("3550308");
        dmDev.infoIR[0].infoProcJudRub[0].idVara.Should().Be(1);

        // totApurMen
        dmDev.totApurMen.Should().HaveCount(1);
        dmDev.totApurMen[0].CRMen.Should().Be("056107");
        dmDev.totApurMen[0].vlrRendTrib.Should().Be(3500.00m);
        dmDev.totApurMen[0].vlrPrevOficial.Should().Be(385.00m);
        dmDev.totApurMen[0].vlrCRMen.Should().Be(120.00m);

        // totApurDia
        dmDev.totApurDia.Should().HaveCount(1);
        dmDev.totApurDia[0].perApurDia.Should().Be(28);
        dmDev.totApurDia[0].CRDia.Should().Be("047301");
        dmDev.totApurDia[0].frmTribut.Should().Be("01");
        dmDev.totApurDia[0].paisResidExt.Should().Be("105");
        dmDev.totApurDia[0].vlrPagoDia.Should().Be(3500.00m);
        dmDev.totApurDia[0].vlrCRDia.Should().Be(120.00m);

        // infoRRA
        dmDev.infoRRA.Should().NotBeNull();
        dmDev.infoRRA.tpProcRRA.Should().Be(TipoProcesso.Judicial);
        dmDev.infoRRA.nrProcRRA.Should().Be("00012345620255010001");
        dmDev.infoRRA.descRRA.Should().Be("Processo RRA");
        dmDev.infoRRA.qtdMesesRRA.Should().Be(12.0m);
        dmDev.infoRRA.despProcJud.Should().NotBeNull();
        dmDev.infoRRA.despProcJud.vlrDespCustas.Should().Be(100.00m);
        dmDev.infoRRA.despProcJud.vlrDespAdvogados.Should().Be(500.00m);
        dmDev.infoRRA.ideAdv.Should().HaveCount(1);
        dmDev.infoRRA.ideAdv[0].tpInsc.Should().Be(PersonalidadeJuridica.CPF);
        dmDev.infoRRA.ideAdv[0].nrInsc.Should().Be("98765432100");
        dmDev.infoRRA.ideAdv[0].vlrAdv.Should().Be(500.00m);

        // infoPgtoExt
        dmDev.infoPgtoExt.Should().NotBeNull();
        dmDev.infoPgtoExt.paisResidExt.Should().Be("105");
        dmDev.infoPgtoExt.indNIF.Should().Be(IndicadorNIF.PossuiNIF);
        dmDev.infoPgtoExt.nifBenef.Should().Be("NIF12345");
        dmDev.infoPgtoExt.frmTribut.Should().Be("01");
        dmDev.infoPgtoExt.endExt.Should().NotBeNull();
        dmDev.infoPgtoExt.endExt.endDscLograd.Should().Be("Main Street");
        dmDev.infoPgtoExt.endExt.endNrLograd.Should().Be("100");
        dmDev.infoPgtoExt.endExt.endCidade.Should().Be("New York");

        // totInfoIR
        evt5002.evtIrrfBenef.ideTrabalhador.totInfoIR.Should().NotBeNull();
        evt5002.evtIrrfBenef.ideTrabalhador.totInfoIR.consolidApurMen.Should().HaveCount(1);
        evt5002.evtIrrfBenef.ideTrabalhador.totInfoIR.consolidApurMen[0].CRMen.Should().Be("056107");

        // infoIRComplem
        evt5002.evtIrrfBenef.ideTrabalhador.infoIRComplem.Should().HaveCount(1);
        var infoIRComplem = evt5002.evtIrrfBenef.ideTrabalhador.infoIRComplem[0];
        infoIRComplem.dtLaudo.Should().Be(new DateTime(2024, 1, 1));
        infoIRComplem.perAnt.perRefAjuste.Should().Be("2024-12");
        infoIRComplem.ideDep.Should().HaveCount(1);
        infoIRComplem.ideDep[0].cpfDep.Should().Be("98765432100");
        infoIRComplem.ideDep[0].depIRRF.Should().Be(SimNaoString.Sim);
        infoIRComplem.infoIRCR.Should().HaveCount(1);
        infoIRComplem.infoIRCR[0].tpCR.Should().Be("056107");
        infoIRComplem.infoIRCR[0].dedDepen[0].vlrDedDep.Should().Be(189.59m);
        infoIRComplem.infoIRCR[0].penAlim[0].vlrDedPenAlim.Should().Be(300.00m);
        infoIRComplem.infoIRCR[0].previdCompl[0].vlrDedPC.Should().Be(200.00m);
        infoIRComplem.infoIRCR[0].infoProcRet[0].infoValores[0].vlrNRetido.Should().Be(50.00m);
        infoIRComplem.planSaude[0].vlrSaudeTit.Should().Be(250.00m);
        infoIRComplem.infoReembMed[0].detReembTit[0].vlrReemb.Should().Be(100.00m);
    }

    public override void PreencheCampos(S5002 evento)
    {
        bool isV0103 = _versao == Versao.v_S_01_03_00;
        evento.Versao = _versao;
        evento.evtIrrfBenef = new S5002EvtIrrfBenef()
        {
            ideEvento = new S5002IdeEvento()
            {
                nrRecArqBase = "1.1.0000000000000000000",
                perApur = "2025-02"
            },
            ideEmpregador = new Empregador()
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = CnpjCpf[..8]
            },
            ideTrabalhador = new S5002IdeTrabalhador()
            {
                cpfBenef = "12345678901",
                dmDev =
                [
                    new S5002DmDev()
                    {
                        perRef = "2025-02",
                        ideDmDev = "DEMO001",
                        tpPgto = TipoPagamento.RemuneracaoS1200,
                        dtPgto = new DateTime(2025, 2, 28),
                        codCateg = "101",
                        infoIR =
                        [
                            new S5002InfoIR()
                            {
                                tpInfoIR = "11",
                                valor = 3500.00m,
                                descRendimento = isV0103 ? "Salário Base" : null,
                                infoProcJudRub =
                                [
                                    new S5002InfoProcJudRub()
                                    {
                                        nrProc = "12345678901234567890",
                                        ufVara = UFCadastro.SP,
                                        codMunic = "3550308",
                                        idVara = 1
                                    }
                                ]
                            }
                        ],
                        totApurMen =
                        [
                            new S5002TotApurMen()
                            {
                                CRMen = "056107",
                                vlrRendTrib = isV0103 ? 3500.00m : null,
                                vlrRendTrib13 = isV0103 ? 0.00m : null,
                                vlrPrevOficial = isV0103 ? 385.00m : null,
                                vlrPrevOficial13 = isV0103 ? 0.00m : null,
                                vlrCRMen = 120.00m,
                                vlrCR13Men = isV0103 ? 0.00m : null,
                                vlrParcIsenta65 = isV0103 ? 0.00m : null,
                                vlrParcIsenta65Dec = isV0103 ? 0.00m : null,
                                vlrDiarias = isV0103 ? 0.00m : null,
                                vlrAjudaCusto = isV0103 ? 0.00m : null,
                                vlrIndResContrato = isV0103 ? 0.00m : null,
                                vlrAbonoPec = isV0103 ? 0.00m : null,
                                vlrRendMoleGrave = isV0103 ? 0.00m : null,
                                vlrRendMoleGrave13 = isV0103 ? 0.00m : null,
                                vlrAuxMoradia = isV0103 ? 0.00m : null,
                                vlrBolsaMedico = isV0103 ? 0.00m : null,
                                vlrBolsaMedico13 = isV0103 ? 0.00m : null,
                                vlrJurosMora = isV0103 ? 0.00m : null,
                                vlrIsenOutros = isV0103 ? 0.00m : null,
                                descRendimento = isV0103 ? "Demais Isenções" : null
                            }
                        ],
                        totApurDia =
                        [
                            new S5002TotApurDia()
                            {
                                perApurDia = 28,
                                CRDia = "047301",
                                frmTribut = isV0103 ? "01" : null,
                                paisResidExt = isV0103 ? "105" : null,
                                vlrPagoDia = isV0103 ? 3500.00m : null,
                                vlrCRDia = 120.00m
                            }
                        ],
                        infoRRA = new S5002InfoRRA()
                        {
                            tpProcRRA = TipoProcesso.Judicial,
                            nrProcRRA = "00012345620255010001",
                            descRRA = "Processo RRA",
                            qtdMesesRRA = 12.0m,
                            despProcJud = new S5002DespProcJud()
                            {
                                vlrDespCustas = 100.00m,
                                vlrDespAdvogados = 500.00m
                            },
                            ideAdv =
                            [
                                new S5002IdeAdv()
                                {
                                    tpInsc = PersonalidadeJuridica.CPF,
                                    nrInsc = "98765432100",
                                    vlrAdv = 500.00m
                                }
                            ]
                        },
                        infoPgtoExt = new S5002InfoPgtoExt()
                        {
                            paisResidExt = "105",
                            indNIF = IndicadorNIF.PossuiNIF,
                            nifBenef = "NIF12345",
                            frmTribut = "01",
                            endExt = new S5002EndExt()
                            {
                                endDscLograd = "Main Street",
                                endNrLograd = "100",
                                endComplem = "Apt 2",
                                endBairro = "Downtown",
                                endCidade = "New York",
                                endEstado = "NY",
                                endCodPostal = "10001",
                                telef = "11999998888"
                            }
                        }
                    }
                ],
                totInfoIR = isV0103 ? new S5002TotInfoIR()
                {
                    consolidApurMen =
                    [
                        new S5002ConsolidApurMen()
                        {
                            CRMen = "056107",
                            vlrRendTrib = 3500.00m,
                            vlrRendTrib13 = 0.00m,
                            vlrPrevOficial = 385.00m,
                            vlrPrevOficial13 = 0.00m,
                            vlrCRMen = 120.00m,
                            vlrCR13Men = 0.00m,
                            vlrParcIsenta65 = 0.00m,
                            vlrParcIsenta65Dec = 0.00m,
                            vlrDiarias = 0.00m,
                            vlrAjudaCusto = 0.00m,
                            vlrIndResContrato = 0.00m,
                            vlrAbonoPec = 0.00m,
                            vlrRendMoleGrave = 0.00m,
                            vlrRendMoleGrave13 = 0.00m,
                            vlrAuxMoradia = 0.00m,
                            vlrBolsaMedico = 0.00m,
                            vlrBolsaMedico13 = 0.00m,
                            vlrJurosMora = 0.00m,
                            vlrIsenOutros = 0.00m,
                            descRendimento = "Totais Consolidados"
                        }
                    ]
                } : null,
                infoIRComplem =
                [
                    new S5002InfoIRComplem()
                    {
                        dtLaudo = new DateTime(2024, 1, 1),
                        perAnt = isV0103 ? new S5002PerAnt()
                        {
                            perRefAjuste = "2024-12",
                            nrRec1210Orig = "1.1.0000000000000000001"
                        } : null,
                        ideDep =
                        [
                            new S5002IdeDep()
                            {
                                cpfDep = "98765432100",
                                depIRRF = SimNaoString.Sim,
                                dtNascto = new DateTime(2015, 5, 20),
                                nome = "Filho Exemplo",
                                tpDep = "01",
                                descrDep = "Filho"
                            }
                        ],
                        infoIRCR =
                        [
                            new S5002InfoIRCR()
                            {
                                tpCR = "056107",
                                dedDepen =
                                [
                                    new S5002DedDepen()
                                    {
                                        tpRend = TipoRendimentoDependente.RemuneracaoMensal,
                                        cpfDep = "98765432100",
                                        vlrDedDep = 189.59m
                                    }
                                ],
                                penAlim =
                                [
                                    new S5002PenAlim()
                                    {
                                        tpRend = TipoRendimentoPensaoAlimenticia.RemuneracaoMensal,
                                        cpfDep = "98765432100",
                                        vlrDedPenAlim = 300.00m
                                    }
                                ],
                                previdCompl =
                                [
                                    new S5002PrevidCompl()
                                    {
                                        tpPrev = TipoPrevidenciaComplementar.SociedadeAberta,
                                        cnpjEntidPC = "12345678000195",
                                        vlrDedPC = 200.00m
                                    }
                                ],
                                infoProcRet =
                                [
                                    new S5002InfoProcRet()
                                    {
                                        tpProcRet = TipoProcesso.Judicial,
                                        nrProcRet = "12345678901234567890",
                                        codSusp = "123456",
                                        infoValores =
                                        [
                                            new S5002InfoValores()
                                            {
                                                indApuracao = IndicadorApuracao.Mensal,
                                                vlrNRetido = 50.00m,
                                                vlrDepJud = 50.00m,
                                                dedSusp =
                                                [
                                                    new S5002DedSusp()
                                                    {
                                                        indTpDeducao = IndicadorTipoDeducao.PrevidenciaOficial,
                                                        vlrDedSusp = 50.00m,
                                                        cnpjEntidPC = "12345678000195",
                                                        benefPen =
                                                        [
                                                            new S5002BenefPen()
                                                            {
                                                                cpfDep = "98765432100",
                                                                vlrDepenSusp = 50.00m
                                                            }
                                                        ]
                                                    }
                                                ]
                                            }
                                        ]
                                    }
                                ]
                            }
                        ],
                        planSaude =
                        [
                            new S5002PlanSaude()
                            {
                                cnpjOper = "12345678000195",
                                regANS = "123456",
                                vlrSaudeTit = 250.00m,
                                infoDepSau =
                                [
                                    new S5002InfoDepSau()
                                    {
                                        cpfDep = "98765432100",
                                        vlrSaudeDep = 150.00m
                                    }
                                ]
                            }
                        ],
                        infoReembMed =
                        [
                            new S5002InfoReembMed()
                            {
                                indOrgReemb = IndicadorOrigemReembolso.PlanoSaude,
                                cnpjOper = "12345678000195",
                                regANS = "123456",
                                detReembTit =
                                [
                                    new S5002DetReemb()
                                    {
                                        tpInsc = PersonalidadeJuridica.CNPJ,
                                        nrInsc = "12345678000195",
                                        vlrReemb = 100.00m
                                    }
                                ],
                                infoReembDep =
                                [
                                    new S5002InfoReembDep()
                                    {
                                        cpfBenef = "98765432100",
                                        detReembDep =
                                        [
                                            new S5002DetReemb()
                                            {
                                                tpInsc = PersonalidadeJuridica.CNPJ,
                                                nrInsc = "12345678000195",
                                                vlrReemb = 50.00m
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

    public override void ValidaInstanciasLeituraEscrita(S5002 instanciaPopulada, S5002 instanciaXml)
    {
        instanciaPopulada.Should().NotBeNull();
        instanciaXml.Should().NotBeNull();

        // ideEvento
        instanciaXml.evtIrrfBenef.ideEvento.nrRecArqBase.Should().Be(instanciaPopulada.evtIrrfBenef.ideEvento.nrRecArqBase);
        instanciaXml.evtIrrfBenef.ideEvento.perApur.Should().Be(instanciaPopulada.evtIrrfBenef.ideEvento.perApur);

        // ideEmpregador
        instanciaXml.evtIrrfBenef.ideEmpregador.tpInsc.Should().Be(instanciaPopulada.evtIrrfBenef.ideEmpregador.tpInsc);
        instanciaXml.evtIrrfBenef.ideEmpregador.nrInsc.Should().Be(instanciaPopulada.evtIrrfBenef.ideEmpregador.nrInsc);

        // ideTrabalhador
        instanciaXml.evtIrrfBenef.ideTrabalhador.cpfBenef.Should().Be(instanciaPopulada.evtIrrfBenef.ideTrabalhador.cpfBenef);

        // dmDev
        instanciaXml.evtIrrfBenef.ideTrabalhador.dmDev.Should().HaveCount(1);
        var dmDevPop = instanciaPopulada.evtIrrfBenef.ideTrabalhador.dmDev[0];
        var dmDevXml = instanciaXml.evtIrrfBenef.ideTrabalhador.dmDev[0];
        dmDevXml.perRef.Should().Be(dmDevPop.perRef);
        dmDevXml.ideDmDev.Should().Be(dmDevPop.ideDmDev);
        dmDevXml.tpPgto.Should().Be(dmDevPop.tpPgto);
        dmDevXml.dtPgto.Should().Be(dmDevPop.dtPgto);
        dmDevXml.codCateg.Should().Be(dmDevPop.codCateg);

        // infoIR
        dmDevXml.infoIR.Should().HaveCount(1);
        dmDevXml.infoIR[0].tpInfoIR.Should().Be(dmDevPop.infoIR[0].tpInfoIR);
        dmDevXml.infoIR[0].valor.Should().Be(dmDevPop.infoIR[0].valor);
        dmDevXml.infoIR[0].descRendimento.Should().Be(dmDevPop.infoIR[0].descRendimento);
        dmDevXml.infoIR[0].infoProcJudRub.Should().HaveCount(1);
        dmDevXml.infoIR[0].infoProcJudRub[0].nrProc.Should().Be(dmDevPop.infoIR[0].infoProcJudRub[0].nrProc);
        dmDevXml.infoIR[0].infoProcJudRub[0].ufVara.Should().Be(dmDevPop.infoIR[0].infoProcJudRub[0].ufVara);
        dmDevXml.infoIR[0].infoProcJudRub[0].codMunic.Should().Be(dmDevPop.infoIR[0].infoProcJudRub[0].codMunic);
        dmDevXml.infoIR[0].infoProcJudRub[0].idVara.Should().Be(dmDevPop.infoIR[0].infoProcJudRub[0].idVara);

        // totApurMen
        dmDevXml.totApurMen.Should().HaveCount(1);
        dmDevXml.totApurMen[0].CRMen.Should().Be(dmDevPop.totApurMen[0].CRMen);
        dmDevXml.totApurMen[0].vlrRendTrib.Should().Be(dmDevPop.totApurMen[0].vlrRendTrib);
        dmDevXml.totApurMen[0].vlrPrevOficial.Should().Be(dmDevPop.totApurMen[0].vlrPrevOficial);
        dmDevXml.totApurMen[0].vlrCRMen.Should().Be(dmDevPop.totApurMen[0].vlrCRMen);

        // totApurDia
        dmDevXml.totApurDia.Should().HaveCount(1);
        dmDevXml.totApurDia[0].perApurDia.Should().Be(dmDevPop.totApurDia[0].perApurDia);
        dmDevXml.totApurDia[0].CRDia.Should().Be(dmDevPop.totApurDia[0].CRDia);
        dmDevXml.totApurDia[0].frmTribut.Should().Be(dmDevPop.totApurDia[0].frmTribut);
        dmDevXml.totApurDia[0].paisResidExt.Should().Be(dmDevPop.totApurDia[0].paisResidExt);
        dmDevXml.totApurDia[0].vlrPagoDia.Should().Be(dmDevPop.totApurDia[0].vlrPagoDia);
        dmDevXml.totApurDia[0].vlrCRDia.Should().Be(dmDevPop.totApurDia[0].vlrCRDia);

        // infoRRA
        dmDevXml.infoRRA.Should().NotBeNull();
        dmDevXml.infoRRA.tpProcRRA.Should().Be(dmDevPop.infoRRA.tpProcRRA);
        dmDevXml.infoRRA.nrProcRRA.Should().Be(dmDevPop.infoRRA.nrProcRRA);
        dmDevXml.infoRRA.descRRA.Should().Be(dmDevPop.infoRRA.descRRA);
        dmDevXml.infoRRA.qtdMesesRRA.Should().Be(dmDevPop.infoRRA.qtdMesesRRA);
        dmDevXml.infoRRA.despProcJud.vlrDespCustas.Should().Be(dmDevPop.infoRRA.despProcJud.vlrDespCustas);
        dmDevXml.infoRRA.despProcJud.vlrDespAdvogados.Should().Be(dmDevPop.infoRRA.despProcJud.vlrDespAdvogados);
        dmDevXml.infoRRA.ideAdv[0].tpInsc.Should().Be(dmDevPop.infoRRA.ideAdv[0].tpInsc);
        dmDevXml.infoRRA.ideAdv[0].nrInsc.Should().Be(dmDevPop.infoRRA.ideAdv[0].nrInsc);
        dmDevXml.infoRRA.ideAdv[0].vlrAdv.Should().Be(dmDevPop.infoRRA.ideAdv[0].vlrAdv);

        // infoPgtoExt
        dmDevXml.infoPgtoExt.Should().NotBeNull();
        dmDevXml.infoPgtoExt.paisResidExt.Should().Be(dmDevPop.infoPgtoExt.paisResidExt);
        dmDevXml.infoPgtoExt.indNIF.Should().Be(dmDevPop.infoPgtoExt.indNIF);
        dmDevXml.infoPgtoExt.nifBenef.Should().Be(dmDevPop.infoPgtoExt.nifBenef);
        dmDevXml.infoPgtoExt.frmTribut.Should().Be(dmDevPop.infoPgtoExt.frmTribut);
        dmDevXml.infoPgtoExt.endExt.endDscLograd.Should().Be(dmDevPop.infoPgtoExt.endExt.endDscLograd);
        dmDevXml.infoPgtoExt.endExt.endNrLograd.Should().Be(dmDevPop.infoPgtoExt.endExt.endNrLograd);
        dmDevXml.infoPgtoExt.endExt.endCidade.Should().Be(dmDevPop.infoPgtoExt.endExt.endCidade);

        // totInfoIR
        if (instanciaPopulada.evtIrrfBenef.ideTrabalhador.totInfoIR != null)
        {
            instanciaXml.evtIrrfBenef.ideTrabalhador.totInfoIR.Should().NotBeNull();
            instanciaXml.evtIrrfBenef.ideTrabalhador.totInfoIR.consolidApurMen.Should().HaveCount(1);
            instanciaXml.evtIrrfBenef.ideTrabalhador.totInfoIR.consolidApurMen[0].CRMen.Should().Be(instanciaPopulada.evtIrrfBenef.ideTrabalhador.totInfoIR.consolidApurMen[0].CRMen);
        }

        // infoIRComplem
        instanciaXml.evtIrrfBenef.ideTrabalhador.infoIRComplem.Should().HaveCount(1);
        var infoIRComplemPop = instanciaPopulada.evtIrrfBenef.ideTrabalhador.infoIRComplem[0];
        var infoIRComplemXml = instanciaXml.evtIrrfBenef.ideTrabalhador.infoIRComplem[0];
        if (infoIRComplemPop.perAnt != null)
        {
            infoIRComplemXml.perAnt.Should().NotBeNull();
            infoIRComplemXml.perAnt.perRefAjuste.Should().Be(infoIRComplemPop.perAnt.perRefAjuste);
        }
        infoIRComplemXml.ideDep[0].cpfDep.Should().Be(infoIRComplemPop.ideDep[0].cpfDep);
        infoIRComplemXml.ideDep[0].depIRRF.Should().Be(infoIRComplemPop.ideDep[0].depIRRF);
        infoIRComplemXml.infoIRCR[0].tpCR.Should().Be(infoIRComplemPop.infoIRCR[0].tpCR);
        infoIRComplemXml.infoIRCR[0].dedDepen[0].vlrDedDep.Should().Be(infoIRComplemPop.infoIRCR[0].dedDepen[0].vlrDedDep);
        infoIRComplemXml.infoIRCR[0].penAlim[0].vlrDedPenAlim.Should().Be(infoIRComplemPop.infoIRCR[0].penAlim[0].vlrDedPenAlim);
        infoIRComplemXml.infoIRCR[0].previdCompl[0].vlrDedPC.Should().Be(infoIRComplemPop.infoIRCR[0].previdCompl[0].vlrDedPC);
        infoIRComplemXml.infoIRCR[0].infoProcRet[0].infoValores[0].vlrNRetido.Should().Be(infoIRComplemPop.infoIRCR[0].infoProcRet[0].infoValores[0].vlrNRetido);
        infoIRComplemXml.planSaude[0].vlrSaudeTit.Should().Be(infoIRComplemPop.planSaude[0].vlrSaudeTit);
        infoIRComplemXml.infoReembMed[0].detReembTit[0].vlrReemb.Should().Be(infoIRComplemPop.infoReembMed[0].detReembTit[0].vlrReemb);
    }
}
