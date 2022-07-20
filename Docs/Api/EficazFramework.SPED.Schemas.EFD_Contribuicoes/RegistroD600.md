#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_Contribuicoes](EficazFramework.SPED.Schemas.EFD_Contribuicoes.md 'EficazFramework.SPED.Schemas.EFD_Contribuicoes')

## RegistroD600 Class

Consolidação da Prestação de Serviços - Notas de Serviço de Comunicação

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | CodigoModeloDocFiscal | `String` |  |
| 03 | CodigoMunicipioIBGE | `String` |  |
| 04 | SerieDocFiscal | `String` |  |
| 05 | SubSerieDocFiscal | `String` |  |
| 06 | IndicadorTipoReceita | `IndicadorTipoReceita` |  |
| 07 | QtdeDocsConsolidadosRegistro | `Nullable<Int64>` |  |
| 08 | DataInicialDocsConsolidados | `Nullable<DateTime>` |  |
| 09 | DataFinalDocsConsolidados | `Nullable<DateTime>` |  |
| 10 | VrTotalAcumDocsFiscais | `Nullable<Double>` |  |
| 11 | VrAcumDescontos | `Nullable<Double>` |  |
| 12 | VrAcumPrestServTribICMS | `Nullable<Double>` |  |
| 13 | VrAcumPrestServNTribICMS | `Nullable<Double>` |  |
| 14 | VrCobradosTerceiros | `Nullable<Double>` |  |
| 15 | VrAcumDespAcessorias | `Nullable<Double>` |  |
| 16 | VrAcumBCICMS | `Nullable<Double>` |  |
| 17 | VrAcumICMS | `Nullable<Double>` |  |
| 18 | VrPIS | `Nullable<Double>` |  |
| 19 | VrCofins | `Nullable<Double>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
