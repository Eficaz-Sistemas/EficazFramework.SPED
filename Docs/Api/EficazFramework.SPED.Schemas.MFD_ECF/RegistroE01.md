#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.MFD_ECF](EficazFramework.SPED.Schemas.MFD_ECF.md 'EficazFramework.SPED.Schemas.MFD_ECF')

## RegistroE01 Class

Identificação do ECF

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | NumeroFabricacaoECF | `String` |  |
| 03 | MFAdicional | `String` |  |
| 04 | TipoECF | `String` |  |
| 05 | Marca | `String` |  |
| 06 | Modelo | `String` |  |
| 07 | VersaoSoftwareBasico | `String` |  |
| 08 | DataSoftwareBasico | `Nullable<DateTime>` |  |
| 09 | HoraSoftwareBasico | `Nullable<TimeSpan>` |  |
| 10 | NumeroSequencialECF | `Nullable<Int32>` |  |
| 11 | CNPJ | `String` |  |
| 12 | ComandoGeracao | `String` |  |
| 13 | CRZ_Inicial | `Nullable<Int32>` |  |
| 14 | CRZ_Final | `Nullable<Int32>` |  |
| 15 | DataInicial | `Nullable<DateTime>` |  |
| 16 | DataFInal | `Nullable<DateTime>` |  |
| 17 | VersaoDLL | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
