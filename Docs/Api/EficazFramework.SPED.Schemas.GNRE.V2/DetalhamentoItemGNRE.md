#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.GNRE.V2](EficazFramework.SPED.Schemas.GNRE.V2.md 'EficazFramework.SPED.Schemas.GNRE.V2')

## DetalhamentoItemGNRE Class

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | receita | `String` |  |
| 03 | detalhamentoReceita | `String` |  |
| 04 | documentoOrigem | `TipoDocumentoOrigem` |  |
| 05 | produto | `String` |  |
| 06 | referencia | `Referencia` |  |
| 07 | dataVencimentoDate | `Nullable<DateTime>` |  |
| 08 | dataVencimento | `String` |  |
| 09 | valor | `ObservableCollection<ItemValor>` |  |
| 10 | convenio | `String` |  |
| 11 | contribuinteDestinatario | `Destinatario` |  |
| 12 | camposExtras | `ObservableCollection<CampoExtra>` |  |
| 13 | ForcarCamposExtras | `Boolean` |  |
| 14 | numeroControle | `String` |  |
| 15 | numeroControleFecp | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| ShouldSerializecamposExtras() | `Boolean` |  |
