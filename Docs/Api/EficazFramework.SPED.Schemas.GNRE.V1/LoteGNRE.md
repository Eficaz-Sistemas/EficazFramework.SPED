#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.GNRE.V1](EficazFramework.SPED.Schemas.GNRE.V1.md 'EficazFramework.SPED.Schemas.GNRE.V1')

## LoteGNRE Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | guias | `ObservableCollection<GuiaGNRE>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| OnPropertyChanged(string) | `Void` |  |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, LoteGNRE, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, LoteGNRE) | `Boolean` |  |
| Deserialize(string) | `LoteGNRE` |  |
| Deserialize(Stream) | `LoteGNRE` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, LoteGNRE, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, LoteGNRE) | `Boolean` |  |
| LoadFrom(Stream) | `LoteGNRE` |  |
| LoadFromAsync(Stream) | `Task<LoteGNRE>` |  |
| LoadFromAsync(Stream, bool) | `Task<LoteGNRE>` |  |
