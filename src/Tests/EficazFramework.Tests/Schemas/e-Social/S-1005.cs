namespace EficazFramework.SPED.Schemas.eSocial;

public class S1005Test : BaseESocialTest<S1005>
{
    private int _testNumber = 0;

    [Test]
    [TestCase(Versao.v_S_01_02_00)]
    public void ValidaInclusao(Versao versao)
    {
        _testNumber = 0;
        _versao = versao;
        InstanciaDesserializada = (S1005 e) => e.Versao = versao;
        ValidationSchemaNamespace = $"http://www.esocial.gov.br/schema/evt/evtTabEstab/{versao}";
        ValidationSchema = versao switch
        {
            _ => Resources.Schemas.eSocial.S1005_v_S_01_02_00
        };
        TestaEvento();
    }


    [Test]
    [TestCase(Versao.v_S_01_02_00)]
    public void ValidaAlteracao(Versao versao)
    {
        _testNumber = 1;
        _versao = versao;
        InstanciaDesserializada = (S1005 e) => e.Versao = versao;
        ValidationSchemaNamespace = $"http://www.esocial.gov.br/schema/evt/evtTabEstab/{versao}";
        ValidationSchema = versao switch
        {
            _ => Resources.Schemas.eSocial.S1005_v_S_01_02_00
        };
        TestaEvento();
    }


    [Test]
    [TestCase(Versao.v_S_01_02_00)]
    public void ValidaExclusao(Versao versao)
    {
        _testNumber = 2;
        _versao = versao;
        InstanciaDesserializada = (S1005 e) => e.Versao = versao;
        ValidationSchemaNamespace = $"http://www.esocial.gov.br/schema/evt/evtTabEstab/{versao}";
        ValidationSchema = versao switch
        {
            _ => Resources.Schemas.eSocial.S1005_v_S_01_02_00
        };
        TestaEvento();
    }


    // BaseESocialTest overrides
    public override void PreencheCampos(S1005 evento)
    {
        evento.Versao = _versao;
        switch (_testNumber)
        {
            case 0:
                PreencheCamposInclusao(evento, CnpjCpf);
                break;
            case 1:
                PreencheCamposAlteracao(evento, CnpjCpf);
                break;
            case 2:
                PreencheCamposExclusao(evento, CnpjCpf);
                break;
        }
    }

    public override void ValidaInstanciasLeituraEscrita(S1005 instanciaPopulada, S1005 instanciaXml)
    {
        // TODO: verifique se os campos de instanciaXml, preenchidos a partir da leitura de um XmlDocument, 
        //       correspondem exatamente aos valores de instanciaPopulada, formado à partir do método
        //       PreencheCampos().


        // ideEvento
        instanciaXml.evtTabEstab.ideEvento.tpAmb.Should().Be(instanciaPopulada.evtTabEstab.ideEvento.tpAmb);
        instanciaXml.evtTabEstab.ideEvento.procEmi.Should().Be(instanciaPopulada.evtTabEstab.ideEvento.procEmi);
        instanciaXml.evtTabEstab.ideEvento.verProc.Should().Be(instanciaPopulada.evtTabEstab.ideEvento.verProc);

        // ideEmpregador
        instanciaXml.evtTabEstab.ideEmpregador.tpInsc.Should().Be(instanciaPopulada.evtTabEstab.ideEmpregador.tpInsc);
        instanciaXml.evtTabEstab.ideEmpregador.nrInsc.Should().Be(instanciaPopulada.evtTabEstab.ideEmpregador.nrInsc);

        // by test number
        switch (_testNumber)
        {
            case 0:
                ValidaCamposInclusao(instanciaPopulada, instanciaXml);
                break;
            case 1:
                ValidaCamposAlteracao(instanciaPopulada, instanciaXml);
                break;
            case 2:
                ValidaCamposExclusao(instanciaPopulada, instanciaXml);
                break;
        }
    }


    // Preenchimento e validação por tipo de teste
    #region Inclusao
    internal static void PreencheCamposInclusao(S1005 evento, string cnpjCpf)
    {
        evento.evtTabEstab = new S1005TabelaEstabelecimento()
        {
            ideEvento = new IdentificacaoCadastro()
            {
                tpAmb = Ambiente.ProducaoRestrita_DadosReais,
                procEmi = EmissorEvento.AppEmpregador,
                verProc = "2.2"
            },
            ideEmpregador = new Empregador()
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = cnpjCpf.Substring(0, 8)
            },
            infoEstab = new  S1005InfoEstabelecimento()
            {
                Item = new S1005Inclusao()
                {
                    ideEstab = new S1005IdentificacaoEstabelecimento()
                    {
                        tpInsc = TipoInscricao.CNPJ,
                        nrInsc = cnpjCpf,
                        iniValid = $"{DateTime.Now.AddMonths(-1):yyyy-MM}"
                    },
                    dadosEstab = new S1005DadosEstabelecimento()
                    {
                        cnaePrep = "1234567",
                        aliqGilrat = new S1005AliquotaGilRat()
                        {
                            aliqRat = 1,
                            fap = 1.55m
                        },
                        infoCaepf = new S1005InfoCaePF()
                        {
                            tpCaepf = TipoCAEPF.ContribIndividual
                        },
                        infoObra = new S1005InfoObra()
                        {
                            indSubstPatrObra = IndicadorSubstPatronalObra.NaoSubstituida
                        },
                        infoTrab = new()
                        {
                            infoApr = new S1005InfoAprendiz()
                            {
                                infoEntEduc = [
                                    new S1005InfoEntidadeEduc() {
                                        nrInsc = cnpjCpf
                                    }
                                ]
                            },
                            infoPCD = new S1005InfoPcd()
                            {
                                nrProcJud = "12345123451234512345"
                            }
                        }
                    }
                }
            }
        };
    }

    public void ValidaCamposInclusao(S1005 instanciaPopulada, S1005 instanciaXml)
    {
        S1005Inclusao itemPopulado = instanciaPopulada.evtTabEstab.infoEstab.Item as S1005Inclusao;
        S1005Inclusao itemXml = instanciaXml.evtTabEstab.infoEstab.Item as S1005Inclusao;
        itemPopulado.Should().NotBeNull();
        itemXml.Should().NotBeNull();

        // ideEstab
        itemXml.ideEstab.tpInsc.Should().Be(itemPopulado.ideEstab.tpInsc);
        itemXml.ideEstab.nrInsc.Should().Be(itemPopulado.ideEstab.nrInsc);
        itemXml.ideEstab.iniValid.Should().Be(itemPopulado.ideEstab.iniValid);
        itemXml.ideEstab.fimValid.Should().Be(itemPopulado.ideEstab.fimValid);

        // dadosEstab
        itemXml.dadosEstab.cnaePrep.Should().Be(itemPopulado.dadosEstab.cnaePrep);
        itemXml.dadosEstab.aliqGilrat.aliqRat.Should().Be(itemPopulado.dadosEstab.aliqGilrat.aliqRat);
        itemXml.dadosEstab.aliqGilrat.fap.Should().Be(itemPopulado.dadosEstab.aliqGilrat.fap);
        itemXml.dadosEstab.infoCaepf.tpCaepf.Should().Be(itemPopulado.dadosEstab.infoCaepf.tpCaepf);
        itemXml.dadosEstab.infoObra.indSubstPatrObra.Should().Be(itemPopulado.dadosEstab.infoObra.indSubstPatrObra);
        itemXml.dadosEstab.infoTrab.infoApr.infoEntEduc.Count.Should().Be(itemPopulado.dadosEstab.infoTrab.infoApr.infoEntEduc.Count);
        itemXml.dadosEstab.infoTrab.infoApr.infoEntEduc[0].nrInsc.Should().Be(itemPopulado.dadosEstab.infoTrab.infoApr.infoEntEduc[0].nrInsc);
        itemXml.dadosEstab.infoTrab.infoPCD.nrProcJud.Should().Be(itemPopulado.dadosEstab.infoTrab.infoPCD.nrProcJud);
    }
    #endregion

    #region Alteracao
    internal static void PreencheCamposAlteracao(S1005 evento, string cnpjCpf)
    {
        evento.evtTabEstab = new S1005TabelaEstabelecimento()
        {
            ideEvento = new IdentificacaoCadastro()
            {
                tpAmb = Ambiente.ProducaoRestrita_DadosReais,
                procEmi = EmissorEvento.AppEmpregador,
                verProc = "2.2"
            },
            ideEmpregador = new Empregador()
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = cnpjCpf.Substring(0, 8)
            },
            infoEstab = new S1005InfoEstabelecimento()
            {
                Item = new S1005Alteracao()
                {
                    ideEstab = new S1005IdentificacaoEstabelecimento()
                    {
                        tpInsc = TipoInscricao.CNPJ,
                        nrInsc = cnpjCpf,
                        iniValid = $"{DateTime.Now.AddMonths(-1):yyyy-MM}"
                    },
                    dadosEstab = new S1005DadosEstabelecimento()
                    {
                        cnaePrep = "1234567",
                        aliqGilrat = new S1005AliquotaGilRat()
                        {
                            aliqRat = 1,
                            fap = 1.55m
                        },
                        infoCaepf = new S1005InfoCaePF()
                        {
                            tpCaepf = TipoCAEPF.ContribIndividual
                        },
                        infoObra = new S1005InfoObra()
                        {
                            indSubstPatrObra = IndicadorSubstPatronalObra.NaoSubstituida
                        },
                        infoTrab = new()
                        {
                            infoApr = new S1005InfoAprendiz()
                            {
                                infoEntEduc = [
                                    new S1005InfoEntidadeEduc() {
                                        nrInsc = cnpjCpf
                                    }
                                ]
                            },
                            infoPCD = new S1005InfoPcd()
                            {
                                nrProcJud = "12345123451234512345"
                            }
                        }
                    },
                    novaValidade = new IdePeriodo()
                    {
                        iniValid = $"{DateTime.Now:yyyy-MM}",
                    }
                }
            }
        };
    }

    public void ValidaCamposAlteracao(S1005 instanciaPopulada, S1005 instanciaXml)
    {
        S1005Alteracao itemPopulado = instanciaPopulada.evtTabEstab.infoEstab.Item as S1005Alteracao;
        S1005Alteracao itemXml = instanciaXml.evtTabEstab.infoEstab.Item as S1005Alteracao;
        itemPopulado.Should().NotBeNull();
        itemXml.Should().NotBeNull();

        // ideEstab
        itemXml.ideEstab.tpInsc.Should().Be(itemPopulado.ideEstab.tpInsc);
        itemXml.ideEstab.nrInsc.Should().Be(itemPopulado.ideEstab.nrInsc);
        itemXml.ideEstab.iniValid.Should().Be(itemPopulado.ideEstab.iniValid);
        itemXml.ideEstab.fimValid.Should().Be(itemPopulado.ideEstab.fimValid);

        // dadosEstab
        itemXml.dadosEstab.cnaePrep.Should().Be(itemPopulado.dadosEstab.cnaePrep);
        itemXml.dadosEstab.aliqGilrat.aliqRat.Should().Be(itemPopulado.dadosEstab.aliqGilrat.aliqRat);
        itemXml.dadosEstab.aliqGilrat.fap.Should().Be(itemPopulado.dadosEstab.aliqGilrat.fap);
        itemXml.dadosEstab.infoCaepf.tpCaepf.Should().Be(itemPopulado.dadosEstab.infoCaepf.tpCaepf);
        itemXml.dadosEstab.infoObra.indSubstPatrObra.Should().Be(itemPopulado.dadosEstab.infoObra.indSubstPatrObra);
        itemXml.dadosEstab.infoTrab.infoApr.infoEntEduc.Count.Should().Be(itemPopulado.dadosEstab.infoTrab.infoApr.infoEntEduc.Count);
        itemXml.dadosEstab.infoTrab.infoApr.infoEntEduc[0].nrInsc.Should().Be(itemPopulado.dadosEstab.infoTrab.infoApr.infoEntEduc[0].nrInsc);
        itemXml.dadosEstab.infoTrab.infoPCD.nrProcJud.Should().Be(itemPopulado.dadosEstab.infoTrab.infoPCD.nrProcJud);

        // novaValidade
        itemXml.novaValidade.iniValid.Should().Be(itemPopulado.novaValidade.iniValid);
        itemXml.novaValidade.fimValid.Should().Be(itemPopulado.novaValidade.fimValid);
    }
    #endregion

    #region Exclusao
    internal static void PreencheCamposExclusao(S1005 evento, string cnpjCpf)
    {
        evento.evtTabEstab = new S1005TabelaEstabelecimento()
        {
            ideEvento = new IdentificacaoCadastro()
            {
                tpAmb = Ambiente.ProducaoRestrita_DadosReais,
                procEmi = EmissorEvento.AppEmpregador,
                verProc = "2.2"
            },
            ideEmpregador = new Empregador()
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = cnpjCpf.Substring(0, 8)
            },
            infoEstab = new S1005InfoEstabelecimento()
            {
                Item = new S1005Exclusao()
                {
                    ideEstab = new S1005IdentificacaoEstabelecimento()
                    {
                        tpInsc = TipoInscricao.CNPJ,
                        nrInsc = cnpjCpf,
                        iniValid = $"{DateTime.Now.AddMonths(-1):yyyy-MM}"
                    },
                }
            }
        };
    }

    public void ValidaCamposExclusao(S1005 instanciaPopulada, S1005 instanciaXml)
    {
        S1005Exclusao itemPopulado = instanciaPopulada.evtTabEstab.infoEstab.Item as S1005Exclusao;
        S1005Exclusao itemXml = instanciaXml.evtTabEstab.infoEstab.Item as S1005Exclusao;
        itemPopulado.Should().NotBeNull();
        itemXml.Should().NotBeNull();

        // ideEstab
        itemXml.ideEstab.tpInsc.Should().Be(itemPopulado.ideEstab.tpInsc);
        itemXml.ideEstab.nrInsc.Should().Be(itemPopulado.ideEstab.nrInsc);
        itemXml.ideEstab.iniValid.Should().Be(itemPopulado.ideEstab.iniValid);
        itemXml.ideEstab.fimValid.Should().Be(itemPopulado.ideEstab.fimValid);
    }
    #endregion
}