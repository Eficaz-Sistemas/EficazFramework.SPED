#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.ECF](EficazFramework.SPED.Schemas.ECF.md 'EficazFramework.SPED.Schemas.ECF')

## Registro0010 Class

Parâmetros de Tributação

### Remarks
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| HashEcfAnterior | `String` |  |
| OpptanteRefis | `Boolean` |  |
| OptantePAES | `Boolean` |  |
| FormaTributacao | `FormaTributacao` |  |
| FormaApuracao | `FormaApuracao` |  |
| QualificacaoPJ | `QualificacaoPJ` |  |
| FormaTributacaoTrimestre | `String` | Valores válidos (um caractere para cada trimestre):            0 - ZERO - Não Informado - trimestre não compreendido no período de apuração            R - Real            P - Presumido            A - Arbitrado            E - Real Estimativa |
| FormaTributacaoMes | `String` | Valores válidos (um caractere para cada trimestre):            0 - ZERO - Fora do Período            E - Receita Bruta: Estimativa com base na Receita Bruta            B - Balanço ou Balancete: Estimativa com base no balanço ou balancete de suspensão / reduçao |
| ObrigatoriedadeECD | `String` | Valores Válidos:            C - Obrigada a entregar ECD ou entrega facultativa            L - Não obrigada a entregar ECD |
| TipoPJImuneIsenta | `TipoPJImuneOuIsenta` |  |
| FormaApuracaoImuneIsenta_IRPJ | `String` | Valores Válidos:            A - Anual            T - Trimestral            D - Desobrigada |
| FormaApuracaoImuneIsenta_CSLL | `String` | Valores Válidos:            A - Anual            T - Trimestral            D - Desobrigada |
| IndicadorRegimeReceita | `IndicadorReceita` |  |

| Methods | |
| :--- | :--- |
| [EscreveLinha()](EficazFramework.SPED.Schemas.ECF/Registro0010/EscreveLinha().md 'EficazFramework.SPED.Schemas.ECF.Registro0010.EscreveLinha()') | |
| [LeParametros(string[])](EficazFramework.SPED.Schemas.ECF/Registro0010/LeParametros(string[]).md 'EficazFramework.SPED.Schemas.ECF.Registro0010.LeParametros(string[])') | |
