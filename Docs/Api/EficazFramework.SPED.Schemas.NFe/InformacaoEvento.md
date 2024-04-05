#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## InformacaoEvento Class
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| Orgao | `OrgaoIBGE` |  |
| Ambiente | `Ambiente` |  |
| CNPJ_CPF | `String` |  |
| PersonalidadeJuridica | `PersonalidadeJuridica` |  |
| ChaveNFe | `String` |  |
| EventoData | `Nullable<DateTime>` |  |
| EventoDataString | `String` |  |
| EventoCodigo | `CodigoEvento` |  |
| EventoNumeroSequencial | `String` | Sequencial do evento. INFORMAR 1. |
| EventoVersao | `String` |  |
| EventoDetalhes | `DetalheEvento` |  |
| Id | `String` | Identificador da TAG a ser assinada.            A regra de formação do ID é:            "ID" + tpEvento + chave da NFe + nSeqEvento.            É gerado automaticamente. |

| Methods | |
| :--- | :--- |
| [Regenerate_ID()](EficazFramework.SPED.Schemas.NFe/InformacaoEvento/Regenerate_ID().md 'EficazFramework.SPED.Schemas.NFe.InformacaoEvento.Regenerate_ID()') | |
