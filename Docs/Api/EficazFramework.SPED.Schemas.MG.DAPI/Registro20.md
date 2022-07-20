#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.MG.DAPI](EficazFramework.SPED.Schemas.MG.DAPI.md 'EficazFramework.SPED.Schemas.MG.DAPI')

## Registro20 Class

Detalhamento de Créditos Recebidos no Campo 66
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | InscricaoEstadual | `String` |  |
| 03 | DataFinal | `Nullable<DateTime>` |  |
| 04 | DataInicial | `Nullable<DateTime>` |  |
| 05 | ProdutorRural | `String` | Informar SEMPRE "N" a partir da versao 8.02.00 |
| 06 | UF_Remetente | `String` |  |
| 07 | IE_Rementete | `String` |  |
| 08 | NotaFiscal_Numero | `String` |  |
| 09 | NotaFiscal_Serie | `String` |  |
| 10 | NotaFiscal_Data | `Nullable<DateTime>` |  |
| 11 | NotaFiscal_DataVisto | `Nullable<DateTime>` |  |
| 12 | ValorDeclarado | `Nullable<Double>` |  |
| 13 | Motivo | `Int16` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
