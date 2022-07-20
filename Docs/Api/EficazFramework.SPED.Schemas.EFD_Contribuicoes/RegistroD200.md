#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_Contribuicoes](EficazFramework.SPED.Schemas.EFD_Contribuicoes.md 'EficazFramework.SPED.Schemas.EFD_Contribuicoes')

## RegistroD200 Class

Resumo Escrituração Diária Transportes

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | CodigoModeloDocFiscal | `String` |  |
| 03 | CodigoSituacaoDocFisca | `String` |  |
| 04 | SerieDocFiscal | `String` |  |
| 05 | SubSerieDocFiscal | `String` |  |
| 06 | NumeroDocFiscalInicial | `Nullable<Int64>` |  |
| 07 | NumeroDocFiscalFinal | `Nullable<Int64>` |  |
| 08 | CFOP | `String` |  |
| 09 | DataReferenciaResumoDiario | `Nullable<DateTime>` |  |
| 10 | VrTotalDocsFiscais | `Nullable<Double>` |  |
| 11 | VrTotalDescontos | `Nullable<Double>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
