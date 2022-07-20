#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.CTe](EficazFramework.SPED.Schemas.CTe.md 'EficazFramework.SPED.Schemas.CTe')

## IdentificacaoOperacao Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | CodigoIBGE | `OrgaoIBGE` |  |
| 03 | Chave | `String` |  |
| 04 | CFOP | `String` |  |
| 05 | NaturezaOperacao | `String` |  |
| 06 | FormaPagamento | `FormaPagamento` |  |
| 07 | Modelo | `Modelo` |  |
| 08 | Serie | `String` |  |
| 09 | Numero | `Nullable<Int64>` |  |
| 10 | DataEmissao | `Nullable<DateTime>` |  |
| 11 | TipoImpressao | `FormatoImpressao` |  |
| 12 | FormaEmissao | `FormaEmissao` |  |
| 13 | DigitoVerificador | `String` |  |
| 14 | Ambiente | `Ambiente` |  |
| 15 | Finalidade | `TipoCTe` |  |
| 16 | ProcessoEmissao | `ProcessoEmissao` |  |
| 17 | VersaoAplicativoEmissor | `String` |  |
| 18 | ChaveCteReferenciado | `String` |  |
| 19 | MunicipioEnvioCodigo | `String` |  |
| 20 | MunicipioEnvioNome | `String` |  |
| 21 | UFEnvio | `Estado` |  |
| 22 | Modalidade | `ModalidadeTransporte` |  |
| 23 | TipoServico | `TiposServico` |  |
| 24 | MunicipioInicioCodigo | `String` |  |
| 25 | MunicipioInicioNome | `String` |  |
| 26 | UFInicio | `Estado` |  |
| 27 | MunicipioFimCodigo | `String` |  |
| 28 | MunicipioFimNome | `String` |  |
| 29 | UFFim | `Estado` |  |
| 30 | retira | `Retira` |  |
| 31 | xDetRetira | `String` |  |
| 32 | Tomador | `Object` |  |
| 33 | DataHoraContingencia | `Nullable<DateTime>` |  |
| 34 | JustificativaContingencia | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| ShouldSerializeDataEmissao() | `Boolean` |  |
| ShouldSerializeDataHoraContingencia() | `Boolean` |  |
| OnPropertyChanged(string) | `Void` |  |
