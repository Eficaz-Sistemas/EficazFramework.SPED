#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFSe.BETHA](EficazFramework.SPED.Schemas.NFSe.BETHA.md 'EficazFramework.SPED.Schemas.NFSe.BETHA')

## ConsultarRpsResposta Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | Documentos | `tcListaNfse` |  |
| 03 | DocumentType | `XMLDocumentType` |  |
| 04 | DataEmissao | `Nullable<DateTime>` |  |
| 05 | Chave | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, ConsultarRpsResposta, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, ConsultarRpsResposta) | `Boolean` |  |
| Deserialize(string) | `ConsultarRpsResposta` |  |
| Deserialize(Stream) | `ConsultarRpsResposta` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, ConsultarRpsResposta, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, ConsultarRpsResposta) | `Boolean` |  |
| LoadFrom(Stream) | `ConsultarRpsResposta` |  |
| LoadFromAsync(Stream, bool) | `Task<ConsultarRpsResposta>` |  |
