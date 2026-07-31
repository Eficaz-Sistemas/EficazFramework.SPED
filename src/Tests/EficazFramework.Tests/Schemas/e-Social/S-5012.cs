namespace EficazFramework.SPED.Schemas.eSocial;

public class S5012Test : BaseESocialTest<S5012>
{
    [Test]
    [TestCase(Versao.v_S_01_02_00)]
    [TestCase(Versao.v_S_01_03_00)]
    public async Task Valida(Versao versao)
    {
        _versao = versao;
        ValidationSchemaNamespace = $"http://www.esocial.gov.br/schema/evt/evtIrrf/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v_S_01_03_00 => Resources.Schemas.eSocial.S5012_v_S_01_03_00,
            _ => Resources.Schemas.eSocial.S5012_v_S_01_02_00
        };
        await TestaEvento();
    }

    [Test]
    public async Task Read_v_S_01_03_00()
    {
        var evento = await Evento.ReadAsync(Resources.Samples.eSocial.S5012_v_S_01_03_00);
        evento.Should().NotBeNull();
        evento.Versao.Should().Be(Versao.v_S_01_03_00);
        var evt5012 = evento as S5012;
        evt5012.Should().NotBeNull();
        evt5012.evtIrrf.Should().NotBeNull();
        evt5012.evtIrrf.ideEvento.perApur.Should().Be("2025-02");
        evt5012.evtIrrf.ideEmpregador.tpInsc.Should().Be(PersonalidadeJuridica.CNPJ);
        evt5012.evtIrrf.ideEmpregador.nrInsc.Should().Be("34785515");

        // infoIRRF
        evt5012.evtIrrf.infoIRRF.Should().NotBeNull();
        evt5012.evtIrrf.infoIRRF.nrRecArqBase.Should().Be("1.1.0000000000000000000");
        evt5012.evtIrrf.infoIRRF.indExistInfo.Should().Be(IndicadorExistenciaInfoIRRF.HaInformacoesIRRF);

        // infoCRMen
        evt5012.evtIrrf.infoIRRF.infoCRMen.Should().HaveCount(1);
        evt5012.evtIrrf.infoIRRF.infoCRMen[0].CRMen.Should().Be("056107");
        evt5012.evtIrrf.infoIRRF.infoCRMen[0].vrCRMen.Should().Be(1500.50m);

        // infoCRDia
        evt5012.evtIrrf.infoIRRF.infoCRDia.Should().HaveCount(1);
        evt5012.evtIrrf.infoIRRF.infoCRDia[0].perApurDia.Should().Be((byte)15);
        evt5012.evtIrrf.infoIRRF.infoCRDia[0].CRDia.Should().Be("047301");
        evt5012.evtIrrf.infoIRRF.infoCRDia[0].vrCRDia.Should().Be(500.00m);
    }

    public override void PreencheCampos(S5012 evento)
    {
        evento.Versao = _versao;
        evento.evtIrrf = new S5012EvtIrrf()
        {
            ideEvento = new S5012IdeEvento()
            {
                perApur = "2025-02"
            },
            ideEmpregador = new Empregador()
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = CnpjCpf.Substring(0, 8)
            },
            infoIRRF = new S5012InfoIRRF()
            {
                nrRecArqBase = "1.1.0000000000000000000",
                indExistInfo = IndicadorExistenciaInfoIRRF.HaInformacoesIRRF,
                infoCRMen =
                [
                    new S5012InfoCRMen()
                    {
                        CRMen = "056107",
                        vrCRMen = 1500.50m
                    }
                ],
                infoCRDia =
                [
                    new S5012InfoCRDia()
                    {
                        perApurDia = 15,
                        CRDia = "047301",
                        vrCRDia = 500.00m
                    }
                ]
            }
        };
    }

    public override void ValidaInstanciasLeituraEscrita(S5012 instanciaPopulada, S5012 instanciaXml)
    {
        instanciaPopulada.Should().NotBeNull();
        instanciaXml.Should().NotBeNull();

        // ideEvento
        instanciaXml.evtIrrf.ideEvento.perApur.Should().Be(instanciaPopulada.evtIrrf.ideEvento.perApur);

        // ideEmpregador
        instanciaXml.evtIrrf.ideEmpregador.tpInsc.Should().Be(instanciaPopulada.evtIrrf.ideEmpregador.tpInsc);
        instanciaXml.evtIrrf.ideEmpregador.nrInsc.Should().Be(instanciaPopulada.evtIrrf.ideEmpregador.nrInsc);

        // infoIRRF
        instanciaXml.evtIrrf.infoIRRF.Should().NotBeNull();
        instanciaXml.evtIrrf.infoIRRF.nrRecArqBase.Should().Be(instanciaPopulada.evtIrrf.infoIRRF.nrRecArqBase);
        instanciaXml.evtIrrf.infoIRRF.indExistInfo.Should().Be(instanciaPopulada.evtIrrf.infoIRRF.indExistInfo);

        // infoCRMen
        instanciaXml.evtIrrf.infoIRRF.infoCRMen.Should().HaveCount(1);
        instanciaXml.evtIrrf.infoIRRF.infoCRMen[0].CRMen.Should().Be(instanciaPopulada.evtIrrf.infoIRRF.infoCRMen[0].CRMen);
        instanciaXml.evtIrrf.infoIRRF.infoCRMen[0].vrCRMen.Should().Be(instanciaPopulada.evtIrrf.infoIRRF.infoCRMen[0].vrCRMen);

        // infoCRDia
        instanciaXml.evtIrrf.infoIRRF.infoCRDia.Should().HaveCount(1);
        instanciaXml.evtIrrf.infoIRRF.infoCRDia[0].perApurDia.Should().Be(instanciaPopulada.evtIrrf.infoIRRF.infoCRDia[0].perApurDia);
        instanciaXml.evtIrrf.infoIRRF.infoCRDia[0].CRDia.Should().Be(instanciaPopulada.evtIrrf.infoIRRF.infoCRDia[0].CRDia);
        instanciaXml.evtIrrf.infoIRRF.infoCRDia[0].vrCRDia.Should().Be(instanciaPopulada.evtIrrf.infoIRRF.infoCRDia[0].vrCRDia);
    }
}
