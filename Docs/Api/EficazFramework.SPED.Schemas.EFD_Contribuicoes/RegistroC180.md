#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_Contribuicoes](EficazFramework.SPED.Schemas.EFD_Contribuicoes.md 'EficazFramework.SPED.Schemas.EFD_Contribuicoes')

## RegistroC180 Class

Consolidação de Notas Fiscais Eletrônicas Emitidas Pela Pessoa Jurídica - Códigos 55 e 65 - Operações de Vendas

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | CodigoModeloDocumento | `String` |  |
| 03 | DataEmissaoInicialDocs | `Nullable<DateTime>` |  |
| 04 | DataEmissaoFinalDocs | `Nullable<DateTime>` |  |
| 05 | CodigoItem | `String` |  |
| 06 | CodigoNCM | `String` |  |
| 07 | CodigoEXTipi | `String` |  |
| 08 | VrTotalItem | `Nullable<Double>` |  |
| 09 | RegistrosC181 | `List<RegistroC181>` |  |
| 10 | RegistrosC185 | `List<RegistroC185>` |  |
| 11 | RegistrosC188 | `List<RegistroC188>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
