namespace EficazFramework.SPED.Schemas.eSocial;

public class S1298Test : BaseESocialTest<S1298>
{
    [Test]
    [TestCase(Versao.v_S_01_02_00)]
    [TestCase(Versao.v_S_01_03_00)]
    public async Task Valida(Versao versao)
    {
        _versao = versao;
        ValidationSchemaNamespace = $"http://www.esocial.gov.br/schema/evt/evtReabreEvPer/{versao}";
        await TestaEvento();
    }

    [Test]
    public async Task ImportaXmlLegado()
    {
        string xmlLegado = $@"<eSocial xmlns=""http://www.esocial.gov.br/schema/evt/evtReabreEvPer/v_S_01_01_00"">
  <evtReabreEvPer Id=""ID1347855150001662025020112000000001"">
    <ideEvento>
      <perApur>2025-02</perApur>
      <tpAmb>2</tpAmb>
      <procEmi>1</procEmi>
      <verProc>1.0</verProc>
    </ideEvento>
    <ideEmpregador>
      <tpInsc>1</tpInsc>
      <nrInsc>{CnpjCpf[..8]}</nrInsc>
    </ideEmpregador>
  </evtReabreEvPer>
</eSocial>";

        var evento = (S1298)(await Evento.ReadAsync(xmlLegado));
        evento.Should().NotBeNull();
        evento.evtReabreEvPer.Should().NotBeNull();

        // ideEvento
        evento.evtReabreEvPer.ideEvento.perApur.Should().Be("2025-02");
        evento.evtReabreEvPer.ideEvento.tpAmb.Should().Be(Ambiente.ProducaoRestrita_DadosReais);
        evento.evtReabreEvPer.ideEvento.procEmi.Should().Be(EmissorEvento.AppEmpregador);
        evento.evtReabreEvPer.ideEvento.verProc.Should().Be("1.0");

        // ideEmpregador
        evento.evtReabreEvPer.ideEmpregador.tpInsc.Should().Be(PersonalidadeJuridica.CNPJ);
        evento.evtReabreEvPer.ideEmpregador.nrInsc.Should().Be(CnpjCpf[..8]);
    }

    public override void PreencheCampos(S1298 evento)
    {
        evento.Versao = _versao;
        evento.evtReabreEvPer = new S1298EventoPeriodico
        {
            ideEvento = new S1298IdentificacaoEvento
            {
                perApur = "2025-02",
                tpAmb = Ambiente.ProducaoRestrita_DadosReais,
                procEmi = EmissorEvento.AppEmpregador,
                verProc = "1.0"
            },
            ideEmpregador = new Empregador
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = CnpjCpf[..8]
            }
        };
    }

    public override void ValidaInstanciasLeituraEscrita(S1298 instanciaPopulada, S1298 instanciaXml)
    {
        instanciaPopulada.Should().NotBeNull();
        instanciaXml.Should().NotBeNull();

        // ideEvento
        instanciaXml.evtReabreEvPer.ideEvento.perApur.Should().Be(instanciaPopulada.evtReabreEvPer.ideEvento.perApur);
        instanciaXml.evtReabreEvPer.ideEvento.tpAmb.Should().Be(instanciaPopulada.evtReabreEvPer.ideEvento.tpAmb);
        instanciaXml.evtReabreEvPer.ideEvento.procEmi.Should().Be(instanciaPopulada.evtReabreEvPer.ideEvento.procEmi);
        instanciaXml.evtReabreEvPer.ideEvento.verProc.Should().Be(instanciaPopulada.evtReabreEvPer.ideEvento.verProc);

        // ideEmpregador
        instanciaXml.evtReabreEvPer.ideEmpregador.tpInsc.Should().Be(instanciaPopulada.evtReabreEvPer.ideEmpregador.tpInsc);
        instanciaXml.evtReabreEvPer.ideEmpregador.nrInsc.Should().Be(instanciaPopulada.evtReabreEvPer.ideEmpregador.nrInsc);
    }
}
