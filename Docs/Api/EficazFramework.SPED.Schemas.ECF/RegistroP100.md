#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.ECF](EficazFramework.SPED.Schemas.ECF.md 'EficazFramework.SPED.Schemas.ECF')

## RegistroP100 Class

Balanço Patrimonial

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | CodigoReferencial | `String` |  |
| 03 | Descricao | `String` |  |
| 04 | TipoConta | `String` | S - Sintética            A - Analitica |
| 05 | Nivel | `Int32` |  |
| 06 | Natureza | `TipoConta` |  |
| 07 | ContaSuperior | `String` |  |
| 08 | SaldoInicial | `Nullable<Double>` |  |
| 09 | NaturezaSaldoInicial | `String` | D - Devedor            C - Credor |
| 10 | Debitos | `Nullable<Double>` |  |
| 11 | Creditos | `Nullable<Double>` |  |
| 12 | SaldoFinal | `Nullable<Double>` |  |
| 13 | NaturezaSaldoFinal | `String` | D - Devedor            C - Credor |
| 14 | SubContas | `List<RegistroP100>` | Apenas para possibilitar a totalização na montagem do BP |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
