#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Services.NFe](EficazFramework.SPED.Services.NFe.md 'EficazFramework.SPED.Services.NFe')

## NFeService Class

| Methods | |
| :--- | :--- |
| [Autoriza4Async(NFe, string, Ambiente)](EficazFramework.SPED.Services.NFe/NFeService/Autoriza4Async(NFe,string,Ambiente).md 'EficazFramework.SPED.Services.NFe.NFeService.Autoriza4Async(EficazFramework.SPED.Schemas.NFe.NFe, string, EficazFramework.SPED.Schemas.NFe.Ambiente)') | Efetua a transmissão de NF-e / NFC-e na versão 4.00 para autorização.<br/>NOTA: No nomento, opera apenas no modelo síncroni, com um único documento por lote |
| [ConsultaCadastro4Async(string, TipoPesquisaCadastro, OrgaoIBGE)](EficazFramework.SPED.Services.NFe/NFeService/ConsultaCadastro4Async(string,TipoPesquisaCadastro,OrgaoIBGE).md 'EficazFramework.SPED.Services.NFe.NFeService.ConsultaCadastro4Async(string, EficazFramework.SPED.Schemas.NFe.TipoPesquisaCadastro, EficazFramework.SPED.Schemas.NFe.OrgaoIBGE)') | Efetua a consulta de cadastro de contribuintes, na versão 4.00 |
| [ConsultaProtocolo4Async(string, Ambiente)](EficazFramework.SPED.Services.NFe/NFeService/ConsultaProtocolo4Async(string,Ambiente).md 'EficazFramework.SPED.Services.NFe.NFeService.ConsultaProtocolo4Async(string, EficazFramework.SPED.Schemas.NFe.Ambiente)') | Efetua a consulta de protocolo de NF-e / NFC-e na versão 4.00 |
| [DistribuicaoDFeAsync(OrgaoIBGE, string, int, Ambiente, string)](EficazFramework.SPED.Services.NFe/NFeService/DistribuicaoDFeAsync(OrgaoIBGE,string,int,Ambiente,string).md 'EficazFramework.SPED.Services.NFe.NFeService.DistribuicaoDFeAsync(EficazFramework.SPED.Schemas.NFe.OrgaoIBGE, string, int, EficazFramework.SPED.Schemas.NFe.Ambiente, string)') | Executa o serviço de distribuição de DF-e e visa retornar as informações sobre NF-e dos últimos 90 dias. <br/><br/>Pode incluir: NF-e completa, resumo de NF-e e/ou eventos da NF-e. |
| [EnvioEventoAsync(string, string, CodigoEvento, Ambiente, string)](EficazFramework.SPED.Services.NFe/NFeService/EnvioEventoAsync(string,string,CodigoEvento,Ambiente,string).md 'EficazFramework.SPED.Services.NFe.NFeService.EnvioEventoAsync(string, string, EficazFramework.SPED.Schemas.NFe.CodigoEvento, EficazFramework.SPED.Schemas.NFe.Ambiente, string)') | Executa a chamada ao WebService de envio de eventos para uma NF-e |
