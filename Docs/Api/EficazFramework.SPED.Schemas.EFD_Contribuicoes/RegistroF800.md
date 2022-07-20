#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_Contribuicoes](EficazFramework.SPED.Schemas.EFD_Contribuicoes.md 'EficazFramework.SPED.Schemas.EFD_Contribuicoes')

## RegistroF800 Class

créditos decorrentes de eventos de incorporação, fusão e cisão

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | IndicadorNaturezaEventoSucessao | `IndicadorNaturezaEventoSucessao` |  |
| 03 | DataEvento | `Nullable<DateTime>` |  |
| 04 | CNPJSucedida | `String` |  |
| 05 | PeriodoApCredito | `Nullable<DateTime>` |  |
| 06 | CodigoCreditoTransferido | `String` |  |
| 07 | VrCredTransfPis | `Nullable<Double>` |  |
| 08 | VrCredTransfCofins | `Nullable<Double>` |  |
| 09 | PercentualCredOriginalTransf | `Nullable<Double>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
