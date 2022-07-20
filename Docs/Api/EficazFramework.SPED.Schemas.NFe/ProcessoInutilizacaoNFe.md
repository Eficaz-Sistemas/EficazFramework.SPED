#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## ProcessoInutilizacaoNFe Class

### Remarks
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | Inutilizacao |  |
| 03 | RetornoInutilizacao |  |
| 04 | versao |  |
| 05 | DocumentType |  |
| 06 | DataEmissao |  |
| 07 | Chave |  |
### Methods

| Name | |
| :--- | :--- |
| Serialize() | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, ProcessoInutilizacaoNFe, Exception) | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, ProcessoInutilizacaoNFe) |  |
| Deserialize(string) |  |
| Deserialize(Stream) |  |
| CanSaveToFile(Stream, Exception) | Serializes current TNfeProc object into file |
| SaveTo(Stream) |  |
| SaveToAsync(Stream) |  |
| CanLoadFrom(Stream, ProcessoInutilizacaoNFe, Exception) | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, ProcessoInutilizacaoNFe) |  |
| LoadFrom(Stream) |  |
| LoadFromAsync(Stream) |  |
| LoadFromAsync(Stream, bool) |  |
