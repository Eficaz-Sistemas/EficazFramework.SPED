#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.GNRE.V1](EficazFramework.SPED.Schemas.GNRE.V1.md 'EficazFramework.SPED.Schemas.GNRE.V1')

## ResultadoLoteProcessamento Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | codigo | `String` |  |
| 03 | descricao | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| OnPropertyChanged(string) | `Void` |  |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, ResultadoLoteProcessamento, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, ResultadoLoteProcessamento) | `Boolean` |  |
| Deserialize(string) | `ResultadoLoteProcessamento` |  |
| Deserialize(Stream) | `ResultadoLoteProcessamento` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, ResultadoLoteProcessamento, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, ResultadoLoteProcessamento) | `Boolean` |  |
| LoadFrom(Stream) | `ResultadoLoteProcessamento` |  |
| LoadFromAsync(Stream) | `Task<ResultadoLoteProcessamento>` |  |
| LoadFromAsync(Stream, bool) | `Task<ResultadoLoteProcessamento>` |  |
