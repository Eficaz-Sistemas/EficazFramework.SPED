#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## RegistroD500 Class

Plano de contas contábeis

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
| 09 | Numero | `Nullable<Int32>` |  |
| 10 | DataEmissao | `Nullable<DateTime>` |  |
| 11 | DataPrestacaoAquisicao | `Nullable<DateTime>` |  |
| 12 | ValorTotalDocumento | `Nullable<Double>` |  |
| 13 | ValorDesconto | `Nullable<Double>` |  |
| 14 | ValorServicos | `Nullable<Double>` |  |
| 15 | ValorServicosICMSNaoTributato | `Nullable<Double>` |  |
| 16 | ValorCobradoTerceiros | `Nullable<Double>` |  |
| 17 | ValorDespesasAcessorias | `Nullable<Double>` |  |
| 18 | ValorBaseCalculoICMS | `Nullable<Double>` |  |
| 19 | ValorICMS | `Nullable<Double>` |  |
| 20 | CodigoInformacaoComplementar0450 | `String` |  |
| 21 | ValorPIS | `Nullable<Double>` |  |
| 22 | ValorCofins | `Nullable<Double>` |  |
| 23 | CodigoContaContabil | `String` |  |
| 24 | TipoAssinante | `TipoAssinanteComunincacao` |  |
| 25 | RegistrosD590 | `List<RegistroD590>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
