namespace EficazFramework.SPED.Schemas.eSocial;

public class S1000Test : BaseESocialTest<S1000>
{
    private int _testNumber = 0;

    [Test]
    [TestCase(Versao.v_S_01_02_00)]
    [TestCase(Versao.v_S_01_03_00)]
    public async Task ValidaInclusao(Versao versao)
    {
        _testNumber = 0;
        _versao = versao;
        ValidationSchemaNamespace = $"http://www.esocial.gov.br/schema/evt/evtInfoEmpregador/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v_S_01_03_00 => Resources.Schemas.eSocial.S1000_v_S_01_03_00,
            _ => Resources.Schemas.eSocial.S1000_v_S_01_02_00
        };
        await TestaEvento();
    }


    [Test]
    [TestCase(Versao.v_S_01_02_00)]
    [TestCase(Versao.v_S_01_03_00)]
    public async Task ValidaAlteracao(Versao versao)
    {
        _testNumber = 1;
        _versao = versao;
        ValidationSchemaNamespace = $"http://www.esocial.gov.br/schema/evt/evtInfoEmpregador/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v_S_01_03_00 => Resources.Schemas.eSocial.S1000_v_S_01_03_00,
            _ => Resources.Schemas.eSocial.S1000_v_S_01_02_00
        };
        await TestaEvento();
    }


    [Test]
    [TestCase(Versao.v_S_01_02_00)]
    [TestCase(Versao.v_S_01_03_00)]
    public async Task ValidaExclusao(Versao versao)
    {
        _testNumber = 2;
        _versao = versao;
        ValidationSchemaNamespace = $"http://www.esocial.gov.br/schema/evt/evtInfoEmpregador/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v_S_01_03_00 => Resources.Schemas.eSocial.S1000_v_S_01_03_00,
            _ => Resources.Schemas.eSocial.S1000_v_S_01_02_00
        };
        await TestaEvento();
    }


    [Test]
    public async Task Read_v_S_01_01_01()
    {
        var evento = await Evento.ReadAsync(Resources.Samples.eSocial.S1000_v_S_01_01_01);
        evento.Should().NotBeNull();
        evento.Versao.Should().Be(Versao.v_S_01_01_00);
        var evtAdmissao = evento as S1000;
        evtAdmissao.Should().NotBeNull();
        evtAdmissao.evtInfoEmpregador.Id.Should().Be("ID1123456780000002023061909493500001");
        var inclusao = evtAdmissao.evtInfoEmpregador.infoEmpregador.Item as S1000Inclusao;
        inclusao.Should().NotBeNull();
        inclusao.idePeriodo.iniValid.Should().Be("2023-06");
        inclusao.infoCadastro.classTrib.Should().Be("99");
        inclusao.infoCadastro.indCoop.Should().Be(IndicadorCooperativa.Nao);
        inclusao.infoCadastro.indConstrSpecified.Should().BeTrue();
        inclusao.infoCadastro.indConstr.Should().Be(SimNaoByte.Nao);
        inclusao.infoCadastro.indDesFolha.Should().Be(SimNaoByte.Nao);
        inclusao.infoCadastro.indOptRegEletron.Should().Be(SimNaoByte.Sim);
    }

    [Test]
    public async Task Read_v_02_04_02()
    {
        var evento = await Evento.ReadAsync(Resources.Samples.eSocial.S1000_v02_04_02);
        evento.Should().NotBeNull();
        evento.Versao.Should().Be(Versao.v02_04_02);
        var evtAdmissao = evento as S1000;
        evtAdmissao.Should().NotBeNull();
        evtAdmissao.evtInfoEmpregador.Id.Should().Be("ID1123456780000002018092508301200001");
        var inclusao = evtAdmissao.evtInfoEmpregador.infoEmpregador.Item as S1000Inclusao;
        inclusao.Should().NotBeNull();
        inclusao.idePeriodo.iniValid.Should().Be("2018-07");
        inclusao.infoCadastro.classTrib.Should().Be("99");
        inclusao.infoCadastro.indCoop.Should().Be(IndicadorCooperativa.OutrasCoops);
        inclusao.infoCadastro.indConstrSpecified.Should().BeTrue();
        inclusao.infoCadastro.indConstr.Should().Be(SimNaoByte.Nao);
        inclusao.infoCadastro.indDesFolha.Should().Be(SimNaoByte.Nao);
        inclusao.infoCadastro.indOptRegEletron.Should().Be(SimNaoByte.Nao);
    }


    // BaseESocialTest overrides
    public override void PreencheCampos(S1000 evento)
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

    public override void ValidaInstanciasLeituraEscrita(S1000 instanciaPopulada, S1000 instanciaXml)
    {
        // TODO: verifique se os campos de instanciaXml, preenchidos a partir da leitura de um XmlDocument, 
        //       correspondem exatamente aos valores de instanciaPopulada, formado à partir do método
        //       PreencheCampos().


        // ideEvento
        instanciaXml.evtInfoEmpregador.ideEvento.tpAmb.Should().Be(instanciaPopulada.evtInfoEmpregador.ideEvento.tpAmb);
        instanciaXml.evtInfoEmpregador.ideEvento.procEmi.Should().Be(instanciaPopulada.evtInfoEmpregador.ideEvento.procEmi);
        instanciaXml.evtInfoEmpregador.ideEvento.verProc.Should().Be(instanciaPopulada.evtInfoEmpregador.ideEvento.verProc);

        // ideEmpregador
        instanciaXml.evtInfoEmpregador.ideEmpregador.tpInsc.Should().Be(instanciaPopulada.evtInfoEmpregador.ideEmpregador.tpInsc);
        instanciaXml.evtInfoEmpregador.ideEmpregador.nrInsc.Should().Be(instanciaPopulada.evtInfoEmpregador.ideEmpregador.nrInsc);

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
    internal static void PreencheCamposInclusao(S1000 evento, string cnpjCpf)
    {
        evento.evtInfoEmpregador = new S1000InfoEmpregador()
        {
            ideEvento = new IdentificacaoCadastro()
            {
                tpAmb = Ambiente.ProducaoRestrita_DadosReais,
                procEmi = EmissorEvento.AppEmpregador,
                verProc = "2.2"
            },
            ideEmpregador = new()
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = cnpjCpf.Substring(0, 8)
            },
            infoEmpregador = new S1000InfoEmpregadorAcao()
            {
                Item = new S1000Inclusao()
                {
                    idePeriodo = new IdePeriodo()
                    {
                        iniValid = $"{DateTime.Now.AddMonths(-1):yyyy-MM}"
                    },
                    infoCadastro = new S1000InfoCadastro()
                    {
                        classTrib = "99",
                        indCoop = IndicadorCooperativa.Nao,
                        indCoopSpecified = true,
                        indConstr = SimNaoByte.Nao,
                        indConstrSpecified = true,
                        indDesFolha = SimNaoByte.Nao,
                        indOpcCP = OpcaoTributacaoPrevidenciaria.FolhaPagto,
                        indOpcCPSpecified = true,
                        indPorte = SimNaoString.Sim,
                        indOptRegEletron = SimNaoByte.Nao,
                        indTribFolhaPisCofins = SimNaoString.Nao,
                        dadosIsencao = new S1000DadosIsencao()
                        {
                            ideMinLei = "MTE",
                            nrCertif = "abc",
                            dtEmisCertif = DateTime.Now.AddYears(-1),
                            dtVencCertif = DateTime.Now.AddYears(5),
                            dtDou = DateTime.Now.AddYears(-1),
                            pagDou = 1234
                        }
                    }
                }
            }
        };
    }

    public void ValidaCamposInclusao(S1000 instanciaPopulada, S1000 instanciaXml)
    {
        S1000Inclusao itemPopulado = instanciaPopulada.evtInfoEmpregador.infoEmpregador.Item as S1000Inclusao;
        S1000Inclusao itemXml = instanciaXml.evtInfoEmpregador.infoEmpregador.Item as S1000Inclusao;
        itemPopulado.Should().NotBeNull();
        itemXml.Should().NotBeNull();

        // idePeriodo
        itemXml.idePeriodo.iniValid.Should().Be(itemPopulado.idePeriodo.iniValid);
        itemXml.idePeriodo.fimValid.Should().Be(itemPopulado.idePeriodo.fimValid);

        // infoCadastro
        itemXml.infoCadastro.classTrib.Should().Be(itemPopulado.infoCadastro.classTrib);
        itemXml.infoCadastro.indCoop.Should().Be(itemPopulado.infoCadastro.indCoop);
        itemXml.infoCadastro.indConstr.Should().Be(itemPopulado.infoCadastro.indConstr);
        itemXml.infoCadastro.indDesFolha.Should().Be(itemPopulado.infoCadastro.indDesFolha);
        itemXml.infoCadastro.indOpcCP.Should().Be(itemPopulado.infoCadastro.indOpcCP);
        itemXml.infoCadastro.indPorte.Should().Be(itemPopulado.infoCadastro.indPorte);
        itemXml.infoCadastro.indOptRegEletron.Should().Be(itemPopulado.infoCadastro.indOptRegEletron);
        itemXml.infoCadastro.indTribFolhaPisCofins.Should().Be(itemPopulado.infoCadastro.indTribFolhaPisCofins);
        itemXml.infoCadastro.dadosIsencao.ideMinLei.Should().Be(itemPopulado.infoCadastro.dadosIsencao.ideMinLei);
        itemXml.infoCadastro.dadosIsencao.nrCertif.Should().Be(itemPopulado.infoCadastro.dadosIsencao.nrCertif);
        itemXml.infoCadastro.dadosIsencao.dtEmisCertif.Should().BeSameDateAs(itemPopulado.infoCadastro.dadosIsencao.dtEmisCertif);
        itemXml.infoCadastro.dadosIsencao.dtVencCertif.Should().BeSameDateAs(itemPopulado.infoCadastro.dadosIsencao.dtVencCertif);
        itemXml.infoCadastro.dadosIsencao.dtDou.Should().BeSameDateAs(itemPopulado.infoCadastro.dadosIsencao.dtDou.Value);
        itemXml.infoCadastro.dadosIsencao.pagDou.Should().Be(itemPopulado.infoCadastro.dadosIsencao.pagDou);
    }
    #endregion

    #region Alteracao
    internal static void PreencheCamposAlteracao(S1000 evento, string cnpjCpf)
    {
        evento.evtInfoEmpregador = new S1000InfoEmpregador()
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
            infoEmpregador = new S1000InfoEmpregadorAcao()
            {
                Item = new S1000Alteracao()
                {
                    idePeriodo = new IdePeriodo()
                    {
                        iniValid = $"{DateTime.Now.AddMonths(-1):yyyy-MM}"
                    },
                    infoCadastro = new S1000InfoCadastro()
                    {
                        classTrib = "99",
                        indCoop = IndicadorCooperativa.Nao,
                        indCoopSpecified = true,
                        indConstr = SimNaoByte.Nao,
                        indConstrSpecified = true,
                        indDesFolha = SimNaoByte.Nao,
                        indOpcCP = OpcaoTributacaoPrevidenciaria.FolhaPagto,
                        indOpcCPSpecified = true,
                        indPorte = SimNaoString.Sim,
                        indOptRegEletron = SimNaoByte.Nao,
                        indTribFolhaPisCofins = SimNaoString.Nao,
                        dadosIsencao = new S1000DadosIsencao()
                        {
                            ideMinLei = "MTE",
                            nrCertif = "abc",
                            dtEmisCertif = DateTime.Now.AddYears(-1),
                            dtVencCertif = DateTime.Now.AddYears(5),
                            dtDou = DateTime.Now.AddYears(-1),
                            pagDou = 1234
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

    public void ValidaCamposAlteracao(S1000 instanciaPopulada, S1000 instanciaXml)
    {
        S1000Alteracao itemPopulado = instanciaPopulada.evtInfoEmpregador.infoEmpregador.Item as S1000Alteracao;
        S1000Alteracao itemXml = instanciaXml.evtInfoEmpregador.infoEmpregador.Item as S1000Alteracao;
        itemPopulado.Should().NotBeNull();
        itemXml.Should().NotBeNull();

        // idePeriodo
        itemXml.idePeriodo.iniValid.Should().Be(itemPopulado.idePeriodo.iniValid);
        itemXml.idePeriodo.fimValid.Should().Be(itemPopulado.idePeriodo.fimValid);

        // infoCadastro
        itemXml.infoCadastro.classTrib.Should().Be(itemPopulado.infoCadastro.classTrib);
        itemXml.infoCadastro.indCoop.Should().Be(itemPopulado.infoCadastro.indCoop);
        itemXml.infoCadastro.indConstr.Should().Be(itemPopulado.infoCadastro.indConstr);
        itemXml.infoCadastro.indDesFolha.Should().Be(itemPopulado.infoCadastro.indDesFolha);
        itemXml.infoCadastro.indOpcCP.Should().Be(itemPopulado.infoCadastro.indOpcCP);
        itemXml.infoCadastro.indPorte.Should().Be(itemPopulado.infoCadastro.indPorte);
        itemXml.infoCadastro.indOptRegEletron.Should().Be(itemPopulado.infoCadastro.indOptRegEletron);
        itemXml.infoCadastro.indTribFolhaPisCofins.Should().Be(itemPopulado.infoCadastro.indTribFolhaPisCofins);
        itemXml.infoCadastro.dadosIsencao.ideMinLei.Should().Be(itemPopulado.infoCadastro.dadosIsencao.ideMinLei);
        itemXml.infoCadastro.dadosIsencao.nrCertif.Should().Be(itemPopulado.infoCadastro.dadosIsencao.nrCertif);
        itemXml.infoCadastro.dadosIsencao.dtEmisCertif.Should().BeSameDateAs(itemPopulado.infoCadastro.dadosIsencao.dtEmisCertif);
        itemXml.infoCadastro.dadosIsencao.dtVencCertif.Should().BeSameDateAs(itemPopulado.infoCadastro.dadosIsencao.dtVencCertif);
        itemXml.infoCadastro.dadosIsencao.dtDou?.Should().BeSameDateAs(itemPopulado.infoCadastro.dadosIsencao.dtDou.Value);
        itemXml.infoCadastro.dadosIsencao.pagDou.Should().Be(itemPopulado.infoCadastro.dadosIsencao.pagDou);

        // novaValidade
        itemXml.novaValidade.iniValid.Should().Be(itemPopulado.novaValidade.iniValid);
        itemXml.novaValidade.fimValid.Should().Be(itemPopulado.novaValidade.fimValid);
    }
    #endregion

    #region Exclusao
    internal static void PreencheCamposExclusao(S1000 evento, string cnpjCpf)
    {
        evento.evtInfoEmpregador = new S1000InfoEmpregador()
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
            infoEmpregador = new S1000InfoEmpregadorAcao()
            {
                Item = new S1000Exclusao()
                {
                    idePeriodo = new IdePeriodo()
                    {
                        iniValid = $"{DateTime.Now:yyyy-MM}",
                    }
                }
            }
        };
    }

    public void ValidaCamposExclusao(S1000 instanciaPopulada, S1000 instanciaXml)
    {
        S1000Exclusao itemPopulado = instanciaPopulada.evtInfoEmpregador.infoEmpregador.Item as S1000Exclusao;
        S1000Exclusao itemXml = instanciaXml.evtInfoEmpregador.infoEmpregador.Item as S1000Exclusao;
        itemPopulado.Should().NotBeNull();
        itemXml.Should().NotBeNull();

        // idePeriodo
        itemXml.idePeriodo.iniValid.Should().Be(itemPopulado.idePeriodo.iniValid);
        itemXml.idePeriodo.fimValid.Should().Be(itemPopulado.idePeriodo.fimValid);
    }
    #endregion
}