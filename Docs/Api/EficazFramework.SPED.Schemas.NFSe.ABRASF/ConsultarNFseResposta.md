#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFSe.ABRASF](EficazFramework.SPED.Schemas.NFSe.ABRASF.md 'EficazFramework.SPED.Schemas.NFSe.ABRASF')

## ConsultarNFseResposta Class

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
| CanDeserialize(string, ConsultarNFseResposta, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, ConsultarNFseResposta) | `Boolean` |  |
| Deserialize(string) | `ConsultarNFseResposta` |  |
| Deserialize(Stream) | `ConsultarNFseResposta` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, ConsultarNFseResposta, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, ConsultarNFseResposta) | `Boolean` |  |
| LoadFrom(Stream) | `ConsultarNFseResposta` |  |
| LoadFromAsync(Stream, bool) | `Task<ConsultarNFseResposta>` |  |
