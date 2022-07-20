#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.LCDPR](EficazFramework.SPED.Schemas.LCDPR.md 'EficazFramework.SPED.Schemas.LCDPR')

## Registro0000 Class

Abertura do Arquivo Digital e Identificação do Empresário ou da Sociedade

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | CPF | `String` |  |
| 03 | Nome | `String` |  |
| 04 | IndicadorSitInicioPeriodo | `SituacaoInicioPeriodo` |  |
| 05 | SituacaoEspecial | `SituacaoEspecial` |  |
| 06 | DataSituacaoEspecial | `Nullable<DateTime>` |  |
| 07 | DataInicial | `Nullable<DateTime>` |  |
| 08 | DataFinal | `Nullable<DateTime>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
