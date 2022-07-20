#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## ProcessoInutilizacaoNFe Class

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | Inutilizacao | `InutilizacaoNFe` |  |
| 03 | RetornoInutilizacao | `InutilizacaoRetorno` |  |
| 04 | versao | `String` |  |
| 05 | DocumentType | `XMLDocumentType` |  |
| 06 | DataEmissao | `Nullable<DateTime>` |  |
| 07 | Chave | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, ProcessoInutilizacaoNFe, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, ProcessoInutilizacaoNFe) | `Boolean` |  |
| Deserialize(string) | `ProcessoInutilizacaoNFe` |  |
| Deserialize(Stream) | `ProcessoInutilizacaoNFe` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, ProcessoInutilizacaoNFe, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, ProcessoInutilizacaoNFe) | `Boolean` |  |
| LoadFrom(Stream) | `ProcessoInutilizacaoNFe` |  |
| LoadFromAsync(Stream) | `Task<ProcessoInutilizacaoNFe>` |  |
| LoadFromAsync(Stream, bool) | `Task<ProcessoInutilizacaoNFe>` |  |
