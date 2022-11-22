using EficazFramework.SPED.Schemas.EFD_Reinf.v2_01_01;

namespace EficazFramework.SPED.Schemas.EFD_Reinf.Versionamento;

public class R1000Test : BaseEfdReinfTest<R1000>
{
    private int _testNumber = 0;
    private Versao _versao = Versao.v2_01_01;

    [Test]
    [TestCase(Versao.v1_05_01)]
    [TestCase(Versao.v2_01_01)]
    public void TestaInclusao(Versao versao)
    {
        _testNumber = 0;
        _versao = versao;
        InstanciaDesserializada = (R1000 e) => e.Versao = versao;
        ValidationSchemaNamespace = $"http://www.reinf.esocial.gov.br/schemas/evtInfoContribuinte/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v1_05_01 => Resources.Schemas.EFD_Reinf.R1000_v1_05_01,
            Versao.v2_01_01 => Resources.Schemas.EFD_Reinf.R1000_v2_01_01,
            _ => ""
        };
        TestaEvento();
    }


    // BaseEfdReinfTest overrides
    public override void PreencheCampos(R1000 evento)
    {
        evento.Versao = _versao;
        switch (_testNumber)
        {
            case 0:
                PreencheCamposInclusao(evento);
                break;
            case 1:
                PreencheCamposAlteracao(evento);
                break;
            case 2:
                PreencheCamposExclusao(evento);
                break;
        }
    }

    public override void ValidaInstanciasLeituraEscrita(R1000 instanciaPopulada, R1000 instanciaXml)
    {
        // TODO: verifique se os campos de instanciaXml, preenchidos a partir da leitura de um XmlDocument, 
        //       correspondem exatamente aos valores de instanciaPopulada, formado à partir do método
        //       PreencheCampos().


        // ideEvento
        instanciaXml.evtInfoContri.ideEvento.tpAmb.Should().Be(instanciaPopulada.evtInfoContri.ideEvento.tpAmb);
        instanciaXml.evtInfoContri.ideEvento.procEmi.Should().Be(instanciaPopulada.evtInfoContri.ideEvento.procEmi);
        instanciaXml.evtInfoContri.ideEvento.verProc.Should().Be(instanciaPopulada.evtInfoContri.ideEvento.verProc);

        // ideContri
        instanciaXml.evtInfoContri.ideContri.tpInsc.Should().Be(instanciaPopulada.evtInfoContri.ideContri.tpInsc);
        instanciaXml.evtInfoContri.ideContri.nrInsc.Should().Be(instanciaPopulada.evtInfoContri.ideContri.nrInsc);

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
    #region RendimentoIsento-LucrosDistribuidos
    private void PreencheCamposInclusao(R1000 evento)
    {
        evento.evtInfoContri = new()
        {
            ideEvento = new()
            {
                tpAmb = Ambiente.ProducaoRestrita_DadosReais,
                procEmi = EmissorEvento.AppContribuinte,
                verProc = "6.0"
            },
            ideContri = new()
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = "34785515000166"
            },
            infoContri = new()
            {
                Item = new R1000_Inclusao()
                {
                    idePeriodo = new()
                    {
                        iniValid = $"{DateTime.Now:yyyy-MM}",
                        fimValid = $"{DateTime.Now.AddMonths(1):yyyy-MM}"
                    },
                    infoCadastro = new()
                    {
                        classTrib = "99",
                        indEscrituracao = ObrigatoriedadeECD.NaoFaz,
                        indDesoneracao = DesoneracaoCPRB.NaoAplicavel,
                        indAcordoIsenMulta = AcordoInternacionalIsencaoMulta.SemAcordo,
                        indSitPJ = SituacaoPessoaJuridica.Normal,
                        indSitPJSpecified = true,
                        contato = new()
                        {
                            nmCtt = "Pierre de Fermat",
                            cpfCtt = "47363361886",
                            foneFixo = "3535441234",
                            email = "suporte@eficazcs.com.br"
                        },
                        softHouse = new()
                        {
                            cnpjSoftHouse = "34785515000166",
                            nmRazao = "Eficaz Sistemas",
                            telefone = "3535444321",
                            email = "comercial@eficazcs.com.br"
                        }
                    }
                }
            }
        };
    }

    public void ValidaCamposInclusao(R1000 instanciaPopulada, R1000 instanciaXml)
    {
        R1000_Inclusao itemPopulado = instanciaPopulada.evtInfoContri.infoContri.Item as R1000_Inclusao;
        R1000_Inclusao itemXml = instanciaXml.evtInfoContri.infoContri.Item as R1000_Inclusao;
        itemPopulado.Should().NotBeNull();
        itemXml.Should().NotBeNull();

        // idePeriodo
        itemXml.idePeriodo.iniValid.Should().Be(itemPopulado.idePeriodo.iniValid);
        itemXml.idePeriodo.fimValid.Should().Be(itemPopulado.idePeriodo.fimValid);

        // infoCadastro
        itemXml.infoCadastro.classTrib.Should().Be(itemPopulado.infoCadastro.classTrib);
        itemXml.infoCadastro.indEscrituracao.Should().Be(itemPopulado.infoCadastro.indEscrituracao);
        itemXml.infoCadastro.indDesoneracao.Should().Be(itemPopulado.infoCadastro.indDesoneracao);
        itemXml.infoCadastro.indAcordoIsenMulta.Should().Be(itemPopulado.infoCadastro.indAcordoIsenMulta);
        itemXml.infoCadastro.indSitPJ.Should().Be(itemPopulado.infoCadastro.indSitPJ);
        itemXml.infoCadastro.indSitPJSpecified.Should().Be(itemPopulado.infoCadastro.indSitPJSpecified);

        // contato
        itemXml.infoCadastro.contato.nmCtt.Should().Be(itemPopulado.infoCadastro.contato.nmCtt);
        itemXml.infoCadastro.contato.cpfCtt.Should().Be(itemPopulado.infoCadastro.contato.cpfCtt);
        itemXml.infoCadastro.contato.foneFixo.Should().Be(itemPopulado.infoCadastro.contato.foneFixo);
        itemXml.infoCadastro.contato.email.Should().Be(itemPopulado.infoCadastro.contato.email);

        // softHouse
        itemXml.infoCadastro.softHouse.cnpjSoftHouse.Should().Be(itemPopulado.infoCadastro.softHouse.cnpjSoftHouse);
        itemXml.infoCadastro.softHouse.nmRazao.Should().Be(itemPopulado.infoCadastro.softHouse.nmRazao);
        itemXml.infoCadastro.softHouse.telefone.Should().Be(itemPopulado.infoCadastro.softHouse.telefone);
        itemXml.infoCadastro.softHouse.email.Should().Be(itemPopulado.infoCadastro.softHouse.email);
    }
    #endregion

    #region RendimentoTributado
    private void PreencheCamposAlteracao(R1000 evento)
    {
        evento.evtInfoContri = new()
        {
            ideEvento = new()
            {
                tpAmb = Ambiente.ProducaoRestrita_DadosReais,
                procEmi = EmissorEvento.AppContribuinte,
                verProc = "6.0"
            },
            ideContri = new()
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = "34785515000166"
            },
            infoContri = new()
            {
                Item = new R1000_Alteracao()
                {
                    idePeriodo = new()
                    {
                        iniValid = $"{DateTime.Now:yyyy-MM}",
                        fimValid = $"{DateTime.Now.AddMonths(1):yyyy-MM}"
                    },
                    infoCadastro = new()
                    {
                        classTrib = "99",
                        indEscrituracao = ObrigatoriedadeECD.NaoFaz,
                        indDesoneracao = DesoneracaoCPRB.NaoAplicavel,
                        indAcordoIsenMulta = AcordoInternacionalIsencaoMulta.SemAcordo,
                        indSitPJ = SituacaoPessoaJuridica.Normal,
                        indSitPJSpecified = true,
                        contato = new()
                        {
                            nmCtt = "Pierre de Fermat",
                            cpfCtt = "47363361886",
                            foneFixo = "3535441234",
                            email = "suporte@eficazcs.com.br"
                        },
                        softHouse = new()
                        {
                            cnpjSoftHouse = "34785515000166",
                            nmRazao = "Eficaz Sistemas",
                            telefone = "3535444321",
                            email = "comercial@eficazcs.com.br"
                        },
                    },
                    novaValidade = new()
                    {
                        iniValid = $"{DateTime.Now:yyyy-MM}",
                        fimValid = $"{DateTime.Now.AddMonths(1):yyyy-MM}"
                    }
                }
            }
        };
    }

    public void ValidaCamposAlteracao(R1000 instanciaPopulada, R1000 instanciaXml)
    {
        R1000_Alteracao itemPopulado = instanciaPopulada.evtInfoContri.infoContri.Item as R1000_Alteracao;
        R1000_Alteracao itemXml = instanciaXml.evtInfoContri.infoContri.Item as R1000_Alteracao;
        itemPopulado.Should().NotBeNull();
        itemXml.Should().NotBeNull();

        // idePeriodo
        itemXml.idePeriodo.iniValid.Should().Be(itemPopulado.idePeriodo.iniValid);
        itemXml.idePeriodo.fimValid.Should().Be(itemPopulado.idePeriodo.fimValid);

        // infoCadastro
        itemXml.infoCadastro.classTrib.Should().Be(itemPopulado.infoCadastro.classTrib);
        itemXml.infoCadastro.indEscrituracao.Should().Be(itemPopulado.infoCadastro.indEscrituracao);
        itemXml.infoCadastro.indDesoneracao.Should().Be(itemPopulado.infoCadastro.indDesoneracao);
        itemXml.infoCadastro.indAcordoIsenMulta.Should().Be(itemPopulado.infoCadastro.indAcordoIsenMulta);
        itemXml.infoCadastro.indSitPJ.Should().Be(itemPopulado.infoCadastro.indSitPJ);
        itemXml.infoCadastro.indSitPJSpecified.Should().Be(itemPopulado.infoCadastro.indSitPJSpecified);

        // contato
        itemXml.infoCadastro.contato.nmCtt.Should().Be(itemPopulado.infoCadastro.contato.nmCtt);
        itemXml.infoCadastro.contato.cpfCtt.Should().Be(itemPopulado.infoCadastro.contato.cpfCtt);
        itemXml.infoCadastro.contato.foneFixo.Should().Be(itemPopulado.infoCadastro.contato.foneFixo);
        itemXml.infoCadastro.contato.email.Should().Be(itemPopulado.infoCadastro.contato.email);

        // softHouse
        itemXml.infoCadastro.softHouse.cnpjSoftHouse.Should().Be(itemPopulado.infoCadastro.softHouse.cnpjSoftHouse);
        itemXml.infoCadastro.softHouse.nmRazao.Should().Be(itemPopulado.infoCadastro.softHouse.nmRazao);
        itemXml.infoCadastro.softHouse.telefone.Should().Be(itemPopulado.infoCadastro.softHouse.telefone);
        itemXml.infoCadastro.softHouse.email.Should().Be(itemPopulado.infoCadastro.softHouse.email);

        // novaValidade
        itemXml.novaValidade.iniValid.Should().Be(itemPopulado.novaValidade.iniValid);
        itemXml.novaValidade.fimValid.Should().Be(itemPopulado.novaValidade.fimValid);
    }
    #endregion

    #region RendimentoTributadoComDependente
    private void PreencheCamposExclusao(R1000 evento)
    {
        evento.evtInfoContri = new()
        {
            ideEvento = new()
            {
                tpAmb = Ambiente.ProducaoRestrita_DadosReais,
                procEmi = EmissorEvento.AppContribuinte,
                verProc = "6.0"
            },
            ideContri = new()
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = "34785515000166"
            },
            infoContri = new()
            {
                Item = new R1000_Exclusao()
                {
                    idePeriodo = new()
                    {
                        iniValid = $"{DateTime.Now:yyyy-MM}",
                        fimValid = $"{DateTime.Now.AddMonths(1):yyyy-MM}"
                    }
                }
            }
        };
    }

    public void ValidaCamposExclusao(R1000 instanciaPopulada, R1000 instanciaXml)
    {
        R1000_Exclusao itemPopulado = instanciaPopulada.evtInfoContri.infoContri.Item as R1000_Exclusao;
        R1000_Exclusao itemXml = instanciaXml.evtInfoContri.infoContri.Item as R1000_Exclusao;
        itemPopulado.Should().NotBeNull();
        itemXml.Should().NotBeNull();

        // idePeriodo
        itemXml.idePeriodo.iniValid.Should().Be(itemPopulado.idePeriodo.iniValid);
        itemXml.idePeriodo.fimValid.Should().Be(itemPopulado.idePeriodo.fimValid);
    }
    #endregion
}
