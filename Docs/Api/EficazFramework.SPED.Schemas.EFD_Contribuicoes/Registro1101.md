#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_Contribuicoes](EficazFramework.SPED.Schemas.EFD_Contribuicoes.md 'EficazFramework.SPED.Schemas.EFD_Contribuicoes')

## Registro1101 Class

Apuração de Crédito Extemporâneo - Documentos e Operações de Períodos Anteriores

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | CodigoParticipante | `String` |  |
| 03 | CodigoItem | `String` |  |
| 04 | CodigoModDocFiscal | `String` |  |
| 05 | SerieDocFiscal | `String` |  |
| 06 | SubSerieDocFiscal | `String` |  |
| 07 | NumeroDocFiscal | `String` |  |
| 08 | DataOperacao | `Nullable<DateTime>` |  |
| 09 | ChaveNFe | `String` |  |
| 10 | VrOperacao | `Nullable<Double>` |  |
| 11 | CFOP | `String` |  |
| 12 | CodigoBCCredito | `String` |  |
| 13 | IndicadorOrigemCredito | `IndicadorOrigemCredito` |  |
| 14 | CSTPis | `String` |  |
| 15 | VrBCPis | `Nullable<Double>` |  |
| 16 | AliqPis | `Nullable<Double>` |  |
| 17 | VrCredPis | `Nullable<Double>` |  |
| 18 | CodigoContaContabil | `String` |  |
| 19 | CodigoCentroCusto | `String` |  |
| 20 | DescricaoComplementar | `String` |  |
| 21 | MesAnoEscrituracao | `Nullable<DateTime>` |  |
| 22 | CNPJEstabelecimentoCredito | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
