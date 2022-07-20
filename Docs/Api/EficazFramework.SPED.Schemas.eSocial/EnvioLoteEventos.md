#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.eSocial](EficazFramework.SPED.Schemas.eSocial.md 'EficazFramework.SPED.Schemas.eSocial')

## EnvioLoteEventos Class

Envio dos eventos
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | envioLoteEventos | `eSocialEnvioLoteEventos` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| LoadFromXDocument(XDocument) | `EnvioLoteEventos` |  |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, EnvioLoteEventos, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, EnvioLoteEventos) | `Boolean` |  |
| Deserialize(string) | `EnvioLoteEventos` |  |
| Deserialize(Stream) | `EnvioLoteEventos` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, EnvioLoteEventos, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, EnvioLoteEventos) | `Boolean` |  |
| LoadFrom(Stream) | `EnvioLoteEventos` |  |
| LoadFromAsync(Stream) | `Task<EnvioLoteEventos>` |  |
