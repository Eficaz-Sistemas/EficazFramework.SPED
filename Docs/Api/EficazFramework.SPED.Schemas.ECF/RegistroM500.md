#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.ECF](EficazFramework.SPED.Schemas.ECF.md 'EficazFramework.SPED.Schemas.ECF')

## RegistroM500 Class

Controle de Saldos das Contas da Parte B do e-Lalur e do e-Lacs

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | CodigoContaB | `String` |  |
| 03 | CodigoTributo | `String` | I = IRPJ            C = CSLL |
| 04 | SaldoInicial | `Nullable<Double>` |  |
| 05 | NaturezaSaldoInicial | `String` | D – Para prejuízos ou valores que reduzam o lucro real ou a base de cálculo da contribuição social em períodos subsequentes.            C – Para valores que aumentem o lucro real ou a base de cálculo da contribuição social em períodos subsequentes. |
| 06 | ValorLanctoParteA | `Nullable<Double>` |  |
| 07 | NaturezaLanctoParteA | `String` | D – Para prejuízos ou valores que reduzam o lucro real ou a base de cálculo da contribuição social em períodos subsequentes.            C – Para valores que aumentem o lucro real ou a base de cálculo da contribuição social em períodos subsequentes. |
| 08 | ValorLanctoParteB | `Nullable<Double>` |  |
| 09 | NaturezaLanctoParteB | `String` | D – Para prejuízos ou valores que reduzam o lucro real ou a base de cálculo da contribuição social em períodos subsequentes.            C – Para valores que aumentem o lucro real ou a base de cálculo da contribuição social em períodos subsequentes. |
| 10 | SaldoFinal | `Nullable<Double>` |  |
| 11 | NaturezaSaldoFinal | `String` | D – Para prejuízos ou valores que reduzam o lucro real ou a base de cálculo da contribuição social em períodos subsequentes.            C – Para valores que aumentem o lucro real ou a base de cálculo da contribuição social em períodos subsequentes. |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
