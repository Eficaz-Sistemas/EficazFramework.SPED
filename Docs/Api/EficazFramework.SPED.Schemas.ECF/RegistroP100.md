#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.ECF](EficazFramework.SPED.Schemas.ECF.md 'EficazFramework.SPED.Schemas.ECF')

## RegistroP100 Class

Balanço Patrimonial

### Remarks
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| CodigoReferencial | `String` |  |
| Descricao | `String` |  |
| TipoConta | `String` | S - Sintética            A - Analitica |
| Nivel | `Int32` |  |
| Natureza | `TipoConta` |  |
| ContaSuperior | `String` |  |
| SaldoInicial | `Nullable<Double>` |  |
| NaturezaSaldoInicial | `String` | D - Devedor            C - Credor |
| Debitos | `Nullable<Double>` |  |
| Creditos | `Nullable<Double>` |  |
| SaldoFinal | `Nullable<Double>` |  |
| NaturezaSaldoFinal | `String` | D - Devedor            C - Credor |
| SubContas | `List<RegistroP100>` | Apenas para possibilitar a totalização na montagem do BP |

| Methods | |
| :--- | :--- |
| [EscreveLinha()](EficazFramework.SPED.Schemas.ECF/RegistroP100/EscreveLinha().md 'EficazFramework.SPED.Schemas.ECF.RegistroP100.EscreveLinha()') | |
| [LeParametros(string[])](EficazFramework.SPED.Schemas.ECF/RegistroP100/LeParametros(string[]).md 'EficazFramework.SPED.Schemas.ECF.RegistroP100.LeParametros(string[])') | |
