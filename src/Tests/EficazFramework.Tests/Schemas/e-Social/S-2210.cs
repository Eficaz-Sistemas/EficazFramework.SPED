using EficazFramework.SPED.Schemas.eSocial;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace EficazFramework.SPED.Schemas.eSocial;

public class S2210Test : BaseESocialTest<S2210>
{
    private int _testNumber = 0;

    [Test]
    [TestCase(Versao.v_S_01_02_00)]
    [TestCase(Versao.v_S_01_03_00)]
    public async Task Valida(Versao versao)
    {
        _testNumber = 0;
        _versao = versao;
        ValidationSchemaNamespace = $"http://www.esocial.gov.br/schema/evt/evtCAT/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v_S_01_03_00 => Resources.Schemas.eSocial.S2010_v_S_01_03_01,
            _ => Resources.Schemas.eSocial.S2010_v_S_01_02_01
        };
        await TestaEvento();
    }

    [Test]
    public async Task Read_v_S_01_03_00()
    {
        var evento = await Evento.ReadAsync(Resources.Samples.eSocial.S2210_v_S_01_03_00);
        evento.Should().NotBeNull();
        evento.Versao.Should().Be(Versao.v_S_01_03_00);
        var evtCAT = evento as S2210;
        evtCAT.Should().NotBeNull();
        
        evtCAT.evtCAT.Id.Should().Be("ID1123456780001232024010100000000001");
        
        evtCAT.evtCAT.ideEvento.indRetif.Should().Be(IndicadorRetificacao.Original);
        evtCAT.evtCAT.ideEvento.tpAmb.Should().Be(Ambiente.ProducaoRestrita_DadosReais);
        evtCAT.evtCAT.ideEvento.procEmi.Should().Be(EmissorEvento.AppEmpregador);
        evtCAT.evtCAT.ideEvento.verProc.Should().Be("2.2");

        evtCAT.evtCAT.ideEmpregador.tpInsc.Should().Be(PersonalidadeJuridica.CNPJ);
        evtCAT.evtCAT.ideEmpregador.nrInsc.Should().Be("12345678");

        evtCAT.evtCAT.ideVinculo.cpfTrab.Should().Be("12345678901");
        evtCAT.evtCAT.ideVinculo.matricula.Should().Be("123456");
        evtCAT.evtCAT.ideVinculo.codCateg.Should().Be(101);

        evtCAT.evtCAT.cat.dtAcid.Should().BeSameDateAs(new DateTime(2024, 1, 1));
        evtCAT.evtCAT.cat.tpAcid.Should().Be(TipoAcidenteTrabalho.Tipico);
        evtCAT.evtCAT.cat.hrAcid.Should().Be("1000");
        evtCAT.evtCAT.cat.hrsTrabAntesAcid.Should().Be("0200");
        evtCAT.evtCAT.cat.tpCat.Should().Be(TipoCAT.Inicial);
        evtCAT.evtCAT.cat.indCatObito.Should().Be(SimNaoString.Nao);
        evtCAT.evtCAT.cat.dtObito.Should().BeSameDateAs(new DateTime(2024, 1, 1));
        evtCAT.evtCAT.cat.indComunPolicia.Should().Be(SimNaoString.Nao);
        evtCAT.evtCAT.cat.codSitGeradora.Should().Be("123456789");
        evtCAT.evtCAT.cat.iniciatCAT.Should().Be(IniciativaCAT.Empregador);
        evtCAT.evtCAT.cat.obsCAT.Should().Be("Observacao");
        evtCAT.evtCAT.cat.ultDiaTrab.Should().BeSameDateAs(new DateTime(2024, 1, 1));
        evtCAT.evtCAT.cat.houveAfast.Should().Be(SimNaoString.Sim);

        evtCAT.evtCAT.cat.localAcidente.tpLocal.Should().Be(TipoLocalAcidente.EmpregadorBrasil);
        evtCAT.evtCAT.cat.localAcidente.dscLocal.Should().Be("Patio");
        evtCAT.evtCAT.cat.localAcidente.tpLograd.Should().Be("Rua");
        evtCAT.evtCAT.cat.localAcidente.dscLograd.Should().Be("A");
        evtCAT.evtCAT.cat.localAcidente.nrLograd.Should().Be("123");
        evtCAT.evtCAT.cat.localAcidente.complemento.Should().Be("Sala 1");
        evtCAT.evtCAT.cat.localAcidente.bairro.Should().Be("Centro");
        evtCAT.evtCAT.cat.localAcidente.cep.Should().Be("12345678");
        evtCAT.evtCAT.cat.localAcidente.codMunic.Should().Be("1234567");
        evtCAT.evtCAT.cat.localAcidente.uf.Should().Be("MG");
        evtCAT.evtCAT.cat.localAcidente.pais.Should().Be("076");
        evtCAT.evtCAT.cat.localAcidente.codPostal.Should().Be("12345");
        evtCAT.evtCAT.cat.localAcidente.ideLocalAcid.tpInsc.Should().Be(PersonalidadeJuridica.CNPJ);
        evtCAT.evtCAT.cat.localAcidente.ideLocalAcid.nrInsc.Should().Be("12345678000123");

        evtCAT.evtCAT.cat.parteAtingida.codParteAting.Should().Be("123456789");
        evtCAT.evtCAT.cat.parteAtingida.lateralidade.Should().Be(Lateralidade.Esquerda);

        evtCAT.evtCAT.cat.agenteCausador.codAgntCausador.Should().Be("123456789");

        evtCAT.evtCAT.cat.atestado.dtAtendimento.Should().BeSameDateAs(new DateTime(2024, 1, 1));
        evtCAT.evtCAT.cat.atestado.hrAtendimento.Should().Be("1200");
        evtCAT.evtCAT.cat.atestado.indInternacao.Should().Be(SimNaoString.Nao);
        evtCAT.evtCAT.cat.atestado.durTrat.Should().Be(10);
        evtCAT.evtCAT.cat.atestado.indAfast.Should().Be(SimNaoString.Sim);
        evtCAT.evtCAT.cat.atestado.dscLesao.Should().Be("123456789");
        evtCAT.evtCAT.cat.atestado.dscCompLesao.Should().Be("Corte");
        evtCAT.evtCAT.cat.atestado.diagProvavel.Should().Be("Tétano");
        evtCAT.evtCAT.cat.atestado.codCID.Should().Be("A00");
        evtCAT.evtCAT.cat.atestado.observacao.Should().Be("Nada a declarar");

        evtCAT.evtCAT.cat.atestado.emitente.nmEmit.Should().Be("Medico da Silva");
        evtCAT.evtCAT.cat.atestado.emitente.ideOC.Should().Be(OrgaoClasseSaude.CRM);
        evtCAT.evtCAT.cat.atestado.emitente.nrOC.Should().Be("12345");
        evtCAT.evtCAT.cat.atestado.emitente.ufOC.Should().Be("MG");

        evtCAT.evtCAT.cat.catOrigem.nrRecCatOrig.Should().Be("1.2.0000000000000000000");
    }

    // BaseESocialTest overrides
    public override void PreencheCampos(S2210 evento)
    {
        evento.Versao = _versao;
        evento.evtCAT = new S2210EvtCAT()
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
            ideVinculo = new S2210IdeVinculo()
            {
                cpfTrab = "12345678901",
                matricula = "123456",
                codCateg = 101
            },
            cat = new S2210Cat()
            {
                dtAcid = new DateTime(2024, 1, 1),
                tpAcid = TipoAcidenteTrabalho.Tipico,
                hrAcid = "1000",
                hrsTrabAntesAcid = "0200",
                tpCat = TipoCAT.Inicial,
                indCatObito = SimNaoString.Nao,
                dtObito = new DateTime(2024, 1, 1),
                indComunPolicia = SimNaoString.Nao,
                codSitGeradora = "123456789",
                iniciatCAT = IniciativaCAT.Empregador,
                obsCAT = "Observacao",
                ultDiaTrab = new DateTime(2024, 1, 1),
                houveAfast = SimNaoString.Sim,
                localAcidente = new S2210LocalAcidente()
                {
                    tpLocal = TipoLocalAcidente.EmpregadorBrasil,
                    dscLocal = "Patio",
                    tpLograd = "Rua",
                    dscLograd = "A",
                    nrLograd = "123",
                    complemento = "Sala 1",
                    bairro = "Centro",
                    cep = "12345678",
                    codMunic = "1234567",
                    uf = "MG",
                    pais = "076",
                    codPostal = "12345",
                    ideLocalAcid = new S2210IdeLocalAcid()
                    {
                        tpInsc = PersonalidadeJuridica.CNPJ,
                        nrInsc = "12345678000123"
                    }
                },
                parteAtingida = new S2210ParteAtingida()
                {
                    codParteAting = "123456789",
                    lateralidade = Lateralidade.Esquerda
                },
                agenteCausador = new S2210AgenteCausador()
                {
                    codAgntCausador = "123456789"
                },
                atestado = new S2210Atestado()
                {
                    dtAtendimento = new DateTime(2024, 1, 1),
                    hrAtendimento = "1200",
                    indInternacao = SimNaoString.Nao,
                    durTrat = 10,
                    indAfast = SimNaoString.Sim,
                    dscLesao = "123456789",
                    dscCompLesao = "Corte",
                    diagProvavel = "Tétano",
                    codCID = "A00",
                    observacao = "Nada a declarar",
                    emitente = new S2210Emitente()
                    {
                        nmEmit = "Medico da Silva",
                        ideOC = OrgaoClasseSaude.CRM,
                        nrOC = "12345",
                        ufOC = "MG"
                    }
                },
                catOrigem = new S2210CatOrigem()
                {
                    nrRecCatOrig = "1.2.0000000000000000000"
                }
            }
        };
    }

    public override void ValidaInstanciasLeituraEscrita(S2210 instanciaPopulada, S2210 instanciaXml)
    {
        // ideEvento
        instanciaXml.evtCAT.ideEvento.tpAmb.Should().Be(instanciaPopulada.evtCAT.ideEvento.tpAmb);
        instanciaXml.evtCAT.ideEvento.procEmi.Should().Be(instanciaPopulada.evtCAT.ideEvento.procEmi);
        instanciaXml.evtCAT.ideEvento.verProc.Should().Be(instanciaPopulada.evtCAT.ideEvento.verProc);

        // ideEmpregador
        instanciaXml.evtCAT.ideEmpregador.tpInsc.Should().Be(instanciaPopulada.evtCAT.ideEmpregador.tpInsc);
        instanciaXml.evtCAT.ideEmpregador.nrInsc.Should().Be(instanciaPopulada.evtCAT.ideEmpregador.nrInsc);

        // ideVinculo
        instanciaXml.evtCAT.ideVinculo.cpfTrab.Should().Be(instanciaPopulada.evtCAT.ideVinculo.cpfTrab);
        instanciaXml.evtCAT.ideVinculo.matricula.Should().Be(instanciaPopulada.evtCAT.ideVinculo.matricula);
        instanciaXml.evtCAT.ideVinculo.codCateg.Should().Be(instanciaPopulada.evtCAT.ideVinculo.codCateg);

        // cat
        instanciaXml.evtCAT.cat.dtAcid.Should().BeSameDateAs(instanciaPopulada.evtCAT.cat.dtAcid);
        instanciaXml.evtCAT.cat.tpAcid.Should().Be(instanciaPopulada.evtCAT.cat.tpAcid);
        instanciaXml.evtCAT.cat.hrAcid.Should().Be(instanciaPopulada.evtCAT.cat.hrAcid);
        instanciaXml.evtCAT.cat.hrsTrabAntesAcid.Should().Be(instanciaPopulada.evtCAT.cat.hrsTrabAntesAcid);
        instanciaXml.evtCAT.cat.tpCat.Should().Be(instanciaPopulada.evtCAT.cat.tpCat);
        instanciaXml.evtCAT.cat.indCatObito.Should().Be(instanciaPopulada.evtCAT.cat.indCatObito);
        instanciaXml.evtCAT.cat.dtObito.Should().BeSameDateAs(instanciaPopulada.evtCAT.cat.dtObito.Value);
        instanciaXml.evtCAT.cat.indComunPolicia.Should().Be(instanciaPopulada.evtCAT.cat.indComunPolicia);
        instanciaXml.evtCAT.cat.codSitGeradora.Should().Be(instanciaPopulada.evtCAT.cat.codSitGeradora);
        instanciaXml.evtCAT.cat.iniciatCAT.Should().Be(instanciaPopulada.evtCAT.cat.iniciatCAT);
        instanciaXml.evtCAT.cat.obsCAT.Should().Be(instanciaPopulada.evtCAT.cat.obsCAT);
        instanciaXml.evtCAT.cat.ultDiaTrab.Should().BeSameDateAs(instanciaPopulada.evtCAT.cat.ultDiaTrab.Value);
        instanciaXml.evtCAT.cat.houveAfast.Should().Be(instanciaPopulada.evtCAT.cat.houveAfast);

        // localAcidente
        instanciaXml.evtCAT.cat.localAcidente.tpLocal.Should().Be(instanciaPopulada.evtCAT.cat.localAcidente.tpLocal);
        instanciaXml.evtCAT.cat.localAcidente.dscLocal.Should().Be(instanciaPopulada.evtCAT.cat.localAcidente.dscLocal);
        instanciaXml.evtCAT.cat.localAcidente.tpLograd.Should().Be(instanciaPopulada.evtCAT.cat.localAcidente.tpLograd);
        instanciaXml.evtCAT.cat.localAcidente.dscLograd.Should().Be(instanciaPopulada.evtCAT.cat.localAcidente.dscLograd);
        instanciaXml.evtCAT.cat.localAcidente.nrLograd.Should().Be(instanciaPopulada.evtCAT.cat.localAcidente.nrLograd);
        instanciaXml.evtCAT.cat.localAcidente.complemento.Should().Be(instanciaPopulada.evtCAT.cat.localAcidente.complemento);
        instanciaXml.evtCAT.cat.localAcidente.bairro.Should().Be(instanciaPopulada.evtCAT.cat.localAcidente.bairro);
        instanciaXml.evtCAT.cat.localAcidente.cep.Should().Be(instanciaPopulada.evtCAT.cat.localAcidente.cep);
        instanciaXml.evtCAT.cat.localAcidente.codMunic.Should().Be(instanciaPopulada.evtCAT.cat.localAcidente.codMunic);
        instanciaXml.evtCAT.cat.localAcidente.uf.Should().Be(instanciaPopulada.evtCAT.cat.localAcidente.uf);
        instanciaXml.evtCAT.cat.localAcidente.pais.Should().Be(instanciaPopulada.evtCAT.cat.localAcidente.pais);
        instanciaXml.evtCAT.cat.localAcidente.codPostal.Should().Be(instanciaPopulada.evtCAT.cat.localAcidente.codPostal);
        instanciaXml.evtCAT.cat.localAcidente.ideLocalAcid.tpInsc.Should().Be(instanciaPopulada.evtCAT.cat.localAcidente.ideLocalAcid.tpInsc);
        instanciaXml.evtCAT.cat.localAcidente.ideLocalAcid.nrInsc.Should().Be(instanciaPopulada.evtCAT.cat.localAcidente.ideLocalAcid.nrInsc);

        // parteAtingida
        instanciaXml.evtCAT.cat.parteAtingida.codParteAting.Should().Be(instanciaPopulada.evtCAT.cat.parteAtingida.codParteAting);
        instanciaXml.evtCAT.cat.parteAtingida.lateralidade.Should().Be(instanciaPopulada.evtCAT.cat.parteAtingida.lateralidade);

        // agenteCausador
        instanciaXml.evtCAT.cat.agenteCausador.codAgntCausador.Should().Be(instanciaPopulada.evtCAT.cat.agenteCausador.codAgntCausador);

        // atestado
        instanciaXml.evtCAT.cat.atestado.dtAtendimento.Should().BeSameDateAs(instanciaPopulada.evtCAT.cat.atestado.dtAtendimento);
        instanciaXml.evtCAT.cat.atestado.hrAtendimento.Should().Be(instanciaPopulada.evtCAT.cat.atestado.hrAtendimento);
        instanciaXml.evtCAT.cat.atestado.indInternacao.Should().Be(instanciaPopulada.evtCAT.cat.atestado.indInternacao);
        instanciaXml.evtCAT.cat.atestado.durTrat.Should().Be(instanciaPopulada.evtCAT.cat.atestado.durTrat);
        instanciaXml.evtCAT.cat.atestado.indAfast.Should().Be(instanciaPopulada.evtCAT.cat.atestado.indAfast);
        instanciaXml.evtCAT.cat.atestado.dscLesao.Should().Be(instanciaPopulada.evtCAT.cat.atestado.dscLesao);
        instanciaXml.evtCAT.cat.atestado.dscCompLesao.Should().Be(instanciaPopulada.evtCAT.cat.atestado.dscCompLesao);
        instanciaXml.evtCAT.cat.atestado.diagProvavel.Should().Be(instanciaPopulada.evtCAT.cat.atestado.diagProvavel);
        instanciaXml.evtCAT.cat.atestado.codCID.Should().Be(instanciaPopulada.evtCAT.cat.atestado.codCID);
        instanciaXml.evtCAT.cat.atestado.observacao.Should().Be(instanciaPopulada.evtCAT.cat.atestado.observacao);

        // emitente
        instanciaXml.evtCAT.cat.atestado.emitente.nmEmit.Should().Be(instanciaPopulada.evtCAT.cat.atestado.emitente.nmEmit);
        instanciaXml.evtCAT.cat.atestado.emitente.ideOC.Should().Be(instanciaPopulada.evtCAT.cat.atestado.emitente.ideOC);
        instanciaXml.evtCAT.cat.atestado.emitente.nrOC.Should().Be(instanciaPopulada.evtCAT.cat.atestado.emitente.nrOC);
        instanciaXml.evtCAT.cat.atestado.emitente.ufOC.Should().Be(instanciaPopulada.evtCAT.cat.atestado.emitente.ufOC);

        // catOrigem
        instanciaXml.evtCAT.cat.catOrigem.nrRecCatOrig.Should().Be(instanciaPopulada.evtCAT.cat.catOrigem.nrRecCatOrig);
    }
}
