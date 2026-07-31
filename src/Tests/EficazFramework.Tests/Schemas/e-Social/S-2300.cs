namespace EficazFramework.SPED.Schemas.eSocial;

public class S2300Test : BaseESocialTest<S2300>
{
    private int _testNumber = 0;

    [Test]
    [TestCase(Versao.v_S_01_02_00)]
    [TestCase(Versao.v_S_01_03_00)]
    public async Task Valida(Versao versao)
    {
        _testNumber = 0;
        _versao = versao;
        ValidationSchemaNamespace = $"http://www.esocial.gov.br/schema/evt/evtTSVInicio/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v_S_01_03_00 => Resources.Schemas.eSocial.S2300_v_S_01_03_01,
            _ => Resources.Schemas.eSocial.S2300_v_S_01_02_01
        };
        await TestaEvento();
    }

    [Test]
    public async Task Read_v_S_01_03_00()
    {
        var evento = await Evento.ReadAsync(Resources.Samples.eSocial.S2300_v_S_01_03_00);
        evento.Should().NotBeNull();
        evento.Should().BeOfType<S2300>();
        evento.Versao.Should().Be(Versao.v_S_01_03_00);
        
        var evtTSV = evento as S2300;
        evtTSV.Should().NotBeNull();
        
        evtTSV.evtTSVInicio.Id.Should().Be("ID1106080250000002026072916114600002");
        evtTSV.evtTSVInicio.ideEvento.indRetif.Should().Be(IndicadorRetificacao.Original);
        evtTSV.evtTSVInicio.ideEvento.tpAmb.Should().Be(Ambiente.ProducaoRestrita_DadosReais);
        evtTSV.evtTSVInicio.ideEvento.procEmi.Should().Be(EmissorEvento.AppEmpregador);
        evtTSV.evtTSVInicio.ideEvento.verProc.Should().Be("2.2");
        
        evtTSV.evtTSVInicio.ideEmpregador.tpInsc.Should().Be(PersonalidadeJuridica.CNPJ);
        evtTSV.evtTSVInicio.ideEmpregador.nrInsc.Should().Be("10608025000126");
        
        evtTSV.evtTSVInicio.trabalhador.cpfTrab.Should().Be("12345678901");
        evtTSV.evtTSVInicio.trabalhador.nmTrab.Should().Be("Fulano de Tal");
        evtTSV.evtTSVInicio.trabalhador.sexo.Should().Be(Sexo.Masculino);
        evtTSV.evtTSVInicio.trabalhador.racaCor.Should().Be(RacaCor.Branca);
        evtTSV.evtTSVInicio.trabalhador.estCiv.Should().Be(EstadoCivil.Solteiro);
        evtTSV.evtTSVInicio.trabalhador.grauInstr.Should().Be(GrauInstrucao.Analfabeto);
        evtTSV.evtTSVInicio.trabalhador.nmSoc.Should().Be("Fulano");
        
        evtTSV.evtTSVInicio.infoTSVInicio.cadIni.Should().Be(SimNaoString.Sim);
        evtTSV.evtTSVInicio.infoTSVInicio.matricula.Should().Be("12345");
        evtTSV.evtTSVInicio.infoTSVInicio.codCateg.Should().Be("721");
        evtTSV.evtTSVInicio.infoTSVInicio.dtInicio.Should().Be(new System.DateTime(2023, 1, 1));
        evtTSV.evtTSVInicio.infoTSVInicio.natAtividade.Should().Be(NaturezaAtividade.Urbano);
    }

    public override void PreencheCampos(S2300 evento)
    {
        evento.Versao = _versao;
        evento.evtTSVInicio = new S2300EvtTSVInicio()
        {
            ideEvento = new IdeEventoNaoPeriodico()
            {
                indRetif = IndicadorRetificacao.Original,
                tpAmb = Ambiente.ProducaoRestrita_DadosReais,
                procEmi = EmissorEvento.AppEmpregador,
                verProc = "2.2"
            },
            ideEmpregador = new Empregador()
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = CnpjCpf
            },
            trabalhador = new S2300Trabalhador()
            {
                cpfTrab = "12345678901",
                nmTrab = "Fulano de Tal",
                sexo = Sexo.Masculino,
                racaCor = RacaCor.Branca,
                estCiv = EstadoCivil.Solteiro,
                grauInstr = GrauInstrucao.Analfabeto,
                nmSoc = "Fulano",
                nascimento = new S2300Nascimento()
                {
                    dtNascto = new DateTime(1980, 1, 1),
                    paisNascto = "105",
                    paisNac = "105"
                },
                endereco = new S2300Endereco()
                {
                    brasil = new EnderecoBrasileiro()
                    {
                        tpLograd = "Rua",
                        dscLograd = "Rua de Teste",
                        nrLograd = "123",
                        bairro = "Centro",
                        cep = "12345678",
                        codMunic = "1234567",
                        uf = UFCadastro.SP
                    }
                },
                trabImig = new S2300TrabImig()
                {
                    tmpResid = 1,
                    condIng = 2
                },
                infoDeficiencia = new S2300InfoDeficiencia()
                {
                    defFisica = SimNaoString.Nao,
                    defVisual = SimNaoString.Nao,
                    defAuditiva = SimNaoString.Nao,
                    defMental = SimNaoString.Nao,
                    defIntelectual = SimNaoString.Nao,
                    reabReadap = SimNaoString.Nao,
                    observacao = "Obs"
                },
                dependente = new System.Collections.Generic.List<S2300Dependente>()
                {
                    new S2300Dependente()
                    {
                        tpDep = "01",
                        nmDep = "Dependente 1",
                        dtNascto = new DateTime(2010, 1, 1),
                        cpfDep = "09876543210",
                        depIRRF = SimNaoString.Sim,
                        depSF = SimNaoString.Sim,
                        incTrab = SimNaoString.Nao,
                        descrDep = "Descricao"
                    }
                },
                contato = new S2300Contato()
                {
                    fonePrinc = "11999999999",
                    emailPrinc = "teste@teste.com"
                }
            },
            infoTSVInicio = new S2300InfoTSVInicio()
            {
                cadIni = SimNaoString.Sim,
                matricula = "12345",
                codCateg = "721",
                dtInicio = new DateTime(2023, 1, 1),
                nrProcTrab = "12345678901234567890",
                natAtividade = NaturezaAtividade.Urbano,
                infoComplementares = new S2300InfoComplementares()
                {
                    cargoFuncao = new S2300CargoFuncao()
                    {
                        nmCargo = "Diretor",
                        CBOCargo = "123456",
                        nmFuncao = "Diretor Financeiro",
                        CBOFuncao = "123456"
                    },
                    remuneracao = new S2300Remuneracao()
                    {
                        vrSalFx = 10000.00m,
                        undSalFixo = 5,
                        dscSalVar = "Bonus"
                    },
                    FGTS = new S2300FGTS()
                    {
                        dtOpcFGTS = new DateTime(2023, 1, 1)
                    },
                    infoDirigenteSindical = new S2300InfoDirigenteSindical()
                    {
                        categOrig = "101",
                        tpInsc = 1,
                        nrInsc = "12345678000123",
                        dtAdmOrig = new DateTime(2020, 1, 1),
                        matricOrig = "123",
                        tpRegTrab = VinculoTrabalhista.CLT,
                        tpRegPrev = RegimePrevidenciario.RGPS
                    },
                    infoTrabCedido = new S2300InfoTrabCedido()
                    {
                        categOrig = "101",
                        cnpjCednt = "12345678000123",
                        matricCed = "123",
                        dtAdmCed = new DateTime(2020, 1, 1),
                        tpRegTrab = VinculoTrabalhista.CLT,
                        tpRegPrev = RegimePrevidenciario.RGPS
                    },
                    infoMandElet = new S2300InfoMandElet()
                    {
                        categOrig = "101",
                        cnpjOrig = "12345678000123",
                        matricOrig = "123",
                        dtExercOrig = new DateTime(2020, 1, 1),
                        indRemunCargo = SimNaoString.Sim,
                        tpRegTrab = VinculoTrabalhista.CLT,
                        tpRegPrev = RegimePrevidenciario.RGPS
                    },
                    infoEstagiario = new S2300InfoEstagiario()
                    {
                        natEstagio = "O",
                        nivEstagio = 1,
                        areaAtuacao = "TI",
                        nrApol = "12345",
                        dtPrevTerm = new DateTime(2024, 1, 1),
                        instEnsino = new S2300InstEnsino()
                        {
                            cnpjInstEnsino = "12345678000123",
                            nmRazao = "Inst Ensino",
                            dscLograd = "Rua",
                            nrLograd = "123",
                            bairro = "Centro",
                            cep = "12345678",
                            codMunic = "1234567",
                            uf = "SP"
                        },
                        ageIntegracao = new S2300AgeIntegracao()
                        {
                            cnpjAgntInteg = "12345678000123"
                        },
                        supervisorEstagio = new S2300SupervisorEstagio()
                        {
                            cpfSupervisor = "12345678901"
                        }
                    },
                    localTrabGeral = new S2300LocalTrabalho()
                    {
                        tpInsc = 1,
                        nrInsc = "12345678000123",
                        descComp = "Local 1"
                    }
                },
                mudancaCPF = new S2300MudancaCPF()
                {
                    cpfAnt = "12345678901",
                    matricAnt = "12345",
                    dtAltCPF = new DateTime(2023, 1, 1),
                    observacao = "Obs"
                },
                afastamento = new S2300Afastamento()
                {
                    dtIniAfast = new DateTime(2023, 1, 1),
                    codMotAfast = "01"
                },
                termino = new S2300Termino()
                {
                    dtTerm = new DateTime(2023, 12, 31)
                }
            }
        };
    }

    public override void ValidaInstanciasLeituraEscrita(S2300 instanciaPopulada, S2300 instanciaXml)
    {
        // ideEvento
        instanciaXml.evtTSVInicio.ideEvento.indRetif.Should().Be(instanciaPopulada.evtTSVInicio.ideEvento.indRetif);
        instanciaXml.evtTSVInicio.ideEvento.tpAmb.Should().Be(instanciaPopulada.evtTSVInicio.ideEvento.tpAmb);
        instanciaXml.evtTSVInicio.ideEvento.procEmi.Should().Be(instanciaPopulada.evtTSVInicio.ideEvento.procEmi);
        instanciaXml.evtTSVInicio.ideEvento.verProc.Should().Be(instanciaPopulada.evtTSVInicio.ideEvento.verProc);

        // ideEmpregador
        instanciaXml.evtTSVInicio.ideEmpregador.tpInsc.Should().Be(instanciaPopulada.evtTSVInicio.ideEmpregador.tpInsc);
        instanciaXml.evtTSVInicio.ideEmpregador.nrInsc.Should().Be(instanciaPopulada.evtTSVInicio.ideEmpregador.nrInsc);

        // trabalhador
        instanciaXml.evtTSVInicio.trabalhador.cpfTrab.Should().Be(instanciaPopulada.evtTSVInicio.trabalhador.cpfTrab);
        instanciaXml.evtTSVInicio.trabalhador.nmTrab.Should().Be(instanciaPopulada.evtTSVInicio.trabalhador.nmTrab);
        instanciaXml.evtTSVInicio.trabalhador.sexo.Should().Be(instanciaPopulada.evtTSVInicio.trabalhador.sexo);
        instanciaXml.evtTSVInicio.trabalhador.racaCor.Should().Be(instanciaPopulada.evtTSVInicio.trabalhador.racaCor);
        instanciaXml.evtTSVInicio.trabalhador.estCiv.Should().Be(instanciaPopulada.evtTSVInicio.trabalhador.estCiv);
        instanciaXml.evtTSVInicio.trabalhador.grauInstr.Should().Be(instanciaPopulada.evtTSVInicio.trabalhador.grauInstr);
        instanciaXml.evtTSVInicio.trabalhador.nmSoc.Should().Be(instanciaPopulada.evtTSVInicio.trabalhador.nmSoc);

        instanciaXml.evtTSVInicio.trabalhador.nascimento.dtNascto.Should().Be(instanciaPopulada.evtTSVInicio.trabalhador.nascimento.dtNascto);
        instanciaXml.evtTSVInicio.trabalhador.nascimento.paisNascto.Should().Be(instanciaPopulada.evtTSVInicio.trabalhador.nascimento.paisNascto);
        instanciaXml.evtTSVInicio.trabalhador.nascimento.paisNac.Should().Be(instanciaPopulada.evtTSVInicio.trabalhador.nascimento.paisNac);

        instanciaXml.evtTSVInicio.trabalhador.endereco.brasil.tpLograd.Should().Be(instanciaPopulada.evtTSVInicio.trabalhador.endereco.brasil.tpLograd);
        instanciaXml.evtTSVInicio.trabalhador.endereco.brasil.dscLograd.Should().Be(instanciaPopulada.evtTSVInicio.trabalhador.endereco.brasil.dscLograd);
        instanciaXml.evtTSVInicio.trabalhador.endereco.brasil.nrLograd.Should().Be(instanciaPopulada.evtTSVInicio.trabalhador.endereco.brasil.nrLograd);
        instanciaXml.evtTSVInicio.trabalhador.endereco.brasil.bairro.Should().Be(instanciaPopulada.evtTSVInicio.trabalhador.endereco.brasil.bairro);
        instanciaXml.evtTSVInicio.trabalhador.endereco.brasil.cep.Should().Be(instanciaPopulada.evtTSVInicio.trabalhador.endereco.brasil.cep);
        instanciaXml.evtTSVInicio.trabalhador.endereco.brasil.codMunic.Should().Be(instanciaPopulada.evtTSVInicio.trabalhador.endereco.brasil.codMunic);
        instanciaXml.evtTSVInicio.trabalhador.endereco.brasil.uf.Should().Be(instanciaPopulada.evtTSVInicio.trabalhador.endereco.brasil.uf);

        instanciaXml.evtTSVInicio.trabalhador.trabImig.tmpResid.Should().Be(instanciaPopulada.evtTSVInicio.trabalhador.trabImig.tmpResid);
        instanciaXml.evtTSVInicio.trabalhador.trabImig.condIng.Should().Be(instanciaPopulada.evtTSVInicio.trabalhador.trabImig.condIng);

        instanciaXml.evtTSVInicio.trabalhador.infoDeficiencia.defFisica.Should().Be(instanciaPopulada.evtTSVInicio.trabalhador.infoDeficiencia.defFisica);
        instanciaXml.evtTSVInicio.trabalhador.infoDeficiencia.defVisual.Should().Be(instanciaPopulada.evtTSVInicio.trabalhador.infoDeficiencia.defVisual);
        instanciaXml.evtTSVInicio.trabalhador.infoDeficiencia.defAuditiva.Should().Be(instanciaPopulada.evtTSVInicio.trabalhador.infoDeficiencia.defAuditiva);
        instanciaXml.evtTSVInicio.trabalhador.infoDeficiencia.defMental.Should().Be(instanciaPopulada.evtTSVInicio.trabalhador.infoDeficiencia.defMental);
        instanciaXml.evtTSVInicio.trabalhador.infoDeficiencia.defIntelectual.Should().Be(instanciaPopulada.evtTSVInicio.trabalhador.infoDeficiencia.defIntelectual);
        instanciaXml.evtTSVInicio.trabalhador.infoDeficiencia.reabReadap.Should().Be(instanciaPopulada.evtTSVInicio.trabalhador.infoDeficiencia.reabReadap);
        instanciaXml.evtTSVInicio.trabalhador.infoDeficiencia.observacao.Should().Be(instanciaPopulada.evtTSVInicio.trabalhador.infoDeficiencia.observacao);

        instanciaXml.evtTSVInicio.trabalhador.dependente[0].tpDep.Should().Be(instanciaPopulada.evtTSVInicio.trabalhador.dependente[0].tpDep);
        instanciaXml.evtTSVInicio.trabalhador.dependente[0].nmDep.Should().Be(instanciaPopulada.evtTSVInicio.trabalhador.dependente[0].nmDep);
        instanciaXml.evtTSVInicio.trabalhador.dependente[0].dtNascto.Should().Be(instanciaPopulada.evtTSVInicio.trabalhador.dependente[0].dtNascto);
        instanciaXml.evtTSVInicio.trabalhador.dependente[0].cpfDep.Should().Be(instanciaPopulada.evtTSVInicio.trabalhador.dependente[0].cpfDep);
        instanciaXml.evtTSVInicio.trabalhador.dependente[0].depIRRF.Should().Be(instanciaPopulada.evtTSVInicio.trabalhador.dependente[0].depIRRF);
        instanciaXml.evtTSVInicio.trabalhador.dependente[0].depSF.Should().Be(instanciaPopulada.evtTSVInicio.trabalhador.dependente[0].depSF);
        instanciaXml.evtTSVInicio.trabalhador.dependente[0].incTrab.Should().Be(instanciaPopulada.evtTSVInicio.trabalhador.dependente[0].incTrab);
        instanciaXml.evtTSVInicio.trabalhador.dependente[0].descrDep.Should().Be(instanciaPopulada.evtTSVInicio.trabalhador.dependente[0].descrDep);

        instanciaXml.evtTSVInicio.trabalhador.contato.fonePrinc.Should().Be(instanciaPopulada.evtTSVInicio.trabalhador.contato.fonePrinc);
        instanciaXml.evtTSVInicio.trabalhador.contato.emailPrinc.Should().Be(instanciaPopulada.evtTSVInicio.trabalhador.contato.emailPrinc);

        // infoTSVInicio
        instanciaXml.evtTSVInicio.infoTSVInicio.cadIni.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.cadIni);
        instanciaXml.evtTSVInicio.infoTSVInicio.matricula.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.matricula);
        instanciaXml.evtTSVInicio.infoTSVInicio.codCateg.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.codCateg);
        instanciaXml.evtTSVInicio.infoTSVInicio.dtInicio.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.dtInicio);
        instanciaXml.evtTSVInicio.infoTSVInicio.nrProcTrab.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.nrProcTrab);
        instanciaXml.evtTSVInicio.infoTSVInicio.natAtividade.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.natAtividade);

        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.cargoFuncao.nmCargo.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.cargoFuncao.nmCargo);
        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.cargoFuncao.CBOCargo.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.cargoFuncao.CBOCargo);
        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.cargoFuncao.nmFuncao.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.cargoFuncao.nmFuncao);
        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.cargoFuncao.CBOFuncao.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.cargoFuncao.CBOFuncao);

        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.remuneracao.vrSalFx.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.remuneracao.vrSalFx);
        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.remuneracao.undSalFixo.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.remuneracao.undSalFixo);
        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.remuneracao.dscSalVar.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.remuneracao.dscSalVar);

        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.FGTS.dtOpcFGTS.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.FGTS.dtOpcFGTS);

        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.infoDirigenteSindical.categOrig.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.infoDirigenteSindical.categOrig);
        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.infoDirigenteSindical.tpInsc.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.infoDirigenteSindical.tpInsc);
        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.infoDirigenteSindical.nrInsc.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.infoDirigenteSindical.nrInsc);
        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.infoDirigenteSindical.dtAdmOrig.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.infoDirigenteSindical.dtAdmOrig);
        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.infoDirigenteSindical.matricOrig.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.infoDirigenteSindical.matricOrig);
        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.infoDirigenteSindical.tpRegTrab.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.infoDirigenteSindical.tpRegTrab);
        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.infoDirigenteSindical.tpRegPrev.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.infoDirigenteSindical.tpRegPrev);

        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.infoTrabCedido.categOrig.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.infoTrabCedido.categOrig);
        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.infoTrabCedido.cnpjCednt.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.infoTrabCedido.cnpjCednt);
        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.infoTrabCedido.matricCed.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.infoTrabCedido.matricCed);
        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.infoTrabCedido.dtAdmCed.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.infoTrabCedido.dtAdmCed);
        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.infoTrabCedido.tpRegTrab.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.infoTrabCedido.tpRegTrab);
        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.infoTrabCedido.tpRegPrev.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.infoTrabCedido.tpRegPrev);

        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.infoMandElet.categOrig.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.infoMandElet.categOrig);
        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.infoMandElet.cnpjOrig.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.infoMandElet.cnpjOrig);
        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.infoMandElet.matricOrig.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.infoMandElet.matricOrig);
        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.infoMandElet.dtExercOrig.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.infoMandElet.dtExercOrig);
        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.infoMandElet.indRemunCargo.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.infoMandElet.indRemunCargo);
        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.infoMandElet.tpRegTrab.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.infoMandElet.tpRegTrab);
        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.infoMandElet.tpRegPrev.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.infoMandElet.tpRegPrev);

        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.infoEstagiario.natEstagio.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.infoEstagiario.natEstagio);
        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.infoEstagiario.nivEstagio.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.infoEstagiario.nivEstagio);
        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.infoEstagiario.areaAtuacao.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.infoEstagiario.areaAtuacao);
        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.infoEstagiario.nrApol.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.infoEstagiario.nrApol);
        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.infoEstagiario.dtPrevTerm.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.infoEstagiario.dtPrevTerm);

        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.infoEstagiario.instEnsino.cnpjInstEnsino.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.infoEstagiario.instEnsino.cnpjInstEnsino);
        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.infoEstagiario.instEnsino.nmRazao.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.infoEstagiario.instEnsino.nmRazao);
        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.infoEstagiario.instEnsino.dscLograd.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.infoEstagiario.instEnsino.dscLograd);
        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.infoEstagiario.instEnsino.nrLograd.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.infoEstagiario.instEnsino.nrLograd);
        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.infoEstagiario.instEnsino.bairro.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.infoEstagiario.instEnsino.bairro);
        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.infoEstagiario.instEnsino.cep.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.infoEstagiario.instEnsino.cep);
        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.infoEstagiario.instEnsino.codMunic.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.infoEstagiario.instEnsino.codMunic);
        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.infoEstagiario.instEnsino.uf.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.infoEstagiario.instEnsino.uf);

        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.infoEstagiario.ageIntegracao.cnpjAgntInteg.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.infoEstagiario.ageIntegracao.cnpjAgntInteg);
        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.infoEstagiario.supervisorEstagio.cpfSupervisor.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.infoEstagiario.supervisorEstagio.cpfSupervisor);

        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.localTrabGeral.tpInsc.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.localTrabGeral.tpInsc);
        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.localTrabGeral.nrInsc.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.localTrabGeral.nrInsc);
        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.localTrabGeral.descComp.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.localTrabGeral.descComp);

        instanciaXml.evtTSVInicio.infoTSVInicio.mudancaCPF.cpfAnt.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.mudancaCPF.cpfAnt);
        instanciaXml.evtTSVInicio.infoTSVInicio.mudancaCPF.matricAnt.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.mudancaCPF.matricAnt);
        instanciaXml.evtTSVInicio.infoTSVInicio.mudancaCPF.dtAltCPF.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.mudancaCPF.dtAltCPF);
        instanciaXml.evtTSVInicio.infoTSVInicio.mudancaCPF.observacao.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.mudancaCPF.observacao);

        instanciaXml.evtTSVInicio.infoTSVInicio.afastamento.dtIniAfast.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.afastamento.dtIniAfast);
        instanciaXml.evtTSVInicio.infoTSVInicio.afastamento.codMotAfast.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.afastamento.codMotAfast);

        instanciaXml.evtTSVInicio.infoTSVInicio.termino.dtTerm.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.termino.dtTerm);
    }
}
