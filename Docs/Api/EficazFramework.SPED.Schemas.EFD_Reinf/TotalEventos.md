#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_Reinf](EficazFramework.SPED.Schemas.EFD_Reinf.md 'EficazFramework.SPED.Schemas.EFD_Reinf')

## TotalEventos Class

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | evtTotal | `ReinfEvtTotal` |  |
| 03 | Signature | `SignatureType` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, TotalEventos, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, TotalEventos) | `Boolean` |  |
| Deserialize(string) | `TotalEventos` |  |
| Deserialize(Stream) | `TotalEventos` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, TotalEventos, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, TotalEventos) | `Boolean` |  |
| LoadFrom(Stream) | `TotalEventos` |  |
| LoadFromAsync(Stream) | `Task<TotalEventos>` |  |
