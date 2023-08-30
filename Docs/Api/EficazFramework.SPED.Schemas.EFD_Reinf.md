#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')

## EficazFramework.SPED.Schemas.EFD_Reinf Namespace

# Escrituração Fiscal Digital de Retenções e Outras Informações Fiscais<br/>  
## Publico Alvo<br/>  
 - Pessoas Físicas e Jurídicas;<br/>  
 - Ocorrência de valores de tributos ou contribuições previdenciárias retidos.<br/>  
## Guia<br/>  
Obrigação acessória que deve ser enviada mensalmente (ou a cada competência Janeiro, havendo a persistência da situação 'Sem Movimento'), para compor os valores de tributos ou contribuições previdenciárias retidas (substituídas) na DCTF-Web,   
de forma permitir o cálculo mensal das obrigações do contribuinte por meio deste.  
## Objetivo<br/>  
Tem por objeto a escrituração de rendimentos pagos e retenções de Imposto de Renda, Contribuição Social do contribuinte exceto aquelas relacionadas ao trabalho e informações sobre a receita bruta para a apuração das contribuições previdenciárias substituídas.<br/>  
## Links Úteis<br/>  
- [Manual de Orientação ao Usuário, v2.1.2.1](http://sped.rfb.gov.br/arquivo/show/7261)<br/>  
- [Manual de Orientação ao Desenvolvedor, v2.3](http://sped.rfb.gov.br/arquivo/show/7258)<br/>  
- [Layout, v2.1.2](http://sped.rfb.gov.br/pasta/show/7184)<br/>  
- [Schemas XSD, v.2.1.2](http://sped.rfb.gov.br/item/show/7196)<br/>  
- [Perguntas e Respostas](http://sped.rfb.gov.br/pastaperguntas/show/1497)<br/>  
## Implementação<br/>

| Classes | |
| :--- | :--- |
| [Evento](EficazFramework.SPED.Schemas.EFD_Reinf/Evento.md 'EficazFramework.SPED.Schemas.EFD_Reinf.Evento') | Abstração padrão para implementação em todos os eventos da escrituração. |
| [R1000](EficazFramework.SPED.Schemas.EFD_Reinf/R1000.md 'EficazFramework.SPED.Schemas.EFD_Reinf.R1000') | Informações do contribuinte |
| [R1070](EficazFramework.SPED.Schemas.EFD_Reinf/R1070.md 'EficazFramework.SPED.Schemas.EFD_Reinf.R1070') | Tabela de processos administrativos/judiciais |
| [R2010](EficazFramework.SPED.Schemas.EFD_Reinf/R2010.md 'EficazFramework.SPED.Schemas.EFD_Reinf.R2010') | Retenção de contribuição previdenciária - serviços tomados |
| [R2020](EficazFramework.SPED.Schemas.EFD_Reinf/R2020.md 'EficazFramework.SPED.Schemas.EFD_Reinf.R2020') | Retenção de contribuição previdenciária – serviços prestados |
| [R2030](EficazFramework.SPED.Schemas.EFD_Reinf/R2030.md 'EficazFramework.SPED.Schemas.EFD_Reinf.R2030') | Recursos recebidos por associação desportiva |
| [R2040](EficazFramework.SPED.Schemas.EFD_Reinf/R2040.md 'EficazFramework.SPED.Schemas.EFD_Reinf.R2040') | Recursos repassados para associação desportiva |
| [R2050](EficazFramework.SPED.Schemas.EFD_Reinf/R2050.md 'EficazFramework.SPED.Schemas.EFD_Reinf.R2050') | Comercialização da produção p/ produtor rural PJ/agroindústria |
| [R2055](EficazFramework.SPED.Schemas.EFD_Reinf/R2055.md 'EficazFramework.SPED.Schemas.EFD_Reinf.R2055') | Aquisição de produção rural |
| [R2060](EficazFramework.SPED.Schemas.EFD_Reinf/R2060.md 'EficazFramework.SPED.Schemas.EFD_Reinf.R2060') | Contribuição previdenciária sobre a receita bruta – CPRB |
| [R2098](EficazFramework.SPED.Schemas.EFD_Reinf/R2098.md 'EficazFramework.SPED.Schemas.EFD_Reinf.R2098') | Reabertura dos eventos da série R-2000 |
| [R2099](EficazFramework.SPED.Schemas.EFD_Reinf/R2099.md 'EficazFramework.SPED.Schemas.EFD_Reinf.R2099') | Fechamento dos eventos da série R-2000 |
| [R3010](EficazFramework.SPED.Schemas.EFD_Reinf/R3010.md 'EficazFramework.SPED.Schemas.EFD_Reinf.R3010') | Receita de espetáculos desportivos |
| [R4010](EficazFramework.SPED.Schemas.EFD_Reinf/R4010.md 'EficazFramework.SPED.Schemas.EFD_Reinf.R4010') | Pagamentos/créditos a beneficiário pessoa física |
| [R4020](EficazFramework.SPED.Schemas.EFD_Reinf/R4020.md 'EficazFramework.SPED.Schemas.EFD_Reinf.R4020') | Pagamentos/créditos a beneficiário pessoa jurídica |
| [R4040](EficazFramework.SPED.Schemas.EFD_Reinf/R4040.md 'EficazFramework.SPED.Schemas.EFD_Reinf.R4040') | Pagamentos/créditos a beneficiários não identificados |
| [R4080](EficazFramework.SPED.Schemas.EFD_Reinf/R4080.md 'EficazFramework.SPED.Schemas.EFD_Reinf.R4080') | Retenção no recebimento |
| [R4099](EficazFramework.SPED.Schemas.EFD_Reinf/R4099.md 'EficazFramework.SPED.Schemas.EFD_Reinf.R4099') | Fechamento/reabertura dos eventos da série R-4000 |
| [R9000](EficazFramework.SPED.Schemas.EFD_Reinf/R9000.md 'EficazFramework.SPED.Schemas.EFD_Reinf.R9000') | Exclusão de eventos |
| [ReinfTimeStampUtils](EficazFramework.SPED.Schemas.EFD_Reinf/ReinfTimeStampUtils.md 'EficazFramework.SPED.Schemas.EFD_Reinf.ReinfTimeStampUtils') | Utilitário para geração do identificador único de evento, para sua transmissão. |

| Enums | |
| :--- | :--- |
| [AcordoInternacionalIsencaoMulta](EficazFramework.SPED.Schemas.EFD_Reinf/AcordoInternacionalIsencaoMulta.md 'EficazFramework.SPED.Schemas.EFD_Reinf.AcordoInternacionalIsencaoMulta') | |
| [Ambiente](EficazFramework.SPED.Schemas.EFD_Reinf/Ambiente.md 'EficazFramework.SPED.Schemas.EFD_Reinf.Ambiente') | Ambiente em que os eventos são gerados e/ou enviados |
| [CategoriaEvento](EficazFramework.SPED.Schemas.EFD_Reinf/CategoriaEvento.md 'EficazFramework.SPED.Schemas.EFD_Reinf.CategoriaEvento') | |
| [CodigoAjusteConstribuicao](EficazFramework.SPED.Schemas.EFD_Reinf/CodigoAjusteConstribuicao.md 'EficazFramework.SPED.Schemas.EFD_Reinf.CodigoAjusteConstribuicao') | |
| [DesoneracaoCPRB](EficazFramework.SPED.Schemas.EFD_Reinf/DesoneracaoCPRB.md 'EficazFramework.SPED.Schemas.EFD_Reinf.DesoneracaoCPRB') | |
| [EmissorEvento](EficazFramework.SPED.Schemas.EFD_Reinf/EmissorEvento.md 'EficazFramework.SPED.Schemas.EFD_Reinf.EmissorEvento') | Origem do software emissor/transmissor do evento |
| [IndicadorAquisProd](EficazFramework.SPED.Schemas.EFD_Reinf/IndicadorAquisProd.md 'EficazFramework.SPED.Schemas.EFD_Reinf.IndicadorAquisProd') | |
| [IndicadorAuditoria](EficazFramework.SPED.Schemas.EFD_Reinf/IndicadorAuditoria.md 'EficazFramework.SPED.Schemas.EFD_Reinf.IndicadorAuditoria') | |
| [IndicadorContribuicaoProd](EficazFramework.SPED.Schemas.EFD_Reinf/IndicadorContribuicaoProd.md 'EficazFramework.SPED.Schemas.EFD_Reinf.IndicadorContribuicaoProd') | |
| [IndicadorContribuinteCPRB](EficazFramework.SPED.Schemas.EFD_Reinf/IndicadorContribuinteCPRB.md 'EficazFramework.SPED.Schemas.EFD_Reinf.IndicadorContribuinteCPRB') | |
| [IndicadorFciScp](EficazFramework.SPED.Schemas.EFD_Reinf/IndicadorFciScp.md 'EficazFramework.SPED.Schemas.EFD_Reinf.IndicadorFciScp') | |
| [IndicadorFechamentoReabertura](EficazFramework.SPED.Schemas.EFD_Reinf/IndicadorFechamentoReabertura.md 'EficazFramework.SPED.Schemas.EFD_Reinf.IndicadorFechamentoReabertura') | |
| [IndicadorNIF](EficazFramework.SPED.Schemas.EFD_Reinf/IndicadorNIF.md 'EficazFramework.SPED.Schemas.EFD_Reinf.IndicadorNIF') | |
| [IndicadorObra](EficazFramework.SPED.Schemas.EFD_Reinf/IndicadorObra.md 'EficazFramework.SPED.Schemas.EFD_Reinf.IndicadorObra') | |
| [IndicadorOrigemDosRecursos](EficazFramework.SPED.Schemas.EFD_Reinf/IndicadorOrigemDosRecursos.md 'EficazFramework.SPED.Schemas.EFD_Reinf.IndicadorOrigemDosRecursos') | |
| [IndicadorRetificacao](EficazFramework.SPED.Schemas.EFD_Reinf/IndicadorRetificacao.md 'EficazFramework.SPED.Schemas.EFD_Reinf.IndicadorRetificacao') | |
| [IndicadorTipoDeducaoPrevidenciaria](EficazFramework.SPED.Schemas.EFD_Reinf/IndicadorTipoDeducaoPrevidenciaria.md 'EficazFramework.SPED.Schemas.EFD_Reinf.IndicadorTipoDeducaoPrevidenciaria') | |
| [ObrigatoriedadeECD](EficazFramework.SPED.Schemas.EFD_Reinf/ObrigatoriedadeECD.md 'EficazFramework.SPED.Schemas.EFD_Reinf.ObrigatoriedadeECD') | |
| [PersonalidadeJuridica](EficazFramework.SPED.Schemas.EFD_Reinf/PersonalidadeJuridica.md 'EficazFramework.SPED.Schemas.EFD_Reinf.PersonalidadeJuridica') | Personalidade Jurídica do Contribuinte, Estabelecimento ou Participante |
| [RelacaoDependencia](EficazFramework.SPED.Schemas.EFD_Reinf/RelacaoDependencia.md 'EficazFramework.SPED.Schemas.EFD_Reinf.RelacaoDependencia') | |
| [SimNao](EficazFramework.SPED.Schemas.EFD_Reinf/SimNao.md 'EficazFramework.SPED.Schemas.EFD_Reinf.SimNao') | |
| [SituacaoPessoaJuridica](EficazFramework.SPED.Schemas.EFD_Reinf/SituacaoPessoaJuridica.md 'EficazFramework.SPED.Schemas.EFD_Reinf.SituacaoPessoaJuridica') | Indicador de Situação da Pessoa Jurídica |
| [TipoAjusteContribuicao](EficazFramework.SPED.Schemas.EFD_Reinf/TipoAjusteContribuicao.md 'EficazFramework.SPED.Schemas.EFD_Reinf.TipoAjusteContribuicao') | |
| [TipoCompeticao](EficazFramework.SPED.Schemas.EFD_Reinf/TipoCompeticao.md 'EficazFramework.SPED.Schemas.EFD_Reinf.TipoCompeticao') | |
| [TipoEventoExclusao](EficazFramework.SPED.Schemas.EFD_Reinf/TipoEventoExclusao.md 'EficazFramework.SPED.Schemas.EFD_Reinf.TipoEventoExclusao') | |
| [TipoIngressoCompeticao](EficazFramework.SPED.Schemas.EFD_Reinf/TipoIngressoCompeticao.md 'EficazFramework.SPED.Schemas.EFD_Reinf.TipoIngressoCompeticao') | |
| [TipoIsencaoPF](EficazFramework.SPED.Schemas.EFD_Reinf/TipoIsencaoPF.md 'EficazFramework.SPED.Schemas.EFD_Reinf.TipoIsencaoPF') | |
| [TipoIsencaoPJ](EficazFramework.SPED.Schemas.EFD_Reinf/TipoIsencaoPJ.md 'EficazFramework.SPED.Schemas.EFD_Reinf.TipoIsencaoPJ') | |
| [TipoOCorrenciaR5001](EficazFramework.SPED.Schemas.EFD_Reinf/TipoOCorrenciaR5001.md 'EficazFramework.SPED.Schemas.EFD_Reinf.TipoOCorrenciaR5001') | |
| [TipoProcesso](EficazFramework.SPED.Schemas.EFD_Reinf/TipoProcesso.md 'EficazFramework.SPED.Schemas.EFD_Reinf.TipoProcesso') | |
| [TipoReceitaCompeticao](EficazFramework.SPED.Schemas.EFD_Reinf/TipoReceitaCompeticao.md 'EficazFramework.SPED.Schemas.EFD_Reinf.TipoReceitaCompeticao') | |
| [TipoRepasseAssocDesp](EficazFramework.SPED.Schemas.EFD_Reinf/TipoRepasseAssocDesp.md 'EficazFramework.SPED.Schemas.EFD_Reinf.TipoRepasseAssocDesp') | |
| [Versao](EficazFramework.SPED.Schemas.EFD_Reinf/Versao.md 'EficazFramework.SPED.Schemas.EFD_Reinf.Versao') | Versão do schema |
