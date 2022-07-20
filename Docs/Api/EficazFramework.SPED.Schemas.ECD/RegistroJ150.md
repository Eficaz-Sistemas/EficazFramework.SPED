#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.ECD](EficazFramework.SPED.Schemas.ECD.md 'EficazFramework.SPED.Schemas.ECD')

## RegistroJ150 Class

Demonstração do Resultado do Exercício

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | NumeroOrdem | `Int32` |  |
| 03 | CodAglutinacao | `String` |  |
| 04 | IndicadorCodAglutinacao | `String` |  |
| 05 | NivelCodAglutinacao | `String` |  |
| 06 | CodAglutinacaoSuperior | `String` |  |
| 07 | DescCodAglutinacao | `String` |  |
| 08 | VrTotalPerAnteriorCodAglutinacao | `Nullable<Double>` |  |
| 09 | IndicadorSitVrPerAnteriorInformado | `String` |  |
| 10 | VrTotalCodAglutinacao | `Nullable<Double>` | Entenda esta campo como saldo final, a partir do Layout 7.00 considerado antes do encerramento |
| 11 | IndicadorSitVrInformado | `String` |  |
| 12 | IndicadorGrupoDRE | `String` |  |
| 13 | VrSaldoFinalAntesEncerr | `Nullable<Double>` | Utilizado apenas até o layout 6.00 |
| 14 | IndicadorSitVrInformadoSaldo | `String` | Utilizado apenas até o layout 6.00 |
| 15 | NotaExplicativa | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
