#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## RegistroC800 Class

Cupom Fiscal Eletrônico SAT CF-e (59)

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | EspecieDocumento | `String` |  |
| 03 | SituacaoDocumento | `SituacaoDocumento` |  |
| 04 | Numero | `Nullable<Int32>` |  |
| 05 | DataEmissao | `Nullable<DateTime>` |  |
| 06 | ValorTotalDocumento | `Nullable<Double>` |  |
| 07 | ValorPIS | `Nullable<Double>` |  |
| 08 | ValorCofins | `Nullable<Double>` |  |
| 09 | CNPJ_CPF | `String` |  |
| 10 | NumeroSerieSAT | `Nullable<Int32>` |  |
| 11 | ChaveCFe | `String` |  |
| 12 | ValorDesconto | `Nullable<Double>` |  |
| 13 | ValorTotalMercadorias | `Nullable<Double>` |  |
| 14 | ValorOutrasDespesas | `Nullable<Double>` |  |
| 15 | ValorICMS | `Nullable<Double>` |  |
| 16 | ValorPISST | `Nullable<Double>` |  |
| 17 | ValorCofinsST | `Nullable<Double>` |  |
| 18 | RegistrosC850 | `List<RegistroC850>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
| DocumentoValido() | `Boolean` |  |
