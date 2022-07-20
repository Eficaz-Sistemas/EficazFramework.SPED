#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.GNRE.V1](EficazFramework.SPED.Schemas.GNRE.V1.md 'EficazFramework.SPED.Schemas.GNRE.V1')

## ReciboLote Class
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | numero |  |
| 03 | dataHoraRecibo |  |
| 04 | tempoEstimadoProc |  |
### Methods

| Name | |
| :--- | :--- |
| OnPropertyChanged(string) |  |
| Serialize() | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, ReciboLote, Exception) | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, ReciboLote) |  |
| Deserialize(string) |  |
| Deserialize(Stream) |  |
| CanSaveToFile(Stream, Exception) | Serializes current TNfeProc object into file |
| SaveTo(Stream) |  |
| SaveToAsync(Stream) |  |
| CanLoadFrom(Stream, ReciboLote, Exception) | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, ReciboLote) |  |
| LoadFrom(Stream) |  |
| LoadFromAsync(Stream) |  |
| LoadFromAsync(Stream, bool) |  |
