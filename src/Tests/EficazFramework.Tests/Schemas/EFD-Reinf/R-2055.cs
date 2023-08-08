namespace EficazFramework.SPED.Schemas.EFD_Reinf;

public class R2055Test : BaseEfdReinfTest<R2055>
{
    [Test]
    [TestCase(Versao.v1_05_01)]
    [TestCase(Versao.v2_01_01)]
    [TestCase(Versao.v2_01_02)]
    public void ValidaEvento(Versao versao)
    {
        _versao = versao;
        InstanciaDesserializada = (R2055 e) => e.Versao = versao;
        ValidationSchemaNamespace = $"http://www.reinf.esocial.gov.br/schemas/evt2055AquisicaoProdRural/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v1_05_01 => Resources.Schemas.EFD_Reinf.R2055_v1_05_01,
            Versao.v2_01_01 => Resources.Schemas.EFD_Reinf.R2055_v2_01_01,
            Versao.v2_01_02 => Resources.Schemas.EFD_Reinf.R2055_v2_01_02_B,
            _ => Resources.Schemas.EFD_Reinf.R2055_v2_01_02_B
        };
        TestaEvento();
    }


    // BaseEfdReinfTest overrides
    public override void PreencheCampos(R2055 evento)
    {
        evento.Versao = _versao;
        PreencheCamposR2055(evento);
    }

    public static void PreencheCamposR2055(R2055 evento)
    {
        EficazFramework.SPED.Schemas.EFD_Reinf.R2055 registro = new EficazFramework.SPED.Schemas.EFD_Reinf.R2055();
        evento.evtAqProd = new EficazFramework.SPED.Schemas.EFD_Reinf.ReinfAqProd()
        {
            ideContri = new EficazFramework.SPED.Schemas.EFD_Reinf.ReinfEvtAqProdIdeContri(),
            ideEvento = new EficazFramework.SPED.Schemas.EFD_Reinf.ReinfEvtAqProdIdeEvento(),
            infoAquisProd = new EficazFramework.SPED.Schemas.EFD_Reinf.ReinfEvtAqProdInfoAqProd(),
        };

        //ideContri
        evento.evtAqProd.ideContri.tpInsc = PersonalidadeJuridica.CNPJ;
        evento.evtAqProd.ideContri.nrInsc = _cnpj.Substring(0, 8);

        //ideEvento
        evento.evtAqProd.ideEvento.indRetif = IndicadorRetificacao.Original;
        evento.evtAqProd.ideEvento.perApur = $"{DateTime.Now.AddMonths(-1):yyyy-MM}";
        evento.evtAqProd.ideEvento.procEmi = EmissorEvento.AppContribuinte;
        evento.evtAqProd.ideEvento.tpAmb = Ambiente.ProducaoRestrita_DadosReais;
        evento.evtAqProd.ideEvento.verProc = "2.2";

        //infoAquisProd
        evento.evtAqProd.infoAquisProd.ideEstabAdquir = new EficazFramework.SPED.Schemas.EFD_Reinf.ReinfEvtAqProdInfoAqProdIdeEstabAdquir()
        {
            tpInscAdq = PersonalidadeJuridica.CNPJ,
            nrInscAdq = _cnpj,
            ideProdutor = new EficazFramework.SPED.Schemas.EFD_Reinf.ReinfEvtAqProdInfoAquisProdIdeEstabIdeProdutor()
        };
        evento.evtAqProd.infoAquisProd.ideEstabAdquir.ideProdutor.tpInscProd = PersonalidadeJuridica.CPF;
        evento.evtAqProd.infoAquisProd.ideEstabAdquir.ideProdutor.nrInscProd = "07731253619";
        evento.evtAqProd.infoAquisProd.ideEstabAdquir.ideProdutor.detAquis.Add(new EficazFramework.SPED.Schemas.EFD_Reinf.ReinfEvtAqProdInfoAquisProdIdeEstabIdeProdutorDetAquis
        {
            indAquis = IndicadorAquisProd.PF,
            vlrBruto = $"{1000.01D:#0.00}",
            vlrCPDescPR = $"{15.02:#0.00}",
            vlrRatDescPR = $"{2.01:#0.00}",
            vlrSenarDesc = $"{1.01:#0.00}",
            infoProcJud = null
        });
    }


    public override void ValidaInstanciasLeituraEscrita(R2055 instanciaPopulada, R2055 instanciaXml)
    {
        // TODO: verifique se os campos de instanciaXml, preenchidos a partir da leitura de um XmlDocument, 
        //       correspondem exatamente aos valores de instanciaPopulada, formado à partir do método
        //       PreencheCampos().


        // ideEvento
        instanciaXml.evtAqProd.ideEvento.tpAmb.Should().Be(instanciaPopulada.evtAqProd.ideEvento.tpAmb);
        instanciaXml.evtAqProd.ideEvento.procEmi.Should().Be(instanciaPopulada.evtAqProd.ideEvento.procEmi);
        instanciaXml.evtAqProd.ideEvento.verProc.Should().Be(instanciaPopulada.evtAqProd.ideEvento.verProc);

        // ideContri
        instanciaXml.evtAqProd.ideContri.tpInsc.Should().Be(instanciaPopulada.evtAqProd.ideContri.tpInsc);
        instanciaXml.evtAqProd.ideContri.nrInsc.Should().Be(instanciaPopulada.evtAqProd.ideContri.nrInsc);

        // infoAquisProd
        instanciaXml.evtAqProd.infoAquisProd.ideEstabAdquir.tpInscAdq.Should().Be(instanciaPopulada.evtAqProd.infoAquisProd.ideEstabAdquir.tpInscAdq);
        instanciaXml.evtAqProd.infoAquisProd.ideEstabAdquir.nrInscAdq.Should().Be(instanciaPopulada.evtAqProd.infoAquisProd.ideEstabAdquir.nrInscAdq);
        instanciaXml.evtAqProd.infoAquisProd.ideEstabAdquir.ideProdutor.tpInscProd.Should().Be(instanciaPopulada.evtAqProd.infoAquisProd.ideEstabAdquir.ideProdutor.tpInscProd);
        instanciaXml.evtAqProd.infoAquisProd.ideEstabAdquir.ideProdutor.nrInscProd.Should().Be(instanciaPopulada.evtAqProd.infoAquisProd.ideEstabAdquir.ideProdutor.nrInscProd);
        instanciaXml.evtAqProd.infoAquisProd.ideEstabAdquir.ideProdutor.indOpcCP.Should().Be(instanciaPopulada.evtAqProd.infoAquisProd.ideEstabAdquir.ideProdutor.indOpcCP);
        int iDetAquis = 0;
        instanciaXml.evtAqProd.infoAquisProd.ideEstabAdquir.ideProdutor.detAquis.ForEach(ev =>
        {
            ev.indAquis.Should().Be(instanciaPopulada.evtAqProd.infoAquisProd.ideEstabAdquir.ideProdutor.detAquis[iDetAquis].indAquis);
            ev.vlrBruto.Should().Be(instanciaPopulada.evtAqProd.infoAquisProd.ideEstabAdquir.ideProdutor.detAquis[iDetAquis].vlrBruto); ;
            ev.vlrCPDescPR.Should().Be(instanciaPopulada.evtAqProd.infoAquisProd.ideEstabAdquir.ideProdutor.detAquis[iDetAquis].vlrCPDescPR);
            ev.vlrRatDescPR.Should().Be(instanciaPopulada.evtAqProd.infoAquisProd.ideEstabAdquir.ideProdutor.detAquis[iDetAquis].vlrRatDescPR);
            ev.vlrSenarDesc.Should().Be(instanciaPopulada.evtAqProd.infoAquisProd.ideEstabAdquir.ideProdutor.detAquis[iDetAquis].vlrSenarDesc);
            iDetAquis += 1;
        });
    }
}