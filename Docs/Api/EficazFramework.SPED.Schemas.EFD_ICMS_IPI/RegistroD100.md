#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## RegistroD100 Class

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
| 10 | ChaveNFe | `String` |  |
| 11 | DataEmissao | `Nullable<DateTime>` |  |
| 12 | DataPrestacaoAquisicao | `Nullable<DateTime>` |  |
| 13 | TipoCTe | `TipoCTe` |  |
| 14 | ChaveCTeReferenciado | `String` |  |
| 15 | ValorTotalDocumento | `Nullable<Double>` |  |
| 16 | ValorDesconto | `Nullable<Double>` |  |
| 17 | TipoFrete | `IndicadorFrete` |  |
| 18 | ValorPrestacaoServico | `Nullable<Double>` |  |
| 19 | ValorBaseCalculoICMS | `Nullable<Double>` |  |
| 20 | ValorICMS | `Nullable<Double>` |  |
| 21 | ValorNaoTributado | `Nullable<Double>` |  |
| 22 | CodigoComplementar0450 | `String` |  |
| 23 | CodigoContaContabil | `String` |  |
| 24 | IBGE_Municipio_Origem | `String` |  |
| 25 | IBGE_Municipio_destino | `String` |  |
| 26 | RegistroD101 | `RegistroD101` |  |
| 27 | RegistrosD110 | `List<RegistroD110>` |  |
| 28 | RegistrosD190 | `List<RegistroD190>` |  |
| 29 | RegistrosD195 | `List<RegistroD195>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
| DocumentoValido() | `Boolean` |  |
