namespace EficazFramework.SPED.Schemas.EFD_Reinf;

public class R9000Test : BaseEfdReinfTest<R9000>
{
    [Test]
    [TestCase(Versao.v1_05_01)]
    [TestCase(Versao.v2_01_01)]
    [TestCase(Versao.v2_01_02)]
    public void ValidaEvento(Versao versao)
    {
        _versao = versao;
        InstanciaDesserializada = (R9000 e) => e.Versao = versao;
        ValidationSchemaNamespace = $"http://www.reinf.esocial.gov.br/schemas/evtExclusao/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v1_05_01 => Resources.Schemas.EFD_Reinf.R9000_v1_05_01,
            Versao.v2_01_01 => Resources.Schemas.EFD_Reinf.R9000_v2_01_01,
            Versao.v2_01_02 => Resources.Schemas.EFD_Reinf.R9000_v2_01_02_B,
            _ => Resources.Schemas.EFD_Reinf.R9000_v2_01_02_B
        };
        TestaEvento();
    }


    // BaseEfdReinfTest overrides
    public override void PreencheCampos(R9000 evento)
    {
        evento.Versao = _versao;
        PreencheCamposInclusao(evento);
    }

    public override void ValidaInstanciasLeituraEscrita(R9000 instanciaPopulada, R9000 instanciaXml)
    {
        // TODO: verifique se os campos de instanciaXml, preenchidos a partir da leitura de um XmlDocument, 
        //       correspondem exatamente aos valores de instanciaPopulada, formado à partir do método
        //       PreencheCampos().


        // ideEvento
        instanciaXml.evtExclusao.ideEvento.tpAmb.Should().Be(instanciaPopulada.evtExclusao.ideEvento.tpAmb);
        instanciaXml.evtExclusao.ideEvento.procEmi.Should().Be(instanciaPopulada.evtExclusao.ideEvento.procEmi);
        instanciaXml.evtExclusao.ideEvento.verProc.Should().Be(instanciaPopulada.evtExclusao.ideEvento.verProc);

        // ideContri
        instanciaXml.evtExclusao.ideContri.tpInsc.Should().Be(instanciaPopulada.evtExclusao.ideContri.tpInsc);
        instanciaXml.evtExclusao.ideContri.nrInsc.Should().Be(instanciaPopulada.evtExclusao.ideContri.nrInsc);

        // infoExclusao
        instanciaXml.evtExclusao.infoExclusao.nrRecEvt.Should().Be(instanciaPopulada.evtExclusao.infoExclusao.nrRecEvt);
        instanciaXml.evtExclusao.infoExclusao.perApur.Should().Be(instanciaPopulada.evtExclusao.infoExclusao.perApur);
        instanciaXml.evtExclusao.infoExclusao.tpEvento.Should().Be(instanciaPopulada.evtExclusao.infoExclusao.tpEvento);
    }

    internal static void PreencheCamposInclusao(R9000 evento)
    {
        evento.evtExclusao = new R9000EventoExclusao()
        {
            ideEvento = new IdentificacaoEvento()
            {
                tpAmb = Ambiente.ProducaoRestrita_DadosReais,
                procEmi = EmissorEvento.AppContribuinte,
                verProc = "2.2"
            },
            ideContri = new IdentificacaoContribuinte()
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = _cnpj.Substring(0, 8)
            },
            infoExclusao = new ReinfEvtExclusaoInfoExclusao()
            {
                nrRecEvt = "12345-00-1234-9876-0",
                perApur = $"{DateTime.Now.AddMonths(-1):yyyy-MM}",
                tpEvento = "R-4010" // ou qualquer outro evento que for preciso, exceto pelos de Fechamento/reabertura - R-2098, R-2099 e R-4099
            }
        };
    }
}