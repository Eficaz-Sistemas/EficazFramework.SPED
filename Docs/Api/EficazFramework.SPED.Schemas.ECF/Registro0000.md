#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.ECF](EficazFramework.SPED.Schemas.ECF.md 'EficazFramework.SPED.Schemas.ECF')

## Registro0000 Class

Abertura do Arquivo Digital e Identificação do Empresário ou da Sociedade

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | CNPJ | `String` |  |
| 03 | NomeEmpresarial | `String` |  |
| 04 | IndicadorSitInicioPeriodo | `SituacaoInicioPeriodo` |  |
| 05 | SituacaoEspecial | `SituacaoEspecial` |  |
| 06 | PatrimonioRemanescente | `Nullable<Double>` |  |
| 07 | DataSituacaoEspecial | `Nullable<DateTime>` |  |
| 08 | DataInicial | `Nullable<DateTime>` |  |
| 09 | DataFinal | `Nullable<DateTime>` |  |
| 10 | Retificadora | `Boolean` | Valores válidos:            S - ECF Retificadora            N - ECF Original            F - ECF Original com mudança de forma de tributação |
| 11 | ReciboRetificacao | `String` |  |
| 12 | TipoECF | `TipoECF` |  |
| 13 | CodigoSCP | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
