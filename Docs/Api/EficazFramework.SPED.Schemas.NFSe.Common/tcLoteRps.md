#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFSe.Common](EficazFramework.SPED.Schemas.NFSe.Common.md 'EficazFramework.SPED.Schemas.NFSe.Common')

## tcLoteRps Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | NumeroLote | `String` |  |
| 03 | Cnpj | `String` |  |
| 04 | InscricaoMunicipal | `String` |  |
| 05 | QuantidadeRps | `Int32` |  |
| 06 | ListaRps | `List<tcRps>` |  |
| 07 | Id | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| OnPropertyChanged(string) | `Void` |  |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, tcLoteRps, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, tcLoteRps) | `Boolean` |  |
| Deserialize(string) | `tcLoteRps` |  |
| Deserialize(Stream) | `tcLoteRps` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, tcLoteRps, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, tcLoteRps) | `Boolean` |  |
| LoadFrom(Stream) | `tcLoteRps` |  |
| LoadFromAsync(Stream, bool) | `Task<tcLoteRps>` |  |
