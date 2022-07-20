#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.MFD_ECF](EficazFramework.SPED.Schemas.MFD_ECF.md 'EficazFramework.SPED.Schemas.MFD_ECF')

## RegistroE14 Class

Cupom Fiscal, Nota Fiscal de Venda a Consumidor e Bilhete de Passagem

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
| 08 | DataEmissao | `Nullable<DateTime>` |  |
| 09 | SubTotal | `Nullable<Double>` |  |
| 10 | DescontoSubTotal | `Nullable<Double>` |  |
| 11 | IndicadorDesconto | `IndicadorValor` |  |
| 12 | AcrescimoSubTotal | `Nullable<Double>` |  |
| 13 | IndicadorAcrescimo | `IndicadorValor` |  |
| 14 | ValorTotalLiquido | `Nullable<Double>` |  |
| 15 | Cancelamento | `Nullable<Boolean>` |  |
| 16 | CancelamentoAcrescimo | `Nullable<Double>` |  |
| 17 | OrdemDescontoAcrescimo | `Nullable<OrdemDescontoAcrescimo>` |  |
| 18 | NomeAdquirente | `String` |  |
| 19 | CNPJ_CPF | `String` |  |
| 20 | RegistrosE15 | `List<RegistroE15>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
