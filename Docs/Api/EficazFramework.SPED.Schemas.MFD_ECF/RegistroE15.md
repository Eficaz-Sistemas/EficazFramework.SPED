#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.MFD_ECF](EficazFramework.SPED.Schemas.MFD_ECF.md 'EficazFramework.SPED.Schemas.MFD_ECF')

## RegistroE15 Class

Detalhe do Cupom Fiscal, da Nota Fiscal de Venda a Consumidor ou do Bilhete de Passagem.

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | NumeroFabricacaoECF | `String` |  |
| 03 | MFAdicional | `String` |  |
| 04 | Modelo | `String` |  |
| 05 | NumeroUsuario | `Nullable<Int32>` |  |
| 06 | CCF_CVC_CBP | `Nullable<Int32>` |  |
| 07 | COO | `Nullable<Int32>` |  |
| 08 | NumeroItem | `Nullable<Int32>` |  |
| 09 | CodigoProduto | `String` |  |
| 10 | Descricao | `String` |  |
| 11 | Quantidade | `Nullable<Double>` |  |
| 12 | UnidadeMedida | `String` |  |
| 13 | ValorUnitario | `Nullable<Double>` |  |
| 14 | Desconto | `Nullable<Double>` |  |
| 15 | Acrescimo | `Nullable<Double>` |  |
| 16 | TotalLiquido | `Nullable<Double>` |  |
| 17 | TotalizadorParcial | `String` |  |
| 18 | Cancelamento | `Nullable<Boolean>` |  |
| 19 | QuantidadeCancelada | `Nullable<Double>` |  |
| 20 | ValorCancelado | `Nullable<Double>` |  |
| 21 | CancelamentoAcrescimo | `Nullable<Double>` |  |
| 22 | IAT_TotalLiquido | `IndicadorArredTruncam` |  |
| 23 | CasasDecimaisQtdade | `Nullable<Int32>` |  |
| 24 | CasasDecimaisUnitario | `Nullable<Int32>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
