using System.Threading.Tasks;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.eSocial;

public class S3000Test : BaseESocialTest<S3000>
{
    [Test]
    [TestCase(Versao.v_S_01_02_00)]
    [TestCase(Versao.v_S_01_03_00)]
    public async Task Valida(Versao versao)
    {
        _versao = versao;
        ValidationSchemaNamespace = $"http://www.esocial.gov.br/schema/evt/evtExclusao/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v_S_01_03_00 => Resources.Schemas.eSocial.S3000_v_S_01_03_00,
            _ => Resources.Schemas.eSocial.S3000_v_S_01_02_00
        };
        await TestaEvento();
    }

    [Test]
    public async Task Read_v_S_01_03_00()
    {
        var evento = await Evento.ReadAsync(Resources.Samples.eSocial.S3000_v_S_01_03_00);
        evento.Should().NotBeNull();
        evento.Should().BeOfType<S3000>();

        var ev3000 = evento as S3000;

        // ideEvento
        ev3000.evtExclusao.ideEvento.tpAmb.Should().Be(Ambiente.ProducaoRestrita_DadosReais);
        ev3000.evtExclusao.ideEvento.procEmi.Should().Be(EmissorEvento.AppEmpregador);
        ev3000.evtExclusao.ideEvento.verProc.Should().Be("EficazFramework");

        // ideEmpregador
        ev3000.evtExclusao.ideEmpregador.tpInsc.Should().Be(PersonalidadeJuridica.CNPJ);
        ev3000.evtExclusao.ideEmpregador.nrInsc.Should().Be("34785515000166");

        // infoExclusao
        var info = ev3000.evtExclusao.infoExclusao;
        info.Should().NotBeNull();
        info.tpEvento.Should().Be("S-1200");
        info.nrRecEvt.Should().Be("1.1.0000000000000000000");

        info.ideTrabalhador.Should().NotBeNull();
        info.ideTrabalhador.cpfTrab.Should().Be("12345678901");

        info.ideFolhaPagto.Should().NotBeNull();
        info.ideFolhaPagto.indApuracao.Should().Be(IndicadorApuracao.Mensal);
        info.ideFolhaPagto.perApur.Should().Be("2023-05");
    }

    public override void PreencheCampos(S3000 evento)
    {
        evento.Versao = _versao;

        evento.evtExclusao = new S3000EvtExclusao
        {
            ideEvento = new IdentificacaoCadastro
            {
                tpAmb = Ambiente.ProducaoRestrita_DadosReais,
                procEmi = EmissorEvento.AppEmpregador,
                verProc = "EficazFramework"
            },
            ideEmpregador = new Empregador
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = CnpjCpf
            },
            infoExclusao = new S3000InfoExclusao
            {
                tpEvento = "S-1200",
                nrRecEvt = "1.1.0000000000000000000",
                ideTrabalhador = new S3000IdeTrabalhador
                {
                    cpfTrab = "12345678901"
                },
                ideFolhaPagto = new S3000IdeFolhaPagto
                {
                    indApuracao = IndicadorApuracao.Mensal,
                    perApur = "2023-05"
                }
            }
        };
    }

    public override void ValidaInstanciasLeituraEscrita(S3000 instanciaPopulada, S3000 instanciaXml)
    {
        instanciaXml.Should().NotBeNull();
        instanciaXml.evtExclusao.Should().NotBeNull();

        // ideEvento
        instanciaXml.evtExclusao.ideEvento.tpAmb.Should().Be(instanciaPopulada.evtExclusao.ideEvento.tpAmb);
        instanciaXml.evtExclusao.ideEvento.procEmi.Should().Be(instanciaPopulada.evtExclusao.ideEvento.procEmi);
        instanciaXml.evtExclusao.ideEvento.verProc.Should().Be(instanciaPopulada.evtExclusao.ideEvento.verProc);

        // ideEmpregador
        instanciaXml.evtExclusao.ideEmpregador.tpInsc.Should().Be(instanciaPopulada.evtExclusao.ideEmpregador.tpInsc);
        instanciaXml.evtExclusao.ideEmpregador.nrInsc.Should().Be(instanciaPopulada.evtExclusao.ideEmpregador.nrInsc);

        // infoExclusao
        instanciaXml.evtExclusao.infoExclusao.tpEvento.Should().Be(instanciaPopulada.evtExclusao.infoExclusao.tpEvento);
        instanciaXml.evtExclusao.infoExclusao.nrRecEvt.Should().Be(instanciaPopulada.evtExclusao.infoExclusao.nrRecEvt);

        // ideTrabalhador
        instanciaXml.evtExclusao.infoExclusao.ideTrabalhador.cpfTrab.Should().Be(instanciaPopulada.evtExclusao.infoExclusao.ideTrabalhador.cpfTrab);

        // ideFolhaPagto
        instanciaXml.evtExclusao.infoExclusao.ideFolhaPagto.indApuracao.Should().Be(instanciaPopulada.evtExclusao.infoExclusao.ideFolhaPagto.indApuracao);
        instanciaXml.evtExclusao.infoExclusao.ideFolhaPagto.perApur.Should().Be(instanciaPopulada.evtExclusao.infoExclusao.ideFolhaPagto.perApur);
    }
}
