namespace EficazFramework.SPED.Schemas.eSocial;

public class S1020Test : BaseESocialTest<S1020>
{
    private int _testNumber = 0;

    [Test]
    [TestCase(Versao.v_S_01_02_00)]
    public async Task ValidaInclusao(Versao versao)
    {
        _testNumber = 0;
        _versao = versao;
        ValidationSchemaNamespace = $"http://www.esocial.gov.br/schema/evt/evtTabLotacao/{versao}";
        ValidationSchema = versao switch
        {
            _ => Resources.Schemas.eSocial.S1020_v_S_01_02_00
        };
        await TestaEvento();
    }


    [Test]
    [TestCase(Versao.v_S_01_02_00)]
    public async Task ValidaAlteracao(Versao versao)
    {
        _testNumber = 1;
        _versao = versao;
        ValidationSchemaNamespace = $"http://www.esocial.gov.br/schema/evt/evtTabLotacao/{versao}";
        ValidationSchema = versao switch
        {
            _ => Resources.Schemas.eSocial.S1020_v_S_01_02_00
        };
        await TestaEvento();
    }


    [Test]
    [TestCase(Versao.v_S_01_02_00)]
    public async Task ValidaExclusao(Versao versao)
    {
        _testNumber = 2;
        _versao = versao;
        ValidationSchemaNamespace = $"http://www.esocial.gov.br/schema/evt/evtTabLotacao/{versao}";
        ValidationSchema = versao switch
        {
            _ => Resources.Schemas.eSocial.S1020_v_S_01_02_00
        };
        await TestaEvento();
    }


    // BaseESocialTest overrides
    public override void PreencheCampos(S1020 evento)
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

    public override void ValidaInstanciasLeituraEscrita(S1020 instanciaPopulada, S1020 instanciaXml)
    {
        // TODO: verifique se os campos de instanciaXml, preenchidos a partir da leitura de um XmlDocument, 
        //       correspondem exatamente aos valores de instanciaPopulada, formado à partir do método
        //       PreencheCampos().


        // ideEvento
        instanciaXml.evtTabLotacao.ideEvento.tpAmb.Should().Be(instanciaPopulada.evtTabLotacao.ideEvento.tpAmb);
        instanciaXml.evtTabLotacao.ideEvento.procEmi.Should().Be(instanciaPopulada.evtTabLotacao.ideEvento.procEmi);
        instanciaXml.evtTabLotacao.ideEvento.verProc.Should().Be(instanciaPopulada.evtTabLotacao.ideEvento.verProc);

        // ideEmpregador
        instanciaXml.evtTabLotacao.ideEmpregador.tpInsc.Should().Be(instanciaPopulada.evtTabLotacao.ideEmpregador.tpInsc);
        instanciaXml.evtTabLotacao.ideEmpregador.nrInsc.Should().Be(instanciaPopulada.evtTabLotacao.ideEmpregador.nrInsc);

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
    internal static void PreencheCamposInclusao(S1020 evento, string cnpjCpf)
    {
        evento.evtTabLotacao = new S1020TabelaLotacao()
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
            infoLotacao = new S1020InfoLotacao()
            {
                Item = new S1020Inclusao()
                {
                    ideLotacao = new S1020IdentificacaoLotacao()
                    {
                        codLotacao = "10",
                        iniValid = $"{DateTime.Now.AddMonths(-1):yyyy-MM}"
                    },
                    dadosLotacao = new S1020DadosLotacao()
                    {
                        tpLotacao = "01",
                        tpInsc =  PersonalidadeJuridica.CNPJ,
                        tpInscSpecified = true,
                        fpasLotacao = new S1020FpasLotacao()
                        {
                            fpas = 123,
                            codTercs = "0000",
                            codTercsSusp = "0000"
                        },
                        infoEmprParcial = new S1020InfoEmprParcial()
                        {
                            tpInscContrat = PersonalidadeJuridica.CNPJ,
                            nrInscContrat = cnpjCpf
                        },
                        dadosOpPort = new S1020DadosOpPortuario()
                        {
                            aliqRat = 1,
                            fap = 1.55m
                        },
                    }
                }
            }
        };
    }

    public void ValidaCamposInclusao(S1020 instanciaPopulada, S1020 instanciaXml)
    {
        S1020Inclusao itemPopulado = instanciaPopulada.evtTabLotacao.infoLotacao.Item as S1020Inclusao;
        S1020Inclusao itemXml = instanciaXml.evtTabLotacao.infoLotacao.Item as S1020Inclusao;
        itemPopulado.Should().NotBeNull();
        itemXml.Should().NotBeNull();

        // ideLotacao
        itemXml.ideLotacao.codLotacao.Should().Be(itemPopulado.ideLotacao.codLotacao);
        itemXml.ideLotacao.iniValid.Should().Be(itemPopulado.ideLotacao.iniValid);
        itemXml.ideLotacao.fimValid.Should().Be(itemPopulado.ideLotacao.fimValid);

        // dadosEstab
        itemXml.dadosLotacao.tpLotacao.Should().Be(itemPopulado.dadosLotacao.tpLotacao);
        itemXml.dadosLotacao.tpInsc.Should().Be(itemPopulado.dadosLotacao.tpInsc);
        itemXml.dadosLotacao.nrInsc.Should().Be(itemPopulado.dadosLotacao.nrInsc);
        itemXml.dadosLotacao.fpasLotacao.fpas.Should().Be(itemPopulado.dadosLotacao.fpasLotacao.fpas);
        itemXml.dadosLotacao.fpasLotacao.codTercs.Should().Be(itemPopulado.dadosLotacao.fpasLotacao.codTercs);
        itemXml.dadosLotacao.fpasLotacao.codTercsSusp.Should().Be(itemPopulado.dadosLotacao.fpasLotacao.codTercsSusp);
        itemXml.dadosLotacao.infoEmprParcial.tpInscContrat.Should().Be(itemPopulado.dadosLotacao.infoEmprParcial.tpInscContrat);
        itemXml.dadosLotacao.infoEmprParcial.nrInscContrat.Should().Be(itemPopulado.dadosLotacao.infoEmprParcial.nrInscContrat);
        itemXml.dadosLotacao.infoEmprParcial.tpInscProp.Should().Be(itemPopulado.dadosLotacao.infoEmprParcial.tpInscProp);
        itemXml.dadosLotacao.infoEmprParcial.nrInscProp.Should().Be(itemPopulado.dadosLotacao.infoEmprParcial.nrInscProp);
        itemXml.dadosLotacao.dadosOpPort.aliqRat.Should().Be(itemPopulado.dadosLotacao.dadosOpPort.aliqRat);
        itemXml.dadosLotacao.dadosOpPort.fap.Should().Be(itemPopulado.dadosLotacao.dadosOpPort.fap);
    }
    #endregion

    #region Alteracao
    internal static void PreencheCamposAlteracao(S1020 evento, string cnpjCpf)
    {
        evento.evtTabLotacao = new S1020TabelaLotacao()
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
            infoLotacao = new S1020InfoLotacao()
            {
                Item = new S1020Alteracao()
                {
                    ideLotacao = new S1020IdentificacaoLotacao()
                    {
                        codLotacao = "10",
                        iniValid = $"{DateTime.Now.AddMonths(-1):yyyy-MM}"
                    },
                    dadosLotacao = new S1020DadosLotacao()
                    {
                        tpLotacao = "01",
                        tpInsc = PersonalidadeJuridica.CNPJ,
                        tpInscSpecified = true,
                        fpasLotacao = new S1020FpasLotacao()
                        {
                            fpas = 123,
                            codTercs = "0000",
                            codTercsSusp = "0000"
                        },
                        infoEmprParcial = new S1020InfoEmprParcial()
                        {
                            tpInscContrat = PersonalidadeJuridica.CNPJ,
                            nrInscContrat = cnpjCpf
                        },
                        dadosOpPort = new S1020DadosOpPortuario()
                        {
                            aliqRat = 1,
                            fap = 1.55m
                        },
                    },
                    novaValidade = new IdePeriodo()
                    {
                        iniValid = $"{DateTime.Now:yyyy-MM}",
                    }
                }
            }
        };
    }

    public void ValidaCamposAlteracao(S1020 instanciaPopulada, S1020 instanciaXml)
    {
        S1020Alteracao itemPopulado = instanciaPopulada.evtTabLotacao.infoLotacao.Item as S1020Alteracao;
        S1020Alteracao itemXml = instanciaXml.evtTabLotacao.infoLotacao.Item as S1020Alteracao;
        itemPopulado.Should().NotBeNull();
        itemXml.Should().NotBeNull();

        // ideEstab
        itemXml.ideLotacao.codLotacao.Should().Be(itemPopulado.ideLotacao.codLotacao);
        itemXml.ideLotacao.iniValid.Should().Be(itemPopulado.ideLotacao.iniValid);
        itemXml.ideLotacao.fimValid.Should().Be(itemPopulado.ideLotacao.fimValid);

        // dadosEstab
        itemXml.dadosLotacao.tpLotacao.Should().Be(itemPopulado.dadosLotacao.tpLotacao);
        itemXml.dadosLotacao.tpInsc.Should().Be(itemPopulado.dadosLotacao.tpInsc);
        itemXml.dadosLotacao.nrInsc.Should().Be(itemPopulado.dadosLotacao.nrInsc);
        itemXml.dadosLotacao.fpasLotacao.fpas.Should().Be(itemPopulado.dadosLotacao.fpasLotacao.fpas);
        itemXml.dadosLotacao.fpasLotacao.codTercs.Should().Be(itemPopulado.dadosLotacao.fpasLotacao.codTercs);
        itemXml.dadosLotacao.fpasLotacao.codTercsSusp.Should().Be(itemPopulado.dadosLotacao.fpasLotacao.codTercsSusp);
        itemXml.dadosLotacao.infoEmprParcial.tpInscContrat.Should().Be(itemPopulado.dadosLotacao.infoEmprParcial.tpInscContrat);
        itemXml.dadosLotacao.infoEmprParcial.nrInscContrat.Should().Be(itemPopulado.dadosLotacao.infoEmprParcial.nrInscContrat);
        itemXml.dadosLotacao.infoEmprParcial.tpInscProp.Should().Be(itemPopulado.dadosLotacao.infoEmprParcial.tpInscProp);
        itemXml.dadosLotacao.infoEmprParcial.nrInscProp.Should().Be(itemPopulado.dadosLotacao.infoEmprParcial.nrInscProp);
        itemXml.dadosLotacao.dadosOpPort.aliqRat.Should().Be(itemPopulado.dadosLotacao.dadosOpPort.aliqRat);
        itemXml.dadosLotacao.dadosOpPort.fap.Should().Be(itemPopulado.dadosLotacao.dadosOpPort.fap);

        // novaValidade
        itemXml.novaValidade.iniValid.Should().Be(itemPopulado.novaValidade.iniValid);
        itemXml.novaValidade.fimValid.Should().Be(itemPopulado.novaValidade.fimValid);
    }
    #endregion

    #region Exclusao
    internal static void PreencheCamposExclusao(S1020 evento, string cnpjCpf)
    {
        evento.evtTabLotacao = new S1020TabelaLotacao()
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
            infoLotacao = new S1020InfoLotacao()
            {
                Item = new S1020Exclusao()
                {
                    ideLotacao = new S1020IdentificacaoLotacao()
                    {
                        codLotacao = "10",
                        iniValid = $"{DateTime.Now.AddMonths(-1):yyyy-MM}"
                    },
                }
            }
        };
    }

    public void ValidaCamposExclusao(S1020 instanciaPopulada, S1020 instanciaXml)
    {
        S1020Exclusao itemPopulado = instanciaPopulada.evtTabLotacao.infoLotacao.Item as S1020Exclusao;
        S1020Exclusao itemXml = instanciaXml.evtTabLotacao.infoLotacao.Item as S1020Exclusao;
        itemPopulado.Should().NotBeNull();
        itemXml.Should().NotBeNull();

        // ideEstab
        itemXml.ideLotacao.codLotacao.Should().Be(itemPopulado.ideLotacao.codLotacao);
        itemXml.ideLotacao.iniValid.Should().Be(itemPopulado.ideLotacao.iniValid);
        itemXml.ideLotacao.fimValid.Should().Be(itemPopulado.ideLotacao.fimValid);
    }
    #endregion
}