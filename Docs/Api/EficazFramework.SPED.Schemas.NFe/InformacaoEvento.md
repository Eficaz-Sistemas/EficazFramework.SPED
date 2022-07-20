#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## InformacaoEvento Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | Orgao | `OrgaoIBGE` |  |
| 03 | Ambiente | `Ambiente` |  |
| 04 | CNPJ_CPF | `String` |  |
| 05 | PersonalidadeJuridica | `PersonalidadeJuridica` |  |
| 06 | ChaveNFe | `String` |  |
| 07 | EventoData | `Nullable<DateTime>` |  |
| 08 | EventoDataString | `String` |  |
| 09 | EventoCodigo | `CodigoEvento` |  |
| 10 | EventoNumeroSequencial | `String` | Sequencial do evento. INFORMAR 1. |
| 11 | EventoVersao | `String` |  |
| 12 | EventoDetalhes | `DetalheEvento` |  |
| 13 | Id | `String` | Identificador da TAG a ser assinada.            A regra de formação do ID é:            "ID" + tpEvento + chave da NFe + nSeqEvento.            É gerado automaticamente. |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| OnPropertyChanged(string) | `Void` |  |
| Regenerate_ID() | `Void` |  |
