#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_Contribuicoes](EficazFramework.SPED.Schemas.EFD_Contribuicoes.md 'EficazFramework.SPED.Schemas.EFD_Contribuicoes')

## RegistroD500 Class

Nota Fiscal Serviços de Comunicação

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | IndicadorTipoOperacao | `IndicadorTipoOperacaoBlocoD` |  |
| 03 | IndicadorEmitenteDocFiscal | `IndicadorEmitente` |  |
| 04 | CodigoParticipante | `String` |  |
| 05 | CodigoModeloDocFiscal | `String` |  |
| 06 | CodigoSituacaoDocFiscal | `String` |  |
| 07 | SerieDocFiscal | `String` |  |
| 08 | SubSerieDocFiscal | `String` |  |
| 09 | NumeroDocFiscal | `Nullable<Int64>` |  |
| 10 | DataEmissaoDocFiscal | `Nullable<DateTime>` |  |
| 11 | DataEntrada | `Nullable<DateTime>` |  |
| 12 | VrTotalDocFiscal | `Nullable<Double>` |  |
| 13 | VrTotalDesconto | `Nullable<Double>` |  |
| 14 | VrPrestacaoServico | `Nullable<Double>` |  |
| 15 | VrTotalServicosNaoTribICMS | `Nullable<Double>` |  |
| 16 | VrCobradoNomeTerceiro | `Nullable<Double>` |  |
| 17 | VrOutrasDespesas | `Nullable<Double>` |  |
| 18 | VrBcICMS | `Nullable<Double>` |  |
| 19 | VrICMS | `Nullable<Double>` |  |
| 20 | CodigoInfoComplementar | `String` |  |
| 21 | VrPis | `Nullable<Double>` |  |
| 22 | VrCofins | `Nullable<Double>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
