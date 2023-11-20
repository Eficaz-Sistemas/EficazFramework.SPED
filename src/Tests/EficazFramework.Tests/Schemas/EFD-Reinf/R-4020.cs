namespace EficazFramework.SPED.Schemas.EFD_Reinf;

public class R4020Test : BaseEfdReinfTest<R4020>
{
    private int _testNumber = 0;

    [Test]
    [TestCase(Versao.v2_01_01)]
    [TestCase(Versao.v2_01_02)]
    public void RendimentosIsentos(Versao versao)
    {
        _testNumber = 0;
        _versao = versao;
        InstanciaDesserializada = (R4020 e) => e.Versao = versao;
        ValidationSchemaNamespace = $"http://www.reinf.esocial.gov.br/schemas/evt4020PagtoBeneficiarioPJ/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v1_05_01 => throw new ArgumentException("Invalid version."),
            Versao.v2_01_01 => Resources.Schemas.EFD_Reinf.R4020_v2_01_01,
            Versao.v2_01_02 => Resources.Schemas.EFD_Reinf.R4020_v2_01_02_B,
            _ => Resources.Schemas.EFD_Reinf.R4020_v2_01_02_B
        };
        TestaEvento();
    }

    [Test]
    [TestCase(Versao.v2_01_01)]
    [TestCase(Versao.v2_01_02)]
    public void RendimentosTributados(Versao versao)
    {
        _testNumber = 1;
        _versao = versao;
        InstanciaDesserializada = (R4020 e) => e.Versao = versao;
        ValidationSchemaNamespace = $"http://www.reinf.esocial.gov.br/schemas/evt4020PagtoBeneficiarioPJ/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v1_05_01 => throw new ArgumentException("Invalid version."),
            Versao.v2_01_01 => Resources.Schemas.EFD_Reinf.R4020_v2_01_01,
            Versao.v2_01_02 => Resources.Schemas.EFD_Reinf.R4020_v2_01_02_B,
            _ => Resources.Schemas.EFD_Reinf.R4020_v2_01_02_B
        };
        TestaEvento();
    }

    [Test]
    [TestCase(Versao.v2_01_01)]
    [TestCase(Versao.v2_01_02)]
    public void RendimentosTributadosAgregados(Versao versao)
    {
        _testNumber = 2;
        _versao = versao;
        InstanciaDesserializada = (R4020 e) => e.Versao = versao;
        ValidationSchemaNamespace = $"http://www.reinf.esocial.gov.br/schemas/evt4020PagtoBeneficiarioPJ/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v1_05_01 => throw new ArgumentException("Invalid version."),
            Versao.v2_01_01 => Resources.Schemas.EFD_Reinf.R4020_v2_01_01,
            Versao.v2_01_02 => Resources.Schemas.EFD_Reinf.R4020_v2_01_02_B,
            _ => Resources.Schemas.EFD_Reinf.R4020_v2_01_02_B
        };
        TestaEvento();
    }


    // BaseEfdReinfTest overrides
    public override void PreencheCampos(R4020 evento)
    {
        evento.Versao = _versao;
        switch (_testNumber)
        {
            case 0:
                PreencheCamposRendimentoisento(evento, CnpjCpf);
                break;
            case 1:
                PreencheCamposRendimentoTributado(evento, CnpjCpf);
                break;
            case 2:
                PreencheCamposRendimentoTributadoAgregado(evento, CnpjCpf);
                break;
        }
    }

    public override void ValidaInstanciasLeituraEscrita(R4020 instanciaPopulada, R4020 instanciaXml)
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
                ValidaCamposRendimentoTributadoAgregado(instanciaPopulada, instanciaXml);
                break;
        }
    }


    // Preenchimento e validação por tipo de teste
    #region RendimentoIsento-PgAssociacoesFilantropicas
    internal static void PreencheCamposRendimentoisento(R4020 evento, string cnpjCpf)
    {
        evento.evtRetPJ = new R4020EventoRetencaoPj()
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
                nrInsc = cnpjCpf[..8] ,
            },
            ideEstab = new R4020IdentificacaoEstabelecimentoPj()
            {
                tpInscEstab = PersonalidadeJuridica.CNPJ,
                nrInscEstab = cnpjCpf,
                ideBenef = new R4020IdentificacaoBeneficiarioPj()
                {
                    // identificação do beneficiário
                    cnpjBenef = "34785515000166",
                    nmBenef = "Wayne Enterprise Inc",
                    //isenImun = TipoIsencaoPJ.InstituicaoFilantropica,
                    // pagamento (1:1, diferentemente ao apresentado em R-4010
                    idePgto = new System.Collections.Generic.List<R4020IdentificacaoPagtoPj>()
                    {
                        // identificação do pagamento
                        new R4020IdentificacaoPagtoPj()
                        {
                            // informações do pagamento
                            infoPgto = new System.Collections.Generic.List<R4020InfoPagtoPj>()
                            {
                                new R4020InfoPagtoPj()
                                {
                                    DataFatoGerador = DateTime.Now.AddMonths(-1),
                                    vlrBruto = 152725.25M.ToString("f2"),
                                    retencoes = null 
                                    // rendimento isento não possui renteção
                                },
                            },
                            // Utilizar a tabela 01, do Anexo I do Manual
                            natRend = "12001", 
                            observ = "Lucros do exercício/trimestre anterior"
                        },
                    }
                }
            }
        };
    }

    public void ValidaCamposRendimentoisento(R4020 instanciaPopulada, R4020 instanciaXml)
    {
        // ideEvento
        instanciaXml.evtRetPJ.ideEvento.indRetif.Should().Be(instanciaPopulada.evtRetPJ.ideEvento.indRetif);
        instanciaXml.evtRetPJ.ideEvento.perApur.Should().Be(instanciaPopulada.evtRetPJ.ideEvento.perApur);
        instanciaXml.evtRetPJ.ideEvento.tpAmb.Should().Be(instanciaPopulada.evtRetPJ.ideEvento.tpAmb);
        instanciaXml.evtRetPJ.ideEvento.procEmi.Should().Be(instanciaPopulada.evtRetPJ.ideEvento.procEmi);
        instanciaXml.evtRetPJ.ideEvento.verProc.Should().Be(instanciaPopulada.evtRetPJ.ideEvento.verProc);

        // ideContri
        instanciaXml.evtRetPJ.ideContri.tpInsc.Should().Be(instanciaPopulada.evtRetPJ.ideContri.tpInsc);
        instanciaXml.evtRetPJ.ideContri.nrInsc.Should().Be(instanciaPopulada.evtRetPJ.ideContri.nrInsc);

        // ideEstab         
        instanciaXml.evtRetPJ.ideEstab.tpInscEstab.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.tpInscEstab);
        instanciaXml.evtRetPJ.ideEstab.nrInscEstab.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.nrInscEstab);

        // ideBenef         
        instanciaXml.evtRetPJ.ideEstab.ideBenef.cnpjBenef.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.cnpjBenef);
        instanciaXml.evtRetPJ.ideEstab.ideBenef.nmBenef.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.nmBenef);
        instanciaXml.evtRetPJ.ideEstab.ideBenef.isenImun.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.isenImun);

        // idePgto
        instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto.Should().HaveCount(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto.Count);
        for (int i = 0; i < instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto.Count; i++)
        {
            instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].natRend.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].natRend);
            instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].observ.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].observ);

            // infoPgto
            instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto.Should().HaveCount(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto.Count);
            for (int ii = 0; ii < instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto.Count; ii++)
            {
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].DataFatoGerador.Should().BeSameDateAs(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].DataFatoGerador);
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].vlrBruto.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].vlrBruto);
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indFciScp.Should().BeNull();
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indFciScp.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indFciScp);
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].nrInscFciScp.Should().BeNull();
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].nrInscFciScp.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].nrInscFciScp);
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].percSCP.Should().BeNull();
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].percSCP.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].percSCP);
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indJud.Should().BeNull();
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indJud.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indJud);
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].paisResidExt.Should().BeNull();
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].paisResidExt.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].paisResidExt);

                // retencoes
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.Should().BeNull();
                instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.Should().BeNull();

                // infoProcRet
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoProcRet.Should().BeNullOrEmpty();
                instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoProcRet.Should().BeNullOrEmpty();

                // infoProcJud
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoProcJud.Should().BeNull();
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoProcJud.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoProcJud);

                // infoPgtoExt
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoPgtoExt.Should().BeNull();
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoPgtoExt.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoProcJud);
            }
        }
    }
    #endregion

    #region RendimentoTributado
    internal static void PreencheCamposRendimentoTributado(R4020 evento, string cnpjCpf)
    {
        evento.evtRetPJ = new R4020EventoRetencaoPj()
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
            ideEstab = new R4020IdentificacaoEstabelecimentoPj()
            {
                tpInscEstab = PersonalidadeJuridica.CNPJ,
                nrInscEstab = cnpjCpf,
                ideBenef = new R4020IdentificacaoBeneficiarioPj()
                {
                    // identificação do beneficiário
                    cnpjBenef = "34785515000166",
                    nmBenef = "Wayne Enterprise Inc",
                    isenImun = TipoIsencaoPJ.InstEduOrAssistSocial,
                    // pagamento (1:1, diferentemente ao apresentado em R-4010
                    idePgto = new System.Collections.Generic.List<R4020IdentificacaoPagtoPj>()
                {
                    // identificação do pagamento
                    new R4020IdentificacaoPagtoPj()
                    {
                        // informações do pagamento
                        infoPgto = new System.Collections.Generic.List<R4020InfoPagtoPj>()
                        {
                            new R4020InfoPagtoPj()
                            {
                                DataFatoGerador = DateTime.Now.AddMonths(-1),
                                vlrBruto = 152725.25M.ToString("f2"),
                                retencoes = new R4020InfoPagtoRetencoes()
                                {
                                    vlrBaseIR = 152725.25M.ToString("f2"),
                                    vlrIR = 2290.88M.ToString("f2"),
                                    vlrBaseCSLL = 152725.25M.ToString("f2"),
                                    vlrCSLL = 15272.53M.ToString("f2"),
                                    vlrBaseCofins = 152725.25M.ToString("f2"),
                                    vlrCofins = 4581.76M.ToString("f2"),
                                    vlrBasePP = 152725.25M.ToString("f2"),
                                    vlrPP = 992.71M.ToString("f2"),
                                }
                            },
                        },
                        // Utilizar a tabela 01, do Anexo I do Manual
                        natRend = "15010", // Remuneração de Serviços de auditoria;
                        observ = "Referente auditoria das demonstrações contábeis do exercício de 2021"
                    },
                }
                }
            }
        };
    }

    public void ValidaCamposRendimentoTributado(R4020 instanciaPopulada, R4020 instanciaXml)
    {
        // ideEvento
        instanciaXml.evtRetPJ.ideEvento.indRetif.Should().Be(instanciaPopulada.evtRetPJ.ideEvento.indRetif);
        instanciaXml.evtRetPJ.ideEvento.perApur.Should().Be(instanciaPopulada.evtRetPJ.ideEvento.perApur);
        instanciaXml.evtRetPJ.ideEvento.tpAmb.Should().Be(instanciaPopulada.evtRetPJ.ideEvento.tpAmb);
        instanciaXml.evtRetPJ.ideEvento.procEmi.Should().Be(instanciaPopulada.evtRetPJ.ideEvento.procEmi);
        instanciaXml.evtRetPJ.ideEvento.verProc.Should().Be(instanciaPopulada.evtRetPJ.ideEvento.verProc);

        // ideContri
        instanciaXml.evtRetPJ.ideContri.tpInsc.Should().Be(instanciaPopulada.evtRetPJ.ideContri.tpInsc);
        instanciaXml.evtRetPJ.ideContri.nrInsc.Should().Be(instanciaPopulada.evtRetPJ.ideContri.nrInsc);

        // ideEstab         
        instanciaXml.evtRetPJ.ideEstab.tpInscEstab.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.tpInscEstab);
        instanciaXml.evtRetPJ.ideEstab.nrInscEstab.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.nrInscEstab);

        // ideBenef         
        instanciaXml.evtRetPJ.ideEstab.ideBenef.cnpjBenef.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.cnpjBenef);
        instanciaXml.evtRetPJ.ideEstab.ideBenef.nmBenef.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.nmBenef);
        instanciaXml.evtRetPJ.ideEstab.ideBenef.isenImun.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.isenImun);

        // idePgto
        instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto.Should().HaveCount(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto.Count);
        for (int i = 0; i < instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto.Count; i++)
        {
            instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].natRend.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].natRend);
            instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].observ.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].observ);

            // infoPgto
            instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto.Should().HaveCount(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto.Count);
            for (int ii = 0; ii < instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto.Count; ii++)
            {
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].DataFatoGerador.Should().BeSameDateAs(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].DataFatoGerador);
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].vlrBruto.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].vlrBruto);
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indFciScp.Should().BeNull();
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indFciScp.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indFciScp);
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].nrInscFciScp.Should().BeNull();
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].nrInscFciScp.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].nrInscFciScp);
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].percSCP.Should().BeNull();
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].percSCP.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].percSCP);
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indJud.Should().BeNull();
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indJud.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indJud);
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].paisResidExt.Should().BeNull();
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].paisResidExt.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].paisResidExt);

                // retencoes
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.Should().NotBeNull();
                instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.Should().NotBeNull();
                // // vlrBaseIR
                instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrBaseIR.Should().NotBeNullOrEmpty();
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrBaseIR.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrBaseIR);
                // // vlrIR
                instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrIR.Should().NotBeNullOrEmpty();
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrIR.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrIR);
                // // vlrBaseAgreg
                instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrBaseAgreg.Should().BeNullOrEmpty();
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrBaseAgreg.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrBaseAgreg);
                // // vlrAgreg
                instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrAgreg.Should().BeNullOrEmpty();
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrAgreg.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrAgreg);
                // // vlrBaseCSLL
                instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrBaseCSLL.Should().NotBeNullOrEmpty();
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrBaseCSLL.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrBaseCSLL);
                // // vlrCSLL
                instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrCSLL.Should().NotBeNullOrEmpty();
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrCSLL.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrCSLL);
                // // vlrBaseCofins
                instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrBaseCofins.Should().NotBeNullOrEmpty();
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrBaseCofins.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrBaseCofins);
                // // vlrCofins
                instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrCofins.Should().NotBeNullOrEmpty();
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrCofins.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrCofins);
                // // vlrBasePP
                instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrBasePP.Should().NotBeNullOrEmpty();
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrBasePP.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrBasePP);
                // // vlrPP
                instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrPP.Should().NotBeNullOrEmpty();
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrPP.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrPP);

                // infoProcRet
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoProcRet.Should().BeNullOrEmpty();
                instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoProcRet.Should().BeNullOrEmpty();

                // infoProcJud
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoProcJud.Should().BeNull();
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoProcJud.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoProcJud);

                // infoPgtoExt
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoPgtoExt.Should().BeNull();
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoPgtoExt.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoPgtoExt);
            }
        }
    }
    #endregion

    #region RendimentoTributadoAgregado
    internal static void PreencheCamposRendimentoTributadoAgregado(R4020 evento, string cnpjCpf)
    {
        evento.evtRetPJ = new R4020EventoRetencaoPj()
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
            ideEstab = new R4020IdentificacaoEstabelecimentoPj()
            {
                tpInscEstab = PersonalidadeJuridica.CNPJ,
                nrInscEstab = cnpjCpf,
                ideBenef = new R4020IdentificacaoBeneficiarioPj()
                {
                    // identificação do beneficiário
                    cnpjBenef = "34785515000166",
                    nmBenef = "Wayne Enterprise Inc",
                    isenImun = TipoIsencaoPJ.InstEduOrAssistSocial,
                    // pagamento (1:1, diferentemente ao apresentado em R-4010
                    idePgto = new System.Collections.Generic.List<R4020IdentificacaoPagtoPj>()
                {
                    // identificação do pagamento
                    new R4020IdentificacaoPagtoPj()
                    {
                        // informações do pagamento
                        infoPgto = new System.Collections.Generic.List<R4020InfoPagtoPj>()
                        {
                            new R4020InfoPagtoPj()
                            {
                                DataFatoGerador = DateTime.Now.AddMonths(-1),
                                vlrBruto = 152725.25M.ToString("f2"),
                                retencoes = new R4020InfoPagtoRetencoes()
                                {
                                    vlrBaseIR = 152725.25M.ToString("f2"),
                                    vlrIR = 2290.88M.ToString("f2"),
                                    vlrBaseAgreg = 152725.25M.ToString("f2"),
                                    vlrAgreg = 7101.72M.ToString("f2")
                                }
                            },
                        },
                        // Utilizar a tabela 01, do Anexo I do Manual
                        natRend = "15010", // Remuneração de Serviços de auditoria;
                        observ = "Referente auditoria das demonstrações contábeis do exercício de 2021"
                    },
                }
                }
            }
        };
    }

    public void ValidaCamposRendimentoTributadoAgregado(R4020 instanciaPopulada, R4020 instanciaXml)
    {
        // ideEvento
        instanciaXml.evtRetPJ.ideEvento.indRetif.Should().Be(instanciaPopulada.evtRetPJ.ideEvento.indRetif);
        instanciaXml.evtRetPJ.ideEvento.perApur.Should().Be(instanciaPopulada.evtRetPJ.ideEvento.perApur);
        instanciaXml.evtRetPJ.ideEvento.tpAmb.Should().Be(instanciaPopulada.evtRetPJ.ideEvento.tpAmb);
        instanciaXml.evtRetPJ.ideEvento.procEmi.Should().Be(instanciaPopulada.evtRetPJ.ideEvento.procEmi);
        instanciaXml.evtRetPJ.ideEvento.verProc.Should().Be(instanciaPopulada.evtRetPJ.ideEvento.verProc);

        // ideContri
        instanciaXml.evtRetPJ.ideContri.tpInsc.Should().Be(instanciaPopulada.evtRetPJ.ideContri.tpInsc);
        instanciaXml.evtRetPJ.ideContri.nrInsc.Should().Be(instanciaPopulada.evtRetPJ.ideContri.nrInsc);

        // ideEstab         
        instanciaXml.evtRetPJ.ideEstab.tpInscEstab.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.tpInscEstab);
        instanciaXml.evtRetPJ.ideEstab.nrInscEstab.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.nrInscEstab);

        // ideBenef         
        instanciaXml.evtRetPJ.ideEstab.ideBenef.cnpjBenef.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.cnpjBenef);
        instanciaXml.evtRetPJ.ideEstab.ideBenef.nmBenef.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.nmBenef);
        instanciaXml.evtRetPJ.ideEstab.ideBenef.isenImun.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.isenImun);

        // idePgto
        instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto.Should().HaveCount(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto.Count);
        for (int i = 0; i < instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto.Count; i++)
        {
            instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].natRend.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].natRend);
            instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].observ.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].observ);

            // infoPgto
            instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto.Should().HaveCount(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto.Count);
            for (int ii = 0; ii < instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto.Count; ii++)
            {
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].DataFatoGerador.Should().BeSameDateAs(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].DataFatoGerador);
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].vlrBruto.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].vlrBruto);
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indFciScp.Should().BeNull();
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indFciScp.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indFciScp);
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].nrInscFciScp.Should().BeNull();
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].nrInscFciScp.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].nrInscFciScp);
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].percSCP.Should().BeNull();
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].percSCP.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].percSCP);
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indJud.Should().BeNull();
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indJud.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].indJud);
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].paisResidExt.Should().BeNull();
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].paisResidExt.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].paisResidExt);

                // retencoes
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.Should().NotBeNull();
                instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.Should().NotBeNull();
                // // vlrBaseIR
                instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrBaseIR.Should().NotBeNullOrEmpty();
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrBaseIR.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrBaseIR);
                // // vlrIR
                instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrIR.Should().NotBeNullOrEmpty();
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrIR.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrIR);
                // // vlrBaseAgreg
                instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrBaseAgreg.Should().NotBeNullOrEmpty();
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrBaseAgreg.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrBaseAgreg);
                // // vlrAgreg
                instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrAgreg.Should().NotBeNullOrEmpty();
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrAgreg.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrAgreg);
                // // vlrBaseCSLL
                instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrBaseCSLL.Should().BeNullOrEmpty();
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrBaseCSLL.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrBaseCSLL);
                // // vlrCSLL
                instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrCSLL.Should().BeNullOrEmpty();
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrCSLL.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrCSLL);
                // // vlrBaseCofins
                instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrBaseCofins.Should().BeNullOrEmpty();
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrBaseCofins.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrBaseCofins);
                // // vlrCofins
                instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrCofins.Should().BeNullOrEmpty();
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrCofins.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrCofins);
                // // vlrBasePP
                instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrBasePP.Should().BeNullOrEmpty();
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrBasePP.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrBasePP);
                // // vlrPP
                instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrPP.Should().BeNullOrEmpty();
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrPP.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].retencoes.vlrPP);

                // infoProcRet
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoProcRet.Should().BeNullOrEmpty();
                instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoProcRet.Should().BeNullOrEmpty();

                // infoProcJud
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoProcJud.Should().BeNull();
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoProcJud.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoProcJud);

                // infoPgtoExt
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoPgtoExt.Should().BeNull();
                instanciaXml.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoPgtoExt.Should().Be(instanciaPopulada.evtRetPJ.ideEstab.ideBenef.idePgto[i].infoPgto[ii].infoPgtoExt);
            }
        }
    }
    #endregion

}