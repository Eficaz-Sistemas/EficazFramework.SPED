#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.CTeOS](EficazFramework.SPED.Schemas.CTeOS.md 'EficazFramework.SPED.Schemas.CTeOS')

## ProcessoCTeOS Class
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | CTeOS |  |
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
| CanDeserialize(string, ProcessoCTeOS, Exception) | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, ProcessoCTeOS) |  |
| Deserialize(string) |  |
| Deserialize(Stream) |  |
| CanSaveToFile(Stream, Exception) | Serializes current TNfeProc object into file |
| SaveTo(Stream) |  |
| SaveToAsync(Stream) |  |
| CanLoadFrom(Stream, ProcessoCTeOS, Exception) | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, ProcessoCTeOS) |  |
| LoadFrom(Stream, bool) |  |
| LoadFromAsync(Stream) |  |
| LoadFromAsync(Stream, bool) |  |
