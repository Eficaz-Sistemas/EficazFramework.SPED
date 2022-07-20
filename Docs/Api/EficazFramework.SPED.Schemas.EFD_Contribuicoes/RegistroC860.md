#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_Contribuicoes](EficazFramework.SPED.Schemas.EFD_Contribuicoes.md 'EficazFramework.SPED.Schemas.EFD_Contribuicoes')

## RegistroC860 Class

Identificação do Equipamento SAT CF-e

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | EspecieDocumento | `String` |  |
| 03 | NumeroSerieSAT | `Nullable<Int32>` |  |
| 04 | DataEmissao | `Nullable<DateTime>` |  |
| 05 | DocInicial | `Nullable<Int32>` |  |
| 06 | DocFinal | `Nullable<Int32>` |  |
| 07 | RegistrosC870 | `List<RegistroC870>` |  |
| 08 | RegistrosC880 | `List<RegistroC880>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
