#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.CTe](EficazFramework.SPED.Schemas.CTe.md 'EficazFramework.SPED.Schemas.CTe')

## CTe Class
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
| CanDeserialize(string, CTe, Exception) | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, CTe) |  |
| Deserialize(string) |  |
| Deserialize(Stream) |  |
| CanSaveToFile(Stream, Exception) | Serializes current TNfeProc object into file |
| SaveTo(Stream) |  |
| SaveToAsync(Stream) |  |
| CanLoadFrom(Stream, CTe, Exception) | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, CTe) |  |
| LoadFrom(Stream, bool) |  |
| LoadFromAsync(Stream) |  |
| LoadFromAsync(Stream, bool) |  |
