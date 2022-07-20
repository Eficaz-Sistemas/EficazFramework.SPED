#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.GNRE.V1](EficazFramework.SPED.Schemas.GNRE.V1.md 'EficazFramework.SPED.Schemas.GNRE.V1')

## ConsultaConfigUF Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | ambiente | `Ambiente` |  |
| 03 | uf | `UF` |  |
| 04 | receita | `ConsultaConfigUfReceita` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| OnPropertyChanged(string) | `Void` |  |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, ConsultaConfigUF, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, ConsultaConfigUF) | `Boolean` |  |
| Deserialize(string) | `ConsultaConfigUF` |  |
| Deserialize(Stream) | `ConsultaConfigUF` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, ConsultaConfigUF, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, ConsultaConfigUF) | `Boolean` |  |
| LoadFrom(Stream) | `ConsultaConfigUF` |  |
| LoadFromAsync(Stream) | `Task<ConsultaConfigUF>` |  |
| LoadFromAsync(Stream, bool) | `Task<ConsultaConfigUF>` |  |
