#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.CTe](EficazFramework.SPED.Schemas.CTe.md 'EficazFramework.SPED.Schemas.CTe')

## ProtocoloAutorizacao Class
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | infProt |  |
| 03 | Signature |  |
| 04 | versao |  |
### Methods

| Name | |
| :--- | :--- |
| OnPropertyChanged(string) |  |
| Serialize() | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, ProtocoloAutorizacao, Exception) | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, ProtocoloAutorizacao) |  |
| Deserialize(string) |  |
| Deserialize(Stream) |  |
| CanSaveToFile(Stream, Exception) | Serializes current TNfeProc object into file |
| SaveTo(Stream) |  |
| SaveToAsync(Stream) |  |
| CanLoadFrom(Stream, ProtocoloAutorizacao, Exception) | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, ProtocoloAutorizacao) |  |
| LoadFrom(Stream) |  |
| LoadFromAsync(Stream) |  |
