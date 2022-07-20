#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## InformacaoEvento Class
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | Orgao |  |
| 03 | Ambiente |  |
| 04 | CNPJ_CPF |  |
| 05 | PersonalidadeJuridica |  |
| 06 | ChaveNFe |  |
| 07 | EventoData |  |
| 08 | EventoDataString |  |
| 09 | EventoCodigo |  |
| 10 | EventoNumeroSequencial | Sequencial do evento. INFORMAR 1. |
| 11 | EventoVersao |  |
| 12 | EventoDetalhes |  |
| 13 | Id | Identificador da TAG a ser assinada.            A regra de formação do ID é:            "ID" + tpEvento + chave da NFe + nSeqEvento.            É gerado automaticamente. |
### Methods

| Name | |
| :--- | :--- |
| OnPropertyChanged(string) |  |
| Regenerate_ID() |  |
