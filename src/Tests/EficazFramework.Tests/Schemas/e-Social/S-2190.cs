using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.eSocial;

public class S2190Test : BaseESocialTest<S2190>
{
    [Test]
    [TestCase(Versao.v_S_01_02_00)]
    [TestCase(Versao.v_S_01_03_00)]
    public async Task Valida(Versao versao)
    {
        _versao = versao;
        ValidationSchemaNamespace = $"http://www.esocial.gov.br/schema/evt/evtAdmPrelim/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v_S_01_03_00 => Resources.Schemas.eSocial.S2190_v_S_01_03_01,
            _ => Resources.Schemas.eSocial.S2190_v_S_01_02_01
        };
        await TestaEvento();
    }

    [Test]
    public async Task Read_v_S_01_03_00()
    {
        var evento = await Evento.ReadAsync(Resources.Samples.eSocial.S2190_v_S_01_03_00);
        evento.Should().NotBeNull();
        evento.Versao.Should().Be(Versao.v_S_01_03_00);
        var evtAdmPrelim = evento as S2190;
        evtAdmPrelim.Should().NotBeNull();

        evtAdmPrelim.evtAdmPrelim.Id.Should().Be("ID1347855150000002024010100000000001");

        evtAdmPrelim.evtAdmPrelim.ideEvento.indRetif.Should().Be(IndicadorRetificacao.Original);
        evtAdmPrelim.evtAdmPrelim.ideEvento.tpAmb.Should().Be(Ambiente.ProducaoRestrita_DadosReais);
        evtAdmPrelim.evtAdmPrelim.ideEvento.procEmi.Should().Be(EmissorEvento.AppEmpregador);
        evtAdmPrelim.evtAdmPrelim.ideEvento.verProc.Should().Be("2.2");

        evtAdmPrelim.evtAdmPrelim.ideEmpregador.tpInsc.Should().Be(PersonalidadeJuridica.CNPJ);
        evtAdmPrelim.evtAdmPrelim.ideEmpregador.nrInsc.Should().Be("34785515");

        evtAdmPrelim.evtAdmPrelim.infoRegPrelim.cpfTrab.Should().Be("12345678901");
        evtAdmPrelim.evtAdmPrelim.infoRegPrelim.dtNascto.Should().BeSameDateAs(new DateTime(1990, 1, 1));
        evtAdmPrelim.evtAdmPrelim.infoRegPrelim.dtAdm.Should().BeSameDateAs(new DateTime(2024, 1, 1));
        evtAdmPrelim.evtAdmPrelim.infoRegPrelim.matricula.Should().Be("123456");
        evtAdmPrelim.evtAdmPrelim.infoRegPrelim.codCateg.Should().Be("101");
        evtAdmPrelim.evtAdmPrelim.infoRegPrelim.natAtividade.Should().Be(NaturezaAtividade.Urbano);

        evtAdmPrelim.evtAdmPrelim.infoRegPrelim.infoRegCTPS.CBOCargo.Should().Be("123456");
        evtAdmPrelim.evtAdmPrelim.infoRegPrelim.infoRegCTPS.vrSalFx.Should().Be(2500.50m);
        evtAdmPrelim.evtAdmPrelim.infoRegPrelim.infoRegCTPS.undSalFixo.Should().Be(UnidadeSalarial.Mes);
        evtAdmPrelim.evtAdmPrelim.infoRegPrelim.infoRegCTPS.tpContr.Should().Be(TipoContrato.Indeterminado);
        evtAdmPrelim.evtAdmPrelim.infoRegPrelim.infoRegCTPS.dtTerm.Value.Should().BeSameDateAs(new DateTime(2024, 12, 31));
    }

    public override void PreencheCampos(S2190 evento)
    {
        evento.Versao = _versao;
        evento.evtAdmPrelim = new S2190EvtAdmPrelim()
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
            infoRegPrelim = new S2190InfoRegPrelim()
            {
                cpfTrab = "12345678901",
                dtNascto = new DateTime(1990, 1, 1),
                dtAdm = new DateTime(2024, 1, 1),
                matricula = "123456",
                codCateg = "101",
                natAtividade = NaturezaAtividade.Urbano,
                infoRegCTPS = new S2190InfoRegCTPS()
                {
                    CBOCargo = "123456",
                    vrSalFx = 2500.50m,
                    undSalFixo = UnidadeSalarial.Mes,
                    tpContr = TipoContrato.Indeterminado,
                    dtTerm = new DateTime(2024, 12, 31)
                }
            }
        };
    }

    public override void ValidaInstanciasLeituraEscrita(S2190 instanciaPopulada, S2190 instanciaXml)
    {
        // ideEvento
        instanciaXml.evtAdmPrelim.ideEvento.tpAmb.Should().Be(instanciaPopulada.evtAdmPrelim.ideEvento.tpAmb);
        instanciaXml.evtAdmPrelim.ideEvento.procEmi.Should().Be(instanciaPopulada.evtAdmPrelim.ideEvento.procEmi);
        instanciaXml.evtAdmPrelim.ideEvento.verProc.Should().Be(instanciaPopulada.evtAdmPrelim.ideEvento.verProc);

        // ideEmpregador
        instanciaXml.evtAdmPrelim.ideEmpregador.tpInsc.Should().Be(instanciaPopulada.evtAdmPrelim.ideEmpregador.tpInsc);
        instanciaXml.evtAdmPrelim.ideEmpregador.nrInsc.Should().Be(instanciaPopulada.evtAdmPrelim.ideEmpregador.nrInsc);

        // infoRegPrelim
        instanciaXml.evtAdmPrelim.infoRegPrelim.cpfTrab.Should().Be(instanciaPopulada.evtAdmPrelim.infoRegPrelim.cpfTrab);
        instanciaXml.evtAdmPrelim.infoRegPrelim.dtNascto.Should().BeSameDateAs(instanciaPopulada.evtAdmPrelim.infoRegPrelim.dtNascto);
        instanciaXml.evtAdmPrelim.infoRegPrelim.dtAdm.Should().BeSameDateAs(instanciaPopulada.evtAdmPrelim.infoRegPrelim.dtAdm);
        instanciaXml.evtAdmPrelim.infoRegPrelim.matricula.Should().Be(instanciaPopulada.evtAdmPrelim.infoRegPrelim.matricula);
        instanciaXml.evtAdmPrelim.infoRegPrelim.codCateg.Should().Be(instanciaPopulada.evtAdmPrelim.infoRegPrelim.codCateg);
        instanciaXml.evtAdmPrelim.infoRegPrelim.natAtividade.Should().Be(instanciaPopulada.evtAdmPrelim.infoRegPrelim.natAtividade);

        // infoRegCTPS
        instanciaXml.evtAdmPrelim.infoRegPrelim.infoRegCTPS.CBOCargo.Should().Be(instanciaPopulada.evtAdmPrelim.infoRegPrelim.infoRegCTPS.CBOCargo);
        instanciaXml.evtAdmPrelim.infoRegPrelim.infoRegCTPS.vrSalFx.Should().Be(instanciaPopulada.evtAdmPrelim.infoRegPrelim.infoRegCTPS.vrSalFx);
        instanciaXml.evtAdmPrelim.infoRegPrelim.infoRegCTPS.undSalFixo.Should().Be(instanciaPopulada.evtAdmPrelim.infoRegPrelim.infoRegCTPS.undSalFixo);
        instanciaXml.evtAdmPrelim.infoRegPrelim.infoRegCTPS.tpContr.Should().Be(instanciaPopulada.evtAdmPrelim.infoRegPrelim.infoRegCTPS.tpContr);
        instanciaXml.evtAdmPrelim.infoRegPrelim.infoRegCTPS.dtTerm.Value.Should().BeSameDateAs(instanciaPopulada.evtAdmPrelim.infoRegPrelim.infoRegCTPS.dtTerm.Value);
    }
}
