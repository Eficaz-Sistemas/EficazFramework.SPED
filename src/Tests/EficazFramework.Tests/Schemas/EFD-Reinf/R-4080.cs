namespace EficazFramework.SPED.Schemas.EFD_Reinf;

public class R4080Test : BaseEfdReinfTest<R4080>
{
    [Test]
    [TestCase(Versao.v2_01_01)]
    [TestCase(Versao.v2_01_02)]
    public void RendimentosRecebidosComRetencao(Versao versao)
    {
        _versao = versao;
        InstanciaDesserializada = (R4080 e) => e.Versao = versao;
        ValidationSchemaNamespace = $"http://www.reinf.esocial.gov.br/schemas/evt4080RetencaoRecebimento/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v1_05_01 => throw new ArgumentException("Invalid version."),
            Versao.v2_01_01 => Resources.Schemas.EFD_Reinf.R4080_v2_01_01,
            Versao.v2_01_02 => Resources.Schemas.EFD_Reinf.R4080_v2_01_02_B,
            _ => Resources.Schemas.EFD_Reinf.R4080_v2_01_02_B
        };
        TestaEvento();
    }

    // BaseEfdReinfTest overrides
    public override void PreencheCampos(R4080 evento)
    {
        evento.Versao = _versao;
        PreencheCamposServices(evento, CnpjCpf);
    }

    internal static void PreencheCamposServices(R4080 evento, string cnpjCpf)
    {
        evento.evtRetRec = new R4080EventoRetRecebimento()
        {
            ideEvento = new IdentificacaoEventoPeriodico()
            {
                indRetif = IndicadorRetificacao.Original,
                perApur = $"{DateTime.Now.AddMonths(-1):yyyy-MM}",
                tpAmb = Ambiente.ProducaoRestrita_DadosReais,
                procEmi = EmissorEvento.AppContribuinte,
                verProc = "6.0"
            },
            ideContri = new IdentificacaoContribuinte()
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = cnpjCpf[..8],
            },
            ideEstab = new R4080IdentificacaoEstabelecimento()
            {
                tpInscEstab = PersonalidadeJuridica.CNPJ,
                nrInscEstab = cnpjCpf,
                ideFont = new R4080IdentificacaoFontePagadora()
                {
                    // identificação do beneficiário
                    cnpjFont = "34785515000166",
                    // pagamento (1:1, diferentemente ao apresentado em R-4010
                    ideRend = new System.Collections.Generic.List<R4080IdentificacaoRendimento>()
                    {
                        // identificação do recebimento
                        new R4080IdentificacaoRendimento()
                        {
                            // informações do recebimento
                            infoRec = new System.Collections.Generic.List<R4080InfoRecebimento>()
                            {
                                new R4080InfoRecebimento()
                                {
                                    DataFatoGerador = DateTime.Now.AddMonths(-1),
                                    vlrBruto = 152725.25M.ToString("f2"),
                                    vlrBaseIR = 152725.25M.ToString("f2"),
                                    vlrIR = 2290.88M.ToString("f2")
                                },
                            },
                            // Utilizar a tabela 01, do Anexo I do Manual
                            natRend = "20001", // propaganda e publicidade;
                            observ = "Serviços de Propaganda e Publicidade"
                        },
                    }
                }
            }
        };
    }

    public override void ValidaInstanciasLeituraEscrita(R4080 instanciaPopulada, R4080 instanciaXml)
    {
        // TODO: verifique se os campos de instanciaXml, preenchidos a partir da leitura de um XmlDocument, 
        //       correspondem exatamente aos valores de instanciaPopulada, formado à partir do método
        //       PreencheCampos().
        // ideEvento
        instanciaXml.evtRetRec.ideEvento.indRetif.Should().Be(instanciaPopulada.evtRetRec.ideEvento.indRetif);
        instanciaXml.evtRetRec.ideEvento.perApur.Should().Be(instanciaPopulada.evtRetRec.ideEvento.perApur);
        instanciaXml.evtRetRec.ideEvento.tpAmb.Should().Be(instanciaPopulada.evtRetRec.ideEvento.tpAmb);
        instanciaXml.evtRetRec.ideEvento.procEmi.Should().Be(instanciaPopulada.evtRetRec.ideEvento.procEmi);
        instanciaXml.evtRetRec.ideEvento.verProc.Should().Be(instanciaPopulada.evtRetRec.ideEvento.verProc);

        // ideContri
        instanciaXml.evtRetRec.ideContri.tpInsc.Should().Be(instanciaPopulada.evtRetRec.ideContri.tpInsc);
        instanciaXml.evtRetRec.ideContri.nrInsc.Should().Be(instanciaPopulada.evtRetRec.ideContri.nrInsc);

        // ideEstab         
        instanciaXml.evtRetRec.ideEstab.tpInscEstab.Should().Be(instanciaPopulada.evtRetRec.ideEstab.tpInscEstab);
        instanciaXml.evtRetRec.ideEstab.nrInscEstab.Should().Be(instanciaPopulada.evtRetRec.ideEstab.nrInscEstab);

        // ideFont         
        instanciaXml.evtRetRec.ideEstab.ideFont.cnpjFont.Should().Be(instanciaPopulada.evtRetRec.ideEstab.ideFont.cnpjFont);

        // ideRend
        instanciaXml.evtRetRec.ideEstab.ideFont.ideRend.Should().HaveCount(instanciaPopulada.evtRetRec.ideEstab.ideFont.ideRend.Count);
        for (int i = 0; i < instanciaXml.evtRetRec.ideEstab.ideFont.ideRend.Count; i++)
        {
            instanciaXml.evtRetRec.ideEstab.ideFont.ideRend[i].natRend.Should().Be(instanciaPopulada.evtRetRec.ideEstab.ideFont.ideRend[i].natRend);
            instanciaXml.evtRetRec.ideEstab.ideFont.ideRend[i].observ.Should().Be(instanciaPopulada.evtRetRec.ideEstab.ideFont.ideRend[i].observ);

            // infoRec
            instanciaXml.evtRetRec.ideEstab.ideFont.ideRend[i].infoRec.Should().HaveCount(instanciaPopulada.evtRetRec.ideEstab.ideFont.ideRend[i].infoRec.Count);
            for (int ii = 0; ii < instanciaXml.evtRetRec.ideEstab.ideFont.ideRend[i].infoRec.Count; ii++)
            {
                instanciaXml.evtRetRec.ideEstab.ideFont.ideRend[i].infoRec[ii].DataFatoGerador.Should().BeSameDateAs(instanciaPopulada.evtRetRec.ideEstab.ideFont.ideRend[i].infoRec[ii].DataFatoGerador);
                instanciaXml.evtRetRec.ideEstab.ideFont.ideRend[i].infoRec[ii].vlrBruto.Should().Be(instanciaPopulada.evtRetRec.ideEstab.ideFont.ideRend[i].infoRec[ii].vlrBruto);
                instanciaPopulada.evtRetRec.ideEstab.ideFont.ideRend[i].infoRec[ii].vlrBaseIR.Should().NotBeNullOrEmpty();
                instanciaXml.evtRetRec.ideEstab.ideFont.ideRend[i].infoRec[ii].vlrBaseIR.Should().Be(instanciaPopulada.evtRetRec.ideEstab.ideFont.ideRend[i].infoRec[ii].vlrBaseIR);
                instanciaPopulada.evtRetRec.ideEstab.ideFont.ideRend[i].infoRec[ii].vlrIR.Should().NotBeNullOrEmpty();
                instanciaXml.evtRetRec.ideEstab.ideFont.ideRend[i].infoRec[ii].vlrIR.Should().Be(instanciaPopulada.evtRetRec.ideEstab.ideFont.ideRend[i].infoRec[ii].vlrIR);

                // infoProcRet
                instanciaXml.evtRetRec.ideEstab.ideFont.ideRend[i].infoRec[ii].infoProcRet.Should().BeNullOrEmpty();
                instanciaPopulada.evtRetRec.ideEstab.ideFont.ideRend[i].infoRec[ii].infoProcRet.Should().BeNullOrEmpty();
            }
        }
    }

}