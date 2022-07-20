#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## RegistroC857 Class

Outras obrigações tributárias, ajustes e informações de  valores provenientes de documento fiscal.

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | CodigoAjusteBeneficio | `String` |  |
| 03 | DescricaoAjusteBeneficio | `String` |  |
| 04 | CodigoItem | `String` |  |
| 05 | ValorBaseCalculoICMS | `Nullable<Double>` |  |
| 06 | AliquotaICMS | `Nullable<Double>` |  |
| 07 | ValorICMS | `Nullable<Double>` |  |
| 08 | ValorOutros | `Nullable<Double>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
