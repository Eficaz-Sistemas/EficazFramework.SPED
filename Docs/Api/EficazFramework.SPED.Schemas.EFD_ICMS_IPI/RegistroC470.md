#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## RegistroC470 Class

Itens do Documento Fiscal 2D

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | Produto | `String` |  |
| 03 | QuantidadeBruto | `Nullable<Double>` |  |
| 04 | QuantidadeCancelada | `Nullable<Double>` |  |
| 05 | Unidade | `String` |  |
| 06 | ValorLiquidoItem | `Nullable<Double>` |  |
| 07 | Origem | `OrigemMercadoria` |  |
| 08 | CST_ICMS | `CST_ICMS` |  |
| 09 | CFOP | `String` |  |
| 10 | Aliquota_ICMS | `Nullable<Double>` |  |
| 11 | PIS | `Nullable<Double>` |  |
| 12 | COFINS | `Nullable<Double>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
