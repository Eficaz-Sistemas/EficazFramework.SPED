﻿namespace EficazFramework.SPED.Schemas.EFD_Reinf;

public class R1000Test : BaseEfdReinfTest<R1000>
{
    private int _testNumber = 0;

    [Test]
    [TestCase(Versao.v1_05_01)]
    [TestCase(Versao.v2_01_01)]
    public void ValidaInclusao(Versao versao)
    {
        _testNumber = 0;
        _versao = versao;
        InstanciaDesserializada = (R1000 e) => e.Versao = versao;
        ValidationSchemaNamespace = $"http://www.reinf.esocial.gov.br/schemas/evtInfoContribuinte/{versao}";
        switch (versao)
        {
            case Versao.v1_05_01:
                ValidationSchema = Resources.Schemas.EFD_Reinf.R1000_v1_05_01;
                break;

            case Versao.v2_01_01:
                ValidationSchema = Resources.Schemas.EFD_Reinf.R1000_v2_01_01;
                break;
        }
        TestaEvento();
    }


    [Test]
    [TestCase(Versao.v1_05_01)]
    [TestCase(Versao.v2_01_01)]
    public void ValidaAlteracao(Versao versao)
    {
        _testNumber = 1;
        _versao = versao;
        InstanciaDesserializada = (R1000 e) => e.Versao = versao;
        ValidationSchemaNamespace = $"http://www.reinf.esocial.gov.br/schemas/evtInfoContribuinte/{versao}";
        switch (versao)
        {
            case Versao.v1_05_01:
                ValidationSchema = Resources.Schemas.EFD_Reinf.R1000_v1_05_01;
                break;

            case Versao.v2_01_01:
                ValidationSchema = Resources.Schemas.EFD_Reinf.R1000_v2_01_01;
                break;
        }
        TestaEvento();
    }


    [Test]
    [TestCase(Versao.v1_05_01)]
    [TestCase(Versao.v2_01_01)]
    public void ValidaExclusao(Versao versao)
    {
        _testNumber = 2;
        _versao = versao;
        InstanciaDesserializada = (R1000 e) => e.Versao = versao;
        ValidationSchemaNamespace = $"http://www.reinf.esocial.gov.br/schemas/evtInfoContribuinte/{versao}";
        switch (versao)
        {
            case Versao.v1_05_01:
                ValidationSchema = Resources.Schemas.EFD_Reinf.R1000_v1_05_01;
                break;

            case Versao.v2_01_01:
                ValidationSchema = Resources.Schemas.EFD_Reinf.R1000_v2_01_01;
                break;
        }
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
    #region Inclusao
    internal static void PreencheCamposInclusao(R1000 evento)
    {
        evento.evtInfoContri = new R1000_EventoInfoContribuinte()
        {
            ideEvento = new ReinfEvtIdeEvento()
            {
                tpAmb = Ambiente.ProducaoRestrita_DadosReais,
                procEmi = EmissorEvento.AppContribuinte,
                verProc = "2.2"
            },
            ideContri = new ReinfEvtIdeContri()
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = _cnpj.Substring(0, 8)
            },
            infoContri = new R1000_InfoContri()
            {
                Item = new R1000_Inclusao()
                {
                    idePeriodo = new ReinfEvtIdePeriodo()
                    {
                        iniValid = $"{DateTime.Now.AddMonths(-1):yyyy-MM}"
                    },
                    infoCadastro = new R1000_InfoCadastro()
                    {
                        classTrib = "99",
                        indEscrituracao = ObrigatoriedadeECD.EntregaECD,
                        indDesoneracao = DesoneracaoCPRB.NaoAplicavel,
                        indAcordoIsenMulta = AcordoInternacionalIsencaoMulta.SemAcordo,
                        indSitPJ = SituacaoPessoaJuridica.Normal,
                        indSitPJSpecified = true,
                        contato = new R1000_InfoCadastro_Contato()
                        {
                            nmCtt = "Pierre de Fermat",
                            cpfCtt = "47363361886",
                            foneFixo = "3535441234",
                            email = "suporte@eficazcs.com.br"
                        },
                        softHouse = new R1000_InfoCadastro_SoftwareHouse()
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

    #region Alteracao
    internal static void PreencheCamposAlteracao(R1000 evento)
    {
        evento.evtInfoContri = new R1000_EventoInfoContribuinte()
        {
            ideEvento = new ReinfEvtIdeEvento()
            {
                tpAmb = Ambiente.ProducaoRestrita_DadosReais,
                procEmi = EmissorEvento.AppContribuinte,
                verProc = "2.2"
            },
            ideContri = new ReinfEvtIdeContri()
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = _cnpj.Substring(0, 8)
            },
            infoContri = new R1000_InfoContri()
            {
                Item = new R1000_Alteracao()
                {
                    idePeriodo = new ReinfEvtIdePeriodo()
                    {
                        iniValid = $"{DateTime.Now.AddMonths(-1):yyyy-MM}"
                    },
                    infoCadastro = new R1000_InfoCadastro()
                    {
                        classTrib = "99",
                        indEscrituracao = ObrigatoriedadeECD.EntregaECD,
                        indDesoneracao = DesoneracaoCPRB.NaoAplicavel,
                        indAcordoIsenMulta = AcordoInternacionalIsencaoMulta.SemAcordo,
                        indSitPJ = SituacaoPessoaJuridica.Normal,
                        indSitPJSpecified = true,
                        contato = new R1000_InfoCadastro_Contato()
                        {
                            nmCtt = "Pierre de Fermat",
                            cpfCtt = "47363361886",
                            foneFixo = "3535441234",
                            email = "suporte@eficazcs.com.br"
                        },
                        softHouse = new R1000_InfoCadastro_SoftwareHouse(),
                    },
                    novaValidade = new ReinfEvtIdePeriodo()
                    {
                        iniValid = $"{DateTime.Now:yyyy-MM}",
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

    #region Exclusao
    internal static void PreencheCamposExclusao(R1000 evento)
    {
        evento.evtInfoContri = new R1000_EventoInfoContribuinte()
        {
            ideEvento = new ReinfEvtIdeEvento()
            {
                tpAmb = Ambiente.ProducaoRestrita_DadosReais,
                procEmi = EmissorEvento.AppContribuinte,
                verProc = "2.2"
            },
            ideContri = new ReinfEvtIdeContri()
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = _cnpj.Substring(0, 8)
            },
            infoContri = new R1000_InfoContri()
            {
                Item = new R1000_Exclusao()
                {
                    idePeriodo = new ReinfEvtIdePeriodo()
                    {
                        iniValid = $"{DateTime.Now:yyyy-MM}",
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