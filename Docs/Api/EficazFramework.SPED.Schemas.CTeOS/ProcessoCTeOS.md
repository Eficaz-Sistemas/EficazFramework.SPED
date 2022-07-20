#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.CTeOS](EficazFramework.SPED.Schemas.CTeOS.md 'EficazFramework.SPED.Schemas.CTeOS')

## ProcessoCTeOS Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | CTeOS | `CTeOS` |  |
| 03 | ProtocoloAutorizacao | `ProtocoloAutorizacao` |  |
| 04 | Versao | `String` |  |
| 05 | DocumentType | `XMLDocumentType` |  |
| 06 | DataEmissao | `Nullable<DateTime>` |  |
| 07 | Chave | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| OnPropertyChanged(string) | `Void` |  |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, ProcessoCTeOS, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, ProcessoCTeOS) | `Boolean` |  |
| Deserialize(string) | `ProcessoCTeOS` |  |
| Deserialize(Stream) | `ProcessoCTeOS` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, ProcessoCTeOS, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, ProcessoCTeOS) | `Boolean` |  |
| LoadFrom(Stream, bool) | `ProcessoCTeOS` |  |
| LoadFromAsync(Stream) | `Task<ProcessoCTeOS>` |  |
| LoadFromAsync(Stream, bool) | `Task<ProcessoCTeOS>` |  |
