namespace EficazFramework.SPED.Schemas.EFD_Reinf;

public class R2050Test : BaseEfdReinfTest<R2050>
{
    [Test]
    [TestCase(Versao.v1_05_01)]
    [TestCase(Versao.v2_01_01)]
    [TestCase(Versao.v2_01_02)]
    public void ValidaEvento(Versao versao)
    {
        _versao = versao;
        InstanciaDesserializada = (R2050 e) => e.Versao = versao;
        ValidationSchemaNamespace = $"http://www.reinf.esocial.gov.br/schemas/evtInfoProdRural/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v1_05_01 => Resources.Schemas.EFD_Reinf.R2050_v1_05_01,
            Versao.v2_01_01 => Resources.Schemas.EFD_Reinf.R2050_v2_01_01,
            Versao.v2_01_02 => Resources.Schemas.EFD_Reinf.R2050_v2_01_02_B,
            _ => Resources.Schemas.EFD_Reinf.R2050_v2_01_02_B
        };
        TestaEvento();
    }


    // BaseEfdReinfTest overrides
    public override void PreencheCampos(R2050 evento)
    {
        evento.Versao = _versao;
        PreencheCamposR2050(evento);
    }

    public static void PreencheCamposR2050(R2050 evento)
    {
        evento.evtComProd = new R2050EventoInfoComProdutor()
        {
            ideContri = new IdentificacaoContribuinte()
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = _cnpj.Substring(0, 8)
            },
            ideEvento = new IdentificacaoEventoPeriodico()
            {
                indRetif = IndicadorRetificacao.Original,
                perApur = $"{DateTime.Now.AddMonths(-1):yyyy-MM}",
                procEmi = EmissorEvento.AppContribuinte,
                tpAmb = Ambiente.ProducaoRestrita_DadosReais,
                verProc = "2.2"
            },
            infoComProd = new R2050InfoComProdutor()
            {
                ideEstab = new()
                {
                    tpInscEstab = PersonalidadeJuridica.CNPJ,
                    nrInscEstab = "61918769000188",
                    vlrRecBrutaTotal = 1000.01M.ToString("f2"),
                    vlrCPApur = 15.02M.ToString("f2"),
                    vlrRatApur = 2.01M.ToString("f2"),
                    vlrSenarApur = 1.01M.ToString("f2"),
                    tipoCom = new()
                    {
                        new R2050TipoComercializacao()
                        {
                            indCom = IndicadorContribuicaoProd.PJ_Agrodind,
                            vlrRecBruta = 1000.01M.ToString("f2")
                        }
                    }
                }
            },
        };
    }


    public override void ValidaInstanciasLeituraEscrita(R2050 instanciaPopulada, R2050 instanciaXml)
    {
        // TODO: verifique se os campos de instanciaXml, preenchidos a partir da leitura de um XmlDocument, 
        //       correspondem exatamente aos valores de instanciaPopulada, formado à partir do método
        //       PreencheCampos().


        // ideEvento
        instanciaXml.evtComProd.ideEvento.tpAmb.Should().Be(instanciaPopulada.evtComProd.ideEvento.tpAmb);
        instanciaXml.evtComProd.ideEvento.procEmi.Should().Be(instanciaPopulada.evtComProd.ideEvento.procEmi);
        instanciaXml.evtComProd.ideEvento.verProc.Should().Be(instanciaPopulada.evtComProd.ideEvento.verProc);

        // ideContri
        instanciaXml.evtComProd.ideContri.tpInsc.Should().Be(instanciaPopulada.evtComProd.ideContri.tpInsc);
        instanciaXml.evtComProd.ideContri.nrInsc.Should().Be(instanciaPopulada.evtComProd.ideContri.nrInsc);

        // infoAquisProd
        instanciaXml.evtComProd.infoComProd.ideEstab.tpInscEstab.Should().Be(instanciaPopulada.evtComProd.infoComProd.ideEstab.tpInscEstab);
        instanciaXml.evtComProd.infoComProd.ideEstab.nrInscEstab.Should().Be(instanciaPopulada.evtComProd.infoComProd.ideEstab.nrInscEstab);
        instanciaXml.evtComProd.infoComProd.ideEstab.vlrRecBrutaTotal.Should().Be(instanciaPopulada.evtComProd.infoComProd.ideEstab.vlrRecBrutaTotal);
        instanciaXml.evtComProd.infoComProd.ideEstab.vlrCPApur.Should().Be(instanciaPopulada.evtComProd.infoComProd.ideEstab.vlrCPApur);
        instanciaXml.evtComProd.infoComProd.ideEstab.vlrRatApur.Should().Be(instanciaPopulada.evtComProd.infoComProd.ideEstab.vlrRatApur);
        int iDetAquis = 0;
        instanciaXml.evtComProd.infoComProd.ideEstab.tipoCom.ForEach(ev =>
        {
            ev.indCom.Should().Be(instanciaPopulada.evtComProd.infoComProd.ideEstab.tipoCom[iDetAquis].indCom);
            ev.vlrRecBruta.Should().Be(instanciaPopulada.evtComProd.infoComProd.ideEstab.tipoCom[iDetAquis].vlrRecBruta);
            iDetAquis += 1;
        });
    }
}