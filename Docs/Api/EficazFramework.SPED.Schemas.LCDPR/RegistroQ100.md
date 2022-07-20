#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.LCDPR](EficazFramework.SPED.Schemas.LCDPR.md 'EficazFramework.SPED.Schemas.LCDPR')

## RegistroQ100 Class

Demonstração da Atividade Rural

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | DataMov | `Nullable<DateTime>` |  |
| 03 | CodImovel | `Nullable<Int32>` |  |
| 04 | CodigoContaBanco | `String` |  |
| 05 | NumeroDoc | `String` |  |
| 06 | TipoDocumento | `TipoDocumento` |  |
| 07 | Historico | `String` |  |
| 08 | TerceiroID | `String` | CPF ou CNPJ do Terceiro. Caso TipoDocumento = FolhaPagto utilizar o CPF do próprio declarante. |
| 09 | TipoLancamento | `TipoLancamento` |  |
| 10 | ValorEntrada | `Nullable<Double>` |  |
| 11 | ValorSaida | `Nullable<Double>` |  |
| 12 | SaldoFinal | `Nullable<Double>` |  |
| 13 | SaldoFinal_Natureza | `String` | [N/P] |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
