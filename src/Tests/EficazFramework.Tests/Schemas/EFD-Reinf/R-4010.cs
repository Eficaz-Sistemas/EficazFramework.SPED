namespace EficazFramework.SPED.Schemas.EFD_Reinf;

public class R4010Test : BaseEfdReinfTest<R4010>
{
    private int _testNumber = 0;

    [Test]
    [TestCase(Versao.v2_01_01)]
    [TestCase(Versao.v2_01_02)]
    public void ValidaRendimentosIsentos(Versao versao)
    {
        _testNumber = 0;
        _versao = versao;
        InstanciaDesserializada = (R4010 e) => e.Versao = versao;
        ValidationSchemaNamespace = $"http://www.reinf.esocial.gov.br/schemas/evt4010PagtoBeneficiarioPF/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v1_05_01 => throw new ArgumentException("Invalid version."),
            Versao.v2_01_01 => Resources.Schemas.EFD_Reinf.R4010_v2_01_01,
            Versao.v2_01_02 => Resources.Schemas.EFD_Reinf.R4010_v2_01_02_B,
            _ => Resources.Schemas.EFD_Reinf.R4010_v2_01_02_B
        };
        TestaEvento();
    }

    [Test]
    [TestCase(Versao.v2_01_01)]
    [TestCase(Versao.v2_01_02)]
    public void ValidaRendimentosTributados(Versao versao)
    {
        _testNumber = 1;
        _versao = versao;
        InstanciaDesserializada = (R4010 e) => e.Versao = versao;
        ValidationSchemaNamespace = $"http://www.reinf.esocial.gov.br/schemas/evt4010PagtoBeneficiarioPF/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v1_05_01 => throw new ArgumentException("Invalid version."),
            Versao.v2_01_01 => Resources.Schemas.EFD_Reinf.R4010_v2_01_01,
            Versao.v2_01_02 => Resources.Schemas.EFD_Reinf.R4010_v2_01_02_B,
            _ => Resources.Schemas.EFD_Reinf.R4010_v2_01_02_B
        };
        TestaEvento();
    }

    [Test]
    [TestCase(Versao.v2_01_01)]
    [TestCase(Versao.v2_01_02)]
    public void ValidaRendimentosTributadosComDependente(Versao versao)
    {
        _testNumber = 2;
        _versao = versao;
        InstanciaDesserializada = (R4010 e) => e.Versao = versao;
        ValidationSchemaNamespace = $"http://www.reinf.esocial.gov.br/schemas/evt4010PagtoBeneficiarioPF/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v1_05_01 => throw new ArgumentException("Invalid version."),
            Versao.v2_01_01 => Resources.Schemas.EFD_Reinf.R4010_v2_01_01,
            Versao.v2_01_02 => Resources.Schemas.EFD_Reinf.R4010_v2_01_02_B,
            _ => Resources.Schemas.EFD_Reinf.R4010_v2_01_02_B
        };
        TestaEvento();
    }


    // BaseEfdReinfTest overrides
    public override void PreencheCampos(R4010 evento)
    {
        evento.Versao = _versao;
        switch (_testNumber)
        {
            case 0:
                PreencheCamposRendimentoisento(evento);
                break;
            case 1:
                PreencheCamposRendimentoTributado(evento);
                break;
            case 2:
                PreencheCamposRendimentoTributadoComDependente(evento);
                break;
        }
    }

    public override void ValidaInstanciasLeituraEscrita(R4010 instanciaPopulada, R4010 instanciaXml)
    {
        // TODO: verifique se os campos de instanciaXml, preenchidos a partir da leitura de um XmlDocument, 
        //       correspondem exatamente aos valores de instanciaPopulada, formado à partir do método
        //       PreencheCampos().
        switch (_testNumber)
        {
            case 0:
                ValidaCamposRendimentoisento(instanciaPopulada, instanciaXml);
                break;
            case 1:
                ValidaCamposRendimentoTributado(instanciaPopulada, instanciaXml);
                break;
            case 2:
                ValidaCamposRendimentoTributadoComDependente(instanciaPopulada, instanciaXml);
                break;
        }
    }


    // Preenchimento e validação por tipo de teste
    #region RendimentoIsento-LucrosDistribuidos
    internal static void PreencheCamposRendimentoisento(R4010 evento)
    {
        evento.evtRetPF = new R4010EventoRetencaoPf()
        {
            ideEvento = new IdentificacaoEventoPeriodico()
            {
                indRetif = IndicadorRetificacao.Original,
                perApur = "2022-08",
                tpAmb = Ambiente.ProducaoRestrita_DadosReais,
                procEmi = EmissorEvento.AppContribuinte,
                verProc = "6.0"
            },
            ideContri = new IdentificacaoContribuinte()
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = "34785515000166",
            },
            ideEstab = new R4010IdentificacaoEstabelecimentoPf()
            {
                tpInscEstab = PersonalidadeJuridica.CNPJ,
                nrInscEstab = "34785515000166",
                ideBenef = new R4010IdentificacaoBeneficiarioPf()
                {
                    // identificação do beneficiário
                    cpfBenef = "47363361886",
                    nmBenef = "Pierre de Fermat",
                    // listagem de pagamentos
                    idePgto = new System.Collections.Generic.List<R4010IdentificacaoPagtoPf>()
                {
                    // identificação do pagamento
                    new R4010IdentificacaoPagtoPf()
                    {
                        // informações do pagamento
                        infoPgto = new System.Collections.Generic.List<R4010InfoPagtoPf>()
                        {
                            new R4010InfoPagtoPf()
                            {
                                DataFatoGerador = System.DateTime.Now,
                                vlrRendBruto = 152725.25M.ToString("f2"),
                                // desmembramento da parte isenta dos rendimentos (que neste caso é todo isento)
                                rendIsento = new System.Collections.Generic.List<ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoRendIsento>()
                                {
                                    new ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoRendIsento()
                                    {
                                        tpIsencao = evento.Versao >= Versao.v2_01_02 ? TipoIsencaoPF.Outros : TipoIsencaoPF.RendimentoSemIRRF,
                                        vlrIsento = 152725.25M.ToString("f2"),
                                        descRendimento = "Lucros do exercício de 2021"
                                    }
                                }

                            },
                        },
                        // Utilizar a tabela 01, do Anexo I do Manual
                        natRend = "12001", // Lucro e dividendo
                        observ = "Lucros do exercício de 2021"
                    },
                }
                }
            }
        };
    }

    public void ValidaCamposRendimentoisento(R4010 instanciaPopulada, R4010 instanciaXml)
    {
        // ideEvento
        instanciaXml.evtRetPF.ideEvento.indRetif.Should().Be(instanciaPopulada.evtRetPF.ideEvento.indRetif);
        instanciaXml.evtRetPF.ideEvento.perApur.Should().Be(instanciaPopulada.evtRetPF.ideEvento.perApur);
        instanciaXml.evtRetPF.ideEvento.tpAmb.Should().Be(instanciaPopulada.evtRetPF.ideEvento.tpAmb);
        instanciaXml.evtRetPF.ideEvento.procEmi.Should().Be(instanciaPopulada.evtRetPF.ideEvento.procEmi);
        instanciaXml.evtRetPF.ideEvento.verProc.Should().Be(instanciaPopulada.evtRetPF.ideEvento.verProc);

        // ideContri
        instanciaXml.evtRetPF.ideContri.tpInsc.Should().Be(instanciaPopulada.evtRetPF.ideContri.tpInsc);
        instanciaXml.evtRetPF.ideContri.nrInsc.Should().Be(instanciaPopulada.evtRetPF.ideContri.nrInsc);

        // ideEstab
        instanciaXml.evtRetPF.ideEstab.tpInscEstab.Should().Be(instanciaPopulada.evtRetPF.ideEstab.tpInscEstab);
        instanciaXml.evtRetPF.ideEstab.nrInscEstab.Should().Be(instanciaPopulada.evtRetPF.ideEstab.nrInscEstab);

        // ideBenef
        instanciaXml.evtRetPF.ideEstab.ideBenef.cpfBenef.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.cpfBenef);
        instanciaXml.evtRetPF.ideEstab.ideBenef.nmBenef.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.nmBenef);
        instanciaXml.evtRetPF.ideEstab.ideBenef.ideOpSaude.Should().BeNullOrEmpty();
        instanciaPopulada.evtRetPF.ideEstab.ideBenef.ideOpSaude.Should().BeNullOrEmpty();

        // ideDep
        instanciaXml.evtRetPF.ideEstab.ideBenef.ideDep.Should().BeNullOrEmpty();
        instanciaPopulada.evtRetPF.ideEstab.ideBenef.ideDep.Should().BeNullOrEmpty();

        // idePgto
        instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto.Should().HaveCount(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto.Count);
        for (int i = 0; i < instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto.Count; i++)
        {
            instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].natRend.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].natRend);
            instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].observ.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].observ);

            // infoPgto
            instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto.Should().HaveCount(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto.Count);
            for (int ii = 0; ii < instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto.Count; ii++)
            {
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].DataFatoGerador.Should().BeSameDateAs(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].DataFatoGerador);
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].compFP.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].compFP);
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indDecTerc.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indDecTerc);
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].vlrRendBruto.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].vlrRendBruto);
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].vlrRendTrib.Should().BeNull();
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].vlrRendTrib.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].vlrRendTrib);
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].vlrIR.Should().BeNull();
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].vlrIR.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].vlrIR);
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indRRA.Should().BeNull();
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indRRA.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indRRA);
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indFciScp.Should().BeNull();
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indFciScp.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indFciScp);
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].nrInscFciScp.Should().BeNull();
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].nrInscFciScp.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].nrInscFciScp);
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].percSCP.Should().BeNull();
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].percSCP.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].percSCP);
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indJud.Should().BeNull();
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indJud.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indJud);
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].paisResidExt.Should().BeNull();
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].paisResidExt.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].paisResidExt);

                // detDed
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].detDed.Should().BeNullOrEmpty();
                instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].detDed.Should().BeNullOrEmpty();

                // infoProcRet
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoProcRet.Should().BeNullOrEmpty();
                instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoProcRet.Should().BeNullOrEmpty();

                // infoRRA
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoRRA.Should().BeNull();
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoRRA.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoRRA);

                // infoRRA
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoProcJud.Should().BeNull();
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoProcJud.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoProcJud);

                // infoPgtoExt
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoPgtoExt.Should().BeNull();
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoPgtoExt.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoPgtoExt);

                // rendIsento
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].rendIsento.Should().HaveCount(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].rendIsento.Count);
                for (int iii = 0; iii < instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].rendIsento.Count; iii++)
                {
                    instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].rendIsento[iii].tpIsencao.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].rendIsento[iii].tpIsencao);
                    instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].rendIsento[iii].vlrIsento.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].rendIsento[iii].vlrIsento);
                    instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].rendIsento[iii].descRendimento.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].rendIsento[iii].descRendimento);
                    instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].rendIsento[iii].dtLaudo.Should().BeNull();
                    instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].rendIsento[iii].dtLaudo.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].rendIsento[iii].dtLaudo);
                }
            }
        }
    }
    #endregion

    #region RendimentoTributado
    internal static void PreencheCamposRendimentoTributado(R4010 evento)
    {
        evento.evtRetPF = new R4010EventoRetencaoPf()
        {
            ideEvento = new IdentificacaoEventoPeriodico()
            {
                indRetif = IndicadorRetificacao.Original,
                perApur = "2022-08",
                tpAmb = Ambiente.ProducaoRestrita_DadosReais,
                procEmi = EmissorEvento.AppContribuinte,
                verProc = "6.0"
            },
            ideContri = new IdentificacaoContribuinte()
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = "34785515000166",
            },
            ideEstab = new R4010IdentificacaoEstabelecimentoPf()
            {
                tpInscEstab = PersonalidadeJuridica.CNPJ,
                nrInscEstab = "34785515000166",
                ideBenef = new R4010IdentificacaoBeneficiarioPf()
                {
                    // identificação do beneficiário
                    cpfBenef = "47363361886",
                    nmBenef = "Pierre de Fermat",
                    // listagem de pagamentos
                    idePgto = new System.Collections.Generic.List<R4010IdentificacaoPagtoPf>()
                {
                    // identificação do pagamento
                    new R4010IdentificacaoPagtoPf()
                    {
                        // informações do pagamento
                        infoPgto = new System.Collections.Generic.List<R4010InfoPagtoPf>()
                        {
                            new R4010InfoPagtoPf()
                            {
                                DataFatoGerador = System.DateTime.Now,
                                vlrRendBruto = 750.ToString("f2"),
                                vlrRendTrib = 750.ToString("f2"),
                                vlrIR = 112.5.ToString("f2"),
                            },
                        },
                        // Utilizar a tabela 01, do Anexo I do Manual
                        natRend = "10001", // Lucro e dividendo
                        observ = "Algum rendimento sem vínculo empregatício" // na verdade, não imagino que exista esta possibilidade
                    },
                }
                }
            }
        };
    }

    public void ValidaCamposRendimentoTributado(R4010 instanciaPopulada, R4010 instanciaXml)
    {
        // ideEvento
        instanciaXml.evtRetPF.ideEvento.indRetif.Should().Be(instanciaPopulada.evtRetPF.ideEvento.indRetif);
        instanciaXml.evtRetPF.ideEvento.perApur.Should().Be(instanciaPopulada.evtRetPF.ideEvento.perApur);
        instanciaXml.evtRetPF.ideEvento.tpAmb.Should().Be(instanciaPopulada.evtRetPF.ideEvento.tpAmb);
        instanciaXml.evtRetPF.ideEvento.procEmi.Should().Be(instanciaPopulada.evtRetPF.ideEvento.procEmi);
        instanciaXml.evtRetPF.ideEvento.verProc.Should().Be(instanciaPopulada.evtRetPF.ideEvento.verProc);

        // ideContri
        instanciaXml.evtRetPF.ideContri.tpInsc.Should().Be(instanciaPopulada.evtRetPF.ideContri.tpInsc);
        instanciaXml.evtRetPF.ideContri.nrInsc.Should().Be(instanciaPopulada.evtRetPF.ideContri.nrInsc);

        // ideEstab
        instanciaXml.evtRetPF.ideEstab.tpInscEstab.Should().Be(instanciaPopulada.evtRetPF.ideEstab.tpInscEstab);
        instanciaXml.evtRetPF.ideEstab.nrInscEstab.Should().Be(instanciaPopulada.evtRetPF.ideEstab.nrInscEstab);

        // ideBenef
        instanciaXml.evtRetPF.ideEstab.ideBenef.cpfBenef.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.cpfBenef);
        instanciaXml.evtRetPF.ideEstab.ideBenef.nmBenef.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.nmBenef);
        instanciaXml.evtRetPF.ideEstab.ideBenef.ideOpSaude.Should().BeNullOrEmpty();
        instanciaPopulada.evtRetPF.ideEstab.ideBenef.ideOpSaude.Should().BeNullOrEmpty();

        // ideDep
        instanciaXml.evtRetPF.ideEstab.ideBenef.ideDep.Should().BeNullOrEmpty();
        instanciaPopulada.evtRetPF.ideEstab.ideBenef.ideDep.Should().BeNullOrEmpty();

        // idePgto
        instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto.Should().HaveCount(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto.Count);
        for (int i = 0; i < instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto.Count; i++)
        {
            instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].natRend.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].natRend);
            instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].observ.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].observ);

            // infoPgto
            instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto.Should().HaveCount(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto.Count);
            for (int ii = 0; ii < instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto.Count; ii++)
            {
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].DataFatoGerador.Should().BeSameDateAs(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].DataFatoGerador);
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].compFP.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].compFP);
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indDecTerc.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indDecTerc);
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].vlrRendBruto.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].vlrRendBruto);
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].vlrRendTrib.Should().NotBeNull();
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].vlrRendTrib.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].vlrRendTrib);
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].vlrIR.Should().NotBeNull();
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].vlrIR.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].vlrIR);
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indRRA.Should().BeNull();
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indRRA.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indRRA);
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indFciScp.Should().BeNull();
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indFciScp.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indFciScp);
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].nrInscFciScp.Should().BeNull();
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].nrInscFciScp.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].nrInscFciScp);
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].percSCP.Should().BeNull();
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].percSCP.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].percSCP);
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indJud.Should().BeNull();
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indJud.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indJud);
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].paisResidExt.Should().BeNull();
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].paisResidExt.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].paisResidExt);

                // detDed
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].detDed.Should().BeNullOrEmpty();
                instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].detDed.Should().BeNullOrEmpty();

                // infoProcRet
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoProcRet.Should().BeNullOrEmpty();
                instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoProcRet.Should().BeNullOrEmpty();

                // infoRRA
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoRRA.Should().BeNull();
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoRRA.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoRRA);

                // infoRRA
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoProcJud.Should().BeNull();
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoProcJud.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoProcJud);

                // infoPgtoExt
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoPgtoExt.Should().BeNull();
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoPgtoExt.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoPgtoExt);

                // rendIsento
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].rendIsento.Should().BeNullOrEmpty();
                instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].rendIsento.Should().BeNullOrEmpty();
            }
        }
    }
    #endregion

    #region RendimentoTributadoComDependente
    internal static void PreencheCamposRendimentoTributadoComDependente(R4010 evento)
    {
        evento.evtRetPF = new R4010EventoRetencaoPf()
        {
            ideEvento = new IdentificacaoEventoPeriodico()
            {
                indRetif = IndicadorRetificacao.Original,
                perApur = "2022-08",
                tpAmb = Ambiente.ProducaoRestrita_DadosReais,
                procEmi = EmissorEvento.AppContribuinte,
                verProc = "6.0"
            },
            ideContri = new IdentificacaoContribuinte()
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = "34785515000166",
            },
            ideEstab = new R4010IdentificacaoEstabelecimentoPf()
            {
                tpInscEstab = PersonalidadeJuridica.CNPJ,
                nrInscEstab = "34785515000166",
                ideBenef = new R4010IdentificacaoBeneficiarioPf()
                {
                    // identificação do beneficiário
                    cpfBenef = "47363361886",
                    nmBenef = "Pierre de Fermat",
                    // listagem de dependentes (neste teste apenas para dedução de IRRF)
                    ideDep = new System.Collections.Generic.List<R4010IdentificacaoDependente>()
                {
                    new R4010IdentificacaoDependente()
                    {
                        cpfDep = "36580385006",
                        relDep = RelacaoDependencia.FilhoOuEnteado
                    }
                },
                    // listagem de pagamentos
                    idePgto = new System.Collections.Generic.List<R4010IdentificacaoPagtoPf>()
                {
                    // identificação do pagamento
                    new R4010IdentificacaoPagtoPf()
                    {
                        // informações do pagamento
                        infoPgto = new System.Collections.Generic.List<R4010InfoPagtoPf>()
                        {
                            new R4010InfoPagtoPf()
                            {
                                DataFatoGerador = System.DateTime.Now,
                                vlrRendBruto = 750.ToString("f2"),
                                vlrRendTrib = 750.ToString("f2"),
                                vlrIR = 112.5.ToString("f2"),
                                detDed = new System.Collections.Generic.List<ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoDetDed>()
                                {
                                    new ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoDetDed()
                                    {
                                        indTpDeducao = IndicadorTipoDeducaoPrevidenciaria.Dependentes,
                                        vlrDeducao = 33.75.ToString("f2")
                                    }
                                }
                            },
                        },
                        // Utilizar a tabela 01, do Anexo I do Manual
                        natRend = "10001", // Lucro e dividendo
                        observ = "Algum rendimento sem vínculo empregatício" // na verdade, não imagino que exista esta possibilidade
                    },
                }
                }
            }
        };
    }

    public void ValidaCamposRendimentoTributadoComDependente(R4010 instanciaPopulada, R4010 instanciaXml)
    {
        // ideEvento
        instanciaXml.evtRetPF.ideEvento.indRetif.Should().Be(instanciaPopulada.evtRetPF.ideEvento.indRetif);
        instanciaXml.evtRetPF.ideEvento.perApur.Should().Be(instanciaPopulada.evtRetPF.ideEvento.perApur);
        instanciaXml.evtRetPF.ideEvento.tpAmb.Should().Be(instanciaPopulada.evtRetPF.ideEvento.tpAmb);
        instanciaXml.evtRetPF.ideEvento.procEmi.Should().Be(instanciaPopulada.evtRetPF.ideEvento.procEmi);
        instanciaXml.evtRetPF.ideEvento.verProc.Should().Be(instanciaPopulada.evtRetPF.ideEvento.verProc);

        // ideContri
        instanciaXml.evtRetPF.ideContri.tpInsc.Should().Be(instanciaPopulada.evtRetPF.ideContri.tpInsc);
        instanciaXml.evtRetPF.ideContri.nrInsc.Should().Be(instanciaPopulada.evtRetPF.ideContri.nrInsc);

        // ideEstab
        instanciaXml.evtRetPF.ideEstab.tpInscEstab.Should().Be(instanciaPopulada.evtRetPF.ideEstab.tpInscEstab);
        instanciaXml.evtRetPF.ideEstab.nrInscEstab.Should().Be(instanciaPopulada.evtRetPF.ideEstab.nrInscEstab);

        // ideBenef
        instanciaXml.evtRetPF.ideEstab.ideBenef.cpfBenef.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.cpfBenef);
        instanciaXml.evtRetPF.ideEstab.ideBenef.nmBenef.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.nmBenef);
        instanciaXml.evtRetPF.ideEstab.ideBenef.ideOpSaude.Should().BeNullOrEmpty();
        instanciaPopulada.evtRetPF.ideEstab.ideBenef.ideOpSaude.Should().BeNullOrEmpty();

        // ideDep
        instanciaXml.evtRetPF.ideEstab.ideBenef.ideDep.Should().HaveCount(instanciaPopulada.evtRetPF.ideEstab.ideBenef.ideDep.Count);
        for (int i = 0; i < instanciaXml.evtRetPF.ideEstab.ideBenef.ideDep.Count; i++)
        {
            instanciaXml.evtRetPF.ideEstab.ideBenef.ideDep[i].cpfDep.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.ideDep[i].cpfDep);
            instanciaXml.evtRetPF.ideEstab.ideBenef.ideDep[i].relDep.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.ideDep[i].relDep);

        }

        // idePgto
        instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto.Should().HaveCount(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto.Count);
        for (int i = 0; i < instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto.Count; i++)
        {
            instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].natRend.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].natRend);
            instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].observ.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].observ);

            // infoPgto
            instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto.Should().HaveCount(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto.Count);
            for (int ii = 0; ii < instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto.Count; ii++)
            {
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].DataFatoGerador.Should().BeSameDateAs(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].DataFatoGerador);
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].compFP.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].compFP);
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indDecTerc.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indDecTerc);
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].vlrRendBruto.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].vlrRendBruto);
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].vlrRendTrib.Should().NotBeNull();
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].vlrRendTrib.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].vlrRendTrib);
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].vlrIR.Should().NotBeNull();
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].vlrIR.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].vlrIR);
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indRRA.Should().BeNull();
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indRRA.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indRRA);
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indFciScp.Should().BeNull();
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indFciScp.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indFciScp);
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].nrInscFciScp.Should().BeNull();
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].nrInscFciScp.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].nrInscFciScp);
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].percSCP.Should().BeNull();
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].percSCP.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].percSCP);
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indJud.Should().BeNull();
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indJud.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indJud);
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].paisResidExt.Should().BeNull();
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].paisResidExt.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].paisResidExt);

                // detDed
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].detDed.Should().HaveCount(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].detDed.Count);
                for (int iii = 0; iii < instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].detDed.Count; iii++)
                {
                    instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].detDed[iii].indTpDeducao.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].detDed[iii].indTpDeducao);
                    instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].detDed[iii].vlrDeducao.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].detDed[iii].vlrDeducao);
                    instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].detDed[iii].infoEntid.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].detDed[iii].infoEntid);
                    instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].detDed[iii].nrInscPrevComp.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].detDed[iii].nrInscPrevComp);
                    instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].detDed[iii].vlrPatrocFunp.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].detDed[iii].vlrPatrocFunp);
                }


                // infoProcRet
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoProcRet.Should().BeNullOrEmpty();
                instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoProcRet.Should().BeNullOrEmpty();

                // infoRRA
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoRRA.Should().BeNull();
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoRRA.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoRRA);

                // infoRRA
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoProcJud.Should().BeNull();
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoProcJud.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoProcJud);

                // infoPgtoExt
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoPgtoExt.Should().BeNull();
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoPgtoExt.Should().Be(instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoPgtoExt);

                // rendIsento
                instanciaXml.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].rendIsento.Should().BeNullOrEmpty();
                instanciaPopulada.evtRetPF.ideEstab.ideBenef.idePgto[i].infoPgto[ii].rendIsento.Should().BeNullOrEmpty();
            }
        }
    }
    #endregion

}