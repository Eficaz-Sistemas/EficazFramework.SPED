#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## RegistroC405 Class

Redução Z (Código 02, 2D e 60)

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | Data | `Nullable<DateTime>` |  |
| 03 | CRO | `Nullable<Int32>` | Contador Reinínio Operação |
| 04 | CRZ | `Nullable<Int32>` | Contador de Redução Z |
| 05 | COO | `Nullable<Int32>` | Contador de Redução Z |
| 06 | GrandeTotalFinal | `Nullable<Double>` |  |
| 07 | VendaBruta | `Nullable<Double>` |  |
| 08 | RegistroC410 | `RegistroC410` |  |
| 09 | RegistrosC420 | `List<RegistroC420>` |  |
| 10 | RegistrosC460 | `List<RegistroC460>` |  |
| 11 | RegistrosC470 | `List<RegistroC470>` |  |
| 12 | RegistrosC490 | `List<RegistroC490>` |  |
| 13 | PossuiItemsC425 | `Boolean` |  |
| 14 | PossuiItemsC470 | `Boolean` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
