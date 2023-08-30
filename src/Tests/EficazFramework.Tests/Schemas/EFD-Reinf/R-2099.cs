namespace EficazFramework.SPED.Schemas.EFD_Reinf;

public class R2099Test : BaseEfdReinfTest<R2099>
{
    [Test]
    [TestCase(Versao.v1_05_01)]
    [TestCase(Versao.v2_01_01)]
    [TestCase(Versao.v2_01_02)]
    public void ValidaEvento(Versao versao)
    {
        _versao = versao;
        InstanciaDesserializada = (R2099 e) => e.Versao = versao;
        ValidationSchemaNamespace = $"http://www.reinf.esocial.gov.br/schemas/evtFechamento/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v1_05_01 => Resources.Schemas.EFD_Reinf.R2099_v1_05_01,
            Versao.v2_01_01 => Resources.Schemas.EFD_Reinf.R2099_v2_01_01,
            Versao.v2_01_02 => Resources.Schemas.EFD_Reinf.R2099_v2_01_02_B,
            _ => Resources.Schemas.EFD_Reinf.R2099_v2_01_02_B
        };
        TestaEvento();
    }


    // BaseEfdReinfTest overrides
    public override void PreencheCampos(R2099 evento)
    {
        evento.Versao = _versao;
        PreencheCamposR2099(evento);
    }

    public static void PreencheCamposR2099(R2099 evento)
    {
        evento.evtFechaEvPer = new EficazFramework.SPED.Schemas.EFD_Reinf.R2099EventoFechamentoPeriodo()
        {
            ideContri = new EficazFramework.SPED.Schemas.EFD_Reinf.IdentificacaoContribuinte()
            {
                tpInsc = EficazFramework.SPED.Schemas.EFD_Reinf.PersonalidadeJuridica.CNPJ,
                nrInsc = _cnpj.Substring(0, 8)
            },
            ideEvento = new IdentificacaoEventoFechamento()
            {
                perApur = $"{DateTime.Now.AddMonths(-1):yyyy-MM}",
                tpAmb = EficazFramework.SPED.Schemas.EFD_Reinf.Ambiente.ProducaoRestrita_DadosReais,
                procEmi = EficazFramework.SPED.Schemas.EFD_Reinf.EmissorEvento.AppContribuinte,
                verProc = "2.2"
            },
            ideRespInf = new EficazFramework.SPED.Schemas.EFD_Reinf.IdentificacaoResponsavel()
            {
                nmResp = "Teste",
                cpfResp = "07448448609",
                telefone = "3535441511",
                email = "contato@eficazctb.com.br"
            },
            infoFech = new EficazFramework.SPED.Schemas.EFD_Reinf.R2099InformacoesFechamento()
            {
                evtServTm = SimNao.Nao,
                evtServPr = SimNao.Nao,
                evtAquis = SimNao.Nao
            }
        };
    }


    public override void ValidaInstanciasLeituraEscrita(R2099 instanciaPopulada, R2099 instanciaXml)
    {
        // TODO: verifique se os campos de instanciaXml, preenchidos a partir da leitura de um XmlDocument, 
        //       correspondem exatamente aos valores de instanciaPopulada, formado à partir do método
        //       PreencheCampos().


        // ideEvento
        instanciaXml.evtFechaEvPer.ideEvento.tpAmb.Should().Be(instanciaPopulada.evtFechaEvPer.ideEvento.tpAmb);
        instanciaXml.evtFechaEvPer.ideEvento.procEmi.Should().Be(instanciaPopulada.evtFechaEvPer.ideEvento.procEmi);
        instanciaXml.evtFechaEvPer.ideEvento.verProc.Should().Be(instanciaPopulada.evtFechaEvPer.ideEvento.verProc);

        // ideContri
        instanciaXml.evtFechaEvPer.ideContri.tpInsc.Should().Be(instanciaPopulada.evtFechaEvPer.ideContri.tpInsc);
        instanciaXml.evtFechaEvPer.ideContri.nrInsc.Should().Be(instanciaPopulada.evtFechaEvPer.ideContri.nrInsc);

        // infoAquisProd
        instanciaXml.evtFechaEvPer.ideRespInf.nmResp.Should().Be(instanciaPopulada.evtFechaEvPer.ideRespInf.nmResp);
        instanciaXml.evtFechaEvPer.ideRespInf.cpfResp.Should().Be(instanciaPopulada.evtFechaEvPer.ideRespInf.cpfResp);
        instanciaXml.evtFechaEvPer.ideRespInf.telefone.Should().Be(instanciaXml.evtFechaEvPer.ideRespInf.telefone);
        instanciaXml.evtFechaEvPer.ideRespInf.email.Should().Be(instanciaXml.evtFechaEvPer.ideRespInf.email);

        // infoFech
        instanciaXml.evtFechaEvPer.infoFech.evtServTm.Should().Be(instanciaPopulada.evtFechaEvPer.infoFech.evtServTm);
        instanciaXml.evtFechaEvPer.infoFech.evtServPr.Should().Be(instanciaPopulada.evtFechaEvPer.infoFech.evtServPr);
        instanciaXml.evtFechaEvPer.infoFech.evtAquis.Should().Be(instanciaXml.evtFechaEvPer.infoFech.evtAquis);
    }
}