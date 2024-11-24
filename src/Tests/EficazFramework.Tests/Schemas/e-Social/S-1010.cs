namespace EficazFramework.SPED.Schemas.eSocial;

public class S1010Test : BaseESocialTest<S1010>
{
    private int _testNumber = 0;

    [Test]
    [TestCase(Versao.v_S_01_02_00)]
    public async Task ValidaInclusao(Versao versao)
    {
        _testNumber = 0;
        _versao = versao;
        ValidationSchemaNamespace = $"http://www.esocial.gov.br/schema/evt/evtTabRubrica/{versao}";
        ValidationSchema = versao switch
        {
            _ => Resources.Schemas.eSocial.S1010_v_S_01_02_00
        };
        await TestaEvento();
    }


    [Test]
    [TestCase(Versao.v_S_01_02_00)]
    public async Task ValidaAlteracao(Versao versao)
    {
        _testNumber = 1;
        _versao = versao;
        ValidationSchemaNamespace = $"http://www.esocial.gov.br/schema/evt/evtTabRubrica/{versao}";
        ValidationSchema = versao switch
        {
            _ => Resources.Schemas.eSocial.S1010_v_S_01_02_00
        };
        await TestaEvento();
    }


    [Test]
    [TestCase(Versao.v_S_01_02_00)]
    public async Task ValidaExclusao(Versao versao)
    {
        _testNumber = 2;
        _versao = versao;
        ValidationSchemaNamespace = $"http://www.esocial.gov.br/schema/evt/evtTabRubrica/{versao}";
        ValidationSchema = versao switch
        {
            _ => Resources.Schemas.eSocial.S1010_v_S_01_02_00
        };
        await TestaEvento();
    }


    // BaseESocialTest overrides
    public override void PreencheCampos(S1010 evento)
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

    public override void ValidaInstanciasLeituraEscrita(S1010 instanciaPopulada, S1010 instanciaXml)
    {
        // TODO: verifique se os campos de instanciaXml, preenchidos a partir da leitura de um XmlDocument, 
        //       correspondem exatamente aos valores de instanciaPopulada, formado à partir do método
        //       PreencheCampos().


        // ideEvento
        instanciaXml.evtTabRubrica.ideEvento.tpAmb.Should().Be(instanciaPopulada.evtTabRubrica.ideEvento.tpAmb);
        instanciaXml.evtTabRubrica.ideEvento.procEmi.Should().Be(instanciaPopulada.evtTabRubrica.ideEvento.procEmi);
        instanciaXml.evtTabRubrica.ideEvento.verProc.Should().Be(instanciaPopulada.evtTabRubrica.ideEvento.verProc);

        // ideEmpregador
        instanciaXml.evtTabRubrica.ideEmpregador.tpInsc.Should().Be(instanciaPopulada.evtTabRubrica.ideEmpregador.tpInsc);
        instanciaXml.evtTabRubrica.ideEmpregador.nrInsc.Should().Be(instanciaPopulada.evtTabRubrica.ideEmpregador.nrInsc);

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
    internal static void PreencheCamposInclusao(S1010 evento, string cnpjCpf)
    {
        evento.evtTabRubrica = new S1010Rubrica()
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
            infoRubrica = new  S1010InfoRubrica()
            {
                Item = new S1010Inclusao()
                {
                    ideRubrica = new S1010IdentificacaoRubrica()
                    {
                        codRubr = "100",
                        ideTabRubr = "1",
                        iniValid = $"{DateTime.Now.AddMonths(-1):yyyy-MM}"
                    },
                    dadosRubrica = new S1010DadosRubrica()
                    {
                        dscRubr = "Pró-Labore",
                        natRubr = 1000,
                        tpRubr = NaturezaRubrica.Provento,
                        codIncCP = "11",
                        codIncIRRF = "11",
                        codIncFGTS = "00",
                        codIncCPRP = "00",
                        tetoRemun = SimNaoString.Nao
                    }
                }
            }
        };
    }

    public void ValidaCamposInclusao(S1010 instanciaPopulada, S1010 instanciaXml)
    {
        S1010Inclusao itemPopulado = instanciaPopulada.evtTabRubrica.infoRubrica.Item as S1010Inclusao;
        S1010Inclusao itemXml = instanciaXml.evtTabRubrica.infoRubrica.Item as S1010Inclusao;
        itemPopulado.Should().NotBeNull();
        itemXml.Should().NotBeNull();

        // ideRubrica
        itemXml.ideRubrica.codRubr.Should().Be(itemPopulado.ideRubrica.codRubr);
        itemXml.ideRubrica.ideTabRubr.Should().Be(itemPopulado.ideRubrica.ideTabRubr);
        itemXml.ideRubrica.iniValid.Should().Be(itemPopulado.ideRubrica.iniValid);
        itemXml.ideRubrica.fimValid.Should().Be(itemPopulado.ideRubrica.fimValid);

        // dadosEstab
        itemXml.dadosRubrica.dscRubr.Should().Be(itemPopulado.dadosRubrica.dscRubr);
        itemXml.dadosRubrica.natRubr.Should().Be(itemPopulado.dadosRubrica.natRubr);
        itemXml.dadosRubrica.tpRubr.Should().Be(itemPopulado.dadosRubrica.tpRubr);
        itemXml.dadosRubrica.codIncCP.Should().Be(itemPopulado.dadosRubrica.codIncCP);
        itemXml.dadosRubrica.codIncIRRF.Should().Be(itemPopulado.dadosRubrica.codIncIRRF);
        itemXml.dadosRubrica.codIncFGTS.Should().Be(itemPopulado.dadosRubrica.codIncFGTS);
        itemXml.dadosRubrica.codIncCPRP.Should().Be(itemPopulado.dadosRubrica.codIncCPRP);
        itemXml.dadosRubrica.tetoRemun.Should().Be(itemPopulado.dadosRubrica.tetoRemun);
    }
    #endregion

    #region Alteracao
    internal static void PreencheCamposAlteracao(S1010 evento, string cnpjCpf)
    {
        evento.evtTabRubrica = new S1010Rubrica()
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
            infoRubrica = new S1010InfoRubrica()
            {
                Item = new S1010Alteracao()
                {
                    ideRubrica = new S1010IdentificacaoRubrica()
                    {
                        codRubr = "100",
                        ideTabRubr = "1",
                        iniValid = $"{DateTime.Now.AddMonths(-1):yyyy-MM}"
                    },
                    dadosRubrica = new S1010DadosRubrica()
                    {
                        dscRubr = "Pró-Labore",
                        natRubr = 1000,
                        tpRubr = NaturezaRubrica.Provento,
                        codIncCP = "11",
                        codIncIRRF = "11",
                        codIncFGTS = "00",
                        codIncCPRP = "00",
                        tetoRemun = SimNaoString.Nao
                    },
                    novaValidade = new IdePeriodo()
                    {
                        iniValid = $"{DateTime.Now:yyyy-MM}",
                    }
                }
            }
        };
    }

    public void ValidaCamposAlteracao(S1010 instanciaPopulada, S1010 instanciaXml)
    {
        S1010Alteracao itemPopulado = instanciaPopulada.evtTabRubrica.infoRubrica.Item as S1010Alteracao;
        S1010Alteracao itemXml = instanciaXml.evtTabRubrica.infoRubrica.Item as S1010Alteracao;
        itemPopulado.Should().NotBeNull();
        itemXml.Should().NotBeNull();

        // ideEstab
        itemXml.ideRubrica.codRubr.Should().Be(itemPopulado.ideRubrica.codRubr);
        itemXml.ideRubrica.ideTabRubr.Should().Be(itemPopulado.ideRubrica.ideTabRubr);
        itemXml.ideRubrica.iniValid.Should().Be(itemPopulado.ideRubrica.iniValid);
        itemXml.ideRubrica.fimValid.Should().Be(itemPopulado.ideRubrica.fimValid);

        // dadosEstab
        itemXml.dadosRubrica.dscRubr.Should().Be(itemPopulado.dadosRubrica.dscRubr);
        itemXml.dadosRubrica.natRubr.Should().Be(itemPopulado.dadosRubrica.natRubr);
        itemXml.dadosRubrica.tpRubr.Should().Be(itemPopulado.dadosRubrica.tpRubr);
        itemXml.dadosRubrica.codIncCP.Should().Be(itemPopulado.dadosRubrica.codIncCP);
        itemXml.dadosRubrica.codIncIRRF.Should().Be(itemPopulado.dadosRubrica.codIncIRRF);
        itemXml.dadosRubrica.codIncFGTS.Should().Be(itemPopulado.dadosRubrica.codIncFGTS);
        itemXml.dadosRubrica.codIncCPRP.Should().Be(itemPopulado.dadosRubrica.codIncCPRP);
        itemXml.dadosRubrica.tetoRemun.Should().Be(itemPopulado.dadosRubrica.tetoRemun);

        // novaValidade
        itemXml.novaValidade.iniValid.Should().Be(itemPopulado.novaValidade.iniValid);
        itemXml.novaValidade.fimValid.Should().Be(itemPopulado.novaValidade.fimValid);
    }
    #endregion

    #region Exclusao
    internal static void PreencheCamposExclusao(S1010 evento, string cnpjCpf)
    {
        evento.evtTabRubrica = new S1010Rubrica()
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
            infoRubrica = new S1010InfoRubrica()
            {
                Item = new S1010Exclusao()
                {
                    ideRubrica = new S1010IdentificacaoRubrica()
                    {
                        codRubr = "100",
                        ideTabRubr = "1",
                        iniValid = $"{DateTime.Now.AddMonths(-1):yyyy-MM}"
                    },
                }
            }
        };
    }

    public void ValidaCamposExclusao(S1010 instanciaPopulada, S1010 instanciaXml)
    {
        S1010Exclusao itemPopulado = instanciaPopulada.evtTabRubrica.infoRubrica.Item as S1010Exclusao;
        S1010Exclusao itemXml = instanciaXml.evtTabRubrica.infoRubrica.Item as S1010Exclusao;
        itemPopulado.Should().NotBeNull();
        itemXml.Should().NotBeNull();

        // ideEstab
        itemXml.ideRubrica.codRubr.Should().Be(itemPopulado.ideRubrica.codRubr);
        itemXml.ideRubrica.ideTabRubr.Should().Be(itemPopulado.ideRubrica.ideTabRubr);
        itemXml.ideRubrica.iniValid.Should().Be(itemPopulado.ideRubrica.iniValid);
        itemXml.ideRubrica.fimValid.Should().Be(itemPopulado.ideRubrica.fimValid);
    }
    #endregion
}