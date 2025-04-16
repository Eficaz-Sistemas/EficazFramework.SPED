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
                CpfTrab = "45019308889"
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
    }
}