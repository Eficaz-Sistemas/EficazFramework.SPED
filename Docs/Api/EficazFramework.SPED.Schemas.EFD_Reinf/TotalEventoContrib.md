#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_Reinf](EficazFramework.SPED.Schemas.EFD_Reinf.md 'EficazFramework.SPED.Schemas.EFD_Reinf')

## TotalEventoContrib Class

Retono ao chamado do evento R-5011
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | evtTotalContrib | `ReinfEvtTotalContrib` |  |
| 03 | Signature | `SignatureType` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, TotalEventoContrib, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, TotalEventoContrib) | `Boolean` |  |
| Deserialize(string) | `TotalEventoContrib` |  |
| Deserialize(Stream) | `TotalEventoContrib` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, TotalEventoContrib, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, TotalEventoContrib) | `Boolean` |  |
| LoadFrom(Stream) | `TotalEventoContrib` |  |
| LoadFromAsync(Stream) | `Task<TotalEventoContrib>` |  |
