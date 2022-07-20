#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## RegistroC100 Class

Documentos Fiscais (01, 1B, 04, 55 e 65)

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
| 09 | ChaveNFe | `String` |  |
| 10 | DataEmissao | `Nullable<DateTime>` |  |
| 11 | DataEntradaSaida | `Nullable<DateTime>` |  |
| 12 | ValorTotalDocumento | `Nullable<Double>` |  |
| 13 | Pagamento | `IndicadorPagamento` |  |
| 14 | ValorDesconto | `Nullable<Double>` |  |
| 15 | ValorAbatimento | `Nullable<Double>` |  |
| 16 | ValorTotalMercadorias | `Nullable<Double>` |  |
| 17 | TipoFrete | `IndicadorFrete` |  |
| 18 | ValorFrete | `Nullable<Double>` |  |
| 19 | ValorSeguro | `Nullable<Double>` |  |
| 20 | ValorOutrasDespesas | `Nullable<Double>` |  |
| 21 | ValorBaseCalculoICMS | `Nullable<Double>` |  |
| 22 | ValorICMS | `Nullable<Double>` |  |
| 23 | ValorBaseCalculoICMSST | `Nullable<Double>` |  |
| 24 | ValorICMSST | `Nullable<Double>` |  |
| 25 | ValorIPI | `Nullable<Double>` |  |
| 26 | ValorPIS | `Nullable<Double>` |  |
| 27 | ValorCofins | `Nullable<Double>` |  |
| 28 | ValorPISST | `Nullable<Double>` |  |
| 29 | ValorCofinsST | `Nullable<Double>` |  |
| 30 | RegistroC101 | `RegistroC101` |  |
| 31 | RegistrosC113 | `List<RegistroC113>` |  |
| 32 | RegistrosC114 | `List<RegistroC114>` |  |
| 33 | RegistrosC120 | `List<RegistroC120>` |  |
| 34 | RegistroC130 | `RegistroC130` |  |
| 35 | RegistroC140 | `RegistroC140` |  |
| 36 | RegistrosC170 | `List<RegistroC170>` |  |
| 37 | RegistrosC190 | `List<RegistroC190>` |  |
| 38 | RegistrosC195 | `List<RegistroC195>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
| DocumentoValido() | `Boolean` |  |
