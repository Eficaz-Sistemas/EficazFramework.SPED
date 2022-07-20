#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.GNRE.V2](EficazFramework.SPED.Schemas.GNRE.V2.md 'EficazFramework.SPED.Schemas.GNRE.V2')

## ResultadoLote Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | ambiente | `Ambiente` |  |
| 03 | numeroRecibo | `String` |  |
| 04 | situacaoProcess | `ResultadoLoteProcessamento` |  |
| 05 | resultado | `List<ResultadoGuiaGNRE>` |  |
| 06 | ResultadoProcessamento | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| OnPropertyChanged(string) | `Void` |  |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, ResultadoLote, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, ResultadoLote) | `Boolean` |  |
| Deserialize(string) | `ResultadoLote` |  |
| Deserialize(Stream) | `ResultadoLote` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, ResultadoLote, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, ResultadoLote) | `Boolean` |  |
| LoadFrom(Stream) | `ResultadoLote` |  |
| LoadFromAsync(Stream) | `Task<ResultadoLote>` |  |
| LoadFromAsync(Stream, bool) | `Task<ResultadoLote>` |  |
