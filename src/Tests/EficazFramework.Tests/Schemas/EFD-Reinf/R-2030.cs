using System.Collections.Generic;

namespace EficazFramework.SPED.Schemas.EFD_Reinf;

public class R2030Test : BaseEfdReinfTest<R2030>
{
    [Test]
    [TestCase(Versao.v1_05_01)]
    [TestCase(Versao.v2_01_01)]
    [TestCase(Versao.v2_01_02)]
    public void ValidaEvento(Versao versao)
    {
        _versao = versao;
        InstanciaDesserializada = (R2030 e) => e.Versao = versao;
        ValidationSchemaNamespace = $"http://www.reinf.esocial.gov.br/schemas/evtRecursoRecebidoAssociacao/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v1_05_01 => Resources.Schemas.EFD_Reinf.R2030_v1_05_01,
            Versao.v2_01_01 => Resources.Schemas.EFD_Reinf.R2030_v2_01_01,
            Versao.v2_01_02 => Resources.Schemas.EFD_Reinf.R2030_v2_01_02_B,
            _ => Resources.Schemas.EFD_Reinf.R2030_v2_01_02_B
        };
        TestaEvento();
    }


    // BaseEfdReinfTest overrides
    public override void PreencheCampos(R2030 evento)
    {
        evento.Versao = _versao;
        PreencheCamposR2030(evento, CnpjCpf);
    }

    public static void PreencheCamposR2030(R2030 evento, string cnpjCpf)
    {
        evento.evtAssocDespRec = new R2030EventoAssociacaoDespRecebim()
        {
            ideContri = new R2030IdentificacaoContribuinteAssoc()
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = cnpjCpf.Substring(0, 8),
                ideEstab = new R2030IdentificacaoEstabelecimentoAssoc()
                {
                    tpInscEstab = PersonalidadeJuridica.CNPJ,
                    nrInscEstab = cnpjCpf,
                    recursosRec = new()
                    {
                        new R2030RecursosRecebidos()
                        {
                            cnpjOrigRecurso = "61918769000188",
                            vlrTotalRec = "600,00",
                            vlrTotalNRet = "0,00",
                            vlrTotalRet = "60,00",
                            infoRecurso = new()
                            {
                                new R2030eR2040InfoRecurso()
                                {
                                    tpRepasse = TipoRepasseAssocDesp.Patrocinio,
                                    descRecurso = "Exib. camp. nac.",
                                    vlrBruto = "660,00",
                                    vlrRetApur = "60,00"
                                }
                            }
                        }
                    }
                }
            },
            ideEvento = new IdentificacaoEventoPeriodico()
            {
                indRetif = IndicadorRetificacao.Original,
                perApur = $"{DateTime.Now.AddMonths(-1):yyyy-MM}",
                procEmi = EmissorEvento.AppContribuinte,
                tpAmb = Ambiente.ProducaoRestrita_DadosReais,
                verProc = "2.2"
            }
        };
    }


    public override void ValidaInstanciasLeituraEscrita(R2030 instanciaPopulada, R2030 instanciaXml)
    {
        // TODO: verifique se os campos de instanciaXml, preenchidos a partir da leitura de um XmlDocument, 
        //       correspondem exatamente aos valores de instanciaPopulada, formado à partir do método
        //       PreencheCampos().


        // ideEvento
        instanciaXml.evtAssocDespRec.ideEvento.tpAmb.Should().Be(instanciaPopulada.evtAssocDespRec.ideEvento.tpAmb);
        instanciaXml.evtAssocDespRec.ideEvento.procEmi.Should().Be(instanciaPopulada.evtAssocDespRec.ideEvento.procEmi);
        instanciaXml.evtAssocDespRec.ideEvento.verProc.Should().Be(instanciaPopulada.evtAssocDespRec.ideEvento.verProc);

        // ideContri
        instanciaXml.evtAssocDespRec.ideContri.tpInsc.Should().Be(instanciaPopulada.evtAssocDespRec.ideContri.tpInsc);
        instanciaXml.evtAssocDespRec.ideContri.nrInsc.Should().Be(instanciaPopulada.evtAssocDespRec.ideContri.nrInsc);
        instanciaXml.evtAssocDespRec.ideContri.ideEstab.tpInscEstab.Should().Be(instanciaPopulada.evtAssocDespRec.ideContri.ideEstab.tpInscEstab);
        instanciaXml.evtAssocDespRec.ideContri.ideEstab.tpInscEstab.Should().Be(instanciaPopulada.evtAssocDespRec.ideContri.ideEstab.tpInscEstab);
        instanciaXml.evtAssocDespRec.ideContri.ideEstab.nrInscEstab.Should().Be(instanciaPopulada.evtAssocDespRec.ideContri.ideEstab.nrInscEstab);
        int iEvtAssocDespRec = 0;
        instanciaXml.evtAssocDespRec.ideContri.ideEstab.recursosRec.ForEach(ev =>
        {
            ev.cnpjOrigRecurso.Should().Be(instanciaPopulada.evtAssocDespRec.ideContri.ideEstab.recursosRec[iEvtAssocDespRec].cnpjOrigRecurso);
            ev.vlrTotalRec.Should().Be(instanciaPopulada.evtAssocDespRec.ideContri.ideEstab.recursosRec[iEvtAssocDespRec].vlrTotalRec);
            ev.vlrTotalNRet.Should().Be(instanciaPopulada.evtAssocDespRec.ideContri.ideEstab.recursosRec[iEvtAssocDespRec].vlrTotalNRet);
            ev.vlrTotalRet.Should().Be(instanciaPopulada.evtAssocDespRec.ideContri.ideEstab.recursosRec[iEvtAssocDespRec].vlrTotalRet);

            iEvtAssocDespRec += 1;
        });
    }
}