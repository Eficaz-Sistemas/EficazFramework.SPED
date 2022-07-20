#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.Sintegra](EficazFramework.SPED.Schemas.Sintegra.md 'EficazFramework.SPED.Schemas.Sintegra')

## Registro60M Class

60 Mestre: Identificador do Equipamento

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | DataEmissao | `Nullable<DateTime>` |  |
| 03 | NumeroSerieFabEquip | `String` |  |
| 04 | NumeroSequencialEquip | `Nullable<Int32>` |  |
| 05 | ModeloDocFiscal | `String` |  |
| 06 | COO_Inicial | `Nullable<Int32>` |  |
| 07 | COO_Final | `Nullable<Int32>` |  |
| 08 | CRZ | `Nullable<Int32>` |  |
| 09 | CRO | `Nullable<Int32>` |  |
| 10 | VendaBrutaAcumulada | `Nullable<Double>` |  |
| 11 | TotalGeralAcumulado | `Nullable<Double>` |  |
| 12 | Brancos | `String` |  |
| 13 | Registros60A | `List<Registro60A>` |  |
| 14 | Registros60D | `List<Registro60D>` |  |
| 15 | Registros60I | `List<Registro60I>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
