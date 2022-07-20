#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_Contribuicoes](EficazFramework.SPED.Schemas.EFD_Contribuicoes.md 'EficazFramework.SPED.Schemas.EFD_Contribuicoes')

## Registro1100 Class

Controle de créditos fiscais - Pis

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | PeriodoApuracaoCredito | `Nullable<DateTime>` |  |
| 03 | IndicadorOrigemCredito | `IndicadorOrigemCreditoBloco1` |  |
| 04 | CNPJSucedida | `String` |  |
| 05 | CodigoTipoCredito | `String` |  |
| 06 | VrTotalCreditoRegistroM100PerAnt | `Nullable<Double>` |  |
| 07 | VrCreditoExtempApuradoPerAnt | `Nullable<Double>` |  |
| 08 | VrTotalCreditoApurado | `Nullable<Double>` |  |
| 09 | VrCreditoUtilizDescPerAnt | `Nullable<Double>` |  |
| 10 | VrCreditoUtilizPedidoRessarcPerAnt | `Nullable<Double>` |  |
| 11 | VrCreditoUtilizDeclCompPerAnt | `Nullable<Double>` |  |
| 12 | SaldoCreditoDispUtilPerEscrit | `Nullable<Double>` |  |
| 13 | VrCredDescontPerEscrit | `Nullable<Double>` |  |
| 14 | VrCredObjPedidoRessarcPerEscrit | `Nullable<Double>` |  |
| 15 | VrCredUtilDeclCompPerEscrit | `Nullable<Double>` |  |
| 16 | VrCredTransfCisaoFusaoIncorp | `Nullable<Double>` |  |
| 17 | VrCredUtilizOutrasFormas | `Nullable<Double>` |  |
| 18 | SaldCredUtilPerFuturos | `Nullable<Double>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
