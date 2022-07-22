#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.LCDPR](EficazFramework.SPED.Schemas.LCDPR.md 'EficazFramework.SPED.Schemas.LCDPR')

## RegistroQ100 Class

Demonstração da Atividade Rural

### Remarks
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| DataMov | `Nullable<DateTime>` |  |
| CodImovel | `Nullable<Int32>` |  |
| CodigoContaBanco | `String` |  |
| NumeroDoc | `String` |  |
| TipoDocumento | `TipoDocumento` |  |
| Historico | `String` |  |
| TerceiroID | `String` | CPF ou CNPJ do Terceiro. Caso TipoDocumento = FolhaPagto utilizar o CPF do próprio declarante. |
| TipoLancamento | `TipoLancamento` |  |
| ValorEntrada | `Nullable<Double>` |  |
| ValorSaida | `Nullable<Double>` |  |
| SaldoFinal | `Nullable<Double>` |  |
| SaldoFinal_Natureza | `String` | [N/P] |

| Methods | |
| :--- | :--- |
| [EscreveLinha()](EficazFramework.SPED.Schemas.LCDPR/RegistroQ100/EscreveLinha().md 'EficazFramework.SPED.Schemas.LCDPR.RegistroQ100.EscreveLinha()') | |
| [LeParametros(string[])](EficazFramework.SPED.Schemas.LCDPR/RegistroQ100/LeParametros(string[]).md 'EficazFramework.SPED.Schemas.LCDPR.RegistroQ100.LeParametros(string[])') | |
