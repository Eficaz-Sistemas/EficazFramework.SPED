#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_Contribuicoes](EficazFramework.SPED.Schemas.EFD_Contribuicoes.md 'EficazFramework.SPED.Schemas.EFD_Contribuicoes')

## RegistroA100 Class

Documento Nota Fiscal de Serviço

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | IndicadorTipoOperacao | `IndicadorTipoOperacao` |  |
| 03 | IndicadorEmitenteDocFiscal | `IndicadorEmitente` |  |
| 04 | CodigoParticipante | `String` |  |
| 05 | CodigoSituacaoDocFiscal | `SituacaoDocumento` |  |
| 06 | SerieDocFiscal | `String` |  |
| 07 | SubserieDocFiscal | `String` |  |
| 08 | NumeroDocFiscal | `String` |  |
| 09 | ChaveCodigoVerificacaoNFSe | `String` |  |
| 10 | Datadocfiscal | `Nullable<DateTime>` |  |
| 11 | DataExecucaoConclusao | `Nullable<DateTime>` |  |
| 12 | VrTotalDoc | `Nullable<Double>` |  |
| 13 | TipoPagamento | `FormaDePagamento` |  |
| 14 | VrTotalDesconto | `Nullable<Double>` |  |
| 15 | VrBaseCalculoPis | `Nullable<Double>` |  |
| 16 | VrPis | `Nullable<Double>` |  |
| 17 | VrBaseCalculoCofins | `Nullable<Double>` |  |
| 18 | VrCofins | `Nullable<Double>` |  |
| 19 | VrPisRetidoFonte | `Nullable<Double>` |  |
| 20 | VrCofinsRetidoFonte | `Nullable<Double>` |  |
| 21 | VrISS | `Nullable<Double>` |  |
| 22 | RegistrosA110 | `List<RegistroA110>` |  |
| 23 | RegistrosA111 | `List<RegistroA111>` |  |
| 24 | RegistrosA120 | `List<RegistroA120>` |  |
| 25 | RegistrosA170 | `List<RegistroA170>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
