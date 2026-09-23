namespace EficazFramework.SPED.Schemas.eSocial;

public class S1299Test : BaseESocialTest<S1299>
{
    [Test]
    [TestCase(Versao.v_S_01_02_00)]
    [TestCase(Versao.v_S_01_03_00)]
    public async Task Valida(Versao versao)
    {
        _versao = versao;
        ValidationSchemaNamespace = $"http://www.esocial.gov.br/schema/evt/evtFechaEvPer/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v_S_01_02_00 => Resources.Schemas.eSocial.S1299_v_S_01_02_00,
            _ => Resources.Schemas.eSocial.S1299_v_S_01_03_00
        };
        await TestaEvento();
    }

    [Test]
    public async Task ImportaXmlLegado()
    {
        string xmlLegado = $@"<eSocial xmlns=""http://www.esocial.gov.br/schema/evt/evtFechaEvPer/v_S_01_01_00"">
  <evtFechaEvPer Id=""ID1347855150001662025020112000000001"">
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
    <ideRespInf>
      <nmResp>Responsavel Legado</nmResp>
      <cpfResp>12345678901</cpfResp>
      <telefone>31999998888</telefone>
      <email>responsavel@empresa.com</email>
    </ideRespInf>
    <infoFech>
      <evtRemun>S</evtRemun>
      <evtPgtos>S</evtPgtos>
      <evtAqProd>N</evtAqProd>
      <evtComProd>N</evtComProd>
      <evtContratAvNP>N</evtContratAvNP>
      <evtInfoComplPer>N</evtInfoComplPer>
      <compSemMovto>2025-01</compSemMovto>
      <transDCTFWeb>S</transDCTFWeb>
      <naoValid>S</naoValid>
    </infoFech>
  </evtFechaEvPer>
</eSocial>";

        var evento = (S1299)(await Evento.ReadAsync(xmlLegado));
        evento.Should().NotBeNull();
        evento.evtFechaEvPer.Should().NotBeNull();

        // ideEvento
        evento.evtFechaEvPer.ideEvento.perApur.Should().Be("2025-02");
        evento.evtFechaEvPer.ideEvento.tpAmb.Should().Be(Ambiente.ProducaoRestrita_DadosReais);
        evento.evtFechaEvPer.ideEvento.procEmi.Should().Be(EmissorEvento.AppEmpregador);
        evento.evtFechaEvPer.ideEvento.verProc.Should().Be("1.0");

        // ideEmpregador
        evento.evtFechaEvPer.ideEmpregador.tpInsc.Should().Be(PersonalidadeJuridica.CNPJ);
        evento.evtFechaEvPer.ideEmpregador.nrInsc.Should().Be(CnpjCpf[..8]);

#pragma warning disable CS0618 // Type or member is obsolete
        // ideRespInf (legado)
        evento.evtFechaEvPer.ideRespInf.Should().NotBeNull();
        evento.evtFechaEvPer.ideRespInf.nmResp.Should().Be("Responsavel Legado");
        evento.evtFechaEvPer.ideRespInf.cpfResp.Should().Be("12345678901");
        evento.evtFechaEvPer.ideRespInf.telefone.Should().Be("31999998888");
        evento.evtFechaEvPer.ideRespInf.email.Should().Be("responsavel@empresa.com");

        // infoFechamento
        var infoFech = evento.evtFechaEvPer.infoFech;
        infoFech.Should().NotBeNull();
        infoFech.evtRemun.Should().Be(SimNaoString.Sim);
        infoFech.evtPgtos.Should().Be(SimNaoString.Sim);
        infoFech.evtAqProd.Should().Be(SimNaoString.Nao);
        infoFech.evtComProd.Should().Be(SimNaoString.Nao);
        infoFech.evtContratAvNP.Should().Be(SimNaoString.Nao);
        infoFech.evtInfoComplPer.Should().Be(SimNaoString.Nao);
        infoFech.compSemMovto.Should().Be("2025-01");
        infoFech.transDCTFWeb.Should().Be(SimNaoString.Sim);
        infoFech.naoValid.Should().Be(SimNaoString.Sim);
#pragma warning restore CS0618
    }

    public override void PreencheCampos(S1299 evento)
    {
        evento.Versao = _versao;
        evento.evtFechaEvPer = new S1299EvPer
        {
            ideEvento = new S1299IdentificacaoEvento
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
            },
            infoFech = new S1299InfoFechamento
            {
                evtRemun = SimNaoString.Sim,
                evtPgtos = SimNaoString.Sim,
                evtComProd = SimNaoString.Nao,
                evtContratAvNP = SimNaoString.Nao,
                evtInfoComplPer = SimNaoString.Nao,
                transDCTFWeb = SimNaoString.Sim,
                naoValid = SimNaoString.Sim
            }
        };
    }

    public override void ValidaInstanciasLeituraEscrita(S1299 instanciaPopulada, S1299 instanciaXml)
    {
        instanciaPopulada.Should().NotBeNull();
        instanciaXml.Should().NotBeNull();

        // ideEvento
        instanciaXml.evtFechaEvPer.ideEvento.perApur.Should().Be(instanciaPopulada.evtFechaEvPer.ideEvento.perApur);
        instanciaXml.evtFechaEvPer.ideEvento.tpAmb.Should().Be(instanciaPopulada.evtFechaEvPer.ideEvento.tpAmb);
        instanciaXml.evtFechaEvPer.ideEvento.procEmi.Should().Be(instanciaPopulada.evtFechaEvPer.ideEvento.procEmi);
        instanciaXml.evtFechaEvPer.ideEvento.verProc.Should().Be(instanciaPopulada.evtFechaEvPer.ideEvento.verProc);

        // ideEmpregador
        instanciaXml.evtFechaEvPer.ideEmpregador.tpInsc.Should().Be(instanciaPopulada.evtFechaEvPer.ideEmpregador.tpInsc);
        instanciaXml.evtFechaEvPer.ideEmpregador.nrInsc.Should().Be(instanciaPopulada.evtFechaEvPer.ideEmpregador.nrInsc);

        // infoFechamento
        var infoFechPopulada = instanciaPopulada.evtFechaEvPer.infoFech;
        var infoFechXml = instanciaXml.evtFechaEvPer.infoFech;
        infoFechXml.Should().NotBeNull();
        infoFechXml.evtRemun.Should().Be(infoFechPopulada.evtRemun);
        infoFechXml.evtPgtos.Should().Be(infoFechPopulada.evtPgtos);
        infoFechXml.evtComProd.Should().Be(infoFechPopulada.evtComProd);
        infoFechXml.evtContratAvNP.Should().Be(infoFechPopulada.evtContratAvNP);
        infoFechXml.evtInfoComplPer.Should().Be(infoFechPopulada.evtInfoComplPer);
        infoFechXml.transDCTFWeb.Should().Be(infoFechPopulada.transDCTFWeb);
        infoFechXml.naoValid.Should().Be(infoFechPopulada.naoValid);
    }
}
