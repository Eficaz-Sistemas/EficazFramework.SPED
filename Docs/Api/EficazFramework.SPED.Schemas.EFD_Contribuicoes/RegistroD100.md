#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_Contribuicoes](EficazFramework.SPED.Schemas.EFD_Contribuicoes.md 'EficazFramework.SPED.Schemas.EFD_Contribuicoes')

## RegistroD100 Class

Aquisição de Serviços de Transporte

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | IndicadorOperacao | `IndicadorTipoOperacaoBlocoD` |  |
| 03 | IndicadorEmitenteDocFiscal | `IndicadorEmitente` |  |
| 04 | CodigoParticipante | `String` |  |
| 05 | CodigoModeloDocFiscal | `String` |  |
| 06 | CodigoSituacaoDocFiscal | `String` |  |
| 07 | SerieDocFiscal | `String` |  |
| 08 | SubSerieDocFiscal | `String` |  |
| 09 | NumeroDocFiscal | `Nullable<Int64>` |  |
| 10 | ChaveCte | `String` |  |
| 11 | DataEmissaoDocFiscal | `Nullable<DateTime>` |  |
| 12 | DataAquisicaoPrestServico | `Nullable<DateTime>` |  |
| 13 | TipoCte | `String` |  |
| 14 | ChaveCteReferencia | `String` |  |
| 15 | VrTotalDocFiscal | `Nullable<Double>` |  |
| 16 | VrTotalDesconto | `Nullable<Double>` |  |
| 17 | IndicadorTipoFrete | `IndicadorFrete` |  |
| 18 | VrTotalPrestacaoServ | `Nullable<Double>` |  |
| 19 | VrBcICMS | `Nullable<Double>` |  |
| 20 | VrICMS | `Nullable<Double>` |  |
| 21 | VrNãoTributadoICMS | `Nullable<Double>` |  |
| 22 | CodigoInfoComplementarDocFiscal | `String` |  |
| 23 | CodigoContaContabil | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
