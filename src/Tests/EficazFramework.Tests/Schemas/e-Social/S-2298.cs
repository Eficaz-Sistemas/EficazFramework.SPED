using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.eSocial;

public class S2298Test : BaseESocialTest<S2298>
{
    private bool _anistia;

    [Test]
    [TestCase(Versao.v_S_01_03_00)]
    public async Task Valida(Versao versao)
    {
        _anistia = false;
        await ValidaEvento(versao);
    }

    [Test]
    [TestCase(Versao.v_S_01_03_00)]
    public async Task ValidaAnistia(Versao versao)
    {
        _anistia = true;
        await ValidaEvento(versao);
    }

    private async Task ValidaEvento(Versao versao)
    {
        _versao = versao;
        ValidationSchemaNamespace = $"http://www.esocial.gov.br/schema/evt/evtReintegr/{versao}";
        ValidationSchema = Resources.Schemas.eSocial.S2298_v_S_01_03_00;
        await TestaEvento();
    }

    [Test]
    public async Task Read_v_S_01_03_00()
    {
        var evento = await Evento.ReadAsync(Resources.Samples.eSocial.S2298_v_S_01_03_00);
        evento.Should().NotBeNull();
        evento.Should().BeOfType<S2298>();

        var ev2298 = evento as S2298;

        // ideEvento
        ev2298.evtReintegr.ideEvento.indRetif.Should().Be(IndicadorRetificacao.Original);
        ev2298.evtReintegr.ideEvento.nrRecibo.Should().BeNull();
        ev2298.evtReintegr.ideEvento.tpAmb.Should().Be(Ambiente.ProducaoRestrita_DadosReais);
        ev2298.evtReintegr.ideEvento.procEmi.Should().Be(EmissorEvento.AppEmpregador);
        ev2298.evtReintegr.ideEvento.verProc.Should().Be("EficazFramework");

        // ideEmpregador
        ev2298.evtReintegr.ideEmpregador.tpInsc.Should().Be(PersonalidadeJuridica.CNPJ);
        ev2298.evtReintegr.ideEmpregador.nrInsc.Should().Be("34785515000166");

        // ideVinculo
        ev2298.evtReintegr.ideVinculo.cpfTrab.Should().Be("12345678901");
        ev2298.evtReintegr.ideVinculo.matricula.Should().Be("123");

        // infoReintegr
        var info = ev2298.evtReintegr.infoReintegr;
        info.Should().NotBeNull();
        info.tpReint.Should().Be(TipoReintegracao.DecisaoJudicial);
        info.nrProcJud.Should().Be("12345678901234567890");
        info.nrLeiAnistia.Should().BeNull();
        info.dtEfetRetorno.Should().Be(new DateTime(2026, 10, 15));
        info.dtEfeito.Should().Be(new DateTime(2026, 10, 1));
    }

    public override void PreencheCampos(S2298 evento)
    {
        evento.Versao = _versao;

        evento.evtReintegr = new S2298EvtReintegr
        {
            ideEvento = new S2298IdeEvento
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

            ideVinculo = new S2298IdeVinculo
            {
                cpfTrab = "12345678901",
                matricula = "123"
            },

            infoReintegr = new S2298InfoReintegr
            {
                tpReint = _anistia ? TipoReintegracao.AnistiaLegal : TipoReintegracao.DecisaoJudicial,
                nrProcJud = _anistia ? null : "12345678901234567890",
                nrLeiAnistia = _anistia ? "L887894" : null,
                dtEfetRetorno = new DateTime(2026, 10, 15),
                dtEfeito = new DateTime(2026, 10, 1)
            }
        };
    }

    public override void ValidaInstanciasLeituraEscrita(S2298 instanciaPopulada, S2298 instanciaXml)
    {
        instanciaXml.Should().NotBeNull();
        instanciaXml.evtReintegr.Should().NotBeNull();

        var pop = instanciaPopulada.evtReintegr;
        var xml = instanciaXml.evtReintegr;

        xml.Id.Should().Be(pop.Id);
        xml.ideEvento.indRetif.Should().Be(pop.ideEvento.indRetif);
        xml.ideEvento.nrRecibo.Should().Be(pop.ideEvento.nrRecibo);
        xml.ideEvento.tpAmb.Should().Be(pop.ideEvento.tpAmb);
        xml.ideEvento.procEmi.Should().Be(pop.ideEvento.procEmi);
        xml.ideEvento.verProc.Should().Be(pop.ideEvento.verProc);

        xml.ideEmpregador.tpInsc.Should().Be(pop.ideEmpregador.tpInsc);
        xml.ideEmpregador.nrInsc.Should().Be(pop.ideEmpregador.nrInsc);

        xml.ideVinculo.cpfTrab.Should().Be(pop.ideVinculo.cpfTrab);
        xml.ideVinculo.matricula.Should().Be(pop.ideVinculo.matricula);

        xml.infoReintegr.tpReint.Should().Be(pop.infoReintegr.tpReint);
        xml.infoReintegr.nrProcJud.Should().Be(pop.infoReintegr.nrProcJud);
        xml.infoReintegr.nrLeiAnistia.Should().Be(pop.infoReintegr.nrLeiAnistia);
        xml.infoReintegr.dtEfetRetorno.Should().BeSameDateAs(pop.infoReintegr.dtEfetRetorno);
        xml.infoReintegr.dtEfeito.Should().BeSameDateAs(pop.infoReintegr.dtEfeito);
    }
}
