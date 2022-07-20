#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## RegistroC500 Class

Energia Elétrica / Gás / Água

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | Operacao | `IndicadorOperacao` |  |
| 03 | Emissao | `IndicadorEmitente` |  |
| 04 | CodigoParticipante | `String` |  |
| 05 | EspecieDocumento | `String` |  |
| 06 | SituacaoDocumento | `SituacaoDocumento` |  |
| 07 | Serie | `String` |  |
| 08 | SubSerie | `String` |  |
| 09 | CodigoConsumo | `CodigoConsumoEnEletricaOuGas` |  |
| 10 | CodigoConsumoAgua | `String` |  |
| 11 | Numero | `Nullable<Int32>` |  |
| 12 | DataEmissao | `Nullable<DateTime>` |  |
| 13 | DataEntradaSaida | `Nullable<DateTime>` |  |
| 14 | ValorTotalDocumento | `Nullable<Double>` |  |
| 15 | ValorDesconto | `Nullable<Double>` |  |
| 16 | ValorFornecidoOuConsumido | `Nullable<Double>` |  |
| 17 | ValorServicosICMSNaoTributato | `Nullable<Double>` |  |
| 18 | ValorCobradoTerceiros | `Nullable<Double>` |  |
| 19 | ValorDespesasAcessorias | `Nullable<Double>` |  |
| 20 | ValorBaseCalculoICMS | `Nullable<Double>` |  |
| 21 | ValorICMS | `Nullable<Double>` |  |
| 22 | ValorBaseCalculoICMSST | `Nullable<Double>` |  |
| 23 | ValorICMSST | `Nullable<Double>` |  |
| 24 | CodigoInformacaoComplementar0450 | `String` |  |
| 25 | ValorPIS | `Nullable<Double>` |  |
| 26 | ValorCofins | `Nullable<Double>` |  |
| 27 | TipoLigacao | `TipoLigacaoEnEletrica` |  |
| 28 | CodigoGrupoTensao | `GrupoTensao` |  |
| 29 | ChaveDocE | `String` |  |
| 30 | FinDocE | `FinalidadeEmissaoDocE` |  |
| 31 | ChaveDocE_Referenciado | `String` |  |
| 32 | DestinatarioIndicador | `Nullable<IndicadorDestinatario>` |  |
| 33 | DestinatarioCodMunicipio | `String` |  |
| 34 | CodigoContaAnaliticaCtb | `String` |  |
| 35 | EspecieDocumentoReferenciado | `String` |  |
| 36 | HashDocumentoReferenciado | `String` |  |
| 37 | SerieDocumentoReferenciado | `String` |  |
| 38 | NumeroDocumentoReferenciado | `Nullable<Int32>` |  |
| 39 | CompetenciaDocumentoReferenciado | `Nullable<DateTime>` |  |
| 40 | EnergiaInjetada | `Nullable<Double>` |  |
| 41 | OutrasDeducoes | `Nullable<Double>` |  |
| 42 | RegistrosC590 | `List<RegistroC590>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
