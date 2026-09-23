using System;
using System.Threading.Tasks;

namespace EficazFramework.SPED.Schemas.eSocial;

public class S2299Test : BaseESocialTest<S2299>
{
    private int _testNumber = 0;

    [Test]
    [TestCase(Versao.v_S_01_02_00)]
    [TestCase(Versao.v_S_01_03_00)]
    public async Task Valida(Versao versao)
    {
        _testNumber = 0;
        _versao = versao;
        ValidationSchemaNamespace = $"http://www.esocial.gov.br/schema/evt/evtDeslig/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v_S_01_03_00 => Resources.Schemas.eSocial.S2299_v_S_01_03_01,
            _ => Resources.Schemas.eSocial.S2299_v_S_01_02_01
        };
        await TestaEvento();
    }

    [Test]
    public async Task Read_v_S_01_03_00()
    {
        var evento = await Evento.ReadAsync(Resources.Samples.eSocial.S2299_v_S_01_03_00);
        evento.Should().NotBeNull();
        evento.Should().BeOfType<S2299>();
        
        var ev2299 = evento as S2299;
        
        // ideEvento
        ev2299.evtDeslig.ideEvento.tpAmb.Should().Be(Ambiente.ProducaoRestrita_DadosReais);
        ev2299.evtDeslig.ideEvento.procEmi.Should().Be(EmissorEvento.AppEmpregador);
        ev2299.evtDeslig.ideEvento.verProc.Should().Be("1.0");
        ev2299.evtDeslig.ideEvento.indRetif.Should().Be(IndicadorRetificacao.Original);
        
        // ideEmpregador
        ev2299.evtDeslig.ideEmpregador.tpInsc.Should().Be(PersonalidadeJuridica.CNPJ);
        ev2299.evtDeslig.ideEmpregador.nrInsc.Should().Be("10608025");
        
        // ideVinculo
        ev2299.evtDeslig.ideVinculo.cpfTrab.Should().Be("12345678901");
        ev2299.evtDeslig.ideVinculo.matricula.Should().Be("123456");
        
        // infoDeslig
        ev2299.evtDeslig.infoDeslig.mtvDeslig.Should().Be("01");
        ev2299.evtDeslig.infoDeslig.dtDeslig.Should().BeSameDateAs(new DateTime(2024, 1, 31));
        ev2299.evtDeslig.infoDeslig.dtAvPrv.Should().BeSameDateAs(new DateTime(2023, 12, 31));
        ev2299.evtDeslig.infoDeslig.indPagtoAPI.Should().Be(SimNaoString.Nao);
        ev2299.evtDeslig.infoDeslig.dtProjFimAPI.Should().BeSameDateAs(new DateTime(2024, 2, 28));
        ev2299.evtDeslig.infoDeslig.pensAlim.Should().Be(1);
        ev2299.evtDeslig.infoDeslig.percAliment.Should().Be(15.5m);
        ev2299.evtDeslig.infoDeslig.vrAlim.Should().Be(500m);
        ev2299.evtDeslig.infoDeslig.nrProcTrab.Should().Be("12345678901234567890");
        ev2299.evtDeslig.infoDeslig.indPDV.Should().Be(SimNaoString.Sim);
        
        // infoInterm e observacoes
        ev2299.evtDeslig.infoDeslig.infoInterm[0].dia.Should().Be(10);
        ev2299.evtDeslig.infoDeslig.observacoes[0].Value.Should().Be("Observacao Teste");
        
        // Novos blocos infoDeslig
        ev2299.evtDeslig.infoDeslig.sucessaoVinc.tpInsc.Should().Be(TipoInscricao.CNPJ);
        ev2299.evtDeslig.infoDeslig.sucessaoVinc.nrInsc.Should().Be("12345678000199");
        
        ev2299.evtDeslig.infoDeslig.transfTit.cpfSubstituto.Should().Be("12345678901");
        ev2299.evtDeslig.infoDeslig.transfTit.dtNascto.Should().BeSameDateAs(new DateTime(1980, 1, 1));
        
        ev2299.evtDeslig.infoDeslig.mudancaCPF.novoCPF.Should().Be("12345678902");
        
        ev2299.evtDeslig.infoDeslig.remunAposDeslig.indRemun.Should().Be(1);
        ev2299.evtDeslig.infoDeslig.remunAposDeslig.dtFimRemun.Should().BeSameDateAs(new DateTime(2024, 12, 31));
        
        ev2299.evtDeslig.infoDeslig.consigFGTS[0].insConsig.Should().Be("12345");
        ev2299.evtDeslig.infoDeslig.consigFGTS[0].nrContr.Should().Be("1234");
        
        ev2299.evtDeslig.infoDeslig.verbasResc.dmDev[0].ideDmDev.Should().Be("IDE1");
        ev2299.evtDeslig.infoDeslig.verbasResc.dmDev[0].indRRA.Should().Be(SimNaoString.Sim);
        ev2299.evtDeslig.infoDeslig.verbasResc.dmDev[0].notAFT.Should().Be("123456789");
        
        var detVerbas = ev2299.evtDeslig.infoDeslig.verbasResc.dmDev[0].infoPerApur.ideEstabLot[0].detVerbas[0];
        detVerbas.codRubr.Should().Be("RUB1");
        detVerbas.vrRubr.Should().Be(100m);
        detVerbas.qtdRubr.Should().Be(1m);
        detVerbas.descFolha.nrDoc.Should().Be("DOC1");
        
        ev2299.evtDeslig.infoDeslig.verbasResc.infoMV.indMV.Should().Be(1);
        ev2299.evtDeslig.infoDeslig.verbasResc.infoMV.remunOutrEmp[0].nrInsc.Should().Be("12345678000199");
        ev2299.evtDeslig.infoDeslig.verbasResc.procCS.nrProcJud.Should().Be("12345678901234567890");
    }

    // BaseESocialTest overrides
    // BaseESocialTest overrides
    public override void PreencheCampos(S2299 evento)
    {
        evento.Versao = _versao;
        evento.evtDeslig = new S2299EvtDeslig()
        {
            ideEvento = new S2299IdeEvento()
            {
                tpAmb = Ambiente.ProducaoRestrita_DadosReais,
                procEmi = EmissorEvento.AppEmpregador,
                verProc = "1.0",
                indRetif = IndicadorRetificacao.Original
            },
            ideEmpregador = new Empregador()
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = CnpjCpf.Substring(0, 8)
            },
            ideVinculo = new S2299IdeVinculo()
            {
                cpfTrab = "12345678901",
                matricula = "123456"
            },
            infoDeslig = new S2299InfoDeslig()
            {
                mtvDeslig = "01",
                dtDeslig = new DateTime(2024, 1, 31),
                dtAvPrv = new DateTime(2023, 12, 31),
                indPagtoAPI = SimNaoString.Nao,
                dtProjFimAPI = new DateTime(2024, 2, 28),
                pensAlim = 1,
                percAliment = 15.5m,
                vrAlim = 500m,
                nrProcTrab = "12345678901234567890",
                indPDV = SimNaoString.Sim,
                infoInterm =
                [
                    new S2299InfoInterm { dia = 10 }
                ],
                observacoes = new System.Collections.Generic.List<S2299Observacao>
                {
                    new S2299Observacao { Value = "Observacao Teste" }
                },
                sucessaoVinc = new S2299SucessaoVinc
                {
                    tpInsc = TipoInscricao.CNPJ,
                    nrInsc = "12345678000199"
                },
                transfTit = new S2299TransfTit
                {
                    cpfSubstituto = "12345678901",
                    dtNascto = new DateTime(1980, 1, 1)
                },
                mudancaCPF = new S2299MudancaCPF
                {
                    novoCPF = "12345678902"
                },
                remunAposDeslig = new S2299RemunAposDeslig
                {
                    indRemun = 1,
                    dtFimRemun = new DateTime(2024, 12, 31)
                },
                consigFGTS = new System.Collections.Generic.List<S2299ConsigFGTS>()
            {
                new S2299ConsigFGTS()
                {
                    insConsig = "12345",
                    nrContr = "1234"
                }
            },
            verbasResc = new S2299VerbasResc()
            {
                dmDev = new System.Collections.Generic.List<S2299DmDev>()
                {
                    new S2299DmDev()
                    {
                        ideDmDev = "IDE1",
                        indRRA = SimNaoString.Sim,
                        notAFT = _versao == Versao.v_S_01_03_00 ? "123456789" : null,
                            infoPerApur = new S2299InfoPerApur
                            {
                                ideEstabLot = new System.Collections.Generic.List<S2299IdeEstabLot>
                                {
                                    new S2299IdeEstabLot
                                    {
                                        tpInsc = TipoInscricao.CNPJ,
                                        nrInsc = "12345678000199",
                                        codLotacao = "LOT1",
                                        detVerbas = new System.Collections.Generic.List<S2299DetVerbasDescFolha>
                                        {
                                            new S2299DetVerbasDescFolha
                                            {
                                                codRubr = "RUB1",
                                                ideTabRubr = "TAB1",
                                                qtdRubr = 1m,
                                                fatorRubr = 1m,
                                                vrRubr = 100m,
                                                indApurIR = 0,
                                                descFolha = _versao == Versao.v_S_01_03_00 ? new S2299DescFolha
                                                {
                                                    tpDesc = 1,
                                                    instFinanc = "123",
                                                    nrDoc = "DOC1",
                                                    observacao = "Obs"
                                                } : null
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    },
                    infoMV = new S2299InfoMV
                    {
                        indMV = 1,
                        remunOutrEmp = new System.Collections.Generic.List<S2299RemunOutrasEmpresas>
                        {
                            new S2299RemunOutrasEmpresas { tpInsc = TipoInscricao.CNPJ, nrInsc = "12345678000199", codCateg = "101", vlrRemunOE = 1000m }
                        }
                    },
                    procCS = new S2299ProcCS
                    {
                        nrProcJud = "12345678901234567890"
                    }
                }
            }
        };
    }

    public override void ValidaInstanciasLeituraEscrita(S2299 instanciaPopulada, S2299 instanciaXml)
    {
        // ideEvento
        instanciaXml.evtDeslig.ideEvento.tpAmb.Should().Be(instanciaPopulada.evtDeslig.ideEvento.tpAmb);
        instanciaXml.evtDeslig.ideEvento.procEmi.Should().Be(instanciaPopulada.evtDeslig.ideEvento.procEmi);
        instanciaXml.evtDeslig.ideEvento.verProc.Should().Be(instanciaPopulada.evtDeslig.ideEvento.verProc);

        // ideEmpregador
        instanciaXml.evtDeslig.ideEmpregador.tpInsc.Should().Be(instanciaPopulada.evtDeslig.ideEmpregador.tpInsc);
        instanciaXml.evtDeslig.ideEmpregador.nrInsc.Should().Be(instanciaPopulada.evtDeslig.ideEmpregador.nrInsc);

        // ideVinculo
        instanciaXml.evtDeslig.ideVinculo.cpfTrab.Should().Be(instanciaPopulada.evtDeslig.ideVinculo.cpfTrab);
        instanciaXml.evtDeslig.ideVinculo.matricula.Should().Be(instanciaPopulada.evtDeslig.ideVinculo.matricula);

        // infoDeslig
        instanciaXml.evtDeslig.infoDeslig.mtvDeslig.Should().Be(instanciaPopulada.evtDeslig.infoDeslig.mtvDeslig);
        instanciaXml.evtDeslig.infoDeslig.dtDeslig.Should().BeSameDateAs(instanciaPopulada.evtDeslig.infoDeslig.dtDeslig);
        instanciaXml.evtDeslig.infoDeslig.dtAvPrv.Should().BeSameDateAs(instanciaPopulada.evtDeslig.infoDeslig.dtAvPrv.Value);
        instanciaXml.evtDeslig.infoDeslig.indPagtoAPI.Should().Be(instanciaPopulada.evtDeslig.infoDeslig.indPagtoAPI);
        instanciaXml.evtDeslig.infoDeslig.dtProjFimAPI.Should().BeSameDateAs(instanciaPopulada.evtDeslig.infoDeslig.dtProjFimAPI.Value);
        instanciaXml.evtDeslig.infoDeslig.pensAlim.Should().Be(instanciaPopulada.evtDeslig.infoDeslig.pensAlim);
        instanciaXml.evtDeslig.infoDeslig.percAliment.Should().Be(instanciaPopulada.evtDeslig.infoDeslig.percAliment);
        instanciaXml.evtDeslig.infoDeslig.vrAlim.Should().Be(instanciaPopulada.evtDeslig.infoDeslig.vrAlim);
        instanciaXml.evtDeslig.infoDeslig.nrProcTrab.Should().Be(instanciaPopulada.evtDeslig.infoDeslig.nrProcTrab);
        instanciaXml.evtDeslig.infoDeslig.indPDV.Should().Be(instanciaPopulada.evtDeslig.infoDeslig.indPDV);
        instanciaXml.evtDeslig.infoDeslig.infoInterm[0].dia.Should().Be(instanciaPopulada.evtDeslig.infoDeslig.infoInterm[0].dia);
        instanciaXml.evtDeslig.infoDeslig.observacoes[0].Value.Should().Be(instanciaPopulada.evtDeslig.infoDeslig.observacoes[0].Value);
        
        // Novos blocos infoDeslig
        instanciaXml.evtDeslig.infoDeslig.sucessaoVinc.tpInsc.Should().Be(instanciaPopulada.evtDeslig.infoDeslig.sucessaoVinc.tpInsc);
        instanciaXml.evtDeslig.infoDeslig.sucessaoVinc.nrInsc.Should().Be(instanciaPopulada.evtDeslig.infoDeslig.sucessaoVinc.nrInsc);
        
        instanciaXml.evtDeslig.infoDeslig.transfTit.cpfSubstituto.Should().Be(instanciaPopulada.evtDeslig.infoDeslig.transfTit.cpfSubstituto);
        instanciaXml.evtDeslig.infoDeslig.transfTit.dtNascto.Should().BeSameDateAs(instanciaPopulada.evtDeslig.infoDeslig.transfTit.dtNascto);
        
        instanciaXml.evtDeslig.infoDeslig.mudancaCPF.novoCPF.Should().Be(instanciaPopulada.evtDeslig.infoDeslig.mudancaCPF.novoCPF);
        
        instanciaXml.evtDeslig.infoDeslig.remunAposDeslig.indRemun.Should().Be(instanciaPopulada.evtDeslig.infoDeslig.remunAposDeslig.indRemun);
        instanciaXml.evtDeslig.infoDeslig.remunAposDeslig.dtFimRemun.Should().BeSameDateAs(instanciaPopulada.evtDeslig.infoDeslig.remunAposDeslig.dtFimRemun);
        
        instanciaXml.evtDeslig.infoDeslig.consigFGTS[0].insConsig.Should().Be(instanciaPopulada.evtDeslig.infoDeslig.consigFGTS[0].insConsig);
        instanciaXml.evtDeslig.infoDeslig.consigFGTS[0].nrContr.Should().Be(instanciaPopulada.evtDeslig.infoDeslig.consigFGTS[0].nrContr);
        
        instanciaXml.evtDeslig.infoDeslig.verbasResc.dmDev[0].ideDmDev.Should().Be(instanciaPopulada.evtDeslig.infoDeslig.verbasResc.dmDev[0].ideDmDev);
        instanciaXml.evtDeslig.infoDeslig.verbasResc.dmDev[0].indRRA.Should().Be(instanciaPopulada.evtDeslig.infoDeslig.verbasResc.dmDev[0].indRRA);
        instanciaXml.evtDeslig.infoDeslig.verbasResc.dmDev[0].notAFT.Should().Be(instanciaPopulada.evtDeslig.infoDeslig.verbasResc.dmDev[0].notAFT);
        
        var detVerbasXml = instanciaXml.evtDeslig.infoDeslig.verbasResc.dmDev[0].infoPerApur.ideEstabLot[0].detVerbas[0];
        var detVerbasPop = instanciaPopulada.evtDeslig.infoDeslig.verbasResc.dmDev[0].infoPerApur.ideEstabLot[0].detVerbas[0];
        
        detVerbasXml.codRubr.Should().Be(detVerbasPop.codRubr);
        detVerbasXml.vrRubr.Should().Be(detVerbasPop.vrRubr);
        detVerbasXml.qtdRubr.Should().Be(detVerbasPop.qtdRubr);
        detVerbasXml.descFolha?.nrDoc.Should().Be(detVerbasPop.descFolha?.nrDoc);
        
        instanciaXml.evtDeslig.infoDeslig.verbasResc.infoMV.indMV.Should().Be(instanciaPopulada.evtDeslig.infoDeslig.verbasResc.infoMV.indMV);
        instanciaXml.evtDeslig.infoDeslig.verbasResc.infoMV.remunOutrEmp[0].nrInsc.Should().Be(instanciaPopulada.evtDeslig.infoDeslig.verbasResc.infoMV.remunOutrEmp[0].nrInsc);
        instanciaXml.evtDeslig.infoDeslig.verbasResc.procCS.nrProcJud.Should().Be(instanciaPopulada.evtDeslig.infoDeslig.verbasResc.procCS.nrProcJud);
    }


}
