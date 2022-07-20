#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.GNRE.V1](EficazFramework.SPED.Schemas.GNRE.V1.md 'EficazFramework.SPED.Schemas.GNRE.V1')

## SituacaoRecepcao Class
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
| CanDeserialize(string, SituacaoRecepcao, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, SituacaoRecepcao) | `Boolean` |  |
| Deserialize(string) | `SituacaoRecepcao` |  |
| Deserialize(Stream) | `SituacaoRecepcao` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, SituacaoRecepcao, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, SituacaoRecepcao) | `Boolean` |  |
| LoadFrom(Stream) | `SituacaoRecepcao` |  |
| LoadFromAsync(Stream) | `Task<SituacaoRecepcao>` |  |
| LoadFromAsync(Stream, bool) | `Task<SituacaoRecepcao>` |  |
