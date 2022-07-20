#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.GNRE.V1](EficazFramework.SPED.Schemas.GNRE.V1.md 'EficazFramework.SPED.Schemas.GNRE.V1')

## ConsultaConfigUfReceita Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | courier | `PTBrBoolean` |  |
| 03 | courierSpecified | `Boolean` |  |
| 04 | Value | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| OnPropertyChanged(string) | `Void` |  |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, ConsultaConfigUfReceita, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, ConsultaConfigUfReceita) | `Boolean` |  |
| Deserialize(string) | `ConsultaConfigUfReceita` |  |
| Deserialize(Stream) | `ConsultaConfigUfReceita` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, ConsultaConfigUfReceita, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, ConsultaConfigUfReceita) | `Boolean` |  |
| LoadFrom(Stream) | `ConsultaConfigUfReceita` |  |
| LoadFromAsync(Stream) | `Task<ConsultaConfigUfReceita>` |  |
| LoadFromAsync(Stream, bool) | `Task<ConsultaConfigUfReceita>` |  |
