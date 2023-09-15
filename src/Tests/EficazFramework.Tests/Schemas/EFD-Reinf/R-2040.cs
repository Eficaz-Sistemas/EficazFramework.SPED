using System.Collections.Generic;

namespace EficazFramework.SPED.Schemas.EFD_Reinf;

public class R2040Test : BaseEfdReinfTest<R2040>
{
    [Test]
    [TestCase(Versao.v1_05_01)]
    [TestCase(Versao.v2_01_01)]
    [TestCase(Versao.v2_01_02)]
    public void ValidaEvento(Versao versao)
    {
        _versao = versao;
        InstanciaDesserializada = (R2040 e) => e.Versao = versao;
        ValidationSchemaNamespace = $"http://www.reinf.esocial.gov.br/schemas/evtRecursoRepassadoAssociacao/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v1_05_01 => Resources.Schemas.EFD_Reinf.R2040_v1_05_01,
            Versao.v2_01_01 => Resources.Schemas.EFD_Reinf.R2040_v2_01_01,
            Versao.v2_01_02 => Resources.Schemas.EFD_Reinf.R2040_v2_01_02_B,
            _ => Resources.Schemas.EFD_Reinf.R2040_v2_01_02_B
        };
        TestaEvento();
    }


    // BaseEfdReinfTest overrides
    public override void PreencheCampos(R2040 evento)
    {
        evento.Versao = _versao;
        PreencheCamposR2040(evento, CnpjCpf);
    }

    public static void PreencheCamposR2040(R2040 evento, string cnpjCpf)
    {
        evento.evtAssocDespRep = new R2040EventoAssociacaoDespRepasse()
        {
            ideContri = new R2040IdentificacaoContribuinteAssoc()
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = cnpjCpf.Substring(0, 8),
                ideEstab = new R2040IdentificacaoEstabelecimentoAssoc()
                {
                    tpInscEstab = PersonalidadeJuridica.CNPJ,
                    nrInscEstab = cnpjCpf,
                    recursosRep = new()
                    {
                        new R2040RecursosRepassados()
                        {
                            cnpjAssocDesp = "61918769000188",
                            vlrTotalRep = "600,00",
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

    public override void ValidaInstanciasLeituraEscrita(R2040 instanciaPopulada, R2040 instanciaXml)
    {
        // TODO: verifique se os campos de instanciaXml, preenchidos a partir da leitura de um XmlDocument, 
        //       correspondem exatamente aos valores de instanciaPopulada, formado à partir do método
        //       PreencheCampos().


        // ideEvento
        instanciaXml.evtAssocDespRep.ideEvento.tpAmb.Should().Be(instanciaPopulada.evtAssocDespRep.ideEvento.tpAmb);
        instanciaXml.evtAssocDespRep.ideEvento.procEmi.Should().Be(instanciaPopulada.evtAssocDespRep.ideEvento.procEmi);
        instanciaXml.evtAssocDespRep.ideEvento.verProc.Should().Be(instanciaPopulada.evtAssocDespRep.ideEvento.verProc);

        // ideContri
        instanciaXml.evtAssocDespRep.ideContri.tpInsc.Should().Be(instanciaPopulada.evtAssocDespRep.ideContri.tpInsc);
        instanciaXml.evtAssocDespRep.ideContri.nrInsc.Should().Be(instanciaPopulada.evtAssocDespRep.ideContri.nrInsc);
        instanciaXml.evtAssocDespRep.ideContri.ideEstab.tpInscEstab.Should().Be(instanciaPopulada.evtAssocDespRep.ideContri.ideEstab.tpInscEstab);
        instanciaXml.evtAssocDespRep.ideContri.ideEstab.tpInscEstab.Should().Be(instanciaPopulada.evtAssocDespRep.ideContri.ideEstab.tpInscEstab);
        instanciaXml.evtAssocDespRep.ideContri.ideEstab.nrInscEstab.Should().Be(instanciaPopulada.evtAssocDespRep.ideContri.ideEstab.nrInscEstab);
        int iEvtAssocDespRep = 0;
        instanciaXml.evtAssocDespRep.ideContri.ideEstab.recursosRep.ForEach(ev =>
        {
            ev.cnpjAssocDesp.Should().Be(instanciaPopulada.evtAssocDespRep.ideContri.ideEstab.recursosRep[iEvtAssocDespRep].cnpjAssocDesp);
            ev.vlrTotalRep.Should().Be(instanciaPopulada.evtAssocDespRep.ideContri.ideEstab.recursosRep[iEvtAssocDespRep].vlrTotalRep);
            ev.vlrTotalNRet.Should().Be(instanciaPopulada.evtAssocDespRep.ideContri.ideEstab.recursosRep[iEvtAssocDespRep].vlrTotalNRet);
            ev.vlrTotalRet.Should().Be(instanciaPopulada.evtAssocDespRep.ideContri.ideEstab.recursosRep[iEvtAssocDespRep].vlrTotalRet);

            iEvtAssocDespRep += 1;
        });
    }
}