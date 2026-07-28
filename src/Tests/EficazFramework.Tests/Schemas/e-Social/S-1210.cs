namespace EficazFramework.SPED.Schemas.eSocial;

public class S1210Test : BaseESocialTest<S1210>
{
    [Test]
    [TestCase(Versao.v_S_01_02_00)]
    [TestCase(Versao.v_S_01_03_00)]
    public async Task Valida(Versao versao)
    {
        _versao = versao;
        ValidationSchemaNamespace = $"http://www.esocial.gov.br/schema/evt/evtPgtos/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v_S_01_02_00 => Resources.Schemas.eSocial.S1210_v_S_01_02_00,
            _ => Resources.Schemas.eSocial.S1210_v_S_01_03_00
        };
        await TestaEvento();
    }

    [Test]
    public async Task Read_v_S_01_03_00()
    {
        var evento = await Evento.ReadAsync(Resources.Samples.eSocial.S1210_v_S_01_03_00);
        evento.Should().NotBeNull();
        evento.Versao.Should().Be(Versao.v_S_01_03_00);

        var evtPgtos = evento as S1210;
        evtPgtos.Should().NotBeNull();
        evtPgtos.evtPgtos.Id.Should().Be("ID1345571090000002025030512521100001");

        // ideEvento
        evtPgtos.evtPgtos.ideEvento.indRetif.Should().Be(IndicadorRetificacao.Original);
        evtPgtos.evtPgtos.ideEvento.perApur.Should().Be("2025-02");
        evtPgtos.evtPgtos.ideEvento.tpAmb.Should().Be(Ambiente.Producao);
        evtPgtos.evtPgtos.ideEvento.procEmi.Should().Be(EmissorEvento.AppEmpregador);
        evtPgtos.evtPgtos.ideEvento.verProc.Should().Be("v_S_01_03_00");

        // ideEmpregador
        evtPgtos.evtPgtos.ideEmpregador.tpInsc.Should().Be(PersonalidadeJuridica.CNPJ);
        evtPgtos.evtPgtos.ideEmpregador.nrInsc.Should().Be("34557109");

        // ideBenef
        evtPgtos.evtPgtos.ideBenef.Should().NotBeNull();
        evtPgtos.evtPgtos.ideBenef.cpfBenef.Should().Be("15273627877");
        evtPgtos.evtPgtos.ideBenef.infoPgto.Should().HaveCount(1);

        var pgto = evtPgtos.evtPgtos.ideBenef.infoPgto[0];
        pgto.dtPgto.Should().Be(new DateTime(2025, 2, 28));
        pgto.tpPgto.Should().Be(TipoPagamento.RemuneracaoS1200);
        pgto.perRef.Should().Be("2025-02");
        pgto.ideDmDev.Should().Be("022025MENSAL14022025155159");
        pgto.vrLiq.Should().Be(1351.02m);
    }

    // BaseESocialTest overrides
    public override void PreencheCampos(S1210 evento)
    {
        evento.Versao = _versao;
        evento.evtPgtos = new S1210EvtPgtos()
        {
            ideEvento = new IdeEventoFolhaMensal()
            {
                tpAmb = Ambiente.ProducaoRestrita_DadosReais,
                procEmi = EmissorEvento.AppEmpregador,
                perApur = "2025-02",
                verProc = "2.2"
            },
            ideEmpregador = new Empregador()
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = CnpjCpf[..8]
            },
            ideBenef = new S1210IdeBenef()
            {
                cpfBenef = "15273627877",
                infoPgto =
                [
                    new S1210InfoPgto()
                    {
                        dtPgto = new DateTime(2025, 2, 28),
                        tpPgto = TipoPagamento.RemuneracaoS1200,
                        perRef = "2025-02",
                        ideDmDev = "022025MENSAL14022025155159",
                        vrLiq = 1351.02m
                    }
                ]
            }
        };
    }

    public override void ValidaInstanciasLeituraEscrita(S1210 instanciaPopulada, S1210 instanciaXml)
    {
        instanciaPopulada.Should().NotBeNull();
        instanciaXml.Should().NotBeNull();

        // ideEvento
        instanciaXml.evtPgtos.ideEvento.tpAmb.Should().Be(instanciaPopulada.evtPgtos.ideEvento.tpAmb);
        instanciaXml.evtPgtos.ideEvento.procEmi.Should().Be(instanciaPopulada.evtPgtos.ideEvento.procEmi);
        instanciaXml.evtPgtos.ideEvento.verProc.Should().Be(instanciaPopulada.evtPgtos.ideEvento.verProc);
        instanciaXml.evtPgtos.ideEvento.perApur.Should().Be(instanciaPopulada.evtPgtos.ideEvento.perApur);

        // ideEmpregador
        instanciaXml.evtPgtos.ideEmpregador.tpInsc.Should().Be(instanciaPopulada.evtPgtos.ideEmpregador.tpInsc);
        instanciaXml.evtPgtos.ideEmpregador.nrInsc.Should().Be(instanciaPopulada.evtPgtos.ideEmpregador.nrInsc);

        // ideBenef
        instanciaXml.evtPgtos.ideBenef.Should().NotBeNull();
        instanciaXml.evtPgtos.ideBenef.cpfBenef.Should().Be(instanciaPopulada.evtPgtos.ideBenef.cpfBenef);

        // infoPgto
        instanciaXml.evtPgtos.ideBenef.infoPgto.Should().HaveCount(1);
        instanciaPopulada.evtPgtos.ideBenef.infoPgto.Should().HaveCount(1);

        var pgtoXml = instanciaXml.evtPgtos.ideBenef.infoPgto[0];
        var pgtoPopulado = instanciaPopulada.evtPgtos.ideBenef.infoPgto[0];

        pgtoXml.dtPgto.Should().Be(pgtoPopulado.dtPgto);
        pgtoXml.tpPgto.Should().Be(pgtoPopulado.tpPgto);
        pgtoXml.perRef.Should().Be(pgtoPopulado.perRef);
        pgtoXml.ideDmDev.Should().Be(pgtoPopulado.ideDmDev);
        pgtoXml.vrLiq.Should().Be(pgtoPopulado.vrLiq);
    }
}
