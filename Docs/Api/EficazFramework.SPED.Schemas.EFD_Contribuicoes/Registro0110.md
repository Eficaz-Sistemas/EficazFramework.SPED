#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_Contribuicoes](EficazFramework.SPED.Schemas.EFD_Contribuicoes.md 'EficazFramework.SPED.Schemas.EFD_Contribuicoes')

## Registro0110 Class

Regimes de Apuração da Contribuição Social e de Apropriação de Crédito

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | CodigoIndicador | `CodigoIncidenciaTributaria` |  |
| 03 | MetodoApropriacao | `Nullable<MetodoApropriacaoEnum>` |  |
| 04 | TipoContribuicao | `Nullable<TipoContribuicaoEnum>` |  |
| 05 | CriterioEscrituracaoApuracao | `Nullable<Int32>` |  |
| 06 | Registro0111 | `Registro0111` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
