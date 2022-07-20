#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFSe.Common](EficazFramework.SPED.Schemas.NFSe.Common.md 'EficazFramework.SPED.Schemas.NFSe.Common')

## NFSe Class
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | InfNfse |  |
| 03 | Signature |  |
| 04 | DocumentType |  |
| 05 | DataEmissao |  |
| 06 | Chave |  |
### Methods

| Name | |
| :--- | :--- |
| OnPropertyChanged(string) |  |
| Serialize() | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, NFSe, Exception) | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, NFSe) |  |
| Deserialize(string) |  |
| Deserialize(Stream) |  |
| CanSaveToFile(Stream, Exception) | Serializes current TNfeProc object into file |
| SaveTo(Stream) |  |
| SaveToAsync(Stream) |  |
| CanLoadFrom(Stream, NFSe, Exception) | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, NFSe) |  |
| LoadFrom(Stream) |  |
| LoadFromAsync(Stream, bool) |  |
