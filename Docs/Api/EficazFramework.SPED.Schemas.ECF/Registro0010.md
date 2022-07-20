#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.ECF](EficazFramework.SPED.Schemas.ECF.md 'EficazFramework.SPED.Schemas.ECF')

## Registro0010 Class

Parâmetros de Tributação

### Remarks
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | HashEcfAnterior |  |
| 03 | OpptanteRefis |  |
| 04 | OptantePAES |  |
| 05 | FormaTributacao |  |
| 06 | FormaApuracao |  |
| 07 | QualificacaoPJ |  |
| 08 | FormaTributacaoTrimestre | Valores válidos (um caractere para cada trimestre):            0 - ZERO - Não Informado - trimestre não compreendido no período de apuração            R - Real            P - Presumido            A - Arbitrado            E - Real Estimativa |
| 09 | FormaTributacaoMes | Valores válidos (um caractere para cada trimestre):            0 - ZERO - Fora do Período            E - Receita Bruta: Estimativa com base na Receita Bruta            B - Balanço ou Balancete: Estimativa com base no balanço ou balancete de suspensão / reduçao |
| 10 | ObrigatoriedadeECD | Valores Válidos:            C - Obrigada a entregar ECD ou entrega facultativa            L - Não obrigada a entregar ECD |
| 11 | TipoPJImuneIsenta |  |
| 12 | FormaApuracaoImuneIsenta_IRPJ | Valores Válidos:            A - Anual            T - Trimestral            D - Desobrigada |
| 13 | FormaApuracaoImuneIsenta_CSLL | Valores Válidos:            A - Anual            T - Trimestral            D - Desobrigada |
| 14 | IndicadorRegimeReceita |  |
### Methods

| Name | |
| :--- | :--- |
| EscreveLinha() |  |
| LeParametros(string[]) |  |
