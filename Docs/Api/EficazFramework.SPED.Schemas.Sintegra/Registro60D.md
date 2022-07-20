#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.Sintegra](EficazFramework.SPED.Schemas.Sintegra.md 'EficazFramework.SPED.Schemas.Sintegra')

## Registro60D Class

60 Diário: Registro de mercadoria/produto constante em PDV / ECF totalizado por dia.

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | DataEmissao | `Nullable<DateTime>` |  |
| 03 | NumeroSerieFabEquip | `String` |  |
| 04 | CodigoProduto | `String` |  |
| 05 | Quantidade | `Nullable<Decimal>` |  |
| 06 | ValorLiquido | `Nullable<Double>` |  |
| 07 | BaseCalculo | `Nullable<Double>` |  |
| 08 | SituacaoTributariaAliquota | `String` |  |
| 09 | ICMS | `Nullable<Double>` |  |
| 10 | Brancos | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
