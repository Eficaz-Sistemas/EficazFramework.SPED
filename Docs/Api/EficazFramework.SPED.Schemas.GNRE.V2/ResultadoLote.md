#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.GNRE.V2](EficazFramework.SPED.Schemas.GNRE.V2.md 'EficazFramework.SPED.Schemas.GNRE.V2')

## ResultadoLote Class
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | ambiente |  |
| 03 | numeroRecibo |  |
| 04 | situacaoProcess |  |
| 05 | resultado |  |
| 06 | ResultadoProcessamento |  |
### Methods

| Name | |
| :--- | :--- |
| OnPropertyChanged(string) |  |
| Serialize() | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, ResultadoLote, Exception) | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, ResultadoLote) |  |
| Deserialize(string) |  |
| Deserialize(Stream) |  |
| CanSaveToFile(Stream, Exception) | Serializes current TNfeProc object into file |
| SaveTo(Stream) |  |
| SaveToAsync(Stream) |  |
| CanLoadFrom(Stream, ResultadoLote, Exception) | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, ResultadoLote) |  |
| LoadFrom(Stream) |  |
| LoadFromAsync(Stream) |  |
| LoadFromAsync(Stream, bool) |  |
