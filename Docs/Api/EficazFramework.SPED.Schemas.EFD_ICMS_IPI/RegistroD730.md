#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## RegistroD730 Class

Registro analítico Nota Fiscal Fatura Eletrônica de Serviços de Comunicação – NFCom (Código 62)

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | Origem | `OrigemMercadoria` |  |
| 03 | CST_ICMS | `CST_ICMS` |  |
| 04 | CFOP | `String` |  |
| 05 | AliquotaICMS | `Nullable<Double>` |  |
| 06 | ValorOperacao | `Nullable<Double>` |  |
| 07 | ValorBaseCalculoICMS | `Nullable<Double>` |  |
| 08 | ValorICMS | `Nullable<Double>` |  |
| 09 | ValorReducaoBC | `Nullable<Double>` |  |
| 10 | CodigoObservacao0460 | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
