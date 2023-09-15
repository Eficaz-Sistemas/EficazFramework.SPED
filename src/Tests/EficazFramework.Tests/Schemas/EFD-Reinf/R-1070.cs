namespace EficazFramework.SPED.Schemas.EFD_Reinf;

public class R1070Test : BaseEfdReinfTest<R1070>
{
    private int _testNumber = 0;

    [Test]
    [TestCase(Versao.v1_05_01)]
    [TestCase(Versao.v2_01_02)]
    public void ValidaInclusao(Versao versao)
    {
        _testNumber = 0;
        _versao = versao;
        InstanciaDesserializada = (R1070 e) => e.Versao = versao;
        ValidationSchemaNamespace = $"http://www.reinf.esocial.gov.br/schemas/evtTabProcesso/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v1_05_01 => Resources.Schemas.EFD_Reinf.R1070_v1_05_01,
            Versao.v2_01_01 => Resources.Schemas.EFD_Reinf.R1070_v2_01_01,
            Versao.v2_01_02 => Resources.Schemas.EFD_Reinf.R1070_v2_01_02_B,
            _ => Resources.Schemas.EFD_Reinf.R1070_v2_01_02_B
        };
        TestaEvento();
    }


    [Test]
    [TestCase(Versao.v1_05_01)]
    [TestCase(Versao.v2_01_02)]
    public void ValidaAlteracao(Versao versao)
    {
        _testNumber = 1;
        _versao = versao;
        InstanciaDesserializada = (R1070 e) => e.Versao = versao;
        ValidationSchemaNamespace = $"http://www.reinf.esocial.gov.br/schemas/evtTabProcesso/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v1_05_01 => Resources.Schemas.EFD_Reinf.R1070_v1_05_01,
            Versao.v2_01_01 => Resources.Schemas.EFD_Reinf.R1070_v2_01_01,
            Versao.v2_01_02 => Resources.Schemas.EFD_Reinf.R1070_v2_01_02_B,
            _ => Resources.Schemas.EFD_Reinf.R1070_v2_01_02_B
        };
        TestaEvento();
    }


    [Test]
    [TestCase(Versao.v1_05_01)]
    [TestCase(Versao.v2_01_01)]
    [TestCase(Versao.v2_01_02)]
    public void ValidaExclusao(Versao versao)
    {
        _testNumber = 2;
        _versao = versao;
        InstanciaDesserializada = (R1070 e) => e.Versao = versao;
        ValidationSchemaNamespace = $"http://www.reinf.esocial.gov.br/schemas/evtTabProcesso/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v1_05_01 => Resources.Schemas.EFD_Reinf.R1070_v1_05_01,
            Versao.v2_01_01 => Resources.Schemas.EFD_Reinf.R1070_v2_01_01,
            Versao.v2_01_02 => Resources.Schemas.EFD_Reinf.R1070_v2_01_02_B,
            _ => Resources.Schemas.EFD_Reinf.R1070_v2_01_02_B
        };
        TestaEvento();
    }


    // BaseEfdReinfTest overrides
    public override void PreencheCampos(R1070 evento)
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

    public override void ValidaInstanciasLeituraEscrita(R1070 instanciaPopulada, R1070 instanciaXml)
    {
        // TODO: verifique se os campos de instanciaXml, preenchidos a partir da leitura de um XmlDocument, 
        //       correspondem exatamente aos valores de instanciaPopulada, formado à partir do método
        //       PreencheCampos().


        // ideEvento
        instanciaXml.evtTabProcesso.ideEvento.tpAmb.Should().Be(instanciaPopulada.evtTabProcesso.ideEvento.tpAmb);
        instanciaXml.evtTabProcesso.ideEvento.procEmi.Should().Be(instanciaPopulada.evtTabProcesso.ideEvento.procEmi);
        instanciaXml.evtTabProcesso.ideEvento.verProc.Should().Be(instanciaPopulada.evtTabProcesso.ideEvento.verProc);

        // ideContri
        instanciaXml.evtTabProcesso.ideContri.tpInsc.Should().Be(instanciaPopulada.evtTabProcesso.ideContri.tpInsc);
        instanciaXml.evtTabProcesso.ideContri.nrInsc.Should().Be(instanciaPopulada.evtTabProcesso.ideContri.nrInsc);

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
    internal static void PreencheCamposInclusao(R1070 evento, string cnpjCpf)
    {
        evento.evtTabProcesso = new R1070EventoTabProcesso()
        {
            ideEvento = new IdentificacaoEvento()
            {
                tpAmb = Ambiente.ProducaoRestrita_DadosReais,
                procEmi = EmissorEvento.AppContribuinte,
                verProc = "2.2"
            },
            ideContri = new IdentificacaoContribuinte()
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = cnpjCpf.Substring(0, 8)
            },
            infoProcesso = new R1070InfoProcesso()
            {
                Item = new R1070Inclusao()
                {
                    ideProcesso = new R1070IdentificacaoProcesso()
                    {
                        tpProc = TipoProcesso.Administrativo,
                        nrProc = "1234",
                        iniValid = $"{DateTime.Now.AddMonths(-1):yyyy-MM}",
                        infoSusp = new System.Collections.Generic.List<R1070IdentificacaoProcessoInfoSusp>
                        {
                            new R1070IdentificacaoProcessoInfoSusp()
                            {
                            codSusp = "1",
                            indSusp = "01",
                            dtDecisao = DateTime.Now.AddYears(-1),
                            indDeposito = "S"
                            }
                        },
                        dadosProcJud = new R1070IdentificacaoProcessoDadosProcJud()
                        {
                             codMunic = "3129707",
                             idVara = "1",
                             ufVara = "MG"
                        }
                    }
                }
            }
        };
        if (evento.Versao == Versao.v1_05_01)
        {
            ((R1070Inclusao)evento.evtTabProcesso.infoProcesso.Item).ideProcesso.indAutoria = IndicadorAuditoria.Contribuinte;
            ((R1070Inclusao)evento.evtTabProcesso.infoProcesso.Item).ideProcesso.indAutoriaSpecified = true;
        }
    }

    public void ValidaCamposInclusao(R1070 instanciaPopulada, R1070 instanciaXml)
    {
        R1070Inclusao itemPopulado = instanciaPopulada.evtTabProcesso.infoProcesso.Item as R1070Inclusao;
        R1070Inclusao itemXml = instanciaXml.evtTabProcesso.infoProcesso.Item as R1070Inclusao;
        itemPopulado.Should().NotBeNull();
        itemXml.Should().NotBeNull();

        // ideProcesso
        itemXml.ideProcesso.iniValid.Should().Be(itemPopulado.ideProcesso.iniValid);
        itemXml.ideProcesso.fimValid.Should().Be(itemPopulado.ideProcesso.fimValid);
        itemXml.ideProcesso.tpProc.Should().Be(itemPopulado.ideProcesso.tpProc);
        itemXml.ideProcesso.nrProc.Should().Be(itemPopulado.ideProcesso.nrProc);
        itemXml.ideProcesso.dadosProcJud.codMunic.Should().Be(itemPopulado.ideProcesso.dadosProcJud.codMunic);
        itemXml.ideProcesso.dadosProcJud.idVara.Should().Be(itemPopulado.ideProcesso.dadosProcJud.idVara);
        itemXml.ideProcesso.dadosProcJud.ufVara.Should().Be(itemPopulado.ideProcesso.dadosProcJud.ufVara);
    }
    #endregion

    #region Alteracao
    internal static void PreencheCamposAlteracao(R1070 evento, string cnpjCpf)
    {
        evento.evtTabProcesso = new R1070EventoTabProcesso()
        {
            ideEvento = new IdentificacaoEvento()
            {
                tpAmb = Ambiente.ProducaoRestrita_DadosReais,
                procEmi = EmissorEvento.AppContribuinte,
                verProc = "2.2"
            },
            ideContri = new IdentificacaoContribuinte()
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = cnpjCpf.Substring(0, 8)
            },
            infoProcesso = new R1070InfoProcesso()
            {
                Item = new R1070Alteracao()
                {
                    ideProcesso = new R1070IdentificacaoProcesso()
                    {
                        tpProc = TipoProcesso.Administrativo,
                        nrProc = "1234",
                        iniValid = $"{DateTime.Now.AddMonths(-1):yyyy-MM}",
                        infoSusp = new System.Collections.Generic.List<R1070IdentificacaoProcessoInfoSusp>
                        {
                            new R1070IdentificacaoProcessoInfoSusp()
                            {
                            codSusp = "1",
                            indSusp = "01",
                            dtDecisao = DateTime.Now.AddYears(-1),
                            indDeposito = "S"
                            }
                        },
                        dadosProcJud = new R1070IdentificacaoProcessoDadosProcJud()
                        {
                            codMunic = "3129707",
                            idVara = "1",
                            ufVara = "MG"
                        }
                    },
                    novaValidade = new IdentificacaoPeriodo()
                    {
                        iniValid = $"{DateTime.Now:yyyy-MM}",
                    }
                }
            }
        };
        if (evento.Versao == Versao.v1_05_01)
        {
            ((R1070Alteracao)evento.evtTabProcesso.infoProcesso.Item).ideProcesso.indAutoria = IndicadorAuditoria.Contribuinte;
            ((R1070Alteracao)evento.evtTabProcesso.infoProcesso.Item).ideProcesso.indAutoriaSpecified = true;
        }
    }

    public void ValidaCamposAlteracao(R1070 instanciaPopulada, R1070 instanciaXml)
    {
        R1070Alteracao itemPopulado = instanciaPopulada.evtTabProcesso.infoProcesso.Item as R1070Alteracao;
        R1070Alteracao itemXml = instanciaXml.evtTabProcesso.infoProcesso.Item as R1070Alteracao;
        itemPopulado.Should().NotBeNull();
        itemXml.Should().NotBeNull();

        // ideProcesso
        itemXml.ideProcesso.iniValid.Should().Be(itemPopulado.ideProcesso.iniValid);
        itemXml.ideProcesso.fimValid.Should().Be(itemPopulado.ideProcesso.fimValid);

        // ideProcesso
        itemXml.ideProcesso.iniValid.Should().Be(itemPopulado.ideProcesso.iniValid);
        itemXml.ideProcesso.fimValid.Should().Be(itemPopulado.ideProcesso.fimValid);
        itemXml.ideProcesso.tpProc.Should().Be(itemPopulado.ideProcesso.tpProc);
        itemXml.ideProcesso.nrProc.Should().Be(itemPopulado.ideProcesso.nrProc);
        itemXml.ideProcesso.dadosProcJud.codMunic.Should().Be(itemPopulado.ideProcesso.dadosProcJud.codMunic);
        itemXml.ideProcesso.dadosProcJud.idVara.Should().Be(itemPopulado.ideProcesso.dadosProcJud.idVara);
        itemXml.ideProcesso.dadosProcJud.ufVara.Should().Be(itemPopulado.ideProcesso.dadosProcJud.ufVara);
    }
    #endregion

    #region Exclusao
    internal static void PreencheCamposExclusao(R1070 evento, string cnpjCpf)
    {
        evento.evtTabProcesso = new R1070EventoTabProcesso()
        {
            ideEvento = new IdentificacaoEvento()
            {
                tpAmb = Ambiente.ProducaoRestrita_DadosReais,
                procEmi = EmissorEvento.AppContribuinte,
                verProc = "2.2"
            },
            ideContri = new IdentificacaoContribuinte()
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = cnpjCpf.Substring(0, 8)
            },
            infoProcesso = new R1070InfoProcesso()
            {
                Item = new R1070Exclusao()
                {
                    ideProcesso = new R1070IdentificacaoProcesso()
                    {
                        tpProc = TipoProcesso.Administrativo,
                        nrProc = "1234",
                        iniValid = $"{DateTime.Now:yyyy-MM}",
                    }
                }
            }
        };
    }

    public void ValidaCamposExclusao(R1070 instanciaPopulada, R1070 instanciaXml)
    {
        R1070Exclusao itemPopulado = instanciaPopulada.evtTabProcesso.infoProcesso.Item as R1070Exclusao;
        R1070Exclusao itemXml = instanciaXml.evtTabProcesso.infoProcesso.Item as R1070Exclusao;
        itemPopulado.Should().NotBeNull();
        itemXml.Should().NotBeNull();

        // ideProcesso
        itemXml.ideProcesso.iniValid.Should().Be(itemPopulado.ideProcesso.iniValid);
        itemXml.ideProcesso.fimValid.Should().Be(itemPopulado.ideProcesso.fimValid);
    }
    #endregion
}