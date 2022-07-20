#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.eSocial](EficazFramework.SPED.Schemas.eSocial.md 'EficazFramework.SPED.Schemas.eSocial')

## ConsultaLoteEventos Class

Consulta de lote de eventos
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | consultaLoteEventos | `eSocialConsultaLoteEventos` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, ConsultaLoteEventos, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, ConsultaLoteEventos) | `Boolean` |  |
| Deserialize(string) | `ConsultaLoteEventos` |  |
| Deserialize(Stream) | `ConsultaLoteEventos` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, ConsultaLoteEventos, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, ConsultaLoteEventos) | `Boolean` |  |
| LoadFrom(Stream) | `ConsultaLoteEventos` |  |
| LoadFromAsync(Stream) | `Task<ConsultaLoteEventos>` |  |
