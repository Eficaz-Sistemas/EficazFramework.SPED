#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_Contribuicoes](EficazFramework.SPED.Schemas.EFD_Contribuicoes.md 'EficazFramework.SPED.Schemas.EFD_Contribuicoes')

## RegistroM300 Class

Contribuição de PIS diferida em períodos anteriores - valores a pagar no período

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | CodigoContribDiferidaPerAnter | `String` |  |
| 03 | VrContribApuradaDiferidaPerAnter | `Nullable<Double>` |  |
| 04 | NatCreditoDiferidoVincRecMerInterno | `NaturezaCreditoDiferido` |  |
| 05 | VrCreditoDescontarVincContribDiferida | `Nullable<Double>` |  |
| 06 | VrContribRecolherDiferidaPerAnteriores | `Nullable<Double>` |  |
| 07 | PeriodoApuracaoContribCredDiferidos | `Nullable<DateTime>` |  |
| 08 | DataRecebReceitaDiferimento | `Nullable<DateTime>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
