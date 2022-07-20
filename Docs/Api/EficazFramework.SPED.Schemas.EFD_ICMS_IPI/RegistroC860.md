#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## RegistroC860 Class

Identificação do Equipamento SAT CF-e (59)

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | EspecieDocumento | `String` |  |
| 03 | NumeroSerieSAT | `Nullable<Int32>` |  |
| 04 | DataEmissao | `Nullable<DateTime>` |  |
| 05 | DocInicial | `Nullable<Int32>` |  |
| 06 | DocFinal | `Nullable<Int32>` |  |
| 07 | RegistrosC890 | `List<RegistroC890>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
