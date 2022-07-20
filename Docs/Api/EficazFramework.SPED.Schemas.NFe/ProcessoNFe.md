#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## ProcessoNFe Class
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | NFe |  |
| 03 | ProtocoloAutorizacao |  |
| 04 | Versao |  |
| 05 | DocumentType |  |
| 06 | DataEmissao |  |
| 07 | Chave |  |
### Methods

| Name | |
| :--- | :--- |
| RefreshSerializer() |  |
| OnPropertyChanged(string) |  |
| ToString() |  |
| Serialize() | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, ProcessoNFe, Exception) | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, ProcessoNFe) |  |
| Deserialize(string) |  |
| Deserialize(Stream) |  |
| CanSaveToFile(Stream, Exception) | Serializes current TNfeProc object into file |
| SaveTo(Stream) |  |
| SaveToAsync(Stream) |  |
| CanLoadFrom(Stream, ProcessoNFe, Exception) | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, ProcessoNFe) |  |
| LoadFrom(Stream, bool) |  |
| LoadFromAsync(Stream, bool) |  |
