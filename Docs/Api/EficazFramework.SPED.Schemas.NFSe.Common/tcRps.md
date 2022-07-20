#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFSe.Common](EficazFramework.SPED.Schemas.NFSe.Common.md 'EficazFramework.SPED.Schemas.NFSe.Common')

## tcRps Class
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | InfRps |  |
| 03 | Signature |  |
### Methods

| Name | |
| :--- | :--- |
| OnPropertyChanged(string) |  |
| Serialize() | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, tcRps, Exception) | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, tcRps) |  |
| Deserialize(string) |  |
| Deserialize(Stream) |  |
| CanSaveToFile(Stream, Exception) | Serializes current TNfeProc object into file |
| SaveTo(Stream) |  |
| SaveToAsync(Stream) |  |
| CanLoadFrom(Stream, tcRps, Exception) | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, tcRps) |  |
| LoadFrom(Stream) |  |
| LoadFromAsync(Stream, bool) |  |
