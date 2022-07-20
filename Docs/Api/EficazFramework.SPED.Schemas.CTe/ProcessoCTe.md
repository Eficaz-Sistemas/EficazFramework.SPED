#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.CTe](EficazFramework.SPED.Schemas.CTe.md 'EficazFramework.SPED.Schemas.CTe')

## ProcessoCTe Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | CTe | `CTe` |  |
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
| CanDeserialize(string, ProcessoCTe, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, ProcessoCTe) | `Boolean` |  |
| Deserialize(string) | `ProcessoCTe` |  |
| Deserialize(Stream) | `ProcessoCTe` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, ProcessoCTe, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, ProcessoCTe) | `Boolean` |  |
| LoadFrom(Stream, bool) | `ProcessoCTe` |  |
| LoadFromAsync(Stream) | `Task<ProcessoCTe>` |  |
| LoadFromAsync(Stream, bool) | `Task<ProcessoCTe>` |  |
