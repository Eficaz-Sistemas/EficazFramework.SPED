using EficazFramework.SPED.Schemas.eSocial;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace EficazFramework.SPED.Schemas.eSocial;

public class S2230Test : BaseESocialTest<S2230>
{
    private int _testNumber = 0;

    [Test]
    [TestCase(Versao.v_S_01_02_00)]
    [TestCase(Versao.v_S_01_03_00)]
    public async Task Valida(Versao versao)
    {
        _testNumber = 0;
        _versao = versao;
        ValidationSchemaNamespace = $"http://www.esocial.gov.br/schema/evt/evtAfastTemp/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v_S_01_03_00 => Resources.Schemas.eSocial.S2230_v_S_01_03_01,
            _ => Resources.Schemas.eSocial.S2230_v_S_01_02_01
        };
        await TestaEvento();
    }

    [Test]
    public async Task Read_v_S_01_03_00()
    {
        var evento = await Evento.ReadAsync(Resources.Samples.eSocial.S2230_v_S_01_03_00);
        evento.Should().NotBeNull();
        evento.Versao.Should().Be(Versao.v_S_01_03_00);
        var evtAfastTemp = evento as S2230;
        evtAfastTemp.Should().NotBeNull();
        
        evtAfastTemp.evtAfastTemp.Id.Should().Be("ID1000000000000002024010100000000000");
        
        evtAfastTemp.evtAfastTemp.ideEvento.indRetif.Should().Be(IndicadorRetificacao.Original);
        evtAfastTemp.evtAfastTemp.ideEvento.tpAmb.Should().Be(Ambiente.ProducaoRestrita_DadosReais);
        evtAfastTemp.evtAfastTemp.ideEvento.procEmi.Should().Be(EmissorEvento.AppEmpregador);
        evtAfastTemp.evtAfastTemp.ideEvento.verProc.Should().Be("1.0");

        evtAfastTemp.evtAfastTemp.ideEmpregador.tpInsc.Should().Be(PersonalidadeJuridica.CNPJ);
        evtAfastTemp.evtAfastTemp.ideEmpregador.nrInsc.Should().Be("00000000");

        evtAfastTemp.evtAfastTemp.ideVinculo.cpfTrab.Should().Be("12345678901");
        evtAfastTemp.evtAfastTemp.ideVinculo.matricula.Should().Be("123456");
        evtAfastTemp.evtAfastTemp.ideVinculo.codCateg.Should().Be("101");

        evtAfastTemp.evtAfastTemp.infoAfastamento.iniAfastamento.dtIniAfast.Should().BeSameDateAs(new DateTime(2024, 1, 1));
        evtAfastTemp.evtAfastTemp.infoAfastamento.iniAfastamento.codMotAfast.Should().Be("01");
        evtAfastTemp.evtAfastTemp.infoAfastamento.iniAfastamento.infoMesmoMtv.Should().Be(SimNaoString.Sim);
        evtAfastTemp.evtAfastTemp.infoAfastamento.iniAfastamento.tpAcidTransito.Should().Be(TipoAcidenteTransito.Atropelamento);
        evtAfastTemp.evtAfastTemp.infoAfastamento.iniAfastamento.observacao.Should().Be("Observação teste");
        
        evtAfastTemp.evtAfastTemp.infoAfastamento.iniAfastamento.perAquis.dtInicio.Should().BeSameDateAs(new DateTime(2023, 1, 1));
        evtAfastTemp.evtAfastTemp.infoAfastamento.iniAfastamento.perAquis.dtFim.Should().BeSameDateAs(new DateTime(2023, 12, 31));

        evtAfastTemp.evtAfastTemp.infoAfastamento.iniAfastamento.infoCessao.cnpjCess.Should().Be("12345678000123");
        evtAfastTemp.evtAfastTemp.infoAfastamento.iniAfastamento.infoCessao.infOnus.Should().Be(OnusCessao.Cedente);

        evtAfastTemp.evtAfastTemp.infoAfastamento.iniAfastamento.infoMandSind.cnpjSind.Should().Be("12345678000123");
        evtAfastTemp.evtAfastTemp.infoAfastamento.iniAfastamento.infoMandSind.infOnusRemun.Should().Be(OnusRemuneracao.Empregador);

        evtAfastTemp.evtAfastTemp.infoAfastamento.iniAfastamento.infoMandElet.cnpjMandElet.Should().Be("12345678000123");
        evtAfastTemp.evtAfastTemp.infoAfastamento.iniAfastamento.infoMandElet.indRemunCargo.Should().Be(SimNaoString.Sim);

        evtAfastTemp.evtAfastTemp.infoAfastamento.infoRetif.origRetif.Should().Be(OrigemRetificacao.Empregador);
        evtAfastTemp.evtAfastTemp.infoAfastamento.infoRetif.tpProc.Should().Be(TipoProcessoRetificacao.Administrativo);
        evtAfastTemp.evtAfastTemp.infoAfastamento.infoRetif.nrProc.Should().Be("12345678901234567");

        evtAfastTemp.evtAfastTemp.infoAfastamento.fimAfastamento.dtTermAfast.Should().BeSameDateAs(new DateTime(2024, 1, 31));
    }

    public override void PreencheCampos(S2230 evento)
    {
        evento.Versao = _versao;
        PreencheCampos(evento, CnpjCpf);
    }


    public override void ValidaInstanciasLeituraEscrita(S2230 instanciaPopulada, S2230 instanciaXml)
    {
        instanciaXml.evtAfastTemp.ideEvento.indRetif.Should().Be(instanciaPopulada.evtAfastTemp.ideEvento.indRetif);
        instanciaXml.evtAfastTemp.ideEvento.tpAmb.Should().Be(instanciaPopulada.evtAfastTemp.ideEvento.tpAmb);
        instanciaXml.evtAfastTemp.ideEvento.procEmi.Should().Be(instanciaPopulada.evtAfastTemp.ideEvento.procEmi);
        instanciaXml.evtAfastTemp.ideEvento.verProc.Should().Be(instanciaPopulada.evtAfastTemp.ideEvento.verProc);

        instanciaXml.evtAfastTemp.ideEmpregador.tpInsc.Should().Be(instanciaPopulada.evtAfastTemp.ideEmpregador.tpInsc);
        instanciaXml.evtAfastTemp.ideEmpregador.nrInsc.Should().Be(instanciaPopulada.evtAfastTemp.ideEmpregador.nrInsc);

        instanciaXml.evtAfastTemp.ideVinculo.cpfTrab.Should().Be(instanciaPopulada.evtAfastTemp.ideVinculo.cpfTrab);
        instanciaXml.evtAfastTemp.ideVinculo.matricula.Should().Be(instanciaPopulada.evtAfastTemp.ideVinculo.matricula);
        instanciaXml.evtAfastTemp.ideVinculo.codCateg.Should().Be(instanciaPopulada.evtAfastTemp.ideVinculo.codCateg);

        instanciaXml.evtAfastTemp.infoAfastamento.iniAfastamento.dtIniAfast.Should().BeSameDateAs(instanciaPopulada.evtAfastTemp.infoAfastamento.iniAfastamento.dtIniAfast);
        instanciaXml.evtAfastTemp.infoAfastamento.iniAfastamento.codMotAfast.Should().Be(instanciaPopulada.evtAfastTemp.infoAfastamento.iniAfastamento.codMotAfast);
        instanciaXml.evtAfastTemp.infoAfastamento.iniAfastamento.infoMesmoMtv.Should().Be(instanciaPopulada.evtAfastTemp.infoAfastamento.iniAfastamento.infoMesmoMtv);
        instanciaXml.evtAfastTemp.infoAfastamento.iniAfastamento.tpAcidTransito.Should().Be(instanciaPopulada.evtAfastTemp.infoAfastamento.iniAfastamento.tpAcidTransito);
        instanciaXml.evtAfastTemp.infoAfastamento.iniAfastamento.observacao.Should().Be(instanciaPopulada.evtAfastTemp.infoAfastamento.iniAfastamento.observacao);

        instanciaXml.evtAfastTemp.infoAfastamento.iniAfastamento.perAquis.dtInicio.Should().BeSameDateAs(instanciaPopulada.evtAfastTemp.infoAfastamento.iniAfastamento.perAquis.dtInicio);
        instanciaXml.evtAfastTemp.infoAfastamento.iniAfastamento.perAquis.dtFim.Should().BeSameDateAs(instanciaPopulada.evtAfastTemp.infoAfastamento.iniAfastamento.perAquis.dtFim.Value);

        instanciaXml.evtAfastTemp.infoAfastamento.iniAfastamento.infoCessao.cnpjCess.Should().Be(instanciaPopulada.evtAfastTemp.infoAfastamento.iniAfastamento.infoCessao.cnpjCess);
        instanciaXml.evtAfastTemp.infoAfastamento.iniAfastamento.infoCessao.infOnus.Should().Be(instanciaPopulada.evtAfastTemp.infoAfastamento.iniAfastamento.infoCessao.infOnus);

        instanciaXml.evtAfastTemp.infoAfastamento.iniAfastamento.infoMandSind.cnpjSind.Should().Be(instanciaPopulada.evtAfastTemp.infoAfastamento.iniAfastamento.infoMandSind.cnpjSind);
        instanciaXml.evtAfastTemp.infoAfastamento.iniAfastamento.infoMandSind.infOnusRemun.Should().Be(instanciaPopulada.evtAfastTemp.infoAfastamento.iniAfastamento.infoMandSind.infOnusRemun);

        instanciaXml.evtAfastTemp.infoAfastamento.iniAfastamento.infoMandElet.cnpjMandElet.Should().Be(instanciaPopulada.evtAfastTemp.infoAfastamento.iniAfastamento.infoMandElet.cnpjMandElet);
        instanciaXml.evtAfastTemp.infoAfastamento.iniAfastamento.infoMandElet.indRemunCargo.Should().Be(instanciaPopulada.evtAfastTemp.infoAfastamento.iniAfastamento.infoMandElet.indRemunCargo);

        instanciaXml.evtAfastTemp.infoAfastamento.infoRetif.origRetif.Should().Be(instanciaPopulada.evtAfastTemp.infoAfastamento.infoRetif.origRetif);
        instanciaXml.evtAfastTemp.infoAfastamento.infoRetif.tpProc.Should().Be(instanciaPopulada.evtAfastTemp.infoAfastamento.infoRetif.tpProc);
        instanciaXml.evtAfastTemp.infoAfastamento.infoRetif.nrProc.Should().Be(instanciaPopulada.evtAfastTemp.infoAfastamento.infoRetif.nrProc);

        instanciaXml.evtAfastTemp.infoAfastamento.fimAfastamento.dtTermAfast.Should().BeSameDateAs(instanciaPopulada.evtAfastTemp.infoAfastamento.fimAfastamento.dtTermAfast);
    }

    internal static void PreencheCampos(S2230 evento, string cnpjCpf)
    {
        evento.evtAfastTemp = new S2230EvtAfastTemp()
        {
            ideEvento = new IdeEventoNaoPeriodico()
            {
                indRetif = IndicadorRetificacao.Original,
                tpAmb = Ambiente.ProducaoRestrita_DadosReais,
                procEmi = EmissorEvento.AppEmpregador,
                verProc = "1.0"
            },
            ideEmpregador = new Empregador()
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = "00000000"
            },
            ideVinculo = new S2230IdeVinculo()
            {
                cpfTrab = "12345678901",
                matricula = "123456",
                codCateg = "101"
            },
            infoAfastamento = new S2230InfoAfastamento()
            {
                iniAfastamento = new S2230IniAfastamento()
                {
                    dtIniAfast = new DateTime(2024, 1, 1),
                    codMotAfast = "01",
                    infoMesmoMtv = SimNaoString.Sim,
                    infoMesmoMtvSpecified = true,
                    tpAcidTransito = TipoAcidenteTransito.Atropelamento,
                    tpAcidTransitoSpecified = true,
                    observacao = "Observação teste",
                    perAquis = new S2230PerAquis()
                    {
                        dtInicio = new DateTime(2023, 1, 1),
                        dtFim = new DateTime(2023, 12, 31)
                    },
                    infoCessao = new S2230InfoCessao()
                    {
                        cnpjCess = "12345678000123",
                        infOnus = OnusCessao.Cedente
                    },
                    infoMandSind = new S2230InfoMandSind()
                    {
                        cnpjSind = "12345678000123",
                        infOnusRemun = OnusRemuneracao.Empregador
                    },
                    infoMandElet = new S2230InfoMandElet()
                    {
                        cnpjMandElet = "12345678000123",
                        indRemunCargo = SimNaoString.Sim,
                        indRemunCargoSpecified = true
                    }
                },
                infoRetif = new S2230InfoRetif()
                {
                    origRetif = OrigemRetificacao.Empregador,
                    tpProc = TipoProcessoRetificacao.Administrativo,
                    tpProcSpecified = true,
                    nrProc = "12345678901234567"
                },
                fimAfastamento = new S2230FimAfastamento()
                {
                    dtTermAfast = new DateTime(2024, 1, 31)
                }
            }
        };
    }
}
