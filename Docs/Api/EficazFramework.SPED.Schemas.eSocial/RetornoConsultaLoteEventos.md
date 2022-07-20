#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.eSocial](EficazFramework.SPED.Schemas.eSocial.md 'EficazFramework.SPED.Schemas.eSocial')

## RetornoConsultaLoteEventos Class

Retorno á consulta de lote de eventos
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | retornoProcessamentoLoteEventos | `eSocialRetornoProcessamentoLoteEventos` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, RetornoConsultaLoteEventos, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, RetornoConsultaLoteEventos) | `Boolean` |  |
| Deserialize(string) | `RetornoConsultaLoteEventos` |  |
| Deserialize(Stream) | `RetornoConsultaLoteEventos` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, RetornoConsultaLoteEventos, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, RetornoConsultaLoteEventos) | `Boolean` |  |
| LoadFrom(Stream) | `RetornoConsultaLoteEventos` |  |
| LoadFromAsync(Stream) | `Task<RetornoConsultaLoteEventos>` |  |
