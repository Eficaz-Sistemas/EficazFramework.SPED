#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.CTe](EficazFramework.SPED.Schemas.CTe.md 'EficazFramework.SPED.Schemas.CTe')

## ProtocoloAutorizacao Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | infProt | `TProtCTeInfProt` |  |
| 03 | Signature | `SignatureType` |  |
| 04 | versao | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| OnPropertyChanged(string) | `Void` |  |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, ProtocoloAutorizacao, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, ProtocoloAutorizacao) | `Boolean` |  |
| Deserialize(string) | `ProtocoloAutorizacao` |  |
| Deserialize(Stream) | `ProtocoloAutorizacao` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, ProtocoloAutorizacao, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, ProtocoloAutorizacao) | `Boolean` |  |
| LoadFrom(Stream) | `ProtocoloAutorizacao` |  |
| LoadFromAsync(Stream) | `Task<ProtocoloAutorizacao>` |  |
