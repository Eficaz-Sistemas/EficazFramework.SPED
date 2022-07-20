#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.ECF](EficazFramework.SPED.Schemas.ECF.md 'EficazFramework.SPED.Schemas.ECF')

## RegistroM410 Class

Lançamento na Conta da Parte B do e-Lalur e do e-Lacs sem Reflexo na Parte A
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | CodigoContaParteB | `String` |  |
| 03 | CodigoTributo | `String` | I = IRPJ            C = CSLL |
| 04 | Valor | `Nullable<Double>` |  |
| 05 | IndicadorRelacao | `String` | CR = Crédito            DB = Débito            PR = Prejuízo do Exerício            BC = Base de Cálculo Negativa da CSLL |
| 06 | CodigoContaParteB_Destino | `String` | Caso seja necessária a transferência de saldo de uma conta na parte B para outra conta na parte B |
| 07 | Historico | `String` |  |
| 08 | LanctoExerciciosAnteriores | `Boolean` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
