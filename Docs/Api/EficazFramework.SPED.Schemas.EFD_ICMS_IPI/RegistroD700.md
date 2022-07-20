#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## RegistroD700 Class

Nota Fiscal Fatura Eletrônica de Serviços de Comunicação – NFCom(Código 62)

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
| 08 | Numero | `Nullable<Int32>` |  |
| 09 | DataEmissao | `Nullable<DateTime>` |  |
| 10 | DataPrestacaoAquisicao | `Nullable<DateTime>` |  |
| 11 | ValorTotalDocumento | `Nullable<Double>` |  |
| 12 | ValorDesconto | `Nullable<Double>` |  |
| 13 | ValorServicos | `Nullable<Double>` |  |
| 14 | ValorServicosICMSNaoTributato | `Nullable<Double>` |  |
| 15 | ValorCobradoTerceiros | `Nullable<Double>` |  |
| 16 | ValorDespesasAcessorias | `Nullable<Double>` |  |
| 17 | ValorBaseCalculoICMS | `Nullable<Double>` |  |
| 18 | ValorICMS | `Nullable<Double>` |  |
| 19 | CodigoInformacaoComplementar0450 | `String` |  |
| 20 | ValorPIS | `Nullable<Double>` |  |
| 21 | ValorCofins | `Nullable<Double>` |  |
| 22 | ChaveDocEletronico | `String` |  |
| 23 | FinalidadeEmissao | `FinalidadeEmissaoDocE` |  |
| 24 | TipoFaturamento | `TipoFaturaDocE` |  |
| 25 | EspecieDocReferenciado | `String` |  |
| 26 | ChaveDocReferenciado | `String` |  |
| 27 | HashDocReferenciado | `String` |  |
| 28 | SerieDocReferenciado | `String` |  |
| 29 | NumeroDocReferenciado | `Nullable<Int32>` |  |
| 30 | CompetenciaDocReferenciado | `Nullable<DateTime>` | Mês e Ano do Documento Fiscal Referenciado |
| 31 | CodigoIbgeDestinatario | `String` |  |
| 32 | RegistrosD730 | `List<RegistroD730>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
