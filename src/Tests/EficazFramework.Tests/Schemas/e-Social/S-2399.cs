using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.eSocial;

public class S2399Test : BaseESocialTest<S2399>
{
    [Test]
    [TestCase(Versao.v_S_01_02_00)]
    [TestCase(Versao.v_S_01_03_00)]
    public async Task Valida(Versao versao)
    {
        _versao = versao;
        ValidationSchemaNamespace = $"http://www.esocial.gov.br/schema/evt/evtTSVTermino/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v_S_01_03_00 => Resources.Schemas.eSocial.S2399_v_S_01_03_00,
            _ => Resources.Schemas.eSocial.S2399_v_S_01_02_00
        };
        await TestaEvento();
    }


    [Test]
    public async Task Read_v_S_01_03_00()
    {
        var evento = await Evento.ReadAsync(Resources.Samples.eSocial.S2399_v_S_01_03_00);
        evento.Should().NotBeNull();
        evento.Should().BeOfType<S2399>();
        
        var ev2399 = evento as S2399;
        
        // ideEvento
        ev2399.evtTSVTermino.ideEvento.tpAmb.Should().Be(Ambiente.ProducaoRestrita_DadosReais);
        ev2399.evtTSVTermino.ideEvento.procEmi.Should().Be(EmissorEvento.AppEmpregador);
        ev2399.evtTSVTermino.ideEvento.verProc.Should().Be("EficazFramework");
        ev2399.evtTSVTermino.ideEvento.indRetif.Should().Be(IndicadorRetificacao.Original);
        
        // ideEmpregador
        ev2399.evtTSVTermino.ideEmpregador.tpInsc.Should().Be(PersonalidadeJuridica.CNPJ);
        ev2399.evtTSVTermino.ideEmpregador.nrInsc.Should().Be("10608025000126");
        
        // ideTrabSemVinculo
        ev2399.evtTSVTermino.ideTrabSemVinculo.cpfTrab.Should().Be("12345678901");
        ev2399.evtTSVTermino.ideTrabSemVinculo.matricula.Should().Be("123");
        ev2399.evtTSVTermino.ideTrabSemVinculo.codCateg.Should().Be("721");
        
        // infoTSVTermino
        var info = ev2399.evtTSVTermino.infoTSVTermino;
        info.Should().NotBeNull();
        info.dtTerm.Should().Be(new DateTime(2024, 5, 20));
        info.mtvDesligTSV.Should().Be(MotivoDesligamentoTSV.ExoneracaoSemJustaCausa);
        info.pensAlim.Should().Be(1);
        info.percAliment.Should().Be(15.5m);
        info.vrAlim.Should().Be(1500m);
        info.nrProcTrab.Should().Be("12345678901234567890");
        
        info.mudancaCPF.Should().NotBeNull();
        info.mudancaCPF.novoCPF.Should().Be("09876543210");
        
        // verbasResc
        info.verbasResc.Should().NotBeNull();
        info.verbasResc.dmDev.Should().HaveCount(1);
        var dmDev = info.verbasResc.dmDev[0];
        dmDev.ideDmDev.Should().Be("DM123");
        dmDev.indRRA.Should().Be(SimNaoString.Sim);
        
        dmDev.infoRRA.Should().NotBeNull();
        dmDev.infoRRA.tpProcRRA.Should().Be(TipoProcesso.Administrativo);
        dmDev.infoRRA.nrProcRRA.Should().Be("123456789012345678901");
        dmDev.infoRRA.descRRA.Should().Be("Descrição RRA");
        dmDev.infoRRA.qtdMesesRRA.Should().Be(10);
        dmDev.infoRRA.despProcJud.Should().NotBeNull();
        dmDev.infoRRA.despProcJud.vlrDespCustas.Should().Be(100m);
        dmDev.infoRRA.despProcJud.vlrDespAdvogados.Should().Be(200m);
        
        dmDev.ideEstabLot.Should().HaveCount(1);
        var estabLot = dmDev.ideEstabLot[0];
        estabLot.tpInsc.Should().Be(PersonalidadeJuridica.CNPJ);
        estabLot.nrInsc.Should().Be("10608025000126");
        estabLot.codLotacao.Should().Be("LOT01");
        
        estabLot.detVerbas.Should().HaveCount(1);
        var detVerbas = estabLot.detVerbas[0];
        detVerbas.codRubr.Should().Be("R01");
        detVerbas.ideTabRubr.Should().Be("T01");
        detVerbas.qtdRubr.Should().Be(1);
        detVerbas.fatorRubr.Should().Be(1);
        detVerbas.vrRubr.Should().Be(1000m);
        detVerbas.indApurIR.Should().Be(0);
        
        detVerbas.descFolha.Should().NotBeNull();
        detVerbas.descFolha.tpDesc.Should().Be(1);
        detVerbas.descFolha.instFinanc.Should().Be("001");
        detVerbas.descFolha.nrDoc.Should().Be("12345");
        detVerbas.descFolha.observacao.Should().Be("Obs");
        
        estabLot.infoSimples.Should().NotBeNull();
        estabLot.infoSimples.indSimples.Should().Be(1);
        
        // procJudTrab
        info.verbasResc.procJudTrab.Should().HaveCount(1);
        info.verbasResc.procJudTrab[0].tpTrib.Should().Be(TipoProcesso.Judicial);
        info.verbasResc.procJudTrab[0].nrProcJud.Should().Be("12345678901234567890");
        info.verbasResc.procJudTrab[0].codSusp.Should().Be("12345678901234");
        
        // infoMV
        info.verbasResc.infoMV.Should().NotBeNull();
        info.verbasResc.infoMV.indMV.Should().Be(1);
        info.verbasResc.infoMV.remunOutrEmpr.Should().HaveCount(1);
        info.verbasResc.infoMV.remunOutrEmpr[0].tpInsc.Should().Be(PersonalidadeJuridica.CNPJ);
        info.verbasResc.infoMV.remunOutrEmpr[0].nrInsc.Should().Be("98765432000199");
        info.verbasResc.infoMV.remunOutrEmpr[0].codCateg.Should().Be("721");
        info.verbasResc.infoMV.remunOutrEmpr[0].vlrRemunOE.Should().Be(500m);
        
        // remunAposTerm
        ev2399.evtTSVTermino.infoTSVTermino.remunAposTerm.Should().NotBeNull();
        ev2399.evtTSVTermino.infoTSVTermino.remunAposTerm.indRemun.Should().Be(IndicadorRemuneracaoTSV.Quarentena);
        ev2399.evtTSVTermino.infoTSVTermino.remunAposTerm.dtFimRemun.Should().Be(new DateTime(2024, 6, 20));
    }

    public override void PreencheCampos(S2399 evento)
    {
        evento.Versao = _versao;
        
        evento.evtTSVTermino = new S2399EvtTSVTermino
        {
            ideEvento = new S2399IdeEvento
            {
                indRetif = IndicadorRetificacao.Original,
                nrRecibo = null,
                indGuia = IndicadorGuia.DAE,
                tpAmb = Ambiente.ProducaoRestrita_DadosReais,
                procEmi = EmissorEvento.AppEmpregador,
                verProc = "EficazFramework"
            },
            
            ideEmpregador = new Empregador
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = CnpjCpf
            },
            
            ideTrabSemVinculo = new S2399IdeTrabSemVinculo
            {
                cpfTrab = "12345678901",
                matricula = "123",
                codCateg = "721"
            },
            
            infoTSVTermino = new S2399InfoTSVTermino
            {
                dtTerm = new DateTime(2024, 5, 20),
                mtvDesligTSV = MotivoDesligamentoTSV.ExoneracaoSemJustaCausa,
                pensAlim = 1,
                percAliment = 15.5m,
                vrAlim = 1500m,
                nrProcTrab = "12345678901234567890",
                
                mudancaCPF = new S2399MudancaCPF
                {
                    novoCPF = "09876543210"
                },
                
                verbasResc = new S2399VerbasResc
                {
                    dmDev = new List<S2399DmDev>
                    {
                        new S2399DmDev
                        {
                            ideDmDev = "DM123",
                            indRRA = SimNaoString.Sim,
                            infoRRA = new S2399InfoRRA
                            {
                                tpProcRRA = TipoProcesso.Administrativo,
                                nrProcRRA = "123456789012345678901",
                                descRRA = "Descrição RRA",
                                qtdMesesRRA = 10,
                                despProcJud = new DetalhamentoDespJud
                                {
                                    vlrDespCustas = 100m,
                                    vlrDespAdvogados = 200m
                                }
                            },
                            ideEstabLot = new List<S2399IdeEstabLot>
                            {
                                new S2399IdeEstabLot
                                {
                                    tpInsc = PersonalidadeJuridica.CNPJ,
                                    nrInsc = CnpjCpf,
                                    codLotacao = "LOT01",
                                    detVerbas = new List<S2399DetVerbas>
                                    {
                                        new S2399DetVerbas
                                        {
                                            codRubr = "R01",
                                            ideTabRubr = "T01",
                                            qtdRubr = 1,
                                            fatorRubr = 1,
                                            vrRubr = 1000m,
                                            indApurIR = 0,
                                            descFolha = _versao == Versao.v_S_01_03_00 ? new S2399DescFolha
                                            {
                                                tpDesc = 1,
                                                instFinanc = "001",
                                                nrDoc = "12345",
                                                observacao = "Obs"
                                            } : null
                                        }
                                    },
                                    infoSimples = new S2399InfoSimples
                                    {
                                        indSimples = 1
                                    }
                                }
                            }
                        }
                    },
                    procJudTrab = new List<S2399ProcJudTrab>
                    {
                        new S2399ProcJudTrab
                        {
                            tpTrib = TipoProcesso.Judicial,
                            nrProcJud = "12345678901234567890",
                            codSusp = "12345678901234"
                        }
                    },
                    infoMV = new S2399InfoMV
                    {
                        indMV = 1,
                        remunOutrEmpr = new List<S2399RemunOutrasEmpresas>
                        {
                            new S2399RemunOutrasEmpresas
                            {
                                tpInsc = PersonalidadeJuridica.CNPJ,
                                nrInsc = "98765432000199",
                                codCateg = "721",
                                vlrRemunOE = 500m
                            }
                        }
                    }
                },
                
                remunAposTerm = new S2399RemunAposTerm
                {
                    indRemun = IndicadorRemuneracaoTSV.Quarentena,
                    dtFimRemun = new DateTime(2024, 6, 20)
                }
            }
        };
    }

    public override void ValidaInstanciasLeituraEscrita(S2399 instanciaPopulada, S2399 instanciaXml)
    {
        instanciaXml.Should().NotBeNull();
        instanciaXml.evtTSVTermino.Should().NotBeNull();
        instanciaXml.evtTSVTermino.ideEvento.indRetif.Should().Be(instanciaPopulada.evtTSVTermino.ideEvento.indRetif);
        instanciaXml.evtTSVTermino.ideEvento.tpAmb.Should().Be(instanciaPopulada.evtTSVTermino.ideEvento.tpAmb);
        instanciaXml.evtTSVTermino.ideEvento.procEmi.Should().Be(instanciaPopulada.evtTSVTermino.ideEvento.procEmi);
        instanciaXml.evtTSVTermino.ideEvento.verProc.Should().Be(instanciaPopulada.evtTSVTermino.ideEvento.verProc);

        instanciaXml.evtTSVTermino.ideEmpregador.tpInsc.Should().Be(instanciaPopulada.evtTSVTermino.ideEmpregador.tpInsc);
        instanciaXml.evtTSVTermino.ideEmpregador.nrInsc.Should().Be(instanciaPopulada.evtTSVTermino.ideEmpregador.nrInsc);

        instanciaXml.evtTSVTermino.ideTrabSemVinculo.cpfTrab.Should().Be(instanciaPopulada.evtTSVTermino.ideTrabSemVinculo.cpfTrab);
        instanciaXml.evtTSVTermino.ideTrabSemVinculo.matricula.Should().Be(instanciaPopulada.evtTSVTermino.ideTrabSemVinculo.matricula);
        instanciaXml.evtTSVTermino.ideTrabSemVinculo.codCateg.Should().Be(instanciaPopulada.evtTSVTermino.ideTrabSemVinculo.codCateg);

        instanciaXml.evtTSVTermino.infoTSVTermino.dtTerm.Should().BeSameDateAs(instanciaPopulada.evtTSVTermino.infoTSVTermino.dtTerm);
        instanciaXml.evtTSVTermino.infoTSVTermino.mtvDesligTSV.Should().Be(instanciaPopulada.evtTSVTermino.infoTSVTermino.mtvDesligTSV);
        
        instanciaXml.evtTSVTermino.infoTSVTermino.mudancaCPF.novoCPF.Should().Be(instanciaPopulada.evtTSVTermino.infoTSVTermino.mudancaCPF.novoCPF);
        
        instanciaXml.evtTSVTermino.infoTSVTermino.verbasResc.dmDev[0].ideDmDev.Should().Be(instanciaPopulada.evtTSVTermino.infoTSVTermino.verbasResc.dmDev[0].ideDmDev);
        instanciaXml.evtTSVTermino.infoTSVTermino.verbasResc.dmDev[0].indRRA.Should().Be(instanciaPopulada.evtTSVTermino.infoTSVTermino.verbasResc.dmDev[0].indRRA);
    }
}
