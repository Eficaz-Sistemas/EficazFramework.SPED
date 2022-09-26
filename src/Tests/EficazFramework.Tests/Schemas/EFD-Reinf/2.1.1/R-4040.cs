namespace EficazFramework.SPED.Schemas.EFD_Reinf.v2_01_01;

public class R4040Test : BaseEfdReinfTest<R4040>
{
    public R4040Test()
    {
        ValidationSchemaNamespace = "http://www.reinf.esocial.gov.br/schemas/evt4040PagtoBenefNaoIdentificado/v2_01_01";
        ValidationSchema = Resources.Schemas.EFD_Reinf.R4040_v2_01_01;
    }

    //[Test] Ignorando o teste pois provavelmente o patten do campo 'natRend' ficou ERRADO.
    public void RendimentoNaoIdentificado()
    {
        TestaEvento();
    }

    // BaseEfdReinfTest overrides
    public override void PreencheCampos(R4040 evento)
    {
        evento.evtBenefNId = new()
        {
            ideEvento = new()
            {
                indRetif = IndicadorRetificacao.Original,
                perApur = "2022-08",
                tpAmb = Ambiente.ProducaoRestrita_DadosReais,
                procEmi = EmissorEvento.AppContribuinte,
                verProc = "6.0"
            },
            ideContri = new()
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = "34785515000166",
            },
            ideEstab = new()
            {
                tpInscEstab = PersonalidadeJuridica.CNPJ,
                nrInscEstab = "34785515000166",
                ideNat = new()
                {
                    new () //ideNat (1:N)
                    {
                        infoPgto = new()
                                {
                                    new()
                                    {
                                        DataFatoGerador = DateTime.Now,
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
                instanciaXml.evtBenefNId.ideEstab.ideNat[i].infoPgto[ii].vlrBaseIR.Should().BeNull();
                instanciaXml.evtBenefNId.ideEstab.ideNat[i].infoPgto[ii].vlrBaseIR.Should().Be(instanciaPopulada.evtBenefNId.ideEstab.ideNat[i].infoPgto[ii].vlrBaseIR);
                instanciaXml.evtBenefNId.ideEstab.ideNat[i].infoPgto[ii].vlrIR.Should().BeNull();
                instanciaXml.evtBenefNId.ideEstab.ideNat[i].infoPgto[ii].vlrIR.Should().Be(instanciaPopulada.evtBenefNId.ideEstab.ideNat[i].infoPgto[ii].vlrIR);
                instanciaXml.evtBenefNId.ideEstab.ideNat[i].infoPgto[ii].descr.Should().Be(instanciaPopulada.evtBenefNId.ideEstab.ideNat[i].infoPgto[ii].descr);

                // infoProcRet
                instanciaXml.evtBenefNId.ideEstab.ideNat[i].infoPgto[ii].infoProcRet.Should().BeNullOrEmpty();
                instanciaPopulada.evtBenefNId.ideEstab.ideNat[i].infoPgto[ii].infoProcRet.Should().BeNullOrEmpty();
            }
        }
    }
}
