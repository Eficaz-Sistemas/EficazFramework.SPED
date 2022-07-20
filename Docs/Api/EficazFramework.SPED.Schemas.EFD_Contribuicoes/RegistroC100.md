#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_Contribuicoes](EficazFramework.SPED.Schemas.EFD_Contribuicoes.md 'EficazFramework.SPED.Schemas.EFD_Contribuicoes')

## RegistroC100 Class

Documento - Nota Fiscal

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | IndicadorTipoOperacao | `OperacaoNFe` |  |
| 03 | IndicadorEmitenteDocFiscal | `IndicadorEmitente` |  |
| 04 | CodigoParticipante | `String` |  |
| 05 | CodigoModeloDocFiscal | `String` |  |
| 06 | CodigoSituacaoDocFiscal | `SituacaoDocumento` |  |
| 07 | SerieDocFiscal | `String` |  |
| 08 | NumeroDocFiscal | `String` |  |
| 09 | ChaveNFeDocFiscal | `String` |  |
| 10 | DataEmissaoDocFiscal | `Nullable<DateTime>` |  |
| 11 | DataEntradaSaida | `Nullable<DateTime>` |  |
| 12 | VrTotalDocFiscal | `Nullable<Double>` |  |
| 13 | IndicadorTipoPagamento | `IndicadorPagamento` |  |
| 14 | VrTotalDesconto | `Nullable<Double>` |  |
| 15 | VrAbatimentoNT | `Nullable<Double>` |  |
| 16 | VrTotalMercadorias | `Nullable<Double>` |  |
| 17 | IndicadorTipoFrete | `IndicadorFrete` |  |
| 18 | VrFrete | `Nullable<Double>` |  |
| 19 | VrSeguro | `Nullable<Double>` |  |
| 20 | VrOutrasDespesas | `Nullable<Double>` |  |
| 21 | VrBaseCalculoICMS | `Nullable<Double>` |  |
| 22 | VrICMS | `Nullable<Double>` |  |
| 23 | VrBaseCalculoICMSST | `Nullable<Double>` |  |
| 24 | VrICMSST | `Nullable<Double>` |  |
| 25 | VrIPI | `Nullable<Double>` |  |
| 26 | VrPIS | `Nullable<Double>` |  |
| 27 | VrCOFINS | `Nullable<Double>` |  |
| 28 | VrPISST | `Nullable<Double>` |  |
| 29 | VrCOFINSST | `Nullable<Double>` |  |
| 30 | RegistrosC110 | `List<RegistroC110>` |  |
| 31 | RegistrosC111 | `List<RegistroC111>` |  |
| 32 | RegistrosC120 | `List<RegistroC120>` |  |
| 33 | RegistrosC170 | `List<RegistroC170>` |  |
| 34 | RegistrosC175 | `List<RegistroC175>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
| DocumentoValido() | `Boolean` |  |
