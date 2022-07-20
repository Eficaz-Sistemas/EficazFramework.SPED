#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## ProcessoNFe Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | NFe | `NFe` |  |
| 03 | ProtocoloAutorizacao | `ProtocoloRecebimento` |  |
| 04 | Versao | `String` |  |
| 05 | DocumentType | `XMLDocumentType` |  |
| 06 | DataEmissao | `Nullable<DateTime>` |  |
| 07 | Chave | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| RefreshSerializer() | `Void` |  |
| OnPropertyChanged(string) | `Void` |  |
| ToString() | `String` |  |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, ProcessoNFe, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, ProcessoNFe) | `Boolean` |  |
| Deserialize(string) | `ProcessoNFe` |  |
| Deserialize(Stream) | `ProcessoNFe` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, ProcessoNFe, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, ProcessoNFe) | `Boolean` |  |
| LoadFrom(Stream, bool) | `ProcessoNFe` |  |
| LoadFromAsync(Stream, bool) | `Task<ProcessoNFe>` |  |
