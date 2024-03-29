﻿namespace EficazFramework.SPED.Schemas.EFD_Reinf;

public class R4099Test : BaseEfdReinfTest<R4099>
{
    private int _testNumber = 0;

    [Test]
    [TestCase(Versao.v2_01_01)]
    [TestCase(Versao.v2_01_02)]
    public void Fechamento(Versao versao)
    {
        _testNumber = 0;
        _versao = versao;
        InstanciaDesserializada = (R4099 e) => e.Versao = versao;
        ValidationSchemaNamespace = $"http://www.reinf.esocial.gov.br/schemas/evt4099FechamentoDirf/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v1_05_01 => throw new ArgumentException("Invalid version."),
            Versao.v2_01_01 => Resources.Schemas.EFD_Reinf.R4099_v2_01_01,
            Versao.v2_01_02 => Resources.Schemas.EFD_Reinf.R4099_v2_01_02_B,
            _ => Resources.Schemas.EFD_Reinf.R4099_v2_01_02_B
        };
        TestaEvento();
    }

    [Test]
    [TestCase(Versao.v2_01_01)]
    [TestCase(Versao.v2_01_02)]
    public void Abertura(Versao versao)
    {
        _testNumber = 1;
        _versao = versao;
        InstanciaDesserializada = (R4099 e) => e.Versao = versao;
        ValidationSchemaNamespace = $"http://www.reinf.esocial.gov.br/schemas/evt4099FechamentoDirf/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v1_05_01 => throw new ArgumentException("Invalid version."),
            Versao.v2_01_01 => Resources.Schemas.EFD_Reinf.R4099_v2_01_01,
            Versao.v2_01_02 => Resources.Schemas.EFD_Reinf.R4099_v2_01_02_B,
            _ => Resources.Schemas.EFD_Reinf.R4099_v2_01_02_B
        };
        TestaEvento();
    }


    // BaseEfdReinfTest overrides
    public override void PreencheCampos(R4099 evento)
    {
        evento.Versao = _versao;
        switch (_testNumber)
        {
            case 0:
                PreencheCamposFechamento(evento, CnpjCpf);
                break;
            case 1:
                PreencheCamposReabertura(evento, CnpjCpf);
                break;
        }
    }

    public override void ValidaInstanciasLeituraEscrita(R4099 instanciaPopulada, R4099 instanciaXml)
    {
        // TODO: verifique se os campos de instanciaXml, preenchidos a partir da leitura de um XmlDocument, 
        //       correspondem exatamente aos valores de instanciaPopulada, formado à partir do método
        //       PreencheCampos().
        // ideEvento
        switch (_testNumber)
        {
            case 0:
                ValidaCamposFechamento(instanciaPopulada, instanciaXml);
                break;
            case 1:
                ValidaCamposReabertura(instanciaPopulada, instanciaXml);
                break;
        }
    }

    // Preenchimento e validação por tipo de teste
    #region Fechamento
    internal static void PreencheCamposFechamento(R4099 evento, string cnpjCpf)
    {
        evento.evtFech = new R4099EventoFechamReabertura()
        {
            ideEvento = new IdentificacaoEventoFechamento()
            {
                perApur = $"{DateTime.Now.AddMonths(-1):yyyy-MM}",
                tpAmb = Ambiente.ProducaoRestrita_DadosReais,
                procEmi = EmissorEvento.AppContribuinte,
                verProc = "6.0"
            },
            ideContri = new IdentificacaoContribuinte()
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = cnpjCpf[..8]
            },
            ideRespInf = new IdentificacaoResponsavel()
            {
                nmResp = "Pierre de Fermat",
                cpfResp = "47363361886",
                telefone = "11999990000",
                email = "contato@eficazcs.com.br",
            },
            infoFech = new R4099InformacaoFechamReabertura()
            {
                fechRet = IndicadorFechamentoReabertura.Fechamento
            }
        };
    }

    public void ValidaCamposFechamento(R4099 instanciaPopulada, R4099 instanciaXml)
    {
        // ideEvento
        instanciaXml.evtFech.ideEvento.perApur.Should().Be(instanciaPopulada.evtFech.ideEvento.perApur);
        instanciaXml.evtFech.ideEvento.tpAmb.Should().Be(instanciaPopulada.evtFech.ideEvento.tpAmb);
        instanciaXml.evtFech.ideEvento.procEmi.Should().Be(instanciaPopulada.evtFech.ideEvento.procEmi);
        instanciaXml.evtFech.ideEvento.verProc.Should().Be(instanciaPopulada.evtFech.ideEvento.verProc);

        // ideContri
        instanciaXml.evtFech.ideContri.tpInsc.Should().Be(instanciaPopulada.evtFech.ideContri.tpInsc);
        instanciaXml.evtFech.ideContri.nrInsc.Should().Be(instanciaPopulada.evtFech.ideContri.nrInsc);

        // ideRespInf
        instanciaXml.evtFech.ideRespInf.nmResp.Should().Be(instanciaPopulada.evtFech.ideRespInf.nmResp);
        instanciaXml.evtFech.ideRespInf.cpfResp.Should().Be(instanciaPopulada.evtFech.ideRespInf.cpfResp);
        instanciaXml.evtFech.ideRespInf.telefone.Should().Be(instanciaPopulada.evtFech.ideRespInf.telefone);
        instanciaXml.evtFech.ideRespInf.email.Should().Be(instanciaPopulada.evtFech.ideRespInf.email);

        // infoFech
        instanciaXml.evtFech.infoFech.fechRet.Should().Be(IndicadorFechamentoReabertura.Fechamento);
        instanciaXml.evtFech.infoFech.fechRet.Should().Be(instanciaPopulada.evtFech.infoFech.fechRet);
    }
    #endregion

    #region Reabertura
    internal static void PreencheCamposReabertura(R4099 evento, string cnpjCpf)
    {
        evento.evtFech = new R4099EventoFechamReabertura()
        {
            ideEvento = new IdentificacaoEventoFechamento()
            {
                perApur = $"{DateTime.Now.AddMonths(-1):yyyy-MM}",
                tpAmb = Ambiente.ProducaoRestrita_DadosReais,
                procEmi = EmissorEvento.AppContribuinte,
                verProc = "6.0"
            },
            ideContri = new IdentificacaoContribuinte()
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = cnpjCpf[..8]
            },
            ideRespInf = new IdentificacaoResponsavel()
            {
                nmResp = "Pierre de Fermat",
                cpfResp = "47363361886",
                telefone = "11999990000",
                email = "contato@eficazcs.com.br",
            },
            infoFech = new R4099InformacaoFechamReabertura()
            {
                fechRet = IndicadorFechamentoReabertura.Reabertura
            }
        };
    }

    public void ValidaCamposReabertura(R4099 instanciaPopulada, R4099 instanciaXml)
    {
        // ideEvento
        instanciaXml.evtFech.ideEvento.perApur.Should().Be(instanciaPopulada.evtFech.ideEvento.perApur);
        instanciaXml.evtFech.ideEvento.tpAmb.Should().Be(instanciaPopulada.evtFech.ideEvento.tpAmb);
        instanciaXml.evtFech.ideEvento.procEmi.Should().Be(instanciaPopulada.evtFech.ideEvento.procEmi);
        instanciaXml.evtFech.ideEvento.verProc.Should().Be(instanciaPopulada.evtFech.ideEvento.verProc);

        // ideContri
        instanciaXml.evtFech.ideContri.tpInsc.Should().Be(instanciaPopulada.evtFech.ideContri.tpInsc);
        instanciaXml.evtFech.ideContri.nrInsc.Should().Be(instanciaPopulada.evtFech.ideContri.nrInsc);

        // ideRespInf
        instanciaXml.evtFech.ideRespInf.nmResp.Should().Be(instanciaPopulada.evtFech.ideRespInf.nmResp);
        instanciaXml.evtFech.ideRespInf.cpfResp.Should().Be(instanciaPopulada.evtFech.ideRespInf.cpfResp);
        instanciaXml.evtFech.ideRespInf.telefone.Should().Be(instanciaPopulada.evtFech.ideRespInf.telefone);
        instanciaXml.evtFech.ideRespInf.email.Should().Be(instanciaPopulada.evtFech.ideRespInf.email);

        // infoFech
        instanciaXml.evtFech.infoFech.fechRet.Should().Be(IndicadorFechamentoReabertura.Reabertura);
        instanciaXml.evtFech.infoFech.fechRet.Should().Be(instanciaPopulada.evtFech.infoFech.fechRet);
    }
    #endregion

}