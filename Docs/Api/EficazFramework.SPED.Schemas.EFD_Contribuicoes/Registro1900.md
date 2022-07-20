#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_Contribuicoes](EficazFramework.SPED.Schemas.EFD_Contribuicoes.md 'EficazFramework.SPED.Schemas.EFD_Contribuicoes')

## Registro1900 Class

Consolidação dos documentos emitidos no período por pessoa jurídica submetida ao regime de tributação com base no lucro presumido - regime de caixa ou de competência

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | CNPJEstabPJEmitenteDocsGeradoresReceita | `String` |  |
| 03 | CodModDocFiscal | `String` |  |
| 04 | SerieDocFiscal | `String` |  |
| 05 | SubSerieDocFiscal | `String` |  |
| 06 | CodigoSitDocFiscal | `SituacaoDocumento` |  |
| 07 | VrTotalRecConfDocsEmitidosPer | `Nullable<Double>` |  |
| 08 | QtdeDocsEmitidosPeriodo | `Nullable<Int32>` |  |
| 09 | CSTPis | `String` |  |
| 10 | CSTCofins | `String` |  |
| 11 | CFOP | `String` |  |
| 12 | InfoComplementar | `String` |  |
| 13 | CodigoConta | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
