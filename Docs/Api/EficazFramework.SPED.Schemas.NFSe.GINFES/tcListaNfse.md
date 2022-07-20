#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFSe.GINFES](EficazFramework.SPED.Schemas.NFSe.GINFES.md 'EficazFramework.SPED.Schemas.NFSe.GINFES')

## tcListaNfse Class
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | Items |  |
| 03 | DocumentType |  |
| 04 | DataEmissao |  |
| 05 | Chave |  |
### Methods

| Name | |
| :--- | :--- |
| OnPropertyChanged(string) |  |
| Serialize() | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, tcListaNfse, Exception) | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, tcListaNfse) |  |
| Deserialize(string) |  |
| Deserialize(Stream) |  |
| CanSaveToFile(Stream, Exception) | Serializes current TNfeProc object into file |
| SaveTo(Stream) |  |
| SaveToAsync(Stream) |  |
| CanLoadFrom(Stream, tcListaNfse, Exception) | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, tcListaNfse) |  |
| LoadFrom(Stream) |  |
| LoadFromAsync(Stream, bool) |  |
