namespace EficazFramework.SPED.Schemas.EFD_Reinf;

public class R2060Test : BaseEfdReinfTest<R2060>
{
    [Test]
    [TestCase(Versao.v1_05_01)]
    [TestCase(Versao.v2_01_01)]
    [TestCase(Versao.v2_01_02)]
    public void ValidaEvento(Versao versao)
    {
        _versao = versao;
        InstanciaDesserializada = (R2060 e) => e.Versao = versao;
        ValidationSchemaNamespace = $"http://www.reinf.esocial.gov.br/schemas/evtInfoCPRB/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v1_05_01 => Resources.Schemas.EFD_Reinf.R2060_v1_05_01,
            Versao.v2_01_01 => Resources.Schemas.EFD_Reinf.R2060_v2_01_01,
            Versao.v2_01_02 => Resources.Schemas.EFD_Reinf.R2060_v2_01_02_B,
            _ => Resources.Schemas.EFD_Reinf.R2060_v2_01_02_B
        };
        TestaEvento();
    }


    // BaseEfdReinfTest overrides
    public override void PreencheCampos(R2060 evento)
    {
        evento.Versao = _versao;
        PreencheCamposR2060(evento, CnpjCpf);
    }


    public static void PreencheCamposR2060(R2060 evento, string cnpjCpf)
    {
        evento.evtCPRB = new R2060EventoCprb()
        {
            ideContri = new IdentificacaoContribuinte()
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = cnpjCpf.Substring(0, 8)
            },
            ideEvento = new IdentificacaoEventoPeriodico()
            {
                indRetif = IndicadorRetificacao.Original,
                perApur = $"{DateTime.Now.AddMonths(-1):yyyy-MM}",
                procEmi = EmissorEvento.AppContribuinte,
                tpAmb = Ambiente.ProducaoRestrita_DadosReais,
                verProc = "2.2"
            },
            infoCPRB = new R2060InfoCprb()
            {
                ideEstab = new R2060IdentificacaoEstabelecimento()
                {
                    tpInscEstab = PersonalidadeJuridica.CNPJ,
                    nrInscEstab = cnpjCpf,
                    vlrRecBrutaTotal = 1000.00M.ToString("f2"),
                    vlrCPApurTotal = 110.00M.ToString("f2"),
                    tipoCod = new()
                    {
                        new R2060ReceitaPorAtividade()
                        {
                            codAtivEcon = "12345678",
                            vlrRecBrutaAtiv = 1000.00M.ToString("f2"),
                            vlrExcRecBruta = 0M.ToString("f2"),
                            vlrAdicRecBruta = 0M.ToString("f2"),
                            vlrBcCPRB = 1000.00M.ToString("f2"),
                            vlrCPRBapur = 110.00M.ToString("f2")
                        }
                    }
                }
            },
        };
    }


    public override void ValidaInstanciasLeituraEscrita(R2060 instanciaPopulada, R2060 instanciaXml)
    {
        // TODO: verifique se os campos de instanciaXml, preenchidos a partir da leitura de um XmlDocument, 
        //       correspondem exatamente aos valores de instanciaPopulada, formado à partir do método
        //       PreencheCampos().


        // ideEvento
        instanciaXml.evtCPRB.ideEvento.tpAmb.Should().Be(instanciaPopulada.evtCPRB.ideEvento.tpAmb);
        instanciaXml.evtCPRB.ideEvento.procEmi.Should().Be(instanciaPopulada.evtCPRB.ideEvento.procEmi);
        instanciaXml.evtCPRB.ideEvento.verProc.Should().Be(instanciaPopulada.evtCPRB.ideEvento.verProc);

        // ideContri
        instanciaXml.evtCPRB.ideContri.tpInsc.Should().Be(instanciaPopulada.evtCPRB.ideContri.tpInsc);
        instanciaXml.evtCPRB.ideContri.nrInsc.Should().Be(instanciaPopulada.evtCPRB.ideContri.nrInsc);

        // infoCPRB
        instanciaXml.evtCPRB.infoCPRB.ideEstab.tpInscEstab.Should().Be(instanciaPopulada.evtCPRB.infoCPRB.ideEstab.tpInscEstab);
        instanciaXml.evtCPRB.infoCPRB.ideEstab.nrInscEstab.Should().Be(instanciaPopulada.evtCPRB.infoCPRB.ideEstab.nrInscEstab);
        instanciaXml.evtCPRB.infoCPRB.ideEstab.vlrRecBrutaTotal.Should().Be(instanciaPopulada.evtCPRB.infoCPRB.ideEstab.vlrRecBrutaTotal);
        instanciaXml.evtCPRB.infoCPRB.ideEstab.vlrCPApurTotal.Should().Be(instanciaPopulada.evtCPRB.infoCPRB.ideEstab.vlrCPApurTotal);
        int iDetAquis = 0;
        instanciaXml.evtCPRB.infoCPRB.ideEstab.tipoCod.ForEach(ev =>
        {
            ev.codAtivEcon.Should().Be(instanciaPopulada.evtCPRB.infoCPRB.ideEstab.tipoCod[iDetAquis].codAtivEcon);
            ev.vlrRecBrutaAtiv.Should().Be(instanciaPopulada.evtCPRB.infoCPRB.ideEstab.tipoCod[iDetAquis].vlrRecBrutaAtiv); ;
            ev.vlrBcCPRB.Should().Be(instanciaPopulada.evtCPRB.infoCPRB.ideEstab.tipoCod[iDetAquis].vlrBcCPRB);
            ev.vlrCPRBapur.Should().Be(instanciaPopulada.evtCPRB.infoCPRB.ideEstab.tipoCod[iDetAquis].vlrCPRBapur);
            iDetAquis += 1;
        });
    }
}