namespace EficazFramework.SPED.Schemas.EFD_Reinf;

public class R4040Test : BaseEfdReinfTest<R4040>
{
    [Test]
    //[TestCase(Versao.v2_01_01)]
    [TestCase(Versao.v2_01_02)]
    public void RendimentoNaoIdentificado(Versao versao)
    {
        _versao = versao;
        InstanciaDesserializada = (R4040 e) => e.Versao = versao;
        ValidationSchemaNamespace = $"http://www.reinf.esocial.gov.br/schemas/evt4040PagtoBenefNaoIdentificado/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v1_05_01 => throw new ArgumentException("Invalid version."),
            Versao.v2_01_01 => Resources.Schemas.EFD_Reinf.R4040_v2_01_01,
            Versao.v2_01_02 => Resources.Schemas.EFD_Reinf.R4040_v2_01_02_B,
            _ => Resources.Schemas.EFD_Reinf.R4040_v2_01_02_B
        };
        TestaEvento();
    }

    // BaseEfdReinfTest overrides
    public override void PreencheCampos(R4040 evento)
    {
        evento.Versao = _versao;
        evento.evtBenefNId = new ReinfEvtBenefNId()
        {
            ideEvento = new ReinfEvtIdeEvento_R40xx()
            {
                indRetif = IndicadorRetificacao.Original,
                perApur = "2022-08",
                tpAmb = Ambiente.ProducaoRestrita_DadosReais,
                procEmi = EmissorEvento.AppContribuinte,
                verProc = "6.0"
            },
            ideContri = new ReinfEvtIdeContri()
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = "34785515000166",
            },
            ideEstab = new ReinfEvtBenefNIdIdeEstab()
            {
                tpInscEstab = PersonalidadeJuridica.CNPJ,
                nrInscEstab = "34785515000166",
                ideNat = new System.Collections.Generic.List<ReinfEvtBenefNIdIdeEstabIdeNat>()
            {
                new ReinfEvtBenefNIdIdeEstabIdeNat() //ideNat (1:N)
                {
                    infoPgto = new System.Collections.Generic.List<ReinfEvtBenefNIdIdeEstabIdeNatInfoPgto>()
                            {
                                new ReinfEvtBenefNIdIdeEstabIdeNatInfoPgto()
                                {
                                    DataFatoGerador = System.DateTime.Now,
                                    vlrLiq = 1000000.00.ToString("f2"),
                                    vlrBaseIR = 153846.15M.ToString("f2"),
                                    vlrIR = 2307.69M.ToString("f2"),
                                    descr = "Alguma prestação de serviço qualquer."
                                },
                            },
                    // Utilizar a tabela 01, do Anexo I do Manual
                    natRend = 19009, // Remuneração de Serviços de auditoria;
                }
            }
            }
        };
    }

    public override void ValidaInstanciasLeituraEscrita(R4040 instanciaPopulada, R4040 instanciaXml)
    {
        // TODO: verifique se os campos de instanciaXml, preenchidos a partir da leitura de um XmlDocument, 
        //       correspondem exatamente aos valores de instanciaPopulada, formado à partir do método
        //       PreencheCampos().
        // ideEvento
        instanciaXml.evtBenefNId.ideEvento.indRetif.Should().Be(instanciaPopulada.evtBenefNId.ideEvento.indRetif);
        instanciaXml.evtBenefNId.ideEvento.perApur.Should().Be(instanciaPopulada.evtBenefNId.ideEvento.perApur);
        instanciaXml.evtBenefNId.ideEvento.tpAmb.Should().Be(instanciaPopulada.evtBenefNId.ideEvento.tpAmb);
        instanciaXml.evtBenefNId.ideEvento.procEmi.Should().Be(instanciaPopulada.evtBenefNId.ideEvento.procEmi);
        instanciaXml.evtBenefNId.ideEvento.verProc.Should().Be(instanciaPopulada.evtBenefNId.ideEvento.verProc);

        // ideContri
        instanciaXml.evtBenefNId.ideContri.tpInsc.Should().Be(instanciaPopulada.evtBenefNId.ideContri.tpInsc);
        instanciaXml.evtBenefNId.ideContri.nrInsc.Should().Be(instanciaPopulada.evtBenefNId.ideContri.nrInsc);

        // ideEstab         
        instanciaXml.evtBenefNId.ideEstab.tpInscEstab.Should().Be(instanciaPopulada.evtBenefNId.ideEstab.tpInscEstab);
        instanciaXml.evtBenefNId.ideEstab.nrInscEstab.Should().Be(instanciaPopulada.evtBenefNId.ideEstab.nrInscEstab);

        // ideNat
        instanciaXml.evtBenefNId.ideEstab.ideNat.Should().HaveCount(instanciaPopulada.evtBenefNId.ideEstab.ideNat.Count);
        for (int i = 0; i < instanciaXml.evtBenefNId.ideEstab.ideNat.Count; i++)
        {
            instanciaXml.evtBenefNId.ideEstab.ideNat[i].natRend.Should().Be(instanciaPopulada.evtBenefNId.ideEstab.ideNat[i].natRend);

            // infoPgto
            instanciaXml.evtBenefNId.ideEstab.ideNat[i].infoPgto.Should().HaveCount(instanciaPopulada.evtBenefNId.ideEstab.ideNat[i].infoPgto.Count);
            for (int ii = 0; ii < instanciaXml.evtBenefNId.ideEstab.ideNat[i].infoPgto.Count; ii++)
            {
                instanciaXml.evtBenefNId.ideEstab.ideNat[i].infoPgto[ii].DataFatoGerador.Should().BeSameDateAs(instanciaPopulada.evtBenefNId.ideEstab.ideNat[i].infoPgto[ii].DataFatoGerador);
                instanciaXml.evtBenefNId.ideEstab.ideNat[i].infoPgto[ii].vlrLiq.Should().Be(instanciaPopulada.evtBenefNId.ideEstab.ideNat[i].infoPgto[ii].vlrLiq);
                instanciaXml.evtBenefNId.ideEstab.ideNat[i].infoPgto[ii].vlrBaseIR.Should().Be(instanciaPopulada.evtBenefNId.ideEstab.ideNat[i].infoPgto[ii].vlrBaseIR);
                instanciaXml.evtBenefNId.ideEstab.ideNat[i].infoPgto[ii].vlrIR.Should().Be(instanciaPopulada.evtBenefNId.ideEstab.ideNat[i].infoPgto[ii].vlrIR);
                instanciaXml.evtBenefNId.ideEstab.ideNat[i].infoPgto[ii].descr.Should().Be(instanciaPopulada.evtBenefNId.ideEstab.ideNat[i].infoPgto[ii].descr);

                // infoProcRet
                instanciaXml.evtBenefNId.ideEstab.ideNat[i].infoPgto[ii].infoProcRet.Should().BeNullOrEmpty();
                instanciaPopulada.evtBenefNId.ideEstab.ideNat[i].infoPgto[ii].infoProcRet.Should().BeNullOrEmpty();
            }
        }
    }
}