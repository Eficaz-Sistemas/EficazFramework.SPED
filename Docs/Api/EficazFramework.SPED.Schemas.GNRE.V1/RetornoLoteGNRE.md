#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.GNRE.V1](EficazFramework.SPED.Schemas.GNRE.V1.md 'EficazFramework.SPED.Schemas.GNRE.V1')

## RetornoLoteGNRE Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | ambiente | `Ambiente` |  |
| 03 | situacaoRecepcao | `SituacaoRecepcao` |  |
| 04 | recibo | `ReciboLote` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| OnPropertyChanged(string) | `Void` |  |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, RetornoLoteGNRE, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, RetornoLoteGNRE) | `Boolean` |  |
| Deserialize(string) | `RetornoLoteGNRE` |  |
| Deserialize(Stream) | `RetornoLoteGNRE` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, RetornoLoteGNRE, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, RetornoLoteGNRE) | `Boolean` |  |
| LoadFrom(Stream) | `RetornoLoteGNRE` |  |
| LoadFromAsync(Stream) | `Task<RetornoLoteGNRE>` |  |
| LoadFromAsync(Stream, bool) | `Task<RetornoLoteGNRE>` |  |
