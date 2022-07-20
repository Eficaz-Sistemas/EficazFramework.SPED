#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## DetalhamentoIPI_Tributacao Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | CST | `CST_IPI` | Valores válidos: 00, 49, 50 e 99 |
| 03 | Aliquota | `Nullable<Double>` | Informar apenas para IPI calculado por alíquota. |
| 04 | Quantidade | `Nullable<Double>` | Informar apenas para IPI calculado por unidade. |
| 05 | BaseDeCalculo | `Nullable<Double>` | Informar apenas para IPI calculado por alíquota. |
| 06 | ValorPorUnidade | `Nullable<Double>` | Informar apenas para IPI calculado por unidade. |
| 07 | ValorIPI | `Nullable<Double>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| ShouldSerializeAliquota() | `Boolean` |  |
| ShouldSerializeQuantidade() | `Boolean` |  |
| ShouldSerializeBaseDeCalculo() | `Boolean` |  |
| ShouldSerializeValorPorUnidade() | `Boolean` |  |
| ShouldSerializeValorIPI() | `Boolean` |  |
| OnPropertyChanged(string) | `Void` |  |
