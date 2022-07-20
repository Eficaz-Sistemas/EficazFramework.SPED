#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_Contribuicoes](EficazFramework.SPED.Schemas.EFD_Contribuicoes.md 'EficazFramework.SPED.Schemas.EFD_Contribuicoes')

## RegistroC380 Class

Nota Fiscal de Venda a Consumidor (Código 02) - Consolidação de Documentos Emitidos

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | CodigoModeloDocumento | `String` |  |
| 03 | DataEmissaoInicialDocs | `Nullable<DateTime>` |  |
| 04 | DataEmissaoFinalDocs | `Nullable<DateTime>` |  |
| 05 | NumeroDocFiscalInicial | `String` |  |
| 06 | NumeroDocFiscalFinal | `String` |  |
| 07 | VrTotalDocsEmitidos | `Nullable<Double>` |  |
| 08 | VrTotalDocsCancelados | `Nullable<Double>` |  |
| 09 | RegistrosC381 | `List<RegistroC381>` |  |
| 10 | RegistrosC385 | `List<RegistroC385>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
