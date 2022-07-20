#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.eSocial](EficazFramework.SPED.Schemas.eSocial.md 'EficazFramework.SPED.Schemas.eSocial')

## RetornoLoteEventos Class

Retorno ao chamado de envio dos eventos
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | DadosEnvio | `EnvioLoteEventos` |  |
| 03 | retornoEnvioLoteEventos | `eSocialRetornoEnvioLoteEventos` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, RetornoLoteEventos, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, RetornoLoteEventos) | `Boolean` |  |
| Deserialize(string) | `RetornoLoteEventos` |  |
| Deserialize(Stream) | `RetornoLoteEventos` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, RetornoLoteEventos, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, RetornoLoteEventos) | `Boolean` |  |
| LoadFrom(Stream) | `RetornoLoteEventos` |  |
| LoadFromAsync(Stream) | `Task<RetornoLoteEventos>` |  |
