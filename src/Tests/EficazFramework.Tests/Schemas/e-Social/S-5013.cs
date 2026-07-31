namespace EficazFramework.SPED.Schemas.eSocial;

public class S5013Test : BaseESocialTest<S5013>
{
    [Test]
    [TestCase(Versao.v_S_01_02_00)]
    [TestCase(Versao.v_S_01_03_00)]
    public async Task Valida(Versao versao)
    {
        _versao = versao;
        ValidationSchemaNamespace = $"http://www.esocial.gov.br/schema/evt/evtFGTS/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v_S_01_03_00 => Resources.Schemas.eSocial.S5013_v_S_01_03_00,
            _ => Resources.Schemas.eSocial.S5013_v_S_01_02_00
        };
        await TestaEvento();
    }

    [Test]
    public async Task Read_v_S_01_03_00()
    {
        var evento = await Evento.ReadAsync(Resources.Samples.eSocial.S5013_v_S_01_03_00);
        evento.Should().NotBeNull();
        evento.Versao.Should().Be(Versao.v_S_01_03_00);
        var evt5013 = evento as S5013;
        evt5013.Should().NotBeNull();
        evt5013.evtFGTS.Should().NotBeNull();
        evt5013.evtFGTS.ideEvento.indApuracao.Should().Be(IndicadorApuracao.Mensal);
        evt5013.evtFGTS.ideEvento.perApur.Should().Be("2025-02");
        evt5013.evtFGTS.ideEmpregador.tpInsc.Should().Be(PersonalidadeJuridica.CNPJ);
        evt5013.evtFGTS.ideEmpregador.nrInsc.Should().Be("34785515");

        // infoFGTS
        evt5013.evtFGTS.infoFGTS.Should().NotBeNull();
        evt5013.evtFGTS.infoFGTS.nrRecArqBase.Should().Be("1.1.0000000000000000000");
        evt5013.evtFGTS.infoFGTS.indExistInfo.Should().Be(IndicadorExistenciaInfoFGTS.HaInformacoesFGTS);

        // ideEstab
        evt5013.evtFGTS.infoFGTS.ideEstab.Should().HaveCount(1);
        var estab = evt5013.evtFGTS.infoFGTS.ideEstab[0];
        estab.tpInsc.Should().Be(PersonalidadeJuridica.CNPJ);
        estab.nrInsc.Should().Be("34785515000166");

        // ideLotacao
        estab.ideLotacao.Should().HaveCount(1);
        var lotacao = estab.ideLotacao[0];
        lotacao.codLotacao.Should().Be("LOT01");
        lotacao.tpLotacao.Should().Be("01");
        lotacao.tpInsc.Should().Be(PersonalidadeJuridica.CNPJ);
        lotacao.nrInsc.Should().Be("34785515000166");

        // infoBaseFGTS
        lotacao.infoBaseFGTS.Should().NotBeNull();

        // basePerApur
        lotacao.infoBaseFGTS.basePerApur.Should().HaveCount(1);
        var basePerApur = lotacao.infoBaseFGTS.basePerApur[0];
        basePerApur.tpValor.Should().Be((byte)11);
        basePerApur.indIncid.Should().Be(IndicadorIncidenciaFGTS.Normal);
        basePerApur.baseFGTS.Should().Be(5000.00m);
        basePerApur.vrFGTS.Should().Be(400.00m);
        basePerApur.notAFT.Should().Be("123456789");
        basePerApur.natRubr.Should().Be("1000");

        // infoBasePerAntE
        lotacao.infoBaseFGTS.infoBasePerAntE.Should().HaveCount(1);
        var infoBasePerAntE = lotacao.infoBaseFGTS.infoBasePerAntE[0];
        infoBasePerAntE.perRef.Should().Be("2024-12");
        infoBasePerAntE.tpAcConv.Should().Be(TipoAcordoColetivo.ConversaoLicencaSaudeAcidenteTrabalho);
        infoBasePerAntE.basePerAntE.Should().HaveCount(1);
        var basePerAntE = infoBasePerAntE.basePerAntE[0];
        basePerAntE.tpValorE.Should().Be((byte)13);
        basePerAntE.indIncidE.Should().Be(IndicadorIncidenciaFGTS.Normal);
        basePerAntE.baseFGTSE.Should().Be(2500.00m);
        basePerAntE.vrFGTSE.Should().Be(200.00m);
    }

    public override void PreencheCampos(S5013 evento)
    {
        bool isV0103 = _versao == Versao.v_S_01_03_00;
        evento.Versao = _versao;
        evento.evtFGTS = new S5013EvtFGTS()
        {
            ideEvento = new S5013IdeEvento()
            {
                indApuracao = IndicadorApuracao.Mensal,
                perApur = "2025-02"
            },
            ideEmpregador = new Empregador()
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = CnpjCpf.Substring(0, 8)
            },
            infoFGTS = new S5013InfoFGTS()
            {
                nrRecArqBase = "1.1.0000000000000000000",
                indExistInfo = IndicadorExistenciaInfoFGTS.HaInformacoesFGTS,
                ideEstab =
                [
                    new S5013IdeEstab()
                    {
                        tpInsc = PersonalidadeJuridica.CNPJ,
                        nrInsc = CnpjCpf,
                        ideLotacao =
                        [
                            new S5013IdeLotacao()
                            {
                                codLotacao = "LOT01",
                                tpLotacao = "01",
                                tpInsc = PersonalidadeJuridica.CNPJ,
                                nrInsc = CnpjCpf,
                                infoBaseFGTS = new S5013InfoBaseFGTS()
                                {
                                    basePerApur =
                                    [
                                        new S5013BasePerApur()
                                        {
                                            tpValor = 11,
                                            indIncid = IndicadorIncidenciaFGTS.Normal,
                                            baseFGTS = 5000.00m,
                                            vrFGTS = 400.00m,
                                            notAFT = isV0103 ? "123456789" : null,
                                            natRubr = isV0103 ? "1000" : null
                                        }
                                    ],
                                    infoBasePerAntE =
                                    [
                                        new S5013InfoBasePerAntE()
                                        {
                                            perRef = "2024-12",
                                            tpAcConv = TipoAcordoColetivo.ConversaoLicencaSaudeAcidenteTrabalho,
                                            basePerAntE =
                                            [
                                                new S5013BasePerAntE()
                                                {
                                                    tpValorE = 13,
                                                    indIncidE = IndicadorIncidenciaFGTS.Normal,
                                                    baseFGTSE = 2500.00m,
                                                    vrFGTSE = 200.00m
                                                }
                                            ]
                                        }
                                    ]
                                }
                            }
                        ]
                    }
                ]
            }
        };
    }

    public override void ValidaInstanciasLeituraEscrita(S5013 instanciaPopulada, S5013 instanciaXml)
    {
        instanciaPopulada.Should().NotBeNull();
        instanciaXml.Should().NotBeNull();

        // ideEvento
        instanciaXml.evtFGTS.ideEvento.indApuracao.Should().Be(instanciaPopulada.evtFGTS.ideEvento.indApuracao);
        instanciaXml.evtFGTS.ideEvento.perApur.Should().Be(instanciaPopulada.evtFGTS.ideEvento.perApur);

        // ideEmpregador
        instanciaXml.evtFGTS.ideEmpregador.tpInsc.Should().Be(instanciaPopulada.evtFGTS.ideEmpregador.tpInsc);
        instanciaXml.evtFGTS.ideEmpregador.nrInsc.Should().Be(instanciaPopulada.evtFGTS.ideEmpregador.nrInsc);

        // infoFGTS
        instanciaXml.evtFGTS.infoFGTS.Should().NotBeNull();
        instanciaXml.evtFGTS.infoFGTS.nrRecArqBase.Should().Be(instanciaPopulada.evtFGTS.infoFGTS.nrRecArqBase);
        instanciaXml.evtFGTS.infoFGTS.indExistInfo.Should().Be(instanciaPopulada.evtFGTS.infoFGTS.indExistInfo);

        // ideEstab
        instanciaXml.evtFGTS.infoFGTS.ideEstab.Should().HaveCount(instanciaPopulada.evtFGTS.infoFGTS.ideEstab.Count);
        var estabPop = instanciaPopulada.evtFGTS.infoFGTS.ideEstab[0];
        var estabXml = instanciaXml.evtFGTS.infoFGTS.ideEstab[0];
        estabXml.tpInsc.Should().Be(estabPop.tpInsc);
        estabXml.nrInsc.Should().Be(estabPop.nrInsc);

        // ideLotacao
        estabXml.ideLotacao.Should().HaveCount(estabPop.ideLotacao.Count);
        var lotacaoPop = estabPop.ideLotacao[0];
        var lotacaoXml = estabXml.ideLotacao[0];
        lotacaoXml.codLotacao.Should().Be(lotacaoPop.codLotacao);
        lotacaoXml.tpLotacao.Should().Be(lotacaoPop.tpLotacao);
        lotacaoXml.tpInsc.Should().Be(lotacaoPop.tpInsc);
        lotacaoXml.nrInsc.Should().Be(lotacaoPop.nrInsc);

        // infoBaseFGTS
        lotacaoXml.infoBaseFGTS.Should().NotBeNull();

        // basePerApur
        lotacaoXml.infoBaseFGTS.basePerApur.Should().HaveCount(lotacaoPop.infoBaseFGTS.basePerApur.Count);
        var basePerApurPop = lotacaoPop.infoBaseFGTS.basePerApur[0];
        var basePerApurXml = lotacaoXml.infoBaseFGTS.basePerApur[0];
        basePerApurXml.tpValor.Should().Be(basePerApurPop.tpValor);
        basePerApurXml.indIncid.Should().Be(basePerApurPop.indIncid);
        basePerApurXml.baseFGTS.Should().Be(basePerApurPop.baseFGTS);
        basePerApurXml.vrFGTS.Should().Be(basePerApurPop.vrFGTS);
        basePerApurXml.notAFT.Should().Be(basePerApurPop.notAFT);
        basePerApurXml.natRubr.Should().Be(basePerApurPop.natRubr);

        // infoBasePerAntE
        lotacaoXml.infoBaseFGTS.infoBasePerAntE.Should().HaveCount(lotacaoPop.infoBaseFGTS.infoBasePerAntE.Count);
        var infoBasePerAntEPop = lotacaoPop.infoBaseFGTS.infoBasePerAntE[0];
        var infoBasePerAntEXml = lotacaoXml.infoBaseFGTS.infoBasePerAntE[0];
        infoBasePerAntEXml.perRef.Should().Be(infoBasePerAntEPop.perRef);
        infoBasePerAntEXml.tpAcConv.Should().Be(infoBasePerAntEPop.tpAcConv);

        infoBasePerAntEXml.basePerAntE.Should().HaveCount(infoBasePerAntEPop.basePerAntE.Count);
        var basePerAntEPop = infoBasePerAntEPop.basePerAntE[0];
        var basePerAntEXml = infoBasePerAntEXml.basePerAntE[0];
        basePerAntEXml.tpValorE.Should().Be(basePerAntEPop.tpValorE);
        basePerAntEXml.indIncidE.Should().Be(basePerAntEPop.indIncidE);
        basePerAntEXml.baseFGTSE.Should().Be(basePerAntEPop.baseFGTSE);
        basePerAntEXml.vrFGTSE.Should().Be(basePerAntEPop.vrFGTSE);
    }
}
