#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFSe.GINFES](EficazFramework.SPED.Schemas.NFSe.GINFES.md 'EficazFramework.SPED.Schemas.NFSe.GINFES')

## ConsultarLoteRpsResposta Class

### Remarks
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
| CanDeserialize(string, ConsultarLoteRpsResposta, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, ConsultarLoteRpsResposta) | `Boolean` |  |
| Deserialize(string) | `ConsultarLoteRpsResposta` |  |
| Deserialize(Stream) | `ConsultarLoteRpsResposta` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, ConsultarLoteRpsResposta, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, ConsultarLoteRpsResposta) | `Boolean` |  |
| LoadFrom(Stream) | `ConsultarLoteRpsResposta` |  |
| LoadFromAsync(Stream, bool) | `Task<ConsultarLoteRpsResposta>` |  |
