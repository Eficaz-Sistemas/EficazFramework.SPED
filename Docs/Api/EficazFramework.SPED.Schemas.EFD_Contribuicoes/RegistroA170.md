#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_Contribuicoes](EficazFramework.SPED.Schemas.EFD_Contribuicoes.md 'EficazFramework.SPED.Schemas.EFD_Contribuicoes')

## RegistroA170 Class

Complemento do Documento - Itens do Documento

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | NumeroItem | `Nullable<Int32>` |  |
| 03 | CodigoItem | `String` |  |
| 04 | DescricaoComplementarItem | `String` |  |
| 05 | VrTotalItem | `Nullable<Double>` |  |
| 06 | VrTotalDesconto | `Nullable<Double>` |  |
| 07 | NaturezaBCCalculo | `NaturezaBaseCalculo` |  |
| 08 | IndicadorOrigemCredito | `IndicadorOrigemCredito` |  |
| 09 | CSTPis | `String` |  |
| 10 | VrBaseCalculoPis | `Nullable<Double>` |  |
| 11 | AliquotaPis | `Nullable<Double>` |  |
| 12 | VrPis | `Nullable<Double>` |  |
| 13 | CSTCofins | `String` |  |
| 14 | VrBaseCalculoCofins | `Nullable<Double>` |  |
| 15 | AliquotaCofins | `Nullable<Double>` |  |
| 16 | VrCofins | `Nullable<Double>` |  |
| 17 | CodigoContaContabil | `String` |  |
| 18 | CodigoCentroCusto | `String` |  |
| 19 | IndicadorTipoOperacao | `IndicadorTipoOperacao` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
