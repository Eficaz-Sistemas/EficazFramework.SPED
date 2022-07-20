#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## DetalhamentoPagamento Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | indPag | `Nullable<FormaDePagamento>` |  |
| 03 | tPag | `FormaPagamento` |  |
| 04 | vPag | `Nullable<Double>` |  |
| 05 | DetalhamentoCartao | `DetalhamentoPagamentoCartao` |  |
| 06 | vTroco | `Nullable<Double>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| ShouldSerializeindPag() | `Boolean` |  |
| ShouldSerializevPag() | `Boolean` |  |
| ShouldSerializevTroco() | `Boolean` |  |
| ToString() | `String` |  |
| OnPropertyChanged(string) | `Void` |  |
