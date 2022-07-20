#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.CTeOS](EficazFramework.SPED.Schemas.CTeOS.md 'EficazFramework.SPED.Schemas.CTeOS')

## CTeOS Class
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | Informacoes |  |
| 03 | Signature |  |
| 04 | DocumentType |  |
| 05 | DataEmissao |  |
| 06 | Chave |  |
### Methods

| Name | |
| :--- | :--- |
| OnPropertyChanged(string) |  |
| Serialize() | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, CTeOS, Exception) | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, CTeOS) |  |
| Deserialize(string) |  |
| Deserialize(Stream) |  |
| CanSaveToFile(Stream, Exception) | Serializes current TNfeProc object into file |
| SaveTo(Stream) |  |
| SaveToAsync(Stream) |  |
| CanLoadFrom(Stream, CTeOS, Exception) | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, CTeOS) |  |
| LoadFrom(Stream, bool) |  |
| LoadFromAsync(Stream) |  |
| LoadFromAsync(Stream, bool) |  |
