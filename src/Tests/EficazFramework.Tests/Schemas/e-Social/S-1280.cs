using System.Collections.Generic;
using System.Threading.Tasks;

namespace EficazFramework.SPED.Schemas.eSocial;

public class S1280Test : BaseESocialTest<S1280>
{
    [Test]
    [TestCase(Versao.v_S_01_02_00)]
    [TestCase(Versao.v_S_01_03_00)]
    public async Task Valida(Versao versao)
    {
        _versao = versao;
        ValidationSchemaNamespace = $"http://www.esocial.gov.br/schema/evt/evtInfoComplPer/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v_S_01_02_00 => Resources.Schemas.eSocial.S1280_v_S_01_02_00,
            _ => Resources.Schemas.eSocial.S1280_v_S_01_03_00
        };
        await TestaEvento();
    }

    // BaseESocialTest overrides
    public override void PreencheCampos(S1280 evento)
    {
        evento.Versao = _versao;
        evento.evtInfoComplPer = new S1280InfoComplPer()
        {
            ideEvento = new IdeEventoPeriodico()
            {
                indRetif = IndicadorRetificacao.Original,
                indApuracao = IndicadorApuracao.Mensal,
                perApur = "2025-02",
                indGuia = IndicadorGuia.DAE,
                tpAmb = Ambiente.ProducaoRestrita_DadosReais,
                procEmi = EmissorEvento.AppEmpregador,
                verProc = "v_S_01_03_00"
            },
            ideEmpregador = new Empregador()
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = CnpjCpf.Substring(0, 8)
            },
            infoSubstPatr = new S1280InfoSubstPatr()
            {
                indSubstPatr = IndicadorSubstPatronal.ParcialmenteSubstituida,
                percRedContrib = 50.5m
            },
            infoSubstPatrOpPort = new List<S1280InfoSubstPatrOpPort>()
            {
                new S1280InfoSubstPatrOpPort() { codLotacao = "L01" }
            },
            infoAtivConcom = new S1280InfoAtivConcom()
            {
                fatorMes = 1.2m,
                fator13 = 1.5m
            },
            infoPercTransf11096 = new S1280InfoPercTransf11096()
            {
                percTransf = PercentualTransformacao.Perc20
            }
        };
    }

    public override void ValidaInstanciasLeituraEscrita(S1280 instanciaPopulada, S1280 instanciaXml)
    {
        // ideEvento
        instanciaXml.evtInfoComplPer.ideEvento.indRetif.Should().Be(instanciaPopulada.evtInfoComplPer.ideEvento.indRetif);
        instanciaXml.evtInfoComplPer.ideEvento.indApuracao.Should().Be(instanciaPopulada.evtInfoComplPer.ideEvento.indApuracao);
        instanciaXml.evtInfoComplPer.ideEvento.perApur.Should().Be(instanciaPopulada.evtInfoComplPer.ideEvento.perApur);
        instanciaXml.evtInfoComplPer.ideEvento.indGuia.Should().Be(instanciaPopulada.evtInfoComplPer.ideEvento.indGuia);
        instanciaXml.evtInfoComplPer.ideEvento.tpAmb.Should().Be(instanciaPopulada.evtInfoComplPer.ideEvento.tpAmb);
        instanciaXml.evtInfoComplPer.ideEvento.procEmi.Should().Be(instanciaPopulada.evtInfoComplPer.ideEvento.procEmi);
        instanciaXml.evtInfoComplPer.ideEvento.verProc.Should().Be(instanciaPopulada.evtInfoComplPer.ideEvento.verProc);

        // ideEmpregador
        instanciaXml.evtInfoComplPer.ideEmpregador.tpInsc.Should().Be(instanciaPopulada.evtInfoComplPer.ideEmpregador.tpInsc);
        instanciaXml.evtInfoComplPer.ideEmpregador.nrInsc.Should().Be(instanciaPopulada.evtInfoComplPer.ideEmpregador.nrInsc);

        // infoSubstPatr
        instanciaXml.evtInfoComplPer.infoSubstPatr.Should().NotBeNull();
        instanciaXml.evtInfoComplPer.infoSubstPatr.indSubstPatr.Should().Be(instanciaPopulada.evtInfoComplPer.infoSubstPatr.indSubstPatr);
        instanciaXml.evtInfoComplPer.infoSubstPatr.percRedContrib.Should().Be(instanciaPopulada.evtInfoComplPer.infoSubstPatr.percRedContrib);

        // infoSubstPatrOpPort
        instanciaXml.evtInfoComplPer.infoSubstPatrOpPort.Should().NotBeNull().And.HaveCount(1);
        instanciaXml.evtInfoComplPer.infoSubstPatrOpPort[0].codLotacao.Should().Be(instanciaPopulada.evtInfoComplPer.infoSubstPatrOpPort[0].codLotacao);

        // infoAtivConcom
        instanciaXml.evtInfoComplPer.infoAtivConcom.Should().NotBeNull();
        instanciaXml.evtInfoComplPer.infoAtivConcom.fatorMes.Should().Be(instanciaPopulada.evtInfoComplPer.infoAtivConcom.fatorMes);
        instanciaXml.evtInfoComplPer.infoAtivConcom.fator13.Should().Be(instanciaPopulada.evtInfoComplPer.infoAtivConcom.fator13);

        // infoPercTransf11096
        instanciaXml.evtInfoComplPer.infoPercTransf11096.Should().NotBeNull();
        instanciaXml.evtInfoComplPer.infoPercTransf11096.percTransf.Should().Be(instanciaPopulada.evtInfoComplPer.infoPercTransf11096.percTransf);
    }
}
