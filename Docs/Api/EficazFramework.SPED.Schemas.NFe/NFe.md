#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## NFe Class
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | InformacoesNFe |  |
| 03 | Signature |  |
| 04 | DocumentType |  |
| 05 | DataEmissao |  |
| 06 | Chave |  |
### Methods

| Name | |
| :--- | :--- |
| OnPropertyChanged(string) |  |
| Serialize() | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, NFe, Exception) | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, NFe) |  |
| Deserialize(string) |  |
| Deserialize(Stream) |  |
| CanSaveToFile(Stream, Exception) | Serializes current TNfeProc object into file |
| SaveTo(Stream) |  |
| SaveToAsync(Stream) |  |
| CanLoadFrom(Stream, NFe, Exception) | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, NFe) |  |
| LoadFrom(Stream, bool) |  |
| LoadFromAsync(Stream, bool) |  |
