#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## RegistroE210 Class

Apuração do ICMS ST
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | IndicadorMovimentoST | `IndicadorMovimentoST_Difal` |  |
| 03 | SaldoCredorAnterior | `Nullable<Double>` |  |
| 04 | ValorSTDevolucoes | `Nullable<Double>` |  |
| 05 | ValorSTRessarcimentos | `Nullable<Double>` |  |
| 06 | CreditosAjustes | `Nullable<Double>` |  |
| 07 | CreditosAjustesDocFiscal | `Nullable<Double>` |  |
| 08 | RetencaoST | `Nullable<Double>` |  |
| 09 | DebitosAjustes | `Nullable<Double>` |  |
| 10 | DebitosAjustesDocFiscal | `Nullable<Double>` |  |
| 11 | SaldoDevedorApurado | `Nullable<Double>` |  |
| 12 | DeducoesTotais | `Nullable<Double>` |  |
| 13 | ICMSST_Recolher | `Nullable<Double>` |  |
| 14 | SaldoCredorATransportar | `Nullable<Double>` |  |
| 15 | DebitosExtraApuracao | `Nullable<Double>` |  |
| 16 | RegistrosE220 | `List<RegistroE220>` |  |
| 17 | RegistrosE250 | `List<RegistroE250>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
