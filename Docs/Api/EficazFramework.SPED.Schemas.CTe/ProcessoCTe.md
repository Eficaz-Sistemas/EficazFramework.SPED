#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.CTe](EficazFramework.SPED.Schemas.CTe.md 'EficazFramework.SPED.Schemas.CTe')

## ProcessoCTe Class
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | CTe |  |
| 03 | ProtocoloAutorizacao |  |
| 04 | Versao |  |
| 05 | DocumentType |  |
| 06 | DataEmissao |  |
| 07 | Chave |  |
### Methods

| Name | |
| :--- | :--- |
| OnPropertyChanged(string) |  |
| Serialize() | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, ProcessoCTe, Exception) | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, ProcessoCTe) |  |
| Deserialize(string) |  |
| Deserialize(Stream) |  |
| CanSaveToFile(Stream, Exception) | Serializes current TNfeProc object into file |
| SaveTo(Stream) |  |
| SaveToAsync(Stream) |  |
| CanLoadFrom(Stream, ProcessoCTe, Exception) | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, ProcessoCTe) |  |
| LoadFrom(Stream, bool) |  |
| LoadFromAsync(Stream) |  |
| LoadFromAsync(Stream, bool) |  |
