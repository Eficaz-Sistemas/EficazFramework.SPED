#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## RegistroB020 Class

Abertura do Bloco B

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | IndicadorTipoOperacao | `IndicadorOperacao` |  |
| 03 | IndicadorEmitente | `IndicadorEmitente` |  |
| 04 | CodigoParticipante | `String` |  |
| 05 | EspecieDocumento | `String` |  |
| 06 | SituacaoDocumento | `SituacaoDocumento` |  |
| 07 | Serie | `String` |  |
| 08 | NumeroDoc | `Nullable<Int32>` |  |
| 09 | ChaveNFe | `String` |  |
| 10 | DataDoc | `Nullable<DateTime>` |  |
| 11 | CodigoMunicipio | `String` |  |
| 12 | ValorContabil | `Nullable<Double>` |  |
| 13 | ValorMaterialTerceiro | `Nullable<Double>` |  |
| 14 | ValorSubempreitada | `Nullable<Double>` |  |
| 15 | ValorISSIsentoNTrib | `Nullable<Double>` |  |
| 16 | ValorDedBC | `Nullable<Double>` |  |
| 17 | ValorBCISS | `Nullable<Double>` |  |
| 18 | ValorBCRetISS | `Nullable<Double>` |  |
| 19 | ValorISSRetTomador | `Nullable<Double>` |  |
| 20 | ValorISSDestacado | `Nullable<Double>` |  |
| 21 | CodigoObsLactoFiscal | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
| DocumentoValido() | `Boolean` |  |
