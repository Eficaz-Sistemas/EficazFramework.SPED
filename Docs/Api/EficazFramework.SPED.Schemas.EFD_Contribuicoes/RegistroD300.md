#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_Contribuicoes](EficazFramework.SPED.Schemas.EFD_Contribuicoes.md 'EficazFramework.SPED.Schemas.EFD_Contribuicoes')

## RegistroD300 Class

Resumo da Escrituração Diária - Bilhetes Consolidados

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | CodigoModeloDocFiscal | `String` |  |
| 03 | SerieDocFiscal | `String` |  |
| 04 | SubSerieDocFiscal | `String` |  |
| 05 | NumeroDocFiscalInicial | `Nullable<Int64>` |  |
| 06 | NumeroDocFiscalFinal | `Nullable<Int64>` |  |
| 07 | CFOP | `String` |  |
| 08 | DataReferenciaResumoDiario | `Nullable<DateTime>` |  |
| 09 | VrTotalDocsFiscais | `Nullable<Double>` |  |
| 10 | VrTotalDescontos | `Nullable<Double>` |  |
| 11 | CSTPis | `String` |  |
| 12 | VrBcPis | `Nullable<Double>` |  |
| 13 | AliquotaPis | `Nullable<Double>` |  |
| 14 | VrPis | `Nullable<Double>` |  |
| 15 | CSTCofins | `String` |  |
| 16 | VrBcCofins | `Nullable<Double>` |  |
| 17 | AliquotaCofins | `Nullable<Double>` |  |
| 18 | VrCofins | `Nullable<Double>` |  |
| 19 | CodigoContaContabil | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
