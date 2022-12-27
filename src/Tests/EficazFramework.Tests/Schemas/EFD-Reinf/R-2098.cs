namespace EficazFramework.SPED.Schemas.EFD_Reinf;

public class R2098Test : BaseEfdReinfTest<R2098>
{
    [Test]
    [TestCase(Versao.v1_05_01)]
    [TestCase(Versao.v2_01_01)]
    public void ValidaEvento(Versao versao)
    {
        _versao = versao;
        InstanciaDesserializada = (R2098 e) => e.Versao = versao;
        ValidationSchemaNamespace = $"http://www.reinf.esocial.gov.br/schemas/evtReabreEvPer/{versao}";
        switch (versao)
        {
            case Versao.v1_05_01:
                ValidationSchema = Resources.Schemas.EFD_Reinf.R2098_v1_05_01;
                break;

            case Versao.v2_01_01:
                ValidationSchema = Resources.Schemas.EFD_Reinf.R2098_v2_01_01;
                break;
        }
        TestaEvento();
    }


    // BaseEfdReinfTest overrides
    public override void PreencheCampos(R2098 evento)
    {
        evento.Versao = _versao;
        PreencheCamposR2098(evento);
    }

    public static void PreencheCamposR2098(R2098 evento)
    {
        evento.evtReabreEvPer = new ReinfEvtReabreEvPer()
        {
            ideContri = new EficazFramework.SPED.Schemas.EFD_Reinf.ReinfEvtIdeContri()
            {
                tpInsc = EficazFramework.SPED.Schemas.EFD_Reinf.PersonalidadeJuridica.CNPJ,
                nrInsc = _cnpj.Substring(0, 8)
            },
            ideEvento = new ReinfEvtIdeEventoPeriodicoFechamento()
            {
                perApur = $"{DateTime.Now.AddMonths(-1):yyyy-MM}",
                tpAmb = EficazFramework.SPED.Schemas.EFD_Reinf.Ambiente.ProducaoRestrita_DadosReais,
                procEmi = EficazFramework.SPED.Schemas.EFD_Reinf.EmissorEvento.AppContribuinte,
                verProc = "2.2"
            }
        };
    }


    public override void ValidaInstanciasLeituraEscrita(R2098 instanciaPopulada, R2098 instanciaXml)
    {
        // TODO: verifique se os campos de instanciaXml, preenchidos a partir da leitura de um XmlDocument, 
        //       correspondem exatamente aos valores de instanciaPopulada, formado à partir do método
        //       PreencheCampos().


        // ideEvento
        instanciaXml.evtReabreEvPer.ideEvento.tpAmb.Should().Be(instanciaPopulada.evtReabreEvPer.ideEvento.tpAmb);
        instanciaXml.evtReabreEvPer.ideEvento.procEmi.Should().Be(instanciaPopulada.evtReabreEvPer.ideEvento.procEmi);
        instanciaXml.evtReabreEvPer.ideEvento.verProc.Should().Be(instanciaPopulada.evtReabreEvPer.ideEvento.verProc);

        // ideContri
        instanciaXml.evtReabreEvPer.ideContri.tpInsc.Should().Be(instanciaPopulada.evtReabreEvPer.ideContri.tpInsc);
        instanciaXml.evtReabreEvPer.ideContri.nrInsc.Should().Be(instanciaPopulada.evtReabreEvPer.ideContri.nrInsc);
    }
}