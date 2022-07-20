#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_Contribuicoes](EficazFramework.SPED.Schemas.EFD_Contribuicoes.md 'EficazFramework.SPED.Schemas.EFD_Contribuicoes')

## RegistroF600 Class

Contribuição Retida na fonte

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | IndicadorNatRetFonte | `IndicadorNatRetFonte` |  |
| 03 | DataRetencao | `Nullable<DateTime>` |  |
| 04 | VrBcRetencao | `Nullable<Double>` |  |
| 05 | VrTotalRetidoFonte | `Nullable<Double>` |  |
| 06 | CodigoReceita | `String` |  |
| 07 | IndicadorNatRec | `IndicadorNaturezaReceita` |  |
| 08 | CNPJFontePagadora | `String` |  |
| 09 | VrRetidoFontePis | `Nullable<Double>` |  |
| 10 | VrRetidoFonteCofins | `Nullable<Double>` |  |
| 11 | IndicadorCondDeclarante | `IndicadorCondicaoPJDeclarante` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
