#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.ECF](EficazFramework.SPED.Schemas.ECF.md 'EficazFramework.SPED.Schemas.ECF')

## Registro0010 Class

Parâmetros de Tributação

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | HashEcfAnterior | `String` |  |
| 03 | OpptanteRefis | `Boolean` |  |
| 04 | OptantePAES | `Boolean` |  |
| 05 | FormaTributacao | `FormaTributacao` |  |
| 06 | FormaApuracao | `FormaApuracao` |  |
| 07 | QualificacaoPJ | `QualificacaoPJ` |  |
| 08 | FormaTributacaoTrimestre | `String` | Valores válidos (um caractere para cada trimestre):            0 - ZERO - Não Informado - trimestre não compreendido no período de apuração            R - Real            P - Presumido            A - Arbitrado            E - Real Estimativa |
| 09 | FormaTributacaoMes | `String` | Valores válidos (um caractere para cada trimestre):            0 - ZERO - Fora do Período            E - Receita Bruta: Estimativa com base na Receita Bruta            B - Balanço ou Balancete: Estimativa com base no balanço ou balancete de suspensão / reduçao |
| 10 | ObrigatoriedadeECD | `String` | Valores Válidos:            C - Obrigada a entregar ECD ou entrega facultativa            L - Não obrigada a entregar ECD |
| 11 | TipoPJImuneIsenta | `TipoPJImuneOuIsenta` |  |
| 12 | FormaApuracaoImuneIsenta_IRPJ | `String` | Valores Válidos:            A - Anual            T - Trimestral            D - Desobrigada |
| 13 | FormaApuracaoImuneIsenta_CSLL | `String` | Valores Válidos:            A - Anual            T - Trimestral            D - Desobrigada |
| 14 | IndicadorRegimeReceita | `IndicadorReceita` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
