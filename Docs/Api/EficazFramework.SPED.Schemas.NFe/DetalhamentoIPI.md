#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## DetalhamentoIPI Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | Classe | `String` |  |
| 03 | CNPJProdutor | `String` | CNPJ do produtor da mercadoria, quando diferente do emitente.            Somente para os casos de exportação direta ou indireta. |
| 04 | SeloControle | `String` |  |
| 05 | SeloQuantidade | `Nullable<Int32>` |  |
| 06 | CodigoEnquadramento | `String` |  |
| 07 | Tributacao | `DetalhamentoIPI_Tributacao` |  |
| 08 | TributacaoIndentifier | `Tributacao_IPI_Identifier` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| ShouldSerializeSeloQuantidade() | `Boolean` |  |
| OnPropertyChanged(string) | `Void` |  |
