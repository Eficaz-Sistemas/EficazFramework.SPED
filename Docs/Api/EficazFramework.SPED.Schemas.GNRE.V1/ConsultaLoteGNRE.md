#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.GNRE.V1](EficazFramework.SPED.Schemas.GNRE.V1.md 'EficazFramework.SPED.Schemas.GNRE.V1')

## ConsultaLoteGNRE Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | ambiente | `Ambiente` |  |
| 03 | numeroRecibo | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| OnPropertyChanged(string) | `Void` |  |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, ConsultaLoteGNRE, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, ConsultaLoteGNRE) | `Boolean` |  |
| Deserialize(string) | `ConsultaLoteGNRE` |  |
| Deserialize(Stream) | `ConsultaLoteGNRE` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, ConsultaLoteGNRE, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, ConsultaLoteGNRE) | `Boolean` |  |
| LoadFrom(Stream) | `ConsultaLoteGNRE` |  |
| LoadFromAsync(Stream) | `Task<ConsultaLoteGNRE>` |  |
| LoadFromAsync(Stream, bool) | `Task<ConsultaLoteGNRE>` |  |
