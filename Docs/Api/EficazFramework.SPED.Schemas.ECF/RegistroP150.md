#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.ECF](EficazFramework.SPED.Schemas.ECF.md 'EficazFramework.SPED.Schemas.ECF')

## RegistroP150 Class

Demonstrativo do Resultado Líquido no Período Fiscal

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
| 08 | Valor | `Nullable<Double>` |  |
| 09 | NaturezaSaldoInicial | `String` | D - Devedor            C - Credor |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
