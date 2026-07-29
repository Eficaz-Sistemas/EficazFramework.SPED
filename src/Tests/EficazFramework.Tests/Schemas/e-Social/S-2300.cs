

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
        
        // ideEvento
        evtTSV.evtTSVInicio.ideEvento.tpAmb.Should().Be(Ambiente.ProducaoRestrita_DadosReais);
        evtTSV.evtTSVInicio.ideEvento.procEmi.Should().Be(EmissorEvento.AppEmpregador);
        evtTSV.evtTSVInicio.ideEvento.verProc.Should().Be("2.2");

        // ideEmpregador
        evtTSV.evtTSVInicio.ideEmpregador.tpInsc.Should().Be(PersonalidadeJuridica.CNPJ);
        evtTSV.evtTSVInicio.ideEmpregador.nrInsc.Should().Be("12345678");

        // trabalhador
        evtTSV.evtTSVInicio.trabalhador.cpfTrab.Should().Be("12345678901");
        evtTSV.evtTSVInicio.trabalhador.nmTrab.Should().Be("Fulano de Tal");
        evtTSV.evtTSVInicio.trabalhador.sexo.Should().Be(Sexo.Masculino);
        evtTSV.evtTSVInicio.trabalhador.racaCor.Should().Be(RacaCor.Branca);
        evtTSV.evtTSVInicio.trabalhador.estCiv.Should().Be(EstadoCivil.Solteiro);
        evtTSV.evtTSVInicio.trabalhador.grauInstr.Should().Be(GrauInstrucao.Analfabeto);
        
        evtTSV.evtTSVInicio.trabalhador.nmSoc.Should().Be("Fulano");
        evtTSV.evtTSVInicio.trabalhador.nascimento.dtNascto.Should().BeSameDateAs(new DateTime(1980, 1, 1));
        evtTSV.evtTSVInicio.trabalhador.nascimento.paisNascto.Should().Be("105");
        evtTSV.evtTSVInicio.trabalhador.nascimento.paisNac.Should().Be("105");

        evtTSV.evtTSVInicio.trabalhador.endereco.brasil.tpLograd.Should().Be("Rua");
        evtTSV.evtTSVInicio.trabalhador.endereco.brasil.dscLograd.Should().Be("Rua de Teste");
        evtTSV.evtTSVInicio.trabalhador.endereco.brasil.nrLograd.Should().Be("123");
        evtTSV.evtTSVInicio.trabalhador.endereco.brasil.bairro.Should().Be("Centro");
        evtTSV.evtTSVInicio.trabalhador.endereco.brasil.cep.Should().Be("12345678");
        evtTSV.evtTSVInicio.trabalhador.endereco.brasil.codMunic.Should().Be("1234567");
        evtTSV.evtTSVInicio.trabalhador.endereco.brasil.uf.Should().Be(UFCadastro.SP);

        evtTSV.evtTSVInicio.trabalhador.infoDeficiencia.defFisica.Should().Be(SimNaoString.Nao);
        evtTSV.evtTSVInicio.trabalhador.infoDeficiencia.defVisual.Should().Be(SimNaoString.Nao);
        evtTSV.evtTSVInicio.trabalhador.infoDeficiencia.defAuditiva.Should().Be(SimNaoString.Nao);
        evtTSV.evtTSVInicio.trabalhador.infoDeficiencia.defMental.Should().Be(SimNaoString.Nao);
        evtTSV.evtTSVInicio.trabalhador.infoDeficiencia.defIntelectual.Should().Be(SimNaoString.Nao);
        evtTSV.evtTSVInicio.trabalhador.infoDeficiencia.reabReadap.Should().Be(SimNaoString.Nao);

        evtTSV.evtTSVInicio.trabalhador.contato.fonePrinc.Should().Be("11999999999");
        evtTSV.evtTSVInicio.trabalhador.contato.emailPrinc.Should().Be("teste@teste.com");

        // infoTSVInicio
        evtTSV.evtTSVInicio.infoTSVInicio.cadIni.Should().Be(SimNaoString.Sim);
        evtTSV.evtTSVInicio.infoTSVInicio.matricula.Should().Be("12345");
        evtTSV.evtTSVInicio.infoTSVInicio.codCateg.Should().Be("721");
        evtTSV.evtTSVInicio.infoTSVInicio.dtInicio.Should().BeSameDateAs(new DateTime(2023, 1, 1));
        evtTSV.evtTSVInicio.infoTSVInicio.natAtividade.Should().Be(NaturezaAtividade.Urbano);

        evtTSV.evtTSVInicio.infoTSVInicio.infoComplementares.cargoFuncao.nmCargo.Should().Be("Diretor");
        evtTSV.evtTSVInicio.infoTSVInicio.infoComplementares.cargoFuncao.CBOCargo.Should().Be("123456");
        evtTSV.evtTSVInicio.infoTSVInicio.infoComplementares.remuneracao.vrSalFx.Should().Be(10000.00m);
        evtTSV.evtTSVInicio.infoTSVInicio.infoComplementares.remuneracao.undSalFixo.Should().Be(5);
        evtTSV.evtTSVInicio.infoTSVInicio.infoComplementares.remuneracao.dscSalVar.Should().Be("Bonus");
        evtTSV.evtTSVInicio.infoTSVInicio.infoComplementares.FGTS.dtOpcFGTS.Should().BeSameDateAs(new DateTime(2023, 1, 1));
    }

    public override void PreencheCampos(S2300 evento)
    {
        evento.Versao = _versao;
        evento.evtTSVInicio = new S2300EvtTSVInicio()
        {
            ideEvento = new IdeEventoNaoPeriodico()
            {
                tpAmb = Ambiente.ProducaoRestrita_DadosReais,
                procEmi = EmissorEvento.AppEmpregador,
                verProc = "2.2"
            },
            ideEmpregador = new Empregador()
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = "12345678"
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
                infoDeficiencia = new S2300InfoDeficiencia()
                {
                    defFisica = SimNaoString.Nao,
                    defVisual = SimNaoString.Nao,
                    defAuditiva = SimNaoString.Nao,
                    defMental = SimNaoString.Nao,
                    defIntelectual = SimNaoString.Nao,
                    reabReadap = SimNaoString.Nao
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
                natAtividade = NaturezaAtividade.Urbano,
                infoComplementares = new S2300InfoComplementares()
                {
                    cargoFuncao = new S2300CargoFuncao()
                    {
                        nmCargo = "Diretor",
                        CBOCargo = "123456"
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
                    }
                }
            }
        };
    }

    public override void ValidaInstanciasLeituraEscrita(S2300 instanciaPopulada, S2300 instanciaXml)
    {
        // ideEvento
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

        instanciaXml.evtTSVInicio.trabalhador.infoDeficiencia.defFisica.Should().Be(instanciaPopulada.evtTSVInicio.trabalhador.infoDeficiencia.defFisica);
        instanciaXml.evtTSVInicio.trabalhador.infoDeficiencia.defVisual.Should().Be(instanciaPopulada.evtTSVInicio.trabalhador.infoDeficiencia.defVisual);
        instanciaXml.evtTSVInicio.trabalhador.infoDeficiencia.defAuditiva.Should().Be(instanciaPopulada.evtTSVInicio.trabalhador.infoDeficiencia.defAuditiva);
        instanciaXml.evtTSVInicio.trabalhador.infoDeficiencia.defMental.Should().Be(instanciaPopulada.evtTSVInicio.trabalhador.infoDeficiencia.defMental);
        instanciaXml.evtTSVInicio.trabalhador.infoDeficiencia.defIntelectual.Should().Be(instanciaPopulada.evtTSVInicio.trabalhador.infoDeficiencia.defIntelectual);
        instanciaXml.evtTSVInicio.trabalhador.infoDeficiencia.reabReadap.Should().Be(instanciaPopulada.evtTSVInicio.trabalhador.infoDeficiencia.reabReadap);

        instanciaXml.evtTSVInicio.trabalhador.contato.fonePrinc.Should().Be(instanciaPopulada.evtTSVInicio.trabalhador.contato.fonePrinc);
        instanciaXml.evtTSVInicio.trabalhador.contato.emailPrinc.Should().Be(instanciaPopulada.evtTSVInicio.trabalhador.contato.emailPrinc);

        // infoTSVInicio
        instanciaXml.evtTSVInicio.infoTSVInicio.cadIni.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.cadIni);
        instanciaXml.evtTSVInicio.infoTSVInicio.matricula.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.matricula);
        instanciaXml.evtTSVInicio.infoTSVInicio.codCateg.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.codCateg);
        instanciaXml.evtTSVInicio.infoTSVInicio.dtInicio.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.dtInicio);
        instanciaXml.evtTSVInicio.infoTSVInicio.natAtividade.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.natAtividade);

        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.cargoFuncao.nmCargo.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.cargoFuncao.nmCargo);
        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.cargoFuncao.CBOCargo.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.cargoFuncao.CBOCargo);
        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.remuneracao.vrSalFx.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.remuneracao.vrSalFx);
        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.remuneracao.undSalFixo.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.remuneracao.undSalFixo);
        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.remuneracao.dscSalVar.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.remuneracao.dscSalVar);
        instanciaXml.evtTSVInicio.infoTSVInicio.infoComplementares.FGTS.dtOpcFGTS.Should().Be(instanciaPopulada.evtTSVInicio.infoTSVInicio.infoComplementares.FGTS.dtOpcFGTS);
    }
}
