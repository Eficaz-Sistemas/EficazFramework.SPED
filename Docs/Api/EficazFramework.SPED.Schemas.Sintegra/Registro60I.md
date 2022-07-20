#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.Sintegra](EficazFramework.SPED.Schemas.Sintegra.md 'EficazFramework.SPED.Schemas.Sintegra')

## Registro60I Class

60 Item: Registro de mercadoria/produto constante em PDV / ECF

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | DataEmissao | `Nullable<DateTime>` |  |
| 03 | NumeroSerieFabEquip | `String` |  |
| 04 | ModeloDocFiscal | `String` |  |
| 05 | CCO | `Nullable<Int64>` |  |
| 06 | OrdemItem | `Nullable<Int16>` |  |
| 07 | CodigoProduto | `String` |  |
| 08 | Quantidade | `Nullable<Double>` |  |
| 09 | ValorLiquido | `Nullable<Double>` |  |
| 10 | BaseCalculo | `Nullable<Double>` |  |
| 11 | SituacaoTributariaAliquota | `String` |  |
| 12 | ICMS | `Nullable<Double>` |  |
| 13 | Brancos | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
