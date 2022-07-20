#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.MFD_ECF](EficazFramework.SPED.Schemas.MFD_ECF.md 'EficazFramework.SPED.Schemas.MFD_ECF')

## RegistroE12 Class

Relação de Reduções Z

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | NumeroFabricacaoECF | `String` |  |
| 03 | MFAdicional | `String` |  |
| 04 | Modelo | `String` |  |
| 05 | NumeroUsuario | `Nullable<Int32>` |  |
| 06 | CRZ | `Nullable<Int32>` |  |
| 07 | COO | `Nullable<Int32>` |  |
| 08 | CRO | `Nullable<Int32>` |  |
| 09 | DataMovimento | `Nullable<DateTime>` |  |
| 10 | DataEmissao | `Nullable<DateTime>` |  |
| 11 | HoraEmissao | `Nullable<TimeSpan>` |  |
| 12 | VendaBrutaDiaria | `Nullable<Double>` |  |
| 13 | IncidenciaDesconto | `Nullable<Boolean>` |  |
| 14 | RegistrosE13 | `List<RegistroE13>` |  |
| 15 | RegistrosE14 | `List<RegistroE14>` |  |
| 16 | RegistrosE15 | `List<RegistroE15>` |  |
| 17 | RegistrosE18 | `List<RegistroE18>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
