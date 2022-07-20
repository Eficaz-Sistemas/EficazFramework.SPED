#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFSe.GINFES](EficazFramework.SPED.Schemas.NFSe.GINFES.md 'EficazFramework.SPED.Schemas.NFSe.GINFES')

## ConsultarLoteRpsResposta2 Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | Documentos | `List<tcInfNfse>` |  |
| 03 | DocumentType | `XMLDocumentType` |  |
| 04 | DataEmissao | `Nullable<DateTime>` |  |
| 05 | Chave | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, ConsultarLoteRpsResposta2, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, ConsultarLoteRpsResposta2) | `Boolean` |  |
| Deserialize(string) | `ConsultarLoteRpsResposta2` |  |
| Deserialize(Stream) | `ConsultarLoteRpsResposta2` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, ConsultarLoteRpsResposta2, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, ConsultarLoteRpsResposta2) | `Boolean` |  |
| LoadFrom(Stream) | `ConsultarLoteRpsResposta2` |  |
| LoadFromAsync(Stream, bool) | `Task<ConsultarLoteRpsResposta2>` |  |
