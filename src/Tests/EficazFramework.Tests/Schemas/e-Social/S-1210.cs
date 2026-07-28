namespace EficazFramework.SPED.Schemas.eSocial;

public class S1210Test : BaseESocialTest<S1210>
{
    [Test]
    [TestCase(Versao.v_S_01_02_00)]
    [TestCase(Versao.v_S_01_03_00)]
    public async Task Valida(Versao versao)
    {
        _versao = versao;
        ValidationSchemaNamespace = $"http://www.esocial.gov.br/schema/evt/evtPgtos/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v_S_01_02_00 => Resources.Schemas.eSocial.S1210_v_S_01_02_00,
            _ => Resources.Schemas.eSocial.S1210_v_S_01_03_00
        };
        await TestaEvento();
    }

    [Test]
    public async Task Read_v_S_01_03_00()
    {
        var evento = await Evento.ReadAsync(Resources.Samples.eSocial.S1210_v_S_01_03_00);
        evento.Should().NotBeNull();
        evento.Versao.Should().Be(Versao.v_S_01_03_00);

        var evtPgtos = evento as S1210;
        evtPgtos.Should().NotBeNull();
        evtPgtos.evtPgtos.Id.Should().Be("ID1345571090000002025030512521100001");

        // ideEvento
        evtPgtos.evtPgtos.ideEvento.indRetif.Should().Be(IndicadorRetificacao.Original);
        evtPgtos.evtPgtos.ideEvento.perApur.Should().Be("2025-02");
        evtPgtos.evtPgtos.ideEvento.tpAmb.Should().Be(Ambiente.Producao);
        evtPgtos.evtPgtos.ideEvento.procEmi.Should().Be(EmissorEvento.AppEmpregador);
        evtPgtos.evtPgtos.ideEvento.verProc.Should().Be("v_S_01_03_00");

        // ideEmpregador
        evtPgtos.evtPgtos.ideEmpregador.tpInsc.Should().Be(PersonalidadeJuridica.CNPJ);
        evtPgtos.evtPgtos.ideEmpregador.nrInsc.Should().Be("34557109");

        // ideBenef
        evtPgtos.evtPgtos.ideBenef.Should().NotBeNull();
        evtPgtos.evtPgtos.ideBenef.cpfBenef.Should().Be("15273627877");
        evtPgtos.evtPgtos.ideBenef.infoPgto.Should().HaveCount(1);

        var pgto = evtPgtos.evtPgtos.ideBenef.infoPgto[0];
        pgto.dtPgto.Should().Be(new DateTime(2025, 2, 28));
        pgto.tpPgto.Should().Be(TipoPagamento.RemuneracaoS1200);
        pgto.perRef.Should().Be("2025-02");
        pgto.ideDmDev.Should().Be("022025MENSAL14022025155159");
        pgto.vrLiq.Should().Be(1351.02m);
    }

    // BaseESocialTest overrides
    public override void PreencheCampos(S1210 evento)
    {
        evento.Versao = _versao;
        evento.evtPgtos = new S1210EvtPgtos()
        {
            ideEvento = new IdeEventoFolhaMensal()
            {
                indRetif = IndicadorRetificacao.Original,
                tpAmb = Ambiente.ProducaoRestrita_DadosReais,
                procEmi = EmissorEvento.AppEmpregador,
                perApur = "2025-02",
                verProc = "2.2"
            },
            ideEmpregador = new Empregador()
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = CnpjCpf[..8]
            },
            ideBenef = new S1210IdeBenef()
            {
                cpfBenef = "15273627877",
                infoPgto =
                [
                    new S1210InfoPgto()
                    {
                        dtPgto = new DateTime(2025, 2, 28),
                        tpPgto = TipoPagamento.RemuneracaoS1200,
                        perRef = "2025-02",
                        ideDmDev = "022025MENSAL14022025155159",
                        vrLiq = 1351.02m,
                        paisResidExt = "031",
                        infoPgtoExt = new()
                        {
                            indNIF = IndicadorNIF.PossuiNIF,
                            nifBenef = "123",
                            frmTribut = "40",
                            endExt = new()
                            {
                                endDscLograd = "1243 Street",
                                endNrLograd = "123",
                                endComplem = "não há",
                                endBairro = "Center",
                                endCidade = "??",
                                endEstado = "??",
                                endCodPostal = "1A",
                                telef = "3535441234"
                            }
                        }
                    }
                ],
                infoIRComplem = 
                [
                    new S1210InfoIRComplem()
                    {
                        dtLaudo = new DateTime(2025, 2, 28),
                        perAnt = _versao == Versao.v_S_01_03_00 ? new()
                        {
                            perRefAjuste = "2025-02",
                            nrRec1210Orig = "1.5.1234567890123456789"
                        } : null,
                        infoDep =
                        [
                            new S1210InfoDep()
                            {
                                cpfDep = "15273627877",
                                dtNascto = new DateTime(2020,1,1),
                                nome = "Filho",
                                depIRRF = SimNaoString.Sim,
                                tpDep = "03",
                                descrDep = "filho",
                            }
                        ],
                        infoIRCR = 
                        [
                            new S1210InfoIRCR()
                            {
                                tpCR = "056107",
                                dedDepen =
                                [
                                    new S1210DedDepen()
                                    {
                                        tpRend = "11",
                                        cpfDep = "15273627877",
                                        vlrDedDep = 125.45m
                                    }
                                ],
                                penAlim =
                                [
                                    new S1210PenAlim()
                                    {
                                        tpRend = "11",
                                        cpfDep = "15273627877",
                                        vlrDedPenAlim = 5200.00m
                                    }
                                ],
                                previdCompl = 
                                [
                                    new S1210PrevidCompl()
                                    {
                                        tpPrev = TipoPrevidenciaComplementar.EntidadeFechada,
                                        cnpjEntidPC = "12456789000100",
                                        vlrDedPC = 100.58m,
                                        vlrDedPC13 = _versao == Versao.v_S_01_03_00 ? 1.99m : null,
                                        vlrPatrocFunp = 2.98m,
                                        vlrPatrocFunp13 = _versao == Versao.v_S_01_03_00 ? 1.98m : null
                                    }
                                ],
                                infoProcRet =
                                [
                                    new S1210InfoProcRet()
                                    {
                                        tpRend = "2",
                                        nrProc = "12345678901234567890",
                                        codSusp = "123456",
                                        infoValores =
                                        [
                                            new S1210InfoValores()
                                            {
                                                indApuracao = IndicadorApuracao.Mensal,
                                                vlrNRetido = 12.34m,
                                                vlrDepJud = 56.78m,
                                                vlrCmpAnoCal = 90.12m,
                                                vlrCmpAnoAnt = 34.56m,
                                                vlrRendSusp = 78.90m,
                                                dedSusp = 
                                                [
                                                    new S1210DedSusp()
                                                    {
                                                        tpDed = "7",
                                                        vlrDedSusp = 67.89m,
                                                        cnpjEntidPC = "12456789000100",
                                                        benefPen = 
                                                        [
                                                            new S1210BenefPen()
                                                            {
                                                                cpfDep = "15273627877",
                                                                vlrDepenSusp = 67.89m
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
                    }
                ]
            }
        };
    }

    public override void ValidaInstanciasLeituraEscrita(S1210 instanciaPopulada, S1210 instanciaXml)
    {
        instanciaPopulada.Should().NotBeNull();
        instanciaXml.Should().NotBeNull();

        // ideEvento
        instanciaXml.evtPgtos.ideEvento.tpAmb.Should().Be(instanciaPopulada.evtPgtos.ideEvento.tpAmb);
        instanciaXml.evtPgtos.ideEvento.procEmi.Should().Be(instanciaPopulada.evtPgtos.ideEvento.procEmi);
        instanciaXml.evtPgtos.ideEvento.verProc.Should().Be(instanciaPopulada.evtPgtos.ideEvento.verProc);
        instanciaXml.evtPgtos.ideEvento.perApur.Should().Be(instanciaPopulada.evtPgtos.ideEvento.perApur);

        // ideEmpregador
        instanciaXml.evtPgtos.ideEmpregador.tpInsc.Should().Be(instanciaPopulada.evtPgtos.ideEmpregador.tpInsc);
        instanciaXml.evtPgtos.ideEmpregador.nrInsc.Should().Be(instanciaPopulada.evtPgtos.ideEmpregador.nrInsc);

        // ideBenef
        instanciaXml.evtPgtos.ideBenef.Should().NotBeNull();
        instanciaXml.evtPgtos.ideBenef.cpfBenef.Should().Be(instanciaPopulada.evtPgtos.ideBenef.cpfBenef);

        // infoPgto
        instanciaXml.evtPgtos.ideBenef.infoPgto.Should().HaveCount(1);
        instanciaPopulada.evtPgtos.ideBenef.infoPgto.Should().HaveCount(1);

        var pgtoXml = instanciaXml.evtPgtos.ideBenef.infoPgto[0];
        var pgtoPopulado = instanciaPopulada.evtPgtos.ideBenef.infoPgto[0];

        pgtoXml.dtPgto.Should().Be(pgtoPopulado.dtPgto);
        pgtoXml.tpPgto.Should().Be(pgtoPopulado.tpPgto);
        pgtoXml.perRef.Should().Be(pgtoPopulado.perRef);
        pgtoXml.ideDmDev.Should().Be(pgtoPopulado.ideDmDev);
        pgtoXml.vrLiq.Should().Be(pgtoPopulado.vrLiq);

        // infoIRComplem
        instanciaXml.evtPgtos.ideBenef.infoIRComplem.Should().HaveCount(1);
        var irXml = instanciaXml.evtPgtos.ideBenef.infoIRComplem[0];
        var irPopulado = instanciaPopulada.evtPgtos.ideBenef.infoIRComplem[0];
        irXml.dtLaudo.Should().Be(irPopulado.dtLaudo);

        if (instanciaPopulada.Versao == Versao.v_S_01_03_00)
        {
            irXml.perAnt.Should().NotBeNull();
            irXml.perAnt.perRefAjuste.Should().Be(irPopulado.perAnt.perRefAjuste);
            irXml.perAnt.nrRec1210Orig.Should().Be(irPopulado.perAnt.nrRec1210Orig);
        }

        // infoDep
        irXml.infoDep.Should().HaveCount(1);
        irXml.infoDep[0].cpfDep.Should().Be(irPopulado.infoDep[0].cpfDep);
        irXml.infoDep[0].dtNascto.Should().Be(irPopulado.infoDep[0].dtNascto);
        irXml.infoDep[0].nome.Should().Be(irPopulado.infoDep[0].nome);
        irXml.infoDep[0].depIRRF.Should().Be(irPopulado.infoDep[0].depIRRF);
        irXml.infoDep[0].tpDep.Should().Be(irPopulado.infoDep[0].tpDep);
        irXml.infoDep[0].descrDep.Should().Be(irPopulado.infoDep[0].descrDep);

        // infoIRCR
        irXml.infoIRCR.Should().HaveCount(1);
        var ircrXml = irXml.infoIRCR[0];
        var ircrPopulado = irPopulado.infoIRCR[0];
        ircrXml.tpCR.Should().Be(ircrPopulado.tpCR);

        // dedDepen
        ircrXml.dedDepen.Should().HaveCount(1);
        ircrXml.dedDepen[0].tpRend.Should().Be(ircrPopulado.dedDepen[0].tpRend);
        ircrXml.dedDepen[0].cpfDep.Should().Be(ircrPopulado.dedDepen[0].cpfDep);
        ircrXml.dedDepen[0].vlrDedDep.Should().Be(ircrPopulado.dedDepen[0].vlrDedDep);

        // penAlim
        ircrXml.penAlim.Should().HaveCount(1);
        ircrXml.penAlim[0].tpRend.Should().Be(ircrPopulado.penAlim[0].tpRend);
        ircrXml.penAlim[0].cpfDep.Should().Be(ircrPopulado.penAlim[0].cpfDep);
        ircrXml.penAlim[0].vlrDedPenAlim.Should().Be(ircrPopulado.penAlim[0].vlrDedPenAlim);

        // previdCompl
        ircrXml.previdCompl.Should().HaveCount(1);
        var pcXml = ircrXml.previdCompl[0];
        var pcPopulado = ircrPopulado.previdCompl[0];
        pcXml.tpPrev.Should().Be(pcPopulado.tpPrev);
        pcXml.cnpjEntidPC.Should().Be(pcPopulado.cnpjEntidPC);
        pcXml.vlrDedPC.Should().Be(pcPopulado.vlrDedPC);
        pcXml.vlrDedPC13.Should().Be(pcPopulado.vlrDedPC13);
        pcXml.vlrPatrocFunp.Should().Be(pcPopulado.vlrPatrocFunp);
        pcXml.vlrPatrocFunp13.Should().Be(pcPopulado.vlrPatrocFunp13);

        // infoProcRet
        ircrXml.infoProcRet.Should().HaveCount(1);
        var prXml = ircrXml.infoProcRet[0];
        var prPopulado = ircrPopulado.infoProcRet[0];
        prXml.tpRend.Should().Be(prPopulado.tpRend);
        prXml.nrProc.Should().Be(prPopulado.nrProc);
        prXml.codSusp.Should().Be(prPopulado.codSusp);

        // infoValores
        prXml.infoValores.Should().HaveCount(1);
        var ivXml = prXml.infoValores[0];
        var ivPopulado = prPopulado.infoValores[0];
        ivXml.indApuracao.Should().Be(ivPopulado.indApuracao);
        ivXml.vlrNRetido.Should().Be(ivPopulado.vlrNRetido);
        ivXml.vlrDepJud.Should().Be(ivPopulado.vlrDepJud);
        ivXml.vlrCmpAnoCal.Should().Be(ivPopulado.vlrCmpAnoCal);
        ivXml.vlrCmpAnoAnt.Should().Be(ivPopulado.vlrCmpAnoAnt);
        ivXml.vlrRendSusp.Should().Be(ivPopulado.vlrRendSusp);

        // dedSusp
        ivXml.dedSusp.Should().HaveCount(1);
        var dsXml = ivXml.dedSusp[0];
        var dsPopulado = ivPopulado.dedSusp[0];
        dsXml.tpDed.Should().Be(dsPopulado.tpDed);
        dsXml.vlrDedSusp.Should().Be(dsPopulado.vlrDedSusp);
        dsXml.cnpjEntidPC.Should().Be(dsPopulado.cnpjEntidPC);

        // benefPen
        dsXml.benefPen.Should().HaveCount(1);
        dsXml.benefPen[0].cpfDep.Should().Be(dsPopulado.benefPen[0].cpfDep);
        dsXml.benefPen[0].vlrDepenSusp.Should().Be(dsPopulado.benefPen[0].vlrDepenSusp);
    }
}
