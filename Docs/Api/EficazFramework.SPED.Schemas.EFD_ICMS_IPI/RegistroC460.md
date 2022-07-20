#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## RegistroC460 Class

Documento Fiscal emitido por ECF (Código 02, 2D e 60)

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | CodigoModelo | `String` |  |
| 03 | Situacao | `SituacaoDocumento` |  |
| 04 | Numero | `Nullable<Int64>` |  |
| 05 | Data | `Nullable<DateTime>` |  |
| 06 | ValorTotal | `Nullable<Double>` |  |
| 07 | ValorPIS | `Nullable<Double>` |  |
| 08 | ValorCofins | `Nullable<Double>` |  |
| 09 | CNPJ_CPF | `String` |  |
| 10 | NomeAdquirente | `String` |  |
| 11 | RegistrosC470 | `List<RegistroC470>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
