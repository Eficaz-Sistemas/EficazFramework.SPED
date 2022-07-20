#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.GNRE.V1](EficazFramework.SPED.Schemas.GNRE.V1.md 'EficazFramework.SPED.Schemas.GNRE.V1')

## ReciboLote Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | numero | `String` |  |
| 03 | dataHoraRecibo | `String` |  |
| 04 | tempoEstimadoProc | `Int32` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| OnPropertyChanged(string) | `Void` |  |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, ReciboLote, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, ReciboLote) | `Boolean` |  |
| Deserialize(string) | `ReciboLote` |  |
| Deserialize(Stream) | `ReciboLote` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, ReciboLote, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, ReciboLote) | `Boolean` |  |
| LoadFrom(Stream) | `ReciboLote` |  |
| LoadFromAsync(Stream) | `Task<ReciboLote>` |  |
| LoadFromAsync(Stream, bool) | `Task<ReciboLote>` |  |
