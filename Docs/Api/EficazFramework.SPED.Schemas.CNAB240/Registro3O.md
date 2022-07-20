#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.CNAB240](EficazFramework.SPED.Schemas.CNAB240.md 'EficazFramework.SPED.Schemas.CNAB240')

## Registro3O Class

Registro Detalhe
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | CodigoBanco | `String` |  |
| 03 | LoteDeServico | `String` |  |
| 04 | NumeroSequencial | `Nullable<Int32>` |  |
| 05 | TipoMovimento | `String` |  |
| 06 | TipoTributo | `String` |  |
| 07 | CodigoBarras | `String` |  |
| 08 | ContribuinteNome | `String` |  |
| 09 | DataVencimento | `Nullable<DateTime>` |  |
| 10 | Moeda | `String` |  |
| 11 | QuantidadeMoeda | `Nullable<Double>` |  |
| 12 | ValorPrincipal | `Nullable<Double>` |  |
| 13 | DataPagamento | `Nullable<DateTime>` |  |
| 14 | ValorPago | `Nullable<Double>` |  |
| 15 | NotaFiscal | `String` |  |
| 16 | SeuNumero | `String` |  |
| 17 | NossoNumero | `String` |  |
| 18 | Ocorrencias | `String` |  |
| 19 | Detalhamento_Z | `Registro3Z` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
| CodigoDeBarrasSemDv() | `String` |  |
