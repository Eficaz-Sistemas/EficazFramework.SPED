#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## RegistroD750 Class

Escrituração consolidada da Nota Fiscal Fatura Eletrônica de   
Serviços de Comunicação – NFCom (Código 62)

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | EspecieDocumento | `String` |  |
| 03 | Serie | `String` |  |
| 04 | DataEmissao | `Nullable<DateTime>` |  |
| 05 | Quantidade | `Nullable<Int32>` |  |
| 06 | IndicadorPrePago | `IndicadorPrePago` |  |
| 07 | ValorTotalDocumentos | `Nullable<Double>` |  |
| 08 | ValorServicos | `Nullable<Double>` |  |
| 09 | ValorServicosNT | `Nullable<Double>` |  |
| 10 | ValorCobradoTerceiros | `Nullable<Double>` |  |
| 11 | ValorDesconto | `Nullable<Double>` |  |
| 12 | ValorDespesasAcessorias | `Nullable<Double>` |  |
| 13 | ValorBaseCalculoICMS | `Nullable<Double>` |  |
| 14 | ValorICMS | `Nullable<Double>` |  |
| 15 | ValorPIS | `Nullable<Double>` |  |
| 16 | ValorCofins | `Nullable<Double>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
