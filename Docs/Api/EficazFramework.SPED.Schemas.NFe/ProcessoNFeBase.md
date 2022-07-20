#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## ProcessoNFeBase Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | Processo | `ProcessoNFe` |  |
| 03 | Schema | `String` |  |
| 04 | DocumentType | `XMLDocumentType` |  |
| 05 | DataEmissao | `Nullable<DateTime>` |  |
| 06 | Chave | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| OnPropertyChanged(string) | `Void` |  |
| ToString() | `String` |  |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, ProcessoNFeBase, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, ProcessoNFeBase) | `Boolean` |  |
| Deserialize(string) | `ProcessoNFeBase` |  |
| Deserialize(Stream) | `ProcessoNFeBase` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, ProcessoNFeBase, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, ProcessoNFeBase) | `Boolean` |  |
| LoadFrom(Stream, bool) | `ProcessoNFeBase` |  |
| LoadFromAsync(Stream, bool) | `Task<ProcessoNFeBase>` |  |
