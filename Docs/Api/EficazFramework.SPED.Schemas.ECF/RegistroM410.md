#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.ECF](EficazFramework.SPED.Schemas.ECF.md 'EficazFramework.SPED.Schemas.ECF')

## RegistroM410 Class

Lançamento na Conta da Parte B do e-Lalur e do e-Lacs sem Reflexo na Parte A
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| CodigoContaParteB | `String` |  |
| CodigoTributo | `String` | I = IRPJ            C = CSLL |
| Valor | `Nullable<Double>` |  |
| IndicadorRelacao | `String` | CR = Crédito            DB = Débito            PR = Prejuízo do Exerício            BC = Base de Cálculo Negativa da CSLL |
| CodigoContaParteB_Destino | `String` | Caso seja necessária a transferência de saldo de uma conta na parte B para outra conta na parte B |
| Historico | `String` |  |
| LanctoExerciciosAnteriores | `Boolean` |  |

| Methods | |
| :--- | :--- |
| [EscreveLinha()](EficazFramework.SPED.Schemas.ECF/RegistroM410/EscreveLinha().md 'EficazFramework.SPED.Schemas.ECF.RegistroM410.EscreveLinha()') | |
| [LeParametros(string[])](EficazFramework.SPED.Schemas.ECF/RegistroM410/LeParametros(string[]).md 'EficazFramework.SPED.Schemas.ECF.RegistroM410.LeParametros(string[])') | |
