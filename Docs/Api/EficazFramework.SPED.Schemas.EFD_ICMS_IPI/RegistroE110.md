#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## RegistroE110 Class

Apuração do ICMS
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | Debitos | `Nullable<Double>` |  |
| 03 | DebitosAjustesDocFiscal | `Nullable<Double>` |  |
| 04 | DebitosAjustes | `Nullable<Double>` |  |
| 05 | EstornoCreditos | `Nullable<Double>` |  |
| 06 | Creditos | `Nullable<Double>` |  |
| 07 | CreditosAjustesDocFiscal | `Nullable<Double>` |  |
| 08 | CreditosAjustes | `Nullable<Double>` |  |
| 09 | EstornoDebitos | `Nullable<Double>` |  |
| 10 | SaldoCredorAnterior | `Nullable<Double>` |  |
| 11 | SaldoDevedorApurado | `Nullable<Double>` |  |
| 12 | DeducoesTotais | `Nullable<Double>` |  |
| 13 | ICMS_Recolher | `Nullable<Double>` |  |
| 14 | SaldoCredorATransportar | `Nullable<Double>` |  |
| 15 | DebitosExtraApuracao | `Nullable<Double>` |  |
| 16 | RegistrosE111 | `List<RegistroE111>` |  |
| 17 | RegistrosE115 | `List<RegistroE115>` |  |
| 18 | RegistrosE116 | `List<RegistroE116>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
