using System;
using System.Collections.Generic;

namespace EficazFramework.SPED.Schemas.eSocial;

public class S2205Test : BaseESocialTest<S2205>
{
    [Test]
    [TestCase(Versao.v_S_01_02_00)]
    [TestCase(Versao.v_S_01_03_00)]
    public async System.Threading.Tasks.Task Valida(Versao versao)
    {
        _versao = versao;
        ValidationSchemaNamespace = $"http://www.esocial.gov.br/schema/evt/evtAltCadastral/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v_S_01_03_00 => Resources.Schemas.eSocial.S2005_v_01_03_01,
            _ => Resources.Schemas.eSocial.S2005_v_01_02_01
        };
        await TestaEvento();
    }

    [Test]
    public async System.Threading.Tasks.Task Read_v_S_01_03_00()
    {
        var evento = await Evento.ReadAsync(Resources.Samples.eSocial.S2205_v_S_01_03_00);
        evento.Should().NotBeNull();
        evento.Versao.Should().Be(Versao.v_S_01_03_00);

        var evtAlt = evento as S2205;
        evtAlt.Should().NotBeNull();
        evtAlt.evtAltCadastral.Id.Should().Be("ID1106080250000002026072813090200002");

        // ideEvento
        evtAlt.evtAltCadastral.ideEvento.indRetif.Should().Be(IndicadorRetificacao.Original);
        evtAlt.evtAltCadastral.ideEvento.tpAmb.Should().Be(Ambiente.ProducaoRestrita_DadosReais);
        evtAlt.evtAltCadastral.ideEvento.procEmi.Should().Be(EmissorEvento.AppEmpregador);
        evtAlt.evtAltCadastral.ideEvento.verProc.Should().Be("2.2");

        // ideEmpregador
        evtAlt.evtAltCadastral.ideEmpregador.tpInsc.Should().Be(PersonalidadeJuridica.CNPJ);
        evtAlt.evtAltCadastral.ideEmpregador.nrInsc.Should().Be("10608025");

        // ideTrabalhador
        evtAlt.evtAltCadastral.ideTrabalhador.cpfTrab.Should().Be("12345678901");

        // alteracao
        evtAlt.evtAltCadastral.alteracao.dtAlteracao.Should().Be(new DateTime(2023, 10, 1));

        // dadosTrabalhador
        var dados = evtAlt.evtAltCadastral.alteracao.dadosTrabalhador;
        dados.nmTrab.Should().Be("Joao da Silva");
        dados.sexo.Should().Be(Sexo.Masculino);
        dados.racaCor.Should().Be(RacaCor.NaoInformado);
        dados.estCiv.Should().Be(EstadoCivil.Solteiro);
        dados.grauInstr.Should().Be(GrauInstrucao.MedioCompleto);
        dados.nmSoc.Should().Be("Joao");
        dados.paisNac.Should().Be("105");

        // endereco (brasil)
        var endBrasil = dados.endereco.Item as EnderecoBrasileiro;
        endBrasil.Should().NotBeNull();
        endBrasil.tpLograd.Should().Be("Rua");
        endBrasil.dscLograd.Should().Be("1");
        endBrasil.nrLograd.Should().Be("123");
        endBrasil.complemento.Should().Be("Apt 1");
        endBrasil.bairro.Should().Be("Centro");
        endBrasil.cep.Should().Be("12345678");
        endBrasil.codMunic.Should().Be("1234567");
        endBrasil.uf.Should().Be(UFCadastro.SP);

        // trabImig
        dados.trabImig.tmpResid.Should().Be(ImigranteTempoResidencia.Indeterminado);
        dados.trabImig.condIng.Should().Be(ImigranteCondicao.Refugidao);

        // infoDeficiencia
        dados.infoDeficiencia.defFisica.Should().Be(SimNaoString.Nao);
        dados.infoDeficiencia.defVisual.Should().Be(SimNaoString.Nao);
        dados.infoDeficiencia.defAuditiva.Should().Be(SimNaoString.Nao);
        dados.infoDeficiencia.defMental.Should().Be(SimNaoString.Nao);
        dados.infoDeficiencia.defIntelectual.Should().Be(SimNaoString.Nao);
        dados.infoDeficiencia.reabReadap.Should().Be(SimNaoString.Nao);
        dados.infoDeficiencia.observacao.Should().Be("Nenhuma");

        // dependente
        dados.dependente.Should().HaveCount(1);
        dados.dependente[0].tpDep.Should().Be("01");
        dados.dependente[0].nmDep.Should().Be("Filho");
        dados.dependente[0].dtNascto.Should().Be(new DateTime(2013, 10, 1));
        dados.dependente[0].cpfDep.Should().Be("12345678901");
        dados.dependente[0].sexoDep.Should().Be(Sexo.Masculino);
        dados.dependente[0].depIRRF.Should().Be(SimNaoString.Sim);
        dados.dependente[0].depSF.Should().Be(SimNaoString.Sim);
        dados.dependente[0].descrDep.Should().Be("Filho");

        // contato
        dados.contato.fonePrinc.Should().Be("11999999999");
        dados.contato.emailPrinc.Should().Be("joao@email.com");
    }

    public override void PreencheCampos(S2205 evento)
    {
        evento.Versao = _versao;
        evento.evtAltCadastral = new S2205AltCadastral()
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
                nrInsc = CnpjCpf.Substring(0, 8)
            },
            ideTrabalhador = new S2205IdeTrabalhador()
            {
                cpfTrab = "12345678901"
            },
            alteracao = new S2205Alteracao()
            {
                dtAlteracao = new DateTime(2023, 10, 01),
                dadosTrabalhador = new S2205DadosTrabalhador()
                {
                    nmTrab = "João da Silva",
                    sexo = Sexo.Masculino,
                    racaCor = RacaCor.NaoInformado,
                    estCiv = EstadoCivil.Solteiro,
                    estCivSpecified = true,
                    grauInstr = GrauInstrucao.MedioCompleto,
                    nmSoc = "João",
                    paisNac = "105",
                    endereco = new S2205Endereco()
                    {
                        Item = new EnderecoBrasileiro()
                        {
                            tpLograd = "Rua",
                            dscLograd = "1",
                            nrLograd = "123",
                            complemento = "Apt 1",
                            bairro = "Centro",
                            cep = "12345678",
                            codMunic = "1234567",
                            uf = UFCadastro.SP
                        }
                    },
                    trabImig = new S2205TrabImig()
                    {
                        tmpResid = ImigranteTempoResidencia.Indeterminado,
                        condIng = ImigranteCondicao.Refugidao
                    },
                    infoDeficiencia = new S2205InfoDeficiencia()
                    {
                        defFisica = SimNaoString.Nao,
                        defVisual = SimNaoString.Nao,
                        defAuditiva = SimNaoString.Nao,
                        defMental = SimNaoString.Nao,
                        defIntelectual = SimNaoString.Nao,
                        reabReadap = SimNaoString.Nao,
                        infoCota = SimNaoString.Nao,
                        observacao = "Nenhuma"
                    },
                    dependente =
                    [
                        new()
                        {
                            tpDep = "01",
                            nmDep = "Filho",
                            dtNascto = new DateTime(2013, 10, 01),
                            cpfDep = "12345678901",
                            sexoDep = Sexo.Masculino,
                            sexoDepSpecified = true,
                            depIRRF = SimNaoString.Sim,
                            depSF = SimNaoString.Sim,
                            incTrab = SimNaoString.Nao,
                            descrDep = "Filho"
                        }
                    ],
                    contato = new S2205Contato()
                    {
                        fonePrinc = "11999999999",
                        emailPrinc = "joao@email.com"
                    }
                }
            }
        };
    }

    public override void ValidaInstanciasLeituraEscrita(S2205 instanciaPopulada, S2205 instanciaXml)
    {
        instanciaXml.Should().NotBeNull();
        instanciaPopulada.Should().NotBeNull();
        
        // ideEvento
        instanciaXml.evtAltCadastral.ideEvento.tpAmb.Should().Be(instanciaPopulada.evtAltCadastral.ideEvento.tpAmb);
        instanciaXml.evtAltCadastral.ideEvento.procEmi.Should().Be(instanciaPopulada.evtAltCadastral.ideEvento.procEmi);
        instanciaXml.evtAltCadastral.ideEvento.verProc.Should().Be(instanciaPopulada.evtAltCadastral.ideEvento.verProc);

        // ideEmpregador
        instanciaXml.evtAltCadastral.ideEmpregador.tpInsc.Should().Be(instanciaPopulada.evtAltCadastral.ideEmpregador.tpInsc);
        instanciaXml.evtAltCadastral.ideEmpregador.nrInsc.Should().Be(instanciaPopulada.evtAltCadastral.ideEmpregador.nrInsc);
        
        // ideTrabalhador
        instanciaXml.evtAltCadastral.ideTrabalhador.cpfTrab.Should().Be(instanciaPopulada.evtAltCadastral.ideTrabalhador.cpfTrab);

        // alteracao
        instanciaXml.evtAltCadastral.alteracao.dtAlteracao.Should().BeSameDateAs(instanciaPopulada.evtAltCadastral.alteracao.dtAlteracao);

        // dadosTrabalhador
        var dadosPop = instanciaPopulada.evtAltCadastral.alteracao.dadosTrabalhador;
        var dadosXml = instanciaXml.evtAltCadastral.alteracao.dadosTrabalhador;
        
        dadosXml.nmTrab.Should().Be(dadosPop.nmTrab);
        dadosXml.sexo.Should().Be(dadosPop.sexo);
        dadosXml.racaCor.Should().Be(dadosPop.racaCor);
        dadosXml.estCiv.Should().Be(dadosPop.estCiv);
        dadosXml.grauInstr.Should().Be(dadosPop.grauInstr);
        dadosXml.nmSoc.Should().Be(dadosPop.nmSoc);
        dadosXml.paisNac.Should().Be(dadosPop.paisNac);

        // endereco
        var endPop = dadosPop.endereco.Item as EnderecoBrasileiro;
        var endXml = dadosXml.endereco.Item as EnderecoBrasileiro;
        endXml.Should().NotBeNull();
        endXml.tpLograd.Should().Be(endPop.tpLograd);
        endXml.dscLograd.Should().Be(endPop.dscLograd);
        endXml.nrLograd.Should().Be(endPop.nrLograd);
        endXml.complemento.Should().Be(endPop.complemento);
        endXml.bairro.Should().Be(endPop.bairro);
        endXml.cep.Should().Be(endPop.cep);
        endXml.codMunic.Should().Be(endPop.codMunic);
        endXml.uf.Should().Be(endPop.uf);
        
        // trabImig
        dadosXml.trabImig.tmpResid.Should().Be(dadosPop.trabImig.tmpResid);
        dadosXml.trabImig.condIng.Should().Be(dadosPop.trabImig.condIng);
        
        // infoDeficiencia
        dadosXml.infoDeficiencia.defFisica.Should().Be(dadosPop.infoDeficiencia.defFisica);
        dadosXml.infoDeficiencia.defVisual.Should().Be(dadosPop.infoDeficiencia.defVisual);
        dadosXml.infoDeficiencia.defAuditiva.Should().Be(dadosPop.infoDeficiencia.defAuditiva);
        dadosXml.infoDeficiencia.defMental.Should().Be(dadosPop.infoDeficiencia.defMental);
        dadosXml.infoDeficiencia.defIntelectual.Should().Be(dadosPop.infoDeficiencia.defIntelectual);
        dadosXml.infoDeficiencia.reabReadap.Should().Be(dadosPop.infoDeficiencia.reabReadap);
        dadosXml.infoDeficiencia.observacao.Should().Be(dadosPop.infoDeficiencia.observacao);

        // dependente
        dadosXml.dependente.Count.Should().Be(dadosPop.dependente.Count);
        dadosXml.dependente[0].tpDep.Should().Be(dadosPop.dependente[0].tpDep);
        dadosXml.dependente[0].nmDep.Should().Be(dadosPop.dependente[0].nmDep);
        dadosXml.dependente[0].dtNascto.Should().BeSameDateAs(dadosPop.dependente[0].dtNascto);
        dadosXml.dependente[0].cpfDep.Should().Be(dadosPop.dependente[0].cpfDep);
        dadosXml.dependente[0].sexoDep.Should().Be(dadosPop.dependente[0].sexoDep);
        dadosXml.dependente[0].depIRRF.Should().Be(dadosPop.dependente[0].depIRRF);
        dadosXml.dependente[0].depSF.Should().Be(dadosPop.dependente[0].depSF);
        dadosXml.dependente[0].incTrab.Should().Be(dadosPop.dependente[0].incTrab);
        dadosXml.dependente[0].descrDep.Should().Be(dadosPop.dependente[0].descrDep);

        // contato
        dadosXml.contato.fonePrinc.Should().Be(dadosPop.contato.fonePrinc);
        dadosXml.contato.emailPrinc.Should().Be(dadosPop.contato.emailPrinc);
    }
}
