#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_Contribuicoes](EficazFramework.SPED.Schemas.EFD_Contribuicoes.md 'EficazFramework.SPED.Schemas.EFD_Contribuicoes')

## RegistroD350 Class

Resumo Diário de Cupom Fiscal Emitido Por ECF

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | CodigoModeloDocFiscal | `String` |  |
| 03 | ModeloEquipamentoECF | `String` |  |
| 04 | NumeroSerieFabricacaoECF | `String` |  |
| 05 | DataMovimentoReducaoZ | `Nullable<DateTime>` |  |
| 06 | ContadorReinicioOperacao | `Nullable<Int32>` |  |
| 07 | ContadorReducaoZ | `Nullable<Int32>` |  |
| 08 | NumeroContadorOrdemOperacao | `Nullable<Int32>` |  |
| 09 | GrandeTotalFinal | `Nullable<Double>` |  |
| 10 | VrVendaBruta | `Nullable<Double>` |  |
| 11 | CSTPis | `String` |  |
| 12 | VrBcPis | `Nullable<Double>` |  |
| 13 | AliquotaPis | `Nullable<Double>` |  |
| 14 | BcPisQtde | `Nullable<Double>` |  |
| 15 | AliquotaPisQtde | `Nullable<Double>` |  |
| 16 | VrPis | `Nullable<Double>` |  |
| 17 | CSTCofins | `String` |  |
| 18 | VrBcCofins | `Nullable<Double>` |  |
| 19 | AliquotaCofins | `Nullable<Double>` |  |
| 20 | BcCofinsQtde | `Nullable<Double>` |  |
| 21 | AliquotaCofinsQtde | `Nullable<Double>` |  |
| 22 | VrCofins | `Nullable<Double>` |  |
| 23 | CodigoContaContabil | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
