#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_Reinf](EficazFramework.SPED.Schemas.EFD_Reinf.md 'EficazFramework.SPED.Schemas.EFD_Reinf')

## EnvioLoteEventos Class

Envio dos eventos R-1000 ao R-2098
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | loteEventos | `ReinfLoteEventos` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
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
