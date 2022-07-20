#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.MG.DAPI](EficazFramework.SPED.Schemas.MG.DAPI.md 'EficazFramework.SPED.Schemas.MG.DAPI')

## Registro22 Class

Detalhamento de Estorno de Débitos no Campo 90
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | InscricaoEstadual | `String` |  |
| 03 | DataFinal | `Nullable<DateTime>` |  |
| 04 | DataInicial | `Nullable<DateTime>` |  |
| 05 | NotaFiscal_Numero | `String` |  |
| 06 | NotaFiscal_Serie | `String` |  |
| 07 | NotaFiscal_Data | `Nullable<DateTime>` |  |
| 08 | ValorDeclarado | `Nullable<Double>` |  |
| 09 | Justificativa | `String` |  |
| 10 | Motivo | `Registro_22_Motivos` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
