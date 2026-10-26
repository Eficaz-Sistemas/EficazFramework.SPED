using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.eSocial;

public class S2306Test : BaseESocialTest<S2306>
{
    [Test]
    [TestCase(Versao.v_S_01_03_00)]
    public async Task Valida(Versao versao)
    {
        _versao = versao;
        ValidationSchemaNamespace = $"http://www.esocial.gov.br/schema/evt/evtTSVAltContr/{versao}";
        ValidationSchema = Resources.Schemas.eSocial.S2306_v_S_01_03_00;
        await TestaEvento();
    }

    [Test]
    public async Task Read_v_S_01_03_00()
    {
        var evento = await Evento.ReadAsync(Resources.Samples.eSocial.S2306_v_S_01_03_00);
        evento.Should().NotBeNull();
        evento.Should().BeOfType<S2306>();

        var ev2306 = evento as S2306;

        // ideEvento
        ev2306.evtTSVAltContr.ideEvento.indRetif.Should().Be(IndicadorRetificacao.Original);
        ev2306.evtTSVAltContr.ideEvento.nrRecibo.Should().BeNull();
        ev2306.evtTSVAltContr.ideEvento.tpAmb.Should().Be(Ambiente.ProducaoRestrita_DadosReais);
        ev2306.evtTSVAltContr.ideEvento.procEmi.Should().Be(EmissorEvento.AppEmpregador);
        ev2306.evtTSVAltContr.ideEvento.verProc.Should().Be("EficazFramework");

        // ideEmpregador
        ev2306.evtTSVAltContr.ideEmpregador.tpInsc.Should().Be(PersonalidadeJuridica.CNPJ);
        ev2306.evtTSVAltContr.ideEmpregador.nrInsc.Should().Be("34785515000166");

        // ideTrabSemVinculo
        ev2306.evtTSVAltContr.ideTrabSemVinculo.cpfTrab.Should().Be("12345678901");
        ev2306.evtTSVAltContr.ideTrabSemVinculo.matricula.Should().Be("123");
        ev2306.evtTSVAltContr.ideTrabSemVinculo.codCateg.Should().BeNull();

        // infoTSVAlteracao
        var info = ev2306.evtTSVAltContr.infoTSVAlteracao;
        info.Should().NotBeNull();
        info.dtAlteracao.Should().Be(new DateTime(2026, 10, 1));
        info.natAtividade.Should().Be(NaturezaAtividade.Urbano);

        // infoComplementares
        var compl = info.infoComplementares;
        compl.Should().NotBeNull();
        compl.cargoFuncao.nmCargo.Should().Be("Diretor Administrativo");
        compl.cargoFuncao.CBOCargo.Should().Be("123105");
        compl.cargoFuncao.nmFuncao.Should().Be("Coordenador de Projetos");
        compl.cargoFuncao.CBOFuncao.Should().Be("142105");

        compl.remuneracao.vrSalFx.Should().Be(3500.50m);
        compl.remuneracao.undSalFixo.Should().Be(5);
        compl.remuneracao.dscSalVar.Should().Be("Comissões de 10% sobre as vendas");

        compl.infoDirigenteSindical.tpRegPrev.Should().Be(RegimePrevidenciario.RGPS);
        compl.infoTrabCedido.tpRegPrev.Should().Be(RegimePrevidenciario.SPSMFA);
        compl.infoMandElet.indRemunCargo.Should().Be(SimNaoString.Sim);
        compl.infoMandElet.tpRegPrev.Should().Be(RegimePrevidenciario.RPPS);

        compl.infoEstagiario.natEstagio.Should().Be("N");
        compl.infoEstagiario.nivEstagio.Should().Be(4);
        compl.infoEstagiario.areaAtuacao.Should().Be("Administração");
        compl.infoEstagiario.nrApol.Should().Be("AP123456");
        compl.infoEstagiario.dtPrevTerm.Should().Be(new DateTime(2027, 6, 30));
        compl.infoEstagiario.instEnsino.cnpjInstEnsino.Should().Be("12345678000195");
        compl.infoEstagiario.instEnsino.nmRazao.Should().Be("Instituição de Ensino Ltda");
        compl.infoEstagiario.instEnsino.dscLograd.Should().Be("Rua das Flores");
        compl.infoEstagiario.instEnsino.nrLograd.Should().Be("100");
        compl.infoEstagiario.instEnsino.bairro.Should().Be("Centro");
        compl.infoEstagiario.instEnsino.cep.Should().Be("01001000");
        compl.infoEstagiario.instEnsino.codMunic.Should().Be("3550308");
        compl.infoEstagiario.instEnsino.uf.Should().Be("SP");
        compl.infoEstagiario.ageIntegracao.cnpjAgntInteg.Should().Be("98765432000198");
        compl.infoEstagiario.supervisorEstagio.cpfSupervisor.Should().Be("98765432100");

        compl.localTrabGeral.tpInsc.Should().Be(1);
        compl.localTrabGeral.nrInsc.Should().Be("34785515000166");
        compl.localTrabGeral.descComp.Should().Be("Sala 12");
    }

    public override void PreencheCampos(S2306 evento)
    {
        evento.Versao = _versao;

        evento.evtTSVAltContr = new S2306EvtTSVAltContr
        {
            ideEvento = new S2306IdeEvento
            {
                indRetif = IndicadorRetificacao.Original,
                nrRecibo = null,
                tpAmb = Ambiente.ProducaoRestrita_DadosReais,
                procEmi = EmissorEvento.AppEmpregador,
                verProc = "EficazFramework"
            },

            ideEmpregador = new Empregador
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = CnpjCpf
            },

            ideTrabSemVinculo = new S2306IdeTrabSemVinculo
            {
                cpfTrab = "12345678901",
                matricula = "123",
                codCateg = null
            },

            infoTSVAlteracao = new S2306InfoTSVAlteracao
            {
                dtAlteracao = new DateTime(2026, 10, 1),
                natAtividade = NaturezaAtividade.Urbano,

                infoComplementares = new S2306InfoComplementares
                {
                    cargoFuncao = new S2306CargoFuncao
                    {
                        nmCargo = "Diretor Administrativo",
                        CBOCargo = "123105",
                        nmFuncao = "Coordenador de Projetos",
                        CBOFuncao = "142105"
                    },

                    remuneracao = new S2306Remuneracao
                    {
                        vrSalFx = 3500.50m,
                        undSalFixo = 5,
                        dscSalVar = "Comissões de 10% sobre as vendas"
                    },

                    infoDirigenteSindical = new S2306InfoDirigenteSindical
                    {
                        tpRegPrev = RegimePrevidenciario.RGPS
                    },

                    infoTrabCedido = new S2306InfoTrabCedido
                    {
                        tpRegPrev = RegimePrevidenciario.SPSMFA
                    },

                    infoMandElet = new S2306InfoMandElet
                    {
                        indRemunCargo = SimNaoString.Sim,
                        tpRegPrev = RegimePrevidenciario.RPPS
                    },

                    infoEstagiario = new S2306InfoEstagiario
                    {
                        natEstagio = "N",
                        nivEstagio = 4,
                        areaAtuacao = "Administração",
                        nrApol = "AP123456",
                        dtPrevTerm = new DateTime(2027, 6, 30),
                        instEnsino = new S2306InstEnsino
                        {
                            cnpjInstEnsino = "12345678000195",
                            nmRazao = "Instituição de Ensino Ltda",
                            dscLograd = "Rua das Flores",
                            nrLograd = "100",
                            bairro = "Centro",
                            cep = "01001000",
                            codMunic = "3550308",
                            uf = "SP"
                        },
                        ageIntegracao = new S2306AgeIntegracao
                        {
                            cnpjAgntInteg = "98765432000198"
                        },
                        supervisorEstagio = new S2306SupervisorEstagio
                        {
                            cpfSupervisor = "98765432100"
                        }
                    },

                    localTrabGeral = new S2306LocalTrabGeral
                    {
                        tpInsc = 1,
                        nrInsc = CnpjCpf,
                        descComp = "Sala 12"
                    }
                }
            }
        };
    }

    public override void ValidaInstanciasLeituraEscrita(S2306 instanciaPopulada, S2306 instanciaXml)
    {
        instanciaXml.Should().NotBeNull();
        instanciaXml.evtTSVAltContr.Should().NotBeNull();

        var pop = instanciaPopulada.evtTSVAltContr;
        var xml = instanciaXml.evtTSVAltContr;

        xml.Id.Should().Be(pop.Id);
        xml.ideEvento.indRetif.Should().Be(pop.ideEvento.indRetif);
        xml.ideEvento.nrRecibo.Should().Be(pop.ideEvento.nrRecibo);
        xml.ideEvento.tpAmb.Should().Be(pop.ideEvento.tpAmb);
        xml.ideEvento.procEmi.Should().Be(pop.ideEvento.procEmi);
        xml.ideEvento.verProc.Should().Be(pop.ideEvento.verProc);

        xml.ideEmpregador.tpInsc.Should().Be(pop.ideEmpregador.tpInsc);
        xml.ideEmpregador.nrInsc.Should().Be(pop.ideEmpregador.nrInsc);

        xml.ideTrabSemVinculo.cpfTrab.Should().Be(pop.ideTrabSemVinculo.cpfTrab);
        xml.ideTrabSemVinculo.matricula.Should().Be(pop.ideTrabSemVinculo.matricula);
        xml.ideTrabSemVinculo.codCateg.Should().Be(pop.ideTrabSemVinculo.codCateg);

        xml.infoTSVAlteracao.dtAlteracao.Should().BeSameDateAs(pop.infoTSVAlteracao.dtAlteracao);
        xml.infoTSVAlteracao.natAtividade.Should().Be(pop.infoTSVAlteracao.natAtividade);

        var popCompl = pop.infoTSVAlteracao.infoComplementares;
        var xmlCompl = xml.infoTSVAlteracao.infoComplementares;

        xmlCompl.cargoFuncao.nmCargo.Should().Be(popCompl.cargoFuncao.nmCargo);
        xmlCompl.cargoFuncao.CBOCargo.Should().Be(popCompl.cargoFuncao.CBOCargo);
        xmlCompl.cargoFuncao.nmFuncao.Should().Be(popCompl.cargoFuncao.nmFuncao);
        xmlCompl.cargoFuncao.CBOFuncao.Should().Be(popCompl.cargoFuncao.CBOFuncao);

        xmlCompl.remuneracao.vrSalFx.Should().Be(popCompl.remuneracao.vrSalFx);
        xmlCompl.remuneracao.undSalFixo.Should().Be(popCompl.remuneracao.undSalFixo);
        xmlCompl.remuneracao.dscSalVar.Should().Be(popCompl.remuneracao.dscSalVar);

        xmlCompl.infoDirigenteSindical.tpRegPrev.Should().Be(popCompl.infoDirigenteSindical.tpRegPrev);
        xmlCompl.infoTrabCedido.tpRegPrev.Should().Be(popCompl.infoTrabCedido.tpRegPrev);
        xmlCompl.infoMandElet.indRemunCargo.Should().Be(popCompl.infoMandElet.indRemunCargo);
        xmlCompl.infoMandElet.tpRegPrev.Should().Be(popCompl.infoMandElet.tpRegPrev);

        xmlCompl.infoEstagiario.natEstagio.Should().Be(popCompl.infoEstagiario.natEstagio);
        xmlCompl.infoEstagiario.nivEstagio.Should().Be(popCompl.infoEstagiario.nivEstagio);
        xmlCompl.infoEstagiario.areaAtuacao.Should().Be(popCompl.infoEstagiario.areaAtuacao);
        xmlCompl.infoEstagiario.nrApol.Should().Be(popCompl.infoEstagiario.nrApol);
        xmlCompl.infoEstagiario.dtPrevTerm.Should().BeSameDateAs(popCompl.infoEstagiario.dtPrevTerm);
        xmlCompl.infoEstagiario.instEnsino.cnpjInstEnsino.Should().Be(popCompl.infoEstagiario.instEnsino.cnpjInstEnsino);
        xmlCompl.infoEstagiario.instEnsino.nmRazao.Should().Be(popCompl.infoEstagiario.instEnsino.nmRazao);
        xmlCompl.infoEstagiario.instEnsino.dscLograd.Should().Be(popCompl.infoEstagiario.instEnsino.dscLograd);
        xmlCompl.infoEstagiario.instEnsino.nrLograd.Should().Be(popCompl.infoEstagiario.instEnsino.nrLograd);
        xmlCompl.infoEstagiario.instEnsino.bairro.Should().Be(popCompl.infoEstagiario.instEnsino.bairro);
        xmlCompl.infoEstagiario.instEnsino.cep.Should().Be(popCompl.infoEstagiario.instEnsino.cep);
        xmlCompl.infoEstagiario.instEnsino.codMunic.Should().Be(popCompl.infoEstagiario.instEnsino.codMunic);
        xmlCompl.infoEstagiario.instEnsino.uf.Should().Be(popCompl.infoEstagiario.instEnsino.uf);
        xmlCompl.infoEstagiario.ageIntegracao.cnpjAgntInteg.Should().Be(popCompl.infoEstagiario.ageIntegracao.cnpjAgntInteg);
        xmlCompl.infoEstagiario.supervisorEstagio.cpfSupervisor.Should().Be(popCompl.infoEstagiario.supervisorEstagio.cpfSupervisor);

        xmlCompl.localTrabGeral.tpInsc.Should().Be(popCompl.localTrabGeral.tpInsc);
        xmlCompl.localTrabGeral.nrInsc.Should().Be(popCompl.localTrabGeral.nrInsc);
        xmlCompl.localTrabGeral.descComp.Should().Be(popCompl.localTrabGeral.descComp);
    }
}
