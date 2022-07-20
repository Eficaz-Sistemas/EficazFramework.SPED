#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## RegistroG130 Class

Identificação do Documento Fiscal

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | IndicadorEmissao | `IndicadorEmitente` |  |
| 03 | CodigoParticipante | `String` |  |
| 04 | Modelo | `String` |  |
| 05 | Serie | `String` |  |
| 06 | Numero | `Nullable<Int32>` |  |
| 07 | Chave_NFeCTe | `String` |  |
| 08 | DataEmissao | `Nullable<DateTime>` |  |
| 09 | NumeroDocArrecadacao | `String` |  |
| 10 | RegistrosG140 | `List<RegistroG140>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
